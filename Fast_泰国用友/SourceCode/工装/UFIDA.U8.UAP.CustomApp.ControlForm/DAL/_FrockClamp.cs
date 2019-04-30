using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;


namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:_FrockClamp
    /// </summary>
    public partial class _FrockClamp
    {
        public _FrockClamp()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model._FrockClamp model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.SerialNo != null)
            {
                strSql1.Append("SerialNo,");
                strSql2.Append("N'" + model.SerialNo + "',");
            }
            if (model.InvName != null)
            {
                strSql1.Append("InvName,");
                strSql2.Append("N'" + model.InvName + "',");
            }
            if (model.InvStd != null)
            {
                strSql1.Append("InvStd,");
                strSql2.Append("N'" + model.InvStd + "',");
            }
            if (model.LC != null)
            {
                strSql1.Append("LC,");
                strSql2.Append("N'" + model.LC + "',");
            }
            if (model.Times != null)
            {
                strSql1.Append("Times,");
                strSql2.Append("" + model.Times + ",");
            }
            if (model.Service != null)
            {
                strSql1.Append("Service,");
                strSql2.Append("" + model.Service + ",");
            }
            if (model.S1 != null)
            {
                strSql1.Append("S1,");
                strSql2.Append("N'" + model.S1 + "',");
            }
            if (model.S2 != null)
            {
                strSql1.Append("S2,");
                strSql2.Append("N'" + model.S2 + "',");
            }
            if (model.S3 != null)
            {
                strSql1.Append("S3,");
                strSql2.Append("N'" + model.S3 + "',");
            }
            if (model.S4 != null)
            {
                strSql1.Append("S4,");
                strSql2.Append("N'" + model.S4 + "',");
            }
            if (model.S5 != null)
            {
                strSql1.Append("S5,");
                strSql2.Append("N'" + model.S5 + "',");
            }
            if (model.S6 != null)
            {
                strSql1.Append("S6,");
                strSql2.Append("N'" + model.S6 + "',");
            }
            if (model.S7 != null)
            {
                strSql1.Append("S7,");
                strSql2.Append("N'" + model.S7 + "',");
            }
            if (model.S8 != null)
            {
                strSql1.Append("S8,");
                strSql2.Append("N'" + model.S8 + "',");
            }
            if (model.S9 != null)
            {
                strSql1.Append("S9,");
                strSql2.Append("N'" + model.S9 + "',");
            }
            if (model.D1 != null)
            {
                strSql1.Append("D1,");
                strSql2.Append("" + model.D1 + ",");
            }
            if (model.D2 != null)
            {
                strSql1.Append("D2,");
                strSql2.Append("" + model.D2 + ",");
            }
            if (model.D3 != null)
            {
                strSql1.Append("D3,");
                strSql2.Append("" + model.D3 + ",");
            }
            if (model.D4 != null)
            {
                strSql1.Append("D4,");
                strSql2.Append("" + model.D4 + ",");
            }
            if (model.D5 != null)
            {
                strSql1.Append("D5,");
                strSql2.Append("" + model.D5 + ",");
            }
            if (model.D6 != null)
            {
                strSql1.Append("D6,");
                strSql2.Append("" + model.D6 + ",");
            }
            if (model.D7 != null)
            {
                strSql1.Append("D7,");
                strSql2.Append("" + model.D7 + ",");
            }
            if (model.D8 != null)
            {
                strSql1.Append("D8,");
                strSql2.Append("" + model.D8 + ",");
            }
            if (model.D9 != null)
            {
                strSql1.Append("D9,");
                strSql2.Append("" + model.D9 + ",");
            }
            if (model.Date1 != null)
            {
                strSql1.Append("Date1,");
                strSql2.Append("N'" + model.Date1 + "',");
            }
            if (model.Date2 != null)
            {
                strSql1.Append("Date2,");
                strSql2.Append("N'" + model.Date2 + "',");
            }
            if (model.Date3 != null)
            {
                strSql1.Append("Date3,");
                strSql2.Append("N'" + model.Date3 + "',");
            }
            if (model.Date4 != null)
            {
                strSql1.Append("Date4,");
                strSql2.Append("N'" + model.Date4 + "',");
            }
            if (model.Date5 != null)
            {
                strSql1.Append("Date5,");
                strSql2.Append("N'" + model.Date5 + "',");
            }
            if (model.Date6 != null)
            {
                strSql1.Append("Date6,");
                strSql2.Append("N'" + model.Date6 + "',");
            }
            if (model.Date7 != null)
            {
                strSql1.Append("Date7,");
                strSql2.Append("N'" + model.Date7 + "',");
            }
            if (model.Date8 != null)
            {
                strSql1.Append("Date8,");
                strSql2.Append("N'" + model.Date8 + "',");
            }
            if (model.Date9 != null)
            {
                strSql1.Append("Date9,");
                strSql2.Append("N'" + model.Date9 + "',");
            }
            if (model.Creater != null)
            {
                strSql1.Append("Creater,");
                strSql2.Append("N'" + model.Creater + "',");
            }
            if (model.CreaterDate != null)
            {
                strSql1.Append("CreaterDate,");
                strSql2.Append("N'" + model.CreaterDate + "',");
            }
            if (model.Updater != null)
            {
                strSql1.Append("Updater,");
                strSql2.Append("N'" + model.Updater + "',");
            }
            if (model.UpdateDate != null)
            {
                strSql1.Append("UpdateDate,");
                strSql2.Append("N'" + model.UpdateDate + "',");
            }
            if (model.Auditer != null)
            {
                strSql1.Append("Auditer,");
                strSql2.Append("N'" + model.Auditer + "',");
            }
            if (model.AuditeDate != null)
            {
                strSql1.Append("AuditeDate,");
                strSql2.Append("N'" + model.AuditeDate + "',");
            }
            if (model.Closed != null)
            {
                strSql1.Append("Closed,");
                strSql2.Append("N'" + model.Closed + "',");
            }
            if (model.CloseDate != null)
            {
                strSql1.Append("CloseDate,");
                strSql2.Append("N'" + model.CloseDate + "',");
            }
            if (model.iState != null)
            {
                strSql1.Append("iState,");
                strSql2.Append("" + model.iState + ",");
            }
            strSql.Append("insert into _FrockClamp(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            return (strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string Update(UFIDA.U8.UAP.CustomApp.ControlForm.Model._FrockClamp model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update _FrockClamp set ");
            if (model.InvName != null)
            {
                strSql.Append("InvName=N'" + model.InvName + "',");
            }
            else
            {
                strSql.Append("InvName= null ,");
            }
            if (model.InvStd != null)
            {
                strSql.Append("InvStd=N'" + model.InvStd + "',");
            }
            else
            {
                strSql.Append("InvStd= null ,");
            }
            if (model.LC != null)
            {
                strSql.Append("LC=N'" + model.LC + "',");
            }
            else
            {
                strSql.Append("LC= null ,");
            }
            if (model.Times != null)
            {
                strSql.Append("Times=" + model.Times + ",");
            }
            else
            {
                strSql.Append("Times= null ,");
            }
            if (model.Service != null)
            {
                strSql.Append("Service=" + model.Service + ",");
            }
            else
            {
                strSql.Append("Service= null ,");
            }
            if (model.S1 != null)
            {
                strSql.Append("S1=N'" + model.S1 + "',");
            }
            else
            {
                strSql.Append("S1= null ,");
            }
            if (model.S2 != null)
            {
                strSql.Append("S2=N'" + model.S2 + "',");
            }
            else
            {
                strSql.Append("S2= null ,");
            }
            if (model.S3 != null)
            {
                strSql.Append("S3=N'" + model.S3 + "',");
            }
            else
            {
                strSql.Append("S3= null ,");
            }
            if (model.S4 != null)
            {
                strSql.Append("S4=N'" + model.S4 + "',");
            }
            else
            {
                strSql.Append("S4= null ,");
            }
            if (model.S5 != null)
            {
                strSql.Append("S5=N'" + model.S5 + "',");
            }
            else
            {
                strSql.Append("S5= null ,");
            }
            if (model.S6 != null)
            {
                strSql.Append("S6=N'" + model.S6 + "',");
            }
            else
            {
                strSql.Append("S6= null ,");
            }
            if (model.S7 != null)
            {
                strSql.Append("S7=N'" + model.S7 + "',");
            }
            else
            {
                strSql.Append("S7= null ,");
            }
            if (model.S8 != null)
            {
                strSql.Append("S8=N'" + model.S8 + "',");
            }
            else
            {
                strSql.Append("S8= null ,");
            }
            if (model.S9 != null)
            {
                strSql.Append("S9=N'" + model.S9 + "',");
            }
            else
            {
                strSql.Append("S9= null ,");
            }
            if (model.D1 != null)
            {
                strSql.Append("D1=" + model.D1 + ",");
            }
            else
            {
                strSql.Append("D1= null ,");
            }
            if (model.D2 != null)
            {
                strSql.Append("D2=" + model.D2 + ",");
            }
            else
            {
                strSql.Append("D2= null ,");
            }
            if (model.D3 != null)
            {
                strSql.Append("D3=" + model.D3 + ",");
            }
            else
            {
                strSql.Append("D3= null ,");
            }
            if (model.D4 != null)
            {
                strSql.Append("D4=" + model.D4 + ",");
            }
            else
            {
                strSql.Append("D4= null ,");
            }
            if (model.D5 != null)
            {
                strSql.Append("D5=" + model.D5 + ",");
            }
            else
            {
                strSql.Append("D5= null ,");
            }
            if (model.D6 != null)
            {
                strSql.Append("D6=" + model.D6 + ",");
            }
            else
            {
                strSql.Append("D6= null ,");
            }
            if (model.D7 != null)
            {
                strSql.Append("D7=" + model.D7 + ",");
            }
            else
            {
                strSql.Append("D7= null ,");
            }
            if (model.D8 != null)
            {
                strSql.Append("D8=" + model.D8 + ",");
            }
            else
            {
                strSql.Append("D8= null ,");
            }
            if (model.D9 != null)
            {
                strSql.Append("D9=" + model.D9 + ",");
            }
            else
            {
                strSql.Append("D9= null ,");
            }
            if (model.Date1 != null)
            {
                strSql.Append("Date1=N'" + model.Date1 + "',");
            }
            else
            {
                strSql.Append("Date1= null ,");
            }
            if (model.Date2 != null)
            {
                strSql.Append("Date2=N'" + model.Date2 + "',");
            }
            else
            {
                strSql.Append("Date2= null ,");
            }
            if (model.Date3 != null)
            {
                strSql.Append("Date3=N'" + model.Date3 + "',");
            }
            else
            {
                strSql.Append("Date3= null ,");
            }
            if (model.Date4 != null)
            {
                strSql.Append("Date4=N'" + model.Date4 + "',");
            }
            else
            {
                strSql.Append("Date4= null ,");
            }
            if (model.Date5 != null)
            {
                strSql.Append("Date5=N'" + model.Date5 + "',");
            }
            else
            {
                strSql.Append("Date5= null ,");
            }
            if (model.Date6 != null)
            {
                strSql.Append("Date6=N'" + model.Date6 + "',");
            }
            else
            {
                strSql.Append("Date6= null ,");
            }
            if (model.Date7 != null)
            {
                strSql.Append("Date7=N'" + model.Date7 + "',");
            }
            else
            {
                strSql.Append("Date7= null ,");
            }
            if (model.Date8 != null)
            {
                strSql.Append("Date8=N'" + model.Date8 + "',");
            }
            else
            {
                strSql.Append("Date8= null ,");
            }
            if (model.Date9 != null)
            {
                strSql.Append("Date9=N'" + model.Date9 + "',");
            }
            else
            {
                strSql.Append("Date9= null ,");
            }
            if (model.Creater != null)
            {
                strSql.Append("Creater=N'" + model.Creater + "',");
            }
            else
            {
                strSql.Append("Creater= null ,");
            }
            if (model.CreaterDate != null)
            {
                strSql.Append("CreaterDate=N'" + model.CreaterDate + "',");
            }
            else
            {
                strSql.Append("CreaterDate= null ,");
            }
            if (model.Updater != null)
            {
                strSql.Append("Updater=N'" + model.Updater + "',");
            }
            else
            {
                strSql.Append("Updater= null ,");
            }
            if (model.UpdateDate != null)
            {
                strSql.Append("UpdateDate=N'" + model.UpdateDate + "',");
            }
            else
            {
                strSql.Append("UpdateDate= null ,");
            }
            if (model.Auditer != null)
            {
                strSql.Append("Auditer=N'" + model.Auditer + "',");
            }
            else
            {
                strSql.Append("Auditer= null ,");
            }
            if (model.AuditeDate != null)
            {
                strSql.Append("AuditeDate=N'" + model.AuditeDate + "',");
            }
            else
            {
                strSql.Append("AuditeDate= null ,");
            }
            if (model.Closed != null)
            {
                strSql.Append("Closed=N'" + model.Closed + "',");
            }
            else
            {
                strSql.Append("Closed= null ,");
            }
            if (model.CloseDate != null)
            {
                strSql.Append("CloseDate=N'" + model.CloseDate + "',");
            }
            else
            {
                strSql.Append("CloseDate= null ,");
            }
            if (model.iState != null)
            {
                strSql.Append("iState=" + model.iState + ",");
            }
            else
            {
                strSql.Append("iState= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where SerialNo=N'" + model.SerialNo + "' ");
            return (strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public string Delete(string SerialNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from _FrockClamp ");
            strSql.Append(" where SerialNo=N'" + SerialNo + "' ");
            return (strSql.ToString());
        }		

        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

