using Jst.Core.JstException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jst.Core.JsJsonResult
{
    /// <summary>
    /// ajax请求返回Json基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class JstAjaxJsonResult<T>
    {
        public JstAjaxJsonResult()
        {
            Status = false;
            Result = 0;
            Message = string.Empty;
            Exception = null;
            Data = default(T);
        }

        /// <summary>
        /// 调用状态
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// 请求结果
        /// </summary>
        public int Result { get; set; }

        /// <summary>
        /// 结果消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 异常信息
        /// </summary>
        public JstCoreException Exception { get; set; }

        /// <summary>
        /// 返回数据
        /// </summary>
        public T Data { get; set; }

    }

    /// <summary>
    /// ajax请求返回类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class JstAjaxJsonResult : JstAjaxJsonResult<object>
    {

    }
}
