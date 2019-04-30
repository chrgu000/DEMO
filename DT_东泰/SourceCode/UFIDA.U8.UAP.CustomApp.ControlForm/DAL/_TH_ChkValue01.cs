using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:_TH_ChkValue01
    /// </summary>
    public partial class _TH_ChkValue01
    {
        public _TH_ChkValue01()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model._TH_ChkValue01 model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
          
            if (model.cCode != null)
            {
                strSql1.Append("cCode,");
                strSql2.Append("'" + model.cCode + "',");
            }
            if (model.dtmCode != null)
            {
                strSql1.Append("dtmCode,");
                strSql2.Append("'" + model.dtmCode + "',");
            }
            if (model.WONo != null)
            {
                strSql1.Append("WONo,");
                strSql2.Append("'" + model.WONo + "',");
            }
            if (model.WORow != null)
            {
                strSql1.Append("WORow,");
                strSql2.Append("" + model.WORow + ",");
            }
            if (model.MODid != null)
            {
                strSql1.Append("MODid,");
                strSql2.Append("" + model.MODid + ",");
            }
            if (model.WorkProcess != null)
            {
                strSql1.Append("WorkProcess,");
                strSql2.Append("'" + model.WorkProcess + "',");
            }
            if (model.WorkGroup != null)
            {
                strSql1.Append("WorkGroup,");
                strSql2.Append("'" + model.WorkGroup + "',");
            }
            if (model.WOBatch != null)
            {
                strSql1.Append("WOBatch,");
                strSql2.Append("'" + model.WOBatch + "',");
            }
            if (model.WOMould != null)
            {
                strSql1.Append("WOMould,");
                strSql2.Append("'" + model.WOMould + "',");
            }
            if (model.WODate != null)
            {
                strSql1.Append("WODate,");
                strSql2.Append("'" + model.WODate + "',");
            }
            if (model.cInvCode != null)
            {
                strSql1.Append("cInvCode,");
                strSql2.Append("'" + model.cInvCode + "',");
            }
            if (model.cInvName != null)
            {
                strSql1.Append("cInvName,");
                strSql2.Append("'" + model.cInvName + "',");
            }
            if (model.cInvStd != null)
            {
                strSql1.Append("cInvStd,");
                strSql2.Append("'" + model.cInvStd + "',");
            }
            if (model.cInvPerformance != null)
            {
                strSql1.Append("cInvPerformance,");
                strSql2.Append("'" + model.cInvPerformance + "',");
            }
            if (model.cInvDraw != null)
            {
                strSql1.Append("cInvDraw,");
                strSql2.Append("'" + model.cInvDraw + "',");
            }
            if (model.Weigth != null)
            {
                strSql1.Append("Weigth,");
                strSql2.Append("" + model.Weigth + ",");
            }
            if (model.Weigths != null)
            {
                strSql1.Append("Weigths,");
                strSql2.Append("" + model.Weigths + ",");
            }
            if (model.WeigthRB != null)
            {
                strSql1.Append("WeigthRB,");
                strSql2.Append("" + model.WeigthRB + ",");
            }
            if (model.WeigthsRB != null)
            {
                strSql1.Append("WeigthsRB,");
                strSql2.Append("" + model.WeigthsRB + ",");
            }
            if (model.QtyDZ != null)
            {
                strSql1.Append("QtyDZ,");
                strSql2.Append("" + model.QtyDZ + ",");
            }
            if (model.QtyG != null)
            {
                strSql1.Append("QtyG,");
                strSql2.Append("" + model.QtyG + ",");
            }
            if (model.QtyWJ != null)
            {
                strSql1.Append("QtyWJ,");
                strSql2.Append("" + model.QtyWJ + ",");
            }
            if (model.QtyGFS != null)
            {
                strSql1.Append("QtyGFS,");
                strSql2.Append("" + model.QtyGFS + ",");
            }
            if (model.QtyTXG != null)
            {
                strSql1.Append("QtyTXG,");
                strSql2.Append("" + model.QtyTXG + ",");
            }
            if (model.QtyTXD != null)
            {
                strSql1.Append("QtyTXD,");
                strSql2.Append("" + model.QtyTXD + ",");
            }
            if (model.QtyTXPK != null)
            {
                strSql1.Append("QtyTXPK,");
                strSql2.Append("" + model.QtyTXPK + ",");
            }
            if (model.QtyGH != null)
            {
                strSql1.Append("QtyGH,");
                strSql2.Append("" + model.QtyGH + ",");
            }
            if (model.QtyWGH != null)
            {
                strSql1.Append("QtyWGH,");
                strSql2.Append("" + model.QtyWGH + ",");
            }
            if (model.QtyHF != null)
            {
                strSql1.Append("QtyHF,");
                strSql2.Append("" + model.QtyHF + ",");
            }
            if (model.QtyUn1 != null)
            {
                strSql1.Append("QtyUn1,");
                strSql2.Append("" + model.QtyUn1 + ",");
            }
            if (model.QtyUn2 != null)
            {
                strSql1.Append("QtyUn2,");
                strSql2.Append("" + model.QtyUn2 + ",");
            }
            if (model.QtyUn3 != null)
            {
                strSql1.Append("QtyUn3,");
                strSql2.Append("" + model.QtyUn3 + ",");
            }
            if (model.CreatUid != null)
            {
                strSql1.Append("CreatUid,");
                strSql2.Append("'" + model.CreatUid + "',");
            }
            if (model.dtmCreate != null)
            {
                strSql1.Append("dtmCreate,");
                strSql2.Append("'" + model.dtmCreate + "',");
            }
            if (model.AuditUid != null)
            {
                strSql1.Append("AuditUid,");
                strSql2.Append("'" + model.AuditUid + "',");
            }
            if (model.dtmAudit != null)
            {
                strSql1.Append("dtmAudit,");
                strSql2.Append("'" + model.dtmAudit + "',");
            }
            if (model.Remark != null)
            {
                strSql1.Append("Remark,");
                strSql2.Append("'" + model.Remark + "',");
            }
            if (model.Qtypcs != null)
            {
                strSql1.Append("Qtypcs,");
                strSql2.Append("" + model.Qtypcs + ",");
            }

            strSql.Append("insert into _TH_ChkValue01(");
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

