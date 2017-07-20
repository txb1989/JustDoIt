using Autofac;
using Jst.Core.Cache;
using Jst.Core.Ioc;
using Jst.Core.JstInterceptors;
using Jst.Core.Log;
using Jst.Core.Uow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jst.Core
{
    public class JstCoreRegister
    {
        private static IIocManager _instance { get; set; }

        static JstCoreRegister()
        {
            _instance = IocManager.Instance;
        }
        /// <summary>
        /// 注册Core里面的核心组件
        /// </summary>
        public static void RegisterCoreDefaultComponent()
        {
            //_instance.RegisterType<JstDefaultCached, ICached>("DefaultCache");
            _instance.RegisterType<JstDefaultCached, ICached>();
            _instance.RegisterType<JstDefaultCached, ICached>("DefaultCache");
            _instance.RegisterType<JstNullLogs, IJstCoreLogs>(interceptor:false);
            _instance.RegisterType<DefaultUnitOfWork, IUnitOfWork>(interceptor: false);
            _instance.RegisterType<UniteOfWorkManager, IUniteOfWorkManager>(interceptor: false);
            (_instance as IocManager).Builder.Register(c=>new JstCoreInterceptor());
        }
        
    }
}
