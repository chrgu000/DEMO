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
    public partial class FrmDB : FrameBaseFunction.Frm�б���ģ��
    {
        public FrmDB()
        {
            InitializeComponent();
        }

        DataTable dtExcel;

        protected override void BtnClick(string sBtnName, string sBtnText)
        {
            try
            {
                switch (sBtnName.ToLower())
                {
                    case "sel":
                        btnGet();
                        break;
                    case "save":
                        btnImport();
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

        private void btnGet()
        {
            try
            {
                OpenFileDialog oFile = new OpenFileDialog();
                oFile.Filter = "Excel�ļ�2003|*.xls|Excel�ļ�2007|*.xlsx";
                if (oFile.ShowDialog() == DialogResult.OK)
                {
                    string sFilePath = oFile.FileName;
                    string sSQL = "select �Ӽ�����,�Ӽ�����,�Ӽ����,����λ,ʵ������,ʵ������ from [Sheet1$]";
                    
                    dtExcel = clsExcel.ExcelToDT(sFilePath, sSQL, true);

                    gridControl1.DataSource = dtExcel;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("���Excel��Ϣʧ�ܣ�\n    " + ee.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void btnImport()
        {
            try
            {
                string sDepIn;
                string sDepOut;
                string sWhIn;
                string sWhOut;
                string sStypeOut;
                string sStypeIn;
                FrmDBEdit fEdit = new FrmDBEdit();
                if (fEdit.ShowDialog() == DialogResult.OK)
                {
                    sDepIn = fEdit.sDepIn;
                    sDepOut = fEdit.sDepOut;
                    sWhIn = fEdit.sWhIn;
                    sWhOut = fEdit.sWhOut;
                    sStypeOut = fEdit.sStyleOut;
                    sStypeIn = fEdit.sStyleIn;
                }
                else
                {
                    MessageBox.Show("δѡ��ת�벿�ţ�");
                    return;
                }

                string sSQL = "";
                long iID;
                long iIDDetail;
                long iVouNumber;

                //���ID��
                sSQL = "select iFatherID,iChildID from UFSystem..UA_Identity where cAcc_Id = '200' and cVouchType = 'at'";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);

                if(dt == null || dt.Rows.Count <1)
                {
                    iID=0;
                    iIDDetail=0;
                }
                else
                {
                    iID = Convert.ToInt64( dt.Rows[0]["iFatherID"]);
                    iIDDetail = Convert.ToInt64( dt.Rows[0]["iChildID"]);
                }


                //�����ʷ��󵥾ݺ�
                sSQL = "select isnull(max(cNumber),0) as Maxnumber From @u8.VoucherHistory  with (NOLOCK) Where  CardNumber='0324' and cSeed = '" + Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyMM") + "'";
                dt = clsSQLCommond.ExecQuery(sSQL);
                iVouNumber = Convert.ToInt64(dt.Rows[0]["Maxnumber"]);
                iVouNumber += 1;
                string sVouNumber;
                string sVouNumber2;

                sVouNumber = iVouNumber.ToString().Trim();
                sVouNumber2 = iVouNumber.ToString().Trim();
                for (int i = 0; i < 10; i++)
                {
                    if (sVouNumber.Length < 10)
                    {
                        sVouNumber = "0" + sVouNumber;
                    }
                    else
                    {
                        break;
                    }
                }

                ArrayList aList = new ArrayList();

                iID += 1;
                //�������뵥��ͷ
                sSQL = "Insert Into @u8.ST_AppTransVouch(ctvcode,dtvdate,cowhcode,ciwhcode,codepcode,cidepcode,cirdcode,cordcode,cmaker,id,vt_id,iswfcontrolled) " +
                        "Values (N'" + sVouNumber + "', '" + Convert.ToDateTime( FrameBaseFunction.ClsBaseDataInfo.sLogDate) + "',N'" + sWhOut + "',N'" + sWhIn + "',N'" + sDepOut + "',N'" + sDepIn + "',N'" + sStypeIn + "',N'" + sStypeOut + "',N'" + FrameBaseFunction.ClsBaseDataInfo.sUid+ "'," + iID + ",37,0)";
                aList.Add(sSQL);

                bool b = true;
                for (int i = 0; i < dtExcel.Rows.Count; i++)
                {
                    if (dtExcel.Rows[i]["ʵ������"] == null || dtExcel.Rows[i]["ʵ������"].ToString().Trim() == string.Empty)
                    {
                        continue;
                    }
                    b = false;
                    iIDDetail += 1;
                    //����������
                    string sSQL1 = "Insert Into @u8.ST_AppTransVouchs(ctvcode,cinvcode,itvquantity,fsalecost,fsaleprice,autoid,id,iTvChkQuantity";
                    string sSQL2 = "Values(N'" + sVouNumber + "',N'" + dtExcel.Rows[i]["�Ӽ�����"].ToString().Trim() + "'," + dtExcel.Rows[i]["ʵ������"].ToString().Trim() + ",0,0," + iIDDetail + "," + iID + "," + dtExcel.Rows[i]["ʵ������"].ToString().Trim();

                    if (dtExcel.Rows[i]["ʵ������"].ToString().Trim() != string.Empty)
                    {
                        sSQL1 = sSQL1 + ",iTVNum,iTVChkNum";
                        sSQL2 = sSQL2 + ",'" + dtExcel.Rows[i]["ʵ������"].ToString().Trim() + "','" + dtExcel.Rows[i]["ʵ������"].ToString().Trim() + "'";
                    }
                    sSQL = sSQL1 + ")" + sSQL2 + ")";

                    aList.Add(sSQL);
                }
                if (b)
                {
                    MessageBox.Show("û��������Ҫ���룬���飡");
                    return;
                }

                sSQL = "update UFSystem..UA_Identity set iFatherID=" + iID + ",iChildID=" + iIDDetail + " where  cAcc_Id = '200' and cVouchType = 'at'";
                aList.Add(sSQL);

                //������󵥾ݺ�
                if (iVouNumber == 1)
                {
                    sSQL = "insert into @u8.VoucherHistory(cardnumber,ccontent,ccontentrule,cseed,cnumber,bempty)values('0324','����','��','" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyMM") + "','1',0)";
                    aList.Add(sSQL);
                }
                else
                {
                    sSQL = "update @u8.VoucherHistory set cNumber = '" + iVouNumber.ToString().Trim() + "' Where  CardNumber='0324' and cSeed='" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyMM") + "'  ";
                    aList.Add(sSQL);
                }

                clsSQLCommond.ExecSqlTran(aList);

                MessageBox.Show("���ݵ���ɹ���");
                gridControl1.DataSource = null;
            }
            catch (Exception ee)
            {
                MessageBox.Show("����������뵥ʧ�ܣ�\n    " + ee.Message);
            }
        }

        private void FrmDB_Load(object sender, EventArgs e)
        {
            try
            {
                //clsExcel = TH.BaseInfo.ClsExcel.Instance();

                dtExcel = new DataTable();
                //btnImport.Enabled = false;
            }
       
            catch (Exception ee)
            {
                MessageBox.Show("���ش���ʧ�ܣ�ԭ��" + ee.Message);
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
    }
}