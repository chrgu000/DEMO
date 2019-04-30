using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallERP.Common.Enums
{
    /// <summary>
    /// 数据状态
    /// </summary>
    public enum DataStatus
    {
        /// <summary>
        /// 不可删除的
        /// </summary>
        [Description("不可删除")]
        NoDelete = 7,

        /// <summary>
        /// 无效的
        /// </summary>
        [Description("无效的")]
        Invalid = 0,

        /// <summary>
        /// 有效的
        /// </summary>
        [Description("有效的")]
        Normal = 1,

        /// <summary>
        /// 删除
        /// </summary>
        [Description("删除")]
        Delete = -9,

        /// <summary>
        /// 数据待产生
        /// </summary>
        [Description("数据待产生")]
        UnCreate = -10
    }
}
