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
    public class TK_PeriodBusiness
    {
        private readonly TK_PeriodData dal = new TK_PeriodData();

        ///// <summary>
        ///// 获得数据列表
        ///// </summary>
        ///// <param name="dt"></param>
        ///// <returns></returns>
        //public List<TK_PeriodEntity> DataTableToList(DataTable dt)
        //{
        //    List<TK_PeriodEntity> modelList = new List<TK_PeriodEntity>();
        //    int rowsCount = dt.Rows.Count;
        //    if (rowsCount > 0)
        //    {
        //        TK_PeriodEntity model;
        //        for (int n = 0; n < rowsCount; n++)
        //        {
        //            model = dal.DataRowToModel(dt.Rows[n]);
        //            if (model != null)
        //            {
        //                modelList.Add(model);
        //            }
        //        }
        //    }
        //    return modelList;
        //}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="sWhere"></param>
        /// <returns></returns>
        public DataTable GetList(string sWhere)
        {
            return dal.GetList(sWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="sWhere"></param>
        /// <returns></returns>
        public DataTable GetList2(string sWhere)
        {
            return dal.GetList2(sWhere);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="iYear"></param>
        /// <param name="iMonth"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public string Update(string iYear, string iMonth, TK_PeriodEntity model)
        {
            //bool result = false;
            string result = "";
            TK_PeriodData dal = new TK_PeriodData();
            // 插入数据库
            int i = dal.Exists(iYear, iMonth);
            if (i == 0)
            {
                result = dal.Add(model);
            }
            else
            {
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

            TK_PeriodData dal = new TK_PeriodData();
            result = dal.Update(aList);
            

            return result;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="iID"></param>
        /// <returns></returns>
        public string Delete(string iID)
        {
            string result = "";

            TK_PeriodData dal = new TK_PeriodData();
            result = dal.Delete(iID);


            return result;
        }

    }
}
