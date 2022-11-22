using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;

namespace BO4E.ENUM
{
    /// <summary>
    ///     Available Encryption Schemes
    /// </summary>
    public enum EncryptionScheme
    {
        /// <summary>
        ///     Symmetric Encryption using libsodium in Authenticated Encrypted Associated Data mode (AEAD)
        /// </summary>
        [EnumMember(Value = "SodiumSymmetricAEAD")]
        SodiumSymmetricAEAD,

        /// <summary>
        ///     Asymmetric Encryption using libsodium Public Key Box format
        /// </summary>
        [EnumMember(Value = "SodiumAsymmetricPublicKeyBox")]
        SodiumAsymmetricPublicKeyBox,

        /// <summary>
        ///     Asymmetric Encryption using a public X509 certificate / PKCS#7 (CMS) enveloped data
        /// </summary>
        [EnumMember(Value = "BouncyCastleCMS")]
        BouncyCastleCMS
    }
}