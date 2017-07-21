using Jst.Utils.UtilsHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Utils.CoreUniteTest
{
    [TestClass]
    public class DateTimeUniteTest
    {
        [TestMethod]
        public void TestTime()
        {

            DateTime time1 = DateTime.Now;
            DateTime time2 = DateTime.UtcNow;
            Console.Write($"{time1.ToString()}----{time2.ToString()}  ");
        }

        [TestMethod]
        public void TestTimeStampToTime()
        {
            long timestamp1 = 1501663571L;//时间：2017/8/2 16:46:11
            DateTime time1 = Convert.ToDateTime("2017/8/2 16:46:11");
            DateTime time = DateTimeHelper.ConvertStampToTime(timestamp1);
            Assert.AreEqual(time1, time);

            long timestamp2 = 1186574400L;//时间：2007/8/8 20:00:00
            DateTime time2 = Convert.ToDateTime("2007/8/8 20:00:00");
            time = DateTimeHelper.ConvertStampToTime(timestamp2);
            Assert.AreEqual(time2, time);
        }

        [TestMethod]
        public void TestTimeToTimeStamp()
        {
            DateTime time2 = Convert.ToDateTime("2007/8/8 20:00:00");
            long timestamp2 = 1186574400L;
            long timestamp = DateTimeHelper.ConvertTimeToStamp(time2);
            Assert.AreEqual(timestamp2, timestamp);
            
            DateTime time1 = Convert.ToDateTime("2017/8/2 16:46:11");
            long timestamp1 = 1501663571L;
            timestamp = DateTimeHelper.ConvertTimeToStamp(time1);
            Assert.AreEqual(timestamp1, timestamp);
        }

    }
}
