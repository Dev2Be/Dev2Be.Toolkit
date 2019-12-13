using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev2Be.Toolkit.Enumerations
{
    /// <summary>
    /// Définit le mode de comparaison d'une chaîne de caractère.
    /// </summary>
    public enum StringComparison
    {
        /// <summary>
        /// Comparer les chaines en ignorant la case.
        /// </summary>
        IgnoreCase,
        /// <summary>
        /// Comparer les chaines en ignorant les diacritiques.
        /// </summary>
        IgnoreDiacritics,
        /// <summary>
        /// Comparer les chaines en ignorant la case et les diacritiques.
        /// </summary>
        IgnoreCaseAndDiacritics,
        /// <summary>
        /// Comparer les chaines en conservant la case et les diactriques.
        /// </summary>
        Normal
    }
}
