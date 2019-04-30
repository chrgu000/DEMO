using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImportDLL
{
    public partial class Frm订单评审_Add : FrameBaseFunction.FrmAddSel
    {
        public string s销售订单ID = "";

        TH.Model.订单评审 Model = new TH.Model.订单评审();
        TH.Model.订单评审明细 ModelDetail = new TH.Model.订单评审明细();
        //TH.BLL.订单评审 BLL = new TH.BLL.订单评审();
        TH.DAL.订单评审 DAL = new TH.DAL.订单评审();
        TH.DAL.GetBaseData DALBaseData = new TH.DAL.GetBaseData();

        public Frm订单评审_Add()
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

        private void Frm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterParent;
            GetLookup();

            dtm单据日期1.Text = Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate).AddYears(-1).ToString("yyyy-MM-dd");
            dtm单据日期2.Text =DateTime.Parse( Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyy-MM-01")).AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");
            
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterParent;

            btnSEL_Click(null, null);
        }

        private void btnSEL_Click(object sender, EventArgs e)
        {
            try
            {
                string sSQLWhere = "";
                if (lookUpEdit销售订单号1.Text.Trim() != "")
                {
                    sSQLWhere = sSQLWhere + " and a.cSoCode >= '" + lookUpEdit销售订单号1.Text.Trim() + "'";
                }
                if (lookUpEdit销售订单号2.Text.Trim() != "")
                {
                    sSQLWhere = sSQLWhere + " and a.cSoCode <= '" + lookUpEdit销售订单号2.Text.Trim() + "'";
                }
                if (dtm单据日期1.Text.Trim() != "")
                {
                    sSQLWhere = sSQLWhere + " and a.dDate >= '" + dtm单据日期1.DateTime.ToString("yyyy-MM-dd") + "'";
                }
                if (dtm单据日期2.Text.Trim() != "")
                {
                    sSQLWhere = sSQLWhere + " and a.dDate <= '" + dtm单据日期2.DateTime.ToString("yyyy-MM-dd") + "'";
                }

                DataTable dt = DAL.GetSoMainList(sSQLWhere);
                gridControl1.DataSource = dt;
            }
            catch (Exception ee)
            {
                MsgBox("加载数据失败", ee.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.RowCount < 1)
                {
                    throw new Exception("没有数据");
                }

                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (Convert.ToBoolean(gridView1.GetRowCellValue(i, gridColChoose)))
                    {
                        //if (gridView1.GetRowCellDisplayText(i, gridCol存货编码).ToString().Trim() != "A53113200")
                        //{ 
                        
                        //}

                        if (s销售订单ID == "")
                            s销售订单ID = gridView1.GetRowCellValue(i, gridCol销售订单子表ID).ToString().Trim();
                        else
                            s销售订单ID = s销售订单ID + "," + gridView1.GetRowCellValue(i, gridCol销售订单子表ID).ToString().Trim();
                    }
                }

                if(s销售订单ID == "")
                {
                    throw new Exception("没有选择数据");
                }

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch(Exception ee)
            {
                MessageBox.Show("查询失败:" + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    gridView1.SetRowCellValue(i, gridColChoose, chkAll.Checked);
                }
            }
            catch { }
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
        
        private void GetLookup()
        {
            DataTable dt = DALBaseData.GetSoCode("");
           lookUpEdit销售订单号1.Properties.DataSource = dt;
           lookUpEdit销售订单号2.Properties.DataSource = dt;

        }
    }
}
