using Jst.Utils.UtilsHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Utils.CoreUniteTest
{
    [TestClass]
    public class EncryptUniteTest
    {
        [TestMethod]
        public void TestMd5()
        {

            string secret1 = "e10adc3949ba59abbe56e057f20f883e";
            string pwd1 = "123456";
            string secret = EncryptHelper.Md532(pwd1);
            Assert.AreEqual(secret1, secret, true);
            string secret2 = "d17515860d4f63c6f3c48acc181e72c7";
            string pwd2 = "tang123456@";
            secret = EncryptHelper.Md532(pwd2);
            Assert.AreEqual(secret2, secret, true);
        }

        [TestMethod]
        public void TestAes()
        {
            string ikey = "123698745159753852456";
            string ivalue = "95135746585274123698";
            string secret = "123456".AesStr(ikey, ivalue);
            string orgin = secret.UnAesStr(ikey, ivalue);
            Assert.AreEqual(orgin, "123456");
        }

        [TestMethod]
        public void TestDes()
        {
            string ikey = "123698745159753852456";
            string ivalue = "95135746585274123698";
            Assert.AreEqual("123456".Des(ikey, ivalue).UnDes(ikey,ivalue), "123456");
        }

    }
}
