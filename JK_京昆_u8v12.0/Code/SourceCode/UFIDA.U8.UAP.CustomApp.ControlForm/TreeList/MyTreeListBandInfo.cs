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
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.ViewInfo;

namespace MyXtraTreeList
{
    public class MyTreeListBandInfo : ColumnInfo
    {
        private MyTreeListBand fBand;

        public MyTreeListBandInfo(MyTreeListBand band)
            : base(band.BandColumn)
        //: base(new TreeListColumn())
        {
            fBand = band;
            Type = ColumnInfoType.ColumnButton;
            //fBand.BandColumn.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
        }

        public virtual MyTreeListBand Band
        {
            get { return fBand; }
        }

        public new MyTreeList TreeList
        {
            get { return Band.TreeList; }
        }

        public virtual void CalcBandInfo(MyTreeListViewInfo viewInfo)
        {
            MyTreeList TL = viewInfo.TreeList;
            //yuxia
            viewInfo.PaintAppearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            viewInfo.PaintAppearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            Appearance.Assign(viewInfo.PaintAppearance.HeaderPanel);
            int VisiblePosition = Band.IndexToColumnHandle(0);
            int X = viewInfo.ViewRects.IndicatorBounds.Width + 1 - TL.LeftCoord;
            for (int i = 0; i < VisiblePosition; i++)
            {
                TreeListColumn Col = TreeList.RootBand.GetColumn(i);
                if ((Col != null) && Col.Visible)
                {
                    X += Col.Width;
                }
            }
            int Y = (Band.Level - 1) * viewInfo.BandHeight + viewInfo.ViewRects.ColumnPanel.Y;
            int Width = 0;
            for (int i = 0; i < Band.Width; i++)
            {
                TreeListColumn Col = Band.GetColumn(i);
                if ((Col != null) && Col.Visible)
                {
                    Width += Col.Width;
                }
            }
            int Height = viewInfo.BandHeight + 1;
            if ((Band.Children.Count == 0) && (!Band.HasColumns()))
            {
                Height *= viewInfo.BandMaxLevel - Band.Level;
            }
            Bounds = new Rectangle(X, Y, Width, Height);
            //yuxia 表头位置
            CaptionRect = new Rectangle(0, -4, Width, Height);
            Caption = Band.Name;
            
        }
    }
}
