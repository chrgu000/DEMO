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
using System.Collections;
using DevExpress.XtraTreeList.Columns;

namespace MyXtraTreeList
{
    public class MyTreeListBandCollection : CollectionBase
    {
        private MyTreeListBand fRootBand;

        private MyTreeListBandCollection fTreeListBands;

        public MyTreeListBandCollection(MyTreeListBand RootBand, MyTreeListBandCollection TreeListBands)
        {
            fRootBand = RootBand;
            fTreeListBands = TreeListBands;
            
        }

        public MyTreeListBandCollection(MyTreeList treeList)
        {
            fRootBand = new MyTreeListBand(treeList, null, 0, treeList.Columns.Count, string.Empty);
            List.Add(fRootBand);
            fTreeListBands = null;
        }

        public virtual MyTreeListBand this[int index]
        {
            get { return (MyTreeListBand)List[index]; }
        }

        protected internal virtual MyTreeListBand Add(MyTreeListBand Band)
        {
            //yuxia
            if (MyTreeListBand.IsValid(Band))
            {
                if (fTreeListBands != null)
                {
                    foreach (MyTreeListBand Child in Band.Children)
                    {
                        fTreeListBands.Add(Child);
                    }
                }
                if (Band.Parent != null)
                {
                    for (int i = Band.Position; i <= Band.EndPosition; i++)
                    {
                        Band.Parent.SetColumn(i, Band.Parent.Columns[i]);
                    }
                }
                return this[List.Add(Band)];
            }
            return null;
        }

        public virtual MyTreeListBand Add(int Index, int Width, string Name)
        {
            MyTreeListBand Res = fRootBand.CreateChild(Index, Width, Name);
            return Add(Res);
        }

        public virtual void Remove(MyTreeListBand Band)
        {
            foreach (MyTreeListBand Child in Band.Children)
            {
                Remove(Child);
            }
            Band.Children.Clear();
            if (Band.Parent != null)
            {
                Band.Parent.Children.Remove(Band);
                for (int i = 0; i < Band.Width; i++)
                {
                    Band.Parent.SetColumn(i + Band.Position, Band.Columns[i]);
                }
            }
            //Remove(Band);
        }

        public virtual bool Contains(MyTreeListBand Band)
        {
            return List.Contains(Band);
        }

        public virtual new void Clear()
        {
            List.Clear();
        }

        protected override void OnInsertComplete(int index, object value)
        {
            base.OnInsert(index, value);
            if ((fTreeListBands != null) && (value != null) && !fTreeListBands.Contains(value as MyTreeListBand))
            {
                fTreeListBands.Add(value as MyTreeListBand);
            }
        }

        protected override void OnRemove(int index, object value)
        {
            base.OnRemove(index, value);
            if (fTreeListBands != null)
            {
                fTreeListBands.Remove(value as MyTreeListBand);
            }
        }

        public virtual MyTreeListBand FindAtHandle(int Handle)
        {
            foreach (MyTreeListBand Band in this)
            {
                if (Band.ContainsHandle(Handle))
                {
                    return Band;
                }
            }
            return null;
        }

        public virtual bool IsBrotherColumns(TreeListColumn ColA, TreeListColumn ColB)
        {
            foreach (MyTreeListBand Band in this)
            {
                if (Band.ThisContainColumn(ColA) && Band.ThisContainColumn(ColB))
                {
                    return true;
                }
            }
            return false;
        }

        protected internal void UpdateColumns()
        {
            for (int i = 0; i < fRootBand.Width; i++)
            {
                TreeListColumn Col = fRootBand.GetColumn(i);
                if (Col != null)
                {
                    Col.VisibleIndex = (Col.Visible) ? fRootBand.IndexToColumnHandle(i) : -1;
                }
            }
        }

        public MyTreeListBand GetColumnParentBand(TreeListColumn Column)
        {
            if (Column == null)
            {
                return null;
            }
            foreach (MyTreeListBand Child in this)
            {
                if (Child.BandColumn == Column)
                {
                    return Child;
                }
                foreach (TreeListColumn Col in Child.Columns)
                {
                    if (Col == Column)
                    {
                        return Child;
                    }
                }
            }
            return null;
        }
    }
}