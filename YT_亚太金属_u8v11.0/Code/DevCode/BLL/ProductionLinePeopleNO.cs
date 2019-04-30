using System;
using System.Data;
using System.Collections.Generic;
using TH.Model;
namespace TH.BLL
{
    /// <summary>
    /// ProductionLinePeopleNO
    /// </summary>
    public partial class ProductionLinePeopleNO
    {
        private readonly TH.DAL.ProductionLinePeopleNO dal = new TH.DAL.ProductionLinePeopleNO();
        public ProductionLinePeopleNO()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string LineNO, DateTime dDate)
        {
            return dal.Exists(LineNO, dDate);
        }

        public int Del(DateTime dTime)
        {
            if (dal.CheckPC(dTime))
            {
                throw new Exception("已经排产,不能删除");
            }

            return dal.Del(dTime);
        }


        public int Save(DataTable dt)
        {
            TH.Model.ProductionLinePeopleNO Model = new TH.Model.ProductionLinePeopleNO();
            string sReturn = "";

            List<TH.Model.ProductionLinePeopleNO> l = new List<TH.Model.ProductionLinePeopleNO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Model = DataRowToModel(dt.Rows[i]);
                if (Model.PeopleNO == null)
                {
                    throw new Exception("并发数量必须填写");
                }

                if (Model.LineNO == "")
                {
                    sReturn = sReturn + "行" + (i + 1).ToString() + "序号不能为空\n";
                    continue;
                }

                l.Add(Model);
            }
            if (sReturn.Trim() != "")
                throw new Exception(sReturn);

            int iCou = dal.Save(l);
            return iCou;
        }

        public TH.Model.ProductionLinePeopleNO DataRowToModel(DataRow row)
        {
            return dal.DataRowToModel(row);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetMonthList(string strWhere)
        {
            return dal.GetMonthList(strWhere);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(TH.Model.ProductionLinePeopleNO model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string Update(TH.Model.ProductionLinePeopleNO model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string LineNO, DateTime dDate)
        {

            return dal.Delete(LineNO, dDate);
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
        public TH.Model.ProductionLinePeopleNO GetModel(int iID)
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
        public DataSet GetList2(string strWhere)
        {
            return dal.GetList2(strWhere);
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
        public List<TH.Model.ProductionLinePeopleNO> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<TH.Model.ProductionLinePeopleNO> DataTableToList(DataTable dt)
        {
            List<TH.Model.ProductionLinePeopleNO> modelList = new List<TH.Model.ProductionLinePeopleNO>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                TH.Model.ProductionLinePeopleNO model;
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

