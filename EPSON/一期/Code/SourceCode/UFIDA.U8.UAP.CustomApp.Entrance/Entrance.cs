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
                INetUserControl mycontrol = new SystemSetCreater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }

            if (cMenuId.Trim().ToLower() == "TH_2".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new SaleBillVouchCreater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }

            if (cMenuId.Trim().ToLower() == "TH_3".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new PurBillVouchCreater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }

            if (cMenuId.Trim().ToLower() == "TH_4".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new ProcessCreater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }

            if (cMenuId.Trim().ToLower() == "TH_5".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new InvProcessCreater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }

            if (cMenuId.Trim().ToLower() == "TH_6".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new PaymentCreater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }

            if (cMenuId.Trim().ToLower() == "TH_7".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new ImportSaleOrderCreater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }

            if (cMenuId.Trim().ToLower() == "TH_8".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new RoutingInfoCreater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }

            if (cMenuId.Trim().ToLower() == "TH_9".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new CreditLineCreater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }
            if (cMenuId.Trim().ToLower() == "TH_10".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new ProcessListCreater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }
            if (cMenuId.Trim().ToLower() == "TH_11".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new  PlatingProcessCreater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }
            if (cMenuId.Trim().ToLower() == "TH_12".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new PrintBarLabelCreater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }
            if (cMenuId.Trim().ToLower() == "TH_13".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new PrintFlowCardCreater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }
            if (cMenuId.Trim().ToLower() == "TH_14".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new BarTransferCreater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }
            if (cMenuId.Trim().ToLower() == "TH_15".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new BarSplitCreater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }
            if (cMenuId.Trim().ToLower() == "TH_16".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new BarCloseCreater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }
            if (cMenuId.Trim().ToLower() == "TH_17".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new  InvProcessPriceCreater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }
            if (cMenuId.Trim().ToLower() == "TH_18".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new BarSalesShipmentCreater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }
            if (cMenuId.Trim().ToLower() == "TH_19".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new ProLineCreater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }
            if (cMenuId.Trim().ToLower() == "TH_20".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new SalesSetCreater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }
            if (cMenuId.Trim().ToLower() == "TH_21".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new BarAdjustCreater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }
            if (cMenuId.Trim().ToLower() == "TH_22".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new  RepBarcodeAverageCreater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }
            if (cMenuId.Trim().ToLower() == "TH_23".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new RepBarcodeDetailCreater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }
            if (cMenuId.Trim().ToLower() == "TH_24".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new PurchaseSetCreater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }
            if (cMenuId.Trim().ToLower() == "TH_25".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new BarCodeStatusCreater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }
            if (cMenuId.Trim().ToLower() == "TH_26".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new BarSalesShipmentAuditCreater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }
            if (cMenuId.Trim().ToLower() == "TH_27".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new BarSalesShipmentEditCreater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }
            if (cMenuId.Trim().ToLower() == "TH_28".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new SaleBillVouchCSVCreater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }
            if (cMenuId.Trim().ToLower() == "TH_29".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new RepWatchWipCreater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }
            if (cMenuId.Trim().ToLower() == "TH_30".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new RepSTFGCreater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }
            if (cMenuId.Trim().ToLower() == "TH_31".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new RepWatchWipOSCreater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }
            if (cMenuId.Trim().ToLower() == "TH_32".ToLower())
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new RepSTFGOSCreater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }



            return null;
        }

        public override bool SubSysLogin()
        {
            return true;
        }
    }
}
