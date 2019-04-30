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
using System.Diagnostics;

namespace 业务
{
    public partial class Frm工作台测量 : 系统服务.FrmBaseInfo
    {
        public Frm工作台测量()
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
                //GetGrid();
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
            if (BaseFunction.ReturnInt(txt序号.Text) <= 0)
            {
                throw new Exception("序号不正确");
            }

            SetTxtEnable(true);
        }
        /// <summary>
        /// 删除
        /// </summary>
        private void btnDel()
        {
          
        }

        /// <summary>
        /// 保存
        /// </summary>
        private void btnSave()
        {
            try
            {
                decimal d测量值 = BaseFunction.ReturnDecimal(txt测量值.Text);
                if (d测量值 <= 0)
                {
                    throw new Exception("测量值不正确");
                }
                int i序号 = BaseFunction.ReturnInt( txt序号.Text);
                if (i序号 <= 0)
                {
                    throw new Exception("序号不正确");
                }

                SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    sSQL = @"
update 工作台测量 set 测量值 = {0},备注 = N'{2}' where iID = {1}
";
                    sSQL = string.Format(sSQL, d测量值, i序号, txt备注.Text.Trim());
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    GetGrid(tran, lookUpEdit检验工位.Text.Trim());
                    tran.Commit();

                    SetTxtEnable(false);
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

                txt检验员.Text = sUserName;

                timer1.Start();

                txtStatus.Text = "";

                SetTxtEnable(false);
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
            lookUpEdit检验工位.Properties.DataSource = dt;

            sSQL = @"select getdate()";
            dt = DbHelperSQL.Query(sSQL);
            dateEdit单据日期.DateTime = Convert.ToDateTime(dt.Rows[0][0]);
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                ReflashData();
            }
            catch(Exception ee)
            {
            
            }
        }



        private void ReflashData()
        {
            string s检验工位 = lookUpEdit检验工位.Text.Trim();
            if (s检验工位 == "")
                return;

            if(dateEdit单据日期.Text.Trim() =="" || dateEdit单据日期.DateTime <BaseFunction.ReturnDate("2018-10-01"))
                return;

            SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
            conn.Open();
            SqlTransaction tran = conn.BeginTransaction();
            try
            {

                string sSQL = @"
select * 
from [dbo].[检验值] a
	left join [dbo].[检验标准档案] b on a.发射器编号 = b.发射器ID
where isnull(a.已取值,0) = 0
	and a.dtmCreate >= '{0}'
	and a.发射器编号 in (select 发射器ID from [dbo].[发射器档案设置] where [检验工位] = '{1}')
order by a.iID
";
                sSQL = string.Format(sSQL,dateEdit单据日期.DateTime.ToString("yyyy-MM-dd HH:mm:ss"), s检验工位);
                DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];


                if (dt != null && dt.Rows.Count > 0)
                {
                    txt发射器ID.EditValue = dt.Rows[0]["发射器编号"].ToString().Trim();
                    txt量具品名.EditValue = dt.Rows[0]["量具品名"].ToString().Trim();
                    txt测定项目.EditValue = dt.Rows[0]["测定项目"].ToString().Trim();
                    txt测定项目日文.EditValue = dt.Rows[0]["测定项目日文"].ToString().Trim();
                    txt尺寸公差.EditValue = dt.Rows[0]["尺寸公差"].ToString().Trim();

                    decimal d上限 = 9999999999999;
                    if (dt.Rows[0]["上限"].ToString().Trim() != "")
                    {
                        d上限 = BaseFunction.ReturnDecimal(dt.Rows[0]["上限"]);

                        txt上限.EditValue = d上限;
                    }
                    else
                    {
                        txt上限.EditValue = "MAX";
                    }
                    decimal d下限 = 0;
                    if (dt.Rows[0]["下限"].ToString().Trim() != "")
                    {
                        d下限 = BaseFunction.ReturnDecimal(dt.Rows[0]["下限"]);
                        txt下限.EditValue = d下限;
                    }

                    decimal d测量值 = BaseFunction.ReturnDecimal(dt.Rows[0]["测量数值"]);
                    txt测量值.EditValue = d测量值;

                    if (d测量值 <= d上限 && d测量值 >= d下限)
                    {
                        txtStatus.Text = "OK";
                        txtStatus.ForeColor = Color.Black;
                    }
                    else
                    {
                        txtStatus.Text = "NG";
                        txtStatus.ForeColor = Color.Red;
                    }

                    Model.工作台测量 mod = new 业务.Model.工作台测量();
                    mod.发射器ID = BaseFunction.ReturnInt(dt.Rows[0]["发射器编号"]);
                    mod.工作台 = s检验工位;
                    mod.量具品名 = dt.Rows[0]["量具品名"].ToString().Trim();
                    mod.测定项目 = dt.Rows[0]["测定项目"].ToString().Trim();
                    mod.测定项目日文 = dt.Rows[0]["测定项目日文"].ToString().Trim();
                    mod.规格 = dt.Rows[0]["规格"].ToString().Trim();
                    mod.尺寸公差 = dt.Rows[0]["尺寸公差"].ToString().Trim();
                    if (dt.Rows[0]["下限"].ToString().Trim() != "")
                    {
                        mod.下限 = BaseFunction.ReturnDecimal(dt.Rows[0]["下限"]);
                    } 
                    if (dt.Rows[0]["上限"].ToString().Trim() != "")
                    {
                        mod.上限 = BaseFunction.ReturnDecimal(dt.Rows[0]["上限"]);
                    }
                    mod.测量值 = BaseFunction.ReturnDecimal(dt.Rows[0]["测量数值"]);
                    mod.原始值 = BaseFunction.ReturnDecimal(dt.Rows[0]["测量数值"]);
                    mod.备注 = dt.Rows[0]["备注"].ToString().Trim();
                    mod.检验员 = txt检验员.Text.Trim();
                    mod.检验时间 = BaseFunction.ReturnDate(dt.Rows[0]["dtmCreate"]);
                    mod.操作员 = sUserName;
                    mod.SourceID = BaseFunction.ReturnLong(dt.Rows[0]["iID"]);
                    DAL.工作台测量 dal = new 业务.DAL.工作台测量();
                    sSQL = dal.Add(mod);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    sSQL = @"
update [dbo].[检验值] set [已取值] = 1 where iID = {0}
";
                    sSQL = string.Format(sSQL, mod.SourceID);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    sSQL = @"
select top 20 * 
from  工作台测量 
where 工作台 = '{0}' and dtmCreate >= dateadd(hour,-2,getdate()) and isnull(删除人,'') = ''
order by iID desc
";
                    sSQL = string.Format(sSQL, s检验工位);
                    dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    gridControl1.DataSource = dt;
                    gridView1.FocusedRowHandle = 0;


                    txt序号.EditValue = dt.Rows[0]["iID"].ToString().Trim();

                    SetTxtEnable(false);
                }

                tran.Commit();
            }
            catch (Exception ee)
            {
                tran.Rollback();
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
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

        private void SetTxtEnable(bool b)
        {
            txt测量值.Enabled = b;
            txt测量值.Properties.ReadOnly = !b;

            txt备注.Enabled = b;
            txt备注.Properties.ReadOnly = !b;
        }

        private void txt测量值_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                decimal d上限 = 9999999999999;
                if (txt上限.Text.Trim() != "")
                {
                    d上限 = BaseFunction.ReturnDecimal(txt上限.Text.Trim());

                    txt上限.EditValue = d上限;
                }
                else
                {
                    txt上限.EditValue = "MAX";
                }
                decimal d下限 = 0;
                if (txt下限.Text.Trim() != "")
                {
                    d下限 = BaseFunction.ReturnDecimal(txt下限.Text.Trim());
                    txt下限.EditValue = d下限;
                }

                decimal d测量值 = BaseFunction.ReturnDecimal(txt测量值.Text.Trim());
                txt测量值.EditValue = d测量值;

                if (d测量值 <= d上限 && d测量值 >= d下限)
                {
                    txtStatus.Text = "OK";
                    txtStatus.ForeColor = Color.Black;
                }
                else
                {
                    txtStatus.Text = "NG";
                    txtStatus.ForeColor = Color.Red;
                }
            }
            catch { }
        }

        private void GetGrid(SqlTransaction tran,string s检验工位)
        {
            string sSQL = @"
select top 20 * 
from  工作台测量 
where 工作台 = '{0}' and dtmCreate >= dateadd(hour,-2,getdate()) and isnull(删除人,'') = ''
order by iID desc
";
            sSQL = string.Format(sSQL, s检验工位);
            DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
            gridControl1.DataSource = dt;
            gridView1.FocusedRowHandle = 0;

        }

        private void lookUpEdit检验工位_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (lookUpEdit检验工位.EditValue == null || lookUpEdit检验工位.Text.Trim() == "")
                {
                    return;
                }

                SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    string sSQL = "select getdate()";
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    dateEdit单据日期.DateTime = Convert.ToDateTime(dt.Rows[0][0]);


                    GetGrid(tran, lookUpEdit检验工位.Text.Trim());


                    tran.Commit();
                }
                catch (Exception ee)
                {
                    tran.Rollback();
                }
            }
            catch { }
        }

    }
}
