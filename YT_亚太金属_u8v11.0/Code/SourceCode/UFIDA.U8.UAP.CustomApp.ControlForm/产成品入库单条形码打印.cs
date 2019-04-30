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
using TH.BaseClass;
using System.IO;


namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class 产成品入库单条形码打印 : UserControl
    {
        string sProPath = Application.StartupPath;

        string sPrintLayOutMod = Application.StartupPath + "\\print\\Model\\入库单条形码打印Mod.dll";
        string sPrintLayOutUser = Application.StartupPath + "\\print\\User\\入库单条形码打印User.dll";
        UFIDA.U8.UAP.CustomApp.ControlForm.RepBaseGrid Rep = new RepBaseGrid();

        string sState = "";

        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }

        public 产成品入库单条形码打印()
        {
            InitializeComponent();
        }


        private void Frm产成品入库单条形码打印_Load(object sender, EventArgs e)
        {
            try
            {
                dateEdit单据日期1.DateTime = DateTime.Now.AddMonths(-1);
                dateEdit单据日期2.DateTime = DateTime.Now;

                SetLookUp();
            }
            catch (Exception ee)
            {
                //MessageBox.Show("加载数据失败");
                throw new Exception(ee.Message);
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

        private void btnLoad_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    TH.BaseClass.ClsExcel clsExcel = TH.BaseClass.ClsExcel.Instance();

            //    OpenFileDialog oFile = new OpenFileDialog();
            //    oFile.Filter = "Excel文件|*.xls|Excel文件|*.xlsx";
            //    if (oFile.ShowDialog() == DialogResult.OK)
            //    {
            //        string sFilePath = oFile.FileName;
            //        string sSQL = "select * from [导入格式$]";

            //        DataTable dt = clsExcel.ExcelToDT(sFilePath, sSQL, true);

            //        gridView1.Columns.Clear();

            //        for (int i = dt.Rows.Count - 1; i >= 0; i--)
            //        {
            //            if (dt.Rows[i]["单据编码"].ToString().Trim() == "" && dt.Rows[i]["合同编号"].ToString().Trim() == "" && dt.Rows[i]["单据日期"].ToString().Trim() == "")
            //            {
            //                dt.Rows.RemoveAt(i);
            //            }
            //        }

            //        gridControl1.DataSource = dt;


            //        if (dt == null || dt.Rows.Count < 1)
            //            throw new Exception("加载的文件没有数据，请核实后继续");
            //    }
            //    else
            //    {
            //        throw new Exception("取消导入");
            //    }
            //}
            //catch (Exception ee)
            //{
            //    FrmMsgBox f = new FrmMsgBox();
            //    f.richTextBox1.Text = ee.Message;
            //    f.Text = "加载失败";
            //    f.ShowDialog();
            //}
        }


        ////根据历史单据生成最新单据号
        //private string ReturnCode(DateTime d, long o)
        //{
        //    string s = o.ToString();
        //    int iLength = 4;

        //    for (int i = 0; i < iLength; i++)
        //    {
        //        if (s.Length < iLength)
        //        {
        //            s = "0" + s;
        //        }
        //        else
        //        {
        //            break;
        //        }
        //    }

        //    s = d.ToString("yyMM") + s;
        //    return s;
        //}

        //private string ReturnID(object o)
        //{
        //    string s = o.ToString().Trim();
        //    for (int i = 0; i < 10; i++)
        //    {
        //        if (s.Length < 9)
        //            s = "0" + s;
        //        else if (s.Length == 9)
        //            s = "1" + s;
        //        else
        //            break;
        //    }
        //    return s;
        //}

        //private string ReturnDBString(decimal o)
        //{
        //    return o.ToString();
        //}

        //private string ReturnDBString(object o)
        //{
        //    if (o.ToString().Trim() == "")
        //        return "null";
        //    else
        //    {
        //        return "'" + o.ToString().Trim() + "'";
        //    }
        //}

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                string sSQL = @"
insert into _BarCodeInventory(cInvCode, cBatch, cFree1, cFree2, cFree3, cFree4, cFree5, cFree6, cFree7, cFree8, cFree9, cFree10)
select b.cInvCode,b.cBatch,b.cFree1,b.cFree2,b.cFree3,b.cFree4,b.cFree5,b.cFree6,b.cFree7,b.cFree8,b.cFree9,b.cFree10 
from rdrecord10  a inner join rdrecords10  b on a.id = b.id
	left join Department c on c.cDepCode = a.cDepCode
	left join inventory d on d.cInvCode = b.cInvCode
	left join Warehouse e on e.cWhCode = d.cDefWareHouse
	left join Position  f on f.cPosCode = d.cPosition
	left join Vendor g on g.cVenCode = a.cVenCode
    left join _BarCodeInventory h on h.cInvCode = b.cInvCode and ISNULL(h.cfree1,'') = ISNULL(b.cfree1,'') and ISNULL(h.cfree2,'') = ISNULL(b.cfree2,'') and ISNULL(h.cfree3,'') = ISNULL(b.cfree3,'') and ISNULL(h.cfree4,'') = ISNULL(b.cfree4,'')
		 and ISNULL(h.cfree5,'') = ISNULL(b.cfree5,'') and ISNULL(h.cfree6,'') = ISNULL(b.cfree6,'') and ISNULL(h.cfree7,'') = ISNULL(b.cfree7,'') and ISNULL(h.cfree8,'') = ISNULL(b.cfree8,'') and ISNULL(h.cfree9,'') = ISNULL(b.cfree9,'') and ISNULL(h.cfree10,'') = ISNULL(b.cfree10,'')
		 and ISNULL(h.cbatch,'') = ISNULL(b.cbatch,'')
where ISNULL(a.cHandler  ,'') <> '' and isnull(h.AutoID,0) = 0
    and 1=1
order by b.autoid

select cast(0 as bit) as 选择, a.cCode as 单据号,convert(varchar, a.dDate, 111) as 单据日期,a.cDefine3 as 所属公司,a.cDepCode as 部门编码,c.cDepName as 部门名称
	,b.cInvCode as 存货编码,d.cInvName as 存货名称,d.cInvStd as 规格型号,b.iQuantity as 数量, b.iNum as 件数
	,d.cDefWareHouse as 仓库编码,e.cWhName as 仓库,d.cPosition as 货位编码,f.cPosName as 货位
    ,b.cFree1 as 材质,b.cFree2 as 渗层,b.cFree3 as 统一号,b.cFree4 as 工艺要求
    ,right('0000000000' + cast(h.AutoID as varchar(10)),10) as 条形码,1 as 打印次数
from rdrecord10 a inner join rdrecords10 b on a.id = b.id
	left join Department c on c.cDepCode = a.cDepCode
	left join inventory d on d.cInvCode = b.cInvCode
	left join Warehouse e on e.cWhCode = d.cDefWareHouse
	left join Position  f on f.cPosCode = d.cPosition
	left join Vendor g on g.cVenCode = a.cVenCode
    left join _BarCodeInventory h on h.cInvCode = b.cInvCode and ISNULL(h.cfree1,'') = ISNULL(b.cfree1,'') and ISNULL(h.cfree2,'') = ISNULL(b.cfree2,'') and ISNULL(h.cfree3,'') = ISNULL(b.cfree3,'') and ISNULL(h.cfree4,'') = ISNULL(b.cfree4,'')
		 and ISNULL(h.cfree5,'') = ISNULL(b.cfree5,'') and ISNULL(h.cfree6,'') = ISNULL(b.cfree6,'') and ISNULL(h.cfree7,'') = ISNULL(b.cfree7,'') and ISNULL(h.cfree8,'') = ISNULL(b.cfree8,'') and ISNULL(h.cfree9,'') = ISNULL(b.cfree9,'') and ISNULL(h.cfree10,'') = ISNULL(b.cfree10,'')
		 and ISNULL(h.cbatch,'') = ISNULL(b.cbatch,'')
where ISNULL(a.cHandler ,'') <> ''
    and 1=1
order by b.autoid
";
                if (lookUpEdit单据号1.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.cCode>='" + lookUpEdit单据号1.Text.Trim() + "'");
                }
                if (lookUpEdit单据号2.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.cCode<='" + lookUpEdit单据号2.Text.Trim() + "'");
                }
                if (dateEdit单据日期1.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.dDate>='" + dateEdit单据日期1.DateTime.ToString("yyyy-MM-dd") + "'");
                }
                if (dateEdit单据日期2.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.dDate<='" + dateEdit单据日期2.DateTime.ToString("yyyy-MM-dd") + "'");
                }
               
                if (radio未完成.Checked)
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and b.iQuantity > ISNULL(b.iSOutQuantity,0) ");
                }
            
                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];

                gridControl1.DataSource = dt;

                gridView1.OptionsView.ColumnAutoWidth = true;
                gridView1.OptionsBehavior.Editable = true;
                for (int i = 0; i < gridView1.Columns.Count; i++)
                { 
                   string sColName = gridView1.Columns[i].FieldName.Trim();
                   if (sColName == "选择" || sColName == "打印次数")
                    {
                        gridView1.Columns[i].OptionsColumn.AllowEdit = true ;
                    }
                    else
                    {
                        gridView1.Columns[i].OptionsColumn.AllowEdit = false;
                    }
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.richTextBox1.Text = ee.Message;
                f.Text = "过滤失败";
                f.ShowDialog();
            }
        }

        private void SetLookUp()
        {
            string sSQL = @"select cCode from rdrecord10 order by cCode";
            DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
            lookUpEdit单据号1.Properties.DataSource = dt;
            lookUpEdit单据号2.Properties.DataSource = dt;
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
                MessageBox.Show(ee.Message);
            }
        }

        private void tsbPrint_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                Rep = new RepBaseGrid();
                if (File.Exists(sPrintLayOutUser))
                {
                    Rep.LoadLayout(sPrintLayOutUser);
                }
                else if (File.Exists(sPrintLayOutMod))
                {
                    Rep.LoadLayout(sPrintLayOutMod);
                }
                else
                {
                    MessageBox.Show("加载报表模板失败，请与管理员联系");
                    return;
                }

                if (Rep.dsPrint == null)
                    throw new Exception("没有需要打印的数据");

                Rep.dsPrint.Tables.Clear();
                DataTable dtGrid = ((DataTable)gridControl1.DataSource).Copy();
                dtGrid.TableName = "dtGrid";

                DataTable dtPrint = new DataTable();
                dtPrint.TableName = "dtGrid";
                for (int i = 0; i < dtGrid.Columns.Count; i++)
                {
                    dtPrint.Columns.Add(dtGrid.Columns[i].ColumnName, dtGrid.Columns[i].DataType);
                }

                for (int i = 0; i < dtGrid.Rows.Count; i++)
                {
                    if (SqlHelper.ReturnObjectToBool(dtGrid.Rows[i]["选择"]))
                    {
                        int count = SqlHelper.ReturnObjectToInt(dtGrid.Rows[i]["打印次数"]);
                        if (count == 0)
                        {
                            count = 1;
                        }
                        for (int j = 1; j <= count; j++)
                        {
                            dtPrint.ImportRow(dtGrid.Rows[i]);
                        }
                    }
                }

                Rep.dsPrint.Tables.Add(dtPrint);
                if (dtPrint.Rows.Count < 1)
                {
                    throw new Exception("没有要打印的单据");
                }

                Rep.ShowPreview();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void tsbClearCon_Click(object sender, EventArgs e)
        {
            lookUpEdit单据号1.EditValue = DBNull.Value;
            lookUpEdit单据号2.EditValue = DBNull.Value;
            dateEdit单据日期1.Text = "";
            dateEdit单据日期2.Text = "";
        }

        private void chk全选_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    gridView1.SetRowCellValue(i, gridView1.Columns["选择"], chk全选.Checked);
                }
            }
            catch { }
        }

        private void btnPrintSet_Click(object sender, EventArgs e)
        {
            bool bMod = false;
            if (sUserID == "demo")
            {
                bMod = true;
            }

            if (!Directory.Exists(sProPath + "\\print"))
                Directory.CreateDirectory(sProPath + "\\print");
            if (!Directory.Exists(sProPath + "\\print\\Model"))
                Directory.CreateDirectory(sProPath + "\\print\\Model");
            if (!Directory.Exists(sProPath + "\\print\\User"))
                Directory.CreateDirectory(sProPath + "\\print\\User");

            if (bMod)
            {
                if (File.Exists(sPrintLayOutMod))
                {
                    Rep.LoadLayout(sPrintLayOutMod);
                }
            }
            else
            {
                if (File.Exists(sPrintLayOutUser))
                {
                    Rep.LoadLayout(sPrintLayOutUser);
                }
                else if (File.Exists(sPrintLayOutMod))
                {
                    Rep.LoadLayout(sPrintLayOutMod);
                }
            }

            Rep.ShowDesignerDialog();

            DialogResult d = MessageBox.Show("是否保存?模板调整将在下次打开窗体时体现\n是：保存打印模板\n否：恢复默认打印模板\n", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
            if (DialogResult.Yes == d)
            {
                if (bMod)
                {
                    Rep.SaveLayoutToXml(sPrintLayOutMod);
                }
                else
                {
                    Rep.SaveLayoutToXml(sPrintLayOutUser);
                }
            }
            else if (DialogResult.No == d)
            {
                if (File.Exists(sPrintLayOutUser))
                {
                    File.Delete(sPrintLayOutUser);
                }
            }
        }

    }
}