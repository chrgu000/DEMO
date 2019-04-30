using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string S = sXML();
      
            DataSet ds = new DataSet();

            ClsUseWebService cls = new ClsUseWebService();
            string sMsg = cls.InsertCustomer(S);
            MessageBox.Show(sMsg);
        }

        private string sXML()
        {
            string strLine = "";
            try
            {
                OpenFileDialog oFile = new OpenFileDialog();
                oFile.Filter = "XML|*.xml";
                if (oFile.ShowDialog() != DialogResult.OK)
                    throw new Exception("取消导入");

                FileStream aFile = new FileStream(oFile.FileName, FileMode.Open);
                StreamReader sr = new StreamReader(aFile);
                strLine = sr.ReadToEnd();       
                     
                sr.Close();

            }
            catch(Exception ee) 
            {
            
            }
            return strLine;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string S = sXML();

            DataSet ds = new DataSet();

            ClsUseWebService cls = new ClsUseWebService();
            string sMsg = cls.InsertVendor(S);
            MessageBox.Show(sMsg);

        }

        private void button3_Click(object sender, EventArgs e)
        {

            string S = sXML();

            DataSet ds = new DataSet();

            ClsUseWebService cls = new ClsUseWebService();
            string sMsg = cls.InsertItem(S);
            MessageBox.Show(sMsg);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string S = @"<?xml version='1.0' encoding='gb2312' standalone='yes'?>
<NewDataSet>
  <ProjectList>
    <GCID>testx01</GCID>
  </ProjectList>
</NewDataSet>
";

            ClsUseWebService cls = new ClsUseWebService();
            string sMsg = cls.GetApCloseBill_IN(S);
            MessageBox.Show(sMsg);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string S = @"<?xml version='1.0' encoding='gb2312' standalone='yes'?>
<NewDataSet>
  <ProjectList>
    <GCID>testx03</GCID>
  </ProjectList>
</NewDataSet>
";

            ClsUseWebService cls = new ClsUseWebService();
            string sMsg = cls.GetApCloseBill_OUT(S);
            MessageBox.Show(sMsg);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string S = @"<?xml version='1.0' encoding='gb2312' standalone='yes'?>
<NewDataSet>
  <ProjectList>
    <GCID>testx01</GCID>
  </ProjectList>
</NewDataSet>
";

            ClsUseWebService cls = new ClsUseWebService();
            string sMsg = cls.GetProCost(S);
            MessageBox.Show(sMsg);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //ClsUseWebService cls = new ClsUseWebService();
            //string sMsg = cls.get
            //MessageBox.Show(sMsg);

        }
    }
}
