using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jst.EntityFramework
{
    public class JstDbContext : DbContext
    {

        public JstDbContext() { }

        public JstDbContext(string cnode) : base(cnode)
        {
        }

    }
}
