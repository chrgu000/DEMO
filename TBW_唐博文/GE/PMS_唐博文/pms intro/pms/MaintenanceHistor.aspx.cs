using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PMMWS
{
    public partial class MaintenanceHistor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            dBQuery.DBSuzhouInitialize();

            if (this.ASPxComboBox1.Value.ToString() != "All")
            {
                string typename = "PMMWS." + this.ASPxComboBox1.Value.ToString() + "Order";

                DataTable dt = dBQuery.GetReflectionResult(typename, "FindAll", "");
                this.xOrderGridView.DataSource = dt;
                this.xOrderGridView.DataBind();
            }
            else
            {
                DataTable dt = dBQuery.GetReflectionResult("PMMWS.MAOrder", "FindAll", "");
                DataTable dt1 = dBQuery.GetReflectionResult("PMMWS.SMOrder", "FindAll", "");
                DataTable dt2 = dBQuery.GetReflectionResult("PMMWS.CMOrder", "FindAll", "");
                DataTable dt3 = dBQuery.GetReflectionResult("PMMWS.HPOrder", "FindAll", "");
                dt.Merge(dt1);
                dt.Merge(dt2);
                dt.Merge(dt3);
                this.xOrderGridView.DataSource = dt;
                this.xOrderGridView.DataBind();
            }

        }

        protected void ASPxButton1_Click(object sender, EventArgs e)
        {
            this.ASPxGridViewExporter1.WriteXlsToResponse();
        }

        protected void xOrderGridView_CustomCallback(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewCustomCallbackEventArgs e)
        {

        }

        protected void xOrderGridView_CustomColumnDisplayText(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewColumnDisplayTextEventArgs e)
        {
            if (e.Column == this.xOrderGridView.Columns["ST"])
            {
                try
                {
                    if (e.Value != null && e.Value.ToString() != "")
                    {
                        e.DisplayText = Convert.ToDateTime(e.Value.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                }
                catch
                {
                    e.DisplayText = e.Value.ToString();
                }
            }
            if (e.Column == xOrderGridView.Columns["CT"])
            {
                try
                {
                    if (e.Value != null && e.Value.ToString() != "")
                    {
                        e.DisplayText = Convert.ToDateTime(e.Value.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                }
                catch
                {
                    e.DisplayText = e.Value.ToString();
                }
            }
            if (e.Column == xOrderGridView.Columns["MST"])
            {
                try
                {
                    if (e.Value != null && e.Value.ToString() != "")
                    {
                        e.DisplayText = Convert.ToDateTime(e.Value.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                }
                catch
                {
                    e.DisplayText = e.Value.ToString();
                }
            }
            if (e.Column == xOrderGridView.Columns["MCT"])
            {
                try
                {
                    if (e.Value != null && e.Value.ToString() != "")
                    {
                        e.DisplayText = Convert.ToDateTime(e.Value.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                }
                catch
                {
                    e.DisplayText = e.Value.ToString();
                }
            }
        }
    }
}