using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
//using UFIDA.U8.UAP.CustomApp.ControlForm.Business;
using DevExpress.XtraEditors;
using System.Xml;
using System.Data.SqlClient;
using System.IO;


namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class 存货标签打印 : UserControl
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

        string sState = "";

        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }

        public 存货标签打印()
        {
            InitializeComponent();

            sPrintLayOutMod = sProPath + "\\UAP\\Runtime\\print\\Model\\" + this.labelControl1.Text.Trim() + "Mod.dll";
            sPrintLayOutUser = sProPath + "\\UAP\\Runtime\\print\\User\\" + this.labelControl1.Text.Trim() + "User.dll";
        }


        private void ProjectManager_Load(object sender, EventArgs e)
        {
            try
            {

                GetLookUp();

                if (sUserID == "admin" || sUserID == "system" || sUserID == "demo")
                {
                    btnPrintSET.Visible = true;
                }
                else
                {
                    btnPrintSET.Visible = false;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载数据失败");
            }
        }

        private void GetLookUp()
        {
            string sSQL = "select * from Inventory order by cInvCode";
            DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
            ItemLookUpEdit存货编码.DataSource = dt;
            ItemLookUpEdit存货名称.DataSource = dt;
            ItemLookUpEdit规格型号.DataSource = dt;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSel_Click(object sender, EventArgs e)
        {
            try
            {
                chk全选.Checked = false;

                //string sSQL2 = "select getdate()";
                //DateTime d当前日期 = Convert.ToDateTime(SqlHelper.ExecuteScalar(Conn, CommandType.Text, sSQL2));
                //DateTime d时间锁 = Convert.ToDateTime("2013-12-25");

                string sSQL = @"
select CAST(0 as bit) as 选择, a.cInvCode as 存货编码
	,cast(null as varchar(50)) as 长度 
    ,b.cInvCCode as 存货分类编码,b.cInvCName as 存货分类,isnull(a.bInvBatch,0)  as 是否批次管理,isnull(bFree1 ,0) as 是否长度必输
    ,cast(null as varchar(50)) as 条形码, cast(null as varchar(50)) as  长度, cast(null as varchar(50)) as 批号, cast(null as varchar(50)) as 炉号
    ,cast(null as varchar(50)) as  数量, cast(null as varchar(50)) as 保存人, cast(null as varchar(50)) as 保存日期, cast(null as varchar(50)) as 打印次数
    ,cast(null as varchar(50)) as 最后一次打印人, cast(null as varchar(50)) as 最后一次打印日期, cast(null as varchar(50)) as 条码单据号, cast(null as varchar(50)) as 修改人, cast(null as varchar(50)) as 修改日期 
    ,cast(null as varchar(50)) as 关闭人, cast(null as varchar(50)) as 关闭日期
from Inventory a inner join InventoryClass b on a.cInvCCode = b.cInvCCode
where 1=1
order by a.cInvCode
";

                string s存货编码条件 = "1=1";
                if (txt存货编码.Text.Trim() != "")
                {
                    if (cmb存货编码.Text.Trim() == "like")
                    {
                        s存货编码条件 = "1=1 and  (a.cInvCode like '%" + txt存货编码.Text.Trim() + "%' or a.cInvName like '%" + txt存货编码.Text.Trim() + "%' )";
                    }
                    else
                    {
                        s存货编码条件 = "1=1 and  (a.cInvCode " + cmb存货编码.Text.Trim() + " '" + txt存货编码.Text.Trim() + "' or a.cInvName " + cmb存货编码.Text.Trim() + " '" + txt存货编码.Text.Trim() + "' )";
                    }
                }
                sSQL = sSQL.Replace("1=1", s存货编码条件);

                string s存货分类条件 = "1=1";
                if (txt存货分类.Text.Trim() != "")
                {
                    if (cmb存货分类.Text.Trim() == "like")
                    {
                        s存货分类条件 = "1=1 and  (b.cInvCCode like '%" + txt存货分类.Text.Trim() + "%' or b.cInvCName like '%" + txt存货分类.Text.Trim() + "%' )";
                    }
                    else
                    {
                        s存货分类条件 = "1=1 and  (b.cInvCCode " + cmb存货分类.Text.Trim() + " '" + txt存货分类.Text.Trim() + "' or b.cInvCName " + cmb存货分类.Text.Trim() + " '" + txt存货分类.Text.Trim() + "' )";
                    }
                }
                sSQL = sSQL.Replace("1=1", s存货分类条件);

                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];

                grdDetail.DataSource = dt;

                sState = "sel";
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
                gridView1.PostEditor();
                this.Validate();

                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "xls";
                sF.FileName = labelControl1.Text.Trim();
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
                MessageBox.Show("导出列表失败：" + ee.Message);
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

        private decimal ReturnObjectToDecimal(object o, int i)
        {
            decimal d = 0;
            try
            {
                d = Convert.ToDecimal(o);
                d = decimal.Round(d, i);
            }
            catch
            { }
            return d;
        }

        private double ReturnObjectToDouble(object o)
        {
            double d = 0;
            try
            {
                d = Convert.ToDouble(o);
            }
            catch
            { }
            return d;
        }

        private void chk全选_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                gridView1.SetRowCellValue(i, gridCol选择, chk全选.Checked);
            }
        }

        private void tsbClearCon_Click(object sender, EventArgs e)
        {
            txt存货编码.Text = ""; 
            txt存货分类.Text = "";
            dtm1.Text = "";
            dtm2.Text = "";
            chk包含已关闭.Checked = false;
            chk全选.Checked = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                if (sState != "sel" && sState != "history")
                {
                    throw new Exception("必须先过滤数据或者未打印的历史数据才能保存");
                }

                string sErr = "";

                bool b是否保存 = false;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (Convert.ToBoolean(gridView1.GetRowCellValue(i, gridCol选择)))
                    {
                        bool b是否批次管理 = Convert.ToBoolean(gridView1.GetRowCellValue(i, gridCol是否批次管理));
                        if (b是否批次管理)
                        {
                            string s批号 = gridView1.GetRowCellValue(i, gridCol批号).ToString().Trim();
                            if (s批号 == "")
                            {
                                sErr = sErr + "行" + (i + 1).ToString() + "批号不能为空\n";
                            }
                        }
                        bool b是否长度必输 = Convert.ToBoolean(gridView1.GetRowCellValue(i, gridCol是否长度必输));
                        if (b是否长度必输)
                        {
                            string s长度 = gridView1.GetRowCellValue(i, gridCol长度).ToString().Trim();
                            if (s长度 == "")
                            {
                                sErr = sErr + "行" + (i + 1).ToString() + "长度不能为空\n";
                            }
                        }

                        decimal d数量 = ClsDataFormat.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol数量));
                        if (d数量 <= 0)
                            sErr = sErr + "行" + (i + 1).ToString() + "数量必须大于0\n";

                        b是否保存 = true;

                        if (sState == "history")
                        {
                            if (ClsDataFormat.ReturnInt(gridView1.GetRowCellValue(i, gridCol打印次数)) != 0)
                            {
                                sErr = sErr + "行" + (i + 1).ToString() + "已经打印不能修改\n";
                            }
                        }
                    }
                }
                if (sErr.Trim().Length > 0)
                {
                    throw new Exception(sErr);
                }

                if (!b是否保存)
                {
                    throw new Exception("没有选中需要保存的数据");
                }


                string sSQL2 = "select getdate()";
                DateTime d当前日期 = Convert.ToDateTime(SqlHelper.ExecuteScalar(Conn, CommandType.Text, sSQL2));
                string s条码单据号 = d当前日期.ToString("yyyyMMddHHmmss");

                string sGuid = Guid.NewGuid().ToString().Trim();

                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (Convert.ToBoolean(gridView1.GetRowCellValue(i, gridCol选择)))
                        {
                            if (sState == "sel")
                            {
                                string sSQL = "INSERT INTO [条形码信息]([存货编码] ,[长度],[批号] ,[炉号] ,[数量] " +
                                                  ",[保存人]  ,[保存日期],[打印次数] " +
                                                  " ,[最后一次打印人]  ,[最后一次打印日期],条码单据号,guid) " +
                                              " VALUES ('" + gridView1.GetRowCellValue(i, gridCol存货编码).ToString().Trim() + "','" + gridView1.GetRowCellValue(i, gridCol长度).ToString().Trim() + "','" + gridView1.GetRowCellValue(i, gridCol批号).ToString().Trim() + "','" + gridView1.GetRowCellValue(i, gridCol炉号).ToString().Trim() + "'," + ClsDataFormat.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol数量)) + " " +
                                                    ",'" + sUserID + "',getdate(),0" +
                                                    ",null,null,'" + s条码单据号 + "','" + sGuid + "')";
                                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                            }
                            else
                            {
                                string sSQL = "update 条形码信息 set 长度 = '" + gridView1.GetRowCellValue(i, gridCol长度).ToString().Trim() + "',批号 = '" + gridView1.GetRowCellValue(i, gridCol批号).ToString().Trim() + "'" +
                                                        ",炉号 = '" + gridView1.GetRowCellValue(i, gridCol炉号).ToString().Trim() + "',数量 = " + ClsDataFormat.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol数量)) + " " +
                                                        ",修改人 = '" + sUserID + "',修改日期 = getdate() " +
                                                        "where 条形码 = '" + gridView1.GetRowCellValue(i, gridCol条形码).ToString().Trim() + "'";
                                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                            }

                        }
                    }

                    tran.Commit();

                    GetGrid();

                    sState = "save";
                }
                catch (Exception error)
                {
                    tran.Rollback();
                    throw new Exception(error.Message);
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox msgBox = new FrmMsgBox();
                msgBox.richTextBox1.Text = ee.Message;
                msgBox.Text = "保存失败";
                msgBox.ShowDialog();
            }
        }

        private void gridView1_Click(object sender, EventArgs e)
        {

        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            try
            {
                GetGrid();

                sState = "history";
            }
            catch (Exception ee)
            {
                FrmMsgBox msgBox = new FrmMsgBox();
                msgBox.richTextBox1.Text = ee.Message;
                msgBox.Text = "保存失败";
                msgBox.ShowDialog();
            }
        }


        private void GetGrid()
        {
            chk全选.Checked = false;

            string sSQL = @"
select cast(0 as bit) as 选择, a.*,c.cInvCCode as 存货分类编码, c.cInvCName as 存货分类 
from [条形码信息] a inner join Inventory b on a.存货编码 = b.cInvCode inner join InventoryClass c on b.cInvCCode = c.cInvCCode
where  1=1    
";
           
            if (dtm1.Text.Trim().Length > 0)
            {
                sSQL = sSQL + " and a.保存日期 >= '" + dtm1.DateTime.ToString("yyyy-MM-dd") + "' ";
            }
            if (dtm2.Text.Trim().Length > 0)
            {
                sSQL = sSQL + " and a.保存日期 <= '" + dtm2.DateTime.AddDays(1).ToString("yyyy-MM-dd") + "' ";
            }

            sSQL = sSQL + " order by a.条形码";

            string s存货编码条件 = "1=1";
            if (txt存货编码.Text.Trim() != "")
            {
                if (cmb存货编码.Text.Trim() == "like")
                {
                    s存货编码条件 = "1=1 and  (b.cInvCode like '%" + txt存货编码.Text.Trim() + "%' or b.cInvName like '%" + txt存货编码.Text.Trim() + "%' )";
                }
                else
                {
                    s存货编码条件 = "1=1 and  (b.cInvCode " + cmb存货编码.Text.Trim() + " '" + txt存货编码.Text.Trim() + "' or b.cInvName " + cmb存货编码.Text.Trim() + " '" + txt存货编码.Text.Trim() + "' )";
                }
            }
            sSQL = sSQL.Replace("1=1", s存货编码条件);

            string s存货分类条件 = "1=1";
            if (txt存货分类.Text.Trim() != "")
            {
                if (cmb存货分类.Text.Trim() == "like")
                {
                    s存货分类条件 = "1=1 and  (b.cInvCCode like '%" + txt存货分类.Text.Trim() + "%' or b.cInvCName like '%" + txt存货分类.Text.Trim() + "%' )";
                }
                else
                {
                    s存货分类条件 = "1=1 and  (b.cInvCCode " + cmb存货分类.Text.Trim() + " '" + txt存货分类.Text.Trim() + "' or b.cInvCName " + cmb存货分类.Text.Trim() + " '" + txt存货分类.Text.Trim() + "' )";
                }
            }
            sSQL = sSQL.Replace("1=1", s存货分类条件);

            if (!chk包含已关闭.Checked)
            {
                sSQL = sSQL.Replace("1=1", " 1=1 and isnull(a.关闭人,'') = '' ");
            }
            if (!chk包含已打印.Checked)
            {
                sSQL = sSQL.Replace("1=1", " 1=1 and isnull(a.打印次数,0) = 0 ");
            }

            DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
            grdDetail.DataSource = dt;
        }


        private string ReturnBarCode(string sBarCode)
        {
            for (int i = 0; i <= 10; i++)
            {
                if (sBarCode.Trim().Length < 10)
                    sBarCode = "0" + sBarCode;
                else
                    break;
            }
            return sBarCode;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                if (sState != "history" && sState != "save" && sState != "print")
                {
                    throw new Exception("必须是新保存的条码，或者历史条码才能打开");
                }

                      SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (Convert.ToBoolean(gridView1.GetRowCellValue(i, gridCol选择)))
                        {
                            string sSQL = "update 条形码信息 set 关闭人 = null,关闭日期 = null where 条形码 = " + gridView1.GetRowCellValue(i, gridCol条形码).ToString().Trim();
                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        } 
                    }
                    tran.Commit();
                    GetGrid();
                }
                catch (Exception error)
                {
                    tran.Rollback();
                    throw new Exception(error.Message);
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox msgBox = new FrmMsgBox();
                msgBox.richTextBox1.Text = ee.Message;
                msgBox.Text = "打开失败";
                msgBox.ShowDialog();
            }
        }

        private void btnClosed_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }


                if (sState != "history" && sState != "save" && sState != "print")
                {
                    throw new Exception("必须是新保存的条码，或者历史条码才能关闭");
                }

                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (Convert.ToBoolean(gridView1.GetRowCellValue(i, gridCol选择)))
                        {
                            string sSQL = "update 条形码信息 set 关闭人 = '" + sUserID + "',关闭日期 = getdate() where 条形码 = " + gridView1.GetRowCellValue(i, gridCol条形码).ToString().Trim();
                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                    }
                    tran.Commit();
                    GetGrid();
                }
                catch (Exception error)
                {
                    tran.Rollback();
                    throw new Exception(error.Message);
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox msgBox = new FrmMsgBox();
                msgBox.richTextBox1.Text = ee.Message;
                msgBox.Text = "关闭失败";
                msgBox.ShowDialog();
            }
        }

        #region 设置打印模板

        private void btnPrintSET_Click(object sender, EventArgs e)
        {
            bool bMod = false;
            if (sUserID == "admin" || sUserID == "system" || sUserID == "demo")
            {
                bMod = true;
            }

            if (!Directory.Exists(sProPath + "\\UAP\\Runtime\\print"))
                Directory.CreateDirectory(sProPath + "\\UAP\\Runtime\\print");
            if (!Directory.Exists(sProPath + "\\UAP\\Runtime\\print\\Model"))
                Directory.CreateDirectory(sProPath + "\\UAP\\Runtime\\print\\Model");
            if (!Directory.Exists(sProPath + "\\UAP\\Runtime\\print\\User"))
                Directory.CreateDirectory(sProPath + "\\UAP\\Runtime\\print\\User");

            if (bMod)
            {
                if (File.Exists(sPrintLayOutMod))
                {
                    Rep.LoadLayout(sPrintLayOutMod);
                }
            }
            else
            {
                if (File.Exists(sPrintLayOutUser))
                {
                    Rep.LoadLayout(sPrintLayOutUser);
                }
                else if (File.Exists(sPrintLayOutMod))
                {
                    Rep.LoadLayout(sPrintLayOutMod);
                }
            }

            Rep.ShowDesignerDialog();

            DialogResult d = MessageBox.Show("是否保存?模板调整将在下次打开窗体时体现\n是：保存打印模板\n否：恢复默认打印模板\n", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
            if (DialogResult.Yes == d)
            {
                if (bMod)
                {
                    Rep.SaveLayoutToXml(sPrintLayOutMod);
                }
                else
                {
                    Rep.SaveLayoutToXml(sPrintLayOutUser);
                }
            }
            else if (DialogResult.No == d)
            {
                if (File.Exists(sPrintLayOutUser))
                {
                    File.Delete(sPrintLayOutUser);
                }
            }
        }

        
        protected string sProPath = Application.StartupPath;    //程序执行位置
        string sPrintLayOutMod;
        string sPrintLayOutUser;
        RepBaseGrid Rep = new RepBaseGrid();
        DataSet dsPrint = new DataSet();          //打印模板数据源



        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                Rep = new RepBaseGrid();
                if (File.Exists(sPrintLayOutUser))
                {
                    Rep.LoadLayout(sPrintLayOutUser);
                }
                else if (File.Exists(sPrintLayOutMod))
                {
                    Rep.LoadLayout(sPrintLayOutMod);
                }
                else
                {
                    MessageBox.Show("加载报表模板失败，请与管理员联系");
                    return;
                }
                Rep.dsPrint.Tables["dtHead"].Rows.Clear();
                Rep.dsPrint.Tables["dtHead"].Columns.Clear();
                //设置报表表头数据表列
                //try
                //{
                //    for (int i = 0; i < this.dsPrint.Tables["dtHead"].Columns.Count; i++)
                //    {
                //        DataColumn dc = new DataColumn();
                //        dc = this.dsPrint.Tables["dtHead"].Columns[i];
                //        DataColumn dcRep = new DataColumn();
                //        dcRep.ColumnName = dc.ColumnName;
                //        Rep.dsPrint.Tables["dtHead"].Columns.Add(dcRep);
                //    }
                //}
                //catch { }

                //if (this.dsPrint.Tables["dtHead"] != null)
                //{
                //    for (int i = 0; i < this.dsPrint.Tables["dtHead"].Rows.Count; i++)
                //    {
                //        DataRow dr = Rep.dsPrint.Tables["dtHead"].NewRow();
                //        for (int j = 0; j < Rep.dsPrint.Tables["dtHead"].Columns.Count; j++)
                //        {
                //            dr[j] = this.dsPrint.Tables["dtHead"].Rows[i][j];
                //        }
                //        Rep.dsPrint.Tables["dtHead"].Rows.Add(dr);
                //    }
                //}

                //设置报表表体数据表列

                Rep.dsPrint.Tables["dtGrid"].Clear();
                Rep.dsPrint.Tables["dtGrid"].Columns.Clear();
                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    DataColumn dcGrid = new DataColumn();
                    dcGrid.ColumnName = gridView1.Columns[i].Caption;
                    Rep.dsPrint.Tables["dtGrid"].Columns.Add(dcGrid);
                }
                if (grdDetail.DataSource != null)
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (Convert.ToBoolean(gridView1.GetRowCellValue(i, gridCol选择)))
                        {
                            DataRow dr = Rep.dsPrint.Tables["dtGrid"].NewRow();
                            for (int j = 0; j < Rep.dsPrint.Tables["dtGrid"].Columns.Count; j++)
                            {
                                if (gridView1.Columns[j].Caption == "条形码")
                                {
                                    dr[j] = ReturnBarCode(gridView1.GetRowCellDisplayText(i, gridView1.Columns[j]));
                                }
                                else
                                {
                                    dr[j] = gridView1.GetRowCellDisplayText(i, gridView1.Columns[j]);
                                }
                            }
                            Rep.dsPrint.Tables["dtGrid"].Rows.Add(dr);
                        }
                    }
                }

                Rep.DataMember = "dtGrid";
                Rep.ShowPreview();
                //Rep.Print();


                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (Convert.ToBoolean(gridView1.GetRowCellValue(i, gridCol选择)))
                        {
                            string sSQL = "update 条形码信息 set 打印次数 = isnull(打印次数,0) + 1,最后一次打印人 = '" + sUserID + "',最后一次打印日期 = getdate() where 条形码 = " + gridView1.GetRowCellValue(i, gridCol条形码).ToString().Trim();
                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                    }
                    tran.Commit();
                }
                catch (Exception error)
                {
                    tran.Rollback();
                    throw new Exception(error.Message);
                }

                sState = "print";
            }
            catch (Exception ee)
            {
                MessageBox.Show("打印失败:" + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        #endregion
    }
}