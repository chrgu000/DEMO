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

public partial class System_RoleRight_List : System.Web.UI.Page
{
    ClsDataBase clsSQLCommond = new ClsDataBase();
    string sSQL;
    DataTable dt;

    #region 加载页面
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            AjaxPro.Utility.RegisterTypeForAjax(typeof(AjaxMethod));

        }
    }
    #endregion

    #region 绑定
    protected void Bind()
    {
        GetTitle();
    }

    private void GetTitle()
    {
        //sSQL = "select vlanguage from _UserInfo where vchrUid='" + Session["uID"].ToString() + "'";
        //string vlanguage = clsSQLCommond.String(sSQL);
        //string ctext = "";
        //string ftext="";
        //if (vlanguage == "" || vlanguage == "CHS")
        //{
        //    ctext = "COLUMN_Text";
        //    ftext="fchrFrmText";
        //}
        //else if (vlanguage == "EN")
        //{
        //    ctext = "COLUMN_Text2";
        //    ftext="fchrFrmText2";
        //}

        //sSQL = "select * from  _Form where fchrFrmNameID='访客登记'";
        //DataTable dttitle = clsSQLCommond.ExecQuery(sSQL);
        //if (dttitle.Rows.Count > 0)
        //{
        //    YxBtnTop.Title = dttitle.Rows[0][ftext].ToString();
        //}
        //sSQL = "select * from  _TableColInfo where  TABLE_NAME='" + tablename + "'";
        //DataTable dt = clsSQLCommond.ExecQuery(sSQL);

        //for (int i = 0; i < dt.Rows.Count; i++)
        //{
        //    switch (dt.Rows[i]["COLUMN_NAME"].ToString())
        //    {
        //        case "S1":
        //            Label1.Text = dt.Rows[i][ctext].ToString();
        //            break;
        //        case "S2":
        //            Label2.Text = dt.Rows[i][ctext].ToString();
        //            break;
        //        case "S3":
        //            Label3.Text = dt.Rows[i][ctext].ToString();
        //            break;
        //        case "S4":
        //            Label4.Text = dt.Rows[i][ctext].ToString();
        //            break;
        //        case "S5":
        //            Label5.Text = dt.Rows[i][ctext].ToString();
        //            break;
        //    }
        //}
    }

    #endregion

    #region 新增时绑定
    protected void NewBind()
    {

    }
    #endregion

    #region 修改时绑定
    protected void UpdateBind()
    {
        
    }
    #endregion

    #region 保存按钮
    protected void ToSave(object sender, EventArgs e)
    {
        
        
    }
    #endregion

    #region 返回按钮
    protected void ToBeck(object sender, EventArgs e)
    {
        Response.Redirect("RoleInfo_Index.aspx");
    }
    #endregion

    //protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    //{
    //    e.InputParameters["sRoleID"] = YxBtn.HidID;
    //}
    protected void chk_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chk = sender as CheckBox;

        int index = ((GridViewRow)(chk.NamingContainer)).RowIndex;

        if (chk.Checked)
        {
            SmartGridView1.Rows[index].Cells[5].Text = SmartGridView1.Rows[index].Cells[2].Text.Trim();
            SmartGridView1.Rows[index].Cells[6].Text = SmartGridView1.Rows[index].Cells[3].Text.Trim();
            SmartGridView1.Rows[index].Cells[7].Text = SmartGridView1.Rows[index].Cells[4].Text.Trim();
        }
    }
    protected void SmartGridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("OnClick", "javascript:window.parent.frames[1].location.href='RoleRight_Left_Tree.aspx?ID=" + e.Row.Cells[0].Text + "'");
        }
    }

    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters["sUid"] = "";

        PublicClass pc = new PublicClass();
        pc.GetSmartGridViewSheet(SmartGridView1);
    }
}

