using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace playCoreTests
{
    [TestClass]
    public class Base64ManualTest
    {
        [TestMethod]
        public void Test()
        {
            var deci = 999;
            Assert.AreEqual("fD", Encode(deci));
        }
        
        [TestMethod]
        public void Test2()
        {
            var str = "fD";
            Assert.AreEqual(999, Decode(str));
        }

        private const string BASE64 = "1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ+/";

        private string Encode(int deci)
        {
            var hash = "";
            while (deci > 0)
            {
                hash = BASE64[deci % 64] + hash;
                deci /= 64;
            }

            return hash;
        }

        private int Decode(string base64String)
        {
            var ret = 0;
            for (var i = 0; i < base64String.Length; i++)
            {
                ret += BASE64.IndexOf(base64String[i]);
            }

            return ret;
        }
    }
}
