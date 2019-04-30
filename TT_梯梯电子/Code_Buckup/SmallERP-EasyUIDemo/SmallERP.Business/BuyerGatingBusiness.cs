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

namespace SmallERP.Business
{
    public class BuyerGatingBusiness
    {
        private readonly BuyerGatingData dal = new BuyerGatingData();

        //#region  BasicMethod
        ///// <summary>
        ///// 获得数据列表
        ///// </summary>
        //public List<BuyerGatingEntity> DataTableToList(DataTable dt)
        //{
        //    List<BuyerGatingEntity> modelList = new List<BuyerGatingEntity>();
        //    int rowsCount = dt.Rows.Count;
        //    if (rowsCount > 0)
        //    {
        //        BuyerGatingEntity model;
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

        //#endregion  BasicMethod
        //#region  ExtensionMethod

        //#endregion  ExtensionMethod
        /// <summary>
        /// 获取分页数据列表
        /// </summary>
        /// <param name="domain"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public DataTable GetList(string sWhere, SearchAdminDomain domain, out int total)
        {
            DataTable result = dal.GetList(sWhere, domain.UserId, domain.Name, domain.RoleId, domain.RowStart(), domain.RowEnd(), out total);
            return result;
        }
    }
}
