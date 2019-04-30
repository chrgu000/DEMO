using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;
using 系统服务;
using System.Data.SqlClient;

namespace 业务
{
    public partial class Frm工作台测量数据列表 : 系统服务.FrmBaseInfo
    {
        public Frm工作台测量数据列表()
        {

            InitializeComponent();

        

            sLayoutHeadPath = base.sProPath + "\\layout\\" + this.Text.Trim() + "Head.xml";
            sLayoutGridPath = base.sProPath + "\\layout\\" + this.Text.Trim() + "Grid.xml";

            if (File.Exists(sLayoutHeadPath))
                layoutControl1.RestoreLayoutFromXml(sLayoutHeadPath);

         
            dtBingGrid = new DataTable();
            dtBingHead = new DataTable();
        }

       

        #region 按钮操作
        protected override void BtnClick(string sBtnName, string sBtnText)
        {
            try
            {
                switch (sBtnName.ToLower())
                {
                    case "addrow":
                        btnAddRow();
                        break;
                    case "alter":
                        btnAlter();
                        break;
                    case "audit":
                        btnAudit();
                        break;
                    case "del":
                        btnDel();
                        break;
                    case "delrow":
                        btnDelRow();
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
                    case "import":
                        btnImport();
                        break;
                    case "last":
                        btnLast();
                        break;
                    case "lock":
                        btnLock();
                        break;
                    case "next":
                        btnNext();
                        break;
                    case "prev":
                        btnPrev();
                        break;
                    case "print":
                        btnPrint();
                        break;
                    //case "printset":
                    //    btnPrintSet();
                    //    break;
                    case "refresh":
                        btnRefresh();
                        break;
                    case "save":
                        btnSave();
                        break;
                    case "sel":
                        btnSel();
                        break;
                    case "unaudit":
                        btnUnAudit();
                        break;
                    case "undo":
                        btnUnDo();
                        break;
                    case "unlock":
                        btnUnLock();
                        break;
                    case "open":
                        btnOpen();
                        break;
                    case "close":
                        btnClose();
                        break;
                    case "layout":
                        btnLayout(sBtnText);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ee)
            {
                throw new Exception(sBtnText + " 失败! \n\n原因:\n  " + ee.Message);
            }
        }


        #region 按钮模板

        /// <summary>
        /// 将表格中Lookup之类的保存ID的数据转换成Text用于打印
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private DataTable SetPrintData(DataTable dt)
        {
            return dt;
        }

        /// <summary>
        /// 打印
        /// </summary>
        private void btnPrint()
        {
          
        }
        /// <summary>
        /// 输出
        /// </summary>
        private void btnExport()
        {
            try
            {
                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "xls";
                sF.FileName = this.Text;
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
                throw new Exception(ee.Message);
            }
          
        }

        private void btnLayout(string sText)
        {
            
        }
        #endregion

        /// <summary>
        /// 导入
        /// </summary>
        private void btnImport()
        {
            //if (dtmStart.EditValue != DBNull.Value)
            //{
            //    dtmStart.EditValue = DBNull.Value;
            //    labelStatus.Text = "暂停";

            //    for (int i = 0; i < this.toolStripMenuBtn.Items.Count; i++)
            //    {
            //        if (this.toolStripMenuBtn.Items[i].Text == "暂停")
            //        {
            //            this.toolStripMenuBtn.Items[i].Text = "取消暂停";
            //            break;
            //        }
            //    }
            //}
            //else
            //{
            //    sSQL = @"select getdate()";
            //    DataTable dt = DbHelperSQL.Query(sSQL);
            //    dtmStart.EditValue = BaseFunction.ReturnDate(dt.Rows[0][0]);
            //    labelStatus.Text = "开始";
            //    for (int i = 0; i < this.toolStripMenuBtn.Items.Count; i++)
            //    {
            //        if (this.toolStripMenuBtn.Items[i].Text == "取消暂停")
            //        {
            //            this.toolStripMenuBtn.Items[i].Text = "暂停";
            //            break;
            //        }
            //    }
            //}
        }
        /// <summary>
        /// 刷新
        /// </summary>
        private void btnRefresh()
        {
            try
            {
                GetGrid();
            }
            catch (Exception ee)
            {
                throw new Exception("刷新窗体失败\n" + ee.Message);
            }
        }
        /// <summary>
        /// 查询
        /// </summary>
        private void btnSel()
        {
            //GetGrid();
        }
        /// <summary>
        /// 首页
        /// </summary>
        private void btnFirst()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 上页
        /// </summary>
        private void btnPrev()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 下页
        /// </summary>
        private void btnNext()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 末页
        /// </summary>
        private void btnLast()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 锁定
        /// </summary>
        private void btnLock()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 解锁
        /// </summary>
        private void btnUnLock()
        {
            throw new NotImplementedException();
        }

        string 批次;
        /// <summary>
        /// 增行
        /// </summary>
        private void btnAddRow()
        {
           
            
        }
        /// <summary>
        /// 删行
        /// </summary>
        private void btnDelRow()
        {

        }
        /// <summary>
        /// 修改
        /// </summary>
        private void btnEdit()
        {
            SetEnable(true);
        }
        /// <summary>
        /// 删除
        /// </summary>
        private void btnDel()
        {
           
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                string sErr = "";
                int iCou = 0;

                if (DialogResult.Yes != MessageBox.Show("确定删除选中的数据么？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk))
                {
                    throw new Exception("取消操作");
                }

                SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (!BaseFunction.ReturnBool(gridView1.GetRowCellValue(i, gridColSelected)))
                        {
                            continue;
                        }

                        decimal d测量值 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol测量值));
                        string s备注 = gridView1.GetRowCellValue(i, gridCol备注).ToString().Trim();
                        long lID = BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridColiID));

                        if (d测量值 <= 0)
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + " 测量值不正确\n";
                            continue;
                        }
                        if (lID <= 0)
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + " 序号不正确\n";
                            continue;
                        }

                        sSQL = @"
update 工作台测量 set 删除人 = '{0}',删除日期 = getdate() where iID = {1}
                        ";
                        sSQL = string.Format(sSQL, sUserName, lID);
                        iCou += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    }

                    tran.Commit();
                    if (iCou > 0)
                    {
                        MessageBox.Show("删除成功");
                    }

                    GetGrid();
                }
                catch (Exception ee)
                {
                    tran.Rollback();

                    throw new Exception(ee.Message);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
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

                string sErr = "";
                int iCou = 0;

                SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if(!BaseFunction.ReturnBool(gridView1.GetRowCellValue(i,gridColSelected)))
                        {
                        continue;
                        }

                        decimal d测量值 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i,gridCol测量值));
                        string s备注 = gridView1.GetRowCellValue(i,gridCol备注).ToString().Trim();
                        long lID = BaseFunction.ReturnLong(gridView1.GetRowCellValue(i,gridColiID));

                        if (d测量值 <= 0)
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + " 测量值不正确\n";
                            continue;
                        }
                        if (lID <= 0)
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + " 序号不正确\n";
                            continue;
                        }

                        sSQL = @"
update 工作台测量 set 测量值 = {0},备注 = N'{1}' where iID = {2}
                        ";
                        sSQL = string.Format(sSQL, d测量值, s备注, lID);
                        iCou += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    }

                    if (iCou > 0)
                    {
                        MessageBox.Show("保存成功");
                    }
                        tran.Commit();


                        GetGrid();
                    
                }
                catch (Exception ee)
                {
                    tran.Rollback();

                    throw new Exception(ee.Message);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
            
        }
        /// <summary>
        /// 撤销
        /// </summary>
        private void btnUnDo()
        {
            //GetGrid();
        }
        /// <summary>
        /// 审核
        /// </summary>
        private void btnAudit()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 弃审
        /// </summary>
        private void btnUnAudit()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 打开
        /// </summary>
        private void btnOpen()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 关闭
        /// </summary>
        private void btnClose()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 变更
        /// </summary>
        private void btnAlter()
        {
            throw new NotImplementedException();
        }

        #endregion

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                SetLookup();

                dateEdit单据日期1.Enabled = true;
                dateEdit单据日期2.Enabled = true;

            }
            catch (Exception ee)
            {
                MsgBox("加载窗体失败", ee.Message);
            }
        }
      

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            try
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
            catch { }
        }


        private void SetLookup()
        {
            string sSQL = @"
select distinct 检验工位 from [发射器档案设置] order by 检验工位
";
            DataTable dt = DbHelperSQL.Query(sSQL);
            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            lookUpEdit检验工位.Properties.DataSource = dt;

            sSQL = @"select getdate()";
            dt = DbHelperSQL.Query(sSQL);

            dateEdit单据日期1.DateTime = BaseFunction.ReturnDate(dt.Rows[0][0]).AddDays(-1);
            dateEdit单据日期2.DateTime = BaseFunction.ReturnDate(dt.Rows[0][0]);
        }



        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                if (gridView1.GetRowCellValue(e.RowHandle, gridCol测量值).ToString().Trim() != "")
                {
                    decimal dMin = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridCol下限));
                    decimal dMax = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridCol上限));
                    if (dMax == 0)
                    {
                        dMax = 9999999999;
                    }

                    decimal d测量值 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridCol测量值));

                    if (d测量值 > dMax || d测量值 < dMin)
                    {
                        e.Appearance.BackColor = Color.Tomato;
                    }
                }
            }
            catch (Exception ee)
            { }
        }



        private void GetGrid()
        {
            int iFoc = gridView1.FocusedRowHandle;
            string sSQL = @"
select *,cast(0 as bit) as Selected 
from  工作台测量 
where 1=1 and isnull(删除人,'') = ''
order by iID desc
";
            if (lookUpEdit检验工位.EditValue != null && lookUpEdit检验工位.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and 工作台 = '" + lookUpEdit检验工位.Text.Trim() + "'");
            }
            if (dateEdit单据日期1.Text != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and 检验时间 >= '" + dateEdit单据日期1.DateTime.ToString("yyyy-MM-dd") + "'");
            }
            if (dateEdit单据日期2.Text != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and 检验时间 < '" + dateEdit单据日期2.DateTime.AddDays(1).ToString("yyyy-MM-dd") + "'");
            }
            if (txt检验员.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and 检验员 = '" + txt检验员.Text.Trim() + "'");
            }
            DataTable dt = DbHelperSQL.Query(sSQL);
            gridControl1.DataSource = dt;
            gridView1.FocusedRowHandle = iFoc;

            SetEnable(false);

        }


        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column != gridColSelected && !BaseFunction.ReturnBool(gridView1.GetRowCellValue(e.RowHandle, gridColSelected)))
                {
                    gridView1.SetRowCellValue(e.RowHandle, gridColSelected, true);
                }
            }
            catch { }
        }

        private void SetEnable(bool b)
        {
            gridColSelected.OptionsColumn.AllowEdit = b;
            gridCol测量值.OptionsColumn.AllowEdit = b;
        }
    }
}
