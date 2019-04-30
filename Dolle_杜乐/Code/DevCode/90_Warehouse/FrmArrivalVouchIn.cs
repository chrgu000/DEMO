using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;


namespace Warehouse
{
    public partial class FrmArrivalVouchIn : FrameBaseFunction.Frm列表窗体模板
    {
        ArrayList aList;
        bool IsBack = false;
        public FrmArrivalVouchIn()
        {
            InitializeComponent();
        }

        int iTaxRate_All = FrameBaseFunction.ClsBaseDataInfo.iTaxRate_All_QJ;
        DataTable dtTable;
        private void FrmArrivalVouchIn_Load(object sender, EventArgs e)
        {
            txtBarCode.Focus();
            date1.Text = FrameBaseFunction.ClsBaseDataInfo.sLogDate;
            date1.Properties.ReadOnly = false;
            try
            {
                GetcWhCode();

                string sSQL = "SELECT cDefine2,'' as 外销订单号,'' as cDepCode,'' as 请购单号,'' as 业务员,'' as 加工费单价, '' as 含税单价,'' as 原币无税单价,'' as 本币无税单价,'' as 税率 ,'' as cComUnitName1,'' as cComUnitName2,'' as cComUnitCode,'' as cAssComUnitCode,''as FaChuCaiLiaoQty,''as FaChuCaiLiaoNum,'' as bUsed,'' as OrderType,p.moid,pD.MODetailsID AS OrderID, p.cCode AS OrderNo,p.cVenCode,pD.cInvCode AS cInvCode, i.cInvName AS cInvName, i.cInvStd AS cInvStd, pD.iQuantity AS iQuantity,pD.iNum,'' as NowQuantity,'' as NowNum,i.cDefWareHouse,'' as iArrQty1,'' as iArrNum1,'' as iOMoDID,'' as iOMoMID,'' as fInExcess,'' as bChoose,'' as iWIPtype " +
                    "FROM @u8.OM_MOMain p LEFT OUTER JOIN @u8.OM_MODetails pD ON p.MOID = pD.MOID  	LEFT OUTER JOIN @u8.Inventory i ON i.cInvCode = pD.cInvCode " +
                    "WHERE 1=-1";

                dtTable = clsSQLCommond.ExecQuery(sSQL);
                gridControl1.DataSource = dtTable;

                txtBarCode.Enabled = true; txtBarCode.ReadOnly = false;
                txtRowCount.Enabled = true; txtRowCount.ReadOnly = false;

                date1.Enabled = true;
                date1.Properties.ReadOnly = false;

            }
            catch { }
        }

        protected override void BtnClick(string sBtnName, string sBtnText)
        {
            try
            {
                switch (sBtnName.ToLower())
                {
                    case "import":
                        btnImport();
                        break;
                    case "delrow":
                        btnDel();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(sBtnText + " 失败! \n\n原因:\n  " + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDel()
        {
            try
            {
                int iRow = gridView1.FocusedRowHandle;
                gridView1.DeleteRow(iRow);
            }
            catch { }
        }

        private void CheckQty()
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                double d1 = 0;//订单数量
                try
                {
                    d1 = Convert.ToDouble(gridView1.GetRowCellValue(i, gridColiQuantity));
                }
                catch { }
                double d2 = 0;//订单件数
                try
                {
                    d2 = Convert.ToDouble(gridView1.GetRowCellValue(i, gridColiNum));
                }
                catch { }
                double d3 = 0;//超订单比率
                try
                {
                    d3 = Convert.ToDouble(gridView1.GetRowCellValue(i, gridColfInExcess));
                }
                catch { }
                double d4 = 0;//未入库数量
                try
                {
                    d4 = Convert.ToDouble(gridView1.GetRowCellValue(i, gridColiArrQty1));
                    d4 = d1 - d4;
                }
                catch { }
                double d5 = 0;//未入库件数
                try
                {
                    d5 = Convert.ToDouble(gridView1.GetRowCellValue(i, gridColiArrNum1));
                    d5 = d2 - d5;
                }
                catch { }
                double d6 = 0;//本次入库数量
                try
                {
                    d6 = Convert.ToDouble(gridView1.GetRowCellValue(i, gridColNowQuantity));
                }
                catch { }
                double d7 = 0;//本次入库件数
                try
                {
                    d7 = Convert.ToDouble(gridView1.GetRowCellValue(i, gridColNowNum));
                }
                catch { }

                if ((d1 * (1 + d3) < d4 + d6) || (d2 > 0 && d2 * (1 + d3) < d5 + d7))
                {
                    gridView1.SetRowCellValue(i, gridColbChoose, "√");
                }
                else
                {
                    gridView1.SetRowCellValue(i, gridColbChoose, "");
                }

            }
        }

        long iID = 0;
        long iIDDetail = 0;
        long iIDArr = 0;
        long iIDDetailArr = 0;

        long iIDBack = 0;
        long iIDBackDetail = 0;

        //单据号
        long iCode = 0;
        long iCodeArr = 0;
        long iCodeBack = 0;
        private void btnImport()
        {
            CheckQty();

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridColbChoose).ToString().Trim() == "√")
                {
                    MessageBox.Show("存在超订单入库的行，请核查！");
                    return;
                }
            }
            
            int iYear = int.Parse(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4));
            int iYear2 = int.Parse(date1.DateTime.ToString("yyyy"));
            string sSQL = "";

            if (iYear >= iYear2)
            {
                sSQL = "select * from @u8.GL_mend where iperiod = month('" + date1.DateTime.ToString("yyyy-MM-dd") + "')";
                DataTable dtTemp1 = clsSQLCommond.ExecQuery(sSQL);
                if (Convert.ToBoolean(dtTemp1.Rows[0]["bflag_ST"]) == true)
                {
                    MessageBox.Show("当月库存管理已结帐，不能录入数据！");
                    return;
                }
            }
            try
            {
                gridView1.FocusedRowHandle -= 1;
            }
            catch { }
            DataTable dt = (DataTable)gridControl1.DataSource;


            //for (int i = 0; i < gridView1.RowCount; i++)
            //{ //Appearance.BackColor = Color.Tomato;
            //    if (gridView1.setrow == Color.Tomato)
            //    {
            //        MessageBox.Show("存在超订单到货，请检查！");
            //        return;
            //    }
            //}

            if (txtRowCount.Text.Trim() == string.Empty)
            {
                MessageBox.Show("请扫描到货单行数信息！");
                txtBarCode.Focus();
                return;
            }

            if (dt.Rows.Count != Convert.ToInt32(txtRowCount.Text.Trim()))
            {
                MessageBox.Show("条码漏扫，请核查！");
                txtBarCode.Focus();
                return;
            }

            try
            {
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("请先导入条码！");
                    return;
                }

                aList = new ArrayList();

                //条码入库ID，单据号
                GetID("rd", out iID, out iIDDetail);
                sSQL = "select isnull(max(cNumber),0) as Maxnumber From @u8.VoucherHistory  with (NOLOCK) Where  CardNumber='24' and (cContent='日期' or cContent='单据日期') and (cSeed='" + DateTime.Parse(date1.DateTime.ToString("yyyy-MM-dd")).ToString("yyyyMM") + "' or cSeed='" + DateTime.Parse(date1.DateTime.ToString("yyyy-MM-dd")).ToString("yyMM") + "')";
                DataTable dtCode2 = clsSQLCommond.ExecQuery(sSQL);
                iCode = Convert.ToInt64(dtCode2.Rows[0]["Maxnumber"]);
                dtCode2 = null;

                //条码到货ID，单据号
                GetID("PuArrival", out iIDArr, out iIDDetailArr);
                sSQL = "select isnull(max(cNumber),0) as Maxnumber From @u8.VoucherHistory  with (NOLOCK) Where  CardNumber='26' and (cContent='日期' or cContent='单据日期') and (cSeed='" + DateTime.Parse(date1.DateTime.ToString("yyyy-MM-dd")).ToString("yyyyMM") + "' or cSeed='" + DateTime.Parse(date1.DateTime.ToString("yyyy-MM-dd")).ToString("yyMM") + "')";
                DataTable dtCode = clsSQLCommond.ExecQuery(sSQL);
                iCodeArr = Convert.ToInt64(dtCode.Rows[0]["Maxnumber"]);
                dtCode = null;

                //委外退货单,单据号
                GetID("rd", out iIDBack, out iIDBackDetail);
                sSQL = "select isnull(max(cNumber),0) as Maxnumber From @u8.VoucherHistory  with (NOLOCK) Where  CardNumber='0412' and (cContent='日期' or cContent='单据日期') and (cSeed='" + DateTime.Parse(date1.DateTime.ToString("yyyy-MM-dd")).ToString("yyyyMM") + "' or cSeed='" + DateTime.Parse(date1.DateTime.ToString("yyyy-MM-dd")).ToString("yyMM") + "')";
                DataTable dtCodeBack = clsSQLCommond.ExecQuery(sSQL);
                iCodeBack = Convert.ToInt64(dtCodeBack.Rows[0]["Maxnumber"]);
                dtCodeBack = null;

                string sInfo1 = "";
                string sInfo2 = "";
                string sInfo3 = "";
                string sInfo4 = "";

                string sInfo5 = "";
                DataRow[] dr0 = dt.Select("ordertype=0");
                //if (dr0.Length > 0)
                //{
                //    ImportStock0(dr0, out sInfo1);

                //    sSQL = "update UFSystem..UA_Identity set iFatherID = " + iID + ",iChildID=" + iIDDetail + "  where cAcc_Id = '200' and cVouchType = 'rd'";
                //    aList.Add(sSQL);

                //    //更改最大单据号
                //    sSQL = "select count(*) as iCount From @u8.VoucherHistory  with (NOLOCK) Where CardNumber='24' and (cContent='日期' or cContent='单据日期') and (cSeed='" + DateTime.Parse(date1.DateTime.ToString("yyyy-MM-dd")).ToString("yyyyMM") + "' or cSeed='" + DateTime.Parse(date1.DateTime.ToString("yyyy-MM-dd")).ToString("yyMM") + "')";
                //    DataTable dtCodeTemp = clsSQLCommond.ExecQuery(sSQL);
                //    if (dtCodeTemp.Rows[0]["iCount"].ToString().Trim() == "0")
                //    {
                //        sSQL = "insert into @u8.VoucherHistory(cardnumber,ccontent,ccontentrule,cseed,cnumber,bempty)values('24','日期','月','" + DateTime.Parse(date1.DateTime.ToString("yyyy-MM-dd")).ToString("yyMM") + "','1',0)";
                //        aList.Add(sSQL);
                //    }
                //    else
                //    {
                //        sSQL = "update @u8.VoucherHistory set cNumber = '" + iCode.ToString().Trim() + "' Where CardNumber='24' and (cContent='日期' or cContent='单据日期') and (cSeed='" + DateTime.Parse(date1.DateTime.ToString("yyyy-MM-dd")).ToString("yyyyMM") + "' or cSeed='" + DateTime.Parse(date1.DateTime.ToString("yyyy-MM-dd")).ToString("yyMM") + "')";
                //        aList.Add(sSQL);
                //    }
                //}

                //DataRow[] dr1 = dt.Select("ordertype=1");
                //if (dr1.Length > 0)
                //{
                //    ImportProcess0(dr1, out sInfo2);

                //    sSQL = "update UFSystem..UA_Identity set iFatherID = " + iID + ",iChildID=" + iIDDetail + "  where cAcc_Id = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3) + "' and cVouchType = 'rd'";
                //    aList.Add(sSQL);

                //    //更改最大单据号
                //    sSQL = "select count(*) as iCount From @u8.VoucherHistory  with (NOLOCK) Where CardNumber='24' and (cContent='日期' or cContent='单据日期') and (cSeed='" + DateTime.Parse(date1.DateTime.ToString("yyyy-MM-dd")).ToString("yyyyMM") + "' or cSeed='" + DateTime.Parse(date1.DateTime.ToString("yyyy-MM-dd")).ToString("yyMM") + "')";
                //    DataTable dtCodeTemp = clsSQLCommond.ExecQuery(sSQL);
                //    if (dtCodeTemp.Rows[0]["iCount"].ToString().Trim() == "0")
                //    {
                //        sSQL = "insert into @u8.VoucherHistory(cardnumber,ccontent,ccontentrule,cseed,cnumber,bempty)values('24','日期','月','" + DateTime.Parse(date1.DateTime.ToString("yyyy-MM-dd")).ToString("yyMM") + "','1',0)";
                //        aList.Add(sSQL);
                //    }
                //    else
                //    {
                //        sSQL = "update @u8.VoucherHistory set cNumber = '" + iCode.ToString().Trim() + "' Where CardNumber='24' and (cContent='日期' or cContent='单据日期') and (cSeed='" + DateTime.Parse(date1.DateTime.ToString("yyyy-MM-dd")).ToString("yyyyMM") + "' or cSeed='" + DateTime.Parse(date1.DateTime.ToString("yyyy-MM-dd")).ToString("yyMM") + "')";
                //        aList.Add(sSQL);
                //    }
                //}

                //DataRow[] dr2 = dt.Select("ordertype=2");
                //if (dr2.Length > 0)
                //{
                //    ImportStock(dr2, out sInfo3);

                //    sSQL = "update UFSystem..UA_Identity set iFatherID = " + iIDArr + ",iChildID=" + iIDDetailArr + "  where cAcc_Id = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3) + "' and cVouchType = 'PuArrival'";
                //    aList.Add(sSQL);

                //    //更新最大单据号
                //    sSQL = "select count(*) as iCount From @u8.VoucherHistory  with (NOLOCK) Where  CardNumber='26' and (cContent='日期' or cContent='单据日期') and (cSeed='" + DateTime.Parse(date1.DateTime.ToString("yyyy-MM-dd")).ToString("yyyyMM") + "' or cSeed='" + DateTime.Parse(date1.DateTime.ToString("yyyy-MM-dd")).ToString("yyMM") + "')";
                //    DataTable dtCodeTemp = clsSQLCommond.ExecQuery(sSQL);
                //    if (dtCodeTemp.Rows[0]["iCount"].ToString().Trim() == "0")
                //    {
                //        sSQL = "insert into @u8.VoucherHistory(cardnumber,ccontent,ccontentrule,cseed,cnumber,bempty)values('26','单据日期','月','" + DateTime.Parse(date1.DateTime.ToString("yyyy-MM-dd")).ToString("yyMM") + "','1',0)";
                //        aList.Add(sSQL);
                //    }
                //    else
                //    {
                //        sSQL = "update @u8.VoucherHistory set cNumber = '" + iCodeArr.ToString().Trim() + "' Where  CardNumber='26' and (cContent='日期' or cContent='单据日期') and (cSeed='" + DateTime.Parse(date1.DateTime.ToString("yyyy-MM-dd")).ToString("yyyyMM") + "' or cSeed='" + DateTime.Parse(date1.DateTime.ToString("yyyy-MM-dd")).ToString("yyMM") + "')";
                //        aList.Add(sSQL);
                //    }
                //}


                //DataRow[] dr3 = dt.Select("ordertype=3");
                //if (dr3.Length > 0)
                //{
                //ImportProcess(dr3, out sInfo4);

                //    sSQL = "update UFSystem..UA_Identity set iFatherID = " + iIDArr + ",iChildID=" + iIDDetailArr + "  where cAcc_Id = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3) + "' and cVouchType = 'PuArrival'";
                //    aList.Add(sSQL);

                //    //更新最大单据号
                //    sSQL = "select count(*) as iCount From @u8.VoucherHistory  with (NOLOCK) Where  CardNumber='26' and (cContent='日期' or cContent='单据日期') and (cSeed='" + DateTime.Parse(date1.DateTime.ToString("yyyy-MM-dd")).ToString("yyyyMM") + "' or cSeed='" + DateTime.Parse(date1.DateTime.ToString("yyyy-MM-dd")).ToString("yyMM") + "')";
                //    DataTable dtCodeTemp = clsSQLCommond.ExecQuery(sSQL);
                //    if (dtCodeTemp.Rows[0]["iCount"].ToString().Trim() == "0")
                //    {
                //        sSQL = "insert into @u8.VoucherHistory(cardnumber,ccontent,ccontentrule,cseed,cnumber,bempty)values('26','单据日期','月','" + DateTime.Parse(date1.DateTime.ToString("yyyy-MM-dd")).ToString("yyMM") + "','1',0)";
                //        aList.Add(sSQL);
                //    }
                //    else
                //    {
                //        sSQL = "update @u8.VoucherHistory set cNumber = '" + iCodeArr.ToString().Trim() + "' Where  CardNumber='26' and (cContent='日期' or cContent='单据日期') and (cSeed='" + DateTime.Parse(date1.DateTime.ToString("yyyy-MM-dd")).ToString("yyyyMM") + "' or cSeed='" + DateTime.Parse(date1.DateTime.ToString("yyyy-MM-dd")).ToString("yyMM") + "')";
                //        aList.Add(sSQL);
                //    }
                //}

                DataRow[] dr4 = dt.Select("ordertype=4");
                if (dr4.Length > 0)
                {
                    ImportProcess5(dr4, out sInfo5);

                    if (iIDBack >= 1000000000)
                        iIDBack = iIDBack - 1000000000;
                    if (iIDBackDetail >= 1000000000)
                        iIDBackDetail = iIDBackDetail - 1000000000;

                    sSQL = "update UFSystem..UA_Identity set iFatherID = " + iIDBack + ",iChildID=" + iIDBackDetail + "  where cAcc_Id = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3) + "' and cVouchType = 'rd'";
                    aList.Add(sSQL);

                    //更改最大单据号
                    sSQL = "select count(*) as iCount From @u8.VoucherHistory  with (NOLOCK) Where CardNumber='0412' and (cContent='日期' or cContent='单据日期') and (cSeed='" + DateTime.Parse(date1.DateTime.ToString("yyyy-MM-dd")).ToString("yyyyMM") + "' or cSeed='" + DateTime.Parse(date1.DateTime.ToString("yyyy-MM-dd")).ToString("yyMM") + "')";
                    DataTable dtCodeTemp = clsSQLCommond.ExecQuery(sSQL);
                    if (dtCodeTemp.Rows[0]["iCount"].ToString().Trim() == "0")
                    {
                        sSQL = "insert into @u8.VoucherHistory(cardnumber,ccontent,ccontentrule,cseed,cnumber,bempty)values('0412','日期','月','" + DateTime.Parse(date1.DateTime.ToString("yyyy-MM-dd")).ToString("yyMM") + "','1',0)";
                        aList.Add(sSQL);
                    }
                    else
                    {
                        sSQL = "update @u8.VoucherHistory set cNumber = '" + iCodeBack.ToString().Trim() + "' Where CardNumber='0412' and (cContent='日期' or cContent='单据日期') and (cSeed='" + DateTime.Parse(date1.DateTime.ToString("yyyy-MM-dd")).ToString("yyyyMM") + "' or cSeed='" + DateTime.Parse(date1.DateTime.ToString("yyyy-MM-dd")).ToString("yyMM") + "')";
                        aList.Add(sSQL);
                    }
                }

                int iCou = clsSQLCommond.ExecSqlTran(aList);
                dtTable.Rows.Clear();
                txtRowCount.Text = "";

                string sInfo = "";
                if (sInfo1.Trim().Length > 0)
                {
                    sInfo1 = "\n采购入库单:" + sInfo1;
                    sInfo = sInfo + sInfo1;
                }
                if (sInfo2.Trim().Length > 0)
                {
                    sInfo2 = "\n委外入库单:" + sInfo2;
                    sInfo = sInfo + sInfo2;
                }
                if (sInfo3.Trim().Length > 0)
                {
                    sInfo3 = "\n采购到货单:" + sInfo3;
                    sInfo = sInfo + sInfo3;
                }
                if (sInfo4.Trim().Length > 0)
                {
                    sInfo4 = "\n委外到货单:" + sInfo4;
                    sInfo = sInfo + sInfo4;
                }
                if (sInfo5.Trim().Length > 0)
                {
                    sInfo5 = "\n委外退货单:" + sInfo5;
                    sInfo = sInfo + sInfo5;
                }
                if (sInfo.Trim().Length > 0)
                {
                    MsgBox("导入单据成功", sInfo);
                }
            }
            catch (Exception ee)
            {
                FrmArrivalVouchIn_Load(null, null);
                aList = new ArrayList();
                throw new Exception(ee.Message);
            }
        }

        /// <summary>
        /// 导入委外入库单
        /// </summary>
        /// <param name="dr2"></param>
        private void ImportProcess0(DataRow[] dr2, out string sInfo)
        {
            string sSQL = "";
            sInfo = "";

            try
            {
                gridView1.FocusedRowHandle -= 1;
            }
            catch { }

            for (int i = 0; i < dr2.Length; i++)
            {
                if (dr2[i]["bUsed"].ToString().Trim() == "-1")
                {
                    iCode += 1;
                    string sRDCode = sSetCode(iCode);

                    iID += 1;
                    iIDDetail += 1;
                    //表头
                    sSQL = "insert into @u8.rdrecord(id,brdflag,cvouchtype,cbustype,csource,cwhcode,ddate,ccode,crdcode,cdepcode," +
                                "cptcode,cvencode,cmaker,cdefine7,bpufirst,vt_id,bisstqc,ipurorderid,itaxrate,iexchrate,cexch_name," +
                                "bomfirst,idiscounttaxtype,iswfcontrolled,dnmaketime,dnmodifytime,dnverifytime,bcredit)" +
                            "values (" + iID + ",1,N'01',N'委外加工',N'委外订单',N'" + dr2[i]["cDefWareHouse"].ToString().Trim() + "','" + date1.DateTime.ToString("yyyy-MM-dd") + "',N'" + sRDCode + "',N'111',N'905'," +
                                "N'02',N'" + dr2[i]["cVenCode"].ToString().Trim() + "',N'" + FrameBaseFunction.ClsBaseDataInfo.sUserName.Trim() + "',0,0,27,0," + dr2[i]["moid"].ToString().Trim() + ",N'0',1,N'人民币'," +
                                "0,N'0',0, getdate(), Null , Null ,N'0')";
                    aList.Add(sSQL);


                    sInfo = sInfo + sRDCode + ";";

                    //表体 

                    string s1 = "null";
                    if (dr2[i]["NowNum"].ToString().Trim() != string.Empty)
                        s1 = dr2[i]["NowNum"].ToString().Trim();
                    if (s1 == "null" || double.Parse(s1) == 0)
                        s1 = "null";
                    string s2 = "null";
                    if (dr2[i]["NowQuantity"].ToString().Trim() != string.Empty)
                        s2 = dr2[i]["NowQuantity"].ToString().Trim();
                    string s3 = "null";
                    if (dr2[i]["iArrQty1"].ToString().Trim() != string.Empty)
                        s3 = dr2[i]["iArrQty1"].ToString().Trim();
                    if (s3 == "null" || s3.Trim() == "" || double.Parse(s3) < 0)
                        s3 = "null";

                    string s4 = "null";
                    if (dr2[i]["iArrNum1"].ToString().Trim() != string.Empty)
                        s4 = dr2[i]["iArrNum1"].ToString().Trim();
                    if (s4 == "null" || s4.Trim() == "" || double.Parse(s4) <= 0)
                        s4 = "null";

                    sSQL = "Insert Into @u8.rdrecords(autoid,id,cinvcode,inum,iquantity," +
                                "isquantity,isnum,imoney,cdefine26,cdefine27,inquantity,innum," +
                                "itaxrate,btaxcost,cpoid," +
                                "iprocesscost,iprocessfee,iomodid," +
                                "bcosting,iinvexchrate,corufts,iexpiratdatecalcu,isotype) " +
                            "Values (" + iIDDetail + "," + iID + ",N'" + dr2[i]["cInvcode"].ToString().Trim() + "'," + s1 + "," + s2 +
                                ",0,0,0,0,0," + s3 + "," + s4 + "," +
                                "0,1,N'" + dr2[i]["OrderNo"].ToString().Trim() +
                                "',0,0," + dr2[i]["orderid"].ToString().Trim() + "," +
                                "1,0,N'1610.3418',0,0)";
                    aList.Add(sSQL);

                    sSQL = "update @u8.rdrecords set iProcessFee=" + Convert.ToDouble(dr2[i]["加工费单价"]) * Convert.ToDouble(s2) + ",iProcessCost = " + dr2[i]["加工费单价"] +
                            " where autoid = " + iIDDetail;
                    aList.Add(sSQL);

                    sSQL = "update @u8.rdrecords set cAssUnit = i.cAssComUnitCode from @u8.inventory i where i.cinvcode = @u8.rdrecords.cinvcode and @u8.rdrecords.autoid = " + iIDDetail;
                    aList.Add(sSQL);

                    sSQL = "select * from @u8.OM_MODetails where MODetailsID = " + dr2[i]["orderid"].ToString().Trim();
                    DataTable dtPodetails = clsSQLCommond.ExecQuery(sSQL);
                    if (dtPodetails.Rows[0]["citemName"].ToString().Trim() != string.Empty)
                    {
                        sSQL = "update @u8.rdrecords set citem_class='" + dtPodetails.Rows[0]["citem_class"] + "',citemcode='" + dtPodetails.Rows[0]["citemName"] + "',cname='" + dtPodetails.Rows[0]["citemName"] + "',citemcname='外销订单项目' " +
                               " where autoid = " + iIDDetail;
                        aList.Add(sSQL);
                    }

                    sSQL = "update @u8.OM_MODetails set iReceivedQTY = isnull(iReceivedQTY,0) + " + s2 + ",iReceivedNum =  isnull(iReceivedNum,0) + " + s1 + " where MODetailsID = " + dr2[i]["orderid"].ToString().Trim();
                    aList.Add(sSQL);
                    //////现存量

                    if (s1 == "null")
                    {
                        sSQL = "if exists(select * from  @u8.CurrentStock where cInvCode = '" + dr2[i]["cInvcode"].ToString().Trim() + "' and cWhCode = '" + dr2[i]["cDefWareHouse"].ToString().Trim() + "') " +
                      "	update  @u8.CurrentStock set iQuantity = isnull(iQuantity,0) + " + s2 + "  where cInvCode = '" + dr2[i]["cInvcode"].ToString().Trim() + "' and cWhCode = '" + dr2[i]["cDefWareHouse"].ToString().Trim() + "' " +
                              "else " +
                                  "begin " +
                                  "    declare @itemid varchar(20); " +
                                  "declare @iCount int;  " +
                                    "select @iCount=count(itemid) from @u8.CurrentStock where cInvCode = '" + dr2[i]["cInvcode"].ToString().Trim() + "';   " +
                                    "if( @iCount > 0 ) " +
                                    "	select @itemid=itemid from @u8.CurrentStock where cInvCode = '" + dr2[i]["cInvcode"].ToString().Trim() + "';  " +
                                    "else  " +
                                    "	 select @itemid=max(itemid+1) from @u8.CurrentStock  " +
                                  "    insert into @u8.CurrentStock(cWhCode,cInvCode,iQuantity,itemid)values('" + dr2[i]["cDefWareHouse"].ToString().Trim() + "','" + dr2[i]["cInvcode"].ToString().Trim() + "'," + s2 + ",@itemid) " +
                                  "end";

                    }
                    else
                    {
                        sSQL = "if exists(select * from  @u8.CurrentStock where cInvCode = '" + dr2[i]["cInvcode"].ToString().Trim() + "' and cWhCode = '" + dr2[i]["cDefWareHouse"].ToString().Trim() + "') " +
                        "	update  @u8.CurrentStock set iQuantity = isnull(iQuantity,0) + " + s2 + ",iNum = isnull(iNum,0) + " + s1 + "  where cInvCode = '" + dr2[i]["cInvcode"].ToString().Trim() + "' and cWhCode = '" + dr2[i]["cDefWareHouse"].ToString().Trim() + "' " +
                                "else " +
                                    "begin " +
                                    "    declare @itemid varchar(20); " +
                                  "declare @iCount int;  " +
                                    "select @iCount=count(itemid) from @u8.CurrentStock where cInvCode = '" + dr2[i]["cInvcode"].ToString().Trim() + "';   " +
                                    "if( @iCount > 0 ) " +
                                    "	select @itemid=itemid from @u8.CurrentStock where cInvCode = '" + dr2[i]["cInvcode"].ToString().Trim() + "';  " +
                                    "else  " +
                                    "	 select @itemid=max(itemid+1) from @u8.CurrentStock  " +
                                    "    insert into @u8.CurrentStock(cWhCode,cInvCode,iQuantity,iNum,itemid)values('" + dr2[i]["cDefWareHouse"].ToString().Trim() + "','" + dr2[i]["cInvcode"].ToString().Trim() + "'," + s2 + "," + s1 + ",@itemid) " +
                                    "end";
                    }
                    aList.Add(sSQL);
                    dr2[i]["bUsed"] = iID;
                }
                else
                {
                    continue;
                }

                for (int j = i + 1; j < dr2.Length; j++)
                {
                    if (dr2[j]["bUsed"].ToString().Trim() == "-1" && dr2[i]["cDefWareHouse"].ToString().Trim() == dr2[j]["cDefWareHouse"].ToString().Trim())
                    {
                        iIDDetail += 1;
                        //表体 
                        string s1 = "null";
                        if (dr2[j]["NowNum"].ToString().Trim() != string.Empty)
                            s1 = dr2[j]["NowNum"].ToString().Trim();
                        if (s1 == "null" || double.Parse(s1) == 0)
                            s1 = "null";
                        string s2 = "null";
                        if (dr2[j]["NowQuantity"].ToString().Trim() != string.Empty)
                            s2 = dr2[j]["NowQuantity"].ToString().Trim();
                        string s3 = "null";
                        if (dr2[j]["iArrQty1"].ToString().Trim() != string.Empty)
                            s3 = dr2[j]["iArrQty1"].ToString().Trim();
                        if (s3 == "null" || s3.Trim() == "" || double.Parse(s3) < 0)
                            s3 = "null";

                        string s4 = "null";
                        if (dr2[j]["iArrNum1"].ToString().Trim() != string.Empty)
                            s4 = dr2[j]["iArrNum1"].ToString().Trim();
                        if (s4 == "null" || s4.Trim() == "" || double.Parse(s4) <= 0)
                            s4 = "null";

                        sSQL = "Insert Into @u8.rdrecords(autoid,id,cinvcode,inum,iquantity," +
                                    "isquantity,isnum,imoney,cdefine26,cdefine27,inquantity,innum," +
                                    "itaxrate,btaxcost,cpoid," +
                                    "iprocesscost,iprocessfee,iomodid," +
                                    "bcosting,iinvexchrate,corufts,iexpiratdatecalcu,isotype) " +
                                "Values (" + iIDDetail + "," + iID + ",N'" + dr2[j]["cInvcode"].ToString().Trim() + "'," + s1 + "," + s2 +
                                    ",0,0,0,0,0," + s3 + "," + s4 + "," +
                                    "0,1,N'" + dr2[j]["OrderNo"].ToString().Trim() +
                                    "',0,0," + dr2[j]["orderid"].ToString().Trim() + "," +
                                    "1,0,N'1610.3418',0,0)";
                        aList.Add(sSQL);


                        sSQL = "update @u8.rdrecords set iProcessFee=" + Convert.ToDouble(dr2[j]["加工费单价"]) * Convert.ToDouble(s2) + ",iProcessCost = " + dr2[j]["加工费单价"] +
                                " where autoid = " + iIDDetail;
                        aList.Add(sSQL);

                        sSQL = "select * from @u8.OM_MODetails where MODetailsID = " + dr2[j]["orderid"].ToString().Trim();
                        DataTable dtPodetails = clsSQLCommond.ExecQuery(sSQL);
                        if (dtPodetails.Rows[0]["citemName"].ToString().Trim() != string.Empty)
                        {
                            sSQL = "update @u8.rdrecords set citem_class='" + dtPodetails.Rows[0]["citem_class"] + "',citemcode='" + dtPodetails.Rows[0]["citemName"] + "',cname='" + dtPodetails.Rows[0]["citemName"] + "',citemcname='外销订单项目' " +
                                   " where autoid = " + iIDDetail;
                            aList.Add(sSQL);
                        }

                        sSQL = "update @u8.OM_MODetails set iReceivedQTY = isnull(iReceivedQTY,0) + " + s2 + ",iReceivedNum =  isnull(iReceivedNum,0) + " + s1 + " where MODetailsID = " + dr2[j]["orderid"].ToString().Trim();
                        aList.Add(sSQL);

                        //////现存量
                        if (s1 == "null")
                        {
                            sSQL = "if exists(select * from  @u8.CurrentStock where cInvCode = '" + dr2[j]["cInvcode"].ToString().Trim() + "' and cWhCode = '" + dr2[j]["cDefWareHouse"].ToString().Trim() + "') " +
                            "	update  @u8.CurrentStock set iQuantity = isnull(iQuantity,0) + " + s2 + "  where cInvCode = '" + dr2[j]["cInvcode"].ToString().Trim() + "' and cWhCode = '" + dr2[j]["cDefWareHouse"].ToString().Trim() + "' " +
                                    "else " +
                                        "begin " +
                                        "    declare @itemid varchar(20); " +
                                        "    declare @iCount int;  " +
                                            "select @iCount=count(itemid) from @u8.CurrentStock where cInvCode = '" + dr2[i]["cInvcode"].ToString().Trim() + "';   " +
                                            "if( @iCount > 0 ) " +
                                            "	select @itemid=itemid from @u8.CurrentStock where cInvCode = '" + dr2[i]["cInvcode"].ToString().Trim() + "';  " +
                                            "else  " +
                                            "	 select @itemid=max(itemid+1) from @u8.CurrentStock  " +
                                            "    insert into @u8.CurrentStock(cWhCode,cInvCode,iQuantity,itemid)values('" + dr2[j]["cDefWareHouse"].ToString().Trim() + "','" + dr2[j]["cInvcode"].ToString().Trim() + "'," + s2 + ",@itemid) " +
                                        "end";
                        }
                        else
                        {
                            sSQL = "if exists(select * from  @u8.CurrentStock where cInvCode = '" + dr2[j]["cInvcode"].ToString().Trim() + "' and cWhCode = '" + dr2[j]["cDefWareHouse"].ToString().Trim() + "') " +
                           "	update  @u8.CurrentStock set iQuantity = isnull(iQuantity,0) + " + s2 + ",iNum = isnull(iNum,0) + " + s1 + "  where cInvCode = '" + dr2[j]["cInvcode"].ToString().Trim() + "' and cWhCode = '" + dr2[j]["cDefWareHouse"].ToString().Trim() + "' " +
                                   "else " +
                                       "begin " +
                                               "    declare @itemid varchar(20); " +
                                          "declare @iCount int;  " +
                                            "select @iCount=count(itemid) from @u8.CurrentStock where cInvCode = '" + dr2[i]["cInvcode"].ToString().Trim() + "';   " +
                                            "if( @iCount > 0 ) " +
                                            "	select @itemid=itemid from @u8.CurrentStock where cInvCode = '" + dr2[i]["cInvcode"].ToString().Trim() + "';  " +
                                            "else  " +
                                            "	 select @itemid=max(itemid+1) from @u8.CurrentStock  " +
                                    "    insert into @u8.CurrentStock(cWhCode,cInvCode,iQuantity,iNum,itemid)values('" + dr2[j]["cDefWareHouse"].ToString().Trim() + "','" + dr2[j]["cInvcode"].ToString().Trim() + "'," + s2 + "," + s1 + ",@itemid) " +
                                       "end";
                        }
                        aList.Add(sSQL);
                        dr2[j]["bUsed"] = iID;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }



        /// <summary>
        /// 导入委外退货单
        /// </summary>
        /// <param name="dr2"></param>
        private void ImportProcess5(DataRow[] dr2, out string sInfo)
        {
            string sSQL = "";
            sInfo = "";

            try
            {
                gridView1.FocusedRowHandle -= 1;
            }
            catch { }

            ArrayList aList材料出库红字 = new ArrayList();
            for (int i = 0; i < dr2.Length; i++)
            {
                if (dr2[i]["bUsed"].ToString().Trim() == "-1")
                {
                    iCodeBack += 1;
                    string sRDCode = sSetOutCode(iCodeBack);

                    iIDBack += 1;
                    iIDBackDetail += 1;
                    //表头
                    sSQL = "insert into @u8.rdrecord11(id,brdflag,cvouchtype,cbustype,csource,cwhcode,ddate,ccode,crdcode,cdepcode," +
                                "cptcode,cvencode,cmaker,cdefine7,bpufirst,vt_id,bisstqc,ipurorderid,iexchrate,cexch_name," +
                                "bomfirst,idiscounttaxtype,iswfcontrolled,dnmaketime,dnmodifytime,dnverifytime)" +
                            "values (" + iIDBack + ",0,N'11',N'委外发料',N'委外订单',N'" + dr2[i]["cDefWareHouse"].ToString().Trim() + "','" + date1.DateTime.ToString("yyyy-MM-dd") + "',N'" + sRDCode + "',N'211',N'" + dr2[i]["cDepCode"].ToString().Trim() + "'," +
                                "N'02',N'" + dr2[i]["cVenCode"].ToString().Trim() + "',N'" + FrameBaseFunction.ClsBaseDataInfo.sUserName.Trim() + "',0,0,65,0,N'0',1,N'人民币'," +
                                "0,N'0',0, getdate(), Null , Null )";
                    aList.Add(sSQL);


                    sInfo = sInfo + sRDCode + ";";

                    aList材料出库红字.Add(iIDBack);

                    //表体 

                    string s1 = "null";
                    if (dr2[i]["NowNum"].ToString().Trim() != string.Empty)
                        s1 = dr2[i]["NowNum"].ToString().Trim();

                    string s2 = "null";
                    if (dr2[i]["NowQuantity"].ToString().Trim() != string.Empty)
                        s2 = dr2[i]["NowQuantity"].ToString().Trim();

                    sSQL = @"select top 1 D.cInvCode  from  @u8.OM_MOMaterials M
                                left join @u8.OM_MODetails D on M.MoDetailsID = D.MODetailsID 
                                where m.MOMaterialsID ={0}";
                    sSQL = string.Format(sSQL, dr2[i]["orderid"].ToString());
                    DataTable dtInv = clsSQLCommond.ExecQuery(sSQL);
                    string pInvCode = dtInv.Rows[0]["cInvCode"].ToString();


                    sSQL = "Insert Into @u8.rdrecords11(autoid,id,cinvcode,inum,iquantity," +
                                "isquantity,isnum,cdefine26,cdefine27,inquantity,innum," +
                                "iprocesscost,iprocessfee,iomodid,iOMoMID," +
                                "bcosting,iinvexchrate,corufts,iexpiratdatecalcu,isotype,comcode,invcode  ) " +
                            "Values (" + iIDBackDetail + "," + iIDBack + ",N'" + dr2[i]["cInvcode"].ToString().Trim() + "',0-" + s1 + ",0-" + s2 +
                                ",0,0,0,0," + "0" + "," + "0" + "," +
                                "0,0," + dr2[i]["iomodid"].ToString().Trim() + "," + dr2[i]["iOMoMID"].ToString().Trim() + "," +
                                "1,0,N'1610.3418',0,0,'" + dr2[i]["OrderNo"].ToString().Trim() + "','" + pInvCode + "')";
                    aList.Add(sSQL);

                    sSQL = "update @u8.rdrecords11 set cAssUnit = i.cAssComUnitCode from @u8.inventory i where i.cinvcode = @u8.rdrecords11.cinvcode and @u8.rdrecords11.autoid = " + iIDBackDetail;
                    aList.Add(sSQL);

                    sSQL = "select D.* from @u8.OM_MODetails D left join  @u8.OM_MOMaterials  OD on D.MoDetailsID =OD.MoDetailsID    where OD.MOMaterialsID  = " + dr2[i]["orderid"].ToString().Trim();
                    DataTable dtPodetails = clsSQLCommond.ExecQuery(sSQL);
                    if (dtPodetails.Rows[0]["citemName"].ToString().Trim() != string.Empty)
                    {
                        sSQL = "update @u8.rdrecords11 set citem_class='" + dtPodetails.Rows[0]["citem_class"] + "',citemcode='" + dtPodetails.Rows[0]["citemName"] + "',cname='" + dtPodetails.Rows[0]["citemName"] + "',citemcname='外销订单项目' " +
                               " where autoid = " + iIDBackDetail;
                        aList.Add(sSQL);
                    }

                    sSQL = "update @u8.OM_MOMaterials set iSendQTY =iSendQTY-" + s2 + ",iSendNum =iSendNum-" + s1 + " where MOMaterialsID = " + dr2[i]["orderid"].ToString().Trim();
                    aList.Add(sSQL);


                    //////现存量

                    if (s1 == "null")
                    {
                        sSQL = "if exists(select * from  @u8.CurrentStock where cInvCode = '" + dr2[i]["cInvcode"].ToString().Trim() + "' and cWhCode = '" + dr2[i]["cDefWareHouse"].ToString().Trim() + "') " +
                      "	update  @u8.CurrentStock set iQuantity = isnull(iQuantity,0) + " + s2 + "  where cInvCode = '" + dr2[i]["cInvcode"].ToString().Trim() + "' and cWhCode = '" + dr2[i]["cDefWareHouse"].ToString().Trim() + "' " +
                              "else " +
                                  "begin " +
                                  "    declare @itemid varchar(20); " +
                                  "declare @iCount int;  " +
                                    "select @iCount=count(itemid) from @u8.CurrentStock where cInvCode = '" + dr2[i]["cInvcode"].ToString().Trim() + "';   " +
                                    "if( @iCount > 0 ) " +
                                    "	select @itemid=itemid from @u8.CurrentStock where cInvCode = '" + dr2[i]["cInvcode"].ToString().Trim() + "';  " +
                                    "else  " +
                                    "	 select @itemid=max(itemid+1) from @u8.CurrentStock  " +
                                  "    insert into @u8.CurrentStock(cWhCode,cInvCode,iQuantity,itemid)values('" + dr2[i]["cDefWareHouse"].ToString().Trim() + "','" + dr2[i]["cInvcode"].ToString().Trim() + "'," + s2 + ",@itemid) " +
                                  "end";

                    }
                    else
                    {
                        sSQL = "if exists(select * from  @u8.CurrentStock where cInvCode = '" + dr2[i]["cInvcode"].ToString().Trim() + "' and cWhCode = '" + dr2[i]["cDefWareHouse"].ToString().Trim() + "') " +
                        "	update  @u8.CurrentStock set iQuantity = isnull(iQuantity,0) + " + s2 + ",iNum = isnull(iNum,0) + " + s1 + "  where cInvCode = '" + dr2[i]["cInvcode"].ToString().Trim() + "' and cWhCode = '" + dr2[i]["cDefWareHouse"].ToString().Trim() + "' " +
                                "else " +
                                    "begin " +
                                    "    declare @itemid varchar(20); " +
                                  "declare @iCount int;  " +
                                    "select @iCount=count(itemid) from @u8.CurrentStock where cInvCode = '" + dr2[i]["cInvcode"].ToString().Trim() + "';   " +
                                    "if( @iCount > 0 ) " +
                                    "	select @itemid=itemid from @u8.CurrentStock where cInvCode = '" + dr2[i]["cInvcode"].ToString().Trim() + "';  " +
                                    "else  " +
                                    "	 select @itemid=max(itemid+1) from @u8.CurrentStock  " +
                                    "    insert into @u8.CurrentStock(cWhCode,cInvCode,iQuantity,iNum,itemid)values('" + dr2[i]["cDefWareHouse"].ToString().Trim() + "','" + dr2[i]["cInvcode"].ToString().Trim() + "'," + s2 + "," + s1 + ",@itemid) " +
                                    "end";
                    }
                    aList.Add(sSQL);
                    dr2[i]["bUsed"] = iID;
                }
                else
                {
                    continue;
                }

                for (int j = i + 1; j < dr2.Length; j++)
                {
                    if (dr2[j]["bUsed"].ToString().Trim() == "-1" && dr2[i]["cDefWareHouse"].ToString().Trim() == dr2[j]["cDefWareHouse"].ToString().Trim())
                    {
                        iIDBackDetail += 1;
                        //表体 
                        string s1 = "null";
                        if (dr2[j]["NowNum"].ToString().Trim() != string.Empty)
                            s1 = dr2[j]["NowNum"].ToString().Trim();


                        string s2 = "null";
                        if (dr2[j]["NowQuantity"].ToString().Trim() != string.Empty)
                            s2 = dr2[j]["NowQuantity"].ToString().Trim();



                        sSQL = @"select top 1 D.cInvCode  from  @u8.OM_MOMaterials M
                                left join @u8.OM_MODetails D on M.MoDetailsID = D.MODetailsID 
                                where m.MOMaterialsID ={0}";
                        sSQL = string.Format(sSQL, dr2[j]["orderid"].ToString());
                        DataTable dtInv = clsSQLCommond.ExecQuery(sSQL);
                        string pInvCode = dtInv.Rows[0]["cInvCode"].ToString();


                        sSQL = "Insert Into @u8.rdrecords11(autoid,id,cinvcode,inum,iquantity," +
                                    "isquantity,isnum,cdefine26,cdefine27,inquantity,innum," +
                                    "iprocesscost,iprocessfee,iomodid,iOMoMID," +
                                    "bcosting,iinvexchrate,corufts,iexpiratdatecalcu,isotype,comcode,invcode  ) " +
                                "Values (" + iIDBackDetail + "," + iIDBack + ",N'" + dr2[j]["cInvcode"].ToString().Trim() + "',0-" + s1 + ",0-" + s2 +
                                    ",0,0,0,0," + "0" + "," + "0" + "," +
                                    "0,0," + dr2[j]["iomodid"].ToString().Trim() + "," + dr2[j]["iOMoMID"].ToString().Trim() + "," +
                                    "1,0,N'1610.3418',0,0,'" + dr2[j]["OrderNo"].ToString().Trim() + "','" + pInvCode + "')";
                        aList.Add(sSQL);


                        sSQL = "select D.* from @u8.OM_MODetails D left join  @u8.OM_MOMaterials  OD on D.MoDetailsID =OD.MoDetailsID    where OD.MOMaterialsID  = " + dr2[j]["orderid"].ToString().Trim();
                        DataTable dtPodetails = clsSQLCommond.ExecQuery(sSQL);
                        if (dtPodetails.Rows[0]["citemName"].ToString().Trim() != string.Empty)
                        {
                            sSQL = "update @u8.rdrecords11 set citem_class='" + dtPodetails.Rows[0]["citem_class"] + "',citemcode='" + dtPodetails.Rows[0]["cItemCode"] + "',cname='" + dtPodetails.Rows[0]["citemName"] + "',citemcname='" + "外销订单项目" + "' " +
                                   " where autoid = " + iIDBackDetail;
                            aList.Add(sSQL);
                        }

                        sSQL = "update @u8.OM_MOMaterials set iSendQTY =iSendQTY-" + s2 + ",iSendNum =iSendNum-" + s1 + " where MOMaterialsID = " + dr2[j]["orderid"].ToString().Trim();
                        aList.Add(sSQL);
                        //sSQL = "update @u8.OM_MODetails set iReceivedQTY = isnull(iReceivedQTY,0) + " + s2 + ",iReceivedNum =  isnull(iReceivedNum,0) + " + s1 + " where MODetailsID = " + dr2[j]["orderid"].ToString().Trim();
                        //aList.Add(sSQL);

                        //////现存量
                        if (s1 == "null")
                        {
                            sSQL = "if exists(select * from  @u8.CurrentStock where cInvCode = '" + dr2[j]["cInvcode"].ToString().Trim() + "' and cWhCode = '" + dr2[j]["cDefWareHouse"].ToString().Trim() + "') " +
                            "	update  @u8.CurrentStock set iQuantity = isnull(iQuantity,0) + " + s2 + "  where cInvCode = '" + dr2[j]["cInvcode"].ToString().Trim() + "' and cWhCode = '" + dr2[j]["cDefWareHouse"].ToString().Trim() + "' " +
                                    "else " +
                                        "begin " +
                                        "    declare @itemid varchar(20); " +
                                        "    declare @iCount int;  " +
                                            "select @iCount=count(itemid) from @u8.CurrentStock where cInvCode = '" + dr2[j]["cInvcode"].ToString().Trim() + "';   " +
                                            "if( @iCount > 0 ) " +
                                            "	select @itemid=itemid from @u8.CurrentStock where cInvCode = '" + dr2[j]["cInvcode"].ToString().Trim() + "';  " +
                                            "else  " +
                                            "	 select @itemid=max(itemid+1) from @u8.CurrentStock  " +
                                            "    insert into @u8.CurrentStock(cWhCode,cInvCode,iQuantity,itemid)values('" + dr2[j]["cDefWareHouse"].ToString().Trim() + "','" + dr2[j]["cInvcode"].ToString().Trim() + "'," + s2 + ",@itemid) " +
                                        "end";
                        }
                        else
                        {
                            sSQL = "if exists(select * from  @u8.CurrentStock where cInvCode = '" + dr2[j]["cInvcode"].ToString().Trim() + "' and cWhCode = '" + dr2[j]["cDefWareHouse"].ToString().Trim() + "') " +
                           "	update  @u8.CurrentStock set iQuantity = isnull(iQuantity,0) + " + s2 + ",iNum = isnull(iNum,0) + " + s1 + "  where cInvCode = '" + dr2[j]["cInvcode"].ToString().Trim() + "' and cWhCode = '" + dr2[j]["cDefWareHouse"].ToString().Trim() + "' " +
                                   "else " +
                                       "begin " +
                                               "    declare @itemid varchar(20); " +
                                          "declare @iCount int;  " +
                                            "select @iCount=count(itemid) from @u8.CurrentStock where cInvCode = '" + dr2[j]["cInvcode"].ToString().Trim() + "';   " +
                                            "if( @iCount > 0 ) " +
                                            "	select @itemid=itemid from @u8.CurrentStock where cInvCode = '" + dr2[j]["cInvcode"].ToString().Trim() + "';  " +
                                            "else  " +
                                            "	 select @itemid=max(itemid+1) from @u8.CurrentStock  " +
                                    "    insert into @u8.CurrentStock(cWhCode,cInvCode,iQuantity,iNum,itemid)values('" + dr2[j]["cDefWareHouse"].ToString().Trim() + "','" + dr2[j]["cInvcode"].ToString().Trim() + "'," + s2 + "," + s1 + ",@itemid) " +
                                       "end";
                        }
                        aList.Add(sSQL);
                        dr2[j]["bUsed"] = iID;
                    }
                    else
                    {
                        continue;
                    }
                }


                for (int j = 0; j < aList材料出库红字.Count; j++)
                {
                    sSQL = "exec @u8.IA_SP_WriteUnAccountVouchForST 'aaaaaaaa',N'11'";
                    sSQL = sSQL.Replace("aaaaaaaa", aList材料出库红字[j].ToString());
                    aList.Add(sSQL);
                }
            }
        }


        /// <summary>
        /// 导入采购入库单
        /// </summary>
        /// <param name="dr"></param>
        private void ImportStock0(DataRow[] dr, out string sInfo)
        {
            string sSQL = "";
            sInfo = "";

            try
            {
                gridView1.FocusedRowHandle -= 1;
            }
            catch { }

            for (int i = 0; i < dr.Length; i++)
            {
                if (dr[i]["bUsed"].ToString().Trim() == "-1")
                {
                    iCode += 1;
                    string sRDCode = sSetCode(iCode);

                    iID += 1;
                    iIDDetail += 1;

                    string sPersonCodeInfo = "null";
                    if (dr[i]["业务员"].ToString().Trim() != string.Empty)
                    {
                        sPersonCodeInfo = "'" + dr[i]["业务员"].ToString().Trim() + "'";
                    }
                    //表头
                    sSQL = "insert into @u8.rdrecord(cDefine2,cDefine14,cOrderCode,cDefine11,cPersonCode,id,brdflag,cvouchtype,cbustype,csource,cwhcode,ddate,ccode,crdcode,cdepcode," +
                                "cptcode,cvencode,cmaker," +
                                "bpufirst,vt_id,bisstqc,ipurorderid,itaxrate,iexchrate,cexch_name, " +
                                "bomfirst,idiscounttaxtype,iswfcontrolled,dnmaketime,dnmodifytime,dnverifytime,bcredit) values  " +
                            "('" + dr[i]["cDefine2"].ToString().Trim() + "','" + dr[i]["请购单号"].ToString().Trim() + "','" + dr[i]["OrderNo"].ToString().Trim() + "','" + dr[i]["外销订单号"].ToString().Trim() + "'," + sPersonCodeInfo + "," + iID + ",1,N'01',N'普通采购',N'采购订单',N'" + dr[i]["cDefWareHouse"].ToString().Trim() + "','" + date1.DateTime.ToString("yyyy-MM-dd") + "',N'" + sRDCode + "',N'101',N'4'," +
                                "N'01',N'" + dr[i]["cVenCode"].ToString().Trim() + "',N'" + FrameBaseFunction.ClsBaseDataInfo.sUserName.Trim() + "', " +
                                "0,27,0,2515,N'" + iTaxRate_All + "',1,N'人民币' " +
                                ",0,N'0',0,getdate(), Null , Null ,N'0')";
                    aList.Add(sSQL);

                    sInfo = sInfo + sRDCode + ";";

                    //表体 

                    string s1 = "null";
                    if (dr[i]["NowNum"].ToString().Trim() != string.Empty)
                        s1 = dr[i]["NowNum"].ToString().Trim();
                    if (s1 == "null" || double.Parse(s1) == 0)
                        s1 = "null";

                    string s2 = "null";
                    if (dr[i]["NowQuantity"].ToString().Trim() != string.Empty)
                        s2 = dr[i]["NowQuantity"].ToString().Trim();
                    string s3 = "null";
                    if (dr[i]["iArrQty1"].ToString().Trim() != string.Empty)
                        s3 = dr[i]["iArrQty1"].ToString().Trim();
                    if (s3 == "null" || s3.Trim() == "" || double.Parse(s3) < 0)
                        s3 = "null";

                    string s4 = "null";
                    if (dr[i]["iArrNum1"].ToString().Trim() != string.Empty)
                        s4 = dr[i]["iArrNum1"].ToString().Trim();
                    if (s4 == "null" || s4.Trim() == "" || double.Parse(s4) <= 0)
                        s4 = "null";


                    sSQL = "select * from @u8.PO_Podetails where id = " + dr[i]["orderid"];
                    DataTable dtPodetails = clsSQLCommond.ExecQuery(sSQL);

                    sSQL = "Insert Into @u8.rdrecords(autoid,id,cinvcode,inum,iquantity," +
                                    "isquantity,isnum,imoney,iposid," +
                                    "inquantity,innum," +
                                    "itaxrate,btaxcost,cpoid)" +
                            " Values (" + iIDDetail + "," + iID + ",N'" + dr[i]["cInvcode"].ToString().Trim() + "'," + s1 + "," + s2 +
                                    ",0,0,0," + dr[i]["orderid"].ToString().Trim() +
                                    "," + s3 + ",cast(" + s4 + " as  decimal(18, 3))," +
                                    iTaxRate_All.ToString() + ",1,N'" + dr[i]["OrderNo"].ToString().Trim() + "')";
                    aList.Add(sSQL);


                    //原币含税单价  6位
                    //无税单价      6位
                    //数量          6位
                    //价税合计      2位   原币含税单价 * 数量
                    //无税金额      2位   价税合计 / （1 + 税率） 
                    //税额          2位   价税合计 - 无税金额 
                    //----------------------------------------------------------------------------------------------------------------

                    //税率
                    decimal ipertaxrate = decimal.Round(Convert.ToDecimal(dtPodetails.Rows[0]["ipertaxrate"]), 2);
                    //单价(不含税)
                    decimal iUnitCost = decimal.Round(Convert.ToDecimal(dtPodetails.Rows[0]["iUnitPrice"]), 2);
                    //金额(不含税)
                    decimal iPrice = decimal.Round(iUnitCost * decimal.Parse(s2), 2);
                    //原币含税单价
                    decimal iTaxPrice = decimal.Round(Convert.ToDecimal(dtPodetails.Rows[0]["iTaxPrice"]), 6);
                    //原币价税合计
                    decimal iOriSum = decimal.Round(iTaxPrice * decimal.Round(decimal.Parse(s2), 6), 2);
                    //原币无税金额 
                    decimal iOriMoney = decimal.Round(iOriSum / (1 + ipertaxrate / 100), 2);
                    //原币税额 
                    decimal iOriTaxPrice = iOriSum - iOriMoney;

                    sSQL = "update @u8.rdrecords set corufts = 13187.1822,iUnitCost= " + iUnitCost + " , iPrice = " + iOriMoney + " , iAPrice =  " + iOriMoney + " , fACost = " + iUnitCost + " " +
                                " ,iOriTaxCost= " + iTaxPrice + ", iOriCost =" + iUnitCost + ", iOriMoney = " + iOriMoney + ",iOriSum =" + iOriSum +
                                " ,iOriTaxPrice =" + iOriTaxPrice + ",  iTaxPrice = " + iOriTaxPrice + ", iSum = " + iOriSum +
                                " ,cAssUnit = '" + dtPodetails.Rows[0]["cUnitID"].ToString() + "',bcosting=1 " +
                           " where autoid = " + iIDDetail;
                    aList.Add(sSQL);


                    if (dtPodetails.Rows[0]["iNum"].ToString().Trim() != string.Empty && Convert.ToDouble(dtPodetails.Rows[0]["iNum"]) != 0)
                    {
                        sSQL = "update @u8.rdrecords set iinvexchrate=cast((" + s2 + "/" + s1 + ")  as decimal(18, 8)),inum = " + s1 + " " +
                               " where autoid = " + iIDDetail;
                        aList.Add(sSQL);
                    }

                    if (dtPodetails.Rows[0]["citemName"].ToString().Trim() != string.Empty)
                    {
                        sSQL = "update @u8.rdrecords set citem_class='" + dtPodetails.Rows[0]["citem_class"] + "',citemcode='" + dtPodetails.Rows[0]["citemName"] + "',cname='" + dtPodetails.Rows[0]["citemName"] + "',citemcname='外销订单项目' " +
                               " where autoid = " + iIDDetail;
                        aList.Add(sSQL);
                    }

                    if (s1.Trim() == string.Empty)
                    {
                        sSQL = "update @u8.PO_Podetails  set iReceivedQTY = isnull(iReceivedQTY,0) + " + s2 + " where [id] = " + dr[i]["orderid"].ToString().Trim();

                    }
                    else
                    {
                        sSQL = "update @u8.PO_Podetails  set iReceivedQTY = isnull(iReceivedQTY,0) + " + s2 + ",iReceivedNum = isnull(iReceivedNum,0) + " + s1 + " where [id] = " + dr[i]["orderid"].ToString().Trim();
                    }
                    aList.Add(sSQL);
                    //////现存量

                    if (s1 == "null")
                    {
                        sSQL = "if exists(select * from  @u8.CurrentStock where cInvCode = '" + dr[i]["cInvcode"].ToString().Trim() + "' and cWhCode = '" + dr[i]["cDefWareHouse"].ToString().Trim() + "') " +
                      "	update  @u8.CurrentStock set iQuantity = isnull(iQuantity,0) + " + s2 + "  where cInvCode = '" + dr[i]["cInvcode"].ToString().Trim() + "' and cWhCode = '" + dr[i]["cDefWareHouse"].ToString().Trim() + "' " +
                              "else " +
                                  "begin " +
                                  "    declare @itemid varchar(20); " +
                                  "declare @iCount int;  " +
                                    "select @iCount=count(itemid) from @u8.CurrentStock where cInvCode = '" + dr[i]["cInvcode"].ToString().Trim() + "';   " +
                                    "if( @iCount > 0 ) " +
                                    "	select @itemid=itemid from @u8.CurrentStock where cInvCode = '" + dr[i]["cInvcode"].ToString().Trim() + "';  " +
                                    "else  " +
                                    "	 select @itemid=max(itemid+1) from @u8.CurrentStock  " +
                                    "    insert into @u8.CurrentStock(cWhCode,cInvCode,iQuantity,itemid)values('" + dr[i]["cDefWareHouse"].ToString().Trim() + "','" + dr[i]["cInvcode"].ToString().Trim() + "'," + s2 + ",@itemid) " +
                                  "end";

                    }
                    else
                    {
                        sSQL = "if exists(select * from  @u8.CurrentStock where cInvCode = '" + dr[i]["cInvcode"].ToString().Trim() + "' and cWhCode = '" + dr[i]["cDefWareHouse"].ToString().Trim() + "') " +
                        "	update  @u8.CurrentStock set iQuantity = isnull(iQuantity,0) + " + s2 + ",iNum = isnull(iNum,0) + " + s1 + "  where cInvCode = '" + dr[i]["cInvcode"].ToString().Trim() + "' and cWhCode = '" + dr[i]["cDefWareHouse"].ToString().Trim() + "' " +
                                "else " +
                                    "begin " +
                                    "    declare @itemid varchar(20); " +
                                  "declare @iCount int;  " +
                                    "select @iCount=count(itemid) from @u8.CurrentStock where cInvCode = '" + dr[i]["cInvcode"].ToString().Trim() + "';   " +
                                    "if( @iCount > 0 ) " +
                                    "	select @itemid=itemid from @u8.CurrentStock where cInvCode = '" + dr[i]["cInvcode"].ToString().Trim() + "';  " +
                                    "else  " +
                                    "	 select @itemid=max(itemid+1) from @u8.CurrentStock  " +
                                    "    insert into @u8.CurrentStock(cWhCode,cInvCode,iQuantity,iNum,itemid)values('" + dr[i]["cDefWareHouse"].ToString().Trim() + "','" + dr[i]["cInvcode"].ToString().Trim() + "'," + s2 + "," + s1 + ",@itemid) " +
                                    "end";
                    }
                    aList.Add(sSQL);
                    dr[i]["bUsed"] = iID;
                }
                else
                {
                    continue;
                }

                for (int j = i + 1; j < dr.Length; j++)
                {
                    if (dr[j]["bUsed"].ToString().Trim() == "-1" && dr[i]["cDefWareHouse"].ToString().Trim() == dr[j]["cDefWareHouse"].ToString().Trim())
                    {
                        iIDDetail += 1;

                        //表体 

                        string s1 = "null";
                        if (dr[j]["NowNum"].ToString().Trim() != string.Empty)
                            s1 = dr[j]["NowNum"].ToString().Trim();
                        if (s1 == "null" || double.Parse(s1) == 0)
                            s1 = "null";

                        string s2 = "null";
                        if (dr[j]["NowQuantity"].ToString().Trim() != string.Empty)
                            s2 = dr[j]["NowQuantity"].ToString().Trim();
                        string s3 = "null";
                        if (dr[j]["iArrQty1"].ToString().Trim() != string.Empty)
                            s3 = dr[j]["iArrQty1"].ToString().Trim();
                        if (s3 == "null" || s3.Trim() == "" || double.Parse(s3) < 0)
                            s3 = "null";

                        string s4 = "null";
                        if (dr[j]["iArrNum1"].ToString().Trim() != string.Empty)
                            s4 = dr[j]["iArrNum1"].ToString().Trim();
                        if (s4 == "null" || s4.Trim() == "" || double.Parse(s4) <= 0)
                            s4 = "null";

                        sSQL = "select * from @u8.PO_Podetails where id = " + dr[j]["orderid"];
                        DataTable dtPodetails = clsSQLCommond.ExecQuery(sSQL);

                        sSQL = "Insert Into @u8.rdrecords(autoid,id,cinvcode,inum,iquantity," +
                                        "isquantity,isnum,imoney,iposid," +
                                        "inquantity,innum," +
                                        "itaxrate,btaxcost,cpoid)" +
                                " Values (" + iIDDetail + "," + iID + ",N'" + dr[j]["cInvcode"].ToString().Trim() + "'," + s1 + "," + s2 +
                                        ",0,0,0," + dr[j]["orderid"].ToString().Trim() +
                                        "," + s3 + ",cast(" + s4 + " as  decimal(18, 3))," +
                                        iTaxRate_All.ToString() +  ",1,N'" + dr[j]["OrderNo"].ToString().Trim() + "')";
                        aList.Add(sSQL);


                        //原币含税单价  5位
                        //无税单价      6位
                        //数量          6位
                        //价税合计      2位   原币含税单价 * 数量
                        //无税金额      2位   价税合计 / （1 + 税率） 
                        //税额          2位   价税合计 - 无税金额 
                        //---------------------------------------------------------

                        //税率
                        decimal ipertaxrate = decimal.Round(Convert.ToDecimal(dtPodetails.Rows[0]["ipertaxrate"]), 2);
                        //单价(不含税)
                        decimal iUnitCost = decimal.Round(Convert.ToDecimal(dtPodetails.Rows[0]["iUnitPrice"]), 2);
                        //金额(不含税)
                        decimal iPrice = decimal.Round(iUnitCost * decimal.Parse(s2), 2);
                        //原币含税单价
                        decimal iTaxPrice = decimal.Round(Convert.ToDecimal(dtPodetails.Rows[0]["iTaxPrice"]), 6);
                        //原币价税合计
                        decimal iOriSum = decimal.Round(iTaxPrice * decimal.Round(decimal.Parse(s2), 6), 2);
                        //原币无税金额 
                        decimal iOriMoney = decimal.Round(iOriSum / (1 + ipertaxrate / 100), 2);
                        //原币税额 
                        decimal iOriTaxPrice = iOriSum - iOriMoney;

                        sSQL = "update @u8.rdrecords set corufts = 13187.1822,iUnitCost= " + iUnitCost + " , iPrice = " + iOriMoney + " , iAPrice =  " + iOriMoney + " , fACost = " + iUnitCost + " " +
                                    " ,iOriTaxCost= " + iTaxPrice + ", iOriCost =" + iUnitCost + ", iOriMoney = " + iOriMoney + ",iOriSum =" + iOriSum +
                                    " ,iOriTaxPrice =" + iOriTaxPrice + ",  iTaxPrice = " + iOriTaxPrice + ", iSum = " + iOriSum +
                                    " ,cAssUnit = '" + dtPodetails.Rows[0]["cUnitID"].ToString() + "',bcosting=1 " +
                               " where autoid = " + iIDDetail;
                        aList.Add(sSQL);

                        if (dtPodetails.Rows[0]["iNum"].ToString().Trim() != string.Empty && Convert.ToDouble(dtPodetails.Rows[0]["iNum"]) != 0)
                        {
                            sSQL = "update @u8.rdrecords set iinvexchrate=cast((" + s2 + "/" + s1 + ")  as decimal(18, 4)),inum= " + s1 + " " +
                                   " where autoid = " + iIDDetail;
                            aList.Add(sSQL);
                        }

                        if (dtPodetails.Rows[0]["citemName"].ToString().Trim() != string.Empty)
                        {
                            sSQL = "update @u8.rdrecords set citem_class='" + dtPodetails.Rows[0]["citem_class"] + "',citemcode='" + dtPodetails.Rows[0]["citemName"] + "',cname='" + dtPodetails.Rows[0]["citemName"] + "',citemcname='外销订单项目' " +
                                   " where autoid = " + iIDDetail;
                            aList.Add(sSQL);
                        }



                        if (s1.Trim() == string.Empty)
                        {
                            sSQL = "update @u8.PO_Podetails  set iReceivedQTY = isnull(iReceivedQTY,0) + " + s2 + " where [id] = " + dr[j]["orderid"].ToString().Trim();

                        }
                        else
                        {
                            sSQL = "update @u8.PO_Podetails  set iReceivedQTY = isnull(iReceivedQTY,0) + " + s2 + ",iReceivedNum = isnull(iReceivedNum,0) + " + s1 + " where [id] = " + dr[j]["orderid"].ToString().Trim();
                        }
                        aList.Add(sSQL);

                        //////现存量
                        if (s1 == "null")
                        {
                            sSQL = "if exists(select * from  @u8.CurrentStock where cInvCode = '" + dr[j]["cInvcode"].ToString().Trim() + "' and cWhCode = '" + dr[j]["cDefWareHouse"].ToString().Trim() + "') " +
                            "	update  @u8.CurrentStock set iQuantity = isnull(iQuantity,0) + " + s2 + "  where cInvCode = '" + dr[j]["cInvcode"].ToString().Trim() + "' and cWhCode = '" + dr[j]["cDefWareHouse"].ToString().Trim() + "' " +
                                    "else " +
                                        "begin " +
                                        "    declare @itemid varchar(20); " +
                                  "declare @iCount int;  " +
                                    "select @iCount=count(itemid) from @u8.CurrentStock where cInvCode = '" + dr[i]["cInvcode"].ToString().Trim() + "';   " +
                                    "if( @iCount > 0 ) " +
                                    "	select @itemid=itemid from @u8.CurrentStock where cInvCode = '" + dr[i]["cInvcode"].ToString().Trim() + "';  " +
                                    "else  " +
                                    "	 select @itemid=max(itemid+1) from @u8.CurrentStock  " +
                                        "    insert into @u8.CurrentStock(cWhCode,cInvCode,iQuantity,itemid)values('" + dr[j]["cDefWareHouse"].ToString().Trim() + "','" + dr[j]["cInvcode"].ToString().Trim() + "'," + s2 + ",@itemid) " +
                                        "end";
                        }
                        else
                        {
                            sSQL = "if exists(select * from  @u8.CurrentStock where cInvCode = '" + dr[j]["cInvcode"].ToString().Trim() + "' and cWhCode = '" + dr[j]["cDefWareHouse"].ToString().Trim() + "') " +
                           "	update  @u8.CurrentStock set iQuantity = isnull(iQuantity,0) + " + s2 + ",iNum = isnull(iNum,0) + " + s1 + "  where cInvCode = '" + dr[j]["cInvcode"].ToString().Trim() + "' and cWhCode = '" + dr[j]["cDefWareHouse"].ToString().Trim() + "' " +
                                   "else " +
                                       "begin " +
                                       "    declare @itemid varchar(20); " +
                                  "declare @iCount int;  " +
                                    "select @iCount=count(itemid) from @u8.CurrentStock where cInvCode = '" + dr[i]["cInvcode"].ToString().Trim() + "';   " +
                                    "if( @iCount > 0 ) " +
                                    "	select @itemid=itemid from @u8.CurrentStock where cInvCode = '" + dr[i]["cInvcode"].ToString().Trim() + "';  " +
                                    "else  " +
                                    "	 select @itemid=max(itemid+1) from @u8.CurrentStock  " +
                                       "    insert into @u8.CurrentStock(cWhCode,cInvCode,iQuantity,iNum,itemid)values('" + dr[j]["cDefWareHouse"].ToString().Trim() + "','" + dr[j]["cInvcode"].ToString().Trim() + "'," + s2 + "," + s1 + ",@itemid) " +
                                       "end";
                        }
                        aList.Add(sSQL);
                        dr[j]["bUsed"] = iID;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }

        /// <summary>
        /// 返回入库单单据号
        /// </summary>
        /// <param name="sCode"></param>
        /// <returns></returns>
        private string sSetCode(long s)
        {
            string sCode = s.ToString().Trim();
            for (int i = 0; i < 4; i++)
            {
                if (sCode.Length < 4)
                {
                    sCode = "0" + sCode;
                }
                else
                {
                    break;
                }
            }

            return "IP" + DateTime.Parse(date1.DateTime.ToString("yyyy-MM-dd")).ToString("yyMM") + sCode;
        }


        /// <summary>
        /// 返回出库单单据号
        /// </summary>
        /// <param name="sCode"></param>
        /// <returns></returns>
        private string sSetOutCode(long s)
        {
            string sCode = s.ToString().Trim();
            for (int i = 0; i < 4; i++)
            {
                if (sCode.Length < 4)
                {
                    sCode = "0" + sCode;
                }
                else
                {
                    break;
                }
            }

            return "OP" + DateTime.Parse(date1.DateTime.ToString("yyyy-MM-dd")).ToString("yyMM") + sCode;
        }


        /// <summary>
        /// 返回到货单单据号
        /// </summary>
        /// <param name="s"></param>
        /// <param name="sDepCode"></param>
        /// <returns></returns>
        private string sSetCode(long s, string sDepCode)
        {
            string sCode = s.ToString().Trim();
            for (int i = 0; i < 4; i++)
            {
                if (sCode.Length < 4)
                {
                    sCode = "0" + sCode;
                }
                else
                {
                    break;
                }
            }

            string sDCode = "";
            string sSQL = "Select cCode from @u8.Vouchercontrapose Where cContent='Department' and cSeed='" + sDepCode + "'";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt != null && dt.Rows.Count > 0)
            {
                sDCode = dt.Rows[0]["cCode"].ToString().Trim();
                sDCode = sDCode.Substring(0, 1);
            }

            return sDCode + DateTime.Parse(date1.DateTime.ToString("yyyy-MM-dd")).ToString("yyMM") + sCode;
        }

        /// <summary>
        /// 导入委外到货单
        /// </summary>
        /// <param name="dr2"></param>
        private void ImportProcess(DataRow[] dr2, out string sInfo)
        {
            string sSQL = "";
            sInfo = "";

            try
            {
                gridView1.FocusedRowHandle -= 1;
            }
            catch { }

            for (int i = 0; i < dr2.Length; i++)
            {
                if (dr2[i]["bUsed"].ToString().Trim() == "-1")
                {
                    iCodeArr += 1;
                    string sDepCode = dr2[i]["cDepCode"].ToString().Trim();
                    string sRDCode = sSetCode(iCodeArr, sDepCode);

                    iIDArr += 1;
                    iIDDetailArr += 1;
                    //表头
                    sSQL = "Insert Into @u8.PU_ArrivalVouch(ivtid,id,ccode,cptcode,ddate,cvencode,cdepcode,cpersoncode,cpaycode,csccode,cexch_name,iexchrate,itaxrate,cmemo," +
                                "cbustype,cmaker,bnegative,cdefine1,cdefine2,cdefine3,cdefine4,cdefine5,cdefine6,cdefine7,cdefine8,cdefine9,cdefine10,cdefine11,cdefine12,cdefine13,cdefine14,cdefine15,cdefine16,ccloser,idiscounttaxtype,ibilltype,cvouchtype,cgeneralordercode,ctmcode,cincotermcode,ctransordercode,dportdate,csportcode,caportcode,csvencode,carrivalplace,dclosedate,idec,bcal,guid,iverifystate,cauditdate,cverifier,iverifystateex,ireturncount,iswfcontrolled,cvenpuomprotocol) " +
                           "Values( 8169," + iIDArr + ",'" + sRDCode + "','02','" + date1.DateTime.ToString("yyyy-MM-dd") + "','" + dr2[i]["cVenCode"].ToString().Trim() + "','" + sDepCode + "',NULL,NULL,NULL,N'人民币',1," + iTaxRate_All.ToString() + ",NULL, " +
                                "N'委外加工','" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',0,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,0,0,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,0,NULL) ";
                    aList.Add(sSQL);

                    sInfo = sInfo + sRDCode + ";";
                    //表体 

                    string s1 = "null";
                    if (dr2[i]["NowNum"].ToString().Trim() != string.Empty)
                        s1 = dr2[i]["NowNum"].ToString().Trim();
                    if (s1 == "null" || double.Parse(s1) == 0)
                        s1 = "null";
                    string s2 = "null";
                    if (dr2[i]["NowQuantity"].ToString().Trim() != string.Empty)
                        s2 = dr2[i]["NowQuantity"].ToString().Trim();
                    string s3 = "null";
                    if (dr2[i]["iArrQty1"].ToString().Trim() != string.Empty)
                        s3 = dr2[i]["iArrQty1"].ToString().Trim();
                    if (s3 == "null" || s3.Trim() == "" || double.Parse(s3) < 0)
                        s3 = "null";

                    string s4 = "null";
                    if (dr2[i]["iArrNum1"].ToString().Trim() != string.Empty)
                        s4 = dr2[i]["iArrNum1"].ToString().Trim();
                    if (s4 == "null" || s4.Trim() == "" || double.Parse(s4) <= 0)
                        s4 = "null";

                    sSQL = " Insert Into @u8.PU_ArrivalVouchs(autoid,id,cwhcode,cinvcode,inum,iquantity," +
                               "ioricost,ioritaxcost,iorimoney,ioritaxprice,iorisum,icost,imoney,itaxprice,isum,itaxrate," +
                               "citem_class,citemcode,iposid,citemname,frealquantity,fvalidquantity,bgsp,btaxcost,sodid," +
                               "sotype,iinvexchrate,csocode,cordercode,rejectsource,iexpiratdatecalcu) Values  " +
                           "(" + iIDDetailArr + "," + iIDArr + ",N'" + dr2[i]["cDefWareHouse"] + "',N'" + dr2[i]["cInvCode"] + "'," + s1 + "," + s2 + "," +
                               "null,null,null,null,null,null,null,null,null," + iTaxRate_All.ToString() + "," +
                               "null,null," + dr2[i]["OrderID"] + ",null," + dr2[i]["NowQuantity"] + ",null,0,0,N'" + dr2[i]["OrderID"] + "'," +
                               "0,0,null,N'" + dr2[i]["OrderNo"] + "',0,0)";
                    aList.Add(sSQL);

                    sSQL = "select isnull(bPropertyCheck,0) as bPropertyCheck,cAssComUnitCode from @u8.Inventory  where cInvCode = '" + dr2[i]["cInvCode"] + "' ";
                    DataTable dtGSP = clsSQLCommond.ExecQuery(sSQL);
                    if (dtGSP.Rows[0]["bPropertyCheck"].ToString().Trim() == "1" || Convert.ToBoolean(dtGSP.Rows[0]["bPropertyCheck"]))
                    {
                        sSQL = "update  @u8.PU_ArrivalVouchs set  bGsp = 1 where autoid = " + iIDDetailArr;
                        aList.Add(sSQL);
                    }

                    sSQL = "select * from @u8.OM_MODetails where MODetailsID = " + dr2[i]["orderid"].ToString().Trim();
                    DataTable dtPodetails = clsSQLCommond.ExecQuery(sSQL);

                    //原币含税单价  6位
                    //无税单价      6位
                    //数量          6位
                    //价税合计      2位   原币含税单价 * 数量
                    //无税金额      2位   价税合计 / （1 + 税率） 
                    //税额          2位   价税合计 - 无税金额 
                    //----------------------------------------------------------------------------------------------------------------
                    //税率
                    decimal ipertaxrate = decimal.Round(Convert.ToDecimal(dtPodetails.Rows[0]["iPerTaxRate"]), 2);
                    //原币含税单价
                    decimal iTaxPrice = decimal.Round(Convert.ToDecimal(dtPodetails.Rows[0]["iTaxPrice"]), 6);
                    //原币价税合计
                    decimal iOriSum = decimal.Round(iTaxPrice * decimal.Round(decimal.Parse(s2), 6), 2);
                    //原币无税金额 
                    decimal iOriMoney = decimal.Round(iOriSum / (1 + ipertaxrate / 100), 2);
                    //原币税额 
                    decimal iOriTaxPrice = iOriSum - iOriMoney;
                    //单价(不含税)
                    decimal iUnitCost = decimal.Round(iOriMoney / decimal.Round(decimal.Parse(s2), 6), 6);
                    //金额(不含税)
                    decimal iPrice = iOriMoney;


                    sSQL = "update @u8.PU_ArrivalVouchs set iOriCost= " + iUnitCost + ",iOriTaxCost = " + iTaxPrice + ",iOriMoney = " + iOriMoney + ",iOriTaxPrice = " + iOriTaxPrice + "," +
                                "iOriSum = " + iOriSum + ",iCost = " + iUnitCost + ",iMoney = " + iOriMoney + ",iTaxPrice = " + iOriTaxPrice + ",iSum = " + iOriSum + ",iTaxRate = " + ipertaxrate + " " +
                            " where autoid = " + iIDDetailArr;
                    aList.Add(sSQL);

                    if (dtPodetails.Rows[0]["iNum"].ToString().Trim() != string.Empty && Convert.ToDouble(dtPodetails.Rows[0]["iNum"]) != 0)
                    {
                        sSQL = "update @u8.PU_ArrivalVouchs set iinvexchrate=cast((" + s2 + "/" + s1 + ")  as decimal(18, 8)),inum=" + s1 + " " +
                                        " ,cUnitID = '" + dtGSP.Rows[0]["cAssComUnitCode"].ToString().Trim() + "' " +
                               " where autoid = " + iIDDetailArr;
                        aList.Add(sSQL);
                    }


                    if (dtPodetails.Rows[0]["citemName"].ToString().Trim() != string.Empty)
                    {

                        sSQL = "update @u8.PU_ArrivalVouchs set citem_class='" + dtPodetails.Rows[0]["citem_class"] + "',citemcode='" + dtPodetails.Rows[0]["citemcode"] + "',cItemName='" + dtPodetails.Rows[0]["citemName"] + "' " +
                                " where autoid = " + iIDDetailArr;
                        aList.Add(sSQL);
                    }

                    sSQL = "update @u8.OM_MODetails set iTaxPrice = " + iTaxPrice + ",iArrMoney = isnull(iArrMoney,0) + " + iOriSum + ",iNatArrMoney = isnull(iNatArrMoney,0) + " + iOriSum + ",iArrQTY = isnull(iArrQTY,0) + " + s2 + ",iArrNum =  isnull(iArrNum,0) + " + s1 + " where MODetailsID = " + dr2[i]["orderid"].ToString().Trim();
                    aList.Add(sSQL);

                    dr2[i]["bUsed"] = iIDArr;
                }
                else
                {
                    continue;
                }

                for (int j = i + 1; j < dr2.Length; j++)
                {
                    if (dr2[j]["bUsed"].ToString().Trim() == "-1" && dr2[i]["cDefWareHouse"].ToString().Trim() == dr2[j]["cDefWareHouse"].ToString().Trim())
                    {
                        iIDDetailArr += 1;
                        //表体 
                        string s1 = "null";
                        if (dr2[j]["NowNum"].ToString().Trim() != string.Empty)
                            s1 = dr2[j]["NowNum"].ToString().Trim();
                        if (s1 == "null" || double.Parse(s1) == 0)
                            s1 = "null";
                        string s2 = "null";
                        if (dr2[j]["NowQuantity"].ToString().Trim() != string.Empty)
                            s2 = dr2[j]["NowQuantity"].ToString().Trim();
                        string s3 = "null";
                        if (dr2[j]["iArrQty1"].ToString().Trim() != string.Empty)
                            s3 = dr2[j]["iArrQty1"].ToString().Trim();
                        if (s3 == "null" || s3.Trim() == "" || double.Parse(s3) < 0)
                            s3 = "null";

                        string s4 = "null";
                        if (dr2[j]["iArrNum1"].ToString().Trim() != string.Empty)
                            s4 = dr2[j]["iArrNum1"].ToString().Trim();
                        if (s4 == "null" || s4.Trim() == "" || double.Parse(s4) <= 0)
                            s4 = "null";

                        sSQL = " Insert Into @u8.PU_ArrivalVouchs(autoid,id,cwhcode,cinvcode,inum,iquantity," +
                                    "ioricost,ioritaxcost,iorimoney,ioritaxprice,iorisum,icost,imoney,itaxprice,isum,itaxrate," +
                                    "citem_class,citemcode,iposid,citemname,frealquantity,fvalidquantity,bgsp,btaxcost,sodid," +
                                    "sotype,iinvexchrate,csocode,cordercode,rejectsource,iexpiratdatecalcu) Values  " +
                                "(" + iIDDetailArr + "," + iIDArr + ",N'" + dr2[j]["cDefWareHouse"] + "',N'" + dr2[j]["cInvCode"] + "'," + s1 + "," + s2 + "," +
                                    "null,null,null,null,null,null,null,null,null," + iTaxRate_All.ToString() + "," +
                                    "null,null," + dr2[j]["OrderID"] + ",null," + dr2[j]["NowQuantity"] + ",null,0,0,N'" + dr2[j]["OrderID"] + "'," +
                                    "0,0,null,N'" + dr2[j]["OrderNo"] + "',0,0)";
                        aList.Add(sSQL);

                        sSQL = "select isnull(bPropertyCheck,0) as bPropertyCheck ,cAssComUnitCode from @u8.Inventory  where cInvCode = '" + dr2[j]["cInvCode"] + "' ";
                        DataTable dtGSP = clsSQLCommond.ExecQuery(sSQL);
                        if (dtGSP.Rows[0]["bPropertyCheck"].ToString().Trim() == "1" || Convert.ToBoolean(dtGSP.Rows[0]["bPropertyCheck"]))
                        {
                            sSQL = "update  @u8.PU_ArrivalVouchs set  bGsp = 1 where autoid = " + iIDDetailArr;
                            aList.Add(sSQL);
                        }


                        sSQL = "select * from @u8.OM_MODetails where MODetailsID = " + dr2[j]["orderid"].ToString().Trim();
                        DataTable dtPodetails = clsSQLCommond.ExecQuery(sSQL);


                        //原币含税单价  6位
                        //无税单价      6位
                        //数量          6位
                        //价税合计      2位   原币含税单价 * 数量
                        //无税金额      2位   价税合计 / （1 + 税率） 
                        //税额          2位   价税合计 - 无税金额 
                        //----------------------------------------------------------------------------------------------------------------
                        //税率
                        decimal ipertaxrate = decimal.Round(Convert.ToDecimal(dtPodetails.Rows[0]["iPerTaxRate"]), 2);
                        //原币含税单价
                        decimal iTaxPrice = decimal.Round(Convert.ToDecimal(dtPodetails.Rows[0]["iTaxPrice"]), 6);
                        //原币价税合计
                        decimal iOriSum = decimal.Round(iTaxPrice * decimal.Round(decimal.Parse(s2), 6), 2);
                        //原币无税金额 
                        decimal iOriMoney = decimal.Round(iOriSum / (1 + ipertaxrate / 100), 2);
                        //原币税额 
                        decimal iOriTaxPrice = iOriSum - iOriMoney;
                        //单价(不含税)
                        decimal iUnitCost = decimal.Round(iOriMoney / decimal.Round(decimal.Parse(s2), 6), 6);
                        //金额(不含税)
                        decimal iPrice = iOriMoney;

                        sSQL = "update @u8.PU_ArrivalVouchs set iOriCost= " + iUnitCost + ",iOriTaxCost = " + iTaxPrice + ",iOriMoney = " + iOriMoney + ",iOriTaxPrice = " + iOriTaxPrice + "," +
                                    "iOriSum = " + iOriSum + ",iCost = " + iUnitCost + ",iMoney = " + iOriMoney + ",iTaxPrice = " + iOriTaxPrice + ",iSum = " + iOriSum + ",iTaxRate = " + ipertaxrate + " " +
                                " where autoid = " + iIDDetailArr;
                        aList.Add(sSQL);

                        if (dtPodetails.Rows[0]["iNum"].ToString().Trim() != string.Empty && Convert.ToDouble(dtPodetails.Rows[0]["iNum"]) != 0)
                        {
                            sSQL = "update @u8.PU_ArrivalVouchs set iinvexchrate=cast((" + s2 + "/" + s1 + ")  as decimal(18, 8)),inum=" + s1 + " " +
                                        " ,cUnitID = '" + dtGSP.Rows[0]["cAssComUnitCode"].ToString().Trim() + "' " +
                                   " where autoid = " + iIDDetailArr;
                            aList.Add(sSQL);
                        }

                        if (dtPodetails.Rows[0]["citemName"].ToString().Trim() != string.Empty)
                        {

                            sSQL = "update @u8.PU_ArrivalVouchs set citem_class='" + dtPodetails.Rows[0]["citem_class"] + "',citemcode='" + dtPodetails.Rows[0]["citemcode"] + "',cItemName='" + dtPodetails.Rows[0]["citemName"] + "' " +
                                    " where autoid = " + iIDDetailArr;
                            aList.Add(sSQL);
                        }

                        sSQL = "update @u8.OM_MODetails set iTaxPrice = " + iTaxPrice + ",iArrMoney = isnull(iArrMoney,0) + " + iOriSum + ",iNatArrMoney = isnull(iNatArrMoney,0) + " + iOriSum + ",iArrQTY = isnull(iArrQTY,0) + " + s2 + ",iArrNum =  isnull(iArrNum,0) + " + s1 + " where MODetailsID = " + dr2[j]["orderid"].ToString().Trim();
                        aList.Add(sSQL);

                        dr2[j]["bUsed"] = iIDArr;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }

        /// <summary>
        /// 导入采购到货单
        /// </summary>
        /// PU_ArrivalVouch:	[cPersonCode,cPayCode,]cDefine2(客户订单号),cDefine11(外销订单号)
        ///PU_ArrivalVouchs:	cdefine37,csocode,sodid
        /// <param name="dr"></param>
        private void ImportStock(DataRow[] dr, out string sInfo)
        {
            string sSQL = "";
            sInfo = "";

            try
            {
                gridView1.FocusedRowHandle -= 1;
            }
            catch { }

            for (int i = 0; i < dr.Length; i++)
            {
                if (dr[i]["bUsed"].ToString().Trim() == "-1")
                {
                    iCodeArr += 1;
                    string sDepCode = dr[i]["cDepCode"].ToString().Trim();
                    string sRDCode = sSetCode(iCodeArr, sDepCode);

                    iIDArr += 1;
                    iIDDetailArr += 1;

                    string sPersonCodeInfo = "null";
                    if (dr[i]["业务员"].ToString().Trim() != string.Empty)
                    {
                        sPersonCodeInfo = "'" + dr[i]["业务员"].ToString().Trim() + "'";
                    }
                    //表头
                    sSQL = "Insert Into @u8.PU_ArrivalVouch(ivtid,id,ccode,cptcode,ddate,cvencode,cdepcode,cpersoncode,cpaycode,csccode,cexch_name,iexchrate,itaxrate,cmemo," +
                                "cbustype,cmaker,bnegative,cdefine1,cdefine2,cdefine3,cdefine4,cdefine5,cdefine6,cdefine7,cdefine8,cdefine9,cdefine10,cdefine11,cdefine12,cdefine13,cdefine14,cdefine15,cdefine16,ccloser,idiscounttaxtype,ibilltype,cvouchtype,cgeneralordercode,ctmcode,cincotermcode,ctransordercode,dportdate,csportcode,caportcode,csvencode,carrivalplace,dclosedate,idec,bcal,guid,iverifystate,cauditdate,cverifier,iverifystateex,ireturncount,iswfcontrolled,cvenpuomprotocol) " +
                           "Values( 8169," + iIDArr + ",'" + sRDCode + "','01','" + date1.DateTime.ToString("yyyy-MM-dd") + "','" + dr[i]["cVenCode"].ToString().Trim() + "','" + sDepCode + "',null,'03',NULL,N'人民币',1," + iTaxRate_All.ToString() + ",NULL, " +
                                "N'普通采购','" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',0,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,0,0,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,0,NULL) ";
                    aList.Add(sSQL);


                    sInfo = sInfo + sRDCode + ";";

                    //表体 

                    string s1 = "null";
                    if (dr[i]["NowNum"].ToString().Trim() != string.Empty)
                        s1 = dr[i]["NowNum"].ToString().Trim();
                    if (s1 == "null" || double.Parse(s1) == 0)
                        s1 = "null";

                    string s2 = "null";
                    if (dr[i]["NowQuantity"].ToString().Trim() != string.Empty)
                        s2 = dr[i]["NowQuantity"].ToString().Trim();
                    string s3 = "null";
                    if (dr[i]["iArrQty1"].ToString().Trim() != string.Empty)
                        s3 = dr[i]["iArrQty1"].ToString().Trim();
                    if (s3 == "null" || s3.Trim() == "" || double.Parse(s3) < 0)
                        s3 = "null";

                    string s4 = "null";
                    if (dr[i]["iArrNum1"].ToString().Trim() != string.Empty)
                        s4 = dr[i]["iArrNum1"].ToString().Trim();
                    if (s4 == "null" || s4.Trim() == "" || double.Parse(s4) <= 0)
                        s4 = "null";


                    sSQL = "select * from @u8.PO_Podetails where id = " + dr[i]["orderid"];
                    DataTable dtPodetails = clsSQLCommond.ExecQuery(sSQL);

                    sSQL = " Insert Into @u8.PU_ArrivalVouchs(autoid,id,cwhcode,cinvcode,inum,iquantity," +
                            "ioricost,ioritaxcost,iorimoney,ioritaxprice,iorisum,icost,imoney,itaxprice,isum,itaxrate," +
                            "citem_class,citemcode,iposid,citemname,frealquantity,fvalidquantity,bgsp,btaxcost,sodid," +
                            "sotype,iinvexchrate,csocode,cordercode,rejectsource,iexpiratdatecalcu) Values  " +
                        "(" + iIDDetailArr + "," + iIDArr + ",N'" + dr[i]["cDefWareHouse"] + "',N'" + dr[i]["cInvCode"] + "'," + s1 + "," + s2 + "," +
                            "null,null,null,null,null,null,null,null,null," + iTaxRate_All.ToString() + "," +
                            "null,null," + dr[i]["OrderID"] + ",null," + dr[i]["NowQuantity"] + ",null,0,0,N'" + dr[i]["OrderID"] + "'," +
                            "0,0,null,N'" + dr[i]["OrderNo"].ToString().Trim() + "',0,0)";
                    aList.Add(sSQL);


                    sSQL = "select isnull(bPropertyCheck,0) as bPropertyCheck,cAssComUnitCode from @u8.Inventory  where cInvCode = '" + dr[i]["cInvCode"].ToString().Trim() + "' ";
                    DataTable dtGSP = clsSQLCommond.ExecQuery(sSQL);
                    if (dtGSP.Rows[0]["bPropertyCheck"].ToString().Trim() == "1" || Convert.ToBoolean(dtGSP.Rows[0]["bPropertyCheck"]))
                    {
                        sSQL = "update  @u8.PU_ArrivalVouchs set  bGsp = 1 where autoid = " + iIDDetailArr;
                        aList.Add(sSQL);
                    }

                    //原币含税单价  6位
                    //无税单价      6位
                    //数量          6位
                    //价税合计      2位   原币含税单价 * 数量
                    //无税金额      2位   价税合计 / （1 + 税率） 
                    //税额          2位   价税合计 - 无税金额 
                    //----------------------------------------------------------------------------------------------------------------

                    //税率
                    decimal ipertaxrate = decimal.Round(Convert.ToDecimal(dtPodetails.Rows[0]["ipertaxrate"]), 2);
                    //单价(不含税)
                    decimal iUnitCost = decimal.Round(Convert.ToDecimal(dtPodetails.Rows[0]["iUnitPrice"]), 2);
                    //金额(不含税)
                    decimal iPrice = decimal.Round(iUnitCost * decimal.Parse(s2), 2);
                    //原币含税单价
                    decimal iTaxPrice = decimal.Round(Convert.ToDecimal(dtPodetails.Rows[0]["iTaxPrice"]), 6);
                    //原币价税合计
                    decimal iOriSum = decimal.Round(iTaxPrice * decimal.Round(decimal.Parse(s2), 6), 2);
                    //原币无税金额 
                    decimal iOriMoney = decimal.Round(iOriSum / (1 + ipertaxrate / 100), 2);
                    //原币税额 
                    decimal iOriTaxPrice = iOriSum - iOriMoney;

                    sSQL = "update @u8.PU_ArrivalVouchs set iOriCost= " + iUnitCost + ",iOriTaxCost = " + iTaxPrice + ",iOriMoney = " + iOriMoney + ",iOriTaxPrice = " + iOriTaxPrice + "," +
                                "iOriSum = " + iOriSum + ",iCost = " + iUnitCost + ",iMoney = " + iOriMoney + ",iTaxPrice = " + iOriTaxPrice + ",iSum = " + iOriSum + ",iTaxRate = " + ipertaxrate + " " +
                           " where autoid = " + iIDDetailArr;
                    aList.Add(sSQL);

                    if (dtPodetails.Rows[0]["iNum"].ToString().Trim() != string.Empty && Convert.ToDouble(dtPodetails.Rows[0]["iNum"]) != 0)
                    {
                        sSQL = "update @u8.PU_ArrivalVouchs set iinvexchrate=cast((" + s2 + "/" + s1 + ")  as decimal(18, 8)),inum=" + s1 + " " +
                                                  " ,cUnitID = '" + dtGSP.Rows[0]["cAssComUnitCode"].ToString().Trim() + "' " +
                               " where autoid = " + iIDDetailArr;
                        aList.Add(sSQL);
                    }

                    if (dtPodetails.Rows[0]["citemName"].ToString().Trim() != string.Empty)
                    {
                        sSQL = "update @u8.PU_ArrivalVouchs set citem_class='" + dtPodetails.Rows[0]["citem_class"] + "',citemcode='" + dtPodetails.Rows[0]["citemName"] + "',cItemName='" + dtPodetails.Rows[0]["citemName"] + "' " +
                               " where autoid = " + iIDDetailArr;
                        aList.Add(sSQL);
                    }

                    if (s1.Trim() == string.Empty)
                    {
                        sSQL = "update @u8.PO_Podetails  set iArrMoney = isnull(iArrMoney,0) + " + iPrice + ",iNatArrMoney =isnull(iNatArrMoney,0) + " + iPrice + " ,iArrQTY = isnull(iArrQTY,0) + " + s2 + ",fPoValidQuantity = isnull(fPoValidQuantity,0) + " + s2 + ",fPoArrQuantity= isnull(fPoArrQuantity,0) + " + s2 + "  where [id] = " + dr[i]["orderid"].ToString().Trim();

                    }
                    else
                    {
                        sSQL = "update @u8.PO_Podetails  set iArrMoney = isnull(iArrMoney,0) + " + iPrice + ",iNatArrMoney = isnull(iNatArrMoney,0) + " + iPrice + " ,iArrQTY = isnull(iArrQTY,0) + " + s2 + ",iArrNum = isnull(iArrNum,0) + " + s1 + ",fPoValidQuantity =isnull(fPoValidQuantity,0) + " + s2 + ",fPoArrQuantity=isnull(fPoArrQuantity,0) + " + s2 + ",fPoValidNum =isnull(fPoValidNum,0) + " + s1 + ",fPoArrNum=isnull(fPoArrNum,0) + " + s1 + "  where [id] = " + dr[i]["orderid"].ToString().Trim();
                    }
                    aList.Add(sSQL);

                    dr[i]["bUsed"] = iIDArr;
                }
                else
                {
                    continue;
                }

                for (int j = i + 1; j < dr.Length; j++)
                {
                    if (dr[j]["bUsed"].ToString().Trim() == "-1" && dr[i]["cDefWareHouse"].ToString().Trim() == dr[j]["cDefWareHouse"].ToString().Trim())
                    {
                        iIDDetailArr += 1;

                        //表体 

                        string s1 = "null";
                        if (dr[j]["NowNum"].ToString().Trim() != string.Empty)
                            s1 = dr[j]["NowNum"].ToString().Trim();
                        if (s1 == "null" || double.Parse(s1) == 0)
                            s1 = "null";

                        string s2 = "null";
                        if (dr[j]["NowQuantity"].ToString().Trim() != string.Empty)
                            s2 = dr[j]["NowQuantity"].ToString().Trim();
                        string s3 = "null";
                        if (dr[j]["iArrQty1"].ToString().Trim() != string.Empty)
                            s3 = dr[j]["iArrQty1"].ToString().Trim();
                        if (s3 == "null" || s3.Trim() == "" || double.Parse(s3) < 0)
                            s3 = "null";

                        string s4 = "null";
                        if (dr[j]["iArrNum1"].ToString().Trim() != string.Empty)
                            s4 = dr[j]["iArrNum1"].ToString().Trim();
                        if (s4 == "null" || s4.Trim() == "" || double.Parse(s4) <= 0)
                            s4 = "null";

                        sSQL = "select * from @u8.PO_Podetails where id = " + dr[j]["orderid"];
                        DataTable dtPodetails = clsSQLCommond.ExecQuery(sSQL);

                        sSQL = " Insert Into @u8.PU_ArrivalVouchs(autoid,id,cwhcode,cinvcode,inum,iquantity," +
                           "ioricost,ioritaxcost,iorimoney,ioritaxprice,iorisum,icost,imoney,itaxprice,isum,itaxrate," +
                           "citem_class,citemcode,iposid,citemname,frealquantity,fvalidquantity,bgsp,btaxcost,sodid," +
                           "sotype,iinvexchrate,csocode,cordercode,rejectsource,iexpiratdatecalcu) Values  " +
                       "(" + iIDDetailArr + "," + iIDArr + ",N'" + dr[j]["cDefWareHouse"] + "',N'" + dr[j]["cInvCode"] + "'," + s1 + "," + s2 + "," +
                           "null,null,null,null,null,null,null,null,null," + iTaxRate_All.ToString() + "," +
                           "null,null," + dr[j]["OrderID"] + ",null," + dr[j]["NowQuantity"] + ",null,0,0,N'" + dr[j]["OrderID"] + "'," +
                           "0,0,null,N'" + dr[j]["OrderNo"] + "',0,0)";
                        aList.Add(sSQL);

                        sSQL = "select isnull(bPropertyCheck,0) as bPropertyCheck,cAssComUnitCode from @u8.Inventory  where cInvCode = '" + dr[j]["cInvCode"].ToString().Trim() + "' ";
                        DataTable dtGSP = clsSQLCommond.ExecQuery(sSQL);
                        if (dtGSP.Rows[0]["bPropertyCheck"].ToString().Trim() == "1" || Convert.ToBoolean(dtGSP.Rows[0]["bPropertyCheck"]))
                        {
                            sSQL = "update  @u8.PU_ArrivalVouchs set  bGsp = 1 where autoid = " + iIDDetailArr;
                            aList.Add(sSQL);
                        }

                        //原币含税单价  5位
                        //无税单价      6位
                        //数量          6位
                        //价税合计      2位   原币含税单价 * 数量
                        //无税金额      2位   价税合计 / （1 + 税率） 
                        //税额          2位   价税合计 - 无税金额 
                        //---------------------------------------------------------

                        //税率
                        decimal ipertaxrate = decimal.Round(Convert.ToDecimal(dtPodetails.Rows[0]["ipertaxrate"]), 2);
                        //单价(不含税)
                        decimal iUnitCost = decimal.Round(Convert.ToDecimal(dtPodetails.Rows[0]["iUnitPrice"]), 2);
                        //金额(不含税)
                        decimal iPrice = decimal.Round(iUnitCost * decimal.Parse(s2), 2);
                        //原币含税单价
                        decimal iTaxPrice = decimal.Round(Convert.ToDecimal(dtPodetails.Rows[0]["iTaxPrice"]), 6);
                        //原币价税合计
                        decimal iOriSum = decimal.Round(iTaxPrice * decimal.Round(decimal.Parse(s2), 6), 2);
                        //原币无税金额 
                        decimal iOriMoney = decimal.Round(iOriSum / (1 + ipertaxrate / 100), 2);
                        //原币税额 
                        decimal iOriTaxPrice = iOriSum - iOriMoney;

                        sSQL = "update @u8.PU_ArrivalVouchs set iOriCost= " + iUnitCost + ",iOriTaxCost = " + iTaxPrice + ",iOriMoney = " + iOriMoney + ",iOriTaxPrice = " + iOriTaxPrice + "," +
                               "iOriSum = " + iOriSum + ",iCost = " + iUnitCost + ",iMoney = " + iOriMoney + ",iTaxPrice = " + iOriTaxPrice + ",iSum = " + iOriSum + ",iTaxRate = " + ipertaxrate + " " +
                          " where autoid = " + iIDDetailArr;
                        aList.Add(sSQL);

                        if (dtPodetails.Rows[0]["iNum"].ToString().Trim() != string.Empty && Convert.ToDouble(dtPodetails.Rows[0]["iNum"]) != 0)
                        {
                            sSQL = "update @u8.PU_ArrivalVouchs set iinvexchrate=cast((" + s2 + "/" + s1 + ")  as decimal(18, 8)),inum=" + s1 + " " +
                                                           " ,cUnitID = '" + dtGSP.Rows[0]["cAssComUnitCode"].ToString().Trim() + "' " +
                                   " where autoid = " + iIDDetailArr;
                            aList.Add(sSQL);
                        }

                        if (dtPodetails.Rows[0]["citemName"].ToString().Trim() != string.Empty)
                        {
                            sSQL = "update @u8.PU_ArrivalVouchs set citem_class='" + dtPodetails.Rows[0]["citem_class"] + "',citemcode='" + dtPodetails.Rows[0]["citemName"] + "',cItemName='" + dtPodetails.Rows[0]["citemName"] + "' " +
                                   " where autoid = " + iIDDetailArr;
                            aList.Add(sSQL);
                        }

                        if (s1.Trim() == string.Empty)
                        {
                            sSQL = "update @u8.PO_Podetails  set iArrMoney = isnull(iArrMoney,0) + " + iPrice + ",iNatArrMoney =isnull(iNatArrMoney,0) + " + iPrice + " ,iArrQTY = isnull(iArrQTY,0) + " + s2 + ",fPoValidQuantity = isnull(fPoValidQuantity,0) + " + s2 + ",fPoArrQuantity= isnull(fPoArrQuantity,0) + " + s2 + "  where [id] = " + dr[j]["orderid"].ToString().Trim();

                        }
                        else
                        {
                            sSQL = "update @u8.PO_Podetails  set iArrMoney = isnull(iArrMoney,0) + " + iPrice + ",iNatArrMoney = isnull(iNatArrMoney,0) + " + iPrice + " ,iArrQTY = isnull(iArrQTY,0) + " + s2 + ",iArrNum = isnull(iArrNum,0) + " + s1 + ",fPoValidQuantity =isnull(fPoValidQuantity,0) + " + s2 + ",fPoArrQuantity=isnull(fPoArrQuantity,0) + " + s2 + ",fPoValidNum =isnull(fPoValidNum,0) + " + s1 + ",fPoArrNum=isnull(fPoArrNum,0) + " + s1 + "  where [id] = " + dr[j]["orderid"].ToString().Trim();
                        }
                        aList.Add(sSQL);

                        dr[j]["bUsed"] = iIDArr;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }

        private void txtBarCode_KeyUp(object sender, KeyEventArgs e)
        {

            //单据类型 0 采购订单入库，1 委外订单入库；帐套号；单据ID；数量
            //         2 采购订单到货，3 委外订单到货,
            //         4 委外退货

            try
            {
                if (txtBarCode.Text.Trim() == string.Empty)
                {
                    return;
                }

                if (e.KeyCode == Keys.Enter)
                {
                    string[] s = txtBarCode.Text.Trim().Split('$');

                    if (s.Length == 1)
                    {
                        if (!ChkNumber(s[0]))
                        {
                            MessageBox.Show("行数必须是数字！");
                            txtBarCode.Text = string.Empty;
                            return;
                        }

                        txtRowCount.Text = s[0];
                        txtBarCode.Text = string.Empty;
                        txtBarCode.Focus();
                    }


                    if (s.Length == 5)
                    {

                        if (s[1].Trim() != FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3).Trim())
                        {
                            MessageBox.Show("登陆帐套错误，请选择正确的帐套！");
                            return;
                        }
                        string sSQL = "";
                        if (s[4] == "")
                        {
                            s[4] = "null";
                        }

                        //采购条码入库
                        if (s[0].Trim() == "0")
                        {
                            sSQL = "SELECT p.dPODate as dDate,cDefine2,'0' as OrderType,p.cDepCode,p.cPersonCode,p.cDefine14,p.cDefine11,p.poid as moid,pd.[id] as OrderID,p.cPOID as OrderNo,p.cVenCode,i.cInvCode,i.cInvName,i.cAssComUnitCode,i.cComUnitCode,c1.cComUnitName as cComUnitName1,c2.cComUnitName as cComUnitName2, " +
                                    "	i.cInvStd,pd.iQuantity,pd.iNum, " +
                                    "	" + s[3].Trim() + " as NowQuantity," + s[4].Trim() + " as NowNum,i.cDefWareHouse,(pD.iQuantity - isnull(pd.iReceivedQTY,0)) as iArrQty1,(pD.iNum- isnull(pd.iReceivedNum,0)) as iArrNum1 " +
                                    "   ,iUnitPrice as 原币无税单价,iNatUnitPrice as 本币无税单价,iPerTaxRate as 税率,pD.iTaxPrice as 含税单价,'' as iOMoDID,'' as iOMoMID  " +
                                    "   ,'' as bChoose,isnull(i.fInExcess ,0) as fInExcess,null as iWIPtype  " +
                                    "FROM @u8.PO_Podetails pD inner join @u8.PO_Pomain p on pD.poid=p.poid inner join @u8.Inventory i on i.cInvCode = pd.cInvCode left join  @u8.ComputationUnit c1 on c1.cComunitCode = i.cComUnitCode left join  @u8.ComputationUnit c2 on c2.cComunitCode = i.cAssComUnitCode  " +
                                    "WHERE pd.[id] =  " + s[2].Trim();
                        }
                        //委外条码入库
                        if (s[0].Trim() == "1")
                        {
                            sSQL = "SELECT distinct p.dDate as dDate,'1' as OrderType,p.cDepCode,pd.iUnitPrice,p.moid,pD.MODetailsID AS OrderID, p.cCode AS OrderNo,p.cVenCode,i.cAssComUnitCode,i.cComUnitCode,c1.cComUnitName as cComUnitName1,c2.cComUnitName as cComUnitName2, " +
                                    "	pD.cInvCode AS cInvCode, i.cInvName AS cInvName, i.cInvStd AS cInvStd, pD.iQuantity AS iQuantity,pD.iNum, " +
                                    "	" + s[3].Trim() + " as NowQuantity," + s[4].Trim() + "  as NowNum,i.cDefWareHouse,(pD.iQuantity - isnull(pd.iReceivedQTY,0)) as iArrQty1,(pD.iNum- isnull(pd.iReceivedNum,0)) as iArrNum1,'' as iOMoDID,'' as iOMoMID " +
                                      "   ,'' as bChoose,isnull(i.fInExcess ,0) as fInExcess,pDD.iWIPtype  " +
                                    "FROM @u8.OM_MOMain p LEFT OUTER JOIN @u8.OM_MODetails pD ON p.MOID = pD.MOID  " +
                                    "   left outer join @u8.OM_MOMaterials pDD on pDD.MoDetailsID = pD.MoDetailsID " +
                                    "	LEFT OUTER JOIN @u8.Inventory i ON i.cInvCode = pD.cInvCode  " +
                                    "  left join  @u8.ComputationUnit c1 on c1.cComunitCode = i.cComUnitCode left join  @u8.ComputationUnit c2 on c2.cComunitCode = i.cAssComUnitCode " +
                                    "WHERE pD.MODetailsID =  " + s[2].Trim();
                        }
                        //采购条码到货
                        if (s[0].Trim() == "2")
                        {
                            sSQL = "SELECT p.dPODate as dDate,cDefine2,'2' as OrderType,p.cDepCode,p.cPersonCode,p.cDefine14,p.cDefine11,p.poid as moid,pd.[id] as OrderID,p.cPOID as OrderNo,p.cVenCode,i.cInvCode,i.cInvName,i.cAssComUnitCode,i.cComUnitCode,c1.cComUnitName as cComUnitName1,c2.cComUnitName as cComUnitName2, " +
                                    "	i.cInvStd,pd.iQuantity,pd.iNum, " +
                                    "	" + s[3].Trim() + " as NowQuantity," + s[4].Trim() + " as NowNum,i.cDefWareHouse,(pD.iQuantity - isnull(pd.iArrQTY,0)) as iArrQty1,(pD.iNum- isnull(pd.iArrNum,0)) as iArrNum1 " +
                                    "   ,iUnitPrice as 原币无税单价,iNatUnitPrice as 本币无税单价,iPerTaxRate as 税率,pD.iTaxPrice as 含税单价,'' as iOMoDID,'' as iOMoMID  " +
                                    "   ,'' as bChoose,isnull(i.fInExcess ,0) as fInExcess,null as iWIPtype  " +
                                    "FROM @u8.PO_Podetails pD inner join @u8.PO_Pomain p on pD.poid=p.poid inner join @u8.Inventory i on i.cInvCode = pd.cInvCode left join  @u8.ComputationUnit c1 on c1.cComunitCode = i.cComUnitCode left join  @u8.ComputationUnit c2 on c2.cComunitCode = i.cAssComUnitCode  " +
                                    "WHERE pd.[id] =  " + s[2].Trim();
                        }
                        //委外条码到货
                        if (s[0].Trim() == "3")
                        {
                            sSQL = "SELECT distinct p.dDate as dDate,'3' as OrderType,p.cDepCode,pd.iUnitPrice,p.moid,pD.MODetailsID AS OrderID, p.cCode AS OrderNo,p.cVenCode,i.cAssComUnitCode,i.cComUnitCode,c1.cComUnitName as cComUnitName1,c2.cComUnitName as cComUnitName2, " +
                                    "	pD.cInvCode AS cInvCode, i.cInvName AS cInvName, i.cInvStd AS cInvStd, pD.iQuantity AS iQuantity,pD.iNum, " +
                                    "	" + s[3].Trim() + " as NowQuantity," + s[4].Trim() + "  as NowNum,i.cDefWareHouse,(pD.iQuantity - isnull(pd.iArrQTY,0)) as iArrQty1,(pD.iNum- isnull(pd.iArrNum,0)) as iArrNum1,'' as iOMoDID,'' as iOMoMID " +
                                    "   ,'' as bChoose,isnull(i.fInExcess,0) as fInExcess,pDD.iWIPtype " +
                                    "FROM @u8.OM_MOMain p LEFT OUTER JOIN @u8.OM_MODetails pD ON p.MOID = pD.MOID  " +
                                    "   left outer join @u8.OM_MOMaterials pDD on pDD.MoDetailsID = pD.MoDetailsID " +
                                    "	LEFT OUTER JOIN @u8.Inventory i ON i.cInvCode = pD.cInvCode  " +
                                    "  left join  @u8.ComputationUnit c1 on c1.cComunitCode = i.cComUnitCode left join  @u8.ComputationUnit c2 on c2.cComunitCode = i.cAssComUnitCode " +
                                    "WHERE pD.MODetailsID =  " + s[2].Trim();
                        }

                        //委外退货
                        if (s[0].Trim() == "4")
                        {
                            IsBack = true;
                            sSQL = @"
                                      select    p.dDate as dDate ,
                                            '4' as OrderType ,
                                            p.cDepCode ,
                                            pd.iUnitPrice ,
                                            PD.moid ,
                                            OD.MOMaterialsID as OrderID ,
                                            p.cCode as OrderNo ,
                                            p.cVenCode ,
                                            i.cAssComUnitCode ,
                                            i.cComUnitCode ,
                                            c1.cComUnitName as cComUnitName1 ,
                                            c2.cComUnitName as cComUnitName2 ,
                                            I.cInvCode as cInvCode ,
                                            i.cInvName as cInvName ,
                                            i.cInvStd as cInvStd ,
                                            OD.iQuantity as iQuantity ,
                                            OD.iNum as iNum ,
                                            cast({1} as decimal(18,6)) as NowQuantity ,
                                            cast({2} as decimal(18,6)) as NowNum ,
                                            '0A' as cDefWareHouse ,
                                            '' as iArrQty1 ,
                                            '' as iArrNum1,
                                            OD.MOMaterialsID,
                                            OD.iSendQty - ((ISNULL(PD.iReceivedQTY ,0) +ISNULL (PD.iArrQTY,0))*(OD.fBaseQtyN / OD.fBaseQtyD ))  as RemainQty,
                                            pd.MODetailsID as iOMoDID,OD.MOMaterialsID as iOMoMID,'' as bChoose,isnull(i.fInExcess ,0) as fInExcess ,null as iWIPtype
                                    from      @u8.OM_MOMaterials OD 
                                            left join @u8.OM_MODetails PD on OD.[MoDetailsID]=PD.[MoDetailsID]  
                                            left join @u8.OM_MOMain p on pd.MOID = p.MOID
                                            left join @u8.Inventory i on i.cInvCode = OD.cInvCode
                                            left join @u8.ComputationUnit c1 on c1.cComunitCode = i.cComUnitCode
                                            left join @u8.ComputationUnit c2 on c2.cComunitCode = i.cAssComUnitCode
                                           
                                    where     OD.MOMaterialsID ={0}
                                     ";

                            sSQL = string.Format(sSQL, s[2], s[3], s[4]);
                        }

                        DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                        if (dt.Rows.Count != 1)
                        {
                            MessageBox.Show("数据错误，请检查！");
                            return;
                        }

                        bool bHav = false;
                        for (int i = 0; i < dtTable.Rows.Count; i++)
                        {
                            if (dtTable.Rows[i]["OrderID"].ToString().Trim() == s[2].Trim())
                            {
                                bHav = true;
                                break;
                            }
                        }

                        if (!bHav)
                        {
                            DataRow dr = dtTable.NewRow();
                            dr["bUsed"] = -1;
                            dr["OrderType"] = dt.Rows[0]["OrderType"];
                            dr["moid"] = dt.Rows[0]["moid"];
                            dr["OrderID"] = dt.Rows[0]["OrderID"];
                            dr["OrderNo"] = dt.Rows[0]["OrderNo"];
                            dr["cVenCode"] = dt.Rows[0]["cVenCode"];
                            dr["cInvCode"] = dt.Rows[0]["cInvCode"];
                            dr["cInvName"] = dt.Rows[0]["cInvName"];
                            dr["cInvStd"] = dt.Rows[0]["cInvStd"];
                            dr["iQuantity"] = dt.Rows[0]["iQuantity"];
                            dr["iNum"] = dt.Rows[0]["iNum"];
                            dr["NowQuantity"] = dt.Rows[0]["NowQuantity"];
                            dr["NowNum"] = dt.Rows[0]["NowNum"];
                            dr["cDefWareHouse"] = dt.Rows[0]["cDefWareHouse"];
                            dr["iArrQty1"] = dt.Rows[0]["iArrQty1"];
                            dr["iArrNum1"] = dt.Rows[0]["iArrNum1"];
                            dr["cComUnitName1"] = dt.Rows[0]["cComUnitName1"];
                            dr["cComUnitName2"] = dt.Rows[0]["cComUnitName2"];
                            dr["cDepCode"] = dt.Rows[0]["cDepCode"];
                            dr["iOMoDID"] = dt.Rows[0]["iOMoDID"];
                            dr["iOMoMID"] = dt.Rows[0]["iOMoMID"];
                            dr["bChoose"] = "";
                            dr["fInExcess"] = dt.Rows[0]["fInExcess"];
                            dr["iWIPtype"] = dt.Rows[0]["iWIPtype"];
                            if (s[0].Trim() == "0")
                            {
                                dr["原币无税单价"] = dt.Rows[0]["原币无税单价"];
                                dr["本币无税单价"] = dt.Rows[0]["本币无税单价"];
                                dr["税率"] = dt.Rows[0]["税率"];
                                dr["含税单价"] = dt.Rows[0]["含税单价"];
                                dr["业务员"] = dt.Rows[0]["cPersonCode"];
                                dr["外销订单号"] = dt.Rows[0]["cDefine11"];
                                dr["请购单号"] = dt.Rows[0]["cDefine14"];
                                dr["cDefine2"] = dt.Rows[0]["cDefine2"];
                            }

                            double d1 = 0;//订单数量
                            try
                            {
                                d1 = Convert.ToDouble(dr["iQuantity"]);
                            }
                            catch { }
                            double d2 = 0;//订单件数
                            try
                            {
                                d2 = Convert.ToDouble(dr["iNum"]);
                            }
                            catch { }
                            double d3 = 0;//超订单比率
                            try
                            {
                                d3 = Convert.ToDouble(dr["fInExcess"]);
                            }
                            catch { }
                            double d4 = 0;//未入库数量
                            try
                            {
                                d4 = Convert.ToDouble(dr["iArrQty1"]);
                                d4 = d1 - d4;
                            }
                            catch { }
                            double d5 = 0;//未入库件数
                            try
                            {
                                d5 = Convert.ToDouble(dr["iArrNum1"]);
                                d5 = d2 - d5;
                            }
                            catch { }
                            double d6 = 0;//本次入库数量
                            try
                            {
                                d6 = Convert.ToDouble(dr["NowQuantity"]);
                            }
                            catch { }
                            double d7 = 0;//本次入库件数
                            try
                            {
                                d7 = Convert.ToDouble(dr["NowNum"]);
                            }
                            catch { }

                            if (d1 * (1 + d3) < d4 + d6)
                            { 
                                MessageBox.Show("发货数量已经超出，请核查！");
                                dr["bChoose"] = "√";
                            }
                            if (d2 > 0 && d2 * (1 + d3) < d5 + d7)
                            {
                                MessageBox.Show("发货件数已经超出，请核查！");
                                dr["bChoose"] = "√";
                            }

                            if (s[0].Trim() == "1")
                            {
                                dr["加工费单价"] = dt.Rows[0]["iUnitPrice"];
                            }

                            if (s[0].Trim() == "0")
                            {
                                if (Convert.ToDouble(dr["NowQuantity"]) > Convert.ToDouble(dr["iArrQty1"]))
                                {
                                    MessageBox.Show("到货数量超出！");
                                }
                            }
                            if (s[0].Trim() == "1" && dt.Rows[0]["iWIPtype"].ToString().Trim() != "1")
                            {
                                //string sSQL2 = "select min(iSendQTY/(fBaseQtyN/fBaseQtyD)) as iQty from @u8.OM_MOMaterials  where MoDetailsID = " + dt.Rows[0]["OrderID"];
                                string sSQL2 = "select min(odM.iSendQTY/(odM.iQuantity/od.iQuantity)) as iQty from @u8.OM_MODetails od inner join @u8.OM_MOMaterials odM on od.MoDetailsID = odM.MODetailsID where od.MoDetailsID = " + dt.Rows[0]["OrderID"];
                              
                                double d11 = Convert.ToDouble(clsSQLCommond.ExecGetScalar(sSQL2));
                                sSQL2 = "select iWIPtype from @u8.OM_MOMaterials  where iWIPtype = 1 and MoDetailsID = " + dt.Rows[0]["OrderID"];
                                DataTable dtType = clsSQLCommond.ExecQuery(sSQL2);
                                if (dtType == null || dtType.Rows.Count < 1)
                                {
                                    if (Convert.ToDouble(dr["NowQuantity"]) > d11 - (Convert.ToDouble(dr["iQuantity"]) - Convert.ToDouble(dr["iArrQty1"])) || Convert.ToDouble(dr["NowQuantity"]) > Convert.ToDouble(dr["iArrQty1"]))
                                    {
                                        MessageBox.Show("到货数量超出发料！");
                                        dr["bChoose"] = "√";
                                    }
                                }
                            }
                            if (s[0].Trim() == "2")
                            {
                                if (Convert.ToDouble(dr["NowQuantity"]) > Convert.ToDouble(dr["iArrQty1"]))
                                {
                                    MessageBox.Show("到货数量超出！");
                                    dr["bChoose"] = "√";
                                }

                                string sSQLDate = "select * from @u8.PO_Podetails where id = " + s[2];
                                DataTable dtDateChk = clsSQLCommond.ExecQuery(sSQLDate);
                                DateTime dDate1 = DateTime.Now;
                                if (dtDateChk.Rows[0]["cDefine37"].ToString().Trim() != "")
                                {
                                    dDate1 = Convert.ToDateTime(dtDateChk.Rows[0]["cDefine37"]);
                                }
                                else if (dtDateChk.Rows[0]["cDefine36"].ToString().Trim() != "")
                                {
                                    dDate1 = Convert.ToDateTime(dtDateChk.Rows[0]["cDefine36"]);
                                }

                                DateTime dDate2 = Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate).AddDays(7);
                                if (dDate1 > dDate2)
                                {
                                    DialogResult dRes = MessageBox.Show("超7天交货，是否继续\n是：继续导入\n否：终止导入", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                                    if (dRes != DialogResult.Yes)
                                    {
                                        return;
                                    }
                                }
                            }
                            if (s[0].Trim() == "3" && dt.Rows[0]["iWIPtype"].ToString().Trim() != "1")
                            {
                                //string sSQL2 = "select min(iSendQTY/(fBaseQtyN/fBaseQtyD)) as iQty from @u8.OM_MOMaterials  where MoDetailsID = " + dt.Rows[0]["OrderID"];
                                string sSQL2 = "select min(odM.iSendQTY/(odM.iQuantity/od.iQuantity)) as iQty from @u8.OM_MODetails od inner join @u8.OM_MOMaterials odM on od.MoDetailsID = odM.MODetailsID where od.MoDetailsID = " + dt.Rows[0]["OrderID"];
                                double d11 = Convert.ToDouble(clsSQLCommond.ExecGetScalar(sSQL2));
                                sSQL2 = "select iWIPtype from @u8.OM_MOMaterials  where iWIPtype = 1 and MoDetailsID = " + dt.Rows[0]["OrderID"];
                                DataTable dtType = clsSQLCommond.ExecQuery(sSQL2);
                                if (dtType == null || dtType.Rows.Count < 1)
                                {
                                    if (Convert.ToDouble(dr["NowQuantity"]) > d11 - (Convert.ToDouble(dr["iQuantity"]) - Convert.ToDouble(dr["iArrQty1"]) )|| Convert.ToDouble(dr["NowQuantity"]) > Convert.ToDouble(dr["iArrQty1"]))
                                    {
                                        MessageBox.Show("到货数量超出发料！");
                                        dr["bChoose"] = "√";
                                    }
                                }
                            }
                            if (s[0].Trim() == "4")
                            {
                                dr["OrderID"] = dt.Rows[0]["MOMaterialsID"];
                                decimal remainQty = decimal.Parse(dt.Rows[0]["RemainQty"].ToString());
                                decimal curQty = decimal.Parse(s[3]);
                                if (curQty > remainQty)
                                {
                                    MessageBox.Show("退货数量大于剩余数量！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    dr["bChoose"] = "√";
                                    return;
                                }

                            }
                            dtTable.Rows.Add(dr);
                            gridControl1.DataSource = dtTable;

                        }
                        else
                        {
                            MessageBox.Show("本条码已经扫描！");
                        }
                        txtBarCode.Text = "";
                        txtBarCode.Focus();
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("条码输入失败！ \n\n原因:\n  " + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmArrivalVouchIn_Activated(object sender, EventArgs e)
        {
            txtBarCode.Focus();
        }

        /// <summary>
        /// 获得单据ID
        /// </summary>
        /// <param name="sType">单据类型  PuArrival，</param>
        private void GetID(string sType, out long iID, out long iIDDetail)
        {
            //string sSQL = "select iFatherID,iChildID from UFSystem..UA_Identity where cAcc_Id = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3) + "' and cVouchType = '" + sType + "'";
            string sSQL = @"
declare @p5 int
set @p5=1000043137
declare @p6 int
set @p6=1000043137
exec @u8.sp_GetID @RemoteId=N'00',@cAcc_Id=N'200',@cVouchType=N'aaaaaa',@iAmount=1,@iFatherId=@p5 output,@iChildId=@p6 output
select @p5, @p6
";
            sSQL = sSQL.Replace("aaaaaa", sType);
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            if (dt == null || dt.Rows.Count < 1)
            {
                iID = 0;
                iIDDetail = 0;
            }
            else
            {
                iID = Convert.ToInt64(dt.Rows[0][0]);
                iIDDetail = Convert.ToInt64(dt.Rows[0][1]);
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column == gridColcInvName)
                {
                    string sSQL = "select cVenCode,cVenName,cVenAbbName from  @u8.Vendor where cVenCode = '" + gridView1.GetRowCellValue(e.RowHandle, gridColcInvName).ToString().Trim() + "'";
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);

                    gridView1.SetRowCellValue(e.RowHandle, gridColcInvStd, dt.Rows[0]["cVenName"].ToString().Trim());
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("设置供应商信息失败！\n\t原因：" + ee.Message);
            }

            try
            {
                if (e.Column == gridColNowQuantity || e.Column == gridColNowNum)
                {
                    if (!ChkNumber(gridView1.GetRowCellValue(e.RowHandle, gridColNowQuantity)))
                    {
                        MessageBox.Show("请输入数字！");
                        gridView1.SetRowCellValue(e.RowHandle, gridColNowQuantity, "");
                        return;
                    }

                    if (!ChkNumber(gridView1.GetRowCellValue(e.RowHandle, gridColNowNum)))
                    {
                        MessageBox.Show("请输入数字！");
                        gridView1.SetRowCellValue(e.RowHandle, gridColNowNum, "");
                        return;
                    }
                    if (e.Column == gridColNowQuantity)
                    {
                        if (gridView1.GetRowCellValue(e.RowHandle, gridColNowQuantity).ToString().Trim() != "")
                        {
                            try
                            {
                                if (IsBack)
                                {
                                    double d = Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridColNowQuantity)) * Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridColiNum)) / Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridColiQuantity));
                                    gridView1.SetRowCellValue(e.RowHandle, gridColNowNum, d.ToString("0.000000"));
                                }
                                else
                                {
                                    double d = Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridColNowQuantity)) * Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridColiArrNum1)) / Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridColiArrQty1));
                                    gridView1.SetRowCellValue(e.RowHandle, gridColNowNum, d.ToString("0.000000"));
                                }
                            }
                            catch { }
                        }
                    }
                }
            }
            catch
            { }
        }

        private bool ChkNumber(object oNum)
        {
            bool b = false;
            try
            {
                if (oNum.ToString().Trim() != string.Empty)
                {
                    double d = Convert.ToDouble(oNum);
                }

                b = true;
            }
            catch
            { }
            return b;
        }

        private void GetcWhCode()
        {
            string sSQL = "select cWhCode,cWhName from @u8.Warehouse  order by cWhCode";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            LookUpWH.DataSource = dt;
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                if (e.RowHandle >= 0)
                {
                    
                    if (gridView1.GetRowCellValue(e.RowHandle, gridColbChoose).ToString().Trim() == "√")
                    {
                        e.Appearance.BackColor = Color.Tomato;
                    }
                }
            }
            catch
            { }
        }

    }
}