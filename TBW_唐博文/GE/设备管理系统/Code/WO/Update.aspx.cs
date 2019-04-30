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
using Ajax;

public partial class WO_Update : System.Web.UI.Page
{
    ClsDataBase clsSQLCommond = new ClsDataBase();
    string sSQL;
    DataTable dt;
    ASPxGridViewShow gridview = new ASPxGridViewShow();
    string tablename = "WO";
    string tableid = "iID";
    #region 加载页面
    protected void Page_Load(object sender, EventArgs e)
    {
        AjaxPro.Utility.RegisterTypeForAjax(typeof(WOAjaxMethod));
        if (!IsPostBack)
        {
            YxBtn.HidFormID = "WOUpdate";
            YxBtn.GetViewState(divSel);
            
            Bind();

            YxBtn.BtnSave.Visible = true;

            if (Request.QueryString["iID"] != "" && Request.QueryString["iID"] != null)
            {
                YxBtn.HidID = Request.QueryString["iID"].ToString();
                UpdateBind();
                
            }
            else
            {
                NewBind();

            }

        }
    }
    #endregion

    #region 是否显示
    private void GetShow(bool b)
    {

    }
    #endregion

    #region 绑定
    protected void Bind()
    {
        
    }

    private void GetTitle()
    {
        
    }

    #endregion

    #region 新增时绑定
    protected void NewBind()
    {
        YxBtn.boolDel = false;
        YxBtn.boolNew = false;
        gridview.GetUpdate(TableUpdate1, tablename, null, "S2", true);
    }
    #endregion

    #region 修改时绑定
    protected void UpdateBind()
    {
        sSQL = "select * from " + tablename + " where " + tableid + "=" + YxBtn.HidID + "";
        dt = clsSQLCommond.ExecQuery(sSQL);
        WOAjaxMethod ajaxM = new WOAjaxMethod();
        bool b = ajaxM.IsDelete(dt.Rows[0]["S1"].ToString());
        gridview.GetUpdate(TableUpdate1, tablename, dt, "S2", true);
    }
    #endregion

    #region 新增
    protected void ToNew(object sender, EventArgs e)
    {
        Response.Redirect("WOSP.aspx?iID="+YxBtn.HidID);
    }
    #endregion

    #region 保存按钮
    protected void ToSave(object sender, EventArgs e)
    {
        
    }
    #endregion

    #region 删除
    protected void ToDel(object sender, EventArgs e)
    {
        
    }
    #endregion

    #region 返回按钮
    protected void ToBeck(object sender, EventArgs e)
    {
        Response.Redirect("Index.aspx");
    }
    #endregion

    #region 查询
    protected void ToSelect(object sender, EventArgs e)
    {
        OpenWindow ow = new OpenWindow();
        ow.Alert(Page, "Error");
    }
    #endregion


    protected void ToExport(object sender, EventArgs e)
    {
    }



}

