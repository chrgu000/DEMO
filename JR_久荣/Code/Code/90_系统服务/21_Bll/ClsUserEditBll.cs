using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

namespace 系统服务.Bll
{
    class ClsUserEditBll
    {
        private static readonly 系统服务.Dal.ClsUserEditDal dal = new 系统服务.Dal.ClsUserEditDal();
        系统服务.Query.ClsUserEditQuery clsQuery = new 系统服务.Query.ClsUserEditQuery();
        

        public ClsUserEditBll()
		{ }

        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(系统服务.Model.ClsUserInfoMod model,DataTable dt)
        {
            //ArrayList arrList = new ArrayList();

            AddUserBll(model.vchrUid);
            AddRoleBll(dt);

            dal.AddSQL(model,dt);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(系统服务.Model.ClsUserInfoMod model, DataTable dt)
        {
            dal.UpdateSQL(model,dt);
        }
        #endregion  成员方法


        private void AddUserBll(string sUid)
        {
            if (!clsQuery.ChkUID(sUid))
                throw new Exception("该用户已经存在！");
        }

        private void AddRoleBll(DataTable dt)
        {
            //for (int i = 0; i < arrDetail.Count; i++)
            //{
            //    系统服务.Model.ClsRoleRightMod clsMod = (系统服务.Model.ClsRoleRightMod)arrDetail[i];



            //      throw new Exception("");
            //}
        }
    }
}
