using System.Windows.Forms;
using System.Collections.Generic;

namespace FrameBaseFunction
{
    partial class MdiMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                if (components != null)
                    components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MdiMain));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.myLF = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.barMenu = new DevExpress.XtraBars.Bar();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barMdiMenu = new DevExpress.XtraBars.Bar();
            this.barInfo1 = new DevExpress.XtraBars.BarSubItem();
            this.barInfo11 = new DevExpress.XtraBars.BarSubItem();
            this.barInfo111 = new DevExpress.XtraBars.BarButtonItem();
            this.barInfo112 = new DevExpress.XtraBars.BarButtonItem();
            this.barInfo113 = new DevExpress.XtraBars.BarButtonItem();
            this.barInfo114 = new DevExpress.XtraBars.BarButtonItem();
            this.barInfo115 = new DevExpress.XtraBars.BarButtonItem();
            this.barInfo116 = new DevExpress.XtraBars.BarButtonItem();
            this.barInfo117 = new DevExpress.XtraBars.BarButtonItem();
            this.barInfo12 = new DevExpress.XtraBars.BarSubItem();
            this.barInfo121 = new DevExpress.XtraBars.BarButtonItem();
            this.barInfo122 = new DevExpress.XtraBars.BarButtonItem();
            this.barInfo123 = new DevExpress.XtraBars.BarButtonItem();
            this.barInfo124 = new DevExpress.XtraBars.BarButtonItem();
            this.barInfo125 = new DevExpress.XtraBars.BarButtonItem();
            this.barInfo126 = new DevExpress.XtraBars.BarButtonItem();
            this.barInfo127 = new DevExpress.XtraBars.BarButtonItem();
            this.btnFunInfo = new DevExpress.XtraBars.BarButtonItem();
            this.btnUpdate = new DevExpress.XtraBars.BarButtonItem();
            this.barInfo13 = new DevExpress.XtraBars.BarButtonItem();
            this.barInfo2 = new DevExpress.XtraBars.BarMdiChildrenListItem();
            this.barButton = new DevExpress.XtraBars.Bar();
            this.lbComName = new DevExpress.XtraBars.BarLargeButtonItem();
            this.lbAcc = new DevExpress.XtraBars.BarLargeButtonItem();
            this.lbLogDate = new DevExpress.XtraBars.BarLargeButtonItem();
            this.lbUid = new DevExpress.XtraBars.BarLargeButtonItem();
            this.lAccInfo = new DevExpress.XtraBars.BarLargeButtonItem();
            this.lVerInfo = new DevExpress.XtraBars.BarLargeButtonItem();
            this.lbActForm = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.btn3 = new DevExpress.XtraEditors.SimpleButton();
            this.btn2 = new DevExpress.XtraEditors.SimpleButton();
            this.btn1 = new DevExpress.XtraEditors.SimpleButton();
            this.treView = new System.Windows.Forms.TreeView();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.barEditItem2 = new DevExpress.XtraBars.BarEditItem();
            this.btnAudit = new DevExpress.XtraBars.BarButtonItem();
            this.btnUnAudit = new DevExpress.XtraBars.BarButtonItem();
            this.btnFirst = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrevious = new DevExpress.XtraBars.BarButtonItem();
            this.btnNext = new DevExpress.XtraBars.BarButtonItem();
            this.btnLast = new DevExpress.XtraBars.BarButtonItem();
            this.btnAddRow = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelRow = new DevExpress.XtraBars.BarButtonItem();
            this.btnAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnDel = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem18 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem19 = new DevExpress.XtraBars.BarButtonItem();
            this.btnSel = new DevExpress.XtraBars.BarButtonItem();
            this.btnExit = new DevExpress.XtraBars.BarButtonItem();
            this.barEditItem3 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.barEditItem4 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemPictureEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemPictureEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.repositoryItemImageEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.m_MenuBDSource = new System.Windows.Forms.BindingSource(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_MenuBDSource)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folderOpened.ico");
            this.imageList1.Images.SetKeyName(1, "folderClosed.ico");
            // 
            // barMenu
            // 
            this.barMenu.BarName = "barMenu";
            this.barMenu.DockCol = 0;
            this.barMenu.DockRow = 0;
            this.barMenu.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMenu.FloatLocation = new System.Drawing.Point(106, 150);
            this.barMenu.FloatSize = new System.Drawing.Size(46, 24);
            this.barMenu.OptionsBar.AllowQuickCustomization = false;
            this.barMenu.OptionsBar.UseWholeRow = true;
            this.barMenu.Text = "菜单";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barMdiMenu,
            this.barButton});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.DockManager = this.dockManager1;
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barInfo1,
            this.barInfo11,
            this.barInfo111,
            this.barInfo112,
            this.barInfo113,
            this.barInfo114,
            this.barInfo115,
            this.barInfo116,
            this.barInfo117,
            this.barInfo12,
            this.barInfo121,
            this.barInfo122,
            this.barInfo123,
            this.barInfo124,
            this.barInfo125,
            this.barInfo126,
            this.barInfo127,
            this.barInfo2,
            this.barEditItem1,
            this.barEditItem2,
            this.lbComName,
            this.lbAcc,
            this.lbLogDate,
            this.lbActForm,
            this.btnAudit,
            this.btnUnAudit,
            this.btnFirst,
            this.btnPrevious,
            this.btnNext,
            this.btnLast,
            this.btnAddRow,
            this.btnDelRow,
            this.btnAdd,
            this.btnEdit,
            this.btnDel,
            this.barButtonItem18,
            this.barButtonItem19,
            this.btnSel,
            this.btnExit,
            this.barInfo13,
            this.lbUid,
            this.btnUpdate,
            this.btnFunInfo,
            this.lVerInfo,
            this.barEditItem3,
            this.barEditItem4,
            this.lAccInfo});
            this.barManager1.MainMenu = this.barMdiMenu;
            this.barManager1.MaxItemId = 97;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit2,
            this.repositoryItemTextEdit1,
            this.repositoryItemTextEdit3,
            this.repositoryItemTextEdit4,
            this.repositoryItemTextEdit5,
            this.repositoryItemPictureEdit1,
            this.repositoryItemPictureEdit2,
            this.repositoryItemImageEdit1,
            this.repositoryItemPictureEdit3});
            this.barManager1.StatusBar = this.barButton;
            // 
            // barMdiMenu
            // 
            this.barMdiMenu.BarName = "Custom 1";
            this.barMdiMenu.DockCol = 0;
            this.barMdiMenu.DockRow = 0;
            this.barMdiMenu.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMdiMenu.FloatLocation = new System.Drawing.Point(169, 162);
            this.barMdiMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barInfo1, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barInfo2)});
            this.barMdiMenu.OptionsBar.AllowQuickCustomization = false;
            this.barMdiMenu.OptionsBar.MultiLine = true;
            this.barMdiMenu.OptionsBar.UseWholeRow = true;
            this.barMdiMenu.Text = "Custom 1";
            // 
            // barInfo1
            // 
            this.barInfo1.Caption = "系统(&S)";
            this.barInfo1.Id = 0;
            this.barInfo1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barInfo11),
            new DevExpress.XtraBars.LinkPersistInfo(this.barInfo12),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnFunInfo, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnUpdate),
            new DevExpress.XtraBars.LinkPersistInfo(this.barInfo13)});
            this.barInfo1.Name = "barInfo1";
            // 
            // barInfo11
            // 
            this.barInfo11.Caption = "窗口样式";
            this.barInfo11.Id = 1;
            this.barInfo11.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barInfo111),
            new DevExpress.XtraBars.LinkPersistInfo(this.barInfo112),
            new DevExpress.XtraBars.LinkPersistInfo(this.barInfo113),
            new DevExpress.XtraBars.LinkPersistInfo(this.barInfo114),
            new DevExpress.XtraBars.LinkPersistInfo(this.barInfo115),
            new DevExpress.XtraBars.LinkPersistInfo(this.barInfo116),
            new DevExpress.XtraBars.LinkPersistInfo(this.barInfo117)});
            this.barInfo11.Name = "barInfo11";
            // 
            // barInfo111
            // 
            this.barInfo111.Caption = "Office样式";
            this.barInfo111.Id = 2;
            this.barInfo111.Name = "barInfo111";
            this.barInfo111.Tag = "0";
            this.barInfo111.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.setWinMode_Click);
            // 
            // barInfo112
            // 
            this.barInfo112.Caption = "扁平样式";
            this.barInfo112.Id = 3;
            this.barInfo112.Name = "barInfo112";
            this.barInfo112.Tag = "1";
            this.barInfo112.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.setWinMode_Click);
            // 
            // barInfo113
            // 
            this.barInfo113.Caption = "超平样式";
            this.barInfo113.Id = 4;
            this.barInfo113.Name = "barInfo113";
            this.barInfo113.Tag = "2";
            this.barInfo113.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.setWinMode_Click);
            // 
            // barInfo114
            // 
            this.barInfo114.Caption = "3D样式";
            this.barInfo114.Id = 5;
            this.barInfo114.Name = "barInfo114";
            this.barInfo114.Tag = "3";
            this.barInfo114.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.setWinMode_Click);
            // 
            // barInfo115
            // 
            this.barInfo115.Caption = "XP样式";
            this.barInfo115.Id = 6;
            this.barInfo115.Name = "barInfo115";
            this.barInfo115.Tag = "4";
            this.barInfo115.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.setWinMode_Click);
            // 
            // barInfo116
            // 
            this.barInfo116.Caption = "使用皮肤";
            this.barInfo116.Id = 7;
            this.barInfo116.Name = "barInfo116";
            this.barInfo116.Tag = "5";
            this.barInfo116.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.setWinMode_Click);
            // 
            // barInfo117
            // 
            this.barInfo117.Caption = "使用默认";
            this.barInfo117.Id = 8;
            this.barInfo117.Name = "barInfo117";
            this.barInfo117.Tag = "6";
            this.barInfo117.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.setWinMode_Click);
            // 
            // barInfo12
            // 
            this.barInfo12.Caption = "皮肤";
            this.barInfo12.Id = 9;
            this.barInfo12.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barInfo121),
            new DevExpress.XtraBars.LinkPersistInfo(this.barInfo122),
            new DevExpress.XtraBars.LinkPersistInfo(this.barInfo123),
            new DevExpress.XtraBars.LinkPersistInfo(this.barInfo124),
            new DevExpress.XtraBars.LinkPersistInfo(this.barInfo125),
            new DevExpress.XtraBars.LinkPersistInfo(this.barInfo126),
            new DevExpress.XtraBars.LinkPersistInfo(this.barInfo127)});
            this.barInfo12.Name = "barInfo12";
            // 
            // barInfo121
            // 
            this.barInfo121.Caption = "Caramel";
            this.barInfo121.Id = 10;
            this.barInfo121.Name = "barInfo121";
            this.barInfo121.Tag = "0";
            this.barInfo121.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.SetSkin_ItemClick);
            // 
            // barInfo122
            // 
            this.barInfo122.Caption = "The Asphalt World";
            this.barInfo122.Id = 11;
            this.barInfo122.Name = "barInfo122";
            this.barInfo122.Tag = "1";
            this.barInfo122.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.SetSkin_ItemClick);
            // 
            // barInfo123
            // 
            this.barInfo123.Caption = "Liquid Sky";
            this.barInfo123.Id = 12;
            this.barInfo123.Name = "barInfo123";
            this.barInfo123.Tag = "2";
            this.barInfo123.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.SetSkin_ItemClick);
            // 
            // barInfo124
            // 
            this.barInfo124.Caption = "Coffee";
            this.barInfo124.Id = 13;
            this.barInfo124.Name = "barInfo124";
            this.barInfo124.Tag = "3";
            this.barInfo124.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.SetSkin_ItemClick);
            // 
            // barInfo125
            // 
            this.barInfo125.Caption = "Stardust";
            this.barInfo125.Id = 14;
            this.barInfo125.Name = "barInfo125";
            this.barInfo125.Tag = "4";
            this.barInfo125.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.SetSkin_ItemClick);
            // 
            // barInfo126
            // 
            this.barInfo126.Caption = "Glass Oceans";
            this.barInfo126.Id = 15;
            this.barInfo126.Name = "barInfo126";
            this.barInfo126.Tag = "5";
            this.barInfo126.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.SetSkin_ItemClick);
            // 
            // barInfo127
            // 
            this.barInfo127.Caption = "Money Twins";
            this.barInfo127.Id = 16;
            this.barInfo127.Name = "barInfo127";
            this.barInfo127.Tag = "6";
            this.barInfo127.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.SetSkin_ItemClick);
            // 
            // btnFunInfo
            // 
            this.btnFunInfo.Caption = "刷新功能菜单";
            this.btnFunInfo.Id = 83;
            this.btnFunInfo.Name = "btnFunInfo";
            this.btnFunInfo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFunInfo_ItemClick);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Caption = "程序升级";
            this.btnUpdate.Id = 82;
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnUpdate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUpdate_ItemClick);
            // 
            // barInfo13
            // 
            this.barInfo13.Caption = "退出";
            this.barInfo13.Id = 64;
            this.barInfo13.Name = "barInfo13";
            this.barInfo13.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnExit_ItemClick);
            // 
            // barInfo2
            // 
            this.barInfo2.Caption = "窗体(&F)";
            this.barInfo2.Id = 18;
            this.barInfo2.Name = "barInfo2";
            // 
            // barButton
            // 
            this.barButton.BarName = "Custom 2";
            this.barButton.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.barButton.DockCol = 0;
            this.barButton.DockRow = 0;
            this.barButton.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.barButton.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.lbComName),
            new DevExpress.XtraBars.LinkPersistInfo(this.lbAcc),
            new DevExpress.XtraBars.LinkPersistInfo(this.lbLogDate),
            new DevExpress.XtraBars.LinkPersistInfo(this.lbUid),
            new DevExpress.XtraBars.LinkPersistInfo(this.lAccInfo),
            new DevExpress.XtraBars.LinkPersistInfo(this.lVerInfo),
            new DevExpress.XtraBars.LinkPersistInfo(this.lbActForm)});
            this.barButton.OptionsBar.AllowQuickCustomization = false;
            this.barButton.OptionsBar.DrawDragBorder = false;
            this.barButton.OptionsBar.UseWholeRow = true;
            this.barButton.Text = "Custom 2";
            // 
            // lbComName
            // 
            this.lbComName.Caption = "lbComName";
            this.lbComName.Id = 35;
            this.lbComName.Name = "lbComName";
            // 
            // lbAcc
            // 
            this.lbAcc.Caption = "lbAcc";
            this.lbAcc.Id = 36;
            this.lbAcc.Name = "lbAcc";
            // 
            // lbLogDate
            // 
            this.lbLogDate.Caption = "lbLogDate";
            this.lbLogDate.Id = 37;
            this.lbLogDate.Name = "lbLogDate";
            // 
            // lbUid
            // 
            this.lbUid.Caption = "帐号";
            this.lbUid.Id = 81;
            this.lbUid.Name = "lbUid";
            // 
            // lAccInfo
            // 
            this.lAccInfo.Caption = "AccInfo";
            this.lAccInfo.Id = 96;
            this.lAccInfo.Name = "lAccInfo";
            // 
            // lVerInfo
            // 
            this.lVerInfo.Caption = "lVerInfo";
            this.lVerInfo.Id = 89;
            this.lVerInfo.Name = "lVerInfo";
            // 
            // lbActForm
            // 
            this.lbActForm.Caption = "当前窗体";
            this.lbActForm.Id = 38;
            this.lbActForm.Name = "lbActForm";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(664, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 375);
            this.barDockControlBottom.Size = new System.Drawing.Size(664, 27);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 351);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(664, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 351);
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.MenuManager = this.barManager1;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel1});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "System.Windows.Forms.StatusBar"});
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel1.ID = new System.Guid("1caa98af-f1f2-48fb-baf0-5d50991a4426");
            this.dockPanel1.Location = new System.Drawing.Point(0, 24);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanel1.Size = new System.Drawing.Size(200, 351);
            this.dockPanel1.Text = "系统菜单";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.btn3);
            this.dockPanel1_Container.Controls.Add(this.btn2);
            this.dockPanel1_Container.Controls.Add(this.btn1);
            this.dockPanel1_Container.Controls.Add(this.treView);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(192, 324);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // btn3
            // 
            this.btn3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btn3.Location = new System.Drawing.Point(0, 251);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(192, 23);
            this.btn3.TabIndex = 4;
            this.btn3.Text = "业务工作";
            this.btn3.Click += new System.EventHandler(this.btn3_Click);
            // 
            // btn2
            // 
            this.btn2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btn2.Location = new System.Drawing.Point(0, 274);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(192, 23);
            this.btn2.TabIndex = 3;
            this.btn2.Text = "基础设置";
            this.btn2.Click += new System.EventHandler(this.btn2_Click);
            // 
            // btn1
            // 
            this.btn1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btn1.Location = new System.Drawing.Point(0, 297);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(192, 23);
            this.btn1.TabIndex = 2;
            this.btn1.Text = "系统服务";
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // treView
            // 
            this.treView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treView.ImageIndex = 1;
            this.treView.ImageList = this.imageList1;
            this.treView.Location = new System.Drawing.Point(0, 0);
            this.treView.Name = "treView";
            this.treView.SelectedImageIndex = 0;
            this.treView.Size = new System.Drawing.Size(192, 249);
            this.treView.TabIndex = 1;
            this.treView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treView_NodeMouseClick);
            // 
            // barEditItem1
            // 
            this.barEditItem1.Edit = null;
            this.barEditItem1.Id = 33;
            this.barEditItem1.Name = "barEditItem1";
            // 
            // barEditItem2
            // 
            this.barEditItem2.Edit = null;
            this.barEditItem2.Id = 34;
            this.barEditItem2.Name = "barEditItem2";
            // 
            // btnAudit
            // 
            this.btnAudit.Id = 65;
            this.btnAudit.Name = "btnAudit";
            // 
            // btnUnAudit
            // 
            this.btnUnAudit.Id = 66;
            this.btnUnAudit.Name = "btnUnAudit";
            // 
            // btnFirst
            // 
            this.btnFirst.Id = 67;
            this.btnFirst.Name = "btnFirst";
            // 
            // btnPrevious
            // 
            this.btnPrevious.Id = 68;
            this.btnPrevious.Name = "btnPrevious";
            // 
            // btnNext
            // 
            this.btnNext.Id = 69;
            this.btnNext.Name = "btnNext";
            // 
            // btnLast
            // 
            this.btnLast.Id = 70;
            this.btnLast.Name = "btnLast";
            // 
            // btnAddRow
            // 
            this.btnAddRow.Id = 71;
            this.btnAddRow.Name = "btnAddRow";
            // 
            // btnDelRow
            // 
            this.btnDelRow.Id = 72;
            this.btnDelRow.Name = "btnDelRow";
            // 
            // btnAdd
            // 
            this.btnAdd.Id = 73;
            this.btnAdd.Name = "btnAdd";
            // 
            // btnEdit
            // 
            this.btnEdit.Id = 74;
            this.btnEdit.Name = "btnEdit";
            // 
            // btnDel
            // 
            this.btnDel.Id = 75;
            this.btnDel.Name = "btnDel";
            // 
            // barButtonItem18
            // 
            this.barButtonItem18.Id = 76;
            this.barButtonItem18.Name = "barButtonItem18";
            // 
            // barButtonItem19
            // 
            this.barButtonItem19.Id = 77;
            this.barButtonItem19.Name = "barButtonItem19";
            // 
            // btnSel
            // 
            this.btnSel.Id = 78;
            this.btnSel.Name = "btnSel";
            // 
            // btnExit
            // 
            this.btnExit.Id = 79;
            this.btnExit.Name = "btnExit";
            // 
            // barEditItem3
            // 
            this.barEditItem3.Caption = "barEditItem3";
            this.barEditItem3.Edit = this.repositoryItemPictureEdit1;
            this.barEditItem3.Id = 91;
            this.barEditItem3.Name = "barEditItem3";
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            // 
            // barEditItem4
            // 
            this.barEditItem4.Caption = "barEditItem4";
            this.barEditItem4.Edit = this.repositoryItemPictureEdit3;
            this.barEditItem4.Id = 94;
            this.barEditItem4.Name = "barEditItem4";
            // 
            // repositoryItemPictureEdit3
            // 
            this.repositoryItemPictureEdit3.Name = "repositoryItemPictureEdit3";
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // repositoryItemTextEdit3
            // 
            this.repositoryItemTextEdit3.AutoHeight = false;
            this.repositoryItemTextEdit3.Name = "repositoryItemTextEdit3";
            // 
            // repositoryItemTextEdit4
            // 
            this.repositoryItemTextEdit4.AutoHeight = false;
            this.repositoryItemTextEdit4.Name = "repositoryItemTextEdit4";
            // 
            // repositoryItemTextEdit5
            // 
            this.repositoryItemTextEdit5.AutoHeight = false;
            this.repositoryItemTextEdit5.Name = "repositoryItemTextEdit5";
            // 
            // repositoryItemPictureEdit2
            // 
            this.repositoryItemPictureEdit2.Name = "repositoryItemPictureEdit2";
            this.repositoryItemPictureEdit2.PictureStoreMode = DevExpress.XtraEditors.Controls.PictureStoreMode.Image;
            this.repositoryItemPictureEdit2.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            // 
            // repositoryItemImageEdit1
            // 
            this.repositoryItemImageEdit1.AutoHeight = false;
            this.repositoryItemImageEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageEdit1.Name = "repositoryItemImageEdit1";
            // 
            // bar3
            // 
            this.bar3.BarName = "Custom 5";
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 2;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnFirst, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPrevious),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnNext),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnLast)});
            this.bar3.Text = "Custom 5";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // MdiMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 402);
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MdiMain";
            this.Text = " ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMdiMain_Load);
            this.SizeChanged += new System.EventHandler(this.MdiMain_SizeChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MdiMain_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_MenuBDSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.LookAndFeel.DefaultLookAndFeel myLF;
        public DevExpress.XtraBars.Bar barMenu;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar barMdiMenu;
        private DevExpress.XtraBars.BarSubItem barInfo1;
        private DevExpress.XtraBars.BarSubItem barInfo11;
        private DevExpress.XtraBars.BarButtonItem barInfo111;
        private DevExpress.XtraBars.BarButtonItem barInfo112;
        private DevExpress.XtraBars.BarButtonItem barInfo113;
        private DevExpress.XtraBars.BarButtonItem barInfo114;
        private DevExpress.XtraBars.BarButtonItem barInfo115;
        private DevExpress.XtraBars.BarButtonItem barInfo116;
        private DevExpress.XtraBars.BarButtonItem barInfo117;
        private DevExpress.XtraBars.BarSubItem barInfo12;
        private DevExpress.XtraBars.BarButtonItem barInfo121;
        private DevExpress.XtraBars.BarButtonItem barInfo122;
        private DevExpress.XtraBars.BarButtonItem barInfo123;
        private DevExpress.XtraBars.BarButtonItem barInfo124;
        private DevExpress.XtraBars.BarButtonItem barInfo125;
        private DevExpress.XtraBars.BarButtonItem barInfo126;
        private DevExpress.XtraBars.BarButtonItem barInfo127;

        private Dictionary<string, Form> m_FormList;
        private ImageList imageList1;
        private DevExpress.XtraBars.BarMdiChildrenListItem barInfo2;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraBars.BarEditItem barEditItem2;
        private DevExpress.XtraBars.Bar barButton;
        private DevExpress.XtraBars.BarLargeButtonItem lbComName;
        private DevExpress.XtraBars.BarLargeButtonItem lbAcc;
        private DevExpress.XtraBars.BarLargeButtonItem lbLogDate;
        private DevExpress.XtraBars.BarLargeButtonItem lbActForm;
        private DevExpress.XtraBars.BarButtonItem btnAudit;
        private DevExpress.XtraBars.BarButtonItem btnUnAudit;
        private DevExpress.XtraBars.BarButtonItem btnFirst;
        private DevExpress.XtraBars.BarButtonItem btnPrevious;
        private DevExpress.XtraBars.BarButtonItem btnNext;
        private DevExpress.XtraBars.BarButtonItem btnLast;
        private DevExpress.XtraBars.BarButtonItem btnAddRow;
        private DevExpress.XtraBars.BarButtonItem btnDelRow;
        private BindingSource bindingSource1;
        private DevExpress.XtraBars.BarButtonItem btnAdd;
        private DevExpress.XtraBars.BarButtonItem btnEdit;
        private DevExpress.XtraBars.BarButtonItem btnDel;
        private DevExpress.XtraBars.BarButtonItem barButtonItem18;
        private DevExpress.XtraBars.BarButtonItem barButtonItem19;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarButtonItem btnSel;
        private DevExpress.XtraBars.BarButtonItem btnExit;
        private DevExpress.XtraBars.BarButtonItem barInfo13;
        private DevExpress.XtraBars.BarLargeButtonItem lbUid;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraBars.BarButtonItem btnUpdate;
        private DevExpress.XtraBars.BarButtonItem btnFunInfo;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraBars.BarLargeButtonItem lVerInfo;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit4;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit5;
        private BindingSource m_MenuBDSource;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit2;
        private DevExpress.XtraBars.BarEditItem barEditItem3;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit1;
        private DevExpress.XtraBars.BarEditItem barEditItem4;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit3;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private TreeView treView;
        private DevExpress.XtraBars.BarLargeButtonItem lAccInfo;
        private DevExpress.XtraEditors.SimpleButton btn3;
        private DevExpress.XtraEditors.SimpleButton btn2;
        private DevExpress.XtraEditors.SimpleButton btn1;
        private NotifyIcon notifyIcon1;
    }
}

