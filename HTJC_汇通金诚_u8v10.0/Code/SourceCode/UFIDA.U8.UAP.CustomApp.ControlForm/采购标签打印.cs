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
    public partial class 采购标签打印 : UserControl
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

        public 采购标签打印()
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

            sSQL = "select  ccode  as 采购入库单号 From zpurrkdlist a with(nolock)  group by ccode order by ccode";

            DataTable dts = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
            lookUpEdit采购入库单号1.Properties.DataSource = dts;
            lookUpEdit采购入库单号2.Properties.DataSource = dts;
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

                string sSQL = @"
select CAST(0 as bit) as 选择, ccode  as 采购入库单号,cbatch as 批号,cinvcode as 存货编码,cinvname as 存货名称,cInvStd as  规格型号
    ,a.cInvCCode as 存货分类编码,c.cInvCName as 存货分类,cbatchproperty6 炉号,cfree1 as 长度,cast(iquantity as decimal(18,2)) as 数量,irowno as 采购入库单行号
    ,cast(d.条形码 as varchar(10)) as 条形码 ,case when d.guid is null then newid() else d.guid end as GUID
From zpurrkdlist a with(nolock)  inner join InventoryClass c on a.cInvCCode = c.cInvCCode 
left join 条形码信息 d on a.ccode=d.采购入库单号 and a.irowno=d.采购入库单行号 
Where  (cbustype=N'普通采购' OR cbustype=N'代管采购')  and 1=1 
order by ccode
";

                string s存货编码条件 = "1=1";
                if (txt存货编码.Text.Trim() != "")
                {
                    if (cmb存货编码.Text.Trim() == "like")
                    {
                        s存货编码条件 = "1=1 and  (cInvCode like '%" + txt存货编码.Text.Trim() + "%' or cInvName like '%" + txt存货编码.Text.Trim() + "%' )";
                    }
                    else
                    {
                        s存货编码条件 = "1=1 and  (cInvCode " + cmb存货编码.Text.Trim() + " '" + txt存货编码.Text.Trim() + "' or cInvName " + cmb存货编码.Text.Trim() + " '" + txt存货编码.Text.Trim() + "' )";
                    }
                }
                sSQL = sSQL.Replace("1=1", s存货编码条件);

                string s存货分类条件 = "1=1";
                if (txt存货分类.Text.Trim() != "")
                {
                    if (cmb存货分类.Text.Trim() == "like")
                    {
                        s存货分类条件 = "1=1 and  (a.cInvCCode like '%" + txt存货分类.Text.Trim() + "%' or c.cInvCName like '%" + txt存货分类.Text.Trim() + "%' )";
                    }
                    else
                    {
                        s存货分类条件 = "1=1 and  (a.cInvCCode " + cmb存货分类.Text.Trim() + " '" + txt存货分类.Text.Trim() + "' or c.cInvCName " + cmb存货分类.Text.Trim() + " '" + txt存货分类.Text.Trim() + "' )";
                    }
                }
                if (lookUpEdit采购入库单号1.EditValue!=null && lookUpEdit采购入库单号1.EditValue.ToString().Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", " 1=1 and ccode>='" + lookUpEdit采购入库单号1.EditValue.ToString().Trim() + "'");
                }

                if (lookUpEdit采购入库单号2.EditValue!=null &&lookUpEdit采购入库单号2.EditValue.ToString().Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", " 1=1 and ccode<='" + lookUpEdit采购入库单号2.EditValue.ToString().Trim() + "'");
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
            lookUpEdit采购入库单号1.EditValue = DBNull.Value;
            lookUpEdit采购入库单号2.EditValue = DBNull.Value;
            chk全选.Checked = false;
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


                DataTable dt = ((DataTable)grdDetail.DataSource).Copy();


                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(dt.Rows[i]["选择"]))
                        {
                            string sSQL = "if exists(select * from dbo.条形码信息 where 采购入库单号 = '" + dt.Rows[i]["采购入库单号"].ToString().Trim() + "' and 采购入库单行号 = '" + dt.Rows[i]["采购入库单行号"].ToString().Trim() + "' and 存货编码 = '" + dt.Rows[i]["存货编码"].ToString().Trim() + "' )" +
                                                " update 条形码信息 set 最后一次打印人 = '" + sUserID + "' ,最后一次打印日期 = GETDATE(),打印次数 = ISNULL(打印次数,0) + 1 where 采购入库单号 = '" + dt.Rows[i]["采购入库单号"].ToString().Trim() + "' and 采购入库单行号 = '" + dt.Rows[i]["采购入库单行号"].ToString().Trim() + "' and 存货编码 = '" + dt.Rows[i]["存货编码"].ToString().Trim() + "' " +
                                           " else " +
                                               " insert into 条形码信息(最后一次打印人,最后一次打印日期,保存人,保存日期,打印次数,采购入库单号,采购入库单行号,存货编码,guid)values " +
                                               " ('" + sUserID + "',getdate(),'" + sUserID + "',GETDATE(),'1','" + dt.Rows[i]["采购入库单号"].ToString().Trim() + "','" + dt.Rows[i]["采购入库单行号"].ToString().Trim() + "','" + dt.Rows[i]["存货编码"].ToString().Trim() + "','" + dt.Rows[i]["GUID"].ToString().Trim() + "')";
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


                for (int i = 0; i <gridView1.RowCount; i++)
                {
                    if (!Convert.ToBoolean(gridView1.GetRowCellValue(i, gridCol选择)))
                        continue;

                    if (gridView1.GetRowCellValue(i, gridCol条形码).ToString().Trim()  == "")
                    {
                        string s = "select 条形码 from 条形码信息 where guid = '" + gridView1.GetRowCellValue(i, gridColGUID).ToString().Trim() + "'";
                        object o = SqlHelper.ExecuteScalar(conn, CommandType.Text, s);
                        gridView1.SetRowCellValue(i, gridCol条形码, o);

                    }
                }

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
                Rep.dsPrint.Clear();
                Rep.dsPrint.Tables.Clear();


                dt = (DataTable)grdDetail.DataSource;
                DataColumn dc = dt.Columns["条形码"];
                
                for (int i = 0; i < dt.Rows.Count; i++)
                { 
                    if(!Convert.ToBoolean(dt.Rows[i]["选择"]))
                        continue;

                    int iLeng = dt.Rows[i]["条形码"].ToString().Trim().Length;
                    for (int ii = iLeng; ii < 10; ii++)
                    {
                        dt.Rows[i]["条形码"] = "0" + dt.Rows[i]["条形码"].ToString().Trim();
                    }
                }
                DataView dv = dt.DefaultView;
                dv.RowFilter = " isnull(选择,0) = 1 ";
                dt.TableName = "dtGrid";
                Rep.dsPrint.Tables.Add(dv.ToTable());

                Rep.DataMember = "dtGrid";
                Rep.ShowPreview();
                //Rep.Print();

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