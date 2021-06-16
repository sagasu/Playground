using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace playCoreTests
{
    [TestClass]
    public class Base64Test
    {
        [TestMethod]
        public void Test()
        {
            var str = "Brown Fox";
            Assert.AreEqual("QnJvd24gRm94", Encode(str));
        }
        
        [TestMethod]
        public void Test2()
        {
            var str = "QnJvd24gRm94";
            Assert.AreEqual("Brown Fox", Decode(str));
        }

        private string Encode(string str)
        {
            var stringArray = Encoding.UTF8.GetBytes(str);
            return Convert.ToBase64String(stringArray);
        }

        private string Decode(string base64String)
        {
            var byteArray = Convert.FromBase64String(base64String);
            return Encoding.UTF8.GetString(byteArray);
        }
    }
}
