using System;
using System.Collections.Generic;
using System.Text;

namespace 系统服务.Bll
{
    class ClsRoleInfoBll
    {
        系统服务.Dal.ClsRoleInfoDal clsDal = new 系统服务.Dal.ClsRoleInfoDal();

        #region  成员方法
        /// <summary>
        /// 关闭一条数据
        /// </summary>
        public void Delete(string sRoleid)
        {
            if (sRoleid == "administrator")
                throw new Exception("administrator 是预置角色不能关闭！");

            系统服务.Query.ClsRoleInfoQuery clsQuery = new 系统服务.Query.ClsRoleInfoQuery();
            if(clsQuery.ChkClosed(sRoleid))
                throw new Exception(sRoleid +"已经关闭！");

            clsDal.Delete(sRoleid);
        }

        /// <summary>
        /// 启用一条数据
        /// </summary>
        public void UnDelete(string sRoleid)
        {
            系统服务.Query.ClsRoleInfoQuery clsQuery = new 系统服务.Query.ClsRoleInfoQuery();
            if (!clsQuery.ChkClosed(sRoleid))
                throw new Exception(sRoleid + "已经启用！");

            clsDal.UnDelete(sRoleid);
        }
        #endregion  成员方法
    }
}
