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

public partial class MasterPage : System.Web.UI.MasterPage
{
    string sSQL = "";
    string uid = "";
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        PublicClass pc = new PublicClass();

        Page.Title = pc.GetCompany();
        compname.InnerHtml = pc.GetCompany();
        if (Session["uID"].ToString() == "")
        {
            Response.Redirect("../Default.aspx");
        }
        GetMenu();
    }


    private void GetMenu()
    {
        ClsDataBase clsSQLCommond = new ClsDataBase();
        try
        {
            uid = Session["uID"].ToString().Trim();

            PublicClass pc = new PublicClass();
            string btext = pc.GetLanguageForm();

            string sSQL2 = @"select count(*) from dbo._UserRoleInfo where vchrRoleID = 'administrator' and vchrUserID = '" + uid + "'";

            if (uid == "admin" || uid == "system")
            {
                sSQL = "SELECT  fchrFrmNameID, " + btext + " as fchrFrmText, fPath, savePath, backPath, newPath, selPath, fchrNameSpace, fchrFrmUpName, fbitHide, fbitNoUse, fIntOrderID,  fImage, vchrFormBel, bSystem, tstamp, bUse, delPath,Flag FROM dbo._Form WHERE (1 = 1) AND (fbitNoUse = 0) AND (fbitHide = 0) and (vchrFormBel='' or vchrFormBel is null)  ORDER BY fIntOrderID";
            }
            else if (clsSQLCommond.Int(sSQL2) != 0)
            {
                sSQL = "SELECT  fchrFrmNameID,  " + btext + " as fchrFrmText, fPath, savePath, backPath, newPath, selPath, fchrNameSpace, fchrFrmUpName, fbitHide, fbitNoUse, fIntOrderID,  fImage, vchrFormBel, bSystem, tstamp, bUse, delPath,Flag FROM dbo._Form WHERE (isnull(bUse,0) = 1) AND (fbitNoUse = 0) AND (fbitHide = 0) and (vchrFormBel='' or vchrFormBel is null)  ORDER BY fIntOrderID";
            }
            else
            {
                sSQL = "SELECT DISTINCT " +
                            "      dbo._Form.fchrFrmNameID, dbo._Form. " + btext + " as fchrFrmText, dbo._Form.fchrNameSpace,  " +
                            "	  dbo._Form.fchrFrmUpName,  " +
                            "      dbo._Form.fbitHide, dbo._Form.fbitNoUse, dbo._Form.fIntOrderID,dbo._Form.fPath,Flag " +
                            "FROM         dbo._RoleInfo INNER JOIN " +
                            "      dbo._RoleRight ON dbo._RoleInfo.vchrRoleID = dbo._RoleRight.vchrRoleID INNER JOIN " +
                            "      dbo._UserRoleInfo ON dbo._RoleInfo.vchrRoleID = dbo._UserRoleInfo.vchrRoleID and dbo._UserRoleInfo.vchrUserID='" + uid + "' INNER JOIN " +
                            "      dbo._Form ON 1=1 " +
                            "		 AND dbo._Form.fchrFrmNameID = RTRIM(LTRIM(RIGHT(dbo._RoleRight.vchrRoleRight, LEN(dbo._RoleRight.vchrRoleRight) - CHARINDEX('|', dbo._RoleRight.vchrRoleRight)))) " +
                            "WHERE (isnull(bUse,0) = 1) AND (fbitNoUse = 0) AND (fbitHide = 0) and (vchrFormBel='' or vchrFormBel is null)  " +
                            "ORDER BY fIntOrderID ";
            }
            dt = clsSQLCommond.ExecQuery(sSQL);

            DataTable dttop = Tables.SelectTable(dt, new string[,] { { "fchrFrmUpName", "s" } }, "fIntOrderID");

            rpItemList.DataSource = dttop;
            rpItemList.DataBind();


        }
        catch (Exception ee)
        {
            throw new Exception(ee.Message);
        }
    }
    protected void rpItemList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            ClsDataBase clsSQLCommond = new ClsDataBase();
            Repeater rep = (Repeater)e.Item.FindControl("rpItemList2");
            HiddenField hidid=(HiddenField)e.Item.FindControl("hidid");
            PublicClass pc = new PublicClass();
            string btext = pc.GetLanguageForm();

            string sSQL2 = @"select count(*) from dbo._UserRoleInfo where vchrRoleID = 'administrator' and vchrUserID = '" + uid + "'";

            if (uid == "admin" || uid == "system")
            {
                sSQL = "SELECT  fchrFrmNameID, " + btext + " as fchrFrmText, fPath, savePath, backPath, newPath, selPath, fchrNameSpace, fchrFrmUpName, fbitHide, fbitNoUse, fIntOrderID,  fImage, vchrFormBel, bSystem, tstamp, bUse, delPath,Flag FROM dbo._Form WHERE (1 = 1) AND (fbitNoUse = 0) AND (fbitHide = 0) and (vchrFormBel='' or vchrFormBel is null) and fchrFrmUpName='" + hidid.Value + "'  ORDER BY fIntOrderID";
            }
            else if (clsSQLCommond.Int(sSQL2) != 0)
            {
                sSQL = "SELECT  fchrFrmNameID,  " + btext + " as fchrFrmText, fPath, savePath, backPath, newPath, selPath, fchrNameSpace, fchrFrmUpName, fbitHide, fbitNoUse, fIntOrderID,  fImage, vchrFormBel, bSystem, tstamp, bUse, delPath,Flag FROM dbo._Form WHERE (isnull(bUse,0) = 1) AND (fbitNoUse = 0) AND (fbitHide = 0) and (vchrFormBel='' or vchrFormBel is null) and fchrFrmUpName='" + hidid.Value + "'  ORDER BY fIntOrderID";
            }
            else
            {
                sSQL = "SELECT DISTINCT " +
                            "      dbo._Form.fchrFrmNameID, dbo._Form. " + btext + " as fchrFrmText, dbo._Form.fchrNameSpace,  " +
                            "	  dbo._Form.fchrFrmUpName,  " +
                            "      dbo._Form.fbitHide, dbo._Form.fbitNoUse, dbo._Form.fIntOrderID,dbo._Form.fPath,Flag " +
                            "FROM         dbo._RoleInfo INNER JOIN " +
                            "      dbo._RoleRight ON dbo._RoleInfo.vchrRoleID = dbo._RoleRight.vchrRoleID INNER JOIN " +
                            "      dbo._UserRoleInfo ON dbo._RoleInfo.vchrRoleID = dbo._UserRoleInfo.vchrRoleID and dbo._UserRoleInfo.vchrUserID='" + uid + "' INNER JOIN " +
                            "      dbo._Form ON 1=1 " +
                            "		 AND dbo._Form.fchrFrmNameID = RTRIM(LTRIM(RIGHT(dbo._RoleRight.vchrRoleRight, LEN(dbo._RoleRight.vchrRoleRight) - CHARINDEX('|', dbo._RoleRight.vchrRoleRight)))) " +
                            "WHERE (isnull(bUse,0) = 1) AND (fbitNoUse = 0) AND (fbitHide = 0) and (vchrFormBel='' or vchrFormBel is null) and fchrFrmUpName='" + hidid.Value + "' " +
                            "ORDER BY fIntOrderID ";
            }
            DataTable  dts = clsSQLCommond.ExecQuery(sSQL);


            rep.DataSource = dts;
            rep.DataBind();
        }
    }
}
