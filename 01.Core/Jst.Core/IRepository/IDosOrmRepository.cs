using Dos.ORM;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Jst.Core.IRepository
{
    public interface IDosOrmRepository<T> :IRepository<T> where T : Entity
    {
        #region 查询
        
        /// <summary>
        /// 通用查询
        /// </summary>
        List<T> Query(Where<T> where, Expression<Func<T, object>> orderBy = null, string ascOrDesc = "asc", int? top = null, int? pageSize = null, int? pageIndex = null);
        /// <summary>
        /// 通用查询
        /// </summary>
        List<T> Query(Where<T> where, OrderByClip orderBy = null, string ascOrDesc = "asc", int? top = null, int? pageSize = null, int? pageIndex = null);
        /// <summary>
        /// 通用查询
        /// </summary>
       
        /// <summary>
        /// 通用查询
        /// </summary>
        T First(Where<T> where, Expression<Func<T, object>> orderBy = null, string ascOrDesc = "asc", int? top = null, int? pageSize = null, int? pageIndex = null);
       
        /// <summary>
        /// 取总数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        int Count(Where<T> where);
        #endregion

        #region 插入
        /// <summary>
        /// 插入单个实体
        /// </summary>
        /// <param name="context"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        void Insert(DbTrans context, T entity);
        /// <summary>
        /// 插入多个实体
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        int Insert(IEnumerable<T> entities);
        void Insert(DbTrans context, IEnumerable<T> entities);
        #endregion

        #region 更新
      
        /// <summary>
        /// 更新单个实体
        /// </summary>
        int Update(T entity, Where where);
      
        void Update(DbTrans context, T entity);
        /// <summary>
        /// 更新多个实体
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        int Update(IEnumerable<T> entities);
        void Update(DbTrans context, IEnumerable<T> entities);
        #endregion

        #region 删除
     
        /// <summary>
        /// 删除单个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int Delete(Guid? id);
        /// <summary>
        /// 删除单个实体
        /// </summary>
        int Delete(Expression<Func<T, bool>> where);
        /// <summary>
        /// 删除单个实体
        /// </summary>
        int Delete(Where<T> where);
        #endregion

    }
}
