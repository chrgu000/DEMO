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

        private void FrmProcess_Click(object sender, EventArgs e)
        {
            FrmProcess frm = new FrmProcess();
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmInvProcess frm = new FrmInvProcess();
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmSystemSet frm = new FrmSystemSet();
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmSaleBillVouch frm = new frmSaleBillVouch();
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmPurBillVouch frm = new frmPurBillVouch();
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmPayment frm = new FrmPayment();
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmImportSaleOrder frm = new FrmImportSaleOrder();
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FrmInvProcessPrice frm = new FrmInvProcessPrice();
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FrmRoutingInfo frm = new FrmRoutingInfo();
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            FrmCreditLine frm = new FrmCreditLine();
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            FrmPrintBarLabel frm = new FrmPrintBarLabel();
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            FrmBarSeparate frm = new FrmBarSeparate();
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void btnBarClose_Click(object sender, EventArgs e)
        {
            FrmBraclose frm = new FrmBraclose();
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            FrmPrintFlowCard frm = new FrmPrintFlowCard();
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            FrmPlatingProcess frm = new FrmPlatingProcess();
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            FrmProcessList frm = new FrmProcessList();
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            FrmBarTransfer frm = new FrmBarTransfer();
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Frm发货 frm = new Frm发货();
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            FrmProLine frm = new FrmProLine();
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Frm销售设置 frm = new Frm销售设置();
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            FrmBarAdjust frm = new FrmBarAdjust();
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            FrmRepBarcodeAverage frm = new FrmRepBarcodeAverage();
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            FrmRepBarcodeDetail frm = new FrmRepBarcodeDetail();
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Frm采购设置 frm = new Frm采购设置();
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            FrmBarCodeStatus frm = new FrmBarCodeStatus();
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            Frm发货确认 frm = new Frm发货确认();
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            Frm发货编辑 frm = new Frm发货编辑();
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            frmSaleBillVouchCSV frm = new frmSaleBillVouchCSV();
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void btnRepSale_Click(object sender, EventArgs e)
        {
            FrmRepWatchWip frm = new FrmRepWatchWip();
            frm.Show();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            FrmRepSTFG frm = new FrmRepSTFG();
            frm.Show();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            FrmRepWatchWipOS frm = new FrmRepWatchWipOS();
            frm.Show();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            FrmRepSTFGOS frm = new FrmRepSTFGOS();
            frm.Show();
        }
    }
}
