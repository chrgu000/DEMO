using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SaleOrder
{
    public partial class Frm物料供需分析 : Form
    {
        protected FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();
        protected FrameBaseFunction.ClsGetSQL clsGetSQL = FrameBaseFunction.ClsGetSQL.Instance();

        public DataTable dtSEL = new DataTable();
        public string sInvCode;
        public string sSaleOrder;
        int iType = 0;

        public Frm物料供需分析()
        {
            InitializeComponent();

            #region 禁止用户调整表格

            layoutControl1.AllowCustomizationMenu = false;

            gridView1.OptionsMenu.EnableColumnMenu = false;
            gridView1.OptionsMenu.EnableFooterMenu = false;
            gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            gridView1.OptionsMenu.ShowAutoFilterRowItem = false;
            gridView1.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            gridView1.OptionsMenu.ShowGroupSortSummaryItems = false;
            gridView1.OptionsMenu.ShowGroupSummaryEditorItem = false;
            gridView1.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.False;
            gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            gridView1.OptionsCustomization.AllowColumnMoving = false;
            //gridView1.OptionsCustomization.

            #endregion
        }

        public Frm物料供需分析(string s_InvCode)
        {
            InitializeComponent();

            iType = 1;

            #region 禁止用户调整表格

            layoutControl1.AllowCustomizationMenu = false;

            gridView1.OptionsMenu.EnableColumnMenu = false;
            gridView1.OptionsMenu.EnableFooterMenu = false;
            gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            gridView1.OptionsMenu.ShowAutoFilterRowItem = false;
            gridView1.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            gridView1.OptionsMenu.ShowGroupSortSummaryItems = false;
            gridView1.OptionsMenu.ShowGroupSummaryEditorItem = false;
            gridView1.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.False;
            gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            gridView1.OptionsCustomization.AllowColumnMoving = false;
            //gridView1.OptionsCustomization.

            #endregion
        } 

        private void Frm物料供需分析_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;

            GetLookUp();

            btnSEL_Click(null, null);
        }

        private void btnSEL_Click(object sender, EventArgs e)
        {
            try
            {
                if (iType == 0)
                {
                    string sSQL = "exec @u8._Get供需分析 '" + sInvCode + "','" + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim() + "','" + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4)).Trim() + "','" + sSaleOrder + "'";
                    clsSQLCommond.ExecSql(sSQL);

                    sSQL = "select * from @u8.Get供需分析";
                    dtSEL = clsSQLCommond.ExecQuery(sSQL);
                    gridControl1.DataSource = dtSEL;
                }
                if (iType == 1)
                {
                    string sSQL = @"
truncate table @u8._temp缺料
";
                    clsSQLCommond.ExecSql(sSQL);


                    sSQL = "exec @u8._Get供需分析2 '" + sInvCode + "','" + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim() + "','" + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4)).Trim() + "','" + sSaleOrder + "';insert into @u8._temp缺料 select * from @u8.Get供需分析 order by 外销单号,供需类型,单据号 ";
                    clsSQLCommond.ExecSql(sSQL);

                    sSQL = @"
select distinct cInvCode from [XWSystemDB_DL].[dbo].[_GetBOM] where InvCode = '{0}'
";
                    sSQL = string.Format(sSQL, sInvCode);
                    DataTable dtBom = clsSQLCommond.ExecQuery(sSQL);

                    for (int i = 0; i < dtBom.Rows.Count; i++)
                    {
                        string scInvCode = dtBom.Rows[i]["cInvCode"].ToString().Trim();

                        sSQL = "exec @u8._Get供需分析2 '" + scInvCode + "','" + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim() + "','" + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4)).Trim() + "','" + sSaleOrder + "';insert into @u8._temp缺料 select * from @u8.Get供需分析 order by 外销单号,供需类型,单据号 ";
                        clsSQLCommond.ExecSql(sSQL);
                    }

                    sSQL = "select * from @u8._temp缺料";
                    dtSEL = clsSQLCommond.ExecQuery(sSQL);
                    gridControl1.DataSource = dtSEL;

                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载数据失败:" + ee.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sInvCode">物料编码</param>
        /// <param name="sSaleOrder">销售订单号</param>
        /// <param name="iType">类型，1：不考虑供需日期，其他：考虑供需日期</param>
        /// <returns></returns>
        public DataTable Get物料供需分析汇总表(string sInvCode, string sSaleOrder,int iType)
        {
            if (sInvCode == "B001")
            { 
            
            }

            string sSQL = "exec @u8._Get供需分析 '" + sInvCode + "','" + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim() + "','" + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4)) + "','" + sSaleOrder + "';";

            sSQL = sSQL + "select 存货编码,sum(isnull(现存量,0)) as 现存量,sum(isnull(待入库,0)) as 待入库,sum(isnull(待出库,0)) as 待出库 from @u8.Get供需分析 group by 存货编码";

            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            return dt;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch(Exception ee)
            {
                MessageBox.Show("查询失败:" + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void GetLookUp()
        {
            try
            {
                string sSQL = "select cInvCode as 存货编码,cInvName as 存货名称,cInvStd as 规格型号 from @u8.Inventory order by cInvCode ";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                ItemLookUpEdit存货编码.DataSource = dt;
                ItemLookUpEdit存货名称.DataSource = dt;
                ItemLookUpEdit规格型号.DataSource = dt;
            }
            catch
            {
                MessageBox.Show("获得参照信息失败!");
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
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
