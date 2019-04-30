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
                INetUserControl mycontrol = new 检验档案Creater();
                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }
            //if (cMenuId == "UA2")
            //{
            //    //根据菜单读取自定义控件
            //    INetUserControl mycontrol = new 库存物资统计查询Creater();
            //    base.ShowEmbedControl(mycontrol, cMenuId, true);
            //}
            if (cMenuId == "UA3")
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new 采购入库统计查询Creater();
                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }
            if (cMenuId == "UA4")
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new 销售出库统计查询Creater();
                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }
            if (cMenuId == "UA5")
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new 销售预测产品入库Creater();
                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }
            if (cMenuId == "UA29")
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new 检验项目Creater();
                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }
            if (cMenuId == "UA25")
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new 产品入库统计查询Creater();
                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }
            if (cMenuId == "UA26")
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new 材料出库统计查询Creater();
                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }
            if (cMenuId == "UA27")
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new 库存物资统计简表查询Creater();
                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }
            if (cMenuId == "UA19")
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new 应收余额表Creater();
                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }

            if (cMenuId == "UA28")
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new 收发存汇总查询Creater();
                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }

            if (cMenuId == "UA21")
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new 产品产量情况表查询Creater();
                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }

            if (cMenuId == "UA22")
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new 存货情况表查询Creater();
                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }

            if (cMenuId == "UA23")
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new 主要物资采购明细表查询Creater();
                base.ShowEmbedControl(mycontrol, cMenuId, true);
            }

            if (cMenuId == "UA24")
            {
                //根据菜单读取自定义控件
                INetUserControl mycontrol = new 应付余额表Creater();
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
