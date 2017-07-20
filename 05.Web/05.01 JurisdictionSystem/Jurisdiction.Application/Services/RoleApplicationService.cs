using Jst.Core;
using Jst.Core.Application;
using Jst.Core.Ioc;
using Jst.Utils.Extension;
using Jurisdiction.Application.Dto;
using Jurisdiction.Application.Interface;
using Jurisdiction.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Jurisdiction.Application.Services
{
    public class RoleApplicationService : ApplicationServiceBase, IRoleApplicationService
    {
        private readonly IRepository<long, Role> roleRepository;
        private readonly IRepository<long,User> userRepositry;
        public RoleApplicationService(IRepository<long,Role> _roleRepository, IRepository<long, User> _userRepositry)
        {
            //IRepository<Role> _roleRepository,IRepository<User> _userRepositry
            this.roleRepository =  _roleRepository;
            this.userRepositry = _userRepositry;
        }
        public List<RoleDto> GetAllRole()
        {
            List<Role> list = new List<Role>();
            list = roleRepository.GetAll().ToList();
            return list.MapTo<List<RoleDto>>();
        }
    }
}
