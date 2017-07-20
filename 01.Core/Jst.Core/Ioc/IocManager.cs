using Autofac;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Jst.Utils.Extension;
using Jst.Utils;
using Autofac.Builder;
using Autofac.Extras.DynamicProxy;
using Jst.Core.JstInterceptors;
using Jst.Core.Extensions;

namespace Jst.Core.Ioc
{
    public class IocManager : IIocManager
    {
        /// <summary>
        /// 实例容器，用来产生实例
        /// </summary>
        public static IIocManager Instance = new Lazy<IIocManager>(() => new IocManager(), true).Value;

        /// <summary>
        /// 
        /// </summary>
        private ContainerBuilder _builder = null;

        internal ContainerBuilder Builder
        {
            get
            {
                return this._builder;
            }
        }

        private IContainer _container = null;

        private IocManager()
        {
            _builder = new ContainerBuilder();
        }

        #region register方法


        /// <summary>
        /// 单个注册方法
        /// </summary>
        /// <typeparam name="TImplement"></typeparam>
        /// <typeparam name="TInterface"></typeparam>
        public void RegisterType<TImplement, TInterface>(string name = "", bool interceptor = true)
        {
            if (name.IsEmpty()) name = typeof(TImplement).GetAliasName();
            RegisterComponent<TImplement, TInterface>(_builder, builder => builder, name, interceptor);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeImplements"></param>
        /// <param name="typeInerface"></param>
        /// <param name="name"></param>
        public void RegisterType(Type typeImplements, Type typeInerface, string name = "", bool interceptor = true)
        {
            if (name.IsEmpty()) name = typeImplements.GetAliasName();
            RegisterComponent(_builder, typeImplements, typeInerface, builder => builder, name, interceptor);
        }

        /// <summary>
        /// 注册泛型方法
        /// </summary>
        /// <param name="typeImplements"></param>
        /// <param name="typeInterface"></param>
        public void RegisterGeneric(Type typeImplements, Type typeInterface, string name = "", bool interceptor = true)
        {
            if (name.IsEmpty()) name = typeImplements.GetAliasName();
            RegisterGenericComponent(_builder, typeImplements, typeInterface, builder => builder, name, interceptor);
        }

        /// <summary>
        /// 注册类型
        /// </summary>
        /// <param name="types"></param>
        public void RegisterTypes(params Type[] types)
        {
            _builder.RegisterTypes(types).AsImplementedInterfaces().InterceptedBy(typeof(JstCoreInterceptor)).EnableInterfaceInterceptors();
        }

        public void RegisterTypeAsObject(bool interceptor = true, params Type[] types)
        {
            if (interceptor)
            {
                _builder.RegisterTypes(types).InterceptedBy(typeof(JstCoreInterceptor)).EnableInterfaceInterceptors();
            }
            else
            {
                _builder.RegisterTypes(types);
            }
        }

        public void RegisterTypeAsObjectByName(string name, Type type, bool interceptor)
        {
            if (interceptor)
            {
                _builder.RegisterTypes(type).Named(name, type).InterceptedBy(typeof(JstCoreInterceptor)).EnableInterfaceInterceptors();
            }
            else
            {
                //_builder.RegisterTypes(type);
                _builder.RegisterType(type).Named(name, type);
            }
        }

        /// <summary>
        /// 批量注册程序集
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="assemblies"></param>
        public void RegisterAssemblies(Func<Type, bool> predicate, params Assembly[] assemblies)
        {

            #region 单例
            _builder.RegisterAssemblyTypes(assemblies)
                   .Where(predicate)
                  .Where(c => typeof(ISingleInstance).IsAssignableFrom(c))
                   .AsImplementedInterfaces().SingleInstance().InterceptedBy(typeof(JstCoreInterceptor)).EnableInterfaceInterceptors();
            #endregion

            #region 每次注入
            _builder.RegisterAssemblyTypes(assemblies)
                 .Where(predicate)
                 .Where(c => typeof(IInstancePerDependency).IsAssignableFrom(c))
                 .AsImplementedInterfaces().InstancePerDependency().InterceptedBy(typeof(JstCoreInterceptor)).EnableInterfaceInterceptors();
            #endregion

            #region 生命周期
            _builder.RegisterAssemblyTypes(assemblies)
                  .Where(predicate)
                 .Where(c => typeof(IInstancePerDependency).IsAssignableFrom(c))
                  .AsImplementedInterfaces().InstancePerLifetimeScope().InterceptedBy(typeof(JstCoreInterceptor)).EnableInterfaceInterceptors();
            #endregion

            _builder.RegisterAssemblyTypes(assemblies).Where(predicate).Where(
                c => !typeof(ISingleInstance).IsAssignableFrom(c)
                && !typeof(IInstancePerDependency).IsAssignableFrom(c)
                && !typeof(IInstancePerLifetimeScope).IsAssignableFrom(c)
                && typeof(IDependency).IsAssignableFrom(c)
                ).AsImplementedInterfaces().SingleInstance().InterceptedBy(typeof(JstCoreInterceptor)).EnableInterfaceInterceptors();

        }

        public void RegisterAssemblies(params Assembly[] assemblies)
        {
            RegisterAssemblies(c => true, assemblies);
        }

        #endregion

        #region check Register

        /// <summary>
        /// 检查是否注册
        /// </summary>
        /// <typeparam name="TInterface"></typeparam>
        /// <returns></returns>
        public bool IsRegister<TInterface>()
        {
            return IsRegister(typeof(TInterface));
        }

        /// <summary>
        /// 检查是否注册
        /// </summary>
        /// <typeparam name="TInterface"></typeparam>
        /// <returns></returns>
        public bool IsRegister(Type types)
        {
            if (_container != null)
            {
                return _container.IsRegistered(types);
            }
            return false;
        }

        #endregion

        #region Resolve

        /// <summary>
        /// 实例化一个对象
        /// </summary>
        /// <typeparam name="TInterface"></typeparam>
        /// <returns></returns>
        public TInterface Resolve<TInterface>(string name = "")
        {
            TInterface tinterface = default(TInterface);
            if (name.IsEmpty())
            {
                if (IsRegister<TInterface>())
                {
                    tinterface = _container.Resolve<TInterface>();
                }
            }
            else
            {
                tinterface = ResolveNamed<TInterface>(name);
            }
            return tinterface;
        }

        public TInterface ResolveNamed<TInterface>(string name)
        {
            TInterface tinterface = default(TInterface); ;
            //if (IsRegister<TInterface>())
            if (_container.IsRegisteredWithName<TInterface>(name))
            {
                tinterface = _container.ResolveNamed<TInterface>(name);
            }
            return tinterface;
        }

        public void OperateContainner(Action<IContainer> action)
        {
            action(_container);
        }

        public void OperateBuilder(Action<ContainerBuilder> action)
        {
            action(_builder);
        }

        #endregion

        /// <summary>
        /// 扫描bin目录里面的dll，如果包含IJstAppModule的模块，则依次执行接口的方法
        /// </summary>
        public void InitIoc()
        {
            List<JstModuleInfo> moduleList = new List<JstModuleInfo>();
            // string[] dllPaths = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll", SearchOption.AllDirectories);
            string[] dllPaths = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.*", SearchOption.AllDirectories).Where(c =>
            {
                string ext = Path.GetExtension(c);
                return ".dll,.exe".IndexOf(ext) > -1;
            }).ToArray();
            foreach (var dll in dllPaths)
            {
                try
                {
                    ///开始用LoadPath加载程序集，再MVC模式下总有些dll加载不进来，就算加载进来也有问题，找不到IJstAppModule，完全不清楚怎么回事，再这里标注一下
                    //Assembly assembly = Assembly.LoadPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, dll));
                    Assembly assembly = Assembly.Load(Assembly.LoadFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, dll)).FullName);
                    Type moduleType = assembly.DefinedTypes.FirstOrDefault(x =>typeof(IJstAppModule).IsAssignableFrom(x));
                    if (moduleType != null
                        && !moduleList.Contains(x => x.ModuleName == moduleType.Name)
                        )
                    {
                        IJstAppModule _appModule = assembly.CreateInstance(moduleType.FullName) as IJstAppModule;// Activator.CreateInstance(moduleType) as IJstAppModule;
                        moduleList.Add(new JstModuleInfo()
                        {
                            AssemblyInfo = assembly,
                            Instance = _appModule,
                            ModuleName = moduleType.Name,
                            SortNo = _appModule.SortNo
                        });
                    }
                }
                catch (Exception)
                {
                    continue;
                }
            }
            EnsureCoreFirst(moduleList);
            moduleList.Foreach(c => c.Instance.PreInit(this));
            moduleList.ForEach(c => c.Instance.Init(c));
            RebuildAutofac();
            moduleList.ForEach(c => c.Instance.PostInit());
        }

        public void Dispose()
        {
            _container.Dispose();
        }

        private List<IJstAppModule> _appModuleList = new List<IJstAppModule>();

        #region private methods
        private List<JstModuleInfo> EnsureCoreFirst(List<JstModuleInfo> moduleList)
        {
            //if (moduleList.IsNotEmpty())
            //{
            //    JstModuleInfo coreModule = moduleList.FirstOrDefault(c => c.Instance.Is<JstCoreModule>());
            //    if (coreModule.IsNotNull())
            //    {
            //        moduleList.Remove(coreModule);
            //        moduleList.Insert(0, coreModule);
            //    }
            //}
            //return moduleList;
            moduleList = moduleList.OrderBy(c => c.SortNo).ToList();
            return moduleList;
        }

        /// <summary>
        /// 重新构建
        /// </summary>
        private void RebuildAutofac()
        {
            _container = _builder.Build();
        }

        private IRegistrationBuilder<TImplement, ConcreteReflectionActivatorData, SingleRegistrationStyle> RegisterComponent<TImplement, TInterface>(ContainerBuilder builder,
        Func<IRegistrationBuilder<TImplement, ConcreteReflectionActivatorData, SingleRegistrationStyle>,
        IRegistrationBuilder<TImplement, ConcreteReflectionActivatorData, SingleRegistrationStyle>> expression, string name = "", bool isInterceptors = true)
        {
            IRegistrationBuilder<TImplement, ConcreteReflectionActivatorData, SingleRegistrationStyle> ret = null;
            if (typeof(ISingleInstance).IsAssignableFrom(typeof(TInterface)))
            {
                if (name.IsEmpty())
                {
                    ret = builder.RegisterType<TImplement>().As<TInterface>().SingleInstance();
                }
                else
                {
                    ret = builder.RegisterType<TImplement>().Named<TInterface>(name).SingleInstance();
                }
            }
            else if (typeof(IInstancePerDependency).IsAssignableFrom(typeof(TInterface)))
            {
                if (name.IsEmpty())
                {
                    ret = builder.RegisterType<TImplement>().As<TInterface>().InstancePerDependency();
                }
                else
                {
                    ret = builder.RegisterType<TImplement>().Named<TInterface>(name).InstancePerDependency();
                }
            }
            else
            {
                if (name.IsEmpty())
                {
                    ret = builder.RegisterType<TImplement>().As<TInterface>().InstancePerLifetimeScope();
                }
                else
                {
                    ret = builder.RegisterType<TImplement>().Named<TInterface>(name).InstancePerLifetimeScope();
                }
            }
            return isInterceptors ? expression(ret).InterceptedBy(typeof(JstCoreInterceptor)).EnableInterfaceInterceptors() : expression(ret);

            //RegisterComponent(builder, typeof(TImplement), typeof(TInterface), expression);
        }

        private IRegistrationBuilder<object, ConcreteReflectionActivatorData, SingleRegistrationStyle> RegisterComponent(ContainerBuilder builder, Type typeImplements, Type typeInterface,
           Func<IRegistrationBuilder<object, ConcreteReflectionActivatorData, SingleRegistrationStyle>,
               IRegistrationBuilder<object, ConcreteReflectionActivatorData, SingleRegistrationStyle>> expression, string name = "", bool isInterceptors = true)
        {
            IRegistrationBuilder<object, ConcreteReflectionActivatorData, SingleRegistrationStyle> ret = null;
            if (typeof(ISingleInstance).IsAssignableFrom(typeInterface))
            {
                ret = builder.RegisterType(typeImplements).As(typeInterface).SingleInstance();
                if (name.IsEmpty())
                {
                    ret = builder.RegisterType(typeImplements).As(typeInterface).SingleInstance();
                }
                else
                {
                    ret = builder.RegisterType(typeImplements).Named(name, typeInterface).SingleInstance();
                }
            }
            else if (typeof(IInstancePerDependency).IsAssignableFrom(typeInterface))
            {
                //ret = builder.RegisterType(typeImplements).As(typeInterface).InstancePerDependency();
                if (name.IsEmpty())
                {
                    ret = builder.RegisterType(typeImplements).As(typeInterface).InstancePerDependency();
                }
                else
                {
                    ret = builder.RegisterType(typeImplements).Named(name, typeInterface).InstancePerDependency();
                }
            }
            else
            {
                //ret = builder.RegisterType(typeImplements).As(typeInterface).InstancePerLifetimeScope();
                if (name.IsEmpty())
                {
                    ret = builder.RegisterType(typeImplements).As(typeInterface).InstancePerLifetimeScope();
                }
                else
                {
                    ret = builder.RegisterType(typeImplements).Named(name, typeInterface).InstancePerLifetimeScope();
                }
            }
            return isInterceptors ? expression(ret).InterceptedBy(typeof(JstCoreInterceptor)).EnableInterfaceInterceptors() : expression(ret);
        }


        private IRegistrationBuilder<object, ReflectionActivatorData, DynamicRegistrationStyle> RegisterGenericComponent(ContainerBuilder builder, Type typeImplements, Type typeInterface,
           Func<IRegistrationBuilder<object, ReflectionActivatorData, DynamicRegistrationStyle>,
               IRegistrationBuilder<object, ReflectionActivatorData, DynamicRegistrationStyle>> expression, string name = "", bool isInterceptors = true)
        {
            IRegistrationBuilder<object, ReflectionActivatorData, DynamicRegistrationStyle> ret = null;
            if (typeof(ISingleInstance).IsAssignableFrom(typeInterface))
            {
                if (name.IsEmpty())
                {
                    ret = builder.RegisterGeneric(typeImplements).As(typeInterface).SingleInstance();
                }
                else
                {
                    ret = builder.RegisterGeneric(typeImplements).Named(name, typeInterface).SingleInstance();
                }
            }
            else if (typeof(IInstancePerDependency).IsAssignableFrom(typeInterface))
            {
                if (name.IsEmpty())
                {
                    ret = builder.RegisterGeneric(typeImplements).As(typeInterface).InstancePerDependency();
                }
                else
                {
                    ret = builder.RegisterGeneric(typeImplements).Named(name, typeInterface).InstancePerDependency();
                }
            }
            else
            {
                if (name.IsEmpty())
                {
                    ret = builder.RegisterGeneric(typeImplements).As(typeInterface).InstancePerLifetimeScope();
                }
                else
                {
                    ret = builder.RegisterGeneric(typeImplements).Named(name, typeInterface).InstancePerLifetimeScope();
                }
            }
            return isInterceptors ? expression(ret).InterceptedBy(typeof(JstCoreInterceptor)).EnableInterfaceInterceptors() : expression(ret);
        }


        #endregion
    }
}
