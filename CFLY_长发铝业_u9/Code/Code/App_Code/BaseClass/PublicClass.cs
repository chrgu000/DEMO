using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;


/// <summary>
/// ParameterSqlClass 的摘要说明
/// </summary>
public class PublicClass : System.Web.UI.Page
{
    private DataTable dt;
    private string sSQL;
    ClsDataBase clsSQLCommond = new ClsDataBase();
    public PublicClass()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public string GetCompany()
    {
        sSQL = "select top 1 strName from _Company ";
        return clsSQLCommond.ExecStringWithoutSession(sSQL);
    }

    public string GetLanguage()
    {
        sSQL = "select vlanguage from _UserInfo where vchrUid='" + HttpContext.Current.Session["uID"].ToString() + "'";
        string vlanguage = clsSQLCommond.ExecString(sSQL);
        if (vlanguage == "" || vlanguage == "1")
        {
            return "1";
        }
        else
        {
            return "";
        }
    }

    public string GetLanguageForm()
    {
        sSQL = "select vlanguage from _UserInfo where vchrUid='" + HttpContext.Current.Session["uID"].ToString() + "'";
        string vlanguage = clsSQLCommond.ExecString(sSQL);
        if (vlanguage == "" || vlanguage == "1")
        {
            return "fchrFrmText";
        }
        else if (vlanguage == "2")
        {
            return "fchrFrmText2";
        }
        return "";
    }

    public string GetLanguageColumn()
    {
        sSQL = "select vlanguage from _UserInfo where vchrUid='" + HttpContext.Current.Session["uID"].ToString() + "'";
        string vlanguage = clsSQLCommond.ExecString(sSQL);
        if (vlanguage == "" || vlanguage == "1")
        {
            return "COLUMN_Text";
        }
        else if (vlanguage == "2")
        {
            return "COLUMN_Text2";
        }
        return "";
    }

    public string GetLanguageLookUpData()
    {
        sSQL = "select vlanguage from _UserInfo where vchrUid='" + HttpContext.Current.Session["uID"].ToString() + "'";
        string vlanguage = clsSQLCommond.ExecString(sSQL);
        if (vlanguage == "" || vlanguage == "1")
        {
            return "iText";
        }
        else if (vlanguage == "2")
        {
            return "iText2";
        }
        return "";
    }

    public string GetLanguageLookUpType()
    {
        sSQL = "select vlanguage from _UserInfo where vchrUid='" + HttpContext.Current.Session["uID"].ToString() + "'";
        string vlanguage = clsSQLCommond.ExecString(sSQL);
        if (vlanguage == "" || vlanguage == "1")
        {
            return "iType";
        }
        else if (vlanguage == "2")
        {
            return "iType2";
        }
        return "";
    }

    public string GetLanguageBtn()
    {
        sSQL = "select vlanguage from _UserInfo where vchrUid='" + HttpContext.Current.Session["uID"].ToString() + "'";
        string vlanguage = clsSQLCommond.ExecString(sSQL);
        if (vlanguage == "" || vlanguage == "1")
        {
            return "vchrBtnText";
        }
        else if (vlanguage == "2")
        {
            return "vchrBtnText2";
        }
        return "";
    }

    public string GetLanguageAlert()
    {
        sSQL = "select vlanguage from _UserInfo where vchrUid='" + HttpContext.Current.Session["uID"].ToString() + "'";
        string vlanguage = clsSQLCommond.ExecString(sSQL);
        if (vlanguage == "" || vlanguage == "1")
        {
            return "Text";
        }
        else if (vlanguage == "2")
        {
            return "Text2";
        }
        return "";
    }


    //public void GetSmartGridViewSheet(YYControls.SmartGridView SmartGridView1)
    //{
    //    string ctext = GetLanguageColumn();
    //    if (ctext == "COLUMN_Text2")
    //    {
    //        SmartGridView1.CustomPagerSettings.TextFormat = "PageSize {0}/Records Count{1} || No.  {2}/Page Count  {3}";
    //        SmartGridView1.PagerSettings.FirstPageText = "FirstPage";
    //        SmartGridView1.PagerSettings.PreviousPageText = "PreviousPage";
    //        SmartGridView1.PagerSettings.NextPageText = "NextPage";
    //        SmartGridView1.PagerSettings.LastPageText = "LastPage";
    //    }
    //    else
    //    {
    //        SmartGridView1.CustomPagerSettings.TextFormat = "每页{0}条/共{1}条||第{2}页/共{3}页";
    //        SmartGridView1.PagerSettings.FirstPageText = "首页";
    //        SmartGridView1.PagerSettings.PreviousPageText = "上一页";
    //        SmartGridView1.PagerSettings.NextPageText = "下一页";
    //        SmartGridView1.PagerSettings.LastPageText = "末页";
    //    }
    //}
    /// <summary>
    /// 1.不可为空
    /// 2.确认删除吗
    /// 3.请扫描需要登出的标签
    /// 4.卡认证失败，无卡或卡片已读过
    /// 5.条已删除
    /// 6.身份证号错误
    /// 7.不可删除
    /// 8.删除失败
    /// 9.未设置该功能
    /// 10.手机或电话号码错误
    /// 11.是否为整数
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public string GetAlert(int i)
    {
        string salt= GetLanguageAlert();
        sSQL = "select " + salt + " from  _AlertLabels where iID=" + i;
        return clsSQLCommond.ExecString(sSQL);
    }
}
