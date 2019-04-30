using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallERP.Domain
{
    /// <summary>
    /// 文件上传返回信息
    /// </summary>
    public class UploadFileInfo
    {
        /// <summary>
        /// 原始文件名
        /// </summary>
        public string OriginalName { get; set; }
        /// <summary>
        /// 上传的路径
        /// </summary>
        public string SavePath { get; set; }
    }
}
