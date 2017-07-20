using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Snowflake.Net;

namespace Utils.Test
{
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1()
        {

        }

        [TestMethod]
        public void TestMethod1()
        {
            List<string> strlist = new List<string>();
            strlist.Add("1:");
            strlist.Add("2:");
            strlist.Add("3:");
            var list =GetEnumerable(strlist);
            Assert.AreEqual(list.Count(), 3);
        }

        public IEnumerable<string> GetEnumerable(IEnumerable<string> list)
        {
            foreach(var item in list)
            {
                yield return item + " TTTT";
            }
        }

        [TestMethod]
        public void Test_GetId() {
            IdWorker worker = new IdWorker(1,1);
            List<long> idlist = new List<long>();
            for(int i = 0; i < 100000; i++)
            {
                idlist.Add(worker.NextId());
            }
            Assert.IsNotNull(idlist);
        }
    }
}
