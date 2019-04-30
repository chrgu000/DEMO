using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TH.BaseClass;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class RepSalebillvouch : UserControl
    {
        string sSQL;

        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }

        public RepSalebillvouch()
        {
            InitializeComponent();
        }

        private void TreeListColumn(DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1, string caption, string fieldname, int visilbeindex)
        {
            treeListColumn1.Caption = caption;
            treeListColumn1.FieldName = fieldname;
            treeListColumn1.Name = "treeListColumn" + (visilbeindex + 1);
            treeListColumn1.Visible = true;
            treeListColumn1.VisibleIndex = visilbeindex;
            treeListColumn1.OptionsColumn.AllowEdit = false;
        }

        private void FrmRepSalebillvouch_Load(object sender, EventArgs e)
        {
            try
            {
                DbHelperSQL.connectionString = Conn;

                SetLookup();
            }
            catch (Exception ee)
            {
                MessageBox.Show("º”‘ÿ ˝æ› ß∞‹");
            }
        }

        private void SetLookup()
        {
            string sSQL = @"
select distinct cDefine10 
from salebillvouch a inner join dbo._DispatchLists_SaleBillVouchs _temp on a.SBVID = _temp.SaleBillID
where isnull(cDefine10 ,'') <> ''
order by cDefine10
";
            DataTable dt = DbHelperSQL.Query(sSQL);
            lookUpEditProName.Properties.DataSource = dt;
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSel_Click(object sender, EventArgs e)
        {
            try
            {
                FrmRepSalebillvouchSEL frm = new FrmRepSalebillvouchSEL(Conn, sUserID, sUserName, sLogDate, sAccID);
                frm.StartPosition = FormStartPosition.CenterParent;
                DialogResult d = frm.ShowDialog();
                if (d == DialogResult.Yes)
                {
                    SetLookup();

                    if (lookUpEditProName.EditValue == null || lookUpEditProName.EditValue.ToString().Trim() != frm.sProjectName)
                    {
                        lookUpEditProName.EditValue = frm.sProjectName;
                    }  
                    else
                    {
                        GetGrid();
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void GetGrid()
        {
            try
            {
                if (lookUpEditProName.Text.Trim() == "")
                {
                    throw new Exception("Please input project name");
                }
                gridView1.Bands.Clear();

                string proj = lookUpEditProName.Text.Trim();
                NewBand(proj);
                int s = 0;
                sSQL = @"
select  b.cDefine29 as item,cu.cComUnitName,cast(sum(ds.DLsQty) as decimal(16,2)) as iQuantity,cast(sum(b.iMoney*ds.DLsQty/b.iQuantity) as decimal(16,2)) as iMoney
from SaleBillVouch a  
    inner join SaleBillVouchs b on a.SBVID=b.SBVID
    inner join _DispatchLists_SaleBillVouchs ds on b.AutoID=ds.SaleBillsID
    left join DispatchLists diss on ds.DLsID=diss.iDLsID
    left join DispatchList dis on diss.DLID = dis.DLID
    left join Inventory i on b.cInvCode=i.cInvCode 
    left join ComputationUnit cu on i.cComUnitCode=cu.cComUnitCode
where ds.SaleBillsID is not null and 1=1 
group by  b.cDefine29,cu.cComUnitName
";
                sSQL = sSQL.Replace("1=1", "1=1 and dis.cDefine10 = '" + proj + "'");
                DataTable dt = DbHelperSQL.Query(sSQL);

                sSQL = @"
select distinct ds.DLCode 
from SaleBillVouch a  
    inner join SaleBillVouchs b on a.SBVID=b.SBVID
    inner join _DispatchLists_SaleBillVouchs ds on b.AutoID=ds.SaleBillsID
    left join DispatchLists diss on ds.DLsID=diss.iDLsID
    left join DispatchList dis on diss.DLID = dis.DLID
where ds.SaleBillsID is not null and 1=1";
                sSQL = sSQL.Replace("1=1", "1=1 and isnull(dis.cDefine10,'') = '" + proj + "'");
                DataTable dts = DbHelperSQL.Query(sSQL);

                for (int i = 0; i < dts.Rows.Count; i++)
                {
                    string DLCode = dts.Rows[i]["DLCode"].ToString();
                    DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1 = NewBand1(DLCode);

                    sSQL = @"
select distinct ds.DLCode,isnull(diss.cDefine24,'') as siteid
from SaleBillVouch a  
    inner join SaleBillVouchs b on a.SBVID=b.SBVID
    inner join _DispatchLists_SaleBillVouchs ds on b.AutoID=ds.SaleBillsID
    left join DispatchLists diss on ds.DLsID=diss.iDLsID
    left join DispatchList dis on diss.DLID = dis.DLID
where ds.SaleBillsID is not null and 1=1";
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(dis.cDefine10,'') = '" + proj + "' and ds.DLCode = '" + DLCode + "'");
                    DataTable dts2 = DbHelperSQL.Query(sSQL);

                    for (int j = 0; j < dts2.Rows.Count; j++)
                    {
                        string siteid = dts2.Rows[j]["siteid"].ToString();
                        DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2 = NewBand2(gridBand1, siteid);

                        sSQL = @"
select cast(sum(b.iQuantity) as decimal(16,2)) as iQuantity,cast(sum(b.iMoney) as decimal(16,2)) as iMoney
from SaleBillVouch a  
    inner join SaleBillVouchs b on a.SBVID=b.SBVID
    inner join _DispatchLists_SaleBillVouchs ds on b.AutoID=ds.SaleBillsID
    left join DispatchLists diss on ds.DLsID=diss.iDLsID
    left join DispatchList dis on diss.DLID = dis.DLID
where ds.SaleBillsID is not null and 1=1";
                        sSQL = sSQL.Replace("1=1", "1=1 and isnull(dis.cDefine10,'') = '" + proj + "' and ds.DLCode = '" + DLCode + "' and isnull(diss.cDefine24,'') = '" + siteid + "'");
                        DataTable dts3 = DbHelperSQL.Query(sSQL);

                        string iQuantity = s + "_iQuantity";
                        string iMoney = s + "_iMoney";
                        dt.Columns.Add(iQuantity);
                        dt.Columns.Add(iMoney);
                        for (int p = 0; p < dt.Rows.Count; p++)
                        {
                            string item = dt.Rows[p]["item"].ToString();
                            sSQL = @"
select cast(sum(ds.DLsQty) as decimal(16,2)) as iQuantity,cast(sum(b.iMoney*ds.DLsQty/b.iQuantity) as decimal(16,2)) as iMoney
from SaleBillVouch a  
    inner join SaleBillVouchs b on a.SBVID=b.SBVID
    inner join _DispatchLists_SaleBillVouchs ds on b.AutoID=ds.SaleBillsID
    left join DispatchLists diss on ds.DLsID=diss.iDLsID
    left join DispatchList dis on diss.DLID = dis.DLID
where ds.SaleBillsID is not null and 1=1";
                            sSQL = sSQL.Replace("1=1", "1=1 and isnull(dis.cDefine10,'') = '" + proj + "' and ds.DLCode = '" + DLCode + "' and isnull(diss.cDefine24,'') = '" + siteid + "' and isnull(b.cDefine29,'') = '" + item + "'");
                            DataTable dts4 = DbHelperSQL.Query(sSQL);
                            dt.Rows[p][iQuantity] = dts4.Rows[0]["iQuantity"];
                            dt.Rows[p][iMoney] = dts4.Rows[0]["iMoney"];
                        }


                        NewBand3(gridBand2, iQuantity, iMoney);
                        s++;
                    }
                }

                gridControl1.DataSource = dt;
                gridView1.BestFitColumns();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private DevExpress.XtraGrid.Views.BandedGrid.GridBand NewBand1(string DLCode)
        {
            DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            gridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridBand.Caption = DLCode;
            gridBand.MinWidth = 20;
            gridBand.Width = 50;
            
            gridView1.Bands.Add(gridBand);

            return gridBand;
        }

        private DevExpress.XtraGrid.Views.BandedGrid.GridBand NewBand2(DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBandtop, string siteid)
        {
            DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            gridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridBand.Caption = siteid;
            gridBand.MinWidth = 20;
            gridBand.Width = 50;

            gridBandtop.Children.Add(gridBand);

            return gridBand;
        }

        private void NewBand4(DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBandtop, string txt,string field)
        {
            DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridColumn1.Caption = txt;
            gridColumn1.FieldName = field;
            gridColumn1.Visible = true;
            gridColumn1.VisibleIndex = gridView1.Columns.Count;
            gridColumn1.OptionsColumn.AllowEdit = false;
            gridColumn1.Width = 100;
            gridColumn1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum) });

            gridBandtop.Columns.Add(gridColumn1);
        }

        private void NewBand4(DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBandtop, string txt, string field,bool b)
        {
            DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridColumn1.Caption = txt;
            gridColumn1.FieldName = field;
            gridColumn1.Visible = true;
            gridColumn1.VisibleIndex = gridView1.Columns.Count;
            gridColumn1.OptionsColumn.AllowEdit = false;
            gridColumn1.Width = 100;
            if (b == true)
            {
                gridColumn1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum) });
            }
            gridBandtop.Columns.Add(gridColumn1);
        }

        private void NewBand3(DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBandtop, string Qty,string AMOUNT)
        {
            DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridColumn1.Caption = "Qty";
            gridColumn1.FieldName = Qty;
            gridColumn1.Visible = true;
            gridColumn1.VisibleIndex = gridView1.Columns.Count;
            gridColumn1.OptionsColumn.AllowEdit = false;
            gridColumn1.Width = 100;
            gridColumn1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum) });

            gridBandtop.Columns.Add(gridColumn1);

            DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridColumn2.Caption = "AMOUNT";
            gridColumn2.FieldName = AMOUNT;
            gridColumn2.Visible = true;
            gridColumn2.VisibleIndex = gridView1.Columns.Count;
            gridColumn2.OptionsColumn.AllowEdit = false;
            gridColumn2.Width = 100;
            gridColumn2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum) });

            gridBandtop.Columns.Add(gridColumn2);
        }

        private void NewBand(string Proj)
        {
            DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1 = NewBand1("Project Name:" + Proj);

            DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2 = NewBand2(gridBand1, "SI NO");
            NewBand4(gridBand2, "ITEM", "item",false);


            DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3 = NewBand2(gridBand1, "Date");
            NewBand4(gridBand3, "Total Qty", "iQuantity");
            NewBand4(gridBand3, "Unit", "cComUnitName", false);
            NewBand4(gridBand3, "AMOUNT", "iMoney");
        }


        private void DelBand2(DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBandtop)
        {
            for (int i = gridBandtop.Children.Count; i > 1; i--)
            {
                if (gridBandtop.Children[i].Columns.Count > 0)
                {
                    DelBand2(gridBandtop.Children[i]);
                }
                gridView1.Bands.Remove(gridBandtop.Children[i]);
            }
        }

        private void DelBand3(DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBandtop)
        {
            for (int i = gridBandtop.Children.Count; i > 1; i--)
            {
                gridView1.Columns.Remove(gridBandtop.Children[i].Columns[0]);
            }
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
                sF.Filter = "Excel(*.xlsx)|*.xlsx|All File(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK == dRes)
                {
                    gridView1.ExportToXlsx(sF.FileName);
                 
                    MessageBox.Show("Path£∫" + sF.FileName);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("Err£∫" + ee.Message);
            }
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = Convert.ToString(e.RowHandle + 1);
            }
        }

        private void lookUpEditProName_EditValueChanged(object sender, EventArgs e)
        {
            GetGrid();
        }
    }
}