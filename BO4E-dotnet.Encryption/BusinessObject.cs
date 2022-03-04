namespace BO4E.Encryption
{
    /*
    public static class BusinessObjectExtensions
    {
        /// <summary>
        /// Encrypt a Business Object with a password
        /// </summary>
        /// <returns>an encrypted object</returns>
        public static EncryptedObject Encrypt(this BusinessObject bo, string associatedData)
        {
            byte[] symkey = SecretBox.GenerateKey();
            string symkeyString = Convert.ToBase64String(symkey);
            EncryptedObject eo;
            using (SymmetricEncrypter encryptor = new SymmetricEncrypter(symkey))
            {
                encryptor.Encrypt(bo, associatedData);
                return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(source));
            }
        }
    }*/
}