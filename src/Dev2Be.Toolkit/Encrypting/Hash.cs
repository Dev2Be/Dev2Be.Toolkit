using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crypto = System.Security.Cryptography;

namespace Dev2Be.Toolkit.Encrypting
{
    public class Hash
    {
        /// <summary>
        /// Hasher une chaîne de caractère en utilisant l'algorithme SHA1.
        /// </summary>
        /// <param name="data">La chaîne de caractère à hasher.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        public static string SHA1(string data)
        {
            if (string.IsNullOrEmpty(data)) throw new ArgumentNullException("data");

            return Convert.ToBase64String(Crypto.SHA1.Create().ComputeHash(Encoding.Default.GetBytes(data)));
        }

        /// <summary>
        /// Hasher une chaîne de caractère en utilisant l'algorithme SHA256.
        /// </summary>
        /// <param name="data">La chaîne de caractère à hasher.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        public static string SHA256(string data)
        {
            if (string.IsNullOrEmpty(data)) throw new ArgumentNullException("data");

            return Convert.ToBase64String(Crypto.SHA256.Create().ComputeHash(Encoding.Default.GetBytes(data)));
        }

        /// <summary>
        /// Hasher une chaîne de caractère en utilisant l'algorithme SHA384.
        /// </summary>
        /// <param name="data">La chaîne de caractère à hasher.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        public static string SHA384(string data)
        {
            if (string.IsNullOrEmpty(data)) throw new ArgumentNullException("data");

            return Convert.ToBase64String(Crypto.SHA384.Create().ComputeHash(Encoding.Default.GetBytes(data)));
        }

        /// <summary>
        /// Hasher une chaîne de caractère en utilisant l'algorithme SHA512.
        /// </summary>
        /// <param name="data">La chaîne de caractère à hasher.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        public static string SHA512(string data)
        {
            if (string.IsNullOrEmpty(data)) throw new ArgumentNullException("data");

            return Convert.ToBase64String(Crypto.SHA512.Create().ComputeHash(Encoding.Default.GetBytes(data)));
        }

        /// <summary>
        /// Hasher une chaîne de caractère en utilisant l'algorithme MD5.
        /// </summary>
        /// <param name="data">La chaîne de caractère à hasher.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        public static string MD5(string data)
        {
            if (string.IsNullOrEmpty(data)) throw new ArgumentNullException("data");

            return Convert.ToBase64String(Crypto.MD5.Create().ComputeHash(Encoding.Default.GetBytes(data)));
        }
    }
}
