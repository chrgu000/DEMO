using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
namespace PMMWS
{
    public partial class ld : System.Web.UI.Page
    {
        DateTime Start { get { return (DateTime)this.dateTimePicker1.Value; } }
        DateTime End { get { return (DateTime)this.dateTimePicker2.Value; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            string sqlconn = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];
            SqlConnection conn = new SqlConnection(sqlconn);
            conn.Open();

            string[] MachineNames = { "7m_Dorries", "10m", "2m3", "10m7", "16m", "6m3-num", "6m3-fanuc", "3m5", "AFP200", "HBM160-1", "HBM160-2", "HBM150-1", "HBM150-2", "S_PAMA", "AFP180_C1-1", "AFP180_C1-2", "AFP180_C2", "W200HC", "B_PAMA", "HBM130", "NEW-PAMA1", "NEW-PAMA2", "SHW", "5m_1", "5m_2" };
            string[] colName = { "工单号", "机床名称", "部门", "报修时间", "描述", "工单类型", "组长", "是否停机", "开始时间", "结束时间", "停机时间", "报警号" };

            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            DataTable dt3 = new DataTable();
            DataTable dt4 = new DataTable();

            for (int i = 0; i < MachineNames.Length; i++)
            {
                string sql = "select WorkOrderNo,Machine,COE=(select BU from machineBU where machine = '" + MachineNames[i] + "'),ReportTime,Description,MalfunctionType,GroupLeader,IsStop=(case when IsStop = '1' then '是' else '否' end),AlarmStartTime,AlarmEndTime,StopTime,AlarmCode from [tblWorkOrder_" + MachineNames[i] + "]  where (AlarmEndTime is NULL  or AlarmEndTime='1900-1-1 0:00:00') and AlarmStartTime<='" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'   order by ReportTime desc";
                dt1 = AdapterFill(sql, conn);
                dt3.Merge(dt1);
                //前一工作周期内完成工单
                if (dateTimePicker2.Value == null) 
                {
                    sql = "select WorkOrderNo,Machine,COE=(select BU from machineBU where machine = '" + MachineNames[i] + "'),ReportTime,Description,MalfunctionType,GroupLeader,IsStop=(case when IsStop = '1' then '是' else '否' end),AlarmStartTime,AlarmEndTime,StopTime,AlarmCode from [tblWorkOrder_" + MachineNames[i] + "]  where (AlarmEndTime>='" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' and AlarmEndTime<='" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')  order by ReportTime desc";
                }
                else
                {
                    DateTime dateTimePicker1Value = DateTime.Parse(dateTimePicker1.Value.ToString());
                    DateTime dateTimePicker2Value = DateTime.Parse(dateTimePicker2.Value.ToString());
                    sql = "select WorkOrderNo,Machine,COE=(select BU from machineBU where machine = '" + MachineNames[i] + "'),ReportTime,Description,MalfunctionType,GroupLeader,IsStop=(case when IsStop = '1' then '是' else '否' end),AlarmStartTime,AlarmEndTime,StopTime,AlarmCode from [tblWorkOrder_" + MachineNames[i] + "]  where (AlarmEndTime>='" + dateTimePicker1Value.ToString("yyyy-MM-dd HH:mm:ss") + "' and AlarmEndTime<='" + dateTimePicker2Value.ToString("yyyy-MM-dd HH:mm:ss") + "')  order by ReportTime desc";
                }
                dt2 = AdapterFill(sql, conn);
                dt4.Merge(dt2);
            }

            this.ASPxGridView1.DataSource = dt3;
            this.ASPxGridView2.DataSource = dt4;
            this.ASPxGridView1.DataBind();
            this.ASPxGridView2.DataBind();


            string queryconn = "select * from Plan_Excel where Plan_Month = " + (this.ASPxComboBox1.SelectedIndex + 1).ToString();
            SqlDataAdapter adp = new SqlDataAdapter(queryconn, conn);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            this.ASPxGridView3.DataSource = ds.Tables[0];
            this.ASPxGridView3.DataBind();
            conn.Close();


        }
        private DataTable UniteDataTable(DataTable dt1, DataTable dt2, string DTName)
        {
            DataTable dt3 = dt1.Clone();
            for (int i = 0; i < dt2.Columns.Count; i++)
            {
                dt3.Columns.Add(dt2.Columns[i].ColumnName);
            }
            object[] obj = new object[dt3.Columns.Count];

            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                dt1.Rows[i].ItemArray.CopyTo(obj, 0);
                dt3.Rows.Add(obj);
            }

            if (dt1.Rows.Count >= dt2.Rows.Count)
            {
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    for (int j = 0; j < dt2.Columns.Count; j++)
                    {
                        dt3.Rows[i][j + dt1.Columns.Count] = dt2.Rows[i][j].ToString();
                    }
                }
            }
            else
            {
                DataRow dr3;
                for (int i = 0; i < dt2.Rows.Count - dt1.Rows.Count; i++)
                {
                    dr3 = dt3.NewRow();
                    dt3.Rows.Add(dr3);
                }
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    for (int j = 0; j < dt2.Columns.Count; j++)
                    {
                        dt3.Rows[i][j + dt1.Columns.Count] = dt2.Rows[i][j].ToString();
                    }
                }
            }
            dt3.TableName = DTName; //设置DT的名字
            return dt3;
        }


        public DataTable AdapterFill(string cmd, SqlConnection conn)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(cmd, conn);
            adp.Fill(dt);
            return dt;
        }


        static string GetString<T>(IList<T> list)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (T item in list)
            {
                sb.Append(item.ToString() + ";");
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append(";");
            return sb.ToString();

        }


        protected void ASPxGridView2_CustomCallback(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewCustomCallbackEventArgs e)
        {
            string sqlconn = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];
            SqlConnection conn = new SqlConnection(sqlconn);
            conn.Open();

            string[] MachineNames = { "7m_Dorries", "10m", "2m3", "10m7", "16m", "6m3-num", "6m3-fanuc", "3m5", "AFP200", "HBM160-1", "HBM160-2", "HBM150-1", "HBM150-2", "S_PAMA", "AFP180_C1-1", "AFP180_C1-2", "AFP180_C2", "W200HC", "B_PAMA", "HBM130", "NEW-PAMA1", "NEW-PAMA2", "SHW", "5m_1", "5m_2" };
            string[] colName = { "工单号", "机床名称", "部门", "报修时间", "描述", "工单类型", "组长", "是否停机", "开始时间", "结束时间", "停机时间", "报警号" };

            string[] dateFormats = e.Parameters.ToString().Split(new char[] { ' ' });
            string month = "";

            switch (dateFormats[1])
            {
                case "Jan":
                    month = "1";
                    break;
                case "Feb":
                    month = "2";
                    break;
                case "Mar":
                    month = "3";
                    break;
                case "Apr":
                    month = "4";
                    break;
                case "May":
                    month = "5";
                    break;
                case "Jun":
                    month = "6";
                    break;
                case "Jul":
                    month = "7";
                    break;
                case "Aug":
                    month = "8";
                    break;
                case "Sep":
                    month = "9";
                    break;
                case "Oct":
                    month = "10";
                    break;
                case "Nov":
                    month = "11";
                    break;
                case "Dec":
                    month = "12";
                    break;
                default:
                    break;
            }

            string dateValue = dateFormats[5] + "-" + month + "-" + dateFormats[2] + "  " + dateFormats[3];

            // DateTime dateTimePicker2Value = DateTime.Parse(dateValue);
            //dateTimePicker2Value.ToString("yyyy-MM-dd HH:mm:ss");
            DateTime dateTimePicker2Value = DateTime.Parse(dateTimePicker2.Value.ToString());

            DateTime dateTimePicker1Value = DateTime.Parse(dateTimePicker1.Value.ToString());
            //dateTimePicker1Value.ToString("yyyy-MM-dd HH:mm:ss");

            DataTable dt2 = new DataTable();
            DataTable dt4 = new DataTable();
            for (int i = 0; i < MachineNames.Length; i++)
            {
                string sql = "select WorkOrderNo,Machine,COE=(select BU from machineBU where machine = '" + MachineNames[i] + "'),ReportTime,Description,MalfunctionType,GroupLeader,IsStop=(case when IsStop = '1' then '是' else '否' end),AlarmStartTime,AlarmEndTime,StopTime,AlarmCode from [tblWorkOrder_" + MachineNames[i] + "]  where (AlarmEndTime>='" + dateTimePicker1Value.ToString("yyyy-MM-dd HH:mm:ss") + "' and AlarmEndTime<='" + dateTimePicker2Value.ToString("yyyy-MM-dd HH:mm:ss") + "')  order by ReportTime desc";
                dt2 = AdapterFill(sql, conn);
                dt4.Merge(dt2);
            }

            this.ASPxGridView2.DataSource = dt4;
            this.ASPxGridView2.DataBind();
        }


        protected void ASPxGridView3_CustomCallback(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewCustomCallbackEventArgs e)
        {
            string sqlconn = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];
            SqlConnection conn = new SqlConnection(sqlconn);

            string month = e.Parameters.ToString();

            string queryconn = "select * from Plan_Excel where Plan_Month = " + month;
            SqlDataAdapter adp = new SqlDataAdapter(queryconn, conn);
            conn.Open();

            DataSet ds = new DataSet();
            adp.Fill(ds);

            this.ASPxGridView3.DataSource = ds.Tables[0];
            this.ASPxGridView3.DataBind();

            conn.Close();
        }

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    string sqlconn = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];
        //    SqlConnection conn = new SqlConnection(sqlconn);
        //    conn.Open();

        //    string[] MachineNames = { "7m_Dorries", "10m", "2m3", "10m7", "16m", "6m3-num", "6m3-fanuc", "3m5", "AFP200", "HBM160-1", "HBM160-2", "HBM150-1", "HBM150-2", "S_PAMA", "AFP180_C1-1", "AFP180_C1-2", "AFP180_C2", "W200HC", "B_PAMA", "HBM130", "NEW-PAMA1", "NEW-PAMA2", "SHW", "5m_1", "5m_2" };
        //    string[] colName = { "工单号", "机床名称", "部门", "报修时间", "描述", "工单类型", "组长", "是否停机", "开始时间", "结束时间", "停机时间", "报警号" };
        //    DataTable dt1 = new DataTable();
        //    DataTable dt2 = new DataTable();
        //    DataTable dt3 = new DataTable();
        //    DataTable dt4 = new DataTable();
        //    for (int i = 0; i < MachineNames.Length; i++)
        //    {
        //        string sql = "select WorkOrderNo,Machine,COE=(select BU from machineBU where machine = '" + MachineNames[i] + "'),ReportTime,Description,MalfunctionType,GroupLeader,IsStop=(case when IsStop = '1' then '是' else '否' end),AlarmStartTime,AlarmEndTime,StopTime,AlarmCode from [tblWorkOrder_" + MachineNames[i] + "]  where (AlarmEndTime is NULL  or AlarmEndTime='1900-1-1 0:00:00') and AlarmStartTime<='" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'   order by ReportTime desc";
        //        dt1 = AdapterFill(sql, conn);
        //        dt3.Merge(dt1);
        //        //前一工作周期内完成工单
        //        sql = "select WorkOrderNo,Machine,COE=(select BU from machineBU where machine = '" + MachineNames[i] + "'),ReportTime,Description,MalfunctionType,GroupLeader,IsStop=(case when IsStop = '1' then '是' else '否' end),AlarmStartTime,AlarmEndTime,StopTime,AlarmCode from [tblWorkOrder_" + MachineNames[i] + "]  where (AlarmEndTime>='" + this.dateTimePicker1.Text + "' and AlarmEndTime<='" + this.dateTimePicker2.Text + "')  order by ReportTime desc";
        //        dt2 = AdapterFill(sql, conn);
        //        dt4.Merge(dt2);
        //    }

        //    this.ASPxGridView1.DataSource = dt3;
        //    this.ASPxGridView2.DataSource = dt4;
        //    this.ASPxGridView1.DataBind();
        //    this.ASPxGridView2.DataBind();

        //    string queryconn = "select * from Plan_Excel where Plan_Month = " + (this.ASPxComboBox1.SelectedIndex + 1).ToString();
        //    SqlDataAdapter adp = new SqlDataAdapter(queryconn, conn);
        //    DataSet ds = new DataSet();
        //    adp.Fill(ds);
        //    this.ASPxGridView3.DataSource = ds.Tables[0];
        //    this.ASPxGridView3.DataBind();

        //    conn.Close();
        //}


    }
}