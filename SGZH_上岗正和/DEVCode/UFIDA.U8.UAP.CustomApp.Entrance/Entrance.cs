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
                INetUserControl mycontrol = new 销售发票导入Creater();


                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }
            if (cMenuId == "UA2")
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new 收款导入Creater();


                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }

            if (cMenuId == "UA3")
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new 结算方式对应表Creater();


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
