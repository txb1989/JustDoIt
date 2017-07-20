using Jst.Core.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jst.Core.Log
{
    /*<!--控制级别，由低到高: ALL|DEBUG|INFO|WARN|ERROR|FATAL|OFF-->  */
    public interface IJstCoreLogs: ISingleInstance
    {
        void Debug(string msg);
        void Debug(string msg, Exception ex);
        
        void Info(string msg);
        void Info(string msg, Exception ex);

        void Warn(string msg);
        void Warn(string msg, Exception ex);

        void Error(string msg);
        void Error(string msg, Exception ex);

        void Fatal(string msg);
        void Fatal(string msg, Exception ex);
        
    }
}
