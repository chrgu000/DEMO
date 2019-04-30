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

public partial class Equip_Index : System.Web.UI.Page
{
    系统服务.ClsDES clsDES = 系统服务.ClsDES.Instance();
    ClsDataBase clsSQLCommond = new ClsDataBase();
    ASPxGridViewShow gridview = new ASPxGridViewShow();
    string sSQL;
    string tablename = "Equip";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            YxBtn.HidFormID = "Equip";
            //cal.ValueStart = DateTime.Now.AddMonths(-10).ToString("yyyy-MM-dd");
            //cal.ValueEnd = DateTime.Now.ToString("yyyy-MM-dd");
            YxBtn.GetViewState(divSel);
            YxBtn.boolNew = false;
            GetTitle();
        }
    }

    #region 标题
    private void GetTitle()
    {
        gridview.GetTitle(ASPxGridView1, tablename);
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

    }
    #endregion

    #region Check
    private void GetCheck(System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs e, int b)
    {
        if (gridview.ParameterIsNull(e.InputParameters["S1"]))
        {
            throw new Exception(gridview.GetFieldName(ASPxGridView1, "S1") + "不可为空");
        }
        if (gridview.ParameterIsNull(e.InputParameters["S3"]))
        {
            throw new Exception(gridview.GetFieldName(ASPxGridView1, "S3") + "不可为空");
        }
        if (gridview.ParameterIsNull(e.InputParameters["S5"]))
        {
            throw new Exception(gridview.GetFieldName(ASPxGridView1, "S5") + "不可为空");
        }
    }
    #endregion

    #region ObjectDataSource
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        //e.InputParameters["S3"] = DropDownListS1.Value;
        //Page.ClientScript.RegisterStartupScript(this.GetType(), "js", "alert('11');", true);
    }

    protected void ObjectDataSource1_Updating(object sender, ObjectDataSourceMethodEventArgs e)
    {
        GetCheck(e, 0);
    }
    protected void ObjectDataSource1_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
    {
        GetCheck(e, 1);
    }
    protected void ObjectDataSource1_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
    {

    }
    protected void ObjectDataSource1_Updated(object sender, ObjectDataSourceStatusEventArgs e)
    {
        //WriteResultMsg("刪除", e);
    }

    protected void ObjectDataSource1_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
    {

    }
    protected void ObjectDataSource1_Deleting(object sender, ObjectDataSourceMethodEventArgs e)
    {
    }
    #endregion

    #region ASPxGridView
    protected void ASPxGridView1_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
    {
        sSQL = "select S1 from " + tablename + " where iID=" + e.Keys[0].ToString().Trim();
        string s = clsSQLCommond.ExecString(sSQL);
        if (clsSQLCommond.Int("select count(*) from WO where S1='" + s + "'") > 0)
        {
            throw new Exception("设备已使用");
        }
        else if (clsSQLCommond.Int("select count(*) from Planned where S13='" + s + "'") > 0)
        {
            throw new Exception("设备已使用");
        }
    }
    #endregion


    protected void ASPxGridView1_CellEditorInitialize(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewEditorEventArgs e)
    {
        if (ASPxGridView1.IsEditing && !ASPxGridView1.IsNewRowEditing && e.Column.FieldName == "S1")
        {
            string s = (string)ASPxGridView1.GetRowValuesByKeyValue(e.KeyValue, "S1");
            if (clsSQLCommond.Int("select count(*) from WO where S1='" + s + "'") > 0)
            {
                e.Editor.ReadOnly = true;
            }
            else if (clsSQLCommond.Int("select count(*) from Planned where S13='" + s + "'") > 0)
            {
                e.Editor.ReadOnly = true;
            }
        }
    }
}

