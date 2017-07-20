using Jst.Core;
using Jst.Core.Attributes;
using Jst.Core.Ioc;
using Jst.Utils;
using Jst.Utils.Extension;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Jst.EntityFramework.Extensions
{
    public static class IocExtension
    {
        /// <summary>
        /// 注册所有的程序集下的DbContext
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="assemblies"></param>
        public static void RegisterDbContext(this IIocManager instance, params Assembly[] assemblies)
        {
            assemblies.Foreach((assembly) =>
            {
                var dbContextTypes = assembly.GetTypes().Where(type => typeof(DbContext).IsAssignableFrom(type)).ToArray();
                instance.RegisterTypeAsObject(false, dbContextTypes);
            });
        }

        /// <summary>
        /// 注册程序集下所有的仓储，即只要继承至IRepository接口
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="assemblies"></param>
        public static void RegsiterRepositories(this IIocManager instance, params Assembly[] assemblies)
        {
            assemblies.Foreach(assembly =>
            {
                RegisterRepository(instance,assembly, typeof(IRepository<,>));
                //说明，IRepository<>这个接口被我干掉了，注入不上
                //RegisterRepository(instance, assembly, typeof(IRepository<>));
            });
        }

        public static void RegisterRepository(IIocManager instance,Assembly assembly,Type typeinterface)
        {
            var repositoryType = assembly.GetTypes().Where(type => type.GetInterfaces().Any(c => c.GUID == typeinterface.GUID) && !type.IsInterface);
            repositoryType.Foreach(type =>
            {
                var attribute = type.GetCustomAttribute<RegisterAliasNameAttribute>();
                string name = string.Empty;
                if (attribute.IsNotNull())
                {
                    name = attribute.AliasName;
                }
                instance.RegisterRepository(type, typeinterface, name);
            });
        }

        public static void RegisterRepository(this IIocManager instance, Type type, Type interRepositoryType, string name)
        {
            if (type.IsGenericType)
            {
                Type interfaceType = type.GetInterfaces().FirstOrDefault(item => item.GetInterfaces().Any(c => c.GUID == typeof(IRepository<,>).GUID) && item.GUID != typeof(IRepository<,>).GUID);
                if (interfaceType.IsNotNull())
                {
                    instance.RegisterGeneric(type, interfaceType,name);
                }
                instance.RegisterGeneric(type, interRepositoryType, name);
            }
            else
            {
                instance.RegisterTypes(type);
            }
        }

    }
}
