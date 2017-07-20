using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jst.Core.Uow
{
    public interface IUnitOfWork : IDisposable
    {

        /// <summary>
        /// Unique id of this UOW.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// 提交
        /// </summary>
        void Commit();

        /// <summary>
        /// 开启
        /// </summary>
        void Begin(UnitOfWorkOptions option);

        /// <summary>
        /// 回滚
        /// </summary>
        void RollBack();
        
        /// <summary>
        /// Is this UOW disposed?
        /// </summary>
        bool IsDisposed { get; }

        /// <summary>
        /// This event is raised when this UOW is successfully completed.
        /// </summary>
        event EventHandler Completed;

        /// <summary>
        /// This event is raised when this UOW is disposed.
        /// </summary>
        event EventHandler Disposed;

    }
}
