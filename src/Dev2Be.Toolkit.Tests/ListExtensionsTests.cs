using Dev2Be.Toolkit.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev2Be.Toolkit.Tests
{
    [TestClass]
    public class ListExtensionsTests
    {
        private List<int> defaultList;
        
        [TestInitialize]
        public void Initialize()
        {
            defaultList = new List<int>() { 1, 2, 3 };
        }

        [TestMethod]
        public void ConcatListTest()
        {            
            List<int> b = new List<int> { 4, 5, 6 };
            List<int> c = new List<int> { 7, 8 };
            List<int> concatenedList = defaultList.Concat(b, c);

            CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 }, concatenedList);
        }

        [TestMethod]
        public void JoinIntListTest()
        {
            string joinedList = defaultList.Join();

            Assert.AreEqual("1;2;3", joinedList);
        }

        [TestMethod]
        public void JoinStringListTest()
        {
            string joinedList = new List<string> { "A", "b", "!" }.Join(' ');

            Assert.AreEqual("A b !", joinedList);
        }

        [TestMethod]
        public void PopListTest()
        {
            int item = defaultList.Pop();

            Assert.AreEqual(item, 3);

            CollectionAssert.AreEqual(new List<int> { 1, 2 }, defaultList);
        }

        [TestMethod]
        public void ShiftListTest()
        {
            int item = defaultList.Shift();

            Assert.AreEqual(item, 1);

            CollectionAssert.AreEqual(new List<int> { 2, 3 }, defaultList);
        }

        [TestMethod]
        public void SwapListTest()
        {
            defaultList.Swap(1, 2);

            CollectionAssert.AreEqual(new List<int> { 1, 3, 2 }, defaultList);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SwapListFirstIndexTooBig()
        {
            defaultList.Swap(5, 2);

            Assert.Fail();
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SwapListFirstIndexTooSmall()
        {
            defaultList.Swap(-1, 2);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SwapListSecondtIndexTooBig()
        {
            defaultList.Swap(1, 5);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SwapListSecondtIndexTooSmall()
        {
            defaultList.Swap(1, -2);

            Assert.Fail();
        }

        [TestMethod]
        public void PermutatedListRightToLeftTest()
        {
            CollectionAssert.AreEqual(new List<int> { 2, 3, 1 }, defaultList.Permutate(System.Windows.FlowDirection.RightToLeft));
        }

        [TestMethod]
        public void PermutatedListLeftToRightTest()
        {
            CollectionAssert.AreEqual(new List<int> { 3, 1, 2 }, defaultList.Permutate(System.Windows.FlowDirection.LeftToRight));
        }

        [TestMethod]
        public void AddIfNotExistsTest()
        {
            defaultList.Add(3, false);

            CollectionAssert.AreEqual(new List<int> { 1, 2, 3 }, defaultList);
        }

        [TestMethod]
        public void AddRangeIfNotExistsParamsTest()
        {
            defaultList.AddRange(false, 5, 1, 7, 9, 2);

            CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 5, 7, 9 }, defaultList);
        }

        [TestMethod]
        public void AddRangeIfNotExistsListTest()
        {
            defaultList.AddRange(new List<int> { 5, 1, 7, 9, 2 }, false);

            CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 5, 7, 9 }, defaultList);
        }
    }
}
