using System;
using System.Security.Cryptography;
using System.Text;

namespace Dev2Be.Toolkit.Encrypting
{
    public class DataProtection
    {
        /// <summary>
        /// Chiffrer une chaîne de caractère
        /// </summary>
        /// <param name="data">La chaîne de caractères à chiffrer.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        public static string Encrypt(string data) => Encrypt(data, "", DataProtectionScope.CurrentUser);

        /// <summary>
        /// Chiffrer une chaîne de caractère
        /// </summary>
        /// <param name="data">La chaîne de caractère à chiffrer.</param>
        /// <param name="passPhrase">Une chaîne de caractères supplémentaire pour augmenter la complexité du chiffrement.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static string Encrypt(string data, string passPhrase) => Encrypt(data, passPhrase, DataProtectionScope.CurrentUser);

        /// <summary>
        /// Chiffrer une chaîne de caractère
        /// </summary>
        /// <param name="data">La chaîne de caractères à chiffrer.</param>
        /// <param name="passPhrase">Une chaîne de caractères supplémentaire pour augmenter la complexité du chiffrement.</param>
        /// <param name="scope">La portée de protection des données devant être appliquée au chiffrement.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static string Encrypt(string data, string passPhrase, DataProtectionScope scope)
        {
            if (data == null) throw new ArgumentNullException("data");

            byte[] clearBytes = Encoding.UTF8.GetBytes(data);
            byte[] entropyBytes = string.IsNullOrEmpty(passPhrase) ? null : Encoding.UTF8.GetBytes(passPhrase);
            byte[] encryptedBytes = ProtectedData.Protect(clearBytes, entropyBytes, scope);

            return Convert.ToBase64String(encryptedBytes);
        }

        /// <summary>
        /// Déchiffrer une chaîne de caractère
        /// </summary>
        /// <param name="data">La chaîne de caractères à chiffrer.</param>
        /// <param name="passPhrase">Une chaîne de caractères supplémentaire pour augmenter la complexité du chiffrement.</param>
        /// <param name="scope">La portée de protection des données devant être appliquée au chiffrement.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static string Decrypt(string data) => Decrypt(data, "", DataProtectionScope.CurrentUser);

        /// <summary>
        /// Déchiffrer une chaîne de caractère
        /// </summary>
        /// <param name="data">La chaîne de caractères à déchiffrer.</param>
        /// <param name="passPhrase">Une chaîne de caractères supplémentaire pour augmenter la complexité du déchiffrement.</param>
        /// <param name="scope">La portée de protection des données devant être appliquée au chiffrement.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static string Decrypt(string data, string passPhrase) => Decrypt(data, passPhrase, DataProtectionScope.CurrentUser);

        /// <summary>
        /// Déchiffrer une chaîne de caractère
        /// </summary>
        /// <param name="data">La chaîne de caractères à chiffrer.</param>
        /// <param name="passPhrase">Une chaîne de caractères supplémentaire qui a été utilisée pour chiffrer les données.</param>
        /// <param name="scope">La portée de protection des données qui a été appliquée au chiffrement.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static string Decrypt(string data, string passPhrase, DataProtectionScope scope)
        {
            if (data == null) throw new ArgumentNullException("data");

            byte[] encryptedBytes = Convert.FromBase64String(data);
            byte[] entropyBytes = string.IsNullOrEmpty(passPhrase) ? null : Encoding.UTF8.GetBytes(passPhrase);
            byte[] clearBytes = ProtectedData.Unprotect(encryptedBytes, entropyBytes, scope);

            return Encoding.UTF8.GetString(clearBytes);
        }
    }
}
