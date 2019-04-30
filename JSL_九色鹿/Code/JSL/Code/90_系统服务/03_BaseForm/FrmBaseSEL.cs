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
//using System.Threading;


namespace 系统服务
{
    public partial class FrmBaseSEL : DevExpress.XtraEditors.XtraForm
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


        public FrmBaseSEL()
        {
            sUid = 系统服务.ClsBaseDataInfo.sUid;
            sUserName = 系统服务.ClsBaseDataInfo.sUserName;

            sProPath = Application.StartupPath;
           
            InitializeComponent();

            toolStripMenuBtn.BackColor = this.BackColor;
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

        private void FrmBaseSEL_Load(object sender, EventArgs e)
        {
            try
            {
                Frm = (Form)sender;
                clsFrm = this;

                this.BackColor = this.MdiParent.BackColor;
            }
            catch(Exception ee)
            {
                MessageBox.Show("加载窗体失败:" + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        
        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                BtnClick(e.ClickedItem.Name, e.ClickedItem.Text);

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }

        protected virtual void BtnClick(string sBtnName, string sBtnText) { }

        private void Exit_Click(object sender, EventArgs e)
        {
            //this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
        
    }
}