using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FrameBaseFunction
{
    public partial class FrmBuckUpDataBase : FrameBaseFunction.FrmFromModel
    {
        public FrmBuckUpDataBase()
        {
            InitializeComponent();
        }

        protected override void BtnClick(string sBtnName, string sBtnText)
        {
            try
            {
                switch (sBtnName.ToLower())
                {
                    case "buckup":
                        BuckUpDataBase();
                        break;
                    case "autobuckup":
                        BuckUpDataBaseAuto();
                        break;
                    default:
                        break;
                }

                if (sBtnName.ToLower() == "add" || sBtnName.ToLower() == "edit")
                {
                    SetBtnEnable(false);
                }
                else
                {
                    SetBtnEnable(true);
                    SetConEnable(false);

                    if (sBtnName.ToLower() != "btnundo")
                        richTextBox1.Text = richTextBox1.Text + "备份成功！    \n__________________________________________\n\n";
                }

            }
            catch (Exception ee)
            {
                richTextBox1.Text = richTextBox1.Text + "备份失败！    \n__________________________________________\n\n";
                MessageBox.Show(sBtnText + " 失败! \n\n原因:\n  " + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuckUpDataBaseAuto()
        {
            
        }

        private void BuckUpDataBase()
        {
            if(!chkIsSer())
                throw new Exception("备份操作只能运行在服务器中！");

            FrameBaseFunction.Query.ClsBuckUpDataBase clsBuckUp = new FrameBaseFunction.Query.ClsBuckUpDataBase();

            DateTime dTime = clsBuckUp.GetSerTime();
            string sFName = FrameBaseFunction.ClsBaseDataInfo.sDataBaseName + dTime.ToString("yyyyMMdd");//dTime.ToString("yyyyMMddHHmmss");

            SaveFileDialog sD = new SaveFileDialog();
            sD.AddExtension = false;
            sD.CheckFileExists = false;
            sD.DefaultExt = "bak";
            sD.Title = "备份数据库";

            sD.FileName = sFName;

            if (sD.ShowDialog() == DialogResult.OK)
            {

                clsBuckUp.BuckUpDataBase(sD.FileName);

                richTextBox1.Text = richTextBox1.Text + "文件名称： " + sFName + " \n\n";
                richTextBox1.Text = richTextBox1.Text + "备份路径：" + sD.FileName + "\n\n";
                richTextBox1.Text = richTextBox1.Text + "备份中，请稍候！\n\n";
            }
            else
            {
                richTextBox1.Text = richTextBox1.Text + "操作被取消！\n\n";
                throw new Exception("操作被取消！");
            }
        }

        string sHostName = "";
        string sSerName = "";

        private bool chkIsSer()
        {

            bool b = false;

            try
            {
                if (sHostName != sSerName)
                {
                    throw new Exception("备份操作只能运行在服务器中！");
                }

                b = true;
            }
            catch
            {
                throw new Exception("备份操作只能运行在服务器中！");
            }

            return b;
        }

        private void GetName()
        {
            FrameBaseFunction.Query.ClsBuckUpDataBase clsBuckUp = new FrameBaseFunction.Query.ClsBuckUpDataBase();
            DataTable dt = clsBuckUp.GetSerHostName();

            sHostName = dt.Rows[0]["sHostName"].ToString().ToLower().Trim();
            sSerName = dt.Rows[0]["sSerName"].ToString().ToLower().Trim();
        }

        private void FrmBuckUpDataBase_Load(object sender, EventArgs e)
        {
            GetName();

            richTextBox1.BackColor = this.BackColor;
            richTextBox1.Text = "备份操作只能运行在服务器上！\n\n";

            if (sSerName == sHostName)
                richTextBox1.Text = richTextBox1.Text + "验证通过可以备份！";
            else
            {
                richTextBox1.Text = richTextBox1.Text + "验证未通过，请确保在服务器中运行！";
                SetBtnEnable(false);
            }

            richTextBox1.Text = richTextBox1.Text + " \n__________________________________________\n\n";
               
        }
    }
}