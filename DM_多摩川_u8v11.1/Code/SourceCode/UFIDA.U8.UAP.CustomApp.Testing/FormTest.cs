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

        private void btn采购入库单打印_Click(object sender, EventArgs e)
        {
            Frm采购入库单条形码打印 f = new Frm采购入库单条形码打印();
            f.ShowDialog();
        }

        private void btn产成品入库单打印_Click(object sender, EventArgs e)
        {
            Frm产成品入库单条形码打印 f = new Frm产成品入库单条形码打印();
            f.ShowDialog();
        }

        private void btn历史_Click(object sender, EventArgs e)
        {
            Frm历史条形码打印 f = new Frm历史条形码打印();
            f.ShowDialog();
        }

        private void btn存货条形码_Click(object sender, EventArgs e)
        {
            Frm存货条形码打印 f = new Frm存货条形码打印();
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {

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

        private void btnSmartUser_Click(object sender, EventArgs e)
        {
            Frm采集器操作员 f = new Frm采集器操作员();
            f.ShowDialog();
        }

        private void btn委外订单条码打印_Click(object sender, EventArgs e)
        {
            Frm委外订单条形码打印 f = new Frm委外订单条形码打印();
            f.Show();
        }

        private void btn生产订单条码打印_Click(object sender, EventArgs e)
        {
            Frm生产订单条形码打印 f = new Frm生产订单条形码打印();
            f.Show();
        }

        private void btn其他入库单_Click(object sender, EventArgs e)
        {
            Frm其它入库单条形码打印 f = new Frm其它入库单条形码打印();
            f.Show();
        }

        private void btn条形码扫描记录查看_Click(object sender, EventArgs e)
        {
            Frm条形码扫描记录查看 f = new Frm条形码扫描记录查看();
            f.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Frm箱码打印 f = new Frm箱码打印();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Frm插件权限设置 f = new Frm插件权限设置();
            f.Show();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmeMail f = new FrmeMail();
            f.Show();
        }  
    }
}
