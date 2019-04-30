using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework;
using System.Collections;
using System.Data;
using System.Runtime.InteropServices;

namespace PMMWS
{
    public partial class WebForm1 : System.Web.UI.Page
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
         
            if (e.GetValue("ST") != null)
            {
                e.Row.BackColor = System.Drawing.Color.Red;

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
                        //int orderId = Convert.ToInt32(e.GetValue("OrderId"));
                        //MAOrder morder = MAOrder.Find(orderId);
                        //morder.Statues = "1";
                        //morder.Update();
                    }

                }
                catch { }
            }
        }
        //板金件
        protected void xOrderGridView0_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
        {
            if (e.GetValue("ST") !=  null)
            {
                e.Row.BackColor = System.Drawing.Color.Red;
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
                        //int orderId = Convert.ToInt32(e.GetValue("OrderId"));
                        //SMOrder smorder = SMOrder.Find(orderId);
                        //smorder.Statues = "1";
                        //smorder.Update();
                    }

                }
                catch { }
            }
        }
        //复合材料区
        protected void xOrderGridView1_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
        {
            if (e.GetValue("ST") != null)
            {

                e.Row.BackColor = System.Drawing.Color.Red;
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

                        //int orderId = Convert.ToInt32(e.GetValue("OrderId"));
                        //CMOrder cmorder = CMOrder.Find(orderId);
                        //cmorder.Statues = "1";
                        //cmorder.Update();
                    }

                }
                catch { }
            }
        }
        //液压系统
        protected void xOrderGridView2_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
        {
            if (e.GetValue("ST") != null)
            {
                e.Row.BackColor = System.Drawing.Color.Red;
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
                        //int orderId = Convert.ToInt32(e.GetValue("OrderId"));
                        //HPOrder hporder = HPOrder.Find(orderId);
                        //hporder.Statues = "1";
                        //hporder.Update();
                    }

                }
                catch { }
            }
            
        }

        protected void xOrderGridView_CustomColumnDisplayText(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewColumnDisplayTextEventArgs e)
        {
            try
            {
                if (e.Column == this.xOrderGridView.Columns["ST"])
                {
                    if (e.Value != null && e.Value.ToString() != "")
                    {
                        e.DisplayText = Convert.ToDateTime(e.Value.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                }
                if (e.Column == xOrderGridView.Columns["MST"])
                {
                    if (e.Value != null && e.Value.ToString() != "")
                    {
                        e.DisplayText = Convert.ToDateTime(e.Value.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                }
                if (e.Column == xOrderGridView.Columns["MCT"])
                {
                    if (e.Value != null && e.Value.ToString() != "")
                    {
                        e.DisplayText = Convert.ToDateTime(e.Value.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                }
            }
            catch
            { }
        }

        protected void xOrderGridView0_CustomColumnDisplayText(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewColumnDisplayTextEventArgs e)
        {
            try
            {
                if (e.Column == this.xOrderGridView0.Columns["ST"])
                {
                    if (e.Value != null && e.Value.ToString() != "")
                    {
                        e.DisplayText = Convert.ToDateTime(e.Value.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                }
                if (e.Column == xOrderGridView0.Columns["MST"])
                {
                    if (e.Value != null && e.Value.ToString() != "")
                    {
                        e.DisplayText = Convert.ToDateTime(e.Value.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                }
                if (e.Column == xOrderGridView0.Columns["MCT"])
                {
                    if (e.Value != null && e.Value.ToString() != "")
                    {
                        e.DisplayText = Convert.ToDateTime(e.Value.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                }
            }
            catch
            { }
        }

        protected void xOrderGridView1_CustomColumnDisplayText(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewColumnDisplayTextEventArgs e)
        {
            try
            {
                if (e.Column == this.xOrderGridView1.Columns["ST"])
                {
                    if (e.Value != null && e.Value.ToString() != "")
                    {
                        e.DisplayText = Convert.ToDateTime(e.Value.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                }
                if (e.Column == xOrderGridView1.Columns["MST"])
                {
                    if (e.Value != null && e.Value.ToString() != "")
                    {
                        e.DisplayText = Convert.ToDateTime(e.Value.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                }
                if (e.Column == xOrderGridView1.Columns["MCT"])
                {
                    if (e.Value != null && e.Value.ToString() != "")
                    {
                        e.DisplayText = Convert.ToDateTime(e.Value.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                }
            }
            catch
            { }
        }

        protected void xOrderGridView2_CustomColumnDisplayText(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewColumnDisplayTextEventArgs e)
        {
            try
            {
                if (e.Column == this.xOrderGridView2.Columns["ST"])
                {
                    if (e.Value != null && e.Value.ToString() != "")
                    {
                        e.DisplayText = Convert.ToDateTime(e.Value.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                }
                if (e.Column == xOrderGridView2.Columns["MST"])
                {
                    if (e.Value != null && e.Value.ToString() != "")
                    {
                        e.DisplayText = Convert.ToDateTime(e.Value.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                }
                if (e.Column == xOrderGridView2.Columns["MCT"])
                {
                    if (e.Value != null && e.Value.ToString() != "")
                    {
                        e.DisplayText = Convert.ToDateTime(e.Value.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                }
            }
            catch
            { }
        }






        



    }
}