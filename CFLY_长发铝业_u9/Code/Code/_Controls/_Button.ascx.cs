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

    #region Select
    public event System.EventHandler ToSelect;
    public void BtnToSelect(Object Sender, EventArgs e)
    {
        if (ToSelect != null)
        {
            ToSelect(this, new EventArgs());
        }
    }
    public void BtnToSelect_Click(Object Sender, EventArgs e)
    {
        if (ToSelect != null)
        {
            ToSelect(this, new EventArgs());
        }
    }
    public DevExpress.Web.ASPxEditors.ASPxButton BtnSelect
    {
        set { btnSelect = value; }
        get { return btnSelect; }
    }
    bool _boolSelect = true;
    public bool boolSelect
    {
        set { _boolSelect = value; }
        get { return _boolSelect; }
    }

    #endregion

    #region New
    public event System.EventHandler ToNew;
    public void BtnToNew(Object Sender, EventArgs e)
    {
        if (ToNew != null)
        {
            ToNew(this, new EventArgs());
        }
    }
    public void BtnToNew_Click(Object Sender, EventArgs e)
    {
        if (ToNew != null)
        {
            ToNew(this, new EventArgs());
        }
    }
    public DevExpress.Web.ASPxEditors.ASPxButton BtnNew
    {
        set { btnNew = value; }
        get { return btnNew; }
    }
    bool _boolNew = true;
    public bool boolNew
    {
        set { _boolNew = value; }
        get { return _boolNew; }
    }

    #endregion

    #region Audit
    public event System.EventHandler ToAudit;
    public void BtnToAudit(Object Sender, EventArgs e)
    {
        if (ToAudit != null)
        {
            ToAudit(this, new EventArgs());
        }
    }
    public void BtnToAudit_Click(Object Sender, EventArgs e)
    {
        if (ToAudit != null)
        {
            ToAudit(this, new EventArgs());
        }
    }
    public DevExpress.Web.ASPxEditors.ASPxButton BtnAudit
    {
        set { btnAudit = value; }
        get { return btnAudit; }
    }
    bool _boolAudit = true;
    public bool boolAudit
    {
        set { _boolAudit = value; }
        get { return _boolAudit; }
    }

    #endregion

    #region UnAudit
    public event System.EventHandler ToUnAudit;
    public void BtnToUnAudit(Object Sender, EventArgs e)
    {
        if (ToUnAudit != null)
        {
            ToUnAudit(this, new EventArgs());
        }
    }
    public void BtnToUnAudit_Click(Object Sender, EventArgs e)
    {
        if (ToUnAudit != null)
        {
            ToUnAudit(this, new EventArgs());
        }
    }
    public DevExpress.Web.ASPxEditors.ASPxButton BtnUnAudit
    {
        set { btnUnAudit = value; }
        get { return btnUnAudit; }
    }
    bool _boolUnAudit = true;
    public bool boolUnAudit
    {
        set { _boolUnAudit = value; }
        get { return _boolUnAudit; }
    }

    #endregion

    #region NewRow
    public event System.EventHandler ToNewRow;
    public void BtnToNewRow(Object Sender, EventArgs e)
    {
        if (ToNewRow != null)
        {
            ToNewRow(this, new EventArgs());
        }
    }
    public void BtnToNewRow_Click(Object Sender, EventArgs e)
    {
        if (ToNewRow != null)
        {
            ToNewRow(this, new EventArgs());
        }
    }
    public DevExpress.Web.ASPxEditors.ASPxButton BtnNewRow
    {
        set { btnNewRow = value; }
        get { return btnNewRow; }
    }
    bool _boolNewRow = true;
    public bool boolNewRow
    {
        set { _boolNewRow = value; }
        get { return _boolNewRow; }
    }

    #endregion

    #region Edit
    public event System.EventHandler ToEdit;
    public void BtnToEdit(Object Sender, EventArgs e)
    {
        if (ToEdit != null)
        {
            ToEdit(this, new EventArgs());
        }
    }
    public void BtnToEdit_Click(Object Sender, EventArgs e)
    {
        if (ToEdit != null)
        {
            ToEdit(this, new EventArgs());
        }
    }
    public DevExpress.Web.ASPxEditors.ASPxButton BtnEdit
    {
        set { btnEdit = value; }
        get { return btnEdit; }
    }
    bool _boolEdit = true;
    public bool boolEdit
    {
        set { _boolEdit = value; }
        get { return _boolEdit; }
    }

    #endregion

    #region Save
    public event System.EventHandler ToSave;
    public void BtnToSave(Object Sender, EventArgs e)
    {
        if (ToSave != null)
        {
            ToSave(this, new EventArgs());
        }
    }
    public void BtnToSave_Click(Object Sender, EventArgs e)
    {
        if (ToSave != null)
        {
            ToSave(this, new EventArgs());
        }
    }
    public DevExpress.Web.ASPxEditors.ASPxButton BtnSave
    {
        set { btnSave = value; }
        get { return btnSave; }
    }
    bool _boolSave = true;
    public bool boolSave
    {
        set { _boolSave = value; }
        get { return _boolSave; }
    }

    #endregion

    #region Export
    public event System.EventHandler ToExport;
    public void BtnToExport(Object Sender, EventArgs e)
    {
        if (ToExport != null)
        {
            ToExport(this, new EventArgs());
        }
    }
    public void BtnToExport_Click(Object Sender, EventArgs e)
    {
        if (ToExport != null)
        {
            ToExport(this, new EventArgs());
        }
    }
    public DevExpress.Web.ASPxEditors.ASPxButton BtnExport
    {
        set { btnExport = value; }
        get { return btnExport; }
    }
    bool _boolExport = true;
    public bool boolExport
    {
        set { _boolExport = value; }
        get { return _boolExport; }
    }

    #endregion

    #region Del
    public event System.EventHandler ToDel;
    public void BtnToDel(Object Sender, EventArgs e)
    {
        if (ToDel != null)
        {
            ToDel(this, new EventArgs());
        }
    }
    public void BtnToDel_Click(Object Sender, EventArgs e)
    {
        if (ToDel != null)
        {
            ToDel(this, new EventArgs());
        }
    }
    public DevExpress.Web.ASPxEditors.ASPxButton BtnDel
    {
        set { btnDel = value; }
        get { return btnDel; }
    }
    bool _boolDel = true;
    public bool boolDel
    {
        set { _boolDel = value; }
        get { return _boolDel; }
    }

    #endregion

    #region Back
    public event System.EventHandler ToBack;
    public void BtnToBack(Object Sender, EventArgs e)
    {
        if (ToBack != null)
        {
            ToBack(this, new EventArgs());
        }
    }
    public void BtnToBack_Click(Object Sender, EventArgs e)
    {
        if (ToBack != null)
        {
            ToBack(this, new EventArgs());
        }
    }
    public DevExpress.Web.ASPxEditors.ASPxButton BtnBack
    {
        set { btnBack = value; }
        get { return btnBack; }
    }
    bool _boolBack = true;
    public bool boolBack
    {
        set { _boolBack = value; }
        get { return _boolBack; }
    }

    #endregion

    #region Close
    public event System.EventHandler ToClose;
    public void BtnToClose_Click(Object Sender, EventArgs e)
    {
//        System.Web.HttpContext.Current.Response.Write(@"<script>
//var k = new Object();
//k.type = 'ok';
//window.returnValue = k;
//window.close();
//</script>"); 
        if (ToClose != null)
        {
            ToClose(this, new EventArgs());
        }
    }
    public DevExpress.Web.ASPxEditors.ASPxButton BtnClose
    {
        set { btnClose = value; }
        get { return btnClose; }
    }
    bool _boolClose = true;
    public bool boolClose
    {
        set { _boolClose = value; }
        get { return _boolClose; }
    }

    #endregion

    #region Open
    public event System.EventHandler ToOpen;
    public void BtnToOpen_Click(Object Sender, EventArgs e)
    {
//        System.Web.HttpContext.Current.Response.Write(@"<script>
//var k = new Object();
//k.type = 'ok';
//window.returnValue = k;
        //window.Close();
//</script>");
        if (ToOpen != null)
        {
            ToOpen(this, new EventArgs());
        }
    }
    public DevExpress.Web.ASPxEditors.ASPxButton BtnOpen
    {
        set { btnOpen = value; }
        get { return btnOpen; }
    }
    bool _boolOpen = true;
    public bool boolOpen
    {
        set { _boolOpen = value; }
        get { return _boolOpen; }
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
                Title = dttitle.Rows[0][ftext].ToString();
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
                case "ASPxButtonEdit":
                    DevExpress.Web.ASPxEditors.ASPxButtonEdit tmpASPxButtonEdit = (DevExpress.Web.ASPxEditors.ASPxButtonEdit)p.Controls[i];
                    Session[leftname + id] = tmpASPxButtonEdit.Value;
                    break;
                case "ASPxDateEdit":
                    DevExpress.Web.ASPxEditors.ASPxDateEdit tmpASPxDateEdit = (DevExpress.Web.ASPxEditors.ASPxDateEdit)p.Controls[i];
                    if (tmpASPxDateEdit.Value == "" || tmpASPxDateEdit.Value==null)
                    {
                        Session[leftname + id] = "";
                    }
                    else
                    {
                        Session[leftname + id] = DateTime.Parse(tmpASPxDateEdit.Value.ToString()).ToString("yyyy-MM-dd");
                    }
                    break;
                case "ASPxComboBox":
                    DevExpress.Web.ASPxEditors.ASPxComboBox tmpASPxComboBox = (DevExpress.Web.ASPxEditors.ASPxComboBox)p.Controls[i];
                    Session[leftname + id] = tmpASPxComboBox.Value;
                    break;
                case "ASPxTextBox":
                    DevExpress.Web.ASPxEditors.ASPxTextBox tmpASPxTextBox = (DevExpress.Web.ASPxEditors.ASPxTextBox)p.Controls[i];
                    Session[leftname + id] = tmpASPxTextBox.Value;
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
                case "ASPxButtonEdit":
                    DevExpress.Web.ASPxEditors.ASPxButtonEdit tmpASPxButtonEdit = (DevExpress.Web.ASPxEditors.ASPxButtonEdit)p.Controls[i];
                    if (Session[leftname + id] != null)
                    {
                        tmpASPxButtonEdit.Value = Session[leftname + id].ToString();
                    }
                    break;
                case "ASPxDateEdit":
                    DevExpress.Web.ASPxEditors.ASPxDateEdit tmpASPxDateEdit = (DevExpress.Web.ASPxEditors.ASPxDateEdit)p.Controls[i];
                    if (Session[leftname + id] != null)
                    {
                        if (Session[leftname + id].ToString() == "")
                        {
                            tmpASPxDateEdit.Value = null;
                        }
                        else
                        {
                            tmpASPxDateEdit.Value = DateTime.Parse(Session[leftname + id].ToString());
                        }
                    }
                    break;
                case "ASPxComboBox":
                    DevExpress.Web.ASPxEditors.ASPxComboBox tmpASPxComboBox = (DevExpress.Web.ASPxEditors.ASPxComboBox)p.Controls[i];
                    if (Session[leftname + id] != null)
                    {
                        tmpASPxComboBox.Value = Session[leftname + id].ToString();
                    }
                    break;
                case "ASPxTextBox":
                    DevExpress.Web.ASPxEditors.ASPxTextBox tmpASPxTextBox = (DevExpress.Web.ASPxEditors.ASPxTextBox)p.Controls[i];
                    if (Session[leftname + id] != null)
                    {
                        tmpASPxTextBox.Value = Session[leftname + id].ToString();
                    }
                    break;
            }

        }
    }

    public void SetViewPage(int p)
    {
        //DataTable dt = GetWebSession();
        string leftname = GetUrl(1);
        Session[leftname + "PageIndex"] = p;
    }

    public int GetViewPage()
    {
        string leftname = Request.Url.AbsoluteUri.ToString().Replace(".", "/");
        leftname = leftname.Split('/')[leftname.Split('/').Length - 3] + "_" + leftname.Split('/')[leftname.Split('/').Length - 2] + "_";
        if (Session[leftname + "PageIndex"] != null && Session[leftname + "PageIndex"].ToString() != "")
        {
            return int.Parse(Session[leftname + "PageIndex"].ToString());
        }
        return 0;
    }
    #endregion

    public string Title
    {
        set {
            //Label label = (Label)ASPxRoundPanel1.FindControl("LabelTitle");
            LabelTitle.Text = value;
        }
        get {
            //Label label = (Label)ASPxRoundPanel1.FindControl("LabelTitle");
            return LabelTitle.Text ;
        }
    }

    public string TitleID
    {
        set
        {
            //Label label = (Label)ASPxRoundPanel1.FindControl("LabelTitleID");
            if (value != "")
            {
                LabelTitleID.Text = "[" + value + "]";
            }
        }
    }

    public string HidID
    {
        set
        {
            hidID.Text = value;
        //labeliID.Text = "[" + value + "]";
        }
        get { return hidID.Text; }
    }

    public string HidFormID
    {
        set { hidformID.Value = value; }
        get { return hidformID.Value; }
    }

    #region role

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

        btnNew.Visible = false;
        btnNewRow.Visible = false;
        btnDel.Visible = false;
        btnSelect.Visible = false;
        btnBack.Visible = false;
        btnSave.Visible = false;
        btnExport.Visible = false;
        btnAudit.Visible = false;
        btnUnAudit.Visible = false;
        btnClose.Visible = false;
        btnOpen.Visible = false;

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
                            btnNew.Visible = true;
                            btnNew.Text = dtbtn.Rows[i][btext].ToString();
                        }
                        break;
                    case "addrow":
                        if ((isadmin == true || dtrole.Select("vchrRoleRight='addrow'").Length > 0) && _boolNewRow == true)
                        {
                            btnNewRow.Visible = true;
                            btnNewRow.Text = dtbtn.Rows[i][btext].ToString();
                        }
                        break;
                    case "edit":
                        if ((isadmin == true || dtrole.Select("vchrRoleRight='edit'").Length > 0) && _boolEdit == true)
                        {
                            btnEdit.Visible = true;
                            btnEdit.Text = dtbtn.Rows[i][btext].ToString();
                        }
                        break;
                    case "audit":
                        if ((isadmin == true || dtrole.Select("vchrRoleRight='audit'").Length > 0) && _boolAudit == true)
                        {
                            btnAudit.Visible = true;
                            btnAudit.Text = dtbtn.Rows[i][btext].ToString();
                        }
                        break;
                    case "unaudit":
                        if ((isadmin == true || dtrole.Select("vchrRoleRight='unaudit'").Length > 0) && _boolUnAudit == true)
                        {
                            btnUnAudit.Visible = true;
                            btnUnAudit.Text = dtbtn.Rows[i][btext].ToString();
                        }
                        break;
                    case "del":
                        if ((isadmin == true || dtrole.Select("vchrRoleRight='del'").Length > 0) && _boolDel == true)
                        {
                            btnDel.Visible = true;
                            btnDel.Text = dtbtn.Rows[i][btext].ToString();
                        }
                        break;
                    case "sel":
                        if ((isadmin == true || dtrole.Select("vchrRoleRight='sel'").Length > 0) && _boolSelect == true)
                        {
                            btnSelect.Visible = true;
                            btnSelect.Text = dtbtn.Rows[i][btext].ToString();
                        }
                        break;
                    case "back":
                        if ((isadmin == true || dtrole.Select("vchrRoleRight='back'").Length > 0) && _boolBack == true)
                        {
                            btnBack.Visible = true;
                            btnBack.Text = dtbtn.Rows[i][btext].ToString();
                        }
                        break;
                    case "close":
                        if ((isadmin == true || dtrole.Select("vchrRoleRight='close'").Length > 0) && _boolClose == true)
                        {
                            btnClose.Visible = true;
                            btnClose.Text = dtbtn.Rows[i][btext].ToString();
                        }
                        break;
                    case "open":
                        if ((isadmin == true || dtrole.Select("vchrRoleRight='open'").Length > 0) && _boolOpen == true)
                        {
                            btnOpen.Visible = true;
                            btnOpen.Text = dtbtn.Rows[i][btext].ToString();
                        }
                        break;
                    case "save":
                        if ((isadmin == true || dtrole.Select("vchrRoleRight='save'").Length > 0) && _boolSave == true)
                        {
                            btnSave.Visible = true;
                            btnSave.Text = dtbtn.Rows[i][btext].ToString();
                        }
                        break;
                    case "export":
                        if ((isadmin == true || dtrole.Select("vchrRoleRight='export'").Length > 0) && _boolExport == true)
                        {
                            btnExport.Visible = true;
                            btnExport.Text = dtbtn.Rows[i][btext].ToString();
                        }
                        break;
                }
            }
        }
    }

    #endregion
}
