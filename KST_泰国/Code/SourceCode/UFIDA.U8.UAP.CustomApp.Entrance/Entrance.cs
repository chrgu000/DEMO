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

            //System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-CN");
            //System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("zh-CN");

            //if (DateTime.Today > Convert.ToDateTime("2017-6-1"))
            //    throw new Exception("出现无法预知的错误，无法申请功能");


            if (cMenuId.Trim().ToLower() == "TH_KST_01".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new FHDListCreater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }
            if (cMenuId.Trim().ToLower() == "TH_KST_02".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new RepFHDListCreater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }
            if (cMenuId.Trim().ToLower() == "TH_KST_03".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new SaleBillCreater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }
            if (cMenuId.Trim().ToLower() == "TH_KST_04".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new RepSalebillCreater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }

            return null;
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
