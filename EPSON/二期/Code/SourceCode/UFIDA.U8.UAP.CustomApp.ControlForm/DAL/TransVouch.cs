using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:TransVouch
    /// </summary>
    public partial class TransVouch
    {
        public TransVouch()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model.TransVouch model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.cTVCode != null)
            {
                strSql1.Append("cTVCode,");
                strSql2.Append("'" + model.cTVCode + "',");
            }
            if (model.dTVDate != null)
            {
                strSql1.Append("dTVDate,");
                strSql2.Append("'" + model.dTVDate + "',");
            }
            if (model.cOWhCode != null)
            {
                strSql1.Append("cOWhCode,");
                strSql2.Append("'" + model.cOWhCode + "',");
            }
            if (model.cIWhCode != null)
            {
                strSql1.Append("cIWhCode,");
                strSql2.Append("'" + model.cIWhCode + "',");
            }
            if (model.cODepCode != null)
            {
                strSql1.Append("cODepCode,");
                strSql2.Append("'" + model.cODepCode + "',");
            }
            if (model.cIDepCode != null)
            {
                strSql1.Append("cIDepCode,");
                strSql2.Append("'" + model.cIDepCode + "',");
            }
            if (model.cPersonCode != null)
            {
                strSql1.Append("cPersonCode,");
                strSql2.Append("'" + model.cPersonCode + "',");
            }
            if (model.cIRdCode != null)
            {
                strSql1.Append("cIRdCode,");
                strSql2.Append("'" + model.cIRdCode + "',");
            }
            if (model.cORdCode != null)
            {
                strSql1.Append("cORdCode,");
                strSql2.Append("'" + model.cORdCode + "',");
            }
            if (model.cTVMemo != null)
            {
                strSql1.Append("cTVMemo,");
                strSql2.Append("'" + model.cTVMemo + "',");
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
            if (model.cAccounter != null)
            {
                strSql1.Append("cAccounter,");
                strSql2.Append("'" + model.cAccounter + "',");
            }
            if (model.cMaker != null)
            {
                strSql1.Append("cMaker,");
                strSql2.Append("'" + model.cMaker + "',");
            }
            if (model.iNetLock != null)
            {
                strSql1.Append("iNetLock,");
                strSql2.Append("" + model.iNetLock + ",");
            }
            if (model.ID != null)
            {
                strSql1.Append("ID,");
                strSql2.Append("" + model.ID + ",");
            }
            if (model.VT_ID != null)
            {
                strSql1.Append("VT_ID,");
                strSql2.Append("" + model.VT_ID + ",");
            }
            if (model.cVerifyPerson != null)
            {
                strSql1.Append("cVerifyPerson,");
                strSql2.Append("'" + model.cVerifyPerson + "',");
            }
            if (model.dVerifyDate != null)
            {
                strSql1.Append("dVerifyDate,");
                strSql2.Append("'" + model.dVerifyDate + "',");
            }
            if (model.cPSPCode != null)
            {
                strSql1.Append("cPSPCode,");
                strSql2.Append("'" + model.cPSPCode + "',");
            }
            if (model.cMPoCode != null)
            {
                strSql1.Append("cMPoCode,");
                strSql2.Append("'" + model.cMPoCode + "',");
            }
            if (model.iQuantity != null)
            {
                strSql1.Append("iQuantity,");
                strSql2.Append("" + model.iQuantity + ",");
            }
            if (model.bTransFlag != null)
            {
                strSql1.Append("bTransFlag,");
                strSql2.Append("" + model.bTransFlag + ",");
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
            //if (model.ufts != null)
            //{
            //    strSql1.Append("ufts,");
            //    strSql2.Append("" + model.ufts + ",");
            //}
            if (model.iproorderid != null)
            {
                strSql1.Append("iproorderid,");
                strSql2.Append("" + model.iproorderid + ",");
            }
            if (model.cOrderType != null)
            {
                strSql1.Append("cOrderType,");
                strSql2.Append("'" + model.cOrderType + "',");
            }
            if (model.cTranRequestCode != null)
            {
                strSql1.Append("cTranRequestCode,");
                strSql2.Append("'" + model.cTranRequestCode + "',");
            }
            if (model.cVersion != null)
            {
                strSql1.Append("cVersion,");
                strSql2.Append("'" + model.cVersion + "',");
            }
            if (model.BomId != null)
            {
                strSql1.Append("BomId,");
                strSql2.Append("" + model.BomId + ",");
            }
            if (model.cFree1 != null)
            {
                strSql1.Append("cFree1,");
                strSql2.Append("'" + model.cFree1 + "',");
            }
            if (model.cFree2 != null)
            {
                strSql1.Append("cFree2,");
                strSql2.Append("'" + model.cFree2 + "',");
            }
            if (model.cFree3 != null)
            {
                strSql1.Append("cFree3,");
                strSql2.Append("'" + model.cFree3 + "',");
            }
            if (model.cFree4 != null)
            {
                strSql1.Append("cFree4,");
                strSql2.Append("'" + model.cFree4 + "',");
            }
            if (model.cFree5 != null)
            {
                strSql1.Append("cFree5,");
                strSql2.Append("'" + model.cFree5 + "',");
            }
            if (model.cFree6 != null)
            {
                strSql1.Append("cFree6,");
                strSql2.Append("'" + model.cFree6 + "',");
            }
            if (model.cFree7 != null)
            {
                strSql1.Append("cFree7,");
                strSql2.Append("'" + model.cFree7 + "',");
            }
            if (model.cFree8 != null)
            {
                strSql1.Append("cFree8,");
                strSql2.Append("'" + model.cFree8 + "',");
            }
            if (model.cFree9 != null)
            {
                strSql1.Append("cFree9,");
                strSql2.Append("'" + model.cFree9 + "',");
            }
            if (model.cFree10 != null)
            {
                strSql1.Append("cFree10,");
                strSql2.Append("'" + model.cFree10 + "',");
            }
            if (model.cAppTVCode != null)
            {
                strSql1.Append("cAppTVCode,");
                strSql2.Append("'" + model.cAppTVCode + "',");
            }
            if (model.csource != null)
            {
                strSql1.Append("csource,");
                strSql2.Append("'" + model.csource + "',");
            }
            if (model.itransflag != null)
            {
                strSql1.Append("itransflag,");
                strSql2.Append("'" + model.itransflag + "',");
            }
            if (model.cModifyPerson != null)
            {
                strSql1.Append("cModifyPerson,");
                strSql2.Append("'" + model.cModifyPerson + "',");
            }
            if (model.dModifyDate != null)
            {
                strSql1.Append("dModifyDate,");
                strSql2.Append("'" + model.dModifyDate + "',");
            }
            if (model.dnmaketime != null)
            {
                strSql1.Append("dnmaketime,");
                strSql2.Append("'" + model.dnmaketime + "',");
            }
            if (model.dnmodifytime != null)
            {
                strSql1.Append("dnmodifytime,");
                strSql2.Append("'" + model.dnmodifytime + "',");
            }
            if (model.dnverifytime != null)
            {
                strSql1.Append("dnverifytime,");
                strSql2.Append("'" + model.dnverifytime + "',");
            }
            if (model.ireturncount != null)
            {
                strSql1.Append("ireturncount,");
                strSql2.Append("" + model.ireturncount + ",");
            }
            if (model.iverifystate != null)
            {
                strSql1.Append("iverifystate,");
                strSql2.Append("" + model.iverifystate + ",");
            }
            if (model.iswfcontrolled != null)
            {
                strSql1.Append("iswfcontrolled,");
                strSql2.Append("" + model.iswfcontrolled + ",");
            }
            if (model.cbustype != null)
            {
                strSql1.Append("cbustype,");
                strSql2.Append("'" + model.cbustype + "',");
            }
            if (model.cSourceCodeLs != null)
            {
                strSql1.Append("cSourceCodeLs,");
                strSql2.Append("'" + model.cSourceCodeLs + "',");
            }
            if (model.iPrintCount != null)
            {
                strSql1.Append("iPrintCount,");
                strSql2.Append("" + model.iPrintCount + ",");
            }
            if (model.csourceguid != null)
            {
                strSql1.Append("csourceguid,");
                strSql2.Append("'" + model.csourceguid + "',");
            }
            if (model.csysbarcode != null)
            {
                strSql1.Append("csysbarcode,");
                strSql2.Append("'" + model.csysbarcode + "',");
            }
            if (model.cCurrentAuditor != null)
            {
                strSql1.Append("cCurrentAuditor,");
                strSql2.Append("'" + model.cCurrentAuditor + "',");
            }
            strSql.Append("insert into TransVouch(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            return (strSql.ToString());
        }
        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

