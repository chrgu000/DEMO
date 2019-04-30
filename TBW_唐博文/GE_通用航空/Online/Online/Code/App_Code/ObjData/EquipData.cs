using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;

    /// <summary>
    ///Public 的摘要说明
    /// </summary>
public class EquipData : Page
{
    ClsDataBase clsSQLCommond = new ClsDataBase();
    系统服务.ClsDES clsDES = 系统服务.ClsDES.Instance();
    string sSQL = "";
    string tablename = "Equip";
    public EquipData()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    public DataTable Get(string iID, string S1, string S2, string S3, string S4, string S5, string S6, string S7, string S8, string S9, string S10, string S11, string S12, string S13, string S14, string S15,
        DateTime sDate1, DateTime eDate1, DateTime sDate2, DateTime eDate2, DateTime sDate3, DateTime eDate3, DateTime sDate4, DateTime eDate4, DateTime sDate5, DateTime eDate5)
    {
        sSQL = "SELECT * FROM   " + tablename + " where 1=1 ";
        if (S1 != null && S1.Trim() != "")
        {
            sSQL = sSQL + " and S1='" + S1.Trim() + "'";
        }
        if (S2 != null && S2.Trim() != "")
        {
            sSQL = sSQL + " and S2='" + S2.Trim() + "'";
        }
        if (S3 != null && S3.Trim() != "")
        {
            sSQL = sSQL + " and S3='" + S3.Trim() + "'";
        }
        if (S4 != null && S4.Trim() != "")
        {
            sSQL = sSQL + " and S4='" + S4.Trim() + "'";
        }
        if (S5 != null && S5.Trim() != "")
        {
            sSQL = sSQL + " and S5='" + S5.Trim() + "'";
        }
        if (S6 != null && S6.Trim() != "")
        {
            sSQL = sSQL + " and S6='" + S6.Trim() + "'";
        }
        if (S7 != null && S7.Trim() != "")
        {
            sSQL = sSQL + " and S7='" + S7.Trim() + "'";
        }
        if (S8 != null && S8.Trim() != "")
        {
            sSQL = sSQL + " and S8='" + S8.Trim() + "'";
        }
        if (S9 != null && S9.Trim() != "")
        {
            sSQL = sSQL + " and S9='" + S9.Trim() + "'";
        }
        if (S10 != null && S10.Trim() != "")
        {
            sSQL = sSQL + " and S10='" + S10.Trim() + "'";
        }
        if (S11 != null && S11.Trim() != "")
        {
            sSQL = sSQL + " and S11='" + S11.Trim() + "'";
        }
        if (S12 != null && S12.Trim() != "")
        {
            sSQL = sSQL + " and S12='" + S12.Trim() + "'";
        }
        if (S13 != null && S13.Trim() != "")
        {
            sSQL = sSQL + " and S13='" + S13.Trim() + "'";
        }
        if (S14 != null && S14.Trim() != "")
        {
            sSQL = sSQL + " and S14='" + S14.Trim() + "'";
        }
        if (S15 != null && S15.Trim() != "")
        {
            sSQL = sSQL + " and S15='" + S15.Trim() + "'";
        }
        if (sDate1 != null && sDate1 != DateTime.MinValue)
        {
            sSQL = sSQL + " and Date1>='" + sDate1 + "'";
        }
        if (eDate1 != null && eDate1 != DateTime.MinValue)
        {
            sSQL = sSQL + " and Date1<='" + eDate1 + "'";
        }
        if (sDate2 != null && sDate2 != DateTime.MinValue)
        {
            sSQL = sSQL + " and Date2>='" + sDate2 + "'";
        }
        if (eDate2 != null && eDate2 != DateTime.MinValue)
        {
            sSQL = sSQL + " and Date2<='" + eDate2 + "'";
        }
        if (sDate3 != null && sDate3 != DateTime.MinValue)
        {
            sSQL = sSQL + " and Date3>='" + sDate3 + "'";
        }
        if (eDate3 != null && eDate3 != DateTime.MinValue)
        {
            sSQL = sSQL + " and Date3<='" + eDate3 + "'";
        }
        if (sDate4 != null && sDate4 != DateTime.MinValue)
        {
            sSQL = sSQL + " and Date4>='" + sDate4 + "'";
        }
        if (eDate4 != null && eDate4 != DateTime.MinValue)
        {
            sSQL = sSQL + " and Date4<='" + eDate4 + "'";
        }
        if (sDate5 != null && sDate5 != DateTime.MinValue)
        {
            sSQL = sSQL + " and Date5>='" + sDate5 + "'";
        }
        if (eDate5 != null && eDate5 != DateTime.MinValue)
        {
            sSQL = sSQL + " and Date5<='" + eDate5 + "'";
        }

        DataTable dt = clsSQLCommond.ExecQuery(sSQL);
        return dt;
    }

    public bool Insert(string iID, string S1, string S2, string S3, string S4, string S5, string S6, string S7, string S8, string S9, string S10, string S11, string S12, string S13, string S14, string S15,
        DateTime Date1, DateTime Date2, DateTime Date3, DateTime Date4, DateTime Date5,
        decimal D1, decimal D2, decimal D3, decimal D4, decimal D5, decimal D6, decimal D7, decimal D8, decimal D9, decimal D10)
    {
        string uid = Session["uID"].ToString();
        ArrayList arr = new ArrayList();
        Sql sql = new Sql();
        if (iID == "" || iID == null)
        {
            sSQL = "select isnull(max(iID),0)+1 from  " + tablename + "";
            iID = clsSQLCommond.ExecString(sSQL);
            sql.Get(tablename, "iID", iID, true);
            sql.ToString("dCreatesysTime", DateTime.Now);
            sql.ToString("dCreatesysPerson", uid);
        }
        else
        {
            sql.Get(tablename, "iID", iID, false);
            sql.ToString("dChangeVerifyTime", DateTime.Now);
            sql.ToString("dChangeVerifyPerson", uid);
        }
        sql.ToString("S1", S1);
        sql.ToString("S2", S2);
        sql.ToString("S3", S3);
        sql.ToString("S4", S4);
        sql.ToString("S5", S5);
        sql.ToString("S6", S6);
        sql.ToString("S7", S7);
        sql.ToString("S8", S8);
        sql.ToString("S9", S9);
        sql.ToString("S10", S10);
        sql.ToString("S11", S11);
        sql.ToString("S12", S12);
        sql.ToString("S13", S13);
        sql.ToString("S14", S14);
        sql.ToString("S15", S15);
        sql.ToString("Date1", Date1);
        sql.ToString("Date2", Date2);
        sql.ToString("Date3", Date3);
        sql.ToString("Date4", Date4);
        sql.ToString("Date5", Date5);
        sql.ToString("D1", D1);
        sql.ToString("D2", D2);
        sql.ToString("D3", D3);
        sql.ToString("D4", D4);
        sql.ToString("D5", D5);
        sql.ToString("D6", D6);
        sql.ToString("D7", D7);
        sql.ToString("D8", D8);
        sql.ToString("D9", D9);
        sql.ToString("D10", D10);
        arr.Add(sql.ReturnSql());
        bool b = clsSQLCommond.ExecSqlTran(arr);
        return b;
    }


    public bool Delete(Int32 iID, string S1)
    {
        sSQL = "delete from " + tablename + " where iID='" + iID + "'";
        bool b = clsSQLCommond.Update(sSQL);
        return b;
    }

}
