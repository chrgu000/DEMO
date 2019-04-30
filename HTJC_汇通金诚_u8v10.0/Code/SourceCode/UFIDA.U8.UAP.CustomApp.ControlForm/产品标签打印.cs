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
    public partial class 产品标签打印 : UserControl
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

        public 产品标签打印()
        {
            InitializeComponent();

            sPrintLayOutMod = sProPath + "\\UAP\\Runtime\\print\\Model\\" + this.labelControl1.Text.Trim() + "Mod.dll";
            sPrintLayOutUser = sProPath + "\\UAP\\Runtime\\print\\User\\" + this.labelControl1.Text.Trim() + "User.dll";
        }


        private void ProjectManager_Load(object sender, EventArgs e)
        {
            try
            {
                if (sUserID == "admin" || sUserID == "system" || sUserID == "demo")
                {
                    btnPrintSET.Visible = true;
                }
                else
                {
                    btnPrintSET.Visible = false;
                }
                txt行号.EditValue = "1";

                SetLookup();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载数据失败");
            }
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
                SetNull();
                if (lookUpEdit生产订单号1.Text.Trim() == "")
                {
                    MessageBox.Show("生产订单号不能为空");
                    lookUpEdit生产订单号1.Focus();
                    return;
                }

                if (txt行号.Text.Trim() == "")
                {
                    MessageBox.Show("生产订单行号不能为空");
                    txt行号.Focus();
                    return;
                }

                string sSQL = @"
select * 
	,cast(d.条形码 as varchar(10)) as 条形码 ,case when d.guid is null then newid() else d.guid end as GUID
from mom_order a inner join mom_orderdetail b on a.moid = b.moid inner join Inventory c on b.InvCode = c.cInvCode
    left join 条形码信息  d on d.生产订单号 = a.MoCode and d.行号 = b.SortSeq 
where 1=1
";

                sSQL = sSQL.Replace("1=1", "1=1 and a.MoCode = '" + lookUpEdit生产订单号1.Text.Trim() + "' and b.SortSeq = '" + txt行号.Text.Trim() + "' ");
                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];

                if (dt == null || dt.Rows.Count < 1)
                {
                    MessageBox.Show("未找到相应生产订单或行号，请核实");
                    SetNull();
                    return;
                }



                txt存货编码.Text = dt.Rows[0]["cInvCode"].ToString().Trim();
                txt存货名称.Text = dt.Rows[0]["cInvName"].ToString().Trim();
                txt规格型号.Text = dt.Rows[0]["cInvStd"].ToString().Trim();
                txt长度.Text = dt.Rows[0]["Free1"].ToString().Trim();

                string s数量=dt.Rows[0]["define25"].ToString().ToUpper().Trim();
                string[] arr = s数量.Split(new string[] { "KG" },System.StringSplitOptions.None);
                if (arr.Length > 0)
                {
                    txt毛重.Text = arr[0].Trim();
                }
                txtGuid.Text = Guid.NewGuid().ToString();
                //sSQL = "select top 1 cast(substring(批号,11,3) as int) +1 as 批号 from 条形码信息 where 生产订单号 like '" + lookUpEdit生产订单号1.Text.Trim() + "' order by 批号 desc";
                sSQL = "select isnull(max(批号),0) as 批号  from 条形码信息 where 生产订单号 = '" + lookUpEdit生产订单号1.Text.Trim() + "' ";
                DataTable dtpro = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                if (dtpro.Rows.Count == 0)
                {
                    txt批号.Text = lookUpEdit生产订单号1.Text.Trim() + "001";
                }
                else
                {

                    string s批号 = dtpro.Rows[0]["批号"].ToString().Trim();
                    if (s批号.Length == 1)
                    {
                        txt批号.Text = lookUpEdit生产订单号1.Text.Trim() + "001";
                    }
                    else
                    {
                        int iLeng = s批号.Length;
                        s批号 = s批号.Substring(iLeng - 3);
                        s批号 = (ReturnObjectToInt(s批号) + 1).ToString().Trim();

                        if (s批号.Length == 1)
                        {
                            txt批号.Text = lookUpEdit生产订单号1.Text.Trim() + "00" + s批号;
                        }
                        else if (s批号.Length == 2)
                        {
                            txt批号.Text = lookUpEdit生产订单号1.Text.Trim() + "0" + s批号;
                        }
                        else if (s批号.Length == 3)
                        {
                            txt批号.Text = lookUpEdit生产订单号1.Text.Trim() + s批号;
                        }
                        else
                        {
                            throw new Exception("批号流水超出三位");
                        }
                    }
                }

                sSQL = @"
select e.cBatchProperty6
from mom_order a inner join mom_orderdetail b on a.moid = b.moid inner join Inventory c on b.InvCode = c.cInvCode
    inner join  mom_moallocate d on d.MoDId  = b.Modid 
	inner join rdrecords11 e on e.iMPoIds = d.AllocateId
where isnull(e.cBatchProperty6,'') <>'' and 1=1
";
                sSQL = sSQL.Replace("1=1", "1=1 and a.MoCode = '" + lookUpEdit生产订单号1.Text.Trim() + "' and b.SortSeq = '" + txt行号.Text.Trim() + "' ");
                DataTable dt炉号 = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];

                if (dt炉号 != null && dt炉号.Rows.Count > 0)
                    txt炉号.Text = dt炉号.Rows[0]["cBatchProperty6"].ToString().Trim();

                sState = "sel";

                btn地磅.Focus();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
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


        private void btnSave_Click(object sender, EventArgs e)
        {
         
        }

        private void gridView1_Click(object sender, EventArgs e)
        {

        }

        private void btnHistory_Click(object sender, EventArgs e)
        {

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
                if(txt行号.Text.Trim() == "")
                {
                    MessageBox.Show("请先输入行号");
                    txt行号.Focus();
                    return;
                }


                if (txt存货编码.Text.Trim() == "")
                {
                    MessageBox.Show("请先输入生产订单信息");
                    lookUpEdit生产订单号1.Focus();
                    return;
                }

                decimal d净重 = ReturnObjectToDecimal(txt净重.Text.Trim(), 6);
                if (d净重 <= 0)
                {
                    MessageBox.Show("获得产品重量失败");
                    txt净重.Focus();
                    return;
                }


                decimal d毛重 = ReturnObjectToDecimal(txt毛重.Text.Trim(), 6);
                if (d毛重 <= 0)
                {
                    MessageBox.Show("称重数据不正确，请核实");
                    txt毛重.Focus();
                    return;
                }

                string sSQL2 = "select getdate()";
                DateTime d当前日期 = Convert.ToDateTime(SqlHelper.ExecuteScalar(Conn, CommandType.Text, sSQL2));
                string s条码单据号 = d当前日期.ToString("yyyyMMddHHmmss");

                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    string sSQL = "select a.*,b.cInvName,b.cInvStd,isnull(b.bInvBatch ,0) as bInvBatch ,isnull(b.bFree1 ,0) as bFree1  from 条形码信息 a inner join inventory b on a.存货编码 = b.cInvCode where guid = '" + txtGuid.Text.Trim() + "'";
                    DataTable dt = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        DialogResult d = MessageBox.Show("该条码已经打印\n  Y：继续打印 \n  N：返回 ", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                        if (d == DialogResult.No)
                            return;
                    }

                    sSQL = "select * from inventory where cInvcode = '" + txt存货编码.Text.Trim() + "'";
                    DataTable dtinv = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtinv == null || dtinv.Rows.Count < 1)
                    {
                        throw new Exception("存货信息不存在");
                    }
                    int iBatch = ReturnObjectToInt(dtinv.Rows[0]["bInvBatch"]);
                    if (iBatch == 1 && txt批号.Text.Trim() == "")
                    {
                        throw new Exception(txt存货编码.Text.Trim() + "是批次管理，请输入批号");
                    }

                    int iFree1 = ReturnObjectToInt(dtinv.Rows[0]["bFree1"]);
                    if (iFree1 == 1 && txt长度.Text.Trim() == "")
                    {
                        throw new Exception(txt存货编码.Text.Trim() + "必须输入长度");
                    }

                    if (dt.Rows.Count == 0)
                    {
                        sSQL = "INSERT INTO [条形码信息]([存货编码] ,[长度],[批号] ,[炉号] ,[数量] ,[毛重]" +
                                          ",[保存人]  ,[保存日期],[打印次数],[生产订单号],[行号] " +
                                          " ,[最后一次打印人]  ,[最后一次打印日期],条码单据号,guid) " +
                                      " VALUES ('" + txt存货编码.Text.Trim() + "','" + txt长度.Text.Trim() + "','" + txt批号.Text.Trim() + "','" + txt炉号.Text.Trim() + "'," + txt净重.Text.Trim() + "," + txt毛重.Text.Trim() + "  " +
                                            ",'" + sUserID + "',getdate(),1,'" + lookUpEdit生产订单号1.Text.Trim() + "','" + txt行号.Text.Trim() + "' " +
                                            ",'" + sUserID + "',getdate(),'" + s条码单据号 + "','" + txtGuid.Text.Trim() + "')";
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    sSQL = "select * from 条形码信息 where guid = '" + txtGuid.Text.Trim() + "'";
                    DataTable dtTemp = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    txt条形码.Text = dtTemp.Rows[0]["条形码"].ToString().Trim();

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
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        DataColumn dcRep = new DataColumn();
                        dcRep.ColumnName = dt.Columns[i].ColumnName;
                        Rep.dsPrint.Tables["dtHead"].Columns.Add(dcRep);
                    }

                    DataRow dr = Rep.dsPrint.Tables["dtHead"].NewRow();
                    dr["条形码"] = ReturnBarCode(txt条形码.Text.Trim()); 
                    dr["存货编码"] = txt存货编码.Text.Trim();
                    dr["cInvName"] = txt存货名称.Text.Trim();
                    dr["cInvStd"] = txt规格型号.Text.Trim();
                    dr["长度"] = txt长度.Text.Trim();
                    dr["批号"] = txt批号.Text.Trim();
                    dr["炉号"] = txt炉号.Text.Trim();
                    dr["数量"] = txt净重.Text.Trim();
                    dr["毛重"] = txt毛重.Text.Trim();
                    dr["生产订单号"] = lookUpEdit生产订单号1.Text.Trim() + " / " + txt行号.Text.Trim();

                    Rep.dsPrint.Tables["dtHead"].Rows.Add(dr);

                    Rep.ShowPreview();
                    //Rep.Print();

                    tran.Commit();
                }
                catch (Exception error)
                {
                    tran.Rollback();
                    throw new Exception(error.Message);
                }

                string sSQL3 = "select * from 条形码信息 where guid = '" + txtGuid.Text.Trim() + "'";
                DataTable dt2 = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL3).Tables[0];
                if (dt2 != null && dt2.Rows.Count > 0)
                {
                    txt条形码.Text = dt2.Rows[0]["条形码"].ToString().Trim();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

            /*
             *     Rep = new RepBaseGrid();
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

             */
        }



        #endregion


        private void SetNull()
        {
            txt存货编码.Text = "";
            txt存货名称.Text = "";
            txt规格型号.Text = "";
            txt批号.Text = "";
            txt炉号.Text = "";
            txt长度.Text = "";
            txt净重.Text = "";
            txt毛重.Text = "";
            txt条形码.Text = "";
            txtGuid.Text = "";
        }



        #region 地磅
        //定义 SerialPort对象
        SerialPort port1;

        //初始化SerialPort对象方法.PortName为COM口名称,例如"COM1","COM2"等,注意是string类型
        public void InitCOM(string PortName)
        {
            port1 = new SerialPort(PortName);
            port1.BaudRate = 9600;//波特率
            port1.Parity = Parity.None;//无奇偶校验位
            port1.StopBits = StopBits.One;//两个停止位
            port1.Handshake = Handshake.RequestToSend;//控制协议
            port1.ReceivedBytesThreshold = 8;//设置 DataReceived 事件发生前内部输入缓冲区中的字节数
            port1.Encoding = Encoding.ASCII;
            port1.DataReceived += new SerialDataReceivedEventHandler(port1_DataReceived);//DataReceived事件委托
        }
        //DataReceived事件委托方法
        private void port1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                //循环接收数据
                string s = "";
                while (port1.BytesToRead > 0 && s.Length<100)
                {
                    //MessageBox.Show(s);
                    char ch = (char)port1.ReadByte();
                    s = s + ch.ToString();
                }

                //MessageBox.Show("AA" + s);
                //MessageBox.Show(s.IndexOf("-+").ToString());
                //txt毛重.Text = s.Substring(s.IndexOf(",+") + 1, 6);

                string s净重 = s.Substring(s.IndexOf(",+") + 1, 6);
                txt净重.Text = Math.Ceiling(ReturnObjectToDecimal(s净重, 2)).ToString();

                ClosePort();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

        }

        //打开串口的方法
        public void OpenPort()
        {
            try
            {
                port1.Open();
            }
            catch { }
            if (port1.IsOpen)
            {
                //label1.Text = port1.ReadExisting();
                //MessageBox.Show("the port is opened!");
            }
            else
            {
                //label1.Text = port1.ReadExisting();
                //MessageBox.Show("failure to open the port!");
            }
        }

        //关闭串口的方法
        public void ClosePort()
        {
            port1.Close();
            if (!port1.IsOpen)
            {
                //Console.WriteLine("the port is already closed!");
            }
        }

        //向串口发送数据
        public void SendCommand(string CommandString)
        {
            byte[] WriteBuffer = Encoding.ASCII.GetBytes(CommandString);
            port1.Write(WriteBuffer, 0, WriteBuffer.Length);
        }

        private void btn地磅_Click(object sender, EventArgs e)
        {
            try
            {
                //我现在用的COM1端口,按需要可改成COM2,COM3
                InitCOM("COM5");
                OpenPort();

                if (ReturnObjectToDecimal(txt净重.Text.Trim(), 2) > 0)
                {
                    btnPrint.Focus();
                }
                else
                {
                    btn地磅.Focus();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        #endregion


        private void lookUpEdit生产订单号1_Validated(object sender, EventArgs e)
        {
            try
            {
                if (lookUpEdit生产订单号1.Text.Trim() == "")
                    return;

                txt行号.Text = "1";

                string sSQL = @"
select count(1) as 行数
from mom_order a inner join mom_orderdetail b on a.moid = b.moid 
where a.mocode = '111111' and b.SortSeq = '222222' 
";
                sSQL = sSQL.Replace("111111", lookUpEdit生产订单号1.Text.Trim());
                sSQL = sSQL.Replace("222222", txt行号.Text.Trim());
                int iCou = ReturnObjectToInt(SqlHelper.ExecuteScalar(Conn, CommandType.Text, sSQL));
                if (iCou == 0)
                {
                    sSQL = @"
select b.SortSeq as 行 
from mom_order a inner join mom_orderdetail b on a.moid = b.moid 
where a.mocode = '111111' 
";
                    sSQL = sSQL.Replace("111111", lookUpEdit生产订单号1.Text.Trim());
                    DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                    if (dt == null || dt.Rows.Count < 1)
                        throw new Exception("没有匹配的生产订单");

                    if (dt.Rows.Count > 1)
                    {
                        throw new Exception("生产订单不能超过一行");
                    }

                    txt行号.Text = dt.Rows[0]["行"].ToString().Trim();
                }

                if (iCou > 1)
                {
                    throw new Exception("生产订单不能超过一行");
                }

                btnSel_Click(null, null);

            }
            catch (Exception ee)
            {
                SetNull();
                MessageBox.Show("获得单据行号失败:" + ee.Message);
            }
        }

        private void txt行号_Validated(object sender, EventArgs e)
        {
            try
            {
                if (lookUpEdit生产订单号1.Text.Trim() == "")
                    return;

                if (txt行号.Text.Trim() == "")
                    return;

                string sSQL = @"
select count(1) as 行数
from mom_order a inner join mom_orderdetail b on a.moid = b.moid 
where a.mocode = '111111' and b.SortSeq = '222222' 
";
                sSQL = sSQL.Replace("111111", lookUpEdit生产订单号1.Text.Trim());
                sSQL = sSQL.Replace("222222", txt行号.Text.Trim());
                int iCou = ReturnObjectToInt(SqlHelper.ExecuteScalar(Conn, CommandType.Text, sSQL));
                if (iCou == 0)
                {
                    SetNull();
                    throw new Exception("行号不正确");
                }

                if (iCou > 1)
                {
                    SetNull();
                    throw new Exception("生产订单不能超过一行");
                }

                btnSel_Click(null, null);

            }
            catch (Exception ee)
            {
                SetNull();
                MessageBox.Show("获得单据行号失败:" + ee.Message);
            }
        }
        private void SetLookup()
        {
            try
            {
                string sSQL = @"
select distinct a.MoCode
from mom_order a inner join mom_orderdetail b on a.moid = b.moid
where b.Status = 3
order by a.MoCode
";
                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                DataRow dr = dt.NewRow();
                dt.Rows.InsertAt(dr, 0);

                lookUpEdit生产订单号1.Properties.DataSource = dt;
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得生产订单号失败");
            }
        }

        private void lookUpEdit生产订单号1_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    if (lookUpEdit生产订单号1.Text.Trim() == "")
            //    {
            //        lookUpEdit生产订单号1.Focus();
            //        throw new Exception("请选择生产订单");
            //    }

            //    btnSel_Click(null, null);
            //}
            //catch (Exception ee)
            //{
            //    MessageBox.Show(ee.Message);
            //}
        }
    }
}