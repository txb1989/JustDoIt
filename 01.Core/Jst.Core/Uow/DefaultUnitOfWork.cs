using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jst.Core.Uow
{
    public abstract class DefaultUnitOfWork : IUnitOfWork
    {
        public string Id { get; protected set; }

        public bool IsDisposed { get; protected set; }

        public event EventHandler Completed;
        public event EventHandler Disposed;

        public virtual void Begin(UnitOfWorkOptions option) { }

        public virtual void Commit() { }

        public virtual void RollBack() { }
        public virtual void Dispose()
        {
            if (IsDisposed)
            {
                return;
            }
            IsDisposed = true;
        }


    }
}
