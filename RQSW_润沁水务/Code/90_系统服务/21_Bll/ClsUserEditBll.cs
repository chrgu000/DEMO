using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

namespace ϵͳ����.Bll
{
    class ClsUserEditBll
    {
        private static readonly ϵͳ����.Dal.ClsUserEditDal dal = new ϵͳ����.Dal.ClsUserEditDal();
        ϵͳ����.Query.ClsUserEditQuery clsQuery = new ϵͳ����.Query.ClsUserEditQuery();
        

        public ClsUserEditBll()
		{ }

        #region  ��Ա����
        /// <summary>
        /// ����һ������
        /// </summary>
        public void Add(ϵͳ����.Model.ClsUserInfoMod model,DataTable dt)
        {
            //ArrayList arrList = new ArrayList();

            AddUserBll(model.vchrUid);
            AddRoleBll(dt);

            dal.AddSQL(model,dt);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(ϵͳ����.Model.ClsUserInfoMod model, DataTable dt)
        {
            dal.UpdateSQL(model,dt);
        }
        #endregion  ��Ա����


        private void AddUserBll(string sUid)
        {
            if (!clsQuery.ChkUID(sUid))
                throw new Exception("���û��Ѿ����ڣ�");
        }

        private void AddRoleBll(DataTable dt)
        {
            //for (int i = 0; i < arrDetail.Count; i++)
            //{
            //    ϵͳ����.Model.ClsRoleRightMod clsMod = (ϵͳ����.Model.ClsRoleRightMod)arrDetail[i];



            //      throw new Exception("");
            //}
        }
    }
}
