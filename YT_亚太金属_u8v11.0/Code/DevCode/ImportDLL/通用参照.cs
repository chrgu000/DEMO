using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ImportDLL
{
    public static class LookUp
    {
        #region LoopUpData
        public static DataTable _LoopUpData(string id)
        {
            FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();
            string sSQL = "select iID,iText,Remark from dbo._LookUpDate where iType = '" + id + "' and isnull(bClose,1) = 1 order by iID";
            return clsSQLCommond.ExecQuery(sSQL);
        }
        public static void _LoopUpData(DevExpress.XtraEditors.LookUpEdit lookup, string id)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = _LoopUpData(id);
            lookup.Properties.ValueMember = "iID";
            lookup.Properties.DisplayMember = "iText";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iID", "类型编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iText", "类型名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Remark", "备注")});
        }

        public static void _LoopUpData(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup, string id)
        {
            lookup.Columns.Clear();
            lookup.Properties.DataSource = _LoopUpData(id);
            lookup.Properties.ValueMember = "iID";
            lookup.Properties.DisplayMember = "iText";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iID", "类型编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iText", "类型名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Remark", "备注")});
        }
        #endregion

        #region 存货类别
        /// <summary>
        /// 存货类别
        /// </summary>
        /// <returns></returns>
        public static DataTable InventoryClass()
        {
            return InventoryClass("");
        }
        /// <summary>
        /// 存货类别
        /// </summary>
        /// <param name="par">存货类别编码</param>
        /// <returns></returns>
        public static DataTable InventoryClass(string par)
        {
            FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();
            string sSQL = @"select cInvCCode,cInvCName  from @u8.InventoryClass where 1=1 ";
            if (par != "")
            {
                sSQL = sSQL + " and cInvCCode='" + par + "'";
            }
            sSQL = sSQL + " order by cInvCCode ";
            return clsSQLCommond.ExecQuery(sSQL);
        }

        public static void InventoryClass(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = InventoryClass();
            lookup.Properties.ValueMember = "cInvCCode";
            lookup.Properties.DisplayMember = "cInvCName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCCode", "存货类别编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCName", "存货类别名称")});
        }

        public static void InventoryClass(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            lookup.Columns.Clear();
            lookup.Properties.DataSource = InventoryClass();
            lookup.Properties.ValueMember = "cInvCCode";
            lookup.Properties.DisplayMember = "cInvCName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCCode", "存货类别编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCName", "存货类别名称")});
        }
        #endregion

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
            FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();
            string sSQL = @"select cInvCode,cInvName,cInvAddCode,cInvStd from @u8.Inventory where 1=1 ";
            if (par != "")
            {
                sSQL = sSQL + " and cInvCode='" + par + "'";
            }
            sSQL = sSQL + " order by cInvCode ";
            return clsSQLCommond.ExecQuery(sSQL);
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

        #region 生产订单
        /// <summary>
        /// 生产订单
        /// </summary>
        /// <returns></returns>
        public static DataTable mom_order()
        {
            return mom_order("");
        }

        /// <summary>
        /// 生产订单
        /// </summary>
        /// <param name="par"></param>
        /// <returns></returns>
        public static DataTable mom_order(string par)
        {
            FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();
            string sSQL = @"select MoCode from @u8.mom_order where 1=1 ";
            if (par != "")
            {
                sSQL = sSQL + " and MoCode='" + par + "'";
            }
            sSQL = sSQL + " order by MoCode ";
            return clsSQLCommond.ExecQuery(sSQL);
        }

        public static void mom_order(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = mom_order();
            lookup.Properties.ValueMember = "MoCode";
            lookup.Properties.DisplayMember = "MoCode";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MoCode", "生产订单号")});
        }

        public static void mom_order(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            lookup.Columns.Clear();
            lookup.Properties.DataSource = mom_order();
            lookup.Properties.ValueMember = "MoCode";
            lookup.Properties.DisplayMember = "MoCode";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MoCode", "生产订单号")});
        }


        #endregion

        #region 工作中心
        /// <summary>
        /// 工作中心
        /// </summary>
        /// <param name="par"></param>
        /// <returns></returns>

        public static DataTable sfc_workcenter()
        {
            return sfc_workcenter("");
        }

        public static DataTable sfc_workcenter(string par)
        {
            FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();
            string sSQL = @"select WcCode,case when WcCode='005' then '磨床' when WcCode='004' then '铣、割键' else Description end Description from @u8.sfc_workcenter where 1=1 ";
            if (par != "")
            {
                sSQL = sSQL + " and WcCode='" + par + "'";
            }
            sSQL = sSQL + " order by WcCode ";
            return clsSQLCommond.ExecQuery(sSQL);
        }

        public static void sfc_workcenter(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = sfc_workcenter();
            lookup.Properties.ValueMember = "WcCode";
            lookup.Properties.DisplayMember = "Description";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("WcCode", "工作中心序号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Description", "工作中心名称")});
        }

        public static void sfc_workcenter(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            lookup.Columns.Clear();
            lookup.Properties.DataSource = sfc_workcenter();
            lookup.Properties.ValueMember = "WcCode";
            lookup.Properties.DisplayMember = "Description";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("WcCode", "工作中心序号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Description", "工作中心名称")});
        }


        #endregion

        #region 设备
        /// <summary>
        /// 设备
        /// </summary>
        /// <param name="par"></param>
        /// <returns></returns>

        public static DataTable EQ_EQData()
        {
            return EQ_EQData("");
        }

        public static DataTable EQ_EQData(string par)
        {
            FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();
            string sSQL = @"select cEQCode,cEQName from @u8.EQ_EQData where 1=1 ";
            if (par != "")
            {
                sSQL = sSQL + " and cEQCode='" + par + "'";
            }
            sSQL = sSQL + " order by cEQCode ";
            return clsSQLCommond.ExecQuery(sSQL);
        }

        public static void EQ_EQData(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = EQ_EQData();
            lookup.Properties.ValueMember = "cEQCode";
            lookup.Properties.DisplayMember = "cEQName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cEQCode", "设备序号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cEQName", "设备名称")});
        }

        public static void EQ_EQData(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            lookup.Columns.Clear();
            lookup.Properties.DataSource = EQ_EQData();
            lookup.Properties.ValueMember = "cEQCode";
            lookup.Properties.DisplayMember = "cEQName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cEQCode", "设备序号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cEQName", "设备名称")});
        }


        #endregion


        #region 存货类别
        /// <summary>
        /// 存货类别
        /// </summary>
        /// <returns></returns>
        public static DataTable Customer()
        {
            return Customer("");
        }
        /// <summary>
        /// 存货类别
        /// </summary>
        /// <param name="par">存货类别编码</param>
        /// <returns></returns>
        public static DataTable Customer(string par)
        {
            FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();
            string sSQL = @"select cCusCode,cCusName  from @u8.Customer  where 1=1 ";
            if (par != "")
            {
                sSQL = sSQL + " and cCusCode='" + par + "'";
            }
            sSQL = sSQL + " order by cCusCode ";
            return clsSQLCommond.ExecQuery(sSQL);
        }

        public static void Customer(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = Customer();
            lookup.Properties.ValueMember = "cCusCode";
            lookup.Properties.DisplayMember = "cCusName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusCode", "客户编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusName", "客户名称")});
        }

        public static void Customer(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            lookup.Columns.Clear();
            lookup.Properties.DataSource = Customer();
            lookup.Properties.ValueMember = "cCusCode";
            lookup.Properties.DisplayMember = "cCusName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusCode", "客户编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusName", "客户名称")});
        }
        #endregion

        #region 人员
        /// <summary>
        /// 人员
        /// </summary>
        /// <param name="par"></param>
        /// <returns></returns>

        public static DataTable Person()
        {
            return Person("");
        }

        public static DataTable Person(string par)
        {
            FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();
            string sSQL = @"select PersonCode,PersonName from Person where 1=1 ";
            if (par != "")
            {
                sSQL = sSQL + " and PersonCode='" + par + "'";
            }
            sSQL = sSQL + " order by PersonCode ";
            return clsSQLCommond.ExecQuery(sSQL);
        }

        public static void Person(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = Person();
            lookup.Properties.ValueMember = "PersonCode";
            lookup.Properties.DisplayMember = "PersonName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PersonCode", "员工编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PersonName", "员工名称")});
        }

        public static void Person(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            lookup.Columns.Clear();
            lookup.Properties.DataSource = Person();
            lookup.Properties.ValueMember = "PersonCode";
            lookup.Properties.DisplayMember = "PersonName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PersonCode", "员工编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PersonName", "员工名称")});
        }

        public static void Person2(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            lookup.Columns.Clear();
            lookup.Properties.DataSource = Person();
            lookup.Properties.ValueMember = "PersonName";
            lookup.Properties.DisplayMember = "PersonName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PersonCode", "员工编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PersonName", "员工名称")});
        }
        #endregion
    }
}
	