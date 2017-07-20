using Jst.Core.Uow;
using Jst.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jst.EntityFramework.Uow
{
    /// <summary>
    /// EF的工作单元扩展方法
    /// </summary>
    public static class EfUnitOfWorkExtension
    {

        public static TDbContext GetDbContext<TDbContext>(this IUnitOfWork unitOfWork) where TDbContext : DbContext
        {
            if (unitOfWork.Is<EfUnitOfWork>())
            {
               return  unitOfWork.Cast<EfUnitOfWork>().GetOrCreateDbContext<TDbContext>();
            }
            return default(TDbContext);
        }

    }
}
