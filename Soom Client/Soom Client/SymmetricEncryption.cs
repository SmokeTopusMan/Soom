using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Soom_Client
{
    public static class SymmetricEncryption
    {
        public static Aes Aes { get; set; }
        public static byte[] EncryptStringToBytesAES(string plainText)
        {
            byte[] encrypted;
            // Create an encryptor to perform the stream transform.
            ICryptoTransform encryptor = Aes.CreateEncryptor(Aes.Key, Aes.IV);

            // Create the streams used for encryption.
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        // Write all data to the stream.
                        swEncrypt.Write(plainText);
                    }
                    encrypted = msEncrypt.ToArray();
                }
            }
            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }
        public static string DecryptBytesToStringAES(byte[] ciphertext)
        {
            // Check arguments.
            if (ciphertext == null || ciphertext.Length <= 0)
                throw new ArgumentNullException("ciphertext");
            if (Aes.Key == null || Aes.Key.Length <= 0)
                throw new ArgumentNullException("key");
            if (Aes.IV == null || Aes.IV.Length <= 0)
                throw new ArgumentNullException("iv");

            string plaintext;
            // Create a decryptor to perform the stream transform.
            ICryptoTransform decryptor = Aes.CreateDecryptor(Aes.Key, Aes.IV);

            // Create a MemoryStream to hold the decrypted data.
            using (MemoryStream msDecrypt = new MemoryStream(ciphertext))
            {
                // Create a CryptoStream, bound to the MemoryStream and the decryptor.
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    // Create a StreamReader for reading the decrypted bytes as text.
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        // Read the decrypted bytes and convert them to a string.
                        plaintext = srDecrypt.ReadToEnd();
                    }
                }
            }
            return plaintext;
        }
    }
}
