using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using UFIDA.U8.UAP.CustomApp.ControlForm.Business;
using DevExpress.XtraEditors;
using System.Xml;
using System.Data.SqlClient;
using UFIDA.U8.UAP.CustomApp.MetaData;
using TH.BaseClass;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class Sa_Type : UserControl
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

        public Sa_Type()
        {
            InitializeComponent();
        }


        private void ProjectManager_Load(object sender, EventArgs e)
        {
            try
            {
                GetLookUp();
                gridView1.OptionsBehavior.Editable = true;
                //DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, "select * from _LookUpDate where iType='" + lookUpEdit类别.EditValue + "'").Tables[0];
                //grdDetail.DataSource = dt;
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载数据失败");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //grvDetail.OptionsBehavior.Editable = false;


            DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, "select * from _LookUpDate where iType='" + lookUpEdit类别.EditValue + "'").Tables[0];

            grdDetail.DataSource = dt;
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("没有任何数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void grvDetail_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {

            if (e.RowHandle < 0)
                return;
            e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    grvDetail.PostEditor();
            //    this.Validate();

            //    SaveFileDialog sa = new SaveFileDialog();
            //    sa.Filter = "Excel文件2003|*.xls";
            //    sa.FileName = "凭证";

            //    DialogResult d = sa.ShowDialog();
            //    if (d == DialogResult.OK)
            //    {
            //        string sPath = sa.FileName;

            //        if (sPath.Trim() != string.Empty)
            //        {
            //            grvDetail.ExportToXls(sPath);
            //            MessageBox.Show("导出列表成功！\n路径：" + sPath);
            //        }
            //    }
            //    grvDetail.OptionsBehavior.Editable = false;
            //}
            //catch (Exception ee)
            //{
            //    MessageBox.Show("导出列表失败：" + ee.Message);
            //}
        }

        private void GetLookUp()
        {
            try
            {
                DataTable dtss = SqlHelper.ExecuteDataset(Conn, CommandType.Text, "select iID,iType from _LookUpType").Tables[0];
                lookUpEdit类别.Properties.DataSource = dtss;

                DataTable dt = new DataTable();
                dt.Columns.Add("辅助核算");

                GetTable(dt, "客户");
                GetTable(dt, "部门");
                GetTable(dt, "物料");
                GetTable(dt, "业务员");

                ItemLookUpEditType.DataSource = dt;

                ItemLookUpSaleType.DataSource = SqlHelper.ExecuteDataset(Conn, CommandType.Text, "SELECT * from SaleType ").Tables[0];

                ItemLookUpInvcode.DataSource = SqlHelper.ExecuteDataset(Conn, CommandType.Text, "SELECT * from Inventory ").Tables[0];
            }

                

            catch (Exception ee)
            {
                MessageBox.Show("获得参照信息失败：" + ee.Message);
            }
        }

        private void GetTable(DataTable dt, string name)
        {
            DataRow dw = dt.NewRow();
            dw[0] = name;
            dt.Rows.Add(dw);
        }

           

        private void grvDetail_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }
            try
            {
                string sErr = "";
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, gridColiID).ToString().Trim() != "" || gridView1.GetRowCellValue(i, gridColiText).ToString().Trim() != "")
                    {
                        if (gridView1.GetRowCellValue(i, gridColiID).ToString().Trim() == "")
                        {
                            sErr = sErr + "行" + (i + 1) + gridColiID.Caption + "不可为空\n";
                        }
                        if (gridView1.GetRowCellValue(i, gridColiText).ToString().Trim() == "" )
                        {
                            sErr = sErr + "行" + (i + 1) + gridColiText.Caption + "不可为空\n";
                        }

                        for (int j = 0; j < i; j++)
                        {
                            if (lookUpEdit类别.EditValue.ToString() != "4")
                            {
                                if (gridView1.GetRowCellValue(i, gridColiText).ToString().Trim() == (gridView1.GetRowCellValue(j, gridColiText).ToString().Trim()))
                                {
                                    sErr = sErr + "行" + (i + 1) + gridColiText.Caption + "不可重复的\n";
                                    continue;
                                }
                            }
                            else
                            {
                                if (gridView1.GetRowCellValue(i, gridColiText).ToString().Trim() == (gridView1.GetRowCellValue(j, gridColiText).ToString().Trim()) && gridView1.GetRowCellValue(i, gridColiID).ToString().Trim() == (gridView1.GetRowCellValue(j, gridColiID).ToString().Trim()))
                                {
                                    sErr = sErr + "行" + (i + 1) + gridColiText.Caption + "不可重复的\n";
                                    continue;
                                }
                            }
                        }
                    }
                    
                }
                if (sErr == "")
                {
                    SqlConnection conn = new SqlConnection(Conn);
                    conn.Open();
                    //启用事务
                    SqlTransaction tran = conn.BeginTransaction();
                    try
                    {
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, "delete from _LookUpDate where iType='" + lookUpEdit类别.EditValue.ToString() + "'");


                        for (int i = 0; i < gridView1.RowCount; i++)
                        {
                            if (lookUpEdit类别.EditValue.ToString() != "5" && gridView1.GetRowCellValue(i, gridColiID).ToString().Trim() != "" && gridView1.GetRowCellValue(i, gridColiText).ToString().Trim() != "")
                            {
                                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, "insert into _LookUpDate(iType,iID,iText,Remark) values('" + lookUpEdit类别.EditValue.ToString() + "','" + gridView1.GetRowCellValue(i, gridColiID).ToString().Trim() + "','" + gridView1.GetRowCellValue(i, gridColiText).ToString().Trim() + "','" + gridView1.GetRowCellValue(i, gridColRemark).ToString().Trim() + "')");
                            }
                            else if (lookUpEdit类别.EditValue.ToString() == "5" && gridView1.GetRowCellValue(i, gridColiText).ToString().Trim() != "")
                            {
                                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, "insert into _LookUpDate(iType,iID,iText,Remark) values('" + lookUpEdit类别.EditValue.ToString() + "','" + gridView1.GetRowCellValue(i, gridColiID).ToString().Trim() + "','" + gridView1.GetRowCellValue(i, gridColiText).ToString().Trim() + "','" + gridView1.GetRowCellValue(i, gridColRemark).ToString().Trim() + "')");
                            }

                        }
                        MessageBox.Show("保存成功");

                        tran.Commit();
                    }

                    catch (Exception error)
                    {
                        tran.Rollback();
                        throw new Exception(error.Message);
                    }
                }
                else
                {
                    MessageBox.Show(sErr);
                }
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }



        private void grvDetail_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {

        }

        private void grvDetail_DoubleClick(object sender, EventArgs e)
        {

        }

        private void ItemTextEditN2_DoubleClick(object sender, EventArgs e)
        {
            grvDetail_DoubleClick(null, null);
        }

        private void ItemTextEditN2_Enter(object sender, EventArgs e)
        {
            TextEdit item = sender as TextEdit;
            item.SelectAll();
            Application.DoEvents();
        }

        private void lookUpEdit类别_EditValueChanged(object sender, EventArgs e)
        {
            DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, "select * from _LookUpDate where iType='" + lookUpEdit类别.EditValue + "'").Tables[0];
            grdDetail.DataSource = dt;
            if (lookUpEdit类别.EditValue.ToString() == "1" || lookUpEdit类别.EditValue.ToString() == "2" || lookUpEdit类别.EditValue.ToString() == "3")
            {
                //gridColiID.Caption = "会计科目";
                gridColiText.Caption = "销售类型";
                gridColiText.ColumnEdit = ItemLookUpSaleType;
                //gridColiID.Visible = true;
                //gridColiText.Visible = true;
            }
            else if (lookUpEdit类别.EditValue.ToString() == "4")
            {
                //gridColiID.Caption = "会计科目";
                gridColiText.Caption = "辅助核算";
                gridColiText.ColumnEdit = ItemLookUpEditType;
                //gridColiID.Visible = true;
                //gridColiText.Visible = true;
            }
            else if (lookUpEdit类别.EditValue.ToString() == "5")
            {
                gridColiText.Caption = "销售折让存货编码";
                gridColiText.ColumnEdit = ItemLookUpInvcode;
                //gridColiID.Visible = false;
                //gridColiText.Visible = true;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            gridView1.AddNewRow();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            for (int i = gridView1.RowCount - 1; i >= 0; i--)
            {
                if (gridView1.IsRowSelected(i))
                {
                    gridView1.DeleteRow(i);
                }
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == gridColiText && e.RowHandle == gridView1.RowCount - 1)
            {
                gridView1.AddNewRow();
            }
        }


    }
}