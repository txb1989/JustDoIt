using Castle.DynamicProxy;
using Jst.Core.Ioc;
using Jst.Core.JstInterceptors;
using Jst.Core.Uow;
using Jst.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Jst.Core.JstInterceptors.AopAttributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class UnitOfWorkAttribute : BaseProcesser
    {

        //private readonly IUnitOfWork _uniteOfWork;

        private readonly IUniteOfWorkManager _uniteManager;

        protected IUnitOfWork _unitOfWork;

        /// <summary>
        /// 是否需要TransactionScope的支持，因为在EF里面，DbContext其实是已经相当于一个工作单元并包含事物性了。
        /// 所以在单个DbContext的时候其实是不需要再创建事物来控制一致性的。
        /// </summary>
        protected bool IsTransaction;

        public UnitOfWorkAttribute(string name = "", bool IsTransaction = false)
        {
            _uniteManager = IocManager.Instance.Resolve<IUniteOfWorkManager>(name);
            this.IsTransaction = IsTransaction;
        }


        public override bool Processing()
        {
            _unitOfWork = _uniteManager.GetUnitOfWork();
            _unitOfWork.Begin(new UnitOfWorkOptions() { IsTransaction = IsTransaction });
            return base.Processing();
        }

        public override bool Processed()
        {
            if (_unitOfWork.IsNotNull())
            {
                _unitOfWork.Dispose();
            }
            return base.Processed();
        }

    }
}
