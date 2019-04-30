using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections;
using DevExpress.XtraTreeList;
using System.Data;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.Business
{
    public enum Priority { Normal = 0, Low = 1, High = 2 }
    public class Project
    {
        public string seq;
        public string cinvcode;
        public string cinvname;
        public string englishname;
        public string cinvstd;
        public string cinvunitname;
        public string flag;
        public double baseqtyn;
        public double baseqtyq;
        public double dcusedq;
        public double usedq;
        public double dj;
        public double jg;
        public string sx;

        public string vendor;
        public string vendorname;
        public string stock;
        public string stockname;

        public string gylx;

        public string pricefrom;
        public string cpbvcode;
        public string cpbvdate;

        Priority priority;
        Projects owner;
        Projects projects;
        bool isTask;
        public Project()
        {
            this.owner = null;

            this.isTask = true;

            this.seq = "";
            this.cinvcode = "";
            this.cinvname = "";
            this.englishname = "";
            this.cinvstd = "";
            this.cinvunitname = "";
            this.flag = "";
            this.baseqtyn = 0;
            this.baseqtyq = 0;
            this.dcusedq = 0;
            this.usedq = 0;
            this.dj = 0;
            this.jg = 0;
            this.sx = "";

            this.vendor = "";
            this.vendorname = "";
            this.stock = "";
            this.stockname = "";

            this.gylx = "";

            this.pricefrom = "";
            this.cpbvcode = "";
            this.cpbvdate = "";

            this.priority = Priority.Normal;
            this.projects = new Projects();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="seq">序号</param>
        /// <param name="cinvcode">母件编码</param>
        /// <param name="cinvname">母件名称</param>
        /// <param name="englishname">母件英文名称</param>
        /// <param name="cinvstd">母件规格型号</param>
        /// <param name="cinvunitname">母件计量单位</param>
        /// <param name="flag">状态</param>
        /// <param name="baseqtyn">基本用量</param>
        /// <param name="baseqtyq">基础数量</param>
        /// <param name="dcusedq">单层使用数量</param>
        /// <param name="usedq">使用数量</param>
        /// <param name="dj">单价</param>
        /// <param name="jg">价格</param>
        /// <param name="sx">属性</param>
        /// <param name="vendor">供应商编号</param>
        /// <param name="vendorname">供应商名称</param>
        /// <param name="stock">仓库编码</param>
        /// <param name="stockname">仓库名称</param>
        /// <param name="priority"></param>
        /// <param name="isTask"></param>
        public Project(string seq,string cinvcode, string cinvname,string englishname, string cinvstd, string cinvunitname, string flag, double baseqtyn, double baseqtyq,
            double dcusedq, double usedq, double dj, double jg, string sx, string vendor, string vendorname, string stock, string stockname, string gylx, string pricefrom, string cpbvcode, string cpbvdate, Priority priority, bool isTask)
        {

            this.isTask = isTask;
            this.seq = seq;
            this.cinvcode = cinvcode;
            this.cinvname = cinvname;
            this.englishname = englishname;
            this.cinvstd = cinvstd;
            this.cinvunitname = cinvunitname;
            this.flag = flag;
            this.baseqtyn = baseqtyn;
            this.baseqtyq = baseqtyq;

            this.dcusedq = dcusedq;
            this.usedq = usedq;
            this.dj =dj;
            this.jg = jg;
            this.sx = sx;

            this.vendor = vendor;
            this.vendorname = vendorname;
            this.stock = stock;
            this.stockname = stockname;

            this.gylx = gylx;

            this.pricefrom = pricefrom;
            this.cpbvcode = cpbvcode;
            this.cpbvdate = cpbvdate;

            this.priority = priority;
            this.projects = new Projects();
        }

        public Project(string seq, string cinvcode,Priority priority, bool isTask)
        {

            this.isTask = isTask;
            this.cinvcode = cinvcode + ":" + seq;

            this.priority = priority;
            this.projects = new Projects();
        }
        public Project(Projects projects, string seq, string cinvcode, string cinvname, string englishname, string cinvstd, string cinvunitname, string flag, double baseqtyn, double baseqtyq,
            double dcusedq, double usedq, double dj, double jg, string sx, string vendor, string vendorname, string stock, string stockname, string gylx, string pricefrom, string cpbvcode, string cpbvdate, Priority priority, bool isTask)
            : this(seq, cinvcode, cinvname, englishname, cinvstd, cinvunitname, flag, baseqtyn, baseqtyq, dcusedq, usedq, dj, jg, sx, vendor, vendorname, stock, stockname, gylx, pricefrom, cpbvcode, cpbvdate, priority, isTask)
        {
            this.projects = projects;
        }
        [Browsable(false)]
        public Projects Owner
        {
            get { return owner; }
            set { owner = value; }
        }
        public bool IsTask
        {
            get { return isTask; }
            set
            {
                if (isTask == value) return;
                isTask = value;
                OnChanged();
            }
        }

        public string Seq
        {
            get { return seq; }
            set
            {
                if (seq == value) return;
                seq = value;
                OnChanged();
            }
        }


        public string Cinvcode
        {
            get { return cinvcode; }
            set
            {
                if (cinvcode == value) return;
                cinvcode = value;
                OnChanged();
            }
        }


        public string Cinvname
        {
            get { return cinvname; }
            set
            {
                if (cinvname == value) return;
                cinvname = value;
                OnChanged();
            }
        }

        public string Englishname
        {
            get { return englishname; }
            set
            {
                if (englishname == value) return;
                englishname = value;
                OnChanged();
            }
        }

        public string Cinvstd
        {
            get { return cinvstd; }
            set
            {
                if (cinvstd == value) return;
                cinvstd = value;
                OnChanged();
            }
        }

        public string Cinvunitname
        {
            get { return cinvunitname; }
            set
            {
                if (cinvunitname == value) return;
                cinvunitname = value;
                OnChanged();
            }
        }


        public string Flag
        {
            get { return flag; }
            set
            {
                if (flag == value) return;
                flag = value;
                OnChanged();
            }
        }


        public double BaseQtyN
        {
            get { return baseqtyn; }
            set
            {
                if (baseqtyn == value) return;
                baseqtyn = value;
                OnChanged();
            }
        }


        public double BaseQtyQ
        {
            get { return baseqtyq; }
            set
            {
                if (baseqtyq == value) return;
                baseqtyq = value;
                OnChanged();
            }
        }

        public double Dcusedq
        {
            get { return dcusedq; }
            set
            {
                if (dcusedq == value) return;
                dcusedq = value;
                OnChanged();
            }
        }

        public double Usedq
        {
            get { return usedq; }
            set
            {
                if (usedq == value) return;
                usedq = value;
                OnChanged();
            }
        }

        public double Dj
        {
            get { return dj; }
            set
            {
                if (dj == value) return;
                dj = value;
                OnChanged();
            }
        }

        public double Jg
        {
            get { return jg; }
            set
            {
                if (jg == value) return;
                jg = value;
                OnChanged();
            }
        }

        public string Sx
        {
            get { return sx; }
            set
            {
                if (sx == value) return;
                sx = value;
                OnChanged();
            }
        }

        public string Vendor
        {
            get { return vendor; }
            set
            {
                if (vendor == value) return;
                vendor = value;
                OnChanged();
            }
        }

        public string Vendorname
        {
            get { return vendorname; }
            set
            {
                if (vendorname == value) return;
                vendorname = value;
                OnChanged();
            }
        }

        public string Stock
        {
            get { return stock; }
            set
            {
                if (stock == value) return;
                stock = value;
                OnChanged();
            }
        }

        public string Stockname
        {
            get { return stockname; }
            set
            {
                if (stockname == value) return;
                stockname = value;
                OnChanged();
            }
        }

        public string Gylx
        {
            get { return gylx; }
            set
            {
                if (gylx == value) return;
                gylx = value;
                OnChanged();
            }
        }

        public string PriceFrom
        {
            get { return pricefrom; }
            set
            {
                if (pricefrom == value) return;
                pricefrom = value;
                OnChanged();
            }
        }


        public string CpbvCode
        {
            get { return cpbvcode; }
            set
            {
                if (cpbvcode == value) return;
                cpbvcode = value;
                OnChanged();
            }
        }

        public string CpbvDate
        {
            get { return cpbvdate; }
            set
            {
                if (cpbvdate == value) return;
                cpbvdate = value;
                OnChanged();
            }
        }

        public Priority Priority
        {
            get { return priority; }
            set
            {
                if (Priority == value) return;
                priority = value;
                OnChanged();
            }
        }
        [Browsable(false)]
        public Projects Projects { get { return projects; } }
        void OnChanged()
        {
            if (owner == null) return;
            int index = owner.IndexOf(this);
            owner.ResetItem(index);
        }
    }

    public class Projects : BindingList<Project>, TreeList.IVirtualTreeListData
    {
        void TreeList.IVirtualTreeListData.VirtualTreeGetChildNodes(VirtualTreeGetChildNodesInfo info)
        {
            Project obj = info.Node as Project;
            info.Children = obj.Projects;
        }
        protected override void InsertItem(int index, Project item)
        {
            item.Owner = this;
            base.InsertItem(index, item);
        }
        void TreeList.IVirtualTreeListData.VirtualTreeGetCellValue(VirtualTreeGetCellValueInfo info)
        {
            Project obj = info.Node as Project;
            switch (info.Column.FieldName)
            {
                case "Seq":
                    info.CellData = obj.Seq;
                    break;
                case "Cinvcode":
                    info.CellData = obj.Cinvcode;
                    break;
                case "Cinvname":
                    info.CellData = obj.Cinvname;
                    break;
                case "Englishname":
                    info.CellData = obj.Englishname;
                    break;
                case "Cinvstd":
                    info.CellData = obj.Cinvstd;
                    break;
                case "Cinvunitname":
                    info.CellData = obj.Cinvunitname;
                    break;
                case "Flag":
                    info.CellData = obj.Flag;
                    break;
                case "BaseQtyN":
                    info.CellData = Math.Round(obj.BaseQtyN,4);
                    break;
                case "BaseQtyQ":
                    info.CellData = Math.Round(obj.BaseQtyQ,4);
                    break;
                case "Dcusedq":
                    info.CellData = Math.Round(obj.Dcusedq,4);
                    break;
                case "Usedq":
                    info.CellData = Math.Round(obj.Usedq,4);
                    break;
                case "Dj":
                    info.CellData = Math.Round(obj.Dj,6);
                    break;
                case "Jg":
                    //info.CellData = Math.Round(obj.Jg,4);
                    info.CellData = 规格化.零舍一入(obj.Jg).ToString();
                    break;
                case "Sx":
                    info.CellData = obj.Sx;
                    break;
                case "Vendor":
                    info.CellData = obj.Vendor;
                    break;
                case "Vendorname":
                    info.CellData = obj.Vendorname;
                    break;
                case "Stock":
                    info.CellData = obj.Stock;
                    break;
                case "Stockname":
                    info.CellData = obj.Stockname;
                    break;
                case "Gylx":
                    info.CellData = obj.gylx;
                    break;
                case "PriceFrom":
                    info.CellData = obj.pricefrom;
                    break;
                case "CpbvCode":
                    info.CellData = obj.cpbvcode;
                    break;
                case "CpbvDate":
                    info.CellData = obj.cpbvdate;
                    break;
                case "Priority":
                    info.CellData = obj.Priority;
                    break;
            }
        }
        void TreeList.IVirtualTreeListData.VirtualTreeSetCellValue(VirtualTreeSetCellValueInfo info)
        {
            Project obj = info.Node as Project;
            switch (info.Column.FieldName)
            {
                case "Seq":
                    obj.Seq = (string)info.NewCellData;
                    break;
                case "Cinvcode":
                    obj.Cinvcode = (string)info.NewCellData;
                    break;
                case "Cinvname":
                    obj.Cinvname = (string)info.NewCellData;
                    break;
                case "Englishname":
                    obj.Englishname = (string)info.NewCellData;
                    break;
                case "Cinvstd":
                    obj.Cinvstd = (string)info.NewCellData;
                    break;
                case "Cinvunitname":
                    obj.Cinvunitname = (string)info.NewCellData;
                    break;
                case "Flag":
                    obj.Flag = (string)info.NewCellData;
                    break;
                case "BaseQtyN":
                    obj.BaseQtyN = (double)info.NewCellData;
                    break;
                case "BaseQtyQ":
                    obj.BaseQtyQ = (double)info.NewCellData;
                    break;
                case "Dcusedq":
                    obj.Dcusedq = (double)info.NewCellData;
                    break;
                case "Usedq":
                    obj.Usedq = (double)info.NewCellData;
                    break;
                case "Dj":
                    obj.Dj = (double)info.NewCellData;
                    break;
                case "Jg":
                    obj.Jg = (double)info.NewCellData;
                    break;
                case "Sx":
                    obj.Sx = (string)info.NewCellData;
                    break;
                case "Vendor":
                    obj.Vendor = (string)info.NewCellData;
                    break;
                case "Vendorname":
                    obj.Vendorname = (string)info.NewCellData;
                    break;
                case "Stock":
                    obj.Stock = (string)info.NewCellData;
                    break;
                case "Stockname":
                    obj.Stockname = (string)info.NewCellData;
                    break;
                case "Gylx":
                    obj.Gylx = (string)info.NewCellData;
                    break;
                case "PriceFrom":
                    obj.PriceFrom = (string)info.NewCellData;
                    break;
                case "CpbvCode":
                    obj.CpbvCode = (string)info.NewCellData;
                    break;
                case "CpbvDate":
                    obj.CpbvDate = (string)info.NewCellData;
                    break;
                case "Priority":
                    obj.Priority = (Priority)info.NewCellData;
                    break;
                
            }
        }
    }
}
