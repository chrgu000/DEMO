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



        private void btn产品材料耗用登记_Click(object sender, EventArgs e)
        {
            Frm产品材料耗用登记 f = new Frm产品材料耗用登记();
            f.Show();
        }

     
        private void button2_Click(object sender, EventArgs e)
        {
            Frm车间材料领用汇总月报 f = new Frm车间材料领用汇总月报();
            f.Show();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Frm分配规则 f = new Frm分配规则();
            //f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Frm共耗费用登记 f = new Frm共耗费用登记();
            //f.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Frm成本分配表 f = new Frm成本分配表();
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Frm部门费用登记 f = new Frm部门费用登记();
            //f.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Frm能源分配 f = new Frm能源分配();
            f.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Frm费用分配 f = new Frm费用分配();
            f.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Frm辅助费用分配 f = new Frm辅助费用分配();
            f.Show();
        }

    }
}
