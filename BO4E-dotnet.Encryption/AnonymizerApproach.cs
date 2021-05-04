namespace BO4E.Encryption
{

    /// <summary>
    /// The class AnonymizerApproach defines how an affected path is handled during anonymization.
    /// </summary>
    public enum AnonymizerApproach
    {
        /// <summary>
        /// Simply delete the data by replacing them with null values in the JSON
        /// representation. In most cases this results in invalid BO4E object as well
        /// as not well formed EDIFCAT messages.
        /// </summary>
        DELETE,

        /// <summary>
        /// Hashes the original data using SHA256.
        /// </summary>
        /// When converting back to EDIFACT the hashed are cropped to the maximum length
        /// allowance by EdiLibrary Host. Using the hash option allows for keeping data
        /// integrity while maintaining privacy (via pseudonymity) at the same time. The
        /// same information hashed with the same salt always results in the same hash.
        /// Null values are not hashed. ENUM based values are not hashed.
        HASH,

        /// <summary>
        /// Asymmetrically encrypt strings or COM objects.
        /// </summary>
        /// Null values are not encrypted. ENUM based values are not encrypted.
        ENCRYPT,

        /// <summary>
        /// Reverts the encryption. <seealso cref="ENCRYPT"/>
        /// </summary>
        DECRYPT,

        /// <summary>
        /// Do not do anything with the data. This is similar to not setting the options
        /// connected to the path at all but more explicit.
        /// </summary>
        KEEP
    }
}
