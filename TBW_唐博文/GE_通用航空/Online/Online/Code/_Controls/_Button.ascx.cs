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
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class FormatButton : System.Web.UI.UserControl
{
   
    string sSQL = "";
    ClsDataBase clsSQLCommond = new ClsDataBase();
    #region button
    public event System.EventHandler ToSelect;
    public event System.EventHandler ToNew;
    public event System.EventHandler ToDel;
    public event System.EventHandler ToSave;
    public event System.EventHandler ToBeck;
    public event System.EventHandler ToExport;
    public event System.EventHandler ToEdit;

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

    public void BtnToEdit(Object Sender, EventArgs e)
    {
        if (ToEdit != null)
        {
            ToEdit(this, new EventArgs());
        }
    }

    public void BtnToSave(Object Sender, EventArgs e)
    {
        if (ToSave != null)
        {
            ToSave(this, new EventArgs());
        }
    }

    protected void BtnToBack(object sender, EventArgs e)
    {
        if (ToBeck != null)
        {
            ToBeck(this, new EventArgs());
        }
    }

    protected void BtnToExport(object sender, EventArgs e)
    {
        if (ToExport != null)
        {
            ToExport(this, new EventArgs());
        }
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

    public Button BtnBack
    {
        set { lbToBack = value; }
        get { return lbToBack; }
    }

    public Button BtnNew
    {
        set { lbToNew = value; }
        get { return lbToNew; }
    }

    public Button BtnEdit
    {
        set { lbToEdit = value; }
        get { return lbToEdit; }
    }

    public Button BtnSave
    {
        set { lbToSave = value; }
        get { return lbToSave; }
    }

    public Button BtnExport
    {
        set { lbToExport = value; }
        get { return lbToExport; }
    }

    #endregion

    #region Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { 
            Session["url"] = GetUrl(2);
            Session["backurl"] = GetUrl(2);
            
            //string sql = "select RightName from EmployeeRight where Path='" + GetUrl(2) + "'";
            //lblTitle.Text = clsSQLCommond.String(sql);
            
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
            PublicClass pc = new PublicClass();
            //string ltext = pc.GetLanguageLookUp();
            //sSQL = "select * from _LookUpDate where iType=4";
            //DataTable dtlookup = clsSQLCommond.ExecQuery(sSQL);
            //DropDownList1.DataSource = dtlookup;
            //DropDownList1.DataValueField = "iID";
            //DropDownList1.DataTextField = ltext;
            //DropDownList1.DataBind();

            //sSQL = "select vlanguage from _UserInfo where vchrUid='" + HttpContext.Current.Session["uID"].ToString() + "'";
            //string vlanguage = clsSQLCommond.String(sSQL);
            //if (vlanguage == "" || vlanguage == "1")
            //{
            //    DropDownList1.Items[0].Selected = true;
            //}
            //else
            //{
            //    DropDownList1.Items[1].Selected = true;
            //}
            string ftext = pc.GetLanguageForm();
            sSQL = "select * from  _Form where fchrFrmNameID='"+hidformID.Value.Trim()+"'";
            DataTable dttitle = clsSQLCommond.ExecQuery(sSQL);
            if (dttitle.Rows.Count > 0)
            {
                lblTitle.Text = dttitle.Rows[0][ftext].ToString();
            }

            GetRoleShow();
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
                    TextBox tmpYxCalendar = (TextBox)p.Controls[i].FindControl("datetimepicker");
                    Session[leftname + id + "cal"] = tmpYxCalendar.Text;
                    break;
                case "_controls__calendarstartend_ascx":
                    TextBox tmpYxCalendarStart = (TextBox)p.Controls[i].FindControl("datetimepicker1");
                    Session[leftname + id + "datetimepicker1"] = tmpYxCalendarStart.Text;
                    TextBox tmpYxCalendarEnd = (TextBox)p.Controls[i].FindControl("datetimepicker2");
                    Session[leftname + id + "datetimepicker2"] = tmpYxCalendarEnd.Text;
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
                case "DropDownList":
                    DropDownList tmpDropDownList = (DropDownList)p.Controls[i];
                    if (Session[leftname + id] != null)
                    {
                        ControlsClass cc = new ControlsClass();
                        cc.Select(tmpDropDownList, Session[leftname + id].ToString());
                    }
                    break;
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
                    HtmlInputText tmpYxCalendar = (HtmlInputText)p.Controls[i].FindControl("datetimepicker");
                    if (Session[leftname + id + "datetimepicker"] != null)
                    {
                        tmpYxCalendar.Value = Session[leftname + id + "datetimepicker"].ToString();
                    }
                    break;
                case "_controls__calendarstartend_ascx":
                    TextBox tmpYxCalendarStart = (TextBox)p.Controls[i].FindControl("datetimepicker1");
                    if (Session[leftname + id + "datetimepicker1"] != null)
                    {
                        tmpYxCalendarStart.Text = Session[leftname + id + "datetimepicker1"].ToString();
                    }
                    TextBox tmpYxCalendarEnd = (TextBox)p.Controls[i].FindControl("datetimepicker2");
                    if (Session[leftname + id + "datetimepicker2"] != null)
                    {
                        tmpYxCalendarEnd.Text = Session[leftname + id + "datetimepicker2"].ToString();
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
    #endregion

    public string Title
    {
        set { lblTitle.Text = value; Page.Title = value; }
        get { return lblTitle.Text; }
    }

    public string HidID
    {
        set { hidID.Value = value; }
        get { return hidID.Value; }
    }

    public string HidFormID
    {
        set { hidformID.Value = value; }
        get { return hidformID.Value; }
    }

    //protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    sSQL = "update  _UserInfo set vlanguage='" + DropDownList1.SelectedValue + "' where  vchrUid='" + Session["uID"].ToString() + "'";
    //    clsSQLCommond.Update(sSQL);
    //}

    #region role

    bool _boolSelect = true;
    bool _boolNew = true;
    bool _boolEdit = true;
    bool _boolDel = true;
    bool _boolSave = true;
    bool _boolBack = true;
    bool _boolExport = true;

    public bool boolSelect
    {
        set { _boolSelect = value; }
        get { return _boolSelect; }
    }

    public bool boolNew
    {
        set { _boolNew = value; }
        get { return _boolNew; }
    }

    public bool boolEdit
    {
        set { _boolEdit = value; }
        get { return _boolEdit; }
    }

    public bool boolDel
    {
        set { _boolDel = value; }
        get { return _boolDel; }
    }

    public bool boolSave
    {
        set { _boolSave = value; }
        get { return _boolSave; }
    }

    public bool boolBack
    {
        set { _boolBack = value; }
        get { return _boolBack; }
    }

    public bool boolExport
    {
        set { _boolExport = value; }
        get { return _boolExport; }
    }

    public void GetRoleShow()
    {
        bool isadmin = false;
        if (Session["uID"].ToString() == "admin")
        {
            isadmin = true;
        }
        else
        {
            sSQL = "select * from _UserRoleInfo where vchrUserID='" + Session["uID"].ToString() + "' and vchrRoleID='administrator'";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt.Rows.Count > 0)
            {
                isadmin = true;
            }
        }

        lbToNew.Visible = false;
        lbToDel.Visible = false;
        lbToSelect.Visible = false;
        lbToBack.Visible = false;
        lbToSave.Visible = false;
        lbToExport.Visible = false;

        string uid = Session["uID"].ToString();

        sSQL = @"select distinct vchrUserID, _UserRoleInfo.vchrRoleID,SUBSTRING(vchrRoleRight,
" + (hidformID.Value.Trim().Length + 2) + ",len(vchrRoleRight)) as vchrRoleRight from    _UserRoleInfo left join _RoleRight on _UserRoleInfo.vchrRoleID=_RoleRight.vchrRoleID   where vchrUserID='"+uid+"' and LEFT(vchrRoleRight," + hidformID.Value.Trim().Length + ")='" + hidformID.Value.Trim() + "'";

        DataTable dtrole = clsSQLCommond.ExecQuery(sSQL);

        PublicClass pc = new PublicClass();
        string btext = pc.GetLanguageBtn();
        sSQL = "select * from _FormBtnInfo left join _BtnBaseInfo on vchrBtnID=btnCode where fchrFrmNameID='" + hidformID.Value.Trim() + "'";
        DataTable dtbtn = clsSQLCommond.ExecQuery(sSQL);
        if (dtbtn.Rows.Count > 0)
        {
            for (int i = 0; i < dtbtn.Rows.Count; i++)
            {
                switch (dtbtn.Rows[i]["vchrBtnID"].ToString())
                {
                    case "add":
                        if ((isadmin == true || dtrole.Select("vchrRoleRight='add'").Length > 0) && _boolNew == true)
                        {
                            lbToNew.Visible = true;
                            lbToNew.Text = dtbtn.Rows[i][btext].ToString();
                        }
                        break;
                    case "edit":
                        if ((isadmin == true || dtrole.Select("vchrRoleRight='edit'").Length > 0) && _boolEdit == true)
                        {
                            lbToEdit.Visible = true;
                            lbToEdit.Text = dtbtn.Rows[i][btext].ToString();
                        }
                        break;
                    case "del":
                        if ((isadmin == true || dtrole.Select("vchrRoleRight='del'").Length > 0) && _boolDel == true)
                        {
                            lbToDel.Visible = true;
                            lbToDel.Text = dtbtn.Rows[i][btext].ToString();
                        }
                        break;
                    case "sel":
                        if ((isadmin == true || dtrole.Select("vchrRoleRight='sel'").Length > 0) && _boolSelect == true)
                        {
                            lbToSelect.Visible = true;
                            lbToSelect.Text = dtbtn.Rows[i][btext].ToString();
                        }
                        break;
                    case "back":
                        if ((isadmin == true || dtrole.Select("vchrRoleRight='back'").Length > 0) && _boolBack == true)
                        {
                            lbToBack.Visible = true;
                            lbToBack.Text = dtbtn.Rows[i][btext].ToString();
                        }
                        break;
                    case "save":
                        if ((isadmin == true || dtrole.Select("vchrRoleRight='save'").Length > 0) && _boolSave == true)
                        {
                            lbToSave.Visible = true;
                            lbToSave.Text = dtbtn.Rows[i][btext].ToString();
                        }
                        break;
                    case "export":
                        if ((isadmin == true || dtrole.Select("vchrRoleRight='export'").Length > 0) && _boolExport == true)
                        {
                            lbToExport.Visible = true;
                            lbToExport.Text = dtbtn.Rows[i][btext].ToString();
                        }
                        break;
                }
            }
        }
    }

    #endregion
}
