using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MyXtraTreeList;
using System.Collections;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class Frm销售出库统计查询 : UserControl
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
        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }

        public Frm销售出库统计查询()
        {
            InitializeComponent();
        }


        private void Frm销售出库统计查询_Load(object sender, EventArgs e)
        {
            try
            {
                Cls时间锁 cls = new Cls时间锁();
                string sSQL = "";
                DataTable dt;
                DataRow dr;
                if (cls.bchk时间锁(Conn) == false)
                {
                    throw new Exception("加载数据失败");
                }

                LookUp.Inventory(Conn, lookUpEdit存货名称1);
                LookUp.Inventory(Conn, lookUpEdit存货名称2);
                LookUp.Customer(Conn, lookUpEdit客户名称);
                LookUp.Person(Conn, lookUpEdit销售员名称);
                LookUp.Department(Conn, lookUpEdit部门);
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

                //MyTreeListBand Band3 = myTreeList1.Bands.Add(i, 1, "统计区间");
                //Band3.SetColumn(0, myTreeList1.Columns["统计区间销售数量"], "销售数量", false, DevExpress.Utils.HorzAlignment.Far);
                //i = i + 1;

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
select d.cDepName as 部门,p.cPersonName as 销售员,dis.cDCName as 区域,c.cCusName as 客户,i.cInvName,i.cInvStd as 规格型号,a.cDepCode,a.cPersonCode,a.cCusCode,i.cInvCode
,convert(decimal(18, 3),sum(case when datepart(MM,a.dDate)=1 then 111111 end))  as iQty1,convert(decimal(18, 2),sum(case when datepart(MM,a.dDate)=1 then b.iPrice end))  as iMoney1
,convert(decimal(18, 3),sum(case when datepart(MM,a.dDate)=2 then 111111 end))  as iQty2,convert(decimal(18, 2),sum(case when datepart(MM,a.dDate)=2 then b.iPrice end))  as iMoney2
,convert(decimal(18, 3),sum(case when datepart(MM,a.dDate)=3 then 111111 end))  as iQty3,convert(decimal(18, 2),sum(case when datepart(MM,a.dDate)=3 then b.iPrice end))  as iMoney3
,convert(decimal(18, 3),sum(case when datepart(MM,a.dDate)=4 then 111111 end))  as iQty4,convert(decimal(18, 2),sum(case when datepart(MM,a.dDate)=4 then b.iPrice end))  as iMoney4
,convert(decimal(18, 3),sum(case when datepart(MM,a.dDate)=5 then 111111 end))  as iQty5,convert(decimal(18, 2),sum(case when datepart(MM,a.dDate)=5 then b.iPrice end))  as iMoney5
,convert(decimal(18, 3),sum(case when datepart(MM,a.dDate)=6 then 111111 end))  as iQty6,convert(decimal(18, 2),sum(case when datepart(MM,a.dDate)=6 then b.iPrice end))  as iMoney6
,convert(decimal(18, 3),sum(case when datepart(MM,a.dDate)=7 then 111111 end))  as iQty7,convert(decimal(18, 2),sum(case when datepart(MM,a.dDate)=7 then b.iPrice end))  as iMoney7
,convert(decimal(18, 3),sum(case when datepart(MM,a.dDate)=8 then 111111 end))  as iQty8,convert(decimal(18, 2),sum(case when datepart(MM,a.dDate)=8 then b.iPrice end))  as iMoney8
,convert(decimal(18, 3),sum(case when datepart(MM,a.dDate)=9 then 111111 end))  as iQty9,convert(decimal(18, 2),sum(case when datepart(MM,a.dDate)=9 then b.iPrice end))  as iMoney9
,convert(decimal(18, 3),sum(case when datepart(MM,a.dDate)=10 then 111111 end))  as iQty10,convert(decimal(18, 2),sum(case when datepart(MM,a.dDate)=10 then b.iPrice end))  as iMoney10
,convert(decimal(18, 3),sum(case when datepart(MM,a.dDate)=11 then 111111 end))  as iQty11,convert(decimal(18, 3),sum(case when datepart(MM,a.dDate)=11 then b.iPrice end))  as iMoney11
,convert(decimal(18, 3),sum(case when datepart(MM,a.dDate)=12 then 111111 end))  as iQty12,convert(decimal(18, 2),sum(case when datepart(MM,a.dDate)=12 then b.iPrice end))  as iMoney12
,case when convert(decimal(18, 2),sum(iquantity))<>0 then convert(decimal(18, 2),sum(iPrice)/sum(iquantity)) else 0 end as 年度均价
,convert(decimal(18, 3),sum(iPrice)) as 年度合计
,convert(decimal(18, 3),sum(b.iquantity)) as 年度合计数量
,convert(decimal(18, 3),sum(b.iquantity))  as 统计区间销售数量
,case when convert(decimal(18, 2),sum(case when datepart(MM,a.dDate)=111111 then iquantity else 0 end))<>0 then convert(decimal(18, 2),sum(case when datepart(MM,a.dDate)=111111 then b.iPrice end)/sum(case when datepart(MM,a.dDate)=111111 then iquantity end)) else 0 end as 月度均价
into #a
from RdRecord32 a inner join rdrecords32 b on a.ID = b.ID left join Inventory i on b.cInvCode=i.cInvCode left join Customer c on a.cCusCode=c.cCusCode
left join Person p on a.cPersonCode=p.cPersonCode left join Department d on a.cDepCode=d.cDepCode left join DistrictClass dis on c.cDCCode=dis.cDCCode 
left join Warehouse w on a.cWhCode=w.cWhCode  where 1=1 
group by d.cDepName,p.cPersonName,dis.cDCName,c.cCusName,i.cInvName,i.cInvStd,a.cDepCode,a.cPersonCode,a.cCusCode,i.cInvCode

select a.*,i.cInvName,i.cInvStd
,ic1.cInvCCode as cInvCCode1,ic1.cInvCName as cInvCName1,ic2.cInvCCode as cInvCCode2,ic2.cInvCName as cInvCName2,ic3.cInvCCode as cInvCCode3,ic3.cInvCName as cInvCName3
from #a as a 
    left join Inventory i on i.cInvCode = a.cInvCode  
    left join InventoryClass ic1 on ic1.cInvCCode = left(i.cInvCCode,2)
	left join InventoryClass ic2 on ic2.cInvCCode = left(i.cInvCCode,4)
	left join InventoryClass ic3 on ic3.cInvCCode = left(i.cInvCCode,6) order by a.cInvCode
";
                if (rdo金额.Checked == true)
                {
                    sSQL = sSQL.Replace("111111", "b.iPrice");
                }
                else
                {
                    sSQL = sSQL.Replace("111111", "b.iquantity");
                }
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
                if (buttonEdit客户.EditValue != null && buttonEdit客户.EditValue.ToString() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and (c.cCusCode='" + buttonEdit客户.EditValue.ToString().Trim() + "' or c.cCusName='" + buttonEdit客户.EditValue.ToString().Trim() + "')");
                }
                if (buttonEdit销售员.EditValue != null && buttonEdit销售员.EditValue.ToString() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and (p.cPersonCode='" + buttonEdit销售员.EditValue.ToString().Trim() + "' or p.cPersonName='" + buttonEdit销售员.EditValue.ToString().Trim() + "')");
                }
                if (buttonEdit部门.EditValue != null && buttonEdit部门.EditValue.ToString() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and (d.cDepName='" + buttonEdit部门.EditValue.ToString().Trim() + "' or d.cDepName='" + buttonEdit部门.EditValue.ToString().Trim() + "')");
                }
                if (buttonEdit仓库.EditValue != null && buttonEdit仓库.EditValue.ToString() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and (w.cWhCode='" + buttonEdit仓库.EditValue.ToString().Trim() + "' or w.cWhName='" + buttonEdit仓库.EditValue.ToString().Trim() + "')");
                }
                if (txt年.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and datepart(yyyy,a.dDate)='" + txt年.Text.Trim() + "'");
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
                dtBind.Columns.Add("统计区间销售数量", typeof(decimal));
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
                        , "年度合计数量", "统计区间销售数量"};
                string[] col = new string[] { "cInvCode", "cInvStd" };
                if (radioButton1.Checked)//部门
                {
                    myTreeList1.Band(dt, dtBind
                        , new string[] { "部门", "cInvCName1", "cInvCName2", "cInvCName3", "cInvName" }
                        , sum, col);
                }
                else if (radioButton2.Checked)//销售员
                {
                    myTreeList1.Band(dt, dtBind
                       , new string[] { "销售员", "cInvCName1", "cInvCName2", "cInvCName3", "cInvName" }
                      , sum, col);
                } 
                else if (radioButton3.Checked)//存货
                {
                    myTreeList1.Band(dt, dtBind
                       , new string[] { "cInvCName1", "cInvCName2", "cInvCName3", "cInvName" }
                       , sum, col);
                }
                else if (radioButton4.Checked)//客户
                {
                    myTreeList1.Band(dt, dtBind
                       , new string[] { "客户","cInvCName1", "cInvCName2", "cInvCName3", "cInvName" }
                       , sum, col);
                }
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
                string cDepCode = "";
                string cPersonCode = "";
                string cDCName = "";
                string cCusCode = "";
                if (radioButton1.Checked)
                {
                    cDepCode = myTreeList1.FocusedNode.ParentNode.ParentNode.ParentNode.ParentNode.GetValue("TreeList").ToString();
                }
                else if (radioButton2.Checked)
                {
                    cPersonCode = myTreeList1.FocusedNode.ParentNode.ParentNode.ParentNode.ParentNode.GetValue("TreeList").ToString();
                }
                else if (radioButton3.Checked)
                {
                }
                else if (radioButton4.Checked)
                {
                    cCusCode = myTreeList1.FocusedNode.ParentNode.ParentNode.ParentNode.ParentNode.GetValue("TreeList").ToString();
                }
                
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
                    frm.销售出库明细(cDepCode, cPersonCode, cDCName, cInvCode, cCusCode, txt年.Text.Trim(), month);
                    
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

        private void buttonEdit客户_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                FrmCustomer frm = new FrmCustomer(buttonEdit客户.Text.ToString(), Conn, true);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    buttonEdit客户.EditValue = frm.sCusCode;

                    frm.Enabled = true;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit销售员_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                FrmPerson frm = new FrmPerson(buttonEdit销售员.Text.ToString(), Conn, true);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    buttonEdit销售员.EditValue = frm.sPerCode;

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

        private void buttonEdit客户_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (buttonEdit客户.Text.Trim() != "")
                {
                    lookUpEdit客户名称.EditValue = buttonEdit客户.Text.Trim();
                }
                else
                {
                    lookUpEdit客户名称.EditValue = null;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit客户_Leave(object sender, EventArgs e)
        {
            try
            {
                if (buttonEdit客户.Text.Trim() == "")
                    return;
                if (lookUpEdit客户名称.Text.Trim() == "")
                {
                    buttonEdit客户.Text = "";
                    buttonEdit客户.Focus();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit销售员_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (buttonEdit销售员.Text.Trim() != "")
                {
                    lookUpEdit销售员名称.EditValue = buttonEdit销售员.Text.Trim();
                }
                else
                {
                    lookUpEdit销售员名称.EditValue = null;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit销售员_Leave(object sender, EventArgs e)
        {
            try
            {
                if (buttonEdit销售员.Text.Trim() == "")
                    return;
                if (lookUpEdit销售员名称.Text.Trim() == "")
                {
                    buttonEdit销售员.Text = "";
                    buttonEdit销售员.Focus();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit部门_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                FrmDepartment frm = new FrmDepartment(buttonEdit部门.Text.ToString(), Conn, true);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    buttonEdit部门.EditValue = frm.sPerCode;

                    frm.Enabled = true;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit部门_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (buttonEdit部门.Text.Trim() != "")
                {
                    lookUpEdit部门.EditValue = buttonEdit部门.Text.Trim();
                }
                else
                {
                    lookUpEdit部门.EditValue = null;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit部门_Leave(object sender, EventArgs e)
        {
            try
            {
                if (buttonEdit部门.Text.Trim() == "")
                    return;
                if (lookUpEdit部门.Text.Trim() == "")
                {
                    buttonEdit部门.Text = "";
                    buttonEdit部门.Focus();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh_Click(null, null);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh_Click(null, null);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh_Click(null, null);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh_Click(null, null);
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