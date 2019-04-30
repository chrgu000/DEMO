using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace SmallERP.Common
{
    public class SuccessJsonResult : MyJsonResult
    {
        // 保护默认构造函数，防止外部实例化
        protected SuccessJsonResult() { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="data">需要传递的数据</param>
        /// <param name="count">返回的结果集总数<remarks>常用在数据分页中</remarks></param>
        public SuccessJsonResult(Object data = null, int count = 0)
        {
            success = true;
            rows = data;
            total = count;
        }


        public object rows { get; set; }

        public int total { get; set; }
    }
}
