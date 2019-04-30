using System;
using System.Data;
using System.Collections.Generic;
using TH.Model;
namespace TH.BLL
{
    /// <summary>
    /// InvLineCycle
    /// </summary>
    public partial class InvLineCycle
    {
        private readonly TH.DAL.InvLineCycle dal = new TH.DAL.InvLineCycle();
        public InvLineCycle()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int iID)
        {
            return dal.Exists(iID);
        }

        public int Del(DataTable dt)
        {
            TH.Model.InvLineCycle Model = new TH.Model.InvLineCycle();
            string sReturn = "";

            List<TH.Model.InvLineCycle> l = new List<TH.Model.InvLineCycle>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (!Convert.ToBoolean(dt.Rows[i]["choose"]))
                    continue;

                Model = DataRowToModel(dt.Rows[i]);

                ////判断已经使用不能删除
                //if (dal.bUsed(Model.LineNo))
                //{
                //    sReturn = sReturn + "行" + (i + 1).ToString() + "已经使用过，不能删除\n";
                //    continue;
                //}

                if (Model.cInvCode == "")
                {
                    sReturn = sReturn + "行" + (i + 1).ToString() + "存货编码不能为空\n";
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
            TH.Model.InvLineCycle Model = new TH.Model.InvLineCycle();
            string sReturn = "";

            int iCouMR = 0;
            List<TH.Model.InvLineCycle> l = new List<TH.Model.InvLineCycle>();
     
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = i + 1; j < dt.Rows.Count; j++)
                {
                    if (dt.Rows[i]["LineNo"].ToString().Trim() == dt.Rows[j]["LineNo"].ToString().Trim())
                    {
                        sReturn = sReturn + "行" + (i + 1).ToString() + "与行" + (j + 1).ToString() + "产线一样\n";
                        break;
                    }
                }

                Model = DataRowToModel(dt.Rows[i]);

                if (Model.cInvCode == "")
                {
                    sReturn = sReturn + "行" + (i + 1).ToString() + "存货不能为空\n";
                    continue;
                }

                if (Model.Priority && Model.LineNo != "")
                {
                    iCouMR += 1;
                }

                if (Model.SelfCycleB == null)
                    Model.SelfCycleB = 1;

                if (Model.SelfSetupCycle == null)
                    Model.SelfSetupCycle = 0;

              
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

        public TH.Model.InvLineCycle DataRowToModel(DataRow row)
        {
            return dal.DataRowToModel(row);
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
        public TH.Model.InvLineCycle GetModel(int iID)
        {

            return dal.GetModel(iID);
        }
   
        public DataTable GetInventory(string cInvCode)
        {
            return dal.GetInventory(cInvCode);
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
        /// 
        /// </summary>
        public DataTable GetLookUp()
        {
            return dal.GetLookUp();
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<TH.Model.InvLineCycle> GetModelList(string strWhere)
        {
            DataTable ds = dal.GetList(strWhere);
            return DataTableToList(ds);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<TH.Model.InvLineCycle> DataTableToList(DataTable dt)
        {
            List<TH.Model.InvLineCycle> modelList = new List<TH.Model.InvLineCycle>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                TH.Model.InvLineCycle model;
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

