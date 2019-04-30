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

            if (cMenuId == "UA3")
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new Sa_BOMAllCreater();


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
