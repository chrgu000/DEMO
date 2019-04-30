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
using System.Drawing;
using DevExpress.XtraTreeList.ViewInfo;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.Utils.Drawing;

namespace MyXtraTreeList
{
    public class MyTreeListViewInfo : TreeListViewInfo
    {
        private int fBandMaxlevel;

        private int fBandHeight;

        private int fRowBandHeight;

        private int fRowLevelCount;

        private int fColCount;

        protected internal Dictionary<TreeListColumn, MyTreeListBandInfo> BandLinks;

        protected BandMap ColumnPanelBandMap;

        protected BandMap CellBandMap;

        public MyTreeListViewInfo(MyTreeList treeList)
            : base(treeList)
        {
            ColumnPanelBandMap = new BandMap();
            CellBandMap = new BandMap();
            BandLinks = new Dictionary<TreeListColumn, MyTreeListBandInfo>();
        }

        public new MyTreeList TreeList
        {
            get { return base.TreeList as MyTreeList; }
        }

        public new MyResourceInfo RC
        {
            get { return base.RC as MyResourceInfo; }
        }

        protected override ResourceInfo CreateResourceCache()
        {
            return new MyResourceInfo(this);
        }

        public virtual int BandMaxLevel
        {
            get { return fBandMaxlevel; }
            protected set { fBandMaxlevel = value; }
        }

        public virtual int BandHeight
        {
            get { return fBandHeight; }
            protected set { fBandHeight = value; }
        }

        public virtual int RowBandHeight
        {
            get { return fRowBandHeight; }
            protected set { fRowBandHeight = value; }
        }

        public virtual int RowLevelCount
        {
            get { return fRowLevelCount; }
            protected set { fRowLevelCount = value; }
        }

        public virtual int ColCount
        {
            get { return fColCount; }
            protected set { fColCount = value; }
        }

        protected virtual void CalcMaxBandLevel()
        {
            int max = 0;
            bool HasColumns = false;
            foreach (MyTreeListBand B in TreeList.Bands)
            {
                if (B.Level > max)
                {
                    max = B.Level;
                    HasColumns = B.HasColumns();
                }
            }
            if (HasColumns)
            {
                max++;
            }
            BandMaxLevel = max;
        }

        protected override void CalcColumnPanelHeight()
        {
            base.CalcColumnPanelHeight();
            BandHeight = ColumnPanelHeight;
            if (ColumnPanelHeight != 0)
            {
                CalcMaxBandLevel();
                RC.SetColumnPanelHeight(BandHeight * BandMaxLevel);
            }
        }

        protected override void CalcRowHeight()
        {
            base.CalcRowHeight();
            RowBandHeight = RC.RowHeight;
            if (CellBandMap.LevelCount > 0)
            {
                RC.SetRowHeight(RowBandHeight * CellBandMap.LevelCount);
            }
        }

        protected virtual void CalcBandsInfo()
        {
            int totoalWidth = 0;
            foreach (MyTreeListBand B in TreeList.Bands)
            {
                if ((B.Level > 0) && B.Visible && B.BandColumn == null)
                {
                    MyTreeListBandInfo bi = new MyTreeListBandInfo(B);
                    bi.CalcBandInfo(this);
                    ColumnsInfo.Columns.Add(bi);
                    totoalWidth += bi.Bounds.Width;
                }
            }
        }

        public override void CalcColumnsInfo()
        {
            ColCount = 0;
            BandLinks.Clear();
            base.CalcColumnsInfo();
            CalcBandsInfo();
            ColumnPanelBandMap.CalcBandMap(TreeList.RootBand);
            CellBandMap.CalcCellBandMap(TreeList.RootBand);
        }

        public override void CalcColumnInfo(ColumnInfo ci, ref int left, bool customization)
        {
            int offset = 0;
            base.CalcColumnInfo(ci, ref offset, customization);
            if (ci.Type == ColumnInfo.ColumnInfoType.Column)
            {
                MyTreeListBand ParentBand = TreeList.Bands.GetColumnParentBand(ci.Column);
                if (ParentBand == null)
                {
                    ci.Bounds = Rectangle.Empty;
                    return;
                }
                MyTreeListBandInfo bi = new MyTreeListBandInfo(ParentBand);
                bi.CalcBandInfo(this);
                int VisiblePosition = ParentBand.GetColumnIndex(ci.Column);
                if (ParentBand.BandColumn == ci.Column)
                {
                    ci.Bounds = bi.Bounds;
                    //ci.CaptionRect = new Rectangle(left + 4, 0, bi.Bounds.Width, bi.Bounds.Height);
                    ci.CaptionRect = new Rectangle(0, 0, bi.Bounds.Width, bi.Bounds.Height);
                    if (BandLinks.ContainsKey(ci.Column))
                    {
                        BandLinks[ci.Column] = bi;
                    }
                    else
                    {
                        BandLinks.Add(ci.Column, bi);
                    }
                }
                else
                {
                    int X = bi.Bounds.X;
                    for (int i = 0; i < VisiblePosition; i++)
                    {
                        TreeListColumn Col = ParentBand.GetColumn(i);
                        if ((Col != null) && Col.Visible)
                        {
                            X += Col.Width;
                        }
                    }
                    int Y = bi.Bounds.Bottom - 1;
                    int Width = ci.Column.Width;
                    int Height = BandHeight * (BandMaxLevel - ParentBand.Level);
                    ci.Bounds = new Rectangle(X, Y, Width, Height);
                    ci.CaptionRect = new Rectangle(left + 4, 0, Width, Height);
                    ColCount++;
                    left += Width;
                }
            }
            else
            {
                left += offset;
            }
            UpdateGlyphInfo(ci);
            ObjectPainter.CalcObjectBounds(GInfo.Graphics, TreeList.ElementsLookAndFeel.Painter.Header, ci);
        }

        protected int GetColumnVisibleIndex(int ColIndex)
        {
            int VisibleColIndex = 0;
            for (int i = 0; i < ColIndex; i++)
            {
                TreeListColumn C = TreeList.RootBand.GetColumn(i);
                if ((C != null) && (C.Visible))
                {
                    VisibleColIndex++;
                }
            }
            return VisibleColIndex;
        }

        ColumnInfo GetNextColumn(ColumnInfo ci)
        {
            int index = ColumnsInfo.Columns.IndexOf(ci);
            return ((index + 1) >= ColumnsInfo.Columns.Count) ? null : (ColumnInfo)ColumnsInfo.Columns[index + 1];
        }

        protected override void CalcRowCellsInfo(RowInfo ri, System.Collections.ArrayList viewInfoList)
        {
            base.CalcRowCellsInfo(ri, viewInfoList);
            ri.Lines.Clear();
            foreach (CellInfo ci in ri.Cells)
            {
                int ColIndex, Level;
                if (CellBandMap.GetColumnStartPosition(ci.Column, out ColIndex, out Level))
                {
                    int X = ci.Bounds.X;
                    int Y = ci.Bounds.Y + RowBandHeight * Level;
                    int Height = RowBandHeight;
                    int Width = ci.Bounds.Width;
                    if ((GetColumnVisibleIndex(ColIndex) == 0) && (ci.Column.VisibleIndex != 0))
                    {
                        int Offset = (ri.Level + 1) * RC.LevelWidth;
                        X += Offset;
                        Width -= Offset;
                    }
                    ColumnInfo nextColumn = GetNextColumn(ci.ColumnInfo);
                    if (nextColumn != null && FixedRightColumn == nextColumn.Column)
                    {
                        if (!IsFixed(ci.ColumnInfo) && ci.ColumnInfo.Bounds.Right <= (nextColumn.Bounds.Left - TreeList.FixedLineWidth)) Width -= 1;
                    }
                    ci.EditorViewInfo.Bounds = new Rectangle(X, Y, Width, Height);
                    UpdateEditorInfo(ci);
                    UpdateCell(ci, ci.Column, ri.Node);
                    ri.Lines.Add(new LineInfo(new Rectangle(X + Width, Y, 1, Height + 1), PaintAppearance.VertLine));
                    ri.Lines.Add(new LineInfo(new Rectangle(X, Y + Height, Width + 1, 1), PaintAppearance.HorzLine));
                }
            }
        }

        protected internal virtual MyTreeListBandInfo GetBandInfoByPoint(Point pt)
        {
            foreach (ColumnInfo ci in ColumnsInfo.Columns)
            {
                MyTreeListBandInfo bi = ci as MyTreeListBandInfo;
                if (bi != null)
                {
                    //yuxia 
                    //bi.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    
                }
                if ((bi != null) && (bi.Bounds.Contains(pt)))
                {
                    return bi;
                }
            }
            return null;
        }

        public override TreeListHitTest GetHitTest(Point pt)
        {
            try
            {
                if (ViewRects.ColumnPanel.Contains(pt))
                {
                    MyTreeListBandInfo bi = GetBandInfoByPoint(pt);
                    if (bi != null)
                    {
                        TreeListHitTest ht = new TreeListHitTest();
                        ht.ColumnInfo = bi;
                        ht.HitInfoType = HitInfoType.Column;
                        ht.MousePoint = pt;
                        return ht;
                    }
                }
            }
            catch
            {
            }
            return base.GetHitTest(pt);
        }

        protected internal new TreeListColumn FindFixedLeftColumn()
        {
            return this.FindFixedLeftColumn();
        }

        public override int GetColumnLeftCoord(TreeListColumn column)
        {
            if (column.VisibleIndex < 0) return 0;
            int res = 0;
            if (BandLinks.ContainsKey(column))
            {
                int colWidth = 0;
                foreach (TreeListColumn col in BandLinks[column].Band.Columns)
                {
                    if (col != null && col.Visible == true)
                        colWidth += col.VisibleWidth;
                }
                column.Width = colWidth;
                foreach (KeyValuePair<TreeListColumn, MyTreeListBandInfo> bandLink in BandLinks)
                {
                    if (bandLink.Key == column) return res;
                    if (bandLink.Value.Band.Level == BandLinks[column].Band.Level)
                        foreach (TreeListColumn col in bandLink.Value.Band.Columns)
                        {
                            if (col != null && col.Visible == true)
                                res += col.VisibleWidth;
                        }
                }
                return res;
            }
            int returnedValue = base.GetColumnLeftCoord(column);
            return returnedValue;
        }

        public override void CalcColumnTotalWidth()
        {
            CalcIndicatorWidth();
            ViewRects.ColumnTotalWidth = ViewRects.IndicatorWidth;
            foreach (TreeListColumn c in TreeList.VisibleColumns)
            {
                if (TreeList.BandedColumns.Contains(c))
                {
                    ViewRects.ColumnTotalWidth += c.VisibleWidth;
                }
            }
        }
        //导致滚动条无法拖拽
        //protected override void CalcViewRects()
        //{
        //    base.CalcViewRects();
        //    ViewRects.ColumnPanel = new Rectangle(ViewRects.Client.X, ViewRects.Client.Y, ViewRects.ColumnTotalWidth - 1, ViewRects.Client.Height);
        //    ViewRects.ColumnPanel.Height = ColumnPanelHeight;
        //}
    }
}
