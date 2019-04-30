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
    public partial class Frm产品产量情况表查询 : UserControl
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

        public Frm产品产量情况表查询()
        {
            InitializeComponent();
        }

        private void TreeListColumn(DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1, string caption, string fieldname, int visilbeindex)
        {
            treeListColumn1.Caption = caption;
            treeListColumn1.FieldName = fieldname;
            treeListColumn1.Name = "treeListColumn" + (visilbeindex + 1);
            treeListColumn1.Visible = true;
            treeListColumn1.VisibleIndex = visilbeindex;
            treeListColumn1.OptionsColumn.AllowEdit = false;
        }

        private void Frm产品产量情况表查询_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    string sSQL = "";
            //    DataTable dt;
            //    DataRow dr;
            //    Cls时间锁 cls = new Cls时间锁();
            //    if (cls.bchk时间锁(Conn) == false)
            //    {
            //        throw new Exception("加载数据失败");
            //    }
            //    LookUp.Inventory(Conn, lookUpEdit存货名称1);
            //    LookUp.Inventory(Conn, lookUpEdit存货名称2);

            //    LookUp.Warehouse(Conn, lookUpEdit仓库);

            //    lookUpEditcFree4.EditValue = "";
            //    lookUpEditcPosition.EditValue = "";
            //    lookUpEdit仓库.EditValue = "";

            //    sSQL = @"select cValue from UserDefine where cID=29  ORDER BY cAlias";
            //    dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
            //    dr = dt.NewRow();
            //    dt.Rows.InsertAt(dr, 0);
            //    lookUpEditcFree4.Properties.DataSource = dt;

            //    sSQL = @"select cPosCode,cPosName from Position ";
            //    dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
            //    dr = dt.NewRow();
            //    dt.Rows.InsertAt(dr, 0);
            //    lookUpEditcPosition.Properties.DataSource = dt;

            //    sSQL = "select datepart(yyyy,getdate())";
            //    dateEdit1.EditValue = DateTime.Now.Year.ToString() + "-01-01";
            //    dateEdit2.EditValue = DateTime.Now.ToString("yyyy-MM-dd");

            //    btnRefresh_Click(null, null);

            //    myTreeList1.SetBandsWidth(50);

            //    DataTable dtck = SqlHelper.ExecuteDataset(Conn, CommandType.Text, @"select * from Warehouse where dWhEndDate is null ORDER BY cWhCode").Tables[0];
            //    DataTable dtproj = SqlHelper.ExecuteDataset(Conn, CommandType.Text, @"select cValue from UserDefine where cID=28  ORDER BY cAlias").Tables[0];
            //    DataTable dtqc = SqlHelper.ExecuteDataset(Conn, CommandType.Text, @"select * from _QC").Tables[0];

            //    int i = 0;
            //    MyTreeListBand Band1 = myTreeList1.Bands.Add(i, 1, "分类品名");
            //    Band1.SetColumn(0, myTreeList1.Columns["TreeList"], "分类", false, DevExpress.Utils.HorzAlignment.Default);
                
            //    i = i + 1;

            //    MyTreeListBand Band2 = myTreeList1.Bands.Add(i, 1, "");
            //    Band2.SetColumn(0, myTreeList1.Columns["cFree1"], "包装", false, DevExpress.Utils.HorzAlignment.Default);
            //    i = i + 1;

            //    MyTreeListBand Band3 = myTreeList1.Bands.Add(i, 1, "");
            //    Band3.SetColumn(0, myTreeList1.Columns["iQuantity"],"数量", false, DevExpress.Utils.HorzAlignment.Far);
            //    i = i + 1;

            //    MyTreeListBand Band9 = myTreeList1.Bands.Add(i, 3, "检验汇总");
            //    Band9.SetColumn(0, myTreeList1.Columns["待检"], false, DevExpress.Utils.HorzAlignment.Far);
            //    Band9.SetColumn(1, myTreeList1.Columns["合格"], false, DevExpress.Utils.HorzAlignment.Far);
            //    Band9.SetColumn(2, myTreeList1.Columns["不合格"], false, DevExpress.Utils.HorzAlignment.Far);
            //    i = i + 3;

            //    MyTreeListBand Band5 = myTreeList1.Bands.Add(i, dtck.Rows.Count + dtproj.Rows.Count, "期末库位");
            //    Band5.CreateChild(0, dtck.Rows.Count, "实体库");
            //    Band5.CreateChild(dtck.Rows.Count, dtproj.Rows.Count, "虚拟库");
            //    for (int j = 0; j < dtck.Rows.Count; j++)
            //    {
            //        Band5.SetColumn(j, myTreeList1.Columns["cWhCode_" + dtck.Rows[j]["cWhCode"].ToString()], dtck.Rows[j]["cWhName"].ToString(), false, DevExpress.Utils.HorzAlignment.Far);
            //    }
            //    for (int j = 0; j < dtproj.Rows.Count; j++)
            //    {
            //        Band5.SetColumn(j + dtck.Rows.Count, myTreeList1.Columns["Project_" + dtproj.Rows[j]["cValue"].ToString().Trim()], dtproj.Rows[j]["cValue"].ToString(), false, DevExpress.Utils.HorzAlignment.Far);
            //    }
            //    i = i + dtck.Rows.Count + dtproj.Rows.Count;

            //    MyTreeListBand Band6 = myTreeList1.Bands.Add(i, 3, "区间生产出入库统计");
            //    Band6.SetColumn(0, myTreeList1.Columns["累计入库"], false, DevExpress.Utils.HorzAlignment.Far);
            //    Band6.SetColumn(1, myTreeList1.Columns["累计领料"], false, DevExpress.Utils.HorzAlignment.Far);
            //    Band6.SetColumn(2, myTreeList1.Columns["累计退库"], false, DevExpress.Utils.HorzAlignment.Far);
            //    i = i + 3;

            //    MyTreeListBand Band7 = myTreeList1.Bands.Add(i, 2, "区间采购统计");
            //    Band7.SetColumn(0, myTreeList1.Columns["采购入库"], false, DevExpress.Utils.HorzAlignment.Far);
            //    Band7.SetColumn(1, myTreeList1.Columns["退货数量"], false, DevExpress.Utils.HorzAlignment.Far);
            //    i = i + 2;

            //    MyTreeListBand Band8 = myTreeList1.Bands.Add(i, 2, "区间销售统计");
            //    Band8.SetColumn(0, myTreeList1.Columns["累计销售"], false, DevExpress.Utils.HorzAlignment.Far);
            //    Band8.SetColumn(1, myTreeList1.Columns["累计退货"], false, DevExpress.Utils.HorzAlignment.Far);
            //    i = i + 2;

            //    MyTreeListBand Band10 = myTreeList1.Bands.Add(i, 1, "存货编码");
            //    Band10.SetColumn(0, myTreeList1.Columns["cInvCode"], "编码", false, DevExpress.Utils.HorzAlignment.Default);
            //    i = i + 1;

            //    myTreeList1.ViewInfo.RC.NeedsRestore = true;
            //    myTreeList1.BestFitColumns();
            //    myTreeList1.LayoutChanged();
            //    myTreeList1.Columns["TreeList"].Width = 200;
                
            //}
            //catch (Exception ee)
            //{
            //    MessageBox.Show("加载数据失败");
            //}
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetGrid();
        }

        private void GetGrid()
        {
            try
            {
                Cls时间锁 cls = new Cls时间锁();
                if (cls.bchk时间锁(Conn) == false)
                {
                    throw new Exception("加载数据失败");
                }
                if (dateEdit1.Text.Trim() == "")
                {
                    throw new Exception("开始日期不可为空");
                }
                if (dateEdit2.Text.Trim() == "")
                {
                    throw new Exception("结束日期不可为空");
                }

                string 仓库 = "";
                DataTable dtck = SqlHelper.ExecuteDataset(Conn, CommandType.Text, @"select * from Warehouse where dWhEndDate is null ORDER BY cWhCode").Tables[0];
                DataTable dtproj = SqlHelper.ExecuteDataset(Conn, CommandType.Text, @"select cValue from UserDefine where cID=28  ORDER BY cAlias").Tables[0];
                DataTable dtqc = SqlHelper.ExecuteDataset(Conn, CommandType.Text, @"select * from _QC").Tables[0];
                
//                string sSQL = @"
//2222222222
//
//select ic1.cInvCCode as cInvCCode1,ic1.cInvCName as cInvCName1,ic2.cInvCCode as cInvCCode2,ic2.cInvCName as cInvCName2,ic3.cInvCCode as cInvCCode3,ic3.cInvCName as cInvCName3,a.cInvCode,cInvName,isnull(a.cFree1,'') AS cFree1,cInvStd
//,sum(iQMJCSL) as iQuantity,sum(累计入库) as 累计入库,sum(累计领料) as 累计领料,sum(累计退库) as 累计退库,sum(采购入库) as 采购入库,sum(退货数量) as 退货数量,sum(累计销售) as 累计销售,sum(累计退货) as 累计退货
//,convert(decimal(18, 3),null) as 待检,convert(decimal(18, 3),null) as 合格,convert(decimal(18, 3),null) as 不合格
//1111111111
//from #temp1 a 
//    left join InventoryClass ic1 on ic1.cInvCCode = left(a.cInvCCode,2)
//	left join InventoryClass ic2 on ic2.cInvCCode = left(a.cInvCCode,4)
//	left join InventoryClass ic3 on ic3.cInvCCode = left(a.cInvCCode,6) 
//group by ic1.cInvCCode,ic1.cInvCName,ic2.cInvCCode,ic2.cInvCName,ic3.cInvCCode,ic3.cInvCName,a.cInvCode,cInvName,isnull(a.cFree1,''),cInvStd  having  sum(a.iQMJCSL)<>0 order by ic1.cInvCCode
//";
                
//                //仓库
//                for (int i = 0; i < dtck.Rows.Count; i++)
//                {
//                    仓库 = 仓库 + @"
//                    ,sum(case when cWhCode='" + dtck.Rows[i]["cWhCode"].ToString().Trim() + "' then convert(decimal(18, 3),iQMJCSL) end) as " + dtck.Rows[i]["cWhName"].ToString().Trim() + "";
//                }

//                //虚拟仓
//                for (int i = 0; i < dtproj.Rows.Count; i++)
//                {
//                    仓库 = 仓库 + @"
//                    ,sum(case when cFree3='" + dtproj.Rows[i]["cValue"].ToString().Trim() + "' then convert(decimal(18, 3),iQMJCSL) end) as " + dtproj.Rows[i]["cValue"].ToString().Trim() + "";
//                }
//                //检验明细
////                for (int i = 0; i < dtqc.Rows.Count; i++)
////                {
////                    仓库 = 仓库 + @"
////                    ,convert(decimal(18, 3),null) as QCResult_1_" + dtqc.Rows[i]["QCCode"].ToString().Trim() 
////                      + ",convert(decimal(18, 3),null)  as QCResult_2_" + dtqc.Rows[i]["QCCode"].ToString().Trim() 
////                      + ",convert(decimal(18, 3),null)  as QCResult_3_" + dtqc.Rows[i]["QCCode"].ToString().Trim();
////                }
//                sSQL = sSQL.Replace("1111111111", 仓库);

//                if (buttonEdit存货编码1.EditValue != null && buttonEdit存货编码1.EditValue.ToString() != "")
//                {
//                    sSQL = sSQL.Replace("1=1", "1=1 and cInvCode>='" + buttonEdit存货编码1.EditValue.ToString().Trim() + "'");
//                }
//                if (buttonEdit存货编码2.EditValue != null && buttonEdit存货编码2.EditValue.ToString() != "")
//                {
//                    sSQL = sSQL.Replace("1=1", "1=1 and cInvCode<='" + buttonEdit存货编码2.EditValue.ToString().Trim() + "'");
//                }
//                if (buttonEdit仓库.EditValue != null && buttonEdit仓库.EditValue.ToString() != "")
//                {
//                    sSQL = sSQL.Replace("1=1", "1=1 and cWhCode='" + buttonEdit仓库.EditValue.ToString().Trim() + "' ");
//                }
//                if (lookUpEditcDefine3.Text != "")
//                {
//                    sSQL = sSQL.Replace("1=1", "1=1 and cFree4='" + lookUpEditcDefine3.EditValue.ToString().Trim() + "'");
//                }
//                if (lookUpEditcPosition.Text != "")
//                {
//                    sSQL = sSQL.Replace("1=1", "1=1 and cPosition ='" + lookUpEditcPosition.EditValue.ToString().Trim() + "'");
//                }
                数据源 sfc = new 数据源();
                //sSQL = sSQL.Replace("2222222222", sfc.收发存汇总(Conn, dateEdit1.DateTime.ToString("yyyy-MM-dd"), dateEdit2.DateTime.ToString("yyyy-MM-dd")));
                //DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                //DataTable dtjy = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sfc.检验()).Tables[0];
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    decimal q1 = 系统服务.规格化.ReturnDecimal(dtjy.Compute("sum(iQuantity)", "cInvCode='" + dt.Rows[i]["cInvCode"].ToString() + "' and cFree1='" + dt.Rows[i]["cFree1"].ToString() + "' and Conclusion='1'"));//待检
                //    decimal q2 = 系统服务.规格化.ReturnDecimal(dtjy.Compute("sum(iQuantity)", "cInvCode='" + dt.Rows[i]["cInvCode"].ToString() + "' and cFree1='" + dt.Rows[i]["cFree1"].ToString() + "' and Conclusion='2'"));//合格
                //    decimal q3 = 系统服务.规格化.ReturnDecimal(dtjy.Compute("sum(iQuantity)", "cInvCode='" + dt.Rows[i]["cInvCode"].ToString() + "' and cFree1='" + dt.Rows[i]["cFree1"].ToString() + "' and Conclusion='3'"));//不合格
                //    decimal q = 系统服务.规格化.ReturnDecimal(dt.Rows[i]["iQuantity"]);

                //    if (q > q3)
                //    {
                //        dt.Rows[i]["不合格"] = q3;
                //        q = q - q3;
                //    }
                //    else
                //    {
                //        dt.Rows[i]["不合格"] = q;
                //        q = 0;
                //    }

                //    if (q > q1)
                //    {
                //        dt.Rows[i]["待检"] = q1;
                //        q = q - q1;
                //    }
                //    else
                //    {
                //        dt.Rows[i]["待检"] = q;
                //        q = 0;
                //    }

                //    dt.Rows[i]["合格"] = q;
                //}
                string cInvCode1 = "";
                if (lookUpEdit存货名称1.EditValue != null)
                {
                    cInvCode1 = lookUpEdit存货名称1.EditValue.ToString().Trim();
                }
                string cInvCode2 = "";
                if (lookUpEdit存货名称2.EditValue != null)
                {
                    cInvCode2 = lookUpEdit存货名称2.EditValue.ToString().Trim();
                }
                DataTable dt = sfc.库存汇总(Conn, cInvCode1, cInvCode2, dateEdit2.DateTime.ToString("yyyy-MM-dd"), "", lookUpEdit仓库.EditValue.ToString());

                DataTable dtBind = new DataTable();
                dtBind.Columns.Add("ID");
                dtBind.Columns.Add("ParentID");
                dtBind.Columns.Add("TreeList");
                dtBind.Columns.Add("cInvCode");
                dtBind.Columns.Add("cFree1");
                dtBind.Columns.Add("iQuantity", typeof(decimal));
                dtBind.Columns.Add("累计入库", typeof(decimal));
                dtBind.Columns.Add("累计领料", typeof(decimal));
                dtBind.Columns.Add("累计退库", typeof(decimal));
                dtBind.Columns.Add("采购入库", typeof(decimal));
                dtBind.Columns.Add("退货数量", typeof(decimal));
                dtBind.Columns.Add("累计销售", typeof(decimal));
                dtBind.Columns.Add("累计退货", typeof(decimal));
                dtBind.Columns.Add("待检", typeof(decimal));
                dtBind.Columns.Add("合格", typeof(decimal));
                dtBind.Columns.Add("不合格", typeof(decimal));

                string[] sum = new string[11 + dtck.Rows.Count + dtproj.Rows.Count];
                sum[0] = "iQuantity";
                sum[1] = "累计入库";
                sum[2] = "累计领料";
                sum[3] = "累计退库";
                sum[4] = "采购入库";
                sum[5] = "退货数量";
                sum[6] = "累计销售";
                sum[7] = "累计退货";
                sum[8] = "待检";
                sum[9] = "合格";
                sum[10] = "不合格";
                
                //仓库
                for (int j = 0; j < dtck.Rows.Count; j++)
                {
                    dtBind.Columns.Add("cWhCode_" + dtck.Rows[j]["cWhCode"].ToString().Trim(), typeof(decimal));
                    sum[11 + j] = "cWhCode_" + dtck.Rows[j]["cWhCode"].ToString().Trim();
                }
                //虚拟仓
                for (int j = 0; j < dtproj.Rows.Count; j++)
                {
                    dtBind.Columns.Add("Project_" + dtproj.Rows[j]["cValue"].ToString().Trim(), typeof(decimal));
                    sum[11 + j + dtck.Rows.Count] = "Project_" + dtproj.Rows[j]["cValue"].ToString().Trim();
                }

                string[] col = new string[] { "cInvCode", "cFree1" };
                myTreeList1.Band(dt, dtBind
                       , new string[] { "cInvCName1", "cInvCName2", "cInvCName3", "cInvName", "cInvStd" }
                       , sum, col);
                for (int i = 0; i < myTreeList1.Nodes.Count; i++)
                {
                    myTreeList1.Nodes[i].Expanded = true;
                }
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
                sF.Filter = "Excel文件(*.xlsx)|*.xlsx|所有文件(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK == dRes)
                {
                    myTreeList1.ExportToXlsx(sF.FileName);
                    //NOPI.ToExcel(sF.FileName, "库存");
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
                DevExpress.XtraTreeList.Nodes.TreeListNode node =myTreeList1.FocusedNode;
                if (node == null)
                    return;
                if (node.HasChildren == true)
                    return;
                string Caption=myTreeList1.FocusedColumn.FieldName;
                string cInvCode = myTreeList1.FocusedNode.GetValue("cInvCode").ToString();
                string sdate = dateEdit1.DateTime.ToString("yyyy-MM-dd");
                string edate = dateEdit2.DateTime.ToString("yyyy-MM-dd");
                string cFree1 = myTreeList1.FocusedNode.GetValue("cFree1").ToString();
                string cFree3 = myTreeList1.FocusedNode.GetValue("cFree3").ToString();
                string cWhCode = lookUpEdit仓库.EditValue.ToString();
                string cFree4 = lookUpEditcFree4.EditValue.ToString();
                string cposname = myTreeList1.FocusedNode.GetValue("cposname").ToString();
                if (Caption == "累计入库" || Caption == "累计领料" || Caption == "累计退库"
                    || Caption == "采购入库" || Caption == "退货数量"
                    || Caption == "累计销售" || Caption == "累计退货")
                {
                    Frm明细 frm = new Frm明细(Conn);

                    //if (Caption =="累计入库")
                    //{
                    //    frm.累计入库(cInvCode, sdate, edate, cposname, cFree1, cFree3);
                    //}
                    //else if (Caption == "累计领料")
                    //{
                    //    frm.累计领料(cInvCode, sdate, edate, cposname, cFree1, cFree3, 0, "");
                    //}
                    //else if (Caption == "累计退库")
                    //{
                    //    frm.累计领料(cInvCode, sdate, edate, cposname, cFree1, cFree3, 1, "");
                    //}
                    //else if (Caption == "采购入库")
                    //{
                    //    frm.采购入库(cInvCode, sdate, edate, cposname, cFree1, cFree3, 0, "");
                    //}
                    //else if (Caption =="退货数量")
                    //{
                    //    frm.采购入库(cInvCode, sdate, edate, cposname, cFree1, cFree3, 1, "");
                    //}
                    //else if (Caption == "累计销售")
                    //{
                    //    frm.累计销售(cInvCode, sdate, edate, cposname, cFree1, cFree3, 0, "");
                    //}
                    //else if (Caption == "累计退货")
                    //{
                    //    frm.累计销售(cInvCode, sdate, edate, cposname, cFree1, cFree3, 1, "");
                    //}
                    frm.Show();
                    if (DialogResult.OK == frm.ShowDialog())
                    {
                        frm.Enabled = true;
                    }
                }
                else
                {
                    //Frm产品产量情况表查询明细 frm = new Frm产品产量情况表查询明细(Conn, cInvCode, cInvCode, sdate, edate, cFree1, cFree3, cFree4, cposname, cWhCode);
                    //frm.Show();
                    //if (DialogResult.OK == frm.ShowDialog())
                    //{
                    //    frm.Enabled = true;
                    //}
                }
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

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            bool b = !checkBox2.Checked;
            for (int i = myTreeList1.Bands.Count - 1; i >= 0; i--)
            {
                if (myTreeList1.Bands[i].Name == "区间生产出入库统计" || myTreeList1.Bands[i].Name == "区间采购统计" || myTreeList1.Bands[i].Name == "区间销售统计")
                {
                    myTreeList1.Bands[i].Visible = b;
                }
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