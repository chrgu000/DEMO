using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;


namespace Warehouse
{
    public partial class Frmջ��ֿ��շ��ǼǱ� : FrameBaseFunction.Frm�б���ģ��
    {
        public Frmջ��ֿ��շ��ǼǱ�()
        {
            InitializeComponent();
        }



        #region ��ť����
        protected override void BtnClick(string sBtnName, string sBtnText)
        {
            try
            {
                switch (sBtnName.ToLower())
                {
                    case "addrow":
                        btnAddRow();
                        break;
                    case "add":
                        btnAdd();
                        break;
                    case "alter":
                        btnAlter();
                        break;
                    case "audit":
                        btnAudit();
                        break;
                    case "del":
                        btnDel();
                        break;
                    case "delrow":
                        btnDelRow();
                        break;
                    case "edit":
                        btnEdit();
                        break;
                    case "export":
                        btnExport();
                        break;
                    case "first":
                        btnFirst();
                        break;
                    case "import":
                        btnImport();
                        break;
                    case "last":
                        btnLast();
                        break;
                    case "lock":
                        btnLock();
                        break;
                    case "next":
                        btnNext();
                        break;
                    case "prev":
                        btnPrev();
                        break;
                    //case "printset":
                    //    btnPrintSet();
                    //    break;
                    case "refresh":
                        btnRefresh();
                        break;
                    case "save":
                        btnSave();
                        break;
                    case "sel":
                        btnSel();
                        break;
                    case "unaudit":
                        btnUnAudit();
                        break;
                    case "undo":
                        btnUnDo();
                        break;
                    case "unlock":
                        btnUnLock();
                        break;
                    case "open":
                        btnOpen();
                        break;
                    case "close":
                        btnClose();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ee)
            {
                throw new Exception(sBtnText + " ʧ��! \n\nԭ��:\n  " + ee.Message);
            }
        }

        private void btnAdd()
        {

        }


        #region ��ťģ��

        /// <summary>
        /// ���
        /// </summary>
        private void btnExport()
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

       
        #endregion

        /// <summary>
        /// ����
        /// </summary>
        private void btnImport()
        {

        }
        /// <summary>
        /// ˢ��
        /// </summary>
        private void btnRefresh()
        {
            GetLookUp();
        }
        /// <summary>
        /// ��ѯ
        /// </summary>
        private void btnSel()
        {
            GetGrid();
        }
        /// <summary>
        /// ��ҳ
        /// </summary>
        private void btnFirst()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// ��ҳ
        /// </summary>
        private void btnPrev()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// ��ҳ
        /// </summary>
        private void btnNext()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// ĩҳ
        /// </summary>
        private void btnLast()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// ����
        /// </summary>
        private void btnLock()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// ����
        /// </summary>
        private void btnUnLock()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// ����
        /// </summary>
        private void btnAddRow()
        {
            gridView1.AddNewRow();
        }
        /// <summary>
        /// ɾ��
        /// </summary>
        private void btnDelRow()
        {
            for (int i = gridView1.RowCount - 1; i >= 0; i--)
            {
                if (gridView1.IsRowSelected(i))
                {
                    gridView1.DeleteRow(i);
                }
            }
        }
        /// <summary>
        /// �޸�
        /// </summary>
        private void btnEdit()
        {
            SetGridColReadOnly(false);

            string sID = "";
            try
            {
                sID = gridView1.GetRowCellValue(gridView1.RowCount - 1, gridColiID).ToString().Trim();
            }
            catch { }
            if (sID != "")
                gridView1.AddNewRow();
        }
        /// <summary>
        /// ɾ��
        /// </summary>
        private void btnDel()
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            ArrayList aList = new ArrayList();
            string sErr = "";
            DialogResult d = MessageBox.Show("ȷ��ɾ��ѡ�е���ô?", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (d == DialogResult.Yes)
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, gridColiID).ToString().Trim() == "")
                        continue;

                    bool b = Convert.ToBoolean(gridView1.GetRowCellValue(i, gridColѡ��));
                    if (b)
                    {
                        string siID = gridView1.GetRowCellValue(i, gridColiID).ToString().Trim();

                        string sSQL = "select * from   [UFDLImport].[dbo].[ջ��ֿ��շ��ǼǱ�] where iID = " + siID;
                        DataTable dt = clsSQLCommond.ExecQuery(sSQL);

                        if (dt == null || dt.Rows.Count == 0)
                        {
                            sErr = sErr + "��" + (i + 1).ToString() + "������,�����Ѿ�ɾ��\n";
                        }
                        else
                        {

                            string s����� = dt.Rows[0]["�����"].ToString().Trim();
                            if (s����� == "")
                            {
                                sSQL = "delete  [UFDLImport].[dbo].[ջ��ֿ��շ��ǼǱ�] where iID = " + siID;
                                aList.Add(sSQL);
                            }
                            else
                            {
                                sErr = sErr + "��" + (i + 1).ToString() + "�Ѿ���˲���ɾ��\n";
                            }
                        }
                    }
                }
                if (sErr.Trim() != "")
                {
                    throw new Exception(sErr);
                }

                if (aList.Count > 0)
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("ɾ���ɹ�");

                    GetGrid();
                }
                else
                {
                    MessageBox.Show("��ѡ����Ҫɾ���ĵ���");
                }
            }
        }


        /// <summary>
        /// ����
        /// </summary>
        private void btnSave()
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            DALջ��ֿ��շ��ǼǱ� DAL = new DALջ��ֿ��շ��ǼǱ�();

            DataView dv = ((DataView)gridView1.DataSource);
            DataTable dtGrid = dv.ToTable();
            ArrayList aList = new ArrayList();

            string sErr = "";
            for (int i = 0; i < dtGrid.Rows.Count; i++)
            {
                bool b = false;
                try
                {
                    b = Convert.ToBoolean(dtGrid.Rows[i]["ѡ��"]);
                }
                catch { }

                if (!b)
                    continue;

                Modelջ��ֿ��շ��ǼǱ� model = new Modelջ��ֿ��շ��ǼǱ�();
                model = DAL.DataRowToModel(dtGrid.Rows[i]);

                model.�Ƶ��� = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                model.�Ƶ����� = Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate);

                if (model.iID == 0 && model.�������� == "")
                {
                    continue;
                }

                

                if (model.�������� == "")
                {
                    sErr = sErr + "��" + (i + 1).ToString() + "�������Ͳ���Ϊ��\n";
                }

                string sSQL = "select * from   [UFDLImport].[dbo].[ջ��ֿ��շ��ǼǱ�] where iID = " + model.iID;
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["�����"].ToString().Trim() != "")
                    {
                        sErr = sErr + "��" + (i + 1).ToString() + "�Ѿ����\n";
                        continue;
                    }
                }

                if (model.iID == 0)
                {
                    sSQL = DAL.Add(model);
                    aList.Add(sSQL);
                }
                else
                {
                    sSQL = DAL.Update(model);
                    aList.Add(sSQL);
                }
            }

            if (sErr.Trim() != "")
            {
                throw new Exception(sErr);
            }

            if (aList.Count > 0)
            {
                clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("����ɹ�");
                GetGrid();
            }
        }
        /// <summary>
        /// ����
        /// </summary>
        private void btnUnDo()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// ���
        /// </summary>
        private void btnAudit()
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            ArrayList aList = new ArrayList();
            string sErr = "";

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridColiID).ToString().Trim() == "")
                    continue;

                bool b = Convert.ToBoolean(gridView1.GetRowCellValue(i, gridColѡ��));
                if (b)
                {
                    string siID = gridView1.GetRowCellValue(i, gridColiID).ToString().Trim();

                    string sSQL = "select * from   [UFDLImport].[dbo].[ջ��ֿ��շ��ǼǱ�] where iID = " + siID;
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);

                    if (dt == null || dt.Rows.Count == 0)
                    {
                        sErr = sErr + "��" + (i + 1).ToString() + "������,�����Ѿ�ɾ��\n";
                    }
                    else
                    {

                        string s����� = dt.Rows[0]["�����"].ToString().Trim();
                        if (s����� == "")
                        {
                            sSQL = "update  [UFDLImport].[dbo].[ջ��ֿ��շ��ǼǱ�] set ����� = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "' , ������� = getdate() where iID = " + siID;
                            aList.Add(sSQL);
                        }
                        else
                        {
                            sErr = sErr + "��" + (i + 1).ToString() + "�Ѿ����\n";
                        }
                    }
                }
            }
            if (sErr.Trim() != "")
            {
                throw new Exception(sErr);
            }

            if (aList.Count > 0)
            {
                clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("��˳ɹ�");

                GetGrid();
            }
            else
            {
                MessageBox.Show("��ѡ����Ҫ��˵ĵ���");
            }
        }
        /// <summary>
        /// ����
        /// </summary>
        private void btnUnAudit()
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            ArrayList aList = new ArrayList();
            string sErr = "";

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridColiID).ToString().Trim() == "")
                    continue;

                bool b = Convert.ToBoolean(gridView1.GetRowCellValue(i, gridColѡ��));
                if (b)
                {
                    string siID = gridView1.GetRowCellValue(i, gridColiID).ToString().Trim();

                    string sSQL = "select * from   [UFDLImport].[dbo].[ջ��ֿ��շ��ǼǱ�] where iID = " + siID;
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);

                    if (dt == null || dt.Rows.Count == 0)
                    {
                        sErr = sErr + "��" + (i + 1).ToString() + "������,�����Ѿ�ɾ��\n";
                    }
                    else
                    {

                        string s����� = dt.Rows[0]["�����"].ToString().Trim();
                        if (s����� != "")
                        {
                            sSQL = "update  [UFDLImport].[dbo].[ջ��ֿ��շ��ǼǱ�] set ����� = null , ������� = null where iID = " + siID;
                            aList.Add(sSQL);
                        }
                        else
                        {
                            sErr = sErr + "��" + (i + 1).ToString() + "δ���\n";
                        }
                    }
                }
            }
            if (sErr.Trim() != "")
            {
                throw new Exception(sErr);
            }

            if (aList.Count > 0)
            {
                clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("����ɹ�");

                GetGrid();
            }
            else
            {
                MessageBox.Show("��ѡ����Ҫ����ĵ���");
            }
        }
        /// <summary>
        /// ��
        /// </summary>
        private void btnOpen()
        {
           
        }
        /// <summary>
        /// �ر�
        /// </summary>
        private void btnClose()
        {
           
        }
        /// <summary>
        /// ���
        /// </summary>
        private void btnAlter()
        {
            throw new NotImplementedException();
        }

        #endregion

        private void Frmջ�峧���շ��ǼǱ�_Load(object sender, EventArgs e)
        {
            try
            {
                dateEdit1.DateTime = ReturnObjectToDatetime(FrameBaseFunction.ClsBaseDataInfo.sLogDate).AddMonths(-1);
                dateEdit2.DateTime = ReturnObjectToDatetime(FrameBaseFunction.ClsBaseDataInfo.sLogDate);

                GetLookUp();
                GetGrid();

                dateEdit1.Enabled = true;
                dateEdit1.Properties.ReadOnly = false;
                dateEdit2.Enabled = true;
                dateEdit2.Properties.ReadOnly = false;
            }
            catch (Exception ee)
            {
                MessageBox.Show("���ش���ʧ��\n" + ee.Message);
            }
        }

        private void GetGrid()
        {
            string sSQL = "select * from UFDLImport.dbo._Code where vchrType = '1' order by vchrInfo";
            DataTable dtջ�� = clsSQLCommond.ExecQuery(sSQL);
            for (int i = 0; i < gridView1.Columns.Count; i++)
            {
                string sCol = gridView1.Columns[i].FieldName;
                if (sCol.Length > 2 && sCol.Substring(0, 2) == "ջ��")
                {
                    DataRow[] dr = dtջ��.Select("vchrInfo = '" + sCol.Trim() + "'");
                    if (dr.Length > 0)
                    {
                        gridView1.Columns[i].Visible = true;
                        gridView1.Columns[i].Caption = dr[0]["vchrRemark"].ToString().Trim();
                    }
                    else
                    {
                        gridView1.Columns[i].Visible = false;
                    }
                }
            }

            int iRow = gridView1.FocusedRowHandle;

            sSQL = @"
select cast(0 as bit) as ѡ��
      ,a.iID, a.��������, a.���ݺ�, a.ջ��1, a.ջ��2, a.ջ��3, a.ջ��4, a.ջ��5, a.ջ��6, a.ջ��7, a.ջ��8, a.ջ��9, a.ջ��10, a.����, a.��ע, a.�Ƶ���, a.�Ƶ�����, a.�����, a.�������
      ,c.vchrInfo as �շ�
from [UFDLImport].[dbo].[ջ��ֿ��շ��ǼǱ�] a left join [UFDLImport].._Code b on b.vchrInfo = a.[��������] and b.vchrType = '4'
    left join  [UFDLImport].._Code c on c.iOrder = b.iOrder and c.vchrType = '3'
where [����] >= '111111' and [����] < = '222222'
order by a.iID;
";
            sSQL = sSQL.Replace("111111", dateEdit1.DateTime.ToString("yyyy-MM-dd"));
            sSQL = sSQL.Replace("222222", dateEdit2.DateTime.ToString("yyyy-MM-dd"));
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dt;
            gridView1.AddNewRow();

            SetGridColReadOnly(false);
            gridView1.FocusedRowHandle = iRow;

            chkȫѡ.Checked = false;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column != gridColѡ��)
                {
                    gridView1.SetRowCellValue(e.RowHandle, gridColѡ��, true);

                    int iRow = e.RowHandle;

                    if (iRow == gridView1.RowCount - 1)
                    {
                        gridView1.AddNewRow();
                        gridView1.FocusedRowHandle = iRow;
                    }

                    if (gridView1.GetRowCellValue(e.RowHandle, gridCol����).ToString().Trim() == "")
                    {
                        gridView1.SetRowCellValue(e.RowHandle, gridCol����, FrameBaseFunction.ClsBaseDataInfo.sLogDate);
                    }
                }

                if (e.Column == gridCol��������)
                {
                    string s�������� = gridView1.GetRowCellValue(e.RowHandle, gridCol��������).ToString().Trim();
                    string sSQL = @"
select b.vchrInfo 
from UFDLImport.dbo._Code a
	inner join UFDLImport.dbo._Code b on a.iOrder = b.iOrder and a.vchrType = '4' and b.vchrType = '3'
where a.vchrInfo = '111111'
";
                    sSQL = sSQL.Replace("111111", s��������);
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        gridView1.SetRowCellValue(e.RowHandle, gridCol�շ�, dt.Rows[0][0]);
                    }

                }
            }
            catch (Exception ee)
            {
                MsgBox("��ʾ", ee.Message);
            }
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

        private void GetLookUp()
        {
            string sSQL = "select vchrInfo as �������� from UFDLImport.dbo._Code where vchrType = '4' order by vchrRemark";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit��������.DataSource = dt;

            sSQL = "select iOrder as ����,vchrInfo as ���� from UFDLImport.._Code where vchrType = '3' order by iOrder";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit�շ�.DataSource = dt;
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                string s����� = gridView1.GetRowCellValue(e.FocusedRowHandle, gridCol�����).ToString().Trim();
                if (s����� == "")
                    SetGridColReadOnly(false);
                else
                    SetGridColReadOnly(true);
            }
            catch { }
        }

        private void SetGridColReadOnly(bool b)
        {
            gridCol��������.OptionsColumn.ReadOnly = b;
            gridCol����.OptionsColumn.ReadOnly = b;
            gridColջ��1.OptionsColumn.ReadOnly = b;
            gridColջ��2.OptionsColumn.ReadOnly = b;
            gridColջ��3.OptionsColumn.ReadOnly = b;
            gridColջ��4.OptionsColumn.ReadOnly = b;
            gridColջ��5.OptionsColumn.ReadOnly = b;
            gridColջ��6.OptionsColumn.ReadOnly = b;
            gridColջ��7.OptionsColumn.ReadOnly = b;
            gridColջ��8.OptionsColumn.ReadOnly = b;
            gridColջ��9.OptionsColumn.ReadOnly = b;
            gridColջ��10.OptionsColumn.ReadOnly = b;
            gridColѡ��.OptionsColumn.ReadOnly = false;
        }

        private void chkȫѡ_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    string siID = gridView1.GetRowCellValue(i, gridColiID).ToString().Trim();
                    if (siID == "")
                        continue;

                    gridView1.SetRowCellValue(i, gridColѡ��, chkȫѡ.Checked);
                }
            }
            catch { }
        }

        private DataTable GetVendor(string sVenCode)
        {
            try
            {
                string sSQL = "select cVenCode as iID,cVenName as iText from @u8.Vendor where cVenCode = '" + sVenCode + "' order by cVenCode";
                DataTable dt = clsGetSQL.GetLookUpEdit(sSQL);
                return dt;
            }
            catch
            {
                throw new Exception("��ù�Ӧ����Ϣʧ�ܣ�");
            }
        }
    }



    /// <summary>
    /// ջ��ֿ��շ��ǼǱ�:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    [Serializable]
    public partial class Modelջ��ֿ��շ��ǼǱ�
    {
        public Modelջ��ֿ��շ��ǼǱ�()
        { }
        #region Model
        private int _iid;
        private string _��������;
        private string _���ݺ�;
        private int? _ջ��1;
        private int? _ջ��2;
        private int? _ջ��3;
        private int? _ջ��4;
        private int? _ջ��5;
        private int? _ջ��6;
        private int? _ջ��7;
        private int? _ջ��8;
        private int? _ջ��9;
        private int? _ջ��10;
        private DateTime? _����;
        private string _��ע;
        private string _�Ƶ���;
        private DateTime? _�Ƶ�����;
        private string _�����;
        private DateTime? _�������;
        /// <summary>
        /// 
        /// </summary>
        public int iID
        {
            set { _iid = value; }
            get { return _iid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ��������
        {
            set { _�������� = value; }
            get { return _��������; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ���ݺ�
        {
            set { _���ݺ� = value; }
            get { return _���ݺ�; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ջ��1
        {
            set { _ջ��1 = value; }
            get { return _ջ��1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ջ��2
        {
            set { _ջ��2 = value; }
            get { return _ջ��2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ջ��3
        {
            set { _ջ��3 = value; }
            get { return _ջ��3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ջ��4
        {
            set { _ջ��4 = value; }
            get { return _ջ��4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ջ��5
        {
            set { _ջ��5 = value; }
            get { return _ջ��5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ջ��6
        {
            set { _ջ��6 = value; }
            get { return _ջ��6; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ջ��7
        {
            set { _ջ��7 = value; }
            get { return _ջ��7; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ջ��8
        {
            set { _ջ��8 = value; }
            get { return _ջ��8; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ջ��9
        {
            set { _ջ��9 = value; }
            get { return _ջ��9; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ջ��10
        {
            set { _ջ��10 = value; }
            get { return _ջ��10; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ����
        {
            set { _���� = value; }
            get { return _����; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ��ע
        {
            set { _��ע = value; }
            get { return _��ע; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string �Ƶ���
        {
            set { _�Ƶ��� = value; }
            get { return _�Ƶ���; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? �Ƶ�����
        {
            set { _�Ƶ����� = value; }
            get { return _�Ƶ�����; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string �����
        {
            set { _����� = value; }
            get { return _�����; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? �������
        {
            set { _������� = value; }
            get { return _�������; }
        }
        #endregion Model

    }



    /// <summary>
    /// ���ݷ�����:ջ��ֿ��շ��ǼǱ�
    /// </summary>
    public partial class DALջ��ֿ��շ��ǼǱ�
    {
        public DALջ��ֿ��շ��ǼǱ�()
        { }
        #region  Method

        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public string Exists(int iID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from UFDLImport..ջ��ֿ��շ��ǼǱ�");
            strSql.Append(" where iID=" + iID + " ");
            return (strSql.ToString());
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public string Add(Modelջ��ֿ��շ��ǼǱ� model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.�������� != null)
            {
                strSql1.Append("��������,");
                strSql2.Append("'" + model.�������� + "',");
            }
            if (model.���ݺ� != null)
            {
                strSql1.Append("���ݺ�,");
                strSql2.Append("'" + model.���ݺ� + "',");
            }
            if (model.ջ��1 != null)
            {
                strSql1.Append("ջ��1,");
                strSql2.Append("" + model.ջ��1 + ",");
            }
            if (model.ջ��2 != null)
            {
                strSql1.Append("ջ��2,");
                strSql2.Append("" + model.ջ��2 + ",");
            }
            if (model.ջ��3 != null)
            {
                strSql1.Append("ջ��3,");
                strSql2.Append("" + model.ջ��3 + ",");
            }
            if (model.ջ��4 != null)
            {
                strSql1.Append("ջ��4,");
                strSql2.Append("" + model.ջ��4 + ",");
            }
            if (model.ջ��5 != null)
            {
                strSql1.Append("ջ��5,");
                strSql2.Append("" + model.ջ��5 + ",");
            }
            if (model.ջ��6 != null)
            {
                strSql1.Append("ջ��6,");
                strSql2.Append("" + model.ջ��6 + ",");
            }
            if (model.ջ��7 != null)
            {
                strSql1.Append("ջ��7,");
                strSql2.Append("" + model.ջ��7 + ",");
            }
            if (model.ջ��8 != null)
            {
                strSql1.Append("ջ��8,");
                strSql2.Append("" + model.ջ��8 + ",");
            }
            if (model.ջ��9 != null)
            {
                strSql1.Append("ջ��9,");
                strSql2.Append("" + model.ջ��9 + ",");
            }
            if (model.ջ��10 != null)
            {
                strSql1.Append("ջ��10,");
                strSql2.Append("" + model.ջ��10 + ",");
            }
            if (model.���� != null)
            {
                strSql1.Append("����,");
                strSql2.Append("'" + model.���� + "',");
            }
            if (model.��ע != null)
            {
                strSql1.Append("��ע,");
                strSql2.Append("'" + model.��ע + "',");
            }
            if (model.�Ƶ��� != null)
            {
                strSql1.Append("�Ƶ���,");
                strSql2.Append("'" + model.�Ƶ��� + "',");
            }
            if (model.�Ƶ����� != null)
            {
                strSql1.Append("�Ƶ�����,");
                strSql2.Append("'" + model.�Ƶ����� + "',");
            }
            if (model.����� != null)
            {
                strSql1.Append("�����,");
                strSql2.Append("'" + model.����� + "',");
            }
            if (model.������� != null)
            {
                strSql1.Append("�������,");
                strSql2.Append("'" + model.������� + "',");
            }
            strSql.Append("insert into UFDLImport..ջ��ֿ��շ��ǼǱ�(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            return strSql.ToString();
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public string Update(Modelջ��ֿ��շ��ǼǱ� model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update UFDLImport..ջ��ֿ��շ��ǼǱ� set ");
            if (model.�������� != null)
            {
                strSql.Append("��������='" + model.�������� + "',");
            }
            else
            {
                strSql.Append("��������= null ,");
            }
            if (model.���ݺ� != null)
            {
                strSql.Append("���ݺ�='" + model.���ݺ� + "',");
            }
            else
            {
                strSql.Append("���ݺ�= null ,");
            }
            if (model.ջ��1 != null)
            {
                strSql.Append("ջ��1=" + model.ջ��1 + ",");
            }
            else
            {
                strSql.Append("ջ��1= null ,");
            }
            if (model.ջ��2 != null)
            {
                strSql.Append("ջ��2=" + model.ջ��2 + ",");
            }
            else
            {
                strSql.Append("ջ��2= null ,");
            }
            if (model.ջ��3 != null)
            {
                strSql.Append("ջ��3=" + model.ջ��3 + ",");
            }
            else
            {
                strSql.Append("ջ��3= null ,");
            }
            if (model.ջ��4 != null)
            {
                strSql.Append("ջ��4=" + model.ջ��4 + ",");
            }
            else
            {
                strSql.Append("ջ��4= null ,");
            }
            if (model.ջ��5 != null)
            {
                strSql.Append("ջ��5=" + model.ջ��5 + ",");
            }
            else
            {
                strSql.Append("ջ��5= null ,");
            }
            if (model.ջ��6 != null)
            {
                strSql.Append("ջ��6=" + model.ջ��6 + ",");
            }
            else
            {
                strSql.Append("ջ��6= null ,");
            }
            if (model.ջ��7 != null)
            {
                strSql.Append("ջ��7=" + model.ջ��7 + ",");
            }
            else
            {
                strSql.Append("ջ��7= null ,");
            }
            if (model.ջ��8 != null)
            {
                strSql.Append("ջ��8=" + model.ջ��8 + ",");
            }
            else
            {
                strSql.Append("ջ��8= null ,");
            }
            if (model.ջ��9 != null)
            {
                strSql.Append("ջ��9=" + model.ջ��9 + ",");
            }
            else
            {
                strSql.Append("ջ��9= null ,");
            }
            if (model.ջ��10 != null)
            {
                strSql.Append("ջ��10=" + model.ջ��10 + ",");
            }
            else
            {
                strSql.Append("ջ��10= null ,");
            }
            if (model.���� != null)
            {
                strSql.Append("����='" + model.���� + "',");
            }
            else
            {
                strSql.Append("����= null ,");
            }
            if (model.��ע != null)
            {
                strSql.Append("��ע='" + model.��ע + "',");
            }
            else
            {
                strSql.Append("��ע= null ,");
            }
            if (model.�Ƶ��� != null)
            {
                strSql.Append("�Ƶ���='" + model.�Ƶ��� + "',");
            }
            else
            {
                strSql.Append("�Ƶ���= null ,");
            }
            if (model.�Ƶ����� != null)
            {
                strSql.Append("�Ƶ�����='" + model.�Ƶ����� + "',");
            }
            else
            {
                strSql.Append("�Ƶ�����= null ,");
            }
            if (model.����� != null)
            {
                strSql.Append("�����='" + model.����� + "',");
            }
            else
            {
                strSql.Append("�����= null ,");
            }
            if (model.������� != null)
            {
                strSql.Append("�������='" + model.������� + "',");
            }
            else
            {
                strSql.Append("�������= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where iID=" + model.iID + "");
            return strSql.ToString();
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Modelջ��ֿ��շ��ǼǱ� DataRowToModel(DataRow row)
        {
            Modelջ��ֿ��շ��ǼǱ� model = new Modelջ��ֿ��շ��ǼǱ�();
            if (row != null)
            {
                if (row["iID"] != null && row["iID"].ToString() != "")
                {
                    model.iID = int.Parse(row["iID"].ToString());
                }
                if (row["��������"] != null)
                {
                    model.�������� = row["��������"].ToString();
                }
                if (row["���ݺ�"] != null)
                {
                    model.���ݺ� = row["���ݺ�"].ToString();
                }
                if (row["ջ��1"] != null && row["ջ��1"].ToString() != "")
                {
                    model.ջ��1 = int.Parse(row["ջ��1"].ToString());
                }
                if (row["ջ��2"] != null && row["ջ��2"].ToString() != "")
                {
                    model.ջ��2 = int.Parse(row["ջ��2"].ToString());
                }
                if (row["ջ��3"] != null && row["ջ��3"].ToString() != "")
                {
                    model.ջ��3 = int.Parse(row["ջ��3"].ToString());
                }
                if (row["ջ��4"] != null && row["ջ��4"].ToString() != "")
                {
                    model.ջ��4 = int.Parse(row["ջ��4"].ToString());
                }
                if (row["ջ��5"] != null && row["ջ��5"].ToString() != "")
                {
                    model.ջ��5 = int.Parse(row["ջ��5"].ToString());
                }
                if (row["ջ��6"] != null && row["ջ��6"].ToString() != "")
                {
                    model.ջ��6 = int.Parse(row["ջ��6"].ToString());
                }
                if (row["ջ��7"] != null && row["ջ��7"].ToString() != "")
                {
                    model.ջ��7 = int.Parse(row["ջ��7"].ToString());
                }
                if (row["ջ��8"] != null && row["ջ��8"].ToString() != "")
                {
                    model.ջ��8 = int.Parse(row["ջ��8"].ToString());
                }
                if (row["ջ��9"] != null && row["ջ��9"].ToString() != "")
                {
                    model.ջ��9 = int.Parse(row["ջ��9"].ToString());
                }
                if (row["ջ��10"] != null && row["ջ��10"].ToString() != "")
                {
                    model.ջ��10 = int.Parse(row["ջ��10"].ToString());
                }
                if (row["����"] != null && row["����"].ToString() != "")
                {
                    model.���� = DateTime.Parse(row["����"].ToString());
                }
                if (row["��ע"] != null)
                {
                    model.��ע = row["��ע"].ToString();
                }
                if (row["�Ƶ���"] != null)
                {
                    model.�Ƶ��� = row["�Ƶ���"].ToString();
                }
                if (row["�Ƶ�����"] != null && row["�Ƶ�����"].ToString() != "")
                {
                    model.�Ƶ����� = DateTime.Parse(row["�Ƶ�����"].ToString());
                }
                if (row["�����"] != null)
                {
                    model.����� = row["�����"].ToString();
                }
                if (row["�������"] != null && row["�������"].ToString() != "")
                {
                    model.������� = DateTime.Parse(row["�������"].ToString());
                }
            }
            return model;
        }

        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

