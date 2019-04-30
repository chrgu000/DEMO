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
                INetUserControl mycontrol = new 受注残数据Creater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }

            if (cMenuId.Trim().ToLower() == "TH_2".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new 订货数据Creater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }

            if (cMenuId.Trim().ToLower() == "TH_3".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new 生产入库数据每月明细Creater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }

            if (cMenuId.Trim().ToLower() == "TH_4".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new 受注数据Creater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }

            if (cMenuId.Trim().ToLower() == "TH_5".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new 条件数据Creater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }

            if (cMenuId.Trim().ToLower() == "TH_6".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new 销售实绩数据Creater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }

            if (cMenuId.Trim().ToLower() == "TH_7".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new 有效在库数据安排生产Creater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }

            if (cMenuId.Trim().ToLower() == "TH_8".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new 月底生产入库数据Creater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }

            if (cMenuId.Trim().ToLower() == "TH_9".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new 月末在库数据Creater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }

            if (cMenuId.Trim().ToLower() == "TH_10".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new 在库数据Creater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }

            if (cMenuId.Trim().ToLower() == "TH_11".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new 客户数据Creater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }

            if (cMenuId.Trim().ToLower() == "TH_12".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new 处理日期数据Creater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }

            if (cMenuId.Trim().ToLower() == "TH_13".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new 出货完成Creater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }
            if (cMenuId.Trim().ToLower() == "TH_14".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new 产成品成本分配Creater();

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
