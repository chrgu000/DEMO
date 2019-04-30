using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Data.SqlClient;
using System.Data.OracleClient;

namespace 定时任务
{
    public partial class Frm定时任务 : Form
    {
        private string sPathConfig = Application.StartupPath + @"\App.dll";

        bool isSd = false;
        #region 计算
        private uint _Stat;
 
        #region
        public bool GetFormsData(string conn)
        {
            bool b = false;
            progressBar1.Value = 0;
            label2.Text = DateTime.Now.ToString();

            Config oconfig = new Config();
            OracleConnection ocon = new OracleConnection(oconfig.ConnectionString);
            OracleCommand ocmd = new OracleCommand();
            OracleTransaction otrans;
            ocon.Open();
            ocmd.Connection = ocon;
            otrans = ocon.BeginTransaction();
            ocmd.Transaction = otrans;

            try
            {
                Get1(conn, ocmd);
                Get2(conn, ocmd);
                otrans.Commit();
                b = true;
            }
            catch (Exception e)
            {
                b = false;
                otrans.Rollback();
                throw new Exception(e.Message);

            }
            finally
            {
                progressBar1.Value = 0;
                if (ocon.State == ConnectionState.Open)
                {
                    ocon.Close();
                }
            }

            label3.Text = DateTime.Now.ToString();


            return b;
        }

        private void Get1(string conn, OracleCommand ocmd)
        {
            string sSQL = @"
select distinct 发票号码,a.CHB_BILLID as 发票ID 
from CW_SEND_BILL_VW a 
    left join CW_SEND_CHB_LISTS c on a.CHB_BILLID=c.YSB_CHB_BILLID  
where c.YSB_CHB_BILLID is  null";
            DataTable dt = OracleHelp.ExecuteDataTable(sSQL);

            progressBar1.Minimum = 0;
            progressBar1.Maximum = dt.Rows.Count;
            progressBar1.Step = 1;

            sSQL = @"
select a.cVouchID,a.cPzID,cPZNum,b.cbill,b.dbill_date,c.发票id,a.Auto_ID,c.* from Ap_Vouch a left join GL_accvouch b on a.cPzID=b.coutno_id 
left join ERP_IMPORT_SALE c on a.cVouchID=c.cVouchID
where cPZNum is not null AND c.cVouchID IS NOT NULL";
            DataTable dts = SqlHelper.ExecuteDataset(conn, CommandType.Text, sSQL).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow[] dw = dts.Select("发票id='" + dt.Rows[i]["发票ID"].ToString().Trim() + "'");
                if (dw.Length > 0)
                {
                    ocmd.CommandText = @"insert into CW_SEND_CHB_LISTS(YSB_CHB_BILLID,YSB_VOUCHER,YSB_VOUCHER_TM,YSB_VOUCHER_EMPTID) values(
'" + dt.Rows[i]["发票ID"].ToString() + "','" + dw[0]["cPZNum"].ToString().Trim() + "',TO_DATE('" + DateTime.Parse(dw[0]["dbill_date"].ToString().Trim()).ToString("yyyy-MM-dd") + "','YYYY-MM-DD'),'" + dw[0]["cbill"].ToString().Trim() + "')";
                    ocmd.ExecuteNonQuery();
                }
                progressBar1.PerformStep();
            }
        }

        private void Get2(string conn, OracleCommand ocmd)
        {
            string sSQL = @"select a.发票号码,a.发票ID,a.收款单ID,核销ID as 核销单ID from CW_RECE_MONEY_VW a 
left join CW_RECE_BILL_LISTS c on a.收款单ID=c.YRB_REL_ID  where c.YRB_REL_ID is  null";
            DataTable dt = OracleHelp.ExecuteDataTable(sSQL);

            progressBar1.Minimum = 0;
            progressBar1.Maximum = dt.Rows.Count;
            progressBar1.Step = 1;

            sSQL = @"select cVouchID,cPZNum,b.cbill,b.dbill_date,收款单ID from Ap_CloseBill a left join GL_accvouch b on a.cPzID=b.coutno_id 
left join ERP_IMPORT_AP c on a.cVouchID=c.erp收款单单据号 where cPZNum is not null ";
            DataTable dts = SqlHelper.ExecuteDataset(conn, CommandType.Text, sSQL).Tables[0];
            int count = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow[] dw = dts.Select("收款单ID='" + dt.Rows[i]["收款单ID"].ToString().Trim() + "'");
                if (dw.Length > 0)
                {
                    ocmd.CommandText = @"insert into CW_RECE_BILL_LISTS(YRB_CHB_BILLID,YRB_RCV_RCVID,YRB_REL_ID,YRB_VOUCHER,
                        YRB_VOUCHER_TM,YRB_VOUCHER_EMPTID,YRB_TYPE) 
                        values('" + dt.Rows[i]["发票ID"].ToString() + "','" + dt.Rows[i]["核销单ID"].ToString() + "','" + dt.Rows[i]["收款单ID"].ToString() + "','" + dw[0]["cPZNum"].ToString().Trim() + "'," +
                    "TO_DATE('" + DateTime.Parse(dw[0]["dbill_date"].ToString().Trim()).ToString("yyyy-MM-dd") + "','YYYY-MM-DD'),'" + dw[0]["cbill"].ToString().Trim() + "',null)";
                    ocmd.ExecuteNonQuery();
                }
                progressBar1.PerformStep();
            }
        }

        private decimal ReturnDecimal2(object oo)
        {
            decimal o = 0;
            decimal s = 0.00004M;
            if (oo.ToString() != "")
            {
                o =decimal.Parse(oo.ToString());
            }
            decimal o1 = Math.Round(o, 4);
            decimal o2 = Math.Round(o + s, 4);
            if (o2 >= o1)
            {
                return Math.Round(o + s, 4);
            }
            else
            {
                return Math.Round(o, 4);
            }
            //decimal d = 0;
            //try
            //{
            //    d = decimal.Round(Convert.ToDecimal(o), 2);
            //}
            //catch { }
            //return d;
        }


        #endregion

        #endregion


        public Frm定时任务()
        {
            InitializeComponent();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.ToString("HH:mm:ss") == Convert.ToDateTime(timeEdit1.EditValue).ToString("HH:mm:ss"))
            {
                GetGrid();
            }
        }

        private void GetGrid()
        {
            try
            {
                string s1 = GetConfigValue(sPathConfig, "ServerInfo");
                string s2 = GetConfigValue(sPathConfig, "SQLPWD");
                string s3 = GetConfigValue(sPathConfig, "DataBaseInfo");
                string s4 = GetConfigValue(sPathConfig, "SQLUID");
                string sConn = "server=" + s1 + ";uid=" + s4 + ";pwd=" + s2 + ";database=" + s3 + "";

                GetFormsData(sConn);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            isSd = true;
            GetGrid();
            isSd = false;
        }

        ///
        /// Read confing
        /// </summary>
        /// <param name="path"></param>
        /// <param name="appKey"></param>
        /// <returns></returns>
        public string GetConfigValue(string path, string appKey)
        {
            XmlDocument xDoc = new XmlDocument();
            try
            {
                xDoc.Load(path);
                XmlNode xNode;
                XmlElement xElem;
                xNode = xDoc.SelectSingleNode("//appSettings");
                xElem = (XmlElement)xNode.SelectSingleNode("//add[@key='" + appKey + "']");
                if (xElem != null)
                    return xElem.GetAttribute("value");
                else
                    return "";
            }
            catch (Exception)
            {
                return "";
            }
        }

        private void Frm定时任务_Load(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    label2.Text = "";
                    label3.Text = "";

                    this.WindowState = FormWindowState.Normal;  //还原窗体
                    this.ShowInTaskbar = false;  //不显示在系统任务栏
                    notifyIcon1.Visible = true;    //托盘图标可见

                    string s5 = GetConfigValue(sPathConfig, "sTime");
                    timeEdit1.EditValue = s5;

                    this.StartPosition = FormStartPosition.CenterScreen;

                }
                catch { }

                timer1.Start();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.WindowState == FormWindowState.Minimized)
                {
                    this.WindowState = FormWindowState.Normal;  //还原窗体
                    this.ShowInTaskbar = false;  //不显示在系统任务栏
                    notifyIcon1.Visible = true;  //托盘图标显示
                }
                else
                {
                    this.WindowState = FormWindowState.Minimized;
                    this.ShowInTaskbar = false;  //不显示在系统任务栏
                    notifyIcon1.Visible = true;  //托盘图标显示
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void Frm定时任务_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.WindowState == FormWindowState.Minimized)  //判断是否最小化
                {
                    this.ShowInTaskbar = false;  //不显示在系统任务栏
                    notifyIcon1.Visible = true;    //托盘图标可见
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

    }
}
