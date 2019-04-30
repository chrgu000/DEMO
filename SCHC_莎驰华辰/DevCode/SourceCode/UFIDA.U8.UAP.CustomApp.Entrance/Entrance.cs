using System;
using System.Collections.Generic;
using System.Text;
using UFIDA.U8.Portal.Proxy.supports;
using UFIDA.U8.Portal.Proxy.editors;
using System.Windows.Forms;
using System.IO;
using System.Data;
using System.Xml;

namespace UFIDA.U8.UAP.CustomApp.Entrance
{
    public class Entrance : NetLoginable
    {
        public override object CallFunction(string cMenuId, string cMenuName, string cAuthId, string cCmdLine)
        {

            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-CN");
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("zh-CN");

            string sMenuID = cMenuId;

            try
            {
                string s = sXML();

                DataSet ds = ConvertXMLToDataSet(s);


                if (ds == null || ds.Tables.Count < 1 || ds.Tables[0].Rows.Count < 1)
                {
                    throw new Exception("加载菜单对照表失败");
                }

                DataRow[] dr = ds.Tables[0].Select("u8cMenuId = '" + cMenuId.Trim() + "'");

                if (dr != null && dr.Length > 0)
                {
                    sMenuID = dr[0]["KFMenuId"].ToString().Trim();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

            if (sMenuID.Trim().ToLower() == "hr_tm_OriCardData".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new hr_tm_OriCardDataCreater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }

           
            return null ;
        }

        public override bool SubSysLogin()
        {
            return true;

        }

        private string sXML()
        {
            string strLine = "";
            try
            {
                string sFileName = Application.StartupPath + "\\UAP\\Runtime\\MenuID.xml";

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
    }
}
