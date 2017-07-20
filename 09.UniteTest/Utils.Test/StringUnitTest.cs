using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jst.Utils;
using Jst.Utils.Extension;

namespace Utils.Test
{
    [TestClass]
    public class StringUnitTest
    {
        [TestMethod]
        public void TestMethod1() { }

        [TestMethod]
        public void TestSplitString()
        {
            string str = "1,2,3,4,5,6,7,8,9,0";
            string str2 = "2015-08-31|2016-08-08 23:56:12.33|2008-08-08";
            var arrays =str.GetString2Array<int>(',');
            var datearray = str2.GetString2Array<DateTime>('|');
            Assert.AreEqual(arrays.Count,10);
            Assert.AreEqual(datearray.Count, 3);
            var date = new DateTime(2015,8,31);
            Assert.AreEqual(datearray[0], date);
        }

        [TestMethod]
        public void TestSbc2Dbc()
        {
            string sbc = "ｑｗｅ";
            string dbc = "qwe";
            string s1 = sbc.ToDbc();
            string s2 = dbc.ToSbc();
            Assert.AreEqual(s1,dbc);
            Assert.AreEqual(s2, sbc);
        }

        [TestMethod]
        public void TestIsDateTime()
        {
            string dt = "2016-16-32";
            Assert.IsFalse(dt.IsDateTime());
            string dt2 = "2008-2-29";
            Assert.IsTrue(dt2.IsDateTime());
            string dt3 = "2011-2-29";
            Assert.IsFalse(dt3.IsDateTime());
            string dt4 = "2011-3-29";
            Assert.IsTrue(dt4.IsDateTime());

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCheckNull()
        {
            object obj = null;
            object o = "";
            bool flag = obj.IsNotNull();
            Assert.IsTrue(flag);
            flag = o.IsNull();
            Assert.IsFalse(flag);
             obj.CheckNull("");

        }
    }
}
