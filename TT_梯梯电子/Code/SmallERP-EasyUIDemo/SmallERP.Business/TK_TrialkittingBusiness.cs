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
    public class TK_TrialkittingBusiness
    {
        private readonly TK_TrialkittingData dal = new TK_TrialkittingData();

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<TK_TrialkittingEntity> DataTableToList(DataTable dt)
        {
            List<TK_TrialkittingEntity> modelList = new List<TK_TrialkittingEntity>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                TK_TrialkittingEntity model;
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

        ///// <summary>
        ///// 获得数据列表
        ///// </summary>
        ///// <returns></returns>
        //public List<TK_TrialkittingEntity> GetList(string sWhere)
        //{
        //    List<TK_TrialkittingEntity> result;
        //    result = dal.GetList(sWhere);
        //    return result;
        //}


        /// <summary>
        /// 获得数据列表
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
        /// <param name=""></param>
        /// <returns></returns>
        public string Update(TK_TrialkittingEntity model)
        {
            //bool result = false;
            string result = "";
            TK_TrialkittingData dal = new TK_TrialkittingData();
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

            TK_TrialkittingData dal = new TK_TrialkittingData();
            result = dal.Update(aList);
            

            return result;
        }

        /// <summary>
        /// Trialkit版本号
        /// </summary>
        /// <returns></returns>
        public object GetTKTrialkitVersion()
        {
            PublicBusiness p = new PublicBusiness();
            return p.ToObject(dal.GetTKTrialkitVersion());
        }

        /// <summary>
        /// Trialkit版本号Result
        /// </summary>
        /// <returns></returns>
        public object GetTKTrialkitVersionResult()
        {
            PublicBusiness p = new PublicBusiness();
            return p.ToObject(dal.GetTKTrialkitVersionResult());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="domain"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public DataTable GetNetQtyList(string queryVersion, string sPartID, string sWhere, SearchAdminDomain domain, out int total)
        {
            DataTable result;
            result = dal.GetNetQtyList(queryVersion, sPartID, sWhere, domain.UserId, domain.Name, domain.RoleId, domain.RowStart(), domain.RowEnd(), out total);
            return result;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="domain"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public DataTable GetQueryList(string sWhere, SearchAdminDomain domain, out int total)
        {
            DataTable result;
            result = dal.GetQueryList(sWhere, domain.UserId, domain.Name, domain.RoleId, domain.RowStart(), domain.RowEnd(), out total);
            return result;
        }
    }
}
