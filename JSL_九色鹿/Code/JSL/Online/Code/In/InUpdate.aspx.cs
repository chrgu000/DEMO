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

public partial class In_InUpdate : System.Web.UI.Page
{
    OpenWindow ow = new OpenWindow();

    string sSQL;
    DataTable dt;

    #region 加载页面
    protected void Page_Load(object sender, EventArgs e)
    {
        Ajax.Utility.RegisterTypeForAjax(typeof(AjaxMethod));
        if (!IsPostBack)
        {
            

            BoxID.Attributes.Add("onkeyup", "javascript:doAdd('" + BoxID.ClientID + "','" + dDate.mycal.ClientID + "','" + hidid.ClientID + "')");
            BtnAdd.Attributes.Add("onclick", "javascript:doAdd('" + BoxID.ClientID + "','" + dDate.mycal.ClientID + "','" + hidid.ClientID + "')");

            #region 定义本页面的连接的数据库
            YxBtn.HidTable = "AttendanceLeave";
            //YxBtn.HidSTable = YxBtn.HidTable + "s";
            YxBtn.HidName = "ID";
            //YxBtn.HidSName = "S" + YxBtn.HidName;
            #endregion


            Bind();

            YxBtn.BtnSave.Visible = true;

            if (Request.QueryString["ID"] != "" && Request.QueryString["ID"] != null)
            {
                YxBtn.HidID = Request.QueryString["ID"].ToString();

                UpdateBind();
            }
            else
            {
                NewBind();
            }
            BoxID.Focus();
        }
    }
    #endregion




    #region 绑定
    protected void Bind()
    {

    }
    #endregion

    #region 新增时绑定
    protected void NewBind()
    {
        dDate.Value = DateTime.Now.ToString("yyyy-MM-dd");
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
        DoSave();
    }
    #endregion

    #region 保存按钮
    public void DoSave()
    {

        SqlConnection con = new SqlConnection(Conn.Online);
        SqlCommand cmd = new SqlCommand();
        SqlTransaction trans;
        con.Open();
        cmd.Connection = con;
        trans = con.BeginTransaction();
        cmd.Transaction = trans;
        try
        {
            
            trans.Commit();
        }
        catch
        {
            trans.Rollback();
            Response.Redirect("../ErrorPage.aspx");
        }
        finally
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
    #endregion

    protected void ToBeck(object sender, EventArgs e)
    {
        Response.Redirect("../Frame/Index.aspx");
    }

    protected void ToAdd(object sender, EventArgs e)
    {

    }

    protected void ToChoose(object sender, EventArgs e)
    {
        Response.Redirect("../Share/CustomerSelect.aspx");
    }

    protected void img_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../Share/CustomerSelect.aspx");
    }

    
}

