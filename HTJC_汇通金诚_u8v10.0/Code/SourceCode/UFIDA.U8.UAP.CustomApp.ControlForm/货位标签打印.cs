using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
//using UFIDA.U8.UAP.CustomApp.ControlForm.Business;
using DevExpress.XtraEditors;
using System.Xml;
using System.Data.SqlClient;


namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class 货位标签打印 : UserControl
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

        string sState = "";

        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }

        public 货位标签打印()
        {
            InitializeComponent();
        }


        private void ProjectManager_Load(object sender, EventArgs e)
        {
            try
            {

                GetLookUp();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载数据失败");
            }
        }

        private void GetLookUp()
        {
            string sSQL = "select * from Inventory order by cInvCode";
            DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
            ItemLookUpEdit存货编码.DataSource = dt;
            ItemLookUpEdit存货名称.DataSource = dt;
            ItemLookUpEdit规格型号.DataSource = dt;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSel_Click(object sender, EventArgs e)
        {
            try
            {
                chk全选.Checked = false;

               string sSQL = @"select   CAST(0 as bit) as 选择,a.cWhCode as 仓库编码,a.cWhName as 仓库名称,b.cPosCode as 货位编码,b.cPosName as 货位名称
from Warehouse a left join Position b on a.cWhCode = b.cWhCode and ISNULL(b.bPosEnd ,0) = 1
order by a.cWhCode,b.cPosCode";

                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];

                grdDetail.DataSource = dt;

                sState = "sel";
            }
            catch (Exception ee)
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

        
        private void chk全选_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                gridView1.SetRowCellValue(i, gridCol选择, chk全选.Checked);
            }
        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                Rep货位标签 rep = new Rep货位标签();
                DataTable dtPrint = rep.dataSet1.Tables[0];


                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (Convert.ToBoolean(gridView1.GetRowCellValue(i, gridCol选择)))
                    {
                        DataRow dr = dtPrint.NewRow();
                        dr["Column1"] = gridView1.GetRowCellValue(i, gridCol仓库编码).ToString().Trim();
                        dr["Column2"] = gridView1.GetRowCellValue(i, gridCol仓库名称).ToString().Trim();
                        dr["Column3"] = gridView1.GetRowCellDisplayText(i, gridCol货位编码).ToString().Trim();
                        dr["Column4"] = gridView1.GetRowCellDisplayText(i, gridCol货位名称).ToString().Trim();
                        dtPrint.Rows.Add(dr);
                    }
                }
                //rep.ShowPreview();
                rep.Print();

                sState = "print";
            }
            catch (Exception ee)
            {
                FrmMsgBox msgBox = new FrmMsgBox();
                msgBox.richTextBox1.Text = ee.Message;
                msgBox.Text = "打印失败";
                msgBox.ShowDialog();
            }
        }
    }
}