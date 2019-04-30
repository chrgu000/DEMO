using System;
using System.Collections.Generic;
using System.Text;

namespace FrameBaseFunction.Bll
{
    class ClsRoleInfoBll
    {
        FrameBaseFunction.Dal.ClsRoleInfoDal clsDal = new FrameBaseFunction.Dal.ClsRoleInfoDal();

        #region  ��Ա����
        /// <summary>
        /// �ر�һ������
        /// </summary>
        public void Delete(string sRoleid)
        {
            if (sRoleid == "administrator")
                throw new Exception("administrator ��Ԥ�ý�ɫ���ܹرգ�");

            FrameBaseFunction.Query.ClsRoleInfoQuery clsQuery = new FrameBaseFunction.Query.ClsRoleInfoQuery();
            if(clsQuery.ChkClosed(sRoleid))
                throw new Exception(sRoleid +"�Ѿ��رգ�");

            clsDal.Delete(sRoleid);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void UnDelete(string sRoleid)
        {
            FrameBaseFunction.Query.ClsRoleInfoQuery clsQuery = new FrameBaseFunction.Query.ClsRoleInfoQuery();
            if (!clsQuery.ChkClosed(sRoleid))
                throw new Exception(sRoleid + "�Ѿ����ã�");

            clsDal.UnDelete(sRoleid);
        }
        #endregion  ��Ա����
    }
}
