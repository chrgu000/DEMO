using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SmallERP.Common
{
    /// <summary>
    /// Web端返回Json格式数据
    /// </summary>
    public abstract class MyJsonResult
    {
        /// <summary>
        /// 是否成功返回数据
        /// </summary>
        public bool success { get; set; }


        /// <summary>
        /// 额外要传递的数据
        /// </summary>
        public object extraData { get; set; }
    }
}
