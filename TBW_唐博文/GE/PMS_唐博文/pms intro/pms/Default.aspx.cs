using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace PMMWS
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
       
            string sqlconn = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];
            SqlConnection conn = new SqlConnection(sqlconn);
            conn.Open();

            string[] MachineNames = { "7m_Dorries", "10m", "2m3", "10m7", "16m", "6m3-num", "6m3-fanuc", "3m5", "AFP200", "HBM160-1", "HBM160-2", "HBM150-1", "HBM150-2", "S_PAMA", "AFP180_C1-1", "AFP180_C1-2", "AFP180_C2", "W200HC", "B_PAMA", "HBM130", "NEW-PAMA1", "NEW-PAMA2", "SHW", "5m_1", "5m_2" };
           

            DataTable dtest = new DataTable();
            DataTable dPart = new DataTable();
           
            for (int i = 0; i < MachineNames.Length; i++)
            {
                string strCmd = "select WorkOrderNo,Machine,Description,WorkGroup,AlarmCode,AlarmEndTime,ReportTime,MalfunctionType,IsGotoLive=(case when IsGotoLive ='1' then '是' when IsGotoLive ='0' then '否' when IsGotoLive ='2' then '已到' end)  from [tblWorkOrder_" + MachineNames[i] + "] where OrderStatus = '0' order by ReportTime desc";
                DataTable dt = AdapterFill(strCmd, conn);

                dtest.Merge(dt);
            }
            for (int i = 0; i < dtest.Rows.Count; i++)
            {
                string MachinNames = dtest.Rows[i][2].ToString();
                string MachinPart = "select BU from machineBU where machine = '" + MachineNames[i] + "'";
                DataTable dt1 = AdapterFill(MachinPart, conn);
                dPart.Merge(dt1);
            }

            DataTable newtable = this.UniteDataTable(dtest, dPart, "newtable");
          
            this.ASPxGridView1.DataSource = newtable;
            this.ASPxGridView1.DataBind();

            string queryconn = "select * from Plan_Excel where Plan_Month = " + (this.ASPxComboBox1.SelectedIndex + 1).ToString();
            SqlDataAdapter adp = new SqlDataAdapter(queryconn, conn);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            this.ASPxGridView3.DataSource = ds.Tables[0];
            this.ASPxGridView3.DataBind();
            conn.Close();

            //object aa = this.ASPxGridView1.GetRowValues(0, "AlarmCode");
            //object bb = this.ASPxGridView1.GetRowValues(0, "Machine");
            // MainHistory_Show(aa.ToString(),bb.ToString(),conn);
            //this.ASPxGridView1.Selection.SelectAll();

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
        public void MainHistory_Show(string strAlarmCode, string MachineName, SqlConnection conn)
        {

            conn.Open();
            string[] ssAlarmCode = strAlarmCode.Trim().Split(';');

            if (ssAlarmCode[0] != "&nbsp")
            {
                int[] sAlarmCode = new int[ssAlarmCode.Length - 1];
                for (int i = 0; i < ssAlarmCode.Length - 1; i++)
                {
                    sAlarmCode[i] = Convert.ToInt32(ssAlarmCode[i]);
                }

                for (int i = 1; i < sAlarmCode.Length; i++)
                {
                    for (int j = 0; j < sAlarmCode.Length - 1; j++)
                        if (sAlarmCode[j] > sAlarmCode[j + 1])
                        {
                            int m_Integer = sAlarmCode[j];
                            sAlarmCode[j] = sAlarmCode[j + 1];
                            sAlarmCode[j + 1] = m_Integer;
                        }
                }


                DataTable dtest = new DataTable();
                //   DataTable dt = new DataTable();
                if (sAlarmCode.Length > 0)
                {
                    for (int i = 1; i <= sAlarmCode.Length; i++)
                    {

                        Combinations<int> combinations = new Combinations<int>(sAlarmCode, i);
                        foreach (IList<int> oneCom in combinations)
                        {
                            string ee = GetString<int>(oneCom);
                            string strCmd = "select WorkOrderNo,Machine,ReportTime,AlarmCode,Description,WorkGroup,AlarmTime,AlarmEndTime,StopTime,Engineer,Definition,Location,Reason,Remedy,IsStop =(case when IsStop ='1' then '是' when IsStop ='0' then '否' end),PartName,Attachment from [tblWorkOrder_" + MachineName + "] where (AlarmCode='" + ee + "') and OrderStatus='1'";
                            DataTable dt = AdapterFill(strCmd, conn);
                            dtest.Merge(dt);
                        }

                    }
                    if (dtest.Rows.Count != 0)
                    {
                        this.ASPxGridView2.DataSource = dtest;
                        this.ASPxGridView2.DataBind();
                    }
                    else
                    {
                        string strCmd = "select WorkOrderNo,Machine,ReportTime,AlarmCode,Description,WorkGroup,AlarmTime,AlarmEndTime,StopTime,Engineer,Definition,Location,Reason,Remedy,IsStop =(case when IsStop ='1' then '是' when IsStop ='0' then '否' end),PartName,Attachment from [tblWorkOrder_" + MachineName + "] where (AlarmCode='') and OrderStatus='1'";

                        DataTable dt = AdapterFill(strCmd, conn);

                        this.ASPxGridView2.DataSource = dt;
                        this.ASPxGridView2.DataBind();
                    }
                }
                else
                {
                    string strCmd = "select WorkOrderNo,Machine,ReportTime,AlarmCode,Description,WorkGroup,AlarmTime,AlarmEndTime,StopTime,Engineer,Definition,Location,Reason,Remedy,IsStop =(case when IsStop ='1' then '是' when IsStop ='0' then '否' end),PartName,Attachment from [tblWorkOrder_" + MachineName + "] where (AlarmCode='') and OrderStatus='1'";

                    DataTable dt = AdapterFill(strCmd, conn);

                    this.ASPxGridView2.DataSource = dt;
                    this.ASPxGridView2.DataBind();
                }
            }
            else
            {
                string strCmd = "select WorkOrderNo,Machine,ReportTime,AlarmCode,Description,WorkGroup,AlarmTime,AlarmEndTime,StopTime,Engineer,Definition,Location,Reason,Remedy,IsStop =(case when IsStop ='1' then '是' when IsStop ='0' then '否' end),PartName,Attachment from [tblWorkOrder_" + MachineName + "] where (AlarmCode='') and OrderStatus='1'";

                DataTable dt = AdapterFill(strCmd, conn);

                this.ASPxGridView2.DataSource = dt;
                this.ASPxGridView2.DataBind();
            }
            conn.Close();
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

        protected void ASPxGridView2_BeforeGetCallbackResult(object sender, EventArgs e)
        {
            int aa = this.ASPxGridView1.VisibleRowCount;
            string sqlconn = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];
            SqlConnection conn = new SqlConnection(sqlconn);

            if (aa != 0)
            {
                for (int i = 0; i < aa; i++)
                {
                    if (this.ASPxGridView1.Selection.IsRowSelected(i) == true)
                    {
                        object sAlarmCode = this.ASPxGridView1.GetRowValues(i, "AlarmCode");
                        object MachineName = this.ASPxGridView1.GetRowValues(i, "Machine");
                        MainHistory_Show(sAlarmCode.ToString(), MachineName.ToString(), conn);
                    }
                }

            }
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


    }

    public class Combinations<T> : IEnumerable<IList<T>>
    {
        private List<IList<T>> _combinations;
        private IList<T> _items;
        private int _length;
        private int[] _endIndices;

        public Combinations(IList<T> itemList)
            : this(itemList, itemList.Count)
        {
        }

        public Combinations(IList<T> itemList, int length)
        {
            _items = itemList;
            _length = length;
            _combinations = new List<IList<T>>();
            _endIndices = new int[length];
            int j = length - 1;
            for (int i = _items.Count - 1; i > _items.Count - 1 - length; i--)
            {
                _endIndices[j] = i;
                j--;
            }
            ComputeCombination();
        }

        private void ComputeCombination()
        {
            int[] indices = new int[_length];
            for (int i = 0; i < _length; i++)
            {
                indices[i] = i;
            }

            do
            {
                T[] oneCom = new T[_length];
                for (int k = 0; k < _length; k++)
                {
                    oneCom[k] = _items[indices[k]];
                }
                _combinations.Add(oneCom);
            }
            while (GetNext(indices));
        }

        private bool GetNext(int[] indices)
        {
            bool hasMore = true;

            for (int j = _endIndices.Length - 1; j > -1; j--)
            {
                if (indices[j] < _endIndices[j])
                {
                    indices[j]++;
                    for (int k = 1; j + k < _endIndices.Length; k++)
                    {
                        indices[j + k] = indices[j] + k;
                    }
                    break;
                }
                else if (j == 0)
                {
                    hasMore = false;
                }
            }
            return hasMore;
        }

        public int Count
        {
            get { return _combinations.Count; }
        }

        public IEnumerator<IList<T>> GetEnumerator()
        {
            return _combinations.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return (IEnumerator<IList<T>>)GetEnumerator();
        }

    }
}