using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using TH.BaseClass;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class 高开返利核销单列表 : UserControl
    {
        TH.BaseClass.GetBaseData getBaseData = new GetBaseData();
        
        string sProPath = Application.StartupPath;

        UFIDA.U8.UAP.CustomApp.ControlForm.RepBaseGrid Rep = new RepBaseGrid();

        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                SetLookUp();
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "加载窗体失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }




        public 高开返利核销单列表()
        {
            InitializeComponent();
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

      
        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                }
                catch { }

                SaveFileDialog sa = new SaveFileDialog();
                sa.Filter = "Excel文件2003|*.xls";
                sa.FileName = "高开返利单";

                sa.ShowDialog();
                string sPath = sa.FileName;

                if (sPath.Trim() != string.Empty)
                {
                    gridView1.ExportToXls(sPath);
                    MessageBox.Show("导出列表成功！\n路径：" + sPath);
                }
            }
            catch (Exception ee)
            {
                throw new Exception("导出列表失败：" + ee.Message);
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            string sCode = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridCol单据号).ToString().Trim();
            if (sCode != "")
            {
                Frm高开返利核销单窗体 frm = new Frm高开返利核销单窗体(sCode, Conn, sUserID, sUserName, sLogDate, sAccID);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();

                int iFoc = gridView1.FocusedRowHandle;

                btnSEL_Click(null, null);
                gridView1.FocusedRowHandle = iFoc;
            }
        }

        private void btnSEL_Click(object sender, EventArgs e)
        {
            try
            {
                string sSQL = @"
select case when b.ccuscode is null then c.cVenCode else b.ccuscode end as cCusCode,cus.cCusName
    ,*
from [dbo].[_高开返利核销单]a
	left join [dbo].[_高开返利单] b on a.FLD_iID = b.iID
	left join PurBillVouch c on a.FP_IDs = c.PBVID	
    left join Customer cus on cus.cCusCode =  case when b.ccuscode is null then c.cVenCode else b.ccuscode end 
where 1=1
order by a.iID
";
                if (lookUpEditcCode.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.cCode = '" + lookUpEditcCode.Text.Trim() + "'");
                }
                if (dtm1.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.dtmDate >= '" + dtm1.DateTime.ToString("yyyy-MM-dd") + "'");
                }
                if (dtm2.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.dtmDate < '" + dtm2.DateTime.AddDays(1).ToString("yyyy-MM-dd") + "'");
                }

                if (lookUpEditcCusCode.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and case when b.ccuscode is null then c.cVenCode else b.ccuscode end = '" + lookUpEditcCusCode.EditValue.ToString().Trim() + "'");
                }

                DataTable dt = DbHelperSQL.Query(sSQL);
                gridControl1.DataSource = dt;

                gridView1.BestFitColumns();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载数据失败:" + ee.Message);
            }
        }

        private void SetLookUp()
        {
//            string sSQL = @"
//select cPersonCode,cPersonName from Person order by cPersonCode
//";
//            DataTable dt = DbHelperSQL.Query(sSQL);
//            DataRow dr = dt.NewRow();
//            dt.Rows.InsertAt(dr, 0);

//            lookUpEditcPersonCode.Properties.DataSource = dt;
//            lookUpEditcPersonName.Properties.DataSource = dt;

           string sSQL = @"
select cCusCode,cCusName,cCusAbbName from Customer order by cCusCode
";
            DataTable dt = DbHelperSQL.Query(sSQL);
            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);

            lookUpEditcCusCode.Properties.DataSource = dt;
            lookUpEditcCusName.Properties.DataSource = dt;

            sSQL = @"
select distinct cCode from [dbo].[_高开返利核销单] order by cCode
";
            dt = DbHelperSQL.Query(sSQL);
            dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            lookUpEditcCode.Properties.DataSource = dt;
        }

        private void lookUpEditcCusCode_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEditcCusName.EditValue = lookUpEditcCusCode.EditValue;
        }

        private void lookUpEditcCusName_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEditcCusCode.EditValue = lookUpEditcCusName.EditValue;
        }


    }
}
