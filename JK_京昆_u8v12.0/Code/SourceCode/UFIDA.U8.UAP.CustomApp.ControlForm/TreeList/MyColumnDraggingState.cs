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
using System.Windows.Forms;
using DevExpress.XtraTreeList.Handler;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.ViewInfo;
using DevExpress.Utils.Drawing.Helpers;
using DevExpress.XtraTreeList.Columns;

namespace MyXtraTreeList
{
    public class MyColumnDraggingState : TreeListHandler.ColumnDraggingState
    {
        private MyPositionInfo flastPosition;

        private bool dropTargetHighlighted;

        public MyColumnDraggingState(MyTreeListHandler handler)
            : base(handler)
        {
            dropTargetHighlighted = false;
        }

        public new MyTreeList TreeList
        {
            get { return base.TreeList as MyTreeList; }
        }

        public new MyTreeListViewInfo ViewInfo
        {
            get { return base.ViewInfo as MyTreeListViewInfo; }
        }

        protected ColumnInfo SourceInfo
        {
            get { return Data.DownHitTest.ColumnInfo; }
        }

        protected MyTreeListBandInfo SourceBandInfo
        {
            get { return ColumnInfoToBandInfo(SourceInfo); }
        }

        protected virtual MyPositionInfo LastPosition
        {
            get { return flastPosition; }
            set { flastPosition = value; }
        }

        protected bool DropTargetHighlighted
        {
            get { return dropTargetHighlighted; }
            set { dropTargetHighlighted = value; }
        }

        protected MyTreeListBandInfo ColumnInfoToBandInfo(ColumnInfo ci)
        {
            MyTreeListBandInfo bi = ci as MyTreeListBandInfo;
            if ((bi == null) && ViewInfo.BandLinks.ContainsKey(ci.Column))
            {
                bi = ViewInfo.BandLinks[ci.Column];
            }
            return bi;
        }

        protected virtual bool IsBandPositionValid(ColumnInfo ci)
        {
            if (ci == null || ci.Column == null)
            {
                return false;
            }
            MyTreeListBandInfo bi = ColumnInfoToBandInfo(ci);
            if (SourceBandInfo != null)
            {
                if (bi == null)
                {
                    return SourceBandInfo.Band.IsBrother(ci.Column);
                }
                else
                {
                    return (SourceBandInfo.Band.IsBrother(bi.Band)) && (SourceBandInfo.Band != bi.Band);
                }
            }
            else
            {
                if (bi == null)
                {
                    return TreeList.Bands.IsBrotherColumns(SourceInfo.Column, ci.Column);
                }
                else
                {
                    return bi.Band.IsBrother(SourceInfo.Column);
                }
            }
        }

        protected override DragDropEffects GetDragEffect(HitInfoType ht, int pos, bool customizationZone)
        {
            if (customizationZone)
            {
                return DragDropEffects.None;
            }
            if (ht == HitInfoType.CustomizationForm)
            {
                return DragDropEffects.None;
            }
            if (pos >= 0)
            {
                return DragDropEffects.Move;
            }
            return (SourceInfo.Column.VisibleIndex == -1 ? DragDropEffects.None : DragDropEffects.Move);
        }

        public override void DoColumnDragging(Point p, HitInfoType ht)
        {
            MyPositionInfo pos = new MyPositionInfo();
            Rectangle rect;
            int index = GetDragColumnInfo(p, ht, out rect);
            ColumnInfo ci = ViewInfo.GetHitTest(p).ColumnInfo;
            Rectangle r = (rect.Width > 0 && rect.Height > 0) ? TreeList.RectangleToClient(rect) : Rectangle.Empty;
            pos.Assign(index, r, (ci != null) && IsDragPositionValid(index, ht, ci), ci);
            if (SourceBandInfo == null)
            {
                TreeList.MyRaiseDragObjectOver(new DragObjectOverEventArgs(SourceInfo.Column, pos));
            }
            else
            {
                TreeList.MyRaiseDragObjectOver(new DragObjectOverEventArgs(SourceBandInfo.Band, pos));
            }
            if (CheckColumnOptions(SourceInfo.Column, index))
            {
                if (DropTargetHighlighted && !UseArrows)
                {
                    DrawReversibleFrame(Data.DragColumnRect);
                }
                if (pos.Valid)
                {
                    DrawReversibleFrame(rect);
                    UpdateColumnDragFrame(rect);
                    DropTargetHighlighted = true;
                }
                else
                {
                    DropTargetHighlighted = false;
                    UpdateColumnDragFrame(Rectangle.Empty);
                }
                Data.DragColumnRect = rect;
            }
            LastPosition = pos;
            DragDropEffects effect = GetDragEffect(ht, pos.Index, IsInCustomizationZone(p));
            Data.DragMaster.DoDrag(TreeList.PointToScreen(p), effect, false);
        }

        public override void DoEndColumnDragging(Point p, HitInfoType ht)
        {
            Data.DragMaster.EndDrag();
            if (LastPosition != null && ht != HitInfoType.CustomizationForm && !IsInCustomizationZone(p))
            {
                MyPositionInfo pos = new MyPositionInfo();
                pos.Assign(LastPosition);
                if (SourceBandInfo == null)
                {
                    TreeList.MyRaiseDragObjectDrop(new DragObjectDropEventArgs(SourceInfo.Column, pos));
                }
                else
                {
                    TreeList.MyRaiseDragObjectDrop(new DragObjectDropEventArgs(SourceBandInfo.Band, pos));
                }
                if (LastPosition.Valid)
                {
                    if (pos.Index >= 0)
                    {
                        MyTreeListBandInfo posBandInfo = ColumnInfoToBandInfo(pos.Info);
                        if (SourceBandInfo == null)
                        {
                            if (posBandInfo == null)
                            {
                                TreeList.Swap(pos.Info.Column, SourceInfo.Column);
                            }
                            else
                            {
                                TreeList.Swap(posBandInfo.Band, SourceInfo.Column);
                            }
                        }
                        else
                        {
                            if (posBandInfo == null)
                            {
                                TreeList.Swap(SourceBandInfo.Band, pos.Info.Column);
                            }
                            else
                            {
                                TreeList.Swap(SourceBandInfo.Band, posBandInfo.Band);
                            }
                        }
                    }
                }
            }
            UpdateColumnDragFrame(Rectangle.Empty);
            SetState(Regular);
        }

        private int GetDragColumnInfo(Point ptMouse, HitInfoType ht, out Rectangle colRect)
        {
            colRect = Rectangle.Empty;
            if (ht == HitInfoType.CustomizationForm && SourceInfo.Column.OptionsColumn.AllowMoveToCustomizationForm)
            {
                return -101;
            }
            Rectangle visibleColPanelBounds = new Rectangle(ViewInfo.ViewRects.ColumnPanel.Left + ViewInfo.ViewRects.IndicatorWidth, ViewInfo.ViewRects.ColumnPanel.Top, ViewInfo.ViewRects.ColumnPanel.Width - ViewInfo.ViewRects.IndicatorWidth, ViewInfo.ViewRects.ColumnPanel.Height + IncreasedColumnHeight);
            if (!visibleColPanelBounds.Contains(ptMouse))
            {
                if (ptMouse.X < (ViewInfo.ViewRects.Client.Left + ViewInfo.ViewRects.IndicatorWidth) || ptMouse.X > ViewInfo.ViewRects.Client.Right - 2)
                {
                    return -1;
                }
                return -100;
            }
            ColumnInfo ci = ViewInfo.GetHitTest(ptMouse).ColumnInfo;
            if (ht == HitInfoType.FixedRightDiv)
            {
                ci = ViewInfo.ColumnsInfo[ViewInfo.FixedRightColumn];
            }
            if (ht == HitInfoType.FixedLeftDiv)
            {
                ci = ViewInfo.ColumnsInfo[ViewInfo.FindFixedLeftColumn()];
            }
            if (ci == null)
            {
                return -1;
            }
            if (((ci.Type != ColumnInfo.ColumnInfoType.Column) && !(ci is MyTreeListBandInfo)) || ci.Type == ColumnInfo.ColumnInfoType.ColumnButton)
            {
                if (ci.Type == ColumnInfo.ColumnInfoType.ColumnBlank && TreeList.VisibleColumns.Count == 0)
                {
                    colRect = TreeList.RectangleToScreen(ci.Bounds);
                    return 0;
                }
                return -1;
            }
            if (Data.DownHitTest.MouseDest == ci.Bounds)
            {
                return -1;
            }
            Rectangle rect = Rectangle.Intersect(ci.Bounds, visibleColPanelBounds);
            int showIndicatorIndexOffset = (TreeList.OptionsView.ShowIndicator ? 1 : 0);
            int colIndex = ViewInfo.ColumnsInfo.Columns.IndexOf(ci) - showIndicatorIndexOffset;
            bool nextAfterPressed = (ci.Column.VisibleIndex == SourceInfo.Column.VisibleIndex + 1);
            bool lastVisbleLeft = ci.Column == ViewInfo.FixedLeftColumn;
            bool lastVisibleRight = IsBeforeFixedRight(ci.Column);
            bool lastVisible = (rect.Right == visibleColPanelBounds.Right || ci.Column.VisibleIndex == TreeList.VisibleColumns.Count - 1 || lastVisbleLeft || lastVisibleRight);
            if (SourceInfo.Column.VisibleIndex == -1)
            {
                nextAfterPressed = false;
            }
            if (nextAfterPressed || lastVisible)
            {
                if (rect.Width < 6)
                {
                    return -1;
                }
                Rectangle nextR = rect, nextR2 = rect;
                nextR2.X = nextR.Right - 1;
                nextR2.Width = 1;
                nextR.X = nextR.Right - nextR.Width / 2;
                nextR.Width /= 2;
                if (lastVisible)
                {
                    if (NextRectContains(nextR, ptMouse))
                    {
                        rect = UseArrows ? nextR2 : nextR;
                        if (colIndex >= 0)
                        {
                            ci = ViewInfo.ColumnsInfo.Columns[colIndex++] as ColumnInfo;
                        }
                    }
                    else
                    {
                        if (nextAfterPressed)
                        {
                            return -1;
                        }
                    }
                }
                else
                {
                    if (!NextRectContains(nextR, ptMouse))
                    {
                        return -1;
                    }
                    colIndex++;
                    ci = ViewInfo.ColumnsInfo.Columns[colIndex + showIndicatorIndexOffset] as ColumnInfo;
                    if (colIndex - 1 < ViewInfo.ColumnsInfo.Columns.Count - 1)
                    {
                        rect = Rectangle.Intersect(ci.Bounds, visibleColPanelBounds);
                    }
                    else
                    {
                        rect = UseArrows ? nextR2 : nextR;
                    }
                }
            }
            colRect = TreeList.RectangleToScreen(rect);
            int columnsCount = TreeList.VisibleColumns.Count;
            if (ci.Type == ColumnInfo.ColumnInfoType.ColumnBlank || colIndex > columnsCount - 1)
            {
                return columnsCount;
            }
            columnsCount = CalcFixedColumnsCount(FixedStyle.Left);
            if (lastVisbleLeft && colIndex > columnsCount - 1)
            {
                return columnsCount;
            }
            columnsCount = TreeList.VisibleColumns.Count - CalcFixedColumnsCount(FixedStyle.Right);
            if (lastVisibleRight && colIndex > columnsCount - 1)
            {
                return columnsCount;
            }
            if (ci.Column == null)
            {
                return -1;
            }
            return ci.Column.VisibleIndex;
        }

        private void MoveDragColumnToCustomizationForm()
        {
            if (SourceBandInfo == null)
            {
                if (SourceInfo.Column.VisibleIndex == -1)
                {
                    return;
                }
                if (SourceInfo.Column.OptionsColumn.AllowMoveToCustomizationForm)
                {
                    SetDragColumnVisibleIndex(-1);
                }
            }
            else
            {
                SourceBandInfo.Band.Visible = false;
            }
        }

        private void SetDragColumnVisibleIndex(int value)
        {
            SourceInfo.Column.VisibleIndex = value;
        }

        protected bool IsInCustomizationZone(Point pt)
        {
            if (pt.X < ViewInfo.ViewRects.ColumnPanel.Left || pt.X > ViewInfo.ViewRects.ColumnPanel.Right)
            {
                return false;
            }
            return (pt.Y > ViewInfo.ViewRects.ColumnPanel.Bottom) && (pt.Y < TreeList.Bounds.Bottom);
        }

        protected void DrawReversibleFrame(Rectangle rect)
        {
            if (UseArrows)
            {
                return;
            }
            if (NativeVista.IsVista && !NativeVista.IsCompositionEnabled())
            {
                return;
            }
            rect.Location = TreeList.PointToClient(rect.Location);
            DevExpress.XtraEditors.Drawing.SplitterLineHelper.Default.DrawReversibleFrame(TreeList.Handle, rect);
        }

        protected int CalcFixedColumnsCount(FixedStyle fixedStyle)
        {
            int count = 0;
            foreach (TreeListColumn column in TreeList.VisibleColumns)
            {
                if (column.Fixed == fixedStyle)
                {
                    count++;
                }
            }
            return count;
        }

        protected bool IsBeforeFixedRight(TreeListColumn column)
        {
            if (column.Fixed != FixedStyle.None)
            {
                return false;
            }
            int index = column.VisibleIndex;
            if (++index > TreeList.VisibleColumns.Count - 1)
            {
                return false;
            }
            if (TreeList.VisibleColumns[index] == ViewInfo.FixedRightColumn)
            {
                return true;
            }
            return false;
        }

        protected bool NextRectContains(Rectangle bounds, Point pt)
        {
            bounds.Height += IncreasedColumnHeight;
            return bounds.Contains(pt);
        }

        protected virtual bool IsDragPositionValid(int index, HitInfoType ht, ColumnInfo ci)
        {
            if (ci.Column != null)
            {
                MyTreeListBandInfo bi = ColumnInfoToBandInfo(ci);
                bool inColumn = ht == HitInfoType.Column;
                if (bi != null)
                    return (ht == HitInfoType.Column && bi.Band.ThisContainColumn(SourceInfo.Column) && bi.Band.ThisContainColumn(ci.Column));
                return inColumn;
            }
            return false;
        }
    }
}