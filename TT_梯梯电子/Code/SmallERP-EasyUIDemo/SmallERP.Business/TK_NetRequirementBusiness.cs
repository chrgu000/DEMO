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
    public class TK_NetRequirementBusiness
    {
        private readonly TK_NetRequirementData dal = new TK_NetRequirementData();

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

        ///// <summary>
        ///// 获取分页数据列表
        ///// </summary>
        ///// <param name="domain"></param>
        ///// <param name="total"></param>
        ///// <returns></returns>
        //public DataTable GetListNet(string sWhere, SearchAdminDomain domain, out int total)
        //{
        //    DataTable result;
        //    result = dal.GetList(sWhere, domain.UserId, domain.Name, domain.RoleId, domain.RowStart(), domain.RowEnd(), out total);
        //    return result;
        //}

        public string GetNewVersion()
        {
            return dal.GetNewVersion();
        }
    }
}
