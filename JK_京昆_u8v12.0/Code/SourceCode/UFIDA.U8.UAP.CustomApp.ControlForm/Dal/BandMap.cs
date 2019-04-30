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

namespace MyXtraTreeList {
    public class BandMap {
        protected BandMapCell[,] Source;

        public BandMap() {
            Source = new BandMapCell[0, 0];
        }

        public int ColCount {
            get { return Source.GetLength(0); }
        }

        public int LevelCount {
            get { return Source.GetLength(1); }
        }

        public BandMapCell this[int ColIndex, int Level] {
            get {
                if ((ColIndex < ColCount) && (Level < LevelCount) && (ColIndex >= 0) && (Level >= 0)) {
                    return Source[ColIndex, Level];
                }
                return null;
            }
        }

        protected void FillSource(MyTreeListBand Band, int Offset, int Level) {
            object CellObj = (Band.BandColumn == null) ? (object)Band : (object)Band.BandColumn;
            for (int i = 0; i < Band.Width; i++) {
                Source[Offset + i, Level] = new BandMapCell(CellObj, i == 0, i == (Band.Width - 1));
                if (Band.Columns[i] != null) {
                    Source[Offset + i, Level + 1] = new BandMapCell(Band.Columns[i], true, true);
                }
            }
            foreach (MyTreeListBand Child in Band.Children) {
                FillSource(Child, Offset + Child.Position, Level + 1);
            }
        }

        public void CalcBandMap(MyTreeListBand Band) {
            Source = new BandMapCell[Band.Width, Band.GetDepth()];
            for (int i = 0; i < Band.Width; i++) {
                if (Band.Columns[i] != null) {
                    Source[i, 0] = new BandMapCell(Band.Columns[i], true, true);
                }
            }
            foreach (MyTreeListBand Child in Band.Children) {
                FillSource(Child, Child.Position, 0);
            }
        }

        private void FillCellSource(MyTreeListBand Band, int Offset, int Level) {
            int NewLevel = (Band.BandColumn == null) ? Level : Level + 1;
            for (int i = 0; i < Band.Width; i++) {
                if (Band.BandColumn != null) {
                    Source[Offset + i, Level] = new BandMapCell(Band.BandColumn, i == 0, i == (Band.Width - 1));
                }
                if (Band.Columns[i] != null) {
                    Source[Offset + i, NewLevel] = new BandMapCell(Band.Columns[i], true, true);
                }
            }
            foreach (MyTreeListBand Child in Band.Children) {
                FillCellSource(Child, Offset + Child.Position, NewLevel);
            }
        }

        public void CalcCellBandMap(MyTreeListBand Band) {
            Source = new BandMapCell[Band.Width, Band.GetDepth()];
            for (int i = 0; i < Band.Width; i++) {
                if (Band.Columns[i] != null) {
                    Source[i, 0] = new BandMapCell(Band.Columns[i], true, true);
                }
            }
            foreach (MyTreeListBand Child in Band.Children) {
                FillCellSource(Child, Child.Position, 0);
            }
            int EmptyLevelCount = 0;
            for (int i = LevelCount - 1; i >= 0; i--) {
                bool EmptyLevel = true;
                for (int j = 0; j < ColCount; j++) {
                    if (Source[j, i] != null) {
                        EmptyLevel = false;
                        break;
                    }
                }
                if (EmptyLevel) {
                    EmptyLevelCount++;
                }
                else {
                    break;
                }
            }
            if (EmptyLevelCount > 0) {
                int NewLevelCount = LevelCount - EmptyLevelCount;
                BandMapCell[,] Temp = new BandMapCell[ColCount, NewLevelCount];
                for (int i = 0; i < ColCount; i++) {
                    for (int j = 0; j < NewLevelCount; j++) {
                        Temp[i, j] = Source[i, j];
                    }
                }
                Source = Temp;
            }
        }

        public bool GetColumnStartPosition(TreeListColumn Column, out int ColIndex, out int Level)
        {

            ColIndex = -1;
            Level = -1;
            if (Column == null)
            {
                return false;
            }
            for (int i = 0; i < ColCount; i++)
            {
                for (int j = 0; j < LevelCount; j++)
                {
                    //2016-05-29 yuxia
                    try
                    {
                        if ((Source[i, j].Column == Column) && (Source[i, j].LeftBorder))
                        {
                            ColIndex = i;
                            Level = j;
                            return true;
                        }
                    }
                    catch
                    {
                    }
                }
            }

            return false;
        }
    }

    public enum BandMapType {
        Band,
        Column
    }
    ;

    public class BandMapCell {
        private BandMapType fType;

        private object fObject;

        private bool fLeftBoreder;

        private bool fRightBorder;

        public BandMapCell(object Obj, bool Left, bool Right) {
            if (Obj is MyTreeListBand) {
                fType = BandMapType.Band;
            }
            if (Obj is TreeListColumn) {
                fType = BandMapType.Column;
            }
            fObject = Obj;
            fLeftBoreder = Left;
            fRightBorder = Right;
        }

        public BandMapType Type {
            get { return fType; }
        }

        public MyTreeListBand Band {
            get { return fObject as MyTreeListBand; }
        }

        public TreeListColumn Column {
            get { return fObject as TreeListColumn; }
        }

        public bool LeftBorder {
            get { return fLeftBoreder; }
        }

        public bool RightBorder {
            get { return fRightBorder; }
        }
    }
}
