using Jst.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uow.Test.Entities
{
    public class Role : EntityBase<long>
    {
        public string RoleName { get; set; }

        public long ParentRoleId { get; set; }

        [ForeignKey("ParentRoleId")]
        public Role ParentRole { get; set; }

        public List<User_Role_Relations> UserRoleRelations { get; set; }
    }
}
