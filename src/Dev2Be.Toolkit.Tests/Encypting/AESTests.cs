using Dev2Be.Toolkit.Encrypting;
using Dev2Be.Toolkit.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Dev2Be.Toolkit.Tests.Encypting
{
    [TestClass]
    public class AESTests
    {
        [TestMethod]
        public void CreateAESTest()
        {
            AESKey aesKey = AES.CreateAesKey();

            Assert.IsNotNull(aesKey);
            Assert.AreEqual(32, aesKey.Key.Length);
            Assert.AreEqual(16, aesKey.IV.Length);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AESEncryptKeyIsNullTest()
        {
            AESKey aesKey = AES.CreateAesKey();

            AES.Encrypt("Text to encrypt", null, aesKey.IV);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AESEncryptKeyLenghtIs6Test()
        {
            AESKey aesKey = AES.CreateAesKey();

            AES.Encrypt("Text to encrypt", "15rfgd", aesKey.IV);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AESEncryptIvIsNullTest()
        {
            AESKey aesKey = AES.CreateAesKey();

            AES.Encrypt("Text to encrypt", aesKey.Key, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AESEncryptKeyIvLenghtIs6Test()
        {
            AESKey aesKey = AES.CreateAesKey();

            AES.Encrypt("Text to encrypt", aesKey.Key, "19e3sv");
        }

        [TestMethod]
        public void AESEncryptStringSuccesTest()
        {
            AESKey aesKey = AES.CreateAesKey();

            Assert.IsNotNull(AES.Encrypt("Text to encrypt", aesKey.Key, aesKey.IV));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AESDecryptKeyIsNullTest()
        {
            AESKey aesKey = AES.CreateAesKey();

            AES.Decrypt("Text to decrypt", null, aesKey.IV);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AESDecryptKeyLenghtIs6Test()
        {
            AESKey aesKey = AES.CreateAesKey();

            AES.Decrypt("Text to decrypt", "15rfgd", aesKey.IV);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AESDecryptIvIsNullTest()
        {
            AESKey aesKey = AES.CreateAesKey();

            AES.Decrypt("Text to decrypt", aesKey.Key, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AESDecryptKeyIvLenghtIs6Test()
        {
            AESKey aesKey = AES.CreateAesKey();

            AES.Decrypt("Text to decrypt", aesKey.Key, "19e3sv");
        }

        [TestMethod]
        public void AESDecryptStringSuccesTest()
        {
            AESKey aesKey = AES.CreateAesKey();

            string plainText = "Text to encrypt.";

            string encrypted = AES.Encrypt(plainText, aesKey.Key, aesKey.IV);

            Assert.AreEqual(plainText, AES.Decrypt(encrypted, aesKey.Key, aesKey.IV));
        }
    }
}
