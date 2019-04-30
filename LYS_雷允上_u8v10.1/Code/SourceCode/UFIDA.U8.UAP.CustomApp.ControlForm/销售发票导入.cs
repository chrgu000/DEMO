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
    public partial class 销售发票导入 : UserControl
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

        public 销售发票导入()
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

                DataTable dtGrid = (DataTable)gridControl1.DataSource;

                string sErr = "";
                string sSQL = "";

                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    for (int i = 0; i < dtGrid.Rows.Count; i++)
                    {
                        sSQL = "select count(1) from SaleBillVouch where cSBVCode = '" + dtGrid.Rows[i]["发票号"].ToString().Trim() + "' ";
                        int iCou = SqlHelper.ReturnObjectToInt(SqlHelper.ExecuteScalar(tran, CommandType.Text, sSQL));
                        if (iCou > 0)
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "发票号已存在\n";
                            continue;
                        }
                    }

                    if (sErr.Length > 0)
                    {
                        throw new Exception(sErr);
                    }


                    sSQL = "SELECT iFatherId,iChildId FROM UFSystem..UA_Identity where cVouchType = 'BILLVOUCH' and cAcc_Id = '" + sAccID + "'";
                    DataTable dt = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    long lID=0;
                    long lIDMain=0;
                     long lIDDetail=0;
                     if (dt != null && dt.Rows.Count > 0)
                     {
                         lID = SqlHelper.ReturnObjectToLong(dt.Rows[0]["iFatherId"]);

                         lIDMain = lID;
                         lIDDetail = SqlHelper.ReturnObjectToLong(dt.Rows[0]["iChildId"]);
                     }

                    for (int i = 0; i < dtGrid.Rows.Count; i++)
                    {
                        #region 数据验证

                        sSQL = "select * from Inventory where cInvCode = '" + dtGrid.Rows[i]["存货编码"].ToString().Trim() + "'";
                        DataTable dt存货 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt存货.Rows.Count == 0)
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "存货不存在\n";
                            continue;
                        }

                        sSQL = "select * from SaleType  where cSTCode  = '" + dtGrid.Rows[i]["销售类型"].ToString().Trim() + "'";
                        DataTable dt销售类型 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt销售类型.Rows.Count == 0)
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "销售类型不存在\n";
                            continue;
                        }

                        sSQL = "select * from Customer where cCusCode = '" + dtGrid.Rows[i]["客户编码"].ToString().Trim() + "'";
                        DataTable dt客户 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt客户.Rows.Count == 0)
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "客户编码不存在\n";
                            continue;
                        }

                        sSQL = "select * from Department where cDepCode = '" + dtGrid.Rows[i]["销售部门"].ToString().Trim() + "'";
                        DataTable dt部门 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt部门.Rows.Count == 0)
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "销售部门不存在\n";
                            continue;
                        }

                        sSQL = "select * from Warehouse where cWhCode = '" + dtGrid.Rows[i]["仓库编码"].ToString().Trim() + "'";
                        DataTable dt仓库 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt仓库.Rows.Count == 0)
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "仓库编码不存在\n";
                            continue;
                        }

                        sSQL = "select * from foreigncurrency where cexch_code = '" + dtGrid.Rows[i]["币种"].ToString().Trim() + "' or cexch_name = '" + dtGrid.Rows[i]["币种"].ToString().Trim() + "'";
                        DataTable dt币种 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt币种.Rows.Count == 0)
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "币种不存在\n";
                            continue;
                        }

                        sSQL = "select * from person where cPersonCode = '" + dtGrid.Rows[i]["业务员"].ToString().Trim() + "' or cPersonName = '" + dtGrid.Rows[i]["业务员"].ToString().Trim() + "'";
                        DataTable dt业务员 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt业务员.Rows.Count == 0)
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "业务员不存在\n";
                            continue;
                        }


                        #endregion


                        sSQL = "select * from salebillvouch where csbvcode = '" + dtGrid.Rows[i]["发票号"].ToString().Trim() + "'";
                        DataTable dt销售发票 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                        if (dt销售发票.Rows.Count == 0)
                        {
                            lID += 1;
                            lIDMain = ReturnID(lID);

                            sSQL = "select * from Bank";
                            DataTable dt开户银行 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];


                            string s发票类型 = "";
                            if (dtGrid.Rows[i]["单据类型"].ToString().Trim() == "增值税专用发票")           //0 专用发票；1 普通发票
                                s发票类型 = "26";

                            if (dtGrid.Rows[i]["单据类型"].ToString().Trim() == "增值税普通发票")
                                s发票类型 = "27";

                            if (s发票类型 == "")
                            {
                                sErr = sErr + "行" + (i + 1).ToString() + "单据类型不存在\n";
                                continue;
                            }


                            int i红蓝标志 = 0;
                            if (SqlHelper.ReturnObjectToDecimal(dtGrid.Rows[i]["数量"], 2) < 0 || SqlHelper.ReturnObjectToDecimal(dtGrid.Rows[i]["原币价税合计"], 2) < 0)
                            {
                                i红蓝标志 = 1;
                            }

                            sSQL = " Insert Into salebillvouch(ivtid,csource,cstcode,cdepcode,ccuscode,ccusbank,ccusaccount,bcashsale,sbvid,csbvcode" +
                                        ",cvouchtype,ddate,csocode,cdefine2,cmaker,cverifier,iexchrate,itaxrate,breturnflag,bfirst" +

                                        ",cbustype,cbcode,cexch_name,ccusname,idisp,cdlcode,cchecker,iflowid,bcredit,ioutgolden" +
                                        ",iverifystate,iswfcontrolled,iprintcount,cgatheringplan,icreditdays,cPersonCode ) " +

                                   "Values (53,N'销售',N'" + dtGrid.Rows[i]["销售类型"].ToString().Trim() + "',N'" + dtGrid.Rows[i]["销售部门"].ToString().Trim() + "',N'" + dtGrid.Rows[i]["客户编码"].ToString().Trim() + "',N'" + dt客户.Rows[0]["cCusBank"].ToString().Trim() + "',N'" + dt客户.Rows[0]["cCusAccount"].ToString().Trim() + "',0," + lIDMain + ",N'" + dtGrid.Rows[i]["发票号"].ToString().Trim() + "'" +
                                   ",N'" + s发票类型 + "','" + dtGrid.Rows[i]["开票日期"].ToString().Trim() + "',Null,Null,N'" + sUserName + "',Null," + dtGrid.Rows[i]["汇率"].ToString().Trim() + "," + dtGrid.Rows[i]["税率"].ToString().Trim() + "," + i红蓝标志 + ",0" +

                                   ",N'普通销售',N'" + dt开户银行.Rows[0]["cBCode"].ToString().Trim() + "',N'" + dt币种.Rows[0]["cexch_name"].ToString().Trim() + "',N'" + dt客户.Rows[0]["cCusName"].ToString().Trim() + "',0,Null,Null,Null,0,Null" +
                                   ",0,0,Null,Null,Null,'" + dt业务员.Rows[0]["cPersonCode"].ToString().Trim() + "')";

                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                        else
                        {
                            lIDMain = SqlHelper.ReturnObjectToLong(dt销售发票.Rows[0]["SBVID"]);
                        }

                        lIDDetail += 1;

                        decimal d数量 = SqlHelper.ReturnObjectToDecimal(dtGrid.Rows[i]["数量"]);
                        decimal d件数 = SqlHelper.ReturnObjectToDecimal(dtGrid.Rows[i]["件数"]);
                        decimal d换算率 = 0;
                        if (d件数 != 0)
                        {
                            d换算率 = SqlHelper.ReturnObjectToDecimal(d数量 / d件数, 6);
                        }

                        sSQL = "Insert Into salebillvouchs(sbvid,autoid,cwhcode,cinvcode,iquantity,inum,iquotedprice,iunitprice,itaxunitprice,imoney" +
                                        ",itax,isum,idiscount,inatunitprice,inatmoney,inattax,inatsum,inatdiscount,isbvid,imoneysum" +
                                        ",iexchsum,cclue,cincomesub,ctaxsub,ibatch,cbatch,bsettleall,rdsid,itb,tbquantity" +
                                        ",isosid,idlsid,kl,kl2,cinvname,itaxrate,foutquantity,foutnum,fsalecost,fsaleprice" +

                                        ",iinvexchrate,cunitid,ipbvsid,ccode,csocode,bgsp,ccontractid,ccontracttagcode,ccontractrowguid,cmassunit" +
                                        ",bqaneedcheck,bqaurgency,cbaccounter,bcosting,cordercode,iorderrowno,fcusminprice,irowno,iexpiratdatecalcu,idemandtype" +
                                        ",cdemandcode,cdemandmemo,cdemandid,idemandseq,cbdlcode,iinvsncount,bneedsign,cgathingcode,ftaxpasum,fpasum" +
                                        ",fnattaxpasum,fnatpasum,body_outid,cinvouchtype,icostquantity,icostsum)" +
                              " Values (" + lIDMain + "," + ReturnID(lIDDetail) + ",N'" + dtGrid.Rows[i]["仓库编码"].ToString().Trim() + "',N'" + dtGrid.Rows[i]["存货编码"].ToString().Trim() + "'," + d数量 + "," + d件数 + ",0," + SqlHelper.ReturnObjectToDecimal(dtGrid.Rows[i]["原币无税单价"]) + "," + SqlHelper.ReturnObjectToDecimal(dtGrid.Rows[i]["原币含税单价"]) + "," + SqlHelper.ReturnObjectToDecimal(dtGrid.Rows[i]["原币无税金额"]) + "" +
                                        "," + dtGrid.Rows[i]["原币税额"].ToString().Trim() + "," + dtGrid.Rows[i]["原币价税合计"].ToString().Trim() + ",0," + dtGrid.Rows[i]["本币无税单价"].ToString().Trim() + "," + dtGrid.Rows[i]["本币无税金额"].ToString().Trim() + "," + dtGrid.Rows[i]["本币税额"].ToString().Trim() + "," + dtGrid.Rows[i]["本币价税合计"].ToString().Trim() + ",0,0,0" +
                                        ",0,Null,Null,Null,Null,Null,0,Null,0,0" +
                                        ",Null,Null,100,100,N'" + dt存货.Rows[0]["cInvName"].ToString().Trim() + "'," + dtGrid.Rows[i]["税率"].ToString().Trim() + ",0,0,0,0" +
                                        "," + d换算率 + ",N'" + dt存货.Rows[0]["cComUnitCode"].ToString().Trim() + "',Null,Null,Null,0,Null,Null,Null,0" +
                                        ",0,0,Null,1,Null,Null,0,1,0,Null" +
                                        ",Null,Null,Null,Null,Null,0,0,Null,0,Null" +
                                        ",0,0,Null,Null,Null,Null)";
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }


                    if (sErr.Length > 0)
                    {
                        throw new Exception(sErr);
                    }


                    sSQL = "update  UFSystem..UA_Identity set iFatherId = " + lID + ",iChildId = " + lIDDetail + " where cVouchType = 'BILLVOUCH' and cAcc_Id = '" + sAccID + "'";
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    tran.Commit();
                    MessageBox.Show("导入成功");
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
                    string sSQL = "select * from [销售发票$]";

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