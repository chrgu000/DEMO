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
using System.IO;


namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class �����ǩ��ӡ : UserControl
    {
        //public class CmbDataSource
        //{
        //    public string WareHouseCode;
        //    public string WareHouseName;
        //}

        //public class UserMsg
        //{
        //    public string UserCode;
        //    public string UserName;
        //}

        string sState = "";

        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }

        public �����ǩ��ӡ()
        {
            InitializeComponent();

            sPrintLayOutMod = sProPath + "\\UAP\\Runtime\\print\\Model\\" + this.labelControl1.Text.Trim() + "Mod.dll";
            sPrintLayOutUser = sProPath + "\\UAP\\Runtime\\print\\User\\" + this.labelControl1.Text.Trim() + "User.dll";
        }


        private void ProjectManager_Load(object sender, EventArgs e)
        {
            try
            {

                GetLookUp();

                if (sUserID == "admin" || sUserID == "system" || sUserID == "demo")
                {
                    btnPrintSET.Visible = true;
                }
                else
                {
                    btnPrintSET.Visible = false;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("��������ʧ��");
            }
        }

        private void GetLookUp()
        {
            string sSQL = "select * from Inventory order by cInvCode";
            DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
            ItemLookUpEdit�������.DataSource = dt;
            ItemLookUpEdit�������.DataSource = dt;
            ItemLookUpEdit����ͺ�.DataSource = dt;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSel_Click(object sender, EventArgs e)
        {
            try
            {
                chkȫѡ.Checked = false;

                //string sSQL2 = "select getdate()";
                //DateTime d��ǰ���� = Convert.ToDateTime(SqlHelper.ExecuteScalar(Conn, CommandType.Text, sSQL2));
                //DateTime dʱ���� = Convert.ToDateTime("2013-12-25");

                string sSQL = @"
select CAST(0 as bit) as ѡ��, a.cInvCode as �������
	,cast(null as varchar(50)) as ���� 
    ,b.cInvCCode as ����������,b.cInvCName as �������,isnull(a.bInvBatch,0)  as �Ƿ����ι���,isnull(bFree1 ,0) as �Ƿ񳤶ȱ���
    ,cast(null as varchar(50)) as ������, cast(null as varchar(50)) as  ����, cast(null as varchar(50)) as ����, cast(null as varchar(50)) as ¯��
    ,cast(null as varchar(50)) as  ����, cast(null as varchar(50)) as ������, cast(null as varchar(50)) as ��������, cast(null as varchar(50)) as ��ӡ����
    ,cast(null as varchar(50)) as ���һ�δ�ӡ��, cast(null as varchar(50)) as ���һ�δ�ӡ����, cast(null as varchar(50)) as ���뵥�ݺ�, cast(null as varchar(50)) as �޸���, cast(null as varchar(50)) as �޸����� 
    ,cast(null as varchar(50)) as �ر���, cast(null as varchar(50)) as �ر�����
from Inventory a inner join InventoryClass b on a.cInvCCode = b.cInvCCode
where 1=1
order by a.cInvCode
";

                string s����������� = "1=1";
                if (txt�������.Text.Trim() != "")
                {
                    if (cmb�������.Text.Trim() == "like")
                    {
                        s����������� = "1=1 and  (a.cInvCode like '%" + txt�������.Text.Trim() + "%' or a.cInvName like '%" + txt�������.Text.Trim() + "%' )";
                    }
                    else
                    {
                        s����������� = "1=1 and  (a.cInvCode " + cmb�������.Text.Trim() + " '" + txt�������.Text.Trim() + "' or a.cInvName " + cmb�������.Text.Trim() + " '" + txt�������.Text.Trim() + "' )";
                    }
                }
                sSQL = sSQL.Replace("1=1", s�����������);

                string s����������� = "1=1";
                if (txt�������.Text.Trim() != "")
                {
                    if (cmb�������.Text.Trim() == "like")
                    {
                        s����������� = "1=1 and  (b.cInvCCode like '%" + txt�������.Text.Trim() + "%' or b.cInvCName like '%" + txt�������.Text.Trim() + "%' )";
                    }
                    else
                    {
                        s����������� = "1=1 and  (b.cInvCCode " + cmb�������.Text.Trim() + " '" + txt�������.Text.Trim() + "' or b.cInvCName " + cmb�������.Text.Trim() + " '" + txt�������.Text.Trim() + "' )";
                    }
                }
                sSQL = sSQL.Replace("1=1", s�����������);

                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];

                grdDetail.DataSource = dt;

                sState = "sel";
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
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
                sF.FileName = labelControl1.Text.Trim();
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
                MessageBox.Show("�����б�ʧ�ܣ�" + ee.Message);
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

        private decimal ReturnObjectToDecimal(object o, int i)
        {
            decimal d = 0;
            try
            {
                d = Convert.ToDecimal(o);
                d = decimal.Round(d, i);
            }
            catch
            { }
            return d;
        }

        private double ReturnObjectToDouble(object o)
        {
            double d = 0;
            try
            {
                d = Convert.ToDouble(o);
            }
            catch
            { }
            return d;
        }

        private void chkȫѡ_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                gridView1.SetRowCellValue(i, gridColѡ��, chkȫѡ.Checked);
            }
        }

        private void tsbClearCon_Click(object sender, EventArgs e)
        {
            txt�������.Text = ""; 
            txt�������.Text = "";
            dtm1.Text = "";
            dtm2.Text = "";
            chk�����ѹر�.Checked = false;
            chkȫѡ.Checked = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                if (sState != "sel" && sState != "history")
                {
                    throw new Exception("�����ȹ������ݻ���δ��ӡ����ʷ���ݲ��ܱ���");
                }

                string sErr = "";

                bool b�Ƿ񱣴� = false;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (Convert.ToBoolean(gridView1.GetRowCellValue(i, gridColѡ��)))
                    {
                        bool b�Ƿ����ι��� = Convert.ToBoolean(gridView1.GetRowCellValue(i, gridCol�Ƿ����ι���));
                        if (b�Ƿ����ι���)
                        {
                            string s���� = gridView1.GetRowCellValue(i, gridCol����).ToString().Trim();
                            if (s���� == "")
                            {
                                sErr = sErr + "��" + (i + 1).ToString() + "���Ų���Ϊ��\n";
                            }
                        }
                        bool b�Ƿ񳤶ȱ��� = Convert.ToBoolean(gridView1.GetRowCellValue(i, gridCol�Ƿ񳤶ȱ���));
                        if (b�Ƿ񳤶ȱ���)
                        {
                            string s���� = gridView1.GetRowCellValue(i, gridCol����).ToString().Trim();
                            if (s���� == "")
                            {
                                sErr = sErr + "��" + (i + 1).ToString() + "���Ȳ���Ϊ��\n";
                            }
                        }

                        decimal d���� = ClsDataFormat.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol����));
                        if (d���� <= 0)
                            sErr = sErr + "��" + (i + 1).ToString() + "�����������0\n";

                        b�Ƿ񱣴� = true;

                        if (sState == "history")
                        {
                            if (ClsDataFormat.ReturnInt(gridView1.GetRowCellValue(i, gridCol��ӡ����)) != 0)
                            {
                                sErr = sErr + "��" + (i + 1).ToString() + "�Ѿ���ӡ�����޸�\n";
                            }
                        }
                    }
                }
                if (sErr.Trim().Length > 0)
                {
                    throw new Exception(sErr);
                }

                if (!b�Ƿ񱣴�)
                {
                    throw new Exception("û��ѡ����Ҫ���������");
                }


                string sSQL2 = "select getdate()";
                DateTime d��ǰ���� = Convert.ToDateTime(SqlHelper.ExecuteScalar(Conn, CommandType.Text, sSQL2));
                string s���뵥�ݺ� = d��ǰ����.ToString("yyyyMMddHHmmss");

                string sGuid = Guid.NewGuid().ToString().Trim();

                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                //��������
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (Convert.ToBoolean(gridView1.GetRowCellValue(i, gridColѡ��)))
                        {
                            if (sState == "sel")
                            {
                                string sSQL = "INSERT INTO [��������Ϣ]([�������] ,[����],[����] ,[¯��] ,[����] " +
                                                  ",[������]  ,[��������],[��ӡ����] " +
                                                  " ,[���һ�δ�ӡ��]  ,[���һ�δ�ӡ����],���뵥�ݺ�,guid) " +
                                              " VALUES ('" + gridView1.GetRowCellValue(i, gridCol�������).ToString().Trim() + "','" + gridView1.GetRowCellValue(i, gridCol����).ToString().Trim() + "','" + gridView1.GetRowCellValue(i, gridCol����).ToString().Trim() + "','" + gridView1.GetRowCellValue(i, gridCol¯��).ToString().Trim() + "'," + ClsDataFormat.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol����)) + " " +
                                                    ",'" + sUserID + "',getdate(),0" +
                                                    ",null,null,'" + s���뵥�ݺ� + "','" + sGuid + "')";
                                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                            }
                            else
                            {
                                string sSQL = "update ��������Ϣ set ���� = '" + gridView1.GetRowCellValue(i, gridCol����).ToString().Trim() + "',���� = '" + gridView1.GetRowCellValue(i, gridCol����).ToString().Trim() + "'" +
                                                        ",¯�� = '" + gridView1.GetRowCellValue(i, gridCol¯��).ToString().Trim() + "',���� = " + ClsDataFormat.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol����)) + " " +
                                                        ",�޸��� = '" + sUserID + "',�޸����� = getdate() " +
                                                        "where ������ = '" + gridView1.GetRowCellValue(i, gridCol������).ToString().Trim() + "'";
                                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                            }

                        }
                    }

                    tran.Commit();

                    GetGrid();

                    sState = "save";
                }
                catch (Exception error)
                {
                    tran.Rollback();
                    throw new Exception(error.Message);
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox msgBox = new FrmMsgBox();
                msgBox.richTextBox1.Text = ee.Message;
                msgBox.Text = "����ʧ��";
                msgBox.ShowDialog();
            }
        }

        private void gridView1_Click(object sender, EventArgs e)
        {

        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            try
            {
                GetGrid();

                sState = "history";
            }
            catch (Exception ee)
            {
                FrmMsgBox msgBox = new FrmMsgBox();
                msgBox.richTextBox1.Text = ee.Message;
                msgBox.Text = "����ʧ��";
                msgBox.ShowDialog();
            }
        }


        private void GetGrid()
        {
            chkȫѡ.Checked = false;

            string sSQL = @"
select cast(0 as bit) as ѡ��, a.*,c.cInvCCode as ����������, c.cInvCName as ������� 
from [��������Ϣ] a inner join Inventory b on a.������� = b.cInvCode inner join InventoryClass c on b.cInvCCode = c.cInvCCode
where  1=1    
";
           
            if (dtm1.Text.Trim().Length > 0)
            {
                sSQL = sSQL + " and a.�������� >= '" + dtm1.DateTime.ToString("yyyy-MM-dd") + "' ";
            }
            if (dtm2.Text.Trim().Length > 0)
            {
                sSQL = sSQL + " and a.�������� <= '" + dtm2.DateTime.AddDays(1).ToString("yyyy-MM-dd") + "' ";
            }

            sSQL = sSQL + " order by a.������";

            string s����������� = "1=1";
            if (txt�������.Text.Trim() != "")
            {
                if (cmb�������.Text.Trim() == "like")
                {
                    s����������� = "1=1 and  (b.cInvCode like '%" + txt�������.Text.Trim() + "%' or b.cInvName like '%" + txt�������.Text.Trim() + "%' )";
                }
                else
                {
                    s����������� = "1=1 and  (b.cInvCode " + cmb�������.Text.Trim() + " '" + txt�������.Text.Trim() + "' or b.cInvName " + cmb�������.Text.Trim() + " '" + txt�������.Text.Trim() + "' )";
                }
            }
            sSQL = sSQL.Replace("1=1", s�����������);

            string s����������� = "1=1";
            if (txt�������.Text.Trim() != "")
            {
                if (cmb�������.Text.Trim() == "like")
                {
                    s����������� = "1=1 and  (b.cInvCCode like '%" + txt�������.Text.Trim() + "%' or b.cInvCName like '%" + txt�������.Text.Trim() + "%' )";
                }
                else
                {
                    s����������� = "1=1 and  (b.cInvCCode " + cmb�������.Text.Trim() + " '" + txt�������.Text.Trim() + "' or b.cInvCName " + cmb�������.Text.Trim() + " '" + txt�������.Text.Trim() + "' )";
                }
            }
            sSQL = sSQL.Replace("1=1", s�����������);

            if (!chk�����ѹر�.Checked)
            {
                sSQL = sSQL.Replace("1=1", " 1=1 and isnull(a.�ر���,'') = '' ");
            }
            if (!chk�����Ѵ�ӡ.Checked)
            {
                sSQL = sSQL.Replace("1=1", " 1=1 and isnull(a.��ӡ����,0) = 0 ");
            }

            DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
            grdDetail.DataSource = dt;
        }


        private string ReturnBarCode(string sBarCode)
        {
            for (int i = 0; i <= 10; i++)
            {
                if (sBarCode.Trim().Length < 10)
                    sBarCode = "0" + sBarCode;
                else
                    break;
            }
            return sBarCode;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                if (sState != "history" && sState != "save" && sState != "print")
                {
                    throw new Exception("�������±�������룬������ʷ������ܴ�");
                }

                      SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                //��������
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (Convert.ToBoolean(gridView1.GetRowCellValue(i, gridColѡ��)))
                        {
                            string sSQL = "update ��������Ϣ set �ر��� = null,�ر����� = null where ������ = " + gridView1.GetRowCellValue(i, gridCol������).ToString().Trim();
                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        } 
                    }
                    tran.Commit();
                    GetGrid();
                }
                catch (Exception error)
                {
                    tran.Rollback();
                    throw new Exception(error.Message);
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox msgBox = new FrmMsgBox();
                msgBox.richTextBox1.Text = ee.Message;
                msgBox.Text = "��ʧ��";
                msgBox.ShowDialog();
            }
        }

        private void btnClosed_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }


                if (sState != "history" && sState != "save" && sState != "print")
                {
                    throw new Exception("�������±�������룬������ʷ������ܹر�");
                }

                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                //��������
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (Convert.ToBoolean(gridView1.GetRowCellValue(i, gridColѡ��)))
                        {
                            string sSQL = "update ��������Ϣ set �ر��� = '" + sUserID + "',�ر����� = getdate() where ������ = " + gridView1.GetRowCellValue(i, gridCol������).ToString().Trim();
                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                    }
                    tran.Commit();
                    GetGrid();
                }
                catch (Exception error)
                {
                    tran.Rollback();
                    throw new Exception(error.Message);
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox msgBox = new FrmMsgBox();
                msgBox.richTextBox1.Text = ee.Message;
                msgBox.Text = "�ر�ʧ��";
                msgBox.ShowDialog();
            }
        }

        #region ���ô�ӡģ��

        private void btnPrintSET_Click(object sender, EventArgs e)
        {
            bool bMod = false;
            if (sUserID == "admin" || sUserID == "system" || sUserID == "demo")
            {
                bMod = true;
            }

            if (!Directory.Exists(sProPath + "\\UAP\\Runtime\\print"))
                Directory.CreateDirectory(sProPath + "\\UAP\\Runtime\\print");
            if (!Directory.Exists(sProPath + "\\UAP\\Runtime\\print\\Model"))
                Directory.CreateDirectory(sProPath + "\\UAP\\Runtime\\print\\Model");
            if (!Directory.Exists(sProPath + "\\UAP\\Runtime\\print\\User"))
                Directory.CreateDirectory(sProPath + "\\UAP\\Runtime\\print\\User");

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

        
        protected string sProPath = Application.StartupPath;    //����ִ��λ��
        string sPrintLayOutMod;
        string sPrintLayOutUser;
        RepBaseGrid Rep = new RepBaseGrid();
        DataSet dsPrint = new DataSet();          //��ӡģ������Դ



        private void btnPrint_Click(object sender, EventArgs e)
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
                Rep.dsPrint.Tables["dtHead"].Rows.Clear();
                Rep.dsPrint.Tables["dtHead"].Columns.Clear();
                //���ñ����ͷ���ݱ���
                //try
                //{
                //    for (int i = 0; i < this.dsPrint.Tables["dtHead"].Columns.Count; i++)
                //    {
                //        DataColumn dc = new DataColumn();
                //        dc = this.dsPrint.Tables["dtHead"].Columns[i];
                //        DataColumn dcRep = new DataColumn();
                //        dcRep.ColumnName = dc.ColumnName;
                //        Rep.dsPrint.Tables["dtHead"].Columns.Add(dcRep);
                //    }
                //}
                //catch { }

                //if (this.dsPrint.Tables["dtHead"] != null)
                //{
                //    for (int i = 0; i < this.dsPrint.Tables["dtHead"].Rows.Count; i++)
                //    {
                //        DataRow dr = Rep.dsPrint.Tables["dtHead"].NewRow();
                //        for (int j = 0; j < Rep.dsPrint.Tables["dtHead"].Columns.Count; j++)
                //        {
                //            dr[j] = this.dsPrint.Tables["dtHead"].Rows[i][j];
                //        }
                //        Rep.dsPrint.Tables["dtHead"].Rows.Add(dr);
                //    }
                //}

                //���ñ���������ݱ���

                Rep.dsPrint.Tables["dtGrid"].Clear();
                Rep.dsPrint.Tables["dtGrid"].Columns.Clear();
                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    DataColumn dcGrid = new DataColumn();
                    dcGrid.ColumnName = gridView1.Columns[i].Caption;
                    Rep.dsPrint.Tables["dtGrid"].Columns.Add(dcGrid);
                }
                if (grdDetail.DataSource != null)
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (Convert.ToBoolean(gridView1.GetRowCellValue(i, gridColѡ��)))
                        {
                            DataRow dr = Rep.dsPrint.Tables["dtGrid"].NewRow();
                            for (int j = 0; j < Rep.dsPrint.Tables["dtGrid"].Columns.Count; j++)
                            {
                                if (gridView1.Columns[j].Caption == "������")
                                {
                                    dr[j] = ReturnBarCode(gridView1.GetRowCellDisplayText(i, gridView1.Columns[j]));
                                }
                                else
                                {
                                    dr[j] = gridView1.GetRowCellDisplayText(i, gridView1.Columns[j]);
                                }
                            }
                            Rep.dsPrint.Tables["dtGrid"].Rows.Add(dr);
                        }
                    }
                }

                Rep.DataMember = "dtGrid";
                Rep.ShowPreview();
                //Rep.Print();


                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                //��������
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (Convert.ToBoolean(gridView1.GetRowCellValue(i, gridColѡ��)))
                        {
                            string sSQL = "update ��������Ϣ set ��ӡ���� = isnull(��ӡ����,0) + 1,���һ�δ�ӡ�� = '" + sUserID + "',���һ�δ�ӡ���� = getdate() where ������ = " + gridView1.GetRowCellValue(i, gridCol������).ToString().Trim();
                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                    }
                    tran.Commit();
                }
                catch (Exception error)
                {
                    tran.Rollback();
                    throw new Exception(error.Message);
                }

                sState = "print";
            }
            catch (Exception ee)
            {
                MessageBox.Show("��ӡʧ��:" + ee.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        #endregion
    }
}