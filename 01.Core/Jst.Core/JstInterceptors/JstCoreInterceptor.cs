using Castle.DynamicProxy;
using Jst.Core.Ioc;
using Jst.Core.Log;
using Jst.Utils;
using Jst.Utils.Extension;
using System.Collections.Generic;
using System.Linq;

namespace Jst.Core.JstInterceptors
{
    /// <summary>
    /// 框架代理的拦截器，用AOP方式可以阻断内容从处理
    /// </summary>
    public class JstCoreInterceptor : IInterceptor
    {
        protected IJstCoreLogs _logger;
        public JstCoreInterceptor()
        {
            /**为啥我在这儿不注入这个Log对象，因为Ioc都被我注入了一个拦截器，拦截器里面又注入一个log对象。导致的问题就是循环了。
             * 实例化拦截器有趣实例化log对象，实例log对象的时候又要实例拦截器，周而复始了*/
           // _logger = IocManager.Instance.Resolve<IJstCoreLogs>();
        }

        public JstCoreInterceptor(IJstCoreLogs logger)
        {
            _logger = logger;
        }

        public void Intercept(IInvocation invocation)
        {
            List<IProcesser> list = new List<IProcesser>();
            #region MyRegion
            object[] attributes = invocation.Method.GetCustomAttributes(true);
            try
            {
                if (attributes.IsNotEmpty())
                {
                    var processAttribute = attributes.Where(c => c.Is<IProcesser>());
                    processAttribute.Foreach((item) =>
                    {
                        if (item.Is<IProcesser>())
                        {
                            //item.Cast<IProcesser>().Process();
                            list.Add(item.Cast<IProcesser>());
                        }
                    });
                }
                list.ForEach(item => { if (!item.Processing()) { throw new InterruptException("中断执行") { Source = item.GetType().FullName   }; } });
                invocation.Proceed();
                list.ForEach(item => { item.Processed(); });
            }
            catch (InterruptException ex)
            {
                //_logger.Info(ex.Message, ex);
            }
            #endregion
        }
    }
}
