using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace 系统服务
{
    public class LookUp
    {
        protected ClsUseWebService clsWeb = new ClsUseWebService();
        #region LoopUpData
        public  void LoopUpData(DevExpress.XtraEditors.LookUpEdit lookup, string id)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = clsWeb.LookUpLoopUpData(id);
            lookup.Properties.ValueMember = "iID";
            lookup.Properties.DisplayMember = "iText";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iID", "类型编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iText", "类型名称")});
        }

        public void LoopUpData(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup, string id)
        {
            lookup.Columns.Clear();
            lookup.Properties.DataSource = clsWeb.LookUpLoopUpData(id);
            lookup.Properties.ValueMember = "iID";
            lookup.Properties.DisplayMember = "iText";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iID", "类型编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iText", "类型名称")});
        }
        #endregion

        #region 部门档案
        public void Department(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = clsWeb.LookUpDepartment();
            lookup.Properties.ValueMember = "cDepCode";
            lookup.Properties.DisplayMember = "cDepName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepCode", "部门编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepName", "部门名称")});
        }
        public void Department(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            lookup.Columns.Clear();
            lookup.Properties.DataSource = clsWeb.LookUpDepartment();
            lookup.Properties.ValueMember = "cDepCode";
            lookup.Properties.DisplayMember = "cDepName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepCode", "部门编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDepName", "部门名称")});
        }
        #endregion

        #region 计量档案
        public void ComputationUnit(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = clsWeb.LookUpComputationUnit();
            lookup.Properties.ValueMember = "cComunitCode";
            lookup.Properties.DisplayMember = "cComunitName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cComunitCode", "主计量编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cComunitName", "主计量名称")});
        }
        public void ComputationUnit(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            lookup.Columns.Clear();
            lookup.Properties.DataSource = clsWeb.LookUpComputationUnit();
            lookup.Properties.ValueMember = "cComunitCode";
            lookup.Properties.DisplayMember = "cComunitName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cComunitCode", "主计量编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cComunitName", "主计量名称")});
        }
        #endregion

        #region 存货档案
        public void Inventory(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = clsWeb.LookUpInventory();
            lookup.Properties.ValueMember = "cInvCode";
            lookup.Properties.DisplayMember = "cInvName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCode", "存货编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvName", "存货名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvStd", "规格型号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cComunitCode", "计量单位编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cComunitName", "计量单位名称")});
        }

        public void Inventory(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            lookup.Columns.Clear();
            lookup.Properties.DataSource = clsWeb.LookUpInventory();
            lookup.Properties.ValueMember = "cInvCode";
            lookup.Properties.DisplayMember = "cInvName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCode", "存货编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvName", "存货名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvStd", "规格型号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cComunitCode", "计量单位编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cComunitName", "计量单位名称")});
        }
        #endregion

        #region 人员档案
        public void Person(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = clsWeb.LookUpPerson();
            lookup.Properties.ValueMember = "PersonCode";
            lookup.Properties.DisplayMember = "PersonName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PersonCode", "人员编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PersonName", "人员名称")});
        }

        public void Person(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            lookup.Columns.Clear();
            lookup.Properties.DataSource = clsWeb.LookUpPerson();
            lookup.Properties.ValueMember = "PersonCode";
            lookup.Properties.DisplayMember = "PersonName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PersonCode", "人员编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PersonName", "人员名称")});
        }
        #endregion

        #region 用户
        public void UserInfo(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = clsWeb.LookUpUserInfo();
            lookup.Properties.ValueMember = "vchrUid";
            lookup.Properties.DisplayMember = "vchrName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("vchrUid", "用户编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("vchrName", "用户名称")});
        }

        public void UserInfo(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            lookup.Columns.Clear();
            lookup.Properties.DataSource = clsWeb.LookUpUserInfo();
            lookup.Properties.ValueMember = "vchrUid";
            lookup.Properties.DisplayMember = "vchrName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("vchrUid", "用户编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("vchrName", "用户名称")});
        }
        #endregion

        #region 地区分类
        public void DistrictClass(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = clsWeb.LookUpDistrictClass();
            lookup.Properties.ValueMember = "cDCCode";
            lookup.Properties.DisplayMember = "cDCName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDCCode", "地区分类编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDCName", "地区分类名称")});
        }
        public void DistrictClass(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            lookup.Columns.Clear();
            lookup.Properties.DataSource = clsWeb.LookUpDistrictClass();
            lookup.Properties.ValueMember = "cDCCode";
            lookup.Properties.DisplayMember = "cDCName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDCCode", "地区分类编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cDCName", "地区分类名称")});
        }
        #endregion

        #region 工程性质档案
        public void Engineering(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = clsWeb.LookUpEngineering();
            lookup.Properties.ValueMember = "cECode";
            lookup.Properties.DisplayMember = "cEName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cECode", "工程性质档案编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cEName", "工程性质档案名称")});
        }
        public void Engineering(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            lookup.Columns.Clear();
            lookup.Properties.DataSource = clsWeb.LookUpEngineering();
            lookup.Properties.ValueMember = "cECode";
            lookup.Properties.DisplayMember = "cEName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cECode", "工程性质档案编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cEName", "工程性质档案名称")});
        }
        #endregion

        #region 安全标准档案
        public void Security(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = clsWeb.LookUpSecurity();
            lookup.Properties.ValueMember = "cSCode";
            lookup.Properties.DisplayMember = "cSName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cSCode", "安全标准档案编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cSName", "安全标准档案名称")});
        }
        public void Security(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            lookup.Columns.Clear();
            lookup.Properties.DataSource = clsWeb.LookUpSecurity();
            lookup.Properties.ValueMember = "cSCode";
            lookup.Properties.DisplayMember = "cSName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cSCode", "安全标准档案编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cSName", "安全标准档案名称")});
        }
        #endregion

        #region 质量标准档案
        public void Quality(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = clsWeb.LookUpQuality();
            lookup.Properties.ValueMember = "cQCode";
            lookup.Properties.DisplayMember = "cQName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cQCode", "质量标准档案编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cQName", "质量标准档案名称")});
        }
        public void Quality(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            lookup.Columns.Clear();
            lookup.Properties.DataSource = clsWeb.LookUpQuality();
            lookup.Properties.ValueMember = "cQCode";
            lookup.Properties.DisplayMember = "cQName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cQCode", "质量标准档案编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cQName", "质量标准档案名称")});
        }

        public void Quality(DevExpress.XtraEditors.CheckedListBoxControl chk)
        {
            DataTable dt = clsWeb.LookUpQuality();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                chk.Items.Add(dt.Rows[i]["cQCode"].ToString(), dt.Rows[i]["cQName"].ToString());
            }
        }
        #endregion

        #region 出入库单
        public void RdRecord(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = clsWeb.LookUpRdRecord();
            lookup.Properties.ValueMember = "cRdCode";
            lookup.Properties.DisplayMember = "cRdCode";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cRdCode","单据号")});
        }

        public void RdRecord(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            lookup.Columns.Clear();
            lookup.Properties.DataSource = clsWeb.LookUpRdRecord();
            lookup.Properties.ValueMember = "cRdCode";
            lookup.Properties.DisplayMember = "cRdCode";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cRdCode", "单据号")});
        }
        #endregion

        #region 月份
        public void Month(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("月份");
            for (int i = 1; i <= 12; i++)
            {
                DataRow dw = dt.NewRow();
                if (i < 10)
                {
                    dw[0] = "0" + i;
                }
                else
                {
                    dw[0] = i;
                }
                dt.Rows.Add(dw);
            }
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = dt;
            lookup.Properties.ValueMember = "月份";
            lookup.Properties.DisplayMember = "月份";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("月份","月份")});
        }

        public void Month(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("月份");
            for (int i = 1; i <= 12; i++)
            {
                DataRow dw = dt.NewRow();
                if (i < 10)
                {
                    dw[0] = "0" + i;
                }
                else
                {
                    dw[0] = i;
                }
                dt.Rows.Add(dw);
            }
            lookup.Columns.Clear();
            lookup.Properties.DataSource = dt;
            lookup.Properties.ValueMember = "月份";
            lookup.Properties.DisplayMember = "月份";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("月份", "月份")});
        }
        #endregion

        #region 项目
        public void Project(DevExpress.XtraEditors.LookUpEdit lookup)
        {
            lookup.Properties.Columns.Clear();
            lookup.Properties.DataSource = clsWeb.LookUpProject();
            lookup.Properties.ValueMember = "cCode";
            lookup.Properties.DisplayMember = "cName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCode","项目编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cName","项目名称")});
        }

        public void Project(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookup)
        {
            lookup.Columns.Clear();
            lookup.Properties.DataSource = clsWeb.LookUpProject();
            lookup.Properties.ValueMember = "cCode";
            lookup.Properties.DisplayMember = "cName";
            lookup.Properties.NullText = "";
            lookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCode","项目编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cName","项目名称")});
        }
        #endregion

    }
}
	