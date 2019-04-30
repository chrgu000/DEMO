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

        private void button4_Click(object sender, EventArgs e)
        {
            frm受注残数据 f = new frm受注残数据();
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm有效在库数据安排生产 f = new frm有效在库数据安排生产();
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm月底生产入库数据 f = new frm月底生产入库数据();
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frm受注数据 f = new frm受注数据();
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frm订货数据 f = new frm订货数据();
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frm销售实绩数据 f = new frm销售实绩数据();
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frm生产入库数据每月明细 f = new frm生产入库数据每月明细();
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            frm客户数据 f = new frm客户数据();
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            frm条件数据 f = new frm条件数据();
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            frm月末在库数据 f = new frm月末在库数据();
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            frm在库数据 f = new frm在库数据();
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            frm处理日数据 f = new frm处理日数据();
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            frm出货完成 f = new frm出货完成();
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void btn产成品成本分配_Click(object sender, EventArgs e)
        {
            frm产成品成本分配 f = new frm产成品成本分配();
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void btn发货单导入_Click(object sender, EventArgs e)
        {
            frm发货单导入 f = new frm发货单导入();
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

    }
}
