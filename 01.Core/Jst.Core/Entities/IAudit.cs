using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jst.Core.Entities
{
    public interface IAudit<TForeignKey> where TForeignKey : struct
    {
        /// <summary>
        /// 审核人
        /// </summary>
        TForeignKey? AuditUserId { get; set; }

        /// <summary>
        /// 审核时间
        /// </summary>
        DateTime AuditTime { get; set; }

        /// <summary>
        /// 审核信息
        /// </summary>
        string AuditReason { get; set; }
    }

    public interface IAuditUser<TForeignKey,TUser> : IAudit<TForeignKey> where TForeignKey : struct
    {
        TUser AuditUser { get; set; }
    }
}
