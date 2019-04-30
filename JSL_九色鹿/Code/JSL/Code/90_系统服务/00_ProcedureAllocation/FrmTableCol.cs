using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace ϵͳ����
{
    public partial class FrmTableCol : ϵͳ����.FrmBaseInfo
    {
        ϵͳ����.ClsDataBase clsSQL = ϵͳ����.ClsDataBaseFactory.Instance();

        public FrmTableCol()
        {
            InitializeComponent();
        }


//��900�������ݱ�ṹ����200����
//insert into dbo._TableColInfo(TABLE_CATALOG,TABLE_SCHEMA,TABLE_NAME,COLUMN_NAME,COLUMN_Text,DATA_TYPE,COLLATION_ADD)
//select  'UFDATA_200_2010',TABLE_SCHEMA,TABLE_NAME,COLUMN_NAME,COLUMN_Text,DATA_TYPE,COLLATION_ADD
//from dbo._TableColInfo
//where TABLE_CATALOG = 'UFDATA_900_2010'


        protected override void BtnClick(string sBtnName, string sBtnText)
        {
            try
            {
                switch (sBtnName.ToLower())
                {
                    case "save":
                        btnSave();
                        break;
                    case "export":
                        btnExport();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(sBtnText + " ʧ��! \n\nԭ��:\n  " + ee.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExport()
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                }
                catch { }

                SaveFileDialog sa = new SaveFileDialog();
                sa.Filter = "Excel�ļ�2003|*.xls";
                sa.FileName = "������Ϣ";

                DialogResult d = sa.ShowDialog();
                if (d == DialogResult.OK)
                {
                    string sPath = sa.FileName;

                    if (sPath.Trim() != string.Empty)
                    {
                        gridView1.ExportToXls(sPath);
                        MessageBox.Show("�����б�ɹ���\n·����" + sPath);
                    }
                }
            }
            catch (Exception ee)
            {
                throw new Exception("�����б�ʧ�ܣ�" + ee.Message);
            }
        }

        private void btnSave()
        {
            try
            {
                int iSystem = 0;
                if (chkSystem.Checked)
                    iSystem = 1;

                ArrayList aList = new ArrayList();
                string sSQL = "delete _TableColInfo where TABLE_CATALOG = '" + lookUpEditDataBase.EditValue.ToString().Trim() + "' and TABLE_NAME = '" + lookUpEditTable.EditValue.ToString().Trim() + "'";
                aList.Add(sSQL);

                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;

                DataTable dt = (DataTable)gridControl1.DataSource;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int iKey = 0;
                    if (Convert.ToBoolean(dt.Rows[i]["bKey"]))
                        iKey = 1;

                    sSQL = "insert into dbo._TableColInfo(bSystem,TABLE_CATALOG,TABLE_SCHEMA,TABLE_NAME,COLUMN_NAME,COLUMN_Text,DATA_TYPE,COLLATION_ADD,bKey) " +
                            "values(" + iSystem + ",'" + dt.Rows[i]["TABLE_CATALOG"] + "','dbo','" + dt.Rows[i]["TABLE_NAME"] + "','" + dt.Rows[i]["COLUMN_NAME"] + "','" + dt.Rows[i]["COLUMN_Text"] + "'," + dt.Rows[i]["DataType"] + "," + dt.Rows[i]["collation_add"] + "," + iKey + ")";

                    aList.Add(sSQL);
                }

                if (aList.Count <= 0)
                {
                    throw new Exception("����ʧ�ܣ�");
                }
                clsSQL.ExecSqlTran(aList);
                MessageBox.Show("����ɹ�,���ƣ�" + aList.Count);
                lookUpEditTable_EditValueChanged(null, null);
            }
            catch (Exception ee)
            {
                MessageBox.Show("����ʧ�ܣ�\n  " + ee.Message);
            }
        }
        private void FrmTableCol_Load(object sender, EventArgs e)
        {
            try
            {
                SetConEnable(true);

                string sSQL = "Select Name FROM Master..SysDatabases order by Name ";
                DataTable dt = clsSQL.ExecQuery(sSQL);
                lookUpEditDataBase.Properties.DataSource = dt;
                lookUpEditDataBase.EditValue = ϵͳ����.ClsBaseDataInfo.sDataBaseName;

                GetlookUpEditDataBase();
                GetlookUpEditSQLAdd(); 
                GetlookUpEdibKey();

                if (ϵͳ����.ClsBaseDataInfo.sUid.ToLower() == "admin" || ϵͳ����.ClsBaseDataInfo.sUid.ToLower() == "system")
                {
                    for (int i = 0; i < base.toolStripMenuBtn.Items.Count; i++)
                    {
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "save")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = true;
                        }
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "export")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = true;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < base.toolStripMenuBtn.Items.Count; i++)
                    {
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "save")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = false;
                        }
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "export")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = false;
                        }
                    } 
                }
            }
            catch(Exception ee)
            {
                MessageBox.Show("���ش���ʧ�ܣ�\n  " + ee.Message);
            }
        }

        private void GetlookUpEditSQLAdd()
        {
            try
            {
                DataTable dt = new DataTable();
                DataColumn dc = new DataColumn();
                dc.Caption = "���";
                dc.ColumnName = "iID";
                dt.Columns.Add(dc);

                dc = new DataColumn();
                dc.Caption = "˵��";
                dc.ColumnName = "iText";
                dt.Columns.Add(dc);

                DataRow dr = dt.NewRow();
                dr["iID"] = "0";
                dr["iText"] = "����";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["iID"] = "1";
                dr["iText"] = "������";
                dt.Rows.Add(dr);

                LookUpEditSQLAdd.DataSource = dt;
            }
            catch (Exception ee)
            {
                MessageBox.Show("���ش���ʧ�ܣ�\n  " + ee.Message);
            }
        }

        private void GetlookUpEdibKey()
        {
            try
            {
                DataTable dt = new DataTable();
                DataColumn dc = new DataColumn();
                dc.Caption = "���";
                dc.ColumnName = "iID";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.Caption = "����";
                dc.ColumnName = "iText";
                dt.Columns.Add(dc);
                DataRow dr = dt.NewRow();
                dr["iID"] = true;
                dr["iText"] = "��";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["iID"] = false;
                dr["iText"] = "��";
                dt.Rows.Add(dr);

                LookUpEditbKey.DataSource = dt;
            }
            catch (Exception ee)
            {
                MessageBox.Show("���ش���ʧ�ܣ�\n  " + ee.Message);
            }
        }

        private void GetlookUpEditDataBase()
        {
            try
            {
                DataTable dt = new DataTable();
                DataColumn dc = new DataColumn();
                dc.Caption = "���";
                dc.ColumnName = "iID";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.Caption = "˵��";
                dc.ColumnName = "iText";
                dt.Columns.Add(dc);

                DataRow dr = dt.NewRow();
                dr["iID"] = "0";
                dr["iText"] = "������";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["iID"] = "1";
                dr["iText"] = "�������ͣ��޵�����";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["iID"] = "2";
                dr["iText"] = "�ַ����ͣ��е�����";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["iID"] = "3";
                dr["iText"] = "�������ͣ���ת��";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["iID"] = "9";
                dr["iText"] = "δȷ��";
                dt.Rows.Add(dr);

                LookUpEditDataType.DataSource = dt;
            }
            catch (Exception ee)
            {
                MessageBox.Show("���ش���ʧ�ܣ�\n  " + ee.Message);
            }
        }

        private void lookUpEditDataBase_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string sSQL = "Select Name FROM " + lookUpEditDataBase.Text.ToString().Trim() + "..SysObjects Where XType='U' orDER BY Name  ";
                DataTable dt = clsSQL.ExecQuery(sSQL);
                lookUpEditTable.Properties.DataSource = dt;

            }
            catch (Exception ee)
            {
                MessageBox.Show("���ش���ʧ�ܣ�\n  " + ee.Message);
            }
        }

        private void lookUpEditTable_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string sSQL = "select  t.COLUMN_Text,t.iID,a.*,a.DATA_Type as DATA_Type2,0 as bUsed ,2 as DataType,isnull(t.collation_add,0) as collation_add,case a.COLUMN_NAME when isnull(t.COLUMN_NAME,0) then 0 else 1 end  as newAdd,isnull(t.bKey ,0) as bKey " +
                                "from " + lookUpEditDataBase.EditValue.ToString().Trim() + ".INFORMATION_SCHEMA.COLUMNS a left join dbo._TableColInfo t on a.TABLE_CATALOG = t.TABLE_CATALOG and a.TABLE_NAME=t.TABLE_NAME and a.COLUMN_NAME = t.COLUMN_NAME " +
                                "where a.table_name = '" + lookUpEditTable.Text.Trim() + "' " +
                                "order by a.table_name,a.ordinal_position";
                DataTable dt = clsSQL.ExecQuery(sSQL);

               //sSQL = "exec   sp_pkeys     @table_name   = 'PersonInfo'"

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["DataType"] = GetDataType(dt.Rows[i]["DATA_Type"].ToString().Trim());
                }
                gridControl1.DataSource  = dt;

            }
            catch (Exception ee)
            {
                MessageBox.Show("���ش���ʧ�ܣ�\n  " + ee.Message);
            }
        }

        private int GetDataType(string sDataType)
        {
            int i=0;
            switch (sDataType.ToLower().Trim())
            {
                //cursor,binary ,varbinary ,image 

                case "timestamp":
                    i = 0;
                    break;

                case "int":
                case "smallint":
                case "tinyint":
                case "numeric":
                case "decimal":
                case "money":
                case "smallmoney":
                case "float":
                case "real":
                    i = 1;
                    break;

                case "varchar":
                case "nvarchar":
                case "datetime":
                case "smalldatetime":
                case "uniqueidentifier":
                case "char":
                case "text":
                case "nchar":
                case "ntext":
                    i = 2;
                    break;

                case "bit":
                    i = 3;
                    break;
                default:
                    i = 9;
                    break;
            }
            return i;
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                if (e.RowHandle >= 0)
                {
                    if (gridView1.GetRowCellValue(e.RowHandle, gridColDataType).ToString().Trim() == "9")
                    {
                        e.Appearance.BackColor = Color.Tomato;
                    }
                }
            }
            catch
            { }
        }
    }
}