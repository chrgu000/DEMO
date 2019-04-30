using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallERP.Domain
{

    /// <summary>
    /// 针对Easyui的树形属性结构
    /// </summary>
    public class PermissionNodeDomain
    {
        /// <summary>
        /// 节点Id
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// 节点名称
        /// </summary>
        public string text { get; set; }

        /// <summary>
        /// 状态  open/close
        /// </summary>
        public string state { get; set; }

        /// <summary>
        /// 默认是否选中
        /// </summary>
        public bool @checked { get; set; }

        /// <summary>
        /// 节点图标CSS类
        /// </summary>
        public string iconCls { get; set; }

        /// <summary>
        /// 额外属性
        /// </summary>
        public NodeAttributes attributes { get; set; }

        /// <summary>
        /// 子节点
        /// </summary>
        public List<PermissionNodeDomain> children { get; set; }
    }


    public class NodeAttributes
    {
        /// <summary>
        /// url
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 排序号
        /// </summary>
        public int sort { get; set; }
    }
}
