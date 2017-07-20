using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jst.Core.Uow
{
    public interface IUniteOfWorkManager
    {
        IUnitOfWork Current { get;  }

        IUnitOfWork GetUnitOfWork();
    }
}