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
    public partial class PrintBarCode_SEL : UserControl
    {
        TH.BaseClass.GetBaseData getBaseData = new GetBaseData();
        DAL_BarCodeList DAL = new DAL_BarCodeList();
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
                GetLookUp();

                dtm1.DateTime = DateTime.Today.AddDays(-7);
                dtm2.DateTime = DateTime.Today;
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "加载窗体失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        public PrintBarCode_SEL()
        {
            InitializeComponent();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "xls";
                sF.FileName = this.Text;
                sF.Filter = "Excel文件(*.xls)|*.xls|所有文件(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK == dRes)
                {
                    gridView1.ExportToXls(sF.FileName);
                    MessageBox.Show("导出Excel成功\n\t路径：" + sF.FileName);
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "导出Excel失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        private void tsbClearCon_Click(object sender, EventArgs e)
        {
            try
            {
                lookUpEditcCode1.EditValue = DBNull.Value;
                lookUpEditcCode2.EditValue = DBNull.Value;
             
                lookUpEditcInvCode.EditValue = DBNull.Value;
                lookUpEditcInvName.EditValue = DBNull.Value;

                dtm1.Text = "";
                dtm2.Text = "";

                radioValid.Checked = true;
                radioAllType.Checked = true;

                GetLookUp();
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "清空过滤条件失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }


        private void GetLookUp()
        {
            string sSQL = @"
select distinct ExCode as cCode from dbo._BarCodeRD order by ExCode
";

            DataTable dt = DbHelperSQL.Query(sSQL);
            DataRow dr = dt.NewRow();
            dr["cCode"] = string.Empty;
            dt.Rows.InsertAt(dr, 0);

            lookUpEditcCode1.Properties.DataSource = dt;
            lookUpEditcCode2.Properties.DataSource = dt;

            sSQL = "select cPTCode,cPTName from PurchaseType order by cPTCode";
            dt = DbHelperSQL.Query(sSQL);
            dr = dt.NewRow();
            dr["cPTCode"] = string.Empty;
            dr["cPTName"] = string.Empty;
            dt.Rows.InsertAt(dr, 0);
            lookUpEditcPTCode.Properties.DataSource = dt;
            lookUpEditcPTName.Properties.DataSource = dt;


            sSQL = "select cInvCode,cInvName,cInvStd from Inventory order by cInvCode";
            dt = DbHelperSQL.Query(sSQL);
            dr = dt.NewRow();
            dr["cInvCode"] = string.Empty;
            dr["cInvName"] = string.Empty;
            dr["cInvStd"] = string.Empty;
            dt.Rows.InsertAt(dr, 0);
            lookUpEditcInvCode.Properties.DataSource = dt;
            lookUpEditcInvName.Properties.DataSource = dt;

        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                string sSQL = @"


select a.* ,b.cInvName,b.cInvStd,isnull(c.Qty,0) as UseQty,d.*,e.cPTCode,e.cPTName,InvCode
from dbo._BarCodeRD a  inner join dbo._BarCodeList d on a.barcode = d.barcode
    left join Inventory b on a.cInvCode = b.cInvCode
	left join 
		(
			select sum(case when isnull(RDType,0) = 1 then Qty when  isnull(RDType,0) = 2 then -1 * Qty else 0 end) as Qty,BarCode,InvCode
			from (
				select b.Qty,b.sType,b.RdType,a.BarCode,c.InvCode
				from dbo._BarCodeList a inner join dbo._BarCodeRD b on a.BarCode = b.BarCode
					inner join (
						select a.cCode,b.iRowno,b.autoid,b.cinvcode,b.cbMemo,null as InvCode
						from rdrecord01 a inner join rdrecords01 b 
							on a.id = b.id) c on b.ExsID = c.autoid and c.cCode = b.ExCode and c.iRowno = b.ExRowNo and c.cInvCode = b.cInvCode
						where b.sType = '采购入库单'
							and isnull(a.valid,0) = 1 and isnull(a.Used,0) = 1 
                union
                select b.Qty,b.sType,b.RdType,a.BarCode,c.InvCode
                from dbo._BarCodeList a inner join dbo._BarCodeRD b on a.BarCode = b.BarCode
	                inner join (select a.cCode,b.iRowno,b.autoid,b.cinvcode,b.InvCode from rdrecord11 a inner join rdrecords11 b 
			                on a.id = b.id) c on b.ExsID = c.autoid and c.cCode = b.ExCode and c.iRowno = b.ExRowNo and c.cInvCode = b.cInvCode
                where b.sType = '材料出库单'
	                and isnull(a.valid,0) = 1 and isnull(a.Used,0) = 1 	
                union
                select b.Qty,b.sType,b.RdType,a.BarCode,null as InvCode
                from dbo._BarCodeList a inner join dbo._BarCodeRD b on a.BarCode = b.BarCode
	                inner join (select a.cCode,b.iRowno,b.autoid,b.cinvcode from rdrecord08 a inner join rdrecords08 b 
			                on a.id = b.id) c on b.ExsID = c.autoid and c.cCode = b.ExCode and c.iRowno = b.ExRowNo and c.cInvCode = b.cInvCode
                where b.sType = '其他入库单'
	                and isnull(a.valid,0) = 1 and isnull(a.Used,0) = 1 
                union
                select b.Qty,b.sType,b.RdType,a.BarCode,null as InvCode
                from dbo._BarCodeList a inner join dbo._BarCodeRD b on a.BarCode = b.BarCode
	                inner join (select a.cCode,b.iRowno,b.autoid,b.cinvcode from rdrecord09 a inner join rdrecords09 b 
			                on a.id = b.id) c on b.ExsID = c.autoid and c.cCode = b.ExCode and c.iRowno = b.ExRowNo and c.cInvCode = b.cInvCode
                where b.sType = '其他出库单'
	                and isnull(a.valid,0) = 1 and isnull(a.Used,0) = 1 
                union
                select b.Qty,b.sType,b.RdType,a.BarCode,null as InvCode
                from dbo._BarCodeList a inner join dbo._BarCodeRD b on a.BarCode = b.BarCode
	                inner join (select a.cCode,b.iRowno,b.autoid,b.cinvcode from rdrecord10 a inner join rdrecords10 b 
			                on a.id = b.id) c on b.ExsID = c.autoid and c.cCode = b.ExCode and c.iRowno = b.ExRowNo and c.cInvCode = b.cInvCode
                where b.sType = '产成品入库单'
	                and isnull(a.valid,0) = 1

                union
                select b.Qty,b.sType,b.RdType,a.BarCode,null as InvCode
                from dbo._BarCodeList a inner join dbo._BarCodeRD b on a.BarCode = b.BarCode
	                inner join (select a.cDLCode,b.iRowno,b.autoid,b.cinvcode from DispatchList a inner join DispatchLists b on a.DLID  = b.DLID ) c 
		                on b.ExsID = c.autoid and c.cDLCode = b.ExCode and c.iRowno = b.ExRowNo and c.cInvCode = b.cInvCode
                where b.sType = '销售发货单'
	                and isnull(a.valid,0) = 1 and isnull(a.Used,0) = 1 

                union
                select a.Qty,a.sType,a.RdType,a.BarCode,null as InvCode
                from dbo._BarCodeRD a
                where a.sType = '历史条码打印'

                 union
                select a.Qty,a.sType,a.RdType,a.BarCode,null as InvCode
                from dbo._BarCodeRD a
                where a.sType = '条码数量调整'

                 union
                select a.Qty,a.sType,a.RdType,a.BarCode,null as InvCode
                from dbo._BarCodeRD a
                where a.sType = '期初'  
			) b 
			group by BarCode,InvCode
		) c on a.BarCode = c.BarCode
        left join (
				select a.cPTCode,a.cCode,a.ID,b.AutoID,b.iRowno,b.cInvCode ,c.cPTName 
				from Rdrecord01 a inner join Rdrecords01 b on a.id = b.id
					inner join PurchaseType c on c.cPTCode = a.cPTCode
			) e on e.Autoid = d.ExsID and e.cCode = d.ExCode and d.ExRowNo = e.iRowno and e.cInvCode = d.cInvCode and a.sType = '采购入库单'
where 1=1
order by sCode


";
                if (lookUpEditcCode1.EditValue != null && lookUpEditcCode1.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.ExCode >= '" + lookUpEditcCode1.Text.Trim() + "'");
                }
                if (lookUpEditcCode2.EditValue != null && lookUpEditcCode2.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.ExCode <= '" + lookUpEditcCode2.Text.Trim() + "'");
                }

                if (dtm1.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.CreateDate  >= '" + dtm1.DateTime.ToString("yyyy-MM-dd") + "'");
                }
                if (dtm2.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.CreateDate  < '" + dtm2.DateTime.AddDays(1).ToString("yyyy-MM-dd") + "'");
                }


                if (lookUpEditcInvCode.EditValue != null && lookUpEditcInvCode.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and b.cInvCode = '" + lookUpEditcInvCode.EditValue.ToString().Trim() + "'");
                }
                if (lookUpEditcPTCode.EditValue != null && lookUpEditcPTCode.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and e.cPTCode = '" + lookUpEditcPTCode.EditValue.ToString().Trim() + "'");
                }

                if (radioValid.Checked)
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(c.Qty,0) > 0");
                }
                if (radioRD01.Checked)
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(a.sType,'') = '采购入库单' and isnull(e.cPTCode,'') <> '' and  isnull(e.cPTCode,'') <> '07'");
                }
                if (radioRD0107.Checked)
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(a.sType,'') = '采购入库单' and isnull(e.cPTCode,'') = ''");
                }
                if (radioRD10.Checked)
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(a.sType,'') = '产成品入库单'");
                }
                if (radioRD08.Checked)
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(a.sType,0) = '其他入库单'");
                }
                if (radioRD11.Checked)
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(a.sType,'') = '材料出库单'");
                }
                if (radioDispatchList.Checked)
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(a.sType,'') = '销售发货单'");
                }
                if (radioRD09.Checked)
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(a.sType,'') = '其他出库单'");
                }
                if (radioBarList.Checked)
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(a.sType,'') = '条码数量调整'");
                }
                if (radioQC.Checked)
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(a.sType,'') = '期初'");
                }

                DataTable dt = DbHelperSQL.Query(sSQL);
                gridControl1.DataSource = dt;
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "加载数据失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }     

        private void lookUpEditcInvCode_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lookUpEditcInvName.EditValue = lookUpEditcInvCode.EditValue;
            }
            catch { }
        }

        private void lookUpEditcInvName_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lookUpEditcInvCode.EditValue = lookUpEditcInvName.EditValue;
            }
            catch { }
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

        private void lookUpEditcPTCode_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lookUpEditcPTName.EditValue = lookUpEditcPTCode.EditValue;
            }
            catch { }
        }

        private void lookUpEditcPTName_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lookUpEditcPTCode.EditValue = lookUpEditcPTName.EditValue;
            }
            catch { }
        }

      
    }
}
