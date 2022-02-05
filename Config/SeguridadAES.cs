using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsolaEncriptacionEstandar.Config
{
    public class SeguridadAES
    {
        public string Encriptar(string cadena)
        {
            string cadenaSalida = "";
            try
            {
                using (RijndaelManaged myRijndael = new RijndaelManaged())
                {
                    byte[] _key = Encoding.ASCII.GetBytes("Gaia_CEC_2021@*!");
                    byte[] _IV = Encoding.ASCII.GetBytes("1234567812345678");
                    byte[] encrypted = EncryptStringToBytes(cadena, _key, _IV);
                    //byte[] _byteCOmbinado = Combine(myRijndael.IV, encrypted);

                    cadenaSalida = Convert.ToBase64String(encrypted, 0, encrypted.Length);

                }
            }
            catch (Exception e)
            {
                cadenaSalida = "ERROR";
            }

            return cadenaSalida;

        }
        public static byte[] Combine(byte[] first, byte[] second)
        {
            return first.Concat(second).ToArray();
        }
        public string Desencriptar(string cadena)
        {
            string cadenaSalida = "";
            try
            {
                using (RijndaelManaged myRijndael = new RijndaelManaged())
                {
                    byte[] _key = Encoding.ASCII.GetBytes("Gaia_CEC_2021@*!");
                    byte[] _IV = Encoding.ASCII.GetBytes("1234567812345678");

                    byte[] _cadena = System.Convert.FromBase64String(cadena);
                    cadenaSalida = DecryptStringFromBytes(_cadena, _key, _IV);

                }
            }
            catch (Exception e)
            {
                cadenaSalida = "ERROR";
            }

            return cadenaSalida;

        }
        static byte[] EncryptStringToBytes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;
            // Create an RijndaelManaged object
            // with the specified key and IV.
            using (RijndaelManaged rijAlg = new RijndaelManaged())
            {
                rijAlg.Key = Key;
                rijAlg.IV = IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {

                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }
        static string DecryptStringFromBytes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an RijndaelManaged object
            // with the specified key and IV.
            using (RijndaelManaged rijAlg = new RijndaelManaged())
            {
                rijAlg.Key = Key;
                rijAlg.IV = IV;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }
    }
}
