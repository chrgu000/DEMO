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

public partial class WO_WOSPUpdate : System.Web.UI.Page
{
    ClsDataBase clsSQLCommond = new ClsDataBase();
    string sSQL;
    DataTable dt;
    ASPxGridViewShow gridview = new ASPxGridViewShow();
    string tablename = "SP";
    string tableid = "iID";
    #region 加载页面
    protected void Page_Load(object sender, EventArgs e)
    {
        AjaxPro.Utility.RegisterTypeForAjax(typeof(WOSPAjaxMethod));
        if (!IsPostBack)
        {
            YxBtn.HidFormID = "WOUpdate";
            YxBtn.GetViewState(divSel);
            
            Bind();

            YxBtn.BtnSave.Visible = true;
            if (Request.QueryString["iType"] != "" && Request.QueryString["iType"] != null)
            {
                hidiType.Value = Request.QueryString["iType"].ToString();
            }
            if (Request.QueryString["iID"] != "" && Request.QueryString["iID"] != null)
            {
                YxBtn.HidID = Request.QueryString["iID"].ToString();
                UpdateBind2();
                UpdateBind();
                
            }
            else
            {
                UpdateBind2();
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
        //WOSPAjaxMethod ajaxM = new WOSPAjaxMethod();
        //bool b = ajaxM.IsDelete(dt.Rows[0]["S1"].ToString());
        gridview.GetUpdate(TableUpdate1, tablename, dt, "", false);
    }

    private void UpdateBind2()
    {
        sSQL = "select * from WO where " + tableid + "=" + hidiType.Value + "";
        DataTable dt = clsSQLCommond.ExecQuery(sSQL);
        //wosp ajaxM = new WOAjaxMethod();
        //bool b = ajaxM.IsDelete(dt.Rows[0]["S1"].ToString());
        GetUpdate(TableUpdate1, "WO", dt, "", true);
    }
    public void GetUpdate(HtmlTable TableUpdate1, string tablename, DataTable dts, string bCol, bool bRed)
    {
        PublicClass pc = new PublicClass();
        string ctext = pc.GetLanguageColumn();
        string h = "";
        PublicData pd = new PublicData();
        ControlsClass cc = new ControlsClass();
        sSQL = "select * from  _TableColInfo where  TABLE_NAME in ('" + tablename + "')  order by UpdateVisibleIndex";
        DataTable dt = clsSQLCommond.ExecQuery(sSQL);
        bool b = true;
        if (dts == null || dts.Rows.Count == 0)
        {
            b = false;
        }
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            HtmlTableRow tw = new HtmlTableRow();
            if (dt.Rows[i]["UpdateVisibleIndex"].ToString().Trim() == "")
            {
                tw.Style.Add("display", "none");
            }
            string coltext = "";
            if (dt.Rows[i]["ShowCol"].ToString().Trim() != "")
            {
                coltext = dt.Rows[i]["ShowCol"].ToString();
            }
            else
            {
                coltext = dt.Rows[i]["COLUMN_Text"].ToString();
            }
            //if (dt.Rows[i]["IsInput"].ToString() == "*")
            //{
            //    coltext = "<label id='lbltitle_" + dt.Rows[i]["COLUMN_NAME"].ToString() + "'>" + coltext + "</label><label id='lblisinput_" + dt.Rows[i]["COLUMN_NAME"].ToString() + "'>*</label>";
            //}
            //else
            //{
            coltext = "<label id='lbltitle_" + dt.Rows[i]["COLUMN_NAME"].ToString() + "'>" + coltext + "</label>";
            //}
            HtmlTableCell tclabel = new HtmlTableCell();
            tclabel.Style.Add("font-weight", "bold");
            tclabel.InnerHtml = coltext;
            HtmlTableCell tc = new HtmlTableCell();
            string value = "";
            if (dts != null && dts.Rows.Count > 0)
            {
                value = dts.Rows[0][dt.Rows[i]["COLUMN_NAME"].ToString()].ToString();
            }
            string col = dt.Rows[i]["COLUMN_NAME"].ToString();
            Label label = new Label();
            switch (dt.Rows[i]["UpdateType"].ToString())
            {
                case "textbox":

                    label.ID = "text" + dt.Rows[i]["COLUMN_NAME"].ToString();
                    if (b)
                    {
                        label.Text = value;
                    }
                    tc.Controls.Add(label);
                    break;
                case "label":
                    label.ID = "label" + dt.Rows[i]["COLUMN_NAME"].ToString();
                    if (b)
                    {
                        label.Text = value;
                    }
                    tc.Controls.Add(label);
                    break;
                case "select":

                    switch (dt.Rows[i]["ColSel"].ToString().Trim())
                    {
                        case "LookUpData":
                            string iType = dt.Rows[i]["ColSelFlag"].ToString();
                            if (iType != "")
                            {
                                value = pd.GetLookUpData(iType, value);
                            }
                            break;
                        case "Equip":
                            value = pd.GetEquip(value);
                            break;
                        case "EquipType":
                            value = pd.GetEquipType(value);
                            break;
                        case "Inventory":
                            value = pd.GetInventory(value);
                            break;
                        case "Machine":
                            value = pd.GetMachine(value);
                            break;
                        case "Worker":
                            value = pd.GetWorkers(value);
                            break;
                        case "LookUpType":
                            value = pd.GetLookUpType(value);
                            break;
                        default:
                            value = "";
                            break;
                    }
                    label.Text = value;
                    tc.Controls.Add(label);
                    break;
                case "date":
                    if (value != "")
                    {
                        value = DateTime.Parse(value).ToString("yyyy-MM-dd");
                    }
                    label.Text = value;
                    tc.Controls.Add(label);
                    break;
                default:
                    label.Text = value;
                    tc.Controls.Add(label);
                    break;
            }
            tw.Cells.Add(tclabel);
            tw.Cells.Add(tc);
            TableUpdate1.Controls.Add(tw);
        }

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

