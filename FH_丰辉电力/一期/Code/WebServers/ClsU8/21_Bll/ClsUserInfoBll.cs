using ClsBaseClass;
using ClsU8.Dal;
using System;
namespace ClsU8.Bll
{
    public class ClsUserInfoBll
    {
        private ClsUserInfoDal clsDal = new ClsUserInfoDal();
        public string Delete(string sUserid)
        {
            string sErr = "";
            try
            {
                if (sUserid == "admin" || sUserid == "system")
                {
                    throw new Exception("admin/system ��Ԥ���ʺŲ���ɾ����");
                }
                if (sUserid == ClsBaseDataInfo.sUid)
                {
                    throw new Exception(sUserid + " �ǵ�ǰ��½�ʺŲ���ɾ����");
                }
                this.clsDal.Delete(sUserid);
            }
            catch (Exception ee)
            {
                sErr = ee.Message;
            }
            return sErr;
        }
    }
}
