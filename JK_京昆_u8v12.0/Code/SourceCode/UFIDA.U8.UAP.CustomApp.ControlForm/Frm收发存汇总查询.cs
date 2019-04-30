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
    public partial class Frm�շ�����ܲ�ѯ : UserControl
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

        public Frm�շ�����ܲ�ѯ()
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

        private void Frm�շ�����ܲ�ѯ_Load(object sender, EventArgs e)
        {
            try
            {
                Frm��ϸ frm = new Frm��ϸ(Conn);
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

                lookUpEditcFree4.EditValue = "";
                lookUpEditcPosition.EditValue = "";
                lookUpEdit�ֿ�.EditValue = "";

                sSQL = @"select cValue from UserDefine where cID=29  ORDER BY cAlias";
                dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                dr = dt.NewRow();
                dt.Rows.InsertAt(dr, 0);
                lookUpEditcFree4.Properties.DataSource = dt;

                sSQL = @"select cValue from UserDefine where cID=28  ORDER BY cAlias";
                dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                dr = dt.NewRow();
                dt.Rows.InsertAt(dr, 0);
                lookUpEditcFree3.Properties.DataSource = dt;

                sSQL = @"select cPosCode,cPosName from Position ";
                dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                dr = dt.NewRow();
                dt.Rows.InsertAt(dr, 0);
                lookUpEditcPosition.Properties.DataSource = dt;

                btnRefresh_Click(null, null);

                myTreeList1.SetBandsWidth(50);

                DataTable dtck = SqlHelper.ExecuteDataset(Conn, CommandType.Text, @"select * from Warehouse where dWhEndDate is null ORDER BY cWhCode").Tables[0];
                DataTable dtproj = SqlHelper.ExecuteDataset(Conn, CommandType.Text, @"select cValue from UserDefine where cID=28  ORDER BY cAlias").Tables[0];
                DataTable dtqc = SqlHelper.ExecuteDataset(Conn, CommandType.Text, @"select * from _QC").Tables[0];

                int i = 0;
                MyTreeListBand Band1 = myTreeList1.Bands.Add(i, 1, "����Ʒ��");
                Band1.SetColumn(0, myTreeList1.Columns["TreeList"], "����", false, DevExpress.Utils.HorzAlignment.Default);

                i = i + 1;

                //MyTreeListBand Band2 = myTreeList1.Bands.Add(i, 1, "");
                //Band2.SetColumn(0, myTreeList1.Columns["cFree1"], "��װ", false, DevExpress.Utils.HorzAlignment.Default);
                //i = i + 1;

                MyTreeListBand Band3 = myTreeList1.Bands.Add(i, 1, "");
                Band3.SetColumn(0, myTreeList1.Columns["������λ"], "������λ", false, DevExpress.Utils.HorzAlignment.Far);
                i = i + 1;

                MyTreeListBand Band4 = myTreeList1.Bands.Add(i, 4, "");
                Band4.SetColumn(0, myTreeList1.Columns["�ڳ��������"], "�ڳ����", false, DevExpress.Utils.HorzAlignment.Far);
                Band4.SetColumn(1, myTreeList1.Columns["���ڱ䶯"], "����䶯", false, DevExpress.Utils.HorzAlignment.Far);
                Band4.SetColumn(2, myTreeList1.Columns["��ĩ�������"], "��ĩ���", false, DevExpress.Utils.HorzAlignment.Far);
                Band4.SetColumn(3, myTreeList1.Columns["�ɹ�������;"], "��ĩ�ɹ�δ���", false, DevExpress.Utils.HorzAlignment.Far);
                i = i + 4;

                MyTreeListBand Band5 = myTreeList1.Bands.Add(i, 4, "�������");
                Band5.SetColumn(0, myTreeList1.Columns["iQty32"], "���۳����ˣ���", false, DevExpress.Utils.HorzAlignment.Far);
                Band5.SetColumn(1, myTreeList1.Columns["iQty11"], "���������ˣ���", false, DevExpress.Utils.HorzAlignment.Far);
                Band5.SetColumn(2, myTreeList1.Columns["iQty09"], "��������", false, DevExpress.Utils.HorzAlignment.Far);
                Band5.SetColumn(3, myTreeList1.Columns["���ڳ���"], "�ϼ�", false, DevExpress.Utils.HorzAlignment.Far);

                
                i = i + 4;
                MyTreeListBand Band6 = myTreeList1.Bands.Add(i, 4, "�������");
                Band6.SetColumn(0, myTreeList1.Columns["iQty10"], "�������", false, DevExpress.Utils.HorzAlignment.Far);
                Band6.SetColumn(1, myTreeList1.Columns["iQty01"], "�ɹ����", false, DevExpress.Utils.HorzAlignment.Far);
                Band6.SetColumn(2, myTreeList1.Columns["iQty08"], "�������", false, DevExpress.Utils.HorzAlignment.Far);
                Band6.SetColumn(3, myTreeList1.Columns["�������"], "�ϼ�", false, DevExpress.Utils.HorzAlignment.Far);

                i = i + 4;
                //MyTreeListBand Band6 = myTreeList1.Bands.Add(i, 2, "��ĩ");
                
                //i = i + 2;

                MyTreeListBand Band10 = myTreeList1.Bands.Add(i, 1, "�������");
                Band10.SetColumn(0, myTreeList1.Columns["cInvCode"], "����", false, DevExpress.Utils.HorzAlignment.Default);
                i = i + 1;

                myTreeList1.ViewInfo.RC.NeedsRestore = true;
                myTreeList1.BestFitColumns();
                myTreeList1.LayoutChanged();
                myTreeList1.Columns["TreeList"].Width = 200;
                
            }
            catch (Exception ee)
            {
                MessageBox.Show("��������ʧ��");
            }
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
                string �ֿ� = "";
                DataTable dtck = SqlHelper.ExecuteDataset(Conn, CommandType.Text, @"select * from Warehouse where dWhEndDate is null ORDER BY cWhCode").Tables[0];
                DataTable dtproj = SqlHelper.ExecuteDataset(Conn, CommandType.Text, @"select cValue from UserDefine where cID=28  ORDER BY cAlias").Tables[0];
                DataTable dtqc = SqlHelper.ExecuteDataset(Conn, CommandType.Text, @"select * from _QC").Tables[0];
                
                ����Դ sfc = new ����Դ();
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

                string cFree3 = "";
                if (lookUpEditcFree3.EditValue != null)
                {
                    cFree3 = lookUpEditcFree3.EditValue.ToString().Trim();
                }

                string cFree4 = "";
                if (lookUpEditcFree4.EditValue != null)
                {
                    cFree4 = lookUpEditcFree4.EditValue.ToString().Trim();
                }

                string cWhCode = "";
                if (lookUpEdit�ֿ�.EditValue != null)
                {
                    cWhCode = lookUpEdit�ֿ�.EditValue.ToString().Trim();
                }

                string cPosCode = "";
                if (lookUpEditcPosition.EditValue != null)
                {
                    cPosCode = lookUpEditcPosition.EditValue.ToString().Trim();
                }

                string d1 = "";
                string d2 = "";
                ϵͳ����.���.ReturnDate(out d1, out d2, rdo����.Checked, rdo����.Checked, rdo����.Checked, rdo����.Checked);
                bool bcHandler = ϵͳ����.���.ReturncHandler(rdo���.Checked, rdoδ��.Checked);
                bool bcHas = ϵͳ����.���.ReturncHandler(rdo����δ��������.Checked, rdo������δ��������.Checked);
                DataTable dt = sfc.�շ������(Conn, cInvCode1, cInvCode2, d1, d2, 1, bcHandler, bcHas, cFree3, cFree4, cWhCode, cPosCode, "", "");

                DataTable dtBind = new DataTable();
                dtBind.Columns.Add("ID");
                dtBind.Columns.Add("ParentID");
                dtBind.Columns.Add("TreeList");
                dtBind.Columns.Add("cInvCode");
                //dtBind.Columns.Add("cFree1");
                dtBind.Columns.Add("�ڳ��������", typeof(decimal));
                dtBind.Columns.Add("���ڳ���", typeof(decimal));
                dtBind.Columns.Add("�������", typeof(decimal));
                dtBind.Columns.Add("���ڱ䶯", typeof(decimal));
                dtBind.Columns.Add("��ĩ�������", typeof(decimal));
                dtBind.Columns.Add("�ɹ�������;", typeof(decimal));

                dtBind.Columns.Add("iQty32", typeof(decimal));
                dtBind.Columns.Add("iQty11", typeof(decimal));
                dtBind.Columns.Add("iQty09", typeof(decimal));
                dtBind.Columns.Add("iQty10", typeof(decimal));
                dtBind.Columns.Add("iQty01", typeof(decimal));
                dtBind.Columns.Add("iQty08", typeof(decimal));

                string[] sum = new string[12];
                sum[0] = "�ڳ��������";
                sum[1] = "���ڳ���";
                sum[2] = "�������";
                sum[3] = "���ڱ䶯";
                sum[4] = "��ĩ�������";
                sum[5] = "�ɹ�������;";

                sum[6] = "iQty32";
                sum[7] = "iQty11";
                sum[8] = "iQty09";
                sum[9] = "iQty10";
                sum[10] = "iQty01";
                sum[11] = "iQty08";

                string[] col = new string[] { "cInvCode" };
                myTreeList1.Band(dt, dtBind
                       , new string[] { "cInvCName1", "cInvCName2", "cInvCName3", "cInvName", "cInvStd", "������λ" }
                       , sum, col);
                //for (int i = 0; i < myTreeList1.Nodes.Count; i++)
                //{
                //    myTreeList1.Nodes[i].Expanded = true;
                //}
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
                string d1 = "";
                string d2 = "";
                ϵͳ����.���.ReturnDate(out d1, out d2, rdo����.Checked, rdo����.Checked, rdo����.Checked, rdo����.Checked);
                bool bcHandler = ϵͳ����.���.ReturncHandler(rdo���.Checked, rdoδ��.Checked);
                bool bcHas = ϵͳ����.���.ReturncHandler(rdo����δ��������.Checked, rdo������δ��������.Checked);
                string cFree1 = myTreeList1.FocusedNode.GetValue("cFree1").ToString();
                string cFree3 = myTreeList1.FocusedNode.GetValue("cFree3").ToString();
                string cWhCode = lookUpEdit�ֿ�.EditValue.ToString();
                string cFree4 = lookUpEditcFree4.EditValue.ToString();
                string cposname = myTreeList1.FocusedNode.GetValue("cposname").ToString();
                if (cInvCode != "")
                {
                    if (Caption == "�ڳ��������" || Caption == "��ĩ�������")
                    {
                        Frm�������ͳ�Ƽ���ѯ��ϸ frm = new Frm�������ͳ�Ƽ���ѯ��ϸ(Conn, cInvCode, cInvCode, d1, d2, cFree1, cFree3, cFree4, cposname, cWhCode);
                        frm.Show();
                        if (DialogResult.OK == frm.ShowDialog())
                        {
                            frm.Enabled = true;
                        }
                    }
                    else if (Caption == "�ܼ��������" || Caption == "�ܼƳ�������" || Caption == "���ڱ䶯")
                    {
                        Frm��ϸ frm = new Frm��ϸ(Conn);
                        frm.�շ�����ܱ��ڵ����������(cInvCode, d1, d2, bcHandler, bcHas, cFree3, cFree4, cWhCode, cposname);
                        frm.Show();
                        if (DialogResult.OK == frm.ShowDialog())
                        {
                            frm.Enabled = true;
                        }
                    }
                    else if (Caption == "�ɹ�������;")
                    {
                        Frm��ϸ frm = new Frm��ϸ(Conn);
                        frm.�շ�����ܲɹ�������;(cInvCode, d1, d2, bcHandler);
                        frm.Show();
                        if (DialogResult.OK == frm.ShowDialog())
                        {
                            frm.Enabled = true;
                        }
                    }
                    else if (Caption == "iQty32" || Caption == "iQty11" || Caption == "iQty09" || Caption == "iQty10" || Caption == "iQty01" || Caption == "iQty08")
                    {
                        string RdFlag="";
                        switch (Caption)
                        {
                            case "iQty32":
                                RdFlag = "32";
                                break;
                            case "iQty11":
                                RdFlag = "11";
                                break;
                            case "iQty09":
                                RdFlag = "09";
                                break;
                            case "iQty10":
                                RdFlag = "10";
                                break;
                            case "iQty08":
                                RdFlag = "08";
                                break;
                            case "iQty01":
                                RdFlag = "01";
                                break;
                        }
                        Frm��ϸ frm = new Frm��ϸ(Conn);
                        //frm.����ⵥ��ϸ(cInvCode, cInvCode, d1, d2, cposname, cFree1, cFree3, -1, "", Flag);
                        frm.�շ�����ܱ��ڵ���������ϸ(cInvCode, d1, d2, bcHandler, bcHas, cFree3, cFree4, cWhCode, cposname, "", RdFlag);
                        frm.Show();
                        if (DialogResult.OK == frm.ShowDialog())
                        {
                            frm.Enabled = true;
                        }
                    }
                    
                }
                else
                {
                    //Frm�շ�����ܲ�ѯ��ϸ frm = new Frm�շ�����ܲ�ѯ��ϸ(Conn, cInvCode, cInvCode, sdate, edate, cFree1, cFree3, cFree4, cposname, cWhCode);
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