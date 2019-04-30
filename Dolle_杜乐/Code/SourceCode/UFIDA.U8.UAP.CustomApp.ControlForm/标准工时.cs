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
    public partial class 标准工时 : UserControl
    {
        TH.BaseClass.GetBaseData getBaseData = new GetBaseData();
        
        string sProPath = Application.StartupPath;

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
                GetGrid();
            }
            catch
            { 
            
            }
        }

        public 标准工时()
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string sErr = "";
                int iCount = 0;

                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }


                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {

                    string sSQL = "select getdate()";
                    DateTime dNow = BaseFunction.ReturnDate(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);

                    sSQL = "insert into CA_Quo_TH_Back select *,'aaaaaa' as UpdateTime from CA_Quo";
                    sSQL = sSQL.Replace("aaaaaa", dNow.ToString("yyyy-MM-dd HH:mm:ss"));
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        bool b = BaseFunction.ReturnBool(gridView1.GetRowCellValue(i, gridColisRight));
                        if (b)
                            continue;

                        decimal d工时 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColGS));
                        if (d工时 <= 0)
                            continue;

                        sSQL = @"

IF EXISTS(SELECT * FROM CA_Quo WHERE   (iYear = aaaaaa) AND (cPPID = bbbbbb) AND cWktType = 1)
	UPDATE CA_Quo SET iQuo = cccccc  WHERE   (iYear = aaaaaa) AND (cPPID = bbbbbb) AND cWktType = 1
ELSE
	INSERT INTO CA_Quo(cPPID,  cAmotype, iQuo,  cWktType, iYear)
	VALUES(bbbbbb,1,cccccc,1,aaaaaa)
";
                        sSQL = sSQL.Replace("aaaaaa", BaseFunction.ReturnDate(sLogDate).ToString("yyyy"));
                        sSQL = sSQL.Replace("bbbbbb", gridView1.GetRowCellValue(i, gridColiPlanCOID).ToString().Trim());
                        sSQL = sSQL.Replace("cccccc", d工时.ToString().Trim());
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        iCount = iCount + 1;
                    }

                    if (sErr.Length > 0)
                    {
                        throw new Exception(sErr);
                    }

                    if (iCount > 0)
                    {
                        tran.Commit();
                        MessageBox.Show("保存成功\n");

                        GetGrid();
                    }
                    else
                    {
                        throw new Exception("无数据需要保存");
                    }
                }
                catch (Exception ee)
                {
                    tran.Rollback();
                    throw new Exception(ee.Message);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void GetGrid()
        {
            string sSQL = @"
select *
    ,case when iQuo=GS then cast(1 as bit) else cast(0 as bit) end as isRight
from
(
SELECT b.iPlanCOID,b.cDeptID,b.cDepName,b.InvCode,b.cInvName,b.cInvStd,cast(a.iQuo as decimal(16,6)) as iQuo,cast(c.工时 as decimal(16,6)) as GS
FROM caq_coplan_withNoBom b 
	inner join Inventory inv on inv.cInvCode = b.InvCode
	inner join InventoryClass invs on invs.cInvCCode = inv.cInvCCode and invs.cInvCCode = 'CP'
    left JOIN CA_Quo a  ON a.cPPID = b.iPlanCOID AND a.iYear = aaaaaa
    left join
    (
        SELECT 产品编码,SUM(单位工时*数量) * 1000 AS 工时 FROM [XWSystemDB_DL].[dbo].[ProProcess] WHERE 1=1 and 组别 <> '委外部' and 组别 <> '采购部' GROUP BY 产品编码
    )c on b.InvCode = c.产品编码
)a 
order by a.invcode,a.iPlanCOID
";
            sSQL = sSQL.Replace("aaaaaa", BaseFunction.ReturnDate(sLogDate).ToString("yyyy"));
            DataTable dt = DbHelperSQL.Query(sSQL);
            gridControl1.DataSource = dt;
            gridView1.FocusedRowHandle = 0;
        }

        private void btnSEL_Click(object sender, EventArgs e)
        {
            
            try
            {
                GetGrid();
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                bool b = BaseFunction.ReturnBool(gridView1.GetRowCellValue(e.RowHandle, gridColisRight));
                if(!b)
                    e.Appearance.BackColor = Color.Tomato;
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
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "xlsx";
                sF.FileName = "定额工时";
                sF.Filter = "xlsx文件(*.xlsx)|*.xlsx|所有文件(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK != dRes)
                {
                    return;
                }

                gridView1.ExportToXlsx(sF.FileName);
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "导出Excel失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }
    }
}
