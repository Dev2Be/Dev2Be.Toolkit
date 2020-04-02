using Dev2Be.Toolkit.Encrypting;
using Dev2Be.Toolkit.Enumerations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev2Be.Toolkit.Tests.Encypting
{
    [TestClass]
    public class PasswordForceTests
    {
        [TestMethod]
        public void PasswordScoreReturnBlankTest()
        {
            Assert.AreEqual(PasswordScore.Blank, PasswordForce.CheckStrength(""));
        }
        
        [TestMethod]
        public void PasswordScoreReturnVeryWeekTest()
        {
            Assert.AreEqual(PasswordScore.VeryWeak, PasswordForce.CheckStrength("dvz5"));
        }
        
        [TestMethod]
        public void PasswordScoreReturnWeekTest()
        {
            Assert.AreEqual(PasswordScore.Weak, PasswordForce.CheckStrength("xceov7xpr"));
        }
        
        [TestMethod]
        public void PasswordScoreReturnMeduimTest()
        {
            Assert.AreEqual(PasswordScore.Medium, PasswordForce.CheckStrength("dV9zfpcy1"));
        } 
        
        [TestMethod]
        public void PasswordScoreReturnStrongTest()
        {
            Assert.AreEqual(PasswordScore.Strong, PasswordForce.CheckStrength("dV9pc!y1"));
        }

        [TestMethod]
        public void PasswordScoreReturnVeryStrongTest()
        {
            Assert.AreEqual(PasswordScore.VeryStrong, PasswordForce.CheckStrength("kIq;aU7.0@*.@\\qz~"));
        }

        [TestMethod]
        public void ReplaceLettersWithSubstitution1Test()
        {
            Assert.AreEqual("4z3rtyu10p", PasswordForce.ReplaceLettersWithSubstitutions("Azertyuiop"));
        }
        
        [TestMethod]
        public void ReplaceLettersWithSubstitution2Test()
        {
            Assert.AreEqual("jzerttuio3", PasswordForce.ReplaceLettersWithSubstitutions("azertyuiop", new char[] { 'a', 'y', 'p' }, new char[] { 'j', 't', '3' }));
        }
    }
}
