using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
namespace PMMWS
{
    public partial class PmContents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            dBQuery.DBSuzhouInitialize();

            string Year = System.DateTime.Now.Year.ToString();

            if (!IsPostBack)
            {
                string[] names = PMSPMContent.FindbyDistinctField("MachineName");

                for (int i = 0; i < names.Length; i++)
                {
                    this.ASPxComboBox2.Items.Add(names[i], names[i]);
                }

                this.ASPxComboBox2.SelectedIndex = 0;
            }
            string Name = this.ASPxComboBox2.Text;

            IList<PMSPMContent> PMSPMContents = PMSPMContent.FindbyName(Name);
            this.grid.DataSource = PMSPMContents;
            this.grid.DataBind();


        }

        protected void ASPxButton3_Click(object sender, EventArgs e)
        {
            if (this.ASPxTextBox1.Text == ConfigurationSettings.AppSettings["PlanAdmin"].ToString())
            {
                this.grid.Columns[0].Visible = true;
            }
        }

        protected void grid_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
           int id = Convert.ToInt32(e.Keys["PMContentId"].ToString());

           PMSPMContent pContent = PMSPMContent.Find(id);


           try
           {

               if (e.NewValues["Contents1"] != null)
               {
                   pContent.Contents1 = e.NewValues["Contents1"].ToString();
               }
               else
               {
                   pContent.Contents1 = "";
               }
               if (e.NewValues["MachineName"] != null)
               {
                   pContent.MachineName = e.NewValues["MachineName"].ToString();
               }

               if (e.NewValues["Contents2"] != null)
               {
                   pContent.Contents2 = e.NewValues["Contents2"].ToString();
               }
               else
               {
                   pContent.Contents2 = "";
               }

               if (e.NewValues["Contents3"] != null)
               {
                   pContent.Contents3 = e.NewValues["Contents3"].ToString();
               }
               else
               {
                   pContent.Contents3 = "";
               }


               if (e.NewValues["Contents4"] != null)
               {
                   pContent.Contents4 = e.NewValues["Contents4"].ToString();
               }
               else
               {
                   pContent.Contents4 = "";
               }

               if (e.NewValues["Month1"] != null)
               {
                   pContent.Month1 = e.NewValues["Month1"].ToString();
               }
               else
               {
                   pContent.Month1 = "";
               }
               if (e.NewValues["Month2"] != null)
               {
                   pContent.Month2 = e.NewValues["Month2"].ToString();
               }
               else
               {
                   pContent.Month2 = "";
               }
               if (e.NewValues["Month3"] != null)
               {
                   pContent.Month3 = e.NewValues["Month3"].ToString();
               }
               else
               {
                   pContent.Month3 = "";
               }
               if (e.NewValues["Month4"] != null)
               {
                   pContent.Month4 = e.NewValues["Month4"].ToString();
               }
               else
               {
                   pContent.Month4 = "";
               }
               if (e.NewValues["Month5"] != null)
               {
                   pContent.Month5 = e.NewValues["Month5"].ToString();
               }
               else
               {
                   pContent.Month5 = "";
               }
               if (e.NewValues["Month6"] != null)
               {
                   pContent.Month6 = e.NewValues["Month6"].ToString();
               }
               else
               {
                   pContent.Month6 = "";
               }
               if (e.NewValues["Month7"] != null)
               {
                   pContent.Month7 = e.NewValues["Month7"].ToString();
               }
               else
               {
                   pContent.Month7 = "";
               }
               if (e.NewValues["Month8"] != null)
               {
                   pContent.Month8 = e.NewValues["Month8"].ToString();
               }
               else
               {
                   pContent.Month8 = "";
               }
               if (e.NewValues["Month9"] != null)
               {
                   pContent.Month9 = e.NewValues["Month9"].ToString();
               }
               else
               {
                   pContent.Month9 = "";
               }
               if (e.NewValues["Month10"] != null)
               {
                   pContent.Month10 = e.NewValues["Month10"].ToString();
               }
               else
               {
                   pContent.Month10 = "";
               }
               if (e.NewValues["Month11"] != null)
               {
                   pContent.Month11 = e.NewValues["Month11"].ToString();
               }
               else
               {
                   pContent.Month11 = "";
               }
               if (e.NewValues["Month12"] != null)
               {
                   pContent.Month12 = e.NewValues["Month12"].ToString();
               }
               else
               {
                   pContent.Month12 = "";
               }
               if (e.NewValues["Year"] != null)
               {
                   pContent.Year = e.NewValues["Year"].ToString();
               }
               if (e.NewValues["MWorker"] != null)
               {
                   pContent.MWorker = e.NewValues["MWorker"].ToString();
               }

               pContent.Update();
           }
           catch
           {

           }

           e.Cancel = true;
           this.grid.CancelEdit();
           performCallBack();    
        }

        private void performCallBack()
        {

            string Year = System.DateTime.Now.Year.ToString();
            string Name = this.ASPxComboBox2.Text;

            IList<PMSPMContent> PMSPMContents = PMSPMContent.FindbyName(Name);
            this.grid.DataSource = PMSPMContents;
            this.grid.DataBind();
        }

        protected void ASPxButton2_Click(object sender, EventArgs e)
        {
            this.ASPxGridViewExporter1.WriteXlsToResponse();
        }
    }
}