using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace 系统服务.Bll
{
    class ClsRoleEditBll
    { 
        private static readonly 系统服务.Dal.ClsRoleEditDal dal = new 系统服务.Dal.ClsRoleEditDal();
        系统服务.Query.ClsRoleEditQuery clsQuery = new 系统服务.Query.ClsRoleEditQuery();

        public ClsRoleEditBll()
		{ }

        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(系统服务.Model.ClsRoleInfoMod model, DataTable dt)
        {
            AddRoleBll(model.vchrRoleID);
            AddUserBll(dt);

            dal.AddSQL(model, dt);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(系统服务.Model.ClsRoleInfoMod model, DataTable dt)
        {
            dal.UpdateSQL(model, dt);
        }
        #endregion  成员方法


        private void AddRoleBll(string sRoleId)
        {
            if (!clsQuery.ChkRoleID(sRoleId))
                throw new Exception("该角色已经存在！");
        }

        private void AddUserBll(DataTable dt)
        {
            
        }
    }
}
