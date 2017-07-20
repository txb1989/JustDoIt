using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Jst.Core.Ioc
{
    /// <summary>
    /// 注册接口
    /// </summary>
    public interface IIocRegistrar
    {
        #region register types
        /// <summary>
        /// 注册，注册泛型
        /// </summary>
        /// <param name="typeImplements"></param>
        /// <param name="typeInterface"></param>
        void RegisterGeneric(Type typeImplements, Type typeInterface, string name = "", bool interceptor = true);

        /// <summary>
        /// 注册接口和实现类，如果已经注册，则覆盖
        /// </summary>
        /// <typeparam name="TImplement"></typeparam>
        /// <typeparam name="TInterface"></typeparam>
        void RegisterType<TImplement, TInterface>(string name = "", bool interceptor = true);

        void RegisterType(Type typeImplements, Type typeInerface, string name="", bool interceptor = true);

        /// <summary>
        /// 批量注册类型
        /// </summary>
        /// <param name="types"></param>
        void RegisterTypes(params Type[] types);


        /// <summary>
        /// 不用接口的方式注册，直接注册对象
        /// </summary>
        /// <param name="interceptor">是否需要拦截</param>
        /// <param name="types">类型</param>
        void RegisterTypeAsObject(bool interceptor = true, params Type[] types);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="interceptor"></param>
        void RegisterTypeAsObjectByName(string name, Type type, bool interceptor);


        /// <summary>
        /// 批量注册程序集
        /// </summary>
        /// <param name="predicate">约束</param>
        /// <param name="assemblies"></param>
        void RegisterAssemblies(Func<Type, bool> predicate, params Assembly[] assemblies);

        /// <summary>
        /// 批量注册程序集
        /// </summary>
        /// <param name="assemblies"></param>
        void RegisterAssemblies(params Assembly[] assemblies);
        
        #endregion

    }
}
