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
            if (cMenuId == "TH_1")
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new GL_CodeCreater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }

            if (cMenuId == "TH_2")
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new GL_accvouchCreater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }

            if (cMenuId == "TH_3")
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new GL_accvouchToJPCreater();

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
