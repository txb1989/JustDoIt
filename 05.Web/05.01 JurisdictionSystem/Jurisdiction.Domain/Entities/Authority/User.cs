using Jst.Core.Entities;
using Jurisdiction.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jurisdiction.Domain.Entities.Authority
{
    [Table("AdminUser")]
    public class User : EntityBase<long>
    {
        [Required]
        [StringLength(maximumLength:40,MinimumLength =6)]
        public string UserName { get; set; }
        
        public string Password { get; set; }
        
        [StringLength(maximumLength:15)]
        public string PhoneNo { get; set; }

        [StringLength(maximumLength: 200)]
        public string Email { get; set; }

        public Gender Gender { get; set; }

        public List<User_Role_Relations> UserRoleRelations { get; set; }
    }
}
