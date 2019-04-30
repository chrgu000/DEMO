// Developer Express Code Central Example:
// How to create a custom TreeList that allows you to group tree list columns in bands in the same manner as in AdvancedGridView
// 
// This example demonstrates how to create a custom tree list with the capability
// to create bands in the same manner as in AdvancedGridView.
// Note that this is
// not a full implementation of bands in TreeList but just an example of how it can
// be done. Some features like Drag&Drop of bands and Column Chooser are disabled
// because of differences in TreeList layout calculation algorithm which does not
// support bands.
// A request to implement this feature out of the box is already
// registered in our Support Center: http://www.devexpress.com/scid=AS4236. You can
// subscribe to email notifications by adding this page to your favorites.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E3581

// Developer Express Code Central Example:
// How to create a custom TreeList that allows you to group tree list columns in bands in the same manner as in AdvancedGridView
// 
// This example demonstrates how to create a custom tree list with the capability
// to create bands in the same manner as in AdvancedGridView.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E3581
using System;
using System.Collections.Generic;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.ViewInfo;
using DevExpress.XtraTreeList.Handler;
using DevExpress.LookAndFeel;
using DevExpress.XtraTreeList.Menu;
using DevExpress.Utils.Menu;
using System.Collections;
using System.Data;

namespace MyXtraTreeList
{
    public class MyTreeList : TreeList
    {
        private MyTreeListBand fRootBand;

        public MyTreeListBandCollection fBands;
        public List<TreeListColumn> BandedColumns = new List<TreeListColumn>();

        public MyTreeList()
            : base()
        {
            Bands = new MyTreeListBandCollection(this);
            fRootBand = Bands[0];
            this.PopupMenuShowing += onPopupMenuShowing;
        }

        public MyTreeList(object ignore)
            : base(ignore)
        {
        }

        protected internal MyTreeListBand RootBand
        {
            get { return fRootBand; }
        }

        public MyTreeListBandCollection Bands
        {
            get { return fBands; }
            set
            {
                if (fBands != value)
                {
                    fBands = value;
                    fBands.UpdateColumns();
                }
            }
        }

        protected override DevExpress.XtraTreeList.Painter.TreeListPainter CreatePainter()
        {
            return base.CreatePainter();
        }

        public new MyTreeListViewInfo ViewInfo
        {
            get { return base.ViewInfo as MyTreeListViewInfo; }
        }

        protected override TreeListViewInfo CreateViewInfo()
        {
            return new MyTreeListViewInfo(this);
        }

        protected override TreeListHandler CreateHandler()
        {
            return new MyTreeListHandler(this);
        }

        public bool Swap(MyTreeListBand BandA, MyTreeListBand BandB)
        {
            if (BandA.Parent != null)
            {
                return BandA.Parent.TryToSwap(BandA, BandB);
            }
            return false;
        }

        public bool Swap(MyTreeListBand Band, TreeListColumn Column)
        {
            if (Band.Parent != null)
            {
                return Band.Parent.TryToSwapBandAndColumn(Band, Column);
            }
            return false;
        }

        public bool Swap(TreeListColumn ColumnA, TreeListColumn ColumnB)
        {
            return RootBand.TryToSwapColumns(ColumnA, ColumnB);
        }

        internal void MyRaiseDragObjectOver(DragObjectOverEventArgs e)
        {
            RaiseDragObjectOver(e);
        }

        internal void MyRaiseDragObjectDrop(DragObjectDropEventArgs e)
        {
            RaiseDragObjectDrop(e);
        }

        public void SetBandsWidth(int Width)
        {
            RootBand.SetWidth(Width);
        }

        //yuxia
        public void ExportToXls(string FileName)
        {
            Export(DevExpress.XtraPrinting.ExportTarget.Xls, FileName);
        }

        protected internal new UserLookAndFeel ElementsLookAndFeel
        {
            get { return base.ElementsLookAndFeel; }
        }

        protected override void ResizeColumn(int index, int byUnits, int maxPossibleWidth)
        {
            if (ViewInfo.BandLinks.ContainsKey(VisibleColumns[index]))
            {
                MyTreeListBandCollection childBands = ViewInfo.BandLinks[VisibleColumns[index]].Band.Children;
                TreeListColumn[] childColumns = ViewInfo.BandLinks[VisibleColumns[index]].Band.Columns;
                int unitsPerChild = byUnits / (childBands.Count + childColumns.Length);
                foreach (MyTreeListBand band in childBands)
                {
                    if (band.Visible && band.BandColumn != null)
                        ResizeColumn(band.BandColumn.VisibleIndex, unitsPerChild, maxPossibleWidth);
                }
                foreach (TreeListColumn col in childColumns)
                {
                    if (col != null && col.Visible)
                        ResizeColumn(col.VisibleIndex, unitsPerChild, maxPossibleWidth);
                }
            }
            else
                base.ResizeColumn(index, byUnits, maxPossibleWidth);
        }

        void onPopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.Menu.MenuType == TreeListMenuType.Column)
            {
                foreach (DXMenuItem item in e.Menu.Items)
                {
                    if (item.Caption == "Column Chooser")
                    {
                        item.Enabled = false;
                        break;
                    }
                }
            }
        }

        int id;
        //void 

        //internal DevExpress.XtraTreeList.Scrolling.ScrollInfo MyScrollInfo { get { return typeof(TreeList).GetProperty("ScrollInfo", System.Reflection.BindingFlags.GetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(this, new object[] { }) as DevExpress.XtraTreeList.Scrolling.ScrollInfo; } }

        //override makec

        public void Band(DataTable dt, DataTable dtBind, string[] group, string[] sum, string[] col)
        {
            id = 0;
            GetTree(dt, dtBind, 0, 0, new ArrayList(), group, sum, col);
            this.DataSource = dtBind;
            //myTreeList1.ForceInitialize();
            //this.ExpandAll();
            //this.ViewInfo.RC.NeedsRestore = true;
            //this.BestFitColumns();
            //this.LayoutChanged();
            
        }

        private void GetTree(DataTable dt, DataTable dtBind, int pid, int level, ArrayList Val, string[] group, string[] sum, string[] col)
        {
            DataTable dtgroup;

            //string[] sum = GetGroupSum();
            //string[] col = GetCol();
            ////得到汇总列
            //string[] group = GetGroup(flag);

            string[] sgroup;
            if (group.Length - 1 != level)
            {
                sgroup = new string[level + 1];
                for (int i = 0; i < level + 1; i++)
                {
                    sgroup[i] = group[i];
                }
            }
            else
            {
                sgroup = new string[level + 1 + col.Length];
                for (int i = 0; i < level + 1; i++)
                {
                    sgroup[i] = group[i];
                }
                for (int i = 0; i < col.Length; i++)
                {
                    sgroup[level + 1 + i] = col[i];
                }
            }

            if (level == 0)
            {
                dtgroup = 系统服务.Tables.Group(dt
                   , sgroup
                   , sum);
            }
            else
            {
                string[,] swhere = new string[level, 2];
                for (int i = 0; i < level; i++)
                {
                    swhere[i, 0] = group[i];
                    swhere[i, 1] = Val[i].ToString();
                }
                dtgroup = 系统服务.Tables.Group(dt,
                       sgroup,
                       sum,
                       swhere);
            }
            //try
            //{
            //    if (dtgroup.Select("cinvcode='040105050001'").Length > 0)
            //    {
            //        string s = "";
            //    }
            //}
            //catch
            //{
            //}
            for (int i = 0; i < dtgroup.Rows.Count; i++)
            {
                id = id + 1;
                ArrayList sVal = new ArrayList();
                DataRow dw1 = dtBind.NewRow();
                dw1["ID"] = id;
                dw1["ParentID"] = pid;
                dw1["TreeList"] = dtgroup.Rows[i][sgroup[level]].ToString();
                for (int j = 0; j < sgroup.Length; j++)
                {
                    sVal.Add(dtgroup.Rows[i][sgroup[j]].ToString());
                }
                if (group.Length - 1 == level)
                {
                    for (int j = 0; j < col.Length; j++)
                    {
                        dw1[col[j]] = dtgroup.Rows[i][col[j]];
                    }
                }
                //汇总项
                for (int j = 0; j < sum.Length; j++)
                {
                    //if (group.Length - 1 != level && (sum[j] == "最新价格" || sum[j] == "年度均价" || sum[j] == "月度均价"))
                    //{
                    //}
                    //else if (dtgroup.Rows[i][sum[j]].ToString() != "0")
                    //{
                    //    dw1[sum[j]] = dtgroup.Rows[i][sum[j]];
                    //}
                    if (dtgroup.Rows[i][sum[j]].ToString() != "0")
                    {
                        dw1[sum[j]] = dtgroup.Rows[i][sum[j]];
                    }
                }
                
                dtBind.Rows.Add(dw1);
                if (level < group.Length - 1)
                {
                    GetTree(dt, dtBind, id, level + 1, sVal, group, sum, col);
                }
            }
        }

    }
}