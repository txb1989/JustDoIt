using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jst.Core.Attributes
{
    public class RegisterAliasNameAttribute : Attribute
    {

        public string AliasName { get; set; }

        public RegisterAliasNameAttribute(string name)
        {
            AliasName = name;
        }

    }
}
