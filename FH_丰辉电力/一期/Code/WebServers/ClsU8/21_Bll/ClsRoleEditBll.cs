using ClsU8.Dal;
using ClsU8.Model;
using ClsU8.Query;
using System;
using System.Data;
namespace ClsU8.Bll
{
    public class ClsRoleEditBll
    {
        private static readonly ClsRoleEditDal dal = new ClsRoleEditDal();
        private ClsRoleEditQuery clsQuery = new ClsRoleEditQuery();
        private ClsRoleInfoMod model = new ClsRoleInfoMod();
        public string Add(string vchrRoleID, string vchrRoleText, string vchrRemark, bool bClosed, DateTime dtmCreate, DataTable dt)
        {
            string sErr = "";
            try
            {
                this.SetTxtToMod(vchrRoleID, vchrRoleText, vchrRemark, bClosed, dtmCreate);
                this.AddRoleBll(this.model.vchrRoleID);
                this.AddUserBll(dt);
                ClsRoleEditBll.dal.AddSQL(this.model, dt);
            }
            catch (Exception ee)
            {
                sErr = ee.Message;
            }
            return sErr;
        }
        public string Update(string vchrRoleID, string vchrRoleText, string vchrRemark, bool bClosed, DateTime dtmCreate, DataTable dt)
        {
            string sErr = "";
            try
            {
                this.SetTxtToMod(vchrRoleID, vchrRoleText, vchrRemark, bClosed, dtmCreate);
                ClsRoleEditBll.dal.UpdateSQL(this.model, dt);
            }
            catch (Exception ee)
            {
                sErr = ee.Message;
            }
            return sErr;
        }
        private void AddRoleBll(string sRoleId)
        {
            if (!this.clsQuery.ChkRoleID(sRoleId))
            {
                throw new Exception("该角色已经存在！");
            }
        }
        private void AddUserBll(DataTable dt)
        {
        }
        private void SetTxtToMod(string vchrRoleID, string vchrRoleText, string vchrRemark, bool bClosed, DateTime dtmCreate)
        {
            this.model.vchrRoleID = vchrRoleID;
            this.model.vchrRoleText = vchrRoleText;
            this.model.vchrRemark = vchrRemark;
            this.model.bClosed = bClosed;
            this.model.dtmCreate = dtmCreate;
        }
    }
}
