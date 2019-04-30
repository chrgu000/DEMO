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
using System.Collections.Generic;

public partial class System_CreateFormMenu_Left_Tree : System.Web.UI.Page
{
    private string dir;
    string sSQL;
    string ctext;
    string ftext;
    DataTable ParentDt;
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

        DataRow[] dw = ParentDt.Select("fchrFrmUpName='0'", "fIntOrderID");
        for (int i = 0; i < dw.Length; i++)
        {
            TreeNode pnd = new TreeNode();
            //pnd.NavigateUrl = "CreateFormMenu_List.aspx?dirid=" + dw[i]["fchrFrmNameID"].ToString() + "&FLAG=0";
            pnd.Target = "middle";
            pnd.Text = dw[i][ftext].ToString();
            pnd.Value = dw[i]["fchrFrmNameID"].ToString();
            treeDir.Nodes.Add(pnd);
            GetTree(pnd, "S");
        }
        
    }

    private void GetTree(TreeNode tn, string fchrNameSpace)
    {
        DataRow[] dw = ParentDt.Select("fchrFrmUpName='" + fchrNameSpace + "'", "fIntOrderID");
        for (int i = 0; i < dw.Length; i++)
        {
            TreeNode pnd = new TreeNode();
            pnd.NavigateUrl = "CreateFormMenu_List.aspx?dirid=" + dw[i]["fchrFrmNameID"].ToString() + "&FLAG=0";
            pnd.Target = "middle";
            pnd.Text = dw[i][ftext].ToString();
            pnd.Value = dw[i]["fchrFrmNameID"].ToString();
            tn.ChildNodes.Add(pnd);
            GetTree(pnd, dw[i]["fchrFrmNameID"].ToString());
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PublicClass pc = new PublicClass();
            ftext = pc.GetLanguageForm();
            ctext = pc.GetLanguageColumn();
           
            ToLoadTree();
        }
    }

}
