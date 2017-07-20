using Jst.Core.Application.Dtos;
using Jurisdiction.Domain.Entities;
using Jurisdiction.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jurisdiction.Application.Dto
{
    public class UserDto : BaseDtos
    {

        public string UserName { get; set; }

        public string Password { get; set; }

        public string PhoneNo { get; set; }

        public string Email { get; set; }

        public Gender Gender { get; set; }

        public List<User_Role_Relations> UserRoleRelations { get; set; }
    }
}
