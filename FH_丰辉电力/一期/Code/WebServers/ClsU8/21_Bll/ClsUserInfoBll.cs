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
                    throw new Exception("admin/system 是预置帐号不能删除！");
                }
                if (sUserid == ClsBaseDataInfo.sUid)
                {
                    throw new Exception(sUserid + " 是当前登陆帐号不能删除！");
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
