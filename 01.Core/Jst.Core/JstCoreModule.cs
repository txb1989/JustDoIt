using Jst.Core.Cache;
using Jst.Core.Enums;
using Jst.Core.Ioc;
using Jst.Core.Log;

namespace Jst.Core
{
    public class JstCoreModule : JstAppModuleBase
    {
        public override int SortNo { get { return (int)EnumModuleComponent.Core; } }

        public override void PreInit(IIocManager instance)
        {
            ////日志默认组件注册
            //instance.RegisterType<JstNullLogs, IJstCoreLogs>();
            /////缓存默认组件注册
            //instance.RegisterType<JstDefaultCached, ICached>();
            JstCoreRegister.RegisterCoreDefaultComponent();
        }

        public override void PostInit()
        {

        }
    }
}
