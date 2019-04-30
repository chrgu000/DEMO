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
    public class TK_WO_Materials_SumBusiness
    {
        private readonly TK_WO_Materials_SumData dal = new TK_WO_Materials_SumData();

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="sWhere"></param>
        /// <returns></returns>
        public DataTable GetList(string sTKVersion, string qyPlanner, string qyGroup)
        {
            DataTable result = dal.GetList(sTKVersion, qyPlanner, qyGroup);
            return result;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="sWhere"></param>
        /// <returns></returns>
        public DataTable GetListGroup(string sTKVersion, string qyPlanner, string qyGroup)
        {
            DataTable result = dal.GetListGroup(sTKVersion, qyPlanner, qyGroup);
            return result;
        }
    }
}
