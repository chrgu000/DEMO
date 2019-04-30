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
    public class TK_TrialkittingsBusiness
    {
        private readonly TK_TrialkittingsData dal = new TK_TrialkittingsData();

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<TK_TrialkittingsEntity> DataTableToList(DataTable dt)
        {
            List<TK_TrialkittingsEntity> modelList = new List<TK_TrialkittingsEntity>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                TK_TrialkittingsEntity model;
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
        /// 获得数据列表 导出Excel
        /// </summary>
        /// <returns></returns>
        public DataTable GetList(string sTKVersion, string qyPlanner, string qyGroup, string queryName, string qyReorderpolicy, SearchAdminDomain domain, out int total, bool b, bool b1)
        {
            TK_PeriodData tp = new TK_PeriodData();
            DataTable dtt = tp.GetList(sTKVersion);

            PublicBusiness p = new PublicBusiness();
            DataTable dt = dal.GetList(sTKVersion, qyPlanner, qyGroup, queryName, qyReorderpolicy, dtt, domain.UserId, domain.Name, domain.RoleId, domain.RowStart(), domain.RowEnd(), out total, b, b1);

            for (int i = 5; i < dt.Columns.Count;i++ )
            {
                for (int j = 3; j < dtt.Columns.Count; j++)
                {
                    string s1 = dt.Columns[i].ColumnName;
                    string s2 = DateTime.Parse(dtt.Rows[0][j].ToString()).ToString("yyyy-MM-dd");
                    if (s1 == s2)
                    {
                        dt.Columns[i].ColumnName = dtt.Columns[j].ColumnName;
                        continue;
                    }
                }
            }
            return dt;
        }

        ///// <summary>
        ///// 获得数据列表-导出Excel
        ///// </summary>
        ///// <returns></returns>
        //public DataTable GetList(string sTKVersion, string qyPlanner, string qyGroup, string qyReorderpolicy)
        //{
        //    TK_PeriodData tp = new TK_PeriodData();
        //    //string sTKVersionDate = sTKVersion.Split('-')[1];
        //    //int iYear = int.Parse(sTKVersionDate.Substring(0, 4));
        //    //int iMonth = int.Parse(sTKVersionDate.Substring(4, 2));
        //    DataTable dtt = tp.GetList(sTKVersion);

        //    PublicBusiness p = new PublicBusiness();
        //    DataTable dt = dal.GetList(sTKVersion, qyPlanner, qyGroup, qyReorderpolicy, dtt);

        //    for (int i = 5; i < dt.Columns.Count; i++)
        //    {
        //        for (int j = 3; j < dtt.Columns.Count; j++)
        //        {
        //            string s1 = dt.Columns[i].ColumnName;
        //            string s2 = DateTime.Parse(dtt.Rows[0][j].ToString()).ToString("yyyy-MM-dd");
        //            if (s1 == s2)
        //            {
        //                dt.Columns[i].ColumnName = dtt.Columns[j].ColumnName;
        //                continue;
        //            }
        //        }
        //    }

        //    return dt;
        //}

        ///// <summary>
        ///// 导出PAD
        ///// </summary>
        ///// <param name="sTKVersion"></param>
        ///// <param name="qyPlanner"></param>
        ///// <param name="qyGroup"></param>
        ///// <returns></returns>
        //public DataTable GetListPAD(string sTKVersion, string qyPlanner, string qyGroup)
        //{
        //    PublicBusiness p = new PublicBusiness();
        //    DataTable dt = dal.GetListPAD(sTKVersion, qyPlanner, qyGroup);

        //    return dt;
        //}

        //public DataTable GetListPADGroup(string sTKVersion, string qyPlanner, string qyGroup)
        //{
        //    PublicBusiness p = new PublicBusiness();
        //    DataTable dt = dal.GetListPADGroup(sTKVersion, qyPlanner, qyGroup);

        //    return dt;
        //}

        /// <summary>
        /// 得到查询结果列表
        /// </summary>
        /// <returns></returns>
        //public DataTable GetIsQuery(string sWhere)
        //{
        //    TK_TrialkittingsData p = new TK_TrialkittingsData();
        //    DataTable dt = dal.GetIsQuery(sWhere);

        //    return dt;
        //}

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public string Update(TK_TrialkittingsEntity model)
        {
            //bool result = false;
            string result = "";
            TK_TrialkittingsData dal = new TK_TrialkittingsData();
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

        public bool Update(ArrayList aList)
        {
            bool result = false;

            TK_TrialkittingsData dal = new TK_TrialkittingsData();
            result = dal.Update(aList);
            

            return result;
        }

    }
}
