using System;
using BO4E.BO;
using BO4E.meta;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BO4E.Encryption
{
    /// <summary>
    ///     abstract base class of all encryption classes; provides useful methods for derived encryption classes
    /// </summary>
    public abstract class Encrypter : IDisposable
    {
        /// <summary>
        ///     serializer settings used in the encrypted objects
        /// </summary>
        protected static readonly JsonSerializerSettings encryptionSerializerSettings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Objects,
            SerializationBinder = new BusinessObjectSerializationBinder()
        };

        /// <summary>
        /// logger.
        /// </summary>
        // ToDo: inject properly
        public ILogger _logger { get; set; }
        /// <summary>
        /// Each encrypter has to define a Dispose method that cleans up stuff.
        /// </summary>
        public abstract void Dispose();

        /// <summary>
        ///     decrypt an encrypted Business Object
        /// </summary>
        /// <param name="encryptedObject">an encrypted Business Object</param>
        /// <returns>a decrypted Business Object</returns>
        public abstract BusinessObject Decrypt(EncryptedObject encryptedObject);

        /// <summary>
        /// Decrypt <paramref name="encryptedObject"/>
        /// </summary>
        /// <param name="encryptedObject"></param>
        /// <typeparam name="T">expected type</typeparam>
        /// <returns>decrypted object</returns>
        public abstract T Decrypt<T>(EncryptedObject encryptedObject) where T : BusinessObject;

        ~Encrypter()
        {
            Dispose();
        }
    }
}