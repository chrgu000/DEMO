using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SaleOrder
{
    public partial class Frm缺料_demo : Form
    {
        protected FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();
        protected FrameBaseFunction.ClsGetSQL clsGetSQL = FrameBaseFunction.ClsGetSQL.Instance();

        string sWhere = "";

        public Frm缺料_demo()
        {
            InitializeComponent();
        }
        public Frm缺料_demo(string s)
        {
            InitializeComponent();

            sWhere = s;
        }

        private void Frm缺料_demo_Load(object sender, EventArgs e)
        {
            string sSQL = @"
select 子件编码 as 存货编码, inv.cInvName as 存货名称,inv.cInvStd as 规格型号,sum(cast(a.本次下单数量 as decimal(16,2))) as 数量,a.[完成日期] as 需求日期
from 订单评审运算原始数据 a inner join ufdata_200_2015..Inventory inv on a.子件编码 = inv.cInvCode
where 1=1 and a.[子件属性] = '采购'
group by 子件编码,inv.cInvName,a.[完成日期],inv.cInvStd
having sum(cast(a.本次下单数量 as decimal(16,2))) > 0
order by 子件编码,a.[完成日期]
";
            if (sWhere != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and 销售订单子表ID in (" + sWhere + ")");
            }

            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            gridControl销售订单列表.DataSource = dt;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridView销售订单列表_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            if (e.Info.IsRowIndicator)
            {
                if (e.RowHandle >= 0)
                {
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
                }
                else if (e.RowHandle < 0 && e.RowHandle > -1000)
                {
                    e.Info.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
                    e.Info.DisplayText = "G" + e.RowHandle.ToString();
                }
            }
        }


    }
}
