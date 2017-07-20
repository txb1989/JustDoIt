using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jst.Core.Ioc;
using Ioc.Test.Services;
using Jst.Utils;
using Jst.Core.Log;

namespace Ioc.Test
{
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1()
        {
            IocManager.Instance.InitIoc();
        }

        [TestMethod]
        public void Test_GetService()
        {
            IService _service = IocManager.Instance.Resolve<IService>();
            int result = _service.Add(2, 3);
            Assert.AreEqual(5, result);
        }
        [TestMethod]
        public void Test_GetGenericService()
        {
            IServiceGeneric<int> _service = IocManager.Instance.Resolve<IServiceGeneric<int>>();
            Assert.IsTrue(_service.equal(1, 1));
        }

        [TestMethod]
        public void Test_GetObject()
        {
            Object1 obj1 = IocManager.Instance.Resolve<Object1>();
            Assert.IsNotNull(obj1);
        }
        [TestMethod]
        public void Test_GetProvider()
        {
            IObjectProvider<Object1> provider = IocManager.Instance.Resolve<IObjectProvider<Object1>>();
            Assert.IsNotNull(provider);
            MyDbObject obj = provider.GetObject();
            Assert.IsNotNull(obj);
            Assert.IsTrue(obj.Is<Object1>());
        }

        [TestMethod]
        public void Test_GetRepository()
        {
            IRepository<int, object> rep = IocManager.Instance.Resolve<IRepository<int, object>>("RepositoryA");
            Assert.IsNotNull(rep);
        }

        [TestMethod]
        public void Test_GetNoneGenericImplements()
        {
            IServiceGeneric2<int> _service = IocManager.Instance.Resolve<IServiceGeneric2<int>>();
            _service.equal(1, 1);
        }

        [TestMethod]
        public void Test_GetLogOperator()
        {
            IJstCoreLogs log = IocManager.Instance.Resolve<IJstCoreLogs>();
            log.Debug("Hello Test");
        }
    }
}
