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


namespace Base
{
    public partial class Frm询价单供应商Edit : Form
    {
        FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();
        FrameBaseFunction.ClsGetSQL clsGetSQL = FrameBaseFunction.ClsGetSQL.Instance();

        string sGuid = "";
        string sVenCode = "";
        string sType = "";

        public Frm询价单供应商Edit(string s,string sVen)
        {
            InitializeComponent();

            sGuid = s;
            sVenCode = sVen;

            labelGUID.Text = s;
        }

        #region 按钮模板

      
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
select * ,getdate() as 当前时间
from UFDLImport..询价单 a inner join UFDLImport..询价单供应商 b on a.GUID = b.GUID 
where a.GUID = '111111' and b.供应商编码 = '222222'
";
            sSQL = sSQL.Replace("111111", sGuid);
            sSQL = sSQL.Replace("222222", lookUpEditcVenCode.EditValue.ToString().Trim());
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt == null || dt.Rows.Count == 0)
            {
                SetNull();
                return;
            }

            DateTime d截止时间 = Convert.ToDateTime(dt.Rows[0]["截止日期"]);
            DateTime d终止时间 = Convert.ToDateTime("2099-12-31");
            if (dt.Rows[0]["终止询价日期"].ToString().Trim() != "")
            {
                d终止时间 = Convert.ToDateTime(dt.Rows[0]["终止询价日期"]);
            }
            DateTime d当前时间 = Convert.ToDateTime(dt.Rows[0]["当前时间"]);
            if (d当前时间 > d终止时间 || d当前时间 > d截止时间.AddHours(2))
            {
                gridView2.OptionsBehavior.Editable = false;
                btn撤销.Enabled = false;
                btn提交.Enabled = false;
            }
            else
            {
                gridView2.OptionsBehavior.Editable = true;
                btn撤销.Enabled = true;
                btn提交.Enabled = true;
            }

            sSQL = @"
select a.iID, a.[GUID], a.自定义物料, a.物料编码, a.数量 as 要求数量, a.送样周期 as 要求送样周期, a.备注1, a.备注2, a.备注3, a.GUID物料
	, b.单价, b.供应商编码, b.提交人, b.提交时间, b.供应商备注 as 供应商备注,b.数量,b.送样周期
    ,c.附件名 as 下载附件
    ,b.审批人,b.审批日期,b.审批结论
from UFDLImport..询价单物料列表 a left join UFDLImport..询价单供应商报价 b on a.GUID物料 = b.GUID物料 and b.供应商编码 = '111111'
    left join UFDLImport..询价单附件 c on c.GUID物料 = a.GUID物料
where 1=1
order by a.iID

";
            sSQL = sSQL.Replace("111111", lookUpEditcVenCode.EditValue.ToString().Trim());
            sSQL = sSQL.Replace("1=1","1=1 and a.GUID = '" + sGuid + "'");
            DataTable dt物料列表 = clsSQLCommond.ExecQuery(sSQL);
            gridControl2.DataSource = dt物料列表;

            txt主题.Text = dt.Rows[0]["标题"].ToString().Trim();
            richTextBox备注.Text = dt.Rows[0]["备注"].ToString().Trim();
            dtm截止.Text = Convert.ToDateTime(dt.Rows[0]["截止日期"]).ToString("yyyy-MM-dd");
            txt终止日期.Text = dt.Rows[0]["终止询价日期"].ToString().Trim();
            lookUpEditTime.EditValue =  Convert.ToDateTime(dt.Rows[0]["截止日期"]).ToString("HH:mm");
            dtm单据日期.DateTime = Convert.ToDateTime(dt.Rows[0]["单据日期"]);
            txt制单人.EditValue = dt.Rows[0]["制单人"].ToString().Trim();
            date制单日期.Text = dt.Rows[0]["制单日期"].ToString().Trim();
            txt发布人.EditValue = dt.Rows[0]["发布人"].ToString().Trim();
            date_发布日期.Text = dt.Rows[0]["发布日期"].ToString().Trim();

            txt提交人.EditValue = dt物料列表.Rows[0]["提交人"].ToString().Trim();
            txt提交日期.Text = dt物料列表.Rows[0]["提交时间"].ToString().Trim();
        }

        private void SetNull()
        {
            txt主题.Text = "";
            richTextBox备注.Text = "";
            dtm截止.DateTime = DateTime.Today;
            dtm单据日期.DateTime = DateTime.Today;
            txt制单人.Text = "";
            date制单日期.Text = "";
            txt发布人.Text = "";
            date_发布日期.Text = "";
            labelGUID.Text = "";
            sGuid = "";

            string sSQL = "select cast(0 as bit) as bChoose,* from UFDLImport..询价单物料列表 where 1=-1";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            gridControl2.DataSource = dt;

            txt主题.Focus();
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                string sSQL = "select * from UFDLImport..询价单 where [GUID] = '" + sGuid + "'";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt == null || dt.Rows.Count == 0)
                {
                    throw new Exception("获得询价单信息失败");
                }
                if (dt.Rows[0]["结案人"].ToString().Trim() != "")
                {
                    gridView2.OptionsBehavior.Editable = false;
                    btn提交.Enabled = false;
                    btn撤销.Enabled = false;
                    
                }
                else
                {
                    gridView2.OptionsBehavior.Editable = true;
                    btn提交.Enabled = true;
                    btn撤销.Enabled = true;
                }

                SetLookUp();
                if (sGuid == "")
                {
                    SetNull();
                }
                else
                {
                    SetValue();
                }
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

        private void btn保存_Click(object sender, EventArgs e)
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

            
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                  
                }

                

            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "提示";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        private void btn提交_Click(object sender, EventArgs e)
        {
            try
            {

                try
                {
                    gridView2.FocusedRowHandle -= 1;
                    gridView2.FocusedRowHandle += 1;
                }
                catch { }

                string sSQL = "select getdate()";
                DataTable dtTime = clsSQLCommond.ExecQuery(sSQL);
                DateTime d服务器时间 = Convert.ToDateTime(dtTime.Rows[0][0]);
                DateTime d截止时间 = Convert.ToDateTime(dtm截止.DateTime.ToString("yyyy-MM-dd") + " " + lookUpEditTime.Text.Trim() + ":00");
                if (d服务器时间 > d截止时间.AddHours(2))
                {
                    throw new Exception("超出截止时间，不能提交");
                }

                sSQL = "select * from UFDLImport..询价单 where [GUID] = '" + sGuid + "'";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt == null || dt.Rows.Count == 0)
                {
                    throw new Exception("获得询价单信息失败");
                }
                if (dt.Rows[0]["结案人"].ToString().Trim() != "")
                {
                    gridView2.OptionsBehavior.Editable = false;
                    btn提交.Enabled = false;
                    btn撤销.Enabled = false;
                    throw new Exception("已经结案，不能提交");
                }
                else
                {
                    gridView2.OptionsBehavior.Editable = true;
                    btn提交.Enabled = true;
                    btn撤销.Enabled = true;
                }

                bool b未报价 = true;
                ArrayList aList = new ArrayList();
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    decimal d数量 = ReturnObjectToDecimal(gridView2.GetRowCellValue(i, gridCol_数量),2);
                    string s数量 = "null";
                    if(d数量>0)
                    {
                        s数量 = d数量.ToString();
                    }
                    decimal d单价 = ReturnObjectToDecimal(gridView2.GetRowCellValue(i, gridCol_单价), 2);
                    string s单价 = "null";
                    if (d单价 >= 0)
                    {
                        s单价 = d单价.ToString();
                        b未报价 = false;
                    }
                    decimal d送样周期 = ReturnObjectToDecimal(gridView2.GetRowCellValue(i, gridCol_送样周期), 2);
                    string s送样周期 = "null";
                    if (d送样周期 > 0)
                    {
                        s送样周期 = d送样周期.ToString();
                    }

                    sSQL = @"
if exists(select * from UFDLImport..询价单供应商报价 where 供应商编码 = '@供应商编码' and GUID物料 = '@GUID物料')
	update UFDLImport..询价单供应商报价 set 数量 = @数量,送样周期 = @送样周期,单价 = @单价,供应商备注 = '@供应商备注' ,提交人 = '@提交人',提交时间 = getdate()
	where 供应商编码 = '@供应商编码' and GUID物料 = '@GUID物料'
else
	insert into UFDLImport..询价单供应商报价(GUID, GUID物料, 数量, 送样周期, 单价, 供应商编码, 提交人, 提交时间, 供应商备注)
	values('@GUID','@GUID物料',@数量,@送样周期,@单价,'@供应商编码','@提交人',getdate(),'@供应商备注')
";
                    sSQL = sSQL.Replace("@GUID物料", gridView2.GetRowCellValue(i, gridCol_GUID物料).ToString().Trim());
                    sSQL = sSQL.Replace("@GUID", sGuid);
                    sSQL = sSQL.Replace("@数量", s数量);
                    sSQL = sSQL.Replace("@送样周期", s送样周期);
                    sSQL = sSQL.Replace("@单价", s单价);
                    sSQL = sSQL.Replace("@供应商编码", lookUpEditcVenCode.EditValue.ToString().Trim());
                    sSQL = sSQL.Replace("@提交人", FrameBaseFunction.ClsBaseDataInfo.sUid);
                    sSQL = sSQL.Replace("@供应商备注", gridView2.GetRowCellValue(i, gridCol_供应商备注).ToString().Trim());
                    aList.Add(sSQL);
                }

                if (b未报价)
                {
                    throw new Exception("请报价");
                }

                clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("提交成功");

                this.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btn退出_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void ItemButtonEdit下载附件_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                string sSQL = @"
select * from UFDLImport..询价单附件 where GUID物料 = '@GUID物料' and [GUID] = '@GUID'
";
                sSQL = sSQL.Replace("@GUID物料", gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridCol_GUID物料).ToString().Trim());
                sSQL = sSQL.Replace("@GUID", sGuid);
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt == null || dt.Rows.Count == 0)
                {
                    throw new Exception("附件不存在");
                }


                SaveFileDialog oFile = new SaveFileDialog();
                oFile.Filter = "附件|*.*";
                oFile.FileName = dt.Rows[0]["附件名"].ToString().Trim();
                if (oFile.ShowDialog() == DialogResult.OK)
                {
                    string sFilePath = oFile.FileName;
                    FileInfo fi = new FileInfo(sFilePath);
                    string[] sName = sFilePath.Split('\\');
                    string sFileName = sName[sName.Length - 1];
                    Byte[] b = (byte[])dt.Rows[0]["附件"];
                    writePic(b, sFilePath);

                    MessageBox.Show("下载成功");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        public void writePic(byte[] pics, string sPath)
        {
            FileStream fs = new FileStream(sPath, FileMode.Append, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(pics, 0, pics.Length);
            bw.Close();
            fs.Close();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog oFile = new OpenFileDialog();
                oFile.Filter = "Excel文件2003|*.xls|Excel文件2007|*.xlsx";
                if (oFile.ShowDialog() == DialogResult.OK)
                {
                    string sFilePath = oFile.FileName;
                    string sSQL = "select * from [报价单$]";

                    FrameBaseFunction.ClsExcel clsExcel = FrameBaseFunction.ClsExcel.Instance();
                    DataTable dtExcel = clsExcel.ExcelToDT(sFilePath, sSQL, true);
                    DataColumn dc = new DataColumn();
                    dc.ColumnName = "GUID物料";
                    dtExcel.Columns.Add(dc);

                    for (int i = 0; i < dtExcel.Rows.Count; i++)
                    {
                        Guid g = Guid.NewGuid();
                        dtExcel.Rows[i]["GUID物料"] = g.ToString();

                        string sInvCode = dtExcel.Rows[i]["物料编码"].ToString().Trim();
                        if (sInvCode == "")
                        {
                            continue;
                        }

                        DataTable dtInv = (DataTable)ItemLookUpEdit_cInvName.DataSource;
                        DataRow[] dr = dtInv.Select("cInvCode = '" + sInvCode + "'");
                        if (dr.Length > 0)
                        {
                            sInvCode = dr[0]["cInvCode"].ToString().Trim();
                            dtExcel.Rows[i]["物料编码"] = sInvCode;
                        }
                    }

                    gridControl2.DataSource = dtExcel;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void SetLookUp()
        {
            string sSQL = "select * from @u8.Inventory order by cInvCode";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit_cInvName.DataSource = dt;
            ItemLookUpEdit_cInvStd.DataSource = dt;

            sSQL = "select cVenCode,cVenName from @u8.Vendor where cVenCode = '" + sVenCode + "' order by cVenCode";
            dt = clsSQLCommond.ExecQuery(sSQL);
            lookUpEditcVenCode.Properties.DataSource = dt;
            lookUpEditcVenCode.EditValue = sVenCode;

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



            sSQL = "select  vchrUid, vchrName from _UserInfo order by vchrUid";
            dt = clsSQLCommond.ExecQuery(sSQL);
            txt发布人.Properties.DataSource = dt;
            txt提交人.Properties.DataSource = dt;
            txt制单人.Properties.DataSource = dt;
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

        private void btn撤销_Click(object sender, EventArgs e)
        {
            try
            {
                string sSQL = @"
select * 
from UFDLImport..询价单供应商报价 
where 供应商编码 = '@供应商编码' and GUID = '@GUID'
";
                sSQL = sSQL.Replace("@供应商编码", lookUpEditcVenCode.EditValue.ToString().Trim());
                sSQL = sSQL.Replace("@GUID", sGuid);
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt == null || dt.Rows.Count == 0)
                {
                    throw new Exception("询价单失败");
                }
                if (dt.Rows.Count > 0)
                {
                    string s审批人 = dt.Rows[0]["审批人"].ToString().Trim();
                    if (s审批人 != "")
                    {
                        throw new Exception("已经审批不能撤销");
                    }
                }

                sSQL = @"
	delete UFDLImport..询价单供应商报价 
	where 供应商编码 = '@供应商编码' and GUID = '@GUID'
";
                sSQL = sSQL.Replace("@供应商编码", lookUpEditcVenCode.EditValue.ToString().Trim());
                sSQL = sSQL.Replace("@GUID", sGuid);
                clsSQLCommond.ExecSql(sSQL);
                MessageBox.Show("撤销成功");

                this.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show("撤销提交:" + ee.Message);
            }
        }

        private void btn放弃_Click(object sender, EventArgs e)
        {
            try
            {

                try
                {
                    gridView2.FocusedRowHandle -= 1;
                    gridView2.FocusedRowHandle += 1;
                }
                catch { }

                string sSQL = "select getdate()";
                DataTable dtTime = clsSQLCommond.ExecQuery(sSQL);
                DateTime d服务器时间 = Convert.ToDateTime(dtTime.Rows[0][0]);
                DateTime d截止时间 = Convert.ToDateTime(dtm截止.DateTime.ToString("yyyy-MM-dd") + " " + lookUpEditTime.Text.Trim() + ":00");
                if (d服务器时间 > d截止时间.AddHours(2))
                {
                    throw new Exception("超出截止时间，不能提交");
                }

                sSQL = "select * from UFDLImport..询价单 where [GUID] = '" + sGuid + "'";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt == null || dt.Rows.Count == 0)
                {
                    throw new Exception("获得询价单信息失败");
                }
                if (dt.Rows[0]["结案人"].ToString().Trim() != "")
                {
                    gridView2.OptionsBehavior.Editable = false;
                    btn提交.Enabled = false;
                    btn撤销.Enabled = false;
                    throw new Exception("已经结案，不能提交");
                }
                else
                {
                    gridView2.OptionsBehavior.Editable = true;
                    btn提交.Enabled = true;
                    btn撤销.Enabled = true;
                }

                ArrayList aList = new ArrayList();
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    string s数量 = "0";
                    string s单价 = "0";
                    string s送样周期 = "0";

                    sSQL = @"
if exists(select * from UFDLImport..询价单供应商报价 where 供应商编码 = '@供应商编码' and GUID物料 = '@GUID物料')
	update UFDLImport..询价单供应商报价 set 数量 = @数量,送样周期 = @送样周期,单价 = @单价,供应商备注 = '@供应商备注' ,提交人 = '@提交人',提交时间 = getdate()
	where 供应商编码 = '@供应商编码' and GUID物料 = '@GUID物料'
else
	insert into UFDLImport..询价单供应商报价(GUID, GUID物料, 数量, 送样周期, 单价, 供应商编码, 提交人, 提交时间, 供应商备注)
	values('@GUID','@GUID物料',@数量,@送样周期,@单价,'@供应商编码','@提交人',getdate(),'@供应商备注')
";
                    sSQL = sSQL.Replace("@GUID物料", gridView2.GetRowCellValue(i, gridCol_GUID物料).ToString().Trim());
                    sSQL = sSQL.Replace("@GUID", sGuid);
                    sSQL = sSQL.Replace("@数量", s数量);
                    sSQL = sSQL.Replace("@送样周期", s送样周期);
                    sSQL = sSQL.Replace("@单价", s单价);
                    sSQL = sSQL.Replace("@供应商编码", lookUpEditcVenCode.EditValue.ToString().Trim());
                    sSQL = sSQL.Replace("@提交人", FrameBaseFunction.ClsBaseDataInfo.sUid);
                    sSQL = sSQL.Replace("@供应商备注", "放弃");
                    aList.Add(sSQL);
                }

                clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("放弃成功");

                this.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

    }
}