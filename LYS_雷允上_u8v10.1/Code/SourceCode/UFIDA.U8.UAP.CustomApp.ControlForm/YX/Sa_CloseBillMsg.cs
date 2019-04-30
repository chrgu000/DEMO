using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TH.BaseClass;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class Sa_CloseBillMsg : Form
    {
        public string str = "";
        System.Xml.XmlDocument doc;

        public Sa_CloseBillMsg(string sstr,System.Xml.XmlDocument sdoc)
        {
           
            InitializeComponent();
            str = sstr;
            doc = sdoc;
        }

        public Sa_CloseBillMsg()
        {
            InitializeComponent();

            #region 禁止用户调整表格

            layoutControl1.AllowCustomizationMenu = false;

            //gridView1.OptionsMenu.EnableColumnMenu = false;
            //gridView1.OptionsMenu.EnableFooterMenu = false;
            //gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            //gridView1.OptionsMenu.ShowAutoFilterRowItem = false;
            //gridView1.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            //gridView1.OptionsMenu.ShowGroupSortSummaryItems = false;
            //gridView1.OptionsMenu.ShowGroupSummaryEditorItem = false;
            //gridView1.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.False;
            //gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            //gridView1.OptionsCustomization.AllowColumnMoving = false;
            //gridView1.OptionsCustomization.

            #endregion
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Sa_CloseBillMsg_Load(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.Text = str;
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败：" + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sa = new SaveFileDialog();
            sa.Filter = "xml files(*.xml)|*.xml|所有文件(*.*)|*.*";
            sa.FileName = "收款单导出";
            DialogResult d = sa.ShowDialog();
            string sPath = sa.FileName;
            if (d == DialogResult.OK)
            {
                if (sPath != "")
                {
                    doc.Save(sPath);
                    MessageBox.Show("导出列表成功！\n路径：" + sPath);
                }
                else
                {
                    MessageBox.Show("请选择导出路径");
                }
            }
        }

    }
}
