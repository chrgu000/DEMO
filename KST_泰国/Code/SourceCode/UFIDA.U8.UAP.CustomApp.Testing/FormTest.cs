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


        private void btn发货单导入_Click(object sender, EventArgs e)
        {
            FHDList f = new FHDList();
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void btn发货单报表_Click(object sender, EventArgs e)
        {
            RepFHDList f = new RepFHDList();
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void btn发货单生成发票_Click(object sender, EventArgs e)
        {
            Salebillvouch f = new Salebillvouch();
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void btn发票报表_Click(object sender, EventArgs e)
        {
            RepSalebillvouch f = new RepSalebillvouch();
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }
    }
}
