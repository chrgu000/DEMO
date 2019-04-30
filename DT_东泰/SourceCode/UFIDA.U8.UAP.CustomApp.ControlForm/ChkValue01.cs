using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using TH.BaseClass;
using System.Data.SqlClient;
using System.Collections;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class ChkValue01 : UserControl
    {
        TH.BaseClass.GetBaseData getBaseData = new GetBaseData();

        string sProPath = Application.StartupPath;

        //UFIDA.U8.UAP.CustomApp.ControlForm.RepBaseGrid Rep = new RepBaseGrid();

        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }


        public ChkValue01()
        {
            InitializeComponent();
        }

        int i序号范围 = 30;

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {

                DbHelperSQL.connectionString = Conn;
                SetEnable(false);
                SetTxtNull();
                Setlookup();

            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "加载窗体失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
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


        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "xls";
                sF.FileName = this.Text;
                sF.Filter = "Excel(*.xls)|*.xls|All files(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK == dRes)
                {
                    gridView1.ExportToXls(sF.FileName);
                    MessageBox.Show("OK\n\tPath：" + sF.FileName);
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "Export Excel Err";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }



        private void Setlookup()
        {
            string sSQL = @"
select distinct a.MoCode as 生产订单号
from mom_order a inner join mom_orderdetail b on a.moid = b.moid
where b.[Status] = 3
order by a.MoCode
";
            DataTable dt = DbHelperSQL.Query(sSQL);
            lookUpEdit生产订单号.Properties.DataSource = dt;

            dt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "序号";
            dc.DataType = Type.GetType("System.Int32");
            dt.Columns.Add(dc);


            for (int i = 1; i <= i序号范围; i++)
            {
                DataRow dr = dt.NewRow();
                dr["序号"] = i;
                dt.Rows.Add(dr);
            }
            lookUpEdit_序号.Properties.DataSource = dt;

            sSQL = @"
select distinct sCode ,sOrder
from  _TH_Code
where iType = 1 
order by sOrder,sCode
";
            dt = DbHelperSQL.Query(sSQL);
            lookUpEdit工序.Properties.DataSource = dt;

            sSQL = @"
select distinct sCode ,sOrder
from  _TH_Code
where iType = 2
order by sOrder,sCode
";
            dt = DbHelperSQL.Query(sSQL);
            lookUpEdit班组 .Properties.DataSource = dt;
        }

        private void SetTxtNull()
        {
            txtcCode.EditValue = DBNull.Value;
            dtmCode.EditValue = DBNull.Value;

            lookUpEdit生产订单号.EditValue = DBNull.Value;
            txt存货编码.EditValue = DBNull.Value;
            txt存货名称.EditValue = DBNull.Value;
            txt产品规格.EditValue = DBNull.Value;
            txt生产批号.EditValue = DBNull.Value;
            txt磁粉性能.EditValue = DBNull.Value;
            txt模具号.EditValue = DBNull.Value;
            txt图号.EditValue = DBNull.Value;
            dtm生产日期.EditValue = DBNull.Value;
            lookUpEdit班组.EditValue = DBNull.Value;
            lookUpEdit工序.EditValue = DBNull.Value;

            txt备注.EditValue = DBNull.Value;


            lookUpEdit_检验项目.Properties.DataSource = null;
            txt_检验值.EditValue = DBNull.Value;

            gridControl1.DataSource = null;
            gridControl高度.DataSource = null;
            gridControl外径.DataSource = null;

            txt单重.EditValue = DBNull.Value;
           
            txt共.EditValue = DBNull.Value;

            txt万件.EditValue = DBNull.Value;
       
            txt共份数.EditValue = DBNull.Value;

            txt挑选高.EditValue = DBNull.Value;
            txt挑选低.EditValue = DBNull.Value;
            txt挑选破口.EditValue = DBNull.Value;

            txt固化后废品.EditValue = DBNull.Value;
            txt未固化废品.EditValue = DBNull.Value;
            txt回粉.EditValue = DBNull.Value;

            txtMoDid.EditValue = DBNull.Value;

            txt不合格数量.EditValue = DBNull.Value;
            txt不合格单件.EditValue = DBNull.Value;
            txt不合格万件.EditValue = DBNull.Value;

            txt制单人.EditValue = DBNull.Value;
            dtm制单日期.EditValue = DBNull.Value;
            txt审核人.EditValue = DBNull.Value;
            dtm审核日期.EditValue = DBNull.Value;

            txt万件个.EditValue = DBNull.Value;
            txtPCS.EditValue = DBNull.Value;
        }

        private void SetEnable(bool b)
        {
            lookUpEdit生产订单号.Enabled = b;
            txt存货编码.Enabled = b;
            txt存货名称.Enabled = b;
            txt产品规格.Enabled = b;
            txt生产批号.Enabled = b;
            txt磁粉性能.Enabled = b;
            txt模具号.Enabled = b;
            txt图号.Enabled = b;
            dtm生产日期.Enabled = b;
            lookUpEdit班组.Enabled = b;
            lookUpEdit工序.Enabled = b;
            txt备注.Enabled = b;

            lookUpEdit_检验项目.Enabled = b;
            lookUpEdit_序号.Enabled = b;
            txt_检验值.Enabled = b;

            gridView1.OptionsBehavior.ReadOnly = !b;
            gridView1.OptionsBehavior.Editable = b;

            gridView高度.OptionsBehavior.ReadOnly = !b;
            gridView高度.OptionsBehavior.Editable = b;

            gridView外径.OptionsBehavior.ReadOnly = !b;
            gridView外径.OptionsBehavior.Editable = b;


            txt单重.Enabled = b;
      

            txt共.Enabled = b;

            txt万件.Enabled = b;

            txt共份数.Enabled = b;

            txt挑选高.Enabled = b;
            txt挑选低.Enabled = b;
            txt挑选破口.Enabled = b;

            txt固化后废品.Enabled = b;
            txt未固化废品.Enabled = b;
            txt回粉.Enabled = b;

            txt不合格单件.Enabled = b;
            txt不合格数量.Enabled = b;
            txt不合格万件.Enabled = b;

            btnLoad.Enabled = false;
            btnEnter.Enabled = b;
            txtPCS.Enabled = b;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string sSQL = @"
select * from [_TH_ChkValue01] where cCode = '{0}'
";
                sSQL = string.Format(sSQL, txtcCode.Text.Trim());
                DataTable dt = DbHelperSQL.Query(sSQL);
                if (dt == null || dt.Rows.Count == 0)
                {
                    throw new Exception("单据信息获取失败");
                }

                string sAudit = dt.Rows[0]["AuditUid"].ToString().Trim();
                if (sAudit != "")
                {
                    throw new Exception("已审核");
                }
                else
                {

                    SetEnable(true);
                }

                sSQL = @"
select citemcode as 检验项目编码,citemname as 检验项目
from [dbo].[_sospInvCheck]
where cInvCode = '{0}'
     and (citemname not like '%高度%' and citemname not like '%平行度%' and citemname not like '%外径%' and citemname not like '%圆度%')
order by citemcode

";
                sSQL = string.Format(sSQL, txt存货编码.Text.Trim());
                DataTable dt检验 = DbHelperSQL.Query(sSQL);
                lookUpEdit_检验项目.Properties.DataSource = dt检验;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
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
                try
                {
                    gridView外径.FocusedRowHandle -= 1;
                    gridView外径.FocusedRowHandle += 1;
                }
                catch { }
                try
                {
                    gridView高度.FocusedRowHandle -= 1;
                    gridView高度.FocusedRowHandle += 1;
                }
                catch { }

                string sErr = "";

                if (gridView1.RowCount == 0)
                {
                    throw new Exception("请加载数据");
                }

                if (lookUpEdit工序.EditValue == null || lookUpEdit工序.Text.Trim() == "")
                {
                    throw new Exception("工序不能为空");
                }

                if (lookUpEdit班组.EditValue == null || lookUpEdit班组.Text.Trim() == "")
                {
                    throw new Exception("班组不能为空");
                }

                for (int i = 0; i < gridView1.RowCount; i++)                {
                    JS(i);
                }
                for (int i = 0; i < gridView外径.RowCount; i++)
                {
                    JS_W(i);
                }
                for (int i = 0; i < gridView高度.RowCount; i++)
                {
                    JS_G(i);
                }

                int iCou = 0;


                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    string sSQL = "";


                    sSQL = @"select getdate()";
                    DateTime dtmNow = BaseFunction.ReturnDate(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);

                    string sCode = txtcCode.Text.Trim();
                    if (sCode == "")
                    {
                        //单据号
                        sSQL = @"
select isnull(max(cCode),0) as cCode
from [dbo].[_TH_ChkValue01]
where cCode like '{0}%'
";
                        sSQL = string.Format(sSQL, "JY" + dtmNow.ToString("yyMM"));
                        DataTable dtCode = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        sCode = dtCode.Rows[0][0].ToString().Trim();
                        if (sCode == "0" || sCode == "")
                        {
                            sCode = "JY" + dtmNow.ToString("yyMM") + "000001";
                        }
                        else
                        {
                            long iCode = BaseFunction.ReturnLong(sCode.Substring(6));
                            sCode = "JY" + dtmNow.ToString("yyMM") + (iCode + 1).ToString().PadLeft(6, '0');
                        }
                    }

                    sSQL = "select * from _TH_ChkValue01 where cCode = '{0}'";
                    sSQL = string.Format(sSQL, txtcCode.Text.Trim());
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt != null && dt.Rows.Count > 0 && dt.Rows[0]["AuditUid"].ToString().Trim() != "")
                    {
                        throw new Exception("单据已经审核，不能保存");
                    }

                    sSQL = @"
delete  _TH_ChkValue01 where cCode = '{0}';
delete  _TH_ChkValues01 where cCode = '{0}';

";
                    sSQL = string.Format(sSQL, txtcCode.Text.Trim());
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);


                    Model._TH_ChkValue01 mod = new UFIDA.U8.UAP.CustomApp.ControlForm.Model._TH_ChkValue01();
                    mod.WONo = lookUpEdit生产订单号.Text.Trim();
                    if (mod.WONo == "")
                        throw new Exception("保存数据失败:没有生产订单号");
                    mod.cCode = sCode;
                    mod.dtmCode = dtmNow;

                    mod.WORow = BaseFunction.ReturnInt(txtWORow.Text.Trim());
                    mod.MODid = BaseFunction.ReturnLong(txtMoDid.Text.Trim());
                    mod.WorkGroup = lookUpEdit班组.Text.Trim();
                    mod.WOBatch = txt生产批号.Text.Trim();
                    mod.WOMould = txt模具号.Text.Trim();
                    mod.WODate = dtm生产日期.DateTime;
                    mod.cInvCode = txt存货编码.Text.Trim();
                    mod.cInvName = txt存货名称.Text.Trim();
                    mod.cInvStd = txt产品规格.Text.Trim();
                    mod.cInvPerformance = txt磁粉性能.Text.Trim();
                    mod.cInvDraw = txt图号.Text.Trim();

                    mod.WorkProcess = lookUpEdit工序.EditValue.ToString().Trim();

                    mod.QtyDZ = BaseFunction.ReturnDecimal(txt单重.Text.Trim());
                    mod.QtyG = BaseFunction.ReturnDecimal(txt共.Text.Trim());
                    mod.QtyWJ = BaseFunction.ReturnDecimal(txt万件.Text.Trim());
                    mod.QtyGFS = BaseFunction.ReturnDecimal(txt共份数.Text.Trim());
                    mod.QtyTXG = BaseFunction.ReturnDecimal(txt挑选高.Text.Trim());
                    mod.QtyTXD = BaseFunction.ReturnDecimal(txt挑选低.Text.Trim());
                    mod.QtyTXPK = BaseFunction.ReturnDecimal(txt挑选破口.Text.Trim());
                    mod.QtyGH = BaseFunction.ReturnDecimal(txt固化后废品.Text.Trim());
                    mod.QtyWGH = BaseFunction.ReturnDecimal(txt未固化废品.Text.Trim());
                    mod.QtyHF = BaseFunction.ReturnDecimal(txt回粉.Text.Trim());
                    mod.QtyUn1 = BaseFunction.ReturnDecimal(txt不合格数量.Text.Trim());
                    mod.QtyUn2 = BaseFunction.ReturnDecimal(txt不合格万件.Text.Trim());
                    mod.QtyUn3 = BaseFunction.ReturnDecimal(txt不合格单件.Text.Trim());
                    mod.Remark = txt备注.Text.Trim();
                    mod.Qtypcs = BaseFunction.ReturnDecimal(txtPCS.Text.Trim());


                    txt制单人.Text = sUserName;
                    dtm制单日期.EditValue = DateTime.Now;


                    mod.CreatUid = txt制单人.Text;
                    mod.dtmCreate = dtm制单日期.DateTime;



                    DAL._TH_ChkValue01 dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._TH_ChkValue01();
                    sSQL = dal.Add(mod);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    sSQL = "delete   _TH_ChkValues01 where cCode = '{0}'";
                    sSQL = string.Format(sSQL, BaseFunction.ReturnLong(txtMoDid.Text.Trim()), txtcCode.Text.Trim());
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (gridView1.GetRowCellValue(i, gridCol检验项目编码).ToString().Trim() == "")
                            continue;

                        Model._TH_ChkValues01 mods = new UFIDA.U8.UAP.CustomApp.ControlForm.Model._TH_ChkValues01();
                        mods.cCode = mod.cCode;
                        mods.WorkGroup = mod.WorkGroup;
                        mods.WorkProcess = mod.WorkProcess;
                        mods.WONo = mod.WONo;
                        mods.MODid = mod.MODid;
                        mods.chkItemCode = gridView1.GetRowCellValue(i, gridCol检验项目编码).ToString().Trim();
                        mods.chkItemName = gridView1.GetRowCellValue(i, gridCol检验项目).ToString().Trim();

                        mods.chkMax = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol上限));
                        mods.chkMin = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol下限));

                        mods.PassOrNG = BaseFunction.ReturnBool(gridView1.GetRowCellValue(i, gridCol判定));

                        if (BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColVal01)) > 0)
                        {
                            mods.chkValue01 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColVal01));
                        }
                        if (BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColVal02)) > 0)
                        {
                            mods.chkValue02 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColVal02));
                        }
                        if (BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColVal03)) > 0)
                        {
                            mods.chkValue03 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColVal03));
                        }
                        if (BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColVal04)) > 0)
                        {
                            mods.chkValue04 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColVal04));
                        }
                        if (BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColVal05)) > 0)
                        {
                            mods.chkValue05 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColVal05));
                        }
                        if (BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColVal06)) > 0)
                        {
                            mods.chkValue06 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColVal06));
                        }
                        if (BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColVal07)) > 0)
                        {
                            mods.chkValue07 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColVal07));
                        }
                        if (BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColVal08)) > 0)
                        {
                            mods.chkValue08 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColVal08));
                        }
                        if (BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColVal09)) > 0)
                        {
                            mods.chkValue09 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColVal09));
                        }
                        if (BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColVal10)) > 0)
                        {
                            mods.chkValue10 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColVal10));
                        }
                        if (BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColVal11)) > 0)
                        {
                            mods.chkValue11 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColVal11));
                        }
                        if (BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColVal12)) > 0)
                        {
                            mods.chkValue12 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColVal12));
                        }
                        if (BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColVal13)) > 0)
                        {
                            mods.chkValue13 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColVal13));
                        }
                        if (BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColVal14)) > 0)
                        {
                            mods.chkValue14 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColVal14));
                        }
                        if (BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColVal15)) > 0)
                        {
                            mods.chkValue15 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColVal15));
                        }
                        if (BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColVal16)) > 0)
                        {
                            mods.chkValue16 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColVal16));
                        }
                        if (BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColVal17)) > 0)
                        {
                            mods.chkValue17 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColVal17));
                        }
                        if (BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColVal18)) > 0)
                        {
                            mods.chkValue18 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColVal18));
                        }
                        if (BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColVal19)) > 0)
                        {
                            mods.chkValue19 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColVal19));
                        }
                        if (BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColVal20)) > 0)
                        {
                            mods.chkValue20 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColVal20));
                        }
                        if (BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColVal21)) > 0)
                        {
                            mods.chkValue21 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColVal21));
                        }
                        if (BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColVal22)) > 0)
                        {
                            mods.chkValue22 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColVal22));
                        }
                        if (BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColVal23)) > 0)
                        {
                            mods.chkValue23 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColVal23));
                        }
                        if (BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColVal24)) > 0)
                        {
                            mods.chkValue24 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColVal24));
                        }
                        if (BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColVal25)) > 0)
                        {
                            mods.chkValue25 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColVal25));
                        }
                        if (BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColVal26)) > 0)
                        {
                            mods.chkValue26 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColVal26));
                        }
                        if (BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColVal27)) > 0)
                        {
                            mods.chkValue27 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColVal27));
                        }
                        if (BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColVal28)) > 0)
                        {
                            mods.chkValue28 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColVal28));
                        }
                        if (BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColVal29)) > 0)
                        {
                            mods.chkValue29 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColVal29));
                        }
                        if (BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColVal30)) > 0)
                        {
                            mods.chkValue30 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColVal30));
                        }
                        mods.Remark = gridView1.GetRowCellValue(i, gridColRemark).ToString().Trim();
                        DAL._TH_ChkValues01 dals = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._TH_ChkValues01();
                        sSQL = dals.Add(mods);
                        iCou += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    #region MyRegion 高度

                    for (int i = 0; i < gridView高度.RowCount; i++)
                    {
                        if (gridView高度.GetRowCellValue(i, gridCol_检验项目编码).ToString().Trim() == "")
                            continue;

                        Model._TH_ChkValues01 mods = new UFIDA.U8.UAP.CustomApp.ControlForm.Model._TH_ChkValues01();

                        mods.cCode = mod.cCode;
                        mods.WorkGroup = mod.WorkGroup;
                        mods.WorkProcess = mod.WorkProcess;
                        mods.WONo = mod.WONo;
                        mods.MODid = mod.MODid;
                        mods.chkItemCode = gridView高度.GetRowCellValue(i, gridCol_检验项目编码).ToString().Trim();
                        mods.chkItemName = gridView高度.GetRowCellValue(i, gridCol_检验项目).ToString().Trim();

                        mods.chkMax = BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_上限));
                        mods.chkMin = BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_下限));

                        mods.PassOrNG = BaseFunction.ReturnBool(gridView高度.GetRowCellValue(i, gridCol判定));

                        if (BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_Val01)) > 0)
                        {
                            mods.chkValue01 = BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_Val01));
                        }
                        if (BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_Val02)) > 0)
                        {
                            mods.chkValue02 = BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_Val02));
                        }
                        if (BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_Val03)) > 0)
                        {
                            mods.chkValue03 = BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_Val03));
                        }
                        if (BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_Val04)) > 0)
                        {
                            mods.chkValue04 = BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_Val04));
                        }
                        if (BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_Val05)) > 0)
                        {
                            mods.chkValue05 = BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_Val05));
                        }
                        if (BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_Val06)) > 0)
                        {
                            mods.chkValue06 = BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_Val06));
                        }
                        if (BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_Val07)) > 0)
                        {
                            mods.chkValue07 = BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_Val07));
                        }
                        if (BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_Val08)) > 0)
                        {
                            mods.chkValue08 = BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_Val08));
                        }
                        if (BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_Val09)) > 0)
                        {
                            mods.chkValue09 = BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_Val09));
                        }
                        if (BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_Val10)) > 0)
                        {
                            mods.chkValue10 = BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_Val10));
                        }
                        if (BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_Val11)) > 0)
                        {
                            mods.chkValue11 = BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_Val11));
                        }
                        if (BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_Val12)) > 0)
                        {
                            mods.chkValue12 = BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_Val12));
                        }
                        if (BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_Val13)) > 0)
                        {
                            mods.chkValue13 = BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_Val13));
                        }
                        if (BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_Val14)) > 0)
                        {
                            mods.chkValue14 = BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_Val14));
                        }
                        if (BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_Val15)) > 0)
                        {
                            mods.chkValue15 = BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_Val15));
                        }
                        if (BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_Val16)) > 0)
                        {
                            mods.chkValue16 = BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_Val16));
                        }
                        if (BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_Val17)) > 0)
                        {
                            mods.chkValue17 = BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_Val17));
                        }
                        if (BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_Val18)) > 0)
                        {
                            mods.chkValue18 = BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_Val18));
                        }
                        if (BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_Val19)) > 0)
                        {
                            mods.chkValue19 = BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_Val19));
                        }
                        if (BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_Val20)) > 0)
                        {
                            mods.chkValue20 = BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_Val20));
                        }
                        if (BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_Val21)) > 0)
                        {
                            mods.chkValue21 = BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_Val21));
                        }
                        if (BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_Val22)) > 0)
                        {
                            mods.chkValue22 = BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_Val22));
                        }
                        if (BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_Val23)) > 0)
                        {
                            mods.chkValue23 = BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_Val23));
                        }
                        if (BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_Val24)) > 0)
                        {
                            mods.chkValue24 = BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_Val24));
                        }
                        if (BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_Val25)) > 0)
                        {
                            mods.chkValue25 = BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_Val25));
                        }
                        if (BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_Val26)) > 0)
                        {
                            mods.chkValue26 = BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_Val26));
                        }
                        if (BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_Val27)) > 0)
                        {
                            mods.chkValue27 = BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_Val27));
                        }
                        if (BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_Val28)) > 0)
                        {
                            mods.chkValue28 = BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_Val28));
                        }
                        if (BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_Val29)) > 0)
                        {
                            mods.chkValue29 = BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_Val29));
                        }
                        if (BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_Val30)) > 0)
                        {
                            mods.chkValue30 = BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(i, gridCol_Val30));
                        }
                        mods.Remark = gridView高度.GetRowCellValue(i, gridColRemark).ToString().Trim();
                        DAL._TH_ChkValues01 dals = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._TH_ChkValues01();
                        sSQL = dals.Add(mods);
                        iCou += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    #endregion

                    #region MyRegion 外径

                    for (int i = 0; i < gridView外径.RowCount; i++)
                    {
                        if (gridView外径.GetRowCellValue(i, gridCol__检验项目编码).ToString().Trim() == "")
                            continue;

                        Model._TH_ChkValues01 mods = new UFIDA.U8.UAP.CustomApp.ControlForm.Model._TH_ChkValues01();

                        mods.cCode = mod.cCode;
                        mods.WorkGroup = mod.WorkGroup;
                        mods.WorkProcess = mod.WorkProcess;
                        mods.WONo = mod.WONo;
                        mods.MODid = mod.MODid;
                        mods.chkItemCode = gridView外径.GetRowCellValue(i, gridCol__检验项目编码).ToString().Trim();
                        mods.chkItemName = gridView外径.GetRowCellValue(i, gridCol__检验项目).ToString().Trim();

                        mods.chkMax = BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol__上限));
                        mods.chkMin = BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol__下限));

                        mods.PassOrNG = BaseFunction.ReturnBool(gridView外径.GetRowCellValue(i, gridCol__判定));

                        if (BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol_Val01)) > 0)
                        {
                            mods.chkValue01 = BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol_Val01));
                        }
                        if (BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol_Val02)) > 0)
                        {
                            mods.chkValue02 = BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol_Val02));
                        }
                        if (BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol_Val03)) > 0)
                        {
                            mods.chkValue03 = BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol_Val03));
                        }
                        if (BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol_Val04)) > 0)
                        {
                            mods.chkValue04 = BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol_Val04));
                        }
                        if (BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol_Val05)) > 0)
                        {
                            mods.chkValue05 = BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol_Val05));
                        }
                        if (BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol_Val06)) > 0)
                        {
                            mods.chkValue06 = BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol_Val06));
                        }
                        if (BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol_Val07)) > 0)
                        {
                            mods.chkValue07 = BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol_Val07));
                        }
                        if (BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol_Val08)) > 0)
                        {
                            mods.chkValue08 = BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol_Val08));
                        }
                        if (BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol_Val09)) > 0)
                        {
                            mods.chkValue09 = BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol_Val09));
                        }
                        if (BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol_Val10)) > 0)
                        {
                            mods.chkValue10 = BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol_Val10));
                        }
                        if (BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol_Val11)) > 0)
                        {
                            mods.chkValue11 = BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol_Val11));
                        }
                        if (BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol_Val12)) > 0)
                        {
                            mods.chkValue12 = BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol_Val12));
                        }
                        if (BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol_Val13)) > 0)
                        {
                            mods.chkValue13 = BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol_Val13));
                        }
                        if (BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol_Val14)) > 0)
                        {
                            mods.chkValue14 = BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol_Val14));
                        }
                        if (BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol_Val15)) > 0)
                        {
                            mods.chkValue15 = BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol_Val15));
                        }
                        if (BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol_Val16)) > 0)
                        {
                            mods.chkValue16 = BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol_Val16));
                        }
                        if (BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol_Val17)) > 0)
                        {
                            mods.chkValue17 = BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol_Val17));
                        }
                        if (BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol_Val18)) > 0)
                        {
                            mods.chkValue18 = BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol_Val18));
                        }
                        if (BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol_Val19)) > 0)
                        {
                            mods.chkValue19 = BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol_Val19));
                        }
                        if (BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol_Val20)) > 0)
                        {
                            mods.chkValue20 = BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol_Val20));
                        }
                        if (BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol_Val21)) > 0)
                        {
                            mods.chkValue21 = BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol_Val21));
                        }
                        if (BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol_Val22)) > 0)
                        {
                            mods.chkValue22 = BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol_Val22));
                        }
                        if (BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol_Val23)) > 0)
                        {
                            mods.chkValue23 = BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol_Val23));
                        }
                        if (BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol_Val24)) > 0)
                        {
                            mods.chkValue24 = BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol_Val24));
                        }
                        if (BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol_Val25)) > 0)
                        {
                            mods.chkValue25 = BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol_Val25));
                        }
                        if (BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol_Val26)) > 0)
                        {
                            mods.chkValue26 = BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol_Val26));
                        }
                        if (BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol_Val27)) > 0)
                        {
                            mods.chkValue27 = BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol_Val27));
                        }
                        if (BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol_Val28)) > 0)
                        {
                            mods.chkValue28 = BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol_Val28));
                        }
                        if (BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol_Val29)) > 0)
                        {
                            mods.chkValue29 = BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol_Val29));
                        }
                        if (BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol_Val30)) > 0)
                        {
                            mods.chkValue30 = BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(i, gridCol_Val30));
                        }
                        mods.Remark = gridView外径.GetRowCellValue(i, gridColRemark).ToString().Trim();
                        DAL._TH_ChkValues01 dals = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._TH_ChkValues01();
                        sSQL = dals.Add(mods);
                        iCou += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    #endregion


                    if (iCou > 0)
                    {
                        tran.Commit();
                        MessageBox.Show("保存成功");

                        SetEnable(false);

                        gridView1.FocusedColumn = gridColVal01;
                        gridView高度.FocusedColumn = gridCol_Val01;
                        gridView外径.FocusedColumn = gridCol__Val01;

                        txtcCode.Text = mod.cCode;
                        dtmCode.DateTime = BaseFunction.ReturnDate(mod.dtmCode);
                    }
                    else
                        tran.Rollback();

                }
                catch (Exception ee)
                {
                    tran.Rollback();
                    throw new Exception(ee.Message);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                if (lookUpEdit_检验项目.Text.Trim() == "")
                {
                    lookUpEdit_检验项目.Focus();
                    throw new Exception("请选择检验项目");
                }

                decimal d检验值 = BaseFunction.ReturnDecimal(txt_检验值.Text.Trim());
                if (d检验值 <= 0)
                {
                    txt_检验值.Focus();
                    txt_检验值.Text = "";
                    return;
                }

                int iRow = -1;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, gridCol检验项目编码).ToString().Trim() == lookUpEdit_检验项目.EditValue.ToString().Trim())
                    {
                        iRow = i;
                        break;
                    }
                }

                if (iRow < 0)
                {
                    throw new Exception("检验项目错误");
                }

                int i序号 = BaseFunction.ReturnInt(lookUpEdit_序号.EditValue.ToString().Trim());

                string s序号 = "Val" + i序号.ToString("00");
                gridView1.SetRowCellValue(iRow, gridView1.Columns[s序号], d检验值);

                if (i序号 < i序号范围)
                {
                    lookUpEdit_序号.EditValue = i序号 + 1;
                }
                else
                {
                    MessageBox.Show("测量值已满");
                }

                txt_检验值.Focus();
                txt_检验值.Text = "";

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void txt_检验值_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnEnter_Click(null, null);
                }
            }
            catch
            { }
        }

        private void lookUpEdit_检验项目_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lookUpEdit_序号.EditValue = 1;
                txt_检验值.EditValue = DBNull.Value;
                txt_检验值.Focus();
            }
            catch { }
        }

        private void JS(int iRow)
        {
            decimal d上限 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol上限));
            decimal d下限 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol下限));

            decimal dMax = 0;
            decimal dMin = 0;
            decimal dAvg = 0;
            decimal dSum = 0;
            decimal dσ = 0;
            decimal dCP = 0;
            decimal dCa = 0;
            decimal dCPK = 0;
            int iCou = 0;

            ArrayList aList = new ArrayList();

            decimal[] arrData = new decimal[i序号范围];
            for (int i = 1; i <= i序号范围; i++)
            {
                decimal d = BaseFunction.ReturnDecimal(gridView1.GetRowCellDisplayText(iRow, gridView1.Columns["Val" + i.ToString("00")]));
                aList.Add(d);

                if (d <= 0)
                {
                    continue;
                }

                if (dMax == 0)
                    dMax = d;

                if (dMin == 0)
                    dMin = d;

                iCou += 1;

                dSum = dSum + d;

                if (dMax < d)
                {
                    dMax = d;
                }
                if (dMin > d)
                {
                    dMin = d;
                }

                arrData[i - 1] = d;
            }

            if (iCou > 0)
            {
                dAvg = dSum / iCou;
            }

            dσ = StDev(arrData);

            if (dSum != 0)
            {
                if (dσ != 0)
                {
                    dCP = (d上限 - d下限) / 6 / dσ;
                }
                if (d上限 - d下限 != 0)
                {
                    dCa = (dAvg - (d上限 + d下限) / 2) / ((d上限 - d下限) / 4);
                }
                dCPK = dCP * Math.Abs(((decimal)1 - dCa));
            }

            gridView1.SetRowCellValue(iRow, gridColMAX, dMax);
            gridView1.SetRowCellValue(iRow, gridColMIN, dMin);
            gridView1.SetRowCellValue(iRow, gridColAVG, dAvg);
            gridView1.SetRowCellValue(iRow, gridColσ, dσ);
            gridView1.SetRowCellValue(iRow, gridColCP, dCP);
            gridView1.SetRowCellValue(iRow, gridColCa, dCa);
            gridView1.SetRowCellValue(iRow, gridColCPK, dCPK);
        }

        private void JS_G(int iRow)
        {
            decimal d上限 = BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(iRow, gridCol_上限));
            decimal d下限 = BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(iRow, gridCol_下限));

            decimal dMax = 0;
            decimal dMin = 0;
            decimal dAvg = 0;
            decimal dSum = 0;
            decimal dσ = 0;
            decimal dCP = 0;
            decimal dCa = 0;
            decimal dCPK = 0;
            int iCou = 0;

            ArrayList aList = new ArrayList();

            decimal[] arrData = new decimal[i序号范围];
            for (int i = 1; i <= i序号范围 ; i++)
            {
                decimal d = BaseFunction.ReturnDecimal(gridView高度.GetRowCellDisplayText(iRow, gridView高度.Columns["Val" + i.ToString("00")]));
                aList.Add(d);

                if (d <= 0)
                {
                    continue;
                }

                if (dMax == 0)
                    dMax = d;

                if (dMin == 0)
                    dMin = d;

                iCou += 1;

                dSum = dSum + d;

                if (dMax < d)
                {
                    dMax = d;
                }
                if (dMin > d)
                {
                    dMin = d;
                }

                arrData[i - 1] = d;
            }

            if (iCou > 0)
            {
                dAvg = dSum / iCou;
            }

            dσ = StDev(arrData);

            if (dSum != 0)
            {
                if (dσ != 0)
                {
                    dCP = (d上限 - d下限) / 6 / dσ;
                }
                if (d上限 - d下限 != 0)
                {
                    dCa = (dAvg - (d上限 + d下限) / 2) / ((d上限 - d下限) / 4);
                }
                dCPK = dCP * Math.Abs(((decimal)1 - dCa));
            }

            gridView高度.SetRowCellValue(iRow, gridCol_MAX, dMax);
            gridView高度.SetRowCellValue(iRow, gridCol_MIN, dMin);
            gridView高度.SetRowCellValue(iRow, gridCol_AVG, dAvg);
            gridView高度.SetRowCellValue(iRow, gridCol_σ, dσ);
            gridView高度.SetRowCellValue(iRow, gridCol_CP, dCP);
            gridView高度.SetRowCellValue(iRow, gridCol_Ca, dCa);
            gridView高度.SetRowCellValue(iRow, gridCol_CPK, dCPK);
        }

        private void JS_W(int iRow)
        {
            decimal d上限 = BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(iRow, gridCol__上限));
            decimal d下限 = BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(iRow, gridCol__下限));

            decimal dMax = 0;
            decimal dMin = 0;
            decimal dAvg = 0;
            decimal dSum = 0;
            decimal dσ = 0;
            decimal dCP = 0;
            decimal dCa = 0;
            decimal dCPK = 0;
            int iCou = 0;

            ArrayList aList = new ArrayList();

            decimal[] arrData = new decimal[i序号范围];
            for (int i = 1; i <= i序号范围; i++)
            {
                decimal d = BaseFunction.ReturnDecimal(gridView外径.GetRowCellDisplayText(iRow, gridView外径.Columns["Val" + i.ToString("00")]));
                aList.Add(d);

                if (d <= 0)
                {
                    continue;
                }

                if (dMax == 0)
                    dMax = d;

                if (dMin == 0)
                    dMin = d;

                iCou += 1;

                dSum = dSum + d;

                if (dMax < d)
                {
                    dMax = d;
                }
                if (dMin > d)
                {
                    dMin = d;
                }

                arrData[i - 1] = d;
            }

            if (iCou > 0)
            {
                dAvg = dSum / iCou;
            }

            dσ = StDev(arrData);

            if (dSum != 0)
            {
                if (dσ != 0)
                {
                    dCP = (d上限 - d下限) / 6 / dσ;
                }
                if (d上限 - d下限 != 0)
                {
                    dCa = (dAvg - (d上限 + d下限) / 2) / ((d上限 - d下限) / 4);
                }
                dCPK = dCP * Math.Abs(((decimal)1 - dCa));
            }

            gridView外径.SetRowCellValue(iRow, gridCol__MAX, dMax);
            gridView外径.SetRowCellValue(iRow, gridCol__MIN, dMin);
            gridView外径.SetRowCellValue(iRow, gridCol__AVG, dAvg);
            gridView外径.SetRowCellValue(iRow, gridCol__σ, dσ);
            gridView外径.SetRowCellValue(iRow, gridCol__CP, dCP);
            gridView外径.SetRowCellValue(iRow, gridCol__Ca, dCa);
            gridView外径.SetRowCellValue(iRow, gridCol__CPK, dCPK);
        }

        public decimal StDev(decimal[] arrData) //计算标准偏差
        {
            decimal xSum = 0;
            decimal xAvg = 0;
            decimal sSum = 0;
            decimal tmpStDev = 0;
            int arrNum = arrData.Length;
            for (int i = 0; i < arrNum; i++)
            {
                xSum += arrData[i];
            }
            xAvg = xSum / arrNum;
            for (int j = 0; j < arrNum; j++)
            {
                sSum += ((arrData[j] - xAvg) * (arrData[j] - xAvg));
            }
            tmpStDev = BaseFunction.ReturnDecimal(Math.Sqrt(BaseFunction.ReturnDouble((sSum / (arrNum - 1)))).ToString());
            return tmpStDev;
        }

        private void lookUpEdit生产订单号_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    GetGrid();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }



        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                GetGrid();

                gridView1.FocusedColumn = gridColVal01;
                gridView高度.FocusedColumn = gridCol_Val01;
                gridView外径.FocusedColumn = gridCol__Val01;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void GetGrid()
        {
            string sWoCode = lookUpEdit生产订单号.EditValue.ToString().Trim();
            if (sWoCode == "")
            {
                lookUpEdit生产订单号.Focus();
                return;
            }

            string s工序 = lookUpEdit工序.EditValue.ToString().Trim();
            if (s工序 == "")
            {
                lookUpEdit工序.Focus();
                return;
            }

            string s班组 = lookUpEdit班组.EditValue.ToString().Trim();
            if (s班组 == "")
            {
                lookUpEdit班组.Focus();
                return;
            }


            SetTxtNull();

            lookUpEdit生产订单号.EditValue = sWoCode;
            lookUpEdit工序.EditValue = s工序;
            lookUpEdit班组.EditValue = s班组;


            int iRow = BaseFunction.ReturnInt(txtWORow.Text.Trim());


            string sSQL = @"
select a.*,b.*,inv.cInvName,inv.cInvStd
from mom_order a inner join mom_orderdetail b on a.moid = b.moid
    inner join Inventory inv on b.InvCode = inv.cInvCode
where b.[Status] = 3 and a.MoCode = '{0}' and b.SortSeq = {1}
order by a.MoCode
";
            sSQL = string.Format(sSQL, sWoCode, iRow);
            DataTable dtHead = DbHelperSQL.Query(sSQL);
            if (dtHead == null || dtHead.Rows.Count == 0)
            {
                throw new Exception("获得生产订单信息失败");
            }

            lookUpEdit生产订单号.EditValue = sWoCode;
            txtMoDid.Text = dtHead.Rows[0]["MODid"].ToString().Trim();
            dtm生产日期.DateTime = BaseFunction.ReturnDate(sLogDate);
            txt生产批号.Text = dtHead.Rows[0]["MoLotCode"].ToString().Trim();
            txt存货编码.Text = dtHead.Rows[0]["InvCode"].ToString().Trim();
            txt存货名称.Text = dtHead.Rows[0]["cInvName"].ToString().Trim();
            txt产品规格.Text = dtHead.Rows[0]["cInvStd"].ToString().Trim();
            lookUpEdit班组.EditValue = s班组;
            lookUpEdit工序.EditValue = s工序;
            txt磁粉性能.Text = "";
            txt模具号.Text = "";
            txt图号.Text = "";
            txt备注.Text = dtHead.Rows[0]["Remark"].ToString().Trim();

            sSQL = @"
select citemcode as 检验项目编码,citemname as 检验项目
from [dbo].[_sospInvCheck]
where cInvCode = '{0}'
     and (citemname not like '%高度%' and citemname not like '%平行度%' and citemname not like '%外径%' and citemname not like '%圆度%'and citemname not like '%大小头%')
order by citemcode

";
            sSQL = string.Format(sSQL, txt存货编码.Text.Trim());
            DataTable dt检验 = DbHelperSQL.Query(sSQL);
            lookUpEdit_检验项目.Properties.DataSource = dt检验;

            sSQL = @"

select citemcode as 检验项目编码,citemname as 检验项目
	,lowLimit as 下限,upLimit as 上限
	,cast(null as decimal(16,4)) as Val01
	,cast(null as decimal(16,4)) as Val02
	,cast(null as decimal(16,4)) as Val03
	,cast(null as decimal(16,4)) as Val04
	,cast(null as decimal(16,4)) as Val05
	,cast(null as decimal(16,4)) as Val06
	,cast(null as decimal(16,4)) as Val07
	,cast(null as decimal(16,4)) as Val08
	,cast(null as decimal(16,4)) as Val09
	,cast(null as decimal(16,4)) as Val10
	,cast(null as decimal(16,4)) as Val11
	,cast(null as decimal(16,4)) as Val12
	,cast(null as decimal(16,4)) as Val13
	,cast(null as decimal(16,4)) as Val14
	,cast(null as decimal(16,4)) as Val15
	,cast(null as decimal(16,4)) as Val16
	,cast(null as decimal(16,4)) as Val17
	,cast(null as decimal(16,4)) as Val18
	,cast(null as decimal(16,4)) as Val19
	,cast(null as decimal(16,4)) as Val20
	,cast(null as decimal(16,4)) as Val21
	,cast(null as decimal(16,4)) as Val22
	,cast(null as decimal(16,4)) as Val23
	,cast(null as decimal(16,4)) as Val24
	,cast(null as decimal(16,4)) as Val25
	,cast(null as decimal(16,4)) as Val26
	,cast(null as decimal(16,4)) as Val27
	,cast(null as decimal(16,4)) as Val28
	,cast(null as decimal(16,4)) as Val29
	,cast(null as decimal(16,4)) as Val30
	,cast(null as decimal(16,4)) as [MAX]
	,cast(null as decimal(16,4)) as [MIN]
	,cast(null as decimal(16,4)) as [AVG]
	,cast(null as decimal(16,4)) as [σ]
	,cast(null as decimal(16,4)) as [CP]
	,cast(null as decimal(16,4)) as [Ca]
	,cast(null as decimal(16,4)) as [CPK]
	,cast(0 as bit) AS PassOrNG
    ,cast(null as decimal(16,4)) as Remark
from [dbo].[_sospInvCheck]
where cInvCode = '{0}' and WorkProcess = '{1}'
    and (citemname not like '%高度%' and citemname not like '%平行度%' and citemname not like '%外径%' and citemname not like '%圆度%' and citemname not like '%大小头%')
order by citemcode

";
            sSQL = string.Format(sSQL, txt存货编码.Text.Trim(), lookUpEdit工序.EditValue.ToString().Trim());
            DataTable dtGrid = DbHelperSQL.Query(sSQL);
            gridControl1.DataSource = dtGrid;

            SetDatatable();


            gridView1.FocusedColumn = gridColVal01;
            gridView高度.FocusedColumn = gridCol_Val01;
            gridView外径.FocusedColumn = gridCol__Val01;
        }

        private void btnAudit_Click(object sender, EventArgs e)
        {
            try
            {
                string sSQL = "select * from _TH_ChkValue01 where cCode = '{0}'";
                sSQL = string.Format(sSQL, txtcCode.Text.Trim());
                DataTable dt = DbHelperSQL.Query(sSQL);

                if (dt == null || dt.Rows.Count == 0)
                {
                    throw new Exception("单据尚未保存");
                }

                if (dt != null && dt.Rows.Count > 0 && dt.Rows[0]["AuditUid"].ToString().Trim() != "")
                {
                    throw new Exception("单据已经审核");
                }

                DateTime dtmNow = DateTime.Now;

                sSQL = @"
update _TH_ChkValue01 set  AuditUid = '{0}', dtmAudit = '{1}' where  cCode = '{2}'
";
                sSQL = string.Format(sSQL, sUserName, dtmNow, txtcCode.Text.Trim());
                int iCou = DbHelperSQL.ExecuteSql(sSQL);
                if (iCou > 0)
                {
                    txt审核人.Text = sUserName;
                    dtm审核日期.DateTime = dtmNow;
                    MessageBox.Show("审核成功");

                    SetEnable(false);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("审核失败:" + ee.Message);
            }
        }

        private void btnUnAudit_Click(object sender, EventArgs e)
        {
            try
            {
                string sSQL = "select * from _TH_ChkValue01 where cCode = '{0}'";
                sSQL = string.Format(sSQL, txtcCode.Text.Trim());
                DataTable dt = DbHelperSQL.Query(sSQL);

                if (dt == null || dt.Rows.Count == 0)
                {
                    throw new Exception("单据尚未保存");
                }

                if (dt != null && dt.Rows.Count > 0 && dt.Rows[0]["AuditUid"].ToString().Trim() == "")
                {
                    throw new Exception("单据尚未审核");
                }

                sSQL = @"
update _TH_ChkValue01 set  AuditUid = null, dtmAudit = null  where  cCode = '{0}'
";
                sSQL = string.Format(sSQL, txtcCode.Text.Trim());
                int iCou = DbHelperSQL.ExecuteSql(sSQL);
                if (iCou > 0)
                {

                    txt审核人.EditValue = DBNull.Value;
                    dtm审核日期.EditValue = DBNull.Value;
                    MessageBox.Show("弃审成功");

                    SetEnable(false);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("弃审失败:" + ee.Message);
            }
        }

        private void SetDatatable()
        {
            string sSQL = @"
select  iID, WONo, MODid, chkStd
    ,chkItemCode as 检验项目编码, chkItemName as 检验项目, chkMax 上限, chkMin 下限
    , chkValue01 as Val01, chkValue02 as Val02  ,chkValue03 as Val03, chkValue04 as Val04, chkValue05 as Val05
    , chkValue06 as Val06, chkValue07 as Val07  ,chkValue08 as Val08, chkValue09 as Val09, chkValue10 as Val10
    , chkValue11 as Val11, chkValue12 as Val12  ,chkValue13 as Val13, chkValue14 as Val14, chkValue15 as Val15
    , chkValue16 as Val16, chkValue17 as Val17  ,chkValue18 as Val18, chkValue19 as Val19, chkValue20 as Val20
    , chkValue21 as Val21, chkValue22 as Val22  ,chkValue23 as Val23, chkValue24 as Val24, chkValue25 as Val25
    , chkValue26 as Val26, chkValue27 as Val27  ,chkValue28 as Val28, chkValue29 as Val29, chkValue30 as Val30
    , PassOrNG as PassOrNG
    , Remark

	,cast(null as decimal(16,4)) as [MAX]
	,cast(null as decimal(16,4)) as [MIN]
	,cast(null as decimal(16,4)) as [AVG]
	,cast(null as decimal(16,4)) as [σ]
	,cast(null as decimal(16,4)) as [CP]
	,cast(null as decimal(16,4)) as [Ca]
	,cast(null as decimal(16,4)) as [CPK]

FROM      _TH_ChkValues01
where 1=-1
order by iID
";
            DataTable dt高度 = DbHelperSQL.Query(sSQL);

            sSQL = @"
SELECT * FROM [dbo].[_sospInvCheck] 
WHERE citemcode = '高度'
	AND cInvCode = '{0}' AND WorkProcess = '{1}'
";
            sSQL = string.Format(sSQL, txt存货编码.Text.Trim(), lookUpEdit工序.EditValue.ToString());
            DataTable dt高度范围 = DbHelperSQL.Query(sSQL);
            string s检验项目 = "高度";
            string s规格 = "";
            decimal s上限 = 0;
            decimal s下限 = 0;
            if (dt高度范围 != null && dt高度范围.Rows.Count > 0)
            {
                s检验项目 = dt高度范围.Rows[0]["citemname"].ToString().Trim();
                s规格 = dt高度范围.Rows[0]["cInvStd"].ToString().Trim();
                s上限 = BaseFunction.ReturnDecimal(dt高度范围.Rows[0]["upLimit"]);
                s下限 = BaseFunction.ReturnDecimal(dt高度范围.Rows[0]["lowLimit"]);
            }


            DataRow dr高度 = dt高度.NewRow();
            dr高度["检验项目编码"] = "高度";
            dr高度["检验项目"] = s检验项目;
            dr高度["chkStd"] = s规格;
            dr高度["上限"] = s上限;
            dr高度["下限"] = s下限;
            dt高度.Rows.Add(dr高度);

            dr高度 = dt高度.NewRow();
            dr高度["检验项目编码"] = "高度";
            dr高度["检验项目"] = s检验项目;
            dr高度["chkStd"] = s规格;
            dr高度["上限"] = s上限;
            dr高度["下限"] = s下限;
            dt高度.Rows.Add(dr高度); 

            dr高度 = dt高度.NewRow();
            dr高度["检验项目编码"] = "高度";
            dr高度["检验项目"] = s检验项目;
            dr高度["chkStd"] = s规格;
            dr高度["上限"] = s上限;
            dr高度["下限"] = s下限;
            dt高度.Rows.Add(dr高度);

            dr高度 = dt高度.NewRow();
            dr高度["检验项目编码"] = "高度";
            dr高度["检验项目"] =s检验项目;
            dr高度["chkStd"] = "MAX";
            dt高度.Rows.Add(dr高度);

            dr高度 = dt高度.NewRow();
            dr高度["检验项目编码"] = "高度";
            dr高度["检验项目"] =s检验项目;
            dr高度["chkStd"] = "MIN";
            dt高度.Rows.Add(dr高度);

            dr高度 = dt高度.NewRow();
            dr高度["检验项目编码"] = "高度";
            dr高度["检验项目"] = s检验项目;
            dr高度["chkStd"] = "平均值";
            dt高度.Rows.Add(dr高度);


            dr高度 = dt高度.NewRow();
            dr高度["检验项目编码"] = "平行度";
            dr高度["检验项目"] = "平行度";
            //dr高度["上限"] = 0.02;
            dt高度.Rows.Add(dr高度); 

            gridControl高度.DataSource = dt高度;

            sSQL = @"
select  iID, WONo, MODid, chkStd
    ,chkItemCode as 检验项目编码, chkItemName as 检验项目, chkMax 上限, chkMin 下限
    , chkValue01 as Val01, chkValue02 as Val02  ,chkValue03 as Val03, chkValue04 as Val04, chkValue05 as Val05
    , chkValue06 as Val06, chkValue07 as Val07  ,chkValue08 as Val08, chkValue09 as Val09, chkValue10 as Val10
    , chkValue11 as Val11, chkValue12 as Val12  ,chkValue13 as Val13, chkValue14 as Val14, chkValue15 as Val15
    , chkValue16 as Val16, chkValue17 as Val17  ,chkValue18 as Val18, chkValue19 as Val19, chkValue20 as Val20
    , chkValue21 as Val21, chkValue22 as Val22  ,chkValue23 as Val23, chkValue24 as Val24, chkValue25 as Val25
    , chkValue26 as Val26, chkValue27 as Val27  ,chkValue28 as Val28, chkValue29 as Val29, chkValue30 as Val30
    , PassOrNG as PassOrNG
    , Remark

	,cast(null as decimal(16,4)) as [MAX]
	,cast(null as decimal(16,4)) as [MIN]
	,cast(null as decimal(16,4)) as [AVG]
	,cast(null as decimal(16,4)) as [σ]
	,cast(null as decimal(16,4)) as [CP]
	,cast(null as decimal(16,4)) as [Ca]
	,cast(null as decimal(16,4)) as [CPK]

FROM      _TH_ChkValues01
where 1=-1
order by iID
";
            DataTable dt外径 = DbHelperSQL.Query(sSQL);


            sSQL = @"
SELECT * FROM [dbo].[_sospInvCheck] 
WHERE citemcode = '外径' 
	AND cInvCode = '{0}' AND WorkProcess = '{1}'
";
            sSQL = string.Format(sSQL, txt存货编码.Text.Trim(), lookUpEdit工序.EditValue.ToString());
            DataTable dt外径范围 = DbHelperSQL.Query(sSQL);

            s检验项目 = "外径";
            s规格 = "";
            s上限 = 0;
            s下限 = 0;
            if (dt外径范围 != null && dt外径范围.Rows.Count > 0)
            {
                s检验项目 = dt外径范围.Rows[0]["citemname"].ToString().Trim();
                s规格 = dt外径范围.Rows[0]["cInvStd"].ToString().Trim();
                s上限 = BaseFunction.ReturnDecimal(dt外径范围.Rows[0]["upLimit"]);
                s下限 = BaseFunction.ReturnDecimal(dt外径范围.Rows[0]["lowLimit"]);
            }


            DataRow dr外径 = dt外径.NewRow();
            dr外径["检验项目编码"] = "外径";
            dr外径["检验项目"] = s检验项目;
            dr外径["chkStd"] = s规格;
            dr外径["上限"] = s上限;
            dr外径["下限"] = s下限;
            dt外径.Rows.Add(dr外径);

            dr外径 = dt外径.NewRow();
            dr外径["检验项目编码"] = "外径";
            dr外径["检验项目"] = s检验项目;
            dr外径["chkStd"] = s规格;
            dr外径["上限"] = s上限;
            dr外径["下限"] = s下限;
            dt外径.Rows.Add(dr外径);

            dr外径 = dt外径.NewRow();
            dr外径["检验项目编码"] = "外径";
            dr外径["检验项目"] = s检验项目;
            dr外径["chkStd"] = s规格;
            dr外径["上限"] = s上限;
            dr外径["下限"] = s下限;
            dt外径.Rows.Add(dr外径);

            dr外径 = dt外径.NewRow();
            dr外径["检验项目编码"] = "外径";
            dr外径["检验项目"] = s检验项目;
            dr外径["chkStd"] = "MAX";
            dt外径.Rows.Add(dr外径);

            dr外径 = dt外径.NewRow();
            dr外径["检验项目编码"] = "外径";
            dr外径["检验项目"] = s检验项目;
            dr外径["chkStd"] = "MIN";
            dt外径.Rows.Add(dr外径);

            dr外径 = dt外径.NewRow();
            dr外径["检验项目编码"] = "外径";
            dr外径["检验项目"] = s检验项目;
            dr外径["chkStd"] = "平均值";
            dt外径.Rows.Add(dr外径);

            dr外径 = dt外径.NewRow();
            dr外径["检验项目编码"] = "圆度";
            dr外径["检验项目"] = "圆度";
            //dr外径["上限"] = 0.02;
            dt外径.Rows.Add(dr外径);

            dr外径 = dt外径.NewRow();
            dr外径["检验项目编码"] = "大小头";
            dr外径["检验项目"] = "大小头";
            //dr外径["上限"] = 0.02;
            dt外径.Rows.Add(dr外径);


            gridControl外径.DataSource = dt外径;
        }

        private void ItemTextEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Modifiers == Keys.Control && e.KeyCode == Keys.V)
                {
                    int iFocRow = gridView1.FocusedRowHandle;

                    string sColName = gridView1.FocusedColumn.Name;
                    if (!sColName.StartsWith("gridColVal"))
                    {
                        return;
                    }

                    int iCol = BaseFunction.ReturnInt(sColName.Substring(10));

                    gridView1.SetRowCellValue(iFocRow, gridView1.FocusedColumn, DBNull.Value);

                    string sList = GetString();
                    if (sList.Trim() != "")
                    {
                        sList = sList.Replace("\r\n", "");
                        string[] sCode = sList.Replace("\t", "◆").Split('◆');

                        for (int i = 0; i < sCode.Length; i++)
                        {
                            int iColName = iCol + i;

                            if (iColName > 30)
                                break;

                            string sColName2 = "Val" + iColName.ToString().PadLeft(2, '0');

                            decimal d = BaseFunction.ReturnDecimal(sCode[i].Trim());
                            gridView1.SetRowCellValue(iFocRow, gridView1.Columns[sColName2], d);
                        }

                    }

                    try
                    {
                        gridView1.FocusedRowHandle -= 1;
                        gridView1.FocusedRowHandle = iFocRow;
                    }
                    catch { }
                }
            }
            catch { }
        }

        private string GetString()
        {
            string s = "";
            IDataObject iData = Clipboard.GetDataObject();
            // 将数据与指定的格式进行匹配，返回bool
            if (iData.GetDataPresent(DataFormats.Text))
            {
                // GetData检索数据并指定一个格式
                s = (string)iData.GetData(DataFormats.Text);
            }

            return s;
        }

        private void ItemTextEdit_1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Modifiers == Keys.Control && e.KeyCode == Keys.V)
                {
                    int iFocRow = gridView高度.FocusedRowHandle;

                    string sColName = gridView高度.FocusedColumn.Name;
                    if (!sColName.StartsWith("gridCol_Val"))
                    {
                        return;
                    }

                    int iCol = BaseFunction.ReturnInt(sColName.Substring(11));

                    gridView高度.SetRowCellValue(iFocRow, gridView高度.FocusedColumn, DBNull.Value);

                    string sList = GetString();
                    if (sList.Trim() != "")
                    {
                        sList = sList.Replace("\r\n", "");
                        string[] sCode = sList.Replace("\t", "◆").Split('◆');

                        for (int i = 0; i < sCode.Length; i++)
                        {
                            int iColName = iCol + i;

                            if (iColName > 30)
                                break;

                            string sColName2 = "Val" + iColName.ToString().PadLeft(2, '0');

                            decimal d = BaseFunction.ReturnDecimal(sCode[i].Trim());
                            gridView高度.SetRowCellValue(iFocRow, gridView高度.Columns[sColName2], d);
                        }

                    }

                    try
                    {
                        gridView高度.FocusedRowHandle -= 1;
                        gridView高度.FocusedRowHandle = iFocRow;
                    }
                    catch { }
                }
            }
            catch { }
        }

        private void ItemTextEdit__1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Modifiers == Keys.Control && e.KeyCode == Keys.V)
                {
                    int iFocRow = gridView外径.FocusedRowHandle;

                    string sColName = gridView外径.FocusedColumn.Name;
                    if (!sColName.StartsWith("gridCol__Val"))
                    {
                        return;
                    }

                    int iCol = BaseFunction.ReturnInt(sColName.Substring(12));

                    gridView外径.SetRowCellValue(iFocRow, gridView外径.FocusedColumn, DBNull.Value);

                    string sList = GetString();
                    if (sList.Trim() != "")
                    {
                        sList = sList.Replace("\r\n", "");
                        string[] sCode = sList.Replace("\t", "◆").Split('◆');

                        for (int i = 0; i < sCode.Length; i++)
                        {
                            int iColName = iCol + i;

                            if (iColName > 30)
                                break;

                            string sColName2 = "Val" + iColName.ToString().PadLeft(2, '0');

                            decimal d = BaseFunction.ReturnDecimal(sCode[i].Trim());
                            gridView外径.SetRowCellValue(iFocRow, gridView外径.Columns[sColName2], d);
                        }

                    }

                    try
                    {
                        gridView外径.FocusedRowHandle -= 1;
                        gridView外径.FocusedRowHandle = iFocRow;
                    }
                    catch { }
                }
              
            }
            catch { }
        }

        private void gridView高度_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (gridView高度.OptionsBehavior.Editable == true && gridView高度.OptionsBehavior.ReadOnly == false)
                {
                    if (e.FocusedRowHandle < 3)
                    {
                        for (int i = 1; i <= 30; i++)
                        {
                            gridView高度.Columns["Val" + i.ToString().PadLeft(2, '0')].OptionsColumn.AllowEdit = true;
                        }
                    }
                    else
                    {
                        for (int i = 1; i <= 30; i++)
                        {
                            gridView高度.Columns["Val" + i.ToString().PadLeft(2, '0')].OptionsColumn.AllowEdit = false;
                        }
                    }
                }
            }
            catch(Exception ee) { }
        }

        private void gridView外径_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (gridView外径.OptionsBehavior.Editable == true && gridView外径.OptionsBehavior.ReadOnly == false)
                {
                    if (e.FocusedRowHandle < 3)
                    {
                        for (int i = 1; i <= 30; i++)
                        {
                            gridView外径.Columns["Val" + i.ToString().PadLeft(2, '0')].OptionsColumn.AllowEdit = true;
                        }
                    }
                    else
                    {
                        for (int i = 1; i <= 30; i++)
                        {
                            gridView外径.Columns["Val" + i.ToString().PadLeft(2, '0')].OptionsColumn.AllowEdit = false;
                        }
                    }
                }
            }
            catch (Exception ee) { }
        }

        private void setValue高度(string sColName)
        {
            try
            {
                int iFoc = gridView高度.FocusedRowHandle;
                try
                {
                    gridView高度.FocusedRowHandle += 1;
                    gridView高度.FocusedRowHandle = iFoc;
                }
                catch { }

                sColName = sColName.Replace("gridCol_", "");
                decimal d1 = BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(0, gridView高度.Columns[sColName]), 2);
                decimal d2 = BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(1, gridView高度.Columns[sColName]), 2);
                decimal d3 = BaseFunction.ReturnDecimal(gridView高度.GetRowCellValue(2, gridView高度.Columns[sColName]), 2);

                decimal dMax = d1;
                if (d2 > dMax)
                    dMax = d2;
                if (d3 > dMax)
                    dMax = d3;

                decimal dMin = d1;
                if (d2 < dMin)
                    dMin = d2;
                if (d3 < dMin)
                    dMin = d3;

                decimal dAvg = BaseFunction.ReturnDecimal((d1 + d2 + d3) / 3, 2);
                decimal d平行度 = dMax - dMin;

                gridView高度.SetRowCellValue(3, gridView高度.Columns[sColName], dMax);
                gridView高度.SetRowCellValue(4, gridView高度.Columns[sColName], dMin);
                gridView高度.SetRowCellValue(5, gridView高度.Columns[sColName], dAvg);
                gridView高度.SetRowCellValue(6, gridView高度.Columns[sColName], d平行度);

                if (iFoc < 2)
                {
                    gridView高度.FocusedRowHandle = iFoc + 1;
                }
                if (iFoc == 2)
                {
                    int iFocCol = gridView高度.Columns.IndexOf(gridView高度.FocusedColumn);
                    gridView高度.FocusedColumn = gridView高度.Columns[iFocCol + 1];
                    gridView高度.FocusedRowHandle = 0;
                }
            }
            catch (Exception ee)
            { }
        }



        private void setValue外径(string sColName)
        {
            try
            {
                int iFoc = gridView外径.FocusedRowHandle;
                try
                {
                    gridView外径.FocusedRowHandle += 1;
                    gridView外径.FocusedRowHandle = iFoc;
                }
                catch { }

                sColName = sColName.Replace("gridCol__", "");

                decimal d1 = BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(0, gridView外径.Columns[sColName]), 4);
                decimal d2 = BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(1, gridView外径.Columns[sColName]), 4);
                decimal d3 = BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(2, gridView外径.Columns[sColName]), 4);

                decimal dMax = d1;
                if (d2 > dMax)
                    dMax = d2;
                if (d3 > dMax)
                    dMax = d3;

                decimal dMin = d1;
                if (d2 < dMin)
                    dMin = d2;
                if (d3 < dMin)
                    dMin = d3;

                decimal dAvg = BaseFunction.ReturnDecimal((d1 + d2 + d3) / 3, 4);
                decimal d平行度 = dMax - dMin;

                gridView外径.SetRowCellValue(3, gridView外径.Columns[sColName], dMax);
                gridView外径.SetRowCellValue(4, gridView外径.Columns[sColName], dMin);
                gridView外径.SetRowCellValue(5, gridView外径.Columns[sColName], dAvg);
                gridView外径.SetRowCellValue(6, gridView外径.Columns[sColName], d平行度);
                if (iFoc < 2)
                {
                    gridView外径.FocusedRowHandle = iFoc + 1;
                }
                if (iFoc == 2)
                {
                    int iFocCol = gridView外径.Columns.IndexOf(gridView外径.FocusedColumn);
                    gridView外径.FocusedColumn = gridView外径.Columns[iFocCol + 1];
                    gridView外径.FocusedRowHandle = 0;
                }

                int iColMax = BaseFunction.ReturnInt(sColName.Substring(3));
                if (iColMax % 2 == 1)
                {
                    decimal dMax1 = BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(3, gridView外径.Columns[sColName]));
                    decimal dMax2 = BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(3, gridView外径.Columns["Val" + (iColMax + 1).ToString().PadLeft(2, '0')]));
                    decimal d大小头 = Math.Abs(dMax1 - dMax2);

                    gridView外径.SetRowCellValue(7, gridView外径.Columns[sColName], d大小头);
                }
                else
                {
                    decimal dMax1 = BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(3, gridView外径.Columns[sColName]));
                    decimal dMax2 = BaseFunction.ReturnDecimal(gridView外径.GetRowCellValue(3, gridView外径.Columns["Val" + (iColMax - 1).ToString().PadLeft(2, '0')]));
                    decimal d大小头 = Math.Abs(dMax1 - dMax2);

                    gridView外径.SetRowCellValue(7, gridView外径.Columns["Val" + (iColMax - 1).ToString().PadLeft(2, '0')], d大小头);
                }
            }
            catch (Exception ee)
            { }
        }


        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column.Name.ToLower().StartsWith("gridColVal".ToLower()))
                {
                    JS(e.RowHandle);
                }
            }
            catch { }
        }


        private void gridView高度_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column.Name.StartsWith("gridCol_Val") && e.RowHandle < 3)
                {
                    setValue高度(e.Column.Name);

                    JS_G(e.RowHandle);
                }
            }
            catch (Exception ee)
            { }
        }

        private void gridView外径_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column.Name.StartsWith("gridCol__Val") && e.RowHandle < 3)
                {
                    setValue外径(e.Column.Name);

                    JS_W(e.RowHandle);
                }
            }
            catch (Exception ee)
            { }
        }

        private void ItemTextEdit_1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            { 
            
            }
        }

        private void btn查询_Click(object sender, EventArgs e)
        {
            try
            {
                FrmchkVouch01_SEL frm = new FrmchkVouch01_SEL(Conn);
                DialogResult d = frm.ShowDialog();
                if (d == DialogResult.OK)
                {
                    string sCode = frm.sCode;
                    if (sCode != "")
                    {
                        GetGrid(sCode);
                    }
                }
            }
            catch 
            { } 
        }


        private void GetGrid(string sCode)
        {
            SetTxtNull();

            string sSQL = @"
select * from _TH_ChkValue01
where cCode = '{0}'
";
            sSQL = string.Format(sSQL, sCode);
            DataTable dtHead = DbHelperSQL.Query(sSQL);

            txtcCode.Text = dtHead.Rows[0]["cCode"].ToString().Trim();
            dtmCode.DateTime = BaseFunction.ReturnDate(dtHead.Rows[0]["dtmCode"]);
            lookUpEdit生产订单号.EditValue = dtHead.Rows[0]["WONo"].ToString().Trim();
            txtMoDid.Text = dtHead.Rows[0]["MODid"].ToString().Trim();
            txtWORow.Text = dtHead.Rows[0]["WORow"].ToString().Trim();

            dtm生产日期.DateTime = BaseFunction.ReturnDate(dtHead.Rows[0]["WODate"]);

            txt生产批号.Text = dtHead.Rows[0]["WOBatch"].ToString().Trim();
            txt存货编码.Text = dtHead.Rows[0]["cInvCode"].ToString().Trim();
            txt存货名称.Text = dtHead.Rows[0]["cInvName"].ToString().Trim();
            txt产品规格.Text = dtHead.Rows[0]["cInvStd"].ToString().Trim();
            lookUpEdit班组.EditValue = dtHead.Rows[0]["WorkGroup"].ToString().Trim();
            txt磁粉性能.Text = dtHead.Rows[0]["cInvPerformance"].ToString().Trim();
            txt模具号.Text = dtHead.Rows[0]["WOMould"].ToString().Trim();
            txt图号.Text = dtHead.Rows[0]["cInvDraw"].ToString().Trim();

            lookUpEdit工序.EditValue = dtHead.Rows[0]["WorkProcess"].ToString().Trim();

            txt单重.EditValue = BaseFunction.ReturnDecimal(dtHead.Rows[0]["QtyDZ"]);
            txt共.EditValue = BaseFunction.ReturnDecimal(dtHead.Rows[0]["QtyG"]);
            txt万件.EditValue = BaseFunction.ReturnDecimal(dtHead.Rows[0]["QtyWJ"]);
            txt备注.Text = dtHead.Rows[0]["Remark"].ToString().Trim();
            txtPCS.Text = dtHead.Rows[0]["Qtypcs"].ToString().Trim();



            txt共份数.EditValue = BaseFunction.ReturnDecimal(dtHead.Rows[0]["QtyGFS"], 4);
            txt挑选高.EditValue = BaseFunction.ReturnDecimal(dtHead.Rows[0]["QtyTXG"], 4);
            txt挑选低.EditValue = BaseFunction.ReturnDecimal(dtHead.Rows[0]["QtyTXD"], 4);
            txt挑选破口.EditValue = BaseFunction.ReturnDecimal(dtHead.Rows[0]["QtyTXPK"], 4);

            txt固化后废品.EditValue = BaseFunction.ReturnDecimal(dtHead.Rows[0]["QtyGH"], 4);
            txt未固化废品.EditValue = BaseFunction.ReturnDecimal(dtHead.Rows[0]["QtyWGH"], 4);
            txt回粉.EditValue = BaseFunction.ReturnDecimal(dtHead.Rows[0]["QtyHF"], 4);

            txt不合格数量.EditValue = BaseFunction.ReturnDecimal(dtHead.Rows[0]["QtyUn1"], 4);
            txt不合格万件.EditValue = BaseFunction.ReturnDecimal(dtHead.Rows[0]["QtyUn2"], 4);
            txt不合格单件.EditValue = BaseFunction.ReturnDecimal(dtHead.Rows[0]["QtyUn3"], 4);

            if (BaseFunction.ReturnDecimal(txt不合格万件.EditValue) != 0)
            {
                txt万件个.EditValue = BaseFunction.ReturnDecimal(BaseFunction.ReturnDecimal(txt不合格单件.EditValue) * 1000 / BaseFunction.ReturnDecimal(txt不合格万件.EditValue) / 10000, 4);
            }


            txt制单人.Text = dtHead.Rows[0]["CreatUid"].ToString().Trim();
            dtm制单日期.EditValue = BaseFunction.ReturnDate(dtHead.Rows[0]["dtmCreate"]);
            txt审核人.Text = dtHead.Rows[0]["AuditUid"].ToString().Trim();

            if (BaseFunction.ReturnDate(dtHead.Rows[0]["dtmAudit"]) < Convert.ToDateTime("2000-01-01"))
            {
                dtm审核日期.EditValue = DBNull.Value;
            }
            else
            {
                dtm审核日期.EditValue = BaseFunction.ReturnDate(dtHead.Rows[0]["dtmAudit"]);
            }

            sSQL = @"
select  iID, WONo, MODid
    ,chkItemCode as 检验项目编码, chkItemName as 检验项目, chkStd, chkMax 上限, chkMin 下限
    , chkValue01 as Val01, chkValue02 as Val02  ,chkValue03 as Val03, chkValue04 as Val04, chkValue05 as Val05
    , chkValue06 as Val06, chkValue07 as Val07  ,chkValue08 as Val08, chkValue09 as Val09, chkValue10 as Val10
    , chkValue11 as Val11, chkValue12 as Val12  ,chkValue13 as Val13, chkValue14 as Val14, chkValue15 as Val15
    , chkValue16 as Val16, chkValue17 as Val17  ,chkValue18 as Val18, chkValue19 as Val19, chkValue20 as Val20
    , chkValue21 as Val21, chkValue22 as Val22  ,chkValue23 as Val23, chkValue24 as Val24, chkValue25 as Val25
    , chkValue26 as Val26, chkValue27 as Val27  ,chkValue28 as Val28, chkValue29 as Val29, chkValue30 as Val30
    , PassOrNG as PassOrNG
    , Remark

	,cast(null as decimal(16,4)) as [MAX]
	,cast(null as decimal(16,4)) as [MIN]
	,cast(null as decimal(16,4)) as [AVG]
	,cast(null as decimal(16,4)) as [σ]
	,cast(null as decimal(16,4)) as [CP]
	,cast(null as decimal(16,4)) as [Ca]
	,cast(null as decimal(16,4)) as [CPK]

FROM      _TH_ChkValues01
where cCode = '{0}'
    and chkItemName not like '%高度%' and  chkItemName not like '%外径%' and chkItemName not like '%平行度%' and chkItemName not like '%圆度%' and chkItemName not like '%大小头%'
order by iID
";
            sSQL = string.Format(sSQL, sCode);
            DataTable dtGrid = DbHelperSQL.Query(sSQL);
            gridControl1.DataSource = dtGrid;

            sSQL = @"
select  iID, WONo, MODid
    ,chkItemCode as 检验项目编码, chkItemName as 检验项目, chkStd, chkMax 上限, chkMin 下限
    , chkValue01 as Val01, chkValue02 as Val02  ,chkValue03 as Val03, chkValue04 as Val04, chkValue05 as Val05
    , chkValue06 as Val06, chkValue07 as Val07  ,chkValue08 as Val08, chkValue09 as Val09, chkValue10 as Val10
    , chkValue11 as Val11, chkValue12 as Val12  ,chkValue13 as Val13, chkValue14 as Val14, chkValue15 as Val15
    , chkValue16 as Val16, chkValue17 as Val17  ,chkValue18 as Val18, chkValue19 as Val19, chkValue20 as Val20
    , chkValue21 as Val21, chkValue22 as Val22  ,chkValue23 as Val23, chkValue24 as Val24, chkValue25 as Val25
    , chkValue26 as Val26, chkValue27 as Val27  ,chkValue28 as Val28, chkValue29 as Val29, chkValue30 as Val30
    , PassOrNG as PassOrNG
    , Remark

	,cast(null as decimal(16,4)) as [MAX]
	,cast(null as decimal(16,4)) as [MIN]
	,cast(null as decimal(16,4)) as [AVG]
	,cast(null as decimal(16,4)) as [σ]
	,cast(null as decimal(16,4)) as [CP]
	,cast(null as decimal(16,4)) as [Ca]
	,cast(null as decimal(16,4)) as [CPK]

FROM      _TH_ChkValues01
where cCode = '{0}'
    and ( chkItemName like '%高度%' or  chkItemName like '%平行度%')
order by iID
";
            sSQL = string.Format(sSQL, sCode);
            DataTable dtGrid高度 = DbHelperSQL.Query(sSQL);
            gridControl高度.DataSource = dtGrid高度;

            sSQL = @"
select  iID, WONo, MODid
    ,chkItemCode as 检验项目编码, chkItemName as 检验项目, chkStd, chkMax 上限, chkMin 下限
    , chkValue01 as Val01, chkValue02 as Val02  ,chkValue03 as Val03, chkValue04 as Val04, chkValue05 as Val05
    , chkValue06 as Val06, chkValue07 as Val07  ,chkValue08 as Val08, chkValue09 as Val09, chkValue10 as Val10
    , chkValue11 as Val11, chkValue12 as Val12  ,chkValue13 as Val13, chkValue14 as Val14, chkValue15 as Val15
    , chkValue16 as Val16, chkValue17 as Val17  ,chkValue18 as Val18, chkValue19 as Val19, chkValue20 as Val20
    , chkValue21 as Val21, chkValue22 as Val22  ,chkValue23 as Val23, chkValue24 as Val24, chkValue25 as Val25
    , chkValue26 as Val26, chkValue27 as Val27  ,chkValue28 as Val28, chkValue29 as Val29, chkValue30 as Val30
    , PassOrNG as PassOrNG
    , Remark

	,cast(null as decimal(16,4)) as [MAX]
	,cast(null as decimal(16,4)) as [MIN]
	,cast(null as decimal(16,4)) as [AVG]
	,cast(null as decimal(16,4)) as [σ]
	,cast(null as decimal(16,4)) as [CP]
	,cast(null as decimal(16,4)) as [Ca]
	,cast(null as decimal(16,4)) as [CPK]

FROM      _TH_ChkValues01
where cCode = '{0}'
    and (chkItemName like '%外径%' or chkItemName like '%圆度%' or chkItemName like '%大小头%')
order by iID
";
            sSQL = string.Format(sSQL, sCode);
            DataTable dtGrid外径 = DbHelperSQL.Query(sSQL);
            gridControl外径.DataSource = dtGrid外径;

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                JS(i);
            }
            for (int i = 0; i < gridView高度.RowCount; i++)
            {
                JS_G(i);
            }
            for (int i = 0; i < gridView外径.RowCount; i++)
            {
                JS_W(i);
            }


            SetEnable(false);
    
        }

        private void btn新增_Click(object sender, EventArgs e)
        {
            try
            {
                SetEnable(true);
                SetTxtNull();

                btnLoad.Enabled = true;
            }
            catch { }
        }

        private void btn删除_Click(object sender, EventArgs e)
        {
            try
            {
                string sSQL = "select * from _TH_ChkValue01 where cCode = '{0}'";
                sSQL = string.Format(sSQL, txtcCode.Text.Trim());
                DataTable dt = DbHelperSQL.Query(sSQL);

                if (dt == null || dt.Rows.Count == 0)
                {
                    throw new Exception("单据尚未保存");
                }

                if (dt != null && dt.Rows.Count > 0 && dt.Rows[0]["AuditUid"].ToString().Trim() != "")
                {
                    throw new Exception("单据已经审核");
                }

                DateTime dtmNow = DateTime.Now;

                sSQL = @"
delete _TH_ChkValue01 where cCode = '{0}';
delete _TH_ChkValues01 where cCode = '{0}';

";
                sSQL = string.Format(sSQL, txtcCode.Text.Trim());
                int iCou = DbHelperSQL.ExecuteSql(sSQL);
                if (iCou > 0)
                {
                    txt审核人.Text = sUserName;
                    dtm审核日期.DateTime = dtmNow;
                    MessageBox.Show("删除成功");

                    SetEnable(false);

                    SetTxtNull();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("删除失败:" + ee.Message);
            }
        }

        private void bnt撤销_Click(object sender, EventArgs e)
        {
            try 
            {
                if (txtcCode.Text.Trim() == "")
                {
                    SetTxtNull();
                    SetEnable(false);
                }
                else
                {
                    GetGrid(txtcCode.Text.Trim());
                }
            }
            catch { }
        }

        private void txt不合格单件_EditValueChanged(object sender, EventArgs e)
        {
            if (BaseFunction.ReturnDecimal(txt不合格万件.EditValue) != 0)
            {
                txt万件个.EditValue = BaseFunction.ReturnDecimal(BaseFunction.ReturnDecimal(txt不合格单件.EditValue) * 1000 / BaseFunction.ReturnDecimal(txt不合格万件.EditValue) / 10000, 4);
            }
        }
    }
}
