using System;
using System.Data;
using System.Collections.Generic;
using TH.Model;
namespace TH.BLL
{
    /// <summary>
    /// ProductionLineState
    /// </summary>
    public partial class ProductionLineState
    {
        private readonly TH.DAL.ProductionLineState dal = new TH.DAL.ProductionLineState();
        public ProductionLineState()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string LineNo)
        {
            return dal.Exists(LineNo);
        }


        public int Del(DateTime dTime)
        {
            bool b = CheckCanEdit(dTime);
            if (b)
            {
                throw new Exception("已经登记生产并发数量信息,不能删除");
            }

            if (dal.CheckPC(dTime))
            {
                throw new Exception("已经排产,不能删除");
            }

            return dal.Del(dTime);
        }

        public bool CheckCanEdit(DateTime dTime)
        {
            return dal.CheckCanEdit(dTime);
        }

        public int Save(DateTime dTime, DataTable dt)
        {
            if (CheckCanEdit(dTime))
            {
                throw new Exception("已经登记生产并发数量信息,不能修改");
            }

            if (dal.CheckPC(dTime))
            {
                throw new Exception("已经排产,不能删除");
            }

            TH.Model.ProductionLineState Model = new TH.Model.ProductionLineState();
            string sReturn = "";

            List<TH.Model.ProductionLineState> l = new List<TH.Model.ProductionLineState>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Model = DataRowToModel(dt.Rows[i]);

                if (Model.LineNo == "")
                {
                    sReturn = sReturn + "行" + (i + 1).ToString() + "序号不能为空\n";
                    continue;
                }

                if (Model.LineName == "")
                {
                    sReturn = sReturn + "行" + (i + 1).ToString() + "工作中心不能为空\n";
                    continue;
                }

                l.Add(Model);

            }
            if (sReturn.Trim() != "")
                throw new Exception(sReturn);

            int iCou = dal.Save(l);
            return iCou;
        }

        /// <summary>
        /// 获得参照表
        /// </summary>
        public DataSet GetLookUp(List<string> l)
        {
            return dal.GetLookUp(l);
        }

        public TH.Model.ProductionLineState DataRowToModel(DataRow row)
        {
            return dal.DataRowToModel(row);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string LineNo)
        {

            return dal.Delete(LineNo);
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
        public TH.Model.ProductionLineState GetModel(int iID)
        {

            return dal.GetModel(iID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetMonthList(string strWhere)
        {
            return dal.GetMonthList(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetMonthList2(string strWhere)
        {
            return dal.GetMonthList2(strWhere);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<TH.Model.ProductionLineState> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<TH.Model.ProductionLineState> DataTableToList(DataTable dt)
        {
            List<TH.Model.ProductionLineState> modelList = new List<TH.Model.ProductionLineState>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                TH.Model.ProductionLineState model;
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
        public DataSet GetAllList()
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
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

