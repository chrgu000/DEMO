using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace 系统服务
{
    public static class LookUp
    {
        #region LoopUpData
        public static DataTable _LoopUpData(string id)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = "select iID,iText from dbo._LookUpDate where iType = '" + id + "' and isnull(bClose,1) = 1 order by iID";
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
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iText", "类型名称")});
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
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iText", "类型名称")});
        }
        #endregion

        #region 计量档案组
        /// <summary>
        /// 计量档案组
        /// </summary>
        /// <returns></returns>
        public static DataTable ComputationUnitGroup()
        {
            return ComputationUnitGroup("");
        }
        /// <summary>
        /// 计量档案组
        /// </summary>
        /// <param name="par">计量档案组编码</param>
        /// <returns></returns>
        public static DataTable ComputationUnitGroup(string par)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = @"select a.cGroupCode,b.cComunitCode,b.cComunitName as cComunitName,c.cComunitCode as cAuxComunitCode,c.cComunitName as cAuxComunitName 
                from ComputationUnitGroup a left join ComputationUnit b on a.cComunitCode=b.cComunitCode 
                left join ComputationUnit c on a.cAuxComunitCode=c.cComunitCode where 1=1 ";
            if (par != "")
            {
                sSQL = sSQL + " and a.cGroupCode='" + par + "'";
            }
            sSQL = sSQL + " order by a.cGroupCode,b.cComunitCode";
            return clsSQLCommond.ExecQuery(sSQL);
        }
        public static void ComputationUnitGroup(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = ComputationUnitGroup();
            lookup.Properties.ValueMember = "cGroupCode";
            lookup.Properties.DisplayMember = "cComunitName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cGroupCode", "计量档案组编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cComunitCode", "主计量编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cComunitName", "主计量名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cAuxComunitCode", "辅计量编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cAuxComunitName", "辅计量名称")});
        }
        public static void ComputationUnitGroup(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            lookup.Columns.Clear();
            lookup.Properties.DataSource = ComputationUnitGroup();
            lookup.Properties.ValueMember = "cGroupCode";
            lookup.Properties.DisplayMember = "cComunitName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cGroupCode", "计量档案组编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cComunitCode", "主计量编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cComunitName", "主计量名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cAuxComunitCode", "辅计量编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cAuxComunitName", "辅计量名称")});
        }
        #endregion

        #region 人员档案
        /// <summary>
        /// 人员档案
        /// </summary>
        /// <returns></returns>
        public static DataTable Person()
        {
            return Person("");
        }
        /// <summary>
        /// 人员档案
        /// </summary>
        /// <param name="par">人员编码</param>
        /// <returns></returns>
        public static DataTable Person(string par)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = @"select PersonCode,PersonName from Person where 1=1 ";
            if (par != "")
            {
                sSQL = sSQL + " and PersonCode='" + par + "'";
            }
            sSQL = sSQL + " order by PersonCode";
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
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PersonCode", "人员编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PersonName", "人员名称")});
        }

        public static void Person(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            lookup.Columns.Clear();
            lookup.Properties.DataSource = Person();
            lookup.Properties.ValueMember = "PersonCode";
            lookup.Properties.DisplayMember = "PersonName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PersonCode", "人员编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PersonName", "人员名称")});
        }
        #endregion

        #region 部门人员档案
        /// <summary>
        /// 部门人员档案
        /// </summary>
        /// <returns></returns>
        public static DataTable PersonDepartment()
        {
            return PersonDepartment("");
        }
        /// <summary>
        /// 部门人员档案
        /// </summary>
        /// <param name="par">人员编码</param>
        /// <returns></returns>
        public static DataTable PersonDepartment(string par)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = @"select a.PersonCode,a.PersonName,b.cDepCode,b.cDepName from Person a left join dbo.Department b on b.cDepCode = a.DeptID where 1=1 ";
            if (par != "")
            {
                sSQL = sSQL + " and PersonCode='" + par + "'";
            }
            sSQL = sSQL + " order by a.PersonCode,b.cDepCode";
            return clsSQLCommond.ExecQuery(sSQL);
        }
        #endregion

        #region 客户档案
        /// <summary>
        /// 客户档案
        /// </summary>
        /// <returns></returns>
        public static DataTable Customer()
        {
            return Customer("");
        }
        /// <summary>
        /// 客户档案
        /// </summary>
        /// <param name="par">客户档案</param>
        /// <returns></returns>
        public static DataTable Customer(string par)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = @"select cCusCode,cCusName,cCusAbbName from Customer where 1=1 ";
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

        public static DataTable CustomercCusPPerson(string par)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = @"select * from Customer where 1=1 ";
            if (par != "")
            {
                sSQL = sSQL + " and cCusCode='" + par + "'";
            }
            sSQL = sSQL + " order by cCusCode ";

            return clsSQLCommond.ExecQuery(sSQL);
        }
        #endregion

        #region 意向性客户
        /// <summary>
        /// 意向性客户
        /// </summary>
        /// <returns></returns>
        public static DataTable CustomersIntentionality()
        {
            return CustomersIntentionality("");
        }
        /// <summary>
        /// 意向性客户
        /// </summary>
        /// <param name="par">意向性客户</param>
        /// <returns></returns>
        public static DataTable CustomersIntentionality(string par)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = @"select iCode,cIntName  from CustomersIntentionality  where isnull(bCustomer,'')='' ";
            if (par != "")
            {
                sSQL = sSQL + " and iCode='" + par + "'";
            }
            sSQL = sSQL + " order by iCode ";
            return clsSQLCommond.ExecQuery(sSQL);
        }

        public static void CustomersIntentionality(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = CustomersIntentionality();
            lookup.Properties.ValueMember = "iCode";
            lookup.Properties.DisplayMember = "cIntName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iCode", "意向性客户编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cIntName", "意向性客户名称")});
        }

        public static void CustomersIntentionality(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            lookup.Columns.Clear();
            lookup.Properties.DataSource = CustomersIntentionality();
            lookup.Properties.ValueMember = "iCode";
            lookup.Properties.DisplayMember = "cIntName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iCode", "意向性客户编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cIntName", "意向性客户名称")});
        }
        #endregion

        #region 部门档案
        /// <summary>
        /// 部门档案
        /// </summary>
        /// <returns></returns>
        public static DataTable Department()
        {
            return Department("");
        }
        /// <summary>
        /// 部门档案
        /// </summary>
        /// <param name="par">部门编码</param>
        /// <returns></returns>
        public static DataTable Department(string par)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = @"select cDepCode,cDepName from Department where 1=1 ";
            if (par != "")
            {
                sSQL = sSQL + " and cDepCode='" + par + "'";
            }
            sSQL = sSQL + " order by cDepCode ";
            return clsSQLCommond.ExecQuery(sSQL);
        }

        public static void Department(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = Department();
            lookup.Properties.ValueMember = "cDepCode";
            lookup.Properties.DisplayMember = "cDepName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepCode", "部门编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepName", "部门名称")});
        }

        public static void Department(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            lookup.Columns.Clear();
            lookup.Properties.DataSource = Department();
            lookup.Properties.ValueMember = "cDepCode";
            lookup.Properties.DisplayMember = "cDepName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepCode", "部门编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepName", "部门名称")});
        }
        #endregion

        #region 人员职务
        /// <summary>
        /// 人员职务
        /// </summary>
        /// <returns></returns>
        public static DataTable PersonDuty()
        {
            return PersonDuty("");
        }
        /// <summary>
        /// 人员职务
        /// </summary>
        /// <param name="par">职务编码</param>
        /// <returns></returns>
        public static DataTable PersonDuty(string par)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = @"select cDCode,cDName from PersonDuty where 1=1 ";
            if (par != "")
            {
                sSQL = sSQL + " and cDCode='" + par + "'";
            }
            sSQL = sSQL + " order by cDCode ";
            return clsSQLCommond.ExecQuery(sSQL);
        }

        public static void PersonDuty(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = PersonDuty();
            lookup.Properties.ValueMember = "cDCode";
            lookup.Properties.DisplayMember = "cDName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDCode", "人员职务编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDName", "人员职务名称")});
        }

        public static void PersonDuty(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            lookup.Columns.Clear();
            lookup.Properties.DataSource = PersonDuty();
            lookup.Properties.ValueMember = "cDCode";
            lookup.Properties.DisplayMember = "cDName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDCode", "人员职务编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDName", "人员职务名称")});
        }
        #endregion

        #region 人员类别
        /// <summary>
        /// 人员类别
        /// </summary>
        /// <returns></returns>
        public static DataTable PersonType()
        {
            return PersonType("");
        }
        /// <summary>
        /// 人员类别
        /// </summary>
        /// <param name="par">人员类别</param>
        /// <returns></returns>
        public static DataTable PersonType(string par)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = @"select cPTCode,cPTName from PersonType where 1=1 ";
            if (par != "")
            {
                sSQL = sSQL + " and cPTCode='" + par + "'";
            }
            sSQL = sSQL + " order by cPTCode ";
            return clsSQLCommond.ExecQuery(sSQL);
        }

        public static void PersonType(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = PersonType();
            lookup.Properties.ValueMember = "cPTCode";
            lookup.Properties.DisplayMember = "cPTName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cPTCode", "人员类别编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cPTName", "人员类别名称")});
        }

        public static void PersonType(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            lookup.Columns.Clear();
            lookup.Properties.DataSource = PersonType();
            lookup.Properties.ValueMember = "cPTCode";
            lookup.Properties.DisplayMember = "cPTName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cPTCode", "人员类别编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cPTName", "人员类别名称")});
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
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = @"select cInvClassCode,cInvClassName from InventoryClass where 1=1 ";
            if (par != "")
            {
                sSQL = sSQL + " and cInvClassCode='" + par + "'";
            }
            sSQL = sSQL + " order by cInvClassCode ";
            return clsSQLCommond.ExecQuery(sSQL);
        }

        public static void InventoryClass(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = InventoryClass();
            lookup.Properties.ValueMember = "cInvClassCode";
            lookup.Properties.DisplayMember = "cInvClassName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvClassCode", "存货类别编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvClassName", "存货类别名称")});
        }

        public static void InventoryClass(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            lookup.Columns.Clear();
            lookup.Properties.DataSource = InventoryClass();
            lookup.Properties.ValueMember = "cInvClassCode";
            lookup.Properties.DisplayMember = "cInvClassName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvClassCode", "存货类别编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvClassName", "存货类别名称")});
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
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = @"select cInvCode,cInvName,cInvAddCode,cInvStd,cInvVenCode from Inventory where 1=1 ";
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

        public static void Inventory2(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = Inventory();
            lookup.Properties.ValueMember = "cInvCode";
            lookup.Properties.DisplayMember = "cInvVenCode";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCode", "存货编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvName", "存货名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvStd", "规格型号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvVenCode", "供应商存货编码")});
        }

        public static void Inventory2(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            lookup.Columns.Clear();
            lookup.Properties.DataSource = Inventory();
            lookup.Properties.ValueMember = "cInvCode";
            lookup.Properties.DisplayMember = "cInvVenCode";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCode", "存货编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvName", "存货名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvStd", "规格型号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvVenCode", "供应商存货编码")});
        }



        public static void Inventory3(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = Inventory();
            lookup.Properties.ValueMember = "cInvCode";
            lookup.Properties.DisplayMember = "cInvAddCode";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCode", "存货编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvName", "存货名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvAddCode", "存货代码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvStd", "规格型号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvVenCode", "供应商存货编码")});
        }

        
        public static void Inventory3(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            lookup.Columns.Clear();
            lookup.Properties.DataSource = Inventory();
            lookup.Properties.ValueMember = "cInvCode";
            lookup.Properties.DisplayMember = "cInvAddCode";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCode", "存货编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvName", "存货名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvAddCode", "存货代码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvStd", "规格型号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvVenCode", "供应商存货编码")});
        }

        #endregion

        #region 地区分类
        /// <summary>
        /// 地区分类
        /// </summary>
        /// <returns></returns>
        public static DataTable DistrictClass()
        {
            return DistrictClass("");
        }
        /// <summary>
        /// 地区分类
        /// </summary>
        /// <param name="par">分类编码</param>
        /// <returns></returns>
        public static DataTable DistrictClass(string par)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = @"select cDCCode,cDCName from DistrictClass where 1=1 ";
            if (par != "")
            {
                sSQL = sSQL + " and cDCCode='" + par + "'";
            }
            sSQL = sSQL + " order by cDCCode ";
            return clsSQLCommond.ExecQuery(sSQL);
        }

        public static void DistrictClass(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = DistrictClass();
            lookup.Properties.ValueMember = "cDCCode";
            lookup.Properties.DisplayMember = "cDCName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDCCode", "地区分类编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDCName", "地区分类名称")});
        }
        public static void DistrictClass(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            lookup.Columns.Clear();
            lookup.Properties.DataSource = DistrictClass();
            lookup.Properties.ValueMember = "cDCCode";
            lookup.Properties.DisplayMember = "cDCName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDCCode", "地区分类编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDCName", "地区分类名称")});
        }
        #endregion

        #region 供应商分类
        /// <summary>
        /// 供应商分类
        /// </summary>
        /// <returns></returns>
        public static DataTable VendorClass()
        {
            return VendorClass("");
        }
        /// <summary>
        /// 供应商分类
        /// </summary>
        /// <param name="par">供应商分类编码</param>
        /// <returns></returns>
        public static DataTable VendorClass(string par)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = @"select cVCCode,cVCName from VendorClass where 1=1 ";
            if (par != "")
            {
                sSQL = sSQL + " and cVCCode='" + par + "'";
            }
            sSQL = sSQL + " order by cVCCode ";
            return clsSQLCommond.ExecQuery(sSQL);
        }

        public static void VendorClass(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = VendorClass();
            lookup.Properties.ValueMember = "cVCCode";
            lookup.Properties.DisplayMember = "cVCName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cVCCode", "供应商分类编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cVCName", "供应商分类名称")});
        }

        public static void VendorClass(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            lookup.Columns.Clear();
            lookup.Properties.DataSource = VendorClass();
            lookup.Properties.ValueMember = "cVCCode";
            lookup.Properties.DisplayMember = "cVCName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cVCCode", "供应商分类编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cVCName", "供应商分类名称")});
        }
        #endregion

        #region 供应商分类
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
            string sSQL = @"select cVenCode,cVenName from Vendor where 1=1 ";
            if (par != "")
            {
                sSQL = sSQL + " and cVenCode='" + par + "'";
            }
            sSQL = sSQL + " order by cVenCode ";
            return clsSQLCommond.ExecQuery(sSQL);
        }

        public static void Vendor(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = Vendor();
            lookup.Properties.ValueMember = "cVenCode";
            lookup.Properties.DisplayMember = "cVenName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cVenCode", "供应商编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cVenName", "供应商名称")});
        }

        public static void Vendor(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            lookup.Columns.Clear();
            lookup.Properties.DataSource = Vendor();
            lookup.Properties.ValueMember = "cVenCode";
            lookup.Properties.DisplayMember = "cVenName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cVenCode", "供应商编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cVenName", "供应商名称")});
        }
        #endregion

        #region 经销商分类
        /// <summary>
        /// 经销商分类
        /// </summary>
        /// <returns></returns>
        public static DataTable DealerClass()
        {
            return DealerClass("");
        }
        /// <summary>
        /// 经销商分类
        /// </summary>
        /// <param name="par">经销商分类编码</param>
        /// <returns></returns>
        public static DataTable DealerClass(string par)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = @"select cDCode,cDName from Dealer where 1=1 ";
            if (par != "")
            {
                sSQL = sSQL + " and cDCode='" + par + "'";
            }
            sSQL = sSQL + " order by cDCode ";
            return clsSQLCommond.ExecQuery(sSQL);
        }

        public static void DealerClass(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = DealerClass();
            lookup.Properties.ValueMember = "cDCode";
            lookup.Properties.DisplayMember = "cDName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDCode", "经销商分类编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDName", "经销商分类名称")});
        }

        public static void DealerClass(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            lookup.Columns.Clear();
            lookup.Properties.DataSource = DealerClass();
            lookup.Properties.ValueMember = "cDCode";
            lookup.Properties.DisplayMember = "cDName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDCode", "经销商分类编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDName", "经销商分类名称")});
        }
        #endregion

        #region 客户分类
        /// <summary>
        /// 客户分类
        /// </summary>
        /// <returns></returns>
        public static DataTable CustomerClass()
        {
            return CustomerClass("");
        }
        /// <summary>
        /// 客户分类
        /// </summary>
        /// <param name="par">客户分类编码</param>
        /// <returns></returns>
        public static DataTable CustomerClass(string par)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = @"select cCCode,cCName from CustomerClass where 1=1 ";
            if (par != "")
            {
                sSQL = sSQL + " and cCCode='" + par + "'";
            }
            sSQL = sSQL + " order by cCCode ";
            return clsSQLCommond.ExecQuery(sSQL);
        }

        public static void CustomerClass(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = CustomerClass();
            lookup.Properties.ValueMember = "cCCode";
            lookup.Properties.DisplayMember = "cCName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCCode", "客户分类编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCName", "客户分类名称")});
        }

        public static void CustomerClass(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            lookup.Columns.Clear();
            lookup.Properties.DataSource = CustomerClass();
            lookup.Properties.ValueMember = "cCCode";
            lookup.Properties.DisplayMember = "cCName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCCode", "客户分类编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCName", "客户分类名称")});
        }
        #endregion

        #region 结算方式
        /// <summary>
        /// 结算方式
        /// </summary>
        /// <returns></returns>
        public static DataTable SettleStyle()
        {
            return SettleStyle("");
        }
        /// <summary>
        /// 结算方式
        /// </summary>
        /// <param name="par">结算方式编码</param>
        /// <returns></returns>
        public static DataTable SettleStyle(string par)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = @"select cSSCode,cSSName from SettleStyle where 1=1 ";
            if (par != "")
            {
                sSQL = sSQL + " and cSSCode='" + par + "'";
            }
            sSQL = sSQL + " order by cSSCode ";
            return clsSQLCommond.ExecQuery(sSQL);
        }

        public static void SettleStyle(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = SettleStyle();
            lookup.Properties.ValueMember = "cSSCode";
            lookup.Properties.DisplayMember = "cSSName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cSSCode", "结算方式编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cSSName", "结算方式名称")});
        }

        public static void SettleStyle(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            lookup.Columns.Clear();
            lookup.Properties.DataSource = SettleStyle();
            lookup.Properties.ValueMember = "cSSCode";
            lookup.Properties.DisplayMember = "cSSName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cSSCode", "结算方式编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cSSName", "结算方式名称")});
        }
        #endregion

        #region 销售类型
        /// <summary>
        /// 销售类型
        /// </summary>
        /// <returns></returns>
        public static DataTable SaleTypeSaleRole()
        {
            return SaleTypeSaleRole("");
        }
        /// <summary>
        /// 销售类型
        /// </summary>
        /// <param name="par">销售类型编码</param>
        /// <returns></returns>
        public static DataTable SaleTypeSaleRole(string par)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();

            string sSQL = "";
            if(系统服务.ClsBaseDataInfo.sUid == "admin")
                sSQL = @"select cSTCode,cSTName from SaleType where 1=1 ";
            else
                sSQL = @"select cSTCode,cSTName from SaleType where 1=1 and cSTCode in (select cSTCode from SaleRole where vchrUid='" + 系统服务.ClsBaseDataInfo.sUid + "')";
            if (par != "")
            {
                sSQL = sSQL + " and cSTCode='" + par + "'";
            }
            sSQL = sSQL + " order by cSTCode ";
            return clsSQLCommond.ExecQuery(sSQL);
        }

        public static void SaleTypeSaleRole(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = SaleTypeSaleRole();
            lookup.Properties.ValueMember = "cSTCode";
            lookup.Properties.DisplayMember = "cSTName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cSTCode", "销售类型编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cSTName", "销售类型名称")});
        }

        public static void SaleTypeSaleRole(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            lookup.Columns.Clear();
            lookup.Properties.DataSource = SaleTypeSaleRole();
            lookup.Properties.ValueMember = "cSTCode";
            lookup.Properties.DisplayMember = "cSTName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cSTCode", "销售类型编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cSTName", "销售类型名称")});
        }

        public static DataTable SaleTypeSaleRoleCloseBill()
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();

            string sSQL = "";
            if (系统服务.ClsBaseDataInfo.sUid == "admin")
                sSQL = @"select cSTCode,cSTName from SaleType where 1=1 ";
            else
                sSQL = @"select cSTCode,cSTName from SaleType where 1=1 and cSTCode in (select cSTCode from SaleRoleCloseBill where vchrUid='" + 系统服务.ClsBaseDataInfo.sUid + "')";
            sSQL = sSQL + " order by cSTCode ";
            return clsSQLCommond.ExecQuery(sSQL);
        }

        public static void SaleTypeSaleRoleCloseBill(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = SaleTypeSaleRoleCloseBill();
            lookup.Properties.ValueMember = "cSTCode";
            lookup.Properties.DisplayMember = "cSTName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cSTCode", "销售类型编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cSTName", "销售类型名称")});
        }

        public static void SaleTypeAll(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = clsSQLCommond.ExecQuery("select cSTCode,cSTName from SaleType ");
            lookup.Properties.ValueMember = "cSTCode";
            lookup.Properties.DisplayMember = "cSTName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cSTCode", "销售类型编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cSTName", "销售类型名称")});
        }

        public static void SaleTypeAll(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = clsSQLCommond.ExecQuery("select cSTCode,cSTName from SaleType ");
            lookup.Properties.ValueMember = "cSTCode";
            lookup.Properties.DisplayMember = "cSTName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cSTCode", "销售类型编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cSTName", "销售类型名称")});
        }
        #endregion

        #region 仓库
        /// <summary>
        /// 仓库
        /// </summary>
        /// <returns></returns>
        public static DataTable Warehouse()
        {
            return Warehouse("");
        }
        /// <summary>
        /// 仓库
        /// </summary>
        /// <param name="par">仓库</param>
        /// <returns></returns>
        public static DataTable Warehouse(string par)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = @"select cWhCode,cWhName from Warehouse where 1=1 ";
            if (par != "")
            {
                sSQL = sSQL + " and cWhCode='" + par + "'";
            }
            sSQL = sSQL + " order by cWhCode ";
            return clsSQLCommond.ExecQuery(sSQL);
        }

        public static void Warehouse(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = Warehouse();
            lookup.Properties.ValueMember = "cWhCode";
            lookup.Properties.DisplayMember = "cWhName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cWhCode", "仓库编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cWhName", "仓库名称")});
        }

        public static void Warehouse(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            lookup.Columns.Clear();
            lookup.Properties.DataSource = Warehouse();
            lookup.Properties.ValueMember = "cWhCode";
            lookup.Properties.DisplayMember = "cWhName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cWhCode", "仓库编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cWhName", "仓库名称")});
        }
        #endregion

        #region 系统登录
        /// <summary>
        /// 系统登录
        /// </summary>
        /// <returns></returns>
        public static DataTable _UserInfo()
        {
            return _UserInfo("");
        }
        /// <summary>
        /// 系统登录
        /// </summary>
        /// <param name="par">系统登录名称</param>
        /// <returns></returns>
        public static DataTable _UserInfo(string par)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = @"select vchrUid,vchrName from _UserInfo where 1=1 ";
            if (par != "")
            {
                sSQL = sSQL + " and vchrUid='" + par + "'";
            }
            sSQL = sSQL + " order by vchrUid ";
            return clsSQLCommond.ExecQuery(sSQL);
        }

        public static void _UserInfo(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = _UserInfo();
            lookup.Properties.ValueMember = "vchrUid";
            lookup.Properties.DisplayMember = "vchrName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("vchrUid", "用户编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("vchrName", "用户名称")});
        }

        public static void _UserInfo(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            lookup.Columns.Clear();
            lookup.Properties.DataSource = _UserInfo();
            lookup.Properties.ValueMember = "vchrUid";
            lookup.Properties.DisplayMember = "vchrName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("vchrUid", "用户编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("vchrName", "用户名称")});
        }
        #endregion

        #region 采购类型
        /// <summary>
        /// 采购类型
        /// </summary>
        /// <returns></returns>
        public static DataTable PurchaseType()
        {
            return PurchaseType("");
        }
        /// <summary>
        /// 采购类型
        /// </summary>
        /// <param name="par">采购类型编码</param>
        /// <returns></returns>
        public static DataTable PurchaseType(string par)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = @"select cPTCode,cPTName from PurchaseType where 1=1 ";
            if (par != "")
            {
                sSQL = sSQL + " and cPTCode='" + par + "'";
            }
            sSQL = sSQL + " order by cPTCode ";
            return clsSQLCommond.ExecQuery(sSQL);
        }

        public static void PurchaseType(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = PurchaseType();
            lookup.Properties.ValueMember = "cPTCode";
            lookup.Properties.DisplayMember = "cPTName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cPTCode", "采购类型编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cPTName", "采购类型名称")});
        }

        public static void PurchaseType(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            lookup.Columns.Clear();
            lookup.Properties.DataSource = PurchaseType();
            lookup.Properties.ValueMember = "cPTCode";
            lookup.Properties.DisplayMember = "cPTName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cPTCode", "采购类型编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cPTName", "采购类型名称")});
        }
        #endregion

        #region 行业
        /// <summary>
        /// 存货档案
        /// </summary>
        /// <returns></returns>
        public static DataTable TradeClass()
        {
            return TradeClass("");
        }

        /// <summary>
        /// 行业
        /// </summary>
        /// <param name="par">行业编码</param>
        /// <returns></returns>
        public static DataTable TradeClass(string par)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = @"select cTCode,cTCName from TradeClass where 1=1 ";
            if (par != "")
            {
                sSQL = sSQL + " and cTCode='" + par + "'";
            }
            sSQL = sSQL + " order by cTCode ";
            return clsSQLCommond.ExecQuery(sSQL);
        }

        public static void TradeClass(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = TradeClass();
            lookup.Properties.ValueMember = "cTCode";
            lookup.Properties.DisplayMember = "cTCName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cTCode", "行业编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cTCName", "行业名称")});
        }

        public static void TradeClass(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            lookup.Columns.Clear();
            lookup.Properties.DataSource = TradeClass();
            lookup.Properties.ValueMember = "cTCode";
            lookup.Properties.DisplayMember = "cTCName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cTCode", "行业编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cTCName", "行业名称")});
        }
        #endregion

        #region 收发类别
        /// <summary>
        /// 采购类型
        /// </summary>
        /// <returns></returns>
        public static DataTable RdStyle()
        {
            return RdStyle("");
        }
        /// <summary>
        /// 收发类别
        /// </summary>
        /// <param name="par">收发类别</param>
        /// <returns></returns>
        public static DataTable RdStyle(string par)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = @"select cRSCode,cRSName from RdStyle where 1=1 ";
            if (par != "")
            {
                sSQL = sSQL + " and cRSCode='" + par + "'";
            }
            return clsSQLCommond.ExecQuery(sSQL);
        }

        public static void RdStyle(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = RdStyle();
            lookup.Properties.ValueMember = "cRSCode";
            lookup.Properties.DisplayMember = "cRSName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cRSCode","收发类别编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cRSName", "收发类别名称")});
        }

        public static void RdStyle(DevExpress.XtraEditors.LookUpEdit lookup,int type)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = @"select cRSCode,cRSName from RdStyle where  收发标志=" + type + " and cRSCode<>'01'";
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = clsSQLCommond.ExecQuery(sSQL);
            lookup.Properties.ValueMember = "cRSCode";
            lookup.Properties.DisplayMember = "cRSName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cRSCode","收发类别编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cRSName", "收发类别名称")});
        }


        public static void RdStyle(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            lookup.Columns.Clear();
            lookup.Properties.DataSource = RdStyle();
            lookup.Properties.ValueMember = "cRSCode";
            lookup.Properties.DisplayMember = "cRSName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cRSCode", "收发类别编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cRSName", "收发类别名称")});
        }
        #endregion

        #region 销售

        #region 销售订单
        /// <summary>
        /// 销售订单
        /// </summary>
        /// <returns></returns>
        public static DataTable SO_SOMain()
        {
            return SO_SOMain("");
        }
        /// <summary>
        /// 销售订单
        /// </summary>
        /// <param name="par">销售订单号</param>
        /// <returns></returns>
        public static DataTable SO_SOMain(string par)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = @"select ID,cSOCode from SO_SOMain where 1=1 ";
            if (par != "")
            {
                sSQL = sSQL + " and ID='" + par + "'";
            }
            sSQL = sSQL + " order by ID ";
            return clsSQLCommond.ExecQuery(sSQL);
        }
        public static void SO_SOMain(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = SO_SOMain();
            lookup.Properties.ValueMember = "cSOCode";
            lookup.Properties.DisplayMember = "cSOCode";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cSOCode","销售订单号")});
        }

        public static void SO_SOMainCommission(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = @"select cSOCode from SO_SOMain where isnull(dVerifysysPerson,'') <> '' order by cSOCode";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            lookup.Properties.DataSource = dt;
            lookup.Properties.ValueMember = "cSOCode";
            lookup.Properties.DisplayMember = "cSOCode";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cSOCode","销售订单号")});
        }

        public static void SO_SODetails(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = @"select AutoID,cSOCode from SO_SODetails where 1=1 ";
            sSQL = sSQL + " order by AutoID ";
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = clsSQLCommond.ExecQuery(sSQL);
            lookup.Properties.ValueMember = "AutoID";
            lookup.Properties.DisplayMember = "cSOCode";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AutoID","销售订单AutoID"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cSOCode","销售订单号")});
        }

        #endregion

        #region 销售收款单
        /// <summary>
        /// 销售收款单
        /// </summary>
        /// <returns></returns>
        public static DataTable SO_CloseBill()
        {
            return SO_CloseBill("");
        }
        /// <summary>
        /// 销售收款单
        /// </summary>
        /// <param name="par">销售收款单</param>
        /// <returns></returns>
        public static DataTable SO_CloseBill(string par)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = @"select cSOCCode from SO_CloseBill where 1=1 ";
            if (par != "")
            {
                sSQL = sSQL + " and cSOCCode='" + par + "'";
            }
            sSQL = sSQL + " order by cSOCCode ";
            return clsSQLCommond.ExecQuery(sSQL);
        }
        public static void SO_CloseBill(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = SO_CloseBill();
            lookup.Properties.ValueMember = "cSOCCode";
            lookup.Properties.DisplayMember = "cSOCCode";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cSOCCode","销售收款单号")});
        }

        /// 销售收款单
        /// </summary>
        /// <returns></returns>
        public static DataTable SO_CloseBills()
        {
            return SO_CloseBills("");
        }
        /// <summary>
        /// 销售收款单
        /// </summary>
        /// <param name="par">销售收款单</param>
        /// <returns></returns>
        public static DataTable SO_CloseBills(string par)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = @"select a.AutoID,b.cSOCCode from SO_CloseBillDetails a left join SO_CloseBill b on a.ID=b.ID where 1=1 ";
            if (par != "")
            {
                sSQL = sSQL + " and b.cSOCCode='" + par + "'";
            }
            sSQL = sSQL + " order by b.cSOCCode ";
            return clsSQLCommond.ExecQuery(sSQL);
        }
        public static void SO_CloseBills(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = SO_CloseBills();
            lookup.Properties.ValueMember = "AutoID";
            lookup.Properties.DisplayMember = "cSOCCode";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AutoID","销售收款单AutoID"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cSOCCode","销售收款单号")});
        }

        public static void SO_CloseBills(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = SO_CloseBills();
            lookup.Properties.ValueMember = "AutoID";
            lookup.Properties.DisplayMember = "cSOCCode";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AutoID","销售收款单AutoID"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cSOCCode","销售收款单号")});
        }
        #endregion

        #region 销售发票
        /// <summary>
        /// 销售发票
        /// </summary>
        /// <returns></returns>
        public static DataTable SaleBillVouch()
        {
            return SaleBillVouch("");
        }
        /// <summary>
        /// 销售发票
        /// </summary>
        /// <param name="par">销售发票号</param>
        /// <returns></returns>
        public static DataTable SaleBillVouch(string par)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = @"select ID,cSBVCode from SaleBillVouch where 1=1 ";
            if (par != "")
            {
                sSQL = sSQL + " and ID='" + par + "'";
            }
            sSQL = sSQL + " order by ID ";
            return clsSQLCommond.ExecQuery(sSQL);
        }

        public static void SaleBillVouch(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = SaleBillVouch();
            lookup.Properties.ValueMember = "cSBVCode";
            lookup.Properties.DisplayMember = "cSBVCode";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cSBVCode","销售发票号")});
        }
        #endregion

        #region 销售出库单
        /// <summary>
        /// 销售出库单
        /// </summary>
        /// <returns></returns>
        public static DataTable SO_SOOutMain()
        {
            return SO_SOOutMain("");
        }
        /// <summary>
        /// 销售出库单
        /// </summary>
        /// <param name="par">销售出库单号</param>
        /// <returns></returns>
        public static DataTable SO_SOOutMain(string par)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = @"select ID,cSOOutCode from SO_SOOutMain where 1=1 ";
            if (par != "")
            {
                sSQL = sSQL + " and ID='" + par + "'";
            }
            sSQL = sSQL + " order by ID ";
            return clsSQLCommond.ExecQuery(sSQL);
        }

        public static void SO_SOOutMain(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.DataSource = SO_SOOutMain();
            lookup.Properties.ValueMember = "cSOOutCode";
            lookup.Properties.DisplayMember = "cSOOutCode";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cSOOutCode","销售出库单号")});
        }
        #endregion

        #endregion

        #region 采购

        #region 采购订单
        /// <summary>
        /// 采购订单
        /// </summary>
        /// <returns></returns>
        public static DataTable PO_POMain()
        {
            return PO_POMain("");
        }
        /// <summary>
        /// 采购订单
        /// </summary>
        /// <param name="par">采购订单号</param>
        /// <returns></returns>
        public static DataTable PO_POMain(string par)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = @"select ID,cPOCode from PO_POMain where 1=1 ";
            if (par != "")
            {
                sSQL = sSQL + " and ID='" + par + "'";
            }
            sSQL = sSQL + " order by ID ";
            return clsSQLCommond.ExecQuery(sSQL);
        }

        public static void PO_POMain(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = PO_POMain();
            lookup.Properties.ValueMember = "cPOCode";
            lookup.Properties.DisplayMember = "cPOCode";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cPOCode","采购订单号")});
        }

        public static void PO_POMain(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = PO_POMain();
            lookup.Properties.ValueMember = "cPOCode";
            lookup.Properties.DisplayMember = "cPOCode";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cPOCode","采购订单号")});
        }
        #endregion

        #region 采购付款单
        /// <summary>
        /// 采购付款单
        /// </summary>
        /// <returns></returns>
        public static DataTable PO_CloseBill()
        {
            return PO_CloseBill("");
        }
        /// <summary>
        /// 采购付款单
        /// </summary>
        /// <param name="par"></param>
        /// <returns></returns>
        public static DataTable PO_CloseBill(string par)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = @"select ID,cPOCCode from PO_CloseBill where 1=1 ";
            if (par != "")
            {
                sSQL = sSQL + " and ID='" + par + "'";
            }
            sSQL = sSQL + " order by ID ";
            return clsSQLCommond.ExecQuery(sSQL);
        }
        public static void PO_CloseBill(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = PO_CloseBill();
            lookup.Properties.ValueMember = "cPOCCode";
            lookup.Properties.DisplayMember = "cPOCCode";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cPOCCode","付款单号")});
        }
        #endregion

        #region 采购发票
        /// <summary>
        /// 采购发票
        /// </summary>
        /// <returns></returns>
        public static DataTable PurBillVouch()
        {
            return PurBillVouch("");
        }
        /// <summary>
        /// 采购发票
        /// </summary>
        /// <param name="par"></param>
        /// <returns></returns>
        public static DataTable PurBillVouch(string par)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = @"select ID,cPBVCode from PurBillVouch where 1=1 ";
            if (par != "")
            {
                sSQL = sSQL + " and ID='" + par + "'";
            }
            sSQL = sSQL + " order by ID ";
            return clsSQLCommond.ExecQuery(sSQL);
        }
        public static void PurBillVouch(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = PurBillVouch();
            lookup.Properties.ValueMember = "cPBVCode";
            lookup.Properties.DisplayMember = "cPBVCode";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cPBVCode","发票号")});
        }
        #endregion

        #endregion

        #region 出入库单
        /// <summary>
        /// 出入库单
        /// </summary>
        /// <returns></returns>
        public static DataTable RdRecord(string cRSCode)
        {
            return RdRecord(cRSCode,"");
        }
        /// <summary>
        /// 出入库单
        /// </summary>
        /// <param name="par"></param>
        /// <returns></returns>
        public static DataTable RdRecord(string cRSCode, string par)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = @"select ID,cRdCode from RdRecord where 1=1 and cRSCode=" + cRSCode + "";
            if (par != "")
            {
                sSQL = sSQL + " and ID='" + par + "'";
            }
            sSQL = sSQL + " order by ID ";
            return clsSQLCommond.ExecQuery(sSQL);
        }

        public static void RdRecord(string cRSCode,DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = RdRecord(cRSCode);
            lookup.Properties.ValueMember = "cRdCode";
            lookup.Properties.DisplayMember = "cRdCode";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cRdCode","单据号")});
        }
        #endregion

        #region 调价单
        /// <summary>
        /// 调价单
        /// </summary>
        /// <returns></returns>
        public static DataTable PriceAdjust_Main()
        {
            return PriceAdjust_Main("");
        }
        /// <summary>
        /// 调价单
        /// </summary>
        /// <param name="par"></param>
        /// <returns></returns>
        public static DataTable PriceAdjust_Main(string par)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = @"select ID,iCode from PriceAdjust_Main ";
            if (par != "")
            {
                sSQL = sSQL + " and ID='" + par + "'";
            }
            sSQL = sSQL + " order by ID ";
            return clsSQLCommond.ExecQuery(sSQL);
        }

        public static void PriceAdjust_Main(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = PriceAdjust_Main();
            lookup.Properties.ValueMember = "iCode";
            lookup.Properties.DisplayMember = "iCode";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iCode","单据号")});
        }
        #endregion

        #region 用人申请
        /// <summary>
        /// 用人申请
        /// </summary>
        /// <returns></returns>
        public static DataTable Employer()
        {
            return Employer("");
        }
        /// <summary>
        /// 用人申请
        /// </summary>
        /// <param name="par"></param>
        /// <returns></returns>
        public static DataTable Employer(string par)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = @"select ID,iCode from Employer ";
            if (par != "")
            {
                sSQL = sSQL + " and ID='" + par + "'";
            }
            sSQL = sSQL + " order by ID ";
            return clsSQLCommond.ExecQuery(sSQL);
        }

        public static void Employer(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = Employer();
            lookup.Properties.ValueMember = "iCode";
            lookup.Properties.DisplayMember = "iCode";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iCode","单据号")});
        }
        #endregion

        #region 出差登记
        /// <summary>
        /// 出差登记
        /// </summary>
        /// <returns></returns>
        public static DataTable Travel()
        {
            return Travel("");
        }
        /// <summary>
        /// 佣金申请
        /// </summary>
        /// <param name="par"></param>
        /// <returns></returns>
        public static DataTable Travel(string par)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = @"select ID,iCode from Travel ";
            if (par != "")
            {
                sSQL = sSQL + " and ID='" + par + "'";
            }
            sSQL = sSQL + " order by ID ";
            return clsSQLCommond.ExecQuery(sSQL);
        }

        public static void Travel(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = Travel();
            lookup.Properties.ValueMember = "iCode";
            lookup.Properties.DisplayMember = "iCode";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iCode","单据号")});
        }
        #endregion

        #region 佣金申请
        /// <summary>
        /// 佣金申请
        /// </summary>
        /// <returns></returns>
        public static DataTable Commission()
        {
            return Commission("");
        }
        /// <summary>
        /// 佣金申请
        /// </summary>
        /// <param name="par"></param>
        /// <returns></returns>
        public static DataTable Commission(string par)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = @"select ID,iCode from Commission ";
            if (par != "")
            {
                sSQL = sSQL + " and ID='" + par + "'";
            }
            sSQL = sSQL + " order by ID ";
            return clsSQLCommond.ExecQuery(sSQL);
        }

        public static void Commission(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = Commission();
            lookup.Properties.ValueMember = "iCode";
            lookup.Properties.DisplayMember = "iCode";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iCode","单据号")});
        }
        #endregion

        #region 实验申请
        /// <summary>
        /// 实验申请
        /// </summary>
        /// <returns></returns>
        public static DataTable ExperimentApplications()
        {
            return ExperimentApplications("");
        }
        /// <summary>
        /// 实验申请
        /// </summary>
        /// <param name="par"></param>
        /// <returns></returns>
        public static DataTable ExperimentApplications(string par)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = @"select 申请单编号 from ExperimentApplications ";
            if (par != "")
            {
                sSQL = sSQL + " and ID='" + par + "'";
            }
            sSQL = sSQL + " order by ID ";
            return clsSQLCommond.ExecQuery(sSQL);
        }

        public static void ExperimentApplications(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = ExperimentApplications();
            lookup.Properties.ValueMember = "申请单编号";
            lookup.Properties.DisplayMember = "申请单编号";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("申请单编号","申请单编号")});
        }
        #endregion

        #region 包装方式
        /// <summary>
        /// Packing
        /// </summary>
        /// <returns></returns>
        public static DataTable Packing()
        {
            return Packing("");
        }
        /// <summary>
        /// 包装方式
        /// </summary>
        /// <param name="par"></param>
        /// <returns></returns>
        public static DataTable Packing(string par)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = @"select cPCode,cPName from Packing ";
            if (par != "")
            {
                sSQL = sSQL + " and cPCode='" + par + "'";
            }
            sSQL = sSQL + " order by cPCode ";
            return clsSQLCommond.ExecQuery(sSQL);
        }

        public static void Packing(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = Packing();
            lookup.Properties.ValueMember = "cPCode";
            lookup.Properties.DisplayMember = "cPName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cPCode","包装方式编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cPName","包装方式名称")});
        }

        public static void Packing(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            lookup.Columns.Clear();
            lookup.Properties.DataSource = Packing();
            lookup.Properties.ValueMember = "cPCode";
            lookup.Properties.DisplayMember = "cPName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cPCode","包装方式编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cPName","包装方式名称")});
        }
        #endregion

        #region 合作方式
        /// <summary>
        /// Packing
        /// </summary>
        /// <returns></returns>
        public static DataTable Cooperation()
        {
            return Cooperation("");
        }
        /// <summary>
        /// 合作方式
        /// </summary>
        /// <param name="par"></param>
        /// <returns></returns>
        public static DataTable Cooperation(string par)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = @"select cCCode,cCName from Cooperation ";
            if (par != "")
            {
                sSQL = sSQL + " and cCCode='" + par + "'";
            }
            sSQL = sSQL + " order by cCCode ";
            return clsSQLCommond.ExecQuery(sSQL);
        }

        public static void Cooperation(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = Cooperation();
            lookup.Properties.ValueMember = "cCCode";
            lookup.Properties.DisplayMember = "cCName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCCode","合作方式编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCName","合作方式名称")});
        }

        public static void Cooperation(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            lookup.Columns.Clear();
            lookup.Properties.DataSource = Cooperation();
            lookup.Properties.ValueMember = "cCCode";
            lookup.Properties.DisplayMember = "cCName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCCode","合作方式编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCName","合作方式名称")});
        }
        #endregion

        #region 业务费用
        /// <summary>
        /// 业务费用
        /// </summary>
        /// <returns></returns>
        public static DataTable OperationalCosts()
        {
            return OperationalCosts("");
        }
        /// <summary>
        /// 业务费用
        /// </summary>
        /// <param name="par"></param>
        /// <returns></returns>
        public static DataTable OperationalCosts(string par)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = @"select ID,iCode from OperationalCosts ";
            if (par != "")
            {
                sSQL = sSQL + " and ID='" + par + "'";
            }
            sSQL = sSQL + " order by ID ";
            return clsSQLCommond.ExecQuery(sSQL);
        }

        public static void OperationalCosts(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = OperationalCosts();
            lookup.Properties.ValueMember = "iCode";
            lookup.Properties.DisplayMember = "iCode";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iCode","单据号")});
        }
        #endregion

        #region 发运方式
        /// <summary>
        /// 发运方式
        /// </summary>
        /// <returns></returns>
        public static DataTable ShippingChoice()
        {
            return ShippingChoice("");
        }
        /// <summary>
        /// 发运方式
        /// </summary>
        /// <param name="par"></param>
        /// <returns></returns>
        public static DataTable ShippingChoice(string par)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = @"select cSCCode,cSCName from ShippingChoice ";
            if (par != "")
            {
                sSQL = sSQL + " and cSCCode='" + par + "'";
            }
            sSQL = sSQL + " order by cSCCode ";
            return clsSQLCommond.ExecQuery(sSQL);
        }

        public static void ShippingChoice(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = ShippingChoice();
            lookup.Properties.ValueMember = "cSCCode";
            lookup.Properties.DisplayMember = "cSCName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cSCCode","发运方式编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cSCName", "发运方式名称")});
        }

        public static void ShippingChoice(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = ShippingChoice();
            lookup.Properties.ValueMember = "cSCCode";
            lookup.Properties.DisplayMember = "cSCName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cSCCode","发运方式编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cSCName", "发运方式名称")});
        }
        #endregion

        #region 竞争对手
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DataTable Competitors()
        {
            return Competitors("");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="par"></param>
        /// <returns></returns>
        public static DataTable Competitors(string par)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = @"select iCode,S1 from Competitors ";
            if (par != "")
            {
                sSQL = sSQL + " and iCode='" + par + "'";
            }
            sSQL = sSQL + " order by iCode ";
            return clsSQLCommond.ExecQuery(sSQL);
        }

        public static void Competitors(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = Competitors();
            lookup.Properties.ValueMember = "iCode";
            lookup.Properties.DisplayMember = "S1";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iCode","竞争对手编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("S1", "竞争对手名称")});
        }

        public static void Competitors(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = Competitors();
            lookup.Properties.ValueMember = "iCode";
            lookup.Properties.DisplayMember = "S1";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iCode","竞争对手编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("S1", "竞争对手名称")});
        }
        #endregion

        #region 年
        /// <summary>
        /// 
        /// </summary>
        /// <param name="par"></param>
        /// <returns></returns>
        public static DataTable Year()
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            DataTable dt = new DataTable();
            dt.Columns.Add("年");

            int iyear = DateTime.Now.Year + 2;
            for (int i = 2012; i <= iyear; i++)
            {
                DataRow dw = dt.NewRow();
                dw[0] = i.ToString();
                dt.Rows.Add(dw);
            }
            return dt;
        }

        public static void Year(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = Year();
            lookup.Properties.ValueMember = "年";
            lookup.Properties.DisplayMember = "年";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("年","年")});
            //lookup.EditValue = DateTime.Now.Year.ToString();
        }
        #endregion

        #region 其他入库单
        /// <summary>
        /// 期初
        /// </summary>
        /// <param name="par"></param>
        /// <returns></returns>
        public static DataTable RdAR_First(string cCusCode, string ID, string cSTCode)
        {
            if (cCusCode != "")
            {
                系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
                string sSQL = @"select iID,D1,Date1,S1 from  "
                + " AR_First where  S5='" + cSTCode + "' and D1-isnull((select sum(iMoney) from RdRecord a left join RdRecords b on a.ID=b.ID where a.ARiID=AR_First.iID and 1=1),0) >0";
                if (cCusCode != "")
                {
                    sSQL = sSQL + " and S1='" + cCusCode + "'";
                }
                if (ID != "")
                {
                    sSQL = sSQL.Replace("1=1", " a.ID<>'" + ID + "'");
                }
                sSQL = sSQL + " order by Date1 ";
                return clsSQLCommond.ExecQuery(sSQL);
            }
            else
            {
                return null;
            }
        }

        public static void RdAR_First(DevExpress.XtraEditors.LookUpEdit lookup, string cCusCode, string ID, string cSTCode)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = RdAR_First(cCusCode, ID, cSTCode);
            lookup.Properties.ValueMember = "iID";
            lookup.Properties.DisplayMember = "iID";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iID","序号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("S1","客户编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("D1","期初金额"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Date1","日期")});
        }


        /// <summary>
        /// 销售订单
        /// </summary>
        /// <param name="par"></param>
        /// <returns></returns>
        public static DataTable RdSO_SOMain(string cCusCode, string ID, string cSTCode)
        {
            if (cCusCode != "")
            {
                系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
                string sSQL = @"select AutoID,SO_SODetails.cSOCode,cInvCode,iQuantity,iMoney from  "
                + " SO_SODetails left join So_SoMain on SO_SODetails.ID=So_SoMain.ID where cSTCode='" + cSTCode + "' and SO_SODetails.iMoney-isnull((select sum(iMoney) from RdRecord a left join RdRecords b on a.ID=b.ID where a.ARiID=SO_SODetails.AutoID and 1=1),0) >0";
                if (cCusCode != "")
                {
                    sSQL = sSQL + " and cCusCode='" + cCusCode + "'";
                }
                if (ID != "")
                {
                    sSQL = sSQL.Replace("1=1", " a.ID<>'" + ID + "'");
                }

                sSQL = sSQL + " order by SO_SODetails.cSOCode desc ";

                return clsSQLCommond.ExecQuery(sSQL);
            }
            else
            {
                return null;
            }
        }

        public static void RdSO_SOMain(DevExpress.XtraEditors.LookUpEdit lookup, string cCusCode, string ID, string cSTCode)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = RdSO_SOMain(cCusCode, ID, cSTCode);
            lookup.Properties.ValueMember = "AutoID";
            lookup.Properties.DisplayMember = "cSOCode";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AutoID","序号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cSOCode","销售订单号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCode","存货编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iQuantity","存货数量"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iMoney","金额")});
        }

        #endregion


        #region 销售统计类型
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DataTable SOStatType()
        {
            return SOStatType("");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="par"></param>
        /// <returns></returns>
        public static DataTable SOStatType(string par)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = @"select cSTTCode,cSTTName from SOStatType where 1=1 ";
            if (par != "")
            {
                sSQL = sSQL + " and cSTTCode='" + par + "'";
            }
            sSQL = sSQL + " order by cSTTCode ";
            return clsSQLCommond.ExecQuery(sSQL);
        }

        public static void SOStatType( DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = SOStatType();
            lookup.Properties.ValueMember = "cSTTCode";
            lookup.Properties.DisplayMember = "cSTTName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cSTTCode","销售统计类型编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cSTTName","销售统计类型名称")});
        }

        public static void SOStatType(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = SOStatType();
            lookup.Properties.ValueMember = "cSTTCode";
            lookup.Properties.DisplayMember = "cSTTName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cSTTCode","销售统计类型编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cSTTName","销售统计类型名称")});
        }
        #endregion

        #region 销售退货单
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DataTable SO_SOReturn()
        {
            return SO_SOReturn("");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="par"></param>
        /// <returns></returns>
        public static DataTable SO_SOReturn(string par)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = @"select ID,cReCode from SO_SOReturn where 1=1 ";
            if (par != "")
            {
                sSQL = sSQL + " and cReCode='" + par + "'";
            }
            sSQL = sSQL + " order by cReCode ";
            return clsSQLCommond.ExecQuery(sSQL);
        }
        public static void SO_SOReturn(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = SO_SOReturn();
            lookup.Properties.ValueMember = "cReCode";
            lookup.Properties.DisplayMember = "cReCode";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cReCode","销售退货单号")});
        }

        public static void SO_SOReturn(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = SO_SOReturn();
            lookup.Properties.ValueMember = "cReCode";
            lookup.Properties.DisplayMember = "cReCode";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cReCode","销售退货单号")});
        }
        #endregion

        #region 销售核销单
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DataTable SaleVerification()
        {
            return SaleVerification("");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="par"></param>
        /// <returns></returns>
        public static DataTable SaleVerification(string par)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL = @"select ID,cSVCode from SaleVerification where 1=1 ";
            if (par != "")
            {
                sSQL = sSQL + " and cSVCode='" + par + "'";
            }
            sSQL = sSQL + " order by cSVCode ";
            return clsSQLCommond.ExecQuery(sSQL);
        }
        public static void SaleVerification(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = SaleVerification();
            lookup.Properties.ValueMember = "cSVCode";
            lookup.Properties.DisplayMember = "cSVCode";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cSVCode","核销单号")});
        }

        public static void SaleVerification(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = SaleVerification();
            lookup.Properties.ValueMember = "cSVCode";
            lookup.Properties.DisplayMember = "cSVCode";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cReCode","核销单号")});
        }
        #endregion
    }
}
