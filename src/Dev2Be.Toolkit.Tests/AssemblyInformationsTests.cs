using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace Dev2Be.Toolkit.Tests
{
    [TestClass]
    public class AssemblyInformationsTests
    {
        private AssemblyInformations SetAssemblyInformations() => new AssemblyInformations(Assembly.GetExecutingAssembly().GetName().Name);

        [TestMethod]
        public void GetProductNameTest()
        {
            Assert.AreEqual("Dev2Be.Toolkit.Tests", SetAssemblyInformations().Product);
        }

        [TestMethod]
        public void GetTitleTest()
        {
            Assert.AreEqual("Dev2Be.Toolkit.Tests", SetAssemblyInformations().Product);
        }

        [TestMethod]
        public void GetDescriptionTest()
        {
            Assert.AreEqual("Classes de tests de Dev2Be.Toolkit.Tests", SetAssemblyInformations().Description);
        }

        [TestMethod]
        public void GetCompanyTest()
        {
            Assert.AreEqual("Dev2Be", SetAssemblyInformations().Company);
        }
    }
}
