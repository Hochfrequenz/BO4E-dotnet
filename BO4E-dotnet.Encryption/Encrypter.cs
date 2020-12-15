using BO4E.BO;
using BO4E.meta;

using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

using System;

namespace BO4E.Extensions.Encryption
{
    /// <summary>
    /// abstract base class of all encryption classes; provides useful methods for derived encryption classes
    /// </summary>
    public abstract class Encrypter : IDisposable
    {
        /// <summary>
        /// serializer settings used in the encrypted objects
        /// </summary>
        protected static JsonSerializerSettings encryptionSerializerSettings = new JsonSerializerSettings()
        {
            TypeNameHandling = TypeNameHandling.Objects,
            SerializationBinder = new BusinessObjectSerializationBinder()
        };

        public ILogger _logger { get; set; }
        /// <summary>
        /// decrypt an encrypted Business Object
        /// </summary>
        /// <param name="encryptedObject">an encrypted Business Object</param>
        /// <returns>a decrypted Business Object</returns>
        public abstract BusinessObject Decrypt(EncryptedObject encryptedObject);
        public abstract T Decrypt<T>(EncryptedObject encryptedObject) where T : BusinessObject;
        public abstract void Dispose();

        ~Encrypter()
        {
            Dispose();
        }
    }
}