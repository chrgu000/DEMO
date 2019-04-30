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
using Ajax;

public partial class Frame_Left : System.Web.UI.Page
{
    string sSQL;
    DataTable dtl;
    DataTable dt;
    ClsDataBase clsSQLCommond = new ClsDataBase();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            AjaxPro.Utility.RegisterTypeForAjax(typeof(AjaxMethod));
            if (Session["uID"].ToString() != null && Session["uID"].ToString() != "")
            {
                try
                {
                    if (Request.QueryString["iID"] != null && Request.QueryString["iID"].ToString() != "")
                    {
                        string fiID = Request.QueryString["iID"].ToString();
                        #region
                        string uid = Session["uID"].ToString().Trim();
                        sSQL = "select vchrUid,vchrName from _UserInfo where vchrUid='" + uid + "'";
                        dtl = clsSQLCommond.ExecQuery(sSQL);
                        if (dtl.Rows.Count > 0)
                        {
                            DataTable dtt = new DataTable();
                            dtt.Columns.Add("Rights");
                            dtt.Columns.Add("Name");

                            PublicClass pc = new PublicClass();

                            string btext = pc.GetLanguageForm(); 

                            string sSQL2 = @"select count(*) from dbo._UserRoleInfo where vchrRoleID = 'administrator' and vchrUserID = '" + uid + "'";

                            if (uid == "admin" || uid == "system")
                            {
                                sSQL = "SELECT  fchrFrmNameID, " + btext + " as fchrFrmText, fPath, savePath, backPath, newPath, selPath, fchrNameSpace, fchrFrmUpName, fbitHide, fbitNoUse, fIntOrderID,  fImage, vchrFormBel, bSystem, tstamp, bUse, delPath FROM dbo._Form WHERE (1 = 1) AND (fbitNoUse = 0) AND (fbitHide = 0) and (vchrFormBel='' or vchrFormBel is null)  ORDER BY fIntOrderID";
                            }
                            else if (clsSQLCommond.Int(sSQL2) != 0)
                            {
                                sSQL = "SELECT  fchrFrmNameID,  " + btext + " as fchrFrmText, fPath, savePath, backPath, newPath, selPath, fchrNameSpace, fchrFrmUpName, fbitHide, fbitNoUse, fIntOrderID,  fImage, vchrFormBel, bSystem, tstamp, bUse, delPath FROM dbo._Form WHERE (isnull(bUse,0) = 1) AND (fbitNoUse = 0) AND (fbitHide = 0) and (vchrFormBel='' or vchrFormBel is null)  ORDER BY fIntOrderID";
                            }
                            else
                            {
                                sSQL = "SELECT DISTINCT " +
                                            "      dbo._Form.fchrFrmNameID, dbo._Form. " + btext + " as fchrFrmText, dbo._Form.fchrNameSpace,  " +
                                            "	  dbo._Form.fchrFrmUpName,  " +
                                            "      dbo._Form.fbitHide, dbo._Form.fbitNoUse, dbo._Form.fIntOrderID,dbo._Form.fPath " +
                                            "FROM         dbo._RoleInfo INNER JOIN " +
                                            "      dbo._RoleRight ON dbo._RoleInfo.vchrRoleID = dbo._RoleRight.vchrRoleID INNER JOIN " +
                                            "      dbo._UserRoleInfo ON dbo._RoleInfo.vchrRoleID = dbo._UserRoleInfo.vchrRoleID and dbo._UserRoleInfo.vchrUserID='" + uid + "' INNER JOIN " +
                                            "      dbo._Form ON 1=1 " +
                                            "		 AND dbo._Form.fchrFrmNameID = RTRIM(LTRIM(RIGHT(dbo._RoleRight.vchrRoleRight, LEN(dbo._RoleRight.vchrRoleRight) - CHARINDEX('|', dbo._RoleRight.vchrRoleRight)))) " +
                                            "WHERE (isnull(bUse,0) = 1) AND (fbitNoUse = 0) AND (fbitHide = 0) and (vchrFormBel='' or vchrFormBel is null)  " +
                                            "ORDER BY fIntOrderID ";
                            }
                            dt = clsSQLCommond.ExecQuery(sSQL);

                            DataTable dttop = Tables.SelectTable(dt, new string[,] { { "fchrFrmUpName", fiID } }, "fIntOrderID");

                            //sSQL = "select fchrFrmText as Name,fchrFrmNameID as Rights  from _Form where fchrFrmUpName='s'   order by fIntOrderID";
                            //DataTable dttop = clsSQLCommond.ExecQuery(sSQL);

                            rpItemList.DataSource = dttop;
                            rpItemList.DataBind();

                            if (dttop.Rows.Count == 0)
                            {
                                //ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>Show_Hide_Menu(2);</script>");
                                Response.Write("<script type='text/javascript'>window.top.document.frames.frm.cols = '0,*';</script>");
                            }
                            else
                            {
                                //ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>Show_Hide_Menu(1);</script>");
                                Response.Write("<script type='text/javascript'>window.top.document.frames.frm.cols = '220,*';</script>");
                            }
                        }
                    }
                   
                    #endregion
                }
                catch (Exception ee)
                {
                    throw new Exception(ee.Message);
                }
            }
        }
    }
}
