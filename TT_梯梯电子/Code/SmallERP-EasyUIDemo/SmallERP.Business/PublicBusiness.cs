using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmallERP.Common;
using SmallERP.DataAccess;
using SmallERP.Entity;
using SmallERP.Domain;
using System.Data;
using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Web;
using System.Web.Script.Serialization;
using System.Text.RegularExpressions;

namespace SmallERP.Business
{
    public class PublicBusiness
    {
        private readonly PublicData dal = new PublicData();

        /// <summary>
        /// 计划员
        /// </summary>
        /// <returns></returns>
        public object GetPlannerList()
        {
            return ToObject(dal.GetPlannerList());
        }

        /// <summary>
        /// category
        /// </summary>
        /// <returns></returns>
        public object GetcategoryList()
        {
            return ToObject(dal.GetcategoryList());
        }

        /// <summary>
        /// 项目组
        /// </summary>
        /// <returns></returns>
        public object GetProductGroupList()
        {
            return ToObject(dal.GetProductGroupList());
        }

        /// <summary>
        /// 仓库
        /// </summary>
        /// <returns></returns>
        public object GetWarehouseList()
        {
            return ToObject(dal.GetWarehouseList());
        }

        /// <summary>
        /// 版本号
        /// </summary>
        /// <returns></returns>
        public object GetVersionList()
        {
            return ToObject(dal.GetVersionList());
        }

        /// <summary>
        /// 获得7个月
        /// </summary>
        /// <returns></returns>
        public object GetPeriod()
        {
            return ToObject(dal.GetPeriod());
        }

        public object ToObject(DataTable dt)
        {
            IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
            timeFormat.DateTimeFormat = "yyyy-MM-dd";

            string s = JsonConvert.SerializeObject(dt, timeFormat);
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = int.MaxValue;

            object obj = js.DeserializeObject(s);
            return obj;
        }

        public object ToObject(DataTable dt, string Format)
        {
            IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
            timeFormat.DateTimeFormat = Format;

            string s = JsonConvert.SerializeObject(dt, timeFormat);
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = int.MaxValue;

            object obj = js.DeserializeObject(s);
            return obj;
        }

        /// <summary>
        /// Json 字符串 转换为 DataTable数据集合
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public DataTable ToDataTable(string strJson)
        {
            ////取出表名  
            //Regex rg = new Regex(@"(?<={)[^:]+(?=:/[)", RegexOptions.IgnoreCase);
            //string strName = rg.Match(strJson).Value;
            DataTable tb = null;
            ////去除表名  
            //strJson = strJson.Substring(strJson.IndexOf("[") + 1);
            //strJson = strJson.Substring(0, strJson.IndexOf("]"));

            //获取数据  
            Regex rg = new Regex(@"(?<={)[^}]+(?=})");
            MatchCollection mc = rg.Matches(strJson);
            for (int i = 0; i < mc.Count; i++)
            {
                string strRow = mc[i].Value;
                string[] strRows = strRow.Split(',');

                //创建表  
                if (tb == null)
                {
                    tb = new DataTable();
                    tb.TableName = "";
                    foreach (string str in strRows)
                    {
                        DataColumn dc = new DataColumn();
                        string[] strCell = str.Split(':');

                        dc.ColumnName = strCell[0].ToString().Replace("\"", "").Trim();
                        tb.Columns.Add(dc);
                    }
                    tb.AcceptChanges();
                }

                //增加内容  
                DataRow dr = tb.NewRow();
                for (int r = 0; r < strRows.Length; r++)
                {
                    dr[r] = strRows[r].Split(':')[1].Trim().Replace("，", ",").Replace("：", ":").Replace("/", "").Replace("\"", "").Trim();
                }
                tb.Rows.Add(dr);
                tb.AcceptChanges();
            }

            return tb;
        }
    }
}
