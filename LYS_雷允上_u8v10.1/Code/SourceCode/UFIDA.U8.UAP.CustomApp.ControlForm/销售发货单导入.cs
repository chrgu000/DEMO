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
using TH.BaseClass;


namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class 销售发货单导入 : UserControl
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

        public 销售发货单导入()
        {
            InitializeComponent();
        }


        private void ProjectManager_Load(object sender, EventArgs e)
        {
            try
            {



            }
            catch (Exception ee)
            {
                //MessageBox.Show("加载数据失败");
                throw new Exception(ee.Message);
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

                string sErr = "";
                string sSQL = "";
                DataTable dtGrid = (DataTable)gridControl1.DataSource;

                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    for (int i = 0; i < dtGrid.Rows.Count; i++)
                    {
                        sSQL = "select count(1) from DispatchList where cDLCode = '" + dtGrid.Rows[i]["单据号"].ToString().Trim() + "' ";
                        int iCou = SqlHelper.ReturnObjectToInt(SqlHelper.ExecuteScalar(tran, CommandType.Text, sSQL));
                        if (iCou > 0)
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "单据号已存在\n";
                            continue;
                        }
                    }

                    if (sErr.Length > 0)
                    {
                        throw new Exception(sErr);
                    }

                    sSQL = "SELECT * FROM UFSystem..UA_Identity where cVouchType = 'DISPATCH' and cAcc_Id = '" + sAccID + "'";
                    DataTable dtID = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    long lID = 0;
                    long lIDMain = 0;
                    long lIDDetails = 0;
                    if (dtID != null && dtID.Rows.Count > 0)
                    {
                        lID = SqlHelper.ReturnObjectToLong(dtID.Rows[0]["iFatherId"]);
                        lIDDetails = SqlHelper.ReturnObjectToLong(dtID.Rows[0]["iChildId"]);
                    }

                    for (int i = 0; i < dtGrid.Rows.Count; i++)
                    {
                        #region 数据验证

                        string s存货编码 = dtGrid.Rows[i]["存货编码"].ToString().Trim();
                        sSQL = "select * from Inventory a inner join Inventory_Sub b on a.cinvcode = b.cinvsubcode  where a.cInvCode = '" + s存货编码 + "'";
                        DataTable dt存货档案 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt存货档案 == null || dt存货档案.Rows.Count < 1)
                        {
                            sErr = sErr + "行" + (i + 1).ToString().Trim() + "存货" + s存货编码 + "不存在\n";
                            continue;
                        }

                        decimal d数量 = SqlHelper.ReturnObjectToDecimal(dtGrid.Rows[i]["数量"]);
                        if (d数量 <= 0)
                        {
                            sErr = sErr + "行" + (i + 1).ToString().Trim() + "发货数量必须大于0\n";
                            continue;
                        }

                        DateTime d发货日期 = SqlHelper.ReturnObjectToDateTime(dtGrid.Rows[i]["发货日期"]);
                        if (d发货日期 < Convert.ToDateTime("2000-01-01"))
                        {
                            sErr = sErr + "行" + (i + 1).ToString().Trim() + "单据日期格式不正确\n";
                            continue;
                        }

                        sSQL = @"select bflag_SA,iyear ,iperiod,* from GL_mend 
where isnull(bflag_SA,0) = 0 and iperiod <> 0
order by iyear,iperiod ";
                        DataTable dt结账状态 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        DateTime d结账 = Convert.ToDateTime(dt结账状态.Rows[0]["iyear"].ToString().Trim() + "-" + dt结账状态.Rows[0]["iperiod"].ToString().Trim() + "-1");
                        if (d结账 > d发货日期)
                        {
                            sErr = sErr + "行" + (i + 1).ToString().Trim() + "该单据日期销售模块已结账\n";
                            continue;
                        }

                        string s客户 = dtGrid.Rows[i]["客户编码"].ToString().Trim();
                        sSQL = "select * from customer where cCusCode = '" + s客户 + "' or cCusName = '" + s客户 + "' or cCusAbbName = '" + s客户 + "'";
                        DataTable dt客户 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt客户 == null || dt客户.Rows.Count < 1)
                        {
                            sErr = sErr + "行" + (i + 1).ToString().Trim() + "客户" + s客户 + "不存在\n";
                            continue;
                        }
                        if (dt客户.Rows.Count > 1)
                        {
                            sErr = sErr + "行" + (i + 1).ToString().Trim() + "客户" + s客户 + "存在多个定义,请使用客户编码唯一指定\n";
                            continue;
                        }

                        sSQL = "select * from foreigncurrency where cexch_code = '" + dtGrid.Rows[i]["币种"].ToString().Trim() + "' or cexch_name = '" + dtGrid.Rows[i]["币种"].ToString().Trim() + "'";
                        DataTable dt币种 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt币种.Rows.Count == 0)
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "币种不存在\n";
                            continue;
                        }


                        sSQL = "select * from Warehouse where cWhCode = '" + dtGrid.Rows[i]["仓库编码"].ToString().Trim() + "'";
                        DataTable dt仓库 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt仓库.Rows.Count == 0)
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "仓库编码不存在\n";
                            continue;
                        }
                        #endregion

                        #region 导入表头数据

                        string s销售类型编码 = dtGrid.Rows[i]["销售类型"].ToString().Trim();


                        sSQL = "select * from dispatchlist where cDLCode = '" + dtGrid.Rows[i]["单据号"].ToString().Trim() + "'";
                        DataTable dt发货单 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                        if (dt发货单.Rows.Count == 0)
                        {
                            lID += 1;
                            lIDMain = ReturnID(lID);


                            sSQL = @"
 Insert Into dispatchlist(cbustype,caccounter
    ,ivtid,outid,ccrechpname,cdlcode,cvouchtype
    ,cstcode,ddate,cdepcode,cpersoncode,csbvcode
    ,csocode,ccuscode,cpaycode,csccode,cshipaddress
    ,cexch_name,iexchrate,itaxrate,cmemo,cdefine1
    ,cdefine2,inetlock,breturnflag,dlid,cverifier
    ,cmaker,bfirst,sbvid,cdefine3,cdefine5
    ,cdefine7,cdefine8,cdefine9,cdefine10,cdefine11
    ,cdefine12,cdefine13,cdefine14,cdefine15,cdefine16
    ,cmodifier,isale,ccusname,ccusperson,ccuspersoncode
    ,cbooktype,cbookdepcode,crdcode,ccloser,caddcode
    ,csvouchtype,iflowid,cgatheringplan,icreditdays,bcredit
    ,bmustbook,ioutgolden,iverifystate,ireturncount,icreditstate
    ,iswfcontrolled,cchanger,cchangememo,bcashsale,cgathingcode
    ,bsigncreate,bneedbill,iprintcount,baccswitchflag) 
";

                            sSQL = sSQL + "Values (N'" + dtGrid.Rows[i]["业务类型"].ToString().Trim() + "',Null" +
    ",71,Null,Null,N'" + dtGrid.Rows[i]["单据号"].ToString().Trim() + "',N'05'" +
    "," + ReturnDBString(dtGrid.Rows[i]["销售类型"]) + ",'" + d发货日期.ToString("yyyy-MM-dd") + "'," + ReturnDBString(dtGrid.Rows[i]["销售部门"]) + "," + ReturnDBString(sUserID) + ",Null" +
    ",Null," + ReturnDBString(dt客户.Rows[0]["cCusCode"]) + ",null," + ReturnDBString(dtGrid.Rows[i]["发运方式"]) + ",Null" +
    "," + ReturnDBString(dt币种.Rows[0]["cexch_name"]) + "," + ReturnDBString(dtGrid.Rows[i]["汇率"]) + "," + ReturnDBString(dtGrid.Rows[i]["税率"]) + ",Null,Null " +
    ",Null,Null,0," + lIDMain + ",Null" +
    ",N'" + sUserID + "',0,0,Null,Null" +
    ",Null,Null,Null,Null,Null" +
    ",Null,Null,Null,Null,Null" +
    ",Null,0," + ReturnDBString(dt客户.Rows[0]["cCusName"]) + ",Null,Null" +
    ",Null,Null,Null,Null,Null" +
    ",Null,0,Null,Null,0" +
    ",0,Null,0,Null,Null" +
    ",0,Null,Null,0,Null" +
    ",0,1,Null,0)    ";


                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                        else
                        {
                            lIDMain = SqlHelper.ReturnObjectToLong(dt发货单.Rows[0]["DLID"]);
                        }


                        #endregion


                        #region 导入表体数据

                        string s仓库 = dt仓库.Rows[0]["cWhCode"].ToString().Trim();

                        sSQL = "select count(1) from dispatchlists where dlid = " + lIDMain;
                        int i行号 = SqlHelper.ReturnObjectToInt(SqlHelper.ExecuteScalar(tran, CommandType.Text, sSQL));
                        i行号 += 1;
                      
                            lIDDetails += 1;


                            //decimal d数量 = SqlHelper.ReturnObjectToDecimal(dtGrid.Rows[i]["数量"]);
                            decimal d件数 = SqlHelper.ReturnObjectToDecimal(dtGrid.Rows[i]["件数"]);
                            decimal d原币无税单价 = SqlHelper.ReturnObjectToDecimal(dtGrid.Rows[i]["原币无税单价"]);
                            decimal d原币含税单价 = SqlHelper.ReturnObjectToDecimal(dtGrid.Rows[i]["原币含税单价"]);
                            decimal d原币无税金额 = SqlHelper.ReturnObjectToDecimal(dtGrid.Rows[i]["原币无税金额"]);
                            decimal d原币税额 = SqlHelper.ReturnObjectToDecimal(dtGrid.Rows[i]["原币税额"]);
                            decimal d原币价税合计 = SqlHelper.ReturnObjectToDecimal(dtGrid.Rows[i]["原币价税合计"]);
                            decimal d本币无税单价 = SqlHelper.ReturnObjectToDecimal(dtGrid.Rows[i]["本币无税单价"]);
                            decimal d本币含税单价 = SqlHelper.ReturnObjectToDecimal(dtGrid.Rows[i]["本币含税单价"]);
                            decimal d本币无税金额 = SqlHelper.ReturnObjectToDecimal(dtGrid.Rows[i]["本币无税金额"]);
                            decimal d本币税额 = SqlHelper.ReturnObjectToDecimal(dtGrid.Rows[i]["本币税额"]);
                            decimal d本币价税合计 = SqlHelper.ReturnObjectToDecimal(dtGrid.Rows[i]["本币价税合计"]);


                            decimal d换算率 = 0;
                            if (d件数 != 0)
                            {
                                d换算率 = SqlHelper.ReturnObjectToDecimal(d数量 / d件数, 6);
                            }

                            sSQL = @"
 Insert Into dispatchlists(dlid,cwhcode,cinvcode,iquantity,inum,iquotedprice,iunitprice,itaxunitprice,imoney,itax
        ,isum,idiscount,inatunitprice,inatmoney,inattax,inatsum,inatdiscount,ibatch,cbatch,cfree1
        ,cfree2,itb,tbquantity,isosid,idlsid,kl,kl2,cinvname,itaxrate,fsalecost
        ,fsaleprice,cfree3,cfree4,cfree5,cfree6,cfree7,cfree8,cfree9,cfree10,cunitid
        ,ccode,bgsp,csocode,imassdate,cmassunit,bqaneedcheck,bqaurgency,bcosting,cordercode,iorderrowno
        ,fcusminprice,cvmivencode,irowno,iexpiratdatecalcu,cexpirationdate,cbatchproperty1,cbatchproperty2,cbatchproperty3,cbatchproperty4,cbatchproperty5
        ,cbatchproperty6,cbatchproperty7,cbatchproperty8,cbatchproperty9,creasoncode,bneedsign,frlossqty,cinvouchtype) 
";
                            sSQL = sSQL + "Values (" + lIDMain + ",N'" + s仓库 + "',N'" + s存货编码 + "'," + d数量 + "," + d件数 + "," + d原币无税单价 + "," + d原币无税单价 + "," + d原币含税单价 + "," + d原币无税金额 + "," + d原币税额 + " " +
        "," + d原币价税合计 + ",0," + d本币无税单价 + "," + d本币无税金额 + "," + d本币税额 + "," + d本币价税合计 + ",0,Null,Null,Null" +
        ",Null,0,0,null," + ReturnID(lIDDetails) + ",100,100," + ReturnDBString(dt存货档案.Rows[0]["cInvName"]) + ",17,0" +
        ",0,Null,Null,Null,Null,Null,Null,Null,Null,Null" +
        ",Null,0,Null,Null,0,0,0,0,Null,Null" +
        ",0,Null," + i行号.ToString() + ",0,Null,Null,Null,Null,Null,Null" +
        ",Null,Null,Null,Null,Null,0,0,Null)";

                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    #endregion

                    if (sErr.Length > 0)
                    {
                        throw new Exception(sErr);
                    }

                    sSQL = "update UFSystem..UA_Identity set iFatherId = " + lID + ",iChildId = " + lIDDetails + " where cVouchType = 'DISPATCH' and cAcc_Id = '" + sAccID + "'";
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    tran.Commit();
                    MessageBox.Show("保存成功", "提示");

                    gridControl1.DataSource = null;
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
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }
           

        private long ReturnID(long l)
        {
            long l1 = 1000000000;
            return l1 + l;
        }

        private string GetColValue(object o)
        { 
            string s = "null";
            if (o.ToString().Trim() != "")
            {
                s = "'" + o.ToString().Trim() + "'";
            }
            return s;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                TH.BaseClass.ClsExcel clsExcel = TH.BaseClass.ClsExcel.Instance();

                OpenFileDialog oFile = new OpenFileDialog();
                oFile.Filter = "Excel文件|*.xls|Excel文件|*.xlsx";
                if (oFile.ShowDialog() == DialogResult.OK)
                {
                    string sFilePath = oFile.FileName;
                    string sSQL = "select * from [销售发货单$]";

                    DataTable dt = clsExcel.ExcelToDT(sFilePath, sSQL, true);

                    gridView1.Columns.Clear();

                    gridControl1.DataSource = dt;


                    if (dt == null || dt.Rows.Count < 1)
                        throw new Exception("加载的文件没有数据，请核实后继续");
                }
                else
                {
                    throw new Exception("取消导入");
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.richTextBox1.Text = ee.Message;
                f.Text = "加载失败";
                f.ShowDialog();
            }
        }


        //根据历史单据生成最新单据号
        private string ReturnCode(DateTime d, long o)
        {
            string s = o.ToString();
            int iLength = 4;

            for (int i = 0; i < iLength; i++)
            {
                if (s.Length < iLength)
                {
                    s = "0" + s;
                }
                else
                {
                    break;
                }
            }

            s = d.ToString("yyMM") + s;
            return s;
        }

        private string ReturnID(object o)
        {
            string s = o.ToString().Trim();
            for (int i = 0; i < 10; i++)
            {
                if (s.Length < 9)
                    s = "0" + s;
                else if (s.Length == 9)
                    s = "1" + s;
                else
                    break;
            }
            return s;
        }

        private string ReturnDBString(decimal o)
        {
            return o.ToString();
        }

        private string ReturnDBString(object o)
        {
            if (o.ToString().Trim() == "")
                return "null";
            else
            {
                return "'" + o.ToString().Trim() + "'";
            }
        }

 
        private void btnExcel_Click(object sender, EventArgs e)
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
                MessageBox.Show(ee.Message);
            }
        }
    }
}