using System;
using BO4E.BO;
using Microsoft.Extensions.Logging;

namespace BO4E.Extensions.Encryption
{
    /// <summary>
    /// abstract base class of all encryption classes; provides useful methods for derived encryption classes
    /// </summary>
    public abstract class Encrypter : IDisposable
    {
        public ILogger _logger { get; set; }
        /// <summary>
        /// decrypt an encrypted Business Object
        /// </summary>
        /// <param name="encryptedObject">an encrypted Business Object</param>
        /// <returns>a decrypted Business Object</returns>
        public abstract BusinessObject Decrypt(EncryptedObject encryptedObject);
        public abstract void Dispose();

        ~Encrypter()
        {
            Dispose();
        }
    }
}