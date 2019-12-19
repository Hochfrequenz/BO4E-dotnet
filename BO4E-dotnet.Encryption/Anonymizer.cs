using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using BO4E.BO;
using BO4E.Extensions.BusinessObjects;
using BO4E.meta;
using Microsoft.CSharp.RuntimeBinder;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Crypto;

namespace BO4E.Extensions.Encryption
{
    public class Anonymizer : IDisposable
    {
        private static ILogger _logger = StaticLogger.Logger;
        private readonly AnonymizerConfiguration configuration;
        public X509Certificate2 publicKeyX509 { get; set; }
        private AsymmetricKeyParameter privateKey;
        private byte[] hashingSalt;

        public Anonymizer(AnonymizerConfiguration configuration)
        {
            this.configuration = configuration;
            if (this.configuration.hashingSalt != null)
            {
                this.SetHashingSalt(configuration.GetSalt());
            }
        }

        /// <summary>
        /// Set the receivers public X509 certificate if ENCRYPT is used as anonymizing approach.
        /// </summary>
        /// <param name="x509Certificate">X509 certificate</param>
        public void SetPublicKey(X509Certificate2 x509Certificate)
        {
            this.publicKeyX509 = x509Certificate;
        }

        /// <summary>
        /// Set the private key if DECRYPT is used as anonymizing approach.
        /// </summary>
        /// <param name="privateKey">Bouncy Castle compatible private key</param>
        public void SetPrivateKey(AsymmetricKeyParameter privateKey)
        {
            this.privateKey = privateKey;
        }

        /// <summary>
        /// Set a salt used when hashing values.
        /// </summary>
        /// <remarks>
        /// Note that the same salt is used multiple times, at least within the same processed JObject!
        /// This is a considerable security weakness that allows for attacks, especially when the origin
        /// domain is finite (e.g. when ENUM based values are hashed). This design decision was made because
        /// handling a separate salt for each hashed field is impractical. Please opt for the <see cref="AnonymizerApproach.ENCRYPT"/>
        /// option in case of doubt. The use of a salt is enforced by throwing a ArgumentNullException when
        /// trying to hash ENUM based values without having set a salt before.
        /// </remarks>
        /// <seealso cref="GenerateHashingSalt"/>
        /// <param name="salt">random salt as byte array</param>
        public void SetHashingSalt(byte[] salt)
        {
            this.hashingSalt = salt;
        }

        /// <summary>
        /// passes the result of <see cref="GenerateHashingSalt"/> to <see cref="SetHashingSalt(byte[])"/>
        /// </summary>
        public void SetNewHashingSalt()
        {
            SetHashingSalt(GenerateHashingSalt());
        }

        /// <summary>
        /// Generates a 32 byte long salt to be used as input for <see cref="SetHashingSalt(byte[])"/>.
        /// </summary>
        /// <returns>a 32 byte long securely random salt</returns>
        public static byte[] GenerateHashingSalt()
        {
            byte[] salt = new byte[32];
            using (var random = new RNGCryptoServiceProvider())
            {
                random.GetNonZeroBytes(salt);
            }
            return salt;
        }

        public T ApplyOperations<T>(JObject jobject)
        {
            BusinessObject bo = BoMapper.MapObject(jobject, LenientParsing.MOST_LENIENT);
            return ApplyOperations<T>(bo);
        }

        /// <summary>
        /// Apply the configuration set in the constructor to the JObject set in the constructor.
        /// </summary>
        /// <see cref="Anonymizer(AnonymizerConfiguration)"/>
        /// <returns>A modified JObject with the configuration applied.</returns>
        public T ApplyOperations<T>(BusinessObject bo)
        {
            if (bo == null)
            {
                throw new ArgumentNullException(nameof(bo));
            }
            Dictionary<DataCategory, AnonymizerApproach> mapping = configuration.operations;
            BusinessObject result = bo.DeepClone<BusinessObject>();
            foreach (DataCategory dataCategory in mapping.Keys)
            {
                AnonymizerApproach approach = mapping[dataCategory];
                FieldInfo[] affectedFields = BoMapper.GetAnnotatedFields(bo.GetType());
                foreach (FieldInfo affectedField in affectedFields)
                {
                    if (!affectedField.IsAnonymizerRelevant(approach, dataCategory))
                    {
                        continue;
                    }
                    switch (approach)
                    {
                        case AnonymizerApproach.HASH:
                            try
                            {
                                object affectedFieldValue = affectedField.GetValue(result);
                                HashObject(ref affectedFieldValue, dataCategory);
                                affectedField.SetValue(result, affectedFieldValue);
                            }
                            catch (RuntimeBinderException e)
                            {
                                _logger.LogWarning($"Catched RuntimeBinderException in Object {bo.GetBoTyp()}. Probably due to trying to get the type of a null object BO: {e.Message}");
                            }
                            break;
                        case AnonymizerApproach.DELETE:
                            /* We'd like to set the value to null, but the business object might not allow
                             * it resulting in a JsonSerializationException. That's why we first check, 
                             * whether the field is actually required. If it has to be non-null we set the
                             * annotated default value, otherwise we can safely set null. */
                            bool isRequired = false;
                            Attribute defaultValueAttribute = null;
                            Attribute jsonPropertyAttribute = affectedField.GetCustomAttributes().Where(a => a.GetType() == typeof(JsonPropertyAttribute)).FirstOrDefault();
                            if (jsonPropertyAttribute != null)
                            {
                                JsonPropertyAttribute jpa = (JsonPropertyAttribute)jsonPropertyAttribute;
                                if (jpa.Required == Required.Always)
                                {
                                    isRequired = true;
                                    defaultValueAttribute = affectedField.GetCustomAttributes().Where(a => a.GetType() == typeof(DefaultValueAttribute)).FirstOrDefault();
                                }
                            }

                            if (isRequired && defaultValueAttribute != null)
                            {
                                DefaultValueAttribute dva = (DefaultValueAttribute)defaultValueAttribute;
                                affectedField.SetValue(result, dva.Value);
                            }
                            else if (bo.GetType().IsSubclassOf(typeof(BO4E.BO.BusinessObject)))
                            {
                                // e.g. 1*Energiemenge (mappedObject)---> n*Verbrauch (boSubObject)
                                var boSubObject = affectedField.GetValue(bo);
                                if (boSubObject != null)
                                {
                                    try
                                    {
                                        if (boSubObject.GetType().IsGenericType && boSubObject.GetType().GetGenericTypeDefinition() == typeof(List<>))
                                        {
                                            Type listElementType = boSubObject.GetType().GetGenericArguments()[0];
                                            Type listType = typeof(List<>).MakeGenericType(listElementType);
                                            object newEmptyList = Activator.CreateInstance(listType);
                                            boSubObject = newEmptyList;
                                        }
                                        else
                                        {
                                            boSubObject = null;
                                        }
                                    }
                                    catch (RuntimeBinderException e)
                                    {
                                        _logger.LogError($"Couldn't null BO field!: {e.Message}");
                                    }
                                    affectedField.SetValue(result, boSubObject);
                                }
                            }
                            else
                            {
                                // strings, integers, elementary
                                affectedField.SetValue(result, null);
                            }
                            break;
                        case AnonymizerApproach.ENCRYPT:
                            if (this.publicKeyX509 == null)
                            {
                                throw new ArgumentNullException("To use the encryption feature you have to provide a public X509 certificate using the SetPublicKey method.");
                            }
                            using (X509AsymmetricEncrypter xasyncenc = new X509AsymmetricEncrypter(this.publicKeyX509))
                            {
                                if (affectedField.GetValue(bo).GetType() == typeof(string))
                                {
                                    if (affectedField.GetValue(bo) != null)
                                    {
                                        affectedField.SetValue(result, xasyncenc.Encrypt(affectedField.GetValue(bo).ToString()));
                                    }
                                }
                                else if (affectedField.GetValue(bo).GetType().IsSubclassOf(typeof(BO4E.COM.COM)))
                                {
                                    var comObject = affectedField.GetValue(bo);
                                    dynamic comFields = comObject.GetType().GetFields();
                                    foreach (dynamic comField in comFields)
                                    {
                                        try
                                        {
                                            comField.SetValue(comObject, xasyncenc.Encrypt(comField.GetValue(comObject)).ToString());
                                        }
                                        catch (ArgumentException e)
                                        {
                                            // das sollte passieren, wenn das Argument kein String is und deswegen das encrypten kein sinn macht
                                            _logger.LogError($"Couldn't encrypt COM field!: {e.Message}");
                                        }
                                        catch (Exception f)
                                        {
                                            // das sollte passieren, wenn das Argument ein enum
                                            _logger.LogError($"Couldn't encrypt COM field!: {f.Message}");
                                        }
                                    }
                                    affectedField.SetValue(result, comObject);
                                }
                                else if (affectedField.FieldType.IsSubclassOf(typeof(BO4E.BO.BusinessObject)))
                                {
                                    affectedField.SetValue(result, xasyncenc.Encrypt((BusinessObject)affectedField.GetValue(bo)));
                                }
                                else if (affectedField.FieldType.ToString().StartsWith("BO4E.ENUM")) // todo: check for namespace instead of strinyfied comparison
                                {
                                    //affectedField.SetValue(mappedObject, Sha256HashEnum(affectedField.GetValue(mappedObject).ToString()));
                                    _logger.LogWarning($"Encrypting {affectedField.FieldType} is not supported, since the result would not be a valid ENUM value.");
                                    //throw new NotSupportedException($"Hashing {affectedField.FieldType} is not supported, since the result would not be a valid ENUM value.");
                                }
                                else
                                {
                                    throw new NotImplementedException($"Encrypting {affectedField.FieldType} is not implemented yet.");
                                }
                            }
                            break;
                        case AnonymizerApproach.DECRYPT:
                            if (this.privateKey == null)
                            {
                                throw new ArgumentNullException("To use the decryption feature you have to provide a private key using the SetPrivateKey method.");
                            }
                            using (X509AsymmetricEncrypter xasydec = new X509AsymmetricEncrypter(this.privateKey))
                            {
                                affectedField.SetValue(result, xasydec.Decrypt(affectedField.GetValue(bo).ToString()));
                            }
                            continue;
                        case AnonymizerApproach.KEEP:
                            // do nothing
                            continue;
                        default:
                            continue;
                    }
                }
            }
            if (typeof(T) == typeof(JObject))
            {
                return (T)(object)JObject.FromObject(result);
            }
            return (T)(object)result;
        }

        /// <summary>
        /// Applies recursive Hashing on <paramref name="input"/> for all fields of given DataCategory <paramref name="dataCategory"/>
        /// </summary>
        /// <param name="input">object to be hashed (will be modified by reference)</param>
        /// <param name="dataCategory">Category of fields to be modified</param>
        protected void HashObject(ref object input, DataCategory? dataCategory = null)
        {
            if (input == null)
            {
                return;
            }
            Type inputType = input.GetType();
            if (inputType == typeof(string))
            {
                string inputString = (string)input;
                HashString(ref inputString, dataCategory);
                input = inputString;
            }
            /*else if (inputType == typeof(JValue)) // entry of BusinessObject.userProperties
            {
                string inputString = ((JValue)input).Value<string>();
                HashString(ref inputString, dataCategory);
                input = JToken.FromObject(inputString);
            }*/
            else if (inputType == typeof(Int32))
            {
                _logger.LogWarning($"Hashing {inputType} is not supported.");
            }
            else if (inputType.ToString().StartsWith("BO4E.ENUM"))
            {
                //affectedField.SetValue(mappedObject, Sha256HashEnum(affectedField.GetValue(mappedObject).ToString()));
                _logger.LogWarning($"Hashing {inputType} is not supported, since the result would not be a valid ENUM value.");
                //throw new NotSupportedException($"Hashing {affectedField.FieldType} is not supported, since the result would not be a valid ENUM value.");
            }
            else if (inputType.IsGenericType && inputType.GetGenericTypeDefinition() == typeof(List<>))
            {
                IList inputList = input as IList;
                for (int i = 0; i < inputList.Count; i++)
                {
                    object listItem = inputList[i] as object;
                    HashObject(ref listItem, dataCategory);
                    inputList[i] = listItem;
                }
            }
            else if (typeof(IDictionary<string, JToken>).IsAssignableFrom(inputType)) // typeof BusinessObject.userProperties
            {
                dynamic dict = input as IDictionary<string, JToken>;
                foreach (var dictKey in ((ICollection<string>)dict.Keys).ToList().Where(key => !configuration.unaffectedUserProperties.Contains(key)))
                {
                    if (dict[dictKey] != null)
                    {
                        string inputString = ((JValue)dict[dictKey]).Value<string>();
                        HashString(ref inputString, dataCategory);
                        dict[dictKey] = JToken.FromObject(inputString);
                        /*//dict[dictKey].Set(dict[dictKey].ToString());
                        HashObject(ref dict[dictKey]);
                        string newValue = dict[dictKey].ToString();
                        dict.Remove(dictKey);
                        dict.Add(dictKey, newValue);*/
                    }
                }
                input = dict;
            }
            else
            {
                var fields = inputType.GetFields();
                foreach (var field in fields)
                {
                    if (field.GetValue(input) == null || !field.IsHashingRelevant(dataCategory))
                    {
                        continue;
                    }
                    try
                    {
                        object o = field.GetValue(input);
                        HashObject(ref o, dataCategory);
                        field.SetValue(input, o);
                    }
                    catch (Exception f)
                    {
                        throw new ArgumentException($"Couldn't hash field {field.Name}: {f.Message}");
                    }
                }
                if (fields.Count() == 0)
                {
                    throw new NotImplementedException($"Type {inputType} with value '{input}' has no subfields but is not handled separately.");
                }
            }
        }

        /// <summary>
        /// instead of 'DE' oder another country code messlokationIds that are a hashed/pseudonymized value do start with this prefix.
        /// </summary>
        protected const string HASHED_MESSLOKATION_PREFIX = "XX";

        /// <summary>
        /// instead of '5' or '4' marktlokationIds that are a hashed/pseudonymized value do start with this prefix.
        /// </summary>
        protected const string HASHED_MARKTLOKATION_PREFIX = "9";

        /// <summary>
        /// Applies hashing on string value
        /// </summary>
        /// <param name="input">string that is going to be hashed</param>
        /// <returns>new string containing hashed content</returns>
        protected void HashString(ref string input, DataCategory? dataCategory)
        {
            string hashedValue;
            if (dataCategory.HasValue && dataCategory.Value == DataCategory.POD)
            {
                if (Messlokation.ValidateId(input) || input.Length == 33)
                {
                    string base36String = Sha256Hash(input, BASE36_ALPHABET);
                    hashedValue = $"{HASHED_MESSLOKATION_PREFIX}{base36String.Substring(0, 31)}";
                    Debug.Assert(Messlokation.ValidateId(hashedValue));
                }
                else if (Marktlokation.ValidateId(input) || input.Length == 11)
                {
                    string base10String = Sha256Hash(input, BASE10_ALPHABET);
                    base10String = $"{HASHED_MARKTLOKATION_PREFIX}{base10String.Substring(0, 9)}";
                    string checkSum = Marktlokation.GetChecksum(base10String);
                    hashedValue = base10String + checkSum;
                    Debug.Assert(Marktlokation.ValidateId(hashedValue));
                }
                else
                {
                    hashedValue = Sha256Hash(input);
                }
            }
            else
            {
                hashedValue = Sha256Hash(input);
            }
            input = hashedValue;
        }

        /// <summary>
        /// check if a Marktlokation has been pseudonymized using <see cref="AnonymizerApproach.HASH"/>.
        /// As of 2019 it's impossible for a "real" Marktlokation to fulfill this condition. 
        /// </summary>
        /// <param name="ma">Marktlokation</param>
        /// <returns>true if the <see cref="Marktlokation.marktlokationsId"/> fulfills the requirements of a hashed key</returns>
        public static bool HasHashedKey(Marktlokation ma)
        {
            return !string.IsNullOrWhiteSpace(ma.marktlokationsId) && ma.marktlokationsId.StartsWith(HASHED_MARKTLOKATION_PREFIX);
        }
        /// <summary>
        /// check if a Messlokation has been pseudonymized using <see cref="AnonymizerApproach.HASH"/>
        /// As of 2019 it's impossible for a "real" Messlokation to fulfill this condition.
        /// </summary>
        /// <param name="me">Messlokation</param>
        /// <returns>true if the <see cref="Messlokation.messlokationsId"/> fulfills the requirements of a hashed key</returns>
        public static bool HasHashedKey(Messlokation me)
        {
            return !string.IsNullOrWhiteSpace(me.messlokationsId) && me.messlokationsId.StartsWith(HASHED_MESSLOKATION_PREFIX);
        }

        /// <summary>
        /// check if an Energiemenge been pseudonymized using <see cref="AnonymizerApproach.HASH"/>.
        /// Calls <see cref="IsHashedKey(string)"/> for <see cref="Energiemenge.lokationsId"/>.
        /// </summary>
        /// <param name="em">Energiemenge</param>
        /// <returns>true if the <see cref="Energiemenge.lokationsId"/> fulfills the requirements of a hashed key</returns>
        public static bool HasHashedKey(Energiemenge em)
        {
            return IsHashedKey(em.lokationsId);
        }

        /// <summary>
        /// Checks if a stright might originate from <see cref="AnonymizerApproach.HASH"/>
        /// </summary>
        /// <param name="key">a string, e.g. '54321012345'</param>
        /// <returns>true if the <paramref name="key"/> could originate from hashing.</returns>
        public static bool IsHashedKey(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return false;
            }
            if ((Marktlokation.ValidateId(key) && key.StartsWith(HASHED_MARKTLOKATION_PREFIX)) ||
                (Messlokation.ValidateId(key) && key.StartsWith(HASHED_MESSLOKATION_PREFIX)))
            {
                return true;
            }
            else
            {
                byte[] bytes;
                try
                {
                    bytes = Convert.FromBase64String(key);
                }
                catch (FormatException)
                {
                    return false;
                }
                return true; // Todo: fix this
                             //return bytes.Length == 256 / 8; // sha256 = 256 bits
            }
        }

        // https://stackoverflow.com/questions/16999361/obtain-sha-256-string-of-a-string
        private byte[] Sha256HashBytes(string value)
        {
            byte[] hashedByteArray;
            using (SHA256 hash = SHA256Managed.Create())
            {
                if (hashingSalt != null)
                {
                    hashedByteArray = hash.ComputeHash(Encoding.UTF8.GetBytes(value + Convert.ToBase64String(hashingSalt)));
                }
                else
                {
                    //_logger.LogWarning("Hashing without a salt.");
                    hashedByteArray = hash.ComputeHash(Encoding.UTF8.GetBytes(value));
                }
            }
            return hashedByteArray;
        }

        private string Sha256Hash(string value, string alphabet = null)
        {
            if (alphabet == null)
            {
                return string.Concat(Sha256HashBytes(value).Select(item => item.ToString("x2")));
            }
            else
            {
                return Sha256HashBytes(value).ToBaseXString(alphabet);
            }
        }

        private const string BASE36_ALPHABET = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string BASE10_ALPHABET = "0123456789";

        /// <inheritdoc/>
        public void Dispose()
        {
            this.privateKey = null;
            if (hashingSalt != null)
            {
                for (int i = 0; i < hashingSalt.Length; i++)
                {
                    hashingSalt[i] = 0x0;
                }
            }
        }

        ~Anonymizer()
        {
            Dispose();
        }
    }
}
