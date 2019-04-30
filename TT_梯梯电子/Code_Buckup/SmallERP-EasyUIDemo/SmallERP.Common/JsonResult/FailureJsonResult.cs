using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace SmallERP.Common
{
    public class FailureJsonResult : MyJsonResult
    {
        // 保护构造函数，防止外部实例化
        protected FailureJsonResult() { }

        public FailureJsonResult(string msg)
        {
            success = false;
            message = msg;
        }

        /// <summary>
        /// 返回的错误信息
        /// </summary>
        public string message { get; set; }
    }
}
