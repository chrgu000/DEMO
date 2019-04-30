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

            if (cMenuId == "UA1" || cMenuId == "UA4")
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new 帐套档案对照表Creater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }

            if (cMenuId == "UA2" || cMenuId == "UA5")
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new 帐套科目归属表Creater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }


            if (cMenuId == "UA3" || cMenuId == "UA6")
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new 凭证传递Creater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }


            if (cMenuId == "UA13")
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new 存货条形码打印Creater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }
            if (cMenuId == "UA14")
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new 到货单条形码打印Creater();

                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }
            if (cMenuId == "UA15")
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new 产成品入库单条形码打印Creater();

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
