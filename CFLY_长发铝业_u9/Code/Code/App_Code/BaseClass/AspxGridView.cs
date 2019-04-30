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
using DevExpress.Web.ASPxGridView;

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
    public void GetList(HtmlGenericControl thead1, HtmlGenericControl con1, string tablename, DataTable dts,int type)
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
        if (tablename == "Inventory")
        {
            h = h + "<th>库存</th>";
        }
        if (type == 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string ColLink = dt.Rows[i]["ColLink"].ToString();
                if (ColLink != "")
                {
                    string[] spl = ColLink.Split('/');
                    for (int j = 0; j < spl.Length; j++)
                    {
                        h = h + "<th></th>";
                    }
                }
            }
        }
       
        h = h + "</tr>";
 
        Literal hc = new Literal();
        hc.Text=h;
        thead1.Controls.Add(hc);
        string l = "";
        
        for (int i = 0; i < dts.Rows.Count; i++)
        {
            string linkl = "";
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
                                case "date2":
                                    if (value != "")
                                    {
                                        value = DateTime.Parse(value).ToString("yyyy-MM-dd HH:mm");
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
                            l = l + "<td>" + value + "</td>";
                            break;
                        default:
                            l = l + "<td>" + value + "</td>";
                            break;
                    }
                   
            }
            if (tablename == "Inventory")
            {
                l = l + "<td>" + dts.Rows[i]["库存"].ToString() + "</td>";
            }
            if (type == 0)
            {
                for (int p = 0; p < dt.Rows.Count; p++)
                {
                    string ColLink = dt.Rows[p]["ColLink"].ToString();
                    string ColLinkID = dt.Rows[p]["ColLinkID"].ToString();
                    string ColLinkText = dt.Rows[p]["ColLinkText"].ToString();
                    if (ColLink != "")
                    {
                        string[] spl = ColLink.Split('/');
                        string[] splid = ColLinkID.Split('/');
                        string[] spltext = ColLinkText.Split('/');

                        for (int q = 0; q < spl.Length; q++)
                        {

                            linkl = linkl + "<td><a  href='";
                            string[] spls = spl[q].Split(',');
                            string[] splids = splid[q].Split(',');
                            for (int w = 0; w < spls.Length; w++)
                            {
                                if (w != 0)
                                {
                                    linkl = linkl + "&";
                                }
                                linkl = linkl + spls[w] + "=" + dts.Rows[i][splids[w]].ToString();
                            }
                            linkl = linkl + "'>" + spltext[q] + "</a></td>";
                        }
                    }
                }
            }


            
            l = l + linkl + "</tr>";
        }

        Literal lc = new Literal();
        lc.Text = l;
        con1.Controls.Add(lc);
    }

    private string GetLen(string str, int maxlen)
    {
        if (str.Length < maxlen)
        {
            int s = maxlen - str.Length;
            for (int i = 1; i <= s; i++)
            {
                str = "0" + str;
            }
        }
        return str;
    }

    public void GetUpdate(HtmlTable TableUpdate1, string tablename, DataTable dts,string bCol,bool bRed,bool bNew)
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
            if (Session["uID"].ToString() == "游客" && tablename == "CW" && (dt.Rows[i]["COLUMN_NAME"].ToString() == "Date2" || dt.Rows[i]["COLUMN_NAME"].ToString() == "Date3" || dt.Rows[i]["COLUMN_NAME"].ToString() == "S6"))
            {
                continue;
            }
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
                case "date2":

                    UserControl userControl2 = (UserControl)LoadControl("_Controls/_Calendar2.ascx");
                    userControl2.ID = "Date" + dt.Rows[i]["COLUMN_NAME"].ToString();
                    TextBox text2 = ((TextBox)userControl2.FindControl("datetimepicker"));
                    if (b)
                    {
                        if (value != "")
                        {
                            value = DateTime.Parse(value).ToString();
                            text2.Text = DateTime.Parse(value).ToString("yyyy-MM-dd");
                        }

                    }
                    DropDownList ddld1 = ((DropDownList)userControl2.FindControl("ddlH"));

                    if (value != "")
                    {
                        string valueh = DateTime.Parse(value).ToString("HH");
                        if (ddld1.Items.Count == 0)
                        {
                            for (int s = 0; s < 24; s++)
                            {
                                string str = "";
                                if (s.ToString().Length < 2)
                                {
                                    str = "0" + s.ToString();
                                }
                                else
                                {
                                    str = s.ToString();
                                }
                                ListItem it = new ListItem();
                                it.Text = str;
                                it.Value = str;
                                ddld1.Items.Add(it);
                            }
                        }
                        for (int j = 0; j < ddld1.Items.Count; j++)
                        {
                            if (ddld1.Items[j].Value == valueh)
                            {
                                ddld1.Items[j].Selected = true;
                            }
                        }

                        DropDownList ddld2 = ((DropDownList)userControl2.FindControl("ddlM"));
                        string valuem = DateTime.Parse(value).ToString("mm");
                        if (ddld2.Items.Count == 0)
                        {
                            for (int s = 0; s < 60; s++)
                            {
                                string str = "";
                                if (s.ToString().Length < 2)
                                {
                                    str = "0" + s.ToString();
                                }
                                else
                                {
                                    str = s.ToString();
                                }
                                ListItem it = new ListItem();
                                it.Text = str;
                                it.Value = str;
                                ddld2.Items.Add(it);
                            }
                        }
                        for (int j = 0; j < ddld2.Items.Count; j++)
                        {
                            if (ddld2.Items[j].Value == valuem)
                            {
                                ddld2.Items[j].Selected = true;
                            }
                        }
                    }
                    tc.Controls.Add(userControl2);

                    break;
            }
            tw.Cells.Add(tclabel);
            tw.Cells.Add(tc);
            TableUpdate1.Controls.Add(tw);
        }
        
    }


    public DataTable GetExport(string tablename, DataTable dts)
    {
        sSQL = "select * from  _TableColInfo where  TABLE_NAME in ('" + tablename + "') and (COLUMN_Text<>'' or ShowCol<>'') order by VisibleIndex";
        DataTable dt = clsSQLCommond.ExecQuery(sSQL);
        DataTable dtnew = new DataTable();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (dt.Rows[i]["COLUMN_NAME"].ToString().IndexOf("Date") > -1)
            {
                dtnew.Columns.Add(dt.Rows[i]["COLUMN_NAME"].ToString(),typeof(DateTime));
            }
            else if (dt.Rows[i]["COLUMN_NAME"].ToString().IndexOf("D") > -1)
            {
                dtnew.Columns.Add(dt.Rows[i]["COLUMN_NAME"].ToString(), typeof(decimal));
            }
            else
            {
                dtnew.Columns.Add(dt.Rows[i]["COLUMN_NAME"].ToString());
            }
        }
        for (int i = 0; i < dts.Rows.Count; i++)
        {
            DataRow dw = dtnew.NewRow();
            for (int j = 0; j < dtnew.Columns.Count; j++)
            {
                dw[dtnew.Columns[j].ColumnName] = dts.Rows[i][dtnew.Columns[j].ColumnName];
            }
            dtnew.Rows.Add(dw);
        }
        for (int i = 0; i < dtnew.Columns.Count; i++)
        {
            dtnew.Columns[i].ColumnName = dt.Select("COLUMN_NAME='" + dtnew.Columns[i].ColumnName + "'")[0]["COLUMN_Text"].ToString();
        }
        return dtnew;
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


    #region 生成标题
    public void GetTitle(ASPxGridView ASPxGridView1, string tablename)
    {
        PublicClass pc = new PublicClass();
        string ctext = pc.GetLanguageColumn();

        sSQL = "select * from  _TableColInfo where  TABLE_NAME in ('" + tablename + "')";
        DataTable dt = clsSQLCommond.ExecQuery(sSQL);

        for (int j = 0; j < ASPxGridView1.Columns.Count; j++)
        {
            if (ASPxGridView1.Columns[j].GetType().UnderlyingSystemType.FullName == "DevExpress.Web.ASPxGridView.GridViewDataTextColumn")
            {
                DevExpress.Web.ASPxGridView.GridViewDataTextColumn datacolumn = (DevExpress.Web.ASPxGridView.GridViewDataTextColumn)ASPxGridView1.Columns[j];
                string field = datacolumn.FieldName;
                DataRow[] dw = dt.Select("COLUMN_NAME='" + field + "'");
                if (dw.Length == 0)
                {

                }
                else if (dw.Length > 0 && dw[0][ctext].ToString() != "")
                {
                    string caption = dw[0][ctext].ToString();
                    datacolumn.Caption = caption;
                    if (dw[0]["VisibleIndex"].ToString() != "")
                    {
                        //datacolumn.VisibleIndex = int.Parse(dw[0]["VisibleIndex"].ToString());
                    }
                }
                else
                {
                    //datacolumn.Visible = false;
                }
            }
            else if (ASPxGridView1.Columns[j].GetType().UnderlyingSystemType.FullName == "DevExpress.Web.ASPxGridView.GridViewDataColumn")
            {
                DevExpress.Web.ASPxGridView.GridViewDataColumn datacolumn = (DevExpress.Web.ASPxGridView.GridViewDataColumn)ASPxGridView1.Columns[j];
                string field = datacolumn.FieldName;
                DataRow[] dw = dt.Select("COLUMN_NAME='" + field + "'");
                if (dw.Length == 0)
                {

                }
                else if (dw.Length > 0 && dw[0][ctext].ToString() != "")
                {
                    string caption = dw[0][ctext].ToString();
                    datacolumn.Caption = caption;
                    if (dw[0]["VisibleIndex"].ToString() != "")
                    {
                        //datacolumn.VisibleIndex = int.Parse(dw[0]["VisibleIndex"].ToString());
                    }
                }
                else
                {
                    //datacolumn.Visible = false;
                }
            }
            else if (ASPxGridView1.Columns[j].GetType().UnderlyingSystemType.FullName == "DevExpress.Web.ASPxGridView.GridViewDataDateColumn")
            {
                DevExpress.Web.ASPxGridView.GridViewDataDateColumn datacolumn = (DevExpress.Web.ASPxGridView.GridViewDataDateColumn)ASPxGridView1.Columns[j];
                string field = datacolumn.FieldName;
                DataRow[] dw = dt.Select("COLUMN_NAME='" + field + "'");
                if (dw.Length == 0)
                {

                }
                else if (dw.Length > 0 && dw[0][ctext].ToString() != "")
                {
                    string caption = dw[0][ctext].ToString();
                    datacolumn.Caption = caption;
                    if (dw[0]["VisibleIndex"].ToString() != "")
                    {
                        //datacolumn.VisibleIndex = int.Parse(dw[0]["VisibleIndex"].ToString());
                    }
                }
                else
                {
                    //datacolumn.Visible = false;
                }
            }
            else if (ASPxGridView1.Columns[j].GetType().UnderlyingSystemType.FullName == "DevExpress.Web.ASPxGridView.GridViewDataComboBoxColumn")
            {
                DevExpress.Web.ASPxGridView.GridViewDataComboBoxColumn datacolumn = (DevExpress.Web.ASPxGridView.GridViewDataComboBoxColumn)ASPxGridView1.Columns[j];
                string field = datacolumn.FieldName;
                DataRow[] dw = dt.Select("COLUMN_NAME='" + field + "'");
                if (dw.Length == 0)
                {

                }
                else if (dw.Length > 0 && dw[0][ctext].ToString() != "")
                {
                    string caption = dw[0][ctext].ToString();
                    datacolumn.Caption = caption;
                    if (dw[0]["VisibleIndex"].ToString() != "")
                    {
                        //datacolumn.VisibleIndex = int.Parse(dw[0]["VisibleIndex"].ToString());
                    }
                }
                else
                {
                    //datacolumn.Visible = false;
                }
            }
            else if (ASPxGridView1.Columns[j].GetType().UnderlyingSystemType.FullName == "DevExpress.Web.ASPxGridView.GridViewDataSpinEditColumn")
            {
                DevExpress.Web.ASPxGridView.GridViewDataSpinEditColumn datacolumn = (DevExpress.Web.ASPxGridView.GridViewDataSpinEditColumn)ASPxGridView1.Columns[j];
                string field = datacolumn.FieldName;
                DataRow[] dw = dt.Select("COLUMN_NAME='" + field + "'");
                if (dw.Length == 0)
                {

                }
                else if (dw.Length > 0 && dw[0][ctext].ToString() != "")
                {
                    string caption = dw[0][ctext].ToString();
                    datacolumn.Caption = caption;
                    if (dw[0]["VisibleIndex"].ToString() != "")
                    {
                        //datacolumn.VisibleIndex = int.Parse(dw[0]["VisibleIndex"].ToString());
                    }
                }
                else
                {
                    //datacolumn.Visible = false;
                }
            }
        }
    }
    #endregion
    public string GetFieldName(ASPxGridView ASPxGridView1, string fieldID)
    {
        for (int j = 1; j < ASPxGridView1.Columns.Count; j++)
        {
            if (ASPxGridView1.Columns[j].GetType().UnderlyingSystemType.FullName == "DevExpress.Web.ASPxGridView.GridViewDataTextColumn")
            {
                DevExpress.Web.ASPxGridView.GridViewDataTextColumn datacolumn = (DevExpress.Web.ASPxGridView.GridViewDataTextColumn)ASPxGridView1.Columns[j];
                string field = datacolumn.FieldName;
                if (field == fieldID)
                {
                    return datacolumn.Caption;
                }
            }
            else if (ASPxGridView1.Columns[j].GetType().UnderlyingSystemType.FullName == "DevExpress.Web.ASPxGridView.GridViewDataColumn")
            {
                DevExpress.Web.ASPxGridView.GridViewDataColumn datacolumn = (DevExpress.Web.ASPxGridView.GridViewDataColumn)ASPxGridView1.Columns[j];
                string field = datacolumn.FieldName;
                if (field == fieldID)
                {
                    return datacolumn.Caption;
                }
            }
            else if (ASPxGridView1.Columns[j].GetType().UnderlyingSystemType.FullName == "DevExpress.Web.ASPxGridView.GridViewDataComboBoxColumn")
            {
                DevExpress.Web.ASPxGridView.GridViewDataComboBoxColumn datacolumn = (DevExpress.Web.ASPxGridView.GridViewDataComboBoxColumn)ASPxGridView1.Columns[j];
                string field = datacolumn.FieldName;
                if (field == fieldID)
                {
                    return datacolumn.Caption;
                }
            }
            else if (ASPxGridView1.Columns[j].GetType().UnderlyingSystemType.FullName == "DevExpress.Web.ASPxGridView.GridViewDataDateColumn")
            {
                DevExpress.Web.ASPxGridView.GridViewDataDateColumn datacolumn = (DevExpress.Web.ASPxGridView.GridViewDataDateColumn)ASPxGridView1.Columns[j];
                string field = datacolumn.FieldName;
                if (field == fieldID)
                {
                    return datacolumn.Caption;
                }
            }
        }
        return "";
    }
}