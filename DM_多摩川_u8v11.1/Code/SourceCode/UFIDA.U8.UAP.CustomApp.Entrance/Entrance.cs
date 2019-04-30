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


            //对应菜单编号
            if (sMenuID.Trim().ToLower() == "PrintBarCode_RdRecord01".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new PrintBarCode_RdRecord01Creater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }

            if (sMenuID.Trim().ToLower() == "PrintBarCode_RdRecord10".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new PrintBarCode_RdRecord10Creater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }

            if (sMenuID.Trim().ToLower() == "PrintBarCode_History".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new PrintBarCode_HistoryCreater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }

            if (sMenuID.Trim().ToLower() == "PrintBarCode_Inventory".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new PrintBarCode_InventoryCreater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }

            if (sMenuID.Trim().ToLower() == "SmartUser".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new SmartUsesCreater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }

            if (sMenuID.Trim().ToLower() == "PrintBarCode_OM_MOMain".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new PrintBarCode_OM_MOMainCreater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }

            if (sMenuID.Trim().ToLower() == "PrintBarCode_mom_order".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new PrintBarCode_mom_orderCreater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }

            if (sMenuID.Trim().ToLower() == "PrintBarCode_RdRecord08".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new PrintBarCode_RdRecord08Creater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }

            if (sMenuID.Trim().ToLower() == "PrintBarCode_SEL".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new PrintBarCode_SELCreater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }


            if (sMenuID.Trim().ToLower() == "PrintBarCode_Box".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new PrintBarCode_BoxCreater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }

            if (sMenuID.Trim().ToLower() == "UserRight".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new UserRightCreater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }


            if (sMenuID.Trim().ToLower() == "eMail".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new eMailCreater();

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
