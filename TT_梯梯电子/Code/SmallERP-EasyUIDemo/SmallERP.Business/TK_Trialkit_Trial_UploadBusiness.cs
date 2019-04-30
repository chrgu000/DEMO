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
    public class TK_Trialkit_Trial_UploadBusiness
    {
        private readonly TK_Trialkit_Trial_UploadData dal = new TK_Trialkit_Trial_UploadData();

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public List<TK_Trialkit_Trial_UploadEntity> DataTableToList(DataTable dt)
        {
            List<TK_Trialkit_Trial_UploadEntity> modelList = new List<TK_Trialkit_Trial_UploadEntity>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                TK_Trialkit_Trial_UploadEntity model;
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
        /// <param name="sWhere"></param>
        /// <returns></returns>
        public List<TK_Trialkit_Trial_UploadEntity> GetList(string sWhere)
        {
            List<TK_Trialkit_Trial_UploadEntity> result;
            result = dal.GetList(sWhere);
            return result;
        }

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

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string Update(TK_Trialkit_Trial_UploadEntity model)
        {
            //bool result = false;
            string result = "";
            TK_Trialkit_Trial_UploadData dal = new TK_Trialkit_Trial_UploadData();
            // 插入数据库
            if (string.IsNullOrEmpty(model.iID.ToString()) || model.iID == 0)
            {
                result = dal.Add(model);
            }
            else
            {
                result = dal.Update(model);
            }
                
            return result;
        }

        /// <summary>
        /// 更新多条数据
        /// </summary>
        /// <param name="aList"></param>
        /// <returns></returns>
        public bool Update(ArrayList aList)
        {
            bool result = false;

            TK_Trialkit_Trial_UploadData dal = new TK_Trialkit_Trial_UploadData();
            result = dal.Update(aList);
            

            return result;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="iID"></param>
        /// <returns></returns>
        public string Delete(string iID)
        {
            string result = "";

            TK_Trialkit_Trial_UploadData dal = new TK_Trialkit_Trial_UploadData();
            result = dal.Delete(iID);


            return result;
        }

        /// <summary>
        /// 得到新的版本号
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public string GetNewVersion(string UserID)
        {
            string result = "";

            TK_Trialkit_Trial_UploadData dal = new TK_Trialkit_Trial_UploadData();
            result = dal.GetNewVersion(UserID);

            return result;
        }

        /// <summary>
        /// 得到最新的同步的版本号
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public string GetMaxVersion()
        {
            string result = "";

            TK_Trialkit_Trial_UploadData dal = new TK_Trialkit_Trial_UploadData();
            result = dal.GetMaxVersion();

            return result;
        }

    }
}
