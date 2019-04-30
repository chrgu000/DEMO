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
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Text;

    /// <summary>
    /// TableHelp 的摘要说明
    /// </summary>
public class ASPxGridViewShow:Page
{
    ClsDataBase clsSQLCommond = new ClsDataBase();
    string sSQL = "";
    public ASPxGridViewShow()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    #region 生成标题
    public void GetList(HtmlGenericControl thead1, HtmlGenericControl con1, string tablename, DataTable dts)
    {
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
        hc.Text=h;
        thead1.Controls.Add(hc);
        string l = "";
        for (int i = 0; i < dts.Rows.Count; i++)
        {
            l = l + "<tr>";
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                string value = "";
                value = dts.Rows[i][dt.Rows[j]["COLUMN_NAME"].ToString()].ToString();
                switch  (dt.Rows[j]["ColType"].ToString())
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
                                        value="";
                                        break;
                                }
                                break;
                            default:
                                break;
                        }
                        l = l + "<td>" + value + "</td>";
                        break;
                    case "a":
                        l = l + "<td><a href='" + dt.Rows[j]["ColLink"].ToString() + "?iID=" + dts.Rows[i][dt.Rows[j]["COLUMN_NAME"].ToString()].ToString() + "'>" + dts.Rows[i][dt.Rows[j]["COLUMN_NAME"].ToString()].ToString() + "</a></td>";
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

    

    public void GetUpdate(HtmlTable TableUpdate1, string tablename, DataTable dts,string bCol,bool bRed)
    {
        PublicClass pc = new PublicClass();
        string ctext = pc.GetLanguageColumn();
        string h = "";
        PublicData pd = new PublicData();
        ControlsClass cc = new ControlsClass();
        sSQL = "select * from  _TableColInfo where  TABLE_NAME in ('" + tablename + "')  order by UpdateVisibleIndex";
        DataTable dt = clsSQLCommond.ExecQuery(sSQL);
        bool b = true;
        if (dts == null || dts.Rows.Count == 0)
        {
            b = false;
        }
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            HtmlTableRow tw = new HtmlTableRow();
            if (dt.Rows[i]["UpdateVisibleIndex"].ToString().Trim() == "")
            {
                tw.Style.Add("display", "none");
            }
            string coltext = "";
            if (dt.Rows[i]["ShowCol"].ToString().Trim() != "")
            {
                coltext = dt.Rows[i]["ShowCol"].ToString();
            }
            else
            {
                coltext = dt.Rows[i]["COLUMN_Text"].ToString();
            }
            if (dt.Rows[i]["IsInput"].ToString() == "*")
            {
                coltext = "<label id='lbltitle_" + dt.Rows[i]["COLUMN_NAME"].ToString() + "'>" + coltext + "</label><label id='lblisinput_" + dt.Rows[i]["COLUMN_NAME"].ToString() + "'>*</label>";
            }
            else
            {
                coltext = "<label id='lbltitle_" + dt.Rows[i]["COLUMN_NAME"].ToString() + "'>" + coltext + "</label>";
            }
            HtmlTableCell tclabel = new HtmlTableCell();
            tclabel.Style.Add("font-weight", "bold");
            tclabel.InnerHtml = coltext;
            HtmlTableCell tc = new HtmlTableCell();
            string value = "";
            if (dts!=null && dts.Rows.Count > 0)
            {
                value = dts.Rows[0][dt.Rows[i]["COLUMN_NAME"].ToString()].ToString();
            }
            string col=dt.Rows[i]["COLUMN_NAME"].ToString();
            switch (dt.Rows[i]["UpdateType"].ToString())
            {
                case "textbox":

                    TextBox input = new TextBox();
                    input.ID = "text" + dt.Rows[i]["COLUMN_NAME"].ToString();
                    input.CssClass = "form-control";
                    if (b)
                    {
                        input.Text = value;
                    }
                    tc.Controls.Add(input);
                    if (col == bCol && bRed == true)
                    {
                        input.ReadOnly = true;
                    }
                    break;
                case "label":
                    Label label = new Label();
                    label.ID = "label" + dt.Rows[i]["COLUMN_NAME"].ToString();
                    if (b)
                    {
                        label.Text = value;
                    }
                    label.CssClass = "form-control";
                    tc.Controls.Add(label);
                    break;
                case "select":
                    DropDownList ddl = new DropDownList();
                    ddl.CssClass = "form-control";
                    ddl.ID = "ddl" + dt.Rows[i]["COLUMN_NAME"].ToString();
                    switch (dt.Rows[i]["ColSel"].ToString().Trim())
                    {
                        case "LookUpData":
                            ddl.DataSource = pd.GetLookUpData(dt.Rows[i]["ColSelFlag"].ToString());
                            ddl.DataValueField = "iID";
                            ddl.DataTextField = "iText";
                            ddl.DataBind();
                            break;
                        case "Equip":
                            ddl.DataSource = pd.GetEquip();
                            ddl.DataValueField = "iID";
                            ddl.DataTextField = "iText";
                            ddl.DataBind();
                            break;
                        case "EquipType":
                            ddl.DataSource = pd.GetEquipType();
                            ddl.DataValueField = "iID";
                            ddl.DataTextField = "iText";
                            ddl.DataBind();
                            break;
                        case "Inventory":
                            ddl.DataSource = pd.GetInventory();
                            ddl.DataValueField = "iID";
                            ddl.DataTextField = "iText";
                            ddl.DataBind();
                            break;
                        case "Machine":
                            ddl.DataSource = pd.GetMachine();
                            ddl.DataValueField = "iID";
                            ddl.DataTextField = "iText";
                            ddl.DataBind();
                            break;
                        case "Worker":
                            ddl.DataSource = pd.GetWorker(dt.Rows[i]["ColSelFlag"].ToString());
                            ddl.DataValueField = "iID";
                            ddl.DataTextField = "iText";
                            ddl.DataBind();
                            break;
                        case "LookUpType":
                            ddl.DataSource = pd.GetLookUpType();
                            ddl.DataValueField = "iID";
                            ddl.DataTextField = "iText";
                            ddl.DataBind();
                            break;
                    }
                    
                    if (b)
                    {
                        cc.Select(ddl, value);
                    }
                    if (col == bCol && bRed == true)
                    {
                       
                    }
                    tc.Controls.Add(ddl);
                    break;
                case "date":
                    UserControl userControl = (UserControl)LoadControl("_Controls/_Calendar.ascx");
                    userControl.ID = "Date" + dt.Rows[i]["COLUMN_NAME"].ToString();
                    TextBox text = ((TextBox)userControl.FindControl("datetimepicker"));
                    if (b)
                    {
                        if (value != "")
                        {
                            value = DateTime.Parse(value).ToString("yyyy-MM-dd");
                        }
                        text.Text = value;
                    }
                    tc.Controls.Add(userControl);
                    break;
            }
            tw.Cells.Add(tclabel);
            tw.Cells.Add(tc);
            TableUpdate1.Controls.Add(tw);
        }
        
    }
    public class ColumnTemplate : ITemplate
    {
        private DataControlRowType dcrType;
        private string columnName;
        private DataType.ControlsType datatype;
        private string controlname;
        private string hidid;
        private string spath;
        private string spathid;
        private string sidtitle;
        private string sidid;
        public ColumnTemplate(string colname)
        {
            columnName = colname;
            controlname = colname + "1";
        }
        public void InstantiateIn(System.Web.UI.Control container)
        {
            Label lbl = new Label();
            lbl.ID = controlname;
            lbl.DataBinding += new EventHandler(AddLabel);
            if (controlname != "")
            {
                lbl.ID = controlname;
            }
            container.Controls.Add(lbl);
        }
        private void AddLabel(object sender, EventArgs e)
        {
            Label l = (Label)sender;
            RepeaterItem row = (RepeaterItem)l.NamingContainer;
            l.Text ="11111111111"+ DataBinder.Eval(row.DataItem, columnName).ToString();

        }

    }

    
    #endregion


    public bool ParameterIsNull(object e)
    {
        if (e == null || e.ToString().Trim() == "" || e.ToString().Trim() == "0001/1/1 0:00:00")
        {
            return true;
        }
        return false;
    }
}