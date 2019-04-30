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
    public class TK_Trialkitting_ErrorInfoBusiness
    {
        private readonly TK_Trialkitting_ErrorInfoData dal = new TK_Trialkitting_ErrorInfoData();

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

    }
}
