using Dev2Be.Toolkit.Models;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Dev2Be.Toolkit.Encrypting
{
    /// <summary>
    /// Chiffrer et déchiffrer une chaine de caractères ou un fichier en utilisant la méthode AES.
    /// </summary>
    public class AES
    {
        private static string GetRandomString(int length)
        {
            char[] arrChar = new char[]{ 'a','b','d','c','e','f','g','h','i','j','k','l','m','n','p','r','q','s','t','u','v','w','z','y','x', '0','1','2','3','4','5','6','7','8','9', 'A','B','C','D','E','F','G','H','I','J','K','L','M','N','Q','P','R','T','S','V','U','W','X','Y','Z' };

            StringBuilder stringBuilder = new StringBuilder();

            Random rnd = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < length; i++) 
                stringBuilder.Append(arrChar[rnd.Next(0, arrChar.Length)].ToString()); 

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Générer une clé AES.
        /// </summary>
        /// <returns></returns>
        public static AESKey CreateAesKey()
        {
            return new AESKey()
            {
                Key = GetRandomString(32),
                IV = GetRandomString(16)
            };
        }

        /// <summary>
        /// Chiffrer une chaine de caractères.
        /// </summary>
        /// <param name="plainText">La chaine de caractères qui doit être chiffrée.</param>
        /// <param name="strKey">La clé de chiffrement utilisé pour chiffrer la chaine de caractères.</param>
        /// <param name="strIv">Le vecteur d'initialisation utilisé pour chiffrer la chaine de caractères.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns></returns>
        public static string Encrypt(string plainText, string strKey, string strIv) => Encrypt(plainText, strKey, strIv, CipherMode.CBC);

        /// <summary>
        /// Chiffrer une chaîne de caractères.
        /// </summary>
        /// <param name="plainText">La chaîne de caractères qui doit être chiffrée.</param>
        /// <param name="strKey">La clé de chiffrement utilisé pour chiffrer la chaîne de caractères.</param>
        /// <param name="strIv">Le vecteur d'initialisation utilisé pour chiffrer la chaîne de caractères.</param>
        /// <param name="cipherMode">Le mode de chiffrement par bloc à utiliser pour le chiffrement.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns></returns>
        public static string Encrypt(string data, string key, string iv, CipherMode cipherMode)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException("key");

            if (string.IsNullOrEmpty(iv)) throw new ArgumentNullException("iv");

            if (key.Length != 32) throw new ArgumentOutOfRangeException("key");

            if (iv.Length != 16) throw new ArgumentOutOfRangeException("iv");

            byte[] plainBytes = Encoding.UTF8.GetBytes(data);
            byte[] keys = Encoding.UTF8.GetBytes(key);
            byte[] ivs = Encoding.UTF8.GetBytes(iv);
            byte[] cipherBytes;

            RijndaelManaged rijndael = new RijndaelManaged() { Mode = cipherMode };

            ICryptoTransform aesEncryptor = rijndael.CreateEncryptor(keys, ivs);

            using (MemoryStream ms = new MemoryStream())
            using (CryptoStream cs = new CryptoStream(ms, aesEncryptor, CryptoStreamMode.Write))
            {
                cs.Write(plainBytes, 0, data.Length);
                cs.FlushFinalBlock();

                cipherBytes = ms.ToArray();
            }

            return Convert.ToBase64String(cipherBytes);
        }

        /// <summary>
        /// Déchiffrer une chaîne de caractère
        /// </summary>
        /// <param name="cipherText">La chaîne de caractères qui doit être déchiffrée.</param>
        /// <param name="strKey">La clé de chiffrement utilisé pour déchiffrer la chaîne de caractères.</param>
        /// <param name="strIv">Le vecteur d'initialisation utilisé pour déchiffrer la chaîne de caractères.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns></returns>
        public static string Decrypt(string data, string key, string iv) => Decrypt(data, key, iv, CipherMode.CBC);

        /// <summary>
        /// Déchiffrer une chaîne de caractères.
        /// </summary>
        /// <param name="plainText">La chaîne de caractères qui doit être déchiffrée.</param>
        /// <param name="strKey">La clé de chiffrement utilisé pour déchiffrer la chaîne de caractères.</param>
        /// <param name="strIv">Le vecteur d'initialisation utilisé pour déchiffrer la chaîne de caractères.</param>
        /// <param name="cipherMode">Le mode de chiffrement par bloc à utiliser pour le chiffrement.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns></returns>
        public static string Decrypt(string data, string key, string iv, CipherMode cipherMode)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException("key");

            if (string.IsNullOrEmpty(iv)) throw new ArgumentNullException("iv");

            if (key.Length != 32) throw new ArgumentOutOfRangeException("key");

            if (iv.Length != 16) throw new ArgumentOutOfRangeException("iv");

            byte[] cipheredData = Convert.FromBase64String(data);
            byte[] keys = Encoding.UTF8.GetBytes(key);
            byte[] ivs = Encoding.UTF8.GetBytes(iv);
            byte[] plainBytes;

            int decryptedByteCount;

            RijndaelManaged rijndaelManaged = new RijndaelManaged() { Mode = CipherMode.CBC };

            ICryptoTransform decryptor = rijndaelManaged.CreateDecryptor(keys, ivs);

            using (MemoryStream memoryStream = new MemoryStream(cipheredData))
            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
            {
                plainBytes = new byte[cipheredData.Length];

                decryptedByteCount = cryptoStream.Read(plainBytes, 0, plainBytes.Length);
            }

            return Encoding.UTF8.GetString(plainBytes, 0, decryptedByteCount);
        }

        /// <summary>
        /// Chiffrer un fichier.
        /// </summary>
        /// <param name="plainFilePath">Le chemin du fichier qui doit être chiffré.</param>
        /// <param name="cypheredFilePath">Le chemin d'enregistrement du fichier chiffré.</param>
        /// <param name="key">La clé de chiffrement utilisé pour chiffrer le fichier.</param>
        /// <param name="iv">Le vecteur d'initialisation utilisé pour chiffrer le fichier.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void Encrypt(string plainFilePath, string cypheredFilePath, string key, string iv) => Encrypt(plainFilePath, cypheredFilePath, key, iv, CipherMode.CBC);

        /// <summary>
        /// Chiffrer un fichier.
        /// </summary>
        /// <param name="plainFilePath">Le chemin du fichier qui doit être chiffré.</param>
        /// <param name="cypheredFilePath">Le chemin d'enregistrement du fichier chiffré.</param>
        /// <param name="key">La clé de chiffrement utilisé pour chiffrer le fichier.</param>
        /// <param name="iv">Le vecteur d'initialisation utilisé pour chiffrer le fichier.</param>
        /// <param name="cipherMode">Le mode de chiffrement par bloc à utiliser pour le chiffrement.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void Encrypt(string plainFilePath, string cypheredFilePath, string key, string iv, CipherMode cipherMode)
        {
            if (!File.Exists(plainFilePath)) throw new FileNotFoundException("plainFilePath");

            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException("key");

            if (string.IsNullOrEmpty(iv)) throw new ArgumentNullException("iv");

            if (key.Length != 32) throw new ArgumentOutOfRangeException("key");

            if (iv.Length != 16) throw new ArgumentOutOfRangeException("iv");

            byte[] keys = Encoding.UTF8.GetBytes(key);
            byte[] ivs = Encoding.UTF8.GetBytes(iv);

            FileStream fsCypheredFile = new FileStream(cypheredFilePath, FileMode.Create);

            RijndaelManaged rijndael = new RijndaelManaged() { Mode = cipherMode, Key = keys, IV = ivs };

            ICryptoTransform aesEncryptor = rijndael.CreateEncryptor();

            CryptoStream cs = new CryptoStream(fsCypheredFile, aesEncryptor, CryptoStreamMode.Write);

            FileStream fsPlainTextFile = new FileStream(plainFilePath, FileMode.OpenOrCreate);

            int data;

            while ((data = fsPlainTextFile.ReadByte()) != -1)
                cs.WriteByte((byte)data);

            fsPlainTextFile.Close();
            cs.Close();
            fsCypheredFile.Close();
        }

        /// <summary>
        /// Déchiffrer un fichier.
        /// </summary>
        /// <param name="cypheredFilePath">Le chemin du fichier qui doit être déchiffré.</param>
        /// <param name="plainFilePath">Le chemin d'enregistrement du fichier déchiffré.</param>
        /// <param name="key">La clé de chiffrement utilisé pour déchiffrer le fichier.</param>
        /// <param name="iv">Le vecteur d'initialisation utilisé pour déchiffrer le fichier.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void Decrypt(string cypheredFilePath, string plainFilePath, string key, string iv) => Decrypt(cypheredFilePath, plainFilePath, key, iv, CipherMode.CBC);

        /// <summary>
        /// Déchiffrer un fichier.
        /// </summary>
        /// <param name="cypheredFilePath">Le chemin du fichier qui doit être déchiffré.</param>
        /// <param name="plainFilePath">Le chemin d'enregistrement du fichier déchiffré.</param>
        /// <param name="key">La clé de chiffrement utilisé pour déchiffrer le fichier.</param>
        /// <param name="iv">Le vecteur d'initialisation utilisé pour déchiffrer le fichier.</param>
        /// <param name="cipherMode">Le mode de chiffrement par bloc à utiliser pour le déchiffrement.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void Decrypt(string cypheredFilePath, string plainFilePath, string key, string iv, CipherMode cipherMode)
        {
            if (!File.Exists(cypheredFilePath)) throw new FileNotFoundException("cypheredFilePath");

            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException("key");

            if (string.IsNullOrEmpty(iv)) throw new ArgumentNullException("iv");

            if (key.Length != 32) throw new ArgumentOutOfRangeException("key");

            if (iv.Length != 16) throw new ArgumentOutOfRangeException("iv");

            byte[] keys = Encoding.UTF8.GetBytes(key);

            byte[] ivs = Encoding.UTF8.GetBytes(iv);

            FileStream fsCrypt = new FileStream(plainFilePath, FileMode.Create);

            RijndaelManaged rijndael = new RijndaelManaged() { Mode = cipherMode, Key = keys, IV = ivs };

            ICryptoTransform aesDecryptor = rijndael.CreateDecryptor();

            CryptoStream cs = new CryptoStream(fsCrypt, aesDecryptor, CryptoStreamMode.Write);

            FileStream fsIn = new FileStream(cypheredFilePath, FileMode.OpenOrCreate);

            int data;

            while ((data = fsIn.ReadByte()) != -1)
                cs.WriteByte((byte)data);

            cs.Close();
            fsIn.Close();
            fsCrypt.Close();
        }
    }
}
