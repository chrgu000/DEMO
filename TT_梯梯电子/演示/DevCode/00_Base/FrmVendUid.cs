using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using FrameBaseFunction;

namespace Base
{
    public partial class FrmVendUid : FrameBaseFunction.Frm列表窗体模板
    {
        public FrmVendUid()
        {
            InitializeComponent();
        }

        protected override void BtnClick(string sBtnName, string sBtnText)
        {
            try
            {
                switch (sBtnName.ToLower())
                {
                    case "refresh":
                        btnRefresh();
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

        private void btnRefresh()
        {
            GetGridView();
        }

        private void btnSave()
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }
                ArrayList aList = new ArrayList();
                string sSQL = "delete UFDLImport.._vendUid ";
                aList.Add(sSQL);
                
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    string sVen = gridView1.GetRowCellValue(i, gridColcvenCode).ToString().Trim();
                    if (sVen == string.Empty)
                    {
                        sVen = "null";
                    }
                    else
                    {
                        sVen = "'" + sVen + "'";
                    }
                    string sEMail = gridView1.GetRowCellValue(i, gridView1.Columns["sEMail"]).ToString().Trim();
                    if (sEMail == string.Empty)
                    {
                        sEMail = "null";
                    }
                    else
                    {
                        sEMail = "'" + sEMail + "'";
                    }
                    string bVend = gridView1.GetRowCellValue(i, gridView1.Columns["bVend"]).ToString().Trim();
                    if (bVend == "9")
                    {
                        sEMail = "null";
                    }
                    sSQL = "if exists (select * from UFDLImport.._vendUid where uid = '" + gridView1.GetRowCellValue(i, gridView1.Columns["vchrUid"]).ToString().Trim() + "') " +
                                "update UFDLImport.._vendUid set vendCode = " + sVen + ",seMail = " + sEMail + ",pOAduditGrade = " + gridView1.GetRowCellValue(i, gridView1.Columns["POAduditGrade"]).ToString().Trim() + " where uid = '" + gridView1.GetRowCellValue(i, gridView1.Columns["vchrUid"]).ToString().Trim() + "'  " +
                            "else " +
                                "insert into UFDLImport.._vendUid(uid,vendCode,sEMail,POAduditGrade,AccID,AccYear)values('" + gridView1.GetRowCellValue(i, gridView1.Columns["vchrUid"]).ToString().Trim() + "'," + sVen + "," + sEMail + "," + gridView1.GetRowCellValue(i, gridView1.Columns["POAduditGrade"]).ToString().Trim() + ",'200','" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "')";
                    aList.Add(sSQL);

                    sSQL = "update _UserInfo set cDepCode = '" + gridView1.GetRowCellValue(i, gridColcDepCode).ToString().Trim() + "' where vchrUid = '" + gridView1.GetRowCellValue(i, gridColvchrUid).ToString().Trim() + "' ";
                    aList.Add(sSQL);
                    //}
                }

                clsSQLCommond.ExecSqlTran(aList);

                int iRow = gridView1.FocusedRowHandle;

                GetGridView();

                gridView1.FocusedRowHandle = iRow;

                MessageBox.Show("保存成功！");
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }

        private void GetLookUpEditbVend()
        {
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.Caption = "编号";
            dc.ColumnName = "iID";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.Caption = "说明";
            dc.ColumnName = "iText";
            dt.Columns.Add(dc);

            DataRow dr = dt.NewRow();

            dr["iID"] = "9";
            dr["iText"] = "待设定";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["iID"] = "0";
            dr["iText"] = "员工";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["iID"] = "1";
            dr["iText"] = "供应商";
            dt.Rows.Add(dr);

            LookUpEditbVend.DataSource = dt;
        }

        private void FrmVendUid_Load(object sender, EventArgs e)
        {
            try
            {
                GetLookUpEditbVend();

                GetVendInfo();

                radioAll.Checked = true;

                GetGridView();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败！\n\t原因：" + ee.Message);
            }
        }

        private void GetGridView()
        {
            try
            {
                string sSQL = "select '' as bChoose,isnull(bVend,9) as bVend,vchrUid,vchrName,uid,cvenCode,cVenName,sEMail,isnull(POAduditGrade,0) as POAduditGrade,d.cDepCode,d.cDepName from _UserInfo left join UFDLImport.._vendUid on vchrUid=uid   left join @u8.vendor on cVenCode = vendCode left join @u8.Department d on d.cDepCode=_UserInfo.cDepCode ";

                sSQL = sSQL + " where 1=1 ";
                if(radioPer.Checked)
                {
                    sSQL = sSQL + "  and isnull(bVend,0) = 0 " ;
                }
                if (radioVen.Checked)
                {
                    sSQL = sSQL + "  and isnull(bVend,0) = 1 ";
                }

                sSQL = sSQL + "order by vchrUid";

                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                gridControl1.DataSource = dt;
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得供应商账号对照信息失败！\n\t原因：" + ee.Message);
            }
        }

        private void GetVendInfo()
        {
            try
            {
                string sSQL = "select cVenCode as iID,cVenName as iText,cVenAbbName from  @u8.Vendor order by cVenCode";

                DataTable dt = clsGetSQL.GetLookUpEdit(sSQL);
                LookUpEditVend.DataSource = dt;
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得供应商信息失败！\n\t原因：" + ee.Message);
            }
        }


        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.RowHandle < 0)
                    return;

                //gridView1.SetRowCellValue(e.RowHandle, gridColbChoose, "√");
                if (e.Column == gridColcvenCode)
                {
                    if (gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["cvenCode"]).ToString().Trim() == string.Empty)
                    {
                        gridView1.SetRowCellValue(e.RowHandle, gridColcVenName, "");
                    }
                    else
                    {
                        string sSQL = "select cVenCode,cVenName,cVenAbbName from  @u8.Vendor where cVenCode = '" + gridView1.GetRowCellValue(e.RowHandle, gridColcvenCode).ToString().Trim() + "'";
                        DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                        gridView1.SetRowCellValue(e.RowHandle, gridColcVenName, dt.Rows[0]["cVenName"].ToString().Trim());
                    }
                }
                if (e.Column == gridColcDepCode)
                {
                    string sSQL = "SELECT cDepCode AS iID, cDepName AS iText FROM @u8.Department WHERE bDepEnd =1 and cDepCode = '" + gridView1.GetRowCellValue(e.RowHandle, gridColcDepCode).ToString().Trim() + "' ORDER BY cDepCode ";
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        gridView1.SetRowCellValue(e.RowHandle, gridColcDepName, dt.Rows[0]["iText"]);
                    }
                    else
                    {
                        gridView1.SetRowCellValue(e.RowHandle, gridColcDepName, "");
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("设置供应商信息失败！\n\t原因：" + ee.Message);
            }
               
        }

        private void radioAll_CheckedChanged(object sender, EventArgs e)
        {
            GetGridView();
        }

        private void radioPer_CheckedChanged(object sender, EventArgs e)
        {
            GetGridView();
        }

        private void radioVen_CheckedChanged(object sender, EventArgs e)
        {
            GetGridView();
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

        private void ItemButtonEditDep_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int iRow = 0;
                if (gridView1.RowCount > 0)
                    iRow = gridView1.FocusedRowHandle;

                FrmBaseList fList = new FrmBaseList(1);
                fList.Text = "部门信息";
                if (fList.ShowDialog() == DialogResult.OK)
                {
                    gridView1.SetRowCellValue(iRow, gridColcDepCode, fList.sID);
                    gridView1.SetRowCellValue(iRow, gridColcDepName, fList.sText);
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            //try
            //{
            //    if (e.RowHandle >= 0)
            //    {
            //        string s1 = gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["bChoose"]).ToString().Trim();
            //        if (s1 == "√")
            //        {
            //            e.Appearance.BackColor = Color.MediumSeaGreen;
            //        }
            //    }
            //}
            //catch
            //{ }
        }
    }
}