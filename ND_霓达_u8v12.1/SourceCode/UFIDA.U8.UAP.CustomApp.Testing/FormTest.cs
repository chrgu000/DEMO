﻿using System;
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

        private void btn材料退回单_Click(object sender, EventArgs e)
        {
            Frm材料退回单 frm = new Frm材料退回单();
            frm.Show();
        }

        private void btnXML_Click(object sender, EventArgs e)
        {
            FrmXML文件转换 frm = new FrmXML文件转换();
            frm.Show();
        }

        private void btn采购入库单_Click(object sender, EventArgs e)
        {
            Frm采购入库单 frm = new Frm采购入库单();
            frm.Show();
        }

    }
}
