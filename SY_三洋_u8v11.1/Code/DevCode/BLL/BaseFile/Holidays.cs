using System;
using System.Data;
using System.Collections.Generic;
using TH.Model;
namespace TH.BLL
{
    /// <summary>
    /// Holidays
    /// </summary>
    public partial class Holidays
    {
        private readonly TH.DAL.Holidays dal = new TH.DAL.Holidays();
        public Holidays()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(DateTime dHolidays)
        {
            return dal.Exists(dHolidays);
        }

        public int Del(DataTable dt)
        {
            TH.Model.Holidays Model = new TH.Model.Holidays();
            string sReturn = "";

            List<TH.Model.Holidays> l = new List<TH.Model.Holidays>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (!Convert.ToBoolean(dt.Rows[i]["choose"]))
                    continue;

                Model = DataRowToModel(dt.Rows[i]);
                l.Add(Model);
            }
            if (sReturn.Trim() != "")
                throw new Exception(sReturn);

            int iCou = dal.Del(l);
            return iCou;
        }

        public int Save(DataTable dt)
        {
            TH.Model.Holidays Model = new TH.Model.Holidays();
            string sReturn = "";

            int iCouMR = 0;
            List<TH.Model.Holidays> l = new List<TH.Model.Holidays>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (!Convert.ToBoolean(dt.Rows[i]["choose"]))
                    continue;

                if (dt.Rows[i]["HolidaysText"].ToString().Trim() == "")
                {
                    sReturn = sReturn + "行" + (i + 1).ToString() + "假期类型不能为空\n";
                    continue;
                }

                Model = DataRowToModel(dt.Rows[i]);

                l.Add(Model);
            }
            if (iCouMR > 1)
            {
                sReturn = sReturn + "默认产线只能且必须只有一个\n";
            }

            if (sReturn.Trim() != "")
                throw new Exception(sReturn);

            int iCou = dal.Save(l);
            return iCou;
        }

        public TH.Model.Holidays DataRowToModel(DataRow row)
        {
            return dal.DataRowToModel(row);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(TH.Model.Holidays model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string Update(TH.Model.Holidays model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public string Delete(int iID)
        {

            return dal.Delete(iID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(DateTime dHolidays)
        {

            return dal.Delete(dHolidays);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string iIDlist)
        {
            return dal.DeleteList(iIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TH.Model.Holidays GetModel(int iID)
        {

            return dal.GetModel(iID);
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataTable GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<TH.Model.Holidays> GetModelList(string strWhere)
        {
            DataTable ds = dal.GetList(strWhere);
            return DataTableToList(ds);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<TH.Model.Holidays> DataTableToList(DataTable dt)
        {
            List<TH.Model.Holidays> modelList = new List<TH.Model.Holidays>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                TH.Model.Holidays model;
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
        public DataTable GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataTable GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataTable GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

