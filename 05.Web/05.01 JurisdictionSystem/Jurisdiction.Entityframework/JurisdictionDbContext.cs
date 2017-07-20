using Jst.EntityFramework;
using Jurisdiction.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jurisdiction.Entityframework
{
    public class JurisdictionDbContext : JstDbContext
    {
        public JurisdictionDbContext() : base("Default")
        {
            Database.SetInitializer<JurisdictionDbContext>(null);
        }
        public virtual IDbSet<Role> Roles { get; set; }

        public virtual IDbSet<User> Users { get; set; }
    }
}
