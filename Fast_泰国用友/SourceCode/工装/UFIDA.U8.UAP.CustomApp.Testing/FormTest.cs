using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UFIDA.U8.UAP.CustomApp.MetaData;
using System.IO;
using System.Xml;

namespace WindowsFormsApplication1
{
    public partial class FormTest : Form
    {
        public FormTest()
        {
            InitializeComponent();
        }

      
        private string sXML()
        {
            string strLine = "";
            try
            {
                string sFileName = Application.StartupPath + "\\UAP\\Runtime\\MenuID.xml";
                sFileName = Application.StartupPath + "\\MenuID.xml";

                MessageBox.Show(sFileName);

                FileStream aFile = new FileStream(sFileName, FileMode.Open);
                StreamReader sr = new StreamReader(aFile);
                strLine = sr.ReadToEnd();

                sr.Close();


            }
            catch (Exception ee)
            {

            }
            return strLine;
        }

        /// <summary>
        /// 将xml字符串转换成DataSet
        /// </summary>
        /// <param name="xmlData"></param>
        /// <returns></returns>
        public static DataSet ConvertXMLToDataSet(string xmlData)
        {
            StringReader stream = null;
            XmlTextReader reader = null;
            try
            {
                DataSet xmlDS = new DataSet();
                stream = new StringReader(xmlData);
                reader = new XmlTextReader(stream);
                xmlDS.ReadXml(reader);
                return xmlDS;
            }
            catch (Exception ex)
            {
                string strTest = ex.Message;
                return null;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }

        private void btnFrmPurchasePlan_Click(object sender, EventArgs e)
        {
            FrmFrockClamp frm = new FrmFrockClamp();
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void btnUserRight_Click(object sender, EventArgs e)
        {
            UserRight frm = new UserRight();
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void btnrequisition_Click(object sender, EventArgs e)
        {
            FrmRequisition frm = new FrmRequisition();
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmGiveBack frm = new FrmGiveBack();
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmScrap frm = new FrmScrap();
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmMaintenance frm = new FrmMaintenance();
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmReport frm = new FrmReport();
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmGiveBackM frm = new FrmGiveBackM();
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

    }
}
