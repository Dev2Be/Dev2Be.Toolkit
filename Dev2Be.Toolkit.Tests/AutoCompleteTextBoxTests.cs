using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dev2Be.Toolkit.Tests
{
    [TestClass]
    public class AutoCompleteTextBoxTests
    {
        [TestMethod]
        public void FilterSuggestionsWithValue()
        {
            Wpf.AutoCompleteTextBox autoCompleteTextBox = new Wpf.AutoCompleteTextBox { Suggestions = new List<string> { "Assembly", "Bibliothèque", "Commande", "Commentaire", "Cycle", "Développement", "Namespace", "Programmation", "Valeur" } };
            List<string> results = autoCompleteTextBox.FilterSuggestion("c");

            List<string> expected = new List<string>() { "Commande", "Commentaire", "Cycle" };

            Assert.AreEqual(results.SequenceEqual(expected), true);
 
        }

        [TestMethod]
        public void FilterSuggestionsWithoutValue()
        {
            Wpf.AutoCompleteTextBox autoCompleteTextBox = new Wpf.AutoCompleteTextBox { Suggestions = new List<string>() { "Assembly", "Bibliothèque", "Commande", "Commentaire", "Cycle", "Développement", "Namespace", "Programmation", "Valeur" } };
            List<string> results = autoCompleteTextBox.FilterSuggestion("");

            Assert.AreEqual(results, default(List<string>));
        }
    }
}
