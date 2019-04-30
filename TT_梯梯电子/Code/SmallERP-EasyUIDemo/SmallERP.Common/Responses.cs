using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SmallERP.Common
{
    [XmlRoot("error_response", Namespace = "", IsNullable = false)]
    public class Error
    {
        [JsonProperty("success")]
        public bool Success = false;

        [JsonProperty("error_code")]
        public string ErrorCode;

        [JsonProperty("error_msg")]
        public string ErrorMsg;

        [JsonProperty("error_detail")]
        public string ErrorDetail;

        [JsonProperty("data")]
        public object ErrorData;

    }


    public class Responses
    {
        /// <summary>
        /// 输出正确信息
        /// </summary>
        /// <returns></returns>
        public static string Success()
        {
            return Success(string.Empty, string.Empty);
        }

        /// <summary>
        /// 输出正确信息
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Success(string key, string value)
        {
            string responseStr = string.Empty;
            StringBuilder result = new StringBuilder("");
            result.Append("{");
            result.Append("\"success\":true");
            if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
            {
                result.AppendFormat(",\"{0}\":{1}", key, value);
            }
            result.Append("}");

            return result.ToString();
        }

        /// <summary>
        /// 输出正确信息
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SuccessPage(string key, string value, int total)
        {
            string responseStr = string.Empty;
            StringBuilder result = new StringBuilder("");
            result.Append("{");
            result.Append("\"success\":true,");
            result.Append("\"pagenum\":" + total);
            if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
            {
                result.AppendFormat(",\"{0}\":{1}", key, value);
            }
            result.Append("}");

            return result.ToString();
        }



        /// <summary>
        /// 输出正确信息
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SuccessUrl(string key, string value)
        {
            string responseStr = string.Empty;
            StringBuilder result = new StringBuilder("");
            result.Append("{");
            result.Append("\"success\":true");
            if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
            {
                result.AppendFormat(",\"{0}\":\"{1}\"", key, value);
            }
            result.Append("}");

            return result.ToString();
        }

        /// <summary>
        /// 输出错误信息
        /// </summary>
        /// <returns></returns>
        public static string Errors()
        {
            return Errors(string.Empty, string.Empty, string.Empty, null);
        }

        /// <summary>
        /// 输出错误信息
        /// </summary>
        /// <param name="errorMsg">错误提示信息</param>
        /// <returns></returns>
        public static string Errors(string errorMsg)
        {
            return Errors(string.Empty, errorMsg, string.Empty, null);
        }

        /// <summary>
        /// 输出错误信息
        /// </summary>
        /// <param name="errorCode">错误代码</param>
        /// <param name="errorMsg">错误提示信息</param>
        /// <returns></returns>
        public static string Errors(string errorCode, string errorMsg)
        {
            return Errors(errorCode, errorMsg, string.Empty, string.Empty);
        }

        /// <summary>
        /// 输出错误信息
        /// </summary>
        /// <param name="errorCode">错误代码</param>
        /// <param name="errorMsg">错误提示信息</param>
        /// <param name="errorData">错误数据</param>
        /// <returns></returns>
        public static string Errors(string errorCode, string errorMsg, object errorData)
        {
            return Errors(errorCode, errorMsg, string.Empty, errorData);
        }


        /// <summary>
        /// 输出错误信息
        /// </summary>
        /// <param name="errorCode">错误代码</param>
        /// <param name="errorMsg">错误提示信息</param>
        /// <param name="errorDetail">错误详细信息</param>
        /// <param name="errorData">错误数据</param>
        /// <returns></returns>
        public static string Errors(string errorCode, string errorMsg, string errorDetail, object errorData)
        {
            Error e = new Error();
            e.ErrorCode = errorCode;
            e.ErrorMsg = errorMsg;
            e.ErrorDetail = errorDetail;
            e.ErrorData = errorData;
            return Errors(e);
        }

        /// <summary>
        /// / 输出错误信息
        /// </summary>
        /// <param name="e">错误实体</param>
        /// <returns></returns>
        public static string Errors(Error e)
        {
            return JsonConvert.SerializeObject(e);
        }

        /// <summary>
        /// 返回结果
        /// </summary>
        /// <param name="response">输入的信息</param>
        public static void Write(string response)
        {
            System.Web.HttpContext.Current.Response.Clear();
            System.Web.HttpContext.Current.Response.ContentType = "text/xml";
            System.Web.HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
            System.Web.HttpContext.Current.Response.ContentType = "text/html";
            System.Web.HttpContext.Current.Response.Write(response);
            System.Web.HttpContext.Current.Response.End();
        }
    }
}
