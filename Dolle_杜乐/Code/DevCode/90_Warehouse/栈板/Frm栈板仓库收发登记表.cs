using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;


namespace Warehouse
{
    public partial class Frm栈板仓库收发登记表 : FrameBaseFunction.Frm列表窗体模板
    {
        public Frm栈板仓库收发登记表()
        {
            InitializeComponent();
        }



        #region 按钮操作
        protected override void BtnClick(string sBtnName, string sBtnText)
        {
            try
            {
                switch (sBtnName.ToLower())
                {
                    case "addrow":
                        btnAddRow();
                        break;
                    case "add":
                        btnAdd();
                        break;
                    case "alter":
                        btnAlter();
                        break;
                    case "audit":
                        btnAudit();
                        break;
                    case "del":
                        btnDel();
                        break;
                    case "delrow":
                        btnDelRow();
                        break;
                    case "edit":
                        btnEdit();
                        break;
                    case "export":
                        btnExport();
                        break;
                    case "first":
                        btnFirst();
                        break;
                    case "import":
                        btnImport();
                        break;
                    case "last":
                        btnLast();
                        break;
                    case "lock":
                        btnLock();
                        break;
                    case "next":
                        btnNext();
                        break;
                    case "prev":
                        btnPrev();
                        break;
                    //case "printset":
                    //    btnPrintSet();
                    //    break;
                    case "refresh":
                        btnRefresh();
                        break;
                    case "save":
                        btnSave();
                        break;
                    case "sel":
                        btnSel();
                        break;
                    case "unaudit":
                        btnUnAudit();
                        break;
                    case "undo":
                        btnUnDo();
                        break;
                    case "unlock":
                        btnUnLock();
                        break;
                    case "open":
                        btnOpen();
                        break;
                    case "close":
                        btnClose();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ee)
            {
                throw new Exception(sBtnText + " 失败! \n\n原因:\n  " + ee.Message);
            }
        }

        private void btnAdd()
        {

        }


        #region 按钮模板

        /// <summary>
        /// 输出
        /// </summary>
        private void btnExport()
        {
            try
            {
                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "xls";
                sF.FileName = this.Text;
                sF.Filter = "Excel文件(*.xls)|*.xls|所有文件(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK == dRes)
                {
                    gridView1.ExportToXls(sF.FileName);
                    MessageBox.Show("导出Excel成功\n\t路径：" + sF.FileName);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

       
        #endregion

        /// <summary>
        /// 导入
        /// </summary>
        private void btnImport()
        {

        }
        /// <summary>
        /// 刷新
        /// </summary>
        private void btnRefresh()
        {
            GetLookUp();
        }
        /// <summary>
        /// 查询
        /// </summary>
        private void btnSel()
        {
            GetGrid();
        }
        /// <summary>
        /// 首页
        /// </summary>
        private void btnFirst()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 上页
        /// </summary>
        private void btnPrev()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 下页
        /// </summary>
        private void btnNext()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 末页
        /// </summary>
        private void btnLast()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 锁定
        /// </summary>
        private void btnLock()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 解锁
        /// </summary>
        private void btnUnLock()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 增行
        /// </summary>
        private void btnAddRow()
        {
            gridView1.AddNewRow();
        }
        /// <summary>
        /// 删行
        /// </summary>
        private void btnDelRow()
        {
            for (int i = gridView1.RowCount - 1; i >= 0; i--)
            {
                if (gridView1.IsRowSelected(i))
                {
                    gridView1.DeleteRow(i);
                }
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        private void btnEdit()
        {
            SetGridColReadOnly(false);

            string sID = "";
            try
            {
                sID = gridView1.GetRowCellValue(gridView1.RowCount - 1, gridColiID).ToString().Trim();
            }
            catch { }
            if (sID != "")
                gridView1.AddNewRow();
        }
        /// <summary>
        /// 删除
        /// </summary>
        private void btnDel()
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            ArrayList aList = new ArrayList();
            string sErr = "";
            DialogResult d = MessageBox.Show("确定删除选中的行么?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (d == DialogResult.Yes)
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, gridColiID).ToString().Trim() == "")
                        continue;

                    bool b = Convert.ToBoolean(gridView1.GetRowCellValue(i, gridCol选择));
                    if (b)
                    {
                        string siID = gridView1.GetRowCellValue(i, gridColiID).ToString().Trim();

                        string sSQL = "select * from   [UFDLImport].[dbo].[栈板仓库收发登记表] where iID = " + siID;
                        DataTable dt = clsSQLCommond.ExecQuery(sSQL);

                        if (dt == null || dt.Rows.Count == 0)
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "不存在,可能已经删除\n";
                        }
                        else
                        {

                            string s审核人 = dt.Rows[0]["审核人"].ToString().Trim();
                            if (s审核人 == "")
                            {
                                sSQL = "delete  [UFDLImport].[dbo].[栈板仓库收发登记表] where iID = " + siID;
                                aList.Add(sSQL);
                            }
                            else
                            {
                                sErr = sErr + "行" + (i + 1).ToString() + "已经审核不能删除\n";
                            }
                        }
                    }
                }
                if (sErr.Trim() != "")
                {
                    throw new Exception(sErr);
                }

                if (aList.Count > 0)
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("删除成功");

                    GetGrid();
                }
                else
                {
                    MessageBox.Show("请选择需要删除的单据");
                }
            }
        }


        /// <summary>
        /// 保存
        /// </summary>
        private void btnSave()
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            DAL栈板仓库收发登记表 DAL = new DAL栈板仓库收发登记表();

            DataView dv = ((DataView)gridView1.DataSource);
            DataTable dtGrid = dv.ToTable();
            ArrayList aList = new ArrayList();

            string sErr = "";
            for (int i = 0; i < dtGrid.Rows.Count; i++)
            {
                bool b = false;
                try
                {
                    b = Convert.ToBoolean(dtGrid.Rows[i]["选择"]);
                }
                catch { }

                if (!b)
                    continue;

                Model栈板仓库收发登记表 model = new Model栈板仓库收发登记表();
                model = DAL.DataRowToModel(dtGrid.Rows[i]);

                model.制单人 = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                model.制单日期 = Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate);

                if (model.iID == 0 && model.单据类型 == "")
                {
                    continue;
                }

                

                if (model.单据类型 == "")
                {
                    sErr = sErr + "行" + (i + 1).ToString() + "单据类型不能为空\n";
                }

                string sSQL = "select * from   [UFDLImport].[dbo].[栈板仓库收发登记表] where iID = " + model.iID;
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["审核人"].ToString().Trim() != "")
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "已经审核\n";
                        continue;
                    }
                }

                if (model.iID == 0)
                {
                    sSQL = DAL.Add(model);
                    aList.Add(sSQL);
                }
                else
                {
                    sSQL = DAL.Update(model);
                    aList.Add(sSQL);
                }
            }

            if (sErr.Trim() != "")
            {
                throw new Exception(sErr);
            }

            if (aList.Count > 0)
            {
                clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("保存成功");
                GetGrid();
            }
        }
        /// <summary>
        /// 撤销
        /// </summary>
        private void btnUnDo()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 审核
        /// </summary>
        private void btnAudit()
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            ArrayList aList = new ArrayList();
            string sErr = "";

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridColiID).ToString().Trim() == "")
                    continue;

                bool b = Convert.ToBoolean(gridView1.GetRowCellValue(i, gridCol选择));
                if (b)
                {
                    string siID = gridView1.GetRowCellValue(i, gridColiID).ToString().Trim();

                    string sSQL = "select * from   [UFDLImport].[dbo].[栈板仓库收发登记表] where iID = " + siID;
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);

                    if (dt == null || dt.Rows.Count == 0)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "不存在,可能已经删除\n";
                    }
                    else
                    {

                        string s审核人 = dt.Rows[0]["审核人"].ToString().Trim();
                        if (s审核人 == "")
                        {
                            sSQL = "update  [UFDLImport].[dbo].[栈板仓库收发登记表] set 审核人 = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "' , 审核日期 = getdate() where iID = " + siID;
                            aList.Add(sSQL);
                        }
                        else
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "已经审核\n";
                        }
                    }
                }
            }
            if (sErr.Trim() != "")
            {
                throw new Exception(sErr);
            }

            if (aList.Count > 0)
            {
                clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("审核成功");

                GetGrid();
            }
            else
            {
                MessageBox.Show("请选择需要审核的单据");
            }
        }
        /// <summary>
        /// 弃审
        /// </summary>
        private void btnUnAudit()
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            ArrayList aList = new ArrayList();
            string sErr = "";

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridColiID).ToString().Trim() == "")
                    continue;

                bool b = Convert.ToBoolean(gridView1.GetRowCellValue(i, gridCol选择));
                if (b)
                {
                    string siID = gridView1.GetRowCellValue(i, gridColiID).ToString().Trim();

                    string sSQL = "select * from   [UFDLImport].[dbo].[栈板仓库收发登记表] where iID = " + siID;
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);

                    if (dt == null || dt.Rows.Count == 0)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "不存在,可能已经删除\n";
                    }
                    else
                    {

                        string s审核人 = dt.Rows[0]["审核人"].ToString().Trim();
                        if (s审核人 != "")
                        {
                            sSQL = "update  [UFDLImport].[dbo].[栈板仓库收发登记表] set 审核人 = null , 审核日期 = null where iID = " + siID;
                            aList.Add(sSQL);
                        }
                        else
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "未审核\n";
                        }
                    }
                }
            }
            if (sErr.Trim() != "")
            {
                throw new Exception(sErr);
            }

            if (aList.Count > 0)
            {
                clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("弃审成功");

                GetGrid();
            }
            else
            {
                MessageBox.Show("请选择需要弃审的单据");
            }
        }
        /// <summary>
        /// 打开
        /// </summary>
        private void btnOpen()
        {
           
        }
        /// <summary>
        /// 关闭
        /// </summary>
        private void btnClose()
        {
           
        }
        /// <summary>
        /// 变更
        /// </summary>
        private void btnAlter()
        {
            throw new NotImplementedException();
        }

        #endregion

        private void Frm栈板厂商收发登记表_Load(object sender, EventArgs e)
        {
            try
            {
                dateEdit1.DateTime = ReturnObjectToDatetime(FrameBaseFunction.ClsBaseDataInfo.sLogDate).AddMonths(-1);
                dateEdit2.DateTime = ReturnObjectToDatetime(FrameBaseFunction.ClsBaseDataInfo.sLogDate);

                GetLookUp();
                GetGrid();

                dateEdit1.Enabled = true;
                dateEdit1.Properties.ReadOnly = false;
                dateEdit2.Enabled = true;
                dateEdit2.Properties.ReadOnly = false;
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            }
        }

        private void GetGrid()
        {
            string sSQL = "select * from UFDLImport.dbo._Code where vchrType = '1' order by vchrInfo";
            DataTable dt栈板 = clsSQLCommond.ExecQuery(sSQL);
            for (int i = 0; i < gridView1.Columns.Count; i++)
            {
                string sCol = gridView1.Columns[i].FieldName;
                if (sCol.Length > 2 && sCol.Substring(0, 2) == "栈板")
                {
                    DataRow[] dr = dt栈板.Select("vchrInfo = '" + sCol.Trim() + "'");
                    if (dr.Length > 0)
                    {
                        gridView1.Columns[i].Visible = true;
                        gridView1.Columns[i].Caption = dr[0]["vchrRemark"].ToString().Trim();
                    }
                    else
                    {
                        gridView1.Columns[i].Visible = false;
                    }
                }
            }

            int iRow = gridView1.FocusedRowHandle;

            sSQL = @"
select cast(0 as bit) as 选择
      ,a.iID, a.单据类型, a.单据号, a.栈板1, a.栈板2, a.栈板3, a.栈板4, a.栈板5, a.栈板6, a.栈板7, a.栈板8, a.栈板9, a.栈板10, a.日期, a.备注, a.制单人, a.制单日期, a.审核人, a.审核日期
      ,c.vchrInfo as 收发
from [UFDLImport].[dbo].[栈板仓库收发登记表] a left join [UFDLImport].._Code b on b.vchrInfo = a.[单据类型] and b.vchrType = '4'
    left join  [UFDLImport].._Code c on c.iOrder = b.iOrder and c.vchrType = '3'
where [日期] >= '111111' and [日期] < = '222222'
order by a.iID;
";
            sSQL = sSQL.Replace("111111", dateEdit1.DateTime.ToString("yyyy-MM-dd"));
            sSQL = sSQL.Replace("222222", dateEdit2.DateTime.ToString("yyyy-MM-dd"));
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dt;
            gridView1.AddNewRow();

            SetGridColReadOnly(false);
            gridView1.FocusedRowHandle = iRow;

            chk全选.Checked = false;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column != gridCol选择)
                {
                    gridView1.SetRowCellValue(e.RowHandle, gridCol选择, true);

                    int iRow = e.RowHandle;

                    if (iRow == gridView1.RowCount - 1)
                    {
                        gridView1.AddNewRow();
                        gridView1.FocusedRowHandle = iRow;
                    }

                    if (gridView1.GetRowCellValue(e.RowHandle, gridCol日期).ToString().Trim() == "")
                    {
                        gridView1.SetRowCellValue(e.RowHandle, gridCol日期, FrameBaseFunction.ClsBaseDataInfo.sLogDate);
                    }
                }

                if (e.Column == gridCol单据类型)
                {
                    string s单据类型 = gridView1.GetRowCellValue(e.RowHandle, gridCol单据类型).ToString().Trim();
                    string sSQL = @"
select b.vchrInfo 
from UFDLImport.dbo._Code a
	inner join UFDLImport.dbo._Code b on a.iOrder = b.iOrder and a.vchrType = '4' and b.vchrType = '3'
where a.vchrInfo = '111111'
";
                    sSQL = sSQL.Replace("111111", s单据类型);
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        gridView1.SetRowCellValue(e.RowHandle, gridCol收发, dt.Rows[0][0]);
                    }

                }
            }
            catch (Exception ee)
            {
                MsgBox("提示", ee.Message);
            }
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            if (e.Info.IsRowIndicator)
            {
                if (e.RowHandle >= 0)
                {
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
                }
                else if (e.RowHandle < 0 && e.RowHandle > -1000)
                {
                    e.Info.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
                    e.Info.DisplayText = "G" + e.RowHandle.ToString();
                }
            }
        }

        private void GetLookUp()
        {
            string sSQL = "select vchrInfo as 单据类型 from UFDLImport.dbo._Code where vchrType = '4' order by vchrRemark";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit单据类型.DataSource = dt;

            sSQL = "select iOrder as 编码,vchrInfo as 类型 from UFDLImport.._Code where vchrType = '3' order by iOrder";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit收发.DataSource = dt;
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                string s审核人 = gridView1.GetRowCellValue(e.FocusedRowHandle, gridCol审核人).ToString().Trim();
                if (s审核人 == "")
                    SetGridColReadOnly(false);
                else
                    SetGridColReadOnly(true);
            }
            catch { }
        }

        private void SetGridColReadOnly(bool b)
        {
            gridCol单据类型.OptionsColumn.ReadOnly = b;
            gridCol日期.OptionsColumn.ReadOnly = b;
            gridCol栈板1.OptionsColumn.ReadOnly = b;
            gridCol栈板2.OptionsColumn.ReadOnly = b;
            gridCol栈板3.OptionsColumn.ReadOnly = b;
            gridCol栈板4.OptionsColumn.ReadOnly = b;
            gridCol栈板5.OptionsColumn.ReadOnly = b;
            gridCol栈板6.OptionsColumn.ReadOnly = b;
            gridCol栈板7.OptionsColumn.ReadOnly = b;
            gridCol栈板8.OptionsColumn.ReadOnly = b;
            gridCol栈板9.OptionsColumn.ReadOnly = b;
            gridCol栈板10.OptionsColumn.ReadOnly = b;
            gridCol选择.OptionsColumn.ReadOnly = false;
        }

        private void chk全选_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    string siID = gridView1.GetRowCellValue(i, gridColiID).ToString().Trim();
                    if (siID == "")
                        continue;

                    gridView1.SetRowCellValue(i, gridCol选择, chk全选.Checked);
                }
            }
            catch { }
        }

        private DataTable GetVendor(string sVenCode)
        {
            try
            {
                string sSQL = "select cVenCode as iID,cVenName as iText from @u8.Vendor where cVenCode = '" + sVenCode + "' order by cVenCode";
                DataTable dt = clsGetSQL.GetLookUpEdit(sSQL);
                return dt;
            }
            catch
            {
                throw new Exception("获得供应商信息失败！");
            }
        }
    }



    /// <summary>
    /// 栈板仓库收发登记表:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Model栈板仓库收发登记表
    {
        public Model栈板仓库收发登记表()
        { }
        #region Model
        private int _iid;
        private string _单据类型;
        private string _单据号;
        private int? _栈板1;
        private int? _栈板2;
        private int? _栈板3;
        private int? _栈板4;
        private int? _栈板5;
        private int? _栈板6;
        private int? _栈板7;
        private int? _栈板8;
        private int? _栈板9;
        private int? _栈板10;
        private DateTime? _日期;
        private string _备注;
        private string _制单人;
        private DateTime? _制单日期;
        private string _审核人;
        private DateTime? _审核日期;
        /// <summary>
        /// 
        /// </summary>
        public int iID
        {
            set { _iid = value; }
            get { return _iid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 单据类型
        {
            set { _单据类型 = value; }
            get { return _单据类型; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 单据号
        {
            set { _单据号 = value; }
            get { return _单据号; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? 栈板1
        {
            set { _栈板1 = value; }
            get { return _栈板1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? 栈板2
        {
            set { _栈板2 = value; }
            get { return _栈板2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? 栈板3
        {
            set { _栈板3 = value; }
            get { return _栈板3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? 栈板4
        {
            set { _栈板4 = value; }
            get { return _栈板4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? 栈板5
        {
            set { _栈板5 = value; }
            get { return _栈板5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? 栈板6
        {
            set { _栈板6 = value; }
            get { return _栈板6; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? 栈板7
        {
            set { _栈板7 = value; }
            get { return _栈板7; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? 栈板8
        {
            set { _栈板8 = value; }
            get { return _栈板8; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? 栈板9
        {
            set { _栈板9 = value; }
            get { return _栈板9; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? 栈板10
        {
            set { _栈板10 = value; }
            get { return _栈板10; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? 日期
        {
            set { _日期 = value; }
            get { return _日期; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 备注
        {
            set { _备注 = value; }
            get { return _备注; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 制单人
        {
            set { _制单人 = value; }
            get { return _制单人; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? 制单日期
        {
            set { _制单日期 = value; }
            get { return _制单日期; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 审核人
        {
            set { _审核人 = value; }
            get { return _审核人; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? 审核日期
        {
            set { _审核日期 = value; }
            get { return _审核日期; }
        }
        #endregion Model

    }



    /// <summary>
    /// 数据访问类:栈板仓库收发登记表
    /// </summary>
    public partial class DAL栈板仓库收发登记表
    {
        public DAL栈板仓库收发登记表()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public string Exists(int iID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from UFDLImport..栈板仓库收发登记表");
            strSql.Append(" where iID=" + iID + " ");
            return (strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(Model栈板仓库收发登记表 model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.单据类型 != null)
            {
                strSql1.Append("单据类型,");
                strSql2.Append("'" + model.单据类型 + "',");
            }
            if (model.单据号 != null)
            {
                strSql1.Append("单据号,");
                strSql2.Append("'" + model.单据号 + "',");
            }
            if (model.栈板1 != null)
            {
                strSql1.Append("栈板1,");
                strSql2.Append("" + model.栈板1 + ",");
            }
            if (model.栈板2 != null)
            {
                strSql1.Append("栈板2,");
                strSql2.Append("" + model.栈板2 + ",");
            }
            if (model.栈板3 != null)
            {
                strSql1.Append("栈板3,");
                strSql2.Append("" + model.栈板3 + ",");
            }
            if (model.栈板4 != null)
            {
                strSql1.Append("栈板4,");
                strSql2.Append("" + model.栈板4 + ",");
            }
            if (model.栈板5 != null)
            {
                strSql1.Append("栈板5,");
                strSql2.Append("" + model.栈板5 + ",");
            }
            if (model.栈板6 != null)
            {
                strSql1.Append("栈板6,");
                strSql2.Append("" + model.栈板6 + ",");
            }
            if (model.栈板7 != null)
            {
                strSql1.Append("栈板7,");
                strSql2.Append("" + model.栈板7 + ",");
            }
            if (model.栈板8 != null)
            {
                strSql1.Append("栈板8,");
                strSql2.Append("" + model.栈板8 + ",");
            }
            if (model.栈板9 != null)
            {
                strSql1.Append("栈板9,");
                strSql2.Append("" + model.栈板9 + ",");
            }
            if (model.栈板10 != null)
            {
                strSql1.Append("栈板10,");
                strSql2.Append("" + model.栈板10 + ",");
            }
            if (model.日期 != null)
            {
                strSql1.Append("日期,");
                strSql2.Append("'" + model.日期 + "',");
            }
            if (model.备注 != null)
            {
                strSql1.Append("备注,");
                strSql2.Append("'" + model.备注 + "',");
            }
            if (model.制单人 != null)
            {
                strSql1.Append("制单人,");
                strSql2.Append("'" + model.制单人 + "',");
            }
            if (model.制单日期 != null)
            {
                strSql1.Append("制单日期,");
                strSql2.Append("'" + model.制单日期 + "',");
            }
            if (model.审核人 != null)
            {
                strSql1.Append("审核人,");
                strSql2.Append("'" + model.审核人 + "',");
            }
            if (model.审核日期 != null)
            {
                strSql1.Append("审核日期,");
                strSql2.Append("'" + model.审核日期 + "',");
            }
            strSql.Append("insert into UFDLImport..栈板仓库收发登记表(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            return strSql.ToString();
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string Update(Model栈板仓库收发登记表 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update UFDLImport..栈板仓库收发登记表 set ");
            if (model.单据类型 != null)
            {
                strSql.Append("单据类型='" + model.单据类型 + "',");
            }
            else
            {
                strSql.Append("单据类型= null ,");
            }
            if (model.单据号 != null)
            {
                strSql.Append("单据号='" + model.单据号 + "',");
            }
            else
            {
                strSql.Append("单据号= null ,");
            }
            if (model.栈板1 != null)
            {
                strSql.Append("栈板1=" + model.栈板1 + ",");
            }
            else
            {
                strSql.Append("栈板1= null ,");
            }
            if (model.栈板2 != null)
            {
                strSql.Append("栈板2=" + model.栈板2 + ",");
            }
            else
            {
                strSql.Append("栈板2= null ,");
            }
            if (model.栈板3 != null)
            {
                strSql.Append("栈板3=" + model.栈板3 + ",");
            }
            else
            {
                strSql.Append("栈板3= null ,");
            }
            if (model.栈板4 != null)
            {
                strSql.Append("栈板4=" + model.栈板4 + ",");
            }
            else
            {
                strSql.Append("栈板4= null ,");
            }
            if (model.栈板5 != null)
            {
                strSql.Append("栈板5=" + model.栈板5 + ",");
            }
            else
            {
                strSql.Append("栈板5= null ,");
            }
            if (model.栈板6 != null)
            {
                strSql.Append("栈板6=" + model.栈板6 + ",");
            }
            else
            {
                strSql.Append("栈板6= null ,");
            }
            if (model.栈板7 != null)
            {
                strSql.Append("栈板7=" + model.栈板7 + ",");
            }
            else
            {
                strSql.Append("栈板7= null ,");
            }
            if (model.栈板8 != null)
            {
                strSql.Append("栈板8=" + model.栈板8 + ",");
            }
            else
            {
                strSql.Append("栈板8= null ,");
            }
            if (model.栈板9 != null)
            {
                strSql.Append("栈板9=" + model.栈板9 + ",");
            }
            else
            {
                strSql.Append("栈板9= null ,");
            }
            if (model.栈板10 != null)
            {
                strSql.Append("栈板10=" + model.栈板10 + ",");
            }
            else
            {
                strSql.Append("栈板10= null ,");
            }
            if (model.日期 != null)
            {
                strSql.Append("日期='" + model.日期 + "',");
            }
            else
            {
                strSql.Append("日期= null ,");
            }
            if (model.备注 != null)
            {
                strSql.Append("备注='" + model.备注 + "',");
            }
            else
            {
                strSql.Append("备注= null ,");
            }
            if (model.制单人 != null)
            {
                strSql.Append("制单人='" + model.制单人 + "',");
            }
            else
            {
                strSql.Append("制单人= null ,");
            }
            if (model.制单日期 != null)
            {
                strSql.Append("制单日期='" + model.制单日期 + "',");
            }
            else
            {
                strSql.Append("制单日期= null ,");
            }
            if (model.审核人 != null)
            {
                strSql.Append("审核人='" + model.审核人 + "',");
            }
            else
            {
                strSql.Append("审核人= null ,");
            }
            if (model.审核日期 != null)
            {
                strSql.Append("审核日期='" + model.审核日期 + "',");
            }
            else
            {
                strSql.Append("审核日期= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where iID=" + model.iID + "");
            return strSql.ToString();
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model栈板仓库收发登记表 DataRowToModel(DataRow row)
        {
            Model栈板仓库收发登记表 model = new Model栈板仓库收发登记表();
            if (row != null)
            {
                if (row["iID"] != null && row["iID"].ToString() != "")
                {
                    model.iID = int.Parse(row["iID"].ToString());
                }
                if (row["单据类型"] != null)
                {
                    model.单据类型 = row["单据类型"].ToString();
                }
                if (row["单据号"] != null)
                {
                    model.单据号 = row["单据号"].ToString();
                }
                if (row["栈板1"] != null && row["栈板1"].ToString() != "")
                {
                    model.栈板1 = int.Parse(row["栈板1"].ToString());
                }
                if (row["栈板2"] != null && row["栈板2"].ToString() != "")
                {
                    model.栈板2 = int.Parse(row["栈板2"].ToString());
                }
                if (row["栈板3"] != null && row["栈板3"].ToString() != "")
                {
                    model.栈板3 = int.Parse(row["栈板3"].ToString());
                }
                if (row["栈板4"] != null && row["栈板4"].ToString() != "")
                {
                    model.栈板4 = int.Parse(row["栈板4"].ToString());
                }
                if (row["栈板5"] != null && row["栈板5"].ToString() != "")
                {
                    model.栈板5 = int.Parse(row["栈板5"].ToString());
                }
                if (row["栈板6"] != null && row["栈板6"].ToString() != "")
                {
                    model.栈板6 = int.Parse(row["栈板6"].ToString());
                }
                if (row["栈板7"] != null && row["栈板7"].ToString() != "")
                {
                    model.栈板7 = int.Parse(row["栈板7"].ToString());
                }
                if (row["栈板8"] != null && row["栈板8"].ToString() != "")
                {
                    model.栈板8 = int.Parse(row["栈板8"].ToString());
                }
                if (row["栈板9"] != null && row["栈板9"].ToString() != "")
                {
                    model.栈板9 = int.Parse(row["栈板9"].ToString());
                }
                if (row["栈板10"] != null && row["栈板10"].ToString() != "")
                {
                    model.栈板10 = int.Parse(row["栈板10"].ToString());
                }
                if (row["日期"] != null && row["日期"].ToString() != "")
                {
                    model.日期 = DateTime.Parse(row["日期"].ToString());
                }
                if (row["备注"] != null)
                {
                    model.备注 = row["备注"].ToString();
                }
                if (row["制单人"] != null)
                {
                    model.制单人 = row["制单人"].ToString();
                }
                if (row["制单日期"] != null && row["制单日期"].ToString() != "")
                {
                    model.制单日期 = DateTime.Parse(row["制单日期"].ToString());
                }
                if (row["审核人"] != null)
                {
                    model.审核人 = row["审核人"].ToString();
                }
                if (row["审核日期"] != null && row["审核日期"].ToString() != "")
                {
                    model.审核日期 = DateTime.Parse(row["审核日期"].ToString());
                }
            }
            return model;
        }

        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

