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

public partial class System_LookUpDataIndex : System.Web.UI.Page
{
    ASPxGridViewShow gridview = new ASPxGridViewShow();
    string sSQL;
    string tablename = "_LookUpDate";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            YxBtn.HidFormID = "FrmLookUpDataList";
            YxBtn.GetViewState(divSel);
            GetTitle();
            
        }
    }

    #region 标题
    private void GetTitle()
    {
        LookUpDataData ed = new LookUpDataData();
        string iID = "";
        string iType = DropDownListS9.Value;
        DataTable dt = ed.Get(iType);

        GetList(thead1, tbody1, tablename, dt);
    }

    public void GetList(HtmlGenericControl thead1, HtmlGenericControl con1, string tablename, DataTable dts)
    {
        ClsDataBase clsSQLCommond = new ClsDataBase();
        PublicClass pc = new PublicClass();
        string ctext = pc.GetLanguageColumn();
        string h = "";
        PublicData pd = new PublicData();
        sSQL = "select * from  _TableColInfo where  TABLE_NAME in ('" + tablename + "') and (COLUMN_Text<>'' or ShowCol<>'') and VisibleIndex is not null order by VisibleIndex";
        DataTable dt = clsSQLCommond.ExecQuery(sSQL);
        HtmlTableRow twbody = new HtmlTableRow();
        h = "<tr>";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string coltext = "";
            if (dt.Rows[i]["ShowCol"].ToString().Trim() != "")
            {
                coltext = dt.Rows[i]["ShowCol"].ToString();
            }
            else
            {
                coltext = dt.Rows[i]["COLUMN_Text"].ToString();
            }
            h = h + "<th>" + coltext + "</th>";
        }
        h = h + "</tr>";
        Literal hc = new Literal();
        hc.Text = h;
        thead1.Controls.Add(hc);
        string l = "";
        for (int i = 0; i < dts.Rows.Count; i++)
        {
            l = l + "<tr>";
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                string value = "";
                value = dts.Rows[i][dt.Rows[j]["COLUMN_NAME"].ToString()].ToString();
                switch (dt.Rows[j]["ColType"].ToString())
                {
                    case "":
                        switch (dt.Rows[j]["UpdateType"].ToString().Trim())
                        {
                            case "date":
                                if (value != "")
                                {
                                    value = DateTime.Parse(value).ToString("yyyy-MM-dd");
                                }
                                break;
                            case "select":
                                switch (dt.Rows[j]["ColSel"].ToString())
                                {
                                    case "LookUpData":
                                        string iType = dt.Rows[j]["ColSelFlag"].ToString();
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
                                    case "LookUpType":
                                        value = pd.GetLookUpType(value);
                                        break;
                                    default:
                                        value = "";
                                        break;
                                }
                                break;
                            default:
                                break;
                        }
                        l = l + "<td>" + value + "</td>";
                        break;
                    case "a":
                        l = l + "<td><a href='" + dt.Rows[j]["ColLink"].ToString() + "?ID=" + dts.Rows[i][dt.Rows[j]["COLUMN_NAME"].ToString()].ToString() + "&iType=" + dts.Rows[i]["iType"].ToString() + "'>" + dts.Rows[i][dt.Rows[j]["COLUMN_NAME"].ToString()].ToString() + "</a></td>";
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
        Response.Redirect("LookUpData_Update.aspx");
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
        Response.Redirect("LookUpData_Index.aspx");
    }
    #endregion
}

