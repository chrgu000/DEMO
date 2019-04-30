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

namespace FrameBaseFunction
{
    public partial  class MdiMain : Form
    {
        bool bIsLogined = false;
        FrameBaseFunction.FrmBaseInfo frmBase;
        DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager();
        FrameBaseFunction.ClsDataBase clsSQLCommond;
        FrameBaseFunction.ClsDES clsDES;
        bool isUpdate = false;  //默认不需要更新

        public MdiMain()
        {
            InitInfo();

            InitializeComponent();

            isUpdate = CheckNeedUpdate();

            if (isUpdate)
            {
                MessageBox.Show("程序需要更新！", "提示");
                Application.Exit();

                System.Diagnostics.Process.Start(Application.StartupPath + @"\AutoUpdate.exe");

                return;
            }

            m_FormList = new Dictionary<string, Form>();



            if (Login())
                bIsLogined = true;
            else
                bIsLogined = false;

            clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();

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
                FrameBaseFunction.ClsBaseDataInfo.sWebURL = GetConfigValue(sPathConfig, "WebURL");
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
                dv.Table = dtMdiMainTree;
                dv.RowFilter = "fchrFrmNameID='" + proFunNO + "'";
                proNameSpace = dv.ToTable().Rows[0]["fchrNameSpace"].ToString().Trim();
                bool flag = false;
                clsFormName = proFunNO;

                for (int i = 0; i < this.MdiChildren.Length; i++)
                {
                    if (this.MdiChildren[i].Tag.ToString().ToLower() == proFunNO.ToLower())
                    {
                        frmBase = (FrameBaseFunction.FrmBaseInfo)this.MdiChildren[i];

                        this.MdiChildren[i].Activate();

                        flag = true;
                        frmBase.ControlBox = false;
                        break;
                    }
                }
                if (!flag)
                {
                    FrameBaseFunction.ClsDistributeForm clsDistributeForm = new FrameBaseFunction.ClsDistributeForm();
                    frmBase = (FrameBaseFunction.FrmBaseInfo)clsDistributeForm.DistributeForm(proNameSpace, clsFormName);
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

        static DataTable dtMdiMainTree;
        private void FrmMdiMain_Load(object sender, EventArgs e)
        {
            try
            {
                //FrameBaseFunction.FrmProgressBar frmProgressBar;
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

                lbAcc.Caption = "登陆帐套：" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseText + "\t";
                lbAcc.Caption = "";
                FrameBaseFunction.ClsBaseDataInfo.sComName = sComName;
                FrameBaseFunction.ClsBaseDataInfo.sProName = sProName;

                lbComName.Caption = "" + FrameBaseFunction.ClsBaseDataInfo.sComName + "\t";
                lbLogDate.Caption = "登陆时间：" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "\t";
                lbUid.Caption = "当前帐号：" + FrameBaseFunction.ClsBaseDataInfo.sUid + "\t";
                if (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseText.Trim() != string.Empty)
                {
                    lAccInfo.Caption = "帐套号：" + "【" +FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11) + "年】" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseText.Trim() + "\t";
                }
                else
                    lAccInfo.Visibility = BarItemVisibility.Never;

                lVerInfo.Caption = "版本号：" + FrameBaseFunction.ClsBaseDataInfo.sEdition + "\t"; 

                this.Text =FrameBaseFunction.ClsBaseDataInfo.sComName + @"&" + FrameBaseFunction.ClsBaseDataInfo.sProName;

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
            clsDES = FrameBaseFunction.ClsDES.Instance();
            FrameBaseFunction.ClsBaseDataInfo.sSnInfo = clsDES.Encrypt(FrameBaseFunction.ClsBaseDataInfo.sComName);

            if (sSN.Trim() != FrameBaseFunction.ClsBaseDataInfo.sSnInfo.Trim())
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
                string sSQL2 = @"select count(*) from dbo._UserRoleInfo where vchrRoleID = 'administrator' and vchrUserID = '" + FrameBaseFunction.ClsBaseDataInfo.sUid + "'";
                string sSQL;
                if (FrameBaseFunction.ClsBaseDataInfo.sUid == "admin" || FrameBaseFunction.ClsBaseDataInfo.sUid == "system")
                {
                    sSQL = "SELECT TOP 100 PERCENT * FROM dbo._Form WHERE (1 = 1) AND (fbitNoUse = 0) AND (fbitHide = 0) and (vchrFormBel='" + FrameBaseFunction.ClsBaseDataInfo.sProForm + "' or vchrFormBel is null)  ORDER BY fIntOrderID";
                }
                else if (Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL2)) != 0)
                {
                    sSQL = "SELECT TOP 100 PERCENT * FROM dbo._Form WHERE (isnull(bUse,0) = 1) AND (fbitNoUse = 0) AND (fbitHide = 0) and (vchrFormBel='" + FrameBaseFunction.ClsBaseDataInfo.sProForm + "' or vchrFormBel is null)  ORDER BY fIntOrderID"; 
                }
                else
                {
                    sSQL = "SELECT DISTINCT " +
                                "      dbo._Form.fchrFrmNameID, dbo._Form.fchrFrmText, dbo._Form.fchrNameSpace,  " +
                                "	  dbo._Form.fchrFrmUpName,  " +
                                "      dbo._Form.fbitHide, dbo._Form.fbitNoUse, dbo._Form.fIntOrderID " +
                                "FROM         dbo._RoleInfo INNER JOIN " +
                                "      dbo._RoleRight ON dbo._RoleInfo.vchrRoleID = dbo._RoleRight.vchrRoleID INNER JOIN " +
                                "      dbo._UserRoleInfo ON dbo._RoleInfo.vchrRoleID = dbo._UserRoleInfo.vchrRoleID and dbo._UserRoleInfo.vchrUserID='" + FrameBaseFunction.ClsBaseDataInfo.sUid + "' INNER JOIN " +
                                "      dbo._Form ON 1=1 " +
                                "		 AND dbo._Form.fchrFrmNameID = RTRIM(LTRIM(RIGHT(dbo._RoleRight.vchrRoleRight, LEN(dbo._RoleRight.vchrRoleRight) - CHARINDEX('|', dbo._RoleRight.vchrRoleRight)))) " +
                                "WHERE (isnull(bUse,0) = 1) AND (fbitNoUse = 0) AND (fbitHide = 0) and (vchrFormBel='" + FrameBaseFunction.ClsBaseDataInfo.sProForm + "' or vchrFormBel is null)  " +
                                "ORDER BY fIntOrderID ";
                }
                dtMdiMainTree = clsSQLCommond.ExecQuery(sSQL);

                if (iBtnType == 0)
                {
                    InitTree(treView.Nodes, "BusinessManage");
                }
                if (iBtnType == 1)
                {
                    InitTree(treView.Nodes, "SystemSet");
                }
                if (iBtnType == 2)
                {
                    InitTree(treView.Nodes, "SystemServer");
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
            FrameBaseFunction.FrmLogin frmLogin = new FrameBaseFunction.FrmLogin();
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
                dv.Table = dtMdiMainTree;
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
                FrameBaseFunction.FrmBaseInfo frm = (FrameBaseFunction.FrmBaseInfo)pair.Value;

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

                
                frmBase = (FrameBaseFunction.FrmBaseInfo)this.ActiveMdiChild;
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

        private bool CheckNeedUpdate()
        {
            string localXmlFile = Application.StartupPath + "\\UpdateList.xml";
            string serverXmlFile = string.Empty;
            string updateUrl = string.Empty;
            string tempUpdatePath = string.Empty;
            XmlFiles updaterXmlFiles = null;
            try
            {
                //从本地读取更新配置文件信息
                updaterXmlFiles = new XmlFiles(localXmlFile);
            }
            catch
            {
                return false;
            }
            //获取服务器地址
            updateUrl = updaterXmlFiles.GetNodeValue("//Url");

            AppUpdater appUpdater = new AppUpdater();
            appUpdater.UpdaterUrl = updateUrl + "UpdateList.xml";

            //与服务器连接,下载更新配置文件
            try
            {
                tempUpdatePath = Application.StartupPath + "\\update\\";
                //tempUpdatePath = Environment.GetEnvironmentVariable("Temp") + "\\" + "_" + updaterXmlFiles.FindNode("//Application").Attributes["applicationId"].Value + "_" + "y" + "_" + "x" + "_" + "m" + "_" + "\\";

                if (!appUpdater.DownAutoUpdateFile(tempUpdatePath))
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

            //获取更新文件列表
            Hashtable htUpdateFile = new Hashtable();

            serverXmlFile = tempUpdatePath + "UpdateList.xml";
            if (!File.Exists(serverXmlFile))
            {
                return false;
            }
            int availableUpdate = 0;
            availableUpdate = appUpdater.CheckForUpdate(serverXmlFile, localXmlFile, out htUpdateFile);
            if (availableUpdate > 0)
            {
                return true;
            }
            else
            {
                return false;
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