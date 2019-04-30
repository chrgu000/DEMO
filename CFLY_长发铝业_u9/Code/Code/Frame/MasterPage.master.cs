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
using DevExpress.Web.ASPxMenu;
using System.Collections.Generic;
using System.Collections.Specialized;

public partial class MasterPage : System.Web.UI.MasterPage
{
    string sSQL = "";
    string uid = "";
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PublicClass pc = new PublicClass();
            string title = pc.GetCompany();
            compname.Text = title;
            Page.Title = title;
            if (Session["uID"].ToString() == "")
            {
                Response.Redirect("../Default.aspx");
            }
            if (Session["uID"].ToString() != "游客")
            {
                //GetMenu();
                BuildMenu(ASPxMenu1, false);
            }
            else
            {
                //GetMenu2();
            }
            if (Session["uName"].ToString() != "")
            {
                lblper.Text = "欢迎登录："+Session["uName"].ToString();
            }
        }
    }

    protected void BuildMenu(ASPxMenu menu,bool enableRoles)
    {
        // Get DataView
        DataSourceSelectArguments arg = new DataSourceSelectArguments();

        DataTable dt = List();

        DataRow[] row = dt.Select("fchrFrmUpName='O'", "fIntOrderID");
        for (int i = 0; i < row.Length; i++)
        {
            DevExpress.Web.ASPxMenu.MenuItem item =new DevExpress.Web.ASPxMenu.MenuItem();
            string fchrFrmNameID = row[i]["fchrFrmNameID"].ToString();
            string parentID = row[i]["fchrFrmUpName"].ToString();
            string fPath = row[i]["fPath"].ToString();
            string fchrFrmText = row[i]["fchrFrmText"].ToString();
            string fchrNameSpace = row[i]["fchrNameSpace"].ToString();
            item.Text = fchrFrmText;
            if (fPath != "")
            {
                item.NavigateUrl = "../" + fPath;
            }
            item.Name = fchrNameSpace;
            menu.Items.Add(item);
            CreateMenuItem(dt, item);
        }
        // Build Menu Items
        //Dictionary<string, DevExpress.Web.ASPxMenu.MenuItem> menuItems =
        //    new Dictionary<string, DevExpress.Web.ASPxMenu.MenuItem>();

        //for (int i = 0; i < dataView.Count; i++)
        //{
        //    DataRow row = dataView[i].Row;


        //    DevExpress.Web.ASPxMenu.MenuItem item = CreateMenuItem(row);
        //    string itemID = row["fchrFrmNameID"].ToString();
        //    string parentID = row["fchrFrmUpName"].ToString();

        //    if (menuItems.ContainsKey(parentID))
        //    {
        //        menuItems[parentID].Items.Add(item);

        //    }
        //    else
        //    {

        //        menu.Items.Add(item);
        //    }
        //    menuItems.Add(itemID, item);
        //}
    }
    private void CreateMenuItem(DataTable dt,DevExpress.Web.ASPxMenu.MenuItem itemparent)
    {
        DataRow[] row = dt.Select("fchrFrmUpName='" + itemparent.Name + "'", "fIntOrderID");
        for (int i = 0; i < row.Length; i++)
        {
            DevExpress.Web.ASPxMenu.MenuItem item = new DevExpress.Web.ASPxMenu.MenuItem();
            string fchrFrmNameID = row[i]["fchrFrmNameID"].ToString();
            string parentID = row[i]["fchrFrmUpName"].ToString();
            string fPath = row[i]["fPath"].ToString();
            string fchrFrmText = row[i]["fchrFrmText"].ToString();
            string fchrNameSpace = row[i]["fchrNameSpace"].ToString();
            item.Text = fchrFrmText;
            if (fPath != "")
            {
                item.NavigateUrl = "../" + fPath;
            }
            item.Name = fchrNameSpace;
            itemparent.Items.Add(item);
            //CreateMenuItem(dt, item);
        }
    }

    private DevExpress.Web.ASPxMenu.MenuItem CreateMenuItem(DataRow row)
    {
        DevExpress.Web.ASPxMenu.MenuItem ret = new DevExpress.Web.ASPxMenu.MenuItem();
        ret.Text = row["fchrFrmText"].ToString();
        if (row["fPath"].ToString() != "")
        {

            ret.NavigateUrl = "../" + row["fPath"].ToString();
        }
        //ret.Image.Url = row["ImageUrl"].ToString();
        return ret;
    }

//    private void GetMenu2()
//    {
//        ClsDataBase clsSQLCommond = new ClsDataBase();
//        try
//        {
//            uid = Session["uID"].ToString().Trim();

//            PublicClass pc = new PublicClass();
//            string btext = pc.GetLanguageForm();

//            string sSQL = @"SELECT  fchrFrmNameID,  fchrFrmText as fchrFrmText, fPath,fchrNameSpace,fchrFrmUpName,fIntOrderID,Flag  into #a FROM dbo._Form 
//WHERE 1=-1  ORDER BY fIntOrderID
//insert into #a(fchrFrmNameID,fchrFrmText,fPath,fchrNameSpace,fchrFrmUpName,fIntOrderID) values ('登陆','登陆','Login/Login.aspx','s','s','100000')
//insert into #a(fchrFrmNameID,fchrFrmText,fPath,fchrNameSpace,fchrFrmUpName,fIntOrderID) values ('厂务报修','厂务报修','CW/Update.aspx','s','s','100001')
//select * from #a";

//            dt = clsSQLCommond.ExecQuery(sSQL);

//            DataTable dttop = Tables.SelectTable(dt, new string[,] { { "fchrFrmUpName", "s" } }, "fIntOrderID");

//            rpItemList.DataSource = dttop;
//            rpItemList.DataBind();


//        }
//        catch (Exception ee)
//        {
//            throw new Exception(ee.Message);
//        }
//    }

    //private void GetMenu()
    //{
    //    ClsDataBase clsSQLCommond = new ClsDataBase();
    //    try
    //    {
    //        uid = Session["uID"].ToString().Trim();

    //        PublicClass pc = new PublicClass();
    //        string btext = pc.GetLanguageForm();

    //        string sSQL2 = @"select count(*) from dbo._UserRoleInfo where vchrRoleID = 'administrator' and vchrUserID = '" + uid + "'";

    //        if (uid == "admin" || uid == "system")
    //        {
    //            sSQL = "SELECT  fchrFrmNameID, " + btext + " as fchrFrmText, fPath, savePath, backPath, newPath, selPath, fchrNameSpace, fchrFrmUpName, fbitHide, fbitNoUse, fIntOrderID,  fImage, vchrFormBel, bSystem, bUse, delPath,Flag FROM dbo._Form WHERE (1 = 1) AND (fbitNoUse = 0) AND (fbitHide = 0) and (vchrFormBel='' or vchrFormBel is null)  ORDER BY fIntOrderID";
    //        }
    //        else if (clsSQLCommond.Int(sSQL2) != 0)
    //        {
    //            sSQL = "SELECT  fchrFrmNameID,  " + btext + " as fchrFrmText, fPath, savePath, backPath, newPath, selPath, fchrNameSpace, fchrFrmUpName, fbitHide, fbitNoUse, fIntOrderID,  fImage, vchrFormBel, bSystem,  bUse, delPath,Flag FROM dbo._Form WHERE (isnull(bUse,0) = 1) AND (fbitNoUse = 0) AND (fbitHide = 0) and (vchrFormBel='' or vchrFormBel is null)  ORDER BY fIntOrderID";
    //        }
    //        else
    //        {
    //            sSQL = "SELECT DISTINCT " +
    //                        "      dbo._Form.fchrFrmNameID, dbo._Form. " + btext + " as fchrFrmText, dbo._Form.fchrNameSpace,  " +
    //                        "	  dbo._Form.fchrFrmUpName,  " +
    //                        "      dbo._Form.fbitHide, dbo._Form.fbitNoUse, dbo._Form.fIntOrderID,dbo._Form.fPath,Flag " +
    //                        "FROM         dbo._RoleInfo INNER JOIN " +
    //                        "      dbo._RoleRight ON dbo._RoleInfo.vchrRoleID = dbo._RoleRight.vchrRoleID INNER JOIN " +
    //                        "      dbo._UserRoleInfo ON dbo._RoleInfo.vchrRoleID = dbo._UserRoleInfo.vchrRoleID and dbo._UserRoleInfo.vchrUserID='" + uid + "' INNER JOIN " +
    //                        "      dbo._Form ON 1=1 " +
    //                        "		 AND dbo._Form.fchrFrmNameID = RTRIM(LTRIM(RIGHT(dbo._RoleRight.vchrRoleRight, LEN(dbo._RoleRight.vchrRoleRight) - CHARINDEX('|', dbo._RoleRight.vchrRoleRight)))) " +
    //                        "WHERE (isnull(bUse,0) = 1) AND (fbitNoUse = 0) AND (fbitHide = 0) and (vchrFormBel='' or vchrFormBel is null)  " +
    //                        "ORDER BY fIntOrderID ";
    //        }
    //        dt = clsSQLCommond.ExecQuery(sSQL);

    //        DataTable dttop = Tables.SelectTable(dt, new string[,] { { "fchrFrmUpName", "s" } }, "fIntOrderID");

    //        rpItemList.DataSource = dttop;
    //        rpItemList.DataBind();


    //    }
    //    catch (Exception ee)
    //    {
    //        throw new Exception(ee.Message);
    //    }
    //}

    public DataTable List()
    {
        ClsDataBase clsSQLCommond = new ClsDataBase();
        uid = Session["uID"].ToString().Trim();

        PublicClass pc = new PublicClass();
        string btext = pc.GetLanguageForm();

        string sSQL2 = @"select count(*) from dbo._UserRoleInfo where vchrRoleID = 'administrator' and vchrUserID = '" + uid + "'";

        if (uid == "admin" || uid == "system")
        {
            sSQL = "SELECT  fchrFrmNameID, " + btext + " as fchrFrmText, fPath, savePath, backPath, newPath, selPath, fchrNameSpace, fchrFrmUpName, fbitHide, fbitNoUse, fIntOrderID,  fImage, vchrFormBel, bSystem, bUse, delPath,Flag FROM dbo._Form WHERE (1 = 1) AND (fbitNoUse = 0) AND (fbitHide = 0) and (vchrFormBel='' or vchrFormBel is null)  ORDER BY fIntOrderID";
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
                        "WHERE (isnull(bUse,0) = 1)  AND (fbitNoUse = 0) AND (fbitHide = 0) and (vchrFormBel='' or vchrFormBel is null)  " +
                        "ORDER BY fIntOrderID ";
        }
        return  clsSQLCommond.ExecQuery(sSQL);
    }
    //protected void rpItemList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    //{
    //    if (uid != "游客")
    //    {
    //        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
    //        {
    //            ClsDataBase clsSQLCommond = new ClsDataBase();
    //            Repeater rep = (Repeater)e.Item.FindControl("rpItemList2");
    //            HiddenField hidid = (HiddenField)e.Item.FindControl("hidid");
    //            PublicClass pc = new PublicClass();
    //            string btext = pc.GetLanguageForm();

    //            string sSQL2 = @"select count(*) from dbo._UserRoleInfo where vchrRoleID = 'administrator' and vchrUserID = '" + uid + "'";

    //            if (uid == "admin" || uid == "system")
    //            {
    //                sSQL = "SELECT  fchrFrmNameID, " + btext + " as fchrFrmText, fPath, savePath, backPath, newPath, selPath, fchrNameSpace, fchrFrmUpName, fbitHide, fbitNoUse, fIntOrderID,  fImage, vchrFormBel, bSystem, bUse, delPath,Flag FROM dbo._Form WHERE (1 = 1) AND (fbitNoUse = 0) AND (fbitHide = 0) and (vchrFormBel='' or vchrFormBel is null) and fchrFrmUpName='" + hidid.Value + "'  ORDER BY fIntOrderID";
    //            }
    //            else if (clsSQLCommond.Int(sSQL2) != 0)
    //            {
    //                sSQL = "SELECT  fchrFrmNameID,  " + btext + " as fchrFrmText, fPath, savePath, backPath, newPath, selPath, fchrNameSpace, fchrFrmUpName, fbitHide, fbitNoUse, fIntOrderID,  fImage, vchrFormBel, bSystem,  bUse, delPath,Flag FROM dbo._Form WHERE (isnull(bUse,0) = 1) AND (fbitNoUse = 0) AND (fbitHide = 0) and (vchrFormBel='' or vchrFormBel is null) and fchrFrmUpName='" + hidid.Value + "'  ORDER BY fIntOrderID";
    //            }
    //            else
    //            {
    //                sSQL = "SELECT DISTINCT " +
    //                            "      dbo._Form.fchrFrmNameID, dbo._Form. " + btext + " as fchrFrmText, dbo._Form.fchrNameSpace,  " +
    //                            "	  dbo._Form.fchrFrmUpName,  " +
    //                            "      dbo._Form.fbitHide, dbo._Form.fbitNoUse, dbo._Form.fIntOrderID,dbo._Form.fPath,Flag " +
    //                            "FROM         dbo._RoleInfo INNER JOIN " +
    //                            "      dbo._RoleRight ON dbo._RoleInfo.vchrRoleID = dbo._RoleRight.vchrRoleID INNER JOIN " +
    //                            "      dbo._UserRoleInfo ON dbo._RoleInfo.vchrRoleID = dbo._UserRoleInfo.vchrRoleID and dbo._UserRoleInfo.vchrUserID='" + uid + "' INNER JOIN " +
    //                            "      dbo._Form ON 1=1 " +
    //                            "		 AND dbo._Form.fchrFrmNameID = RTRIM(LTRIM(RIGHT(dbo._RoleRight.vchrRoleRight, LEN(dbo._RoleRight.vchrRoleRight) - CHARINDEX('|', dbo._RoleRight.vchrRoleRight)))) " +
    //                            "WHERE (isnull(bUse,0) = 1) AND (fbitNoUse = 0) AND (fbitHide = 0) and (vchrFormBel='' or vchrFormBel is null) and fchrFrmUpName='" + hidid.Value + "' " +
    //                            "ORDER BY fIntOrderID ";
    //            }
    //            DataTable dts = clsSQLCommond.ExecQuery(sSQL);


    //            rep.DataSource = dts;
    //            rep.DataBind();
    //        }
    //    }
    //}
}
