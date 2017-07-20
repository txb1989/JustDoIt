using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jst.Core.Entities
{
    public interface IUpdateDateTime
    {
        /// <summary>
        /// 更新时间
        /// </summary>
        DateTime? UpdateTime { get; set; }
    }

    public interface IUpdate<TForeignKey>: IUpdateDateTime where TForeignKey : struct
    {
        /// <summary>
        /// 更新人
        /// </summary>
        TForeignKey? UpdateUserId { get; set; }
        
    }

    public interface IUpdateAuditUser<TUser, TForeignKey> : IUpdate<TForeignKey> where TForeignKey : struct
    {
        TUser UpdateUser { get; set; }
    }

}
