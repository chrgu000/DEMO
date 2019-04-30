using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public static class LookUp
    {
        #region 存货档案
        /// <summary>
        /// 
        /// </summary>
        /// <param name="par"></param>
        /// <returns></returns>
        public static DataTable Inventory(string Conn)
        {
            string sSQL = @"select cInvCode,cInvName,cInvAddCode,cInvStd,cEnglishName from Inventory where 1=1 ";
            return SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
        }

        public static void Inventory(string Conn,DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = Inventory(Conn);
            lookup.Properties.ValueMember = "cInvCode";
            lookup.Properties.DisplayMember = "cInvName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCode", "Product Code"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvName", "Product Name"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvStd", "Specification"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cEnglishName", "English Name")});
        }

        public static void Inventory(string Conn,DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            lookup.Columns.Clear();
            lookup.Properties.DataSource = Inventory(Conn);
            lookup.Properties.ValueMember = "cInvCode";
            lookup.Properties.DisplayMember = "cInvName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCode", "Product Code"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvName", "Product Name"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvStd", "Specification"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cEnglishName", "English Name")});
        }
        #endregion

        #region 项目
        /// <summary>
        /// 
        /// </summary>
        /// <param name="par"></param>
        /// <returns></returns>
        public static DataTable QC(string Conn)
        {
            string sSQL = @"select QCCode, QCName from _QC where 1=1 ";
            return SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
        }

        public static void QC(string Conn, DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = QC(Conn);
            lookup.Properties.ValueMember = "QCCode";
            lookup.Properties.DisplayMember = "QCName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("QCCode", "项目编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("QCName", "项目名称")});
        }

        public static void QC(string Conn, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = QC(Conn);
            lookup.Properties.ValueMember = "QCCode";
            lookup.Properties.DisplayMember = "QCName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("QCCode", "项目编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("QCName", "项目名称")});
        }
        #endregion

        #region 供应商分类
        /// <summary>
        /// 
        /// </summary>
        /// <param name="par"></param>
        /// <returns></returns>
        public static DataTable Vendor(string Conn)
        {
            string sSQL = @"select cVenCode,cVenName,cVenEnName  from Vendor where 1=1 ";
            sSQL = sSQL + " order by cVenCode ";
            return SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
        }

        public static void Vendor(string Conn,DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = Vendor(Conn);
            lookup.Properties.ValueMember = "cVenCode";
            lookup.Properties.DisplayMember = "cVenName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cVenCode", "Vendor Code"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cVenName", "Vendor Name"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cVenEnName", "English Name")});
        }

        public static void Vendor(string Conn,DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            lookup.Columns.Clear();
            lookup.Properties.DataSource = Vendor(Conn);
            lookup.Properties.ValueMember = "cVenCode";
            lookup.Properties.DisplayMember = "cVenName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cVenCode", "Vendor Code"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cVenName", "Vendor Name"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cVenEnName", "English Name")});
        }
        #endregion

        #region 客户
        /// <summary>
        /// 
        /// </summary>
        /// <param name="par"></param>
        /// <returns></returns>
        public static DataTable Customer(string Conn)
        {
            string sSQL = @"select cCusCode ,cCusName  from Customer where 1=1 ";
            sSQL = sSQL + " order by cCusCode ";
            return SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
        }

        public static void Customer(string Conn, DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = Customer(Conn);
            lookup.Properties.ValueMember = "cCusCode";
            lookup.Properties.DisplayMember = "cCusName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusCode", "客户名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusName", "客户名称")});
        }

        public static void Customer(string Conn, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            lookup.Columns.Clear();
            lookup.Properties.DataSource = Customer(Conn);
            lookup.Properties.ValueMember = "cCusCode";
            lookup.Properties.DisplayMember = "cCusName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusCode", "客户名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusName", "客户名称")});
        }
        #endregion

        #region 部门
        /// <summary>
        /// 
        /// </summary>
        /// <param name="par"></param>
        /// <returns></returns>
        public static DataTable Department(string Conn)
        {
            string sSQL = @"select cDepCode,cDepName  from Department  where 1=1 ";
            sSQL = sSQL + " order by cDepCode ";
            return SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
        }

        public static void Department(string Conn, DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = Department(Conn);
            lookup.Properties.ValueMember = "cDepCode";
            lookup.Properties.DisplayMember = "cDepName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepCode", "Department Code"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepName", "Department Name")});
        }

        public static void Department(string Conn, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            lookup.Columns.Clear();
            lookup.Properties.DataSource = Department(Conn);
            lookup.Properties.ValueMember = "cDepCode";
            lookup.Properties.DisplayMember = "cDepName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepCode", "Department Code"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepName", "Department Name")});
        }
        #endregion

        #region 仓库
        /// <summary>
        /// 
        /// </summary>
        /// <param name="par"></param>
        /// <returns></returns>
        public static DataTable Warehouse(string Conn)
        {
            string sSQL = @"select cWhCode,cWhName  from Warehouse  where 1=1 ";
            sSQL = sSQL + " order by cWhCode ";
            return SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
        }

        public static void Warehouse(string Conn, DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = Warehouse(Conn);
            lookup.Properties.ValueMember = "cWhCode";
            lookup.Properties.DisplayMember = "cWhName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cWhCode", "Warehouse Code"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cWhName", "Warehouse Name")});
        }

        public static void Warehouse(string Conn, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            lookup.Columns.Clear();
            lookup.Properties.DataSource = Warehouse(Conn);
            lookup.Properties.ValueMember = "cWhCode";
            lookup.Properties.DisplayMember = "cWhName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cWhCode", "Warehouse Code"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cWhName", "Warehouse Name")});
        }

        public static void Warehouse(string Conn, DevExpress.XtraEditors.CheckedComboBoxEdit lookup)
        {
            lookup.Properties.Items.Clear();
            lookup.Properties.DataSource = Warehouse(Conn);
            lookup.Properties.ValueMember = "cWhCode";
            lookup.Properties.DisplayMember = "cWhName";
            lookup.Properties.NullText = "";
            lookup.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cWhCode", "Warehouse Code"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cWhName", "Warehouse Name")});
        }
        #endregion

        #region 仓库
        /// <summary>
        /// 
        /// </summary>
        /// <param name="par"></param>
        /// <returns></returns>
        public static DataTable Person(string Conn)
        {
            string sSQL = @"select cPersonCode,cPersonName  from Person  where 1=1 ";
            sSQL = sSQL + " order by cPersonCode ";
            return SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
        }

        public static void Person(string Conn, DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = Person(Conn);
            lookup.Properties.ValueMember = "cPersonCode";
            lookup.Properties.DisplayMember = "cPersonName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cPersonCode", "用户编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cPersonName", "用户名称")});
        }

        public static void Person(string Conn, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            lookup.Columns.Clear();
            lookup.Properties.DataSource = Person(Conn);
            lookup.Properties.ValueMember = "cPersonCode";
            lookup.Properties.DisplayMember = "cPersonName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cPersonCode", "用户编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cPersonName", "用户名称")});
        }

        public static void Person(string Conn, DevExpress.XtraEditors.CheckedComboBoxEdit lookup)
        {
            lookup.Properties.Items.Clear();
            lookup.Properties.DataSource = Person(Conn);
            lookup.Properties.ValueMember = "cPersonCode";
            lookup.Properties.DisplayMember = "cPersonName";
            lookup.Properties.NullText = "";
            lookup.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cPersonCode", "用户编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cPersonName", "用户名称")});
        }
        #endregion
    }
}
	