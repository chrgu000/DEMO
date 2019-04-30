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


            if (cMenuId.Trim().ToLower() == "TH_1".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new UserRightCreate();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }
            if (cMenuId.Trim().ToLower() == "TH_2".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new FrockClampCreate();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }
            if (cMenuId.Trim().ToLower() == "TH_3".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new RequisitionCreate();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }
            if (cMenuId.Trim().ToLower() == "TH_4".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new GiveBackCreate();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }
            if (cMenuId.Trim().ToLower() == "TH_5".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new ScrapCreate();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }
            if (cMenuId.Trim().ToLower() == "TH_6".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new MaintenanceCreate();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }
            if (cMenuId.Trim().ToLower() == "TH_7".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new ReportCreate();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }
            if (cMenuId.Trim().ToLower() == "TH_8".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new GiveBackMCreate();

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
