using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MyXtraTreeList;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class Frm材料出库统计查询 : UserControl
    {
        //public class CmbDataSource
        //{
        //    public string WareHouseCode;
        //    public string WareHouseName;
        //}

        //public class UserMsg
        //{
        //    public string UserCode;
        //    public string UserName;
        //}
        int id;

        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }

        public Frm材料出库统计查询()
        {
            InitializeComponent();
        }


        private void Frm材料出库统计查询_Load(object sender, EventArgs e)
        {
            try
            {
                string sSQL = "";
                DataTable dt;
                DataRow dr;
                Cls时间锁 cls = new Cls时间锁();
                if (cls.bchk时间锁(Conn) == false)
                {
                    throw new Exception("加载数据失败");
                }

                LookUp.Inventory(Conn, lookUpEdit存货名称1);
                LookUp.Inventory(Conn, lookUpEdit存货名称2);
                LookUp.Warehouse(Conn, lookUpEdit仓库);

                sSQL = @"select cValue from UserDefine where cID=29  ORDER BY cAlias";
                dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                dr = dt.NewRow();
                dt.Rows.InsertAt(dr, 0);
                lookUpEditcDefine3.Properties.DataSource = dt;

                sSQL = @"select cPosCode,cPosName from Position ";
                dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                dr = dt.NewRow();
                dt.Rows.InsertAt(dr, 0);
                lookUpEditcPosition.Properties.DataSource = dt;

                sSQL = "select datepart(yyyy,getdate())";
                txt年.EditValue = SqlHelper.ExecuteScalar(Conn, CommandType.Text, sSQL);
                btnRefresh_Click(null, null);

                myTreeList1.SetBandsWidth(50);
                int i = 0;
                MyTreeListBand Band1 = myTreeList1.Bands.Add(i, 2, "分类品名");
                Band1.SetColumn(0, myTreeList1.Columns["TreeList"], "分类", false, DevExpress.Utils.HorzAlignment.Default);
                Band1.SetColumn(1, myTreeList1.Columns["cInvStd"], "规格型号", false, DevExpress.Utils.HorzAlignment.Default);
                //Band1.SetColumn(2, myTreeList1.Columns["cInvCode"], "编码", false, DevExpress.Utils.HorzAlignment.Default);
                i = i + 2;

                MyTreeListBand Band3 = myTreeList1.Bands.Add(i, 1, "统计区间");
                Band3.SetColumn(0, myTreeList1.Columns["统计区间出库数量"], "出库数量", false, DevExpress.Utils.HorzAlignment.Far);
                i = i + 1;

                MyTreeListBand Band6 = myTreeList1.Bands.Add(i, 13, "年度统计");
                Band6.SetColumn(0, myTreeList1.Columns["年度合计数量"], "年度合计", false, DevExpress.Utils.HorzAlignment.Far);
                Band6.SetColumn(1, myTreeList1.Columns["iQty1"], "一月", false, DevExpress.Utils.HorzAlignment.Far);
                Band6.SetColumn(2, myTreeList1.Columns["iQty2"], "二月", false, DevExpress.Utils.HorzAlignment.Far);
                Band6.SetColumn(3, myTreeList1.Columns["iQty3"], "三月", false, DevExpress.Utils.HorzAlignment.Far);
                Band6.SetColumn(4, myTreeList1.Columns["iQty4"], "四月", false, DevExpress.Utils.HorzAlignment.Far);
                Band6.SetColumn(5, myTreeList1.Columns["iQty5"], "五月", false, DevExpress.Utils.HorzAlignment.Far);
                Band6.SetColumn(6, myTreeList1.Columns["iQty6"], "六月", false, DevExpress.Utils.HorzAlignment.Far);
                Band6.SetColumn(7, myTreeList1.Columns["iQty7"], "七月", false, DevExpress.Utils.HorzAlignment.Far);
                Band6.SetColumn(8, myTreeList1.Columns["iQty8"], "八月", false, DevExpress.Utils.HorzAlignment.Far);
                Band6.SetColumn(9, myTreeList1.Columns["iQty9"], "九月", false, DevExpress.Utils.HorzAlignment.Far);
                Band6.SetColumn(10, myTreeList1.Columns["iQty10"], "十月", false, DevExpress.Utils.HorzAlignment.Far);
                Band6.SetColumn(11, myTreeList1.Columns["iQty11"], "十一月", false, DevExpress.Utils.HorzAlignment.Far);
                Band6.SetColumn(12, myTreeList1.Columns["iQty12"], "十二月", false, DevExpress.Utils.HorzAlignment.Far);
                i = i + 13;
                MyTreeListBand Band10 = myTreeList1.Bands.Add(i, 1, "存货编码");
                Band10.SetColumn(0, myTreeList1.Columns["cInvCode"], "编码", false, DevExpress.Utils.HorzAlignment.Default);
                i = i + 1;

                myTreeList1.ExpandAll();
                myTreeList1.ViewInfo.RC.NeedsRestore = true;
                myTreeList1.BestFitColumns();
                myTreeList1.LayoutChanged();

                
                myTreeList1.Columns["iQty1"].Width = 70;
                myTreeList1.Columns["iQty2"].Width = 70;
                myTreeList1.Columns["iQty3"].Width = 70;
                myTreeList1.Columns["iQty4"].Width = 70;
                myTreeList1.Columns["iQty5"].Width = 70;
                myTreeList1.Columns["iQty6"].Width = 70;
                myTreeList1.Columns["iQty7"].Width = 70;
                myTreeList1.Columns["iQty8"].Width = 70;
                myTreeList1.Columns["iQty9"].Width = 70;
                myTreeList1.Columns["iQty10"].Width = 70;
                myTreeList1.Columns["iQty11"].Width = 70;
                myTreeList1.Columns["iQty12"].Width = 70;

                myTreeList1.Columns["TreeList"].Width = 200;
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载数据失败");
            }
        }

        /// <summary>
        /// 思路：
        /// 1. 获得物料现存量
        /// 2. 按照周期逐行展开物料的收发信息，单价使用周期内加权平均单价*数量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                Cls时间锁 cls = new Cls时间锁();
                if (cls.bchk时间锁(Conn) == false)
                {
                    throw new Exception("加载数据失败");
                }
                if (txt年.Text.Trim() == "")
                {
                    throw new Exception("年度不可为空");
                }
                string sSQL = @"
select d.cDepName as 部门,i.cInvName,i.cInvStd as 规格型号,a.cDepCode,a.cPersonCode,a.cCusCode,i.cInvCode
,convert(decimal(18, 3),sum(case when datepart(MM,a.dDate)=1 then b.iquantity end))  as iQty1,convert(decimal(18, 2),sum(case when datepart(MM,a.dDate)=1 then b.iPrice end))  as iMoney1
,convert(decimal(18, 3),sum(case when datepart(MM,a.dDate)=2 then b.iquantity end))  as iQty2,convert(decimal(18, 2),sum(case when datepart(MM,a.dDate)=2 then b.iPrice end))  as iMoney2
,convert(decimal(18, 3),sum(case when datepart(MM,a.dDate)=3 then b.iquantity end))  as iQty3,convert(decimal(18, 2),sum(case when datepart(MM,a.dDate)=3 then b.iPrice end))  as iMoney3
,convert(decimal(18, 3),sum(case when datepart(MM,a.dDate)=4 then b.iquantity end))  as iQty4,convert(decimal(18, 2),sum(case when datepart(MM,a.dDate)=4 then b.iPrice end))  as iMoney4
,convert(decimal(18, 3),sum(case when datepart(MM,a.dDate)=5 then b.iquantity end))  as iQty5,convert(decimal(18, 2),sum(case when datepart(MM,a.dDate)=5 then b.iPrice end))  as iMoney5
,convert(decimal(18, 3),sum(case when datepart(MM,a.dDate)=6 then b.iquantity end))  as iQty6,convert(decimal(18, 2),sum(case when datepart(MM,a.dDate)=6 then b.iPrice end))  as iMoney6
,convert(decimal(18, 3),sum(case when datepart(MM,a.dDate)=7 then b.iquantity end))  as iQty7,convert(decimal(18, 2),sum(case when datepart(MM,a.dDate)=7 then b.iPrice end))  as iMoney7
,convert(decimal(18, 3),sum(case when datepart(MM,a.dDate)=8 then b.iquantity end))  as iQty8,convert(decimal(18, 2),sum(case when datepart(MM,a.dDate)=8 then b.iPrice end))  as iMoney8
,convert(decimal(18, 3),sum(case when datepart(MM,a.dDate)=9 then b.iquantity end))  as iQty9,convert(decimal(18, 2),sum(case when datepart(MM,a.dDate)=9 then b.iPrice end))  as iMoney9
,convert(decimal(18, 3),sum(case when datepart(MM,a.dDate)=10 then b.iquantity end))  as iQty10,convert(decimal(18, 2),sum(case when datepart(MM,a.dDate)=10 then b.iPrice end))  as iMoney10
,convert(decimal(18, 3),sum(case when datepart(MM,a.dDate)=11 then b.iquantity end))  as iQty11,convert(decimal(18, 2),sum(case when datepart(MM,a.dDate)=11 then b.iPrice end))  as iMoney11
,convert(decimal(18, 3),sum(case when datepart(MM,a.dDate)=12 then b.iquantity end))  as iQty12,convert(decimal(18, 2),sum(case when datepart(MM,a.dDate)=12 then b.iPrice end))  as iMoney12
,case when convert(decimal(18, 2),sum(iquantity))<>0 then convert(decimal(18, 2),sum(iPrice)/sum(iquantity)) else 0 end as 年度均价
,convert(decimal(18, 2),sum(iPrice)) as 年度合计
,convert(decimal(18, 3),sum(b.iquantity)) as 年度合计数量
,convert(decimal(18, 3),sum(b.iquantity))  as 统计区间出库数量
,case when convert(decimal(18, 2),sum(case when datepart(MM,a.dDate)=111111 then iquantity else 0 end))<>0 then convert(decimal(18, 2),sum(case when datepart(MM,a.dDate)=111111 then b.iPrice end)/sum(case when datepart(MM,a.dDate)=111111 then iquantity end)) else 0 end as 月度均价
into #a 
from RdRecord11 a inner join rdrecords11 b on a.ID = b.ID left join Inventory i on b.cInvCode=i.cInvCode left join Customer c on a.cCusCode=c.cCusCode
left join Person p on a.cPersonCode=p.cPersonCode left join Department d on a.cDepCode=d.cDepCode left join DistrictClass dis on c.cDCCode=dis.cDCCode 
left join Warehouse w on a.cWhCode=w.cWhCode where 1=1 
group by d.cDepName,i.cInvName,i.cInvStd,a.cDepCode,a.cPersonCode,a.cCusCode,i.cInvCode

select a.*,i.cInvName,i.cInvStd
,ic1.cInvCCode as cInvCCode1,ic1.cInvCName as cInvCName1,ic2.cInvCCode as cInvCCode2,ic2.cInvCName as cInvCName2,ic3.cInvCCode as cInvCCode3,ic3.cInvCName as cInvCName3
from #a as a 
    left join Inventory i on i.cInvCode = a.cInvCode  
    left join InventoryClass ic1 on ic1.cInvCCode = left(i.cInvCCode,2)
	left join InventoryClass ic2 on ic2.cInvCCode = left(i.cInvCCode,4)
	left join InventoryClass ic3 on ic3.cInvCCode = left(i.cInvCCode,6)
";
                if (rdo审核.Checked == true)
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(a.cHandler,'')<>''");
                }
                else
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(a.cHandler,'')=''");
                }
                if (buttonEdit存货编码1.EditValue != null && buttonEdit存货编码1.EditValue.ToString() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and b.cInvCode>='" + buttonEdit存货编码1.EditValue.ToString().Trim() + "'");
                }
                if (buttonEdit存货编码2.EditValue != null && buttonEdit存货编码2.EditValue.ToString() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and b.cInvCode<='" + buttonEdit存货编码2.EditValue.ToString().Trim() + "'");
                }
                if (txt年.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and datepart(yyyy,a.dDate)='" + txt年.Text.Trim() + "'");
                }
                if (buttonEdit仓库.EditValue != null && buttonEdit仓库.EditValue.ToString() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and (w.cWhCode='" + buttonEdit仓库.EditValue.ToString().Trim() + "' or w.cWhName='" + buttonEdit仓库.EditValue.ToString().Trim() + "')");
                }
                if (lookUpEditcDefine3.Text != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and b.cFree4='" + lookUpEditcDefine3.EditValue.ToString().Trim() + "'");
                }
                if (lookUpEditcPosition.Text != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and b.cPosition ='" + lookUpEditcPosition.EditValue.ToString().Trim() + "'");
                }
                sSQL = sSQL.Replace("1=1", "1=1 and datepart(yyyy,a.dDate)='" + txt年.Text.Trim() + "'");
                sSQL = sSQL.Replace("111111", DateTime.Now.Month.ToString());
                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];

                DataTable dtBind = new DataTable();
                dtBind.Columns.Add("ID");
                dtBind.Columns.Add("ParentID");
                dtBind.Columns.Add("TreeList");
                dtBind.Columns.Add("cInvStd");
                dtBind.Columns.Add("cInvCode");
                dtBind.Columns.Add("统计区间出库数量", typeof(decimal));
                dtBind.Columns.Add("iQty1", typeof(decimal));
                dtBind.Columns.Add("iQty2", typeof(decimal));
                dtBind.Columns.Add("iQty3", typeof(decimal));
                dtBind.Columns.Add("iQty4", typeof(decimal));
                dtBind.Columns.Add("iQty5", typeof(decimal));
                dtBind.Columns.Add("iQty6", typeof(decimal));
                dtBind.Columns.Add("iQty7", typeof(decimal));
                dtBind.Columns.Add("iQty8", typeof(decimal));
                dtBind.Columns.Add("iQty9", typeof(decimal));
                dtBind.Columns.Add("iQty10", typeof(decimal));
                dtBind.Columns.Add("iQty11", typeof(decimal));
                dtBind.Columns.Add("iQty12", typeof(decimal));
                dtBind.Columns.Add("年度合计数量", typeof(decimal));
                string[] sum = new string[] { "iQty1", "iQty2", "iQty3", "iQty4", "iQty5", "iQty6"
                    , "iQty7", "iQty8", "iQty9", "iQty10", "iQty11", "iQty12"
                        , "年度合计数量", "统计区间出库数量"};
                string[] col = new string[] { "cInvCode", "cInvStd" };
                myTreeList1.Band(dt, dtBind
                       , new string[] { "cInvCName1", "cInvCName2", "cInvCName3", "cInvName" }
                       , sum, col);
                myTreeList1.ExpandAll();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                myTreeList1.PostEditor();
                this.Validate();

                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "xls";
                sF.FileName = this.Text;
                sF.Filter = "Excel文件(*.xls)|*.xls|所有文件(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK == dRes)
                {
                    myTreeList1.ExportToXls(sF.FileName);
                    MessageBox.Show("导出Excel成功\n\t路径：" + sF.FileName);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("导出列表失败：" + ee.Message);
            }
        }

        private void myTreeList1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DevExpress.XtraTreeList.Nodes.TreeListNode node = myTreeList1.FocusedNode;
                if (node == null)
                    return;
                if (node.HasChildren == true)
                    return;
                string Caption = myTreeList1.FocusedColumn.Caption;
                string cInvCode = myTreeList1.FocusedNode.GetValue("cInvCode").ToString();

                //if (Caption == "一月" || Caption == "二月" || Caption == "三月" || Caption == "四月" || Caption == "五月" || Caption == "六月"
                //    || Caption == "七月" || Caption == "八月" || Caption == "九月" || Caption == "十月" || Caption == "十一月" || Caption == "十二月")
                //{
                    Frm明细 frm = new Frm明细(Conn);

                    string month = "";
                    if (Caption.IndexOf("一月") >= 0)
                    {
                        month = "01";
                    }
                    else if (Caption.IndexOf("二月") >= 0)
                    {
                        month = "02";
                    }
                    else if (Caption.IndexOf("三月") >= 0)
                    {
                        month = "03";
                    }
                    else if (Caption.IndexOf("四月") >= 0)
                    {
                        month = "04";
                    }
                    else if (Caption.IndexOf("五月") >= 0)
                    {
                        month = "05";
                    }
                    else if (Caption.IndexOf("六月") >= 0)
                    {
                        month = "06";
                    }
                    else if (Caption.IndexOf("七月") >= 0)
                    {
                        month = "07";
                    }
                    else if (Caption.IndexOf("八月") >= 0)
                    {
                        month = "08";
                    }
                    else if (Caption.IndexOf("九月") >= 0)
                    {
                        month = "09";
                    }
                    else if (Caption.IndexOf("十月") >= 0)
                    {
                        month = "10";
                    }
                    else if (Caption.IndexOf("十一月") >= 0)
                    {
                        month = "11";
                    }
                    else if (Caption.IndexOf("十二月") >= 0)
                    {
                        month = "12";
                    }
                    frm.材料出库明细(
                          ""
                        , cInvCode
                        , txt年.Text.Trim(), month);
                    frm.Show();
                    if (DialogResult.OK == frm.ShowDialog())
                    {
                        frm.Enabled = true;
                    }
                //}
            }
            catch (Exception ee)
            { }
        }

        private void buttonEdit存货编码1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                FrmInvInfo frm = new FrmInvInfo(buttonEdit存货编码1.Text.ToString(), Conn, true);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    buttonEdit存货编码1.EditValue = frm.sInvCode;

                    frm.Enabled = true;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit存货编码2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                FrmInvInfo frm = new FrmInvInfo(buttonEdit存货编码2.Text.ToString(), Conn, true);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    buttonEdit存货编码2.EditValue = frm.sInvCode;

                    frm.Enabled = true;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

     
        private void buttonEdit存货编码1_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (buttonEdit存货编码1.Text.Trim() != "")
                {
                    lookUpEdit存货名称1.EditValue = buttonEdit存货编码1.Text.Trim();
                }
                else
                {
                    lookUpEdit存货名称1.EditValue = null;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit存货编码1_Leave(object sender, EventArgs e)
        {
            try
            {
                if (buttonEdit存货编码1.Text.Trim() == "")
                    return;
                if (lookUpEdit存货名称1.Text.Trim() == "")
                {
                    buttonEdit存货编码1.Text = "";
                    buttonEdit存货编码1.Focus();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit存货编码2_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (buttonEdit存货编码2.Text.Trim() != "")
                {
                    lookUpEdit存货名称2.EditValue = buttonEdit存货编码2.Text.Trim();
                }
                else
                {
                    lookUpEdit存货名称2.EditValue = null;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit存货编码2_Leave(object sender, EventArgs e)
        {
            try
            {
                if (buttonEdit存货编码2.Text.Trim() == "")
                    return;
                if (lookUpEdit存货名称2.Text.Trim() == "")
                {
                    buttonEdit存货编码2.Text = "";
                    buttonEdit存货编码2.Focus();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit仓库_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                FrmWarehouse frm = new FrmWarehouse(buttonEdit仓库.Text.ToString(), Conn, true);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    buttonEdit仓库.EditValue = frm.sPerCode;

                    frm.Enabled = true;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit仓库_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (buttonEdit仓库.Text.Trim() != "")
                {
                    lookUpEdit仓库.EditValue = buttonEdit仓库.Text.Trim();
                }
                else
                {
                    lookUpEdit仓库.EditValue = null;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit仓库_Leave(object sender, EventArgs e)
        {
            try
            {
                if (buttonEdit仓库.Text.Trim() == "")
                    return;
                if (lookUpEdit仓库.Text.Trim() == "")
                {
                    buttonEdit仓库.Text = "";
                    buttonEdit仓库.Focus();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

    }
}