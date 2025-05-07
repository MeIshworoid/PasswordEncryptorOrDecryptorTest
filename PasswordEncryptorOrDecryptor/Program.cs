using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

class Program
{
    private static string key = @"Test@Rt7-YQ";

    static string EncryptString(string plainText)
    {
        byte[] iv = new byte[16];
        byte[] array;

        using (Aes aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = iv;

            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                    {
                        streamWriter.Write(plainText);
                    }

                    array = memoryStream.ToArray();
                }
            }
        }

        return Convert.ToBase64String(array);
    }

    static string DecryptString(string cipherText)
    {
        byte[] iv = new byte[16];
        byte[] buffer = Convert.FromBase64String(cipherText);

        using (Aes aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = iv;
            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            using (MemoryStream memoryStream = new MemoryStream(buffer))
            {
                using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                    {
                        return streamReader.ReadToEnd();
                    }
                }
            }
        }
    }

    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Password Encryption/Decryption Tool");
            Console.WriteLine("==================================");
            Console.WriteLine("1. Encrypt Password");
            Console.WriteLine("2. Decrypt Password");
            Console.WriteLine("3. Exit");
            Console.Write("\nEnter your choice (1-3): ");

            string choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        Console.Write("\nEnter password to encrypt: ");
                        string passwordToEncrypt = Console.ReadLine();
                        string encryptedPassword = EncryptString(passwordToEncrypt);
                        Console.WriteLine("\nEncrypted Password: " + encryptedPassword);
                        break;

                    case "2":
                        Console.Write("\nEnter encrypted password to decrypt: ");
                        string passwordToDecrypt = Console.ReadLine();
                        string decryptedPassword = DecryptString(passwordToDecrypt);
                        Console.WriteLine("\nDecrypted Password: " + decryptedPassword);
                        break;

                    case "3":
                        return;

                    default:
                        Console.WriteLine("\nInvalid choice. Please try again.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nError: " + ex.Message);
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
