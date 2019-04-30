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
    public partial class Frm��Ʒ����������ѯ : UserControl
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

        public Frm��Ʒ����������ѯ()
        {
            InitializeComponent();
        }

        private void TreeListColumn(DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1, string caption, string fieldname, int visilbeindex)
        {
            treeListColumn1.Caption = caption;
            treeListColumn1.FieldName = fieldname;
            treeListColumn1.Name = "treeListColumn" + (visilbeindex + 1);
            treeListColumn1.Visible = true;
            treeListColumn1.VisibleIndex = visilbeindex;
            treeListColumn1.OptionsColumn.AllowEdit = false;
        }

        private void Frm��Ʒ����������ѯ_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    string sSQL = "";
            //    DataTable dt;
            //    DataRow dr;
            //    Clsʱ���� cls = new Clsʱ����();
            //    if (cls.bchkʱ����(Conn) == false)
            //    {
            //        throw new Exception("��������ʧ��");
            //    }
            //    LookUp.Inventory(Conn, lookUpEdit�������1);
            //    LookUp.Inventory(Conn, lookUpEdit�������2);

            //    LookUp.Warehouse(Conn, lookUpEdit�ֿ�);

            //    lookUpEditcFree4.EditValue = "";
            //    lookUpEditcPosition.EditValue = "";
            //    lookUpEdit�ֿ�.EditValue = "";

            //    sSQL = @"select cValue from UserDefine where cID=29  ORDER BY cAlias";
            //    dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
            //    dr = dt.NewRow();
            //    dt.Rows.InsertAt(dr, 0);
            //    lookUpEditcFree4.Properties.DataSource = dt;

            //    sSQL = @"select cPosCode,cPosName from Position ";
            //    dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
            //    dr = dt.NewRow();
            //    dt.Rows.InsertAt(dr, 0);
            //    lookUpEditcPosition.Properties.DataSource = dt;

            //    sSQL = "select datepart(yyyy,getdate())";
            //    dateEdit1.EditValue = DateTime.Now.Year.ToString() + "-01-01";
            //    dateEdit2.EditValue = DateTime.Now.ToString("yyyy-MM-dd");

            //    btnRefresh_Click(null, null);

            //    myTreeList1.SetBandsWidth(50);

            //    DataTable dtck = SqlHelper.ExecuteDataset(Conn, CommandType.Text, @"select * from Warehouse where dWhEndDate is null ORDER BY cWhCode").Tables[0];
            //    DataTable dtproj = SqlHelper.ExecuteDataset(Conn, CommandType.Text, @"select cValue from UserDefine where cID=28  ORDER BY cAlias").Tables[0];
            //    DataTable dtqc = SqlHelper.ExecuteDataset(Conn, CommandType.Text, @"select * from _QC").Tables[0];

            //    int i = 0;
            //    MyTreeListBand Band1 = myTreeList1.Bands.Add(i, 1, "����Ʒ��");
            //    Band1.SetColumn(0, myTreeList1.Columns["TreeList"], "����", false, DevExpress.Utils.HorzAlignment.Default);
                
            //    i = i + 1;

            //    MyTreeListBand Band2 = myTreeList1.Bands.Add(i, 1, "");
            //    Band2.SetColumn(0, myTreeList1.Columns["cFree1"], "��װ", false, DevExpress.Utils.HorzAlignment.Default);
            //    i = i + 1;

            //    MyTreeListBand Band3 = myTreeList1.Bands.Add(i, 1, "");
            //    Band3.SetColumn(0, myTreeList1.Columns["iQuantity"],"����", false, DevExpress.Utils.HorzAlignment.Far);
            //    i = i + 1;

            //    MyTreeListBand Band9 = myTreeList1.Bands.Add(i, 3, "�������");
            //    Band9.SetColumn(0, myTreeList1.Columns["����"], false, DevExpress.Utils.HorzAlignment.Far);
            //    Band9.SetColumn(1, myTreeList1.Columns["�ϸ�"], false, DevExpress.Utils.HorzAlignment.Far);
            //    Band9.SetColumn(2, myTreeList1.Columns["���ϸ�"], false, DevExpress.Utils.HorzAlignment.Far);
            //    i = i + 3;

            //    MyTreeListBand Band5 = myTreeList1.Bands.Add(i, dtck.Rows.Count + dtproj.Rows.Count, "��ĩ��λ");
            //    Band5.CreateChild(0, dtck.Rows.Count, "ʵ���");
            //    Band5.CreateChild(dtck.Rows.Count, dtproj.Rows.Count, "�����");
            //    for (int j = 0; j < dtck.Rows.Count; j++)
            //    {
            //        Band5.SetColumn(j, myTreeList1.Columns["cWhCode_" + dtck.Rows[j]["cWhCode"].ToString()], dtck.Rows[j]["cWhName"].ToString(), false, DevExpress.Utils.HorzAlignment.Far);
            //    }
            //    for (int j = 0; j < dtproj.Rows.Count; j++)
            //    {
            //        Band5.SetColumn(j + dtck.Rows.Count, myTreeList1.Columns["Project_" + dtproj.Rows[j]["cValue"].ToString().Trim()], dtproj.Rows[j]["cValue"].ToString(), false, DevExpress.Utils.HorzAlignment.Far);
            //    }
            //    i = i + dtck.Rows.Count + dtproj.Rows.Count;

            //    MyTreeListBand Band6 = myTreeList1.Bands.Add(i, 3, "�������������ͳ��");
            //    Band6.SetColumn(0, myTreeList1.Columns["�ۼ����"], false, DevExpress.Utils.HorzAlignment.Far);
            //    Band6.SetColumn(1, myTreeList1.Columns["�ۼ�����"], false, DevExpress.Utils.HorzAlignment.Far);
            //    Band6.SetColumn(2, myTreeList1.Columns["�ۼ��˿�"], false, DevExpress.Utils.HorzAlignment.Far);
            //    i = i + 3;

            //    MyTreeListBand Band7 = myTreeList1.Bands.Add(i, 2, "����ɹ�ͳ��");
            //    Band7.SetColumn(0, myTreeList1.Columns["�ɹ����"], false, DevExpress.Utils.HorzAlignment.Far);
            //    Band7.SetColumn(1, myTreeList1.Columns["�˻�����"], false, DevExpress.Utils.HorzAlignment.Far);
            //    i = i + 2;

            //    MyTreeListBand Band8 = myTreeList1.Bands.Add(i, 2, "��������ͳ��");
            //    Band8.SetColumn(0, myTreeList1.Columns["�ۼ�����"], false, DevExpress.Utils.HorzAlignment.Far);
            //    Band8.SetColumn(1, myTreeList1.Columns["�ۼ��˻�"], false, DevExpress.Utils.HorzAlignment.Far);
            //    i = i + 2;

            //    MyTreeListBand Band10 = myTreeList1.Bands.Add(i, 1, "�������");
            //    Band10.SetColumn(0, myTreeList1.Columns["cInvCode"], "����", false, DevExpress.Utils.HorzAlignment.Default);
            //    i = i + 1;

            //    myTreeList1.ViewInfo.RC.NeedsRestore = true;
            //    myTreeList1.BestFitColumns();
            //    myTreeList1.LayoutChanged();
            //    myTreeList1.Columns["TreeList"].Width = 200;
                
            //}
            //catch (Exception ee)
            //{
            //    MessageBox.Show("��������ʧ��");
            //}
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetGrid();
        }

        private void GetGrid()
        {
            try
            {
                Clsʱ���� cls = new Clsʱ����();
                if (cls.bchkʱ����(Conn) == false)
                {
                    throw new Exception("��������ʧ��");
                }
                if (dateEdit1.Text.Trim() == "")
                {
                    throw new Exception("��ʼ���ڲ���Ϊ��");
                }
                if (dateEdit2.Text.Trim() == "")
                {
                    throw new Exception("�������ڲ���Ϊ��");
                }

                string �ֿ� = "";
                DataTable dtck = SqlHelper.ExecuteDataset(Conn, CommandType.Text, @"select * from Warehouse where dWhEndDate is null ORDER BY cWhCode").Tables[0];
                DataTable dtproj = SqlHelper.ExecuteDataset(Conn, CommandType.Text, @"select cValue from UserDefine where cID=28  ORDER BY cAlias").Tables[0];
                DataTable dtqc = SqlHelper.ExecuteDataset(Conn, CommandType.Text, @"select * from _QC").Tables[0];
                
//                string sSQL = @"
//2222222222
//
//select ic1.cInvCCode as cInvCCode1,ic1.cInvCName as cInvCName1,ic2.cInvCCode as cInvCCode2,ic2.cInvCName as cInvCName2,ic3.cInvCCode as cInvCCode3,ic3.cInvCName as cInvCName3,a.cInvCode,cInvName,isnull(a.cFree1,'') AS cFree1,cInvStd
//,sum(iQMJCSL) as iQuantity,sum(�ۼ����) as �ۼ����,sum(�ۼ�����) as �ۼ�����,sum(�ۼ��˿�) as �ۼ��˿�,sum(�ɹ����) as �ɹ����,sum(�˻�����) as �˻�����,sum(�ۼ�����) as �ۼ�����,sum(�ۼ��˻�) as �ۼ��˻�
//,convert(decimal(18, 3),null) as ����,convert(decimal(18, 3),null) as �ϸ�,convert(decimal(18, 3),null) as ���ϸ�
//1111111111
//from #temp1 a 
//    left join InventoryClass ic1 on ic1.cInvCCode = left(a.cInvCCode,2)
//	left join InventoryClass ic2 on ic2.cInvCCode = left(a.cInvCCode,4)
//	left join InventoryClass ic3 on ic3.cInvCCode = left(a.cInvCCode,6) 
//group by ic1.cInvCCode,ic1.cInvCName,ic2.cInvCCode,ic2.cInvCName,ic3.cInvCCode,ic3.cInvCName,a.cInvCode,cInvName,isnull(a.cFree1,''),cInvStd  having  sum(a.iQMJCSL)<>0 order by ic1.cInvCCode
//";
                
//                //�ֿ�
//                for (int i = 0; i < dtck.Rows.Count; i++)
//                {
//                    �ֿ� = �ֿ� + @"
//                    ,sum(case when cWhCode='" + dtck.Rows[i]["cWhCode"].ToString().Trim() + "' then convert(decimal(18, 3),iQMJCSL) end) as " + dtck.Rows[i]["cWhName"].ToString().Trim() + "";
//                }

//                //�����
//                for (int i = 0; i < dtproj.Rows.Count; i++)
//                {
//                    �ֿ� = �ֿ� + @"
//                    ,sum(case when cFree3='" + dtproj.Rows[i]["cValue"].ToString().Trim() + "' then convert(decimal(18, 3),iQMJCSL) end) as " + dtproj.Rows[i]["cValue"].ToString().Trim() + "";
//                }
//                //������ϸ
////                for (int i = 0; i < dtqc.Rows.Count; i++)
////                {
////                    �ֿ� = �ֿ� + @"
////                    ,convert(decimal(18, 3),null) as QCResult_1_" + dtqc.Rows[i]["QCCode"].ToString().Trim() 
////                      + ",convert(decimal(18, 3),null)  as QCResult_2_" + dtqc.Rows[i]["QCCode"].ToString().Trim() 
////                      + ",convert(decimal(18, 3),null)  as QCResult_3_" + dtqc.Rows[i]["QCCode"].ToString().Trim();
////                }
//                sSQL = sSQL.Replace("1111111111", �ֿ�);

//                if (buttonEdit�������1.EditValue != null && buttonEdit�������1.EditValue.ToString() != "")
//                {
//                    sSQL = sSQL.Replace("1=1", "1=1 and cInvCode>='" + buttonEdit�������1.EditValue.ToString().Trim() + "'");
//                }
//                if (buttonEdit�������2.EditValue != null && buttonEdit�������2.EditValue.ToString() != "")
//                {
//                    sSQL = sSQL.Replace("1=1", "1=1 and cInvCode<='" + buttonEdit�������2.EditValue.ToString().Trim() + "'");
//                }
//                if (buttonEdit�ֿ�.EditValue != null && buttonEdit�ֿ�.EditValue.ToString() != "")
//                {
//                    sSQL = sSQL.Replace("1=1", "1=1 and cWhCode='" + buttonEdit�ֿ�.EditValue.ToString().Trim() + "' ");
//                }
//                if (lookUpEditcDefine3.Text != "")
//                {
//                    sSQL = sSQL.Replace("1=1", "1=1 and cFree4='" + lookUpEditcDefine3.EditValue.ToString().Trim() + "'");
//                }
//                if (lookUpEditcPosition.Text != "")
//                {
//                    sSQL = sSQL.Replace("1=1", "1=1 and cPosition ='" + lookUpEditcPosition.EditValue.ToString().Trim() + "'");
//                }
                ����Դ sfc = new ����Դ();
                //sSQL = sSQL.Replace("2222222222", sfc.�շ������(Conn, dateEdit1.DateTime.ToString("yyyy-MM-dd"), dateEdit2.DateTime.ToString("yyyy-MM-dd")));
                //DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                //DataTable dtjy = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sfc.����()).Tables[0];
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    decimal q1 = ϵͳ����.���.ReturnDecimal(dtjy.Compute("sum(iQuantity)", "cInvCode='" + dt.Rows[i]["cInvCode"].ToString() + "' and cFree1='" + dt.Rows[i]["cFree1"].ToString() + "' and Conclusion='1'"));//����
                //    decimal q2 = ϵͳ����.���.ReturnDecimal(dtjy.Compute("sum(iQuantity)", "cInvCode='" + dt.Rows[i]["cInvCode"].ToString() + "' and cFree1='" + dt.Rows[i]["cFree1"].ToString() + "' and Conclusion='2'"));//�ϸ�
                //    decimal q3 = ϵͳ����.���.ReturnDecimal(dtjy.Compute("sum(iQuantity)", "cInvCode='" + dt.Rows[i]["cInvCode"].ToString() + "' and cFree1='" + dt.Rows[i]["cFree1"].ToString() + "' and Conclusion='3'"));//���ϸ�
                //    decimal q = ϵͳ����.���.ReturnDecimal(dt.Rows[i]["iQuantity"]);

                //    if (q > q3)
                //    {
                //        dt.Rows[i]["���ϸ�"] = q3;
                //        q = q - q3;
                //    }
                //    else
                //    {
                //        dt.Rows[i]["���ϸ�"] = q;
                //        q = 0;
                //    }

                //    if (q > q1)
                //    {
                //        dt.Rows[i]["����"] = q1;
                //        q = q - q1;
                //    }
                //    else
                //    {
                //        dt.Rows[i]["����"] = q;
                //        q = 0;
                //    }

                //    dt.Rows[i]["�ϸ�"] = q;
                //}
                string cInvCode1 = "";
                if (lookUpEdit�������1.EditValue != null)
                {
                    cInvCode1 = lookUpEdit�������1.EditValue.ToString().Trim();
                }
                string cInvCode2 = "";
                if (lookUpEdit�������2.EditValue != null)
                {
                    cInvCode2 = lookUpEdit�������2.EditValue.ToString().Trim();
                }
                DataTable dt = sfc.������(Conn, cInvCode1, cInvCode2, dateEdit2.DateTime.ToString("yyyy-MM-dd"), "", lookUpEdit�ֿ�.EditValue.ToString());

                DataTable dtBind = new DataTable();
                dtBind.Columns.Add("ID");
                dtBind.Columns.Add("ParentID");
                dtBind.Columns.Add("TreeList");
                dtBind.Columns.Add("cInvCode");
                dtBind.Columns.Add("cFree1");
                dtBind.Columns.Add("iQuantity", typeof(decimal));
                dtBind.Columns.Add("�ۼ����", typeof(decimal));
                dtBind.Columns.Add("�ۼ�����", typeof(decimal));
                dtBind.Columns.Add("�ۼ��˿�", typeof(decimal));
                dtBind.Columns.Add("�ɹ����", typeof(decimal));
                dtBind.Columns.Add("�˻�����", typeof(decimal));
                dtBind.Columns.Add("�ۼ�����", typeof(decimal));
                dtBind.Columns.Add("�ۼ��˻�", typeof(decimal));
                dtBind.Columns.Add("����", typeof(decimal));
                dtBind.Columns.Add("�ϸ�", typeof(decimal));
                dtBind.Columns.Add("���ϸ�", typeof(decimal));

                string[] sum = new string[11 + dtck.Rows.Count + dtproj.Rows.Count];
                sum[0] = "iQuantity";
                sum[1] = "�ۼ����";
                sum[2] = "�ۼ�����";
                sum[3] = "�ۼ��˿�";
                sum[4] = "�ɹ����";
                sum[5] = "�˻�����";
                sum[6] = "�ۼ�����";
                sum[7] = "�ۼ��˻�";
                sum[8] = "����";
                sum[9] = "�ϸ�";
                sum[10] = "���ϸ�";
                
                //�ֿ�
                for (int j = 0; j < dtck.Rows.Count; j++)
                {
                    dtBind.Columns.Add("cWhCode_" + dtck.Rows[j]["cWhCode"].ToString().Trim(), typeof(decimal));
                    sum[11 + j] = "cWhCode_" + dtck.Rows[j]["cWhCode"].ToString().Trim();
                }
                //�����
                for (int j = 0; j < dtproj.Rows.Count; j++)
                {
                    dtBind.Columns.Add("Project_" + dtproj.Rows[j]["cValue"].ToString().Trim(), typeof(decimal));
                    sum[11 + j + dtck.Rows.Count] = "Project_" + dtproj.Rows[j]["cValue"].ToString().Trim();
                }

                string[] col = new string[] { "cInvCode", "cFree1" };
                myTreeList1.Band(dt, dtBind
                       , new string[] { "cInvCName1", "cInvCName2", "cInvCName3", "cInvName", "cInvStd" }
                       , sum, col);
                for (int i = 0; i < myTreeList1.Nodes.Count; i++)
                {
                    myTreeList1.Nodes[i].Expanded = true;
                }
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
                sF.Filter = "Excel�ļ�(*.xlsx)|*.xlsx|�����ļ�(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK == dRes)
                {
                    myTreeList1.ExportToXlsx(sF.FileName);
                    //NOPI.ToExcel(sF.FileName, "���");
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
                DevExpress.XtraTreeList.Nodes.TreeListNode node =myTreeList1.FocusedNode;
                if (node == null)
                    return;
                if (node.HasChildren == true)
                    return;
                string Caption=myTreeList1.FocusedColumn.FieldName;
                string cInvCode = myTreeList1.FocusedNode.GetValue("cInvCode").ToString();
                string sdate = dateEdit1.DateTime.ToString("yyyy-MM-dd");
                string edate = dateEdit2.DateTime.ToString("yyyy-MM-dd");
                string cFree1 = myTreeList1.FocusedNode.GetValue("cFree1").ToString();
                string cFree3 = myTreeList1.FocusedNode.GetValue("cFree3").ToString();
                string cWhCode = lookUpEdit�ֿ�.EditValue.ToString();
                string cFree4 = lookUpEditcFree4.EditValue.ToString();
                string cposname = myTreeList1.FocusedNode.GetValue("cposname").ToString();
                if (Caption == "�ۼ����" || Caption == "�ۼ�����" || Caption == "�ۼ��˿�"
                    || Caption == "�ɹ����" || Caption == "�˻�����"
                    || Caption == "�ۼ�����" || Caption == "�ۼ��˻�")
                {
                    Frm��ϸ frm = new Frm��ϸ(Conn);

                    //if (Caption =="�ۼ����")
                    //{
                    //    frm.�ۼ����(cInvCode, sdate, edate, cposname, cFree1, cFree3);
                    //}
                    //else if (Caption == "�ۼ�����")
                    //{
                    //    frm.�ۼ�����(cInvCode, sdate, edate, cposname, cFree1, cFree3, 0, "");
                    //}
                    //else if (Caption == "�ۼ��˿�")
                    //{
                    //    frm.�ۼ�����(cInvCode, sdate, edate, cposname, cFree1, cFree3, 1, "");
                    //}
                    //else if (Caption == "�ɹ����")
                    //{
                    //    frm.�ɹ����(cInvCode, sdate, edate, cposname, cFree1, cFree3, 0, "");
                    //}
                    //else if (Caption =="�˻�����")
                    //{
                    //    frm.�ɹ����(cInvCode, sdate, edate, cposname, cFree1, cFree3, 1, "");
                    //}
                    //else if (Caption == "�ۼ�����")
                    //{
                    //    frm.�ۼ�����(cInvCode, sdate, edate, cposname, cFree1, cFree3, 0, "");
                    //}
                    //else if (Caption == "�ۼ��˻�")
                    //{
                    //    frm.�ۼ�����(cInvCode, sdate, edate, cposname, cFree1, cFree3, 1, "");
                    //}
                    frm.Show();
                    if (DialogResult.OK == frm.ShowDialog())
                    {
                        frm.Enabled = true;
                    }
                }
                else
                {
                    //Frm��Ʒ����������ѯ��ϸ frm = new Frm��Ʒ����������ѯ��ϸ(Conn, cInvCode, cInvCode, sdate, edate, cFree1, cFree3, cFree4, cposname, cWhCode);
                    //frm.Show();
                    //if (DialogResult.OK == frm.ShowDialog())
                    //{
                    //    frm.Enabled = true;
                    //}
                }
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

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            bool b = !checkBox2.Checked;
            for (int i = myTreeList1.Bands.Count - 1; i >= 0; i--)
            {
                if (myTreeList1.Bands[i].Name == "�������������ͳ��" || myTreeList1.Bands[i].Name == "����ɹ�ͳ��" || myTreeList1.Bands[i].Name == "��������ͳ��")
                {
                    myTreeList1.Bands[i].Visible = b;
                }
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