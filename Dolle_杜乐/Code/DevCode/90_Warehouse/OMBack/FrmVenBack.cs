using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using DevExpress.XtraEditors;
using FrameBaseFunction;


namespace Warehouse
{
    public partial class FrmVenBack :FrameBaseFunction.Frm列表窗体模板
    {
        FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();
        string SQL = "";
        DataTable DTSource = new DataTable();
        ArrayList aList;
        public FrmVenBack()
        {
            InitializeComponent();

            SQL = @"
                 SET nocount  ON 
                 SELECT m.cCode ,
                        substring(convert(nvarchar(30),m.dDate,120),1,10) as dDate,
                        d.MODetailsID ,
                        v.cVenCode ,
                        v.cVenName ,
                        I.cInvCode ,
                        I.cInvName ,
                        I.cInvAddCode ,
                        I.cInvStd ,
                        D.iNum AS iNum ,
                        d.iUnitPrice ,
                        d.iMoney ,
                        d.dStartDate ,
                        d.dArriveDate ,
                        CAST(NULL AS DECIMAL(18, 6)) AS BackQty ,
                        CAST(NULL AS DECIMAL(18, 6)) AS BackUnitQty ,
                        CAST(NULL AS DECIMAL(18, 6)) as BackNum,
                        CAST(d.iQuantity as DECIMAL(18, 6)) AS UnitQty 
                        ,d.cItemCode, 
                         CAST(OD.fBaseQtyD/ OD.fBaseQtyN as DECIMAL(18, 6)) AS BOMQty ,
                         CAST(OD.iSendNum as DECIMAL(18, 6)) as iSendNum,
    
                        CAST(((ISNULL(d.iReceivedQTY ,0) +ISNULL (d.iArrQTY,0))/(OD.fBaseQtyD / OD.fBaseQtyN)) as DECIMAL(18, 6)) AS HaveUsedQty,
                        cast(OD.iSendQty - ((ISNULL(d.iReceivedQTY ,0) +ISNULL (d.iArrQTY,0))/(OD.fBaseQtyD / OD.fBaseQtyN )) as decimal(18,6)) AS RemainQty,

                        cast(case when OD.iSendNum =0  then 0 else  (OD.iSendQty - ((ISNULL(d.iReceivedQTY ,0) +ISNULL (d.iArrQTY,0))/(OD.fBaseQtyD/ OD.fBaseQtyN )))*(OD.iSendNum/ OD.iSendQty) end as decimal(18,6)) as RemainNum,
                        CAST(OD.iQuantity AS DECIMAL(18, 6)) AS iQuantity ,
                        ( ISNULL(isendqty, 0) - ISNULL(iComplementQty, 0) ) iSendQty ,
                        CAST(( ( ISNULL(isendqty, 0) - ISNULL(iComplementQty, 0) ) ) / (OD.fBaseQtyD / OD.fBaseQtyN) as DECIMAL(18, 6)) AS iSendUnitQty ,
                        IP.cInvCode AS PInvCode ,
                        IP.cInvName AS PInvName ,
                        cast(OD.MOMaterialsID as varchar(50)) as MOMaterialsID,
                        '111111' as MakerName,
                        substring(convert(nvarchar(30),getdate(),120),1,10) as MakeDate ,
                        CAST(case when isnull(OD.iSendNum,0)=0 then null else OD.iSendQty/OD.iSendNum end as DECIMAL(18, 6)) as CRate
  
                  FROM   dbo.OM_MOMain M
                        LEFT JOIN dbo.Vendor V ON M.cVenCode = V.cVenCode
                        LEFT JOIN dbo.OM_MODetails D ON M.MOID = D.MOID
                        LEFT JOIN dbo.OM_MOMaterials OD ON d.MODetailsID = od.MoDetailsID
                        LEFT JOIN dbo.Inventory I ON OD.cInvCode = I.cInvCode
                        LEFT JOIN dbo.Inventory IP ON D.cInvCode = IP.cInvCode
                 WHERE  1=1 
                        AND ( ISNULL(CBUSTYPE, '') = '委外加工' )
                        AND ( NOT ( ISNULL(cverifier, N'') = N'' )
                              AND ISNULL(cbcloser, N'') = N''
                              AND ISNULL(cbustype, N'') <> N'直运采购'
                            )
                        AND D.cbCloser IS NULL
                        AND OD.iSendQty - ((ISNULL(d.iReceivedQTY ,0) +ISNULL (d.iArrQTY,0))*(OD.fBaseQtyN / OD.fBaseQtyD ))>0
                            
            ";
            SQL = SQL.Replace("111111", FrameBaseFunction.ClsBaseDataInfo.sUserName);
            SQL = string.Format(SQL, FrameBaseFunction.ClsBaseDataInfo.sUserName);
        }

        private void GetOMBills()
        {
            string filter = "";
            if (txtVenCode.Text == "" ||SQL =="")
                return;
            filter = " 1=1 and M.cVenCode='" + txtVenCode.Text + "' ";
            if(!chk含AK订单.Checked)
                filter = filter + " and m.cCode not like 'AK%' ";

            string sql = filter == "" ? SQL : SQL.Replace("1=1", filter);
            DTSource = SqlHelper.ExecuteDataset(Assistanter.U8ConnectString, CommandType.Text, sql).Tables[0];
            grdDetail.DataSource = DTSource;
        }


        protected override void BtnClick(string sBtnName, string sBtnText)
        {
            try
            {
                switch (sBtnName.ToLower())
                {
                    case "alter":
                        GenBackForm();
                        break;
                    case "sel":
                        GetOMBills();
                        break;
                    case "export":
                        Export();
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

        private void Export()
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "*.xls|*.xls";
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            grvDetail.ExportToXls(dlg.FileName);
            MessageBox.Show("完成");
        }


        private void GenBackForm()
        {
            grvDetail.PostEditor();
            this.Validate();
            aList = new ArrayList();
            string msg = "";
            bool isHaveQty = false;

            decimal dBackSum = 0;
            for (int i = 0; i < grvDetail.RowCount; i++)
            {
                decimal backQty = grvDetail.GetRowCellValue(i, colBackQty) == null || grvDetail.GetRowCellValue(i, colBackQty).ToString() == "" ? 0 : decimal.Parse(grvDetail.GetRowCellValue(i, colBackQty).ToString());
                decimal iSendQty = grvDetail.GetRowCellValue(i, colSendQty) == null || grvDetail.GetRowCellValue(i, colSendQty).ToString() == "" ? 0 : decimal.Parse(grvDetail.GetRowCellValue(i, colSendQty).ToString());
                if (backQty > 0)
                    isHaveQty = true;

                dBackSum = dBackSum + backQty;

                if (backQty > iSendQty)
                {
                    msg += "第" + (i + 1) + "行,退货数量大于剩余数量";
                }
                else if (backQty > iSendQty)
                {
                    msg += "第" + (i + 1) + "行,退货数量大于已发料数量";
                }
            }

            if (!isHaveQty )
            {
                MessageBox.Show("没有需要退货的数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (msg != "")
            {
                MessageBox.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            DataTable dtPrint = DTSource.Clone();

            foreach (DataRow row in DTSource.Rows)
            {
                string backcQty = row["BackQty"].ToString();

                if (backcQty == "")
                    continue;
                if (decimal.Parse(backcQty) == 0)
                    continue;
                dtPrint.ImportRow(row);
            }

            DataColumn colBarCode = new DataColumn("BarCode");
            dtPrint.Columns.Add(colBarCode);

            DataColumn colRowCount = new DataColumn("Row_Count");
            dtPrint.Columns.Add(colRowCount);


            DataColumn coldBackSum = new DataColumn("dBackSum");
            dtPrint.Columns.Add(coldBackSum);

            foreach (DataRow row in dtPrint.Rows)
            {
                string iSendQty = row["iSendQty"].ToString();
                string iSendNum = row["iSendNum"].ToString();
                decimal changeRate = 0;
                if (iSendNum != "")
                {
                    decimal sendNum = decimal.Parse(iSendNum);
                    decimal sendQty = decimal.Parse(iSendQty);
                    changeRate = sendNum / sendQty;
                    changeRate = ReturnObjectToDecimal(changeRate, 6);
                }

                string backNum = changeRate == 0 ?"0" : (Math.Round (decimal.Parse(row["BackQty"].ToString()) * changeRate,6)).ToString();
                string barCode = "4$" + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Split('_'))[1] + "$" + row["MOMaterialsID"].ToString()
                    + "$" + Math.Round ( decimal.Parse (row["BackQty"].ToString()),4).ToString () + "$" + Math.Round (decimal.Parse (backNum),6).ToString ();
                row["BarCode"] = barCode;
                row["Row_Count"] = dtPrint.Rows.Count.ToString();
                row["dBackSum"] = dBackSum.ToString();
            }
            SubReport fm = new SubReport();

            //无法在打印表中增加字段＂cItemCode＂，使用MOMaterialsID代替
            for (int i = 0; i < dtPrint.Rows.Count; i++)
            {
                dtPrint.Rows[i]["MOMaterialsID"] = dtPrint.Rows[i]["cItemCode"];
            }
            fm.DataSource = dtPrint;

            fm.DataMember = dtPrint.TableName;
            fm.ShowPreviewDialog();

        }

        private void FormVenBack_Load(object sender, EventArgs e)
        {
            try
            {
                LoadVenLists();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void LoadVenLists()
        {
            try
            {
                string sSQL = "select vendCode,cVenName from UFDLImport.._vendUid left join @u8.Vendor on @u8.Vendor.cVenCode = vendCode where uid = '" + FrameBaseFunction.ClsBaseDataInfo.sUid + "'  and accid = 200 and accyear = " + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + " ";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);

                txtVenCode.Properties.ReadOnly = false;
                if (FrameBaseFunction.ClsBaseDataInfo.sUid == "admin" || dt.Rows.Count == 0)
                {
                    txtVenCode.Enabled = true;
                }
                else
                {
                    if (dt.Rows[0]["vendCode"].ToString().Trim() == string.Empty)
                    {
                        txtVenCode.Enabled = true;
                    }
                    else
                    {
                        txtVenCode.Enabled = false;
                    }
                    txtVenCode.Text = dt.Rows[0]["vendCode"].ToString().Trim();
                    txtVenCode_Leave(null, null);
                }
                GetOMBills();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败！\n\t原因：" + ee.Message);
            }
        }

        private void txtVenCode_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtVenCode.Text == "")
                    return;
                DataTable dt = GetVendor(txtVenCode.Text.Trim());
                if (dt != null && dt.Rows.Count > 0)
                {
                    txtVenName.Text = dt.Rows[0]["iText"].ToString().Trim();
                    GetOMBills();
                }
                else
                {
                    txtVenCode.Text = "";
                    txtVenName.Text = "";
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得供应商信息失败！ " + ee.Message);
            }
        }


        private DataTable GetVendor(string sVenCode)
        {
            try
            {
                FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();
                string sSQL = "select cVenCode as iID,cVenName as iText from @u8.Vendor where cVenCode = '" + sVenCode + "' order by cVenCode";
                DataTable dt = clsGetSQL.GetLookUpEdit(sSQL);
                return dt;
            }
            catch
            {
                throw new Exception("获得供应商信息失败！");
            }
        }

        private void grvDetail_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                if (e.RowHandle >= 0)
                {
                    DateTime d1=new DateTime();
                    if (grvDetail.GetRowCellValue(e.RowHandle, colArriveDate).ToString().Trim() != "")
                        d1 = DateTime.Parse(DateTime.Parse(grvDetail.GetRowCellValue(e.RowHandle, colArriveDate).ToString()).ToString("yyyy-MM-dd"));
                    //else if (grvDetail.GetRowCellValue(e.RowHandle, gridColumn20).ToString().Trim() != "")
                    //    d1 = DateTime.Parse(DateTime.Parse(grvDetail.GetRowCellValue(e.RowHandle, gridColumn20).ToString()).ToString("yyyy-MM-dd"));
                    //else
                    //    d1 = DateTime.Parse(DateTime.Parse(grvDetail.GetRowCellValue(e.RowHandle, gridColumn13).ToString()).ToString("yyyy-MM-dd"));

                    if (d1 < DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate))
                    {
                        e.Appearance.BackColor = Color.Tomato;
                    }
                }
            }
            catch
            { }
        }

        private void LookUpWH_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void rpiBackQty_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                decimal qty = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal((sender as TextEdit).Text.Trim());
                decimal remainQty = decimal.Parse(grvDetail.GetRowCellValue(grvDetail.FocusedRowHandle, colRemainQty).ToString());
                if (qty > remainQty)
                {
                    MessageBox.Show("输入的退货数量大于剩余数量", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    grvDetail.SetRowCellValue(grvDetail.FocusedRowHandle, colBackQty, null);
                    return;
                }
                decimal bomQty = (decimal)grvDetail.GetRowCellValue(grvDetail.FocusedRowHandle, colBOMQty);
                decimal unitQty = qty / bomQty;
                grvDetail.SetRowCellValue(grvDetail.FocusedRowHandle, colBackUnitQty, unitQty);



                decimal iSendQty = decimal.Parse(grvDetail.GetRowCellValue(grvDetail.FocusedRowHandle, colSendQty) == null || grvDetail.GetRowCellValue(grvDetail.FocusedRowHandle, colSendQty).ToString() == "" ?
                    "0" : grvDetail.GetRowCellValue(grvDetail.FocusedRowHandle, colSendQty).ToString());
                decimal iSendNum = decimal.Parse(grvDetail.GetRowCellValue(grvDetail.FocusedRowHandle, colSendNum) == null || grvDetail.GetRowCellValue(grvDetail.FocusedRowHandle, colSendNum).ToString() == "" ?
                    "0" : grvDetail.GetRowCellValue(grvDetail.FocusedRowHandle, colSendNum).ToString());
                decimal cRate = iSendNum == 0 ? 0 : iSendNum / iSendQty;
                if (cRate == 0)
                {
                    //MessageBox.Show("换算率为0,无法执行自动换算", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    decimal backNum = Math.Round(qty * cRate, 6);
                    grvDetail.SetRowCellValue(grvDetail.FocusedRowHandle, colBackNum, backNum);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void rpiBackUnitQty_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                decimal qty = decimal.Parse((sender as TextEdit).Text);
                decimal bomQty = (decimal)grvDetail.GetRowCellValue(grvDetail.FocusedRowHandle, colBOMQty);
                decimal backQty = qty * bomQty;


                grvDetail.SetRowCellValue(grvDetail.FocusedRowHandle, colBackQty, backQty);


                decimal iSendQty = decimal.Parse(grvDetail.GetRowCellValue(grvDetail.FocusedRowHandle, colSendQty) == null || grvDetail.GetRowCellValue(grvDetail.FocusedRowHandle, colSendQty).ToString() == "" ?
                    "0" : grvDetail.GetRowCellValue(grvDetail.FocusedRowHandle, colSendQty).ToString());
                decimal iSendNum = decimal.Parse(grvDetail.GetRowCellValue(grvDetail.FocusedRowHandle, colSendNum) == null || grvDetail.GetRowCellValue(grvDetail.FocusedRowHandle, colSendNum).ToString() == "" ?
                    "0" : grvDetail.GetRowCellValue(grvDetail.FocusedRowHandle, colSendNum).ToString());
                decimal cRate = iSendQty / (iSendNum == 0 ? 1 : iSendNum);
                if (cRate == 0)
                {
                    //MessageBox.Show("换算率为0,无法执行自动换算", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    decimal backNum = Math.Round(backQty * cRate, 6);
                    grvDetail.SetRowCellValue(grvDetail.FocusedRowHandle, colBackNum, backNum);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void txtVenCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FrmVenInfo fVen = new FrmVenInfo(txtVenCode.Text.Trim());
            if (DialogResult.OK == fVen.ShowDialog())
            {
                txtVenCode.Text = fVen.sVenCode;
                txtVenName.Text = fVen.sVenName;
            }
        }

        private void grvDetail_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

        private void rpiBackNum_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                decimal qty = decimal.Parse((sender as TextEdit).Text);
                decimal iSendQty = decimal.Parse(grvDetail.GetRowCellValue(grvDetail.FocusedRowHandle, colSendQty) == null || grvDetail.GetRowCellValue(grvDetail.FocusedRowHandle, colSendQty).ToString() == "" ?
                    "0" : grvDetail.GetRowCellValue(grvDetail.FocusedRowHandle, colSendQty).ToString());
                decimal iSendNum = decimal.Parse(grvDetail.GetRowCellValue(grvDetail.FocusedRowHandle, colSendNum) == null || grvDetail.GetRowCellValue(grvDetail.FocusedRowHandle, colSendNum).ToString() == "" ?
                    "0" : grvDetail.GetRowCellValue(grvDetail.FocusedRowHandle, colSendNum).ToString());
                decimal cRate = iSendNum == 0 ? 0 : iSendQty / iSendNum;
                if (cRate == 0 || iSendNum == 0)
                {
                    MessageBox.Show("换算率为0,无法执行自动换算", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    grvDetail.SetRowCellValue(grvDetail.FocusedRowHandle, colBackNum, null);

                    return;
                }

                decimal remainQty = decimal.Parse(grvDetail.GetRowCellValue(grvDetail.FocusedRowHandle, colRemainQty).ToString());
                decimal backQty = Math.Round(qty / cRate, 6);

                if (backQty > remainQty)
                {
                    MessageBox.Show("输入的退货数量大于剩余数量", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    grvDetail.SetRowCellValue(grvDetail.FocusedRowHandle, colBackNum, null);
                    grvDetail.SetRowCellValue(grvDetail.FocusedRowHandle, colBackQty, null);
                    grvDetail.SetRowCellValue(grvDetail.FocusedRowHandle, colBackUnitQty, null);
                    return;
                }

                grvDetail.SetRowCellValue(grvDetail.FocusedRowHandle, colBackQty, backQty);

                decimal bomQty = (decimal)grvDetail.GetRowCellValue(grvDetail.FocusedRowHandle, colBOMQty);
                decimal unitQty = backQty / bomQty;
                grvDetail.SetRowCellValue(grvDetail.FocusedRowHandle, colBackUnitQty, unitQty);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}
