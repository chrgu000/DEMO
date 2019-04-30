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
using System.Runtime.InteropServices;

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

        private void btn同步刷卡数据_Click(object sender, EventArgs e)
        {
            Frm同步刷卡数据 f = new Frm同步刷卡数据();
            f.ShowDialog();
        }



        [DllImport("W_Kqrec.DLL", CharSet = CharSet.Ansi, EntryPoint = "_LANREALINI")]
        public extern static int _LANREALINI(string username);


        [DllImport("W_Kqrec.DLL", CharSet = CharSet.Ansi, EntryPoint = "_LANREALDATA")]
        public extern static string _LANREALDATA(int Socket);

        [DllImport("w_kqrec.dll", CharSet = CharSet.Ansi, EntryPoint = "_LANDOWNLOADS")]
        public static extern int _LANDOWNLOADS(string ipaddress);


        [DllImport("w_kqrec.dll", CharSet = CharSet.Ansi, EntryPoint = "_LANDOWNLOAD")]
        public static extern int _LANDOWNLOAD(string ipaddress);

        [DllImport("w_kqrec.dll", CharSet = CharSet.Ansi, EntryPoint = "_LANBEGINTRAN")]
        public static extern int _LANBEGINTRAN(string ipaddress, string sType, int iOver);

        [DllImport("w_kqrec.dll", CharSet = CharSet.Ansi, EntryPoint = "_LANENDTRAN")]
        public static extern int _LANENDTRAN(int iSocket, string sType, int iOver);

        [DllImport("w_kqrec.dll", CharSet = CharSet.Ansi, EntryPoint = "_LANDOWNLOADSOCK")]
        public static extern int _LANDOWNLOADSOCK(string ipaddress, int iPort);

        [DllImport("w_kqrec.dll", CharSet = CharSet.Ansi, EntryPoint = "_LANTRANCARD")]
        public static extern int _LANTRANCARD(string ipaddress, int iPort);





        [DllImport("w_kqrec.dll", CharSet = CharSet.Ansi, EntryPoint = "_DOWNLOADS")]
        public static extern int _DOWNLOADS(string ipaddress, int iPort);


        [DllImport("w_kqrec.dll", CharSet = CharSet.Ansi, EntryPoint = "_FNPING")]
        public static extern int _FNPING(string ipaddress);



        [DllImport("w_kqrec.dll", CharSet = CharSet.Ansi, EntryPoint = "_LANDOWNALLDATA")]
        public static extern int _LANDOWNALLDATA(string ipaddress, int i);


        private void button1_Click(object sender, EventArgs e)
        {

            int i = _LANDOWNLOADS("192.168.33.192");
        }
    }
}
