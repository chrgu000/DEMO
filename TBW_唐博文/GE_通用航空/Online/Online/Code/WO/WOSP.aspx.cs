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

public partial class WOSP_Index : System.Web.UI.Page
{
    系统服务.ClsDES clsDES = 系统服务.ClsDES.Instance();
    ClsDataBase clsSQLCommond = new ClsDataBase();
    ASPxGridViewShow gridview = new ASPxGridViewShow();
    string sSQL;
    string tablename = "SP";
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            YxBtn.HidFormID = "WOSP";
            if (Request.QueryString["ID"] != null && Request.QueryString["ID"].ToString()!="")
            {
                YxBtn.HidID = Request.QueryString["ID"].ToString();
            }
            
            //cal.ValueStart = DateTime.Now.AddMonths(-10).ToString("yyyy-MM-dd");
            //cal.ValueEnd = DateTime.Now.ToString("yyyy-MM-dd");
            YxBtn.GetViewState(divSel);
            YxBtn.boolNew = false;
            GetTitle();

            ASPxGridView2.DataBind();

        }
    }

    #region 标题
    private void GetTitle()
    {
        ASPxGridViewShow gridview = new ASPxGridViewShow();
        gridview.GetTitle(ASPxGridView1, tablename);

        ASPxGridViewShow gridview2 = new ASPxGridViewShow();
        gridview.GetTitle(ASPxGridView2, "WO");

        ASPxGridView1.Columns["Date2"].Caption = "出库时间";
    }
    #endregion

    #region 按钮
    protected void ToSelect(object sender, EventArgs e)
    {
        YxBtn.SetViewState(divSel);
        ASPxGridView1.DataBind();
    }

    protected void ToSave(object sender, EventArgs e)
    {

    }

    protected void ToNew(object sender, EventArgs e)
    {

    }

    protected void ToDel(object sender, EventArgs e)
    {

    }

    protected void ToExport(object sender, EventArgs e)
    {
        ASPxGridViewExporter1.WriteXlsToResponse(this.Title);
    }

    protected void ToBeck(object sender, EventArgs e)
    {
        Response.Redirect("Index.aspx");
    }
    #endregion

    #region Check
    private void GetCheck(System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs e, int b)
    {
        if (gridview.ParameterIsNull(e.InputParameters["S1"]))
        {
            throw new Exception(gridview.GetFieldName(ASPxGridView1, "S1") + "不可为空");
        }
        if (gridview.ParameterIsNull(e.InputParameters["D1"]))
        {
            throw new Exception(gridview.GetFieldName(ASPxGridView1, "D1") + "不可为空");
        }
        else
        {
            if (double.Parse(e.InputParameters["D1"].ToString()) <= 0)
            {
                throw new Exception(gridview.GetFieldName(ASPxGridView1, "D1") + "必须大于0");
            }
        }
    }
    #endregion

    #region ObjectDataSource
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters["I1"] = YxBtn.HidID;
        //Page.ClientScript.RegisterStartupScript(this.GetType(), "js", "alert('11');", true);
        
    }

    protected void ObjectDataSource1_Updating(object sender, ObjectDataSourceMethodEventArgs e)
    {
        e.InputParameters["I1"] = YxBtn.HidID;
        GetCheck(e, 0); 
    }
    protected void ObjectDataSource1_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
    {
        e.InputParameters["I1"] = YxBtn.HidID;
        GetCheck(e, 1);
    }
    protected void ObjectDataSource1_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
    {

    }
    protected void ObjectDataSource1_Updated(object sender, ObjectDataSourceStatusEventArgs e)
    {
        //WriteResultMsg("刪除", e);
    }
    #endregion

    
    protected void ObjectDataSource3_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters["iID"] = YxBtn.HidID;
    }

    protected void ASPxGridView1_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
    {

    }
    protected void ASPxGridView1_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewCustomButtonCallbackEventArgs e)
    {
        string s=e.ButtonID;
    }
    protected void ASPxGridView1_CellEditorInitialize(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewEditorEventArgs e)
    {
            if (e.Column.FieldName == "Date2")
            {
                string s = "";
               // FormatCalendar cal2 = e.Editor;
            }
    }
}

