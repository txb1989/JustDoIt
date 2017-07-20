using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jst.Core.Ioc;
using UnitOfWork.Test.Entities;
using Jst.Core.Uow;
using System.Linq;
using Jst.Core;
using Jst.EntityFramework;
using Jst.EntityFramework.Uow;
using Jst.Utils;
using UnitOfWork.Test.Repositories;
using System.Data.Entity;

namespace UnitOfWork.Test
{
    [TestClass]
    public class UnitTest1
    {

        public UnitTest1()
        {
            IocManager.Instance.InitIoc();
        }

        [TestMethod]
        public void Test_GetDbContext()
        {
           
            using (CustomerDbContext context = IocManager.Instance.Resolve<CustomerDbContext>())
            {
                Customer customer = context.Customers.FirstOrDefault(c => c.Id == 2L);
                Assert.IsNotNull(customer);
                Assert.AreEqual(customer.Phone, "13145626325");

                Customer c2 = context.Set<Customer>().FirstOrDefault(c => c.Id == 2);
                Assert.IsNotNull(customer);
                Assert.AreEqual(customer.Phone, "13145626325");
            }
        }


        [TestMethod]
        public void Test_GetDbContextProvider()
        {
            IDbContextProvider<CustomerDbContext> provider = IocManager.Instance.Resolve<IDbContextProvider<CustomerDbContext>>();
            Assert.IsNotNull(provider);
        }

        [TestMethod]
        public void Test_GetUnitOfWork()
        {
            IUnitOfWork unite = IocManager.Instance.Resolve<IUnitOfWork>();
            CustomerDbContext context = unite.Cast<EfUnitOfWork>().GetOrCreateDbContext<CustomerDbContext>();
            Assert.IsNotNull(context);
        }


        [TestMethod]
        public void Test_GetRepository()
        {
            ICustomerRepository<int, Customer> _customerRepository = IocManager.Instance.Resolve<ICustomerRepository<int, Customer>>();
            var customer = _customerRepository.Get(2);
            Assert.IsNotNull(customer);
            Assert.AreEqual(customer.Phone, "13145626325");
        }
        
        [TestMethod]
        public void Test_GetUnitOfWorkManager()
        {
            IUnitOfWork manager = IocManager.Instance.Resolve<IUnitOfWork>();
            Assert.IsNotNull(manager);
        }

        [TestMethod]
        public void TestMethod1()
        {
            IApplicationService appService = IocManager.Instance.Resolve<IApplicationService>();
            Customer customer = appService.Service1(2);
            Assert.IsNotNull(customer);
            Assert.AreEqual(customer.Phone, "13145626325");
        }
    }
}
