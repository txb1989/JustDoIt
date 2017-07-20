using Dos.ORM;
using Jst.Core.Ioc;
using Jst.Core.Log;
using Jst.Log4net;

namespace Jst.DosOrmRepository
{
    public class Db
    {
        public static readonly DbSession Context = new DbSession("LocalDb");

        private static readonly IJstCoreLogs _logger;

        static Db()
        {
            if (IocManager.Instance.IsRegister<IJstCoreLogs>())
            {
                _logger = IocManager.Instance.Resolve<IJstCoreLogs>();
            }
          else
            {
                _logger = JstCoreLog4net.Instance;
            }
            Context.RegisterSqlLogger(delegate (string sql)
            {
                //在此可以记录sql日志
                //写日志会影响性能，建议开发版本记录sql以便调试，发布正式版本不要记录
                //LogHelper.Debug(sql, "SQL日志");
                _logger.Debug(sql);
            });

        }

    }
}
