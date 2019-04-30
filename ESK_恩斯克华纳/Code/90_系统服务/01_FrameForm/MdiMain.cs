using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using DevExpress.XtraBars.Localization;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraBars;
using System.Xml;
using System.IO;
using AutoUpdate;
using System.Collections;

namespace 系统服务
{
    public partial class MdiMain : Form
    {
        bool bIsLogined = false;
        系统服务.FrmBaseInfo frmBase;
        DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager();
        系统服务.ClsDataBase clsSQLCommond;
        系统服务.ClsDES clsDES;

        public MdiMain()
        {
            InitInfo();

            InitializeComponent();

            m_FormList = new Dictionary<string, Form>();

            BarLocalizer.Active = new ChineseLocalizer();
            GridLocalizer.Active = new ChineseGridLocalizer();
            Localizer.Active = new ChineseEditorsLocalizer();


            if (Login())
                bIsLogined = true;
            else
                bIsLogined = false;

            clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();

            xtraTabbedMdiManager.SelectedPageChanged += new System.EventHandler(this.xtraTabbedMdiManager2_SelectedPageChanged);
        }

        private string sPathConfig = Application.StartupPath + @"\App.dll";
        /// <summary>
        /// 基础档案信息
        /// </summary>
        private void InitInfo()
        {
            if (File.Exists(sPathConfig))
            {
                系统服务.ClsBaseDataInfo.sWebURL = GetConfigValue(sPathConfig, "WebURL");
            }
        }

        /// <summary>
        /// Read confing
        /// </summary>
        /// <param name="path"></param>
        /// <param name="appKey"></param>
        /// <returns></returns>
        public string GetConfigValue(string path, string appKey)
        {
            XmlDocument xDoc = new XmlDocument();
            try
            {
                xDoc.Load(path);
                XmlNode xNode;
                XmlElement xElem;
                xNode = xDoc.SelectSingleNode("//appSettings");
                xElem = (XmlElement)xNode.SelectSingleNode("//add[@key='" + appKey + "']");
                if (xElem != null)
                    return xElem.GetAttribute("value");
                else
                    return "";
            }
            catch (Exception)
            {
                return "";
            }
        }

        /// <summary>
        /// 创建Form实例。
        /// </summary>
        /// <param name="formName">Form的类名</param>
        public void CreateFormInstance(string proFunNO,string sText)
        {
            try
            {
                string proNameSpace, clsFormName;
                DataView dv = new DataView();
                dv.Table = dt;
                dv.RowFilter = "fchrFrmNameID='" + proFunNO + "'";
                proNameSpace = dv.ToTable().Rows[0]["fchrNameSpace"].ToString().Trim();
                bool flag = false;
                clsFormName = proFunNO;

                for (int i = 0; i < this.MdiChildren.Length; i++)
                {
                    if (this.MdiChildren[i].Tag.ToString().ToLower() == proFunNO.ToLower() && this.MdiChildren[i].Text.Trim().ToLower() == sText.Trim().ToLower())
                    {
                        frmBase = (系统服务.FrmBaseInfo)this.MdiChildren[i];

                        this.MdiChildren[i].Activate();

                        flag = true;
                        frmBase.ControlBox = false;
                        break;
                    }
                }
                if (!flag)
                {
                    系统服务.ClsDistributeForm clsDistributeForm = new 系统服务.ClsDistributeForm();
                    frmBase = (系统服务.FrmBaseInfo)clsDistributeForm.DistributeForm(proNameSpace, clsFormName);
                    frmBase.Tag = proFunNO.ToString();
                    frmBase.Text = sText.Trim();

                    frmBase.MdiParent = this;
                    frmBase.WindowState = FormWindowState.Maximized;
                    frmBase.ControlBox = false;
                    frmBase.Show();
                }
            }
            catch(Exception ee)
            {
                MessageBox.Show("该功能尚未提供！" + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// 获得SN信息
        /// </summary>
        /// <param name="sProName"></param>
        /// <param name="sComName"></param>
        /// <param name="sSN"></param>
        private void GetSNInfo(out string sProName,out string sComName,out string sSN)
        {
            sProName = "";
            sComName = "";
            sSN = "";

            string sPathConfig = Application.StartupPath + @"\App.dll";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(sPathConfig);
            XmlNodeList nodes = xmlDoc.SelectNodes("configuration/appSettings/add");
            foreach (XmlNode node in nodes)
            {
                if (node.Attributes["key"].Value == "ProName")
                    sProName = node.Attributes["value"].Value;
                if (node.Attributes["key"].Value == "ComName")
                    sComName = node.Attributes["value"].Value;
                if (node.Attributes["key"].Value == "SN")
                    sSN = node.Attributes["value"].Value;
            }            
        }

        DataTable dt;
        private void FrmMdiMain_Load(object sender, EventArgs e)
        {
            try
            {
                //系统服务.FrmProgressBar frmProgressBar;
                ////frmProgressBar.ShowDialog();
                //frmProgressBar.Hide();

                if (!bIsLogined)
                {
                    Application.Exit();
                    return;
                }

                iBtnType = 0;
                dockPanel1.Text = "业务工作";
                SetTree();

                string sComName; string sProName; string sSN;
                GetSNInfo(out sProName,out sComName,out sSN);

                lbAcc.Caption = "登陆帐套：" + 系统服务.ClsBaseDataInfo.sUFDataBaseText + "\t";
                lbAcc.Caption = "";
                系统服务.ClsBaseDataInfo.sComName = sComName;
                系统服务.ClsBaseDataInfo.sProName = sProName;

                lbComName.Caption = "" + 系统服务.ClsBaseDataInfo.sComName + "\t";
                lbLogDate.Caption = "登陆时间：" + 系统服务.ClsBaseDataInfo.sLogDate + "\t";
                lbUid.Caption = "当前帐号：" + 系统服务.ClsBaseDataInfo.sUid + "\t";
                if (系统服务.ClsBaseDataInfo.sUFDataBaseText.Trim() != string.Empty)
                {
                    lAccInfo.Caption = "帐套号：" + "【" +系统服务.ClsBaseDataInfo.sUFDataBaseName.Substring(11) + "年】" + 系统服务.ClsBaseDataInfo.sUFDataBaseText.Trim() + "\t";
                }
                else
                    lAccInfo.Visibility = BarItemVisibility.Never;

                lVerInfo.Caption = "版本号：" + 系统服务.ClsBaseDataInfo.sEdition + "\t"; 

                this.Text =系统服务.ClsBaseDataInfo.sComName + @"&" + 系统服务.ClsBaseDataInfo.sProName;

                if (!ChkSN(sSN))
                {
                    Application.Exit();
                    return;
                }

                xtraTabbedMdiManager.MdiParent = this;
            }
            catch (Exception ee)
            {
                MessageBox.Show("出现错误!\n\n\t错误信息如下:\n\t" + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// 检查SN是否正确
        /// </summary>
        /// <param name="sSN"></param>
        /// <returns></returns>
        private bool ChkSN(string sSN)
        {
            clsDES = 系统服务.ClsDES.Instance();
            系统服务.ClsBaseDataInfo.sSnInfo = clsDES.Encrypt(系统服务.ClsBaseDataInfo.sComName);

            if (sSN.Trim() != 系统服务.ClsBaseDataInfo.sSnInfo.Trim())
            {
                MessageBox.Show("请使用正确的注册码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            return true;
        }

        int iBtnType = 0;
        private void SetTree()
        {
            try
            {
                string sSQL2 = @"select count(*) from dbo._UserRoleInfo where vchrRoleID = 'administrator' and vchrUserID = '" + 系统服务.ClsBaseDataInfo.sUid + "'";
                string sSQL;
                if (系统服务.ClsBaseDataInfo.sUid == "admin" || 系统服务.ClsBaseDataInfo.sUid == "system")
                {
                    sSQL = "SELECT TOP 100 PERCENT * FROM dbo._Form WHERE (1 = 1) AND (fbitNoUse = 0) AND (fbitHide = 0) and (vchrFormBel='" + 系统服务.ClsBaseDataInfo.sProForm + "' or vchrFormBel is null)  ORDER BY fIntOrderID";
                }
                else if (Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL2)) != 0)
                {
                    sSQL = "SELECT TOP 100 PERCENT * FROM dbo._Form WHERE (isnull(bUse,0) = 1) AND (fbitNoUse = 0) AND (fbitHide = 0) and (vchrFormBel='" + 系统服务.ClsBaseDataInfo.sProForm + "' or vchrFormBel is null)  ORDER BY fIntOrderID"; 
                }
                else
                {
                    sSQL = "SELECT DISTINCT " +
                                "      dbo._Form.fchrFrmNameID, dbo._Form.fchrFrmText, dbo._Form.fchrNameSpace,  " +
                                "	  dbo._Form.fchrFrmUpName,  " +
                                "      dbo._Form.fbitHide, dbo._Form.fbitNoUse, dbo._Form.fIntOrderID " +
                                "FROM         dbo._RoleInfo INNER JOIN " +
                                "      dbo._RoleRight ON dbo._RoleInfo.vchrRoleID = dbo._RoleRight.vchrRoleID INNER JOIN " +
                                "      dbo._UserRoleInfo ON dbo._RoleInfo.vchrRoleID = dbo._UserRoleInfo.vchrRoleID and dbo._UserRoleInfo.vchrUserID='" + 系统服务.ClsBaseDataInfo.sUid + "' INNER JOIN " +
                                "      dbo._Form ON 1=1 " +
                                "		 AND dbo._Form.fchrFrmNameID = RTRIM(LTRIM(RIGHT(dbo._RoleRight.vchrRoleRight, LEN(dbo._RoleRight.vchrRoleRight) - CHARINDEX('|', dbo._RoleRight.vchrRoleRight)))) " +
                                "WHERE (isnull(bUse,0) = 1) AND (fbitNoUse = 0) AND (fbitHide = 0) and (vchrFormBel='" + 系统服务.ClsBaseDataInfo.sProForm + "' or vchrFormBel is null)  " +
                                "ORDER BY fIntOrderID ";
                }
                dt = clsSQLCommond.ExecQuery(sSQL);

                if (iBtnType == 0)
                {
                    InitTree(treView.Nodes, "业务工作");
                }
                if (iBtnType == 1)
                {
                    InitTree(treView.Nodes, "基础设置");
                }
                if (iBtnType == 2)
                {
                    InitTree(treView.Nodes, "系统服务");
                }
            }
            catch(Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }

        /// <summary>
        /// 登陆
        /// </summary>
        /// <returns></returns>
        private bool Login()
        {
            系统服务.FrmLogin frmLogin = new 系统服务.FrmLogin();
            frmLogin.ShowDialog();
            if (frmLogin.DialogResult != DialogResult.OK)
            {
                return false;
            }
            else
                return true;
        }

        #region 创建功能树
        /// <summary>
        /// 创建功能树
        /// </summary>
        /// <param name="Nds"></param>
        /// <param name="parentId"></param>
        private void InitTree(TreeNodeCollection Nds, string parentId)
        {
            try
            {
                DataView dv = new DataView();
                TreeNode tmpNd;
                string intId;
                dv.Table = dt;
                dv.RowFilter = "fchrFrmUpName='" + parentId + "'";
                foreach (DataRowView drv in dv)
                {
                    tmpNd = new TreeNode();
                    tmpNd.Name = drv["fchrFrmNameID"].ToString().Trim();
                    tmpNd.Text = drv["fchrFrmText"].ToString().Trim();
                    tmpNd.Tag = drv["fchrFrmNameID"].ToString().Trim();
                    Nds.Add(tmpNd);
                    intId = drv["fchrFrmUpName"].ToString().Trim();
                    InitTree(tmpNd.Nodes, tmpNd.Name);
                }
            }
            catch
            {
                throw new Exception("创建功能树失败！");
            }
        }
        #endregion

        #region  窗体样式
        /// <summary>
        /// 窗体样式设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setWinMode_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BarButtonItem item = (BarButtonItem)e.Item;
            switch (int.Parse(item.Tag.ToString()))
            {
                case 0:
                    myLF.LookAndFeel.UseWindowsXPTheme = false;
                    myLF.LookAndFeel.UseDefaultLookAndFeel = false;
                    myLF.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
                    break;
                case 1:
                    myLF.LookAndFeel.UseWindowsXPTheme = false;
                    myLF.LookAndFeel.UseDefaultLookAndFeel = false;
                    myLF.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
                    break;
                case 2:
                    myLF.LookAndFeel.UseWindowsXPTheme = false;
                    myLF.LookAndFeel.UseDefaultLookAndFeel = false;
                    myLF.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
                    break;
                case 3:
                    myLF.LookAndFeel.UseWindowsXPTheme = false;
                    myLF.LookAndFeel.UseDefaultLookAndFeel = false;
                    myLF.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
                    break;
                case 4:
                    myLF.LookAndFeel.UseDefaultLookAndFeel = false;
                    myLF.LookAndFeel.UseWindowsXPTheme = true;
                    break;
                case 5:
                    myLF.LookAndFeel.UseWindowsXPTheme = false;
                    myLF.LookAndFeel.UseDefaultLookAndFeel = false;
                    myLF.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
                    break;
                default:
                    myLF.LookAndFeel.UseWindowsXPTheme = false;
                    myLF.LookAndFeel.UseDefaultLookAndFeel = true;
                    break;
            }

            treView.BackColor = this.BackColor;

            SetChildWindowLookAndFeel();
        }

        /// <summary>
        /// 设置子窗体样式
        /// </summary>
        private void SetChildWindowLookAndFeel()
        {
            foreach (KeyValuePair<string, Form> pair in m_FormList)
            {
                系统服务.FrmBaseInfo frm = (系统服务.FrmBaseInfo)pair.Value;

                frm.SetLookAndFeel(myLF.LookAndFeel);
            }
        }

        /// <summary>
        /// 设置皮肤
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetSkin_ItemClick(object sender, ItemClickEventArgs e)
        {
            BarButtonItem item = (BarButtonItem)e.Item;

            myLF.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
            myLF.LookAndFeel.SkinName = item.Caption;

            SetChildWindowLookAndFeel();
        }
        #endregion

        private void treView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
           
            try
            {
                Cls时间锁 cls = new Cls时间锁();
                if (cls.bchk时间锁() == false)
                {
                    throw new Exception("加载数据失败");
                }
                if (e.Node.Name.Trim() != null)
                {
                    string sName = e.Node.Name.Trim();
                    string sText = e.Node.Text.Trim();
                    if (sName.Trim().Length < 4)
                        return;

                    if ("frm" == sName.Substring(0, 3).ToLower())
                    {
                        CreateFormInstance(sName, sText);
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        
        private void xtraTabbedMdiManager2_SelectedPageChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.ActiveMdiChild == null)
                    return;

                
                frmBase = (系统服务.FrmBaseInfo)this.ActiveMdiChild;
                bindingSource1.DataSource = frmBase.dtBind;
                
                lbActForm.Caption = "当前窗体：" + frmBase.Text + "\t";

                frmBase.WindowState = FormWindowState.Normal;
            }
            catch (Exception ee)
            {
                MessageBox.Show("出现错误!\n\n\t错误信息如下:\n\t" + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

     
        private void barbtnExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            Application.Exit();
        }

        private void btnUpdate_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                DialogResult drRes = MessageBox.Show("升级将关闭当前程序！\n\n  是(Y) 升级，否(N) 取消", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (drRes == DialogResult.Yes)
                {
                    Application.Exit();


                    System.Diagnostics.Process.Start("UpdateApp.exe");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("升级程序失败!\n\n\t错误信息如下:\n\t" + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFunInfo_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                treView.Nodes.Clear();

                //iBtnType = 0;
                //dockPanel1.Text = "业务工作";
                if (dockPanel1.Text == "业务工作")
                    iBtnType = 0;
                if (dockPanel1.Text == "基础档案")
                    iBtnType = 1;
                if (dockPanel1.Text == "系统服务")
                    iBtnType = 2;
                SetTree();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message,"提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            treView.Nodes.Clear();
            iBtnType = 2;
            SetTree();
            dockPanel1.Text = "系统服务";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            treView.Nodes.Clear();
            iBtnType = 1;
            SetTree();
            dockPanel1.Text = "基础档案";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            treView.Nodes.Clear();
            iBtnType = 0;
            SetTree();
            dockPanel1.Text = "业务工作";
        }

        private void MdiMain_SizeChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (this.WindowState == FormWindowState.Minimized)  //判断是否最小化
            //    {
            //        this.ShowInTaskbar = false;  //不显示在系统任务栏
            //        notifyIcon1.Visible = true;    //托盘图标可见
            //    }
            //}
            //catch (Exception ee)
            //{
            //    MessageBox.Show(ee.Message);
            //}
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            //try
            //{
            //    if (this.WindowState == FormWindowState.Minimized)
            //    {
            //        this.WindowState = FormWindowState.Maximized;  //还原窗体
            //        this.ShowInTaskbar = true;  //显示在系统任务栏
            //        notifyIcon1.Visible = false;  //托盘图标隐藏
            //    }
            //}
            //catch (Exception ee)
            //{
            //    MessageBox.Show(ee.Message);
            //}
        }

        private void MdiMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.MdiChildren.Length > 0)
            {
                if (MessageBox.Show("当前有打开的功能窗体，是否继续退出程序？\n是：退出\n否：取消", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}