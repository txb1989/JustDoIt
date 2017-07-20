namespace Jst.Core.Ioc
{
    public interface IJstAppModule
    {
        /// <summary>
        /// 再注册调用执行
        /// </summary>
        /// <param name="instance"></param>
        void PreInit(IIocManager instance);

        /// <summary>
        /// 注册后，build前调用执行
        /// </summary>
        void Init(JstModuleInfo module);
        
        /// <summary>
        /// build以后调用执行
        /// </summary>
        void PostInit();

        int SortNo { get; }
    }

    /// <summary>
    /// 核心组件模块
    /// </summary>
    public interface ICoreComponentModule : IJstAppModule
    {

    }

    /// <summary>
    /// 业务组件模块
    /// </summary>
    public interface IBusyComponentModule: IJstAppModule
    {

    }
}
