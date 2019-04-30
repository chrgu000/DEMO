using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace WorkInformation
{
    public partial class FrmWorkProcedure : FrameBaseFunction.Frm列表窗体模板
    {
        public FrmWorkProcedure()
        {
            InitializeComponent();
        }

        private void FrmWorkProcedure_Load(object sender, EventArgs e)
        {
            try
            {
                txtBarCode.ReadOnly = false;
                txtBarCode.Enabled = true;
                lookUpEquipment.Properties.ReadOnly = false;
                lookUpEquipment.Enabled = true;

                txtTime.Properties.ReadOnly = false;
                txtTime.Enabled = true;

                txtPer.Properties.ReadOnly = false;
                GetQCBase();
                //GetWorkPer();
                GetFacility();
                //GetProCode();
                //GetWorkDep();

                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败！\n    " + ee.Message);
            }
        }

        /// <summary>
        /// 获得母件编码
        /// </summary>
        private void GetProCode()
        {
            try
            {
                if (txtcInvCode.Text.Trim() != string.Empty)
                {
                    string sSQL = "select distinct bas.InvCode as cInvCode,i.cInvName,i.cInvStd from @u8.bom_bom b  " +
                           "left join @u8.bom_parent bP on b.BomId=bP.BomId left join @u8.bas_part bas on bas.PartId = bP.ParentId " +
                           "left join @u8.bom_opcomponent bOP on bOp.BomId = b.BomId left join @u8.bas_part bas2 on bOP.ComponentId = bas2.partid left join @u8.Inventory i on i.cInvCode =bas.InvCode " +
                       "where bas2.Invcode = '" + txtcInvCode.Text.Trim() + "' " +
                       "order by bas.InvCode";
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    lookUpEditProCode.Properties.DataSource = dt;
                }
            }
            catch (Exception ee)
            {
                throw new Exception("获得设备信息失败！" + ee.Message);
            }
        }



        private void lookUpEditProCode_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (lookUpEditProCode.Text.Trim() == string.Empty)
                {
                    txtProcInvName.Text = "";
                }
                else
                {
                    string sSQL = "select cInvName from @u8.inventory where cInvCode = '" + lookUpEditProCode.Text.Trim() + "'";
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    txtProcInvName.Text = dt.Rows[0]["cInvName"].ToString();
                }
            }
            catch (Exception ee)
            {
                throw new Exception("获得设备信息失败！" + ee.Message);
            }
        }


        /// <summary>
        /// 获得设备信息
        /// </summary>
        private void GetFacility()
        {
            try
            {
                string sSQL = "select FCode,FName from UFDLImport..FacilityInfo order by FName,FCode";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                lookUpEquipment.Properties.DataSource = dt;
            }
            catch (Exception ee)
            {
                throw new Exception("获得设备信息失败！" + ee.Message);
            }
        }

        private void GetQCBase()
        {
            try
            {
                string sSQL = "select vchrCode,vchrName from UFDLImport..QCBase1 where isnull(bClose,0) = 0 order by vchrCode";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                LookUpEditQty.DataSource = dt;
            }
            catch (Exception ee)
            {
                throw new Exception("获得不良类型失败！" + ee.Message);
            }
        }

        private void GetGrid()
        {
            try
            {
                string sSQL = "select * from UFDLImport..WorkPlanDetailDefective where 1=-1 order by [ID]";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                gridControl2.DataSource = dt;
                gridView2.AddNewRow();
            }
            catch (Exception ee)
            {
                throw new Exception("获得班组信息失败！" + ee.Message);
            }
        }

        protected override void BtnClick(string sBtnName, string sBtnText)
        {
            try
            {
                switch (sBtnName.ToLower())
                {
                    case "save":
                        btnSave();
                        break;
                    case "addrow":
                        btnAddRow();
                        break;
                    case "delrow":
                        btnDelRow();
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

        private void btnAddRow()
        {
            gridView2.AddNewRow();
        }

        private void btnDelRow()
        {
            try
            {
                gridView2.DeleteRow(gridView2.FocusedRowHandle);
            }
            catch { }
        }

        private void btnSave()
        {
            if (txtWorkOrderNO.Text.Trim() == string.Empty)
            {
                MessageBox.Show("请扫描条码！");
                return;
            }

            if (txtPer.Text.Trim() == string.Empty)
            {
                MessageBox.Show("员工信息不能为空！");
                txtPer.Select();
                return;
            }

            if (txtworkDepment2.Text.Trim() == "")
            {
                MessageBox.Show("接受部门信息不能为空！");
                return;
            }

            string sMsg = "";

            string sGuid = Guid.NewGuid().ToString().Trim();
            ArrayList aList = new ArrayList();
            string sSQL = "insert into UFDLImport..WorkPlanDetail(WorkDep,iQuantity,GUIDHead,[GUID],dtmDay,vchruid,vchrPer,vchrFacility,workTime)values('" + txtworkDepment2.Text.Trim() + "'," + txtQtyNow.Text.Trim() + ",'" + txtGuid.Text.Trim() + "','" + sGuid + "','" + dtm1.Text.Trim() + "','" + FrameBaseFunction.ClsBaseDataInfo.sUid + "','" + txtPer.Text.Trim() + "','" + lookUpEquipment.Text.Trim() + "'," + txtTime.Text.Trim() + ")";
            aList.Add(sSQL);

            if (gridView2.RowCount > 0)
            {
                try
                {
                    gridView2.FocusedRowHandle -= 1;
                    gridView2.FocusedRowHandle += 1;
                }
                catch { }

                for (int i = gridView2.RowCount - 1; i >= 0; i--)
                {
                    if (gridView2.GetRowCellValue(i, gridColumn14).ToString().Trim() == string.Empty)
                        gridView2.DeleteRow(i);
                }

                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    sSQL = "insert into UFDLImport..WorkPlanDetailDefective(defectiveType,iQuantity,GUIDHead)values('" + gridView2.GetRowCellDisplayText(i, gridColumn14).Trim() + "'," + gridView2.GetRowCellDisplayText(i, gridColumn16).Trim() + ",'" + sGuid + "')";
                    aList.Add(sSQL);
                }
            }

            sMsg = "工序转移成功！";

            bool bRDIn = false;
            string sCode = "";
            if (txtRDIn.Text.Trim().ToLower() == "是")
            {
                string sMODID = "";
                if (MessageBox.Show("是否生成产成品入库单？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    bRDIn = true;
                }

                int iYear = int.Parse(ReturnObjectToDatetime(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyy"));
                int iYear2 = int.Parse(dtm1.DateTime.ToString("yyyy"));
                if (iYear >= iYear2)
                {
                    sSQL = "select * from @u8.GL_mend where iperiod = month('" + dtm1.DateTime + "')";
                    DataTable dttemp1 = clsSQLCommond.ExecQuery(sSQL);
                    if (Convert.ToBoolean(dttemp1.Rows[0]["bflag_ST"]) == true)
                    {
                        MessageBox.Show("当月库存管理已结帐，不能录入数据！");
                        return;
                    }
                }

                if (bRDIn)
                {
                    if (txtProcInvName.Text.Trim() == "")
                    {
                        if (MessageBox.Show("母件编码为空，是否继续？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.No)
                        {
                            lookUpEditProCode.Select();
                            throw new Exception("请输入母件编码！");
                        }
                    }

                    //可以使用mom_orderdetail表的  WIPType
                    sSQL = "select iSupplyType,isnull(cDefWareHouse,'') as cDefWareHouse from @u8.inventory  where cinvcode = '" + txtcInvCode.Text.Trim() + "' ";
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    if (dt.Rows.Count > 0)
                    {
                        //默认仓库编码
                        string sWHCode = dt.Rows[0]["cDefWareHouse"].ToString().Trim();
                        if (sWHCode == string.Empty)
                        {
                            MessageBox.Show("请先设置默认仓库，料号：" + txtcInvCode.Text.Trim());
                            return;
                        }

                        ////0：领用；       1：入库倒冲

                        if (dt.Rows[0]["iSupplyType"].ToString().Trim() == "0")
                        {
                            //判断是否材料出库
                        }

                        long iID, iIDDetail;
                        long iCode;
                        GetID("rd", out iID, out iIDDetail);
                        sSQL = "select isnull(max(cNumber),0) as Maxnumber From @u8.VoucherHistory  with (NOLOCK) Where  CardNumber='0411' and cContent='日期' and cSeed='" + dtm1.DateTime.ToString("yyMM") + "'";
                        DataTable dtCode = clsSQLCommond.ExecQuery(sSQL);
                        iCode = Convert.ToInt64(dtCode.Rows[0]["Maxnumber"]);

                        sSQL = "select sum(isnull(Qty,0.00)) as Qty, sum(isnull(QualifiedInQty,0.00)) as QualifiedInQty,sum(isnull(Qty,0.00))-sum(isnull(QualifiedInQty,0.00)) as iQty " +
                                "from  @u8.mom_orderdetail mD inner join @u8.mom_order m on m.MoId = md.MoId 	left join @u8.SO_SOMain s on s.cSOCode = mD.SOCode 	" +
                                        "left join @u8.SO_SODetails sD on s.cSOCode = sd.cSOCode and sd.iRowNo = md.SoSeq " +
                                "where MoCode = '" + txtWorkOrderNO.Text.Trim() + "' and InvCode = '" + txtcInvCode.Text.Trim() + "' ";
                        DataTable dtTemp = clsSQLCommond.ExecQuery(sSQL);
                        double dtemp1 = Convert.ToDouble(dtTemp.Rows[0]["iQty"]);
                        double dtemp2 = Convert.ToDouble(dtTemp.Rows[0]["Qty"]);

                        double dtemp3 = 0;
                        if (txtwdiQty.Text.Trim() != "")
                            dtemp3 = Convert.ToDouble(txtwdiQty.Text.Trim());
                        sSQL = "select isnull(fInExcess,0) as fInExcess from @u8.Inventory where cInvCode = '" + txtcInvCode.Text.Trim() + "' ";
                        DataTable dtExcess = clsSQLCommond.ExecQuery(sSQL);
                        double dtemp4 = 0;
                        if (dtExcess == null || dtExcess.Rows.Count < 1)
                            dtemp4 = 0;
                        else
                            dtemp4 = Convert.ToDouble(dtExcess.Rows[0]["fInExcess"]);

                        if (dtemp2 * (1 + dtemp4) < (dtemp3 + double.Parse(txtQtyNow.Text.Trim())))
                        {
                            MessageBox.Show("超订单，不能入库！");
                            return;
                        }

                        dtTemp = null;

                        sSQL = "select SOCode,define22,QualifiedInQty,MDeptCode,0.000000 as Qty,Qty as Qty2,Qty as Qty3,Status,md.SortSeq,sd.iRowNo,sd.AutoID,m.MoCode,s.cSOCode,isnull(s.cdefine11,'') as cdefine11,isnull(MoCode,'') as MoCode,md.modid,SortSeq,SoDId " +
                                "from  @u8.mom_orderdetail mD inner join @u8.mom_order m on m.MoId = md.MoId 	left join @u8.SO_SOMain s on s.cSOCode = mD.SOCode 	left join @u8.SO_SODetails sD on s.cSOCode = sd.cSOCode and sd.iRowNo = md.SoSeq " +
                                "where MoCode = '" + txtWorkOrderNO.Text.Trim() + "' and InvCode = '" + txtcInvCode.Text.Trim() + "' and Status  = 3  " +
                                "order by md.SortSeq";
                        dtTemp = clsSQLCommond.ExecQuery(sSQL);

                        double dQNowRow2 = double.Parse(txtQtyNow.Text.Trim());                             //本行需要入库数量


                        for (int i = 0; i < dtTemp.Rows.Count; i++)
                        {
                            if (dQNowRow2 > Convert.ToDouble(dtTemp.Rows[i]["qty2"]) - Convert.ToDouble(dtTemp.Rows[i]["QualifiedInQty"]) && i != dtTemp.Rows.Count - 1)
                            {
                                dtTemp.Rows[i]["qty"] = Convert.ToDouble(dtTemp.Rows[i]["qty2"]) - Convert.ToDouble(dtTemp.Rows[i]["QualifiedInQty"]);
                                dtTemp.Rows[i + 1]["qty"] = dQNowRow2 - Convert.ToDouble(dtTemp.Rows[i]["qty"]);
                                dQNowRow2 = dQNowRow2 - Convert.ToDouble(dtTemp.Rows[i]["qty"]);
                            }
                            else
                            {
                                dtTemp.Rows[i]["qty"] = dQNowRow2.ToString();
                                break;
                            }
                        }

                        for (int i = 0; i < dtTemp.Rows.Count; i++)
                        {
                            if (Convert.ToDouble(dtTemp.Rows[i]["qty"]) + Convert.ToDouble(dtTemp.Rows[i]["QualifiedInQty"]) >= Convert.ToDouble(dtTemp.Rows[i]["qty2"]))
                            {
                                sSQL = "update @u8.mom_orderdetail set Status = 4,CloseTime = '" + dtm1.DateTime.ToString("yyyy-MM-dd") + "',CloseUser = '" + FrameBaseFunction.ClsBaseDataInfo.sUid + "',OrgClsTime = '" + dtm1.DateTime + "',CloseDate = '" + dtm1.DateTime + "',OrgClsDate = '" + dtm1.DateTime + "' " +
                                        "where modid = " + dtTemp.Rows[i]["modid"];
                                aList.Add(sSQL);
                            }
                        }


                        long iVouNumber = 0;
                        for (int iRDIn = 0; iRDIn < dtTemp.Rows.Count; iRDIn++)
                        {
                            iID += 1;
                            iIDDetail += 1;
                            iCode += 1;

                            if (Convert.ToDouble(dtTemp.Rows[iRDIn]["qty"]) == 0)
                            {
                                break;
                            }

                            //单据号
                            sCode = sSetCode(iCode);

                            if (dtTemp.Rows[iRDIn]["Status"].ToString().Trim() != "3")
                            {
                                throw new Exception("请检查该订单状态是否是审核状态！");
                            }

                            string sSaleOrder = dtTemp.Rows[iRDIn]["cdefine11"].ToString().Trim();              //外销订单号
                            string sMoCode = dtTemp.Rows[iRDIn]["MoCode"].ToString().Trim();                    //生产订单号
                            string iMoDid = dtTemp.Rows[iRDIn]["modid"].ToString().Trim();                      //生产订单子表标识 
                            string sMoCodeRow = dtTemp.Rows[iRDIn]["SortSeq"].ToString().Trim();                //生产订单行号
                            string sSaOrder = dtTemp.Rows[iRDIn]["cSOCode"].ToString().Trim();                  //销售订单号
                            string sSaDID = dtTemp.Rows[iRDIn]["AutoID"].ToString().Trim();                     //销售订单子表ID
                            string sSaDRow = dtTemp.Rows[iRDIn]["iRowNo"].ToString().Trim();                    //销售订单行号
                            string sMDeptCode = dtTemp.Rows[iRDIn]["MDeptCode"].ToString().Trim();              //生产部门  
                            double dQty = Convert.ToDouble(dtTemp.Rows[iRDIn]["Qty"]);                          //生产订单数量
                            double dQualifiedInQty = Convert.ToDouble(dtTemp.Rows[iRDIn]["QualifiedInQty"]);    //生产订单已入库数量
                            double dQNowRow = dQty;                                                             //本行实际入库数量

                            sMODID = iMoDid;
                            if (sSaDRow.Trim() == string.Empty)
                            {
                                sSaDRow = "null";
                            }
                            //dtTemp = null;

                            sSQL = "insert into @u8.rdrecord10(id,brdflag,cvouchtype,cbustype,csource,cwhcode,ddate," +
                                        "ccode,crdcode,cdepcode,cmaker,vt_id,cdefine11,cmpocode,iswfcontrolled,dnmaketime,cpspcode) values " +                                               //,ipurorderid
                                    "(" + iID + ",1,N'10',N'成品入库',N'生产订单',N'" + sWHCode + "',N'" + dtm1.DateTime + "'" +
                                        ",N'" + sCode + "',N'104',N'" + sMDeptCode + "',N'" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',63,N'" + sSaleOrder + "',N'" + sMoCode + "',0, getdate(),'" + txtcInvCode.Text.Trim() + "')";
                            aList.Add(sSQL);

                            sSQL = "select top 1 iQuantity,iNquantity,(isnull(iNquantity,0)-isnull(iQuantity,0)) as iQty,* " +
                                "from @u8.rdrecords10 rs left join @u8.rdrecord10 r on r.id = rs.id " +
                                " where cmocode='" + txtWorkOrderNO.Text.Trim() + "' and cInvCode = '" + txtcInvCode.Text.Trim() + "' " +
                                "order by autoid desc";
                            DataTable dtTemp4 = clsSQLCommond.ExecQuery(sSQL);
                            string sNQty = "0";
                            if (dtTemp4.Rows.Count > 0)
                            {
                                sNQty = dtTemp4.Rows[0]["iQty"].ToString().Trim();
                                if (Convert.ToDouble(sNQty) < 0)
                                {
                                    //设置sNQty为0有待考证（负数会使单据变成红字）
                                    sNQty = "0";
                                }
                            }

                            sSQL = "Insert Into @u8.rdrecords10(autoid,id,cinvcode,iquantity," +
                                        "impoids,brelated,iordertype," +
                                        "bcosting,iordercode,corufts,cmocode," +
                                        "imoseq,isodid,isotype,csocode,isoseq,inquantity,cdefine24) " +
                                    "Values (" + iIDDetail + "," + iID + ",N'" + txtcInvCode.Text.Trim() + "'," + dQNowRow + "," +
                                        "" + iMoDid + ",0,1," +
                                        "1,N'" + sSaOrder + "',N'1653.4411',N'" + sMoCode + "'," +
                                        "" + sMoCodeRow + ",N'" + sSaDID + "',1,N'" + sSaOrder + "'," + sSaDRow + "," + sNQty + ",'" + txtworkProcedureNext.Text.Trim() + "')";
                            aList.Add(sSQL);

                            if (sSaOrder.Trim() != string.Empty)
                            {
                                sSQL = "update  @u8.rdrecords10 set iordercode='" + sSaOrder + "',iorderdid=" + sSaDID + ",iorderseq=" + sSaDRow + ",iordertype=1 where autoid = " + iIDDetail;
                                aList.Add(sSQL);
                            }

                            if (txtProcInvName.Text.Trim() != "")
                            {
                                sSQL = "update  @u8.rdrecords10 set cdefine23 = '" + lookUpEditProCode.Text.Trim() + "' where autoid = " + iIDDetail;
                                aList.Add(sSQL);
                            }


                            sSQL = "update @u8.mom_orderdetail  set QualifiedInQty = QualifiedInQty + " + dQNowRow + " where MoDId = " + iMoDid;
                            aList.Add(sSQL);

                            sSQL = "update  @u8.rdrecords10 set iNum = cast((iQuantity/mD.Qty*AuxQty) as decimal(18, 6)),cAssUnit=i.cAssComUnitCode ,iinvexchrate=cast((mD.Qty/AuxQty) as decimal(18, 6)),iExpiratDateCalcu=0,iNNum=cast((inQuantity/mD.Qty*AuxQty) as decimal(18, 6)) " +
                                    " from  @u8.mom_orderdetail mD inner join  @u8.Inventory I on md.invcode = i.cInvCode " +
                                    "where mD.MoDId = iMPoIds and  autoid = " + iIDDetail;
                            aList.Add(sSQL);

                            //--更新现存量
                            sSQL = "if exists(select * from  @u8.CurrentStock where cInvCode = '" + txtcInvCode.Text.Trim() + "' and cWhCode = '" + sWHCode + "') " +
                                   "	update  @u8.CurrentStock set iQuantity = isnull(iQuantity,0) + " + dQNowRow + "  where cInvCode = '" + txtcInvCode.Text.Trim() + "' and cWhCode = '" + sWHCode + "' " +
                                   "else " +
                                       "begin " +
                                           "declare @itemid varchar(20); " +
                                           "declare @iCount int;  " +
                                           "select @iCount=count(itemid) from @u8.CurrentStock where cInvCode = '" + txtcInvCode.Text.Trim() + "';   " +
                                           "if( @iCount > 0 ) " +
                                           "	select @itemid=itemid from @u8.CurrentStock where cInvCode = '" + txtcInvCode.Text.Trim() + "';  " +
                                           "else  " +
                                           "	 select @itemid=max(itemid+1) from @u8.CurrentStock  " +
                                           "    insert into @u8.CurrentStock(cWhCode,cInvCode,iQuantity,itemid)values('" + sWHCode + "','" + txtcInvCode.Text.Trim() + "'," + dQNowRow + ",@itemid) " +
                                       "end";
                            aList.Add(sSQL);

                            sSQL = "update UFSystem..UA_Identity set iFatherID = " + iID + ",iChildID=" + iIDDetail + "  where cAcc_Id = '200' and cVouchType = 'rd'";
                            aList.Add(sSQL);
                            //更新最大单据号
                            if (iCode == 1)
                            {
                                sSQL = "insert into @u8.VoucherHistory(cardnumber,ccontent,ccontentrule,cseed,cnumber,bempty)values('0411','日期','月','" + dtm1.DateTime.ToString("yyMM") + "','1',0)";
                            }
                            else
                            {
                                sSQL = "update @u8.VoucherHistory set cNumber = '" + iCode.ToString().Trim() + "' Where  CardNumber='0411' and cContent='日期' and cSeed='" + dtm1.DateTime.ToString("yyMM") + "'  ";
                            }
                            aList.Add(sSQL);
                            //}
                            sMsg = sMsg + "\n产成品入库单保存成功 ‘" + sCode + "’";

                            sSQL = "select BaseQtyN,BaseQtyD, isnull(BaseQtyN,0)/isnull(BaseQtyD,0) as BaseQtyInfo,InvCode,WIPType as iSupplyType  " +
                                           "from @u8.mom_moallocate m left join @u8.Inventory I on I.cInvcode = m.InvCode " +
                                           "where MoDId = " + sMODID + "";
                            DataTable dtTemp2 = clsSQLCommond.ExecQuery(sSQL);

                            if (dtTemp2.Rows.Count < 1)
                            {
                                throw new Exception("获得子件信息失败！");
                            }


                            bool bRDOut = false;                //判断是否需要制作材料出库单
                            for (int j = 0; j < dtTemp2.Rows.Count; j++)
                            {
                                if (dtTemp2.Rows[j]["iSupplyType"].ToString().Trim() == "1")
                                {
                                    sSQL = "SELECT  W.cWhCode, W.cWhName, I.cInvCode,sum(iQuantity) AS iQtty " +
                                                  "FROM @u8.v_CurrentStock CS inner join @u8.Inventory I ON I.cInvCode = CS.cInvCode    " +
                                                  "	 LEFT OUTER JOIN @u8.Warehouse W ON CS.cWhCode = W.cWhCode  " +
                                                  "WHERE  1=1  AND 1=1   And (I.cInvCode = N'" + dtTemp2.Rows[j]["InvCode"].ToString().Trim() + "')  and w.cWhCode = '0F' " +
                                                  "group by w.cWhCode, W.cWhName, I.cInvCode";
                                    DataTable dtTemp3 = clsSQLCommond.ExecQuery(sSQL);
                                    if (dtTemp3.Rows.Count < 1)
                                    {
                                        throw new Exception("产品“" + txtcInvCode.Text.Trim() + "”的子件“" + dtTemp2.Rows[j]["InvCode"] + "”现存量不足，不能入库！");
                                    }

                                    double d2 = Convert.ToDouble(dtTemp3.Rows[0]["iQtty"]);     //仓库现存量
                                    double d1 = Convert.ToDouble(txtQtyNow.Text.Trim()) * Convert.ToDouble(dtTemp2.Rows[j]["BaseQtyInfo"]);
                                    if (d2 < d1)
                                    {
                                        throw new Exception("产品“" + txtcInvCode.Text.Trim() + "”的子件“" + dtTemp2.Rows[j]["InvCode"] + "”现存量不足，不能入库！");
                                    }
                                    bRDOut = true;
                                }
                            }

                            //生成材料出库单
                            long iRDID;
                            long iRDIDDetail;
                            if (bRDOut)
                            {
                                //子件存在入库倒冲，添加材料出库单表头信息
                                //更新最大单据号
                                //更新ID表
                                //更新现存量表
                                //------------//------------//------------//------------//------------

                                string sVouNumber = "";
                                string sVouNumber2 = "";
                                if (iRDIn == 0)
                                {
                                    sSQL = "select isnull(max(cNumber),0) as Maxnumber From @u8.VoucherHistory  with (NOLOCK) Where  CardNumber='0412'  and cSeed = '" + dtm1.DateTime.ToString("yyMM") + "'";
                                    dt = clsSQLCommond.ExecQuery(sSQL);
                                    iVouNumber = Convert.ToInt64(dt.Rows[0]["Maxnumber"]);
                                    iVouNumber += 1;
                                }
                                else
                                {
                                    iVouNumber += 1;
                                }

                                sVouNumber = iVouNumber.ToString().Trim();
                                sVouNumber2 = iVouNumber.ToString().Trim();
                                for (int i = 0; i < 10; i++)
                                {
                                    if (sVouNumber.Length < 4)
                                    {
                                        sVouNumber = "0" + sVouNumber;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                sVouNumber = "OP" + dtm1.DateTime.ToString("yyMM") + sVouNumber;


                                iRDID = iID + 1;
                                iID = iID + 1;
                                iRDIDDetail = iIDDetail + 1;
                                iIDDetail = iIDDetail + 1;


                                //sSQL = "select mod.BaseQtyN/mod.BaseQtyD/(1-mod.ParentScrap)*(1+CompScrap) as useQty,mod.* from @u8.mom_order m inner join @u8.mom_orderdetail mo on m.MoId = mo.MoId inner join @u8.mom_moallocate mod on mod.MoDId = mo.modid " +
                                //       "where  mo.modid = " + iMoDid;
                                sSQL = "select mod.qty/mo.qty as useQty,mod.* from @u8.mom_order m inner join @u8.mom_orderdetail mo on m.MoId = mo.MoId inner join @u8.mom_moallocate mod on mod.MoDId = mo.modid " +
                                       "where  mo.modid = " + iMoDid;
                                DataTable dtMOTemp = clsSQLCommond.ExecQuery(sSQL);

                                //更新最大单据号

                                if (iVouNumber == 1)
                                    sSQL = "insert into @u8.VoucherHistory(cardnumber,ccontent,ccontentrule,cseed,cnumber,bempty)values('0412','日期','月','" + dtm1.DateTime.ToString("yyMM") + "','1',0)";
                                else
                                    sSQL = "update @u8.VoucherHistory set cNumber = '" + sVouNumber2.ToString().Trim() + "' Where  CardNumber='0412' and cSeed='" + dtm1.DateTime.ToString("yyMM") + "'  ";
                                aList.Add(sSQL);

                                sSQL = "insert into @u8.rdrecord10(id,brdflag,cvouchtype,cbustype,csource,cbuscode,cwhcode,ddate," +
                                            "ccode,crdcode,cdepcode,cmaker,vt_id,bisstqc,cpspcode,cmpocode," +
                                            "biscomplement,iswfcontrolled,dnmaketime,dnmodifytime,dnverifytime,bmotran) " +
                                            "values (" + iRDID + ",0,N'11',N'生产倒冲',N'产成品入库单',N'" + sCode + "',N'0F',N'" + dtm1.DateTime + "'," +
                                            "N'" + sVouNumber + "',N'201',N'" + sMDeptCode + "',N'" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',65,0,N'" + txtcInvCode.Text.Trim() + "',N'" + txtWorkOrderNO.Text.Trim() + "'," +
                                            "0,0, getdate(), Null , Null ,N'')";
                                aList.Add(sSQL);
                                for (int i = 0; i < dtMOTemp.Rows.Count; i++)
                                {
                                    iRDIDDetail += 1;
                                    iIDDetail = iIDDetail + 1;

                                    double d1 = Convert.ToDouble(dtMOTemp.Rows[i]["useQty"]);
                                    double d2 = dQNowRow;
                                    double d3 = d2 * d1;
                                    string d4 = "null";
                                    string sRate = dtMOTemp.Rows[i]["ChangeRate"].ToString().Trim();

                                    if (dtMOTemp.Rows[i]["ChangeRate"].ToString().Trim() != string.Empty)
                                    {
                                        d4 = (d3 / Convert.ToDouble(dtMOTemp.Rows[i]["ChangeRate"])).ToString();
                                    }
                                    else
                                    {
                                        sRate = "null";
                                    }

                                    sSQL = "Insert Into @u8.rdrecords10(autoid,id,cinvcode,inum,iquantity," +
                                                "cassunit,impoids,bcosting,bvmiused,iinvexchrate," +
                                                "corufts,cmocode,invcode,imoseq,iopseq," +
                                                "iexpiratdatecalcu,isotype) " +
                                           "Values (" + iRDIDDetail + "," + iRDID + ",N'" + dtMOTemp.Rows[i]["InvCode"].ToString().Trim() + "'," + d4 + "," + d3 + "," +
                                                "N'" + dtMOTemp.Rows[i]["AuxUnitCode"].ToString().Trim() + "'," + dtMOTemp.Rows[i]["AllocateId"].ToString().Trim() + ",1,0," + sRate + "," +
                                                "N'2969.6763',N'" + txtWorkOrderNO.Text.Trim() + "',N'" + txtcInvCode.Text.Trim() + "'," + sMoCodeRow + ",N'" + dtMOTemp.Rows[i]["OpSeq"].ToString().Trim() + "'," +
                                                "0,0)";
                                    aList.Add(sSQL);


                                    //--更新现存量
                                    sSQL = "if exists(select * from  @u8.CurrentStock where cInvCode = '" + dtMOTemp.Rows[i]["InvCode"].ToString().Trim() + "' and cWhCode = '0F') " +
                                           "	update  @u8.CurrentStock set iQuantity = isnull(iQuantity,0) + " + d3 + ",iNum = isnull(iNum,0) + " + d4 + "  where cInvCode = '" + dtMOTemp.Rows[i]["InvCode"].ToString().Trim() + "' and cWhCode = '0F' " +
                                                   "else " +
                                                       "begin " +
                                                       "    declare @itemid varchar(20); " +
                                                     "declare @iCount int;  " +
                                                       "select @iCount=count(itemid) from @u8.CurrentStock where cInvCode = '" + dtMOTemp.Rows[i]["InvCode"].ToString().Trim() + "';   " +
                                                       "if( @iCount > 0 ) " +
                                                       "	select @itemid=itemid from @u8.CurrentStock where cInvCode = '" + dtMOTemp.Rows[i]["InvCode"].ToString().Trim() + "';  " +
                                                       "else  " +
                                                       "	 select @itemid=max(itemid+1) from @u8.CurrentStock  " +
                                                       "    insert into @u8.CurrentStock(cWhCode,cInvCode,iQuantity,iNum,itemid)values('0F','" + dtMOTemp.Rows[i]["InvCode"].ToString().Trim() + "'," + d3 + "," + d4 + ",@itemid) " +
                                                       "end";
                                    aList.Add(sSQL);

                                    //更新生产订单子件用量
                                    sSQL = "update @u8.mom_moallocate set IssQty = IssQty + " + d3 + " where AllocateId = " + dtMOTemp.Rows[i]["AllocateId"].ToString().Trim();
                                    aList.Add(sSQL);
                                }

                                sSQL = "update UFSystem..UA_Identity set iFatherID=" + iRDID + ",iChildID=" + iRDIDDetail + " where  cAcc_Id = '200' and cVouchType = 'rd'";
                                aList.Add(sSQL);


                                sMsg = sMsg + "\n材料出库单保存成功 ‘" + sVouNumber + "’";
                            }
                        }
                    }
                }

            }

            clsSQLCommond.ExecSqlTran(aList);
            SetTxt();
            txtBarCode.Text = string.Empty;

            MessageBox.Show(sMsg);
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

            return "CP" + dtm1.DateTime.ToString("yyMM") + sCode;
        }

        /// <summary>
        /// 获得单据ID
        /// </summary>
        /// <param name="sType">单据类型</param>
        private void GetID(string sType, out long iID, out long iIDDetail)
        {
            string sSQL = "select iFatherID,iChildID from UFSystem..UA_Identity where cAcc_Id = '200' and cVouchType = '" + sType + "'";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            if (dt == null || dt.Rows.Count < 1)
            {
                iID = 0;
                iIDDetail = 0;
            }
            else
            {
                iID = Convert.ToInt64(dt.Rows[0]["iFatherID"]);
                iIDDetail = Convert.ToInt64(dt.Rows[0]["iChildID"]);
            }
        }

        private void txtBarCode_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (txtBarCode.Text.Trim() == string.Empty)
                {
                    return;
                }

                SetTxt();

               
                if (e.KeyCode == Keys.Enter)
                {
                    string sSQL = "select w.cinvcode2,isnull(w.dtmPlan,'1900-1-1') as dtmPlan,isnull(w.bRDIn,0) as bRDIn,w.vchrPer,w.vchrEquipment,w.GUID ,w.AutoID,WorkOrderID,WorkOrderNO,WorkOrderRowNO,w.cInvCode,i.cInvName,i.cInvStd,w.workDepmentNext,isnull(w.iQuantity,0) as iQuantity,workProcedure,wp.fName as workProcedureName,workProcedureNext,wp2.fName as workProcedureNextName,w.workDepment,wDep.fName, 	sum(isnull(wd.iQuantity,0)) as wdiQty  " +
                                     "from UFDLImport..WorkPlan w left join UFDLImport..WorkPlanDetail wd on w.Guid = wd.GuidHead left join @u8.Inventory i on i.cInvcode = w.cInvCode left join UFDLImport..WorkDepment wDep on wDep.FCode = w.workDepment 	left join UFDLImport..WorkingProcedure wp on wp.fCode = w.workProcedure left join UFDLImport..WorkingProcedure wp2 on wp2.fCode = w.workProcedureNext  " +
                                     "where 1=1 and w.autoid = " + txtBarCode.Text.Trim() + " and w.AccID='200' and w.AccYear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' and isnull(w.bClose,0) = 0 and isnull(w.bRDIn,0) = 0 " +
                                     "group by w.cinvcode2,w.dtmPlan,w.GUID ,w.bRDIn,w.AutoID,WorkOrderID,WorkOrderNO,WorkOrderRowNO,w.cInvCode,i.cInvName,i.cInvStd,w.workDepmentNext,w.iQuantity,workProcedure,wp.fName,workProcedureNext,wp2.fName,w.workDepment,wDep.fName,w.vchrPer,w.vchrEquipment";
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                     
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("该条码不存在，或不是工序报表条码！");
                        return;
                    }

                    if (dt.Rows.Count == 1)
                    {
                        if (Convert.ToInt32(dt.Rows[0]["bRDIn"]) == 1 || Convert.ToInt32(dt.Rows[0]["bRDIn"]) == 2)
                        {
                            txtRDIn.Text = "是";
                        }
                        else
                        {
                            txtRDIn.Text = "否";
                        }
                        txtGuid.Text = dt.Rows[0]["GUID"].ToString().Trim();
                        txtcInvCode.Text = dt.Rows[0]["cInvCode"].ToString().Trim();
                        txtcInvName.Text = dt.Rows[0]["cInvName"].ToString().Trim();
                        txtcInvStd.Text = dt.Rows[0]["cInvStd"].ToString().Trim();
                        //txtfName.Text = dt.Rows[0]["fName"].ToString().Trim();
                        txtiQuantity.Text = dt.Rows[0]["iQuantity"].ToString().Trim();
                        txtwdiQty.Text = dt.Rows[0]["wdiQty"].ToString().Trim();
                        txtworkDepment.Text = dt.Rows[0]["workDepment"].ToString().Trim();
                        txtworkDepment2.Text = dt.Rows[0]["workDepmentNext"].ToString().Trim();
                        txtWorkOrderNO.Text = dt.Rows[0]["WorkOrderNO"].ToString().Trim();
                        txtworkProcedure.Text = dt.Rows[0]["workProcedure"].ToString().Trim();
                        txtworkProcedureNext.Text = dt.Rows[0]["workProcedureNext"].ToString().Trim();
                        //lookUpPer.EditValue = dt.Rows[0]["vchrPer"].ToString().Trim();
                        txtPer.Text = dt.Rows[0]["vchrPer"].ToString().Trim();
                        lookUpEquipment.EditValue = dt.Rows[0]["vchrEquipment"].ToString().Trim();
                        //dtm1.Text = Convert.ToDateTime( dt.Rows[0]["dtmPlan"]).ToString("yyyy-MM-dd");
                        dtm1.Text = FrameBaseFunction.ClsBaseDataInfo.sLogDate;
                      
                        //txtWorkOrderRowNO.Text = dt.Rows[0]["WorkOrderRowNO"].ToString().Trim();
                        //txtworkProcedureNextName.Text = dt.Rows[0]["workProcedureNextName"].ToString().Trim();
                        //txtworkProcedureName.Text = dt.Rows[0]["workProcedureName"].ToString().Trim();
                        //lookUpDep2.EditValue = dt.Rows[0]["workDepmentNext"].ToString().Trim();
                    }

                    sSQL = "select sum(isnull(wdd.iQuantity,0)) as iQuantity from UFDLImport..WorkPlan w left join UFDLImport..WorkPlanDetail wd on w.guid = wd.guidhead  " +
                                "	left join UFDLImport..WorkPlanDetailDefective wdd on wd.guid = wdd.guidhead " +
                                "where 1=1 and w.autoid = " + txtBarCode.Text.Trim() + " and AccID='200' and AccYear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' and isnull(w.bClose,0) = 0  ";
                    DataTable dt2 = clsSQLCommond.ExecQuery(sSQL);
                    if (dt2.Rows.Count > 0)
                    {
                        txtwddiQty.Text = dt2.Rows[0]["iQuantity"].ToString().Trim();
                        txtQtyIng.Text = (Convert.ToInt64(dt.Rows[0]["iQuantity"]) - Convert.ToInt64(dt.Rows[0]["wdiQty"]) - Convert.ToInt64(dt2.Rows[0]["iQuantity"])).ToString().Trim();
                        txtQtyNow.Text = txtQtyIng.Text;
                    }

                    sSQL = "select (sum(isnull(Qty,0))-sum(isnull(QualifiedInQty,0))) as QualifiedInQty,InvCode,sum(Qty) as Qty,max(SoCode) as SoCode " +
                            "from @u8.mom_order m left join @u8.mom_orderdetail md on m.moid = md.moid " +
                            "where mocode = '" + txtWorkOrderNO.Text.Trim() + "' and (InvCode = '" + dt.Rows[0]["cinvcode2"].ToString().Trim() + "' or invCode = '" + dt.Rows[0]["cinvcode"].ToString().Trim() + "') " +
                            "group by InvCode";
                    dt2 = clsSQLCommond.ExecQuery(sSQL);
                    if (dt2.Rows.Count > 0)
                    {
                        txtWorkQtyY.Text = dt2.Rows[0]["QualifiedInQty"].ToString().Trim();
                        txtSoCode.Text = dt2.Rows[0]["SoCode"].ToString().Trim();
                    }

                    txtQtyNow.Focus();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("条码输入失败！ \n\n原因:\n  " + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetTxt()
        {
            //txtBarCode.Text = "";
            txtGuid.Text = "";
            txtGuid.Text = "";
            txtcInvCode.Text = "";
            txtcInvName.Text = "";
            txtcInvStd.Text = "";
            //txtfName.Text = "";
            txtiQuantity.Text = "";
            txtwdiQty.Text = "";
            txtworkDepment.Text = "";
            txtworkDepment2.Text = "";
            txtWorkOrderNO.Text = "";
            txtworkProcedure.Text = "";
            txtworkProcedureNext.Text = "";
            txtwddiQty.Text = "";
            txtQtyIng.Text = "";
            txtQtyNow.Text = "";
            txtTime.Text = "0";
            txtRDIn.Text = "";
            lookUpEditProCode.EditValue = null;
            txtProcInvName.Text = "";

            txtPer.Text = "";
            lookUpEquipment.EditValue = null;
            txtSoCode.Text = "";
            txtWorkQtyY.Text = "";

            GetGrid();
        }


        private void txtcInvCode_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                GetProCode();
            }
            catch
            { }
        }

        private void gridView2_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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
    }
}