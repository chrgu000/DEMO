using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 业务
{
    public partial class Frm发货计划_New : Form
    {
        protected 系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
        protected 系统服务.ClsGetSQL clsGetSQL = 系统服务.ClsGetSQL.Instance();
        public string 供应商;
        public DataTable dt;
        DataTable dthas;
        public Frm发货计划_New(DataTable sdthas)
        {
           
            InitializeComponent();
            dthas = sdthas;
        }

        public Frm发货计划_New()
        {
            InitializeComponent();

            #region 禁止用户调整表格

            layoutControl1.AllowCustomizationMenu = false;


            #endregion
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm发货计划_New_Load(object sender, EventArgs e)
        {
            try
            {
                if (供应商.Trim() != "")
                {
                    lookUpEdit供应商.EditValue = 供应商;
                    lookUpEdit供应商.Enabled = false;
                }
                else
                {
                    lookUpEdit供应商.Enabled = true;
                }

                SetLookUpEdit();
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败：" + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void GetGrid()
        {
            if (供应商.Trim() == "")
                return;

            string sSQL = @"
select '' as iChk,a.*,isnull(b.iDelQty,0) as iDelQty,i.cInvName ,a.id as RegistersID
	,i.cPosition,p.cPosName
from Registers a 
    left join (select rid,SUM(iDelQty) as iDelQty from ShipmentPlans group by rid) b on a.ID=b.rID 
    left join @u8.Inventory i on a.InvCode=i.cInvCode 
    left join @u8.Position p on i.cPosition = p.cPosCode
where 1=1 and isnull(a.iQty,0)-isnull(b.iDelQty,0)>0 ";
            if (lookUpEdit供应商.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and VenCode like '%" + lookUpEdit供应商.EditValue.ToString().Trim() + "%' ");
            }
            if (lookUpEdit定单编号.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and OrderNo like '%" + lookUpEdit定单编号.EditValue.ToString().Trim() + "%' ");
            }
            if (dateEdit纳入指示日1.EditValue != null && dateEdit纳入指示日1.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL + " and a.iSheDate >= '" + dateEdit纳入指示日1.DateTime.ToString("yyyy-MM-dd").Trim() + "'";
            }
            if (dateEdit纳入指示日2.EditValue != null && dateEdit纳入指示日2.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL + " and a.iSheDate<'" + dateEdit纳入指示日2.DateTime.AddDays(1).ToString("yyyy-MM-dd").Trim() + "'";
            }
            if (dthas.Rows.Count != 0)
            {
                string s = "";
                for (int i = 0; i < dthas.Rows.Count; i++)
                {
                    if (dthas.Rows[i].RowState == DataRowState.Deleted)
                        continue;

                    if (dthas.Rows[i]["rID"].ToString() != "")
                    {
                        if (s != "")
                        {
                            s = s + ",";
                        }
                        s = s + dthas.Rows[i]["rID"].ToString();
                    }
                }
                if (s.Trim() != "")
                {
                    sSQL = sSQL + " and ID not in (" + s + ")";
                }
            }
            
            sSQL = sSQL + " order by  ID";
            dt = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dt;
        }

        public void Get(string 单据日期1, string 单据日期2,string 供应商,string 定单编号)
        {
            if (单据日期1 != null && 单据日期1 != "")
            {
                单据日期1 = DateTime.Parse(单据日期1).ToString("yyyy-MM-dd");
                dateEdit纳入指示日1.EditValue = 单据日期1;
            }
            if (单据日期2 != null && 单据日期2 != "")
            {
                单据日期2 = DateTime.Parse(单据日期2).ToString("yyyy-MM-dd");
                dateEdit纳入指示日2.EditValue = 单据日期2;
            }
            lookUpEdit供应商.EditValue = 供应商;
            lookUpEdit定单编号.EditValue = 定单编号;
        }

        private void SetLookUpEdit()
        {
            系统服务.LookUp.Vendor(lookUpEdit供应商);
            系统服务.LookUp.OrderNo(lookUpEdit定单编号);
        }

        private void btnEnsure_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.RowCount < 1)
                    return;

                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    if (dt.Rows[i]["iChk"] != "√")
                    {
                        dt.Rows.Remove(dt.Rows[i]);
                    }
                }
                供应商 = lookUpEdit供应商.EditValue.ToString().Trim();
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void button查询_Click(object sender, EventArgs e)
        {
            try
            {
                if (lookUpEdit供应商.Text.Trim() == "")
                {
                    throw new Exception("请选择供应商");
                }
                else
                {
                    供应商 = lookUpEdit供应商.EditValue.ToString().Trim();

                    GetGrid();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.IsRowSelected(i))
                {
                    if (gridView1.GetRowCellValue(i, gridCol选择) == "")
                    {
                        gridView1.SetRowCellValue(i, gridCol选择, "√");
                    }
                    else
                    {
                        gridView1.SetRowCellValue(i, gridCol选择, "");
                    }
                }
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

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAll.Checked)
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        gridView1.SetRowCellValue(i, gridCol选择, "√");
                    }
                }
                else
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        gridView1.SetRowCellValue(i, gridCol选择, "");
                    }
                }
            }
            catch { }
        }

    }
}
