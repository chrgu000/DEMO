using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace 系统服务
{
    public static class LookUp
    {
        #region 存货档案
        /// <summary>
        /// 存货档案
        /// </summary>
        /// <returns></returns>
        public static DataTable Inventory()
        {
            return Inventory("");
        }

        /// <summary>
        /// 存货档案
        /// </summary>
        /// <param name="par">存货档案编码</param>
        /// <returns></returns>
        public static DataTable Inventory(string par)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = @"select cInvCode,cInvName,cInvAddCode,cInvStd from @u8.Inventory where 1=1 ";
            if (par != "")
            {
                sSQL = sSQL + " and cInvCode='" + par + "'";
            }
            sSQL = sSQL + " order by cInvCode "; 
            
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            return dt;
        }

        public static void Inventory(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = Inventory();
            lookup.Properties.ValueMember = "cInvCode";
            lookup.Properties.DisplayMember = "cInvName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCode", "存货编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvName", "存货名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvStd", "规格型号")});
        }

        public static void Inventory(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            lookup.Columns.Clear();
            lookup.Properties.DataSource = Inventory();
            lookup.Properties.ValueMember = "cInvCode";
            lookup.Properties.DisplayMember = "cInvName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCode", "存货编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvName", "存货名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvStd", "规格型号")});
        }

       
        #endregion

        #region 供应商
        /// <summary>
        /// 供应商
        /// </summary>
        /// <returns></returns>
        public static DataTable Vendor()
        {
            return Vendor("");
        }
        /// <summary>
        /// 供应商
        /// </summary>
        /// <param name="par">供应商</param>
        /// <returns></returns>
        public static DataTable Vendor(string par)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = @"select DISTINCT VenCode from Registers where 1=1 ";
            if (par != "")
            {
                sSQL = sSQL + " and VenCode='" + par + "'";
            }
            sSQL = sSQL + " order by VenCode ";

            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            return dt;
        }

        public static void Vendor(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = Vendor();
            lookup.Properties.ValueMember = "VenCode";
            lookup.Properties.DisplayMember = "VenCode";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("VenCode", "供应商编码")});
        }

        public static void Vendor(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            lookup.Columns.Clear();
            lookup.Properties.DataSource = Vendor();
            lookup.Properties.ValueMember = "VenCode";
            lookup.Properties.DisplayMember = "VenCode";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("VenCode", "供应商编码")});
        }
        #endregion

        #region 定单编号
        /// <summary>
        /// 供应商
        /// </summary>
        /// <returns></returns>
        public static DataTable OrderNo()
        {
            return OrderNo("");
        }
        /// <summary>
        /// 定单编号
        /// </summary>
        /// <param name="par">定单编号</param>
        /// <returns></returns>
        public static DataTable OrderNo(string par)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = @"select DISTINCT OrderNo from Registers where 1=1 ";
            if (par != "")
            {
                sSQL = sSQL + " and OrderNo='" + par + "'";
            }
            sSQL = sSQL + " order by OrderNo ";

            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            return dt;
        }

        public static void OrderNo(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = OrderNo();
            lookup.Properties.ValueMember = "OrderNo";
            lookup.Properties.DisplayMember = "OrderNo";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("OrderNo", "定单编号")});
        }

        public static void OrderNo(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            lookup.Columns.Clear();
            lookup.Properties.DataSource = OrderNo();
            lookup.Properties.ValueMember = "OrderNo";
            lookup.Properties.DisplayMember = "OrderNo";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("VenCode", "定单编号")});
        }
        #endregion

        #region 门号
        /// <summary>
        /// 门号
        /// </summary>
        /// <returns></returns>
        public static DataTable Door()
        {
            return Door("");
        }
        /// <summary>
        /// 门号
        /// </summary>
        /// <param name="par">门号</param>
        /// <returns></returns>
        public static DataTable Door(string par)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = @"select DISTINCT iDoor from Gate where 1=1 and isnull(iDoor,'') <> '' ";
            if (par != "")
            {
                sSQL = sSQL + " and iDoor='" + par + "'";
            }
            sSQL = sSQL + " order by iDoor "; 
            
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            return dt;
        }

        public static void Door(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = Door();
            lookup.Properties.ValueMember = "iDoor";
            lookup.Properties.DisplayMember = "iDoor";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iDoor", "门号")});
        }

        public static void Door(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            lookup.Columns.Clear();
            lookup.Properties.DataSource = Door();
            lookup.Properties.ValueMember = "iDoor";
            lookup.Properties.DisplayMember = "iDoor";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iDoor", "门号")});
        }
        #endregion
    }
}
	