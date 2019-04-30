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
using System.IO.Ports;
using System.Threading;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class ��Ʒ�ִ�����ǩ��ӡ : UserControl
    {

        string sState = "";

        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }

        public ��Ʒ�ִ�����ǩ��ӡ()
        {
            InitializeComponent();

            sPrintLayOutMod = sProPath + "\\UAP\\Runtime\\print\\Model\\��Ʒ��ǩ��ӡMod.dll";
            sPrintLayOutUser = sProPath + "\\UAP\\Runtime\\print\\User\\��Ʒ��ǩ��ӡUser.dll";
        }


        private void ProjectManager_Load(object sender, EventArgs e)
        {
            try
            {
                if (sUserID == "admin" || sUserID == "system" || sUserID == "demo")
                {
                    btnPrintSET.Visible = true;
                }
                else
                {
                    btnPrintSET.Visible = false;
                }

                SetLookup();
            }
            catch (Exception ee)
            {
                MessageBox.Show("��������ʧ��");
            }
        }

        private void SetLookup()
        {
            try
            {
                string sSQL = @"
select distinct a.MoCode
from mom_order a inner join mom_orderdetail b on a.moid = b.moid
where b.Status = 3
order by a.MoCode
";
                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                DataRow dr = dt.NewRow();
                dt.Rows.InsertAt(dr, 0);

                lookUpEdit����������1.Properties.DataSource = dt;
            }
            catch (Exception ee)
            {
                MessageBox.Show("�������������ʧ��");
            }
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
               
                string sSQL = @"
select cast(1 as bit) as ѡ�� 
    ,rd.mocode ����������,rd.SortSeq as �к�
	,Curr.cInvCode as �������,Inv.cInvName as �������,Inv.cInvStd as ����ͺ�
	,Curr.cBatch as ����,rd.cBatchProperty6 as ¯��,Curr.cFree1 as ����
	,rd.���� as ë��,Curr.iQuantity as ����,Curr.iNum as ����
	,case when isnull(a.������,0) <> 0 then a.������ else null end as ������
from CurrentStock Curr
	left join (
		select rds.cInvCode,rds.cBatch ,mo.MOCode,mos.SortSeq ,mos.define25 as ����,cBatchProperty6
		from rdrecord10 rd inner join Rdrecords10 rds on rd.id = rds.id
			inner join mom_orderdetail mos on mos.modid = rds.iMPoIds 
			inner join mom_order mo on mo.moid = mos.moid
		) Rd on rd.cInvCode = curr.cInvCode and rd.cBatch = Curr.cBatch
	left join [��������Ϣ] a on a.���������� = rd.MOCode and a.�к� = rd.sortseq and Curr.cBatch = a.����
	inner join Inventory Inv on Inv.cInvCode = Curr.cInvCode
where curr.cWhCode = '04' and curr.iquantity > 0
    and 1=1
order by Curr.cInvCode
";
                if (lookUpEdit����������1.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and rd.mocode = '" + lookUpEdit����������1.Text.Trim() + "' ");
                }
                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                grdDetail.DataSource = dt;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
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

                string sSQL = "select getdate()";
                DateTime d��ǰ���� = Convert.ToDateTime(SqlHelper.ExecuteScalar(Conn, CommandType.Text, sSQL));
                string s���뵥�ݺ� = d��ǰ����.ToString("yyyyMMddHHmmss");

                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                //��������
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
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
                    Rep.dsPrint.Tables.Clear();

                    string sGuid = Guid.NewGuid().ToString();

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (!Convert.ToBoolean(gridView1.GetRowCellValue(i, gridColѡ��)))
                            continue;

                        sSQL = "select * from ��������Ϣ where ������� = '"+ gridView1.GetRowCellValue(i,gridCol�������).ToString().Trim() + "' and ���� = '" + gridView1.GetRowCellValue(i, gridCol����).ToString().Trim() + "' and ���� = '" + gridView1.GetRowCellValue(i, gridCol����).ToString().Trim() + "' and ¯�� = '" + gridView1.GetRowCellValue(i, gridCol¯��).ToString().Trim() + "'";
                        DataTable dt = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt == null || dt.Rows.Count == 0)
                        {
                            string së�� = gridView1.GetRowCellValue(i, gridColë��).ToString().Trim();
                            int iKG = së��.IndexOf("KG");
                            së�� = së��.Substring(0, iKG);

                            sSQL = "INSERT INTO [��������Ϣ]([�������] ,[����],[����] ,[¯��] ,[����] ,[ë��]" +
                                              ",[������]  ,[��������],[��ӡ����],[����������],[�к�] " +
                                              " ,[���һ�δ�ӡ��]  ,[���һ�δ�ӡ����],���뵥�ݺ�,guid) " +
                                          " VALUES ('" + gridView1.GetRowCellValue(i, gridCol�������).ToString().Trim() + "','" + gridView1.GetRowCellValue(i, gridCol����).ToString().Trim() + "','" + gridView1.GetRowCellValue(i, gridCol����).ToString().Trim() + "','" + gridView1.GetRowCellValue(i, gridCol¯��).ToString().Trim() + "'," + gridView1.GetRowCellValue(i, gridCol����).ToString().Trim() + "," + së�� + "  " +
                                                ",'" + sUserID + "',getdate(),1,'" + gridView1.GetRowCellValue(i, gridCol����������).ToString().Trim().Trim() + "','" + gridView1.GetRowCellValue(i, gridCol�к�).ToString().Trim().Trim() + "' " +
                                                ",'" + sUserID + "',getdate(),'" + s���뵥�ݺ� + "','" + sGuid + "')";
                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                        else
                        {
                            sSQL = "update ��������Ϣ set ��ӡ���� = isnull(��ӡ����,0) + 1,���һ�δ�ӡ���� = getdate(),GUID = '" + sGuid + "' where ������� = '"+ gridView1.GetRowCellValue(i,gridCol�������).ToString().Trim() + "' and ���� = '" + gridView1.GetRowCellValue(i, gridCol����).ToString().Trim() + "' and ���� = '" + gridView1.GetRowCellValue(i, gridCol����).ToString().Trim() + "' and ¯�� = '" + gridView1.GetRowCellValue(i, gridCol¯��).ToString().Trim() + "'";
                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                    }


                    sSQL = @"
select right(cast('000000000'+rtrim(������) as varchar(20)),10) as ������, �������, ����, ����, ¯��, ����, ë��, ������, ��������, ��ӡ����, ���һ�δ�ӡ��
    ,���һ�δ�ӡ����, ���뵥�ݺ�, �޸���, �޸�����, �ر���, �ر�����, �ɹ�������, ����������, ���۶�����, �к�, GUID
    ,�ɹ���ⵥ��, �ɹ���ⵥ�к�, ����Ʒ��ⵥ��, ����Ʒ��ⵥ�к�
    ,b.cInvName,b.cInvStd
from ��������Ϣ a inner join Inventory b on a.������� = b.cInvCode 
where guid = '" + sGuid + "'";
                    DataTable dtHead = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    dtHead.TableName = "dtHead";
                    Rep.dsPrint.Tables.Add(dtHead.Copy());
                    Rep.ShowPreview();
                    //Rep.Print();

                    tran.Commit();
                }
                catch (Exception error)
                {
                    tran.Rollback();
                    throw new Exception(error.Message);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }



        #endregion

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    gridView1.SetRowCellValue(i, gridColѡ��, chkAll.Checked);
                }
            }
            catch (Exception ee)
            { }
        }
    }
}