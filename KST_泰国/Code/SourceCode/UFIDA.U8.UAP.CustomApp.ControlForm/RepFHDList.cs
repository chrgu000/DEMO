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
using System.Collections;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class RepFHDList : UserControl
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
                DbHelperSQL.connectionString = Conn;

                dateEdit1.DateTime = DateTime.Today.AddDays(-7);
                dateEdit2.DateTime = DateTime.Today;

                SetLookup();
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "加载窗体失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        private void SetLookup()
        {
            string sSQL = "select cCusCode,cCusName,cCusAbbName from Customer order by cCusCode";
            DataTable dt = DbHelperSQL.Query(sSQL);
            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            lookUpEditcCusCode.Properties.DataSource = dt;
            lookUpEditcCusName.Properties.DataSource = dt;
            lookUpEditcCusCode.EditValue = "01010002";

            sSQL = @"
select distinct a.cDLCode ,b.cCusName
from DispatchList a left join Customer b on a.cCusCode = b.cCusCode
order by a.cDLCode
";
            dt = DbHelperSQL.Query(sSQL);
            dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            lookUpEditcDLCode1.Properties.DataSource = dt;
            lookUpEditcDLCode2.Properties.DataSource = dt;
        }


        public RepFHDList()
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


        private void btnReflash_Click(object sender, EventArgs e)
        {
            try
            {
                if (lookUpEditcCusCode.EditValue == null || lookUpEditcCusCode.EditValue.ToString().Trim() == "")
                { 
                    lookUpEditcCusCode.Focus();
                    throw new Exception("Please choose customer");
                }

                GetGrid();
            }
            catch (Exception ee)
            {
                gridControl1.DataSource = null;
                MessageBox.Show(ee.Message);
            }
        }


        private void GetGrid()
        {
            for (int i = GridView1.Bands.Count - 1; i >=0;i--)
            {
                string sColName = GridView1.Bands[i].Name;
                if (sColName.StartsWith("gridBand_SiteNo_1"))
                {
                    string sSiteNo = sColName.Replace("gridBand_SiteNo_1", "");
                    DelBandCol(sSiteNo);
                }
            }

            string sSQL = @"
select a.cDLCode,a.cDepCode,a.cCusCode,a.cDefine10 as ProName,a.cDefine11 as ContactInfo
	,a.cPersonCode,a.cDefine4 as dtmPickUp,a.cDefine2 as timePickUp,a.cDefine1 as SiteQty
	,b.cDefine22 as NoSite,b.cDefine23 as TypeSite,b.cDefine24 as SiteID,b.cDefine25 as Region
	,b.cDefine26 as ASP,b.cInvCode,Inv.cInvName ,Inv.cInvStd,Inv.cInvAddCode,b.cCusInvCode
	,b.cUnitID ,b.cWhCode,b.iQuantity,b.iUnitPrice,b.iMoney
    ,inv.cComUnitCode
    ,cast(null as decimal(16,2)) as Qty
    ,cast(null as decimal(16,2)) as Amount
    ,cast(null as decimal(16,2)) as Price
    ,b.cDefine29 as Item
from DispatchList a inner join DispatchLists b on a.DLID = b.DLID
	inner join Inventory Inv on Inv.cInvCode = b.cInvCode
where 1=-1  and isnull(a.cDefine15,0) = 1
order by b.AutoID
";
            DataTable dt = DbHelperSQL.Query(sSQL);
            gridControl1.DataSource = dt;

            sSQL = @"
select distinct cDefine22 ,cDefine23 ,cDefine24 ,cDefine25 ,cDefine28,cDefine34
from DispatchList a inner join DispatchLists b on a.DLID = b.DLID 
	inner join Inventory inv on inv.cInvcode = b.cInvCode
where isnull(cDefine22,'') <> '' and  1=1  and isnull(a.cDefine15,0) = 1
order by  cDefine22,cDefine23,cDefine24,cDefine34
";
            sSQL = sSQL.Replace("1=1", "1=1 and a.dDate >= '" + dateEdit1.DateTime.ToString("yyyy-MM-dd") + "' and a.dDate < '" + dateEdit2.DateTime.AddDays(1).ToString("yyyy-MM-dd") + "' ");
            if (lookUpEditcDLCode1.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.cDLCode >= '" + lookUpEditcDLCode1.Text.Trim() + "'");
            }
            if (lookUpEditcDLCode2.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.cDLCode <= '" + lookUpEditcDLCode2.Text.Trim() + "'");
            }
            if (lookUpEditcCusCode.EditValue != null && lookUpEditcCusCode.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.cCusCode = '" + lookUpEditcCusCode.EditValue.ToString().Trim() + "'"); 
            }
            if (txtProName.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.cDefine10 like '%" + txtProName.Text.Trim() + "%'"); 
            }
            if (txtCusInvNo.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and Inv.cInvAddCode like '%" + txtCusInvNo.Text.Trim() + "%'"); 
            }
            if (txtSiteNo.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and b.cDefine24 like '%" + txtSiteNo.Text.Trim() + "%'"); 
            }

            DataTable dtBand = DbHelperSQL.Query(sSQL);
            for (int i = 0; i < dtBand.Rows.Count; i++)
            {
                string sSiteNo = dtBand.Rows[i]["cDefine22"].ToString().Trim();
                string sType = dtBand.Rows[i]["cDefine23"].ToString().Trim();
                string sSiteID = dtBand.Rows[i]["cDefine24"].ToString().Trim();
                string sRegion = dtBand.Rows[i]["cDefine25"].ToString().Trim();
                string sASP = dtBand.Rows[i]["cDefine28"].ToString().Trim();

                if (sSiteNo == "")
                    continue;
                AddBandCol(sSiteNo, sType, sSiteNo, sRegion, sASP);
            }

            sSQL = @"
select distinct a.cCusCode,a.cDefine10 as ProName,a.cDefine11 as ContactInfo
	,a.cPersonCode,a.cDefine4 as dtmPickUp,a.cDefine2 as timePickUp,a.cDefine3 as SiteQty
	,b.cInvCode,Inv.cInvName ,Inv.cInvStd,Inv.cInvAddCode,Inv.cInvAddCode
	,b.cUnitID ,b.cWhCode,b.iUnitPrice as Price
	111111111111111111111111
    ,inv.cComUnitCode
    ,cast(null as decimal(16,2)) as Qty
    ,cast(null as decimal(16,2)) as Amount
    ,b.cDefine29 as Item
from DispatchList a inner join DispatchLists b on a.DLID = b.DLID
	inner join Inventory Inv on Inv.cInvCode = b.cInvCode
where 1=1  and isnull(a.cDefine15,0) = 1
";
            for (int i = 0; i < dtBand.Rows.Count; i++)
            {
                sSQL = sSQL.Replace("111111111111111111111111", "111111111111111111111111,cast(null as decimal(16,2)) as Qty_SiteNo_" + dtBand.Rows[i]["cDefine22"].ToString().Trim());
            }
            sSQL = sSQL.Replace("111111111111111111111111", "");
            sSQL = sSQL.Replace("1=1", "1=1 and a.dDate >= '" + dateEdit1.DateTime.ToString("yyyy-MM-dd") + "' and a.dDate < '" + dateEdit2.DateTime.AddDays(1).ToString("yyyy-MM-dd") + "' ");
            if (lookUpEditcDLCode1.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.cDLCode >= '" + lookUpEditcDLCode1.Text.Trim() + "'");
            }
            if (lookUpEditcDLCode2.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.cDLCode <= '" + lookUpEditcDLCode2.Text.Trim() + "'");
            }
            if (lookUpEditcCusCode.EditValue != null && lookUpEditcCusCode.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.cCusCode = '" + lookUpEditcCusCode.EditValue.ToString().Trim() + "'");
            }
            if (txtProName.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.cDefine10 like '%" + txtProName.Text.ToString().Trim() + "%'");
            }
            if (txtCusInvNo.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and Inv.cInvAddCode like '%" + txtCusInvNo.Text.Trim() + "%'");
            }
            if (txtSiteNo.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and b.cDefine24 like '%" + txtSiteNo.Text.Trim() + "%'");
            }
            DataTable dtGrid = DbHelperSQL.Query(sSQL);
            gridControl1.DataSource = dtGrid;

            sSQL = @"
select a.cCusCode,b.cDefine22,sum(cast(b.iQuantity as decimal(16,2))) as iQuantity,sum(cast(b.iSum as decimal(16,2)))  as iSum
	,cast(sum(b.iSum)/ sum(b.iQuantity) as decimal(16,2)) as iPrice,b.cDefine29
    ,b.cInvCode 
from DispatchList a inner join DispatchLists b on a.DLID = b.DLID
	inner join Inventory Inv on Inv.cInvCode = b.cInvCode
where 1=1  and isnull(a.cDefine15,0) = 1
group by a.cCusCode,b.cDefine22,b.cInvCode ,b.cDefine29
having sum(cast(b.iQuantity as decimal(16,2))) <> 0
";
            if (lookUpEditcCusCode.EditValue != null && lookUpEditcCusCode.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.cCusCode = '" + lookUpEditcCusCode.EditValue.ToString().Trim() + "'");
            }
            sSQL = sSQL.Replace("1=1", "1=1 and a.dDate >= '" + dateEdit1.DateTime.ToString("yyyy-MM-dd") + "' and a.dDate < '" + dateEdit2.DateTime.AddDays(1).ToString("yyyy-MM-dd") + "' ");
            if (lookUpEditcDLCode1.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.cDLCode >= '" + lookUpEditcDLCode1.Text.Trim() + "'");
            }
            if (lookUpEditcDLCode2.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.cDLCode <= '" + lookUpEditcDLCode2.Text.Trim() + "'");
            }
            if (lookUpEditcCusCode.EditValue != null && lookUpEditcCusCode.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.cCusCode = '" + lookUpEditcCusCode.EditValue.ToString().Trim() + "'");
            }
            if (txtProName.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.cDefine10 like '%" + txtProName.Text.ToString().Trim() + "%'");
            }
            if (txtCusInvNo.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and Inv.cInvAddCode like '%" + txtCusInvNo.Text.Trim() + "%'");
            }
            if (txtSiteNo.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and b.cDefine24 like '%" + txtSiteNo.Text.Trim() + "%'");
            }
            DataTable dtDispatchLists = DbHelperSQL.Query(sSQL);

            for (int i = 0; i < GridView1.RowCount; i++)
            {
                decimal dSumQtyRow = 0;
                string sItem = GridView1.GetRowCellValue(i, gridColItem).ToString().Trim();
                for (int j = 0; j < dtBand.Rows.Count; j++)
                {
                    string sSiteNo = dtBand.Rows[j]["cDefine22"].ToString().Trim();
                    if (sSiteNo == "")
                        continue;

                    string sDr = "cDefine22 = '" + sSiteNo + "' and cInvCode = '" + GridView1.GetRowCellValue(i, gridColcInvCode).ToString() + "' and isnull(cDefine29,'') = '" + sItem + "'";
                    DataRow[] dr = dtDispatchLists.Select(sDr);
                    if (dr.Length > 0)
                    {
                        decimal dQty = BaseFunction.ReturnDecimal(dr[0]["iQuantity"]);
                        GridView1.SetRowCellValue(i, GridView1.Columns["Qty_SiteNo_" + sSiteNo], dQty);

                        dSumQtyRow = dSumQtyRow + dQty;
                    }
                }
                GridView1.SetRowCellValue(i, gridColQty, dSumQtyRow);

                decimal dPrice = BaseFunction.ReturnDecimal(GridView1.GetRowCellValue(i, gridColPrice));
                GridView1.SetRowCellValue(i, gridColAmount, BaseFunction.ReturnDecimal(dSumQtyRow * dPrice, 2));
            }
        }


        private void AddBandCol(string sSiteNo,string sType,string sSiteID,string sRegion,string sASP)
        {
            try
            {
                for (int i = 0; i < GridView1.Bands.Count; i++)
                {
                    string sBandName = "gridBand_SiteNo_1" + sSiteNo;
                    if (GridView1.Bands[i].Name == sBandName)
                    {
                        return;
                    }
                }

                // 
                // gridColQty101
                // 
                DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColQty101;
                gridColQty101 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
                gridColQty101.AppearanceHeader.Options.UseTextOptions = true;
                gridColQty101.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gridColQty101.Caption = "Qty";
                gridColQty101.FieldName = "Qty_SiteNo_" + sSiteNo;
                gridColQty101.Name = "gridColQty_SiteNo_" + sSiteNo;
                gridColQty101.OptionsColumn.AllowEdit = true;
                gridColQty101.Visible = true;
                gridColQty101.Width = 80;

                if (gridControl1.DataSource != null)
                {
                    for (int i = 0; i < ((DataTable)gridControl1.DataSource).Columns.Count; i++)
                    {
                        if (((DataTable)gridControl1.DataSource).Columns[i].ColumnName == gridColQty101.FieldName)
                        {
                            ((DataTable)gridControl1.DataSource).Columns.RemoveAt(i);
                            break;
                        }
                    }
                }

                DataColumn dc = new DataColumn();
                dc.ColumnName = gridColQty101.FieldName;
                ((DataTable)gridControl1.DataSource).Columns.Add(dc);

                DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand101;
                DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand102;
                DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand103;
                DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand104;
                DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand105;

                gridBand101 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
                gridBand102 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
                gridBand103 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
                gridBand104 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
                gridBand105 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();

                // 
                // gridBand101
                // 

                gridBand101.AppearanceHeader.Options.UseTextOptions = true;
                gridBand101.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gridBand101.Caption = sSiteNo;
                gridBand101.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] { gridBand102 });
                gridBand101.Name = "gridBand_SiteNo_1" + sSiteNo;
                gridBand101.Width = 80;

                GridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] { gridBand101 });
                // 
                // gridBand102
                // 

                gridBand102.AppearanceHeader.Options.UseTextOptions = true;
                gridBand102.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gridBand102.Caption = sType;
                gridBand102.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] { gridBand103 });
                gridBand102.Name = "gridBand_SiteNo_2" + sSiteNo;
                gridBand102.Width = 80;
                // 
                // gridBand103
                // 

                gridBand103.AppearanceHeader.Options.UseTextOptions = true;
                gridBand103.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gridBand103.Caption = sSiteID;
                gridBand103.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            gridBand104});
                gridBand103.Name = "gridBand_SiteNo_3" + sSiteNo;
                gridBand103.Width = 80;
                // 
                // gridBand104
                // 

                gridBand104.AppearanceHeader.Options.UseTextOptions = true;
                gridBand104.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gridBand104.Caption = sRegion;
                gridBand104.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            gridBand105});
                gridBand104.Name = "gridBand_SiteNo_4" + sSiteNo;
                gridBand104.Width = 80;
                // 
                // gridBand105
                // 
                gridBand105.AppearanceHeader.Options.UseTextOptions = true;
                gridBand105.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gridBand105.Caption = sASP;
                gridBand105.Columns.Add(gridColQty101);
                gridBand105.Name = "gridBand_SiteNo_5" + sSiteNo;
                gridBand105.Width = 80;

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void DelBandCol(string sSiteNo)
        {
            for (int i = 0; i < GridView1.Columns.Count; i++)
            {
                string sColName = GridView1.Columns[i].Name;
                if (sColName == "gridColQty_SiteNo_" + sSiteNo)
                {
                    GridView1.Columns.RemoveAt(i);
                    break;
                }
            }

            for (int i = 0; i < GridView1.Bands.Count; i++)
            {
                string sColName = GridView1.Bands[i].Name;
                if (sColName == "gridBand_SiteNo_5" + sSiteNo)
                {
                    GridView1.Bands.RemoveAt(i);
                    break;
                }
            }
            for (int i = 0; i < GridView1.Bands.Count; i++)
            {
                string sColName = GridView1.Bands[i].Name;
                if (sColName == "gridBand_SiteNo_4" + sSiteNo)
                {
                    GridView1.Bands.RemoveAt(i);
                    break;
                }
            }
            for (int i = 0; i < GridView1.Bands.Count; i++)
            {
                string sColName = GridView1.Bands[i].Name;
                if (sColName == "gridBand_SiteNo_3" + sSiteNo)
                {
                    GridView1.Bands.RemoveAt(i);
                    break;
                }
            }
            for (int i = 0; i < GridView1.Bands.Count; i++)
            {
                string sColName = GridView1.Bands[i].Name;
                if (sColName == "gridBand_SiteNo_2" + sSiteNo)
                {
                    GridView1.Bands.RemoveAt(i);
                    break;
                }
            }
            for (int i = 0; i < GridView1.Bands.Count; i++)
            {
                string sColName = GridView1.Bands[i].Name;
                if (sColName == "gridBand_SiteNo_1" + sSiteNo)
                {
                    GridView1.Bands.RemoveAt(i);
                    break;
                }
            }
        }

        private void lookUpEditcCusCode_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEditcCusName.EditValue = lookUpEditcCusCode.EditValue;
        }

        private void lookUpEditcCusName_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEditcCusCode.EditValue = lookUpEditcCusName.EditValue;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "xls";
                sF.FileName = this.Text;
                sF.Filter = "Excel(*.xls)|*.xls|All Files(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK == dRes)
                {
                    GridView1.ExportToXls(sF.FileName);
                    MessageBox.Show("OK\n\tPath：" + sF.FileName);
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "Export excel err";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                this.printableComponentLink1.CreateDocument();
                this.printableComponentLink1.ShowPreview();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}
