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

            #region 江西
            
            if (cMenuId.Trim().ToLower() == "TH_FLD_01".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new 高开返利单Creater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }
            if (cMenuId.Trim().ToLower() == "TH_FLD_02".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new 高开返利单列表Creater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }

            if (cMenuId.Trim().ToLower() == "TH_FLD_03".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new 高开返利核销单Creater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }
            if (cMenuId.Trim().ToLower() == "TH_FLD_04".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new 高开返利核销单列表Creater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }

            #endregion

            #region 苏州

            if (cMenuId.Trim().ToLower() == "TH_FLD_SZ_01".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new 高开返利单_SZCreater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }
            if (cMenuId.Trim().ToLower() == "TH_FLD_SZ_02".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new 高开返利单列表_SZCreater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }

            if (cMenuId.Trim().ToLower() == "TH_FLD_SZ_03".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new 高开返利核销单_SZCreater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }
            if (cMenuId.Trim().ToLower() == "TH_FLD_SZ_04".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new 高开返利核销单列表_SZCreater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }

            if (cMenuId.Trim().ToLower() == "TH_FLD_SZ_05".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new 发票导入_SZCreater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }
            if (cMenuId.Trim().ToLower() == "TH_FLD_SZ_06".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new 回款导入_SZCreater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }
            #endregion

            return null ;
        }

        public override bool SubSysLogin()
        {
            return true;

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
