using Jst.Core;
using Jst.Core.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Test.Entities;
using UnitOfWork.Test.Repositories;

namespace UnitOfWork.Test
{
   public  class ApplicationService : IApplicationService
    {

        private readonly ICustomerRepository<int, Customer> _customerRepository;
        private readonly IOpenUserRepository<int, OpenUser> _openuserRepository;

        public ApplicationService(ICustomerRepository<int, Customer> customerRepository,IOpenUserRepository<int,OpenUser> openUserRepository)
        {
            _customerRepository = customerRepository;
            _openuserRepository = openUserRepository;
        }

        public Customer Service1(int id)
        {
            return _customerRepository.Get(id);
        }
    }

    public interface IApplicationService: ISingleInstance
    {
        Customer Service1(int id);
    }
}
