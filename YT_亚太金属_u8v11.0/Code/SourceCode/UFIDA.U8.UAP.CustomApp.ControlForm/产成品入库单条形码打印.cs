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
    public partial class ����Ʒ��ⵥ�������ӡ : UserControl
    {
        string sProPath = Application.StartupPath;

        string sPrintLayOutMod = Application.StartupPath + "\\print\\Model\\��ⵥ�������ӡMod.dll";
        string sPrintLayOutUser = Application.StartupPath + "\\print\\User\\��ⵥ�������ӡUser.dll";
        UFIDA.U8.UAP.CustomApp.ControlForm.RepBaseGrid Rep = new RepBaseGrid();

        string sState = "";

        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }

        public ����Ʒ��ⵥ�������ӡ()
        {
            InitializeComponent();
        }


        private void Frm����Ʒ��ⵥ�������ӡ_Load(object sender, EventArgs e)
        {
            try
            {
                dateEdit��������1.DateTime = DateTime.Now.AddMonths(-1);
                dateEdit��������2.DateTime = DateTime.Now;

                SetLookUp();
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

select cast(0 as bit) as ѡ��, a.cCode as ���ݺ�,convert(varchar, a.dDate, 111) as ��������,a.cDefine3 as ������˾,a.cDepCode as ���ű���,c.cDepName as ��������
	,b.cInvCode as �������,d.cInvName as �������,d.cInvStd as ����ͺ�,b.iQuantity as ����, b.iNum as ����
	,d.cDefWareHouse as �ֿ����,e.cWhName as �ֿ�,d.cPosition as ��λ����,f.cPosName as ��λ
    ,b.cFree1 as ����,b.cFree2 as ����,b.cFree3 as ͳһ��,b.cFree4 as ����Ҫ��
    ,right('0000000000' + cast(h.AutoID as varchar(10)),10) as ������,1 as ��ӡ����
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
                if (lookUpEdit���ݺ�1.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.cCode>='" + lookUpEdit���ݺ�1.Text.Trim() + "'");
                }
                if (lookUpEdit���ݺ�2.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.cCode<='" + lookUpEdit���ݺ�2.Text.Trim() + "'");
                }
                if (dateEdit��������1.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.dDate>='" + dateEdit��������1.DateTime.ToString("yyyy-MM-dd") + "'");
                }
                if (dateEdit��������2.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.dDate<='" + dateEdit��������2.DateTime.ToString("yyyy-MM-dd") + "'");
                }
               
                if (radioδ���.Checked)
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
                   if (sColName == "ѡ��" || sColName == "��ӡ����")
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

        private void SetLookUp()
        {
            string sSQL = @"select cCode from rdrecord10 order by cCode";
            DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
            lookUpEdit���ݺ�1.Properties.DataSource = dt;
            lookUpEdit���ݺ�2.Properties.DataSource = dt;
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
            lookUpEdit���ݺ�1.EditValue = DBNull.Value;
            lookUpEdit���ݺ�2.EditValue = DBNull.Value;
            dateEdit��������1.Text = "";
            dateEdit��������2.Text = "";
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

    }
}