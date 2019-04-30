using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace PMMWS
{
    public partial class SPInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dBQuery.DBSuzhouInitialize();
                this.ASPxComboBox2.Items.Add("全部");
                string[] spnames = PMSMPlan.FindbyDistinctQuery();
                for (int i = 0; i < spnames.Length; i++)
                {
                    this.ASPxComboBox2.Items.Add(spnames[i]);
                }
            }
           this.Button1.Attributes.Add("onclick", "return confirm('确认是否添加新的备件类型？')");

           this.Button2.Attributes.Add("onclick", "return confirm('确认删除此备件记录？')");

           this.Button3.Attributes.Add("onclick", "return confirm('确认删除此备件类型？')");

            // this.ASPxComboBox2.SelectedIndex = 0;
            string spName = this.ASPxComboBox2.Text;

            if (spName != "全部" )
            {
                IList<PMSMPlan> SPInfos = PMSMPlan.FindbySPName(spName);
                this.ASPxGridView1.DataSource = SPInfos;
                this.ASPxGridView1.DataBind();
            }
            else
            {
                IList<PMSMPlan> SPinfos = PMSMPlan.FindAll();
                this.ASPxGridView1.DataSource = SPinfos;
                this.ASPxGridView1.DataBind();
            }

            string Qty = "0";
            IList<PMSMPlan> SPInfosQty = PMSMPlan.FindbyQty(Qty);
            this.ASPxGridView2.DataSource = SPInfosQty;
            this.ASPxGridView2.DataBind();

        }
        private void performcallback()
        {
            string spName = this.ASPxComboBox2.Text;
            if (spName != "全部")
            {
                IList<PMSMPlan> SPInfos = PMSMPlan.FindbySPName(spName);
                this.ASPxGridView1.DataSource = SPInfos;
                this.ASPxGridView1.DataBind();
            }
            else
            {
                IList<PMSMPlan> SPinfos = PMSMPlan.FindAll();
                this.ASPxGridView1.DataSource = SPinfos;
                this.ASPxGridView1.DataBind();
            }
        }


        protected void ASPxGridView1_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            try
            {
                PMSMPlan ma = PMSMPlan.Find( Convert.ToInt32(e.Keys["SPId"]));

                if (e.NewValues["MaterialCode"] != null)
                {
                    ma.MaterialCode = e.NewValues["MaterialCode"].ToString();
                }
                if (e.NewValues["ItemDescription"] != null)
                {
                    ma.ItemDescription = e.NewValues["ItemDescription"].ToString();
                }
                if (e.NewValues["Specification"] != null)
                {
                    ma.Specification = e.NewValues["Specification"].ToString();
                }

                if (e.NewValues["ItemNO"] != null)
                {
                    ma.ItemNO = e.NewValues["ItemNO"].ToString();
                }

                if (e.NewValues["UM"] != null)
                {
                    ma.UM = e.NewValues["UM"].ToString();
                }
                if (e.NewValues["Qty"] != null)
                {
                    ma.Qty = e.NewValues["Qty"].ToString();
                }
                if (e.NewValues["DueDate"] != null)
                {
                    ma.DueDate = e.NewValues["DueDate"].ToString();
                }
                if (e.NewValues["CheckingDate"] != null)
                {
                    ma.CheckingDate = e.NewValues["CheckingDate"].ToString();
                }
                if (e.NewValues["SafeQty"] != null)
                {
                    ma.SafeQty = e.NewValues["SafeQty"].ToString();
                }
                if (e.NewValues["UnitPrice"] != null)
                {
                    ma.UnitPrice = e.NewValues["UnitPrice"].ToString();
                }
                if (e.NewValues["Purpose"] != null)
                {
                    ma.Purpose = e.NewValues["Purpose"].ToString();
                }
                if (e.NewValues["StorageStatus"] != null)
                {
                    ma.StorageStatus = e.NewValues["StorageStatus"].ToString();
                }
          
                ma.Update();
            }
            catch
            {

            }

            e.Cancel = true;
            this.ASPxGridView1.CancelEdit();
            performcallback();
        }

        protected void ASPxGridView1_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            try
            {
                PMSMPlan ma = new PMSMPlan();

                if (e.NewValues["MaterialCode"] != null)
                {
                    ma.MaterialCode = e.NewValues["MaterialCode"].ToString();
                }
                if (e.NewValues["ItemDescription"] != null)
                {
                    ma.ItemDescription = e.NewValues["ItemDescription"].ToString();
                }
                if (e.NewValues["Specification"] != null)
                {
                    ma.Specification = e.NewValues["Specification"].ToString();
                }

                if (e.NewValues["ItemNO"] != null)
                {
                    ma.ItemNO = e.NewValues["ItemNO"].ToString();
                }

                if (e.NewValues["UM"] != null)
                {
                    ma.UM = e.NewValues["UM"].ToString();
                }
                if (e.NewValues["Qty"] != null)
                {
                    ma.Qty = e.NewValues["Qty"].ToString();
                }
                if (e.NewValues["DueDate"] != null)
                {
                    ma.DueDate = e.NewValues["DueDate"].ToString();
                }
                if (e.NewValues["CheckingDate"] != null)
                {
                    ma.CheckingDate = e.NewValues["CheckingDate"].ToString();
                }

                if (e.NewValues["UnitPrice"] != null)
                {
                    ma.UnitPrice = e.NewValues["UnitPrice"].ToString();
                }
                if (e.NewValues["Purpose"] != null)
                {
                    ma.Purpose = e.NewValues["Purpose"].ToString();
                }
                if (e.NewValues["StorageStatus"] != null)
                {
                    ma.StorageStatus = e.NewValues["StorageStatus"].ToString();
                }


                ma.SPName = this.ASPxComboBox2.Text;

                ma.Create();
            }
            catch
            {

            }

            e.Cancel = true;
            this.ASPxGridView1.CancelEdit();
            performcallback();
        }

        protected void ASPxGridView2_CustomCallback(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewCustomCallbackEventArgs e)
        {
            IList<PMSMPlan> SPInfosQty = PMSMPlan.FindbyQty("0");
            this.ASPxGridView2.DataSource = SPInfosQty;
            this.ASPxGridView2.DataBind();
        }

        protected void ASPxButton3_Click(object sender, EventArgs e)
        {
            if (this.ASPxTextBox1.Text == ConfigurationSettings.AppSettings["PlanAdmin"].ToString())
            {
                this.ASPxGridView1.Columns[0].Visible = true;
                this.ASPxButton6.Visible = true;
                this.Button2.Visible = true;
            }
        }

        protected void ASPxButton4_Click(object sender, EventArgs e)
        {
            this.ASPxGridViewExporter2.WriteXlsToResponse();
        }

    
        protected void ASPxButton6_Click(object sender, EventArgs e)
        {
            this.ASPxPanel1.Visible = true;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {

                PMSMPlan ma = new PMSMPlan();
                ma.SPName = this.ASPxTextBox2.Text;
                ma.Create();
            }
            catch
            { }

            this.ASPxComboBox2.Items.Clear();
            this.ASPxComboBox2.Items.Add("全部");
            string[] spnames = PMSMPlan.FindbyDistinctQuery();
            for (int i = 0; i < spnames.Length; i++)
            {
                this.ASPxComboBox2.Items.Add(spnames[i]);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                IList<object> ids = this.ASPxGridView1.GetSelectedFieldValues("SPId");
                PMSMPlan ma = PMSMPlan.Find(Convert.ToInt32(ids[0]));
                ma.Delete();

                string spName = this.ASPxComboBox2.Text;
                if (spName != "全部")
                {
                    IList<PMSMPlan> SPInfos = PMSMPlan.FindbySPName(spName);
                    this.ASPxGridView1.DataSource = SPInfos;
                    this.ASPxGridView1.DataBind();
                }
                else
                {
                    IList<PMSMPlan> SPinfos = PMSMPlan.FindAll();
                    this.ASPxGridView1.DataSource = SPinfos;
                    this.ASPxGridView1.DataBind();
                }
            }
            catch { };
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string spname = this.ASPxTextBox2.Text.Trim();
            if (spname != "")
            {
                IList<PMSMPlan> spinfos = PMSMPlan.FindbySPName(spname);
                for (int i = 0; i < spinfos.Count; i++)
                {
                    spinfos[i].Delete();
                }
            }

            this.ASPxComboBox2.Items.Clear();
            this.ASPxComboBox2.Items.Add("全部");
            string[] spnames = PMSMPlan.FindbyDistinctQuery();
            for (int i = 0; i < spnames.Length; i++)
            {
                this.ASPxComboBox2.Items.Add(spnames[i]);
            }
        }

        //protected void ASPxButton7_Click(object sender, EventArgs e)
        //{
        //    //IList<PMSMPlan> SPInfos = PMSMPlan.FindbySPName("三期Okuma");
        //    //for (int i = 0; i < SPInfos.Count; i++)
        //    //{
        //    //    SPInfos[i].Delete();
        //    //}
        //    IList<PMSMPlan> SPInfoss = PMSMPlan.FindbySPName("");
        //    for (int i = 0; i < SPInfoss.Count; i++)
        //    {
        //        SPInfoss[i].SPName = "三期Okuma";
        //        SPInfoss[i].Update();
        //    }
        //}
         
    }
}