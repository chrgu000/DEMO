using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using FrameBaseFunction;

namespace Purchase
{
    public partial class Frm��������_�ɹ� : FrameBaseFunction.Frm�б���ģ��
    {

        DataTable dtTable;
        DataTable dtSel = new DataTable();
        int iPage = 0;
        ArrayList aList;
        string sSQL;

        public Frm��������_�ɹ�()
        {
            InitializeComponent();
        }

        protected override void BtnClick(string sBtnName, string sBtnText)
        {
            try
            {
                switch (sBtnName.ToLower())
                {
                    case "alter":
                        btnAlter();
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
                    case "last":
                        btnLast();
                        break;
                    case "next":
                        btnNext();
                        break;
                    case "prev":
                        btnPrev();
                        break;
                    case "refresh":
                        btnRefresh();
                        break;
                    case "save":
                        btnSave();
                        break;
                    case "sel":
                        btnSel();
                        break;
                    default:
                        break;
                }

                sState = sBtnName.ToLower();
            }
            catch (Exception ee)
            {
                throw new Exception(sBtnText + " ʧ��! \n\nԭ��:\n  " + ee.Message);
            }
        }

        DataTable dt���� = new DataTable();

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
                    gridView����.ExportToXls(sF.FileName);
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
        /// ˢ��
        /// </summary>
        private void btnRefresh()
        {
            if (txt���۶���ID.Text.Trim() != "")
                GetGrid(Convert.ToInt64(txt���۶���ID.Text));
        }

        private string sFrmSEL = "";

        /// <summary>
        /// ��ѯ
        /// </summary>
        private void btnSel()
        {
            Frm��������_SEL fSel = new Frm��������_SEL(1);
            fSel.ShowDialog();
            if (fSel.DialogResult != DialogResult.OK)
            {
                throw new Exception("ȡ����ѯ");
            }
            GetGrid(fSel.i���۶���ID);
        }

        /// <summary>
        /// ��ҳ
        /// </summary>
        private void btnFirst()
        {
            try
            {
                if (dtSel == null || dtSel.Rows.Count < 1)
                {
                    throw new Exception("û�п��Բ鿴�ĵ���");
                }

                iPage = 0;
                long i = Convert.ToInt64(dtSel.Rows[iPage]["���۶���ID"]);
                GetGrid(i);
                lPageInfo.Text = (iPage + 1).ToString() + "/" + dtSel.Rows.Count.ToString();
            }
            catch { }
        }
        /// <summary>
        /// ��ҳ
        /// </summary>
        private void btnPrev()
        {
            try
            {
                if (dtSel == null || dtSel.Rows.Count < 1)
                {
                    throw new Exception("û�п��Բ鿴�ĵ���");
                }

                if (iPage > 0)
                {
                    iPage -= 1;
                    long i = Convert.ToInt64(dtSel.Rows[iPage]["���۶���ID"]);
                    GetGrid(i);
                    lPageInfo.Text = (iPage + 1).ToString() + "/" + dtSel.Rows.Count.ToString();
                }
            }
            catch { }

        }
        /// <summary>
        /// ��ҳ
        /// </summary>
        private void btnNext()
        {
            try
            {
                if (dtSel == null || dtSel.Rows.Count < 1)
                {
                    throw new Exception("û�п��Բ鿴�ĵ���");
                }

                if (iPage < dtSel.Rows.Count - 1)
                {
                    iPage += 1;
                    long i = Convert.ToInt64(dtSel.Rows[iPage]["���۶���ID"]);
                    GetGrid(i);

                    lPageInfo.Text = (iPage + 1).ToString() + "/" + dtSel.Rows.Count.ToString();
                }
            }
            catch { }
        }

        /// <summary>
        /// ĩҳ
        /// </summary>
        private void btnLast()
        {
            try
            {
                if (dtSel == null || dtSel.Rows.Count < 1)
                {
                    throw new Exception("û�п��Բ鿴�ĵ���");
                }

                iPage = dtSel.Rows.Count - 1;

                long i = Convert.ToInt64(dtSel.Rows[iPage]["���۶���ID"]);
                GetGrid(i);
                lPageInfo.Text = (iPage + 1).ToString() + "/" + dtSel.Rows.Count.ToString();
            }
            catch { }
        }
       
        /// <summary>
        /// �޸�
        /// </summary>
        private void btnEdit()
        {
            if (txt���۶�����.Text.Trim() == "")
            {
                throw new Exception("��ѡ����Ҫ�޸ĵĵ���");
            }

            dt���� = (DataTable)gridControl����.DataSource;

            sState = "edit";
            SetColEdit(true);
        }


        /// <summary>
        /// ����
        /// </summary>
        private void btnSave()
        {
            try
            {
                gridView����.FocusedRowHandle -= 1;
                gridView����.FocusedRowHandle += 1;

                gridView����.FocusedRowHandle -= 1;
                gridView����.FocusedRowHandle += 1;
                aList = new System.Collections.ArrayList();
                string sErr = "";

                for (int i = 0; i < gridView����.RowCount; i++)
                {

                    if (gridView����.GetRowCellValue(i, gridColѡ��1).ToString().Trim() == "��")
                    {
                        if (gridView����.GetRowCellValue(i, gridCol������1).ToString().Trim() != "")
                        {
                            sErr = sErr + "��" + (i + 1) + "�Ѿ�������������\n";
                            continue;
                        }
                        if (gridView����.GetRowCellValue(i, gridCol��ǩ�깤����1).ToString().Trim() != "")
                        {
                            DateTime d1 = Convert.ToDateTime(gridView����.GetRowCellValue(i, gridCol��ǩ�깤����1));
                            DateTime d2 = DateTime.Today;
                            if (d1 < d2)
                            {
                                sErr = sErr + "��" + (i + 1) + "��ǩ���ڲ������ڵ���\n";
                                continue;
                            }
                        }

                        gridView����.SetRowCellValue(i, gridCol��ǩ��1, FrameBaseFunction.ClsBaseDataInfo.sUserName);
                        gridView����.SetRowCellValue(i, gridCol��ǩ����1, DateTime.Now);

                        sSQL = "update XWSystemDB_DL..������������3 set ��ǩ����2 = '" + gridView����.GetRowCellValue(i, gridCol��ǩ�깤����1).ToString().Trim() + "',��ǩ�� = '" + gridView����.GetRowCellValue(i, gridCol��ǩ��1).ToString().Trim() + "',��ǩ���� = '" + gridView����.GetRowCellValue(i, gridCol��ǩ����1).ToString().Trim() + "' where iID = " + gridView����.GetRowCellValue(i, gridColiID1).ToString().Trim();
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

                    GetSelList();
                    iPage = dtSel.Rows.Count - 1;
                    lPageInfo.Text = (iPage + 1).ToString() + "/" + dtSel.Rows.Count.ToString();

                    MessageBox.Show("����ɹ���");

                    SetColEdit(false);
                    sState = "save";
                }

                SetColEdit(false);

                GetSelList();
            }
            catch (Exception ee)
            {
                MsgBox("����ʧ��", ee.Message);
            }


        }

        

        /// <summary>
        /// �����ʼ�
        /// </summary>
        private void btnAlter()
        {
            string s = "";
            switch (FrameBaseFunction.ClsBaseDataInfo.sUid)
            {
                case "012":
                    s = " and (iID = 1 or iID = 3)";
                    break;
                case "014":
                    s = " and (iID = 1 or iID = 3)";
                    break;
                case "018":
                    s = " and (iID = 2 or iID = 3)";
                    break;
                case "027":
                    s = " and (iID = 2 or iID = 3)";
                    break;
            }

            string sSQL = "select * from XWSystemDB_DL.dbo._LookUpDate where iType = 7  " + s;
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            string sMail = "";

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (sMail == "")
                    sMail = dt.Rows[i]["iText"].ToString().Trim();
                else
                {
                    sMail = sMail + ";" + dt.Rows[i]["iText"].ToString().Trim();
                }
            }
            string sHead = "��������ɹ�ȷ�ϣ�" + txt����������.Text.Trim();
            string sText = "��������" + txt����������.Text.Trim() + "�Ѿ��ɹ�ȷ�ϡ�";
            //Purchase.FrmSendMail fSendMail = new FrmSendMail(sMail, sHead, sText);
            //fSendMail.ShowDialog();
            //fSendMail.btnSend_Click(null, null);
        }

        private void Frm��������_�ɹ�_Load(object sender, EventArgs e)
        {
            try
            {

                lookUpEdit����.Properties.ReadOnly = false;
                lookUpEdit����.Enabled = true;

                GetLookUp();

                GetSelList();

                btnLast();
            }
            catch (Exception ee)
            {
                MessageBox.Show("���ش���ʧ��\n" + ee.Message);
            }
        }

        private void gridView����_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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
            string sSQL = "select cInvCode,cInvName,cInvStd from @u8.Inventory order by cInvCode";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            DataRow drInv = dt.NewRow();
            drInv["cInvCode"] = "--";
            dt.Rows.Add(drInv);
            ItemLookUpEdit1���ϱ���.DataSource = dt;
            ItemLookUpEdit1��������.DataSource = dt;
            ItemLookUpEdit1���Ϲ��.DataSource = dt;

            sSQL = "select cCusCode,cCusName,cCusAbbName from @u8.Customer order by cCusCode";
            dt = clsSQLCommond.ExecQuery(sSQL);
            lookUpEdit�ͻ�.Properties.DataSource = dt;

            DataColumn dc = new DataColumn();
            dc.ColumnName = "iID";
            dt.Columns.Add(dc);
            DataRow dr = dt.NewRow();
            dr["iID"] = "�ɹ�";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["iID"] = "ί��";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["iID"] = "����";
            dt.Rows.Add(dr);
            ItemLookUpEdit1�Ӽ�����.DataSource = dt;

            sSQL = "select cDepCode,cDepName from @u8.Department order by cDepCode";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit1���ű���.DataSource = dt;
            ItemLookUpEdit1��������.DataSource = dt;

            sSQL = "select cWhCode,cWhName from @u8.Warehouse  order by cWhCode";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit1�ֿ����.DataSource = dt;
            ItemLookUpEdit1�ֿ�����.DataSource = dt;

            sSQL = "select cDepCode,cDepName from @u8.Department where cDepCode in ('1','4','905') order by cDepCode ";
            dt = clsSQLCommond.ExecQuery(sSQL);
            DataRow dr2 = dt.NewRow();
            dt.Rows.InsertAt(dr2, 0);

            lookUpEdit����.Properties.DataSource = dt;

            sSQL = "select cVenCode,cVenName from @u8.Vendor  order by cVenCode";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit��Ӧ��.DataSource = dt;
        }

        private void gridView����_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                int i1 = ReturnObjectToInt(gridView����.GetRowCellValue(e.RowHandle, gridCol���۶����к�1));
                int i2 = i1 % 2;

                if (i2 == 0)
                {
                    e.Appearance.BackColor = Color.AliceBlue;
                }
                else
                {
                    e.Appearance.BackColor = Color.AntiqueWhite;
                }
            }
            catch
            { }
        }

        private void SetColEdit(bool b)
        {
            gridCol��ǩ��ʼ����1.OptionsColumn.AllowEdit = b;
            gridCol��ǩ�깤����1.OptionsColumn.AllowEdit = b;
            chkȫѡ.Enabled = true;
            chkȫѡ.Checked = false;

            //for (int i = 0; i < base.toolStrip1.Items.Count; i++)
            //{
            //    if (base.toolStrip1.Items[i].Name.ToLower().Trim() == "edit")
            //    {
            //        base.toolStrip1.Items[i].Enabled = !b;
            //    }
            //    if (base.toolStrip1.Items[i].Name.ToLower().Trim() == "save")
            //    {
            //        base.toolStrip1.Items[i].Enabled = b;
            //    }
            //}
        }

        private void GetGrid(long i���۶���ID)
        {
            string sSQL = "select * from XWSystemDB_DL.dbo.������������1 where ���۶���ID = " + i���۶���ID + " and ���׺� = " + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim();
            DataTable dt������������1 = clsSQLCommond.ExecQuery(sSQL);

            sSQL = "select * from XWSystemDB_DL.dbo.������������2 where ���۶���ID = " + i���۶���ID + " and ���׺� = " + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim() + " order by iID";
            DataTable dt������������2 = clsSQLCommond.ExecQuery(sSQL);

            sSQL = @"
select cast(null as varchar(2)) as ѡ��,*,cast(null as varchar(50)) as ��Ӧ�̱���,cast(null as decimal(18,6)) as ��˰����,cast(null as decimal(18,6)) as ��˰���,cast(null as varchar(50)) as �ɹ����ű���,cast(null as decimal(18,6)) as �ֿ��ִ���,cast(null as decimal(18,6)) as �����,cast(null as decimal(18,6)) as �µ���,cast(null as decimal(18,6)) as �ۼ��µ���,cast(null as decimal(18,6)) as �ۼƴ����,cast(null as decimal(18,6)) as ��С���� 
from XWSystemDB_DL.dbo.������������3 where isnull(�����µ�����,0) <> 0 and �Ӽ����� = '�ɹ�' and ���۶���ID = aaaaaaaaaa and ���׺� = 200
order by �Ӽ�����,iID
";
            sSQL = sSQL.Replace("aaaaaaaaaa", i���۶���ID.ToString());
            DataTable dt������������3 = clsSQLCommond.ExecQuery(sSQL);

            if (dt������������1 != null && dt������������1.Rows.Count > 0 && dt������������2 != null && dt������������2.Rows.Count > 0 && dt������������3 != null && dt������������3.Rows.Count > 0)
            {
                for (int i = 0; i < dt������������3.Rows.Count; i++)
                {
                    string s�Ӽ� = dt������������3.Rows[i]["�Ӽ�����"].ToString().Trim();
                    string s���۶����� = dt������������1.Rows[0]["���۶�����"].ToString().Trim();
                    sSQL = "select a.cPOID,b.cDefine37,b.iTaxPrice,b.iSum,a.cVenCode,c.cVenDepart " +
                           "from @u8.PO_Pomain a inner join @u8.PO_Podetails b on a.poid = b.poid  left join @u8.Vendor c on a.cVenCode = c.cVenCode " +
                           "where b.cInvCode = '" + s�Ӽ� + "' and cItemCode = '" + s���۶����� + "'  ";
                    DataTable dt�ɹ���Ӧ�̻�ǩ���� = clsSQLCommond.ExecQuery(sSQL);

                    if (dt�ɹ���Ӧ�̻�ǩ���� != null && dt�ɹ���Ӧ�̻�ǩ����.Rows.Count > 0)
                    {
                        DateTime dtm��Ӧ�̻�ǩ���� = ReturnObjectToDatetime(dt�ɹ���Ӧ�̻�ǩ����.Rows[0]["cDefine37"]);
                        if(dtm��Ӧ�̻�ǩ���� > ReturnObjectToDatetime("2015-01-01"))
                        {
                            dt������������3.Rows[i]["��Ӧ�̻�ǩ����"] = dtm��Ӧ�̻�ǩ����.ToString("yyyy/MM/dd");
                        }
                        dt������������3.Rows[i]["��Ӧ�̱���"] = dt�ɹ���Ӧ�̻�ǩ����.Rows[0]["cVenCode"];
                        dt������������3.Rows[i]["��˰����"] = dt�ɹ���Ӧ�̻�ǩ����.Rows[0]["iTaxPrice"];
                        dt������������3.Rows[i]["��˰���"] = dt�ɹ���Ӧ�̻�ǩ����.Rows[0]["iSum"];
                        dt������������3.Rows[i]["�ɹ����ű���"] = dt�ɹ���Ӧ�̻�ǩ����.Rows[0]["cVenDepart"];
                    }
                }

                txt���۶�����.Text = dt������������1.Rows[0]["���۶�����"].ToString().Trim();
                txt����������.Text = dt������������1.Rows[0]["����������"].ToString().Trim();
                txt�ͻ�������.Text = dt������������1.Rows[0]["�ͻ�������"].ToString().Trim();
                lookUpEdit�ͻ�.EditValue = dt������������1.Rows[0]["�ͻ����"];
                txt��ע.Text = dt������������1.Rows[0]["��ע"].ToString().Trim();
                txt���۶���ID.Text = dt������������1.Rows[0]["���۶���ID"].ToString().Trim();
                txt����ע.Text = dt������������1.Rows[0]["����ע"].ToString().Trim();

                DataView dv = dt������������3.DefaultView;
                if (lookUpEdit����.Text.Trim() != "")
                {
                    dv.RowFilter = " isnull(�ɹ����ű���,'') = '' or �ɹ����ű��� = '" + lookUpEdit����.EditValue.ToString().Trim() + "' ";
                }
                DataTable dtTemp = dv.ToTable();

                gridControl����.DataSource = dtTemp;

                sSQL = @"
select distinct a.cCode,b.cItemCode,a.cAuditDate,a.cAuditTime,a.cMakeTime,a.ID
from @u8.PU_AppVouch a inner join @u8.PU_AppVouchs b on a.ID = b.ID  
where b.cItemCode = '111111'
order by a.ID
";
                sSQL = sSQL.Replace("111111", txt���۶�����.Text.Trim());
                DataTable dt���ʱ�� = clsSQLCommond.ExecQuery(sSQL);
                if (dt���ʱ�� != null && dt���ʱ��.Rows.Count > 0)
                {
                    txt�빺�����ʱ��.Text = ReturnObjectToDatetime(dt���ʱ��.Rows[0]["cAuditTime"]).ToString("yyyy-MM-dd HH:mm:ss");
                }
                else
                {
                    txt�빺�����ʱ��.Text = "";
                }
            }
            else
            {
                throw new Exception("��õ���ʧ��");
            }


            SetColEdit(false);

            //if (lookUpEdit����.Text.Trim() != "")
            //{
            //    gridCol�ɹ����ű���1.FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(" �ɹ����ű��� = '" + lookUpEdit����.EditValue.ToString().Trim() + "' or �ɹ����ű��� = '' or �ɹ����ű��� is null ");
            //}
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            b˫�� = true;

            if (sState != "edit" && chkȫѡ.Checked)
            {
                MessageBox.Show("��������״̬�ſ���ȫѡ");
                chkȫѡ.Checked = false;
                return;
            }

            try
            {
                if (chkȫѡ.Checked)
                {
                    for (int i = 0; i < gridView����.RowCount; i++)
                    {

                        //if (gridView����.GetRowCellValue(i, gridCol��ǩ�깤����1).ToString().Trim() == "")
                        //{
                            if (gridView����.GetRowCellValue(i, gridCol��Ӧ�̻�ǩ����1).ToString().Trim() != "")
                            {
                                gridView����.SetRowCellValue(i, gridCol��ǩ�깤����1, gridView����.GetRowCellValue(i, gridCol��Ӧ�̻�ǩ����1));
                            }
                            else
                            {
                                gridView����.SetRowCellValue(i, gridCol��ǩ�깤����1, gridView����.GetRowCellValue(i, gridCol�������1));
                            }
                        //}

                        if (gridView����.GetRowCellValue(i, gridCol��ǩ�깤����1).ToString().Trim() != "")
                        {
                            gridView����.SetRowCellValue(i, gridColѡ��1, "��");
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < gridView����.RowCount; i++)
                    {
                        gridView����.SetRowCellValue(i, gridColѡ��1, "");
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            b˫�� = false;
        }

        bool b˫�� = false;

        private void gridView����_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (sState != "edit")
                    return;

                b˫�� = true;
                int i = gridView����.FocusedRowHandle;
                if (gridView����.GetRowCellValue(i, gridColѡ��1).ToString().Trim() == "")
                {
                    if (gridView����.GetRowCellValue(i, gridCol��Ӧ�̻�ǩ����1).ToString().Trim() != "")
                    {
                        gridView����.SetRowCellValue(i, gridCol��ǩ�깤����1, gridView����.GetRowCellValue(i, gridCol��Ӧ�̻�ǩ����1));
                    }
                    else
                    {
                        gridView����.SetRowCellValue(i, gridCol��ǩ�깤����1, gridView����.GetRowCellValue(i, gridCol�������1));
                    }
                    if (gridView����.GetRowCellValue(i, gridCol��ǩ�깤����1).ToString().Trim() != "")
                    {
                        gridView����.SetRowCellValue(i, gridColѡ��1, "��");
                    }
                }
                else
                {
                    gridView����.SetRowCellValue(i, gridColѡ��1, "");
                }
                if (!b˫��)
                {
                    if (gridView����.GetRowCellValue(i, gridColѡ��1).ToString().Trim() == "��")
                    {
                        gridView����.SetRowCellValue(i, gridColѡ��1, "");
                    }
                }
            }
            catch { }
            b˫�� = false;
        }

        private void GetSelList()
        {
            string sSQL = "select ���۶���ID from XWSystemDB_DL..������������1 where ���׺� = " + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim() + " and isnull(�����,'') <> '' and isnull(�ر���,'') = '' and isnull(�´��빺��,'') <> '' order by ���۶�����";
            dtSel = clsSQLCommond.ExecQuery(sSQL);

            if (dtSel != null && dtSel.Rows.Count > 0)
            {
                iPage = dtSel.Rows.Count - 1;
            }
        }

        private void gridView����_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (sState == "edit")
            {
                if (gridView����.GetRowCellValue(e.FocusedRowHandle, gridCol������1) == null || gridView����.GetRowCellValue(e.FocusedRowHandle, gridCol������1).ToString().Trim() == "")
                {
                    gridCol��ǩ��ʼ����1.OptionsColumn.AllowEdit = true;
                    gridCol��ǩ�깤����1.OptionsColumn.AllowEdit = true;
                }
                else
                {
                    gridCol��ǩ��ʼ����1.OptionsColumn.AllowEdit = false;
                    gridCol��ǩ�깤����1.OptionsColumn.AllowEdit = false;
                }
            }
        }

        private decimal GetQTY(object d)
        {
            try
            {
                return ReturnDecimal(d);
            }
            catch
            {
                return -999999;
            }
        }

        private void lookUpEdit����_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (txt���۶���ID.Text.Trim() == "")
                    return;

                GetGrid(Convert.ToInt64(txt���۶���ID.Text.Trim()));
            }
            catch (Exception ee)
            {
                MessageBox.Show("ɸѡʧ��:" + ee.Message);
            }
        }

        public static decimal ReturnDecimal(object d)
        {
            try
            {
                decimal d1 = Convert.ToDecimal(d);
                return decimal.Round(d1, 6);
            }
            catch
            {
                return 0;
            }
        }

        DateTime ReturnObjectToDatetime(object o)
        {
            DateTime d = Convert.ToDateTime("1900-01-01");
            try
            {
                d = Convert.ToDateTime(o);
            }
            catch { }
            return d;
        }
    }
}