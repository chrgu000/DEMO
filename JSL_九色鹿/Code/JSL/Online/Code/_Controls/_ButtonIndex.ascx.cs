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
using System.Text;

public partial class YxButtonIndex : System.Web.UI.UserControl
{
    public event System.EventHandler ToSelect;
    public event System.EventHandler ToNew;
    public event System.EventHandler ToDel;

    public void BtnToSelect(Object Sender, EventArgs e)
    {
        if (ToSelect != null)
        {
            ToSelect(this, new EventArgs());
        }
    }

    public void BtnToDel(Object Sender, EventArgs e)
    {
        if (ToDel != null)
        {
            ToDel(this, new EventArgs());
        }
    }

    public void BtnToNew(Object Sender, EventArgs e)
    {
        if (ToNew != null)
        {
            ToNew(this, new EventArgs());
        }
    }

    public event System.EventHandler ToBeck;
    protected void BtnToBack(object sender, EventArgs e)
    {
        if (ToBeck == null)
        {
            Response.Redirect("../Frame/Index.aspx");
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["url"] = GetUrl(2);
            Session["backurl"] = GetUrl(2);
            if (Session["uID"].ToString() == "")
            {
                StringBuilder str = new StringBuilder();
                str.Append("<script language=javascript>location.href('../ErrorPage.aspx');</script>");
                System.Web.HttpContext.Current.Response.Write(str.ToString());
            }
            //string sql = "select RightName from EmployeeRight where Path='" + GetUrl(2) + "'";
            //lblTitle.Text = Conn.String(sql);
            
            //if (Request.UrlReferrer != null)
            //{
            //    string requestPage = (Request.UrlReferrer.Segments)[Request.UrlReferrer.Segments.Length - 1];
            //    //if (requestPage != "Left.aspx")
            //    //{
            //        geturl();
            //    //}
            //}
            //else
            //{
            //    geturl();
            //}
        }
    }

    private void geturl()
    {
        StringBuilder str = new StringBuilder();
        str.Append("<script language=javascript>location.href('../ErrorPage.aspx');</script>");
        System.Web.HttpContext.Current.Response.Write(str.ToString());
    }

    public bool IsFirstLoad()
    {
        if (Session[GetUrl(1) + "url"].ToString() != "" && Session[GetUrl(1) + "url"].ToString() != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private string GetUrl(int i)
    {
        string leftname = Request.Url.AbsoluteUri;
        if (i == 1)//得到页面路径为文件夹名称_文件名
        {
            leftname = leftname.Replace(".", "/");
            leftname = leftname.Split('/')[leftname.Split('/').Length - 3] + "_" + leftname.Split('/')[leftname.Split('/').Length - 2] + "_";
        }
        else if (i == 2)//得到页面路径文件夹名称_文件名.附件名
        {
            leftname = "../" + leftname.Split('/')[leftname.Split('/').Length - 2] + "/" + leftname.Split('/')[leftname.Split('/').Length - 1];
        }
        return leftname;
    }

    public void SetViewState(Panel p)
    {
        //DataTable dt = GetWebSession();
        string leftname = GetUrl(1);
        Session[leftname + "url"] = leftname;//是否已经进入过该页面
        for (int i = 0; i < p.Controls.Count; i++)
        {
            string id = p.Controls[i].ClientID;
            string type = p.Controls[i].GetType().Name;
            switch (type)
            {
                case "TextBox":
                    TextBox tmpTextBox = (TextBox)p.Controls[i];
                    Session[leftname + id] = tmpTextBox.Text;
                    break;
                case "HtmlInputHidden":
                    HtmlInputHidden tmpHtmlInputHidden = (HtmlInputHidden)p.Controls[i];
                    Session[leftname + id] = tmpHtmlInputHidden.Value;
                    break;
                case "DropDownList":
                    DropDownList tmpDropDownList = (DropDownList)p.Controls[i];
                    Session[leftname + id] = tmpDropDownList.SelectedValue;
                    break;
                case "CheckBox":
                    CheckBox tmpCheckBox = (CheckBox)p.Controls[i];
                    Session[leftname + id] = tmpCheckBox.Checked.ToString();
                    break;
                case "HtmlInputCheckBox":
                    HtmlInputCheckBox tmpHtmlInputCheckBox = (HtmlInputCheckBox)p.Controls[i];
                    Session[leftname + id] = tmpHtmlInputCheckBox.Checked.ToString();
                    break;
                case "HtmlInputText":
                    HtmlInputText tmpHtmlInputText = (HtmlInputText)p.Controls[i];
                    Session[leftname + id] = tmpHtmlInputText.Value;
                    break;
                case "_controls__calendar_ascx":
                    HtmlInputText tmpYxCalendar = (HtmlInputText)p.Controls[i].FindControl("cal");
                    Session[leftname + id + "cal"] = tmpYxCalendar.Value;
                    break;
                case "_controls__calendarstartend_ascx":
                    HtmlInputText tmpYxCalendarStart = (HtmlInputText)p.Controls[i].FindControl("cals");
                    Session[leftname + id + "cals"] = tmpYxCalendarStart.Value;
                    HtmlInputText tmpYxCalendarEnd = (HtmlInputText)p.Controls[i].FindControl("cale");
                    Session[leftname + id + "cale"] = tmpYxCalendarEnd.Value;
                    break;
                case "_controls__employeeselect_ascx":
                    HtmlInputText tmpYxEmployeeSelectPID = (HtmlInputText)p.Controls[i].FindControl("txtPeople");
                    Session[leftname + id + "txtPeople"] = tmpYxEmployeeSelectPID.Value;
                    HiddenField tmpYxEmployeeSelectPName = (HiddenField)p.Controls[i].FindControl("txtPeopleHid");
                    Session[leftname + id + "txtPeopleHid"] = tmpYxEmployeeSelectPName.Value;
                    break;
                case "_controls__vendorselect_ascx":
                    HtmlInputHidden tmpYxVendorID = (HtmlInputHidden)p.Controls[i].FindControl("hid");
                    Session[leftname + id + "id"] = tmpYxVendorID.Value;
                    HtmlInputText tmpYxVendorName = (HtmlInputText)p.Controls[i].FindControl("txt");
                    Session[leftname + id + "name"] = tmpYxVendorName.Value;
                    break;
                case "_controls__materialselect_ascx":
                    HtmlInputText tmpYxMaterial = (HtmlInputText)p.Controls[i].FindControl("txtM");
                    Session[leftname + id + "txtM"] = tmpYxMaterial.Value;
                    break;
            }
        }
    }

    public void GetViewState(Panel p)
    {
        string leftname = Request.Url.AbsoluteUri.ToString().Replace(".", "/");
        leftname = leftname.Split('/')[leftname.Split('/').Length - 3] + "_" + leftname.Split('/')[leftname.Split('/').Length - 2] + "_";
        for (int i = 0; i < p.Controls.Count; i++)
        {
            string id = p.Controls[i].ClientID;
            string type = p.Controls[i].GetType().Name;

            switch (type)
            {
                case "TextBox":
                    TextBox tmpTextBox = (TextBox)p.Controls[i];
                    if (Session[leftname + id] != null)
                    {
                        tmpTextBox.Text = Session[leftname + id].ToString();
                    }
                    break;
                case "HtmlInputHidden":
                    HtmlInputHidden tmpHtmlInputHidden = (HtmlInputHidden)p.Controls[i];
                    if (Session[leftname + id] != null)
                    {
                        tmpHtmlInputHidden.Value = Session[leftname + id].ToString();
                    }
                    break;
                //case "DropDownList":
                //    DropDownList tmpDropDownList = (DropDownList)p.Controls[i];
                //    if (Session[leftname + id] != null)
                //    {
                //        ControlsClass cc = new ControlsClass();
                //        cc.Select(tmpDropDownList, Session[leftname + id].ToString());
                //    }
                //    break;
                case "CheckBox":
                    CheckBox tmpCheck = (CheckBox)p.Controls[i];
                    if (Session[leftname + id] != null)
                    {
                        tmpCheck.Checked = bool.Parse(Session[leftname + id].ToString());
                    }
                    break;
                case "HtmlInputCheckBox":
                    HtmlInputCheckBox tmpHtmlInputCheckBox = (HtmlInputCheckBox)p.Controls[i];
                    if (Session[leftname + id] != null)
                    {
                        if (Session[leftname + id].ToString() == "True")
                        {
                            tmpHtmlInputCheckBox.Checked = true;
                        }
                        else
                        {
                            tmpHtmlInputCheckBox.Checked = false;
                        }
                    }
                    break;
                case "HtmlInputText":
                    HtmlInputText tmpHtmlInputText = (HtmlInputText)p.Controls[i];
                    if (Session[leftname + id] != null)
                    {
                        tmpHtmlInputText.Value = Session[leftname + id].ToString();
                    }
                    break;
                case "_controls__calendar_ascx":
                    HtmlInputText tmpYxCalendar = (HtmlInputText)p.Controls[i].FindControl("cal");
                    if (Session[leftname + id + "cal"] != null)
                    {
                        tmpYxCalendar.Value = Session[leftname + id + "cal"].ToString();
                    }
                    break;
                case "_controls__calendarstartend_ascx":
                    HtmlInputText tmpYxCalendarStart = (HtmlInputText)p.Controls[i].FindControl("cals");
                    if (Session[leftname + id + "cals"] != null)
                    {
                        tmpYxCalendarStart.Value = Session[leftname + id + "cals"].ToString();
                    }
                    HtmlInputText tmpYxCalendarEnd = (HtmlInputText)p.Controls[i].FindControl("cale");
                    if (Session[leftname + id + "cale"] != null)
                    {
                        tmpYxCalendarEnd.Value = Session[leftname + id + "cale"].ToString();
                    }
                    break;
                case "_controls__employeeselect_ascx":
                    HtmlInputText tmpYxEmployeeSelectPID = (HtmlInputText)p.Controls[i].FindControl("txtPeople");
                    if (Session[leftname + id + "txtPeople"] != null)
                    {
                        tmpYxEmployeeSelectPID.Value = Session[leftname + id + "txtPeople"].ToString();
                    }
                    HiddenField tmpYxEmployeeSelectPName = (HiddenField)p.Controls[i].FindControl("txtPeopleHid");
                    if (Session[leftname + id + "txtPeople"] != null)
                    {
                        tmpYxEmployeeSelectPName.Value = Session[leftname + id + "txtPeopleHid"].ToString();
                    }
                    break;
                case "_controls__vendorselect_ascx":
                    HtmlInputHidden tmpYxVendorID = (HtmlInputHidden)p.Controls[i].FindControl("hid");
                    if (Session[leftname + id + "id"] != null)
                    {
                        tmpYxVendorID.Value = Session[leftname + id + "id"].ToString();
                    }
                    HtmlInputText tmpYxVendorName = (HtmlInputText)p.Controls[i].FindControl("txt");
                    if (Session[leftname + id + "name"] != null)
                    {
                        tmpYxVendorName.Value = Session[leftname + id + "name"].ToString();
                    }
                    break;
                case "_controls__materialselect_ascx":
                    HtmlInputText tmpYxMaterial = (HtmlInputText)p.Controls[i].FindControl("txtM");
                    if (Session[leftname + id + "txtM"] != null)
                    {
                        tmpYxMaterial.Value = Session[leftname + id + "txtM"].ToString();
                    }
                    break;
            }

        }
    }

    //public DataTable GetWebSession()
    //{
    //    string sql = "select * from _WebSession where UserID='"+Session["uID"].ToString()+"'";
    //    return Conn.DataTable(sql);
    //}

    public string Title
    {
        set { lblTitle.Text = value; Page.Title = value; }
        get { return lblTitle.Text; }
    }

    public Button BtnSelect
    {
        set { lbToSelect = value; }
        get { return lbToSelect; }
    }

    public Button BtnDel
    {
        set { lbToDel = value; }
        get { return lbToDel; }
    }

    public Button BtnNew
    {
        set { lbToNew = value; }
        get { return lbToNew; }
    }

    public string HidPageID
    {
        set { hidPageID.Value = value; }
        get { return hidPageID.Value; }
    }
}
