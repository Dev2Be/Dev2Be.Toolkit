using Dev2Be.Toolkit.Encrypting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Dev2Be.Toolkit.Tests.Encypting
{
    [TestClass]
    public class DataProtectionTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DataProtectionEncryptDataIsNullTest()
        {
            DataProtection.Encrypt(null);
        }

        [TestMethod]
        public void DataProtectionEncryptSuccess()
        {
            Assert.IsNotNull(DataProtection.Encrypt("A string to encrypt."));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DataProtectionDecryptDataIsNullTest()
        {
            DataProtection.Decrypt(null);
        }

        [TestMethod]
        public void DataProtectionDecryptSuccess()
        {
            string encrypted = DataProtection.Encrypt("A string to encrypt.");

            Assert.AreEqual("A string to encrypt.", DataProtection.Decrypt(encrypted));
        }
    }
}
