using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace 系统服务
{
    public static class 规格化
    {
        public static decimal ReturnDecimal(object o)
        {
            decimal d = 0;
            try
            {
                d = decimal.Round(Convert.ToDecimal(o), 6);
            }
            catch { }
            return d;
        }
        public static decimal ReturnDecimal(object o, int iLength)
        {
            decimal d = 0;
            try
            {
                d = decimal.Round(Convert.ToDecimal(o), iLength);
            }
            catch { }
            return d;
        }


        public static int ReturnInt(object o)
        {
            int d = 0;
            try
            {
                d = Convert.ToInt32(o);
            }
            catch { }
            return d;
        }

        public static string ReturnDateTimeString(object o)
        {
            string d = "";
            try
            {
                if (Convert.ToDateTime(o) >= Convert.ToDateTime("1900-01-01"))
                {
                    d = Convert.ToDateTime(o).ToString("yyyy-MM-dd");
                }
            }
            catch { }
            return d;
        }

        public static void ReturnDate(out string d1, out string d2, bool b本日, bool b本月, bool b本季, bool b本年)
        {
            if (b本日 == true)
            {
                d1 = DateTime.Now.ToString("yyyy-MM-dd");
                d2 = DateTime.Now.ToString("yyyy-MM-dd");
            }
            else if (b本月 == true)
            {
                d1 = (DateTime.Now.AddDays(1 - DateTime.Now.Day)).ToString("yyyy-MM-dd");
                d2 = ((DateTime.Now.AddDays(1 - DateTime.Now.Day)).AddMonths(1).AddDays(-1)).ToString("yyyy-MM-dd");
            }
            else if (b本季 == true)
            {
                d1 = (DateTime.Now.AddMonths(0 - (DateTime.Now.Month - 1) % 3).AddDays(1 - DateTime.Now.Day)).ToString("yyyy-MM-dd");
                d2 = (DateTime.Now.AddMonths(0 - (DateTime.Now.Month - 1) % 3).AddDays(1 - DateTime.Now.Day)).AddMonths(3).AddDays(-1).ToString("yyyy-MM-dd");
            }
            else if (b本年 == true)
            {
                d1 = (new DateTime(DateTime.Now.Year, 1, 1)).ToString("yyyy-MM-dd");
                d2 = (new DateTime(DateTime.Now.Year, 12, 31)).ToString("yyyy-MM-dd");
            }
            else
            {
                d1 = "";
                d2 = "";
            }
        }

        public static bool ReturncHandler(bool b审核, bool b未审)
        {
            if (b审核 == true)
            {
                return true;
            }
            else if (b未审 == true)
            {
                return false;
            }
            return false;
        }


        public static bool ReturncHas(bool b包含未发生物料, bool b不包含未发生物料)
        {
            if (b包含未发生物料 == true)
            {
                return true;
            }
            else if (b不包含未发生物料 == true)
            {
                return false;
            }
            return false;
        }

        public static void GetGridViewSet(DevExpress.XtraGrid.Views.Grid.GridView gridView1)
        {
            gridView1.OptionsBehavior.CopyToClipboardWithColumnHeaders = false;
            gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
            gridView1.OptionsCustomization.AllowSort = false;
            gridView1.OptionsLayout.Columns.StoreAllOptions = true;
            gridView1.OptionsLayout.Columns.StoreAppearance = true;
            gridView1.OptionsLayout.StoreAllOptions = true;
            gridView1.OptionsLayout.StoreAppearance = true;
            gridView1.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.True;
            gridView1.OptionsMenu.ShowGroupSummaryEditorItem = true;
            gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            gridView1.OptionsSelection.MultiSelect = true;
            gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            gridView1.OptionsView.AutoCalcPreviewLineCount = true;
            gridView1.OptionsView.EnableAppearanceEvenRow = true;
            gridView1.OptionsView.EnableAppearanceOddRow = true;
            gridView1.OptionsView.ShowFooter = true;
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.OptionsPrint.AutoWidth = false;

        }
    }
}
