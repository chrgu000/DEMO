using System;
using System.Data;
using System.Collections.Generic;
using TH.Model;
namespace TH.BLL
{
    /// <summary>
    /// WorkCalendar
    /// </summary>
    public partial class WorkCalendar
    {
        private readonly TH.DAL.WorkCalendar dal = new TH.DAL.WorkCalendar();
        public WorkCalendar()
        { }
        #region  BasicMethod

        public int Save(DataTable dt产线, DataTable dt)
        {
            TH.Model.WorkCalendar Model = new TH.Model.WorkCalendar();
            string sReturn = "";

            List<TH.Model.WorkCalendar> l = new List<TH.Model.WorkCalendar>();

            for (int j = 0; j < dt产线.Rows.Count; j++)
            {
                if (!Convert.ToBoolean(dt产线.Rows[j]["选择"]))
                    continue;

                string sLineNo = dt产线.Rows[j]["LineNo"].ToString().Trim();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (!Convert.ToBoolean(dt.Rows[i]["choose"]))
                        continue;

                    Model = DataRowToModel(dt.Rows[i]);

                    if (sLineNo == "")
                    {
                        sReturn = sReturn + (i + 1).ToString() + "产线不能为空\n";
                    }
                    Model.LineNo = sLineNo;

                    if (Model.i1 > 24 || Model.i1 < 0)
                    {
                        sReturn = sReturn + (i + 1).ToString() + "月1号工时不合理\n";
                    }

                    if (Model.i2 > 24 || Model.i2 < 0)
                    {
                        sReturn = sReturn + (i + 1).ToString() + "月2号工时不合理\n";
                    }

                    if (Model.i3 > 24 || Model.i3 < 0)
                    {
                        sReturn = sReturn + (i + 1).ToString() + "月3号工时不合理\n";
                    }

                    if (Model.i4 > 24 || Model.i4 < 0)
                    {
                        sReturn = sReturn + (i + 1).ToString() + "月4号工时不合理\n";
                    }

                    if (Model.i5 > 24 || Model.i5 < 0)
                    {
                        sReturn = sReturn + (i + 1).ToString() + "月5号工时不合理\n";
                    }

                    if (Model.i6 > 24 || Model.i6 < 0)
                    {
                        sReturn = sReturn + (i + 1).ToString() + "月6号工时不合理\n";
                    }

                    if (Model.i7 > 24 || Model.i7 < 0)
                    {
                        sReturn = sReturn + (i + 1).ToString() + "月7号工时不合理\n";
                    }

                    if (Model.i8 > 24 || Model.i8 < 0)
                    {
                        sReturn = sReturn + (i + 1).ToString() + "月8号工时不合理\n";
                    }

                    if (Model.i9 > 24 || Model.i9 < 0)
                    {
                        sReturn = sReturn + (i + 1).ToString() + "月9号工时不合理\n";
                    }

                    if (Model.i10 > 24 || Model.i10 < 0)
                    {
                        sReturn = sReturn + (i + 1).ToString() + "月10号工时不合理\n";
                    }

                    if (Model.i11 > 24 || Model.i11 < 0)
                    {
                        sReturn = sReturn + (i + 1).ToString() + "月11号工时不合理\n";
                    }

                    if (Model.i12 > 24 || Model.i12 < 0)
                    {
                        sReturn = sReturn + (i + 1).ToString() + "月12号工时不合理\n";
                    }

                    if (Model.i13 > 24 || Model.i13 < 0)
                    {
                        sReturn = sReturn + (i + 1).ToString() + "月13号工时不合理\n";
                    }

                    if (Model.i14 > 24 || Model.i14 < 0)
                    {
                        sReturn = sReturn + (i + 1).ToString() + "月14号工时不合理\n";
                    }

                    if (Model.i15 > 24 || Model.i15 < 0)
                    {
                        sReturn = sReturn + (i + 1).ToString() + "月15号工时不合理\n";
                    }

                    if (Model.i16 > 24 || Model.i16 < 0)
                    {
                        sReturn = sReturn + (i + 1).ToString() + "月16号工时不合理\n";
                    }

                    if (Model.i17 > 24 || Model.i17 < 0)
                    {
                        sReturn = sReturn + (i + 1).ToString() + "月17号工时不合理\n";
                    }

                    if (Model.i18 > 24 || Model.i18 < 0)
                    {
                        sReturn = sReturn + (i + 1).ToString() + "月18号工时不合理\n";
                    }

                    if (Model.i19 > 24 || Model.i19 < 0)
                    {
                        sReturn = sReturn + (i + 1).ToString() + "月19号工时不合理\n";
                    }

                    if (Model.i20 > 24 || Model.i20 < 0)
                    {
                        sReturn = sReturn + (i + 1).ToString() + "月20号工时不合理\n";
                    }

                    if (Model.i21 > 24 || Model.i21 < 0)
                    {
                        sReturn = sReturn + (i + 1).ToString() + "月21号工时不合理\n";
                    }

                    if (Model.i22 > 24 || Model.i22 < 0)
                    {
                        sReturn = sReturn + (i + 1).ToString() + "月22号工时不合理\n";
                    }

                    if (Model.i23 > 24 || Model.i23 < 0)
                    {
                        sReturn = sReturn + (i + 1).ToString() + "月23号工时不合理\n";
                    }

                    if (Model.i24 > 24 || Model.i24 < 0)
                    {
                        sReturn = sReturn + (i + 1).ToString() + "月24号工时不合理\n";
                    }

                    if (Model.i25 > 24 || Model.i25 < 0)
                    {
                        sReturn = sReturn + (i + 1).ToString() + "月25号工时不合理\n";
                    }

                    if (Model.i26 > 24 || Model.i26 < 0)
                    {
                        sReturn = sReturn + (i + 1).ToString() + "月26号工时不合理\n";
                    }

                    if (Model.i27 > 24 || Model.i27 < 0)
                    {
                        sReturn = sReturn + (i + 1).ToString() + "月27号工时不合理\n";
                    }

                    if (Model.i28 > 24 || Model.i28 < 0)
                    {
                        sReturn = sReturn + (i + 1).ToString() + "月28号工时不合理\n";
                    }

                    if (Model.i29 > 24 || Model.i29 < 0)
                    {
                        sReturn = sReturn + (i + 1).ToString() + "月29号工时不合理\n";
                    }

                    if (Model.i30 > 24 || Model.i30 < 0)
                    {
                        sReturn = sReturn + (i + 1).ToString() + "月30号工时不合理\n";
                    }

                    if (Model.i31 > 24 || Model.i31 < 0)
                    {
                        sReturn = sReturn + (i + 1).ToString() + "月31号工时不合理\n";
                    }

                    l.Add(Model);
                }
            }
            if (sReturn.Trim() != "")
                throw new Exception(sReturn);

            int iCou = dal.Save(l);
            return iCou;
        }

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
        public TH.Model.WorkCalendar GetModel(int iID)
        {

            return dal.GetModel(iID);
        }

        public DataTable GetHolidays(string strWhere)
        {
            return dal.GetHolidays(strWhere);
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
        public List<TH.Model.WorkCalendar> GetModelList(string strWhere)
        {
            DataTable ds = dal.GetList(strWhere);
            return DataTableToList(ds);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<TH.Model.WorkCalendar> DataTableToList(DataTable dt)
        {
            List<TH.Model.WorkCalendar> modelList = new List<TH.Model.WorkCalendar>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                TH.Model.WorkCalendar model;
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

        public TH.Model.WorkCalendar DataRowToModel(DataRow row)
        {
            return dal.DataRowToModel(row);
        }

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

