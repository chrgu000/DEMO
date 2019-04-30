using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;


namespace TrialKittingGating.DAL
{
    public class TK_BuyerGatingData
    {

        public TK_BuyerGatingData()
        { }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
		public string Add(Model.TK_BuyerGatingEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.sTKVersion != null)
            {
                strSql1.Append("sTKVersion,");
                strSql2.Append("'" + model.sTKVersion + "',");
            }
            if (model.Period01 != null)
            {
                strSql1.Append("Period01,");
                strSql2.Append("'" + model.Period01 + "',");
            }
            if (model.Period02 != null)
            {
                strSql1.Append("Period02,");
                strSql2.Append("'" + model.Period02 + "',");
            }
            if (model.Period03 != null)
            {
                strSql1.Append("Period03,");
                strSql2.Append("'" + model.Period03 + "',");
            }
            if (model.Period04 != null)
            {
                strSql1.Append("Period04,");
                strSql2.Append("'" + model.Period04 + "',");
            }
            if (model.Period05 != null)
            {
                strSql1.Append("Period05,");
                strSql2.Append("'" + model.Period05 + "',");
            }
            if (model.Period06 != null)
            {
                strSql1.Append("Period06,");
                strSql2.Append("'" + model.Period06 + "',");
            }
            if (model.Period07 != null)
            {
                strSql1.Append("Period07,");
                strSql2.Append("'" + model.Period07 + "',");
            }
            if (model.sProductGroup != null)
            {
                strSql1.Append("sProductGroup,");
                strSql2.Append("'" + model.sProductGroup + "',");
            }
            if (model.sBuyer != null)
            {
                strSql1.Append("sBuyer,");
                strSql2.Append("'" + model.sBuyer + "',");
            }
            if (model.iItemNO != null)
            {
                strSql1.Append("iItemNO,");
                strSql2.Append("'" + model.iItemNO + "',");
            }
            if (model.dtmDuedate != null)
            {
                strSql1.Append("dtmDuedate,");
                strSql2.Append("'" + model.dtmDuedate + "',");
            }
            if (model.dockDate != null)
            {
                strSql1.Append("dockDate,");
                strSql2.Append("'" + model.dockDate + "',");
            }
            if (model.Gating != null)
            {
                strSql1.Append("Gating,");
                strSql2.Append("'" + model.Gating + "',");
            }
            if (model.sPONo != null)
            {
                strSql1.Append("sPONo,");
                strSql2.Append("'" + model.sPONo + "',");
            }
            if (model.fOpenQTY != null)
            {
                strSql1.Append("fOpenQTY,");
                strSql2.Append("'" + model.fOpenQTY + "',");
            }
            if (model.Vendor != null)
            {
                strSql1.Append("Vendor,");
                strSql2.Append("'" + model.Vendor + "',");
            }
            if (model.MPN != null)
            {
                strSql1.Append("MPN,");
                strSql2.Append("'" + model.MPN + "',");
            }
            if (model.MFR != null)
            {
                strSql1.Append("MFR,");
                strSql2.Append("'" + model.MFR + "',");
            }
            if (model.Remark != null)
            {
                strSql1.Append("Remark,");
                strSql2.Append("'" + model.Remark + "',");
            }
            if (model.Action != null)
            {
                strSql1.Append("Action,");
                strSql2.Append("'" + model.Action + "',");
            }
            if (model.CreateUid != null)
            {
                strSql1.Append("CreateUid,");
                strSql2.Append("'" + model.CreateUid + "',");
            }
            if (model.dtmCreate != null)
            {
                strSql1.Append("dtmCreate,");
                strSql2.Append("'" + model.dtmCreate + "',");
            }
            strSql.Append("insert into TK_BuyerGating(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");

            return strSql.ToString();
            //int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            //if (rows > 0)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }
        
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public Model.TK_BuyerGatingEntity DataRowToModel(DataRow row)
        {
            Model.TK_BuyerGatingEntity model = new Model.TK_BuyerGatingEntity();
            if (row != null)
            {
                if (row["iID"] != null && row["iID"].ToString() != "")
                {
                    model.iID = int.Parse(row["iID"].ToString());
                }
                if (row["sTKVersion"] != null)
                {
                    model.sTKVersion = row["sTKVersion"].ToString();
                }
                if (row["Period01"] != null)
                {
                    model.Period01 = row["Period01"].ToString();
                }
                if (row["Period02"] != null)
                {
                    model.Period02 = row["Period02"].ToString();
                }
                if (row["Period03"] != null)
                {
                    model.Period03 = row["Period03"].ToString();
                }
                if (row["Period04"] != null)
                {
                    model.Period04 = row["Period04"].ToString();
                }
                if (row["Period05"] != null)
                {
                    model.Period05 = row["Period05"].ToString();
                }
                if (row["Period06"] != null)
                {
                    model.Period06 = row["Period06"].ToString();
                }
                if (row["Period07"] != null)
                {
                    model.Period07 = row["Period07"].ToString();
                }
                if (row["sProductGroup"] != null)
                {
                    model.sProductGroup = row["sProductGroup"].ToString();
                }
                if (row["sBuyer"] != null)
                {
                    model.sBuyer = row["sBuyer"].ToString();
                }
                if (row["iItemNO"] != null)
                {
                    model.iItemNO = row["iItemNO"].ToString();
                }
                if (row["dtmDuedate"] != null)
                {
                    model.dtmDuedate = row["dtmDuedate"].ToString();
                }
                if (row["dockDate"] != null)
                {
                    model.dockDate = row["dockDate"].ToString();
                }
                if (row["Gating"] != null)
                {
                    model.Gating = row["Gating"].ToString();
                }
                if (row["sPONo"] != null)
                {
                    model.sPONo = row["sPONo"].ToString();
                }
                if (row["fOpenQTY"] != null)
                {
                    model.fOpenQTY = row["fOpenQTY"].ToString();
                }
                if (row["Vendor"] != null)
                {
                    model.Vendor = row["Vendor"].ToString();
                }
                if (row["MPN"] != null)
                {
                    model.MPN = row["MPN"].ToString();
                }
                if (row["MFR"] != null)
                {
                    model.MFR = row["MFR"].ToString();
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["Action"] != null)
                {
                    model.Action = row["Action"].ToString();
                }
                if (row["CreateUid"] != null)
                {
                    model.CreateUid = row["CreateUid"].ToString();
                }
                if (row["dtmCreate"] != null && row["dtmCreate"].ToString() != "")
                {
                    model.dtmCreate = DateTime.Parse(row["dtmCreate"].ToString());
                }
            }
            return model;
        }

    }
}
