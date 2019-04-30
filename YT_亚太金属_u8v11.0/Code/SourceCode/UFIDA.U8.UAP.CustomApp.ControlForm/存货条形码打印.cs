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
    public partial class ����������ӡ : UserControl
    {
        string sProPath = Application.StartupPath;

        string sPrintLayOutMod = Application.StartupPath + "\\print\\Model\\����������ӡMod.dll";
        string sPrintLayOutUser = Application.StartupPath + "\\print\\User\\����������ӡUser.dll";
        UFIDA.U8.UAP.CustomApp.ControlForm.RepBaseGrid Rep = new RepBaseGrid();

        string sState = "";

        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }

        public ����������ӡ()
        {
            InitializeComponent();
        }


        private void ProjectManager_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ee)
            {
                //MessageBox.Show("��������ʧ��");
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
            //    oFile.Filter = "Excel�ļ�|*.xls|Excel�ļ�|*.xlsx";
            //    if (oFile.ShowDialog() == DialogResult.OK)
            //    {
            //        string sFilePath = oFile.FileName;
            //        string sSQL = "select * from [�����ʽ$]";

            //        DataTable dt = clsExcel.ExcelToDT(sFilePath, sSQL, true);

            //        gridView1.Columns.Clear();

            //        for (int i = dt.Rows.Count - 1; i >= 0; i--)
            //        {
            //            if (dt.Rows[i]["���ݱ���"].ToString().Trim() == "" && dt.Rows[i]["��ͬ���"].ToString().Trim() == "" && dt.Rows[i]["��������"].ToString().Trim() == "")
            //            {
            //                dt.Rows.RemoveAt(i);
            //            }
            //        }

            //        gridControl1.DataSource = dt;


            //        if (dt == null || dt.Rows.Count < 1)
            //            throw new Exception("���ص��ļ�û�����ݣ����ʵ�����");
            //    }
            //    else
            //    {
            //        throw new Exception("ȡ������");
            //    }
            //}
            //catch (Exception ee)
            //{
            //    FrmMsgBox f = new FrmMsgBox();
            //    f.richTextBox1.Text = ee.Message;
            //    f.Text = "����ʧ��";
            //    f.ShowDialog();
            //}
        }


        ////������ʷ�����������µ��ݺ�
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

select distinct cast(0 as bit) as ѡ��,a.cInvCode as �������,a.cInvName as �������,a.cInvStd as ����ͺ�,b.cBatch as ����,b.cFree1 as ����,b.cFree2 as ����,b.cFree3 as ͳһ��,b.cFree4 as ����Ҫ��
    ,right('0000000000' + cast(b.AutoID as varchar(10)),10) as ������,1 as ��ӡ����
from inventory a left join dbo._BarCodeInventory b on a.cInvCode = b.cInvCode
    inner join InventoryClass c on a.cInvCCode = c.cInvCCode
where 1=1 and 2=2 
--union all
--select  cast(0 as bit) as ѡ��,a.cInvCode as �������,a.cInvName as �������,a.cInvStd as ����ͺ�,null as ����,null as ����,null as ����,null as ͳһ��,null as ����Ҫ��
--    ,cast(null as varchar(10)) as ������,null as ��ӡ���� from inventory a  inner join InventoryClass c on a.cInvCCode = c.cInvCCode
--where 1=1
order by a.cInvCode
";

                if (textEdit���.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and (a.cInvCode like '%" + textEdit���.Text.Trim() + "%' or a.cInvName like '%" + textEdit���.Text.Trim() + "%')");
                }
                if (textEdit�������.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and (c.cInvCName like '%" + textEdit�������.Text.Trim() + "%' or c.cInvCName like '%" + textEdit�������.Text.Trim() + "%')");
                }
                if (textEdit����.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("2=2", "2=2 and b.cFree1 like '%" + textEdit����.Text.Trim() + "%' ");
                }
            
                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];

                gridView1.OptionsView.ColumnAutoWidth = true;
                gridControl1.DataSource = dt;

                gridView1.OptionsBehavior.Editable = true;
                for (int i = 0; i < gridView1.Columns.Count; i++)
                { 
                   string sColName = gridView1.Columns[i].FieldName.Trim();
                   if (sColName == "ѡ��" || sColName == "��ӡ����" || sColName == "����" || sColName == "����" || sColName == "����" || sColName == "ͳһ��" || sColName == "����Ҫ��")
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
                f.Text = "����ʧ��";
                f.ShowDialog();
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "xls";
                sF.FileName = this.Text;
                sF.Filter = "Excel�ļ�(*.xls)|*.xls|�����ļ�(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK == dRes)
                {
                    gridView1.ExportToXls(sF.FileName);
                    MessageBox.Show("����Excel�ɹ�\n\t·����" + sF.FileName);
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
                    MessageBox.Show("���ر���ģ��ʧ�ܣ��������Ա��ϵ");
                    return;
                }

                if (Rep.dsPrint == null)
                    throw new Exception("û����Ҫ��ӡ������");

                Rep.dsPrint.Tables.Clear();

                try
                {
                    SqlConnection conn = new SqlConnection(Conn);
                    conn.Open();
                    //��������
                    SqlTransaction tran = conn.BeginTransaction();
                    //dtGrid = Select(dtGrid, "ѡ��='True'", "");
                    try
                    {
                        for (int i = 0; i < gridView1.RowCount; i++)
                        {
                            if (SqlHelper.ReturnObjectToBool(gridView1.GetRowCellValue(i, "ѡ��")))
                            {
                                string sSQL = "select * from _BarCodeInventory with(NOLOCK)  where cInvCode='" + gridView1.GetRowCellValue(i, "�������").ToString().Trim() + "' and isnull(cBatch,'')='" + gridView1.GetRowCellValue(i, "����").ToString().Trim() + "' " +
        "and isnull(cFree1,'')='" + gridView1.GetRowCellValue(i, "����").ToString().Trim() + "' and isnull(cFree2,'')='" + gridView1.GetRowCellValue(i, "����").ToString().Trim() + "' and isnull(cFree3,'')='" + gridView1.GetRowCellValue(i, "ͳһ��").ToString().Trim() + "' and isnull(cFree4,'')='" + gridView1.GetRowCellValue(i, "����Ҫ��").ToString().Trim() + "'";
                                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                                if (dt.Rows.Count == 0)
                                {
                                    sSQL = @"insert into _BarCodeInventory(cInvCode,cBatch,cFree1,cFree2,cFree3,cFree4,cFree5,cFree6,cFree7,cFree8,cFree9,cFree10) values(
'" + gridView1.GetRowCellValue(i, "�������").ToString().Trim() + "','" + gridView1.GetRowCellValue(i, "����").ToString().Trim() + "','" + gridView1.GetRowCellValue(i, "����").ToString().Trim() + "','" + gridView1.GetRowCellValue(i, "����").ToString().Trim() + "','" + gridView1.GetRowCellValue(i, "ͳһ��").ToString().Trim() + "','" + gridView1.GetRowCellValue(i, "����Ҫ��").ToString().Trim() + "',NULL,NULL,NULL,NULL,NULL,NULL)";
                                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                                    sSQL = "select right('0000000000' + cast(AutoID as varchar(10)),10) as ������ from _BarCodeInventory with(NOLOCK)  where cInvCode='" + gridView1.GetRowCellValue(i, "�������").ToString().Trim() + "' and isnull(cBatch,'')='" + gridView1.GetRowCellValue(i, "����").ToString().Trim() + "'" +
        "and isnull(cFree1,'')='" + gridView1.GetRowCellValue(i, "����").ToString().Trim() + "' and isnull(cFree2,'')='" + gridView1.GetRowCellValue(i, "����").ToString().Trim() + "' and isnull(cFree3,'')='" + gridView1.GetRowCellValue(i, "ͳһ��").ToString().Trim() + "' and isnull(cFree4,'')='" + gridView1.GetRowCellValue(i, "����Ҫ��").ToString().Trim() + "'";
                                    DataTable dts = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                                    if (dts.Rows.Count > 0)
                                    {
                                        gridView1.SetRowCellValue(i, "������", dts.Rows[0]["������"].ToString().Trim());
                                    }
                                }
                            }
                        }
                        tran.Commit();
                    }
                    catch (Exception error)
                    {
                        tran.Rollback();
                        throw new Exception(error.Message);
                    }

                }
                catch
                {

                }


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
                    if (SqlHelper.ReturnObjectToBool(dtGrid.Rows[i]["ѡ��"]))
                    {
                        int count = SqlHelper.ReturnObjectToInt(dtGrid.Rows[i]["��ӡ����"]);
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
                    throw new Exception("û��Ҫ��ӡ�ĵ���");
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
            textEdit���.Text = "";
            textEdit�������.Text = "";
            textEdit����.Text = "";
        }

        private void chkȫѡ_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    gridView1.SetRowCellValue(i, gridView1.Columns["ѡ��"], chkȫѡ.Checked);
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

            DialogResult d = MessageBox.Show("�Ƿ񱣴�?ģ����������´δ򿪴���ʱ����\n�ǣ������ӡģ��\n�񣺻ָ�Ĭ�ϴ�ӡģ��\n", "��ʾ", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
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

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            
        }


        public static DataTable Select(DataTable dt, string Sel, string Order)
        {
            DataRow[] dw = dt.Select(Sel, Order);
            DataTable dts = new DataTable();
            foreach (DataColumn dc in dt.Columns)
            {
                dts.Columns.Add(dc.ColumnName);
            }
            foreach (DataRow dws in dw)
            {
                dts.ImportRow(dws);
            }
            return dts;
        }
    }
}
//select distinct cast(0 as bit) as ѡ��,a.cInvCode as �������,a.cInvName as �������,a.cInvStd as ����ͺ�,b.cFree1 as ����,b.cFree2 as ����,b.cFree3 as ͳһ��,b.cFree4 as ����Ҫ��
//    ,right('0000000000' + cast(b.AutoID as varchar(10)),10) as ������,1 as ��ӡ����
//from inventory a left join dbo._BarCodeInventory b on a.cInvCode = b.cInvCode
//    inner join InventoryClass c on a.cInvCCode = c.cInvCCode
//where 1=1
//order by a.cInvCode