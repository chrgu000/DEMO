using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Collections;
using DevExpress.XtraReports.UI;
//using System.Threading;


namespace 系统服务
{
    public partial class FrmBaseInfo : DevExpress.XtraEditors.XtraForm
    {
        系统服务.FrmProgressBar frmProgressBar = 系统服务.FrmProgressBar.Instance();
        protected string sUid;
        protected string sUserName;
        protected Form Frm;
        protected object clsFrm;
        protected 系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
        protected 系统服务.ClsExcel clsExcel = 系统服务.ClsExcel.Instance();
        protected 系统服务.ClsGetSQL clsGetSQL = 系统服务.ClsGetSQL.Instance();
        protected string sState;                                //按钮状态
        protected int iFocRow = 0;
        protected string sProPath = Application.StartupPath;    //程序执行位置
        protected string sLayoutHeadPath;
        protected string sLayoutGridPath;
        protected string sPrintLayOutMod;
        protected string sPrintLayOutUser;
        protected string sSQL;
        protected ArrayList aList;
        protected DataSet dsPrint = new DataSet();          //打印模板数据源

        protected System.Windows.Forms.ToolStripButton toolBtn;
        protected DataSet dsForm = new DataSet();
        protected DataTable dtSel = new DataTable();        //翻页主键信息
        protected int iPage = 0;                            //当前页
        protected bool btnEnable = true;                    //设置按钮Enable属性
        DataTable dtBtnInfo;                                //当前窗体的按钮信息

        public DataTable dtBind;                            //与主窗体交互数据使用（子窗体信息）
        protected DataTable dtBingGrid;                     //业务窗体列表信息
        protected DataTable dtBingHead;                     //业务窗体表头信息

        protected string sTableHead;                        //业务窗体表头名称
        protected string sTableList;                        //业务窗体表体列表名称
        

        public FrmBaseInfo()
        {
            sUid = 系统服务.ClsBaseDataInfo.sUid;
            sUserName = 系统服务.ClsBaseDataInfo.sUserName;

            //sProPath = Application.StartupPath;
           
            InitializeComponent();

            toolStripMenuBtn.BackColor = this.BackColor;

            CheckDate();
        }

        /// <summary>
        /// 设置窗体样式
        /// </summary>
        public void SetLookAndFeel(DevExpress.LookAndFeel.UserLookAndFeel lf)
        {
            childLF.LookAndFeel.SkinName = lf.SkinName;
            childLF.LookAndFeel.Style = lf.Style;

            childLF.LookAndFeel.UseDefaultLookAndFeel = lf.UseDefaultLookAndFeel;
            childLF.LookAndFeel.UseWindowsXPTheme = lf.UseWindowsXPTheme;
        }

        private void FrmBaseInfo_Load(object sender, EventArgs e)
        {
            
            try
            {
                Frm = (Form)sender;
                clsFrm = this;

                CreateBtn(Frm.Name.Trim());

                SetBtnEnable(btnEnable);

                SetConEnable(false);
                
                SetConDefData();

                this.WindowState = FormWindowState.Maximized;

                this.BackColor = this.MdiParent.BackColor;

                sPrintLayOutMod = sProPath + "\\print\\Model\\" + this.Text.Trim() + "Mod.dll";
                sPrintLayOutUser = sProPath + "\\print\\User\\" + this.Text.Trim() + "User.dll";

                
            }
            catch(Exception ee)
            {
                ;
            }
        }

        /// <summary>
        /// 创建窗体按钮        
        /// </summary>
        private void CreateBtn(string sFormInfo)
        {
            clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
            string sSQL2 = @"select count(*) from dbo._UserRoleInfo where vchrRoleID = 'administrator' and vchrUserID = '" +sUid + "'";
            string sSQL = "";
            if (sUid == "admin" || sUid == "system" || Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL2)) != 0)
            {
                sSQL = "SELECT TOP 100 PERCENT fchrFrmNameID, vchrBtnID, vchrBtnText, iIcon, vchrRemark, intOrder,isnull(bEnable,0) as bEnable " +
                                "FROM dbo._FormBtnInfo " +
                                "WHERE (fchrFrmNameID = '" + sFormInfo + "') " +
                                "ORDER BY intOrder DESC";
            }
            else
            {
                sSQL = "SELECT distinct _FormBtnInfo.fchrFrmNameID, vchrBtnID, vchrBtnText, _FormBtnInfo.vchrRemark, intOrder,isnull(bEnable,0) as bEnable , " +
                            "  RTRIM(LTRIM(LEFT(dbo._RoleRight.vchrRoleRight, CHARINDEX('|', dbo._RoleRight.vchrRoleRight) - 1))) AS vchrL,  " +
                            "  RTRIM(LTRIM(RIGHT(dbo._RoleRight.vchrRoleRight, LEN(dbo._RoleRight.vchrRoleRight) - CHARINDEX('|', dbo._RoleRight.vchrRoleRight))))  " +
                            "  AS vchrR " +
                            "FROM         dbo._RoleInfo INNER JOIN " +
                            "	dbo._RoleRight ON dbo._RoleInfo.vchrRoleID = dbo._RoleRight.vchrRoleID INNER JOIN " +
                            "	dbo._UserRoleInfo ON dbo._RoleInfo.vchrRoleID = dbo._UserRoleInfo.vchrRoleID AND dbo._UserRoleInfo.vchrUserID = '" + sUid + "'  " +
                            "	INNER JOIN " +
                            "	dbo._FormBtnInfo ON vchrBtnID = RTRIM(LTRIM(RIGHT(dbo._RoleRight.vchrRoleRight, LEN(dbo._RoleRight.vchrRoleRight) - CHARINDEX('|', dbo._RoleRight.vchrRoleRight)))) AND fchrFrmNameID = RTRIM(LTRIM(LEFT(dbo._RoleRight.vchrRoleRight, CHARINDEX('|', dbo._RoleRight.vchrRoleRight) - 1))) " +
                            "WHERE     (fchrFrmNameID = '" + sFormInfo + "')  " +
                            "ORDER BY intOrder DESC"; 
            }
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            if (dt == null || dt.Rows.Count < 1)
                return;

            dtBtnInfo = dt.Copy();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                switch (Convert.ToInt32(dt.Rows[i]["bEnable"]))
                {
                    case 0:
                        toolStripMenuBtn.Items[dt.Rows[i]["vchrBtnID"].ToString().Trim().ToLower()].Enabled = true;
                        break;
                    case 1:
                        toolStripMenuBtn.Items[dt.Rows[i]["vchrBtnID"].ToString().Trim().ToLower()].Enabled = true;
                        break;
                    case 2:
                        toolStripMenuBtn.Items[dt.Rows[i]["vchrBtnID"].ToString().Trim().ToLower()].Enabled = false;
                        break;
                    case 5:
                        toolStripMenuBtn.Items[dt.Rows[i]["vchrBtnID"].ToString().Trim().ToLower()].Enabled = true;
                        break;
                    default:
                        toolStripMenuBtn.Items[dt.Rows[i]["vchrBtnID"].ToString().Trim().ToLower()].Enabled = false;
                        break;
                }
                switch (dt.Rows[i]["vchrBtnID"].ToString().Trim().ToLower())
                {
                    case "layout":
                        toolStripMenuBtn.Items["layout"].Visible = true;
                        toolStripMenuBtn.Items["layout"].Text = dt.Rows[i]["vchrBtnText"].ToString().Trim();
                        toolStripMenuBtn.Items["layout"].Tag = dt.Rows[i]["bEnable"].ToString().Trim();
                        tLayout.Visible = true;
                        break;
                    case "printset":
                        toolStripMenuBtn.Items["printset"].Visible = true;
                        toolStripMenuBtn.Items["printset"].Text = dt.Rows[i]["vchrBtnText"].ToString().Trim();
                        toolStripMenuBtn.Items["layout"].Tag = dt.Rows[i]["bEnable"].ToString().Trim();
                        tLayout.Visible = true;
                        break;
                    case "export":
                        toolStripMenuBtn.Items["export"].Visible = true;
                        toolStripMenuBtn.Items["export"].Text = dt.Rows[i]["vchrBtnText"].ToString().Trim();
                        toolStripMenuBtn.Items["layout"].Tag = dt.Rows[i]["bEnable"].ToString().Trim();
                        tExport.Visible = true;
                        break;
                    case "print":
                        toolStripMenuBtn.Items["print"].Visible = true;
                        toolStripMenuBtn.Items["print"].Text = dt.Rows[i]["vchrBtnText"].ToString().Trim();
                        toolStripMenuBtn.Items["layout"].Tag = dt.Rows[i]["bEnable"].ToString().Trim();
                        tExport.Visible = true;
                        break;
                    case "unaudit":
                        toolStripMenuBtn.Items["unaudit"].Visible = true;
                        toolStripMenuBtn.Items["unaudit"].Text = dt.Rows[i]["vchrBtnText"].ToString().Trim();
                        toolStripMenuBtn.Items["layout"].Tag = dt.Rows[i]["bEnable"].ToString().Trim();
                        tAudit.Visible = true;
                        break;
                    case "audit":
                        toolStripMenuBtn.Items["audit"].Visible = true;
                        toolStripMenuBtn.Items["audit"].Text = dt.Rows[i]["vchrBtnText"].ToString().Trim();
                        toolStripMenuBtn.Items["layout"].Tag = dt.Rows[i]["bEnable"].ToString().Trim();
                        tAudit.Visible = true;
                        break;
                    case "unlock":
                        toolStripMenuBtn.Items["unlock"].Visible = true;
                        toolStripMenuBtn.Items["unlock"].Text = dt.Rows[i]["vchrBtnText"].ToString().Trim();
                        toolStripMenuBtn.Items["layout"].Tag = dt.Rows[i]["bEnable"].ToString().Trim();
                        tLock.Visible = true;
                        break;
                    case "lock":
                        toolStripMenuBtn.Items["lock"].Visible = true;
                        toolStripMenuBtn.Items["lock"].Text = dt.Rows[i]["vchrBtnText"].ToString().Trim();
                        toolStripMenuBtn.Items["layout"].Tag = dt.Rows[i]["bEnable"].ToString().Trim();
                        tLock.Visible = true;
                        break;
                    case "alter":
                        toolStripMenuBtn.Items["alter"].Visible = true;
                        toolStripMenuBtn.Items["alter"].Text = dt.Rows[i]["vchrBtnText"].ToString().Trim();
                        toolStripMenuBtn.Items["layout"].Tag = dt.Rows[i]["bEnable"].ToString().Trim();
                        tSave.Visible = true;
                        break;
                    case "undo":
                        toolStripMenuBtn.Items["undo"].Visible = true;
                        toolStripMenuBtn.Items["undo"].Text = dt.Rows[i]["vchrBtnText"].ToString().Trim();
                        toolStripMenuBtn.Items["layout"].Tag = dt.Rows[i]["bEnable"].ToString().Trim();
                        tSave.Visible = true;
                        break;
                    case "save":
                        toolStripMenuBtn.Items["save"].Visible = true;
                        toolStripMenuBtn.Items["save"].Text = dt.Rows[i]["vchrBtnText"].ToString().Trim();
                        toolStripMenuBtn.Items["layout"].Tag = dt.Rows[i]["bEnable"].ToString().Trim();
                        tSave.Visible = true;
                        break;
                    case "del":
                        toolStripMenuBtn.Items["del"].Visible = true;
                        toolStripMenuBtn.Items["del"].Text = dt.Rows[i]["vchrBtnText"].ToString().Trim();
                        toolStripMenuBtn.Items["layout"].Tag = dt.Rows[i]["bEnable"].ToString().Trim();
                        tAdd.Visible = true;
                        break;
                    case "edit":
                        toolStripMenuBtn.Items["edit"].Visible = true;
                        toolStripMenuBtn.Items["edit"].Text = dt.Rows[i]["vchrBtnText"].ToString().Trim();
                        toolStripMenuBtn.Items["layout"].Tag = dt.Rows[i]["bEnable"].ToString().Trim();
                        tAdd.Visible = true;
                        break;
                    case "add":
                        toolStripMenuBtn.Items["add"].Visible = true;
                        toolStripMenuBtn.Items["add"].Text = dt.Rows[i]["vchrBtnText"].ToString().Trim();
                        toolStripMenuBtn.Items["layout"].Tag = dt.Rows[i]["bEnable"].ToString().Trim();
                        tAdd.Visible = true;
                        break;
                    case "import":
                        toolStripMenuBtn.Items["import"].Visible = true;
                        toolStripMenuBtn.Items["import"].Text = dt.Rows[i]["vchrBtnText"].ToString().Trim();
                        toolStripMenuBtn.Items["layout"].Tag = dt.Rows[i]["bEnable"].ToString().Trim();
                        tAdd.Visible = true;
                        break;
                    case "delrow":
                        toolStripMenuBtn.Items["delrow"].Visible = true;
                        toolStripMenuBtn.Items["delrow"].Text = dt.Rows[i]["vchrBtnText"].ToString().Trim();
                        toolStripMenuBtn.Items["layout"].Tag = dt.Rows[i]["bEnable"].ToString().Trim();
                        tAddRow.Visible = true;
                        break;
                    case "addrow":
                        toolStripMenuBtn.Items["addrow"].Visible = true;
                        toolStripMenuBtn.Items["addrow"].Text = dt.Rows[i]["vchrBtnText"].ToString().Trim();
                        toolStripMenuBtn.Items["layout"].Tag = dt.Rows[i]["bEnable"].ToString().Trim();
                        tAddRow.Visible = true;
                        break;
                    case "last":
                        toolStripMenuBtn.Items["last"].Visible = true;
                        toolStripMenuBtn.Items["last"].Text = dt.Rows[i]["vchrBtnText"].ToString().Trim();
                        toolStripMenuBtn.Items["layout"].Tag = dt.Rows[i]["bEnable"].ToString().Trim();
                        tSel.Visible = true;
                        lPageInfo.Visible = true;
                        break;
                    case "next":
                        toolStripMenuBtn.Items["next"].Visible = true;
                        toolStripMenuBtn.Items["next"].Text = dt.Rows[i]["vchrBtnText"].ToString().Trim();
                        toolStripMenuBtn.Items["layout"].Tag = dt.Rows[i]["bEnable"].ToString().Trim();
                        tSel.Visible = true;
                        lPageInfo.Visible = true;
                        break;
                    case "prev":
                        toolStripMenuBtn.Items["prev"].Visible = true;
                        toolStripMenuBtn.Items["prev"].Text = dt.Rows[i]["vchrBtnText"].ToString().Trim();
                        toolStripMenuBtn.Items["layout"].Tag = dt.Rows[i]["bEnable"].ToString().Trim();
                        tSel.Visible = true;
                        lPageInfo.Visible = true;
                        break;
                    case "first":
                        toolStripMenuBtn.Items["first"].Visible = true;
                        toolStripMenuBtn.Items["first"].Text = dt.Rows[i]["vchrBtnText"].ToString().Trim();
                        toolStripMenuBtn.Items["layout"].Tag = dt.Rows[i]["bEnable"].ToString().Trim();
                        tSel.Visible = true;
                        lPageInfo.Visible = true;
                        break;
                    case "sel":
                        toolStripMenuBtn.Items["sel"].Visible = true;
                        toolStripMenuBtn.Items["sel"].Text = dt.Rows[i]["vchrBtnText"].ToString().Trim();
                        toolStripMenuBtn.Items["layout"].Tag = dt.Rows[i]["bEnable"].ToString().Trim();
                        lPageInfo.Visible = true;
                        break;
                    case "refresh":
                        toolStripMenuBtn.Items["refresh"].Visible = true;
                        toolStripMenuBtn.Items["refresh"].Text = dt.Rows[i]["vchrBtnText"].ToString().Trim();
                        toolStripMenuBtn.Items["layout"].Tag = dt.Rows[i]["bEnable"].ToString().Trim();
                        lPageInfo.Visible = true;
                        break;
                    case "open":
                        toolStripMenuBtn.Items["open"].Visible = true;
                        toolStripMenuBtn.Items["open"].Text = dt.Rows[i]["vchrBtnText"].ToString().Trim();
                        toolStripMenuBtn.Items["layout"].Tag = dt.Rows[i]["bEnable"].ToString().Trim();
                        tOpen.Visible = true;
                        break;
                    case "close":
                        toolStripMenuBtn.Items["close"].Visible = true;
                        toolStripMenuBtn.Items["close"].Text = dt.Rows[i]["vchrBtnText"].ToString().Trim();
                        toolStripMenuBtn.Items["layout"].Tag = dt.Rows[i]["bEnable"].ToString().Trim();
                        tOpen.Visible = true;
                        break;
                    case "buckup":
                        toolStripMenuBtn.Items["buckup"].Visible = true;
                        toolStripMenuBtn.Items["buckup"].Text = dt.Rows[i]["vchrBtnText"].ToString().Trim();
                        toolStripMenuBtn.Items["layout"].Tag = dt.Rows[i]["bEnable"].ToString().Trim();
                        tBuckUp.Visible = true;
                        break;
                    case "autobuckup":
                        toolStripMenuBtn.Items["autobuckup"].Visible = true;
                        toolStripMenuBtn.Items["autobuckup"].Text = dt.Rows[i]["vchrBtnText"].ToString().Trim();
                        toolStripMenuBtn.Items["layout"].Tag = dt.Rows[i]["bEnable"].ToString().Trim();
                        tBuckUp.Visible = true;
                        break;
                }
            }
            dtBtnInfo = dt.Copy();
        }


        protected void SetBtnEnable(bool b)
        {
            if (dtBtnInfo == null)
                return;
            
            bool bEnable = false;

            for (int i = 0; i < dtBtnInfo.Rows.Count; i++)
            {
                if (Convert.ToInt32(dtBtnInfo.Rows[i]["bEnable"]) == 0)
                    bEnable = true;
                if (Convert.ToInt32(dtBtnInfo.Rows[i]["bEnable"]) == 1)
                {
                    if (b)
                        bEnable = true;
                    else
                        bEnable = false;
                }
                if (Convert.ToInt32(dtBtnInfo.Rows[i]["bEnable"]) == 2)
                {
                    if (b)
                        bEnable = false;
                    else
                        bEnable = true;
                }
                if (Convert.ToInt32(dtBtnInfo.Rows[i]["bEnable"]) == 3)
                {
                    bEnable = b;
                    //if (b)
                    //    bEnable = true;
                    //else
                    //    bEnable = true;
                }
                if (Convert.ToInt32(dtBtnInfo.Rows[i]["bEnable"]) == 4)
                {
                    bEnable = !b;
                    //if (b)
                    //    bEnable = false;
                    //else
                    //    bEnable = false;
                }
                if (Convert.ToInt32(dtBtnInfo.Rows[i]["bEnable"]) == 5)
                {
                    bEnable = true;
                    //if (b)
                    //    bEnable = false;
                    //else
                    //    bEnable = false;
                }
                toolStripMenuBtn.Items[dtBtnInfo.Rows[i]["vchrBtnID"].ToString().Trim()].Enabled = bEnable;
            }

            btnEnable = !b;
        }

        /// <summary>
        /// 设置控件的Enable属性
        /// </summary>
        /// <param name="b"></param>
        protected void SetConEnable(bool b)
        {
            for (int i = 0; i < Frm.Controls.Count; i++)
            {
                string sType = Frm.Controls[i].GetType().ToString();
                if (sType == "System.Windows.Forms.TextBox")
                {
                    TextBox edTemp = (TextBox)Frm.Controls[i];
                    edTemp.ReadOnly = !b;
                    edTemp.Enabled = b;
                }
                if (sType == "System.Windows.Forms.ComboBox")
                {
                    ComboBox edTemp = (ComboBox)Frm.Controls[i];
                    edTemp.Enabled = b;
                }
                if (sType == "System.Windows.Forms.DateTimePicker")
                {
                    DateTimePicker edTemp = (DateTimePicker)Frm.Controls[i];
                    edTemp.Enabled = b;
                }
                if (sType == "DevExpress.XtraEditors.DateEdit")
                {
                    DevExpress.XtraEditors.DateEdit edTemp = (DevExpress.XtraEditors.DateEdit)Frm.Controls[i];
                    edTemp.Properties.ReadOnly = !b; 
                    edTemp.Enabled = b;
                }
                if (sType == "DevExpress.XtraEditors.TextEdit")
                {
                    DevExpress.XtraEditors.TextEdit edTemp = (DevExpress.XtraEditors.TextEdit)Frm.Controls[i];
                    edTemp.Properties.ReadOnly = !b;
                }
                if (sType == "DevExpress.XtraEditors.LookUpEdit")
                {
                    DevExpress.XtraEditors.LookUpEdit edTemp = (DevExpress.XtraEditors.LookUpEdit)Frm.Controls[i];
                    edTemp.Properties.ReadOnly = !b;
                }
                if (sType == "System.Windows.Forms.RichTextBox")
                {
                    System.Windows.Forms.RichTextBox edTemp = (System.Windows.Forms.RichTextBox)Frm.Controls[i];
                    edTemp.ReadOnly = !b;
                }

                //if (sType == "DevExpress.XtraGrid.GridControl")
                //{
                //    DevExpress.XtraGrid.GridControl edTemp = (DevExpress.XtraGrid.GridControl)Frm.Controls[i];
                //    edTemp.pro = !b;
                //}
            }
        }

        /// <summary>
        /// 设置控件默认值
        /// </summary>
        protected void SetConDefData()
        {
            for (int i = 0; i < Frm.Controls.Count; i++)
            {
                string sType = Frm.Controls[i].GetType().ToString();
                if (sType == "System.Windows.Forms.TextBox")
                {
                    TextBox edTemp = (TextBox)Frm.Controls[i];
                    edTemp.Text = "";
                }
                if (sType == "System.Windows.Forms.DateTimePicker")
                {
                    DateTimePicker edTemp = (DateTimePicker)Frm.Controls[i];
                    edTemp.Text = "";
                }
                if (sType == "DevExpress.XtraEditors.DateEdit")
                {
                    DevExpress.XtraEditors.DateEdit edTemp = (DevExpress.XtraEditors.DateEdit)Frm.Controls[i];
                    edTemp.Text = "";
                }
                if (sType == "DevExpress.XtraEditors.TextEdit")
                {
                    DevExpress.XtraEditors.TextEdit edTemp = (DevExpress.XtraEditors.TextEdit)Frm.Controls[i];
                    edTemp.Text = "";
                }
                if (sType == "DevExpress.XtraEditors.LookUpEdit")
                {
                    DevExpress.XtraEditors.LookUpEdit edTemp = (DevExpress.XtraEditors.LookUpEdit)Frm.Controls[i];
                    edTemp.EditValue = null;
                }
                if (sType == "System.Windows.Forms.RichTextBox")
                {
                    System.Windows.Forms.RichTextBox edTemp = (System.Windows.Forms.RichTextBox)Frm.Controls[i];
                    edTemp.Text = "";
                }

            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string sInfo = this.Name + "|" + e.ClickedItem.Name;

                if (e.ClickedItem.Name.ToLower().Trim() == "exit")
                {
                    //if (MessageBox.Show("是否关闭当前窗体？\n是：关闭\n否：取消", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                    //{
                    //    sSQL = "insert into Define1(S1,s2,S3,S4,S5,S6,SysCreateDate)values('" + 系统服务.ClsBaseDataInfo.sUid + "','" + 系统服务.ClsBaseDataInfo.sUserName + "','" + this.Name + "','" + this.Text + "','" + e.ClickedItem.Name.Trim() + "','" + e.ClickedItem.Text.Trim() + "',getdate())";
                    //    clsSQLCommond.ExecSql(sSQL);
                        this.Close();
                        return;
                    //}
                }

                clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
                string sSQL2 = @"select count(*) from dbo._UserRoleInfo where vchrRoleID = 'administrator' and vchrUserID = '" + sUid + "'";

                bool b = false;
                if (sUid == "admin" || sUid == "system")
                {
                    b = true;
                }
                if (Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL2)) != 0)
                {
                    b = true;
                }
                if (!b)
                {
                    if (!hasRight(sInfo, sUid))
                    {
                        e.ClickedItem.Enabled = false;
                        MessageBox.Show("权限不足！");
                        return;
                    }
                }


                //sSQL = "insert into Define1(S1,s2,S3,S4,S5,S6,SysCreateDate)values('" + 系统服务.ClsBaseDataInfo.sUid + "','" + 系统服务.ClsBaseDataInfo.sUserName + "','" + this.Name + "','" + this.Text + "','" + e.ClickedItem.Name.Trim() + "','" + e.ClickedItem.Text.Trim() + "',getdate())";
                //clsSQLCommond.ExecSql(sSQL);
                BtnClick(e.ClickedItem.Name, e.ClickedItem.Text);

                if (dtBtnInfo != null && dtBtnInfo.Rows.Count > 0)
                {
                    for (int i = 0; i < dtBtnInfo.Rows.Count; i++)
                    {
                        if (dtBtnInfo.Rows[i]["vchrBtnID"].ToString().Trim().ToLower() == e.ClickedItem.Name.ToLower().Trim())
                        {
                            if (Convert.ToInt32(dtBtnInfo.Rows[i]["bEnable"]) == 0)
                            {
                                btnEnable = true;
                                SetBtnEnable(btnEnable);
                            }
                            else if (Convert.ToInt32(dtBtnInfo.Rows[i]["bEnable"]) == 1 || Convert.ToInt32(dtBtnInfo.Rows[i]["bEnable"]) == 2)
                            {
                                SetBtnEnable(btnEnable);
                            }
                            else if (Convert.ToInt32(dtBtnInfo.Rows[i]["bEnable"]) == 3)
                            {
                                SetBtnEnable(true);
                            }
                            else if (Convert.ToInt32(dtBtnInfo.Rows[i]["bEnable"]) == 4)
                            {
                                SetBtnEnable(false);
                            }
                            else if (Convert.ToInt32(dtBtnInfo.Rows[i]["bEnable"]) == 5)
                            {
                                //SetBtnEnable(false);
                            }
                        }
                    }
                }

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ee)
            {
                MsgBox("操作失败", ee.Message);
            }
        }

        /// <summary>
        /// 权限判断
        /// </summary>
        /// <returns></returns>
        private bool hasRight(string sInfo, string sUid)
        {
            bool b = false;
            try
            {
                clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();

                string sSQL = "SELECT     COUNT(*) AS iCount " +
                              "FROM         dbo._RoleRight INNER JOIN dbo._UserRoleInfo ON _RoleRight.vchrRoleID = dbo._UserRoleInfo.vchrRoleID " +
                              "WHERE   dbo._UserRoleInfo.vchrUserID = '" + sUid + "' and dbo._RoleRight.vchrRoleRight = '" + sInfo + "' ";

                int iCou = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
                if (iCou > 0)
                    b = true;
                else
                    b = false;
            }
            catch
            {
                throw new Exception("判断权限失败！");
            }
            return b;
        }

        protected virtual void BtnClick(string sBtnName, string sBtnText) { }

        /// <summary>
        /// 数字小数位设定
        /// </summary>
        /// <param name="s">数值</param>
        /// <param name="i">小数位</param>
        protected decimal SetNum(object s, int i)
        {
            decimal d = 0;
            try
            {
                d = decimal.Parse(s.ToString().Trim());
                decimal.Round(d, i);
            }
            catch(Exception ee)
            {
                MessageBox.Show("设置小数位失败！   " + ee.Message);
            }
            return d;
        }

        /// <summary>
        /// 提示框
        /// </summary>
        /// <param name="sText">标题</param>
        /// <param name="sInfo">内容</param>
        /// <returns></returns>
        protected DialogResult MsgBox(string sTital,string sInfo)
        {
            FrmMsgBox fMsg = new FrmMsgBox();
            fMsg.richTextBox1.Text = sInfo;
            fMsg.Text = sTital;
            fMsg.ShowDialog();
            return fMsg.DialogResult;
        }


        系统服务.RepBaseGrid Rep = new 系统服务.RepBaseGrid();
        private void Print_Click(object sender, EventArgs e)
        {
            try
            {
                Rep = new RepBaseGrid();
                if (File.Exists(sPrintLayOutUser))
                {
                    Rep.LoadLayout(sPrintLayOutUser);
                }
                else if (File.Exists(sPrintLayOutMod))
                {
                    Rep.LoadLayout(sPrintLayOutMod);
                }
                else
                {
                    MessageBox.Show("加载报表模板失败，请与管理员联系");
                    return;
                }
                Rep.dsPrint.Tables["dtHead"].Rows.Clear();
                Rep.dsPrint.Tables["dtGrid"].Clear();
                Rep.dsPrint.Tables["dtHead"].Columns.Clear();
                Rep.dsPrint.Tables["dtGrid"].Columns.Clear();
                //设置报表表头数据表列
                try
                {
                    for (int i = 0; i < this.dsPrint.Tables["dtHead"].Columns.Count; i++)
                    {
                        DataColumn dc = new DataColumn();
                        dc = this.dsPrint.Tables["dtHead"].Columns[i];
                        DataColumn dcRep = new DataColumn();
                        dcRep.ColumnName = dc.ColumnName;
                        Rep.dsPrint.Tables["dtHead"].Columns.Add(dcRep);
                    }
                }
                catch { }
                //设置报表表体数据表列
                for (int i = 0; i < this.dsPrint.Tables["dtGrid"].Columns.Count; i++)
                {
                    DataColumn dcGrid = new DataColumn();
                    dcGrid = this.dsPrint.Tables["dtGrid"].Columns[i];
                    DataColumn dcRepGrid = new DataColumn();
                    dcRepGrid.ColumnName = dcGrid.ColumnName;
                    Rep.dsPrint.Tables["dtGrid"].Columns.Add(dcRepGrid);
                }
                if (this.dsPrint.Tables["dtHead"] != null)
                {
                    for (int i = 0; i < this.dsPrint.Tables["dtHead"].Rows.Count; i++)
                    {
                        DataRow dr = Rep.dsPrint.Tables["dtHead"].NewRow();
                        for (int j = 0; j < Rep.dsPrint.Tables["dtHead"].Columns.Count; j++)
                        {
                            dr[j] = this.dsPrint.Tables["dtHead"].Rows[i][j];
                        }
                        Rep.dsPrint.Tables["dtHead"].Rows.Add(dr);
                    }
                }
                if (this.dsPrint.Tables["dtGrid"] != null)
                {
                    for (int i = 0; i < this.dsPrint.Tables["dtGrid"].Rows.Count; i++)
                    {
                        DataRow dr = Rep.dsPrint.Tables["dtGrid"].NewRow();
                        for (int j = 0; j < Rep.dsPrint.Tables["dtGrid"].Columns.Count; j++)
                        {
                            dr[j] = this.dsPrint.Tables["dtGrid"].Rows[i][j];
                        }
                        Rep.dsPrint.Tables["dtGrid"].Rows.Add(dr);
                    }
                }
                
                Rep.DataMember = "dtGrid";
                Rep.ShowPreview();
            }
            catch (Exception ee)
            {
                MessageBox.Show("打印失败:" + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void PrintSet_Click(object sender, EventArgs e)
        {
            bool bMod = false;
            if (sUid == "admin" ||sUid == "system")
            {
                bMod = true;
            }

            if (!Directory.Exists(sProPath + "\\print"))
                Directory.CreateDirectory(sProPath + "\\print");
            if (!Directory.Exists(sProPath + "\\print\\Model"))
                Directory.CreateDirectory(sProPath + "\\print\\Model");
            if (!Directory.Exists(sProPath + "\\print\\User"))
                Directory.CreateDirectory(sProPath + "\\print\\User");

            if (bMod)
            {
                if (File.Exists(sPrintLayOutMod))
                {
                    Rep.LoadLayout(sPrintLayOutMod);
                }
            }
            else
            {
                if (File.Exists(sPrintLayOutUser))
                {
                    Rep.LoadLayout(sPrintLayOutUser);
                }
                else if (File.Exists(sPrintLayOutMod))
                {
                    Rep.LoadLayout(sPrintLayOutMod);
                }
            }

            Rep.ShowDesignerDialog();

            DialogResult d = MessageBox.Show("是否保存?模板调整将在下次打开窗体时体现\n是：保存打印模板\n否：恢复默认打印模板\n", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
            if (DialogResult.Yes == d)
            {
                if (bMod)
                {
                    Rep.SaveLayoutToXml(sPrintLayOutMod);
                }
                else
                {
                    Rep.SaveLayoutToXml(sPrintLayOutUser);
                }
            }
            else if (DialogResult.No == d)
            {
                if (File.Exists(sPrintLayOutUser))
                {
                    File.Delete(sPrintLayOutUser);
                }
            }
        }

        private void CheckDate()
        {
            //this.ControlBox = false;

            //DateTime date1 = Convert.ToDateTime("2012-10-08");
            //if (DateTime.Now >= date1)
            //{
            //    MessageBox.Show("系统错误，请与管理员联系！");
            //    Application.Exit();
            //}
        }

        protected long ReturnLong(object o)
        {
            long d = 0;
            try
            {
                d = Convert.ToInt64(o);
            }
            catch { }
            return d;
        }

        protected decimal ReturnDecimal(object o)
        {
            decimal d = 0;
            try
            {
                d = decimal.Round(Convert.ToDecimal(o), 6);
            }
            catch { }
            return d;
        }
        protected decimal ReturnDecimal(object o,int iLength)
        {
            decimal d = 0;
            try
            {
                d = decimal.Round(Convert.ToDecimal(o), iLength);
            }
            catch { }
            return d;
        }

        protected double ReturnDouble(object o)
        {
            double d = 0;
            try
            {
                d = Convert.ToDouble(o);
            }
            catch { }
            return d;
        }

        protected int ReturnInt(object o)
        {
            int d = 0;
            try
            {
                d = Convert.ToInt32(o);
            }
            catch { }
            return d;
        }

        protected string ReturnDateTimeString(object o)
        {
            string d = "";
            try
            {
                if (Convert.ToDateTime(o) >= Convert.ToDateTime("1900-01-01"))
                {
                    d = Convert.ToDateTime(o).ToString("yyyy-MM-dd");
                }
            }
            catch { }
            return d;
        }

        protected string ReturnRoleCode(string sUID)
        {
            string sRole = "";
            try
            {
                sSQL = "select vchrRoleID from dbo._UserRoleInfo where vchrUserID = '" + sUid + "'";
                sRole = clsSQLCommond.ExecGetScalar(sSQL).ToString().Trim();
            }
            catch { }
            return sRole;
        }

        protected string ReturnDepCode(string sUID)
        {
            string sDep = "";
            try
            {
                sSQL = "select a.DeptID from dbo.Person a inner join dbo.Department b on b.cDepCode = a.DeptID where a.PersonCode = '" + sUID + "'";
                sDep = clsSQLCommond.ExecGetScalar(sSQL).ToString().Trim();
            }
            catch { }
            return sDep;
        }
    }
}