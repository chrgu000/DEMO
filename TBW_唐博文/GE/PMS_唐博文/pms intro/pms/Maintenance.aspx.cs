using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMMWS
{
    public partial class Maintenance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            dBQuery.DBSuzhouInitialize();


            IList<CMOrder> cmorder = CMOrder.FindbyStatues("0");
            IList<SMOrder> smorder = SMOrder.FindbyStatues("0");
            IList<MAOrder> maorder = MAOrder.FindbyStatues("0");
            IList<HPOrder> hporder = HPOrder.FindbyStatues("0");

            this.xOrderGridView.DataSource = maorder;
            this.xOrderGridView.DataBind();

            this.xOrderGridView0.DataSource = smorder;
            this.xOrderGridView0.DataBind();

            this.xOrderGridView1.DataSource = cmorder;
            this.xOrderGridView1.DataBind();

            this.xOrderGridView2.DataSource = hporder;
            this.xOrderGridView2.DataBind();


        }

        //状态位颜色设置
        //机加工
        protected void xOrderGridView_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
        {
            try
            {
                string a = e.GetValue("MST").ToString();
                if (a != "")
                {
                    e.Row.BackColor = System.Drawing.Color.Yellow;
                }
            }
            catch { }

            try
            {
                string b = e.GetValue("MCT").ToString();
                if (b != "")
                {
                    e.Row.BackColor = System.Drawing.Color.Green;
                }

            }
            catch { }
        }
        //板金件
        protected void xOrderGridView0_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
        {
            try
            {
                string a = e.GetValue("MST").ToString();
                if (a != "")
                {
                    e.Row.BackColor = System.Drawing.Color.Yellow;
                }
            }
            catch { }

            try
            {
                string b = e.GetValue("MCT").ToString();
                if (b != "")
                {
                    e.Row.BackColor = System.Drawing.Color.Green;
                }

            }
            catch { }
        }
        //复合材料区
        protected void xOrderGridView1_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
        {
            try
            {
                string a = e.GetValue("MST").ToString();
                if (a != "")
                {
                    e.Row.BackColor = System.Drawing.Color.Yellow;
                }
            }
            catch { }

            try
            {
                string b = e.GetValue("MCT").ToString();
                if (b != "")
                {
                    e.Row.BackColor = System.Drawing.Color.Green;
                }

            }
            catch { }
        }
        //液压系统
        protected void xOrderGridView2_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
        {
            try
            {
                string a = e.GetValue("MST").ToString();
                if (a != "")
                {
                    e.Row.BackColor = System.Drawing.Color.Yellow;
                }
            }
            catch { }

            try
            {
                string b = e.GetValue("MCT").ToString();
                if (b != "")
                {
                    e.Row.BackColor = System.Drawing.Color.Green;
                }

            }
            catch { }


        }

    }
}