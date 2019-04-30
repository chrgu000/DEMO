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
    public class TK_Trialkit_CalculateBusiness
    {
        private readonly TK_Trialkit_CalculateData dal = new TK_Trialkit_CalculateData();

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
    }
}
