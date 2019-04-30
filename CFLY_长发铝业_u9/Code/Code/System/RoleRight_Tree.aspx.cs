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
using System.Collections.Generic;
using System.Text;
using AjaxPro;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxClasses;

public partial class System_RoleRight_Tree : System.Web.UI.Page
{
    private string dir;
    string sSQL;
    string ctext;
    string ftext;
    DataTable ParentDt;
    DataTable btnDt;
    DataTable rigDt;
    bool hidtrue = true;
    ClsDataBase clsSQLCommond = new ClsDataBase();
    /// <summary>
    /// 则显示数形结构
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ToLoadTree()
    {
        //連接數據庫，把表中數據放入DataSet中
        ParentDt = new DataTable();
        Dictionary<string, TreeNode> dic = new Dictionary<string, TreeNode>();
        string Id;//第一級子節點ID
        string Name;//
        string ParentId;//第一級字節點以后的ID
        string Flag = "";

        //TreeNode nodeOne=new TreeNode() ;//添加根結點
        //nodeOne.Text ="工程管理系統";
        //string Pid = "0";
        //nodeOne.Value = "0";
        //nodeOne.NavigateUrl = "Directory_List.aspx?comID=" + Pid +"&FLAG=" + Flag;
        //nodeOne.Target = "middle";
        //dic.Add("0", nodeOne);
        //this.treeDir.Nodes.Add(nodeOne);

        string sql = "select fchrFrmNameID,fchrFrmText,fchrFrmText2,fchrNameSpace,fchrFrmUpName,fIntOrderID,0 as SELECT_FLAG  from   _Form";
        ParentDt = clsSQLCommond.ExecQuery(sql);

        sql = "select fchrFrmNameID,btnCode,vchrBtnText as btnName,vchrBtnText2 as btnName,iOrder from  _FormBtnInfo left join  _BtnBaseInfo on   _BtnBaseInfo.btnCode=_FormBtnInfo.vchrBtnID";
        btnDt = clsSQLCommond.ExecQuery(sql);

        sql = "select * from  _RoleRight where vchrRoleID='" + YxBtn.HidID + "'";
        rigDt = clsSQLCommond.ExecQuery(sql);


        DataRow[] dw = ParentDt.Select("fchrFrmUpName='O'", "fIntOrderID");
        for (int i = 0; i < dw.Length; i++)
        {
            TreeNode pnd = new TreeNode();
            pnd.SelectAction = TreeNodeSelectAction.None;
            //pnd.NavigateUrl = "CreateFormMenu_List.aspx?dirid=" + dw[i]["fchrFrmNameID"].ToString() + "&FLAG=0";
            pnd.Target = "middle";
            pnd.Text = dw[i]["fchrFrmText"].ToString();
            pnd.Value = dw[i]["fchrFrmNameID"].ToString();
            treeDir.Nodes.Add(pnd);
            DataRow[] dws = rigDt.Select("vchrRoleRight='0|" + pnd.Value + "'");
            if (dws.Length > 0)
            {
                pnd.Checked = true;
                
            }
            GetTree(pnd, pnd.Text);
        }
        treeDir.Attributes.Add("onclick", "HandleCheckEvent()");
        if (hidtrue == false)
        {
            //treeDir.CheckedNodes = false;
        }
    }

    private int GetTree(TreeNode tn, string fchrNameSpace)
    {
        DataRow[] dw = ParentDt.Select("fchrFrmUpName='" + fchrNameSpace + "'", "fIntOrderID");
        for (int i = 0; i < dw.Length; i++)
        {
            TreeNode pnd = new TreeNode();
            //pnd.NavigateUrl = "CreateFormMenu_List.aspx?dirid=" + dw[i]["fchrFrmNameID"].ToString() + "&FLAG=0";
            //pnd.Target = "middle";
            pnd.Text = dw[i]["fchrFrmText"].ToString() + "/" + dw[i]["fchrFrmNameID"].ToString();
            pnd.Value = dw[i]["fchrFrmNameID"].ToString();
            pnd.SelectAction = TreeNodeSelectAction.None;
            tn.ChildNodes.Add(pnd);

            DataRow[] dws = rigDt.Select("vchrRoleRight='" + fchrNameSpace + "|" + dw[i]["fchrFrmNameID"].ToString() + "'");
            if (dws.Length >= 1)
            {
                pnd.Checked = true;
                pnd.Expand();
            }
            
            int count = GetTree(pnd, dw[i]["fchrFrmNameID"].ToString());
            if (count == 0)
            {
                GetTree2(pnd, dw[i]["fchrFrmNameID"].ToString());
            }
            else
            {
                pnd.Expand();
            }
        }
        return dw.Length;
    }

    private void GetTree2(TreeNode tn, string fchrNameSpace)
    {
        DataRow[] dwbtn = btnDt.Select("fchrFrmNameID='" + fchrNameSpace + "'", "iOrder");
        for (int i = 0; i < dwbtn.Length; i++)
        {
            string btnCode = dwbtn[i]["btnCode"].ToString();
            string btnName = dwbtn[i]["btnName"].ToString();
            TreeNode pnd = new TreeNode();
            DataRow[] dw = rigDt.Select("vchrRoleRight='" + fchrNameSpace + "|" + btnCode + "'");
            //pnd.NavigateUrl = "CreateFormMenu_List.aspx?dirid=" + dw[i]["fchrFrmNameID"].ToString() + "&FLAG=0";
            //pnd.Target = "middle";
            pnd.SelectAction = TreeNodeSelectAction.None;
            pnd.Text = btnName;
            pnd.Value = btnCode;
            if (dw.Length > 0)
            {
                pnd.Checked = true;
                pnd.Expand();
            }
            
            tn.ChildNodes.Add(pnd);
           
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            YxBtn.HidFormID = "FrmRoleRight";
            PublicClass pc = new PublicClass();
            ftext = pc.GetLanguageForm();
            ctext = pc.GetLanguageColumn();
            YxBtn.BtnSelect.Visible = false;
            YxBtn.BtnDel.Visible = false;
            YxBtn.BtnNew.Visible = false;
            YxBtn.BtnSave.Visible = true;
            if (Request.QueryString["id"] != "" && Request.QueryString["id"] != null)
            {
                YxBtn.HidID = Request.QueryString["id"].ToString();
                YxBtn.TitleID = Request.QueryString["id"].ToString();
                hidtrue = true;
                UpdateBind();
            }
            else
            {
                hidtrue = false;
            }

            ToLoadTree();

            GetGrid();
        }
    }
    public void GetGrid()
    {
//        sSQL = @"select *  into #a from _UserInfo
//
//select *  into #b from _UserRoleInfo where vchrRoleID='1111111111'
//
//select *,case when #b.vchrUserID is not null then convert(bit,1) else convert(bit,0) end iCheck from #a left join #b on #a.vchrUid=#b.vchrUserID  ";
//        sSQL = sSQL.Replace("1111111111", YxBtn.HidID);
//        DataTable dt = clsSQLCommond.ExecQuery(sSQL);
//        ASPxGridView1.DataSource = dt;
//        ASPxGridView1.DataBind();
    }

    #region 修改时绑定
    protected void UpdateBind()
    {
        //if (YxBtn.HidID != "")
        //{
        //    sSQL = "select * from _Form where fchrFrmNameID = '" + YxBtn.HidID + "' ORDER BY fIntOrderID";
        //    DataTable dtFormNew = clsSQLCommond.ExecQuery(sSQL);
        //    if (dtFormNew.Rows.Count > 0)
        //    {
        //        TextBox1.Text = dtFormNew.Rows[0]["fchrFrmNameID"].ToString().Trim();
        //        TextBox2.Text = dtFormNew.Rows[0]["fIntOrderID"].ToString().Trim();
        //        TextBox3.Text = dtFormNew.Rows[0]["fchrFrmText"].ToString().Trim();
        //        TextBox4.Text = dtFormNew.Rows[0]["fchrFrmText2"].ToString().Trim();

        //    }

        //    //if (dtFormNew.Rows[0]["fchrFrmNameID"].ToString().Trim().ToLower().StartsWith("frm"))
        //    //{
        //    sSQL = "select 0 as bChoose,*,'' as FormText,'' as FormText2,'' as FormOrder,'' as FormEnable from _BtnBaseInfo order by iOrder ";
        //    DataTable dts = clsSQLCommond.ExecQuery(sSQL);
        //    sSQL = "select *,vchrBtnText as FormText,intOrder as FormOrder from dbo._FormBtnInfo where fchrFrmNameID = '" + YxBtn.HidID + "'";
        //    DataTable dt = clsSQLCommond.ExecQuery(sSQL);

        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        for (int j = 0; j < dts.Rows.Count; j++)
        //        {
        //            if (dt.Rows[i]["vchrBtnID"].ToString().Trim().ToLower() == dts.Rows[j]["btnCode"].ToString().Trim().ToLower())
        //            {
        //                dts.Rows[j]["bChoose"] = true;
        //                dts.Rows[j]["FormText"] = dt.Rows[i]["vchrBtnText"].ToString().Trim();
        //                dts.Rows[j]["FormText2"] = dt.Rows[i]["vchrBtnText2"].ToString().Trim();
        //                dts.Rows[j]["FormOrder"] = dt.Rows[i]["FormOrder"].ToString().Trim();
        //                dts.Rows[j]["FormEnable"] = dt.Rows[i]["intOrder"].ToString().Trim();
        //                break;
        //            }
        //        }
        //    }

        //    SmartGridView1.DataSource = dts;
        //    SmartGridView1.DataBind();
        //    //}
        //}
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
        //int s= ASPxGridView1.VisibleRowCount;
        try
        {
            if (YxBtn.HidID.Trim() == "administrator")
            {
                throw new Exception("administrator是默认角色，不能修改权限！");
            }
            #region  从表
            sSQL = "delete  _RoleRight where vchrRoleID = '" + YxBtn.HidID.Trim() + "' ";
            cmd.CommandText = sSQL;
            cmd.ExecuteNonQuery();

            for (int i = 0; i < treeDir.Nodes.Count; i++)
            {
                GetTree3(treeDir.Nodes[i], cmd);
            }
            //sSQL = "delete  _UserRoleInfo where vchrRoleID = '" + YxBtn.HidID.Trim() + "' ";
            //cmd.CommandText = sSQL;
            //cmd.ExecuteNonQuery();
            //GridViewDataColumn column1 = ASPxGridView1.Columns["bChoosed"] as GridViewDataColumn;
            //sSQL = "select * from _UserRoleInfo where vchrRoleID='" + YxBtn.HidID.Trim() + "'";
            //DataTable dtrinfo = clsSQLCommond.ExecQuery(sSQL);
            //for (int i = 0; i < ASPxGridView1.VisibleRowCount; i++)
            //{
                
            //    ASPxCheckBox checkBox = (ASPxCheckBox)ASPxGridView1.FindRowCellTemplateControl(i, column1, "ASPxCheckBox1");
            //    if (checkBox != null)
            //    {
            //        bool isVisible = checkBox.Checked;
            //        DataRow[] dw=dtrinfo.Select("vchrUserID='" + ASPxGridView1.GetRowValues(i, "vchrUid") + "'");
            //        if (isVisible == true && dw.Length == 0)
            //        {
            //            sSQL = "insert into _UserRoleInfo(vchrUserID, vchrRoleID) values('" + ASPxGridView1.GetRowValues(i, "vchrUid") + "','" + YxBtn.HidID.Trim() + "')";
            //            cmd.CommandText = sSQL;
            //            cmd.ExecuteNonQuery();
            //        }
            //        else if (isVisible == false)
            //        {
            //            sSQL = "delete from _UserRoleInfo where vchrUserID='" + ASPxGridView1.GetRowValues(i, "vchrUid") + "' and vchrRoleID='" + YxBtn.HidID.Trim() + "'";
            //            cmd.CommandText = sSQL;
            //            cmd.ExecuteNonQuery();
            //        }
            //    }
            //}
            #endregion

            trans.Commit();
            System.Web.HttpContext.Current.Response.Write("<script>alert('保存成功！');window.location=document.location.href</script>");
        }
        catch(Exception ee)
        {
            trans.Rollback();
            Response.Write("<script language='javascript'>window.alert('" + ee.Message + "');</script>");
        }
        finally
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
    }

    private void GetTree3(TreeNode tn,SqlCommand cmd)
    {
        if (tn.Checked == true)
        {
            Sql sc = new Sql();
            sc.Get("_RoleRight", "vchrRoleID", YxBtn.HidID.Trim(), true);
            if (tn.Parent != null)
            {
                sc.ToString("vchrRoleRight", tn.Parent.Value + "|" + tn.Value);
            }
            else
            {
                sc.ToString("vchrRoleRight", "0" + "|" + tn.Value);
            }
            cmd.CommandText = sc.ReturnSql();
            cmd.ExecuteNonQuery();
        }
        for (int i = 0; i < tn.ChildNodes.Count; i++)
        {
            //TreeNode ptn = tn.ChildNodes[i];
            //if (ptn.ChildNodes.Count > 0)
            //{
            //    //if (ptn.ChildNodes[0].ChildNodes.Count == 0)
            //    //{
            //        string fchrFrmUpName = ptn.Value;
            //        for (int j = 0; j < ptn.ChildNodes.Count; j++)
            //        {
            //            if (ptn.ChildNodes[j].Checked == true)
            //            {
            //                Sql scc = new Sql();
            //                scc.Get("_RoleRight", "vchrRoleID", YxBtn.HidID.Trim(), true);
            //                scc.ToString("vchrRoleRight", fchrFrmUpName + "|" + ptn.ChildNodes[j].Value);
            //                cmd.CommandText = scc.ReturnSql();
            //                cmd.ExecuteNonQuery();
            //            }
            //        }
            //    //}
            //}
            GetTree3(tn.ChildNodes[i], cmd);
        }
    }
    #endregion


    protected void treeDir_TreeNodeCheckChanged(object sender, TreeNodeEventArgs e)
    {
        TreeNode tn = e.Node;
        if (tn.Checked == true)
        {
            TreeNodeCheck(tn);
        }
    }

    private void TreeNodeCheck(TreeNode tn)
    {
        if (tn.Parent != null)
        {
            TreeNode tnp = tn.Parent;
            tnp.Checked = true;
            TreeNodeCheck(tnp);
        }
    }

    #region ObjectDataSource
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters["sRoleID"] = YxBtn.HidID;
        //e.InputParameters["vchrUid"] = ASPxTextBox1.Value;
        //e.InputParameters["eDate1"] = ASPxDateEdit2.Value;
        //Page.ClientScript.RegisterStartupScript(this.GetType(), "js", "alert('11');", true);

    }

    protected void ObjectDataSource1_Updating(object sender, ObjectDataSourceMethodEventArgs e)
    {
        //GetCheck(e, 0);
    }
    protected void ObjectDataSource1_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
    {
        //GetCheck(e, 1);
    }
    protected void ObjectDataSource1_Deleting(object sender, ObjectDataSourceMethodEventArgs e)
    {
        //GetDelCheck(e);
    }

    protected void ObjectDataSource1_Updated(object sender, ObjectDataSourceStatusEventArgs e)
    {
        //WriteResultMsg("刪除", e);
    }
    protected void ObjectDataSource1_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
    {

    }
    protected void ObjectDataSource1_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
    {

    }

    #endregion
}
