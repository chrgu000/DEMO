using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using TH.BaseClass;
using System.Data.SqlClient;

namespace BarCode
{
    public partial class Frm其他出库 : FrmBase
    {
        DataTable dtTable;

        public Frm其他出库()
        {
            InitializeComponent();

            dtTable = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "存货编码";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "存货名称";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "规格型号";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "货主";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "货位";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "产地";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "厂商";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "包装规格";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "货权方";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "提单号";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "合同号";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "数量";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "单据号";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "订单数量";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "订单件数";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "单据日期";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "条形码";
            dtTable.Columns.Add(dc);
            dataGrid1.DataSource = dtTable;

            dc = new DataColumn();
            dc.ColumnName = "条形码2";
            dtTable.Columns.Add(dc);
            dataGrid1.DataSource = dtTable;
        }

        DataTable dt = new DataTable();

        private void Frm其他出库货位_Load(object sender, EventArgs e)
        {
            date单据日期.Text = DateTime.Now.ToString("yyyy-MM-dd");

            txt条形码.Focus();
        }

        private void txt条形码_KeyUp(object sender, KeyEventArgs e)
        {
            try
            { 
                if(e.KeyCode != Keys.Enter)
                    return;

                btnScan_Click(null,null);
            }
            catch { }
        }

       

        private void btn删行_Click(object sender, EventArgs e)
        {
            for (int i = dtTable.Rows.Count - 1; i >= 0; i--)
            {
                if (dataGrid1.IsSelected(i))
                    dtTable.Rows.RemoveAt(i);
            }
        }

        private void btn保存_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtTable == null || dtTable.Rows.Count < 1)
                {
                    throw new Exception("请先扫条形码");
                }

                string sErr = "";
                int iCount = 0;
                SqlConnection conn = new SqlConnection(MobileBaseDLL.ClsBaseDataInfo.sConnString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                string sSQL = "select getdate()";
                DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                DateTime dNow = MobileBaseDLL.ClsBaseDataInfo.ReturnDate(dt.Rows[0][0]);
                try
                {

                    string sCode = "ID-" + date单据日期.Value.ToString("yyyy-MM") + "-";
                    sSQL = "select ISNULL(max(code),0) as sCode from ST_RDRecord where code like '" + sCode + "%'";
                    DataTable dtCode = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    string s = dtCode.Rows[0][0].ToString().Trim();
                    if (s == "0")
                    {
                        sCode = "ID-" + date单据日期.Value.ToString("yyyy-MM") + "-0001";
                    }
                    else
                    {
                        s = s.Replace(sCode, "");
                        int iCode = MobileBaseDLL.ClsBaseDataInfo.ReturnInt(s);
                        iCode += 1;
                        string sCodeTemp = iCode.ToString();
                        while (sCodeTemp.Length < 4)
                        {
                            sCodeTemp = "0" + sCodeTemp;
                        }
                        sCode = sCode + sCodeTemp;
                    }

                    sSQL = @"
SELECT d.BarCode as 条形码,d.Qty AS 数量
	,a.code AS 单据号,a.voucherdate AS 单据日期,a.pubuserdefnvc1 AS 理货员,a.pubuserdefnvc2 AS 货主
	,b.quantity AS 订单数量,b.quantity2 AS 订单件数
	,b.inventoryLocation AS 货位,b.freeItem0 AS 货主,b.freeItem1 AS 产地,b.freeItem2 AS 厂商,b.freeItem3 AS 包装规格,b.freeItem4 AS 货权方,b.freeItem5 AS 提单号
	,b.freeItem6 AS 合同号
	,c.code AS 存货编码,c.name AS 存货名称,c.specification AS 规格型号
    ,a.id,b.id as ids,a.idwarehouse
    ,a.pubuserdefnvc1
FROM [dbo].[ST_RDRecord] a INNER JOIN [dbo].[ST_RDRecord_b] b ON a.id = b.idRDRecordDTO 
	INNER JOIN AA_Inventory c ON b.idinventory = c.id
	INNER JOIN dbo.[_BarCodeList] d ON b.id = d.DetailsID
WHERE 1=1 AND a.idvouchertype = 17 and d.BarCode = 'aaaaaa'
    and ISNULL(d.[DelUid],'') = ''
	AND ISNULL(d.RdOutIDs,-1) NOT IN (SELECT id FROM [ST_RDRecord_b])
";
                    sSQL = sSQL.Replace("aaaaaa", dtTable.Rows[0]["条形码"].ToString());
                    DataTable dtRdIn = clsSQLCommond.ExecQuery(sSQL);
                    if (dtRdIn == null || dtRdIn.Rows.Count == 0)
                    {
                        throw new Exception("条码 " + dtTable.Rows[0]["条形码"].ToString() + " 错误");
                    }

                    Model.ST_RDRecord mod = new BarCode.Model.ST_RDRecord();
                    mod.code = sCode;
                    mod.printTime = 0;
                    mod.amount = 0;
                    mod.rdDirectionFlag = 0;
                    mod.isCostAccount = 0;
                    mod.isMergedFlow = 0;
                    mod.isAutoGenerate = 0;
                    mod.maker = MobileBaseDLL.ClsBaseDataInfo.sUserName;
                    mod.iscarriedforwardin = 0;
                    mod.iscarriedforwardout = 0;
                    mod.ismodifiedcode = 0;
                    mod.accountingyear = date单据日期.Value.Year;
                    mod.accountingperiod = date单据日期.Value.Month;
                    mod.pubuserdefnvc1 = dtRdIn.Rows[0]["pubuserdefnvc1"].ToString().Trim();
                    mod.updatedBy = MobileBaseDLL.ClsBaseDataInfo.sUid;
                    mod.pubuserdefnvc2 = dtTable.Rows[0]["货主"].ToString().Trim();
                    mod.VoucherYear = date单据日期.Value.Year;
                    mod.VoucherPeriod = date单据日期.Value.Month;
                    mod.PrintCount = 0;
                    mod.idbusitype = 8;
                    mod.IdMarketingOrgan = 1;
                    mod.idwarehouse = MobileBaseDLL.ClsBaseDataInfo.ReturnInt(dtRdIn.Rows[0]["idwarehouse"]);
                    mod.voucherState = 181;
                    mod.makerid = 18;
                    mod.idvouchertype = 30;
                    mod.voucherdate = Convert.ToDateTime(date单据日期.Value.ToString("yyyy-MM-dd"));
                    mod.madedate = MobileBaseDLL.ClsBaseDataInfo.ReturnDate(dNow.ToString("yyyy-MM-dd"));
                    mod.createdtime = dNow;
                    DAL.ST_RDRecord dal = new BarCode.DAL.ST_RDRecord();
                    sSQL = dal.Add(mod);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    sSQL = "select id from ST_RDRecord where code = '" + mod.code + "' order by id desc";
                    dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    int iID = MobileBaseDLL.ClsBaseDataInfo.ReturnInt(dt.Rows[0][0]);

                    for (int i = 0; i < dtTable.Rows.Count; i++)
                    {
                        string[] s2 = dtTable.Rows[i]["条形码2"].ToString().Split('-');
                        string s入库表体ID = s2[0];
                        sSQL = @"
select a.* ,b.name AS 主计量,c.name AS 辅计量
from ST_RDRecord_b a
    LEFT JOIN AA_Unit b ON a.idunit = b.id
	LEFT JOIN AA_Unit c ON a.idunit2 = c.id
where a.id = " + s入库表体ID;
                        DataTable dtRDInDetails = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        Model.ST_RDRecord_b mods = new BarCode.Model.ST_RDRecord_b();
                        mods.code = "0000";
                        mods.quantity = ReturnDecimal(dtTable.Rows[i]["数量"]);
                        mods.quantity2 = 1;

                        string s单位组合 = mods.quantity2.ToString().Trim() + dtRDInDetails.Rows[0]["辅计量"].ToString().Trim() + "/" + mods.quantity.ToString().Trim() + dtRDInDetails.Rows[0]["主计量"].ToString().Trim();
                        mods.compositionQuantity = s单位组合;
                        mods.baseQuantity = mods.quantity2;
                        mods.subQuantity = mods.quantity;
                        mods.price = 0;
                        mods.price2 = 0;
                        mods.basePrice = 0;
                        mods.amount = 0;
                        mods.changeRate = mods.quantity2 / mods.quantity;
                        mods.isManualCost = 0;
                        mods.isCostAccounted = 0;
                        mods.taxFlag = 0;
                        mods.inventoryLocation = dtRDInDetails.Rows[0]["inventoryLocation"].ToString().Trim();
                        mods.updatedBy = MobileBaseDLL.ClsBaseDataInfo.sUid;
                        mods.freeItem0 = dtRDInDetails.Rows[0]["freeItem0"].ToString().Trim();
                        mods.freeItem1 = dtRDInDetails.Rows[0]["freeItem1"].ToString().Trim();
                        mods.freeItem2 = dtRDInDetails.Rows[0]["freeItem2"].ToString().Trim();
                        mods.freeItem3 = dtRDInDetails.Rows[0]["freeItem3"].ToString().Trim();
                        mods.freeItem4 = dtRDInDetails.Rows[0]["freeItem4"].ToString().Trim();
                        mods.freeItem5 = dtRDInDetails.Rows[0]["freeItem5"].ToString().Trim();
                        mods.freeItem6 = dtRDInDetails.Rows[0]["freeItem6"].ToString().Trim();
                        mods.IsPresent = 0;
                        mods.IsPromotionPresent = 0;
                        mods.idbusiTypeByMergedFlow = 8;
                        mods.idinventory = MobileBaseDLL.ClsBaseDataInfo.ReturnInt(dtRDInDetails.Rows[0]["idinventory"]);
                        mods.idbaseunit = MobileBaseDLL.ClsBaseDataInfo.ReturnInt(dtRDInDetails.Rows[0]["idbaseunit"]);
                        mods.idsubunit = MobileBaseDLL.ClsBaseDataInfo.ReturnInt(dtRDInDetails.Rows[0]["idsubunit"]);
                        mods.idunit = MobileBaseDLL.ClsBaseDataInfo.ReturnInt(dtRDInDetails.Rows[0]["idunit"]);
                        mods.idunit2 = MobileBaseDLL.ClsBaseDataInfo.ReturnInt(dtRDInDetails.Rows[0]["idunit2"]);
                        mods.idwarehouse = MobileBaseDLL.ClsBaseDataInfo.ReturnInt(dtRDInDetails.Rows[0]["idwarehouse"]);
                        mods.idRDRecordDTO = iID;
                        mods.createdtime = dNow;
                        mods.updated = dNow;

                        DAL.ST_RDRecord_b dals = new BarCode.DAL.ST_RDRecord_b();
                        sSQL = dals.Add(mods);
                        iCount += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        sSQL = "select max(id) as maxid from ST_RDRecord_b where idRDRecordDTO = " + iID;
                        string sMaxID = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0].ToString().Trim();
                        sSQL = "update  _BarCodeList set RdOutIDs = " + sMaxID + " where BarCode = '" + dtTable.Rows[i]["条形码"].ToString().Trim() + "'";
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        //现存量
                        sSQL = @"
UPDATE  ST_CurrentStock SET otherForDispatchBaseQuantity = ISNULL(otherForDispatchBaseQuantity,0) + @qty, otherForDispatchSubQuantity = ISNULL(otherForDispatchSubQuantity,0) +  @num
where  isnull(freeItem0,'') = '@freeItem0' and isnull(freeItem1,'') = '@freeItem1' and isnull(freeItem2,'') ='@freeItem2' and isnull(freeItem3,'') = '@freeItem3' 
    and isnull(freeItem4,'') = '@freeItem4' and isnull(freeItem5,'') = '@freeItem5' and isnull(freeItem6,'') = '@freeItem6' 
    and  idinventory = @idinventory and  idwarehouse = @idwarehouse
";
                        sSQL = sSQL.Replace("@qty", mods.quantity.ToString());
                        sSQL = sSQL.Replace("@num", mods.quantity2.ToString());
                        sSQL = sSQL.Replace("@freeItem0", mods.freeItem0);
                        sSQL = sSQL.Replace("@freeItem1", mods.freeItem1);
                        sSQL = sSQL.Replace("@freeItem2", mods.freeItem2);
                        sSQL = sSQL.Replace("@freeItem3", mods.freeItem3);
                        sSQL = sSQL.Replace("@freeItem4", mods.freeItem4);
                        sSQL = sSQL.Replace("@freeItem5", mods.freeItem5);
                        sSQL = sSQL.Replace("@freeItem6", mods.freeItem6);
                        sSQL = sSQL.Replace("@baseQuantity", mods.baseQuantity.ToString());
                        sSQL = sSQL.Replace("@subQuantity", mods.subQuantity.ToString());
                        sSQL = sSQL.Replace("@idinventory", mods.idinventory.ToString());
                        sSQL = sSQL.Replace("@idwarehouse", mods.idwarehouse.ToString());
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        sSQL = @"
SELECT * FROM ST_LocationDetail WHERE idRDRecordDetailDTO = @id
";
                        sSQL = sSQL.Replace("@id", s入库表体ID);
                        DataTable dtLocationDetail = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                        Model.ST_LocationDetail modLocals = new BarCode.Model.ST_LocationDetail();
                        modLocals.quantity = mods.quantity;
                        modLocals.quantity2 = mods.quantity2;
                        modLocals.baseQuantity = mods.baseQuantity;
                        modLocals.subQuantity = mods.subQuantity;
                        modLocals.batch = mods.batch;
                        modLocals.idinvlocation = RetrunInt(dtLocationDetail.Rows[0]["idinvlocation"]);
                        modLocals.idunit = mods.idunit;
                        modLocals.idunit2 = mods.idunit2;
                        modLocals.idRDRecordDetailDTO = MobileBaseDLL.ClsBaseDataInfo.ReturnInt(sMaxID);
                        DAL.ST_LocationDetail dalLocals = new BarCode.DAL.ST_LocationDetail();
                        sSQL = dalLocals.Add(modLocals);
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    if (iCount > 0)
                    {
                        tran.Commit();
                        MessageBox.Show("生成单据成功:" + mod.code);
                    }
                    else
                    {
                        MessageBox.Show("请扫描数据后扫描");
                    }

                }
                catch (Exception ee)
                {
                    tran.Rollback();
                    throw new Exception(ee.Message);
                }
            }
            catch (Exception ee)
            {
                msgBox.textBox1.Text = "保存失败:\r\n" + ee.Message;
                msgBox.ShowDialog();
            }
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt条形码.Text.Trim() == "")
                {
                    MessageBox.Show("请扫描条码");
                    return;
                }

                for (int i = 0; i < dtTable.Rows.Count; i++)
                {
                    string sId = dtTable.Rows[i]["条形码"].ToString().Trim();
                    if (sId == txt条形码.Text.Trim())
                    {
                        txt条形码.Focus();
                        MessageBox.Show("该条码已经扫描");
                        txt条形码.Text = "";
                        return;
                    }
                }

                string sSQL = @"
SELECT d.BarCode as 条形码,d.Qty AS 数量
	,a.code AS 单据号,a.voucherdate AS 单据日期,a.pubuserdefnvc1 AS 理货员,a.pubuserdefnvc2 AS 货主
	,b.quantity AS 订单数量,b.quantity2 AS 订单件数
	,b.inventoryLocation AS 货位,b.freeItem0 AS 货主,b.freeItem1 AS 产地,b.freeItem2 AS 厂商,b.freeItem3 AS 包装规格,b.freeItem4 AS 货权方,b.freeItem5 AS 提单号
	,b.freeItem6 AS 合同号
	,c.code AS 存货编码,c.name AS 存货名称,c.specification AS 规格型号
    ,d.BarCode2 as 条形码2
FROM [dbo].[ST_RDRecord] a INNER JOIN [dbo].[ST_RDRecord_b] b ON a.id = b.idRDRecordDTO 
	INNER JOIN AA_Inventory c ON b.idinventory = c.id
	INNER JOIN dbo.[_BarCodeList] d ON b.id = d.DetailsID
WHERE 1=1 AND a.idvouchertype = 17 and d.BarCode = 'aaaaaa'
    and ISNULL(d.[DelUid],'') = ''
	AND ISNULL(d.RdOutIDs,0) = 0 
";
                sSQL = sSQL.Replace("aaaaaa", txt条形码.Text.Trim());
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt == null || dt.Rows.Count == 0)
                {
                    throw new Exception("条码不存在,已经关闭或已经出库");
                }

                DataRow dr = dtTable.NewRow();
                for (int i = 0; i < dtTable.Columns.Count; i++)
                {
                    string sColName = dtTable.Columns[i].ColumnName;
                    dr[sColName] = dt.Rows[0][sColName];
                }
                dtTable.Rows.Add(dr);
                dataGrid1.DataSource = dtTable;

                txt条形码.Text = "";
                txt条形码.Focus();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}