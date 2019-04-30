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
    public partial class �ɹ���ǩ��ӡ : UserControl
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

        public �ɹ���ǩ��ӡ()
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

            sSQL = "select  ccode  as �ɹ���ⵥ�� From zpurrkdlist a with(nolock)  group by ccode order by ccode";

            DataTable dts = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
            lookUpEdit�ɹ���ⵥ��1.Properties.DataSource = dts;
            lookUpEdit�ɹ���ⵥ��2.Properties.DataSource = dts;
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

                string sSQL = @"
select CAST(0 as bit) as ѡ��, ccode  as �ɹ���ⵥ��,cbatch as ����,cinvcode as �������,cinvname as �������,cInvStd as  ����ͺ�
    ,a.cInvCCode as ����������,c.cInvCName as �������,cbatchproperty6 ¯��,cfree1 as ����,cast(iquantity as decimal(18,2)) as ����,irowno as �ɹ���ⵥ�к�
    ,cast(d.������ as varchar(10)) as ������ ,case when d.guid is null then newid() else d.guid end as GUID
From zpurrkdlist a with(nolock)  inner join InventoryClass c on a.cInvCCode = c.cInvCCode 
left join ��������Ϣ d on a.ccode=d.�ɹ���ⵥ�� and a.irowno=d.�ɹ���ⵥ�к� 
Where  (cbustype=N'��ͨ�ɹ�' OR cbustype=N'���ܲɹ�')  and 1=1 
order by ccode
";

                string s����������� = "1=1";
                if (txt�������.Text.Trim() != "")
                {
                    if (cmb�������.Text.Trim() == "like")
                    {
                        s����������� = "1=1 and  (cInvCode like '%" + txt�������.Text.Trim() + "%' or cInvName like '%" + txt�������.Text.Trim() + "%' )";
                    }
                    else
                    {
                        s����������� = "1=1 and  (cInvCode " + cmb�������.Text.Trim() + " '" + txt�������.Text.Trim() + "' or cInvName " + cmb�������.Text.Trim() + " '" + txt�������.Text.Trim() + "' )";
                    }
                }
                sSQL = sSQL.Replace("1=1", s�����������);

                string s����������� = "1=1";
                if (txt�������.Text.Trim() != "")
                {
                    if (cmb�������.Text.Trim() == "like")
                    {
                        s����������� = "1=1 and  (a.cInvCCode like '%" + txt�������.Text.Trim() + "%' or c.cInvCName like '%" + txt�������.Text.Trim() + "%' )";
                    }
                    else
                    {
                        s����������� = "1=1 and  (a.cInvCCode " + cmb�������.Text.Trim() + " '" + txt�������.Text.Trim() + "' or c.cInvCName " + cmb�������.Text.Trim() + " '" + txt�������.Text.Trim() + "' )";
                    }
                }
                if (lookUpEdit�ɹ���ⵥ��1.EditValue!=null && lookUpEdit�ɹ���ⵥ��1.EditValue.ToString().Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", " 1=1 and ccode>='" + lookUpEdit�ɹ���ⵥ��1.EditValue.ToString().Trim() + "'");
                }

                if (lookUpEdit�ɹ���ⵥ��2.EditValue!=null &&lookUpEdit�ɹ���ⵥ��2.EditValue.ToString().Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", " 1=1 and ccode<='" + lookUpEdit�ɹ���ⵥ��2.EditValue.ToString().Trim() + "'");
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
            lookUpEdit�ɹ���ⵥ��1.EditValue = DBNull.Value;
            lookUpEdit�ɹ���ⵥ��2.EditValue = DBNull.Value;
            chkȫѡ.Checked = false;
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


                DataTable dt = ((DataTable)grdDetail.DataSource).Copy();


                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                //��������
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(dt.Rows[i]["ѡ��"]))
                        {
                            string sSQL = "if exists(select * from dbo.��������Ϣ where �ɹ���ⵥ�� = '" + dt.Rows[i]["�ɹ���ⵥ��"].ToString().Trim() + "' and �ɹ���ⵥ�к� = '" + dt.Rows[i]["�ɹ���ⵥ�к�"].ToString().Trim() + "' and ������� = '" + dt.Rows[i]["�������"].ToString().Trim() + "' )" +
                                                " update ��������Ϣ set ���һ�δ�ӡ�� = '" + sUserID + "' ,���һ�δ�ӡ���� = GETDATE(),��ӡ���� = ISNULL(��ӡ����,0) + 1 where �ɹ���ⵥ�� = '" + dt.Rows[i]["�ɹ���ⵥ��"].ToString().Trim() + "' and �ɹ���ⵥ�к� = '" + dt.Rows[i]["�ɹ���ⵥ�к�"].ToString().Trim() + "' and ������� = '" + dt.Rows[i]["�������"].ToString().Trim() + "' " +
                                           " else " +
                                               " insert into ��������Ϣ(���һ�δ�ӡ��,���һ�δ�ӡ����,������,��������,��ӡ����,�ɹ���ⵥ��,�ɹ���ⵥ�к�,�������,guid)values " +
                                               " ('" + sUserID + "',getdate(),'" + sUserID + "',GETDATE(),'1','" + dt.Rows[i]["�ɹ���ⵥ��"].ToString().Trim() + "','" + dt.Rows[i]["�ɹ���ⵥ�к�"].ToString().Trim() + "','" + dt.Rows[i]["�������"].ToString().Trim() + "','" + dt.Rows[i]["GUID"].ToString().Trim() + "')";
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


                for (int i = 0; i <gridView1.RowCount; i++)
                {
                    if (!Convert.ToBoolean(gridView1.GetRowCellValue(i, gridColѡ��)))
                        continue;

                    if (gridView1.GetRowCellValue(i, gridCol������).ToString().Trim()  == "")
                    {
                        string s = "select ������ from ��������Ϣ where guid = '" + gridView1.GetRowCellValue(i, gridColGUID).ToString().Trim() + "'";
                        object o = SqlHelper.ExecuteScalar(conn, CommandType.Text, s);
                        gridView1.SetRowCellValue(i, gridCol������, o);

                    }
                }

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
                Rep.dsPrint.Clear();
                Rep.dsPrint.Tables.Clear();


                dt = (DataTable)grdDetail.DataSource;
                DataColumn dc = dt.Columns["������"];
                
                for (int i = 0; i < dt.Rows.Count; i++)
                { 
                    if(!Convert.ToBoolean(dt.Rows[i]["ѡ��"]))
                        continue;

                    int iLeng = dt.Rows[i]["������"].ToString().Trim().Length;
                    for (int ii = iLeng; ii < 10; ii++)
                    {
                        dt.Rows[i]["������"] = "0" + dt.Rows[i]["������"].ToString().Trim();
                    }
                }
                DataView dv = dt.DefaultView;
                dv.RowFilter = " isnull(ѡ��,0) = 1 ";
                dt.TableName = "dtGrid";
                Rep.dsPrint.Tables.Add(dv.ToTable());

                Rep.DataMember = "dtGrid";
                Rep.ShowPreview();
                //Rep.Print();

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