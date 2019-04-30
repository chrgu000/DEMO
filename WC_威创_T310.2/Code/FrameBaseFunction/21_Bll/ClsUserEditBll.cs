using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

namespace FrameBaseFunction.Bll
{
    class ClsUserEditBll
    {
        private static readonly FrameBaseFunction.Dal.ClsUserEditDal dal = new FrameBaseFunction.Dal.ClsUserEditDal();
        FrameBaseFunction.Query.ClsUserEditQuery clsQuery = new FrameBaseFunction.Query.ClsUserEditQuery();
        

        public ClsUserEditBll()
		{ }

        #region  ��Ա����
        /// <summary>
        /// ����һ������
        /// </summary>
        public void Add(FrameBaseFunction.Model.ClsUserInfoMod model,DataTable dt)
        {
            //ArrayList arrList = new ArrayList();

            AddUserBll(model.vchrUid);
            AddRoleBll(dt);

            dal.AddSQL(model,dt);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(FrameBaseFunction.Model.ClsUserInfoMod model, DataTable dt)
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
            //    FrameBaseFunction.Model.ClsRoleRightMod clsMod = (FrameBaseFunction.Model.ClsRoleRightMod)arrDetail[i];



            //      throw new Exception("");
            //}
        }
    }
}
