using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxPopupControl;
using DevExpress.Web.ASPxEditors;
using DevExpress.Data.Filtering;
using System.Collections;

namespace PMMWS
{
    public partial class WorkOrderAdmin : System.Web.UI.Page
    {
        private string typename;    
        
        protected void Page_Load(object sender, EventArgs e)
        {
            dBQuery.DBSuzhouInitialize();
            this.Button1.Attributes.Add("OnClick", "return confirm('确认要删除所选择的工单？')");

            if (dateTimePicker2.Value == null)
            {
                if (this.DropDownList1.Items[this.DropDownList1.SelectedIndex].Value.ToString() != "All")
                {
                    typename = "PMMWS." + this.DropDownList1.Items[this.DropDownList1.SelectedIndex].Value.ToString() + "Order";
                    DataTable dt = dBQuery.GetReflectionResult(typename, "FindAll", "");
                    this.grid.DataSource = dt;
                    this.grid.DataBind();
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
                    this.grid.DataSource = dt;
                    this.grid.DataBind();
                }
            }

            else
            {
                DateTime dateTimePicker1Value = DateTime.Parse(dateTimePicker1.Value.ToString());
                DateTime dateTimePicker2Value = DateTime.Parse(dateTimePicker2.Value.ToString());
                TimeSpan ts = new TimeSpan(23, 59, 59);

                Object[] arguments = new string[] { dateTimePicker1Value.ToString("yyyy-MM-dd HH:mm:ss"), dateTimePicker2Value.Add(ts).ToString("yyyy-MM-dd HH:mm:ss") };

                if (this.DropDownList1.Items[this.DropDownList1.SelectedIndex].Value.ToString() != "All")
                {
                    typename = "PMMWS." + this.DropDownList1.Items[this.DropDownList1.SelectedIndex].Value.ToString() + "Order";
                    DataTable dt = dBQuery.GetReflectionResultByDateTimes(typename, "FindbyDateTime", arguments);
                    this.grid.DataSource = dt;
                    this.grid.DataBind();
                }
                else
                {
                    DataTable dt = dBQuery.GetReflectionResultByDateTimes("PMMWS.MAOrder", "FindbyDateTime", arguments);
                    DataTable dt1 = dBQuery.GetReflectionResultByDateTimes("PMMWS.SMOrder", "FindbyDateTime", arguments);
                    DataTable dt2 = dBQuery.GetReflectionResultByDateTimes("PMMWS.CMOrder", "FindbyDateTime", arguments);
                    DataTable dt3 = dBQuery.GetReflectionResultByDateTimes("PMMWS.HPOrder", "FindbyDateTime", arguments);
                    dt.Merge(dt1);
                    dt.Merge(dt2);
                    dt.Merge(dt3);
                    this.grid.DataSource = dt;
                    this.grid.DataBind();
                }
            }


        }

        protected void grid_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
          
            string id = e.Keys["OrderId"].ToString();
           
            try
            {

                string machinetype = e.OldValues["MachineType"].ToString();

                if (machinetype == "Machining")
                {
                    typename = "PMMWS.MAOrder";
                }
                else if (machinetype == "Composite")
                {
                    typename = "PMMWS.CMOrder";
                }
                else if (machinetype == "Sheet Metal")
                {
                    typename = "PMMWS.SMOrder";
                }
                else if (machinetype == "Actuation")
                {
                    typename = "PMMWS.HPOrder";
                }
            }
            catch
            { }

         

            DataRow dr = dBQuery.GetReflectionResultbyIntId(typename, "Find", Convert.ToInt32(id));
          
            try
            {

                if (e.NewValues["MachineCode"] != null)
                {
                    dr["MachineCode"] = e.NewValues["MachineCode"].ToString();
                }
                if (e.NewValues["FaultInfo"] != null)
                {
                    dr["FaultInfo"] = e.NewValues["FaultInfo"].ToString();
                }
                if (e.NewValues["ST"] != null)
                {
                    dr["ST"] = e.NewValues["ST"].ToString();
                }
                if (e.NewValues["CT"] != null)
                {
                    dr["CT"] = e.NewValues["CT"].ToString();
                    dr["Statues"] = "1";
                }
                if (e.NewValues["AlarmCode"] != null)
                {
                    dr["AlarmCode"] = e.NewValues["AlarmCode"].ToString();
                }
                if (e.NewValues["Operator"] != null)
                {
                    dr["Operator"] = e.NewValues["Operator"].ToString();
                }
                if (e.NewValues["FaultType"] != null)
                {
                    dr["FaultType"] = e.NewValues["FaultType"].ToString();
                }
                if (e.NewValues["MST"] != null)
                {
                    dr["MST"] = e.NewValues["MST"].ToString();
                }
                if (e.NewValues["MCT"] != null)
                {
                    dr["MCT"] = e.NewValues["MCT"].ToString();
                }
                if (e.NewValues["IsEHS"] != null)
                {
                    dr["IsEHS"] = e.NewValues["IsEHS"].ToString();
                }
    

                dBQuery.UpdateReflectionResultByDataRowInt(typename,Convert.ToInt32(id) , dr);
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
            
            //typename = "PMMWS." + this.DropDownList1.Items[this.DropDownList1.SelectedIndex].Value.ToString() + "Order";
            //DataTable dt = dBQuery.GetReflectionResult(typename, "FindAll", "");
            //this.grid.DataSource = dt;
            //this.grid.DataBind();

            if (dateTimePicker2.Value == null)
            {
                if (this.DropDownList1.Items[this.DropDownList1.SelectedIndex].Value.ToString() != "All")
                {



                    typename = "PMMWS." + this.DropDownList1.Items[this.DropDownList1.SelectedIndex].Value.ToString() + "Order";
                    DataTable dt = dBQuery.GetReflectionResult(typename, "FindAll", "");
                    this.grid.DataSource = dt;
                    this.grid.DataBind();


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
                    this.grid.DataSource = dt;
                    this.grid.DataBind();
                }

            }

            else
            {
                DateTime dateTimePicker1Value = DateTime.Parse(dateTimePicker1.Value.ToString());
                DateTime dateTimePicker2Value = DateTime.Parse(dateTimePicker2.Value.ToString());
                TimeSpan ts = new TimeSpan(23, 59, 59);

                Object[] arguments = new string[] { dateTimePicker1Value.ToString("yyyy-MM-dd HH:mm:ss"), dateTimePicker2Value.Add(ts).ToString("yyyy-MM-dd HH:mm:ss") };

                if (this.DropDownList1.Items[this.DropDownList1.SelectedIndex].Value.ToString() != "All")
                {
                    typename = "PMMWS." + this.DropDownList1.Items[this.DropDownList1.SelectedIndex].Value.ToString() + "Order";
                    DataTable dt = dBQuery.GetReflectionResultByDateTimes(typename, "FindbyDateTime", arguments);
                    this.grid.DataSource = dt;
                    this.grid.DataBind();
                }
                else
                {
                    DataTable dt = dBQuery.GetReflectionResultByDateTimes("PMMWS.MAOrder", "FindbyDateTime", arguments);
                    DataTable dt1 = dBQuery.GetReflectionResultByDateTimes("PMMWS.SMOrder", "FindbyDateTime", arguments);
                    DataTable dt2 = dBQuery.GetReflectionResultByDateTimes("PMMWS.CMOrder", "FindbyDateTime", arguments);
                    DataTable dt3 = dBQuery.GetReflectionResultByDateTimes("PMMWS.HPOrder", "FindbyDateTime", arguments);
                    dt.Merge(dt1);
                    dt.Merge(dt2);
                    dt.Merge(dt3);
                    this.grid.DataSource = dt;
                    this.grid.DataBind();
                }
            }

        }

        protected void ASPxButton3_Click(object sender, EventArgs e)
        {
            if (this.ASPxTextBox1.Text == ConfigurationSettings.AppSettings["PlanAdmin"].ToString())
            {
                this.grid.Columns[0].Visible = true;
                this.Button1.Visible = true;
            }
        }

        protected void grid_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
           
          //  Response.Write("<script language='javascript'>confirm('注意删除后无法恢复，请确认！');</script> ");
            string id = e.Keys["OrderId"].ToString();
           
            string machinetype = e.Values["MachineType"].ToString();

            if (machinetype == "Machining")
            {
                typename = "PMMWS.MAOrder";
            }
            else if (machinetype == "Composite")
            {
                typename = "PMMWS.CMOrder";
            }
            else if (machinetype == "Sheet Metal")
            {
                typename = "PMMWS.SMOrder";
            }
            else if (machinetype == "Actuation")
            {
                typename = "PMMWS.HPOrder";
            }
            
            
            try
            {
                dBQuery.DeleteReflectionResultByDataRowInt(typename, Convert.ToInt32(id));
            }
            catch
            {

            }
            e.Cancel = true;
            this.grid.CancelEdit();
            performCallBack();    
        }

        protected void popupControl_WindowCallback(object source, DevExpress.Web.ASPxPopupControl.PopupWindowCallbackArgs e)
        {
            ASPxPopupControl pc = (ASPxPopupControl)source;

            string fieldName = e.Parameter;
            GridViewDataColumn column = (GridViewDataColumn)grid.Columns[fieldName];

            string[] dv = null;

            if (this.DropDownList1.Items[this.DropDownList1.SelectedIndex].Value.ToString() == "MA")
            {
                dv = MAOrder.FindbyDistinctField(fieldName);
            }
            else if (this.DropDownList1.Items[this.DropDownList1.SelectedIndex].Value.ToString() == "CM")
            { 
                dv = CMOrder.FindbyDistinctField(fieldName);
            }

            else if (this.DropDownList1.Items[this.DropDownList1.SelectedIndex].Value.ToString() == "SM")
            {
                dv = SMOrder.FindbyDistinctField(fieldName);
            }

            else if (this.DropDownList1.Items[this.DropDownList1.SelectedIndex].Value.ToString() == "HP")
            {
                dv = HPOrder.FindbyDistinctField(fieldName);
            }
            else if (this.DropDownList1.Items[this.DropDownList1.SelectedIndex].Value.ToString() == "All")
            {
               string[]  dv1 = MAOrder.FindbyDistinctField(fieldName);
               string[] dv2 = CMOrder.FindbyDistinctField(fieldName);
               string[] dv3 = SMOrder.FindbyDistinctField(fieldName);
               string[] dv4 = HPOrder.FindbyDistinctField(fieldName);
               dv = new string[dv1.Length + dv2.Length + dv3.Length + dv4.Length];
               dv1.CopyTo(dv, 0);
               dv2.CopyTo(dv, dv1.Length);
               dv3.CopyTo(dv, dv1.Length+dv2.Length);
               dv4.CopyTo(dv, dv1.Length + dv2.Length + dv3.Length);
                
            }
            else
            { dv = null; };

            for (int i = 0; i < dv.Length; i++)
            {
                ASPxCheckBox checkBox = new ASPxCheckBox();
                checkBox.ClientInstanceName = "cb_" + i.ToString();
                checkBox.Text = dv[i] ;
                checkBox.Checked = IsRowVisible(e.Parameter, dv[i]);
                CheckBoxPanel.Controls.Add(checkBox);
            }
            pc.JSProperties["cpCheckBoxCount"] = dv.Length;
        }

        private bool IsRowVisible(string fieldName, object value)
        {
            string[] field = new string[] { fieldName };
            for (int i = 0; i < grid.VisibleRowCount; i++)
            {
                if (Comparer.Default.Compare(grid.GetRowValues(i, field), value) == 0)
                    return true;
            }
            return false;
        }

        protected void gridView_CustomCallback(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewCustomCallbackEventArgs e)
        {

            if (e.Parameters == "Clear")
            {
                this.grid.FilterExpression = string.Empty;
                return;
            }

            string[] filterString = e.Parameters.Split(new char[] { '|' });
            string fieldName = filterString[0];

            List<string> values = new List<string>();
            for (int i = 1; i < filterString.Length; i++)
                values.Add(filterString[i].Trim());

            this.grid.FilterExpression = new InOperator(fieldName, values).ToString();
        }


        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.grid.FilterExpression = string.Empty;


            if (this.DropDownList1.Items[this.DropDownList1.SelectedIndex].Value.ToString() != "All")
            {
                typename = "PMMWS." + this.DropDownList1.Items[this.DropDownList1.SelectedIndex].Value.ToString() + "Order";
                DataTable dt = dBQuery.GetReflectionResult(typename, "FindAll", "");
                this.grid.DataSource = dt;
                this.grid.DataBind();
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
                this.grid.DataSource = dt;
                this.grid.DataBind();
            }
        }

        protected void ASPxButton4_Click(object sender, EventArgs e)
        {
            if (dateTimePicker2.Value == null)
            {
                if (this.DropDownList1.Items[this.DropDownList1.SelectedIndex].Value.ToString() != "All")
                {

                    typename = "PMMWS." + this.DropDownList1.Items[this.DropDownList1.SelectedIndex].Value.ToString() + "Order";
                    DataTable dt = dBQuery.GetReflectionResult(typename, "FindAll", "");
                    this.grid.DataSource = dt;
                    this.grid.DataBind();
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
                    this.grid.DataSource = dt;
                    this.grid.DataBind();
                }

            }

            else
            {
                DateTime dateTimePicker1Value = DateTime.Parse(dateTimePicker1.Value.ToString());
                DateTime dateTimePicker2Value = DateTime.Parse(dateTimePicker2.Value.ToString());
                TimeSpan ts = new TimeSpan(23,59,59);
               

                Object[] arguments = new string[] { dateTimePicker1Value.ToString("yyyy-MM-dd HH:mm:ss"),  dateTimePicker2Value.Add(ts).ToString("yyyy-MM-dd HH:mm:ss") };

                if (this.DropDownList1.Items[this.DropDownList1.SelectedIndex].Value.ToString() != "All")
                {
                    typename = "PMMWS." + this.DropDownList1.Items[this.DropDownList1.SelectedIndex].Value.ToString() + "Order";
                    DataTable dt = dBQuery.GetReflectionResultByDateTimes(typename, "FindbyDateTime", arguments);
                    this.grid.DataSource = dt;
                    this.grid.DataBind();
                }
                else
                {
                    DataTable dt = dBQuery.GetReflectionResultByDateTimes("PMMWS.MAOrder", "FindbyDateTime", arguments);
                    DataTable dt1 = dBQuery.GetReflectionResultByDateTimes("PMMWS.SMOrder", "FindbyDateTime", arguments);
                    DataTable dt2 = dBQuery.GetReflectionResultByDateTimes("PMMWS.CMOrder", "FindbyDateTime", arguments);
                    DataTable dt3 = dBQuery.GetReflectionResultByDateTimes("PMMWS.HPOrder", "FindbyDateTime", arguments);
                    dt.Merge(dt1);
                    dt.Merge(dt2);
                    dt.Merge(dt3);
                    this.grid.DataSource = dt;
                    this.grid.DataBind();
                }
            }
        }

        protected void grid_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            if (e.Column == grid.Columns["ST"])
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
            if (e.Column == grid.Columns["CT"])
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
            if (e.Column == grid.Columns["MST"])
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
            if (e.Column == grid.Columns["MCT"])
            {
                try
                {
                    if (e.Value != null && e.Value.ToString() != "")
                    {
                        e.DisplayText = Convert.ToDateTime(e.Value.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                }
                catch {
                    e.DisplayText = e.Value.ToString();
                }
            }
            if (e.Column == grid.Columns["WorkerId"])
            {
                try
                {
                    if (e.Value != null && e.Value.ToString() != "")
                    {
                        string workId = e.Value.ToString();
                        Worker work = Worker.Find(workId);
                        e.DisplayText = work.WorkerName;
                    }
                }
                catch
                { 
                  
                }
            }


        }

        protected void grid_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            string Type;

            if ( DropDownList1.SelectedItem.Value == "MA")
            {
                typename = "PMMWS.MAOrder";
                Type = "Machining";

            }
            else if (DropDownList1.SelectedItem.Value == "CM")
            {
                typename = "PMMWS.CMOrder";
                Type = "Composite";
            }
            else if (DropDownList1.SelectedItem.Value == "SM")
            {
                typename = "PMMWS.SMOrder";
                Type = "Sheet Metal";
            }
            else if (DropDownList1.SelectedItem.Value == "HP")
            {
                typename = "PMMWS.HPOrder";
                Type = "Actuation";
            }
            else
            {
                typename = "PMMWS.MAOrder";
                Type = "Machining";
            }

            DataRow dr = dBQuery.GetReflectionResultProperties(typename);

            try
            {

                dr["MachineType"] = Type;

                if (e.NewValues["MachineCode"] != null)
                {
                    dr["MachineCode"] = e.NewValues["MachineCode"].ToString();
                }
                if (e.NewValues["FaultInfo"] != null)
                {
                    dr["FaultInfo"] = e.NewValues["FaultInfo"].ToString();
                }
                if (e.NewValues["ST"] != null)
                {
                    dr["ST"] = e.NewValues["ST"].ToString();
                }
                if (e.NewValues["CT"] != null)
                {
                    dr["CT"] = e.NewValues["CT"].ToString();
                    dr["Statues"] = "1";
                }
                if (e.NewValues["AlarmCode"] != null)
                {
                    dr["AlarmCode"] = e.NewValues["AlarmCode"].ToString();
                }
                if (e.NewValues["Operator"] != null)
                {
                    dr["Operator"] = e.NewValues["Operator"].ToString();
                }
                if (e.NewValues["FaultType"] != null)
                {
                    dr["FaultType"] = e.NewValues["FaultType"].ToString();
                }
                if (e.NewValues["MST"] != null)
                {
                    dr["MST"] = e.NewValues["MST"].ToString();
                }
                if (e.NewValues["MCT"] != null)
                {
                    dr["MCT"] = e.NewValues["MCT"].ToString();
                }

                if (e.NewValues["IsEHS"] != null)
                {
                    dr["IsEHS"] = e.NewValues["IsEHS"].ToString();
                }

            }
            catch
            {

            }
            // Create
            dBQuery.CreateReflectionResult(typename, dr);

            e.Cancel = true;
            this.grid.CancelEdit();
            performCallBack();     
        }

 
        protected void Button1_Click(object sender, EventArgs e)
        {
            //get id and type 
            string id;
            string machinetype;

            IList<object> ids = this.grid.GetSelectedFieldValues("OrderId");
            IList<object> mTs = this.grid.GetSelectedFieldValues("MachineType");


            if (mTs.Count != 0)
            {
                machinetype = mTs[0].ToString();


                if (machinetype == "Machining")
                {
                    typename = "PMMWS.MAOrder";
                }
                else if (machinetype == "Composite")
                {
                    typename = "PMMWS.CMOrder";
                }
                else if (machinetype == "Sheet Metal")
                {
                    typename = "PMMWS.SMOrder";
                }
                else if (machinetype == "Actuation")
                {
                    typename = "PMMWS.HPOrder";
                }
            }

            //Delete Row; 
            try
            {
                dBQuery.DeleteReflectionResultByDataRowInt(typename, Convert.ToInt32(ids[0].ToString()));
            }
            catch
            { };

            //Delete WorkReport 
            try
            {
                if (typename == "PMMWS.MAOrder")
                {
                    IList<MAReport> mas = MAReport.FindbyScanId(ids[0].ToString());
                    if (mas.Count != 0)
                    {
                        mas[0].Delete();
                    }
                }
                else if (typename == "PMMWS.CMOrder")
                {
                    IList<CMReport> mas = CMReport.FindbyScanId(ids[0].ToString());
                    if (mas.Count != 0)
                    {
                        mas[0].Delete();
                    }
                }
                else if (typename == "PMMWS.SMOrder")
                {
                    IList<SMReport> sms = SMReport.FindbyScanId(ids[0].ToString());
                    if (sms.Count != 0)
                    {
                        sms[0].Delete();
                    }
                }
                else if (typename == "PMMWS.HPOrder")
                {
                    IList<HPReport> hps = HPReport.FindbyScanId(ids[0].ToString());
                    if (hps.Count != 0)
                    {
                        hps[0].Delete();
                    }
                }
            }
            catch
            { };

            performCallBack(); 
        }

    
    
    }
}