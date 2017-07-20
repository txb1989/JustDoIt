using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jst.Core.Entities
{
    public interface ICreateTime
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        DateTime CreateTime { get; set; }
    }

    public interface ICreate<TForeinkey> : ICreateTime where TForeinkey : struct
    {
        /// <summary>
        /// 创建人,外键
        /// </summary>
        TForeinkey? CreateUserId { get; set; }
        
    }

    public interface ICreateAudit<TUser,TForeinkey>:ICreate<TForeinkey> where TForeinkey : struct
    {
        /// <summary>
        /// 
        /// </summary>
        TUser CreateUser { get; set; }
    }
}
