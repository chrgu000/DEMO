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


public partial class Frame_Right : System.Web.UI.Page
{
    OjbData od = new OjbData();
    protected void Page_Load(object sender, EventArgs e)
    {
        //Response.Redirect("../Visitors/Index.aspx");
        //if (Session["IsVendor"].ToString() != "Y")
        //{
        //    if (Session["rid"].ToString() != null && Session["rid"].ToString() != "")
        //    {
        //        Response.Redirect("../Flow/Check.aspx");
        //    }
        //    //TableRowAdd("我需要重送的报废单", "../Flow/MyIndex.aspx", od.GetFlowOne().Rows.Count.ToString());
        //    //TableRowAdd("需要我审批的报废单", "../Flow/MyIndex.aspx", od.GetFlowTwo().Rows.Count.ToString());
        //    //TableRowAdd();
        //    //TableRowAdd("与我相关的纠正预防措施报告", "../Corrective/Index.aspx?IsMy=Y", od.GetCorrective("","","","",true).Rows.Count.ToString());
            
        //    //if (Users.IsManager(Session["uID"].ToString()) == true || Session["uID"].ToString() == "2" || Session["uID"].ToString() == "3")
        //    //{
        //    //    TableRowAdd();
        //    //    TableRowAdd("需要我审批的请假单", "../Attendance/LeaveCheck.aspx", od.GetAttendanceLeaveCheck().Rows.Count.ToString());
        //    //    if (Session["uID"].ToString() != "2")
        //    //    {
        //    //        TableRowAdd("需要我审批的加班单", "../Attendance/OvertimeCheck.aspx", od.GetAttendanceOvertimeCheck().Rows.Count.ToString());
        //    //    }
        //    //}
        //    //TableRowAdd();
        //    ////TableRowAdd("需我会签的检验异常单", "../Sign/IQCIndex.aspx", od.GetSign("160", "", "", "", "", true, "", "").Rows.Count.ToString());
        //    //TableRowAdd("需我会签的物料变更单", "../Sign/ChangeMaterielIndex.aspx", od.GetSign("100", "", "", "", "", true, "", "").Rows.Count.ToString());
        //    //TableRowAdd("需我会签的毛坯退回单", "../Sign/ReturnIndex.aspx", od.GetSign("180", "", "", "", "", true, "", "").Rows.Count.ToString());
        //}
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="title">分类</param>
    /// <param name="href">超链接</param>
    /// <param name="count">数量</param>
    protected void TableRowAdd(string title,string href,string count)
    {
        HtmlTableRow htw = new HtmlTableRow();

        HtmlTableCell htc1 = new HtmlTableCell();
        htc1.Attributes["class"] = "tdlbl";
        HtmlTableCell htc2 = new HtmlTableCell();
        htc2.Attributes["class"] = "tdinput";

        htc1.InnerText = title;

        HtmlAnchor hta = new HtmlAnchor();
        hta.HRef = href;
        hta.InnerText = " " + count + " ";

        if (int.Parse(count) > 0)
        {
            htc1.Attributes["style"] = "color:red";
            hta.Attributes["style"] = "color:red";
        }

        htc2.Controls.Add(hta);
        htw.Controls.Add(htc1);
        htw.Controls.Add(htc2);
        table1.Controls.Add(htw);
    }

    ///// <summary>
    ///// 未完成是想目前需确认列表
    ///// </summary>
    ///// <param name="title"></param>
    //protected void TableRowAdd(string title)
    //{
    //    DataTable dt = od.GetUnFinish();

    //    HtmlTableRow htw = new HtmlTableRow();

    //    HtmlTableCell htc1 = new HtmlTableCell();
    //    htc1.Attributes["class"] = "tdlbl";
    //    htc1.RowSpan = dt.Rows.Count;
        

    //    htc1.InnerText = title;

    //    htw.Controls.Add(htc1);

    //    for (int i = 0; i < dt.Rows.Count; i++)
    //    {
    //        if (i == 0)
    //        {
    //            HtmlTableCell htc2 = new HtmlTableCell();
    //            htc2.Attributes["class"] = "tdinput";

    //            HtmlAnchor hta = new HtmlAnchor();
    //            hta.HRef = "";
    //            hta.Attributes.Add("onclick", "javascript:window.open('../UnFinishBusiness/Return.aspx?ID=" + dt.Rows[i]["URKey"].ToString() + "')");
    //            hta.InnerText = dt.Rows[i]["AddDate"].ToString();
    //            htc2.Controls.Add(hta);
    //            htw.Controls.Add(htc2);
    //            table1.Controls.Add(htw);
    //        }
    //        else
    //        {
    //            HtmlTableRow htws = new HtmlTableRow();

    //            HtmlTableCell htc2 = new HtmlTableCell();
    //            htc2.Attributes["class"] = "tdinput";

    //            HtmlAnchor hta = new HtmlAnchor();
    //            hta.HRef = "";
    //            hta.Attributes.Add("onclick", "javascript:window.open('../UnFinishBusiness/Return.aspx?ID=" + dt.Rows[i]["URKey"].ToString() + "')");
    //            hta.InnerText = dt.Rows[i]["AddDate"].ToString();
    //            htc2.Controls.Add(hta);
    //            htws.Controls.Add(htc2);
    //            table1.Rows.Add(htws);
    //        }
    //    }
    //}

    /// <summary>
    /// 空的表格
    /// </summary>
    protected void TableRowAdd()
    {
        HtmlTableRow htw = new HtmlTableRow();

        HtmlTableCell htc1 = new HtmlTableCell();
        htc1.Attributes["class"] = "tdlbl";
        HtmlTableCell htc2 = new HtmlTableCell();
        htc2.Attributes["class"] = "tdinput";
        htc2.Style.Add("height", "20px");

        htw.Controls.Add(htc1);
        htw.Controls.Add(htc2);
        table1.Controls.Add(htw);
    }
}
