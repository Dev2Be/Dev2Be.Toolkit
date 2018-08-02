using Dev2Be.Toolkit.Enumerations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Markup;

namespace Dev2Be.Toolkit.Extensions
{
    public static class StringExtensions
    {
        internal const string EmailRegex = "(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|\"(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21\\x23-\\x5b\\x5d-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])*\")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21-\\x5a\\x53-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])+)\\])";

        /// <summary>
        /// Vérifier que le mot est un mot entier dans le texte.
        /// </summary>
        /// <param name="word"></param>
        /// <param name="fullText">Indiquer le texte dans lequel le mot doit être vérifié</param>
        /// <returns></returns>
        public static bool IsFullWord(this string word, string fullText) => IsFullWord(word, fullText, Enumerations.StringComparison.Normal);

        /// <summary>
        /// Vérifier que le mot est un mot entier dans le texte.
        /// </summary>
        /// <param name="word"></param>
        /// <param name="fullText">Indiquer le texte dans lequel le mot doit être vérifié</param>
        /// <param name="stringComparaison">Indiquer la méthode de comparaison du mot et du texte.</param>
        /// <exception cref="InvalidOperationException"/>
        /// <returns></returns>
        public static bool IsFullWord(this string word, string fullText, Enumerations.StringComparison stringComparaison)
        {
            if (string.IsNullOrEmpty(fullText) || string.IsNullOrEmpty(word))
                throw new InvalidOperationException();

            switch (stringComparaison)
            {
                case Enumerations.StringComparison.IgnoreCase:
                    return Regex.IsMatch(fullText, "\\b" + word + "\\b", RegexOptions.IgnoreCase);
                case Enumerations.StringComparison.IgnoreCaseAndDiacritics:
                    return Regex.IsMatch(RemoveAccents(fullText), "\\b" + RemoveAccents(word) + "\\b", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
                case Enumerations.StringComparison.IgnoreDiacritics:
                    return Regex.IsMatch(RemoveAccents(fullText), "\\b" + RemoveAccents(word) + "\\b", RegexOptions.CultureInvariant);
                case Enumerations.StringComparison.Normal:
                    return Regex.IsMatch(fullText, "\\b" + word + "\\b");
                default:
                    return false;
            }
        }

        /// <summary>
        /// Supprimer les diacritiques du texte.
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static string RemoveAccents(this string word)
        {
            string normalized = word.Normalize(NormalizationForm.FormD);
            var builder = new StringBuilder();

            foreach (char ch in normalized)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
                    builder.Append(ch);
            }

            return builder.ToString().Normalize(NormalizationForm.FormC);
        }

        /// <summary>
        /// Compter le nombre de mots dans un texte.
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static int Count(this string word) => Count(word, new char[] { ' ', '\r', '\n' });

        /// <summary>
        /// Compter le nombre de mots dans un texte.
        /// </summary>
        /// <param name="word"></param>
        /// <param name="separator">Spécifier les séparateurs de mots.</param>
        /// <returns></returns>
        public static int Count(this string word, char[] separators)
        {
            if (separators == null)
                throw new ArgumentNullException("separators");

            return word.Split(separators, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        /// <summary>
        /// Convertir une chaîne de caractère en FlowDocument.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static FlowDocument ToFlowDocument(this string s) => XamlReader.Parse(s) as FlowDocument;

        /// <summary>
        /// Vérifier que l'adresse e-mail est valide.
        /// </summary>
        /// <param name="s">La chaine de caractère à tester.</param>
        /// <returns><c>true</c> pour une adresse e-mail valide.<c>false</c> sinon.</returns>
        public static bool IsEmail(this string s)
        {
            return Regex.IsMatch(s, EmailRegex);
        }
    }
}
