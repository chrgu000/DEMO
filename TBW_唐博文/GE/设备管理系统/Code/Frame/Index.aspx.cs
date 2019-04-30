﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Frame_Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        PublicClass pc = new PublicClass();
        Page.Title = pc.GetCompany();
        if (Session["uID"].ToString() == "")
        {
            Response.Redirect("../Default.aspx");
        }
        Response.Redirect("../WO/Maintenance.aspx");
    }

}
