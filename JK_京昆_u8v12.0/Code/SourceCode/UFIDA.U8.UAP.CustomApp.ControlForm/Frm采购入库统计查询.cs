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
    public partial class Frm�ɹ����ͳ�Ʋ�ѯ : UserControl
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

        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }

        public Frm�ɹ����ͳ�Ʋ�ѯ()
        {
            InitializeComponent();
        }


        private void Frm�ɹ����ͳ�Ʋ�ѯ_Load(object sender, EventArgs e)
        {
            try
            {
                Clsʱ���� cls = new Clsʱ����();
                string sSQL = "";
                DataTable dt;
                DataRow dr;
                if (cls.bchkʱ����(Conn) == false)
                {
                    throw new Exception("��������ʧ��");
                }
                LookUp.Inventory(Conn, lookUpEdit�������1);
                LookUp.Inventory(Conn, lookUpEdit�������2);
                LookUp.Vendor(Conn, lookUpEdit��Ӧ������);
                LookUp.Person(Conn, lookUpEdit�ɹ�Ա����);
                LookUp.Department(Conn, lookUpEdit����);
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

                //MyTreeListBand Band3 = myTreeList1.Bands.Add(i, 1, "ͳ������");
                //Band3.SetColumn(0, myTreeList1.Columns["ͳ�������������"], "�������", false, DevExpress.Utils.HorzAlignment.Far);
                //i = i + 1;

                MyTreeListBand Band4 = myTreeList1.Bands.Add(i, 3, "����");
                Band4.SetColumn(0, myTreeList1.Columns["���¼۸�"], false, DevExpress.Utils.HorzAlignment.Far);
                Band4.SetColumn(1, myTreeList1.Columns["�¶Ⱦ���"], false, DevExpress.Utils.HorzAlignment.Far);
                Band4.SetColumn(2, myTreeList1.Columns["��Ⱦ���"], false, DevExpress.Utils.HorzAlignment.Far);
                i = i + 3;

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
select d.cDepName as ����,cdefine10 as �ɹ�Ա,dis.cDCName as ����,v.cVenAbbName as ��Ӧ��,i.cInvName,i.cInvStd,a.cDepCode,a.cPersonCode,a.cVenCode,i.cInvCode
    ,convert(decimal(18, 3),sum(case when datepart(MM,a.dDate)=1 then b.iquantity end))  as iQty1,convert(decimal(18, 2),sum(case when datepart(MM,a.dDate)=1 then b.iSum end))  as iSum1
    ,convert(decimal(18, 3),sum(case when datepart(MM,a.dDate)=2 then b.iquantity end))  as iQty2,convert(decimal(18, 2),sum(case when datepart(MM,a.dDate)=2 then b.iSum end))  as iSum2
    ,convert(decimal(18, 3),sum(case when datepart(MM,a.dDate)=3 then b.iquantity end))  as iQty3,convert(decimal(18, 2),sum(case when datepart(MM,a.dDate)=3 then b.iSum end))  as iSum3
    ,convert(decimal(18, 3),sum(case when datepart(MM,a.dDate)=4 then b.iquantity end))  as iQty4,convert(decimal(18, 2),sum(case when datepart(MM,a.dDate)=4 then b.iSum end))  as iSum4
    ,convert(decimal(18, 3),sum(case when datepart(MM,a.dDate)=5 then b.iquantity end))  as iQty5,convert(decimal(18, 2),sum(case when datepart(MM,a.dDate)=5 then b.iSum end))  as iSum5
    ,convert(decimal(18, 3),sum(case when datepart(MM,a.dDate)=6 then b.iquantity end))  as iQty6,convert(decimal(18, 2),sum(case when datepart(MM,a.dDate)=6 then b.iSum end))  as iSum6
    ,convert(decimal(18, 3),sum(case when datepart(MM,a.dDate)=7 then b.iquantity end))  as iQty7,convert(decimal(18, 2),sum(case when datepart(MM,a.dDate)=7 then b.iSum end))  as iSum7
    ,convert(decimal(18, 3),sum(case when datepart(MM,a.dDate)=8 then b.iquantity end))  as iQty8,convert(decimal(18, 2),sum(case when datepart(MM,a.dDate)=8 then b.iSum end))  as iSum8
    ,convert(decimal(18, 3),sum(case when datepart(MM,a.dDate)=9 then b.iquantity end))  as iQty9,convert(decimal(18, 2),sum(case when datepart(MM,a.dDate)=9 then b.iSum end))  as iSum9
    ,convert(decimal(18, 3),sum(case when datepart(MM,a.dDate)=10 then b.iquantity end))  as iQty10,convert(decimal(18, 2),sum(case when datepart(MM,a.dDate)=10 then b.iSum end))  as iSum10
    ,convert(decimal(18, 3),sum(case when datepart(MM,a.dDate)=11 then b.iquantity end))  as iQty11,convert(decimal(18, 2),sum(case when datepart(MM,a.dDate)=11 then b.iSum end))  as iSum11
    ,convert(decimal(18, 3),sum(case when datepart(MM,a.dDate)=12 then b.iquantity end))  as iQty12,convert(decimal(18, 2),sum(case when datepart(MM,a.dDate)=12 then b.iSum end))  as iSum12
    ,case when convert(decimal(18, 2),sum(iquantity))<>0 then convert(decimal(18, 2),sum(iSum)/sum(iquantity)) else 0 end as ��Ⱦ���
    ,convert(decimal(18, 2),sum(iSum)) as ��Ⱥϼ�
    ,convert(decimal(18, 3),sum(b.iquantity)) as ��Ⱥϼ�����
    ,convert(decimal(18, 3),sum(b.iquantity))  as ͳ�������������
    ,case when convert(decimal(18, 2),sum(case when datepart(MM,a.dDate)=111111 then iquantity else 0 end))<>0 then convert(decimal(18, 2),sum(case when datepart(MM,a.dDate)=111111 then iSum end)/sum(case when datepart(MM,a.dDate)=111111 then iquantity end)) else 0 end as �¶Ⱦ��� 
into #a
from RdRecord01 a inner join rdrecords01 b on a.ID = b.ID 
    left join Inventory i on b.cInvCode=i.cInvCode 
    left join Vendor v on a.cVenCode=v.cVenCode
    left join Person p on a.cPersonCode=p.cPersonCode 
    left join Department d on a.cDepCode=d.cDepCode 
    left join DistrictClass dis on v.cDCCode=dis.cDCCode
    left join Warehouse w on a.cWhCode=w.cWhCode where 1=1 
group by d.cDepName,cdefine10,dis.cDCName,v.cVenAbbName,i.cInvName,i.cInvStd,a.cDepCode,a.cPersonCode,a.cVenCode,i.cInvCode


select a.*,i.cInvName,i.cInvStd
,ic1.cInvCCode as cInvCCode1,ic1.cInvCName as cInvCName1,ic2.cInvCCode as cInvCCode2,ic2.cInvCName as cInvCName2,ic3.cInvCCode as cInvCCode3,ic3.cInvCName as cInvCName3
    ,(
        select top 1 convert(decimal(18, 2),iSum/b1.iquantity) 
        from RdRecord01 a1 inner join rdrecords01 b1 on a1.ID = b1.ID 
        where a1.cDepCode=a.cDepCode and a1.cVenCode=a.cVenCode and b1.cInvCode=a.cInvCode and a1.cPersonCode=a.cPersonCode order by a1.ID
    ) as ���¼۸�
from #a as a left join Inventory i on i.cInvCode = a.cInvCode  
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
                if (buttonEdit��Ӧ��.EditValue != null && buttonEdit��Ӧ��.EditValue.ToString() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and (v.cVenCode='" + buttonEdit��Ӧ��.EditValue.ToString().Trim() + "' or v.cVenName='" + buttonEdit��Ӧ��.EditValue.ToString().Trim() + "')");
                }
                if (buttonEdit�ɹ�Ա.EditValue != null && buttonEdit�ɹ�Ա.EditValue.ToString() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and (p.cPersonCode='" + buttonEdit�ɹ�Ա.EditValue.ToString().Trim() + "' or p.cPersonName='" + buttonEdit�ɹ�Ա.EditValue.ToString().Trim() + "')");
                }
                if (buttonEdit����.EditValue != null && buttonEdit����.EditValue.ToString() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and (d.cDepCode='" + buttonEdit����.EditValue.ToString().Trim() + "' or d.cDepName='" + buttonEdit����.EditValue.ToString().Trim() + "')");
                }
                if (buttonEdit�ֿ�.EditValue != null && buttonEdit�ֿ�.EditValue.ToString() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and (w.cWhCode='" + buttonEdit�ֿ�.EditValue.ToString().Trim() + "' or w.cWhName='" + buttonEdit�ֿ�.EditValue.ToString().Trim() + "')");
                }
                if (txt��.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and datepart(yyyy,a.dDate)='" + txt��.Text.Trim() + "'");
                }
                if (lookUpEditcDefine3.Text != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and b.cFree4='" + lookUpEditcDefine3.EditValue.ToString().Trim() + "'");
                }
                if (lookUpEditcPosition.Text != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and b.cPosition ='" + lookUpEditcPosition.EditValue.ToString().Trim() + "'");
                }
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
                dtBind.Columns.Add("���¼۸�", typeof(decimal));
                dtBind.Columns.Add("�¶Ⱦ���", typeof(decimal));
                dtBind.Columns.Add("��Ⱦ���", typeof(decimal));

                string[] sum = new string[] { "iQty1", "iQty2", "iQty3", "iQty4", "iQty5", "iQty6"
                    , "iQty7", "iQty8", "iQty9", "iQty10", "iQty11", "iQty12"
                        , "��Ⱥϼ�����", "ͳ�������������","���¼۸�","�¶Ⱦ���","��Ⱦ���" };
                string[] col = new string[] { "cInvCode", "cInvStd" };
                if (radioButton1.Checked)//����
                {
                    myTreeList1.Band(dt, dtBind
                        , new string[] { "����", "cInvCName1", "cInvCName2", "cInvCName3", "cInvName" }
                        , sum, col);
                }
                else if (radioButton2.Checked)//�ɹ�Ա
                {
                    myTreeList1.Band(dt, dtBind
                       , new string[] { "�ɹ�Ա", "cInvCName1", "cInvCName2", "cInvCName3", "cInvName" }
                       , sum, col);
                }
                else if (radioButton3.Checked)//���
                {
                    myTreeList1.Band(dt, dtBind
                       , new string[] { "cInvCName1", "cInvCName2", "cInvCName3", "cInvName" }
                       , sum, col);
                }
                else if (radioButton4.Checked)//��Ӧ��
                {
                    myTreeList1.Band(dt, dtBind
                       , new string[] { "��Ӧ��", "cInvCName1", "cInvCName2", "cInvCName3", "cInvName" }
                       , sum, col);
                }
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
                string cDepCode = "";
                string cPersonCode = ""; 
                string cVenName = "";
                
                if (radioButton1.Checked)
                {
                    cDepCode = myTreeList1.FocusedNode.ParentNode.ParentNode.ParentNode.ParentNode.GetValue("TreeList").ToString();
                }
                else if (radioButton2.Checked)
                {
                    cPersonCode = myTreeList1.FocusedNode.ParentNode.ParentNode.ParentNode.ParentNode.GetValue("TreeList").ToString();
                }
                else if (radioButton3.Checked)
                {
                }
                else if (radioButton4.Checked)
                {
                    cVenName = myTreeList1.FocusedNode.ParentNode.ParentNode.ParentNode.ParentNode.GetValue("TreeList").ToString();
                }

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
                    frm.�ɹ���ⵥ��ϸ(cDepCode, cPersonCode, cVenName, cInvCode, txt��.Text.Trim(), month);
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
        //private void grdDetail_DoubleClick(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        int iRow = gridView1.FocusedRowHandle;
        //        if (iRow < 0)
        //            return;

        //        string cDepCode=gridView1.GetRowCellValue(iRow, gridCol����).ToString().Trim();
        //        string cPersonCode=gridView1.GetRowCellValue(iRow, gridCol�ɹ�Ա).ToString().Trim();
        //        string cVenCode=gridView1.GetRowCellValue(iRow, gridCol��Ӧ��).ToString().Trim();
        //        string cInvCode = gridView1.GetRowCellValue(iRow, gridCol����).ToString().Trim();
        //        Frm��ϸ frm = new Frm��ϸ(Conn);
        //        string month = "";
        //        if (gridView1.FocusedColumn.Caption.IndexOf("һ��") >= 0)
        //        {
        //            month = "01";
        //        }
        //        else if (gridView1.FocusedColumn.Caption.IndexOf("����") >= 0)
        //        {
        //            month = "02";
        //        }
        //        else if (gridView1.FocusedColumn.Caption.IndexOf("����") >= 0)
        //        {
        //            month = "03";
        //        }
        //        else if (gridView1.FocusedColumn.Caption.IndexOf("����") >= 0)
        //        {
        //            month = "04";
        //        }
        //        else if (gridView1.FocusedColumn.Caption.IndexOf("����") >= 0)
        //        {
        //            month = "05";
        //        }
        //        else if (gridView1.FocusedColumn.Caption.IndexOf("����") >= 0)
        //        {
        //            month = "06";
        //        }
        //        else if (gridView1.FocusedColumn.Caption.IndexOf("����") >= 0)
        //        {
        //            month = "07";
        //        }
        //        else if (gridView1.FocusedColumn.Caption.IndexOf("����") >= 0)
        //        {
        //            month = "08";
        //        }
        //        else if (gridView1.FocusedColumn.Caption.IndexOf("����") >= 0)
        //        {
        //            month = "09";
        //        }
        //        else if (gridView1.FocusedColumn.Caption.IndexOf("ʮ��") >= 0)
        //        {
        //            month = "10";
        //        }
        //        else if (gridView1.FocusedColumn.Caption.IndexOf("ʮһ��") >= 0)
        //        {
        //            month = "11";
        //        }
        //        else if (gridView1.FocusedColumn.Caption.IndexOf("ʮ����") >= 0)
        //        {
        //            month = "12";
        //        }

        //        frm.�ɹ���ⵥ��ϸ(cDepCode, cPersonCode, cVenCode, cInvCode, txt��.Text.Trim(), month);
        //        frm.Show();
        //        if (DialogResult.OK == frm.ShowDialog())
        //        {
        //            frm.Enabled = true;
        //        }
        //    }
        //    catch (Exception ee)
        //    { }
        //}

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

        private void buttonEdit��Ӧ��_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                FrmVenInfo frm = new FrmVenInfo(buttonEdit��Ӧ��.Text.ToString(), Conn, true);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    buttonEdit��Ӧ��.EditValue = frm.cVenCode;

                    frm.Enabled = true;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit�ɹ�Ա_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                FrmPerson frm = new FrmPerson(buttonEdit�ɹ�Ա.Text.ToString(), Conn, true);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    buttonEdit�ɹ�Ա.EditValue = frm.sPerCode;

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

        private void buttonEdit��Ӧ��_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (buttonEdit��Ӧ��.Text.Trim() != "")
                {
                    lookUpEdit��Ӧ������.EditValue = buttonEdit��Ӧ��.Text.Trim();
                }
                else
                {
                    lookUpEdit��Ӧ������.EditValue = null;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit��Ӧ��_Leave(object sender, EventArgs e)
        {
            try
            {
                if (buttonEdit��Ӧ��.Text.Trim() == "")
                    return;
                if (lookUpEdit��Ӧ������.Text.Trim() == "")
                {
                    buttonEdit��Ӧ��.Text = "";
                    buttonEdit��Ӧ��.Focus();
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit�ɹ�Ա_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (buttonEdit�ɹ�Ա.Text.Trim() != "")
                {
                    lookUpEdit�ɹ�Ա����.EditValue = buttonEdit�ɹ�Ա.Text.Trim();
                }
                else
                {
                    lookUpEdit�ɹ�Ա����.EditValue = null;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit�ɹ�Ա_Leave(object sender, EventArgs e)
        {
            try
            {
                if (buttonEdit�ɹ�Ա.Text.Trim() == "")
                    return;
                if (lookUpEdit�ɹ�Ա����.Text.Trim() == "")
                {
                    buttonEdit�ɹ�Ա.Text = "";
                    buttonEdit�ɹ�Ա.Focus();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit����_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                FrmDepartment frm = new FrmDepartment(buttonEdit����.Text.ToString(), Conn, true);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    buttonEdit����.EditValue = frm.sPerCode;

                    frm.Enabled = true;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit����_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (buttonEdit����.Text.Trim() != "")
                {
                    lookUpEdit����.EditValue = buttonEdit����.Text.Trim();
                }
                else
                {
                    lookUpEdit����.EditValue = null;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit����_Leave(object sender, EventArgs e)
        {
            try
            {
                if (buttonEdit����.Text.Trim() == "")
                    return;
                if (lookUpEdit����.Text.Trim() == "")
                {
                    buttonEdit����.Text = "";
                    buttonEdit����.Focus();
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

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh_Click(null, null);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh_Click(null, null);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh_Click(null, null);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh_Click(null, null);
        }



    }
}