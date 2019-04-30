using ClsU8.Dal;
using ClsU8.Model;
using ClsU8.Query;
using System;
using System.Data;
namespace ClsU8.Bll
{
    public class ClsUserEditBll
    {
        private static readonly ClsUserEditDal dal = new ClsUserEditDal();
        private ClsUserEditQuery clsQuery = new ClsUserEditQuery();
        private ClsUserInfoMod model = new ClsUserInfoMod();
        public string Add(string vchrUid, string vchrPwd, DateTime dtmCreate, DateTime dtmClose, string vchrRemark, string vchrName, DataTable dt)
        {
            string sErr = "";
            try
            {
                this.SetTxtToMod(vchrUid, vchrPwd, dtmCreate, dtmClose, vchrRemark, vchrName);
                this.AddUserBll(this.model.vchrUid);
                this.AddRoleBll(dt);
                ClsUserEditBll.dal.AddSQL(this.model, dt);
            }
            catch (Exception ee)
            {
                sErr = ee.Message;
            }
            return sErr;
        }
        public string Update(string vchrUid, string vchrPwd, DateTime dtmCreate, DateTime dtmClose, string vchrRemark, string vchrName, DataTable dt)
        {
            string sErr = "";
            try
            {
                this.SetTxtToMod(vchrUid, vchrPwd, dtmCreate, dtmClose, vchrRemark, vchrName);
                ClsUserEditBll.dal.UpdateSQL(this.model, dt);
            }
            catch (Exception ee)
            {
                sErr = ee.Message;
            }
            return sErr;
        }
        private void AddUserBll(string sUid)
        {
            if (!this.clsQuery.ChkUID(sUid))
            {
                throw new Exception("该用户已经存在！");
            }
        }
        private void AddRoleBll(DataTable dt)
        {
        }
        private void SetTxtToMod(string vchrUid, string vchrPwd, DateTime dtmCreate, DateTime dtmClose, string vchrRemark, string vchrName)
        {
            this.model.vchrUid = vchrUid;
            this.model.vchrPwd = vchrPwd;
            this.model.dtmCreate = dtmCreate;
            this.model.dtmClose = dtmClose;
            this.model.vchrRemark = vchrRemark;
            this.model.vchrName = vchrName;
        }
    }
}
