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
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxEditors;
using System.Text;

public partial class Share_Select : System.Web.UI.Page
{
    ClsDataBase clsSQLCommond = new ClsDataBase();
    string sSQL = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //Ajax.Utility.RegisterTypeForAjax(typeof(AjaxMethod));
        if (!Page.IsPostBack)
        {
            //sel1.Style.Add("height", "300px");
            //ListBox1.Attributes.Add("ondblclick", "javascript:sendback();");
            //sel1.Attributes.Add("ondblclick", "javascript:sendback();");
            if (Request.QueryString["id"] != "" && Request.QueryString["id"] != null && Request.QueryString["id"].ToString() != "null")
            {
                ASPxTextBox1.Value = Request.QueryString["id"].ToString();
            }

        }
        GetBind();
    }

    public void GetBind()
    {
        Remove();
        if (Request.QueryString["flag"] != "" && Request.QueryString["flag"] != null)
        {
            string flag = Request.QueryString["flag"].ToString();
            if (flag == "cInv")
            {
                GetcInv();
            }
            else if (flag == "cCus")
            {
                GetcCus();
            }
        }
        GridViewDataColumn column1 = ASPxGridViewSel.Columns[0] as GridViewDataColumn;
        for (int i = 0; i < ASPxGridViewSel.VisibleRowCount; i++)
        {
            CheckBox chk = (CheckBox)ASPxGridViewSel.FindRowCellTemplateControl(i, column1, "CheckBox1");
            if (chk != null)
            {
                chk.Attributes.Add("onchange", "javascript:CheckBoxChange('" + chk.ClientID + "')");
            }
        }
    }

    public void GetcInv()
    {
        sSQL = "select  cInvCCode as iID, cInvCName as iName from viewInvClass where 1=1 ";
        if (ASPxTextBox1.Text != "")
        {
            sSQL = sSQL + " and (cInvCCode like '%" + ASPxTextBox1.Text + "%' or cInvCName like '%" + ASPxTextBox1.Text + "%')";
        }
        sSQL = sSQL + " and ((len(cInvCCode)=4 and cInvCCode like '02%') or cInvCCode='04' ) group by cInvCCode,cInvCName";
        ASPxGridViewSel.DataSource = clsSQLCommond.ExecQuery(sSQL);
        ASPxGridViewSel.DataBind();

    }

    public void GetcCus()
    {
        sSQL = "select  cCusCode as iID, cCusName as iName from viewCus where 1=1 ";
        if (ASPxTextBox1.Text != "")
        {
            sSQL = sSQL + " and (cCusCode like '%" + ASPxTextBox1.Text + "%' or cCusName like '%" + ASPxTextBox1.Text + "%')";
        }

        ASPxGridViewSel.DataSource = clsSQLCommond.ExecQuery(sSQL);
        ASPxGridViewSel.DataBind();

    }


    private void Remove()
    {
        for (int i = ASPxGridViewSel.Columns.Count - 1; i > 3; i--)
        {
            ASPxGridViewSel.Columns.Remove(ASPxGridViewSel.Columns[i]);
        }
    }

    protected void btnSelect_Click(object sender, EventArgs e)
    {
        GetBind();
    }
    protected void ASPxGridViewSel_PageIndexChanged(object sender, EventArgs e)
    {
        GridViewDataColumn column1 = ASPxGridViewSel.Columns[0] as GridViewDataColumn;
        for (int i = 0; i < ASPxGridViewSel.VisibleRowCount; i++)
        {
            CheckBox chk = (CheckBox)ASPxGridViewSel.FindRowCellTemplateControl(i, column1, "CheckBox1");
            if (chk != null)
            {
                chk.Attributes.Add("onchange", "javascript:CheckBoxChange('" + chk.ClientID + "')");
            }
        }
    }
}
