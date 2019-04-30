using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace FrameBaseFunction.Bll
{
    class ClsRoleEditBll
    { 
        private static readonly FrameBaseFunction.Dal.ClsRoleEditDal dal = new FrameBaseFunction.Dal.ClsRoleEditDal();
        FrameBaseFunction.Query.ClsRoleEditQuery clsQuery = new FrameBaseFunction.Query.ClsRoleEditQuery();

        public ClsRoleEditBll()
		{ }

        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(FrameBaseFunction.Model.ClsRoleInfoMod model, DataTable dt)
        {
            AddRoleBll(model.vchrRoleID);
            AddUserBll(dt);

            dal.AddSQL(model, dt);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(FrameBaseFunction.Model.ClsRoleInfoMod model, DataTable dt)
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
