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
using DevExpress.XtraTreeList.ViewInfo;

namespace MyXtraTreeList
{
    public class MyResourceInfo : ResourceInfo
    {
        public MyResourceInfo(MyTreeListViewInfo viewInfo)
            : base(viewInfo)
        {
            //base
        }

        public new void SetColumnPanelHeight(int value)
        {
            base.SetColumnPanelHeight(value);
        }

        public new void SetRowHeight(int value)
        {
            base.SetRowHeight(value);
        }
    }
}
