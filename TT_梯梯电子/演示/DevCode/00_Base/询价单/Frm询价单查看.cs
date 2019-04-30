using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using FrameBaseFunction;
using System.IO;
using System.Data.SqlClient;


namespace Base
{
    public partial class Frm询价单查看 : FrameBaseFunction.Frm列表窗体模板
    {
        string sGuid = "";
 
        string sType = "";
        public Frm询价单查看(string s)
        {
            InitializeComponent();

            sGuid = s;

            labelGUID.Text = s;

            //base.toolStripMenuBtn.Items["audit"].Visible = true;
            //base.toolStripMenuBtn.Items["unaudit"].Visible = true;

            toolStripMenuBtn.Visible = false;
        }

        #region 按钮模板

        protected override void BtnClick(string sBtnName, string sBtnText)
        {
            try
            {
                switch (sBtnName.ToLower())
                {

                    case "audit":
                        btnAudit();
                        break;
                    case "unaudit":
                        btnUnAudit();
                        break;
                    default:
                        break;
                }

                sState = sBtnName.ToLower();
            }
            catch (Exception ee)
            {
                throw new Exception(sBtnText + " 失败! \n\n原因:\n  " + ee.Message);
            }
        }

        private void btnUnAudit()
        {
            try
            {
                try
                {
                    gridView2.FocusedRowHandle -= 1;
                    gridView2.FocusedRowHandle += 1;
                }
                catch { }

                string sErr = "";

                ArrayList aList = new ArrayList();

                bool b = false;

                string sSQL = "select * from UFDLImport..询价单供应商报价 where isnull(审批结论,'') <> '' and [GUID] = '" + labelGUID.Text.Trim() + "'";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt == null || dt.Rows.Count == 0)
                {
                    throw new Exception("尚未审核");
                }


                sSQL = "update UFDLImport..询价单供应商报价 set 审批结论 = null,审批人 = null,审批日期 = null where [GUID] = '" + sGuid + "'";
                clsSQLCommond.ExecSql(sSQL);


                MessageBox.Show("弃审成功");

                SetValue();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

        }
        private void btnAudit()
        {
            try
            {
                try
                {
                    gridView2.FocusedRowHandle -= 1;
                    gridView2.FocusedRowHandle += 1;
                }
                catch { }

                string sErr = "";

                ArrayList aList = new ArrayList();

                bool b = false;

                string sSQL = "select * from UFDLImport..询价单供应商报价 where isnull(审批结论,'') <> '' and [GUID] = '" + labelGUID.Text.Trim() + "'";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt != null && dt.Rows.Count > 0)
                {
                    throw new Exception("已经审核");
                }

                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    bool bChoose = Convert.ToBoolean(gridView2.GetRowCellValue(i, gridCol_选择));

                    string sGuid物料 = gridView2.GetRowCellValue(i, gridCol_GUID物料).ToString().Trim();
                    string sGuid = labelGUID.Text.Trim();
                    string sVenCode = gridView2.GetRowCellValue(i, gridCol_供应商编码).ToString().Trim();

                    if (bChoose)
                    {
                        decimal d单价 = ReturnObjectToDecimal(gridView2.GetRowCellValue(i, gridCol_单价), 6);
                        if (d单价 == 0)
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "供应商未报价\n";
                            continue;
                        }

                        sSQL = "update UFDLImport..询价单供应商报价 set 审批结论 = '通过',审批人 = '" + FrameBaseFunction.ClsBaseDataInfo.sUid + "',审批日期 = getdate() where 供应商编码 = '" + sVenCode + "' and [GUID] = '" + sGuid + "' and GUID物料 = '" + sGuid物料 + "'";
                        aList.Add(sSQL);

                        b = true;
                    }
                    else
                    {
                        sSQL = "update UFDLImport..询价单供应商报价 set 审批结论 = '不通过',审批人 = '" + FrameBaseFunction.ClsBaseDataInfo.sUid + "',审批日期 = getdate() where 供应商编码 = '" + sVenCode + "' and [GUID] = '" + sGuid + "' and GUID物料 = '" + sGuid物料 + "'";
                        aList.Add(sSQL);
                    }
                }

                if (sErr.Trim() != "")
                {
                    throw new Exception(sErr);
                }

                if (!b)
                {
                    throw new Exception("请选择数据");
                }

                clsSQLCommond.ExecSqlTran(aList);

                MessageBox.Show("审核成功");

                SetValue();

                //                //发送邮件


                //                //

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

      
        /// <summary>
        /// 输出
        /// </summary>
        private void btnExport()
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
                    gridView2.ExportToXls(sF.FileName);
                    MessageBox.Show("导出Excel成功\n\t路径：" + sF.FileName);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

      
        #endregion

        private void SetValue()
        {
            string sSQL = @"
select case when isnull(c.审批结论,'') = '通过' then CAST(1 as bit) else CAST(0 as bit) end as 选择
    , b.供应商编码,d.cVenName as 供应商,aa.自定义物料,aa.物料编码,c.单价,aa.数量,c.送样周期,aa.GUID物料,aa.备注1
	,e.附件名,c.审批人,c.审批日期,c.审批结论,c.[供应商备注]
from UFDLImport..询价单 a inner join UFDLImport..询价单物料列表 aa on a.GUID = aa.GUID
	inner join UFDLImport..询价单供应商 b on a.GUID = b.GUID 
	left join UFDLImport..询价单供应商报价 c on c.GUID = a.guid and aa.GUID物料 = c.GUID物料 and b.供应商编码 = c.供应商编码
	inner join @u8.vendor d on b.供应商编码 = d.cVenCode
	left join UFDLImport..询价单附件 e on e.GUID物料 = aa.GUID物料
where a.[GUID] = '111111'
order by aa.自定义物料,aa.物料编码,b.供应商编码

";
            sSQL = sSQL.Replace("111111", sGuid);
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            gridControl2.DataSource = dt;

            sSQL = @"
select a.* ,b.*,c.cVenName
from UFDLImport..询价单 a inner join UFDLImport..询价单供应商 b on a.GUID = b.GUID 
    left join @u8.Vendor c on b.供应商编码 = c.cVenCode
where a.GUID = '111111'
";
            sSQL = sSQL.Replace("111111", sGuid);
             dt = clsSQLCommond.ExecQuery(sSQL);


            txt主题.Text = dt.Rows[0]["标题"].ToString().Trim();
            richTextBox备注.Text = dt.Rows[0]["备注"].ToString().Trim();
            dtm截止.Text = Convert.ToDateTime(dt.Rows[0]["截止日期"]).ToString("yyyy-MM-dd");
            lookUpEditTime.EditValue = Convert.ToDateTime(dt.Rows[0]["截止日期"]).ToString("HH:ss");
            txt终止日期.Text = dt.Rows[0]["终止询价日期"].ToString().Trim();
            dtm单据日期.DateTime = Convert.ToDateTime(dt.Rows[0]["单据日期"]);
            txt制单人.EditValue = dt.Rows[0]["制单人"].ToString().Trim();
            date制单日期.Text = dt.Rows[0]["制单日期"].ToString().Trim();
            txt发布人.EditValue = dt.Rows[0]["发布人"].ToString().Trim();
            date_发布日期.Text = dt.Rows[0]["发布日期"].ToString().Trim();
        }


        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                dtm单据日期.DateTime = DateTime.Today;
                dtm截止.DateTime = DateTime.Today;

                SetLookUp();

                SetValue();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            }
        }

        private void gridView_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

        private void btn审核_Click(object sender, EventArgs e)
        {
           
        }

//        private void btn不通过_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                string sSQL = @"
//select a.* ,getdate() as 当前时间
//from 询价单 a inner join 询价单供应商 b on a.[GUID] = b.[GUID]
//where a.[GUID] = '111111' and b.供应商编码 = '222222' 
//";
//                sSQL = sSQL.Replace("111111", sGuid);
//                sSQL = sSQL.Replace("222222", txt供应商编码.Text.Trim());
//                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
//                if (dt == null || dt.Rows.Count == 0)
//                {
//                    throw new Exception("获得询价单失败");
//                }
//                if (dt.Rows[0]["发布人"].ToString().Trim() == "")
//                {
//                    throw new Exception("尚未发布");
//                }
//                DateTime d当前时间 = Convert.ToDateTime(dt.Rows[0]["当前时间"]);
//                DateTime d截止日期 = Convert.ToDateTime(dt.Rows[0]["截止日期"]);
//                DateTime d终止日期 = Convert.ToDateTime("2099-12-31");
//                if (dt.Rows[0]["终止询价日期"].ToString().Trim() != "")
//                {
//                    d终止日期 = Convert.ToDateTime(dt.Rows[0]["终止询价日期"]);
//                }
//                if (d当前时间 < d截止日期 && d当前时间 < d终止日期)
//                {
//                    throw new Exception("尚未到期限，不能审批");
//                }

//                sSQL = "update 询价单供应商 set 审批结论 = '不通过',审批时间 = getdate(),审批人 = '" + FrameBaseFunction.ClsBaseDataInfo.sUid + "' where guid = '" + sGuid + "' and 供应商编码 = '" + txt供应商编码.Text.Trim() + "'";

//                int iCou = clsSQLCommond.ExecSql(sSQL);
//                if (iCou > 0)
//                {
//                    MessageBox.Show("审核不通过");

//                    radio不通过.Checked = true;
//                }
//            }
//            catch (Exception ee)
//            {
//                MessageBox.Show(ee.Message);
//            }
//        }

        private void btn退出_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void SetLookUp()
        {
            string sSQL = "select cInvCode,cInvName,cInvStd from @u8.Inventory order by cInvCode";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            DataRow dr2 = dt.NewRow();
            dt.Rows.InsertAt(dr2, 0);

            ItemLookUpEdit_cInvName.DataSource = dt;
            ItemLookUpEdit_cInvStd.DataSource = dt;

            dt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "Time";
            dt.Columns.Add(dc);

            for (int i = 0; i < 24; i++)
            {
                DataRow dr = dt.NewRow();

                string sHour = i.ToString();
                while (sHour.Length < 2)
                {
                    sHour = "0" + sHour;
                }

                dr["Time"] = sHour + ":00";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Time"] = sHour + ":30";
                dt.Rows.Add(dr);
            }
            lookUpEditTime.Properties.DataSource = dt;
            lookUpEditTime.EditValue = "16:30";


            sSQL = "select  vchrUid, vchrName from _UserInfo order by vchrUid";
            dt = clsSQLCommond.ExecQuery(sSQL);
            txt制单人.Properties.DataSource = dt;
            txt发布人.Properties.DataSource = dt;
        }


        private decimal ReturnObjectToDecimal(object o, int iL)
        {
            decimal i = 0;
            try
            {
                i = Convert.ToDecimal(o);
                i = decimal.Round(i, iL);
            }
            catch { }
            return i;
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            try
            {
                gridView2.AddNewRow();
            }
            catch { }
        }

        private void btnDelRow_Click(object sender, EventArgs e)
        {
            try
            {
                gridView2.DeleteRow(gridView2.FocusedRowHandle);
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "提示";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        private void gridView2_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
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

        private void gridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                string s1 = gridView2.GetRowCellValue(e.RowHandle, gridCol_cInvCode).ToString().Trim();
                string s2 = gridView2.GetRowCellValue(e.RowHandle, gridCol_自定义物料).ToString().Trim();
                if (s1 != "" || s2 != "")
                {
                    string sGuid = gridView2.GetRowCellValue(e.RowHandle, gridCol_GUID物料).ToString().Trim();
                    if (sGuid == "")
                    {
                        Guid g = Guid.NewGuid();
                        gridView2.SetRowCellValue(e.RowHandle, gridCol_GUID物料, g.ToString());
                    }
                }
            }
            catch { }
        }

        private void ItemButtonEditcInvCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                try
                {
                    gridView2.FocusedColumn = gridCol_GUID物料;
                    gridView2.FocusedColumn = gridCol_cInvCode;
                }
                catch { }

                string sInvCode = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridCol_cInvCode).ToString().Trim();
                FrmInvInfo fInv = new FrmInvInfo(sInvCode);
                if (DialogResult.OK == fInv.ShowDialog())
                {
                    gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridCol_cInvCode, fInv.sInvCode);
                    //gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridCol_cInvName, fInv.sInvName);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int iRow = gridView2.FocusedRowHandle;
                if (Convert.ToBoolean(gridView2.GetRowCellValue(iRow, gridCol_选择)))
                {
                    gridView2.SetRowCellValue(iRow, gridCol_选择, false);
                }
                else
                {
                    gridView2.SetRowCellValue(iRow, gridCol_选择, true);

                    string scInvCode = gridView2.GetRowCellValue(iRow, gridCol_cInvCode).ToString().Trim();
                    string s自定义物料 = gridView2.GetRowCellValue(iRow, gridCol_自定义物料).ToString().Trim();

                    for (int i = 0; i < gridView2.RowCount; i++)
                    {
                        if (i == iRow)
                            continue;

                        string scInvCode2 = gridView2.GetRowCellValue(i, gridCol_cInvCode).ToString().Trim();
                        string s自定义物料2 = gridView2.GetRowCellValue(i, gridCol_自定义物料).ToString().Trim();

                        if (scInvCode == scInvCode2 && s自定义物料 == s自定义物料2)
                        {
                            gridView2.SetRowCellValue(i, gridCol_选择, false);
                        }
                    }
                }
            }
            catch { }
        }

        private void gridView2_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            try
            {
                if ((this.gridView2.GetDataRow(e.RowHandle1)["物料编码"].ToString() != this.gridView2.GetDataRow(e.RowHandle2)["物料编码"].ToString())
                    || (this.gridView2.GetDataRow(e.RowHandle1)["自定义物料"].ToString() != this.gridView2.GetDataRow(e.RowHandle2)["自定义物料"].ToString())
                    )
                    e.Handled = true;
            }
            catch { }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Audit_Click(object sender, EventArgs e)
        {
            btnAudit();
        }

        private void btn_UnAudit_Click(object sender, EventArgs e)
        {
            btnUnAudit();
        }
    }
}