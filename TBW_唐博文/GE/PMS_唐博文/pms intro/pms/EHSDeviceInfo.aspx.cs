using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace PMMWS
{
    public partial class EHSDeviceInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            dBQuery.DBSuzhouInitialize();

            //string Type = this.ASPxComboBox3.Text;
            this.Button1.Attributes.Add("OnClick", "return confirm('确认要删除所选择的设备记录？')");

            if (!IsPostBack)
            {
                string[] types = PMSPMBackup.FindbyDistinctQuery("特殊设备");

                string[] types2 = PMSPMBackup.FindbyDistinctQuery("辅助设备");

                for (int i = 0; i < types.Length; i++)
                {
                    this.ASPxComboBox3.Items.Add(types[i]);
                }
                for (int i = 0; i < types2.Length; i++)
                {
                    this.ASPxComboBox4.Items.Add(types2[i]);
                }
            }


            IList<PMSPMBackup> PMSPMBackups1 = PMSPMBackup.FindbyTypeAndType1("特殊设备",this.ASPxComboBox3.Text);
            this.ASPxGridView2.DataSource = PMSPMBackups1;
            this.ASPxGridView2.DataBind();
            
            string type2 = this.ASPxComboBox4.Text;
            IList<PMSPMBackup> PMSPMBackups2 = PMSPMBackup.FindbyTypeAndType1("辅助设备",this.ASPxComboBox4.Text);
            this.ASPxGridView3.DataSource = PMSPMBackups2;
            this.ASPxGridView3.DataBind();


            IList<PMSPMBackup> PMSPMBackups3 = PMSPMBackup.FindAll();
            this.ASPxGridView4.DataSource = PMSPMBackups3;
            this.ASPxGridView4.DataBind();

        }

        protected void grid_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {

            int pMBackupId = Convert.ToInt32(e.Keys["PMBackupId"].ToString());

            PMSPMBackup pBackup = PMSPMBackup.Find(pMBackupId);


            try
            {

                if (e.NewValues["MachineType"] != null)
                {
                    pBackup.MachineType = e.NewValues["MachineType"].ToString();
                }
                else
                {
                    pBackup.MachineType = "";
                }
                if (e.NewValues["MachineName"] != null)
                {
                    pBackup.MachineName = e.NewValues["MachineName"].ToString();
                }

                if (e.NewValues["Numbers"] != null)
                {
                    pBackup.Numbers = e.NewValues["Numbers"].ToString();
                }
                else
                {
                    pBackup.Numbers = "";
                }

                try
                {
                    if (e.NewValues["Orders"] != null)
                    {
                        pBackup.Orders = Convert.ToInt32(e.NewValues["Orders"].ToString());
                    }
                }
                catch
                { }

                try
                {
                    if (e.NewValues["CheckTime"] != null)
                    {
                        pBackup.CheckTime = e.NewValues["CheckTime"].ToString();
                    }
                    else
                    {
                        pBackup.CheckTime = "";
                    }
                }
                catch
                { }

                if (e.NewValues["DeviceCode"] != null)
                {
                    pBackup.DeviceCode = e.NewValues["DeviceCode"].ToString();
                }
                else
                {
                    pBackup.DeviceCode = "";
                }

                if (e.NewValues["DeviceNumber"] != null)
                {
                    pBackup.DeviceNumber = e.NewValues["DeviceNumber"].ToString();
                }
                else
                {
                    pBackup.DeviceNumber = "";
                }
                if (e.NewValues["Frequency"] != null)
                {
                    pBackup.Frequency = e.NewValues["Frequency"].ToString();
                }
                else
                {
                    pBackup.Frequency = "";
                }
                if (e.NewValues["IsCal"] != null)
                {
                    pBackup.IsCal = e.NewValues["IsCal"].ToString();
                }
                else
                {
                    pBackup.IsCal = "";
                }
                if (e.NewValues["MeasureContents"] != null)
                {
                    pBackup.MeasureContents = e.NewValues["MeasureContents"].ToString();
                }
                else
                {
                    pBackup.MeasureContents = "";
                }
                try
                {
                    if (e.NewValues["NextCheckTime"] != null)
                    {
                        
                        pBackup.Test = Convert.ToDateTime(e.NewValues["NextCheckTime"].ToString()).ToString("yyyy-MM-dd");
                        pBackup.NextCheckTime = e.NewValues["NextCheckTime"].ToString();
                    }
                    else
                    {
                        pBackup.NextCheckTime = "";
                    }
                }
                catch { }

                if (e.NewValues["Position"] != null)
                {
                    pBackup.Position = e.NewValues["Position"].ToString();
                }
                else
                {
                    pBackup.Position = "";
                }
                if (e.NewValues["RegisterCode"] != null)
                {
                    pBackup.RegisterCode = e.NewValues["RegisterCode"].ToString();
                }
                else
                {
                    pBackup.RegisterCode = "";
                }
                if (e.NewValues["ReportCode"] != null)
                {
                    pBackup.ReportCode = e.NewValues["ReportCode"].ToString();
                }
                else
                {
                    pBackup.ReportCode = "";
                }
                if (e.NewValues["SeriesCode"] != null)
                {
                    pBackup.SeriesCode = e.NewValues["SeriesCode"].ToString();
                }
                else
                {
                    pBackup.SeriesCode = "";
                }

                pBackup.Type = "特殊设备";

                pBackup.Type1 = this.ASPxComboBox3.Text;

                pBackup.Update();
            }
            catch
            {

            }

            e.Cancel = true;
            this.ASPxGridView2.CancelEdit();
            performCallBack();

        }

        private void performCallBack()
        {
            string type1 = this.ASPxComboBox3.Text;

            IList<PMSPMBackup> PMSPMBackups1 = PMSPMBackup.FindbyTypeAndType1("特殊设备", type1);
            this.ASPxGridView2.DataSource = PMSPMBackups1;
            this.ASPxGridView2.DataBind();
        }

        private void performCallBack1()
        {
            string type2 = this.ASPxComboBox4.Text;
            IList<PMSPMBackup> PMSPMBackups2 = PMSPMBackup.FindbyTypeAndType1("辅助设备", type2);
            this.ASPxGridView3.DataSource = PMSPMBackups2;
            this.ASPxGridView3.DataBind();
        }


        protected void ASPxButton3_Click(object sender, EventArgs e)
        {
            if (this.ASPxTextBox1.Text == ConfigurationSettings.AppSettings["PlanAdmin"].ToString())
            {
                this.ASPxGridView2.Columns[0].Visible = true;
                this.ASPxGridView3.Columns[0].Visible = true;
                this.ASPxButton6.Visible = true ;
                this.Button1.Visible = true;
                
            }
        }

        protected void ASPxGridView2_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            PMSPMBackup pBackup = new PMSPMBackup();

            try
            {

                if (e.NewValues["MachineType"] != null)
                {
                    pBackup.MachineType = e.NewValues["MachineType"].ToString();
                }
                else
                {
                    pBackup.MachineType = "";
                }
                if (e.NewValues["MachineName"] != null)
                {
                    pBackup.MachineName = e.NewValues["MachineName"].ToString();
                }

                try
                {
                    if (e.NewValues["Orders"] != null)
                    {
                        pBackup.Orders = Convert.ToInt32(e.NewValues["Orders"].ToString());
                    }
                }
                catch
                { }

                if (e.NewValues["Numbers"] != null)
                {
                    pBackup.Numbers = e.NewValues["Numbers"].ToString();
                }
                else
                {
                    pBackup.Numbers = "";
                }

                try
                {
                    if (e.NewValues["CheckTime"] != null)
                    {
                        pBackup.CheckTime = e.NewValues["CheckTime"].ToString();
                    }
                    else
                    {
                        pBackup.CheckTime = "";
                    }
                }
                catch { }

                if (e.NewValues["DeviceCode"] != null)
                {
                    pBackup.DeviceCode = e.NewValues["DeviceCode"].ToString();
                }
                else
                {
                    pBackup.DeviceCode = "";
                }

                if (e.NewValues["DeviceNumber"] != null)
                {
                    pBackup.DeviceNumber = e.NewValues["DeviceNumber"].ToString();
                }
                else
                {
                    pBackup.DeviceNumber = "";
                }
                if (e.NewValues["Frequency"] != null)
                {
                    pBackup.Frequency = e.NewValues["Frequency"].ToString();
                }
                else
                {
                    pBackup.Frequency = "";
                }
                if (e.NewValues["IsCal"] != null)
                {
                    pBackup.IsCal = e.NewValues["IsCal"].ToString();
                }
                else
                {
                    pBackup.IsCal = "";
                }
                if (e.NewValues["MeasureContents"] != null)
                {
                    pBackup.MeasureContents = e.NewValues["MeasureContents"].ToString();
                }
                else
                {
                    pBackup.MeasureContents = "";
                }
                try
                {
                    if (e.NewValues["NextCheckTime"] != null)
                    {
                        pBackup.Test = Convert.ToInt32(e.NewValues["NextCheckTime"].ToString()).ToString("yyyy-MM-dd");
                        pBackup.NextCheckTime = e.NewValues["NextCheckTime"].ToString();
                    }


                    else
                    {
                        pBackup.NextCheckTime = "";
                    }
                }
                catch { }
                if (e.NewValues["Position"] != null)
                {
                    pBackup.Position = e.NewValues["Position"].ToString();
                }
                else
                {
                    pBackup.Position = "";
                }
                if (e.NewValues["RegisterCode"] != null)
                {
                    pBackup.RegisterCode = e.NewValues["RegisterCode"].ToString();
                }
                else
                {
                    pBackup.RegisterCode = "";
                }
                if (e.NewValues["ReportCode"] != null)
                {
                    pBackup.ReportCode = e.NewValues["ReportCode"].ToString();
                }
                else
                {
                    pBackup.ReportCode = "";
                }
                if (e.NewValues["SeriesCode"] != null)
                {
                    pBackup.SeriesCode = e.NewValues["SeriesCode"].ToString();
                }
                else
                {
                    pBackup.SeriesCode = "";
                }
                
 
                    pBackup.Type1 = this.ASPxComboBox3.Text;
          
                    pBackup.Type = "特殊设备";
                
                pBackup.Create();
            }
            catch
            {

            }

            e.Cancel = true;
            this.ASPxGridView2.CancelEdit();
            performCallBack();    
        }

        protected void ASPxGridView3_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            int pMBackupId = Convert.ToInt32(e.Keys["PMBackupId"].ToString());

            PMSPMBackup pBackup = PMSPMBackup.Find(pMBackupId);

            try
            {

                if (e.NewValues["MachineType"] != null)
                {
                    pBackup.MachineType = e.NewValues["MachineType"].ToString();
                }
                else
                {
                    pBackup.MachineType = "";
                }
                if (e.NewValues["MachineName"] != null)
                {
                    pBackup.MachineName = e.NewValues["MachineName"].ToString();
                }

                if (e.NewValues["Numbers"] != null)
                {
                    pBackup.Numbers = e.NewValues["Numbers"].ToString();
                }
                else
                {
                    pBackup.Numbers = "";
                }

                try
                {
                    if (e.NewValues["Orders"] != null)
                    {
                        pBackup.Orders = Convert.ToInt32(e.NewValues["Orders"].ToString());
                    }
                }
                catch { }


                if (e.NewValues["CheckTime"] != null)
                {
                    pBackup.CheckTime = e.NewValues["CheckTime"].ToString();
                }
                else
                {
                    pBackup.CheckTime = "";
                }


                if (e.NewValues["DeviceCode"] != null)
                {
                    pBackup.DeviceCode = e.NewValues["DeviceCode"].ToString();
                }
                else
                {
                    pBackup.DeviceCode = "";
                }

                if (e.NewValues["DeviceNumber"] != null)
                {
                    pBackup.DeviceNumber = e.NewValues["DeviceNumber"].ToString();
                }
                else
                {
                    pBackup.DeviceNumber = "";
                }
                if (e.NewValues["Frequency"] != null)
                {
                    pBackup.Frequency = e.NewValues["Frequency"].ToString();
                }
                else
                {
                    pBackup.Frequency = "";
                }
                if (e.NewValues["IsCal"] != null)
                {
                    pBackup.IsCal = e.NewValues["IsCal"].ToString();
                }
                else
                {
                    pBackup.IsCal = "";
                }
                if (e.NewValues["MeasureContents"] != null)
                {
                    pBackup.MeasureContents = e.NewValues["MeasureContents"].ToString();
                }
                else
                {
                    pBackup.MeasureContents = "";
                }
                if (e.NewValues["NextCheckTime"] != null)
                {
                    pBackup.NextCheckTime = e.NewValues["NextCheckTime"].ToString();
                }
                else
                {
                    pBackup.NextCheckTime = "";
                }
                if (e.NewValues["Position"] != null)
                {
                    pBackup.Position = e.NewValues["Position"].ToString();
                }
                else
                {
                    pBackup.Position = "";
                }
                if (e.NewValues["RegisterCode"] != null)
                {
                    pBackup.RegisterCode = e.NewValues["RegisterCode"].ToString();
                }
                else
                {
                    pBackup.RegisterCode = "";
                }
                if (e.NewValues["ReportCode"] != null)
                {
                    pBackup.ReportCode = e.NewValues["ReportCode"].ToString();
                }
                else
                {
                    pBackup.ReportCode = "";
                }
                if (e.NewValues["SeriesCode"] != null)
                {
                    pBackup.SeriesCode = e.NewValues["SeriesCode"].ToString();
                }
                else
                {
                    pBackup.SeriesCode = "";
                }
                   
                pBackup.Update();
            }
            catch
            {

            }

            e.Cancel = true;
            this.ASPxGridView3.CancelEdit();
            performCallBack1();    
        }

        protected void ASPxGridView3_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            PMSPMBackup pBackup = new PMSPMBackup();

            try
            {

                if (e.NewValues["MachineType"] != null)
                {
                    pBackup.MachineType = e.NewValues["MachineType"].ToString();
                }
                else
                {
                    pBackup.MachineType = "";
                }
                if (e.NewValues["MachineName"] != null)
                {
                    pBackup.MachineName = e.NewValues["MachineName"].ToString();
                }

                if (e.NewValues["Numbers"] != null)
                {
                    pBackup.Numbers = e.NewValues["Numbers"].ToString();
                }
                else
                {
                    pBackup.Numbers = "";
                }

                try
                {
                    if (e.NewValues["Orders"] != null)
                    {
                        pBackup.Orders = Convert.ToInt32(e.NewValues["Orders"].ToString());
                    }
                }
                catch { }

                if (e.NewValues["CheckTime"] != null)
                {
                    pBackup.CheckTime = e.NewValues["CheckTime"].ToString();
                }
                else
                {
                    pBackup.CheckTime = "";
                }


                if (e.NewValues["DeviceCode"] != null)
                {
                    pBackup.DeviceCode = e.NewValues["DeviceCode"].ToString();
                }
                else
                {
                    pBackup.DeviceCode = "";
                }

                if (e.NewValues["DeviceNumber"] != null)
                {
                    pBackup.DeviceNumber = e.NewValues["DeviceNumber"].ToString();
                }
                else
                {
                    pBackup.DeviceNumber = "";
                }
                if (e.NewValues["Frequency"] != null)
                {
                    pBackup.Frequency = e.NewValues["Frequency"].ToString();
                }
                else
                {
                    pBackup.Frequency = "";
                }
                if (e.NewValues["IsCal"] != null)
                {
                    pBackup.IsCal = e.NewValues["IsCal"].ToString();
                }
                else
                {
                    pBackup.IsCal = "";
                }
                if (e.NewValues["MeasureContents"] != null)
                {
                    pBackup.MeasureContents = e.NewValues["MeasureContents"].ToString();
                }
                else
                {
                    pBackup.MeasureContents = "";
                }
                if (e.NewValues["NextCheckTime"] != null)
                {
                    pBackup.NextCheckTime = e.NewValues["NextCheckTime"].ToString();
                }
                else
                {
                    pBackup.NextCheckTime = "";
                }
                if (e.NewValues["Position"] != null)
                {
                    pBackup.Position = e.NewValues["Position"].ToString();
                }
                else
                {
                    pBackup.Position = "";
                }
                if (e.NewValues["RegisterCode"] != null)
                {
                    pBackup.RegisterCode = e.NewValues["RegisterCode"].ToString();
                }
                else
                {
                    pBackup.RegisterCode = "";
                }
                if (e.NewValues["ReportCode"] != null)
                {
                    pBackup.ReportCode = e.NewValues["ReportCode"].ToString();
                }
                else
                {
                    pBackup.ReportCode = "";
                }
                if (e.NewValues["SeriesCode"] != null)
                {
                    pBackup.SeriesCode = e.NewValues["SeriesCode"].ToString();
                }
                else
                {
                    pBackup.SeriesCode = "";
                }
                    pBackup.Type1 = this.ASPxComboBox4.Text;
                    pBackup.Type = "辅助设备";
                pBackup.Create();
            }
            catch
            {

            }

            e.Cancel = true;
            this.ASPxGridView3.CancelEdit();
            performCallBack1();    
        }

        protected void ASPxButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("PublicFacilities.aspx");
        }

        protected void ASPxButton5_Click(object sender, EventArgs e)
        {
            if (this.ASPxTextBox2.Text != "")
            {
                if (this.ASPxRadioButtonList1.Items[this.ASPxRadioButtonList1.SelectedIndex].Text == "特殊设备")
                {
                    this.ASPxComboBox3.Items.Add(this.ASPxTextBox2.Text);
                }
                else
                {
                    this.ASPxComboBox4.Items.Add(this.ASPxTextBox2.Text);
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            try
            {
                if (this.ASPxPageControl1.ActiveTabIndex == 0)
                {

                    IList<object> ids = this.ASPxGridView2.GetSelectedFieldValues("PMBackupId");

                    if (ids.Count != 0)
                    {
                        PMSPMBackup pmb = PMSPMBackup.Find(Convert.ToInt32(ids[0]));
                        pmb.Delete();
                    }
                    performCallBack();
                }
                else if (this.ASPxPageControl1.ActiveTabIndex == 1)
                {
                    IList<object> ids = this.ASPxGridView3.GetSelectedFieldValues("PMBackupId");

                    if (ids.Count != 0)
                    {
                        PMSPMBackup pmb = PMSPMBackup.Find(Convert.ToInt32(ids[0]));
                        pmb.Delete();
                    }
                    performCallBack1();
                }
            }
            catch
            { };
        }

        protected void ASPxButton8_Click(object sender, EventArgs e)
        {
            this.ASPxGridViewExporter1.WriteXlsToResponse();  
        }

        protected void ASPxButton9_Click(object sender, EventArgs e)
        {
            IList<PMSPMBackup> pmspms = PMSPMBackup.FindbyType("辅助设备");

            for (int i = 0; i < pmspms.Count; i++)
            {
                pmspms[i].CheckTime = System.DateTime.Now.Year.ToString() + "/" + (System.DateTime.Now.Month - 1).ToString();
                pmspms[i].Update();
            }
            performCallBack1();
        }

    }
}