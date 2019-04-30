using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace ImportDLL
{
    public partial class Replist2 : DevExpress.XtraReports.UI.XtraReport
    {
        public Replist2()
        {
            InitializeComponent();
            
        }

        private void Replist_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (dsPrint.Tables[0].Rows[0]["材料类型"].ToString().Trim() == "棒")
            {
                table2.DeleteColumn(tableCell16);
                table2.DeleteColumn(tableCell25);
                table2.DeleteColumn(tableCell29);
                table1.DeleteColumn(tableCell10);
                table1.DeleteColumn(tableCell6);
                table1.DeleteColumn(tableCell38);
                tableCell20.Text = "直径";
                tableCell17.Text = "直径";
                tableCell26.Text = "直径";

                tableCell48.WidthF = tableCell13.WidthF + tableCell14.WidthF + tableCell15.WidthF + tableCell20.WidthF + tableCell19.WidthF + tableCell18.WidthF + tableCell21.WidthF;
                tableCell53.WidthF = tableCell17.WidthF + tableCell23.WidthF + tableCell22.WidthF + tableCell24.WidthF;
            }

        }

    }
}
