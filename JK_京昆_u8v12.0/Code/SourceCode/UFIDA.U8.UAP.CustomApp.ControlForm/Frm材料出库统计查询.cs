using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MyXtraTreeList;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class Frm���ϳ���ͳ�Ʋ�ѯ : UserControl
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
        int id;

        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }

        public Frm���ϳ���ͳ�Ʋ�ѯ()
        {
            InitializeComponent();
        }


        private void Frm���ϳ���ͳ�Ʋ�ѯ_Load(object sender, EventArgs e)
        {
            try
            {
                string sSQL = "";
                DataTable dt;
                DataRow dr;
                Clsʱ���� cls = new Clsʱ����();
                if (cls.bchkʱ����(Conn) == false)
                {
                    throw new Exception("��������ʧ��");
                }

                LookUp.Inventory(Conn, lookUpEdit�������1);
                LookUp.Inventory(Conn, lookUpEdit�������2);
                LookUp.Warehouse(Conn, lookUpEdit�ֿ�);

                sSQL = @"select cValue from UserDefine where cID=29  ORDER BY cAlias";
                dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                dr = dt.NewRow();
                dt.Rows.InsertAt(dr, 0);
                lookUpEditcDefine3.Properties.DataSource = dt;

                sSQL = @"select cPosCode,cPosName from Position ";
                dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                dr = dt.NewRow();
                dt.Rows.InsertAt(dr, 0);
                lookUpEditcPosition.Properties.DataSource = dt;

                sSQL = "select datepart(yyyy,getdate())";
                txt��.EditValue = SqlHelper.ExecuteScalar(Conn, CommandType.Text, sSQL);
                btnRefresh_Click(null, null);

                myTreeList1.SetBandsWidth(50);
                int i = 0;
                MyTreeListBand Band1 = myTreeList1.Bands.Add(i, 2, "����Ʒ��");
                Band1.SetColumn(0, myTreeList1.Columns["TreeList"], "����", false, DevExpress.Utils.HorzAlignment.Default);
                Band1.SetColumn(1, myTreeList1.Columns["cInvStd"], "����ͺ�", false, DevExpress.Utils.HorzAlignment.Default);
                //Band1.SetColumn(2, myTreeList1.Columns["cInvCode"], "����", false, DevExpress.Utils.HorzAlignment.Default);
                i = i + 2;

                MyTreeListBand Band3 = myTreeList1.Bands.Add(i, 1, "ͳ������");
                Band3.SetColumn(0, myTreeList1.Columns["ͳ�������������"], "��������", false, DevExpress.Utils.HorzAlignment.Far);
                i = i + 1;

                MyTreeListBand Band6 = myTreeList1.Bands.Add(i, 13, "���ͳ��");
                Band6.SetColumn(0, myTreeList1.Columns["��Ⱥϼ�����"], "��Ⱥϼ�", false, DevExpress.Utils.HorzAlignment.Far);
                Band6.SetColumn(1, myTreeList1.Columns["iQty1"], "һ��", false, DevExpress.Utils.HorzAlignment.Far);
                Band6.SetColumn(2, myTreeList1.Columns["iQty2"], "����", false, DevExpress.Utils.HorzAlignment.Far);
                Band6.SetColumn(3, myTreeList1.Columns["iQty3"], "����", false, DevExpress.Utils.HorzAlignment.Far);
                Band6.SetColumn(4, myTreeList1.Columns["iQty4"], "����", false, DevExpress.Utils.HorzAlignment.Far);
                Band6.SetColumn(5, myTreeList1.Columns["iQty5"], "����", false, DevExpress.Utils.HorzAlignment.Far);
                Band6.SetColumn(6, myTreeList1.Columns["iQty6"], "����", false, DevExpress.Utils.HorzAlignment.Far);
                Band6.SetColumn(7, myTreeList1.Columns["iQty7"], "����", false, DevExpress.Utils.HorzAlignment.Far);
                Band6.SetColumn(8, myTreeList1.Columns["iQty8"], "����", false, DevExpress.Utils.HorzAlignment.Far);
                Band6.SetColumn(9, myTreeList1.Columns["iQty9"], "����", false, DevExpress.Utils.HorzAlignment.Far);
                Band6.SetColumn(10, myTreeList1.Columns["iQty10"], "ʮ��", false, DevExpress.Utils.HorzAlignment.Far);
                Band6.SetColumn(11, myTreeList1.Columns["iQty11"], "ʮһ��", false, DevExpress.Utils.HorzAlignment.Far);
                Band6.SetColumn(12, myTreeList1.Columns["iQty12"], "ʮ����", false, DevExpress.Utils.HorzAlignment.Far);
                i = i + 13;
                MyTreeListBand Band10 = myTreeList1.Bands.Add(i, 1, "�������");
                Band10.SetColumn(0, myTreeList1.Columns["cInvCode"], "����", false, DevExpress.Utils.HorzAlignment.Default);
                i = i + 1;

                myTreeList1.ExpandAll();
                myTreeList1.ViewInfo.RC.NeedsRestore = true;
                myTreeList1.BestFitColumns();
                myTreeList1.LayoutChanged();

                
                myTreeList1.Columns["iQty1"].Width = 70;
                myTreeList1.Columns["iQty2"].Width = 70;
                myTreeList1.Columns["iQty3"].Width = 70;
                myTreeList1.Columns["iQty4"].Width = 70;
                myTreeList1.Columns["iQty5"].Width = 70;
                myTreeList1.Columns["iQty6"].Width = 70;
                myTreeList1.Columns["iQty7"].Width = 70;
                myTreeList1.Columns["iQty8"].Width = 70;
                myTreeList1.Columns["iQty9"].Width = 70;
                myTreeList1.Columns["iQty10"].Width = 70;
                myTreeList1.Columns["iQty11"].Width = 70;
                myTreeList1.Columns["iQty12"].Width = 70;

                myTreeList1.Columns["TreeList"].Width = 200;
            }
            catch (Exception ee)
            {
                MessageBox.Show("��������ʧ��");
            }
        }

        /// <summary>
        /// ˼·��
        /// 1. ��������ִ���
        /// 2. ������������չ�����ϵ��շ���Ϣ������ʹ�������ڼ�Ȩƽ������*����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                Clsʱ���� cls = new Clsʱ����();
                if (cls.bchkʱ����(Conn) == false)
                {
                    throw new Exception("��������ʧ��");
                }
                if (txt��.Text.Trim() == "")
                {
                    throw new Exception("��Ȳ���Ϊ��");
                }
                string sSQL = @"
select d.cDepName as ����,i.cInvName,i.cInvStd as ����ͺ�,a.cDepCode,a.cPersonCode,a.cCusCode,i.cInvCode
,convert(decimal(18, 3),sum(case when datepart(MM,a.dDate)=1 then b.iquantity end))  as iQty1,convert(decimal(18, 2),sum(case when datepart(MM,a.dDate)=1 then b.iPrice end))  as iMoney1
,convert(decimal(18, 3),sum(case when datepart(MM,a.dDate)=2 then b.iquantity end))  as iQty2,convert(decimal(18, 2),sum(case when datepart(MM,a.dDate)=2 then b.iPrice end))  as iMoney2
,convert(decimal(18, 3),sum(case when datepart(MM,a.dDate)=3 then b.iquantity end))  as iQty3,convert(decimal(18, 2),sum(case when datepart(MM,a.dDate)=3 then b.iPrice end))  as iMoney3
,convert(decimal(18, 3),sum(case when datepart(MM,a.dDate)=4 then b.iquantity end))  as iQty4,convert(decimal(18, 2),sum(case when datepart(MM,a.dDate)=4 then b.iPrice end))  as iMoney4
,convert(decimal(18, 3),sum(case when datepart(MM,a.dDate)=5 then b.iquantity end))  as iQty5,convert(decimal(18, 2),sum(case when datepart(MM,a.dDate)=5 then b.iPrice end))  as iMoney5
,convert(decimal(18, 3),sum(case when datepart(MM,a.dDate)=6 then b.iquantity end))  as iQty6,convert(decimal(18, 2),sum(case when datepart(MM,a.dDate)=6 then b.iPrice end))  as iMoney6
,convert(decimal(18, 3),sum(case when datepart(MM,a.dDate)=7 then b.iquantity end))  as iQty7,convert(decimal(18, 2),sum(case when datepart(MM,a.dDate)=7 then b.iPrice end))  as iMoney7
,convert(decimal(18, 3),sum(case when datepart(MM,a.dDate)=8 then b.iquantity end))  as iQty8,convert(decimal(18, 2),sum(case when datepart(MM,a.dDate)=8 then b.iPrice end))  as iMoney8
,convert(decimal(18, 3),sum(case when datepart(MM,a.dDate)=9 then b.iquantity end))  as iQty9,convert(decimal(18, 2),sum(case when datepart(MM,a.dDate)=9 then b.iPrice end))  as iMoney9
,convert(decimal(18, 3),sum(case when datepart(MM,a.dDate)=10 then b.iquantity end))  as iQty10,convert(decimal(18, 2),sum(case when datepart(MM,a.dDate)=10 then b.iPrice end))  as iMoney10
,convert(decimal(18, 3),sum(case when datepart(MM,a.dDate)=11 then b.iquantity end))  as iQty11,convert(decimal(18, 2),sum(case when datepart(MM,a.dDate)=11 then b.iPrice end))  as iMoney11
,convert(decimal(18, 3),sum(case when datepart(MM,a.dDate)=12 then b.iquantity end))  as iQty12,convert(decimal(18, 2),sum(case when datepart(MM,a.dDate)=12 then b.iPrice end))  as iMoney12
,case when convert(decimal(18, 2),sum(iquantity))<>0 then convert(decimal(18, 2),sum(iPrice)/sum(iquantity)) else 0 end as ��Ⱦ���
,convert(decimal(18, 2),sum(iPrice)) as ��Ⱥϼ�
,convert(decimal(18, 3),sum(b.iquantity)) as ��Ⱥϼ�����
,convert(decimal(18, 3),sum(b.iquantity))  as ͳ�������������
,case when convert(decimal(18, 2),sum(case when datepart(MM,a.dDate)=111111 then iquantity else 0 end))<>0 then convert(decimal(18, 2),sum(case when datepart(MM,a.dDate)=111111 then b.iPrice end)/sum(case when datepart(MM,a.dDate)=111111 then iquantity end)) else 0 end as �¶Ⱦ���
into #a 
from RdRecord11 a inner join rdrecords11 b on a.ID = b.ID left join Inventory i on b.cInvCode=i.cInvCode left join Customer c on a.cCusCode=c.cCusCode
left join Person p on a.cPersonCode=p.cPersonCode left join Department d on a.cDepCode=d.cDepCode left join DistrictClass dis on c.cDCCode=dis.cDCCode 
left join Warehouse w on a.cWhCode=w.cWhCode where 1=1 
group by d.cDepName,i.cInvName,i.cInvStd,a.cDepCode,a.cPersonCode,a.cCusCode,i.cInvCode

select a.*,i.cInvName,i.cInvStd
,ic1.cInvCCode as cInvCCode1,ic1.cInvCName as cInvCName1,ic2.cInvCCode as cInvCCode2,ic2.cInvCName as cInvCName2,ic3.cInvCCode as cInvCCode3,ic3.cInvCName as cInvCName3
from #a as a 
    left join Inventory i on i.cInvCode = a.cInvCode  
    left join InventoryClass ic1 on ic1.cInvCCode = left(i.cInvCCode,2)
	left join InventoryClass ic2 on ic2.cInvCCode = left(i.cInvCCode,4)
	left join InventoryClass ic3 on ic3.cInvCCode = left(i.cInvCCode,6)
";
                if (rdo���.Checked == true)
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(a.cHandler,'')<>''");
                }
                else
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(a.cHandler,'')=''");
                }
                if (buttonEdit�������1.EditValue != null && buttonEdit�������1.EditValue.ToString() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and b.cInvCode>='" + buttonEdit�������1.EditValue.ToString().Trim() + "'");
                }
                if (buttonEdit�������2.EditValue != null && buttonEdit�������2.EditValue.ToString() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and b.cInvCode<='" + buttonEdit�������2.EditValue.ToString().Trim() + "'");
                }
                if (txt��.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and datepart(yyyy,a.dDate)='" + txt��.Text.Trim() + "'");
                }
                if (buttonEdit�ֿ�.EditValue != null && buttonEdit�ֿ�.EditValue.ToString() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and (w.cWhCode='" + buttonEdit�ֿ�.EditValue.ToString().Trim() + "' or w.cWhName='" + buttonEdit�ֿ�.EditValue.ToString().Trim() + "')");
                }
                if (lookUpEditcDefine3.Text != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and b.cFree4='" + lookUpEditcDefine3.EditValue.ToString().Trim() + "'");
                }
                if (lookUpEditcPosition.Text != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and b.cPosition ='" + lookUpEditcPosition.EditValue.ToString().Trim() + "'");
                }
                sSQL = sSQL.Replace("1=1", "1=1 and datepart(yyyy,a.dDate)='" + txt��.Text.Trim() + "'");
                sSQL = sSQL.Replace("111111", DateTime.Now.Month.ToString());
                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];

                DataTable dtBind = new DataTable();
                dtBind.Columns.Add("ID");
                dtBind.Columns.Add("ParentID");
                dtBind.Columns.Add("TreeList");
                dtBind.Columns.Add("cInvStd");
                dtBind.Columns.Add("cInvCode");
                dtBind.Columns.Add("ͳ�������������", typeof(decimal));
                dtBind.Columns.Add("iQty1", typeof(decimal));
                dtBind.Columns.Add("iQty2", typeof(decimal));
                dtBind.Columns.Add("iQty3", typeof(decimal));
                dtBind.Columns.Add("iQty4", typeof(decimal));
                dtBind.Columns.Add("iQty5", typeof(decimal));
                dtBind.Columns.Add("iQty6", typeof(decimal));
                dtBind.Columns.Add("iQty7", typeof(decimal));
                dtBind.Columns.Add("iQty8", typeof(decimal));
                dtBind.Columns.Add("iQty9", typeof(decimal));
                dtBind.Columns.Add("iQty10", typeof(decimal));
                dtBind.Columns.Add("iQty11", typeof(decimal));
                dtBind.Columns.Add("iQty12", typeof(decimal));
                dtBind.Columns.Add("��Ⱥϼ�����", typeof(decimal));
                string[] sum = new string[] { "iQty1", "iQty2", "iQty3", "iQty4", "iQty5", "iQty6"
                    , "iQty7", "iQty8", "iQty9", "iQty10", "iQty11", "iQty12"
                        , "��Ⱥϼ�����", "ͳ�������������"};
                string[] col = new string[] { "cInvCode", "cInvStd" };
                myTreeList1.Band(dt, dtBind
                       , new string[] { "cInvCName1", "cInvCName2", "cInvCName3", "cInvName" }
                       , sum, col);
                myTreeList1.ExpandAll();
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
                myTreeList1.PostEditor();
                this.Validate();

                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "xls";
                sF.FileName = this.Text;
                sF.Filter = "Excel�ļ�(*.xls)|*.xls|�����ļ�(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK == dRes)
                {
                    myTreeList1.ExportToXls(sF.FileName);
                    MessageBox.Show("����Excel�ɹ�\n\t·����" + sF.FileName);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("�����б�ʧ�ܣ�" + ee.Message);
            }
        }

        private void myTreeList1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DevExpress.XtraTreeList.Nodes.TreeListNode node = myTreeList1.FocusedNode;
                if (node == null)
                    return;
                if (node.HasChildren == true)
                    return;
                string Caption = myTreeList1.FocusedColumn.Caption;
                string cInvCode = myTreeList1.FocusedNode.GetValue("cInvCode").ToString();

                //if (Caption == "һ��" || Caption == "����" || Caption == "����" || Caption == "����" || Caption == "����" || Caption == "����"
                //    || Caption == "����" || Caption == "����" || Caption == "����" || Caption == "ʮ��" || Caption == "ʮһ��" || Caption == "ʮ����")
                //{
                    Frm��ϸ frm = new Frm��ϸ(Conn);

                    string month = "";
                    if (Caption.IndexOf("һ��") >= 0)
                    {
                        month = "01";
                    }
                    else if (Caption.IndexOf("����") >= 0)
                    {
                        month = "02";
                    }
                    else if (Caption.IndexOf("����") >= 0)
                    {
                        month = "03";
                    }
                    else if (Caption.IndexOf("����") >= 0)
                    {
                        month = "04";
                    }
                    else if (Caption.IndexOf("����") >= 0)
                    {
                        month = "05";
                    }
                    else if (Caption.IndexOf("����") >= 0)
                    {
                        month = "06";
                    }
                    else if (Caption.IndexOf("����") >= 0)
                    {
                        month = "07";
                    }
                    else if (Caption.IndexOf("����") >= 0)
                    {
                        month = "08";
                    }
                    else if (Caption.IndexOf("����") >= 0)
                    {
                        month = "09";
                    }
                    else if (Caption.IndexOf("ʮ��") >= 0)
                    {
                        month = "10";
                    }
                    else if (Caption.IndexOf("ʮһ��") >= 0)
                    {
                        month = "11";
                    }
                    else if (Caption.IndexOf("ʮ����") >= 0)
                    {
                        month = "12";
                    }
                    frm.���ϳ�����ϸ(
                          ""
                        , cInvCode
                        , txt��.Text.Trim(), month);
                    frm.Show();
                    if (DialogResult.OK == frm.ShowDialog())
                    {
                        frm.Enabled = true;
                    }
                //}
            }
            catch (Exception ee)
            { }
        }

        private void buttonEdit�������1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                FrmInvInfo frm = new FrmInvInfo(buttonEdit�������1.Text.ToString(), Conn, true);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    buttonEdit�������1.EditValue = frm.sInvCode;

                    frm.Enabled = true;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit�������2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                FrmInvInfo frm = new FrmInvInfo(buttonEdit�������2.Text.ToString(), Conn, true);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    buttonEdit�������2.EditValue = frm.sInvCode;

                    frm.Enabled = true;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

     
        private void buttonEdit�������1_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (buttonEdit�������1.Text.Trim() != "")
                {
                    lookUpEdit�������1.EditValue = buttonEdit�������1.Text.Trim();
                }
                else
                {
                    lookUpEdit�������1.EditValue = null;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit�������1_Leave(object sender, EventArgs e)
        {
            try
            {
                if (buttonEdit�������1.Text.Trim() == "")
                    return;
                if (lookUpEdit�������1.Text.Trim() == "")
                {
                    buttonEdit�������1.Text = "";
                    buttonEdit�������1.Focus();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit�������2_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (buttonEdit�������2.Text.Trim() != "")
                {
                    lookUpEdit�������2.EditValue = buttonEdit�������2.Text.Trim();
                }
                else
                {
                    lookUpEdit�������2.EditValue = null;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit�������2_Leave(object sender, EventArgs e)
        {
            try
            {
                if (buttonEdit�������2.Text.Trim() == "")
                    return;
                if (lookUpEdit�������2.Text.Trim() == "")
                {
                    buttonEdit�������2.Text = "";
                    buttonEdit�������2.Focus();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit�ֿ�_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                FrmWarehouse frm = new FrmWarehouse(buttonEdit�ֿ�.Text.ToString(), Conn, true);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    buttonEdit�ֿ�.EditValue = frm.sPerCode;

                    frm.Enabled = true;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit�ֿ�_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (buttonEdit�ֿ�.Text.Trim() != "")
                {
                    lookUpEdit�ֿ�.EditValue = buttonEdit�ֿ�.Text.Trim();
                }
                else
                {
                    lookUpEdit�ֿ�.EditValue = null;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit�ֿ�_Leave(object sender, EventArgs e)
        {
            try
            {
                if (buttonEdit�ֿ�.Text.Trim() == "")
                    return;
                if (lookUpEdit�ֿ�.Text.Trim() == "")
                {
                    buttonEdit�ֿ�.Text = "";
                    buttonEdit�ֿ�.Focus();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

    }
}