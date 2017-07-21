using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jst.Utils.Extension;
using Jst.Utils.UtilsHelper;
using System.Collections.Generic;
using Jst.Utils.EnumExt;
using Newtonsoft.Json;
using Jst.Utils;

namespace Utils.CoreUniteTest
{
    [TestClass]
    public class EnumExtTest
    {
        [TestMethod]
        public void TestGetDescription()
        {
            EnumGender gender = EnumGender.Male;
            string description = gender.GetDescription();
            Assert.AreEqual("男",description);
            gender = EnumGender.Unknown;
            Assert.AreEqual("未知", gender.GetDescription());
        }

        [TestMethod]
        public void TestGetAllEnums()
        {
            List<EnumItem> enumList = EnumHelper.GetEnumList<EnumGender>();

            Assert.AreEqual(enumList.Count, 4);
            foreach(var item in enumList)
            {
                Console.Write(item.ToJson());
            }

        }


    }

    public enum EnumGender
    {
        [System.ComponentModel.Description("男")]
        Male=0,
        [System.ComponentModel.Description("女")]
        Female =1,
        [System.ComponentModel.Description("保密")]
        Secrete = 2,
        [System.ComponentModel.Description("未知")]
        Unknown =-999999,
    }
}
