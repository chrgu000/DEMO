using System;
using System.Collections.Generic;
using System.Text;

namespace ϵͳ����.Bll
{
    class ClsRoleInfoBll
    {
        ϵͳ����.Dal.ClsRoleInfoDal clsDal = new ϵͳ����.Dal.ClsRoleInfoDal();

        #region  ��Ա����
        /// <summary>
        /// �ر�һ������
        /// </summary>
        public void Delete(string sRoleid)
        {
            if (sRoleid == "administrator")
                throw new Exception("administrator ��Ԥ�ý�ɫ���ܹرգ�");

            ϵͳ����.Query.ClsRoleInfoQuery clsQuery = new ϵͳ����.Query.ClsRoleInfoQuery();
            if(clsQuery.ChkClosed(sRoleid))
                throw new Exception(sRoleid +"�Ѿ��رգ�");

            clsDal.Delete(sRoleid);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void UnDelete(string sRoleid)
        {
            ϵͳ����.Query.ClsRoleInfoQuery clsQuery = new ϵͳ����.Query.ClsRoleInfoQuery();
            if (!clsQuery.ChkClosed(sRoleid))
                throw new Exception(sRoleid + "�Ѿ����ã�");

            clsDal.UnDelete(sRoleid);
        }
        #endregion  ��Ա����
    }
}
