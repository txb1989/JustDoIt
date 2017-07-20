using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jst.Core.Log
{
    /// <summary>
    /// 默认的接口，
    /// </summary>
    public interface IJstNullLogs:IJstCoreLogs
    {

    }
    /// <summary>
    /// 空日志，什么都不做
    /// </summary>
    public class JstNullLogs : IJstNullLogs
    {
        public void Debug(string msg)
        {
        }

        public void Debug(string msg, Exception ex)
        {
        }

        public void Error(string msg)
        {
        }

        public void Error(string msg, Exception ex)
        {
        }

        public void Fatal(string msg)
        {
        }

        public void Fatal(string msg, Exception ex)
        {
        }

        public void Info(string msg)
        {
        }

        public void Info(string msg, Exception ex)
        {
        }

        public void Warn(string msg)
        {
        }

        public void Warn(string msg, Exception ex)
        {
        }
    }
}
