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
using DevExpress.XtraTreeList.Columns;

namespace MyXtraTreeList
{
    public class MyTreeListBand
    {
        private MyTreeList fTreeList;

        private MyTreeListBand fParent;

        private MyTreeListBandCollection fChildren;

        private int fPosition;

        private int fLevel;

        private string fName;

        private TreeListColumn fBandColumn;

        private TreeListColumn[] fColumns;

        private bool fVisible;

        public MyTreeListBand(MyTreeList TreeList, MyTreeListBand parent, int position, int width, string name)
        {
            fTreeList = TreeList;
            fChildren = new MyTreeListBandCollection(this, TreeList.Bands);
            fColumns = new TreeListColumn[width];
            fParent = parent;
            fName = name;
            fPosition = position;
            fLevel = (Parent == null) ? 0 : Parent.Level + 1;
            fBandColumn = null;
            fVisible = true;
        }

        public static bool IsValid(MyTreeListBand Band)
        {
            if ((Band == null) || (Band.Position < 0) || (Band.Width < 1))
            {
                return false;
            }
            if (Band.Parent != null)
            {
                foreach (MyTreeListBand Child in Band.Parent.Children)
                {
                    if (Child != Band)
                    {//Intersection check
                        if (Child.Position > Band.Position)
                        {
                            if (Band.EndPosition >= Child.Position)
                            {
                                return false;
                            }
                        }
                        else
                        {
                            if (Child.EndPosition >= Band.Position)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public virtual int Position
        {
            get { return fPosition; }
            protected set { fPosition = value; }
        }

        public virtual int Level
        {
            get { return fLevel; }
            protected set { fLevel = value; }
        }

        public virtual int Width
        {
            get { return fColumns.GetLength(0); }
        }

        public int EndPosition
        {
            get { return Position + Width - 1; }
        }

        public MyTreeList TreeList
        {
            get { return fTreeList; }
        }

        public virtual MyTreeListBand Parent
        {
            get { return fParent; }
        }

        public virtual MyTreeListBandCollection Children
        {
            get { return fChildren; }
        }

        public virtual TreeListColumn[] Columns
        {
            get { return fColumns; }
        }

        public virtual TreeListColumn BandColumn
        {
            get { return fBandColumn; }
            set
            {
                fBandColumn = value;
                MinimizeColumnWidth(fBandColumn);
            }
        }

        public virtual string Name
        {
            get { return fName; }
            set { fName = value; }
        }

        public bool Visible
        {
            get { return fVisible; }
            set
            {
                if (fVisible != value)
                {
                    fVisible = value;
                    if (BandColumn != null)
                    {
                        BandColumn.Visible = value;
                    }
                    foreach (MyTreeListBand Child in Children)
                    {
                        Child.Visible = value;
                    }
                    foreach (TreeListColumn ChildCol in Columns)
                    {
                        if (ChildCol != null)
                        {
                            ChildCol.Visible = value;
                        }
                    }
                    if (Parent != null)
                    {
                        Parent.Children.UpdateColumns();
                    }
                }
            }
        }

        public int IndexToColumnHandle(int Index)
        {
            if (Parent == null)
            {
                return Position + Index;
            }
            return Parent.IndexToColumnHandle(Position) + Index;
        }

        public int ColumnHandleToIndex(int handle)
        {
            if (Parent == null)
            {
                return handle - Position;
            }
            return Parent.ColumnHandleToIndex(handle) - Position;
        }

        public bool ContainsHandle(int Handle)
        {
            return (Handle >= IndexToColumnHandle(0)) && (Handle < IndexToColumnHandle(Width));
        }

        public bool ContainsColumn(TreeListColumn Column)
        {
            if (BandColumn == Column)
            {
                return true;
            }
            foreach (TreeListColumn Col in Columns)
            {
                if (Col == Column)
                {
                    return true;
                }
            }
            foreach (MyTreeListBand Child in Children)
            {
                if (Child.ContainsColumn(Column))
                {
                    return true;
                }
            }
            return false;
        }

        public bool ThisContainColumn(TreeListColumn Column)
        {
            if (Column == null)
            {
                return false;
            }
            foreach (TreeListColumn ChildCol in Columns)
            {
                if (ChildCol == Column)
                {
                    return true;
                }
            }
            return false;
        }

        public MyTreeListBand CreateChild(int Position, int ChildWidth, string ChildName)
        {
            MyTreeListBand Res = new MyTreeListBand(fTreeList, this, Position, ChildWidth, ChildName);
            return Children.Add(Res);
        }

        private bool ResizeColumnsArray(int Width)
        {
            if (Width > 0)
            {
                TreeListColumn[] Tmp = new TreeListColumn[Width];
                fColumns.CopyTo(Tmp, 0);
                fColumns = Tmp;
                return true;
            }
            return false;
        }

        public bool SetWidth(int NewWidth)
        {
            if ((Parent == null) && (NewWidth > Width))
            {
                TreeList.ViewInfo.CalcColumnTotalWidth();
                return ResizeColumnsArray(NewWidth);
            }
            return false;
        }

        public void SetColumn(int Index, TreeListColumn Column)
        {
            if ((Column != null) && (Index >= 0) && (Index < Width))
            {
                TreeList.BandedColumns.Add(Column);
                int Handle = IndexToColumnHandle(Index);
                MyTreeListBand Child = Children.FindAtHandle(Handle);
                if (Child == null)
                {
                    Columns[Index] = Column;
                    Column.VisibleIndex = Handle;
                }
                else
                {
                    Child.SetColumn(Child.ColumnHandleToIndex(Handle), Column);
                    Columns[Index] = null;
                }
            }
        }

        public void SetColumn(int Index, TreeListColumn Column, bool AllowEdit)
        {
            if ((Column != null) && (Index >= 0) && (Index < Width))
            {
                
                TreeList.BandedColumns.Add(Column);
                int Handle = IndexToColumnHandle(Index);
                MyTreeListBand Child = Children.FindAtHandle(Handle);
                
                if (Child == null)
                {
                    Columns[Index] = Column;
                    Column.VisibleIndex = Handle;

                }
                else
                {
                    Child.SetColumn(Child.ColumnHandleToIndex(Handle), Column);
                    Columns[Index] = null;
                }
                Column.OptionsColumn.AllowEdit = AllowEdit;
            }
        }

        public void SetColumn(int Index, TreeListColumn Column, bool AllowEdit, DevExpress.Utils.HorzAlignment HorzAlignment)
        {
            if ((Column != null) && (Index >= 0) && (Index < Width))
            {
                TreeList.BandedColumns.Add(Column);
                int Handle = IndexToColumnHandle(Index);
                MyTreeListBand Child = Children.FindAtHandle(Handle);

                if (Child == null)
                {
                    Columns[Index] = Column;
                    Column.VisibleIndex = Handle;

                }
                else
                {
                    Child.SetColumn(Child.ColumnHandleToIndex(Handle), Column);
                    Columns[Index] = null;
                }
                Column.OptionsColumn.AllowEdit = AllowEdit;
                Column.AppearanceCell.TextOptions.HAlignment = HorzAlignment;
            }
        }

        public void SetColumn(int Index, TreeListColumn Column, string Caption, bool AllowEdit, DevExpress.Utils.HorzAlignment HorzAlignment)
        {
            if ((Column != null) && (Index >= 0) && (Index < Width))
            {
                TreeList.BandedColumns.Add(Column);
                Column.Caption = Caption;
                int Handle = IndexToColumnHandle(Index);
                MyTreeListBand Child = Children.FindAtHandle(Handle);

                if (Child == null)
                {
                    Columns[Index] = Column;
                    Column.VisibleIndex = Handle;

                }
                else
                {
                    Child.SetColumn(Child.ColumnHandleToIndex(Handle), Column);
                    Columns[Index] = null;
                }
                Column.OptionsColumn.AllowEdit = AllowEdit;
                Column.AppearanceCell.TextOptions.HAlignment = HorzAlignment;
            }
        }

        //public void SetColumn(int Index, string Caption, string FieldName, bool AllowEdit)
        //{
        //    TreeListColumn tc=new TreeListColumn();
        //    tc.FieldName=FieldName;
        //    tc.Caption=Caption;
        //    TreeList.BandedColumns.Add(tc);
        //    int Handle = IndexToColumnHandle(Index);
        //    MyTreeListBand Child = Children.FindAtHandle(Handle);

        //    if (Child == null)
        //    {
        //        Columns[Index] = tc;
        //        tc.VisibleIndex = Handle;

        //    }
        //    else
        //    {
        //        Child.SetColumn(Child.ColumnHandleToIndex(Handle), tc);
        //        Columns[Index] = null;
        //    }
        //    tc.OptionsColumn.AllowEdit = AllowEdit;
        //    tc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        //}

        public TreeListColumn GetColumn(int Index)
        {
            if ((Index >= 0) && (Index < Width))
            {
                int Handle = IndexToColumnHandle(Index);
                MyTreeListBand Child = Children.FindAtHandle(Handle);
                if (Child == null)
                {
                    return Columns[Index];
                }
                else
                {
                    return Child.GetColumn(Child.ColumnHandleToIndex(Handle));
                }
            }
            return null;
        }

        public virtual int GetColumnIndex(TreeListColumn column)
        {
            int Res = -1;
            for (int i = 0; i < Width; i++)
            {
                if (Columns[i] == column)
                {
                    return i;
                }
            }
            foreach (MyTreeListBand Child in Children)
            {
                Res = Child.GetColumnIndex(column);
                if (Res != -1)
                {
                    return Res + Child.Position;
                }
            }
            return -1;
        }

        public virtual bool IsBrother(MyTreeListBand Band)
        {
            if (Band == null)
            {
                return false;
            }
            return Band.Parent == Parent;
        }

        public virtual bool IsBrother(TreeListColumn Column)
        {
            if (Parent == null)
            {
                return false;
            }
            return Parent.ThisContainColumn(Column);
        }

        public virtual bool TryToSwap(MyTreeListBand A, MyTreeListBand B)
        {
            if ((this != A.Parent) || (this != B.Parent))
            {
                return false;
            }
            int Start = Math.Min(B.Position, A.Position);
            int End = Math.Max(B.Position, A.Position);
            if (A.Position < B.Position)
            {
                B.Position = A.Position;
                A.Position = B.Position + B.Width;
            }
            else
            {
                A.Position = B.Position;
                B.Position = A.Position + A.Width;
            }
            Children.UpdateColumns();
            return true;
        }

        protected virtual bool TryToSwapBandColumns(TreeListColumn A, TreeListColumn B)
        {
            int AIndex = -1;
            int BIndex = -1;
            for (int i = 0; i < Width; i++)
            {
                if (Columns[i] == A)
                {
                    AIndex = i;
                }
                if (Columns[i] == B)
                {
                    BIndex = i;
                }
            }
            if ((AIndex >= 0) && (BIndex >= 0))
            {
                fColumns[AIndex] = B;
                fColumns[BIndex] = A;
                if (A.VisibleIndex > B.VisibleIndex)
                {
                    A.VisibleIndex = IndexToColumnHandle(BIndex);
                    B.VisibleIndex = IndexToColumnHandle(AIndex);
                }
                else
                {
                    B.VisibleIndex = IndexToColumnHandle(AIndex);
                    A.VisibleIndex = IndexToColumnHandle(BIndex);
                }
                return true;
            }
            return false;
        }

        public bool TryToSwapColumns(TreeListColumn A, TreeListColumn B)
        {
            if ((A == null) || (B == null))
            {
                return false;
            }
            if (TryToSwapBandColumns(A, B))
            {
                return true;
            }
            foreach (MyTreeListBand Child in Children)
            {
                if (Child.TryToSwapColumns(A, B))
                {
                    return true;
                }
            }
            return false;
        }

        public bool TryToSwapBandAndColumn(MyTreeListBand Band, TreeListColumn Column)
        {
            if ((Band == null) || (Column == null) || (Band.Parent != this))
            {
                return false;
            }
            int ColumnPosition = -1;
            for (int i = 0; i < Width; i++)
            {
                if (Columns[i] == Column)
                {
                    ColumnPosition = i;
                }
            }
            if (ColumnPosition < 0)
            {
                return false;
            }
            int Start = Math.Min(ColumnPosition, Band.Position);
            int End = Math.Max(ColumnPosition, Band.Position);
            int NewColumnPosition;
            if (Band.Position < ColumnPosition)
            {
                NewColumnPosition = Band.Position;
                Band.Position = NewColumnPosition + 1;
            }
            else
            {
                Band.Position = ColumnPosition;
                NewColumnPosition = Band.Position + Band.Width;
            }
            Columns[NewColumnPosition] = Columns[ColumnPosition];
            Columns[ColumnPosition] = null;
            Children.UpdateColumns();
            return true;
        }

        public bool HasColumns()
        {
            foreach (TreeListColumn ChildCol in Columns)
            {
                if (ChildCol != null)
                {
                    return true;
                }
            }
            return false;
        }

        public int GetDepth()
        {
            if (Children.Count == 0)
            {
                return (HasColumns()) ? 1 : 0;
            }
            int max = 0;
            foreach (MyTreeListBand Child in Children)
            {
                int ChildDepth = Child.GetDepth();
                if (ChildDepth > max)
                {
                    max = ChildDepth;
                }
            }
            return max + 1;
        }

        public static void MinimizeColumnWidth(TreeListColumn Column)
        {
            if (Column != null)
            {
                Column.MinWidth = 0;
                Column.Width = 0;
                Column.OptionsColumn.FixedWidth = true;
            }
        }
    }
}
