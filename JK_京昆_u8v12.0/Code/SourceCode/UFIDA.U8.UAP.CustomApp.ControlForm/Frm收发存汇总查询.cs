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
    public partial class Frm收发存汇总查询 : UserControl
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

        public Frm收发存汇总查询()
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

        private void Frm收发存汇总查询_Load(object sender, EventArgs e)
        {
            try
            {
                Frm明细 frm = new Frm明细(Conn);
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

                lookUpEditcFree4.EditValue = "";
                lookUpEditcPosition.EditValue = "";
                lookUpEdit仓库.EditValue = "";

                sSQL = @"select cValue from UserDefine where cID=29  ORDER BY cAlias";
                dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                dr = dt.NewRow();
                dt.Rows.InsertAt(dr, 0);
                lookUpEditcFree4.Properties.DataSource = dt;

                sSQL = @"select cValue from UserDefine where cID=28  ORDER BY cAlias";
                dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                dr = dt.NewRow();
                dt.Rows.InsertAt(dr, 0);
                lookUpEditcFree3.Properties.DataSource = dt;

                sSQL = @"select cPosCode,cPosName from Position ";
                dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                dr = dt.NewRow();
                dt.Rows.InsertAt(dr, 0);
                lookUpEditcPosition.Properties.DataSource = dt;

                btnRefresh_Click(null, null);

                myTreeList1.SetBandsWidth(50);

                DataTable dtck = SqlHelper.ExecuteDataset(Conn, CommandType.Text, @"select * from Warehouse where dWhEndDate is null ORDER BY cWhCode").Tables[0];
                DataTable dtproj = SqlHelper.ExecuteDataset(Conn, CommandType.Text, @"select cValue from UserDefine where cID=28  ORDER BY cAlias").Tables[0];
                DataTable dtqc = SqlHelper.ExecuteDataset(Conn, CommandType.Text, @"select * from _QC").Tables[0];

                int i = 0;
                MyTreeListBand Band1 = myTreeList1.Bands.Add(i, 1, "分类品名");
                Band1.SetColumn(0, myTreeList1.Columns["TreeList"], "分类", false, DevExpress.Utils.HorzAlignment.Default);

                i = i + 1;

                //MyTreeListBand Band2 = myTreeList1.Bands.Add(i, 1, "");
                //Band2.SetColumn(0, myTreeList1.Columns["cFree1"], "包装", false, DevExpress.Utils.HorzAlignment.Default);
                //i = i + 1;

                MyTreeListBand Band3 = myTreeList1.Bands.Add(i, 1, "");
                Band3.SetColumn(0, myTreeList1.Columns["计量单位"], "计量单位", false, DevExpress.Utils.HorzAlignment.Far);
                i = i + 1;

                MyTreeListBand Band4 = myTreeList1.Bands.Add(i, 4, "");
                Band4.SetColumn(0, myTreeList1.Columns["期初结存数量"], "期初库存", false, DevExpress.Utils.HorzAlignment.Far);
                Band4.SetColumn(1, myTreeList1.Columns["本期变动"], "区间变动", false, DevExpress.Utils.HorzAlignment.Far);
                Band4.SetColumn(2, myTreeList1.Columns["期末结存数量"], "期末库存", false, DevExpress.Utils.HorzAlignment.Far);
                Band4.SetColumn(3, myTreeList1.Columns["采购订单在途"], "期末采购未入库", false, DevExpress.Utils.HorzAlignment.Far);
                i = i + 4;

                MyTreeListBand Band5 = myTreeList1.Bands.Add(i, 4, "区间出库");
                Band5.SetColumn(0, myTreeList1.Columns["iQty32"], "销售出（退）库", false, DevExpress.Utils.HorzAlignment.Far);
                Band5.SetColumn(1, myTreeList1.Columns["iQty11"], "生产出（退）库", false, DevExpress.Utils.HorzAlignment.Far);
                Band5.SetColumn(2, myTreeList1.Columns["iQty09"], "其他出库", false, DevExpress.Utils.HorzAlignment.Far);
                Band5.SetColumn(3, myTreeList1.Columns["本期出库"], "合计", false, DevExpress.Utils.HorzAlignment.Far);

                
                i = i + 4;
                MyTreeListBand Band6 = myTreeList1.Bands.Add(i, 4, "区间入库");
                Band6.SetColumn(0, myTreeList1.Columns["iQty10"], "生产入库", false, DevExpress.Utils.HorzAlignment.Far);
                Band6.SetColumn(1, myTreeList1.Columns["iQty01"], "采购入库", false, DevExpress.Utils.HorzAlignment.Far);
                Band6.SetColumn(2, myTreeList1.Columns["iQty08"], "其他入库", false, DevExpress.Utils.HorzAlignment.Far);
                Band6.SetColumn(3, myTreeList1.Columns["本期入库"], "合计", false, DevExpress.Utils.HorzAlignment.Far);

                i = i + 4;
                //MyTreeListBand Band6 = myTreeList1.Bands.Add(i, 2, "期末");
                
                //i = i + 2;

                MyTreeListBand Band10 = myTreeList1.Bands.Add(i, 1, "存货编码");
                Band10.SetColumn(0, myTreeList1.Columns["cInvCode"], "编码", false, DevExpress.Utils.HorzAlignment.Default);
                i = i + 1;

                myTreeList1.ViewInfo.RC.NeedsRestore = true;
                myTreeList1.BestFitColumns();
                myTreeList1.LayoutChanged();
                myTreeList1.Columns["TreeList"].Width = 200;
                
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载数据失败");
            }
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
                string 仓库 = "";
                DataTable dtck = SqlHelper.ExecuteDataset(Conn, CommandType.Text, @"select * from Warehouse where dWhEndDate is null ORDER BY cWhCode").Tables[0];
                DataTable dtproj = SqlHelper.ExecuteDataset(Conn, CommandType.Text, @"select cValue from UserDefine where cID=28  ORDER BY cAlias").Tables[0];
                DataTable dtqc = SqlHelper.ExecuteDataset(Conn, CommandType.Text, @"select * from _QC").Tables[0];
                
                数据源 sfc = new 数据源();
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

                string cFree3 = "";
                if (lookUpEditcFree3.EditValue != null)
                {
                    cFree3 = lookUpEditcFree3.EditValue.ToString().Trim();
                }

                string cFree4 = "";
                if (lookUpEditcFree4.EditValue != null)
                {
                    cFree4 = lookUpEditcFree4.EditValue.ToString().Trim();
                }

                string cWhCode = "";
                if (lookUpEdit仓库.EditValue != null)
                {
                    cWhCode = lookUpEdit仓库.EditValue.ToString().Trim();
                }

                string cPosCode = "";
                if (lookUpEditcPosition.EditValue != null)
                {
                    cPosCode = lookUpEditcPosition.EditValue.ToString().Trim();
                }

                string d1 = "";
                string d2 = "";
                系统服务.规格化.ReturnDate(out d1, out d2, rdo今日.Checked, rdo本月.Checked, rdo本季.Checked, rdo本年.Checked);
                bool bcHandler = 系统服务.规格化.ReturncHandler(rdo审核.Checked, rdo未审.Checked);
                bool bcHas = 系统服务.规格化.ReturncHandler(rdo包含未发生物料.Checked, rdo不包含未发生物料.Checked);
                DataTable dt = sfc.收发存汇总(Conn, cInvCode1, cInvCode2, d1, d2, 1, bcHandler, bcHas, cFree3, cFree4, cWhCode, cPosCode, "", "");

                DataTable dtBind = new DataTable();
                dtBind.Columns.Add("ID");
                dtBind.Columns.Add("ParentID");
                dtBind.Columns.Add("TreeList");
                dtBind.Columns.Add("cInvCode");
                //dtBind.Columns.Add("cFree1");
                dtBind.Columns.Add("期初结存数量", typeof(decimal));
                dtBind.Columns.Add("本期出库", typeof(decimal));
                dtBind.Columns.Add("本期入库", typeof(decimal));
                dtBind.Columns.Add("本期变动", typeof(decimal));
                dtBind.Columns.Add("期末结存数量", typeof(decimal));
                dtBind.Columns.Add("采购订单在途", typeof(decimal));

                dtBind.Columns.Add("iQty32", typeof(decimal));
                dtBind.Columns.Add("iQty11", typeof(decimal));
                dtBind.Columns.Add("iQty09", typeof(decimal));
                dtBind.Columns.Add("iQty10", typeof(decimal));
                dtBind.Columns.Add("iQty01", typeof(decimal));
                dtBind.Columns.Add("iQty08", typeof(decimal));

                string[] sum = new string[12];
                sum[0] = "期初结存数量";
                sum[1] = "本期出库";
                sum[2] = "本期入库";
                sum[3] = "本期变动";
                sum[4] = "期末结存数量";
                sum[5] = "采购订单在途";

                sum[6] = "iQty32";
                sum[7] = "iQty11";
                sum[8] = "iQty09";
                sum[9] = "iQty10";
                sum[10] = "iQty01";
                sum[11] = "iQty08";

                string[] col = new string[] { "cInvCode" };
                myTreeList1.Band(dt, dtBind
                       , new string[] { "cInvCName1", "cInvCName2", "cInvCName3", "cInvName", "cInvStd", "计量单位" }
                       , sum, col);
                //for (int i = 0; i < myTreeList1.Nodes.Count; i++)
                //{
                //    myTreeList1.Nodes[i].Expanded = true;
                //}
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
                string d1 = "";
                string d2 = "";
                系统服务.规格化.ReturnDate(out d1, out d2, rdo今日.Checked, rdo本月.Checked, rdo本季.Checked, rdo本年.Checked);
                bool bcHandler = 系统服务.规格化.ReturncHandler(rdo审核.Checked, rdo未审.Checked);
                bool bcHas = 系统服务.规格化.ReturncHandler(rdo包含未发生物料.Checked, rdo不包含未发生物料.Checked);
                string cFree1 = myTreeList1.FocusedNode.GetValue("cFree1").ToString();
                string cFree3 = myTreeList1.FocusedNode.GetValue("cFree3").ToString();
                string cWhCode = lookUpEdit仓库.EditValue.ToString();
                string cFree4 = lookUpEditcFree4.EditValue.ToString();
                string cposname = myTreeList1.FocusedNode.GetValue("cposname").ToString();
                if (cInvCode != "")
                {
                    if (Caption == "期初结存数量" || Caption == "期末结存数量")
                    {
                        Frm库存物资统计简表查询明细 frm = new Frm库存物资统计简表查询明细(Conn, cInvCode, cInvCode, d1, d2, cFree1, cFree3, cFree4, cposname, cWhCode);
                        frm.Show();
                        if (DialogResult.OK == frm.ShowDialog())
                        {
                            frm.Enabled = true;
                        }
                    }
                    else if (Caption == "总计入库数量" || Caption == "总计出库数量" || Caption == "本期变动")
                    {
                        Frm明细 frm = new Frm明细(Conn);
                        frm.收发存汇总本期单据联查汇总(cInvCode, d1, d2, bcHandler, bcHas, cFree3, cFree4, cWhCode, cposname);
                        frm.Show();
                        if (DialogResult.OK == frm.ShowDialog())
                        {
                            frm.Enabled = true;
                        }
                    }
                    else if (Caption == "采购订单在途")
                    {
                        Frm明细 frm = new Frm明细(Conn);
                        frm.收发存汇总采购订单在途(cInvCode, d1, d2, bcHandler);
                        frm.Show();
                        if (DialogResult.OK == frm.ShowDialog())
                        {
                            frm.Enabled = true;
                        }
                    }
                    else if (Caption == "iQty32" || Caption == "iQty11" || Caption == "iQty09" || Caption == "iQty10" || Caption == "iQty01" || Caption == "iQty08")
                    {
                        string RdFlag="";
                        switch (Caption)
                        {
                            case "iQty32":
                                RdFlag = "32";
                                break;
                            case "iQty11":
                                RdFlag = "11";
                                break;
                            case "iQty09":
                                RdFlag = "09";
                                break;
                            case "iQty10":
                                RdFlag = "10";
                                break;
                            case "iQty08":
                                RdFlag = "08";
                                break;
                            case "iQty01":
                                RdFlag = "01";
                                break;
                        }
                        Frm明细 frm = new Frm明细(Conn);
                        //frm.出入库单明细(cInvCode, cInvCode, d1, d2, cposname, cFree1, cFree3, -1, "", Flag);
                        frm.收发存汇总本期单据联查明细(cInvCode, d1, d2, bcHandler, bcHas, cFree3, cFree4, cWhCode, cposname, "", RdFlag);
                        frm.Show();
                        if (DialogResult.OK == frm.ShowDialog())
                        {
                            frm.Enabled = true;
                        }
                    }
                    
                }
                else
                {
                    //Frm收发存汇总查询明细 frm = new Frm收发存汇总查询明细(Conn, cInvCode, cInvCode, sdate, edate, cFree1, cFree3, cFree4, cposname, cWhCode);
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