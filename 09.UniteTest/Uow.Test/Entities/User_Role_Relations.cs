using Jst.Core.Entities;
using Jst.Utils.UtilsHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uow.Test.Entities
{
    public class User_Role_Relations : CreationAuditUserEntityBase<long,long,User>
    {
        public User_Role_Relations() {
            this.Id = SnowflakeWorkerHelper.GetId();
        }

        public long UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public long RoleId { get; set; }

        [ForeignKey("RoleId")]
        public Role Role { get; set; }

    }
}
