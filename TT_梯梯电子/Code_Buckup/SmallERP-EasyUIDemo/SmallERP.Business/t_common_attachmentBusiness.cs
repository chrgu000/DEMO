using System;
using System.Data;
using System.Collections.Generic;
using SmallERP.DataAccess;
using SmallERP.Entity;
using SmallERP.DBUtility;
using SmallERP.Domain;

namespace SmallERP.Business
{
    /// <summary>
    /// t_common_attachment
    /// </summary>
    public partial class t_common_attachmentBusiness
    {
        private readonly t_common_attachmentData dal = new t_common_attachmentData();
        public t_common_attachmentBusiness()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(t_common_attachmentEntity model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(t_common_attachmentEntity model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string id)
        {

            return dal.Delete(id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            return dal.DeleteList(idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public t_common_attachmentEntity GetModel(string id)
        {

            return dal.GetModel(id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        //public t_common_attachmentEntity GetModelByCache(string id)
        //{

        //    string CacheKey = "t_common_attachmentModel-" + id;
        //    object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(id);
        //            if (objModel != null)
        //            {
        //                int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch { }
        //    }
        //    return (t_common_attachmentEntity)objModel;
        //}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<t_common_attachmentEntity> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<t_common_attachmentEntity> DataTableToList(DataTable dt)
        {
            List<t_common_attachmentEntity> modelList = new List<t_common_attachmentEntity>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                t_common_attachmentEntity model;
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
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod

        /// <summary>
        /// 根据source_id事务删除一条数据
        /// </summary>
        public CommandInfo TranDeleteBySourceID(string sourceID)
        {
            return dal.TranDeleteBySourceID(sourceID);
        }

        /// <summary>
        /// 事务删除一条数据
        /// </summary>
        public CommandInfo TranDelete(string id)
        {
            return dal.TranDelete(id);
        }

        /// <summary>
        /// 分页获取数据列表
        /// 创建人：蒋俊
        /// 创建时间：2017-12-14 09:52:41
        /// </summary>
        public List<t_common_attachmentEntity> GetAttachmentListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetAttachmentListByPage(strWhere, orderby, startIndex, endIndex);
        }

        #endregion  ExtensionMethod
    }
}

