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
using DevExpress.XtraReports.UI;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class BarCodeStatus : UserControl
    {
        TH.BaseClass.GetBaseData getBaseData = new GetBaseData();

        UFIDA.U8.UAP.CustomApp.ControlForm.RepBaseGrid Rep = new RepBaseGrid();

        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }

        string sProPath = Application.StartupPath;
        string sPrintLayOutMod = Application.StartupPath + "\\UAP\\Runtime\\print\\BarLabel1.dll";
       

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                DbHelperSQL.connectionString = Conn;

                SetlookUp();
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "加载窗体失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        private void SetlookUp()
        {
            dateEdit1.DateTime = Convert.ToDateTime(DateTime.Today.AddMonths(-2).ToString("yyyy-MM-01"));
            dateEdit2.DateTime = DateTime.Today;

            string sSQL = "select cCusCode,cCusName from Customer order by cCusCode";
            DataTable dt = DbHelperSQL.Query(sSQL);
            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            lookUpEditcCusCode.Properties.DataSource = dt;
            lookUpEditcCusName.Properties.DataSource = dt;

            sSQL = "select cSoCode from SO_SOMain order by cSoCode";
            dt = DbHelperSQL.Query(sSQL);
            dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            lookUpEditSoCode1.Properties.DataSource = dt;
            lookUpEditSoCode2.Properties.DataSource = dt;
        }

        public BarCodeStatus()
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
                    MessageBox.Show("OK\n\tPath：" + sF.FileName);
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

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void GetGrid()
        {

            //当U8删除发货单，刷新发货记录表
            string sSQL = @"
Update b set b.[status] = 'Pending',b.iDispatchLists = null
FROM [dbo].[_SalesShipment] a
	inner join [dbo].[_BarCodeLabel] b on a.LotNO = b.BarCode and a.iSOsID = b.iSOsID
	left join DispatchLists c on b.iDispatchLists = c.iDLsID
where b.[status] = '发货' and isnull(c.AutoID,0) = 0 
";
            DbHelperSQL.ExecuteSql(sSQL);

            //当U8删除发货单，刷新状态表
            sSQL = @"
delete [_BarStatus]
FROM [dbo].[_SalesShipment] a
	inner join [dbo].[_BarCodeLabel] b on a.LotNO = b.BarCode and a.iSOsID = b.iSOsID
	inner join [dbo].[_BarStatus] d on d.BarCode = b.BarCode and b.iSOsID = d.iSOsID
	left join DispatchLists c on b.iDispatchLists = c.iDLsID
where d.[Type] = '发货' and isnull(c.AutoID,0) = 0 

";
            DbHelperSQL.ExecuteSql(sSQL);
            
            
            sSQL = @"
select
    a.BarCode AS [Lot No],c.cSOCode as [Order No],b.iRowNo AS [Sale Order Row]
	,b.cInvCode AS [Item No],d.cInvName AS [Item Desc],c.cCusCode as Cust
	,CAST(b.iQuantity AS DECIMAL(16,2)) AS Qty
	,g.QTY as [Lot No Qty],d.cInvDepCode  AS DEPT	
    ,a.Batch as [Batch No]
    ,g.RoutingTo as Process
	,CONVERT(char(19),g.UpdateTime,120) as [Time]
    ,CAST(a.ORDERQTY AS DECIMAL(16,2)) as [Order Qty]
	,case when g.[Type] = '新增' then 'New' 
          when g.[Type] = '新增-客供条码' then 'New-with Barcode' 
          when g.[Type] = '发货' then 'Delivery' 
          when g.[Type] = '关闭' then 'Closed' 
          when g.[Type] = '流转' then 'Transferv'
          when g.[Type] = '工序流转' then 'Transfer' 
          when g.[Type] = '调整' then 'Adjustment' 
      else g.[Type] end as [Status]
    ,h.cDLCode as [SEP DO No.]
	 ,CreateUid as Operator
FROM [dbo].[_BarCodeLabel] a 
	INNER JOIN dbo.SO_SODetails b ON a.iSOsID = b.iSOsID
	INNER JOIN dbo.SO_SOMain c ON b.ID = c.ID
	INNER JOIN inventory d ON b.cInvCode = d.cInvCode
	left join [dbo].[_BarStatus] g on a.BarCode = g.BarCode and a.iSOsID = g.iSOsID
    left join (select cDLCode,iDLsID from DispatchList  a inner join DispatchLists b on a.DLID = b.DLID ) h on h.iDLsID = a.[iDispatchLists]
WHERE 1=1
order by a.iSOsID,a.BarCode,g.UpdateTime desc
";
            if (txtBarCode.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.BarCode = '" + txtBarCode.Text.Trim() + "'");
            }
            if (dateEdit1.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and c.dDate >= '" + dateEdit1.DateTime.ToString("yyyy-MM-dd") + "'");
            }
            if (dateEdit2.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and c.dDate < '" + dateEdit2.DateTime.AddDays(1).ToString("yyyy-MM-dd") + "'");
            }
            if (lookUpEditcCusName.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and c.cCusCode  = '" + lookUpEditcCusCode.EditValue.ToString().Trim() + "'");
            }
            if (lookUpEditSoCode1.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and c.cSOCode  >= '" + lookUpEditSoCode1.EditValue.ToString().Trim() + "'");
            }
            if (lookUpEditSoCode2.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and c.cSOCode  <= '" + lookUpEditSoCode2.EditValue.ToString().Trim() + "'");
            }


            DataTable dt = DbHelperSQL.Query(sSQL);
            gridControl1.DataSource = dt;
            gridView1.BestFitColumns();
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            gridView1.AddNewRow();
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                int iRow = e.RowHandle;

             
            }
            catch { }
        }
        

        private void btnPrintSet_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(sProPath + "\\print"))
                    Directory.CreateDirectory(sProPath + "\\print");

                if (File.Exists(sPrintLayOutMod))
                {
                    Rep.LoadLayout(sPrintLayOutMod);
                }

                Rep.ShowDesignerDialog();

                DialogResult d = MessageBox.Show("是否保存?模板调整将在下次打开窗体时体现\n是：保存打印模板\n", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (DialogResult.Yes == d)
                {
                    Rep.SaveLayoutToXml(sPrintLayOutMod);
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "设置打印模板失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        private void lookUpEditcCusName_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lookUpEditcCusCode.EditValue = lookUpEditcCusName.EditValue;
            }
            catch { }
        }

        private void lookUpEditcCusCode_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lookUpEditcCusName.EditValue = lookUpEditcCusCode.EditValue;
            }
            catch { }
        }

        private void txtBarCode_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    GetGrid();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

    }
}
