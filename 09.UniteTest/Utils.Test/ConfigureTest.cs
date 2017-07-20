using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jst.Utils.UtilsHelper;
using Jst.Utils.Extension;

namespace Utils.Test
{
    /// <summary>
    /// Summary description for ConfigureTest
    /// </summary>
    [TestClass]
    public class ConfigureTest
    {
        public ConfigureTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestMethod1()
        {
            //ISetting setting = new WebConfigSetting();
            //int i1 = setting.GetSettingValue<int>("set1");
            //int i2 = setting.GetSettingValue<int>("set2");
            //Assert.AreEqual(1, i1);
            //Assert.AreEqual(2, i2);
            //ISetting setting = new WebConfigSetting();
            int i1 = ConfigHelper.GetConfigSetting("set1",1);
            int i2 = ConfigHelper.GetConfigSetting("set2", 1);
            Assert.AreEqual(1, i1);
            Assert.AreEqual(2, i2);
        }
    }
}
