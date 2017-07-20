using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jst.Core.Entities
{

    public interface ISoftDeleteTime
    {
        /// <summary>
        /// 删除时间
        /// </summary>
        DateTime? DeleteTime { get; set; }
    }

    public interface ISoftDeleted<TForeignKey> : ISoftDeleteTime where TForeignKey : struct
    {
        /// <summary>
        /// 删除人
        /// </summary>
        TForeignKey? DeleteUserId { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        bool IsDeleted { get; set; }

    }

    public interface ISoftDeleteUser<TForeignKey, TUser> : ISoftDeleted<TForeignKey> where TForeignKey : struct
    {
        TUser DeleteUser { get; set; }
    }
}
