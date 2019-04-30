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
            if (cMenuId == "TH_1")
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new 产品现存量标签打印Creater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }

            if (cMenuId == "TH_2")
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new 货位标签打印Creater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }

            if (cMenuId == "TH_3")
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new 采购标签打印Creater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }

            if (cMenuId == "TH_4")
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new 产品标签打印Creater();

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
