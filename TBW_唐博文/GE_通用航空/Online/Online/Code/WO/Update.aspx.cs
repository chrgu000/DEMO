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

public partial class WO_Update : System.Web.UI.Page
{
    系统服务.ClsDES clsDES = 系统服务.ClsDES.Instance();
    ClsDataBase clsSQLCommond = new ClsDataBase();
    ASPxGridViewShow gridview = new ASPxGridViewShow();
    string sSQL;
    string tablename = "WO";
    string tablenames = "WOs";
    string tablecode = "WO";
    string sState = "";
    DataTable dtBingGrid;
    OpenWindow ow = new OpenWindow();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            YxBtn.HidFormID = "WOUpdate";
            //cal.ValueStart = DateTime.Now.AddMonths(-10).ToString("yyyy-MM-dd");
            //cal.ValueEnd = DateTime.Now.ToString("yyyy-MM-dd");
            GetTitle();
            SetEnabled(false);
        }
    }

    #region 标题
    private void GetTitle()
    {
        ASPxGridViewShow gridview = new ASPxGridViewShow();
        gridview.GetTitle(ASPxGridView1, tablenames);
    }
    #endregion

    
    protected void GetGrid()
    {
        if (LabiID.Text != "")
        {
            sSQL = @"select * from " + tablename + " a  where ID=" + LabiID.Text;

            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            if (dt.Rows.Count > 0)
            {
                LabiID.Text = dt.Rows[0]["ID"].ToString();

                sSQL = "select * from " + tablenames + " where ID=" + LabiID.Text + " order by AutoID";


                dtBingGrid = clsSQLCommond.ExecQuery(sSQL);
                ASPxGridView1.DataSource = dtBingGrid;

                SetEnabled(false);

                sState = "";
            }
            else
            {
                GetNull();
                SetEnabled(false);

            }
        }
        else
        {
            GetNull();
            SetEnabled(false);
        }
    }

    protected void ToSave(object sender, EventArgs e)
    {
        int iRe = CheState(LabiID.Text.Trim());
        if (iRe == -1)
        {
            ow.Alert("检查单据状态出错");
        }
        if (iRe == 0 && (sState == "edit" || sState == "alter"))
        {
            ow.Alert("单据不存在");
        }
        if (iRe == 1 && sState == "alter")
        {
            ow.Alert("单据未审核");
        }
        if (iRe == 2 && sState == "edit")
        {
            ow.Alert("单据已审核");
        }
        if (iRe == 3)
        {
            ow.Alert("单据已关闭");
        }

        string sErr = "";
        if (SelS1.Value.Trim() == "")
        {
            ow.Alert("委外供应商不能为空");
        }

        sSQL = "select isnull(max(AutoID)+1,1) as AutoID from " + tablenames;
        long sAutoID = long.Parse(clsSQLCommond.ExecQuery(sSQL).Rows[0][0].ToString());

        string iID = "";

        Sql sqlhead = new Sql();
        System.Collections.ArrayList aList = new System.Collections.ArrayList();

        if (sState == "add")
        {
            sSQL = "select isnull(isnull(max(ID),0)+1,1) as ID from " + tablename;
            iID = clsSQLCommond.ExecString(sSQL);
            sqlhead.Get(tablename, "iID", iID, true);
            sqlhead.ToString("iCode", SerialNumber.GetNewSerialNumberContinuous(tablename, tablecode));
        }
        else
        {
            sqlhead.Get(tablename, "iID", LabiID.Text.ToString().Trim(), false);
            iID = LabiID.Text.ToString();
        }
        //sqlhead.ToString("dDate", CaldDate.Value.ToString().Trim());
        sqlhead.ToString("cMemo", TextRemark.Text.ToString().Trim());

        if (sState == "add")
        {
            sqlhead.ToString("dCreatesysTime", 系统服务.ClsBaseDataInfo.sLogDate);
            sqlhead.ToString("dCreatesysPerson", 系统服务.ClsBaseDataInfo.sUid);
        }

        if (sState == "alter")
        {
            sqlhead.ToString("dChangeVerifyTime", 系统服务.ClsBaseDataInfo.sLogDate);
            sqlhead.ToString("dChangeVerifyPerson", 系统服务.ClsBaseDataInfo.sUid);
        }
        aList.Add(sqlhead.ReturnSql());

        #region 删行
        if (hidDel.Value != "")
        {
            string[] strdel = hidDel.Value.Trim().Split(',');
            for (int i = 0; i < strdel.Length; i++)
            {
                if (strdel[i].Trim() != "")
                {
                    sSQL = "delete  from " + tablenames + " where AutoID ='" + strdel[i] + "'";
                    aList.Add(sSQL);
                }
            }
        }

        #endregion

        #region 子表

        for (int i = 0; i < ASPxGridView1.VisibleRowCount; i++)
        {
            if (ASPxGridView1.GetRowValues(i,"iID") != "" )
            {
                #region 判断
                if (ASPxGridView1.GetRowValues(i,"S1") == "")
                {
                    continue;
                }
                #endregion

                #region 生成table
                Sql sql = new Sql();
                if (ASPxGridView1.GetRowValues(i, "iID").ToString().Trim() == "")
                {
                    sql.Get(tablenames, "AutoID", sAutoID,true);
                }
                else
                {
                    sql.Get(tablenames, "AutoID", sAutoID, false);
                }
                sql.ToString("iID", iID);
                sql.ToString("S1",ASPxGridView1.GetRowValues(i, "S1").ToString().Trim());
                
                aList.Add(sql.ReturnSql());
                sAutoID = sAutoID + 1;
                #endregion
            }
        }
        #endregion

        #region 表体不能为空
        bool b列表 = false;
        int bCount = 0;
        for (int i = 0; i < ASPxGridView1.VisibleRowCount; i++)
        {
            if (ASPxGridView1.GetRowValues(i, "S1").ToString().Trim() != "")
            {
                b列表 = true;
                bCount = bCount + 1;
            }
        }
        if (!b列表)
        {
            sErr = sErr + "表体不能为空";
        }

        if (sErr.Length != 0)
        {
            ow.Alert(sErr.ToString());
        }
        #endregion

        if (aList.Count > 0)
        {
            bool iCou = clsSQLCommond.ExecSqlTran(aList);
            ow.Alert("保存成功");
            LabiID.Text = iID;
            hidDel.Value = "";
            sState = "save";
            GetGrid();

        }
    }

    /// <summary>
    /// 判断单据状态
    /// </summary>
    /// <param name="sCode">单据号</param>
    /// <returns>-1：出错</returns>
    /// <returns>0 ：不存在单据</returns>
    /// <returns>1 ：已保存</returns>
    /// <returns>2 ：已审核</returns>
    /// <returns>3 ：已关闭</returns>
    private int CheState(string sCode)
    {
        int iReturn = -1;
        try
        {
            sSQL = "select  isnull(dCreatesysPerson,'') as 制单人,isnull(dVerifysysPerson,'') as 审核人,isnull(dClosesysPerson,'') as 关闭人 from " + tablename + " where " + tablecode + " = '" + sCode + "'";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt == null || dt.Rows.Count < 1)
                iReturn = 0;
            else
            {
                if (dt.Rows[0]["制单人"].ToString().Trim() != "")
                {
                    iReturn = 1;
                }
                if (dt.Rows[0]["审核人"].ToString().Trim() != "")
                {
                    iReturn = 2;
                }
                if (dt.Rows[0]["关闭人"].ToString().Trim() != "")
                {
                    iReturn = 3;
                }
            }
        }
        catch (Exception ee)
        { }
        return iReturn;
    }

    private void SetEnabled(bool b)
    {
        TextBox3.Enabled = b;
        ASPxGridView1.Enabled = b;
    }

    private void GetNull()
    {
        TextBox3.Text = "";

        ASPxGridView1.DataSource = null;
    }


    #region 按钮
    protected void ToSelect(object sender, EventArgs e)
    {
        GetGrid();
    }


    protected void ToNew(object sender, EventArgs e)
    {
        SetEnabled(true);
        sSQL = "select * from " + tablenames + " where 1=-1 order by AutoID";
        dtBingGrid = clsSQLCommond.ExecQuery(sSQL);
        ASPxGridView1.DataSource = dtBingGrid;
        ASPxGridView1.DataBind();
        sState = "add";
    }

    protected void ToEdit(object sender, EventArgs e)
    {
        sState = "edit";
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
    }
    #endregion

    #region ObjectDataSource
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        //e.InputParameters["S2"] = DropDownListS1.SelectedValue;
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
    #endregion

}

