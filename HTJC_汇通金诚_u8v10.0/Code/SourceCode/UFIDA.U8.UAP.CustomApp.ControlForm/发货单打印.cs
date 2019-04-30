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
    public partial class ��������ӡ : UserControl
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

        string sTitle = "��������ӡ";
        string sState = "";

        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }

        public ��������ӡ()
        {
            InitializeComponent();

            sPrintLayOutMod = sProPath + "\\UAP\\Runtime\\print\\Model\\" + sTitle + "Mod.dll";
            sPrintLayOutUser = sProPath + "\\UAP\\Runtime\\print\\User\\" + sTitle + "User.dll";
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSel_Click(object sender, EventArgs e)
        {
          
        }

        private int ReturnObjectToInt(object o)
        {
            int d = 0;
            try
            {
                d = Convert.ToInt32(o);
            }
            catch
            { }
            return d;
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

                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    if (!Convert.ToBoolean(dt.Rows[i]["ѡ��"]))
                    {
                        dt.Rows.RemoveAt(i);
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
                Rep.dsPrint.Tables.Add(dt);

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

        private void btn���_Click(object sender, EventArgs e)
        {
            SetLookup();

            lookUpEdit��������1.EditValue = DBNull.Value;
            lookUpEdit��������2.EditValue = DBNull.Value;
            dtm1.DateTime = DateTime.Today;
            dtm2.DateTime = DateTime.Today.AddDays(7);
        }

        private void SetLookup()
        {
            try
            {
                string sSQL = @"
select distinct cDLCode
from DispatchList 
where isnull(cVerifier ,'') = '' and isnull(cCloser ,'') = ''
order by cDLCode
";
                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                DataRow dr = dt.NewRow();
                dt.Rows.InsertAt(dr, 0);

                lookUpEdit��������1.Properties.DataSource = dt;
                lookUpEdit��������2.Properties.DataSource = dt;
            }
            catch (Exception ee)
            {
                MessageBox.Show("�������������ʧ��");
            }
        }

        private void btnSel_Click_1(object sender, EventArgs e)
        {
            try
            {
                string sSQL = @"
select distinct cast(0 as bit) as ѡ��, cDLCode,cCusCode,cCusName,b.cInvCode,c.cInvName,c.cInvStd
	,cast(b.iQuantity as decimal(16,2)) as iQuantity
from DispatchList a inner join DispatchLists b on a.DLID = b.DLID
	inner join Inventory c on b.cInvCode = c.cInvCode
where 1=1 
order by cDLCode
";
                if (lookUpEdit��������1.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.cDLCode >= '" + lookUpEdit��������1.Text.Trim() + "'");
                }
                if (lookUpEdit��������2.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.cDLCode <= '" + lookUpEdit��������2.Text.Trim() + "'");
                }
                if (dtm1.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.dDate >= '" + dtm1.DateTime.ToString("yyyy-MM-dd") + "'");
                }
                if (dtm2.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.dDate < '" + dtm1.DateTime.AddDays(1).ToString("yyyy-MM-dd") + "'");
                }

                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                grdDetail.DataSource = dt;
            }
            catch (Exception ee)
            {
                MessageBox.Show("������ɶ���ʧ��"); 
            }
        }

        private void �������ϴ�ӡ_Load(object sender, EventArgs e)
        {


            SetLookup();
        }

        private void chkȫѡ_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    gridView1.SetRowCellValue(i, gridColѡ��, chkȫѡ.Checked);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}