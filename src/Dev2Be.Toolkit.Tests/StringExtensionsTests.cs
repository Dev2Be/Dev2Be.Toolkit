using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dev2Be.Toolkit.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dev2Be.Toolkit.Tests
{
    [TestClass]
    public class StringExtensionsTests
    {
        [TestMethod]
        public void IsNotFullWordTest()
        {
            string wordToTest = "text";

            string text = "Ceci est du texte.";

            bool isFullWord = wordToTest.IsFullWord(text);

            Assert.AreEqual(false, isFullWord);
        }

        [TestMethod]
        public void IsFullWordTest()
        {
            string wordToTest = "texte";

            string text = "Ceci est du texte.";

            bool isFullWord = wordToTest.IsFullWord(text);

            Assert.AreEqual(true, isFullWord);
        }

        [TestMethod]
        public void IsFullWordWithIgnoreCaseTest()
        {
            string wordToTest = "Texte";

            string text = "Ceci est du texte.";

            bool isFullWord = wordToTest.IsFullWord(text, Enumerations.StringComparison.IgnoreCase);

            Assert.AreEqual(true, isFullWord);
        }

        [TestMethod]
        public void IsFullWordIgnoreDiacriticsTest()
        {
            string wordToTest = "têxte";

            string text = "Ceci est du texte.";

            bool isFullWord = wordToTest.IsFullWord(text, Enumerations.StringComparison.IgnoreDiacritics);

            Assert.AreEqual(true, isFullWord);
        }

        [TestMethod]
        public void IsFullWordIgnoreDiacriticsAndCaseTest()
        {
            string wordToTest = "Têxte";

            string text = "Ceci est du texte.";

            bool isFullWord = wordToTest.IsFullWord(text, Enumerations.StringComparison.IgnoreCaseAndDiacritics);

            Assert.AreEqual(true, isFullWord);
        }

        [TestMethod]
        public void RemoveDiacriticsTest()
        {
            string wordToTest = "têxte";

            string word = wordToTest.RemoveAccents();

            Assert.AreEqual("texte", word);
        }

        [TestMethod]
        public void CountWordsTest()
        {
            string texte = "L’affaire Iran-Contra ou Irangate est un scandale politico-militaire survenu aux États-Unis dans les années 1980. Plusieurs hauts responsables du gouvernement fédéral américain ont soutenu un trafic d'armes vers l'Iran, autorisant le transfert, partiel ou total, des sommes reçues aux Contras, malgré l'interdiction explicite du Congrès des États-Unis de financer ce groupe armé en lutte contre le pouvoir nicaraguayen. L'affaire est toujours voilée de secrets en 2018.";

            int count = texte.Count();

            Assert.AreEqual(66, count);
        }

        [TestMethod]
        public void IsEmailTest()
        {
            string email = "someone@domain.fr";

            bool isEmail = email.IsEmail();

            Assert.AreEqual(true, isEmail);
        }

        [TestMethod]
        public void IsNotEmailTest()
        {
            string email = "someone@.fr";

            bool isEmail = email.IsEmail();

            Assert.AreEqual(false, isEmail);
        }

        [TestMethod]
        public void IsNumericalStringTest()
        {
            string s = "123";

            bool isNumericalString = s.IsNumerical();

            Assert.AreEqual(true, isNumericalString);
        }

        [TestMethod]
        public void IsNotNumericalStringTest()
        {
            string s = "12z3";

            bool isNumericalString = s.IsNumerical();

            Assert.AreEqual(false, isNumericalString);
        }
    }
}
