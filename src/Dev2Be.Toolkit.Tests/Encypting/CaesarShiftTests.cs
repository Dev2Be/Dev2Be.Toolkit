using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Dev2Be.Toolkit.Tests.Encypting
{
    [TestClass]
    public class CaesarShiftTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CaesarShiftEncryptDataIsNullTest()
        {
            CaesarShift.Encrypt(null, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CaesarShiftEncryptShiftIs0Test()
        {
            string plainText = "AbCDEFGHIJKLMNOPQRSTUVWXYZ'1";

            CaesarShift.Encrypt(plainText, 0);
        }

        [TestMethod]
        public void CaesarShiftEncryptShiftIsNegativeTest()
        {
            string plainText = "AbCDEFGHIJKLMNOPQRSTUVWXYZ'1";

            string cypherText = CaesarShift.Encrypt(plainText, -1);

            Assert.AreEqual("ZaBCDEFGHIJKLMNOPQRSTUVWXY'0", cypherText);
        }

        [TestMethod]
        public void CaesarShiftEncryptTest()
        {
            string plainText = "AbCDEFGHIJKLMNOPQRSTUVWXYZ'1";

            string cypherText = CaesarShift.Encrypt(plainText);

            Assert.AreEqual("DeFGHIJKLMNOPQRSTUVWXYZABC'4", cypherText);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CaesarShiftDecryptDataIsNullTest()
        {
            CaesarShift.Decrypt(null, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CaesarShiftDecryptShiftIs0Test()
        {
            string plainText = "AbCDEFGHIJKLMNOPQRSTUVWXYZ'1";

            CaesarShift.Decrypt(plainText, 0);
        }

        [TestMethod]
        public void CaesarShiftDecryptShiftIsNegativeTest()
        {
            string plainText = "AbCDEFGHIJKLMNOPQRSTUVWXYZ'1";

            string cypherText = CaesarShift.Encrypt(plainText, -2);

            Assert.AreEqual(plainText, CaesarShift.Decrypt(cypherText, -2));
        }

        [TestMethod]
        public void CaesarShiftDecryptTest()
        {
            string plainText = "AbCDEFGHIJKLMNOPQRSTUVWXYZ'1";

            string cypherText = CaesarShift.Encrypt(plainText);

            Assert.AreEqual(plainText, CaesarShift.Decrypt(cypherText));
        }
    }
}
