using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using FrameBaseFunction;

namespace Purchase
{
    public partial class Frm采购调价单 : FrameBaseFunction.Frm列表窗体模板
    {

        public Frm采购调价单()
        {
            InitializeComponent();
        }

        private void GetGrid()
        {
            try
            {
                OpenFileDialog oFile = new OpenFileDialog();
                oFile.Filter = "Excel文件2003|*.xls|Excel文件2007|*.xlsx";
                if (oFile.ShowDialog() == DialogResult.OK)
                {
                    string sFilePath = oFile.FileName;
                    string sSQL = "select 供应商编码,存货编码,含税单价,税率,表头备注,表体备注 from [Sheet1$]";

                    FrameBaseFunction.ClsExcel clsExcel = FrameBaseFunction.ClsExcel.Instance();

                    DataTable dtExcel = clsExcel.ExcelToDT(sFilePath, sSQL, true);
                    if (dtExcel.Rows.Count <= 0)
                    {
                        MessageBox.Show("没有导入数据！");
                        return;
                    }
                    dtExcel.Columns.Add(new DataColumn("选择", System.Type.GetType("System.Boolean")));
                    for (int i = 0; i < dtExcel.Rows.Count; i++)
                    {
                        dtExcel.Rows[i]["存货编码"] = dtExcel.Rows[i]["存货编码"].ToString().Trim();
                        dtExcel.Rows[i]["供应商编码"] = dtExcel.Rows[i]["供应商编码"].ToString().Trim();
                    }


                    gridControl1.DataSource = dtExcel;

                    for (int i = gridView1.RowCount - 1; i >= 0; i--)
                    {
                        string sInvName = gridView1.GetRowCellDisplayText(i, gridColcInvName).ToString().Trim();
                        string sVenName = gridView1.GetRowCellDisplayText(i, gridColcVenName).ToString().Trim();

                        if (sInvName == "" && sVenName == "")
                        {
                            gridView1.DeleteRow(i);
                        }
                    }

                    chkAll.Checked = true;
                    chkAll_CheckedChanged(null, null);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得列表失败! \n\n原因:\n  " + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void BtnClick(string sBtnName, string sBtnText)
        {
            try
            {
                switch (sBtnName.ToLower())
                {
                    case "sel":
                        btnSel();
                        break;
                    case "save":
                        btnSave();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ee)
            {

                FrmMsgBox fMsgBos = new FrmMsgBox();
                fMsgBos.Text = "提示";
                fMsgBos.richTextBox1.Text = ee.Message;
                fMsgBos.ShowDialog();
                
            }
        }

        private void btnSel()
        {
            GetGrid();
        }

        private void btnSave()
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
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    string sInvName = gridView1.GetRowCellDisplayText(i, gridColcInvName).ToString().Trim();
                    if (sInvName == "")
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + " 存货不正确\n";
                    }

                    string sVenName = gridView1.GetRowCellDisplayText(i, gridColcVenName).ToString().Trim();
                    if (sVenName == "")
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + " 供应商不正确\n";
                    }

                    decimal d含税单价 = ReturnObjectToDecimal(gridView1.GetRowCellDisplayText(i, gridCol含税单价), 6);
                    if (d含税单价 <= 0)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + " 含税单价不正确\n";
                    }

                    if (gridView1.GetRowCellDisplayText(i, gridCol税率).ToString().Trim() == "")
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + " 税率不正确\n";
                    }
                    decimal d税率 = ReturnObjectToDecimal(gridView1.GetRowCellDisplayText(i, gridCol税率), 6);
                    if (d税率 < 0 || d税率 > 100)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + " 税率不正确\n";
                    }

                    sSQL = "select isnull(bPurchase,0) as bPurchase from @u8.Inventory where cInvCode = 'aaaaaaaaaa'";
                    sSQL = sSQL.Replace("aaaaaaaaaa", gridView1.GetRowCellDisplayText(i, gridColcinvcode).ToString().Trim());
                    int iReturn = BaseFunction.ReturnInt(clsSQLCommond.ExecGetScalar(sSQL));
                    if (iReturn == 0)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + " 存货【" + gridView1.GetRowCellDisplayText(i, gridColcinvcode).ToString().Trim() + "】" + sInvName + " 不是采购件\n";
                    }
                }

                if (sErr.Length > 0)
                {
                    throw new Exception(sErr);
                }

                
                ArrayList aList = new ArrayList();
                sSQL = @"
declare @p5 int
set @p5=1000003974
declare @p6 int
set @p6=1000042663
exec @u8.sp_getID N'00',N'200',N'puprice',1,@p5 output,@p6 output
select @p5, @p6
";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                long lID = ReturnObjectToLong(dt.Rows[0][0]);
                long lIDs = ReturnObjectToLong(dt.Rows[0][1]);

                sSQL = @"
select cNumber as Maxnumber From @u8.VoucherHistory  with (NOLOCK) Where  CardNumber='PU03' and cContent is NULL
";
                dt = clsSQLCommond.ExecQuery(sSQL);
                long lCode = ReturnObjectToLong(dt.Rows[0][0]) +1;
                string sCode = lCode.ToString();
                while(sCode.Length < 10 )
                {
                    sCode = "0" + sCode;
                }

                Model.PU_PriceJustMain mod = new Purchase.Model.PU_PriceJustMain();
                mod.id = lID;
                mod.ddate = BaseFunction.ReturnDate(FrameBaseFunction.ClsBaseDataInfo.sLogDate);
                mod.ccode = sCode;
                mod.cmaker = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                mod.ivtid = 31338;
                mod.bTaxCost = 1;
                mod.iSupplyType = 1;
                mod.cMakeTime = DateTime.Now;
                mod.iPrintCount = 0;
                //mod.iverifystate = 0;
                mod.cverifier = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                mod.dverifydate = BaseFunction.ReturnDate(FrameBaseFunction.ClsBaseDataInfo.sLogDate);
                mod.iverifystate = 2;
                mod.cmainmemo = gridView1.GetRowCellDisplayText(0, gridCol表头备注).ToString().Trim();
                mod.csysbarcode = @"||putj|" + mod.ccode;
                mod.cAuditTime = mod.cMakeTime;

                DAL.PU_PriceJustMain dal = new Purchase.DAL.PU_PriceJustMain();
                sSQL = dal.Add(mod);
                aList.Add(sSQL);

                int iRow = 0;
                bool bHas = false;
                for (int i = 0; i < gridView1.RowCount;i++)
                {
                    if (!ReturnObjectToBool(gridView1.GetRowCellValue(i,gridCol选择)))
                        continue;

                    iRow+=1;
                    lIDs += 1;
                    Model.PU_PriceJustDetail mods = new Purchase.Model.PU_PriceJustDetail();
                    mods.autoid = lIDs;
                    mods.id = lID;
                    mods.operationtype = "0";
                    mods.cvencode = gridView1.GetRowCellDisplayText(i, gridColcVenCode).ToString().Trim();
                    mods.cinvcode = gridView1.GetRowCellDisplayText(i, gridColcinvcode).ToString().Trim();
                    mods.dstartdate = BaseFunction.ReturnDate(FrameBaseFunction.ClsBaseDataInfo.sLogDate);
                    mods.bsales = 0;
                    mods.fminquantity = 0;
                    mods.iTaxRate = ReturnObjectToDecimal(gridView1.GetRowCellDisplayText(i, gridCol税率), 6);
                    mods.iTaxUnitPrice = ReturnObjectToDecimal(gridView1.GetRowCellDisplayText(i, gridCol含税单价), 6);
                    mods.iUnitPrice = ReturnObjectToDecimal(mods.iTaxUnitPrice / (1 + mods.iTaxRate / 100), 6);
                    mods.cexch_name = "人民币";
                    mods.ivouchrowno = iRow;
                    mods.cbodymemo = gridView1.GetRowCellDisplayText(i, gridCol表体备注).ToString().Trim();
                    mods.cbsysbarcode = @"||putj|" + mod.ccode + @"|" + mods.ivouchrowno.ToString();

                    mods.dstartdate = BaseFunction.ReturnDate(DateTime.Today.ToString("yyyy-MM-dd"));

                    DAL.PU_PriceJustDetail dals = new Purchase.DAL.PU_PriceJustDetail();
                    sSQL = dals.Add(mods);
                    aList.Add(sSQL);

                    Model.Ven_Inv_Price modInv = new Purchase.Model.Ven_Inv_Price();
                    modInv.cVenCode = mods.cvencode;
                    modInv.cInvCode = mods.cinvcode;
                    modInv.dEnableDate = ReturnObjectToDatetime(mods.dstartdate);
                    modInv.cExch_Name = mods.cexch_name;
                    modInv.bPromotion = 0;
                    modInv.iSupplyType = ReturnObjectToInt(mod.iSupplyType);
                    modInv.btaxcost = 1;
                    modInv.iLowerLimit = 0;
                    modInv.iUnitPrice = Convert.ToDecimal(mods.iUnitPrice);
                    modInv.iTaxRate = Convert.ToDecimal(mods.iTaxRate);
                    modInv.iTaxUnitPrice = Convert.ToDecimal(mods.iTaxUnitPrice);


                    sSQL = "select max(ipriceautoid) from @u8.ven_inv_price";
                    long l = ReturnObjectToLong(clsSQLCommond.ExecGetScalar(sSQL));

                    DAL.Ven_Inv_Price dalInv = new Purchase.DAL.Ven_Inv_Price();
                    sSQL = dalInv.Exists(modInv);
                    DataTable dtInvPrice = clsSQLCommond.ExecQuery(sSQL);
                    if (ReturnObjectToInt(dtInvPrice.Rows.Count) == 0)
                    {
                        l += 1;
                        modInv.ipriceautoid = l;

                        sSQL = dalInv.Add(modInv);
                        aList.Add(sSQL);
                    }
                    else
                    {
                        modInv.Autoid = ReturnObjectToInt(dtInvPrice.Rows[0]["autoid"]);
                        sSQL = dalInv.Update(modInv);
                        aList.Add(sSQL);
                    }


                    bHas = true;
                }

                if (!bHas)
                {
                    throw new Exception("没有需要保存的行");
                }

                sSQL = @"
update @u8.VoucherHistory set cNumber='aaaaaa' Where  CardNumber='PU03' and cContent is NULL
";
                sSQL = sSQL.Replace("aaaaaa", lCode.ToString());
                aList.Add(sSQL);


                if (lID > 1000000000)
                {
                    lID = lID - 1000000000;
                }
                if (lIDs > 1000000000)
                {
                    lIDs = lIDs - 1000000000;
                }
                sSQL = "update UFSystem..UA_Identity set iFatherId = " + lID.ToString() + ",iChildId = " + lIDs + " where cAcc_Id = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3) + "' and cVouchType = 'puprice'";
                aList.Add(sSQL);

                if (aList.Count > 0)
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("保存成功！\n" + mod.ccode);
                    ((DataTable)gridControl1.DataSource).Rows.Clear();
                }
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
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

        private void Frm采购调价单_Load(object sender, EventArgs e)
        {
            try
            {
                SetLookUp();

            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败！\n\t原因：" + ee.Message);
            }
        }

        private void SetLookUp()
        {
            string sSQL = @"
select cInvCode ,cInvName,cInvStd
from @u8.Inventory
order by cInvCode
";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEditcInvName.DataSource = dt;
            ItemLookUpEditcInvStd.DataSource = dt;

            sSQL = @"
select cVenCode,cVenName from @u8.vendor order by cVenCode
";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEditcVenName.DataSource = dt;
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for(int i=0;i<gridView1.RowCount;i++)
                {
                    gridView1.SetRowCellValue(i,gridCol选择,chkAll.Checked);
                }
            }
            catch(Exception ee)
            {
            
            }
        }
    }
}