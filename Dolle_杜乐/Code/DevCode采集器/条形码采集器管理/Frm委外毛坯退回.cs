using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace BarCode
{
    public partial class Frm委外毛坯退回 : FrmBase
    {
        DataTable dtTable;
        Cls到货 cls到货 = new Cls到货();

        public Frm委外毛坯退回()
        {
            InitializeComponent();

            dtTable = new DataTable();

            DataColumn dc = new DataColumn();
            dc.ColumnName = "序号";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "订单号";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "物料编码";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "物料名称";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "物料规格";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "本次入库数量";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "本次入库件数";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "仓库编码";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "仓库";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "计量单位";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "辅计量单位";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "订单数量";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "订单件数";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "应收应发数量";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "应收应发件数";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "供应商编码";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "供应商";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "部门编码";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "部门";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "入库超额上限";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "供应类型";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "条形码";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "制单人";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "bUsed";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "子件用料表ID";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "委外订单子表ID";
            dtTable.Columns.Add(dc);
             
            dataGrid1.DataSource = dtTable;
        }

        DataTable dt = new DataTable();

        private void Frm委外毛坯退回_Load(object sender, EventArgs e)
        {
            dateTime单据日期.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void txt条形码_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13)
                {
                    string[] s = txt条形码.Text.Trim().Split('$');
                    if (s[0].Trim() != "4")
                    {
                        txt条形码.Text = "";
                        msgBox.textBox1.Text = "条形码类型错误";
                        msgBox.ShowDialog();
                        return;
                    };
                    if (s[1].Trim() != MobileBaseDLL.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3))
                    {
                        txt条形码.Text = "";
                        msgBox.textBox1.Text = "帐套错误";
                        msgBox.ShowDialog();
                        return;
                    }

                    string sSQL = "select  p.cCode as 订单号,I.cInvCode as 物料编码,i.cInvName as 物料名称,i.cInvStd as 物料规格,cast(" + s[3] + " as decimal(18,6)) as 本次入库数量,cast(" + s[4] + " as decimal(18,6)) as 本次入库件数 " +
	                                ", '0A' as 仓库编码 , '不良品仓库' as 仓库,p.cDepCode as 部门编码,d.cDepName as 部门, p.cVenCode as 供应商编码,v.cVenName as 供应商,p.dDate as 单据日期 " +
	                                ", pd.iUnitPrice ,PD.moid as 单据ID,OD.MOMaterialsID as 子件用料表ID ,isnull(i.fInExcess ,0) as 入库超额上限 " +
	                                ",i.cAssComUnitCode ,i.cComUnitCode ,c1.cComUnitName as cComUnitName1 ,c2.cComUnitName as cComUnitName2  " +
	                                "  ,OD.iQuantity as iQuantity ,OD.iNum as iNum,pd.iQuantity as 订单数量,pd.iNum as 订单件数   " +
	                                " ,'' as iArrQty1 , '' as iArrNum1 " +
                                    ",OD.MOMaterialsID,OD.iSendQty - ((ISNULL(PD.iReceivedQTY ,0) +ISNULL (PD.iArrQTY,0))*(OD.fBaseQtyN / OD.fBaseQtyD ))  as RemainQty,-1 as bUsed " +
                                    ",pd.MODetailsID as 委外订单子表ID,OD.MOMaterialsID as iOMoMID,'' as bChoose, null as iWIPtype ,'" + txt条形码.Text.Trim() + "' as 条形码 " +
                               "from      @u8.OM_MOMaterials OD " +
                                       "left join @u8.OM_MODetails PD on OD.[MoDetailsID]=PD.[MoDetailsID]  " +
                                       "left join @u8.OM_MOMain p on pd.MOID = p.MOID " +
                                       "left join @u8.Inventory i on i.cInvCode = OD.cInvCode " +
                                       "left join @u8.ComputationUnit c1 on c1.cComunitCode = i.cComUnitCode " +
                                       "left join @u8.ComputationUnit c2 on c2.cComunitCode = i.cAssComUnitCode " +
                                       "left join @u8.Department d on d.cDepCode = p.cDepCode  " +
                                       "left join @u8.Vendor v on v.cVenCode = p.cVenCode " +
                                "where     OD.MOMaterialsID = " + s[2];
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL); 
                    if (dt == null || dt.Rows.Count < 1)
                    {
                        throw new Exception("条码扫描失败"); 
                    }
                    
                    string s条形码 = dt.Rows[0]["条形码"].ToString().Trim();
                    for (int i = 0; i < dtTable.Rows.Count; i++)
                    {
                        string s条形码2 = dtTable.Rows[i]["条形码"].ToString().Trim();
                        if (s条形码 == s条形码2)
                        {
                            throw new Exception("该条码已扫");
                        }
                    }

                    DataRow dr = dtTable.NewRow();
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        for (int j = 0; j < dtTable.Columns.Count; j++)
                        {
                            if (dt.Columns[i].ColumnName.ToString().ToLower().Trim() == dtTable.Columns[j].ColumnName.ToString().ToLower().Trim())
                            {
                                dr[dt.Columns[i].ColumnName] = dt.Rows[0][i];
                                break;
                            }
                        }
                    }

                    //毛坯退回进入不良品库，没有库位

                    dr["制单人"] = MobileBaseDLL.ClsBaseDataInfo.sUserName;
                    dr["序号"] = dtTable.Rows.Count + 1;
                    dtTable.Rows.Add(dr);

                    dataGrid1.DataSource = dtTable;                    

                    txt条形码.Text = "";
                    txt条形码.Focus();
                }
            }
            catch (Exception ee)
            {
                txt条形码.Text = "";

                msgBox.textBox1.Text = "扫描条码失败:" + ee.Message;
                msgBox.ShowDialog();
                txt条形码.Focus();
            }
        }

        private DataTable GetArrInfo(string sBarCode)
        {
            return cls到货.GetBarArrInfo(sBarCode);
        }

        private void txt条数_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13)
                {
                    if (txt条数.Text.Trim() == "")
                        return;

                    int iR = MobileBaseDLL.ClsBaseDataInfo.ReturnInt(txt条数.Text.Trim());
                    if (iR <= 0)
                    {
                        throw new Exception("条数必须大于0");
                    }
                    txt条形码.Focus();
                }
            }
            catch (Exception ee)
            {
                txt条数.Text = "";

                msgBox.textBox1.Text = ee.Message;
                msgBox.ShowDialog();
            }
        }

        private void txt货位_KeyUp(object sender, KeyEventArgs e)
        {
            //try
            //{
            //    if (e.KeyValue == 13)
            //    {
            //        if (txt货位.Text.Trim() == "")
            //        {
            //            return;
            //        }
                  
            //        string s货位 = clsDES.Decrypt(txt货位.Text.Trim());

            //        DataTable dt货位 = cls到货.Chk货位(s货位);
            //        if (dt货位 == null || dt货位.Rows.Count < 1)
            //        {
            //            throw new Exception("货位信息失败");
            //        }
            //        if (dt货位.Rows[0]["返回信息"].ToString().Trim() != "")
            //        {
            //            throw new Exception(dt货位.Rows[0]["返回信息"].ToString().Trim());

            //        }

            //        txt条形码.Focus();
            //    }
            //}
            //catch (Exception ee)
            //{
            //    txt货位.Text = "";
            //    msgBox.textBox1.Text = "货位错误:" + ee.Message;
            //    msgBox.ShowDialog();
            //}
        }

        private void btn删行_Click(object sender, EventArgs e)
        {
            for (int i = dtTable.Rows.Count - 1; i >= 0; i--)
            {
                if (dataGrid1.IsSelected(i))
                    dtTable.Rows.RemoveAt(i);
            }
        }

        /// <summary>
        /// 获得单据ID
        /// </summary>
        /// <param name="sType">单据类型  PuArrival，</param>
        private void GetID(string sType, out long iID, out long iIDDetail)
        {
            string sSQL = @"
declare @p5 int
set @p5=1000589146
declare @p6 int
set @p6=1003092055
exec @u8.sp_GetId N'',N'200',N'aaaaaaaa',1,@p5 output,@p6 output,default
select @p5, @p6
";
            sSQL = sSQL.Replace("aaaaaaaa", sType);
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

            return "OP" + DateTime.Parse(dateTime单据日期.Value.ToString("yyyy-MM-dd")).ToString("yyMM") + sCode;
        }

        private void btn保存_Click(object sender, EventArgs e)
        {
            try
            {
                dtTable.TableName = "到货";
                int i1 = dtTable.Rows.Count;
                int i2 = MobileBaseDLL.ClsBaseDataInfo.ReturnInt(txt条数.Text.Trim());
                if (i1 != i2)
                {
                    throw new Exception("条形码数量不一致");
                }
                if (dtTable == null || dtTable.Rows.Count < 1)
                {
                    throw new Exception("请先扫条形码");
                }

                decimal d本次累计 = 0;
                for (int i = 0; i < dtTable.Rows.Count; i++)
                {
                    dtTable.Rows[i]["bUsed"] = -1;

                    d本次累计 = d本次累计 + MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[i]["本次入库数量"]);
                }

                DialogResult d = MessageBox.Show("本次入库数量：" + d本次累计.ToString(), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                if (d != DialogResult.Yes)
                    return;

                string sInfo = "";
                string sErr = "";

                ArrayList aList = new ArrayList();

                //委外退货单,单据号
                long iIDBack = 0;
                long iIDBackDetail = 0;
                GetID("rd", out iIDBack, out iIDBackDetail);
                string sSQL = "select isnull(max(cNumber),0) as Maxnumber From @u8.VoucherHistory  with (NOLOCK) Where  CardNumber='0412' and (cContent='日期' or cContent='单据日期') and (cSeed='" + DateTime.Parse(dateTime单据日期.Value.ToString("yyyy-MM-dd")).ToString("yyyyMM") + "' or cSeed='" + DateTime.Parse(dateTime单据日期.Value.ToString("yyyy-MM-dd")).ToString("yyMM") + "')";
                DataTable dtCodeBack = clsSQLCommond.ExecQuery(sSQL);
                long iCodeBack = Convert.ToInt64(dtCodeBack.Rows[0]["Maxnumber"]);
                dtCodeBack = null;

                #region 红字材料出库单
                for (int i = 0; i < dtTable.Rows.Count; i++)
                {
                    if (dtTable.Rows[i]["bUsed"].ToString().Trim() == "-1")
                    {
                        iCodeBack += 1;
                        string sRDCode = sSetOutCode(iCodeBack);

                        iIDBack += 1;
                        //表头
                        sSQL = "insert into @u8.rdrecord11(id,brdflag,cvouchtype,cbustype,csource,cwhcode,ddate,ccode,crdcode,cdepcode," +
                                    "cptcode,cvencode,cmaker,cdefine7,bpufirst,vt_id,bisstqc,ipurorderid,iexchrate,cexch_name," +
                                    "bomfirst,idiscounttaxtype,iswfcontrolled,dnmaketime,dnmodifytime,dnverifytime)" +
                                "values (" + iIDBack + ",0,N'11',N'委外发料',N'库存',N'" + dtTable.Rows[i]["仓库编码"].ToString().Trim() + "','" + dateTime单据日期.Value.ToString("yyyy-MM-dd") + "',N'" + sRDCode + "',N'211',N'" + dtTable.Rows[i]["部门编码"].ToString().Trim() + "'," +
                                    "N'02',N'" + dtTable.Rows[i]["供应商编码"].ToString().Trim() + "',N'" + MobileBaseDLL.ClsBaseDataInfo.sUserName + "',0,0,65,0," + "null" + ",1,N'人民币'," +
                                    "0,N'0',0,getdate(), Null , Null )";
                        aList.Add(sSQL);


                        sInfo = sInfo + sRDCode + ";";

                        //表体 

                      

                        string s1 = "null";
                        if (dtTable.Rows[i]["本次入库件数"].ToString().Trim() != string.Empty)
                            s1 = dtTable.Rows[i]["本次入库件数"].ToString().Trim();

                        string s2 = "null";
                        if (dtTable.Rows[i]["本次入库数量"].ToString().Trim() != string.Empty)
                            s2 = dtTable.Rows[i]["本次入库数量"].ToString().Trim();

                        decimal d订单数量 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[i]["订单数量"]);
                        if (MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[i]["本次入库数量"]) > d订单数量)
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "超出订单数量\r\n";
                        }

                        sSQL = @"select top 1 D.cInvCode  from  @u8.OM_MOMaterials M
                                left join @u8.OM_MODetails D on M.MoDetailsID = D.MODetailsID 
                                where m.MOMaterialsID ={0}";
                        sSQL = string.Format(sSQL, dtTable.Rows[i]["子件用料表ID"].ToString());
                        DataTable dtInv = clsSQLCommond.ExecQuery(sSQL);
                        string pInvCode = dtInv.Rows[0]["cInvCode"].ToString();


                        iIDBackDetail += 1;
                        sSQL = "Insert Into @u8.rdrecords11(autoid,id,cinvcode,inum,iquantity," +
                                    "isquantity,isnum,cdefine26,cdefine27,inquantity,innum," +
                                    "iprocesscost,iprocessfee,iomodid,iOMoMID," +
                                    "bcosting,iinvexchrate,corufts,iexpiratdatecalcu,isotype,comcode,invcode  ) " +
                                "Values (" + iIDBackDetail + "," + iIDBack + ",N'" + dtTable.Rows[i]["物料编码"].ToString().Trim() + "',0-" + s1 + ",0-" + s2 +
                                    ",0,0,0,0," + "0" + "," + "0" +
                                    ",0,0," + dtTable.Rows[i]["委外订单子表ID"].ToString().Trim() + "," + dtTable.Rows[i]["子件用料表ID"].ToString().Trim() + "," +
                                    "1,0,N'1610.3418',0,0,'" + dtTable.Rows[i]["订单号"].ToString().Trim() + "','" + pInvCode + "')";
                        aList.Add(sSQL);

                        sSQL = "update @u8.rdrecords11 set cAssUnit = i.cAssComUnitCode from @u8.inventory i where i.cinvcode = @u8.rdrecords11.cinvcode and @u8.rdrecords11.autoid = " + iIDBackDetail;
                        aList.Add(sSQL);

                        sSQL = "select D.* from @u8.OM_MODetails D left join  @u8.OM_MOMaterials  OD on D.MoDetailsID =OD.MoDetailsID    where OD.MOMaterialsID  = " + dtTable.Rows[i]["子件用料表ID"].ToString().Trim();
                        DataTable dtPodetails = clsSQLCommond.ExecQuery(sSQL);
                        if (dtPodetails.Rows[0]["citemName"].ToString().Trim() != string.Empty)
                        {
                            sSQL = "update @u8.rdrecords11 set citem_class='" + dtPodetails.Rows[0]["citem_class"] + "',citemcode='" + dtPodetails.Rows[0]["citemName"] + "',cname='" + dtPodetails.Rows[0]["citemName"] + "',citemcname='外销订单项目' " +
                                   " where autoid = " + iIDBackDetail;
                            aList.Add(sSQL);
                        }

                        sSQL = "update @u8.OM_MOMaterials set iSendQTY =iSendQTY-" + s2 + ",iSendNum =iSendNum-" + s1 + " where MOMaterialsID = " + dtTable.Rows[i]["子件用料表ID"].ToString().Trim();
                        aList.Add(sSQL);


                        //////现存量

                        if (s1 == "null")
                        {
                            sSQL = "if exists(select * from  @u8.CurrentStock where cInvCode = '" + dtTable.Rows[i]["物料编码"].ToString().Trim() + "' and cWhCode = '" + dtTable.Rows[i]["仓库编码"].ToString().Trim() + "') " +
                          "	update  @u8.CurrentStock set iQuantity = isnull(iQuantity,0) + " + s2 + "  where cInvCode = '" + dtTable.Rows[i]["物料编码"].ToString().Trim() + "' and cWhCode = '" + dtTable.Rows[i]["仓库编码"].ToString().Trim() + "' " +
                                  "else " +
                                      "begin " +
                                      "    declare @itemid varchar(20); " +
                                      "declare @iCount int;  " +
                                        "select @iCount=count(itemid) from @u8.CurrentStock where cInvCode = '" + dtTable.Rows[i]["物料编码"].ToString().Trim() + "';   " +
                                        "if( @iCount > 0 ) " +
                                        "	select @itemid=itemid from @u8.CurrentStock where cInvCode = '" + dtTable.Rows[i]["物料编码"].ToString().Trim() + "';  " +
                                        "else  " +
                                        "	 select @itemid=max(itemid+1) from @u8.CurrentStock  " +
                                      "    insert into @u8.CurrentStock(cWhCode,cInvCode,iQuantity,itemid)values('" + dtTable.Rows[i]["仓库编码"].ToString().Trim() + "','" + dtTable.Rows[i]["物料编码"].ToString().Trim() + "'," + s2 + ",@itemid) " +
                                      "end";

                        }
                        else
                        {
                            sSQL = "if exists(select * from  @u8.CurrentStock where cInvCode = '" + dtTable.Rows[i]["物料编码"].ToString().Trim() + "' and cWhCode = '" + dtTable.Rows[i]["仓库编码"].ToString().Trim() + "') " +
                            "	update  @u8.CurrentStock set iQuantity = isnull(iQuantity,0) + " + s2 + ",iNum = isnull(iNum,0) + " + s1 + "  where cInvCode = '" + dtTable.Rows[i]["物料编码"].ToString().Trim() + "' and cWhCode = '" + dtTable.Rows[i]["仓库编码"].ToString().Trim() + "' " +
                                    "else " +
                                        "begin " +
                                        "    declare @itemid varchar(20); " +
                                      "declare @iCount int;  " +
                                        "select @iCount=count(itemid) from @u8.CurrentStock where cInvCode = '" + dtTable.Rows[i]["物料编码"].ToString().Trim() + "';   " +
                                        "if( @iCount > 0 ) " +
                                        "	select @itemid=itemid from @u8.CurrentStock where cInvCode = '" + dtTable.Rows[i]["物料编码"].ToString().Trim() + "';  " +
                                        "else  " +
                                        "	 select @itemid=max(itemid+1) from @u8.CurrentStock  " +
                                        "    insert into @u8.CurrentStock(cWhCode,cInvCode,iQuantity,iNum,itemid)values('" + dtTable.Rows[i]["仓库编码"].ToString().Trim() + "','" + dtTable.Rows[i]["物料编码"].ToString().Trim() + "'," + s2 + "," + s1 + ",@itemid) " +
                                        "end";
                        }
                        aList.Add(sSQL);
                        dtTable.Rows[i]["bUsed"] = iIDBackDetail;
                    }
                    else
                    {
                        continue;
                    }

                    for (int j = i + 1; j < dtTable.Rows.Count; j++)
                    {
                        if (dtTable.Rows[j]["bUsed"].ToString().Trim() == "-1" && dtTable.Rows[i]["仓库编码"].ToString().Trim() == dtTable.Rows[j]["仓库编码"].ToString().Trim())
                        {
                            //表体 
                            string s1 = "null";
                            if (dtTable.Rows[j]["本次入库件数"].ToString().Trim() != string.Empty)
                                s1 = dtTable.Rows[j]["本次入库件数"].ToString().Trim();


                            string s2 = "null";
                            if (dtTable.Rows[j]["本次入库数量"].ToString().Trim() != string.Empty)
                                s2 = dtTable.Rows[j]["本次入库数量"].ToString().Trim();

                            decimal d订单数量 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[j]["订单数量"]);
                            if (MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[j]["本次入库数量"]) > d订单数量)
                            {
                                sErr = sErr + "行" + (j + 1).ToString() + "超出订单数量\r\n";
                            }

                            sSQL = @"select top 1 D.cInvCode  from  @u8.OM_MOMaterials M
                                left join @u8.OM_MODetails D on M.MoDetailsID = D.MODetailsID 
                                where m.MOMaterialsID ={0}";
                            sSQL = string.Format(sSQL, dtTable.Rows[j]["子件用料表ID"].ToString());
                            DataTable dtInv = clsSQLCommond.ExecQuery(sSQL);
                            string pInvCode = dtInv.Rows[0]["cInvCode"].ToString();

                            iIDBackDetail += 1;

                            sSQL = "Insert Into @u8.rdrecords11(autoid,id,cinvcode,inum,iquantity," +
                                        "isquantity,isnum,cdefine26,cdefine27,inquantity,innum," +
                                        "iprocesscost,iprocessfee,iomodid,iOMoMID," +
                                        "bcosting,iinvexchrate,corufts,iexpiratdatecalcu,isotype,comcode,invcode  ) " +
                                    "Values (" + iIDBackDetail + "," + iIDBack + ",N'" + dtTable.Rows[j]["物料编码"].ToString().Trim() + "',0-" + s1 + ",0-" + s2 +
                                        ",0,0,0,0," + "0" + "," + "0"  +
                                        ",0,0," + dtTable.Rows[j]["委外订单子表ID"].ToString().Trim() + "," + dtTable.Rows[j]["子件用料表ID"].ToString().Trim() + "," +
                                        "1,0,N'1610.3418',0,0,'" + dtTable.Rows[j]["订单号"].ToString().Trim() + "','" + pInvCode + "')";
                            aList.Add(sSQL);


                            sSQL = "select D.* from @u8.OM_MODetails D left join  @u8.OM_MOMaterials  OD on D.MoDetailsID =OD.MoDetailsID    where OD.MOMaterialsID  = " + dtTable.Rows[j]["子件用料表ID"].ToString().Trim();
                            DataTable dtPodetails = clsSQLCommond.ExecQuery(sSQL);
                            if (dtPodetails.Rows[0]["citemName"].ToString().Trim() != string.Empty)
                            {
                                sSQL = "update @u8.rdrecords11 set citem_class='" + dtPodetails.Rows[0]["citem_class"] + "',citemcode='" + dtPodetails.Rows[0]["cItemCode"] + "',cname='" + dtPodetails.Rows[0]["citemName"] + "',citemcname='" + "外销订单项目" + "' " +
                                       " where autoid = " + iIDBackDetail;
                                aList.Add(sSQL);
                            }

                            sSQL = "update @u8.OM_MOMaterials set iSendQTY =iSendQTY-" + s2 + ",iSendNum =iSendNum-" + s1 + " where MOMaterialsID = " + dtTable.Rows[j]["子件用料表ID"].ToString().Trim();
                            aList.Add(sSQL);

                            //////现存量
                            if (s1 == "null")
                            {
                                sSQL = "if exists(select * from  @u8.CurrentStock where cInvCode = '" + dtTable.Rows[j]["物料编码"].ToString().Trim() + "' and cWhCode = '" + dtTable.Rows[j]["仓库编码"].ToString().Trim() + "') " +
                                "	update  @u8.CurrentStock set iQuantity = isnull(iQuantity,0) + " + s2 + "  where cInvCode = '" + dtTable.Rows[j]["物料编码"].ToString().Trim() + "' and cWhCode = '" + dtTable.Rows[j]["仓库编码"].ToString().Trim() + "' " +
                                        "else " +
                                            "begin " +
                                            "    declare @itemid varchar(20); " +
                                            "    declare @iCount int;  " +
                                                "select @iCount=count(itemid) from @u8.CurrentStock where cInvCode = '" + dtTable.Rows[j]["物料编码"].ToString().Trim() + "';   " +
                                                "if( @iCount > 0 ) " +
                                                "	select @itemid=itemid from @u8.CurrentStock where cInvCode = '" + dtTable.Rows[j]["物料编码"].ToString().Trim() + "';  " +
                                                "else  " +
                                                "	 select @itemid=max(itemid+1) from @u8.CurrentStock  " +
                                                "    insert into @u8.CurrentStock(cWhCode,cInvCode,iQuantity,itemid)values('" + dtTable.Rows[j]["仓库编码"].ToString().Trim() + "','" + dtTable.Rows[j]["物料编码"].ToString().Trim() + "'," + s2 + ",@itemid) " +
                                            "end";
                            }
                            else
                            {
                                sSQL = "if exists(select * from  @u8.CurrentStock where cInvCode = '" + dtTable.Rows[j]["物料编码"].ToString().Trim() + "' and cWhCode = '" + dtTable.Rows[j]["仓库编码"].ToString().Trim() + "') " +
                               "	update  @u8.CurrentStock set iQuantity = isnull(iQuantity,0) + " + s2 + ",iNum = isnull(iNum,0) + " + s1 + "  where cInvCode = '" + dtTable.Rows[j]["物料编码"].ToString().Trim() + "' and cWhCode = '" + dtTable.Rows[j]["仓库编码"].ToString().Trim() + "' " +
                                       "else " +
                                           "begin " +
                                                   "    declare @itemid varchar(20); " +
                                              "declare @iCount int;  " +
                                                "select @iCount=count(itemid) from @u8.CurrentStock where cInvCode = '" + dtTable.Rows[j]["物料编码"].ToString().Trim() + "';   " +
                                                "if( @iCount > 0 ) " +
                                                "	select @itemid=itemid from @u8.CurrentStock where cInvCode = '" + dtTable.Rows[j]["物料编码"].ToString().Trim() + "';  " +
                                                "else  " +
                                                "	 select @itemid=max(itemid+1) from @u8.CurrentStock  " +
                                        "    insert into @u8.CurrentStock(cWhCode,cInvCode,iQuantity,iNum,itemid)values('" + dtTable.Rows[j]["仓库编码"].ToString().Trim() + "','" + dtTable.Rows[j]["物料编码"].ToString().Trim() + "'," + s2 + "," + s1 + ",@itemid) " +
                                           "end";
                            }
                            aList.Add(sSQL);
                            dtTable.Rows[j]["bUsed"] = iIDBackDetail;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                #endregion

                if (iIDBack > 1000000000)
                    iIDBack = iIDBack - 1000000000;
                if (iIDBackDetail > 1000000000)
                    iIDBackDetail = iIDBackDetail - 1000000000;
                sSQL = "update UFSystem..UA_Identity set iFatherID = " + iIDBack + ",iChildID=" + iIDBackDetail + "  where cAcc_Id = '" + MobileBaseDLL.ClsBaseDataInfo.sUFDataBaseName.Substring(7,3) + "' and cVouchType = 'rd'";
                aList.Add(sSQL);

                //更改最大单据号
                sSQL = "select count(*) as iCount From @u8.VoucherHistory  with (NOLOCK) Where CardNumber='0412' and (cContent='日期' or cContent='单据日期') and (cSeed='" + DateTime.Parse(dateTime单据日期.Value.ToString("yyyy-MM-dd")).ToString("yyyyMM") + "' or cSeed='" + DateTime.Parse(dateTime单据日期.Value.ToString("yyyy-MM-dd")).ToString("yyMM") + "')";
                DataTable dtCodeTemp = clsSQLCommond.ExecQuery(sSQL);
                if (dtCodeTemp.Rows[0]["iCount"].ToString().Trim() == "0")
                {
                    sSQL = "insert into @u8.VoucherHistory(cardnumber,ccontent,ccontentrule,cseed,cnumber,bempty)values('0412','日期','月','" + DateTime.Parse(dateTime单据日期.Value.ToString("yyyy-MM-dd")).ToString("yyMM") + "','1',0)";
                    aList.Add(sSQL);
                }
                else
                {
                    sSQL = "update @u8.VoucherHistory set cNumber = '" + iCodeBack.ToString().Trim() + "' Where CardNumber='0412' and (cContent='日期' or cContent='单据日期') and (cSeed='" + DateTime.Parse(dateTime单据日期.Value.ToString("yyyy-MM-dd")).ToString("yyyyMM") + "' or cSeed='" + DateTime.Parse(dateTime单据日期.Value.ToString("yyyy-MM-dd")).ToString("yyMM") + "')";
                    aList.Add(sSQL);
                }

                if (sErr.Trim().Length > 0)
                {
                    throw new Exception(sErr);
                }

                if (aList.Count > 0)
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    dtTable.Rows.Clear();
                    txt货位.Text = "";
                    txt条数.Text = "";
                    txt条形码.Text = "";
                    txt条数.Focus();

                    msgBox.textBox1.Text = sInfo;
                    msgBox.ShowDialog();
                }
            }
            catch (Exception ee)
            {
                msgBox.textBox1.Text = "保存失败:" + ee.Message;
                msgBox.ShowDialog();
            }
        }

        int iRow = -1;
        int iCol = -1;
        private void dataGrid1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                DataGridCell editCell = dataGrid1.CurrentCell;
                Rectangle cellPos = new Rectangle();
                iRow = editCell.RowNumber;
                iCol = editCell.ColumnNumber;

                if (iCol == 5 )
                {
                    cellPos = dataGrid1.GetCellBounds(iRow, iCol);
                    txt编辑.Left = cellPos.Left;
                    txt编辑.Top = cellPos.Top + dataGrid1.Top;
                    txt编辑.Width = cellPos.Width;
                    txt编辑.Height = cellPos.Height;
                    txt编辑.Visible = true;
                    txt编辑.Text = dtTable.Rows[editCell.RowNumber][editCell.ColumnNumber].ToString().Trim();
                    txt编辑.Focus();
                }
                else if (iCol == 6)
                {
                    decimal d订单件数 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[iRow]["订单件数"]);
                    if (d订单件数 > 0)
                    {
                        cellPos = dataGrid1.GetCellBounds(iRow, iCol);
                        txt编辑.Left = cellPos.Left;
                        txt编辑.Top = cellPos.Top + dataGrid1.Top;
                        txt编辑.Width = cellPos.Width;
                        txt编辑.Height = cellPos.Height;
                        txt编辑.Visible = true;
                        txt编辑.Text = dtTable.Rows[editCell.RowNumber][editCell.ColumnNumber].ToString().Trim();
                        txt编辑.Focus();
                    }
                }
                else
                {
                    txt编辑.Text = "";
                    txt编辑.Visible = false;
                    iRow = -1;
                    iCol = -1;
                }
            }
            catch
            {
                txt编辑.Text = "";
                txt编辑.Visible = false;
                iRow = -1;
                iCol = -1;
            }
        }

        private void txt编辑_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13)
                {
                    txt编辑_LostFocus(null, null);
                }
            }
            catch
            { }
        }

        private void txt条形码_LostFocus(object sender, EventArgs e)
        {
            txt编辑.Text = "";
            txt编辑.Visible = false;
        }

        private void txt编辑_LostFocus(object sender, EventArgs e)
        {
            try
            {
                if (iRow == -1 || iCol == -1)
                    return;

                if (iCol == 1)
                {
                    //判断货位
                    dtTable.Rows[iRow][iCol] = txt编辑.Text.Trim();
                }
                if (iCol == 5)
                { 
                    decimal d数量 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(txt编辑.Text);
                    decimal d本次入库数量 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[iRow]["本次入库数量"]);
                    decimal d订单数量 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[iRow]["订单数量"]);
                    decimal d订单件数 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[iRow]["订单件数"]);
                    if (d数量 != d本次入库数量)
                    {
                        if (d数量 <= 0)
                        {
                            MessageBox.Show("本次到货数量必须大于0");
                            return;
                        }

                        if (dtTable.Rows[iRow]["辅计量单位"].ToString().Trim() != "" || d数量 > 0)
                        {
                            if (radio数量.Checked)
                            {
                                decimal d件数 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(d订单件数 * d数量 / d订单数量);
                                dtTable.Rows[iRow]["本次入库件数"] = d件数;
                            }
                        }
                    }
                    dtTable.Rows[iRow][iCol] = txt编辑.Text.Trim();
                }

                if (iCol == 6)
                {
                    decimal d件数 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(txt编辑.Text);
                    decimal d本次入库件数 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[iRow]["本次入库件数"]);
                    decimal d订单数量 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[iRow]["订单数量"]);
                    decimal d订单件数 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[iRow]["订单件数"]);

                    if (d件数 != d本次入库件数)
                    {
                        if (d订单件数 < 0)
                        {
                            iRow = -1;
                            iCol = -1;
                            txt编辑.Visible = false;
                            txt编辑.Text = "";
                        }
                        else
                        {
                            if (d件数 <= 0)
                            {
                                MessageBox.Show("本次到货件数必须大于0");
                                return;
                            }
                            if (radio件数.Checked)
                            {
                                decimal d数量 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(d订单数量 * d件数 / d订单件数);
                                dtTable.Rows[iRow]["本次入库数量"] = d数量;
                            }
                        }
                    }
                    dtTable.Rows[iRow][iCol] = txt编辑.Text.Trim();
                }

                iRow = -1;
                iCol = -1;
                txt编辑.Visible = false;
                txt编辑.Text = "";
            }
            catch
            { }
        }
    }
}