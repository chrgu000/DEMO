using System;
using System.Collections.Generic;
using System.Text;

namespace FrameBaseFunction.Bll
{
    class ClsRoleInfoBll
    {
        FrameBaseFunction.Dal.ClsRoleInfoDal clsDal = new FrameBaseFunction.Dal.ClsRoleInfoDal();

        #region  成员方法
        /// <summary>
        /// 关闭一条数据
        /// </summary>
        public void Delete(string sRoleid)
        {
            if (sRoleid == "administrator")
                throw new Exception("administrator 是预置角色不能关闭！");

            FrameBaseFunction.Query.ClsRoleInfoQuery clsQuery = new FrameBaseFunction.Query.ClsRoleInfoQuery();
            if(clsQuery.ChkClosed(sRoleid))
                throw new Exception(sRoleid +"已经关闭！");

            clsDal.Delete(sRoleid);
        }

        /// <summary>
        /// 启用一条数据
        /// </summary>
        public void UnDelete(string sRoleid)
        {
            FrameBaseFunction.Query.ClsRoleInfoQuery clsQuery = new FrameBaseFunction.Query.ClsRoleInfoQuery();
            if (!clsQuery.ChkClosed(sRoleid))
                throw new Exception(sRoleid + "已经启用！");

            clsDal.UnDelete(sRoleid);
        }
        #endregion  成员方法
    }
}
