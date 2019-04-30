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

        #region  ��Ա����
        /// <summary>
        /// ����һ������
        /// </summary>
        public void Add(FrameBaseFunction.Model.ClsRoleInfoMod model, DataTable dt)
        {
            AddRoleBll(model.vchrRoleID);
            AddUserBll(dt);

            dal.AddSQL(model, dt);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(FrameBaseFunction.Model.ClsRoleInfoMod model, DataTable dt)
        {
            dal.UpdateSQL(model, dt);
        }
        #endregion  ��Ա����


        private void AddRoleBll(string sRoleId)
        {
            if (!clsQuery.ChkRoleID(sRoleId))
                throw new Exception("�ý�ɫ�Ѿ����ڣ�");
        }

        private void AddUserBll(DataTable dt)
        {
            
        }
    }
}
