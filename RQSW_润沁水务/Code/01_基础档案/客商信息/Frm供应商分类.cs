using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraEditors;

namespace 基础设置
{
    public partial class Frm供应商分类 : 系统服务.FrmBaseInfo
    {
        string tablename = "VendorClass";
        string tableid = "cVCCode";
        public Frm供应商分类()
        {
            InitializeComponent();

            sLayoutHeadPath = base.sProPath + "\\layout\\" + this.Text.Trim() + "Head.xml";
            sLayoutGridPath = base.sProPath + "\\layout\\" + this.Text.Trim() + "Grid.xml";

            if (File.Exists(sLayoutHeadPath))
                layoutControl1.RestoreLayoutFromXml(sLayoutHeadPath);

            if (File.Exists(sLayoutGridPath))
            {
                //gridControl1.MainView.RestoreLayoutFromXml(sLayoutGridPath);
            }

            dtBingGrid = new DataTable();
            dtBingHead = new DataTable();
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
                    case "add":
                        btnAdd();
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
                    case "print":
                        btnPrint();
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
                    case "layout":
                        btnLayout(sBtnText);
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


        #region 按钮模板

        /// <summary>
        /// 将表格中Lookup之类的保存ID的数据转换成Text用于打印
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private DataTable SetPrintData(DataTable dt)
        {
            
            return null;
        }

        /// <summary>
        /// 打印
        /// </summary>
        private void btnPrint()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 输出
        /// </summary>
        private void btnExport()
        {
            throw new NotImplementedException();
        }

        private void btnLayout(string sText)
        {
            if (layoutControl1 == null) return;
            if (sText == "布局")
            {
                //layoutControl1.ShowCustomizationForm();
                layoutControl1.AllowCustomizationMenu = true;
                base.toolStripMenuBtn.Items["Layout"].Text = "保存布局";
            }
            else
            {
                //layoutControl1.HideCustomizationForm();
                layoutControl1.AllowCustomizationMenu = false;

                if (!Directory.Exists(base.sProPath + "\\layout"))
                    Directory.CreateDirectory(base.sProPath + "\\layout");

                base.toolStripMenuBtn.Items["Layout"].Text = "布局";

                DialogResult d = MessageBox.Show("是否保存?\n是：保存界面样式\n否：恢复默认界面样式,下次加载时将以默认样式打开\n", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
                if (d == DialogResult.Yes)
                {
                    layoutControl1.SaveLayoutToXml(sLayoutHeadPath);
                }
                else if (d == DialogResult.No)
                {
                    if (File.Exists(sLayoutHeadPath))
                        File.Delete(sLayoutHeadPath);

                    if (File.Exists(sLayoutGridPath))
                        File.Delete(sLayoutGridPath);
                }
            }
        }
        #endregion

        /// <summary>
        /// 导入
        /// </summary>
        private void btnImport()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 刷新
        /// </summary>
        private void btnRefresh()
        {
            GetGrid();
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
            throw new NotImplementedException();
        }
        /// <summary>
        /// 删行
        /// </summary>
        private void btnDelRow()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 新增
        /// </summary>
        private void btnAdd()
        {
            sState = "add";
            GetNull();
            SetEnabled(true);
            if (treeList1.FocusedNode != null)
            {
                textEdit供应商编码.EditValue = treeList1.FocusedNode.Tag.ToString().Trim();
            }
            else
            {
                textEdit供应商编码.EditValue = "";
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        private void btnEdit()
        {
            if (textEdit供应商编码.Text.Trim() == "")
            {
                throw new Exception("请选择需要修改的分类");
            }

            SetEnabled(true);
            textEdit供应商编码.Enabled = false;
            sState = "edit";
        }
        /// <summary>
        /// 删除
        /// </summary>
        private void btnDel()
        {
            DialogResult result = MessageBox.Show("是否删除?", "删除提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {
                try
                {
                    if (textEdit供应商编码.EditValue.ToString().Trim() != "")
                    {
                        aList = new System.Collections.ArrayList();

                        string sID = textEdit供应商编码.EditValue.ToString().Trim();

                        sSQL = "select count(1) from " + tablename + " where " + tableid + " like '" + sID + "%' and " + tableid + "!='" + sID + "'";
                        long iCou = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));
                        if (iCou > 0)
                        {
                            throw new Exception("该分类有子类别，不可删除");
                        }

                        sSQL = "select count(1) from Vendor where cVenCCode = '" + sID + "'";
                        iCou = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));
                        if (iCou > 0)
                        {
                            throw new Exception("该分类已经使用，不可删除");
                        }

                        sSQL = "delete " + tablename + " where " + tableid + " = '" + sID + "' ";
                        aList.Add(sSQL);
                        iCou = clsSQLCommond.ExecSqlTran(aList);
                        MessageBox.Show("删除成功！\n合计执行语句:" + iCou + "条");
                        GetGrid();
                        sState = "del";
                    }
                }
                catch (Exception ee)
                {
                    throw new Exception("删除失败:" + ee.Message);
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
                if (textEdit供应商编码.EditValue!=null && textEdit供应商编码.EditValue.ToString().Trim() == "")
                {
                    throw new Exception("请输入供应商编码");
                }
                if (textEdit供应商名称.EditValue!=null && textEdit供应商名称.EditValue.ToString().Trim() == "")
                {
                    throw new Exception("请输入供应商名称");
                }
                sSQL = "select * from " + tablename + " where 1=-1";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                string sErr = "";

                aList = new System.Collections.ArrayList();
                DataRow dr = dt.NewRow();
                if (sState == "add")
                {
                    sSQL = "select isnull(max(iID)+1,1) as iID from " + tablename;
                    long iID = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));
                    dr["iID"] = iID;
                }
                else
                {
                    dr["iID"] = textEditiID.EditValue.ToString().Trim();
                }
                dr["cVCCode"] = textEdit供应商编码.EditValue.ToString().Trim();
                dr["cVCName"] = textEdit供应商名称.EditValue.ToString().Trim();
                dr["Remark"] = textEdit备注.EditValue.ToString().Trim();
                dt.Rows.Add(dr);

                if (sState == "add")
                {
                    string istrue = 系统服务.序号.CheckSerialNumber(tablename, textEdit供应商编码.EditValue.ToString().Trim());
                    if (istrue == "")
                    {
                        sSQL = clsGetSQL.GetInsertSQL(系统服务.ClsBaseDataInfo.sDataBaseName, tablename, dt, dt.Rows.Count - 1);
                        aList.Add(sSQL);
                    }
                    else
                    {
                        throw new Exception(istrue);
                    }
                }
                else
                {
                    sSQL = clsGetSQL.GetUpdateSQL(系统服务.ClsBaseDataInfo.sDataBaseName, tablename, dt, dt.Rows.Count - 1);
                    aList.Add(sSQL);
                }

                if (aList.Count > 0)
                {
                    int iCou = clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("保存成功！\n合计执行语句:" + iCou + "条");
                    SetEnabled(false);
                    GetGrid();
                    sState = "save";
                }
            }
            catch(Exception ee)
            {
                throw new Exception("保存失败！" + ee.Message);
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
            throw new NotImplementedException();
        }
        /// <summary>
        /// 弃审
        /// </summary>
        private void btnUnAudit()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 打开
        /// </summary>
        private void btnOpen()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 关闭
        /// </summary>
        private void btnClose()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 变更
        /// </summary>
        private void btnAlter()
        {
            throw new NotImplementedException();
        }

        #endregion

        private void Frm供应商分类_Load(object sender, EventArgs e)
        {
            try
            {
                GetGrid();
            }
            catch (Exception ee)
            {
                throw new Exception("加载窗体失败\n" + ee.Message);
            }
        }

        private void GetGrid()
        {
            string rule = 系统服务.序号.GetSerialNumberRules(tablename, tableid);
            textEdit编码规则.EditValue = rule;
            if (rule != "")
            {
                GetTree();
                GetNull();
                SetEnabled(false);
            }
            else
            {
                throw new Exception("请先设定编码规则");
            }
        }

        private void GetTree()
        {
            try
            {
                系统服务.序号.GetTree(treeList1, tablename, tableid, "供应商分类");
                treeList1.ExpandAll();
                treeList1.BestFitColumns();
            }
            catch (Exception ee)
            {
                throw new Exception("获得失败！  " + ee.Message);
            }
        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            try
            {
                if (e.Node.Tag != null && e.Node.Tag.ToString().Trim() != "")
                {
                    string sSQL = "select * from " + tablename + " where " + tableid + " = '" + e.Node.Tag.ToString().Trim() + "' ORDER BY " + tableid;
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    if (e.Node.Tag.ToString().Trim() != null)
                    {
                        textEditiID.EditValue = dt.Rows[0]["iID"].ToString().Trim();
                        textEdit供应商编码.EditValue = dt.Rows[0]["cVCCode"].ToString().Trim();
                        textEdit供应商名称.EditValue = dt.Rows[0]["cVCName"].ToString().Trim();
                        textEdit备注.EditValue = dt.Rows[0]["Remark"].ToString().Trim();

                        SetBtnEnable(true);
                    }
                }
                else
                {
                    GetNull();
                    sState = "sel";
                }
                SetEnabled(false);
            }
            catch (Exception ee)
            {
               
            }
        }

        private void SetEnabled(bool b)
        {
            textEdit供应商编码.Enabled = b;
            textEdit供应商名称.Enabled = b;
            textEdit备注.Enabled = b;
        }

        private void GetNull()
        {
            textEditiID.EditValue = "";
            textEdit供应商编码.EditValue = "";
            textEdit供应商名称.EditValue = "";
            textEdit备注.EditValue = "";
        }
    }
}
