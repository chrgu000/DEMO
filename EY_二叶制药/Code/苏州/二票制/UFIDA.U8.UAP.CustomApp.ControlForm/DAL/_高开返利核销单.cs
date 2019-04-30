using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:_高开返利核销单
    /// </summary>
    public partial class _高开返利核销单
    {
        public _高开返利核销单()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model._高开返利核销单 model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.cCode != null)
            {
                strSql1.Append("cCode,");
                strSql2.Append("'" + model.cCode + "',");
            }
            if (model.dtmDate != null)
            {
                strSql1.Append("dtmDate,");
                strSql2.Append("'" + model.dtmDate + "',");
            }
            if (model.dMoney != null)
            {
                strSql1.Append("dMoney,");
                strSql2.Append("" + model.dMoney + ",");
            }
            if (model.FLD_iID != null)
            {
                strSql1.Append("FLD_iID,");
                strSql2.Append("" + model.FLD_iID + ",");
            }
            if (model.FLD_cCode != null)
            {
                strSql1.Append("FLD_cCode,");
                strSql2.Append("'" + model.FLD_cCode + "',");
            }
            if (model.FLD_Money != null)
            {
                strSql1.Append("FLD_Money,");
                strSql2.Append("" + model.FLD_Money + ",");
            }
            if (model.FP_IDs != null)
            {
                strSql1.Append("FP_IDs,");
                strSql2.Append("" + model.FP_IDs + ",");
            }
            if (model.FP_Code != null)
            {
                strSql1.Append("FP_Code,");
                strSql2.Append("'" + model.FP_Code + "',");
            }
            if (model.FP_Money != null)
            {
                strSql1.Append("FP_Money,");
                strSql2.Append("" + model.FP_Money + ",");
            }
            if (model.createUid != null)
            {
                strSql1.Append("createUid,");
                strSql2.Append("'" + model.createUid + "',");
            }
            if (model.dtmCreate != null)
            {
                strSql1.Append("dtmCreate,");
                strSql2.Append("'" + model.dtmCreate + "',");
            }
            if (model.Remark != null)
            {
                strSql1.Append("Remark,");
                strSql2.Append("'" + model.Remark + "',");
            }
            if (model.GUID != null)
            {
                strSql1.Append("GUID,");
                strSql2.Append("'" + Guid.NewGuid().ToString() + "',");
            }
            if (model.dtmSysCreatetime != null)
            {
                strSql1.Append("dtmSysCreatetime,");
                strSql2.Append("'" + model.dtmSysCreatetime + "',");
            }
            if (model.bRed != null)
            {
                strSql1.Append("bRed,");
                strSql2.Append("" + model.bRed + ",");
            }
            strSql.Append("insert into _高开返利核销单(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            return strSql.ToString();
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string Update(UFIDA.U8.UAP.CustomApp.ControlForm.Model._高开返利核销单 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update _高开返利核销单 set ");
            if (model.cCode != null)
            {
                strSql.Append("cCode='" + model.cCode + "',");
            }
            else
            {
                strSql.Append("cCode= null ,");
            }
            if (model.dtmDate != null)
            {
                strSql.Append("dtmDate='" + model.dtmDate + "',");
            }
            else
            {
                strSql.Append("dtmDate= null ,");
            }
            if (model.dMoney != null)
            {
                strSql.Append("dMoney=" + model.dMoney + ",");
            }
            else
            {
                strSql.Append("dMoney= null ,");
            }
            if (model.FLD_iID != null)
            {
                strSql.Append("FLD_iID=" + model.FLD_iID + ",");
            }
            else
            {
                strSql.Append("FLD_iID= null ,");
            }
            if (model.FLD_cCode != null)
            {
                strSql.Append("FLD_cCode='" + model.FLD_cCode + "',");
            }
            else
            {
                strSql.Append("FLD_cCode= null ,");
            }
            if (model.FLD_Money != null)
            {
                strSql.Append("FLD_Money=" + model.FLD_Money + ",");
            }
            else
            {
                strSql.Append("FLD_Money= null ,");
            }
            if (model.FP_IDs != null)
            {
                strSql.Append("FP_IDs=" + model.FP_IDs + ",");
            }
            else
            {
                strSql.Append("FP_IDs= null ,");
            }
            if (model.FP_Code != null)
            {
                strSql.Append("FP_Code='" + model.FP_Code + "',");
            }
            else
            {
                strSql.Append("FP_Code= null ,");
            }
            if (model.FP_Money != null)
            {
                strSql.Append("FP_Money=" + model.FP_Money + ",");
            }
            else
            {
                strSql.Append("FP_Money= null ,");
            }
            if (model.createUid != null)
            {
                strSql.Append("createUid='" + model.createUid + "',");
            }
            else
            {
                strSql.Append("createUid= null ,");
            }
            if (model.dtmCreate != null)
            {
                strSql.Append("dtmCreate='" + model.dtmCreate + "',");
            }
            else
            {
                strSql.Append("dtmCreate= null ,");
            }
            if (model.Remark != null)
            {
                strSql.Append("Remark='" + model.Remark + "',");
            }
            else
            {
                strSql.Append("Remark= null ,");
            }
            if (model.GUID != null)
            {
                strSql.Append("GUID='" + model.GUID + "',");
            }
            else
            {
                strSql.Append("GUID= null ,");
            }
            if (model.dtmSysCreatetime != null)
            {
                strSql.Append("dtmSysCreatetime='" + model.dtmSysCreatetime + "',");
            }
            else
            {
                strSql.Append("dtmSysCreatetime= null ,");
            }
            if (model.bRed != null)
            {
                strSql.Append("bRed=" + model.bRed + ",");
            }
            else
            {
                strSql.Append("bRed= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where iID=" + model.iID + "");
            return (strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public string Delete(string sCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from _高开返利核销单 ");
            strSql.Append(" where cCode=" + sCode + "");
            return (strSql.ToString());

        }	

        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

