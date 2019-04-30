using ClsU8.Dal;
using System;
using System.Data;
namespace ClsU8.Bll
{
    public class ClsRoleRightBll
    {
        private static readonly ClsRoleRightDal dal = new ClsRoleRightDal();
        public string Add(string sPK, DataTable dt)
        {
            string sErr = "";
            try
            {
                ClsRoleRightBll.dal.AddSQL(sPK, dt);
            }
            catch (Exception ee)
            {
                sErr = ee.Message;
            }
            return sErr;
        }
    }
}
