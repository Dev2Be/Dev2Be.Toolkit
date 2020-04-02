using Dev2Be.Toolkit.Encrypting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Dev2Be.Toolkit.Tests.Encypting
{
    [TestClass]
    public class HashTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SHA1DataIsNullTest() 
        {
            Hash.SHA1(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SHA1DataIsEmptyTest()
        {
            Hash.SHA1("");
        }

        [TestMethod]
        public void SHA1DataSucessTest()
        {
            Assert.IsNotNull(Hash.SHA256("A string to hash."));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SHA256DataIsNullTest()
        {
            Hash.SHA256(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SHA256DataIsEmpty()
        {
            Hash.SHA256("");
        }

        [TestMethod]
        public void SHA256DataSucessTest()
        {
            Assert.IsNotNull(Hash.SHA256("A string to hash."));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SHA384DataIsNullTest()
        {
            Hash.SHA384(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SHA384DataIsEmptyTest()
        {
            Hash.SHA384("");
        }

        [TestMethod]
        public void SHA384DataSucessTest()
        {
            Assert.IsNotNull(Hash.SHA384("A string to hash."));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SHA512DataIsNullTest()
        {
            Hash.SHA512(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SHA512DataIsEmptyTest()
        {
            Hash.SHA512("");
        }

        [TestMethod]
        public void SHA512DataSucessTest()
        {
            Assert.IsNotNull(Hash.SHA512("A string to hash."));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MD5DataIsNullTest()
        {
            Hash.MD5(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MD5DataIsEmptyTest()
        {
            Hash.MD5("");
        }

        [TestMethod]
        public void MD5DataSucessTest()
        {
            Assert.IsNotNull(Hash.MD5("A string to hash."));
        }
    }
}
