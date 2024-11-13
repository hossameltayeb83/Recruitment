using System.Security.Cryptography;
using System.Text;

namespace Recruitment.Helper
{
    public static class GenericHelper
    {
        public static string DecryptGeneric(string Message)
        {
            return DecryptString(Message, "SystemCZ310");
        }

        private static string DecryptString(string Message, string Passphrase)
        {
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

            // Step 1. We hash the passphrase using MD5
            // We use the MD5 hash generator as the result is a 128 bit byte array
            // which is a valid length for the TripleDES encoder we use below

            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Passphrase));

            // Step 2. Create a new TripleDESCryptoServiceProvider object
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

            // Step 3. Setup the decoder
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;

            // Step 4. Convert the input string to a byte[]
            byte[] DataToDecrypt = Convert.FromBase64String(Message);

            // Step 5. Attempt to decrypt the string
            try
            {
                ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
            }
            finally
            {
                // Clear the TripleDes and Hashprovider services of any sensitive information
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }

            // Step 6. Return the decrypted string in UTF8 format
            return UTF8.GetString(Results);
        }

        public static string EncryptString(string Message)
        {
            return EncryptString(Message, "SystemCZ310");
        }
        public static string EncryptString(string Message, string Passphrase)
        {
            UTF8Encoding uTF8Encoding = new UTF8Encoding();
            MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
            byte[] key = mD5CryptoServiceProvider.ComputeHash(uTF8Encoding.GetBytes(Passphrase));
            TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
            tripleDESCryptoServiceProvider.Key = key;
            tripleDESCryptoServiceProvider.Mode = CipherMode.ECB;
            tripleDESCryptoServiceProvider.Padding = PaddingMode.PKCS7;
            byte[] bytes = uTF8Encoding.GetBytes(Message);
            byte[] inArray;
            try
            {
                ICryptoTransform cryptoTransform = tripleDESCryptoServiceProvider.CreateEncryptor();
                inArray = cryptoTransform.TransformFinalBlock(bytes, 0, bytes.Length);
            }
            finally
            {
                tripleDESCryptoServiceProvider.Clear();
                mD5CryptoServiceProvider.Clear();
            }

            return Convert.ToBase64String(inArray);
        }
    }
}
