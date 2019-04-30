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
    public partial class FrmDB : FrameBaseFunction.Frm列表窗体模板
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
                MessageBox.Show(sBtnText + " 失败! \n\n原因:\n  " + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGet()
        {
            try
            {
                OpenFileDialog oFile = new OpenFileDialog();
                oFile.Filter = "Excel文件2003|*.xls|Excel文件2007|*.xlsx";
                if (oFile.ShowDialog() == DialogResult.OK)
                {
                    string sFilePath = oFile.FileName;
                    string sSQL = "select 子件编码,子件名称,子件规格,主单位,实发数量,实发件数 from [Sheet1$]";
                    
                    dtExcel = clsExcel.ExcelToDT(sFilePath, sSQL, true);

                    gridControl1.DataSource = dtExcel;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得Excel信息失败！\n    " + ee.Message);
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
                    MessageBox.Show("未选择转入部门！");
                    return;
                }

                string sSQL = "";
                long iID;
                long iIDDetail;
                long iVouNumber;

                //获得ID号
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


                //获得历史最大单据号
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
                //调拨申请单表头
                sSQL = "Insert Into @u8.ST_AppTransVouch(ctvcode,dtvdate,cowhcode,ciwhcode,codepcode,cidepcode,cirdcode,cordcode,cmaker,id,vt_id,iswfcontrolled) " +
                        "Values (N'" + sVouNumber + "', '" + Convert.ToDateTime( FrameBaseFunction.ClsBaseDataInfo.sLogDate) + "',N'" + sWhOut + "',N'" + sWhIn + "',N'" + sDepOut + "',N'" + sDepIn + "',N'" + sStypeIn + "',N'" + sStypeOut + "',N'" + FrameBaseFunction.ClsBaseDataInfo.sUid+ "'," + iID + ",37,0)";
                aList.Add(sSQL);

                bool b = true;
                for (int i = 0; i < dtExcel.Rows.Count; i++)
                {
                    if (dtExcel.Rows[i]["实发数量"] == null || dtExcel.Rows[i]["实发数量"].ToString().Trim() == string.Empty)
                    {
                        continue;
                    }
                    b = false;
                    iIDDetail += 1;
                    //调拨单表体
                    string sSQL1 = "Insert Into @u8.ST_AppTransVouchs(ctvcode,cinvcode,itvquantity,fsalecost,fsaleprice,autoid,id,iTvChkQuantity";
                    string sSQL2 = "Values(N'" + sVouNumber + "',N'" + dtExcel.Rows[i]["子件编码"].ToString().Trim() + "'," + dtExcel.Rows[i]["实发数量"].ToString().Trim() + ",0,0," + iIDDetail + "," + iID + "," + dtExcel.Rows[i]["实发数量"].ToString().Trim();

                    if (dtExcel.Rows[i]["实发件数"].ToString().Trim() != string.Empty)
                    {
                        sSQL1 = sSQL1 + ",iTVNum,iTVChkNum";
                        sSQL2 = sSQL2 + ",'" + dtExcel.Rows[i]["实发件数"].ToString().Trim() + "','" + dtExcel.Rows[i]["实发件数"].ToString().Trim() + "'";
                    }
                    sSQL = sSQL1 + ")" + sSQL2 + ")";

                    aList.Add(sSQL);
                }
                if (b)
                {
                    MessageBox.Show("没有数据需要导入，请检查！");
                    return;
                }

                sSQL = "update UFSystem..UA_Identity set iFatherID=" + iID + ",iChildID=" + iIDDetail + " where  cAcc_Id = '200' and cVouchType = 'at'";
                aList.Add(sSQL);

                //更新最大单据号
                if (iVouNumber == 1)
                {
                    sSQL = "insert into @u8.VoucherHistory(cardnumber,ccontent,ccontentrule,cseed,cnumber,bempty)values('0324','日期','月','" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyMM") + "','1',0)";
                    aList.Add(sSQL);
                }
                else
                {
                    sSQL = "update @u8.VoucherHistory set cNumber = '" + iVouNumber.ToString().Trim() + "' Where  CardNumber='0324' and cSeed='" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyMM") + "'  ";
                    aList.Add(sSQL);
                }

                clsSQLCommond.ExecSqlTran(aList);

                MessageBox.Show("数据导入成功！");
                gridControl1.DataSource = null;
            }
            catch (Exception ee)
            {
                MessageBox.Show("导入调拨申请单失败！\n    " + ee.Message);
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
                MessageBox.Show("加载窗体失败！原因：" + ee.Message);
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