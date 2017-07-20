using Autofac;
using System;
using System.Reflection;

namespace Jst.Core.Ioc
{
    public interface IIocManager : IIocResolver, IIocRegistrar, IDisposable
    {
        #region check Register
        /// <summary>
        /// 检查某个类型是否注册
        /// </summary>
        /// <typeparam name="TInterface"></typeparam>
        /// <returns></returns>
        bool IsRegister<TInterface>();
        /// <summary>
        /// 检查某个类型是否注册
        /// </summary>
        /// <typeparam name="TInterface"></typeparam>
        /// <returns></returns>
        bool IsRegister(Type types);

        #endregion
        
        #region init
        /// <summary>
        /// 初始化，扫描所有实现了IJstAppModule接口的dll，进行注册
        /// </summary>
        void InitIoc();

        /// <summary>
        /// 对容器操作，会传入一个ContainnerBuilder
        /// 主要想法是不想在Core内部进行Mvc的集成，缺憾就是
        /// </summary>
        /// <param name="action"></param>
        void OperateContainner(Action<IContainer> action);

        /// <summary>
        /// 对Builder操作
        /// </summary>
        /// <param name="action"></param>
        void OperateBuilder(Action<ContainerBuilder> action);
        #endregion
    }
}
