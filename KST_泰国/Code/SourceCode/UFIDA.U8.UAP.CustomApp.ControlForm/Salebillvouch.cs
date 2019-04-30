using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using TH.BaseClass;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class Salebillvouch : UserControl
    {
        //public class CmbDataSource
        //{
        //    public string WareHouseCode;
        //    public string WareHouseName;
        //}

        //public class UserMsg
        //{
        //    public string UserCode;
        //    public string UserName;
        //}


        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }

        string sSQL;

        public Salebillvouch()
        {
            InitializeComponent();
        }


        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                gridView1.PostEditor();
                this.Validate();

                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "xls";
                sF.FileName = this.Text;
                sF.Filter = "Excel(*.xls)|*.xls|All files(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK == dRes)
                {
                    gridView1.ExportToXls(sF.FileName);
                    MessageBox.Show("Path：" + sF.FileName);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("Err：" + ee.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                FrmSalebillvouchEdit frm = new FrmSalebillvouchEdit(Conn, sUserID, sUserName, sLogDate, sAccID);
                DialogResult d = frm.ShowDialog();

                btnReflash_Click(null, null);
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载生单界面失败：" + ee.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int iRow = gridView1.FocusedRowHandle;
                if (iRow >= 0)
                {
                    string sGUID = gridView1.GetRowCellValue(iRow, gridColGUID).ToString();
                    if (sGUID == "")
                    {
                        throw new Exception("Please choose data");
                    }

                    FrmSalebillvouchEdit frm = new FrmSalebillvouchEdit(Conn, sUserID, sUserName, sLogDate, sAccID, sGUID);
                    
                    frm.ShowDialog();

                    btnReflash_Click(null, null);
                    gridView1.FocusedRowHandle = iRow;

                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(null, null);
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                dateEdit1.DateTime = BaseFunction.ReturnDate(BaseFunction.ReturnDate(sLogDate).ToString("yyyy-MM-01"));
                dateEdit2.DateTime = BaseFunction.ReturnDate(sLogDate);
                DbHelperSQL.connectionString = Conn;

                btnReflash_Click(null, null);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }


        private void btnReflash_Click(object sender, EventArgs e)
        {
            try
            {
                sSQL = @"
select ds.[GUID],b.SBVID,b.cSBVCode,b.cCusCode,c.cCusName,b.cPersonCode,p.cPersonName,b.cDepCode,d.cDepName,convert(nvarchar(10),b.dDate,120) as dDate,b.cVerifier 
    ,b.cMemo,b.cMaker ,b.dcreatesystime ,b.cVerifier ,dverifydate ,b.cChecker 
from (select distinct SaleBillCode,[GUID] from _DispatchLists_SaleBillVouchs) ds 
    left join SaleBillVouch b on ds.SaleBillCode=b.cSBVCode  
    left join Customer c on b.cCusCode=c.cCusCode
    LEFT JOIN Person P ON b.cPersonCode=p.cPersonCode
    left join Department d on b.cDepCode=d.cDepCode 
where 1=1 
";
                if (dateEdit1.Text != "")
                {
                    sSQL = sSQL.Replace("1=1", " 1=1 and b.dDate >= '" + dateEdit1.DateTime.ToString("yyyy-MM-dd") + "'");
                }
                if (dateEdit2.Text != "")
                {
                    sSQL = sSQL.Replace("1=1", " 1=1 and b.dDate < '" + dateEdit2.DateTime.AddDays(1).ToString("yyyy-MM-dd") + "'");
                }

                DataTable dtGrid = DbHelperSQL.Query(sSQL);
                gridControl1.DataSource = dtGrid;

                gridView1.BestFitColumns();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}