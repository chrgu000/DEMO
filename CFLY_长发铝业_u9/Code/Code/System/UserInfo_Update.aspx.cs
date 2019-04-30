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
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxClasses;

public partial class System_UserInfo_Update : System.Web.UI.Page
{
    ClsDataBase clsSQLCommond = new ClsDataBase();
    ClsDES clsDES = ClsDES.Instance();
    string sSQL;
    DataTable dt;
    string tablename = "_UserInfo";
    string tableid = "vchrUid";
    #region 加载页面
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            AjaxPro.Utility.RegisterTypeForAjax(typeof(AjaxMethod));
            YxBtn.HidFormID = "FrmUserInfo";
            Bind();

            //YxBtn.BtnSave.Visible = true;

            //UserID.Type = "self";

            if (Request.QueryString["ID"] != "" && Request.QueryString["ID"] != null)
            {
                YxBtn.HidID = Request.QueryString["ID"].ToString();

                UpdateBind();
                YxBtn.BtnDel.Visible = true;
            }
            else
            {
                NewBind();
            }
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
        sSQL = "select * from " + tablename + " where " + tableid + "='" + YxBtn.HidID + "'";
        dt = clsSQLCommond.ExecQuery(sSQL);
        if (dt.Rows.Count > 0)
        {
            #region 绑定表
            ASPxTextBox1.Text = dt.Rows[0]["vchrUid"].ToString();
            ASPxTextBox2.Text = dt.Rows[0]["vchrName"].ToString();
            #endregion
        }
    }
    #endregion

    #region 保存按钮
    protected void ToSave(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(clsSQLCommond.Online);
        SqlCommand cmd = new SqlCommand();
        SqlTransaction trans;
        con.Open();
        cmd.Connection = con;
        trans = con.BeginTransaction();
        cmd.Transaction = trans;
        string uID = Session["uID"].ToString();
        string sErr = "";
        try
        {
            GridViewDataColumn column1 = ASPxGridView1.Columns["iCheck"] as GridViewDataColumn;

            for (int i = 0; i < ASPxGridView1.VisibleRowCount; i++)
            {
                ASPxCheckBox checkBox = (ASPxCheckBox)ASPxGridView1.FindRowCellTemplateControl(i, column1, "ASPxCheckBox1");
                if (checkBox != null)
                {
                    bool isVisible = checkBox.Checked;
                    string ID = ASPxGridView1.GetRowValues(i, "vchrRoleID").ToString();
                    if (ID != "")
                    {
                        sSQL = "select * from _UserRoleInfo where vchrRoleID='" + ID +"' and vchrUserID='" + ASPxTextBox1.Value + "'";
                        dt = clsSQLCommond.ExecQuery(sSQL);
                        if (isVisible == true && dt.Rows.Count == 0)
                        {
                            sSQL = "insert into _UserRoleInfo(vchrRoleID,vchrUserID) values('" + ID + "','" + ASPxTextBox1.Value + "') ";
                            cmd.CommandText = sSQL;
                            cmd.ExecuteNonQuery();
                        }
                        else if (isVisible == false && dt.Rows.Count == 1)
                        {
                            sSQL = "delete from _UserRoleInfo where vchrRoleID='" + ID + "' and vchrUserID='" + ASPxTextBox1.Value + "'";
                            cmd.CommandText = sSQL;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                
            }
            if (sErr != "")
            {
                throw new Exception(sErr);
            }
            trans.Commit();
            System.Web.HttpContext.Current.Response.Write("<script>alert('保存成功！');window.location=document.location.href</script>");
            ASPxGridView1.DataBind();

        }
        catch (Exception ee)
        {
            trans.Rollback();
            System.Web.HttpContext.Current.Response.Write("<script>alert('" + ee.Message + "');</script>");
        }
    }
    #endregion

    #region 删除按钮
    protected void ToDel(object sender, EventArgs e)
    {

    }
    #endregion

    #region 返回按钮
    protected void ToBack(object sender, EventArgs e)
    {
        Response.Redirect("UserInfo_Index.aspx");
    }
    #endregion

    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters["sUid"] = YxBtn.HidID;
    }
}