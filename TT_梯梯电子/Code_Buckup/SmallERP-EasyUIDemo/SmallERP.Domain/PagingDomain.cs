using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallERP.Domain
{
    /// <summary>
    /// EasyUI 分页属性
    /// </summary>
    public class PagingDomain
    {
        /// <summary>
        /// 页码
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// 每页数量
        /// </summary>
        public int Rows { get; set; }
        /// <summary>
        /// 排序字段
        /// </summary>
        public string sort { get; set; }
        /// <summary>
        /// 排序方向
        /// </summary>
        public string order { get; set; }


        public int RowStart()
        {
            return (Page - 1) * Rows + 1;
        }

        public int RowEnd()
        {
            return Page * Rows;
        }
    }
}
