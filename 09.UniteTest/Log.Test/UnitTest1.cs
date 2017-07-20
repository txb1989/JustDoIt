using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jst.Log4net;
using Jst.Core.Log;

namespace Log.Test
{
    [TestClass]
    public class UnitTest1
    {
        private readonly IJstCoreLogs _log;
        public UnitTest1()
        {
            _log = new JstCoreLog4net();
        }

        [TestMethod]
        public void TestInfo()
        {
            _log.Info("测试日志Info");
        }
        [TestMethod]
        public void TestInfoException()
        {
            _log.Info("测试日志Info", new Exception("测试Info And Exception"));
        }
        [TestMethod]
        public void TestDebug()
        {
            _log.Info("测试日志Debug");
        }
        [TestMethod]
        public void TestDebugExceptoin()
        {
            _log.Info("测试日志Debug", new Exception("测试Debug And Exception"));
        }
        [TestMethod]
        public void TestWarn()
        {
            _log.Info("测试日志Warn");
        }
        [TestMethod]
        public void TestWarnExceptoin()
        {
            _log.Info("测试日志Warn", new Exception("测试Warn And Exception"));
        }
        [TestMethod]
        public void TestFatal()
        {
            _log.Info("测试日志Fatal");
        }
        [TestMethod]
        public void TestFatalExceptoin()
        {
            _log.Info("测试日志Fatal", new Exception("测试Fatal And Exception"));
        }
    }
}
