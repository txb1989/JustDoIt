using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ioc.Test.Services
{
    public interface IService
    {
        int Add(int x, int y);
    }

    public interface IServiceGeneric<T>
    {
       bool equal(T x, T y);
    }

    public interface IObjectProvider<T> where T : MyDbObject
    {
        MyDbObject GetObject();
    }

    public interface IRepository<TPrimaryKey, TEntity>
    {
        TEntity Get(TPrimaryKey id);
    }


    public interface IServiceGeneric2<T>
    {
        bool equal(T x, T y);
    }

}
