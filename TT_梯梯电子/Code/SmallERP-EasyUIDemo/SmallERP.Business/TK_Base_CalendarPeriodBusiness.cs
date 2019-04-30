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

namespace SmallERP.Business
{
    public class TK_Base_CalendarPeriodBusiness
    {
        private readonly TK_Base_CalendarPeriodData dal = new TK_Base_CalendarPeriodData();

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public List<TK_Base_CalendarPeriodEntity> DataTableToList(DataTable dt)
        {
            List<TK_Base_CalendarPeriodEntity> modelList = new List<TK_Base_CalendarPeriodEntity>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                TK_Base_CalendarPeriodEntity model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="sWhere"></param>
        /// <returns></returns>
        public List<TK_Base_CalendarPeriodEntity> GetList(string sWhere)
        {
            List<TK_Base_CalendarPeriodEntity> result;
            result = dal.GetList(sWhere);
            return result;
        }

        /// <summary>
        /// 获得17个工作日历数据
        /// </summary>
        /// <param name="iYear">年</param>
        /// <param name="iMonth">月</param>
        /// <returns></returns>
        public DataTable GetList(string iYear, string iMonth)
        {
            DataTable result;
            result = dal.GetList(iYear, iMonth);
            return result;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string Update(TK_Base_CalendarPeriodEntity model)
        {
            //bool result = false;
            string result = "";
            TK_Base_CalendarPeriodData dal = new TK_Base_CalendarPeriodData();
            // 插入数据库
            if (string.IsNullOrEmpty(model.iID.ToString()))
            {
                result = dal.Add(model);
            }
            else {
                result = dal.Update(model);
            }
                
            return result;
        }

        /// <summary>
        /// 更新多条数据
        /// </summary>
        /// <param name="aList"></param>
        /// <returns></returns>
        public bool Update(ArrayList aList)
        {
            bool result = false;

            TK_Base_CalendarPeriodData dal = new TK_Base_CalendarPeriodData();
            result = dal.Update(aList);
            

            return result;
        }

    }
}
