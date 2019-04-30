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

            if (cMenuId == "TH_YS_1")
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new Sa_BOMAllCreater();

                //if (DateTime.Now > Convert.ToDateTime("2019-01-01"))
                //{
                //    MessageBox.Show("获得年度账套信息失败");
                //    return null;
                //}
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
