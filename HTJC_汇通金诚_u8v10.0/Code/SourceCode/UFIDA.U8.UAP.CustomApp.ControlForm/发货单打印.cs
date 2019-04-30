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
using System.IO.Ports;
using System.Threading;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class 发货单打印 : UserControl
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

        string sTitle = "发货单打印";
        string sState = "";

        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }

        public 发货单打印()
        {
            InitializeComponent();

            sPrintLayOutMod = sProPath + "\\UAP\\Runtime\\print\\Model\\" + sTitle + "Mod.dll";
            sPrintLayOutUser = sProPath + "\\UAP\\Runtime\\print\\User\\" + sTitle + "User.dll";
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSel_Click(object sender, EventArgs e)
        {
          
        }

        private int ReturnObjectToInt(object o)
        {
            int d = 0;
            try
            {
                d = Convert.ToInt32(o);
            }
            catch
            { }
            return d;
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

                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    if (!Convert.ToBoolean(dt.Rows[i]["选择"]))
                    {
                        dt.Rows.RemoveAt(i);
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
                Rep.dsPrint.Tables.Add(dt);

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

        private void btn清空_Click(object sender, EventArgs e)
        {
            SetLookup();

            lookUpEdit发货单号1.EditValue = DBNull.Value;
            lookUpEdit发货单号2.EditValue = DBNull.Value;
            dtm1.DateTime = DateTime.Today;
            dtm2.DateTime = DateTime.Today.AddDays(7);
        }

        private void SetLookup()
        {
            try
            {
                string sSQL = @"
select distinct cDLCode
from DispatchList 
where isnull(cVerifier ,'') = '' and isnull(cCloser ,'') = ''
order by cDLCode
";
                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                DataRow dr = dt.NewRow();
                dt.Rows.InsertAt(dr, 0);

                lookUpEdit发货单号1.Properties.DataSource = dt;
                lookUpEdit发货单号2.Properties.DataSource = dt;
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得生产订单号失败");
            }
        }

        private void btnSel_Click_1(object sender, EventArgs e)
        {
            try
            {
                string sSQL = @"
select distinct cast(0 as bit) as 选择, cDLCode,cCusCode,cCusName,b.cInvCode,c.cInvName,c.cInvStd
	,cast(b.iQuantity as decimal(16,2)) as iQuantity
from DispatchList a inner join DispatchLists b on a.DLID = b.DLID
	inner join Inventory c on b.cInvCode = c.cInvCode
where 1=1 
order by cDLCode
";
                if (lookUpEdit发货单号1.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.cDLCode >= '" + lookUpEdit发货单号1.Text.Trim() + "'");
                }
                if (lookUpEdit发货单号2.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.cDLCode <= '" + lookUpEdit发货单号2.Text.Trim() + "'");
                }
                if (dtm1.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.dDate >= '" + dtm1.DateTime.ToString("yyyy-MM-dd") + "'");
                }
                if (dtm2.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.dDate < '" + dtm1.DateTime.AddDays(1).ToString("yyyy-MM-dd") + "'");
                }

                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                grdDetail.DataSource = dt;
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得生成订单失败"); 
            }
        }

        private void 生产发料打印_Load(object sender, EventArgs e)
        {


            SetLookup();
        }

        private void chk全选_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    gridView1.SetRowCellValue(i, gridCol选择, chk全选.Checked);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}