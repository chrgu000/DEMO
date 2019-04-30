using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;



namespace clsU8
{
    public partial class Frm销售订单导出 : Form
    {
        string s服务器;
        string sSA;
        string sPwd;
        string s数据库;
        string s单据号;
        string sConnString;
        string sUserName;
        int iTaxRate_All = 13;

        public Frm销售订单导出()
        {
            InitializeComponent();
        }


        public Frm销售订单导出(string s1, string s2, string s3, string s4, string s5, string s6)
        {
            InitializeComponent();

            s服务器 = s1;
            sSA = s2;
            sPwd = s3;
            s数据库 = s4;
            s单据号 = s5;
            sUserName = s6;

            sConnString = "server = " + s服务器 + ";uid=" + sSA + ";pwd=" + sPwd + ";database=" + s数据库 + ";timeout = 200";


            try
            {
                string sSQL = @"
select cValue  from AccInformation
Where cSysID=N'PU' and cid=N'166'
";
                DataTable dt = DbHelperSQL.ExecuteDataset(sConnString, CommandType.Text, sSQL).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    iTaxRate_All = BaseFunction.ReturnInt(dt.Rows[0]["cValue"]);
                }

            }
            catch { }
        }
    
        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                  SqlConnection conn = new SqlConnection(sConnString);

                string sSQL = @"
select a.cSOCode as 采购订单号,'02004' as 供应商编号,'301' as 采购部门,'01' as 采购类型,'普通采购' as 业务类型,'人民币' as 币种,1 as 汇率
	,case when isnull(c.cCusInvCode ,'') = '' then b.cInvCode else c.cCusInvCode end as 存货编码
	,b.iQuantity as 数量 ,null as 原币含税单价,bbbbbb as 税率,b.dPreDate as 发运日期,b.dPreDate as 计划到货日期
from so_somain a inner join SO_SODetails b on a.ID = b.ID
	left join CusInvContrapose c on b.cInvCode = c.cInvCode
where a.csocode = 'aaaaaa'
order by b.AutoID
";
                sSQL = sSQL.Replace("aaaaaa", s单据号);
                sSQL = sSQL.Replace("bbbbbb", iTaxRate_All.ToString().Trim());
                DataTable dt = DbHelperSQL.ExecuteDataset(conn, CommandType.Text, sSQL).Tables[0];

                gridControl1.DataSource = dt;

                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "xlsx";
                sF.FileName = "销售订单";
                sF.Filter = "xlsx文件(*.xlsx)|*.xlsx|所有文件(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK != dRes)
                {
                    return;
                }

                gridView1.ExportToXlsx(sF.FileName);

                this.Close();

            }
            catch(Exception ee) 
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            try
            {
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                if (e.Info.IsRowIndicator)
                {
                    if (e.RowHandle >= 0)
                    {
                        e.Info.DisplayText = (e.RowHandle + 1).ToString();
                    }
                    else if (e.RowHandle < 0 && e.RowHandle > -1000)
                    {
                        e.Info.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
                        e.Info.DisplayText = "G" + e.RowHandle.ToString();
                    }
                }
            }
            catch { }
        }

       
    }
}
