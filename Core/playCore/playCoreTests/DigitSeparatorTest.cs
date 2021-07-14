using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace playCoreTests
{
    [TestClass]
    public class DigitSeparatorTest
    {
        [TestMethod]
        public void DigitSeparator_ExpectItToBeSame()
        {

            Assert.AreEqual(1_000_000, 1000000);

        }

        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(3, GetDup(new[] { 1, 2, 3, 4, 6, 7, 8, 9, 3 }));
        }
        
        [TestMethod]
        public void Test2()
        {
            Assert.AreEqual(3, GetDup2(new[] { 1, 2, 3, 4, 6, 7, 8, 9, 3 }));
        }
        
        [TestMethod]
        public void Test3()
        {
            Assert.AreEqual(2, GetDup2(new[] { 1, 2, 3, 4, 6, 7, 8, 9, 345,345345,345345345,55,34534534,2,234234,234222 }));
        }
        [TestMethod]
        public void Test4()
        {
            Assert.AreEqual(0, GetDup2(new[] { 1, 2, 3, 4, 6, 7, 8, 9, 345,345345,345345345,55,34534534,234234,234222 }));
        }
        
        [TestMethod]
        public void Test5()
        {
            CollectionAssert.AreEqual(new int[0], GetAllDup(new[] { 1, 2, 3, 4, 6, 7, 8, 9, 345,345345,345345345,55,34534534,234234,234222 }).ToArray());
        }
        
        [TestMethod]
        public void Test6()
        {
            CollectionAssert.AreEqual(new int[]{55}, GetAllDup(new[] { 55, 1, 2, 3, 4, 6, 7, 8, 9, 345,345345,345345345,55,34534534,234234,234222 }).ToArray());
        }

        private static int GetDup(int[] elements)
        {
            var set = new HashSet<int>();

            foreach (var element in elements)
            {
                if (!set.Add(element)) return element;
            }

            return -1;
        }

        private static int GetDup2(int[] elements)
        {
            var set = new HashSet<int>();
            return elements.FirstOrDefault(element => !set.Add(element));
        }

        private static IEnumerable<int> GetAllDup(int[] elements)
        {
            var set = new HashSet<int>();
            return elements.Where(element => !set.Add(element));
        }
    }
}
