using Dev2Be.Toolkit.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev2Be.Toolkit.Tests.Helpers
{
    [TestClass]
    public class NetworkHelperTests
    {
        [TestMethod]
        public void IsValidPort()
        {
            Assert.AreEqual(true, NetworkHelper.IsValidPort(53400));
        }

        [TestMethod]
        public void IsNotValidPortTooSmall()
        {
            Assert.AreEqual(false, NetworkHelper.IsValidPort(32400));
        }

        [TestMethod]
        public void IsNotValidPortTooHigh()
        {
            Assert.AreEqual(false, NetworkHelper.IsValidPort(84210));
        }

        [TestMethod]
        public void IsValidIPv4AddressTest()
        {
            Assert.AreEqual(true, NetworkHelper.IsValidIPv4Address("192.168.1.254"));
        }

        [TestMethod]
        public void IsNotValidIPv4AddressTest()
        {
            Assert.AreEqual(false, NetworkHelper.IsValidIPv4Address("1142.168.1.254"));
        }

        [TestMethod]
        public void IsNotValidIPv4AddressWithCharacterTest()
        {
            Assert.AreEqual(false, NetworkHelper.IsValidIPv4Address("foo.168.1.254"));
        }

        [TestMethod]
        public void IsValidIPv6AddressTest()
        {
            Assert.AreEqual(true, NetworkHelper.IsValidIPv6Address("2001:0db8:0000:85a3:0000:0000:ac1f:8001"));
        }

        [TestMethod]
        public void IsSimplifiedValidIPv6AddressTest()
        {
            Assert.AreEqual(true, NetworkHelper.IsValidIPv6Address("2001:db8:0:85a3:0:0:ac1f:8001"));
        }

        [TestMethod]
        public void IsSimplifiedAndOmitedValidIPv6AddressTest()
        {
            Assert.AreEqual(true, NetworkHelper.IsValidIPv6Address("2001:db8:0:85a3::ac1f:8001"));
        }

        [TestMethod]
        public void IsConverterIPv4ToIPv6AddressTest()
        {
            Assert.AreEqual(true, NetworkHelper.IsValidIPv6Address("::192.168.1.254"));
        }

        [TestMethod]
        public void IsNotValidIPv6Address()
        {
            Assert.AreEqual(false, NetworkHelper.IsValidIPv6Address("20051:0db8:0000:85a3:0000:0000:ac1f:8001"));
        }
        
        [TestMethod]
        public void IsNotValidIPv6AddressHexadecimalIncorrect()
        {
            Assert.AreEqual(false, NetworkHelper.IsValidIPv6Address("20051:0zb8:0000:85a3:0000:0000:ac1f:8001"));
        }
    }
}
