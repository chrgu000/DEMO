using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;
using System.Configuration;

namespace PMMWS
{
    public partial class EquipmentsInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            dBQuery.DBSuzhouInitialize();

            string machineType = this.ASPxComboBox1.Value.ToString();

            if (machineType != "All")
            {

                IList<Machine> mas = Machine.FindbyMachineBu(machineType);

                this.xOrderGridView.DataSource = mas;

                this.xOrderGridView.DataBind();
            }
            else
            {
                IList<Machine> mas = Machine.FindAll();

                this.xOrderGridView.DataSource = mas;
                this.xOrderGridView.DataBind();
            }

            this.Button1.Attributes.Add("onclick", "return confirm('确认是否删除该设备？')");
        }


   
        protected void xOrderGridView_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
           try
            {
                Machine mm = Machine.Find(e.OldValues["MachineCode"].ToString());
                mm.Delete();

                Machine ma = new Machine();

                if (e.NewValues["Orders"] != null)
                {
                    ma.Orders = Convert.ToInt32(e.NewValues["Orders"].ToString());
                }
                if (e.NewValues["MachineCode"] != null)
                {
                    ma.MachineCode = e.NewValues["MachineCode"].ToString();
                }
                if (e.NewValues["MachineName"] != null)
                {
                    ma.MachineName = e.NewValues["MachineName"].ToString();
                }
                if (e.NewValues["MachineType"] != null)
                {
                    ma.MachineType = e.NewValues["MachineType"].ToString();
                }
                if (e.NewValues["MachineBu"] != null)
                {
                    ma.MachineBu = e.NewValues["MachineBu"].ToString();
                }
                if (e.NewValues["Factory"] != null)
                {
                    ma.Factory = e.NewValues["Factory"].ToString();
                }
                if (e.NewValues["ProducingArea"] != null)
                {
                    ma.ProducingArea = e.NewValues["ProducingArea"].ToString();
                }
                if (e.NewValues["MachineSerialNum"] != null)
                {
                    ma.MachineSerialNum = e.NewValues["MachineSerialNum"].ToString();
                }
                if (e.NewValues["Supplier"] != null)
                {
                    ma.Supplier = e.NewValues["Supplier"].ToString();
                }
                if (e.NewValues["UseDate"] != null)
                {
                    ma.UseDate = e.NewValues["UseDate"].ToString();
                }
  
              ma.Create();
            }
           catch
           {

           } 

            e.Cancel = true;
            this.xOrderGridView.CancelEdit();
            performcallback();
    
        }
        private void performcallback()
        {

            string machineType = this.ASPxComboBox1.Value.ToString();

            if (machineType != "All")
            {

                IList<Machine> mas = Machine.FindbyMachineBu(machineType);

                this.xOrderGridView.DataSource = mas;

                this.xOrderGridView.DataBind();
            }
            else
            {
                IList<Machine> mas = Machine.FindAll();

                this.xOrderGridView.DataSource = mas;
                this.xOrderGridView.DataBind();
            }


        }

        protected void xOrderGridView_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {

            try
            {
                Machine ma = new Machine();
                
                if (e.NewValues["Orders"] != null)
                {
                    ma.Orders = Convert.ToInt32(e.NewValues["Orders"].ToString());
                }
                if (e.NewValues["MachineCode"] != null)
                {
                    ma.MachineCode = e.NewValues["MachineCode"].ToString();
                }
                if (e.NewValues["MachineName"] != null)
                {
                    ma.MachineName = e.NewValues["MachineName"].ToString();
                }
                if (e.NewValues["MachineType"] != null)
                {
                    ma.MachineType = e.NewValues["MachineType"].ToString();
                }
                if (e.NewValues["MachineBu"] != null)
                {
                    ma.MachineBu = this.ASPxComboBox1.Value.ToString();
                }

                if (e.NewValues["Factory"] != null)
                {
                    ma.Factory = e.NewValues["Factory"].ToString();
                }

                if (e.NewValues["ProducingArea"] != null)
                {
                    ma.ProducingArea = e.NewValues["ProducingArea"].ToString();
                }
                if (e.NewValues["MachineSerialNum"] != null)
                {
                    ma.MachineSerialNum = e.NewValues["MachineSerialNum"].ToString();
                }
                if (e.NewValues["Supplier"] != null)
                {
                    ma.Supplier = e.NewValues["Supplier"].ToString();
                }
                if (e.NewValues["UseDate"] != null)
                {
                    ma.UseDate = e.NewValues["UseDate"].ToString();
                }

                ma.Create();
            }
            catch
            {

            }
            e.Cancel = true;
            this.xOrderGridView.CancelEdit();
            performcallback();
        }

        protected void ASPxButton3_Click(object sender, EventArgs e)
        {
            if (this.ASPxTextBox1.Text == ConfigurationSettings.AppSettings["PlanAdmin"].ToString())
            {
                this.xOrderGridView.Columns[0].Visible = true;
                this.Button1.Visible = true;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            IList<object> ids = this.xOrderGridView.GetSelectedFieldValues("MachineCode");

            try
            {
                for (int i = 0; i < ids.Count; i++)
                {
                    Machine mar = Machine.Find(ids[i].ToString());
                    mar.Delete();
                    performcallback();
                }
            }
            catch
            { };

        }

        protected void ASPxButton4_Click(object sender, EventArgs e)
        {
            this.ASPxGridViewExporter1.WriteXlsToResponse();
        }

        
    
    }
}