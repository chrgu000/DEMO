﻿using System;
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
    public class TK_Base_Calendar_DayoffBusiness
    {
        private readonly TK_Base_Calendar_DayoffData dal = new TK_Base_Calendar_DayoffData();

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public List<TK_Base_Calendar_DayoffEntity> DataTableToList(DataTable dt)
        {
            List<TK_Base_Calendar_DayoffEntity> modelList = new List<TK_Base_Calendar_DayoffEntity>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                TK_Base_Calendar_DayoffEntity model;
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
        public List<TK_Base_Calendar_DayoffEntity> GetList(string sWhere)
        {
            List<TK_Base_Calendar_DayoffEntity> result;
            result = dal.GetList(sWhere);
            return result;
        }

        /// <summary>
        /// 获取分页数据列表
        /// </summary>
        /// <param name="domain"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public DataTable GetList(string sWhere, SearchAdminDomain domain, out int total)
        {
            DataTable result;
            result = dal.GetList(sWhere, domain.UserId, domain.Name, domain.RoleId, domain.RowStart(), domain.RowEnd(), out total);
            return result;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string Update(TK_Base_Calendar_DayoffEntity model)
        {
            //bool result = false;
            string result = "";
            TK_Base_Calendar_DayoffData dal = new TK_Base_Calendar_DayoffData();
            // 插入数据库
            if (string.IsNullOrEmpty(model.iID.ToString()) || model.iID == 0)
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

            TK_Base_Calendar_DayoffData dal = new TK_Base_Calendar_DayoffData();
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

            TK_Base_Calendar_DayoffData dal = new TK_Base_Calendar_DayoffData();
            result = dal.Delete(iID);


            return result;
        }

    }
}
