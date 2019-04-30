using ClsU8.Dal;
using ClsU8.Query;
using System;
namespace ClsU8.Bll
{
    public class ClsRoleInfoBll
    {
        private ClsRoleInfoDal clsDal = new ClsRoleInfoDal();
        public string Close(string sRoleid)
        {
            string sErr = "";
            try
            {
                if (sRoleid == "administrator")
                {
                    throw new Exception("administrator 是预置角色不能关闭！");
                }
                ClsRoleInfoQuery clsQuery = new ClsRoleInfoQuery();
                if (clsQuery.ChkClosed(sRoleid))
                {
                    throw new Exception(sRoleid + "已经关闭！");
                }
                this.clsDal.Delete(sRoleid);
            }
            catch (Exception ee)
            {
                sErr = ee.Message;
            }
            return sErr;
        }
        public string UnClose(string sRoleid)
        {
            string sErr = "";
            try
            {
                ClsRoleInfoQuery clsQuery = new ClsRoleInfoQuery();
                if (!clsQuery.ChkClosed(sRoleid))
                {
                    throw new Exception(sRoleid + "已经启用！");
                }
                this.clsDal.UnDelete(sRoleid);
            }
            catch (Exception ee)
            {
                sErr = ee.Message;
            }
            return sErr;
        }
    }
}
