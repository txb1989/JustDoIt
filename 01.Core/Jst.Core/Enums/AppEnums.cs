using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jst.Core.Enums
{
    /// <summary>
    /// 实体状态枚举
    /// </summary>
   public enum EnumEntityStatus
    {
        /// <summary>
        /// 有效
        /// </summary>
        [Description("有效")]
        Enable,
        /// <summary>
        /// 禁用
        /// </summary>
        [Description("禁用")]
        Disabled,
        /// <summary>
        /// 删除
        /// </summary>
        [Description("删除")]
        Deleted
    }

    /// <summary>
    /// 各种模块的排序值
    /// </summary>
    public enum EnumModuleComponent
    {
        Core = 0,
        CoreComponent = 100,
        BusyComponent = 200
    }
}
