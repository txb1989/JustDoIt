using Dos.ORM;
using Jst.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Jst.DosOrmRepository
{
    public class DosOrmRepositoryBase<T> :IDosOrmRepository<T> where T:Entity
    {
        #region 查询
        /// <summary>
        /// 获取整表数据
        /// </summary>
        /// <returns></returns>
        public  List<T> GetAll()
        {
            return Db.Context.From<T>().ToList();
        }
        /// <summary>
        /// 通用查询
        /// </summary>
        public  List<T> Query(Expression<Func<T, bool>> where, Expression<Func<T, object>> orderBy = null, string ascOrDesc = "asc", int? top = null, int? pageSize = null, int? pageIndex = null)
        {
            var fs = Db.Context.From<T>().Where(where);
            if (top != null)
            {
                fs.Top(top.Value);
            }
            else if (pageIndex != null && pageSize != null)
            {
                fs.Page(pageSize.Value, pageIndex.Value);
            }
            if (orderBy != null)
            {
                if (ascOrDesc.ToLower() == "asc")
                {
                    fs.OrderBy(orderBy);
                }
                else
                {
                    fs.OrderByDescending(orderBy);
                }
            }
            return fs.ToList();
        }
        /// <summary>
        /// 通用查询
        /// </summary>
        public  List<T> Query(Where<T> where, Expression<Func<T, object>> orderBy = null, string ascOrDesc = "asc", int? top = null, int? pageSize = null, int? pageIndex = null)
        {
            var fs = Db.Context.From<T>().Where(where);
            if (top != null)
            {
                fs.Top(top.Value);
            }
            else if (pageIndex != null && pageSize != null)
            {
                fs.Page(pageSize.Value, pageIndex.Value);
            }
            if (orderBy != null)
            {
                if (ascOrDesc.ToLower() == "asc")
                {
                    fs.OrderBy(orderBy);
                }
                else
                {
                    fs.OrderByDescending(orderBy);
                }
            }
            return fs.ToList();
        }
        /// <summary>
        /// 通用查询
        /// </summary>
        public  List<T> Query(Where<T> where, OrderByClip orderBy = null, string ascOrDesc = "asc", int? top = null, int? pageSize = null, int? pageIndex = null)
        {
            var fs = Db.Context.From<T>().Where(where);
            if (top != null) 
            {
                fs.Top(top.Value);
            }
            else if (pageIndex != null && pageSize != null)
            {
                fs.Page(pageSize.Value, pageIndex.Value);
            }
            if (orderBy != null)
            {
                fs.OrderBy(orderBy);
            }
            return fs.ToList();
        }
        /// <summary>
        /// 通用查询
        /// </summary>
        public  T First(Expression<Func<T, bool>> where, Expression<Func<T, object>> orderBy = null, string ascOrDesc = "asc", int? top = null, int? pageSize = null, int? pageIndex = null)
        {
            var fs = Db.Context.From<T>().Where(where);
            if (top != null)
            {
                fs.Top(top.Value);
            }
            else if (pageIndex != null && pageSize != null)
            {
                fs.Page(pageSize.Value, pageIndex.Value);
            }
            if (orderBy != null)
            {
                if (ascOrDesc.ToLower() == "asc")
                {
                    return fs.OrderBy(orderBy).First();
                }
                return fs.OrderByDescending(orderBy).First();
            }
            var model = fs.First();
            return model;
        }
        /// <summary>
        /// 通用查询
        /// </summary>
        public  T First(Where<T> where, Expression<Func<T, object>> orderBy = null, string ascOrDesc = "asc", int? top = null, int? pageSize = null, int? pageIndex = null)
        {
            var fs = Db.Context.From<T>().Where(where);
            if (top != null)
            {
                fs.Top(top.Value);
            }
            else if (pageIndex != null && pageSize != null)
            {
                fs.Page(pageSize.Value, pageIndex.Value);
            }
            if (orderBy != null)
            {
                if (ascOrDesc.ToLower() == "asc")
                {
                    return fs.OrderBy(orderBy).First();
                }
                return fs.OrderByDescending(orderBy).First();
            }
            return fs.First();
        }
        /// <summary>
        /// 根据条件判断是否存在数据
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public  bool Any(Expression<Func<T, bool>> where)
        {
            return Db.Context.Exists<T>(where);
        }
        /// <summary>
        /// 取总数
        /// </summary>
        public  int Count(Expression<Func<T, bool>> where)
        {
            return Db.Context.From<T>().Where(where).Count();
        }
        /// <summary>
        /// 取总数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public  int Count(Where<T> where)
        {
            return Db.Context.From<T>().Where(where).Count();
        }
        #endregion

        #region 插入
        /// <summary>
        /// 插入单个实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public  int Insert(T entity)
        {
            return Db.Context.Insert<T>(entity);
        }
        /// <summary>
        /// 插入单个实体
        /// </summary>
        /// <param name="context"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public  void Insert(DbTrans context, T entity)
        {
            Db.Context.Insert<T>(context, entity);
            //context.Set<T>().Add(entity);
        }
        /// <summary>
        /// 插入多个实体
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public  int Insert(IEnumerable<T> entities)
        {
            return Db.Context.Insert<T>(entities);
        }
        public  void Insert(DbTrans context, IEnumerable<T> entities)
        {
            Db.Context.Insert<T>(context, entities.ToArray());
        }
        #endregion

        #region 更新
        /// <summary>
        /// 更新单个实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public  int Update(T entity)
        {
            return Db.Context.Update(entity);
        }
        /// <summary>
        /// 更新单个实体
        /// </summary>
        public  int Update(T entity, Where where)
        {
            return Db.Context.Update(entity, where);
        }
        /// <summary>
        /// 更新单个实体
        /// </summary>
        public  int Update(T entity, Expression<Func<T, bool>> lambdaWhere)
        {
            return Db.Context.Update(entity, lambdaWhere);
        }
        public  void Update(DbTrans context, T entity)
        {
            Db.Context.Update(context, entity);
        }
        /// <summary>
        /// 更新多个实体
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public  int Update(IEnumerable<T> entities)
        {
            var enumerable = entities as T[] ?? entities.ToArray();
            Db.Context.Update(enumerable.ToArray());
            return 1;
        }
        public  void Update(DbTrans context, IEnumerable<T> entities)
        {
            Db.Context.Update(context, entities.ToArray());
        }
        #endregion

        #region 删除
        /// <summary>
        /// 删除单个实体
        /// </summary>
        public  int Delete(T entitie)
        {
            return Db.Context.Delete<T>(entitie);
        }
        /// <summary>
        /// 删除多个实体
        /// </summary>
        public  int Delete(IEnumerable<T> entities)
        {
            return Db.Context.Delete<T>(entities);
        }
        /// <summary>
        /// 删除单个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public  int Delete(Guid? id)
        {
            if (id == null)
            {
                return 0;
            }
            return Db.Context.Delete<T>(id.Value);
        }
        /// <summary>
        /// 删除单个实体
        /// </summary>
        public  int Delete(Expression<Func<T, bool>> where)
        {
            return Db.Context.Delete<T>(where);
        }
        /// <summary>
        /// 删除单个实体
        /// </summary>
        public  int Delete(Where<T> where)
        {
            return Db.Context.Delete<T>(where.ToWhereClip());
        }


        #endregion

        #region 不支持的方法
        public Task<List<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> AnyAsync(Expression<Func<T, bool>> where)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync(Expression<Func<T, bool>> where)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(T entity, Expression<Func<T, bool>> lambdaWhere)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(T entitie)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsynce(int key)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
