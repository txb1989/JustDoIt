using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jurisdiction.Domain.SearchParams.Authority
{
    public class RoleSearchParam: BaseSearchParam<long>
    {
        public string RoleName { get; set; }

        public long? ParentRoleId { get; set; }
    }
}
