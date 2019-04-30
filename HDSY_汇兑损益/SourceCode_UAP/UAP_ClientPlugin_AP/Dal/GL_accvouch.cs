using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace UAP_ClientPlugin_AP.DAL
{
    /// <summary>
    /// 数据访问类:GL_accvouch
    /// </summary>
    public partial class GL_accvouch
    {
        public GL_accvouch()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UAP_ClientPlugin_AP.Model.GL_accvouch model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.iperiod != null)
            {
                strSql1.Append("iperiod,");
                strSql2.Append("" + model.iperiod + ",");
            }
            if (model.csign != null)
            {
                strSql1.Append("csign,");
                strSql2.Append("'" + model.csign + "',");
            }
            if (model.isignseq != null)
            {
                strSql1.Append("isignseq,");
                strSql2.Append("" + model.isignseq + ",");
            }
            if (model.ino_id != null)
            {
                strSql1.Append("ino_id,");
                strSql2.Append("" + model.ino_id + ",");
            }
            if (model.inid != null)
            {
                strSql1.Append("inid,");
                strSql2.Append("" + model.inid + ",");
            }
            if (model.dbill_date != null)
            {
                strSql1.Append("dbill_date,");
                strSql2.Append("'" + model.dbill_date + "',");
            }
            if (model.idoc != null)
            {
                strSql1.Append("idoc,");
                strSql2.Append("" + model.idoc + ",");
            }
            if (model.cbill != null)
            {
                strSql1.Append("cbill,");
                strSql2.Append("'" + model.cbill + "',");
            }
            if (model.ccheck != null)
            {
                strSql1.Append("ccheck,");
                strSql2.Append("'" + model.ccheck + "',");
            }
            if (model.cbook != null)
            {
                strSql1.Append("cbook,");
                strSql2.Append("'" + model.cbook + "',");
            }
            if (model.ibook != null)
            {
                strSql1.Append("ibook,");
                strSql2.Append("" + model.ibook + ",");
            }
            if (model.ccashier != null)
            {
                strSql1.Append("ccashier,");
                strSql2.Append("'" + model.ccashier + "',");
            }
            //if (model.iflag != null)
            //{
            //    strSql1.Append("iflag,");
            //    strSql2.Append("" + model.iflag + ",");
            //}
            if (model.ctext1 != null)
            {
                strSql1.Append("ctext1,");
                strSql2.Append("'" + model.ctext1 + "',");
            }
            if (model.ctext2 != null)
            {
                strSql1.Append("ctext2,");
                strSql2.Append("'" + model.ctext2 + "',");
            }
            if (model.cdigest != null)
            {
                strSql1.Append("cdigest,");
                strSql2.Append("'" + model.cdigest + "',");
            }
            if (model.ccode != null)
            {
                strSql1.Append("ccode,");
                strSql2.Append("'" + model.ccode + "',");
            }
            if (model.cexch_name != null)
            {
                strSql1.Append("cexch_name,");
                strSql2.Append("'" + model.cexch_name + "',");
            }
            if (model.md != null)
            {
                strSql1.Append("md,");
                strSql2.Append("" + model.md + ",");
            }
            if (model.mc != null)
            {
                strSql1.Append("mc,");
                strSql2.Append("" + model.mc + ",");
            }
            if (model.md_f != null)
            {
                strSql1.Append("md_f,");
                strSql2.Append("" + model.md_f + ",");
            }
            if (model.mc_f != null)
            {
                strSql1.Append("mc_f,");
                strSql2.Append("" + model.mc_f + ",");
            }
            if (model.nfrat != null)
            {
                strSql1.Append("nfrat,");
                strSql2.Append("" + model.nfrat + ",");
            }
            if (model.nd_s != null)
            {
                strSql1.Append("nd_s,");
                strSql2.Append("" + model.nd_s + ",");
            }
            if (model.nc_s != null)
            {
                strSql1.Append("nc_s,");
                strSql2.Append("" + model.nc_s + ",");
            }
            if (model.csettle != null)
            {
                strSql1.Append("csettle,");
                strSql2.Append("'" + model.csettle + "',");
            }
            if (model.cn_id != null)
            {
                strSql1.Append("cn_id,");
                strSql2.Append("'" + model.cn_id + "',");
            }
            if (model.dt_date != null)
            {
                strSql1.Append("dt_date,");
                strSql2.Append("'" + model.dt_date + "',");
            }
            if (model.cdept_id != null)
            {
                strSql1.Append("cdept_id,");
                strSql2.Append("'" + model.cdept_id + "',");
            }
            if (model.cperson_id != null)
            {
                strSql1.Append("cperson_id,");
                strSql2.Append("'" + model.cperson_id + "',");
            }
            if (model.ccus_id != null)
            {
                strSql1.Append("ccus_id,");
                strSql2.Append("'" + model.ccus_id + "',");
            }
            if (model.csup_id != null)
            {
                strSql1.Append("csup_id,");
                strSql2.Append("'" + model.csup_id + "',");
            }
            if (model.citem_id != null)
            {
                strSql1.Append("citem_id,");
                strSql2.Append("'" + model.citem_id + "',");
            }
            if (model.citem_class != null)
            {
                strSql1.Append("citem_class,");
                strSql2.Append("'" + model.citem_class + "',");
            }
            if (model.cname != null)
            {
                strSql1.Append("cname,");
                strSql2.Append("'" + model.cname + "',");
            }
            if (model.ccode_equal != null)
            {
                strSql1.Append("ccode_equal,");
                strSql2.Append("'" + model.ccode_equal + "',");
            }
            if (model.iflagbank != null)
            {
                strSql1.Append("iflagbank,");
                strSql2.Append("" + model.iflagbank + ",");
            }
            if (model.iflagPerson != null)
            {
                strSql1.Append("iflagPerson,");
                strSql2.Append("" + model.iflagPerson + ",");
            }
            if (model.bdelete != null)
            {
                strSql1.Append("bdelete,");
                strSql2.Append("" + (model.bdelete ? 1 : 0) + ",");
            }
            if (model.coutaccset != null)
            {
                strSql1.Append("coutaccset,");
                strSql2.Append("'" + model.coutaccset + "',");
            }
            if (model.ioutyear != null)
            {
                strSql1.Append("ioutyear,");
                strSql2.Append("" + model.ioutyear + ",");
            }
            if (model.coutsysname != null)
            {
                strSql1.Append("coutsysname,");
                strSql2.Append("'" + model.coutsysname + "',");
            }
            if (model.coutsysver != null)
            {
                strSql1.Append("coutsysver,");
                strSql2.Append("'" + model.coutsysver + "',");
            }
            if (model.doutbilldate != null)
            {
                strSql1.Append("doutbilldate,");
                strSql2.Append("'" + model.doutbilldate + "',");
            }
            if (model.ioutperiod != null)
            {
                strSql1.Append("ioutperiod,");
                strSql2.Append("" + model.ioutperiod + ",");
            }
            if (model.coutsign != null)
            {
                strSql1.Append("coutsign,");
                strSql2.Append("'" + model.coutsign + "',");
            }
            if (model.coutno_id != null)
            {
                strSql1.Append("coutno_id,");
                strSql2.Append("'" + model.coutno_id + "',");
            }
            if (model.doutdate != null)
            {
                strSql1.Append("doutdate,");
                strSql2.Append("'" + model.doutdate + "',");
            }
            if (model.coutbillsign != null)
            {
                strSql1.Append("coutbillsign,");
                strSql2.Append("'" + model.coutbillsign + "',");
            }
            if (model.coutid != null)
            {
                strSql1.Append("coutid,");
                strSql2.Append("'" + model.coutid + "',");
            }
            if (model.bvouchedit != null)
            {
                strSql1.Append("bvouchedit,");
                strSql2.Append("" + (model.bvouchedit ? 1 : 0) + ",");
            }
            if (model.bvouchAddordele != null)
            {
                strSql1.Append("bvouchAddordele,");
                strSql2.Append("" + (model.bvouchAddordele ? 1 : 0) + ",");
            }
            if (model.bvouchmoneyhold != null)
            {
                strSql1.Append("bvouchmoneyhold,");
                strSql2.Append("" + (model.bvouchmoneyhold ? 1 : 0) + ",");
            }
            if (model.bvalueedit != null)
            {
                strSql1.Append("bvalueedit,");
                strSql2.Append("" + (model.bvalueedit ? 1 : 0) + ",");
            }
            if (model.bcodeedit != null)
            {
                strSql1.Append("bcodeedit,");
                strSql2.Append("" + (model.bcodeedit ? 1 : 0) + ",");
            }
            if (model.ccodecontrol != null)
            {
                strSql1.Append("ccodecontrol,");
                strSql2.Append("'" + model.ccodecontrol + "',");
            }
            if (model.bPCSedit != null)
            {
                strSql1.Append("bPCSedit,");
                strSql2.Append("" + (model.bPCSedit ? 1 : 0) + ",");
            }
            if (model.bDeptedit != null)
            {
                strSql1.Append("bDeptedit,");
                strSql2.Append("" + (model.bDeptedit ? 1 : 0) + ",");
            }
            if (model.bItemedit != null)
            {
                strSql1.Append("bItemedit,");
                strSql2.Append("" + (model.bItemedit ? 1 : 0) + ",");
            }
            if (model.bCusSupInput != null)
            {
                strSql1.Append("bCusSupInput,");
                strSql2.Append("" + (model.bCusSupInput ? 1 : 0) + ",");
            }
            if (model.cDefine1 != null)
            {
                strSql1.Append("cDefine1,");
                strSql2.Append("'" + model.cDefine1 + "',");
            }
            if (model.cDefine2 != null)
            {
                strSql1.Append("cDefine2,");
                strSql2.Append("'" + model.cDefine2 + "',");
            }
            if (model.cDefine3 != null)
            {
                strSql1.Append("cDefine3,");
                strSql2.Append("'" + model.cDefine3 + "',");
            }
            if (model.cDefine4 != null)
            {
                strSql1.Append("cDefine4,");
                strSql2.Append("'" + model.cDefine4 + "',");
            }
            if (model.cDefine5 != null)
            {
                strSql1.Append("cDefine5,");
                strSql2.Append("" + model.cDefine5 + ",");
            }
            if (model.cDefine6 != null)
            {
                strSql1.Append("cDefine6,");
                strSql2.Append("'" + model.cDefine6 + "',");
            }
            if (model.cDefine7 != null)
            {
                strSql1.Append("cDefine7,");
                strSql2.Append("" + model.cDefine7 + ",");
            }
            if (model.cDefine8 != null)
            {
                strSql1.Append("cDefine8,");
                strSql2.Append("'" + model.cDefine8 + "',");
            }
            if (model.cDefine9 != null)
            {
                strSql1.Append("cDefine9,");
                strSql2.Append("'" + model.cDefine9 + "',");
            }
            if (model.cDefine10 != null)
            {
                strSql1.Append("cDefine10,");
                strSql2.Append("'" + model.cDefine10 + "',");
            }
            if (model.cDefine11 != null)
            {
                strSql1.Append("cDefine11,");
                strSql2.Append("'" + model.cDefine11 + "',");
            }
            if (model.cDefine12 != null)
            {
                strSql1.Append("cDefine12,");
                strSql2.Append("'" + model.cDefine12 + "',");
            }
            if (model.cDefine13 != null)
            {
                strSql1.Append("cDefine13,");
                strSql2.Append("'" + model.cDefine13 + "',");
            }
            if (model.cDefine14 != null)
            {
                strSql1.Append("cDefine14,");
                strSql2.Append("'" + model.cDefine14 + "',");
            }
            if (model.cDefine15 != null)
            {
                strSql1.Append("cDefine15,");
                strSql2.Append("" + model.cDefine15 + ",");
            }
            if (model.cDefine16 != null)
            {
                strSql1.Append("cDefine16,");
                strSql2.Append("" + model.cDefine16 + ",");
            }
            //if (model.dReceive != null)
            //{
            //    strSql1.Append("dReceive,");
            //    strSql2.Append("'" + model.dReceive + "',");
            //}
            if (model.cWLDZFlag != null)
            {
                strSql1.Append("cWLDZFlag,");
                strSql2.Append("'" + model.cWLDZFlag + "',");
            }
            if (model.dWLDZTime != null)
            {
                strSql1.Append("dWLDZTime,");
                strSql2.Append("'" + model.dWLDZTime + "',");
            }
            if (model.bFlagOut != null)
            {
                strSql1.Append("bFlagOut,");
                strSql2.Append("" + (model.bFlagOut ? 1 : 0) + ",");
            }
            //if (model.iBG_OverFlag != null)
            //{
            //    strSql1.Append("iBG_OverFlag,");
            //    strSql2.Append("" + model.iBG_OverFlag + ",");
            //}
            if (model.cBG_Auditor != null)
            {
                strSql1.Append("cBG_Auditor,");
                strSql2.Append("'" + model.cBG_Auditor + "',");
            }
            if (model.dBG_AuditTime != null)
            {
                strSql1.Append("dBG_AuditTime,");
                strSql2.Append("'" + model.dBG_AuditTime + "',");
            }
            if (model.cBG_AuditOpinion != null)
            {
                strSql1.Append("cBG_AuditOpinion,");
                strSql2.Append("'" + model.cBG_AuditOpinion + "',");
            }
            //if (model.bWH_BgFlag != null)
            //{
            //    strSql1.Append("bWH_BgFlag,");
            //    strSql2.Append("" + (model.bWH_BgFlag ? 1 : 0) + ",");
            //}
            if (model.ssxznum != null)
            {
                strSql1.Append("ssxznum,");
                strSql2.Append("" + model.ssxznum + ",");
            }
            if (model.CErrReason != null)
            {
                strSql1.Append("CErrReason,");
                strSql2.Append("'" + model.CErrReason + "',");
            }
            if (model.BG_AuditRemark != null)
            {
                strSql1.Append("BG_AuditRemark,");
                strSql2.Append("'" + model.BG_AuditRemark + "',");
            }
            if (model.cBudgetBuffer != null)
            {
                strSql1.Append("cBudgetBuffer,");
                strSql2.Append("'" + model.cBudgetBuffer + "',");
            }
            //if (model.iBG_ControlResult != null)
            //{
            //    strSql1.Append("iBG_ControlResult,");
            //    strSql2.Append("" + model.iBG_ControlResult + ",");
            //}
            if (model.NCVouchID != null)
            {
                strSql1.Append("NCVouchID,");
                strSql2.Append("'" + model.NCVouchID + "',");
            }
            if (model.daudit_date != null)
            {
                strSql1.Append("daudit_date,");
                strSql2.Append("'" + model.daudit_date + "',");
            }
            if (model.RowGuid != null)
            {
                strSql1.Append("RowGuid,");
                strSql2.Append("'" + model.RowGuid + "',");
            }
            if (model.cBankReconNo != null)
            {
                strSql1.Append("cBankReconNo,");
                strSql2.Append("'" + model.cBankReconNo + "',");
            }
            if (model.iyear != null)
            {
                strSql1.Append("iyear,");
                strSql2.Append("" + model.iyear + ",");
            }
            if (model.iYPeriod != null)
            {
                strSql1.Append("iYPeriod,");
                strSql2.Append("" + model.iYPeriod + ",");
            }
            if (model.wllqDate != null)
            {
                strSql1.Append("wllqDate,");
                strSql2.Append("'" + model.wllqDate + "',");
            }
            if (model.wllqPeriod != null)
            {
                strSql1.Append("wllqPeriod,");
                strSql2.Append("" + model.wllqPeriod + ",");
            }
            if (model.tvouchtime != null)
            {
                strSql1.Append("tvouchtime,");
                strSql2.Append("'" + model.tvouchtime + "',");
            }
            if (model.cblueoutno_id != null)
            {
                strSql1.Append("cblueoutno_id,");
                strSql2.Append("'" + model.cblueoutno_id + "',");
            }
            if (model.ccodeexch_equal != null)
            {
                strSql1.Append("ccodeexch_equal,");
                strSql2.Append("'" + model.ccodeexch_equal + "',");
            }
            strSql.Append("insert into GL_accvouch(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            return (strSql.ToString());
        }
        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

