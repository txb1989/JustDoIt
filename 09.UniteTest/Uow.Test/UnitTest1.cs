using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Uow.Test.Entities;
using Uow.Test;
using Jst.Core;
using Jst.Core.Ioc;
using System.Linq;

namespace Uow.Test
{
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1() {
            IocManager.Instance.InitIoc();
        }

        [TestMethod]
        public void Test_GetRepository()
        {
            IRepository<long, User> repo = IocManager.Instance.Resolve<IRepository<long,User>>();
            Assert.IsNotNull(repo);
            var user = repo.GetAll().FirstOrDefault();
            Assert.IsNotNull(user);

        }
    }
}
