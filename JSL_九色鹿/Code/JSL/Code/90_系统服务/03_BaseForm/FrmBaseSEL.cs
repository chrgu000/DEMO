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


namespace ϵͳ����
{
    public partial class FrmBaseSEL : DevExpress.XtraEditors.XtraForm
    {
        ϵͳ����.FrmProgressBar frmProgressBar = ϵͳ����.FrmProgressBar.Instance();
        protected string sUid;
        protected string sUserName;
        protected Form Frm;
        protected object clsFrm;
        protected ϵͳ����.ClsDataBase clsSQLCommond = ϵͳ����.ClsDataBaseFactory.Instance();
        protected ϵͳ����.ClsExcel clsExcel = ϵͳ����.ClsExcel.Instance();
        protected ϵͳ����.ClsGetSQL clsGetSQL = ϵͳ����.ClsGetSQL.Instance();
        protected string sState;                                //��ť״̬
        protected int iFocRow = 0;
        protected string sProPath = Application.StartupPath;    //����ִ��λ��
        protected string sLayoutHeadPath;
        protected string sLayoutGridPath;
        protected string sPrintLayOutMod;
        protected string sPrintLayOutUser;
        protected string sSQL;
        protected ArrayList aList;
        protected DataSet dsPrint = new DataSet();          //��ӡģ������Դ

        protected System.Windows.Forms.ToolStripButton toolBtn;
        protected DataSet dsForm = new DataSet();
        protected DataTable dtSel = new DataTable();        //��ҳ������Ϣ
        protected int iPage = 0;                            //��ǰҳ
        protected bool btnEnable = true;                    //���ð�ťEnable����
        DataTable dtBtnInfo;                                //��ǰ����İ�ť��Ϣ

        public DataTable dtBind;                            //�������彻������ʹ�ã��Ӵ�����Ϣ��
        protected DataTable dtBingGrid;                     //ҵ�����б���Ϣ
        protected DataTable dtBingHead;                     //ҵ�����ͷ��Ϣ


        public FrmBaseSEL()
        {
            sUid = ϵͳ����.ClsBaseDataInfo.sUid;
            sUserName = ϵͳ����.ClsBaseDataInfo.sUserName;

            sProPath = Application.StartupPath;
           
            InitializeComponent();

            toolStripMenuBtn.BackColor = this.BackColor;
        }

        /// <summary>
        /// ���ô�����ʽ
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
                MessageBox.Show("���ش���ʧ��:" + ee.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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