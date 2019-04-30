using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class WO_Maintenance : System.Web.UI.Page
{
    ASPxGridViewShow gridview = new ASPxGridViewShow();
    string sSQL;
    string tablename = "WO";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            YxBtn.HidFormID = "Maintenance";
            Calendar1.Value = DateTime.Now.AddYears(-1).ToString("yyyy-MM-dd");
            Calendar2.Value = DateTime.Now.ToString("yyyy-MM-dd");
            YxBtn.GetViewState(divSel);
            GetTitle();
            
        }
    }

    #region 标题
    private void GetTitle()
    {
        WOData ed = new WOData();
        string iID = "";
        string S1 = "";
        string S2 = "";
        string S3 = "";
        string S4 = "";
        string S5 = "";
        string S6 = "";
        string S7 = "";
        string S8 = "";
        string S9 = "";
        string S10 = "";
        string S11 = "";
        string S12 = "";
        string S13 = "";
        string S14 = "";
        string S15 = "";
        DateTime sDate1 = DateTime.MinValue;
        DateTime eDate1 = DateTime.MinValue;
        DateTime sDate2 = DateTime.MinValue;
        DateTime eDate2 = DateTime.MinValue;
        DateTime sDate3 = DateTime.MinValue;
        DateTime eDate3 = DateTime.MinValue;
        DateTime sDate4 = DateTime.MinValue;
        DateTime eDate4 = DateTime.MinValue;
        DateTime sDate5 = DateTime.MinValue;
        DateTime eDate5 = DateTime.MinValue;
        if (Calendar1.Value != "")
        {
            sDate2 = DateTime.Parse(Calendar1.Value);
        }
        if (Calendar2.Value != "")
        {
            eDate2 = DateTime.Parse(Calendar2.Value);
        }
        DataTable dt = ed.Get(iID, S1, S2, S3, S4, S5, S6, S7, S8, S9, S10, S11, S12, S13, S14, S15, sDate1, eDate1, sDate2, eDate2, sDate3, eDate3, sDate4, eDate4, sDate5, eDate5);
        string col = "S1,S3,S4,Date1,S5,S6,Date3,Date4";
        GetList(thead1, tbody1, tablename, dt, col);

    }


    public void GetList(HtmlGenericControl thead1, HtmlGenericControl con1, string tablename, DataTable dts, string col)
    {
        ClsDataBase clsSQLCommond = new ClsDataBase();
        PublicClass pc = new PublicClass();
        string[] colsplit = col.Split(',');
        string ctext = pc.GetLanguageColumn();
        string h = "";
        PublicData pd = new PublicData();
        sSQL = "select * from  _TableColInfo where  TABLE_NAME in ('" + tablename + "') and (COLUMN_Text<>'' or ShowCol<>'') and VisibleIndex is not null order by VisibleIndex";
        DataTable dt = clsSQLCommond.ExecQuery(sSQL);
        HtmlTableRow twbody = new HtmlTableRow();
        h = "<tr>";
        for (int i = 0; i < colsplit.Length; i++)
        {
            string coltext = "";
            DataRow[] dw = dt.Select("COLUMN_NAME='" + colsplit[i] + "'");
            if (dw.Length > 0)
            {
                if (dw[0]["ShowCol"].ToString().Trim() != "")
                {
                    coltext = dw[0]["ShowCol"].ToString();
                }
                else
                {
                    coltext = dw[0]["COLUMN_Text"].ToString();
                }
            }
            h = h + "<th>" + coltext + "</th>";
        }
        h = h + "</tr>";
        Literal hc = new Literal();
        hc.Text = h;
        thead1.Controls.Add(hc);
        string l = "";
        string[] colersplit = new string[] { "Red", "Yellow", "Green" };
        for (int i = 0; i < dts.Rows.Count; i++)
        {
            string color = "";
            string svalue = dts.Rows[i]["Date3"].ToString();
            string evalue = dts.Rows[i]["Date4"].ToString();
            if (svalue == "")
            {
                color = colersplit[0];
            }
            else if (svalue != "" && evalue == "")
            {
                color = colersplit[1];
            }
            else if (evalue != "")
            {
                color = colersplit[2];
            }
            l = l + "<tr>";
            for (int j = 0; j < colsplit.Length; j++)
            {
                DataRow[] dw = dt.Select("COLUMN_NAME='" + colsplit[j] + "'");
                string value = "";
                value = dts.Rows[i][dw[0]["COLUMN_NAME"].ToString()].ToString();
                
                switch (dw[0]["ColType"].ToString())
                {
                    case "":
                        switch (dw[0]["UpdateType"].ToString().Trim())
                        {
                            case "date":
                                if (value != "")
                                {
                                    value = DateTime.Parse(value).ToString("yyyy-MM-dd");
                                }
                                break;
                            case "select":
                                switch (dw[0]["ColSel"].ToString())
                                {
                                    case "LookUpData":
                                        string iType = dw[0]["ColSelFlag"].ToString();
                                        if (iType != "")
                                        {
                                            value = pd.GetLookUpData(iType, value);
                                        }
                                        break;
                                    case "Equip":
                                        value = pd.GetEquip(value);
                                        break;
                                    case "EquipType":
                                        value = pd.GetEquipType(value);
                                        break;
                                    case "Inventory":
                                        value = pd.GetInventory(value);
                                        break;
                                    case "Machine":
                                        value = pd.GetMachine(value);
                                        break;
                                    case "Worker":
                                        value = pd.GetWorkers(value);
                                        break;
                                    default:
                                        value = "";
                                        break;
                                }
                                break;
                            default:
                                break;
                        }
                        l = l + "<td style='background:" + color + "'>" + value + "</td>";
                        break;
                    case "a":
                        l = l + "<td>" + value + "</td>";
                        break;
                    default:
                        l = l + "<td>" + value + "</td>";
                        break;
                }
            }
        }
        l = l + "</tr>";
        Literal lc = new Literal();
        lc.Text = l;
        con1.Controls.Add(lc);
    }
    #endregion

    #region 按钮
    protected void ToSelect(object sender, EventArgs e)
    {
        YxBtn.SetViewState(divSel);
        GetTitle();
    }

    protected void ToSave(object sender, EventArgs e)
    {

    }

    protected void ToNew(object sender, EventArgs e)
    {
        Response.Redirect("Update.aspx");
    }

    protected void ToDel(object sender, EventArgs e)
    {

    }

    protected void ToExport(object sender, EventArgs e)
    {
        //ASPxGridViewExporter1.WriteXlsToResponse(this.Title);
    }

    protected void ToBeck(object sender, EventArgs e)
    {

    }
    #endregion
}

