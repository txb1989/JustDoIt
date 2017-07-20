using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jst.Core.Premission
{
    public class DefaultPremissionChecker : IPremissionChecker
    {
        public bool Check()
        {
            return true;
        }
    }
}
