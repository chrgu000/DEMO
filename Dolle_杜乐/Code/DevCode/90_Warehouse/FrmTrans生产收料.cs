using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using FrameBaseFunction;

namespace Warehouse
{
    public partial class FrmTrans生产收料 : FrameBaseFunction.Frm列表窗体模板
    {
        DataTable dtTable ;
        public FrmTrans生产收料()
        {
            InitializeComponent();
        }

        protected override void BtnClick(string sBtnName, string sBtnText)
        {
            try
            {
                switch (sBtnName.ToLower())
                {
                    case "sel":
                        btnSel();
                        break;
                    case "audit":
                        btnAudit();
                        break;
                    case "unaudit":
                        btnUnAudit();
                        break;
                    case "export":
                        btnExport();
                        break;
                    default:
                        MessageBox.Show("该功能尚未提供，请向管理员咨询！");
                        break;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(sBtnText + " 失败! \n\n原因:\n  " + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSel()
        {
            SetGrid();
        }

        private void btnExport()
        {
            try
            {
                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "xls";
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
                MessageBox.Show(ee.Message);
            }
        }

        private void btnUnAudit()
        {
            if (radioUnAudit.Checked)
            {
                MessageBox.Show("请选择已收料列表");
            }

            string sSQL = "";
            string sErr = "";
            ArrayList aList = new ArrayList();

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridColbChoose).ToString().Trim() == "")
                {
                    continue;
                }

                sSQL = "update @u8.TransVouch  set cDefine14 = null where cTVCode = '" + gridView1.GetRowCellValue(i, gridColcTVCode).ToString().Trim() + "'";
                aList.Add(sSQL);

            }
            if (sErr.Trim() != string.Empty)
            {
                FrmMsgBox fMsgBos = new FrmMsgBox();
                fMsgBos.Text = "错误";
                fMsgBos.richTextBox1.Text = "存在以下错误，请修正后继续：\n" + sErr;
                fMsgBos.ShowDialog();
                return;
            }
            if (aList.Count > 0)
            {
                clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("取消收料成功！");
                SetGrid();
            }
        }

        private void btnAudit()
        {
            if (radioAudit.Checked)
            {
                MessageBox.Show("请选择未收料列表");
            }

            string sSQL = "";
            string sErr = "";
            ArrayList aList = new ArrayList();

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridColbChoose).ToString().Trim() == "")
                {
                    continue;
                }

                sSQL = "update @u8.TransVouch  set cDefine14 = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "' where cTVCode = '" + gridView1.GetRowCellValue(i, gridColcTVCode).ToString().Trim() + "'";
                aList.Add(sSQL);

            }
            if (sErr.Trim() != string.Empty)
            {
                FrmMsgBox fMsgBos = new FrmMsgBox();
                fMsgBos.Text = "错误";
                fMsgBos.richTextBox1.Text = "存在以下错误，请修正后继续：\n" + sErr;
                fMsgBos.ShowDialog();
                return;
            }
            if (aList.Count > 0)
            {
                clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("收料成功！");
                SetGrid();
            }
        }

        private void FrmTransVouchAudit_Load(object sender, EventArgs e)
        {
            GetLookUpInfo();
            dateEdit1.Text = FrameBaseFunction.ClsBaseDataInfo.sLogDate;
            dateEdit1.Enabled = true; dateEdit1.Properties.ReadOnly = false;

            lookUpEdit收料班组.Enabled = true;lookUpEdit收料班组.Properties.ReadOnly = false;

            try
            {
                string sSQL = "select * from _UserInfo where vchrUid = '" + FrameBaseFunction.ClsBaseDataInfo.sUid + "'";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt != null && dt.Rows.Count > 0)
                {
                    lookUpEdit收料班组.EditValue = dt.Rows[0]["cDepCode"];
                }
            }
            catch { }

            SetGrid();
        }

        private void SetGrid()
        {
            string sSQL = @"
select cast(null as varchar(2) ) as bChoose,a.出库数量,a.货位数量
	,*
from @u8.TransVouch t inner join @u8.TransVouchs ts on t.cTVCode = ts.cTVCode 
	inner join @u8.Inventory I on I.cInvCode = ts.cInvCode 
	left join (
					select b.iQuantity as 出库数量,b.iTrIds
						,sum(c.iQuantity) as 货位数量
					from @u8.rdrecord09 a 
						inner join @u8.rdrecords09 b on a.ID = b.ID
						inner join @u8.InvPosition c on b.AutoID = c.RdsID 
					group by b.iTrIds,b.iQuantity 
				) a on a.iTrIds = ts.autoID
where year(dTVDate) = '111111' and month(dTVDate) = '222222' and ISNULL(a.货位数量,0) > 0
    and 1=1
order by t.cTVCode,ts.cInvCode
";

            sSQL = sSQL.Replace("111111",dateEdit1.DateTime.Year.ToString().Trim());
            sSQL = sSQL.Replace("222222", dateEdit1.DateTime.Month.ToString().Trim());
            if (lookUpEdit收料班组.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and t.cIDepCode = '" + lookUpEdit收料班组.EditValue + "' ");
            }
            if (radioAudit.Checked)
            {
                sSQL = sSQL.Replace("1=1", "1=1 and isnull(cDefine14,'') <> '' ");
            }
            if (radioUnAudit.Checked)
            {
                sSQL = sSQL.Replace("1=1", "1=1 and isnull(cDefine14,'') = '' ");
            }

            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dt;

            chkAll.Checked = false;
        }

        private void gridView1_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            if ((this.gridView1.GetDataRow(e.RowHandle1)["cTVCode"].ToString() != this.gridView1.GetDataRow(e.RowHandle2)["cTVCode"].ToString()))
                e.Handled = true;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.RowCount < 1)
                    return;
                int iRow = 1;
                if (gridView1.RowCount == 1)
                    iRow = 0;
                else
                    iRow = gridView1.FocusedRowHandle;

                string sID = gridView1.GetRowCellValue(iRow, gridColcTVCode).ToString().Trim();
                if (gridView1.GetRowCellValue(iRow, gridColbChoose).ToString().Trim() == "")
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (gridView1.GetRowCellValue(i, gridColcTVCode).ToString().Trim() == sID)
                        {
                            gridView1.SetRowCellValue(i, gridColbChoose, "√");
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (gridView1.GetRowCellValue(i, gridColcTVCode).ToString().Trim() == sID)
                        {
                            gridView1.SetRowCellValue(i, gridColbChoose, "");
                        }
                    }
                }
            }
            catch (Exception ee)
            { }
        }

        private void GetLookUpInfo()
        {
            string sSQL = "select cDepCode as iID,cDepName as iText from @u8.Department  order by cDepCode";
            ItemLookUpEditDep.DataSource = clsGetSQL.GetLookUpEdit(sSQL);

            sSQL = "select cWhCode as iID,cWhName as iText from @u8.Warehouse   order by cWhCode";
            ItemLookUpEditWH.DataSource = clsGetSQL.GetLookUpEdit(sSQL);

            sSQL = "select cRdCode as iID,cRdName as iText  from @u8.Rd_Style   order by cRdCode";
            ItemLookUpEditRd_Style.DataSource = clsGetSQL.GetLookUpEdit(sSQL);

            sSQL = "select * from @u8.DepartMent where bDepEnd = 1 order by cDepCode";
            lookUpEdit收料班组.Properties.DataSource = clsSQLCommond.ExecQuery(sSQL);
            
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

        private void radioAudit_CheckedChanged(object sender, EventArgs e)
        {
            SetGrid();
        }

        private void radioUnAudit_CheckedChanged(object sender, EventArgs e)
        {
            SetGrid();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAll.Checked)
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        gridView1.SetRowCellValue(i, gridColbChoose, "√");
                    }
                }
                if (!chkAll.Checked)
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        gridView1.SetRowCellValue(i, gridView1.Columns["bChoose"], "");
                    }
                }
            }
            catch
            { }
        }
    }
}