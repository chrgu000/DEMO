using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;

namespace 基础设置
{
    public partial class Frm本单位信息 : 系统服务.FrmBaseInfo
    {
        public Frm本单位信息()
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
            throw new NotImplementedException();
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
        /// 修改
        /// </summary>
        private void btnEdit()
        {
            SetEnable(true);
        }
        /// <summary>
        /// 删除
        /// </summary>
        private void btnDel()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 保存
        /// </summary>
        private void btnSave()
        {
            if (textEdit单位编号.Text.Trim() == "")
                throw new Exception("单位编码不能为空");
            if (textEdit单位名称.Text.Trim() == "")
                throw new Exception("单位名称不能为空");


            aList = new System.Collections.ArrayList();
            sSQL = "select * from Company where 1=-1";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            DataRow dr = dt.NewRow();
            dr["strID"] = 1;
            dr["senderCode"] = textEdit注册码.EditValue.ToString().Trim();
            dr["strAddress"] = textEdit单位地址.EditValue.ToString().Trim();
            dr["strCode"] = textEdit单位代码.EditValue.ToString().Trim();
            dr["strLeader"] = textEdit法人代表.EditValue.ToString().Trim();
            dr["strName"] = textEdit单位名称.EditValue.ToString().Trim();
            dr["strPhone"] = textEdit联系电话.EditValue.ToString().Trim();
            dr["strPostCode"] = textEdit邮政编码.EditValue.ToString().Trim();
            dr["strRemark1"] = textEdit备注一.EditValue.ToString().Trim();
            dr["strRemark2"] = textEdit备注二.EditValue.ToString().Trim();
            dr["strTax"] = textEdit传真.EditValue.ToString().Trim();
            dr["strTaxID"] = textEdit税务登记号.EditValue.ToString().Trim();
            dt.Rows.Add(dr);
            sSQL = "select * from Company";
            DataTable dts = clsSQLCommond.ExecQuery(sSQL);
            if (dts.Rows.Count == 0)
            {
                sSQL = clsGetSQL.GetInsertSQL(系统服务.ClsBaseDataInfo.sDataBaseName, "Company", dt, 0);
            }
            else
            {
                sSQL = clsGetSQL.GetUpdateSQL(系统服务.ClsBaseDataInfo.sDataBaseName, "Company", dt, 0);
            }
            aList.Add(sSQL);
            

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                SetEnable(false);
                MessageBox.Show("保存成功！\n合计执行语句:" + iCou + "条");
                sState = "save";
            }
        }
        /// <summary>
        /// 撤销
        /// </summary>
        private void btnUnDo()
        {
            GetGrid();
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

        private void Frm本单位信息_Load(object sender, EventArgs e)
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
            sSQL = "select * from Company where 1=1";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt.Rows.Count > 0)
            {
                textEdit单位编号.EditValue = dt.Rows[0]["strID"].ToString();
                textEdit注册码.EditValue = dt.Rows[0]["senderCode"].ToString();
                textEdit单位地址.EditValue = dt.Rows[0]["strAddress"].ToString();
                textEdit单位代码.EditValue = dt.Rows[0]["strCode"].ToString();
                textEdit法人代表.EditValue = dt.Rows[0]["strLeader"].ToString();
                textEdit单位名称.EditValue = dt.Rows[0]["strName"].ToString();
                textEdit联系电话.EditValue = dt.Rows[0]["strPhone"].ToString();
                textEdit邮政编码.EditValue = dt.Rows[0]["strPostCode"].ToString();
                textEdit备注一.EditValue = dt.Rows[0]["strRemark1"].ToString();
                textEdit备注二.EditValue = dt.Rows[0]["strRemark2"].ToString();
                textEdit传真.EditValue = dt.Rows[0]["strTax"].ToString();
                textEdit税务登记号.EditValue = dt.Rows[0]["strTaxID"].ToString();
            }

            SetEnable(false);
            sState = "sel";
        }

        private void SetEnable(bool b)
        {
            textEdit单位编号.Enabled = false;
            textEdit注册码.Enabled = b;
            textEdit单位地址.Enabled = b;
            textEdit单位代码.Enabled = b;
            textEdit法人代表.Enabled = b;
            textEdit单位名称.Enabled = b;
            textEdit联系电话.Enabled = b;
            textEdit邮政编码.Enabled = b;
            textEdit备注一.Enabled = b;
            textEdit备注二.Enabled = b;
            textEdit传真.Enabled = b;
            textEdit税务登记号.Enabled = b;
        }

    }
}
