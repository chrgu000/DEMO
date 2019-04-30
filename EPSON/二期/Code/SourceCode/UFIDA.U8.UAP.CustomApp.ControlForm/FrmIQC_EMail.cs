using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using TH.BaseClass;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class FrmIQC_EMail : Form
    {
        public FrmIQC_EMail()
        {
            InitializeComponent();
        }

        string sUserMailInfo;
        string sMailText;
        string aFileList;
        string sUserID;
        string sIQCNO;

        public FrmIQC_EMail(string sUidMail, string sMail, string sSubject, string sText, string sFiles, string Conn,string sUid,string sIQCNo)
        {
            InitializeComponent();

            txtEmail.Text = sMail;
            txtSubject.Text = sSubject;

            sUserMailInfo = sUidMail;
            sMailText = sText;

            aFileList = sFiles;

            btnEditAdjunct.Text = sFiles;

            sUserID = sUid;

            sIQCNO = sIQCNo;

            DbHelperSQL.connectionString = Conn;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                string sAddress = txtEmail.Text.Trim();
                if (sAddress == "")
                {
                    txtEmail.Focus();
                    throw new Exception("Please set email");
                }
                string sSubject = txtSubject.Text.Trim();
                if (sSubject == "")
                {
                    txtSubject.Focus();
                    throw new Exception("Please set subject");
                }

                if (btnEditAdjunct.Text.Trim() != "")
                {
                    string[] sFile = btnEditAdjunct.Text.Trim().Split(';');
                    decimal dSize = 0;

                    for (int i = 0; i < sFile.Length; i++)
                    {
                        if (!File.Exists(sFile[i]))
                        {
                            throw new Exception("File is not exists" + "[" + sFile[i] + "]");
                        }
                        FileInfo file = new FileInfo(sFile[i]);
                        long size = file.Length;  //文件大小。byte
                        decimal lSizeM = (decimal)size / (decimal)1024.00 / (decimal)1024.00;

                        dSize = dSize + lSizeM;
                    }
                    if (dSize > 10)
                    {
                        throw new Exception("File over size");
                    }
                }

                Model._SendIQCMail mod = new UFIDA.U8.UAP.CustomApp.ControlForm.Model._SendIQCMail();
                mod.MailAddress = sAddress;
                mod.MailAdjunct = btnEditAdjunct.Text.Trim();
                mod.MailSubject = sSubject;
                mod.MailText = sMailText;
                mod.UidCreate = sUserID;
                mod.issend = false;
                mod.IQCNo = sIQCNO;


                DAL._SendIQCMail dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._SendIQCMail();
                string sSQL = "select count(1) from  [dbo].[_SendIQCMail] where IQCNo = '{0}'";
                sSQL = string.Format(sSQL, mod.IQCNo);
                DataTable dtTemp = DbHelperSQL.Query(sSQL);
                if (BaseFunction.ReturnInt(dtTemp.Rows[0][0]) == 0)
                {
                    sSQL = dal.Add(mod);
                }
                else
                {
                    sSQL = dal.Update(mod);
                }
                int iCou = DbHelperSQL.ExecuteSql(sSQL);
                if (iCou > 0)
                {
                    this.DialogResult = DialogResult.Yes;
                    this.Close();
                }

                //TH.BaseClass.ClsEmail clsEmail = new TH.BaseClass.ClsEmail();
                //try
                //{
                //    string s = clsEmail.SendMailUseZj(sUserMailInfo, sAddress, sSubject, sMailText, btnEditAdjunct.Text.Trim());
                //    MessageBox.Show(s);
                //    if (s.Trim().ToLower().StartsWith("ok"))
                //    {
                //        this.DialogResult = DialogResult.Yes;
                //        this.Close();
                //    }
                //}
                //catch (Exception ee)
                //{
                //    throw new Exception(ee.Message);
                //}
                //finally
                //{
                //    clsEmail = null;
                //}
            }
            catch (Exception ee)
            {
                MessageBox.Show("Err:" + ee.Message);
            }
        }

        private void FrmEMail_Load(object sender, EventArgs e)
        {
            try
            {

                //richTextBox1.LoadFile(sRtfSample);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}
