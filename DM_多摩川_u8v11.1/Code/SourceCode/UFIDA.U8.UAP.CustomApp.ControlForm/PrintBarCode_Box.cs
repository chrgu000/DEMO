using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using TH.BaseClass;
using System.Data.SqlClient;
using DevExpress.XtraReports.UI;


namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class PrintBarCode_Box : UserControl
    {
        TH.BaseClass.GetBaseData getBaseData = new GetBaseData();
        DAL_BarCodeList DAL = new DAL_BarCodeList();
        string sProPath = Application.StartupPath;

        string sPrintLayOutMod = Application.StartupPath + "\\UAP\\Runtime\\print\\Model\\箱码打印Mod.dll";
        string sPrintLayOutUser = Application.StartupPath + "\\UAP\\Runtime\\print\\User\\箱码打印User.dll";


        UFIDA.U8.UAP.CustomApp.ControlForm.RepBaseGrid Rep = new RepBaseGrid();

        string sState = "";

        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }



        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                GetGrid();
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "加载窗体失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        public PrintBarCode_Box()
        {
            InitializeComponent();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
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

                string sErr = "";
                string sWarn = "";

                if (Rep.dsPrint == null)
                    throw new Exception("没有需要打印的数据");

                int iBoxCount = BaseFunction.ReturnInt(textEditBoxQTY.Text.Trim());
                if (iBoxCount <= 0)
                {
                    textEditBoxQTY.Focus();
                    throw new Exception("请输入箱数");
                }


                int iCou = 0;
                SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                try
                {

                    Rep.dsPrint.Tables.Clear();


                    string sSQL = "select getdate()";
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    DateTime dDateSer = BaseFunction.ReturnDate(dt.Rows[0][0]);
                    if (dDateSer.Date < BaseFunction.ReturnDate("2014-8-1"))
                    {
                        throw new Exception("获得系统日期失败");
                    }

                    sSQL = "select max(BarCode) from dbo._BarCodeList where BarCode like 'X" + dDateSer.ToString("yyMMdd") + "%' ";
                    dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    string sMaxCode = "";
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        sMaxCode = dt.Rows[0][0].ToString().Trim();
                    }
                    long lMaxID = 0;
                    if (sMaxCode != "")
                    {
                        lMaxID = BaseFunction.ReturnLong(sMaxCode.Substring(7));
                    }

                    Guid sGuid = Guid.NewGuid();



                    for (int i = 0; i < iBoxCount; i++)
                    {
                        decimal dQuantity = BaseFunction.ReturnDecimal(textEditQTY.Text.Trim());
                        if (dQuantity < 0)
                            dQuantity = -1 * dQuantity;


                        Model_BarCodeList model = new Model_BarCodeList();

                        lMaxID += 1;
                        string sBarCode = getBaseData.GetBarCodeBox(dDateSer, lMaxID);
                        model.BarCode = sBarCode;
                        model.ExCode = textEditMomCode.Text.Trim();
                        model.ExQuantity = dQuantity;
                        model.Used = 0;
                        model.iQty = dQuantity;

                        model.CreateUserName = sUserName;
                        model.CreateDate = dDateSer;

                        model.ExType = "生产箱码";

                        model.GUID = sGuid;
                        model.valid = true;

                        model.Batch = textEditBatch.Text.Trim();
                        model.PosCode = textEditHW.Text.Trim();

                        sSQL = DAL.Add(model);
                        iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    sSQL = "select * from [_BarCodeList] where GUID = '" + sGuid.ToString().Trim() + "'";
                    DataTable dtPrint = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    dtPrint.TableName = "dtGrid";

                    Rep.dsPrint.Tables.Add(dtPrint.Copy());

                    if (dtPrint.Rows.Count < 1)
                    {
                        throw new Exception("没有要打印的单据");
                    }
                    if (sErr.Trim() != "")
                        throw new Exception(sErr);

                    if (iCou == 0)
                        throw new Exception("请选择需要保存的数据");

                    if (sErr.Length > 0)
                    {
                        throw new Exception(sErr);
                    }

                    Rep.ShowPreview();

                    tran.Commit();
                }
                catch (Exception error)
                {
                    tran.Rollback();
                    throw new Exception(error.Message);
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "打印失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        private void btnPrintSet_Click(object sender, EventArgs e)
        {
            try
            {
                bool bMod = false;
                if (sUserID == "demo")
                {
                    bMod = true;
                }

                if (!Directory.Exists(sProPath + "\\print"))
                    Directory.CreateDirectory(sProPath + "\\print");
                if (!Directory.Exists(sProPath + "\\print\\Model"))
                    Directory.CreateDirectory(sProPath + "\\print\\Model");
                if (!Directory.Exists(sProPath + "\\print\\User"))
                    Directory.CreateDirectory(sProPath + "\\print\\User");

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
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "设置打印模板失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        private void GetGrid()
        {
//            try
//            {
//                string sSQL = @"
//select cast(0 as bit) as choose , a.*
//from _BarCodeList a
//where 1=-1
//order by a.BarCode
//
//";
               
//                DataTable dt = DbHelperSQL.Query(sSQL);
//                gridControl1.DataSource = dt;
//                gridView1.AddNewRow();

//                chkAll.Checked = false;
//            }
//            catch (Exception ee)
//            {
//                FrmMsgBox f = new FrmMsgBox();
//                f.Text = "加载数据失败";
//                f.richTextBox1.Text = ee.Message;
//                f.ShowDialog();
//            }
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

        private void tsbClearCon_Click(object sender, EventArgs e)
        {
            textEditBatch.Text = "";
            textEditBoxQTY.Text = "";
            textEditHW.Text = "";
            textEditMomCode.Text = "";
            textEditQTY.Text = "";

            textEditBoxQTY.Focus();
        }

    }
}
