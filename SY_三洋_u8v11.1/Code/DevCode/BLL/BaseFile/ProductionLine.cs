using System;
using System.Data;
using System.Collections.Generic;
using TH.Model;
namespace TH.BLL
{
    /// <summary>
    /// ProductionLine
    /// </summary>
    public partial class ProductionLine
    {
        private readonly TH.DAL.ProductionLine dal = new TH.DAL.ProductionLine();
        
        public ProductionLine()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string LineNo)
        {
            return dal.Exists(LineNo);
        }

        public int Del(DataTable dt)
        {
            TH.Model.ProductionLine Model = new TH.Model.ProductionLine();
            string sReturn = "";

            List<TH.Model.ProductionLine> l = new List<TH.Model.ProductionLine>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (!Convert.ToBoolean(dt.Rows[i]["choose"]))
                    continue;

                Model = DataRowToModel(dt.Rows[i]);

                //判断已经使用不能删除
               if(dal.bUsed(Model.LineNo))
               {
                   sReturn = sReturn + "行" + (i + 1).ToString() + "已经使用过，不能删除\n";
                   continue;
               }

                if (Model.LineNo == "")
                {
                    sReturn = sReturn + "行" + (i + 1).ToString() + "序号不能为空\n";
                    continue;
                }

                if (Model.CloseUid != "")
                {
                    sReturn = sReturn + "行" + (i + 1).ToString() + "已经关闭\n";
                    continue;
                }

                l.Add(Model);

            }
            if (sReturn.Trim() != "")
                throw new Exception(sReturn);

            int iCou = dal.Del(l);
            return iCou;
        }

        public int Save(DataTable dt)
        {
            TH.Model.ProductionLine Model = new TH.Model.ProductionLine();
            string sReturn = "";

            List<TH.Model.ProductionLine> l = new List<TH.Model.ProductionLine>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (!Convert.ToBoolean(dt.Rows[i]["choose"]))
                    continue;

                Model = DataRowToModel(dt.Rows[i]);

                if (Model.LineNo == "")
                {
                    sReturn = sReturn + "行" + (i + 1).ToString() + "序号不能为空\n";
                    continue;
                }

                if (Model.LineName == "")
                {
                    sReturn = sReturn + "行" + (i + 1).ToString() + "产线不能为空\n";
                    continue;
                }

                if (Model.CloseUid != "")
                {
                    sReturn = sReturn + "行" + (i + 1).ToString() + "已经关闭\n";
                    continue;  
                }

                l.Add(Model);

            }
            if (sReturn.Trim() != "")
                throw new Exception(sReturn);

            int iCou =  dal.Save(l);
            return iCou;
        }

        public int Open(DataTable dt)
        {
            TH.Model.ProductionLine Model = new TH.Model.ProductionLine();
            string sReturn = "";

            List<TH.Model.ProductionLine> l = new List<TH.Model.ProductionLine>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (!Convert.ToBoolean(dt.Rows[i]["choose"]))
                    continue;

                Model = DataRowToModel(dt.Rows[i]);

                if (Model.LineNo == "")
                {
                    sReturn = sReturn + "行" + (i + 1).ToString() + "序号不能为空\n";
                    continue;
                }

                if (Model.LineName == "")
                {
                    sReturn = sReturn + "行" + (i + 1).ToString() + "产线不能为空\n";
                    continue;
                }

                l.Add(Model);

            }
            int iCou = dal.Open(l);
            return iCou;
        }

        public int Close(DataTable dt)
        {
            TH.Model.ProductionLine Model = new TH.Model.ProductionLine();
            string sReturn = "";

            List<TH.Model.ProductionLine> l = new List<TH.Model.ProductionLine>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (!Convert.ToBoolean(dt.Rows[i]["choose"]))
                    continue;

                Model = DataRowToModel(dt.Rows[i]);

                if (Model.LineNo == "")
                {
                    sReturn = sReturn + "行" + (i + 1).ToString() + "序号不能为空\n";
                    continue;
                }

                if (Model.LineName == "")
                {
                    sReturn = sReturn + "行" + (i + 1).ToString() + "产线不能为空\n";
                    continue;
                }

                l.Add(Model);

            }
            int iCou = dal.Close(l);
            return iCou;
        }


        ///// <summary>
        ///// 增加一条数据
        ///// </summary>
        //public int Add(TH.Model.ProductionLine model)
        //{
        //    return dal.Add(model);
        //}

        ///// <summary>
        ///// 更新一条数据
        ///// </summary>
        //public bool Update(TH.Model.ProductionLine model)
        //{
        //    return dal.Update(model);
        //}

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int iID)
        {

            return dal.Delete(iID);
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
        public TH.Model.ProductionLine GetModel(int iID)
        {

            return dal.GetModel(iID);
        }

        public TH.Model.ProductionLine DataRowToModel(DataRow row)
        {
            return dal.DataRowToModel(row);
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
        public List<TH.Model.ProductionLine> GetModelList(string strWhere)
        {
            DataTable ds = dal.GetList(strWhere);
            return DataTableToList(ds);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<TH.Model.ProductionLine> DataTableToList(DataTable dt)
        {
            List<TH.Model.ProductionLine> modelList = new List<TH.Model.ProductionLine>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                TH.Model.ProductionLine model;
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

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

