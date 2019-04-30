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
    public partial class 收款单导入 : UserControl
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

        public 收款单导入()
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
                        sSQL = "select count(1) from Ap_CloseBill where cVouchID = '" + dtGrid.Rows[i]["单据号"].ToString().Trim() + "' ";
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

                    sSQL = "SELECT * FROM UFSystem..UA_Identity where cVouchType = 'SK' and cAcc_Id = '" + sAccID + "'";
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

                        sSQL = @"select bflag_AR,iyear ,iperiod,* from GL_mend 
where isnull(bflag_AR,0) = 0 and iperiod <> 0
order by iyear,iperiod ";
                        DataTable dt结账状态 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        DateTime d结账 = Convert.ToDateTime(dt结账状态.Rows[0]["iyear"].ToString().Trim() + "-" + dt结账状态.Rows[0]["iperiod"].ToString().Trim() + "-1");
                        if (d结账 > SqlHelper.ReturnObjectToDateTime(dtGrid.Rows[i]["单据日期"]))
                        {
                            sErr = sErr + "行" + (i + 1).ToString().Trim() + "该单据日期应收模块已结账\n";
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

                        sSQL = "select * from SettleStyle where cSSCode = '" + dtGrid.Rows[i]["结算方式"].ToString().Trim() + "' or cSSName = '" + dtGrid.Rows[i]["结算方式"].ToString().Trim() + "'";
                        DataTable dt结算方式 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt结算方式.Rows.Count == 0)
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "结算方式不存在\n";
                            continue;
                        }

                        sSQL = "select * from person where cPersonCode = '" + dtGrid.Rows[i]["业务员"].ToString().Trim() + "' or cPersonName = '" + dtGrid.Rows[i]["业务员"].ToString().Trim() + "'";
                        DataTable dt业务员 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt业务员.Rows.Count == 0)
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "业务员不存在\n";
                            continue;
                        }

                        sSQL = "select * from Department where isnull(bDepEnd,0) = 1 and  (cDepCode  = '" + dtGrid.Rows[i]["部门"].ToString().Trim() + "' or cDepName = '" + dtGrid.Rows[i]["部门"].ToString().Trim() + "')";
                        DataTable dt部门 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt部门.Rows.Count == 0)
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "部门不存在，或不是末级部门\n";
                            continue;
                        }
                        #endregion

                        #region 导入表头数据


                        sSQL = "select * from Ap_CloseBill where cVouchID = '" + dtGrid.Rows[i]["单据号"].ToString().Trim() + "'";
                        DataTable dt收款单 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                        if (dt收款单.Rows.Count == 0)
                        {
                            lID += 1;
                            lIDMain = ReturnID(lID);

                            //cVouchType 48  表示收款单
                            sSQL = @"Insert Into Ap_CloseBill (cVouchType,cVouchID,dVouchDate,iPeriod,cDwCode,cDeptCode,cPerson,cItem_Class,cSSCode,cNoteNo" +
                                            ",cCoVouchType,cCoVouchID,cBankAccount,cexch_name,iExchRate,iAmount,iAmount_f,iRAmount,iRAmount_f,cOperator" +

                                            ",cCancelMan,bStartFlag,cCode,iPayForOther,cFlag,iID,cCancelNo,cBank,bFromBank,bToBank" +
                                            ",bSure,VT_ID,cCheckMan,iAmount_s,iSource,dcreatesystime,dverifysystime,dverifydate) " +
                                   "Values (N'48'," + ReturnDBString(dtGrid.Rows[i]["单据号"]) + "," + ReturnDBString(dtGrid.Rows[i]["单据日期"]) + "," + Convert.ToDateTime(dtGrid.Rows[i]["单据日期"]).Month + "," + ReturnDBString(dt客户.Rows[0]["cCusCode"]) + ",'" + dt部门.Rows[0]["cDepCode"].ToString().Trim() + "','" + dt业务员.Rows[0]["cPersonCode"].ToString().Trim() + "',null," + ReturnDBString(dt结算方式.Rows[0]["cSSCode"]) + ",null" +
                                            ",null,null," + ReturnDBString(dt客户.Rows[0]["cCusAccount"]) + "," + ReturnDBString(dt币种.Rows[0]["cexch_name"]) + "," + ReturnDBString(dtGrid.Rows[i]["汇率"]) + "," + ReturnDBString(dtGrid.Rows[i]["本币金额"]) + "," + ReturnDBString(dtGrid.Rows[i]["原币金额"]) + "," + ReturnDBString(dtGrid.Rows[i]["本币金额"]) + "," + ReturnDBString(dtGrid.Rows[i]["原币金额"]) + ",N'" + sUserName + "'" +

                                            ",null,0," + ReturnDBString(dtGrid.Rows[i]["结算科目"]) + ",0,N'AR'," + lIDMain + ",null," + ReturnDBString(dt客户.Rows[0]["cCusBank"]) + ",0,0" +
                                            ",0,8052,null,0,null,GETDATE(),null,null) ";


                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                        else
                        {
                            lIDMain = SqlHelper.ReturnObjectToLong(dt收款单.Rows[0]["iID"]);
                        }


                        #endregion


                        #region 导入表体数据

                        lIDDetails += 1;

                        sSQL = "INSERT INTO Ap_CloseBills (iID,ID,iType,bPrePay,cCusVen,iAmt_f,iAmt,iRAmt_f,iRAmt,cKm," +
                                    "cXmClass,cDepCode,iAmt_s,iRAmt_s,iOrderType) " +
                               "VALUES " +
                            "(" + lIDMain + "," + ReturnID(lIDDetails) + ",0,0," + ReturnDBString(dt客户.Rows[0]["cCusCode"]) + "," + ReturnDBString(dtGrid.Rows[i]["原币金额"]) + "," + ReturnDBString(dtGrid.Rows[i]["本币金额"]) + "," + ReturnDBString(dtGrid.Rows[i]["原币金额"]) + "," + ReturnDBString(dtGrid.Rows[i]["本币金额"]) + "," + ReturnDBString(dtGrid.Rows[i]["贷方科目"]) + "," +
                                    "NULL,NULL,0,0,NULL)";
                     
                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    #endregion

                    if (sErr.Length > 0)
                    {
                        throw new Exception(sErr);
                    }

                    sSQL = "update UFSystem..UA_Identity set iFatherId = " + lID + ",iChildId = " + lIDDetails + " where cVouchType = 'SK' and cAcc_Id = '" + sAccID + "'";
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
                    string sSQL = "select * from [收款单$]";

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

        private string ReturnDBString(DateTime o)
        {
            return o.ToString("yyyy-MM-dd");
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