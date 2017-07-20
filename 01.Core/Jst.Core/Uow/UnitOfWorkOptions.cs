using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jst.Core.Uow
{
    public class UnitOfWorkOptions
    {
        /// <summary>
        /// 是否需要TransactionScope的支持，因为在EF里面，DbContext其实是已经相当于一个工作单元并包含事物性了。
        /// 所以在单个DbContext的时候其实是不需要再创建事物来控制一致性的。
        /// </summary>
        public bool IsTransaction { get; set; }

        public TimeSpan TimeSpan { get; set; }
    }
}
