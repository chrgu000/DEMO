using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace FrameBaseFunction
{
    public partial class FrmQC1 : FrameBaseFunction.Frm列表窗体模板
    {
        FrameBaseFunction.ClsDataBase clsSQL = FrameBaseFunction.ClsDataBaseFactory.Instance();

        public FrmQC1()
        {
            InitializeComponent();
        }


        private void FrmQCBase1_Load(object sender, EventArgs e)
        {
            try
            {
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败！" + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void BtnClick(string sBtnName, string sBtnText)
        {
            try
            {
                switch (sBtnName.ToLower())
                {
                    case "save":
                        btnSave();
                        break;
                    case "open":
                        btnOpen();
                        break; ;
                    case "close":
                        btnClose();
                        break;
                    case "edit":
                        btnEdit();
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

        private void btnEdit()
        {
            int iRow = gridView1.FocusedRowHandle;
            if (iRow < 0)
            {
                return;
            }

            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            ArrayList aList = new ArrayList();
            string sSQL = "update QCBase1 set vchrName = '" + gridView1.GetRowCellValue(iRow, gridColumn3).ToString().Trim() + "',vchrRemark='" + gridView1.GetRowCellValue(iRow, gridColumn4).ToString().Trim() + "' where vchrCode = '" + gridView1.GetRowCellValue(iRow, gridColumn2).ToString().Trim() + "'";
            aList.Add(sSQL);
            if (aList.Count > 0)
                clsSQL.ExecSqlTran(aList);


            GetGrid();

            try
            {
                gridView1.FocusedRowHandle = gridView1.RowCount - 1;
            }
            catch { }
        }

        private void btnOpen()
        {
            int iRow = gridView1.FocusedRowHandle;
            if (iRow < 0)
            {
                MessageBox.Show("请选择需要打开的行！");
                return;
            }

            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            ArrayList aList = new ArrayList();
            string sSQL = "update QCBase1 set bClose = 0 where vchrCode = '" + gridView1.GetRowCellValue(iRow, gridColumn2).ToString().Trim() + "' and accid = '200' and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "'";
            aList.Add(sSQL);
            if (aList.Count > 0)
                clsSQL.ExecSqlTran(aList);


            GetGrid();
            gridView1.FocusedRowHandle = iRow;
        }

        private void btnClose()
        {
            int iRow = gridView1.FocusedRowHandle;
            if (iRow < 0)
            {
                MessageBox.Show("请选择需要关闭的行！");
                return;
            }

            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            ArrayList aList = new ArrayList();
            string sSQL = "update QCBase1 set bClose = 1 where vchrCode = '" + gridView1.GetRowCellValue(iRow, gridColumn2).ToString().Trim() + "' and accid = '200' and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "'";
            aList.Add(sSQL);

            if (aList.Count > 0)
                clsSQL.ExecSqlTran(aList);


            GetGrid();
            gridView1.FocusedRowHandle = iRow;
        }

        private void GetGrid()
        {
            string sSQL = "select vchrCode,vchrName,vchrRemark,bClose,1 as bSave from dbo.QCBase1 where accid = '200' and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' ";
                
            if(!chkClose.Checked)
                sSQL = sSQL + " and isnull(bClose,0) = 0 order by vchrCode";
            gridControl1.DataSource = clsSQL.ExecQuery(sSQL);
            gridView1.AddNewRow();

            gridControl1.Select();
            gridView1.SelectRow(gridView1.RowCount - 1);
            gridView1.FocusedColumn = gridColumn2;
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
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, gridColumn1).ToString().Trim() != "1")
                    {
                        string sCode = gridView1.GetRowCellValue(i, gridColumn2).ToString().Trim();
                        string sName = gridView1.GetRowCellValue(i, gridColumn3).ToString().Trim();
                        string sRemark = gridView1.GetRowCellValue(i, gridColumn4).ToString().Trim();
                        if (sCode == string.Empty)
                            continue;

                        if (sName == string.Empty)
                        {
                            MessageBox.Show("名称不能为空！");
                            return;
                        }
                        string sSQL = "insert into QCBase1(vchrCode,vchrName,vchrRemark,bClose,accid,accyear)values('" + sCode + "','" + sName + "','" + sRemark + "',0,'200','" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "')";
                        aList.Add(sSQL);
                    }
                }

                if (aList.Count > 0)
                    clsSQL.ExecSqlTran(aList);


                GetGrid();
                gridView1.FocusedRowHandle = gridView1.RowCount - 1;
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }

        private void chkClose_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                GetGrid();
            }
            catch
            { 
            
            }
        }

     

        private void gridView1_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            try
            {
                int iRow = gridView1.FocusedRowHandle;
                if (iRow < 0)
                    return;

                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                if (e.FocusedColumn == gridColumn2 && gridView1.GetRowCellValue(iRow, gridColumn1).ToString().Trim() == "1")
                {
                    gridColumn2.OptionsColumn.AllowEdit = false;
                }
                else
                {
                    gridColumn2.OptionsColumn.AllowEdit = true;
                }
            }
            catch
            { }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                int iRow = gridView1.FocusedRowHandle;
                if (iRow < 0)
                    return;


                if (gridView1.FocusedColumn == gridColumn2 && gridView1.GetRowCellValue(e.FocusedRowHandle, gridColumn1).ToString().Trim() == "1")
                {
                    gridColumn2.OptionsColumn.AllowEdit = false;
                }
                else
                {
                    gridColumn2.OptionsColumn.AllowEdit = true;
                }
            }
            catch
            { }

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