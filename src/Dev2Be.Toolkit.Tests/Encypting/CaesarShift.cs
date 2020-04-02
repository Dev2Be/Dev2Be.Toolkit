using System;
using System.Linq;

namespace Dev2Be.Toolkit.Tests.Encypting
{
    /// <summary>
    /// Chiffrer ou déchiffrer une chaine de caractères en utilisant la méthode du chiffrement par décalage.
    /// </summary>
    public class CaesarShift
    {
        /// <summary>
        /// Chiffrer une chaine de caractères.
        /// </summary>
        /// <param name="data">La chaine de caractères qui doit être chiffrée.</param>
        /// <returns></returns>
        public static string Encrypt(string data) => Encrypt(data, 3);

        /// <summary>
        /// Chiffrer une chaine de caractères.
        /// </summary>
        /// <param name="data">La chaine de caractères qui doit être chiffrée.</param>
        /// <param name="shift">La clé de chiffrement.</param>
        /// <returns></returns>
        public static string Encrypt(string data, int shift)
        {
            if (string.IsNullOrEmpty(data)) throw new ArgumentNullException("data");

            if (shift == 0) throw new ArgumentOutOfRangeException("shift");

            int mod(int val, int m) => val % m + (val < 0 ? m : 0);

            char decal(char c, char offset, int m) => (char)(offset + mod(c - offset + shift, m));

            char cesar(char c) => ('a' <= c && c <= 'z') ? decal(c, 'a', 26) : ('A' <= c && c <= 'Z') ? decal(c, 'A', 26) : ('0' <= c && c <= '9') ? decal(c, '0', 10) : c;

            return new string(data.Select(cesar).ToArray());
        }

        /// <summary>
        /// Déchiffrer une chaine de caractères.
        /// </summary>
        /// <param name="data">La chaine de caractères qui doit être déchiffrée.</param>
        /// <returns></returns>
        public static string Decrypt(string data) => Decrypt(data, 3);

        /// <summary>
        /// Déchiffrer une chaine de caractères.
        /// </summary>
        /// <param name="data">La chaine de caractères qui doit être déchiffrée.</param>
        /// <param name="shift">La clé de chiffrement.</param>
        /// <returns></returns>
        public static string Decrypt(string data, int shift)
        {
            if (string.IsNullOrEmpty(data)) throw new ArgumentNullException("data");

            if (shift == 0) throw new ArgumentOutOfRangeException("shift");

            int mod(int val, int m) => val % m + (val < 0 ? m : 0);

            char decal(char c, char offset, int m) => (char)(offset + mod(c - offset - shift, m));

            char cesar(char c) => ('a' <= c && c <= 'z') ? decal(c, 'a', 26) : ('A' <= c && c <= 'Z') ? decal(c, 'A', 26) : ('0' <= c && c <= '9') ? decal(c, '0', 10) : c;

            return new string(data.Select(cesar).ToArray());
        }
    }
}
