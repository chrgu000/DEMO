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
    public class PADBusiness
    {
        private readonly PADData dal = new PADData();

        #region  BasicMethod
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<PADEntity> DataTableToList(DataTable dt)
        {
            List<PADEntity> modelList = new List<PADEntity>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                PADEntity model;
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

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <returns></returns>
        public List<PADEntity> GetList()
        {
            List<PADEntity> result;
            result = dal.GetList();
            return result;
        }
    }
}
