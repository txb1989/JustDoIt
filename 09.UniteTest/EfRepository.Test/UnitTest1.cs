using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jst.Core.Ioc;
using EfRepository.Test.Entities;
using EfRepository.Test.MyRepositories;

namespace EfRepository.Test
{
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1()
        {
            IocManager.Instance.InitIoc();
        }

        [TestMethod]
        public void Test_GetRepository()
        {
            Jst.Core.IRepository<int,OpenUser> repository = IocManager.Instance.Resolve<Jst.Core.IRepository<int, OpenUser>>();
            OpenUser user = repository.Get(1361957);
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void Test_GetMulityRepository()
        {
            Jst.Core.IRepository<int, Customer> _cusRepository = IocManager.Instance.Resolve<Jst.Core.IRepository<int, Customer>>("CustomerRepository");
            Jst.Core.IRepository<int, OpenUser> _opUserRepository = IocManager.Instance.Resolve<Jst.Core.IRepository<int, OpenUser>>("OpenUserRepository");
            Assert.IsNotNull(_cusRepository);
            Assert.IsNotNull(_opUserRepository);
        }

        [TestMethod]
        public void Test_GetCustomerRepository()
        {
            IMyRepository _myRepository = IocManager.Instance.Resolve<IMyRepository>();
            Customer customer = _myRepository.Get(2);
            Assert.IsNotNull(customer);
            Assert.AreEqual(customer.CustomerName, "CC");
        }
    }
}
