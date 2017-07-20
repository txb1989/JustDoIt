using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jurisdiction.Domain.SearchParams.Authority
{
    public class BaseSearchParam<TPrimaryKey> where TPrimaryKey : struct
    {
        public TPrimaryKey? Id { get; set; }
    }
}
