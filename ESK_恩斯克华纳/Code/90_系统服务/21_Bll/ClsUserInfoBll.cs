using System;
using System.Collections.Generic;
using System.Text;

namespace ϵͳ����.Bll
{
    class ClsUserInfoBll
    {
        ϵͳ����.Dal.ClsUserInfoDal clsDal = new ϵͳ����.Dal.ClsUserInfoDal();

        #region  ��Ա����
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(string sUserid)
        {
            if (sUserid == "admin" || sUserid == "system")
                throw new Exception("admin/system ��Ԥ���ʺŲ���ɾ����");

            if (sUserid == ϵͳ����.ClsBaseDataInfo.sUid)
                throw new Exception(sUserid + " �ǵ�ǰ��½�ʺŲ���ɾ����");

            clsDal.Delete(sUserid);
        }

        #endregion  ��Ա����
    }
}
