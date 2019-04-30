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

public partial class System_RoleRight_Left_Tree : System.Web.UI.Page
{
    private string dir;
    string sSQL;
    string ctext;
    string ftext;
    DataTable ParentDt;
    DataTable btnDt;
    DataTable rigDt;
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

        sql = "select * from _BtnBaseInfo";
        btnDt = clsSQLCommond.ExecQuery(sql);

        sql = "select * from  _RoleRight where vchrRoleID='" + YxBtn.HidID + "'";
        rigDt = clsSQLCommond.ExecQuery(sql);


        DataRow[] dw = ParentDt.Select("fchrFrmUpName='0'", "fIntOrderID");
        for (int i = 0; i < dw.Length; i++)
        {
            TreeNode pnd = new TreeNode();
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
            GetTree(pnd, "S");
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
            pnd.Text = dw[i]["fchrFrmText"].ToString();
            pnd.Value = dw[i]["fchrFrmNameID"].ToString();
            tn.ChildNodes.Add(pnd);
            DataRow[] dws = rigDt.Select("vchrRoleRight='" + fchrNameSpace + "|" + pnd.Value + "'");
            if (dws.Length > 0)
            {
                pnd.Checked = true;
            }
            int count = GetTree(pnd, dw[i]["fchrFrmNameID"].ToString());
            if (count == 0)
            {
                GetTree2(pnd, dw[i]["fchrFrmNameID"].ToString());
            }
        }
        return dw.Length;
    }

    private void GetTree2(TreeNode tn, string fchrNameSpace)
    {
        for (int i = 0; i < btnDt.Rows.Count; i++)
        {
            TreeNode pnd = new TreeNode();
            DataRow[] dw = rigDt.Select("vchrRoleRight='" + fchrNameSpace + "|" + btnDt.Rows[i]["btnCode"].ToString() + "'");
            //pnd.NavigateUrl = "CreateFormMenu_List.aspx?dirid=" + dw[i]["fchrFrmNameID"].ToString() + "&FLAG=0";
            //pnd.Target = "middle";
            pnd.Text = btnDt.Rows[i]["btnName"].ToString();
            pnd.Value = btnDt.Rows[i]["btnCode"].ToString();
            if (dw.Length > 0)
            {
                pnd.Checked = true;
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
                YxBtn.Title = "权限设置-" + Request.QueryString["id"].ToString();
                UpdateBind();
            }
            else
            {
            }

            ToLoadTree();

            
        }
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

            for(int i=0;i<treeDir.Nodes.Count;i++)
            {
                //if (treeDir.Nodes[i].Checked == true)
                //{
                //    Sql scc = new Sql();
                //    scc.Get("_RoleRight", "vchrRoleID", YxBtn.HidID.Trim(), true);
                //    scc.ToString("vchrRoleRight", treeDir.Nodes[i].Parent.Value + "|" + treeDir.Nodes[i].Value);
                //    cmd.CommandText = scc.ReturnSql();
                //    cmd.ExecuteNonQuery();
                //}
                GetTree3(treeDir.Nodes[i],cmd);
            }
           
            #endregion

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
            Response.Redirect("RoleRight_Left_Tree.aspx?id=" + YxBtn.HidID);
        }
    }

    private void GetTree3(TreeNode tn,SqlCommand cmd)
    {
        for (int i = 0; i < tn.ChildNodes.Count; i++)
        {
            if (tn.ChildNodes[i].Checked == true)
            {
                Sql sc = new Sql();
                sc.Get("_RoleRight", "vchrRoleID", YxBtn.HidID.Trim(), true);
                sc.ToString("vchrRoleRight", tn.ChildNodes[i].Parent.Value + "|" + tn.ChildNodes[i].Value);
                cmd.CommandText = sc.ReturnSql();
                cmd.ExecuteNonQuery();
            }

            TreeNode ptn = tn.ChildNodes[i];
            if (ptn.ChildNodes.Count > 0)
            {
                //if (ptn.ChildNodes[0].ChildNodes.Count == 0)
                //{
                    string fchrFrmUpName = ptn.Value;
                    for (int j = 0; j < ptn.ChildNodes.Count; j++)
                    {
                        if (ptn.ChildNodes[j].Checked == true)
                        {
                            Sql scc = new Sql();
                            scc.Get("_RoleRight", "vchrRoleID", YxBtn.HidID.Trim(), true);
                            scc.ToString("vchrRoleRight", fchrFrmUpName + "|" + ptn.ChildNodes[j].Value);
                            cmd.CommandText = scc.ReturnSql();
                            cmd.ExecuteNonQuery();
                        }
                    }
                //}
            }
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
}
