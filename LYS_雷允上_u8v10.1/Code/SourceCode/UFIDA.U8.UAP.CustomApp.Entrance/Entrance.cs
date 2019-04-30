using System;
using System.Collections.Generic;
using System.Text;
using UFIDA.U8.Portal.Proxy.supports;
using UFIDA.U8.Portal.Proxy.editors;
using System.Windows.Forms;

namespace UFIDA.U8.UAP.CustomApp.Entrance
{
    public class Entrance : NetLoginable
    {
        public override object CallFunction(string cMenuId, string cMenuName, string cAuthId, string cCmdLine)
        {
            //对应菜单编号

            if (cMenuId == "UA1")
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new Sa_TypeCreater();


                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }
            if (cMenuId == "UA2" || cMenuId == "UA4")
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new Sa_CloseBillCreater();


                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }
            if (cMenuId == "UA3" || cMenuId == "UA5")
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new Sa_CertificateCreater();


                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }

            //二期 2014-03-24
            if (cMenuId == "UA6")
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new 收款导入Creater();


                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }
            if (cMenuId == "UA7")
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new 销售发货单导入Creater();


                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }
            if (cMenuId == "UA8")
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new 销售发票导入Creater();


                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }

            return null ;

        }

        public override bool SubSysLogin()
        {

            return true;

        }


    }
}
