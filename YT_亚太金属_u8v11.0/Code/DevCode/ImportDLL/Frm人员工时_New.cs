using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImportDLL
{
    public partial class Frm人员工时_New : Form
    {
        DataTable dt = new DataTable();
        public string 人员;
        public string 工时;
        public string OpSeq;
        public Frm人员工时_New(string s人员, string s工时)
        {
            人员 = s人员;
            工时 = s工时;
            InitializeComponent();
            
        }

        public Frm人员工时_New()
        {
            InitializeComponent();

            #region 禁止用户调整表格

            layoutControl1.AllowCustomizationMenu = false;

            //gridView1.OptionsMenu.EnableColumnMenu = false;
            //gridView1.OptionsMenu.EnableFooterMenu = false;
            //gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            //gridView1.OptionsMenu.ShowAutoFilterRowItem = false;
            //gridView1.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            //gridView1.OptionsMenu.ShowGroupSortSummaryItems = false;
            //gridView1.OptionsMenu.ShowGroupSummaryEditorItem = false;
            //gridView1.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.False;
            //gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            //gridView1.OptionsCustomization.AllowColumnMoving = false;
            //gridView1.OptionsCustomization.

            #endregion
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm委外订单_New_Load(object sender, EventArgs e)
        {
            try
            {
                LookUp.Person(ItemLookUpEdit人员);
                LookUp.Person(ItemLookUpEdit人员2);
                ItemLookUpEdit人员.Properties.DisplayMember = "PersonCode";
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败：" + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void GetGrid()
        {
            
            dt.Columns.Add("人员编码");
            dt.Columns.Add("工时",typeof(decimal));
            string[] sp1 = 人员.Split(',');
            string[] sp2 = 工时.Split(',');
            for (int i = 0; i < sp1.Length; i++)
            {
                if (sp1[i] != "")
                {
                    DataRow dw = dt.NewRow();
                    dw["人员编码"] = sp1[i];
                    if (sp2[i] != "")
                    {
                        dw["工时"] = sp2[i];
                    }
                    dt.Rows.Add(dw);
                }
            }
            gridControl1.DataSource = dt;
            gridView1.AddNewRow();
        }

        private void btnEnsure_Click(object sender, EventArgs e)
        {
            string sErr = "";
            int icount = 0;
            人员 = "";
            工时 = "";
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridCol人员编码).ToString().Trim() != "")
                {
                    icount = icount + 1;
                }
                if (gridView1.GetRowCellValue(i, gridCol人员编码).ToString().Trim() != "" && gridView1.GetRowCellValue(i, gridCol工时).ToString().Trim() == "")
                {
                    sErr = sErr+ i + "行工时不可为空" + "\n";
                }
                if (gridView1.GetRowCellValue(i, gridCol人员编码).ToString().Trim() != "" && gridView1.GetRowCellValue(i, gridCol工时).ToString().Trim() != "")
                {
                    if(人员!="")
                    {
                        人员=人员+",";
                        工时=工时+",";
                    }
                    人员=人员+gridView1.GetRowCellValue(i, gridCol人员编码).ToString().Trim();
                    工时=工时+gridView1.GetRowCellValue(i, gridCol工时).ToString().Trim();
                }

            }
            if (icount==0)
            {
                sErr = sErr + "请至少选择一个人员";
            }
            if (sErr != "")
            {
                MessageBox.Show(sErr);
            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void button查询_Click(object sender, EventArgs e)
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

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            //for (int i = 0; i < gridView1.RowCount; i++)
            //{
            //    if (gridView1.IsRowSelected(i))
            //    {
            //        if (gridView1.GetRowCellValue(i, gridCol选择).ToString().Trim() == "")
            //        {
            //            gridView1.SetRowCellValue(i, gridCol选择, "√");
            //        }
            //        else
            //        {
            //            gridView1.SetRowCellValue(i, gridCol选择, "");
            //        }
            //    }
            //}
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = null;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int iRow = 0;
            try
            {
                if (gridView1.FocusedRowHandle >= 0)
                    iRow = gridView1.FocusedRowHandle;

                if (e.Column == gridCol工时 && e.RowHandle == gridView1.RowCount - 1 && gridView1.GetRowCellDisplayText(e.RowHandle, gridCol工时).ToString().Trim() != "")
                {
                    gridView1.AddNewRow();
                    gridView1.FocusedRowHandle = gridView1.RowCount - 1;
                    int row = gridView1.RowCount - 1;
                }
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }

        }

        private void btn删行_Click(object sender, EventArgs e)
        {
            for (int i = gridView1.RowCount - 1; i >= 0; i--)
            {
                if (gridView1.IsRowSelected(i))
                {
                    gridView1.DeleteRow(i);
                }
            }
        }
      
    }
}
