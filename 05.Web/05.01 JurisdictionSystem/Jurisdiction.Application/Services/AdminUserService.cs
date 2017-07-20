using Jst.Core;
using Jst.Core.Application;
using Jurisdiction.Application.Dto;
using Jurisdiction.Application.Interface;
using Jurisdiction.Domain.Entities;
using System.Collections.Generic;

namespace Jurisdiction.Application.Services
{
    public class AdminUserService : ApplicationServiceBase,IAdminUserService
    {

        private readonly IRepository<long, User> userRepository;

        public AdminUserService(IRepository<long, User> _userRepository)
        {
            userRepository = _userRepository;
        }

        public List<UserDto> QueryAdminUserPager()
        {
            List<UserDto> dto = new List<UserDto>();
            
            return dto;
        }

    }
}
