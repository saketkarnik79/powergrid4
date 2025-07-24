using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace CS_DemoEncryption
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //DemoSymmetricEncryption();

            using (RSA rsa = RSA.Create(2048))
            {
                string privateKey= Convert.ToBase64String(rsa.ExportRSAPrivateKey());
                string publicKey = Convert.ToBase64String(rsa.ExportRSAPublicKey());
                Console.WriteLine($"Private Key: {privateKey}");
                Console.WriteLine($"Public Key: {publicKey}");

                string originalMessage = "Here is some data to encrypt!";
                byte[] messageBytes= Encoding.UTF8.GetBytes(originalMessage);
                byte[] encryptedBytes;
                using(RSA rsaEncryptor = RSA.Create())
                {
                    rsaEncryptor.ImportRSAPublicKey(Convert.FromBase64String(publicKey), out _);
                    encryptedBytes = rsaEncryptor.Encrypt(messageBytes, RSAEncryptionPadding.OaepSHA256);
                }
                string encryptedMessage = Convert.ToBase64String(encryptedBytes);
                Console.WriteLine($"\nEncrypted Message: {encryptedMessage}");

                byte[] decryptedBytes;
                using (RSA rsaDecryptor = RSA.Create())
                {
                    rsaDecryptor.ImportRSAPrivateKey(Convert.FromBase64String(privateKey), out _);
                    decryptedBytes = rsaDecryptor.Decrypt(encryptedBytes, RSAEncryptionPadding.OaepSHA256);
                }
                string decryptedMessage = Encoding.UTF8.GetString(decryptedBytes);
                Console.WriteLine($"\nDecrypted Message: {decryptedMessage}");
                Console.WriteLine();
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static void DemoSymmetricEncryption()
        {
            using (Aes aes = Aes.Create())
            {
                aes.KeySize = 256;
                aes.BlockSize = 128;
                aes.GenerateKey();
                aes.GenerateIV();
                string originalMessage = "Here is some data to encrypt!";
                Console.WriteLine($"Original: {originalMessage}");
                // Encrypt the string to an array of bytes
                byte[] encryptedBytes;
                using (ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                using (MemoryStream msEncrypt = new MemoryStream())
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(originalMessage);
                        swEncrypt.Flush();
                        csEncrypt.FlushFinalBlock();
                        encryptedBytes = msEncrypt.ToArray();
                    }

                    string encryptedMessage = Convert.ToBase64String(encryptedBytes);
                    Console.WriteLine($"\nEncrypted String: {encryptedMessage}");

                    //Decrypt to a normal string
                    string decryptedMessage;
                    using (ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                    using (MemoryStream msDecrypt = new MemoryStream(encryptedBytes))
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        decryptedMessage = srDecrypt.ReadToEnd();
                    }
                    Console.WriteLine($"\nDecrypted Message: {decryptedMessage}");
                }
            }
        }
    }
}