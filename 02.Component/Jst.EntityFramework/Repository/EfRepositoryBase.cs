using Jst.Core;
using Jst.Core.Entities;
using Jst.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jst.EntityFramework.Repository
{
    public class EfRepositoryBase<TDbContext, TPrimaryKey, TEntity> : JstDefaultRepository<TPrimaryKey, TEntity>
        where TPrimaryKey : struct
        where TEntity : EntityBase<TPrimaryKey>
        where TDbContext : DbContext
    {
        protected IDbContextProvider<TDbContext> _dbContextProvider;

        public EfRepositoryBase(IDbContextProvider<TDbContext> dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        protected IDbSet<TEntity> Table { get { return Context.Set<TEntity>(); } }

        private TDbContext Context { get { return _dbContextProvider.GetDbContext(); } }

        public override void Delete(TPrimaryKey id)
        {
            //TEntity entity = Single(c=>c.)
            Table.Remove(Get(id));
        }

        public override void Delete(TEntity entity)
        {
            Table.Remove(entity);
        }

        public override IQueryable<TEntity> GetAll()
        {
            return Table;
        }

        public override TEntity Insert(TEntity entity)
        {
           return Table.Add(entity);
        }

        public override TEntity Update(TEntity entity)
        {
            return entity;
        }
    }

    //public class EfRepositoryBase<TDbContext, TEntity> : EfRepositoryBase<TDbContext, long, TEntity>
    //    where TEntity : EntityBase<long>
    //    where TDbContext : DbContext
    //{
    //    public EfRepositoryBase(IDbContextProvider<TDbContext> dbContextProvider) : base(dbContextProvider)
    //    {
    //    }
    //}
}
