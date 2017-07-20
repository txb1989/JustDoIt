using Jst.Core.Ioc;
using Jst.Core.JstInterceptors.AopAttributes;
using Jst.Core.Uow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uow.Test.Serivces
{
    public class MyApplicationService : IMyApplicationService
    {
        [UnitOfWork(IsTransaction:false)]
        public void Operate() { }

    }
}
