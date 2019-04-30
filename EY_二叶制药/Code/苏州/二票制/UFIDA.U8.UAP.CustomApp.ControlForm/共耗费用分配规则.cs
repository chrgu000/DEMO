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

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class 共耗费用分配规则 : UserControl
    {
        TH.BaseClass.GetBaseData getBaseData = new GetBaseData();
        
        string sProPath = Application.StartupPath;

        UFIDA.U8.UAP.CustomApp.ControlForm.RepBaseGrid Rep = new RepBaseGrid();

        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }



        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                SetLookUp();
                GetGrid();
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "加载窗体失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        public 共耗费用分配规则()
        {
            InitializeComponent();
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

        private void SetLookUp()
        {
            string sSQL = "select sType from [dbo].[_CostType] where iType = 1 order by sType";
            DataTable dt = DbHelperSQL.Query(sSQL);
            lookUpEditCostType.Properties.DataSource = dt;
            if (dt != null && dt.Rows.Count > 0)
            {
                lookUpEditCostType.EditValue = dt.Rows[0]["sType"];
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                if (lookUpEditCostType.EditValue == null || lookUpEditCostType.EditValue.ToString().Trim() == "")
                {
                    throw new Exception("请选择费用类型");
                }

                DialogResult d = MessageBox.Show("确定删除该费用类型下的分配比例么?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (d == DialogResult.Yes)
                {
                    string sSQL = "delete _AlocationProportion where CostType = '" + lookUpEditCostType.EditValue.ToString().Trim() + "'";
                    int iCou = DbHelperSQL.ExecuteSql(sSQL);

                    if (iCou > 0)
                    {
                        MessageBox.Show("删除成功");
                        GetGrid();
                    }
                    else
                    {
                        MessageBox.Show("没有需要删除的数据");
                    }
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "删除失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
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

                string sErr = "";
                int iCou = 0;
                SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    string s费用类型 = lookUpEditCostType.EditValue.ToString().Trim();
                    if (s费用类型 == "")
                    {
                        lookUpEditCostType.Focus();
                        throw new Exception("费用不能为空");
                    }

                    string sSQL = "delete _AlocationProportion where [CostType] = '" + lookUpEditCostType.EditValue.ToString().Trim() + "'";
                    DbHelperSQL.ExecuteNonQuery(tran,CommandType.Text,sSQL);

                    decimal d总比例 = 0;
                    for(int i=0;i<gridView1.RowCount;i++)
                    {
                        decimal d = TH.BaseClass.BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i,gridColdPercentage),2);
                        d总比例 = d总比例 + d;

                        Model._AlocationProportion model = new UFIDA.U8.UAP.CustomApp.ControlForm.Model._AlocationProportion();
                        model.cDepCode = gridView1.GetRowCellValue(i,gridColcDepCode).ToString().Trim();
                        model.CostType = lookUpEditCostType.EditValue.ToString().Trim();
                        model.dPercentage = d;
                        model.Remark = gridView1.GetRowCellValue(i,gridColRemark).ToString().Trim();

                        DAL._AlocationProportion dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._AlocationProportion();
                        sSQL = dal.Add(model);
                        iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran,CommandType.Text,sSQL);
                    }

                    if(d总比例 != 100)
                    {
                        throw new Exception("分配比例汇总后必须是100");
                    }


                    tran.Commit();

                    GetGrid();

                    if (iCou > 0)
                    {
                        MessageBox.Show("保存成功");
                    }
                }
                catch (Exception error)
                {
                    tran.Rollback();
                    throw new Exception(error.Message);
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "保存失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }


        private void GetGrid()
        {
            try
            {
                if (lookUpEditCostType.EditValue == null || lookUpEditCostType.EditValue.ToString().Trim() == "")
                {
                    throw new Exception("请选择费用类型");
                }

                string sSQL = @"
select a.cDepCode,a.cDepName,b.[CostType],b.[dPercentage],b.[Remark]
from department a left join [dbo].[_AlocationProportion] b on a.[cDepCode] = b.[cDepCode] and b.[CostType] = '111111'
where isnull(a.bDepEnd,0) = 1 and isnull(a.cDepType,'') = '成本'
order by a.cDepCode
";

                sSQL = sSQL.Replace("111111", lookUpEditCostType.EditValue.ToString());
                DataTable dt = DbHelperSQL.Query(sSQL);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    decimal d = TH.BaseClass.BaseFunction.ReturnDecimal(dt.Rows[i]["dPercentage"], 2);
                    if (d == 0)
                        dt.Rows[i]["dPercentage"] = DBNull.Value;
                }

                gridControl1.DataSource = dt;
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }

        private void lookUpEditCostType_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }





    }
}
