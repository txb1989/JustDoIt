using Jst.Core.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ioc.Test.Services
{
    public class MyService : IService, IDependency
    {
        public int Add(int x, int y)
        {
            return x + y;
        }
    }

    public class MyServiceGeneric<T> : IServiceGeneric<T>, IDependency
    {
        public bool equal(T x, T y)
        {
            return x.Equals(y);
        }
    }

    public class MyObjectProvider<T> : IObjectProvider<T> where T : MyDbObject
    {
        public MyDbObject GetObject()
        {
            return IocManager.Instance.Resolve<T>();
        }
    }

    public class RepositoryA<TPrimaryKey, TEntity> : IRepository<TPrimaryKey, TEntity>
    {

        public RepositoryA(IObjectProvider<Object1> _provider)
        {
        }

        public TEntity Get(TPrimaryKey id)
        {
            return default(TEntity);
        }
    }

    public class RepositoryB<TPrimaryKey, TEntity> : IRepository<TPrimaryKey, TEntity>
    {

        public RepositoryB(IObjectProvider<Object2> _provider)
        {
        }

        public TEntity Get(TPrimaryKey id)
        {
            return default(TEntity);
        }
    }


    public class MyServiceGeneric2 : IServiceGeneric2<int>, IDependency
    {
        public bool equal(int x, int y)
        {
            return x == y;
        }
    }

}
