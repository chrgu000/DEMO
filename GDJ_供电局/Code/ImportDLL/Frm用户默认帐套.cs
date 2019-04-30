using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace ImportDLL
{
    public partial class Frm用户默认帐套 : Form
    {

        FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();
        string sUserID;
        public DataTable dt = new DataTable();

        public Frm用户默认帐套(string sUid)
        {
            InitializeComponent();

            sUserID = sUid;
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

        

        private void Frm用户默认帐套_Load(object sender, EventArgs e)
        {
            try
            {
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得用户帐套信息失败");
            }
        }

        private void btn刷新_Click(object sender, EventArgs e)
        {
            try
            {
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得用户帐套信息失败");
            }
        }

        private void GetGrid()
        {
            string sSQL = @"
SELECT distinct A.cAcc_Id as 帐套号,A.cAcc_Name as 帐套名称,cast( case when isnull(c.帐号,'') = '' then 0 else 1 end as bit) as 选择
FROM UFSystem.dbo.UA_Account A inner join UFSystem.dbo.UA_period P on A.cAcc_Id=P.cAcc_Id AND (P.bIsDelete=0 OR P.bIsDelete IS NULL) 
	left join dbo.用户默认帐套 c on A.cAcc_Id = c.帐套 and c.帐号 = '111111'
WHERE 1=1
order by A.cAcc_Id
";
            sSQL = sSQL.Replace("111111", sUserID);
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dt;
        }

        private void btn保存_Click(object sender, EventArgs e)
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            try
            {
                ArrayList aList = new ArrayList();
                string sSQL = "delete 用户默认帐套 where 帐号 = '" + sUserID + "' ";
                aList.Add(sSQL);

                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    bool b = Convert.ToBoolean(gridView1.GetRowCellValue(i, gridCol选择));
                    if (!b)
                        continue;

                    sSQL = "insert into dbo.用户默认帐套(帐号,帐套)values('" + sUserID + "','" + gridView1.GetRowCellValue(i, gridCol帐套号).ToString().Trim() + "')";
                    aList.Add(sSQL);
                }

                if (aList.Count > 0)
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("保存成功");
                }
                else
                {
                    throw new Exception("没有选择需要保存的帐套");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("保存失败:" + ee.Message);
            }
        }

        private void btn确定_Click(object sender, EventArgs e)
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            dt = (DataTable)gridControl1.DataSource;
            this.DialogResult = DialogResult.Yes;
        }

        private void btn取消_Click(object sender, EventArgs e)
        {
            dt = null;
            this.DialogResult = DialogResult.No;
        }

        private void chk全选_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chk全选.Checked)
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        gridView1.SetRowCellValue(i, gridCol选择, true);
                    }
                }
                else
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        gridView1.SetRowCellValue(i, gridCol选择, false);
                    }
                }
            }
            catch { }
        }
    }
}
