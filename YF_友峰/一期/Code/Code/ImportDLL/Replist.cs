using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace ImportDLL
{
    public partial class Replist : DevExpress.XtraReports.UI.XtraReport
    {
        public Replist()
        {

            InitializeComponent();
        }

        private void Replist_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (dsPrint.Tables[0].Rows[0]["材料类型"].ToString().Trim() == "棒")
            {
                table3.DeleteColumn(tableCell30);
                table1.DeleteColumn(tableCell4);
                tableCell31.Text = "直径";
                tableCell25.WidthF = tableCell29.WidthF + tableCell31.WidthF + tableCell32.WidthF + tableCell33.WidthF;
            }

        }

    }
}
