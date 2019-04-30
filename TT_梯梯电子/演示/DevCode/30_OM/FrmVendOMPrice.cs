using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using FrameBaseFunction;

namespace OM
{
    public partial class FrmVendOMPrice : FrameBaseFunction.Frm列表窗体模板
    {
        public FrmVendOMPrice()
        {
            InitializeComponent();
        }

        private void FrmVendOMPrice_Load(object sender, EventArgs e)
        {
            try
            {
                SetConEnable(true);

                string sVend = GetUidVend();
                if (sVend == "all")
                {
                    txtVenCode.Enabled = true;
                }
                else
                {
                    txtVenCode.Enabled = false;
                    txtVenCode.Text = sVend;
                    txtVenCode_Leave(null, null);
                }


            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败！\n\t原因：" + ee.Message);
            }
        }

        private void GetGrid()
        {
            try
            {
                string sSQL = "Select distinct '' as bChoose,p.cinvcode,p.cInvName,p.cInvStd,Price,v.cInvcode as bAdd,DateEdit " +
                                "from  @u8.pu_veninvpricelst p left join UFDLImport..VendPrice v on p.cInvcode = v.cInvcode and p.cVenCode = v.vend and accid = 200 and accyear = " + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + " left join @u8.Inventory i on i.cInvCode = p.cinvcode " +
                                "Where p.cvencode = '" + txtVenCode.Text + "'  and isnull(bProxyForeign,0) = 1  " +
                                "order by p.cInvCode ";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                gridControl1.DataSource = dt;
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得列表失败! \n\n原因:\n  " + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void BtnClick(string sBtnName, string sBtnText)
        {
            try
            {
                switch (sBtnName.ToLower())
                {
                    case "sel":
                        btnSel();
                        break;
                    case "export":
                        btnExport();
                        break;
                    case "save":
                        btnSave();
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

        private void btnExport()
        {
            try
            {
                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "xls";
                sF.Filter = "Excel文件(*.xls)|*.xls|所有文件(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK == dRes)
                {
                    gridView1.ExportToXls(sF.FileName);
                    MessageBox.Show("导出Excel成功\n\t路径：" + sF.FileName);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnSel()
        {
            try
            {
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得列表失败！  " + ee.Message);
            }
        }

        private void btnSave()
        {
            try
            { 
                ArrayList aList = new ArrayList();
                string sSQL = "";

                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                DataTable dt = (DataTable)gridControl1.DataSource;
                for(int i=0;i<dt.Rows.Count;i++)
                {
                    if (dt.Rows[i]["bChoose"].ToString().Trim() != "√")
                        continue;

                    if(dt.Rows[i]["Price"].ToString().Trim() != string.Empty)
                    {
                        if (dt.Rows[i]["badd"].ToString().Trim().Length > 0)
                        {
                            sSQL = "update UFDLImport..VendPrice set Price = " + dt.Rows[i]["Price"].ToString().Trim() + ",DateEdit = '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "' " +
                                   "where cinvcode = '" + dt.Rows[i]["cInvcode"].ToString().Trim() + "' and vend = '" + txtVenCode.Text.ToString().Trim() + "' and accid = 200 and accyear = " + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4);
                        }
                        else
                        {
                            sSQL = "insert into UFDLImport..vendPrice(vend,cInvcode,price,remark,type,accid,accyear,DateEdit)values " +
                                    "('" + txtVenCode.Text.ToString().Trim() + "','" + dt.Rows[i]["cInvcode"].ToString().Trim() + "'," + dt.Rows[i]["price"].ToString().Trim() + ",'',1,200," + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + ",'" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "')";
                        }
                        aList.Add(sSQL);
                    }
                }

                if (aList.Count > 0)
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("保存成功！");
                    GetGrid();
                }
            }
            catch(Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }

        /// <summary>
        /// 获得当前帐号对应供应商
        /// </summary>
        /// <returns></returns>
        private string GetUidVend()
        {
            try
            {
                string s = "all";

                if (FrameBaseFunction.ClsBaseDataInfo.sUid.ToLower() == "admin")
                {
                    return s;
                }

                string sSQL = "select * from UFDLImport.._vendUid where uid = '" + FrameBaseFunction.ClsBaseDataInfo.sUid + "'  and accid =200 and accyear=" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + " ";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows.Count > 0)
                {
                    s = dt.Rows[0]["vendCode"].ToString().Trim();
                }

                if (s == string.Empty)
                {
                    s = "all";
                }

                return s;
            }
            catch (Exception ee)
            {
                throw new Exception("获得帐号供应商信息失败！\n\t原因：" + ee.Message);
            }
        }

        private void txtVenCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FrmVenInfo fVen = new FrmVenInfo(txtVenCode.Text.Trim());
            if (DialogResult.OK == fVen.ShowDialog())
            {
                txtVenCode.Text = fVen.sVenCode;
                txtVenName.Text = fVen.sVenName;
            }
        }

        private DataTable GetVendor(string sVenCode)
        {
            try
            {
                //TH.BaseForm.ClsGetSQL clsGetSQL = new TH.BaseForm.ClsGetSQL();
                string sSQL = "select cVenCode as iID,cVenName as iText from @u8.Vendor where cVenCode = '" + sVenCode + "' order by cVenCode";
                DataTable dt = clsGetSQL.GetLookUpEdit(sSQL);
                return dt;
            }
            catch
            {
                throw new Exception("获得供应商信息失败！");
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

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle < 0)
                return;
            if (e.Column == gridColPrice)
            {
                gridView1.SetRowCellValue(e.RowHandle, gridColbChoose, "√");
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                if (e.RowHandle >= 0)
                {
                    string s1 = gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["bChoose"]).ToString().Trim();
                    if (s1 == "√")
                    {
                        e.Appearance.BackColor = Color.MediumSeaGreen;
                    }
                }
            }
            catch
            { }
        }

        private void txtVenCode_Leave(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = GetVendor(txtVenCode.Text.Trim());
                if (dt != null && dt.Rows.Count > 0)
                {
                    txtVenName.Text = dt.Rows[0]["iText"].ToString().Trim();
                    GetGrid();
                }
                else
                {
                    txtVenCode.Text = "";
                    txtVenName.Text = "";
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得供应商信息失败！ " + ee.Message);
            }
        }
    }
}