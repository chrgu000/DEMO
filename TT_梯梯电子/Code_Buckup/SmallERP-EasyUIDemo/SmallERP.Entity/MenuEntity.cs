using System;
using System.Collections.Generic;
using System.Text;

namespace SmallERP.Entity
{
    /// <summary>
    /// 菜单实体
    /// </summary>
    public class MenuEntity
    {
        /// <summary>
        /// 菜单ID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 父节点Id
        /// </summary>
        public string ParentID { get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 请求地址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 排序号
        /// </summary>
        public int? Sort { get; set; }

        /// <summary>
        /// 是否禁用
        /// </summary>
        public int? IsDisabled { get; set; }
    }
}
