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

public partial class YxButtonUpdate : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string str = Parent.Page.ClientID;
            if (Session["uID"].ToString() == "")
            {
                StringBuilder str1 = new StringBuilder();
                str1.Append("<script language=javascript>location.href('../ErrorPage.aspx');</script>");
                System.Web.HttpContext.Current.Response.Write(str1.ToString());
            }
        }
    }

    #region 事件
    public event System.EventHandler ToSave;
    public void BtnToSave(Object Sender, EventArgs e)
    {
        Enable(false);
        if (ToSave != null)
        {
            ToSave(this, new EventArgs());
            if (IsTrue == true)
            {
                Response.Redirect(Session["backurl"].ToString());
            }
        }
        
    }

    public event System.EventHandler ToDel;
    public void BtnToDel(Object Sender, EventArgs e)
    {
        Enable(false);
        if (ToDel != null)
        {
            ToDel(this, new EventArgs());
            Response.Redirect(Session["backurl"].ToString());
        }
    }


    public event System.EventHandler ToBeck;
    protected void BtnToBack(object sender, EventArgs e)
    {
        Enable(false);
        if (ToBeck != null)
        {
            ToBeck(this, new EventArgs());
            Response.Redirect(Session["backurl"].ToString());
        }
    }


    //public event System.EventHandler ToChoose;
    //public void BtnToChoose(Object Sender, EventArgs e)
    //{
    //    Enable(false);
    //    if (ToChoose != null)
    //    {
    //        ToChoose(this, new EventArgs());
    //        if (IsTrue == true)
    //        {
    //            Response.Redirect(Session["backurl"].ToString());
    //        }
    //    }

    //}

    #endregion

    
    #region 按钮
    public Button BtnBack
    {
        set { lbToBack = value; }
        get { return lbToBack; }
    }

    public Button BtnSave
    {
        set { lbToSave = value; }
        get { return lbToSave; }
    }

    public Button BtnDel
    {
        set { lbToDel = value; }
        get { return lbToDel; }
    }

    //public Button BtnChoose
    //{
    //    set { lbToChoose = value; }
    //    get { return lbToChoose; }
    //}
    #endregion

    #region 按钮是否可见
    public bool VisibleBtnSave
    {
        set { lbToSave.Visible = value; }
        get { return lbToSave.Visible; }
    }

    public bool VisibleBtnDel
    {
        set { lbToDel.Visible = value; }
        get { return lbToDel.Visible; }
    }

    #endregion

    #region 定义页面的连接的数据库
    /// <summary>
    /// 序号值
    /// </summary>
    public string HidID
    {
        set { hidPageID.Value = value; }
        get { return hidPageID.Value; }
    }

    /// <summary>
    /// 从表序号值
    /// </summary>
    public string HidSID
    {
        set { hidPageSID.Value = value; }
        get { return hidPageSID.Value; }
    }

    /// <summary>
    /// 数据表名
    /// </summary>
    public string HidTable
    {
        set { hidPageTable.Value = value; }
        get { return hidPageTable.Value; }
    }

    /// <summary>
    /// 数据表名
    /// </summary>
    public string HidSTable
    {
        set { hidPageSTable.Value = value; }
        get { return hidPageSTable.Value; }
    }

    /// <summary>
    /// 序号字段名
    /// </summary>
    public string HidName
    {
        set { hidPageIDName.Value = value; }
        get { return hidPageIDName.Value; }
    }

    /// <summary>
    /// 从表序号字段名
    /// </summary>
    public string HidSName
    {
        set { hidPageSIDName.Value = value; }
        get { return hidPageSIDName.Value; }
    }
    #endregion

    public string HidFlag
    {
        set { hidFlag.Value = value; }
        get { return hidFlag.Value; }
    }

    public bool IsTrue
    {
        set { hidIsTrue.Value = value.ToString(); }
        get
        {
            if (hidIsTrue.Value == "False")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    #region
    //public void GetVisibleSave(bool e)
    //{
    //    lbToSave.Visible = e;
    //    lbToSaveNew.Visible = e;
    //    lbToSaveCopy.Visible = e;
    //}

    //public void GetVisibleDel(bool e)
    //{
    //    lbToDel.Visible = e;
    //}

    //public void GetVisible(bool e)
    //{
    //    lbToSave.Visible = e;
    //    lbToSaveNew.Visible = e;
    //    lbToSaveCopy.Visible = e;
    //    lbToDel.Visible = e;
    //}
    #endregion

    private void Enable(bool e)
    {
        lbToSave.Enabled = e;
        lbToDel.Enabled = e;
    }
}
