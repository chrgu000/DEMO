using System;
using System.Data;
using System.Collections.Generic;
using SmallERP.DataAccess;
using SmallERP.Entity;
using SmallERP.DBUtility;

namespace SmallERP.Business
{
    /// <summary>
    /// t_business_parms
    /// </summary>
    public partial class t_business_parmsBusiness
    {
        private readonly t_business_parmsData dal = new t_business_parmsData();
        public t_business_parmsBusiness()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(t_business_parmsEntity model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(t_business_parmsEntity model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
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
        public t_business_parmsEntity GetModel(int id)
        {

            return dal.GetModel(id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        //public t_business_parmsEntity GetModelByCache(int id)
        //{

        //    string CacheKey = "t_business_parmsModel-" + id;
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
        //    return (t_business_parmsEntity)objModel;
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
        public List<t_business_parmsEntity> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<t_business_parmsEntity> DataTableToList(DataTable dt)
        {
            List<t_business_parmsEntity> modelList = new List<t_business_parmsEntity>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                t_business_parmsEntity model;
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
        /// 根据category和item得到一个对象实体
        /// 创建人：蒋俊
        /// 创建时间：2017-09-13 10:34:20
        /// </summary>
        public t_business_parmsEntity GetModelByCategoryAndItem(string category, string item)
        {
            return dal.GetModelByCategoryAndItem(category, item);
        }
        /// <summary>
        /// 根据cid得到一个对象实体

        /// </summary>
        public t_business_parmsEntity GetModelByid(string id)
        {
            return dal.GetModelByid(id);
        }
        /// <summary>
        /// 获得数据列表
        /// 创建人：蒋俊
        /// 创建时间：2017-08-22 16:24:01
        /// </summary>
        public List<t_business_parmsEntity> GetTopModelList(int Top, string strWhere, string filedOrder)
        {
            DataSet ds = dal.GetList(Top, strWhere, filedOrder);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public List<string> GetCategoryList(string filter)
        {
            return dal.GetCategoryList(filter);
        }

        /// <summary>
        /// 分页获取数据列表
        /// 创建人：蒋俊
        /// 创建时间：2017-08-22 15:19:59
        /// </summary>
        public List<t_business_parmsEntity> GetBusinessParmsListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetBusinessParmsListByPage(strWhere, orderby, startIndex, endIndex);
        }

        #endregion  ExtensionMethod
    }
}

