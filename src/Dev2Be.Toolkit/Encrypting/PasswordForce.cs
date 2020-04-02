using Dev2Be.Toolkit.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Dev2Be.Toolkit.Encrypting
{
    public class PasswordForce
    {
        /// <summary>
        /// Vérifier la force d'un mot de passe.
        /// </summary>
        /// <param name="password">Le mot de passe qui doit être vérifié.</param>
        /// <returns></returns>
        public static PasswordScore CheckStrength(string password)
        {
            int score = 0;

            if (string.IsNullOrEmpty(password))
                return PasswordScore.Blank;

            if (password.Length < 1)
                return PasswordScore.Blank;

            if (password.Length < 6)
                return PasswordScore.VeryWeak;

            if (password.Length >= 8)
                score++;

            if (password.Length >= 10)
                score++;

            if (Regex.Match(password, @"\d", RegexOptions.ECMAScript).Success)
                score++;

            if (Regex.Match(password, @"[a-z]", RegexOptions.ECMAScript).Success && Regex.Match(password, @"[A-Z]", RegexOptions.ECMAScript).Success)
                score++;

            if (Regex.Match(password, @"[!,@,#,$,%,^,&,*,?,_,~,-,£,(,)]", RegexOptions.ECMAScript).Success)
                score++;

            return (PasswordScore)score;
        }

        /// <summary>
        /// Substituer certains caractères par d'autres.
        /// </summary>
        /// <param name="password">Le mot de passe contenant les caractères à substituer.</param>
        /// <returns></returns>
        public static string ReplaceLettersWithSubstitutions(string password)
        {
            char[] letters = { 'A', 'a', 'E', 'e', 'i', 'o', 's', 'S' };
            char[] substitutionLetters = { '4', '@', '€', '3', '1', '0', '$', '5' };

            return ReplaceLettersWithSubstitutions(password, letters, substitutionLetters);
        }

        /// <summary>
        /// Substituer certains caractères par d'autres.
        /// </summary>
        /// <param name="password">Le mot de passe contenant les caractères à substituer.</param>
        /// <param name="original">La liste des caractères à remplacer.</param>
        /// <param name="substitution">La liste des caractères de substitution.</param>
        /// <returns></returns>
        public static string ReplaceLettersWithSubstitutions(string password, char[] original, char[] substitution)
        {
            string newPassword = string.Empty;

            foreach (char c in password)
            {
                bool numberAdded = false;

                for (int q = 0; q < original.Length; q++)
                {
                    if (c == original[q])
                    {
                        newPassword += substitution[q];
                        numberAdded = true;
                        break;
                    }
                }

                if (!numberAdded)
                    newPassword += c;
            }

            return newPassword;
        }
    }
}
