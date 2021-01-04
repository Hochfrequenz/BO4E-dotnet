namespace BO4E.ENUM
{
    /// <summary>
    /// Available Encryption Schemes
    /// </summary>
    public enum EncryptionScheme
    {
        /// <summary>
        /// Symmetric Encryption using libsodium in Authenticated Encrypted Associated Data mode (AEAD)
        /// </summary>
        SODIUM_SYMMETRIC_AEAD,

        /// <summary>
        /// Asymmetric Encryption using libsodium Public Key Box format
        /// </summary>
        SODIUM_ASYMMETRIC_PUBLIC_KEY_BOX,

        /// <summary>
        /// Asymmetric Encryption using a public X509 certificate / PKCS#7 (CMS) enveloped data
        /// </summary>
        BOUNCY_CASTLE_CMS
    }
}