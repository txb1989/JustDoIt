using Jst.Core.Application.Dtos;
using Jurisdiction.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jurisdiction.Application.Dto
{
    public class RoleDto : BaseDtos
    {
        public string RoleName { get; set; }

        public long? ParentRoleId { get; set; }
        
        public RoleDto ParentRole { get; set; }

        public List<User_Role_Relations> UserRoleRelations { get; set; }
    }
}
