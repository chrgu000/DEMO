using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 系统服务
{
    public partial class Frm库存_New : Form
    {
        string tablename = "RdRecord";
        string tableid = "ID";
        string tablecode = "cRdCode";
        string tablenames = "RdRecords";
        string tableids = "AutoID";
        string sSQL;
        protected 系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
        protected 系统服务.ClsGetSQL clsGetSQL = 系统服务.ClsGetSQL.Instance();
        protected 系统服务.公共调用 clsPublic = new 系统服务.公共调用();
        public string 红蓝标志;
        public string 客户;
        public DataTable dt;
        DataTable dthas;
        public string RdAutoID;
        public string M2;
        public decimal iQty;
        public string cPosCode;
        public string cWhCode;
        public int type;//1 期初成品  2 原料或半成品  3 辅料
        public decimal MaxQty;
        public string RdAutoIDList;
        public decimal RdAutoIDListQty;
        public int Flag=0;//0 单选  1 多选 有传入需要存货 2 多选 未传入需要存货

        public Frm库存_New(int stype,DataTable sdt)
        {
            InitializeComponent();
            dthas = sdt;
            type = stype;
        }

        public Frm库存_New(int stype, string cInvCode, string M1)
        {
            InitializeComponent();
            buttonEdit物料编码1.EditValue = cInvCode;
            buttonEdit物料编码2.EditValue = cInvCode;
            textEdit色号.EditValue = M1;
            type = stype;
        }

        public Frm库存_New(int stype, string cInvCode, string M1, decimal sMaxQty, int sFlag, string sRdAutoIDList)
        {
            InitializeComponent();
            buttonEdit物料编码1.EditValue = cInvCode;
            buttonEdit物料编码2.EditValue = cInvCode;
            textEdit色号.EditValue = M1;
            type = stype;
            MaxQty = sMaxQty;
            Flag = sFlag;
            RdAutoIDList = sRdAutoIDList;
        }

        //public Frm库存_New(int stype, DataTable sdt, string cInvCode, string M1)
        //{
        //    InitializeComponent();
        //    buttonEdit物料编码1.EditValue = cInvCode;
        //    buttonEdit物料编码2.EditValue = cInvCode;
        //    textEdit色号.EditValue = M1;
        //    dthas = sdt;
        //    type = stype;
        //}

        public Frm库存_New()
        {
            InitializeComponent();

            #region 禁止用户调整表格

            layoutControl1.AllowCustomizationMenu = false;

            //gridView1.OptionsMenu.EnableColumnMenu = false;
            //gridView1.OptionsMenu.EnableFooterMenu = false;
            //gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            //gridView1.OptionsMenu.ShowAutoFilterRowItem = false;
            //gridView1.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            //gridView1.OptionsMenu.ShowGroupSortSummaryItems = false;
            //gridView1.OptionsMenu.ShowGroupSummaryEditorItem = false;
            //gridView1.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.False;
            //gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            //gridView1.OptionsCustomization.AllowColumnMoving = false;
            //gridView1.OptionsCustomization.

            #endregion
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm库存_New_Load(object sender, EventArgs e)
        {
            try
            {
                SetLookUpEdit();
                if (Flag == 1)
                {
                    gridCol选中数量.Visible = true;
                }
                if (lookUpEdit物料编码1.Text != "" || lookUpEdit物料编码2.Text != "")
                {
                    buttonEdit物料编码1.Enabled = false;
                    buttonEdit物料编码2.Enabled = false;
                }
                else
                {
                    buttonEdit物料编码1.Enabled = true;
                    buttonEdit物料编码2.Enabled = true;
                }
                GetGrid();
                if (Flag == 1)
                {
                    string[] split = RdAutoIDList.Split('|');
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        string AutoID = gridView1.GetRowCellValue(i, gridColAutoID).ToString();
                        for (int j = 0; j < split.Length; j++)
                        {
                            string[] split_2 = split[j].Split(':');
                            if (AutoID == split_2[0])
                            {
                                gridView1.SetRowCellValue(i, gridCol选择, "√");
                                gridView1.SetRowCellValue(i, gridCol选中数量, split_2[5]);
                            }
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败：" + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void GetGrid()
        {
            if (type == 1)//普通出库
            {
                sSQL = @"select column into #a from RdRecord01 a left join RdRecords01 b on a.ID=b.ID left join RdStyle r on r.cRSCode=a.cRSCode 
where a.Flag=1 and isnull(b.iQuantity,0)-isnull(b.iOutQuantity,0)>0 and a.dVerifysysPerson is not null and a.dClosesysPerson is null and 1=1 

insert into #a select column from RdRecord02 a left join RdRecords02 b on a.ID=b.ID left join RdStyle r on r.cRSCode=a.cRSCode 
where a.Flag=1 and isnull(b.iQuantity,0)-isnull(b.iOutQuantity,0)>0 and a.dVerifysysPerson is not null and a.dClosesysPerson is null and 1=1 

insert into #a select column from RdRecord05 a left join RdRecords05 b on a.ID=b.ID left join RdStyle r on r.cRSCode=a.cRSCode 
where a.Flag=1 and isnull(b.iQuantity,0)-isnull(b.iOutQuantity,0)>0 and a.dVerifysysPerson is not null and a.dClosesysPerson is null and a.cRSCode<>'0502' and a.cRSCode<>'0503' and 1=1

insert into #a select column from RdRecord11 a left join RdRecords11 b on a.ID=b.ID left join RdStyle r on r.cRSCode=a.cRSCode 
where a.Flag=2 and isnull(-b.iQuantity,0)-isnull(b.iOutQuantity,0)>0 and a.dVerifysysPerson is not null and a.dClosesysPerson is null and 1=1 

insert into #a select column from RdRecord12 a left join RdRecords12 b on a.ID=b.ID left join RdStyle r on r.cRSCode=a.cRSCode 
where a.Flag=2 and isnull(-b.iQuantity,0)-isnull(b.iOutQuantity,0)>0 and a.dVerifysysPerson is not null and a.dClosesysPerson is null and 1=1 

insert into #a select column from RdRecord15 a left join RdRecords15 b on a.ID=b.ID left join RdStyle r on r.cRSCode=a.cRSCode 
where a.Flag=2 and isnull(-b.iQuantity,0)-isnull(b.iOutQuantity,0)>0 and a.dVerifysysPerson is not null and a.dClosesysPerson is null and a.cRSCode<>'1502' and a.cRSCode<>'1503' and 1=1";
                gridColsBoxQty.Visible = false;
            }
            else if (type == 2)//期初成品出库
            {
                sSQL = @"select column into #a from RdRecord05 a left join RdRecords05 b on a.ID=b.ID left join RdStyle r on r.cRSCode=a.cRSCode 
where a.Flag=1 and isnull(b.iQuantity,0)-isnull(b.iOutQuantity,0)>0 and a.dVerifysysPerson is not null and a.dClosesysPerson is null and 1=1  and a.cRSCode='0502'";
                gridColsBoxQty.Visible = false;
            }
            else if (type == 3)//辅料出库
            {
                sSQL = @"select column into #a from RdRecord05 a left join RdRecords05 b on a.ID=b.ID left join RdStyle r on r.cRSCode=a.cRSCode 
where a.Flag=1 and isnull(b.iQuantity,0)-isnull(b.iOutQuantity,0)>0 and a.dVerifysysPerson is not null and a.dClosesysPerson is null and 1=1  and a.cRSCode='0503'";
            }
            else if (type == 4)//委外材料出库
            {
                sSQL = @"select column into #a from RdRecord01 a left join RdRecords01 b on a.ID=b.ID left join RdStyle r on r.cRSCode=a.cRSCode 
where a.Flag=1 and isnull(b.iQuantity,0)-isnull(b.iOutQuantity,0)>0 and a.dVerifysysPerson is not null and a.dClosesysPerson is null and 1=1 

insert into #a select column from RdRecord02 a left join RdRecords02 b on a.ID=b.ID left join RdStyle r on r.cRSCode=a.cRSCode 
where a.Flag=1 and isnull(b.iQuantity,0)-isnull(b.iOutQuantity,0)>0 and a.dVerifysysPerson is not null and a.dClosesysPerson is null and 1=1 

insert into #a select column from RdRecord11 a left join RdRecords11 b on a.ID=b.ID left join RdStyle r on r.cRSCode=a.cRSCode 
where a.Flag=2 and isnull(-b.iQuantity,0)-isnull(b.iOutQuantity,0)>0 and a.dVerifysysPerson is not null and a.dClosesysPerson is null and 1=1 

insert into #a select column from RdRecord05 a left join RdRecords05 b on a.ID=b.ID left join RdStyle r on r.cRSCode=a.cRSCode 
where a.Flag=1 and isnull(b.iQuantity,0)-isnull(b.iOutQuantity,0)>0 and a.dVerifysysPerson is not null and a.dClosesysPerson is null and a.cRSCode<>'0502' and 1=1";
                gridColsBoxQty.Visible = false;
            }
            sSQL = sSQL + @"
            select * from #a";
            sSQL = sSQL.Replace("column", @"isnull(case when a.flag=1 then b.iQuantity else -b.iQuantity end,0)-isnull(b.iOutQuantity,0) as iQuantity, 
isnull(case when a.flag=1 then b.iNum else -b.iNum end,0)-isnull(b.iOutNum,0) as iNum,
0 as sBoxQty,    
b.iUnitPrice*(isnull(b.iQuantity,0)-isnull(b.iOutQuantity,0)) as iMoney,
b.iNatUnitPrice*(isnull(b.iQuantity,0)-isnull(b.iOutQuantity,0)) as iNatMoney,
a.ID, a.cRdCode, dDate, cPersonCode, cOperator, cDepCode, cWhCode, cCusCode, cVenCode,a.cRSCode,null as cMOCode,'' as iChk, b.AutoID,b.cInvCode,b.iNatTax, b.iTaxRate,b.iNatUnitPrice,
b.M1,b.M2,b.M3,b.M4,b.M5,b.M6,b.M7,b.M8,b.M9,b.M10,b.iChangRate, b.iUnitPrice,b.cPosCode,b.D1,b.D2,convert(decimal(18, 6),null) as Qty");
            if (lookUpEdit单据号1.EditValue!=null && lookUpEdit单据号1.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.cRdCode>='" + lookUpEdit单据号1.EditValue.ToString().Trim() + "'");
            }
            if (lookUpEdit单据号2.EditValue!=null && lookUpEdit单据号2.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.cRdCode<='" + lookUpEdit单据号2.EditValue.ToString().Trim() + "'");
            }
            if (dateEdit单据日期1.EditValue!=null && dateEdit单据日期1.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and dDate='" + dateEdit单据日期1.EditValue.ToString().Trim() + "'");
            }
            if (dateEdit单据日期2.EditValue!=null && dateEdit单据日期2.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and dDate<='" + dateEdit单据日期2.EditValue.ToString().Trim() + "'");
            }
            if (buttonEdit物料编码1.EditValue != null && buttonEdit物料编码1.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and b.cInvCode>= '" + buttonEdit物料编码1.EditValue.ToString().Trim() + "'");
            }
            if (buttonEdit物料编码2.EditValue != null && buttonEdit物料编码2.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and b.cInvCode<= '" + buttonEdit物料编码2.EditValue.ToString().Trim() + "'");
            }
            if (textEdit色号.EditValue != null && textEdit色号.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and b.M1= '" + textEdit色号.EditValue.ToString().Trim() + "'");
            }
            if (textEdit缸号.EditValue != null && textEdit缸号.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and b.M2= '" + textEdit缸号.EditValue.ToString().Trim() + "'");
            }
            if (cWhCode != null && cWhCode != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.cWhCode= '" + cWhCode.Trim() + "'");
            }
            if (dthas!=null && dthas.Rows.Count != 0)
            {
                string s = "";
                for (int i = 0; i < dthas.Rows.Count; i++)
                {
                    if (dthas.Rows[i]["RdAutoID"].ToString() != "")
                    {
                        if (s != "")
                        {
                            s = s + ",";
                        }
                        s = s + dthas.Rows[i]["RdAutoID"].ToString();
                    }
                }
                if (s.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and b.AutoID not in (" + s + ")");
                }
            }
            sSQL = sSQL + " order by  " + tablecode;
            dt = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dt;
        }

        public void Get(string 单据号1, string 单据号2, string 单据日期1, string 单据日期2,string 制单日期1,string 制单日期2,string 业务员,
            string 部门, string 客户1, string 客户2, string 审核日期1, string 审核日期2, string 制单人1, string 制单人2, string 审核人1, string 审核人2)
        {
            lookUpEdit单据号1.EditValue = 单据号1;
            lookUpEdit单据号2.EditValue = 单据号2;
            if (单据日期1 != null && 单据日期1 != "")
            {
                单据日期1 = DateTime.Parse(单据日期1).ToString("yyyy-MM-dd");
                dateEdit单据日期1.EditValue = 单据日期1;
            }
            if (单据日期2 != null && 单据日期2 != "")
            {
                单据日期2 = DateTime.Parse(单据日期2).ToString("yyyy-MM-dd");
                dateEdit单据日期2.EditValue = 单据日期2;
            }
        }

        private void SetLookUpEdit()
        {
            //系统服务.LookUp.RdRecord("", "0", lookUpEdit单据号1);
            //系统服务.LookUp.RdRecord("", "0", lookUpEdit单据号2);

            系统服务.LookUp.Inventory(lookUpEdit物料编码1);
            系统服务.LookUp.Inventory(lookUpEdit物料编码2);

            系统服务.LookUp.ColorNo(ItemLookUpEditM1);

            系统服务.LookUp.Warehouse(ItemLookUpEdit仓库);
            系统服务.LookUp.Position(ItemLookUpEdit货位);
            系统服务.LookUp.RdStyle(ItemLookUpEdit出入库类别);
            系统服务.LookUp.MOStyle(ItemLookUpEdit委外类别);

            系统服务.LookUp.Inventory(ItemLookUpEdit物料名称);
            ItemLookUpEdit物料名称.Properties.DisplayMember = "cInvName";
            系统服务.LookUp.Inventory(ItemLookUpEdit物料规格);
            ItemLookUpEdit物料规格.Properties.DisplayMember = "cInvStd";
            
        }

        private void btnEnsure_Click(object sender, EventArgs e)
        {
            string bCode = "";
            bool b = true;
            string sErr = "";
            if (dt != null)
            {
                if (Flag == 1)
                {
                    decimal tmpQty = 0;
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (gridView1.IsRowSelected(i))
                        {
                            tmpQty = tmpQty + clsPublic.ReturnDecimal(dt.Rows[i]["Qty"].ToString());
                        }
                    }
                    if (tmpQty > MaxQty)
                    {
                        sErr = "引用数量超过最大数量，最大" + MaxQty;
                    }

                    RdAutoIDList = "";
                    RdAutoIDListQty = 0;
                    for (int i = dt.Rows.Count - 1; i >= 0; i--)
                    {
                        if (dt.Rows[i]["iChk"].ToString() == "√" && clsPublic.ReturnDecimal(dt.Rows[i]["Qty"].ToString()) > 0)
                        {
                            if (bCode == "")
                            {
                                bCode = dt.Rows[i]["ID"].ToString();
                            }
                            else
                            {
                                if (bCode != dt.Rows[i]["ID"].ToString())
                                {
                                    b = false;
                                }
                            }
                            RdAutoID = dt.Rows[i]["AutoID"].ToString();
                            M2 = dt.Rows[i]["M2"].ToString();
                            //cWhCode = dt.Rows[i]["cWhCode"].ToString();
                            cPosCode = dt.Rows[i]["cPosCode"].ToString();
                            iQty = clsPublic.ReturnDecimal(dt.Rows[i]["iQuantity"].ToString());
                            if (RdAutoIDList != "")
                            {
                                RdAutoIDList = RdAutoIDList + "|";
                            }
                            RdAutoIDList = RdAutoIDList + RdAutoID
                                + ":" + dt.Rows[i]["cWhCode"].ToString()
                                + ":" + dt.Rows[i]["cPosCode"].ToString()
                                + ":" + dt.Rows[i]["M1"].ToString()
                                + ":" + dt.Rows[i]["M2"].ToString()
                                + ":" + dt.Rows[i]["Qty"].ToString();
                            RdAutoIDListQty = RdAutoIDListQty + clsPublic.ReturnDecimal(dt.Rows[i]["Qty"].ToString());
                        }
                        if (dt.Rows[i]["iChk"].ToString() != "√")
                        {
                            dt.Rows.Remove(dt.Rows[i]);
                        }
                    }
                }
                else if (Flag == 2)
                {
                    for (int i = dt.Rows.Count - 1; i >= 0; i--)
                    {
                        if (dt.Rows[i]["iChk"].ToString() == "√")
                        {
                            RdAutoID = dt.Rows[i]["AutoID"].ToString();
                            M2 = dt.Rows[i]["M2"].ToString();
                            cWhCode = dt.Rows[i]["cWhCode"].ToString();
                            cPosCode = dt.Rows[i]["cPosCode"].ToString();
                            iQty = clsPublic.ReturnDecimal(dt.Rows[i]["iQuantity"].ToString());
                        }
                        if (dt.Rows[i]["iChk"].ToString() != "√")
                        {
                            dt.Rows.Remove(dt.Rows[i]);
                        }
                    }
                }
                else
                {
                    for (int i = dt.Rows.Count - 1; i >= 0; i--)
                    {
                        if (dt.Rows[i]["iChk"].ToString() == "√")
                        {
                            if (bCode == "")
                            {
                                bCode = dt.Rows[i]["ID"].ToString();
                            }
                            else
                            {
                                if (bCode != dt.Rows[i]["ID"].ToString())
                                {
                                    b = false;
                                }
                            }
                            RdAutoID = dt.Rows[i]["AutoID"].ToString();
                            M2 = dt.Rows[i]["M2"].ToString();
                            cWhCode = dt.Rows[i]["cWhCode"].ToString();
                            cPosCode = dt.Rows[i]["cPosCode"].ToString();
                            iQty = clsPublic.ReturnDecimal(dt.Rows[i]["iQuantity"].ToString());
                        }
                        if (dt.Rows[i]["iChk"].ToString() != "√")
                        {
                            dt.Rows.Remove(dt.Rows[i]);
                        }
                    }
                }
            }
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("请至少选择一张单据");
                GetGrid();
            }
            else if (sErr != "")
            {
                MessageBox.Show(sErr);
            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void button查询_Click(object sender, EventArgs e)
        {
            try
            {
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (Flag == 0)
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.IsRowSelected(i))
                    {
                        if (gridView1.GetRowCellValue(i, gridCol选择).ToString() == "")
                        {
                            gridView1.SetRowCellValue(i, gridCol选择, "√");
                        }
                        else
                        {
                            gridView1.SetRowCellValue(i, gridCol选择, "");
                        }
                    }
                }
                //单选
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.IsRowSelected(i) == false)
                    {
                        gridView1.SetRowCellValue(i, gridCol选择, "");
                    }
                }
            }
            else if (Flag == 1)
            {
                decimal tmpQty = 0;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.IsRowSelected(i))
                    {
                        gridView1.SetRowCellValue(i, gridCol选中数量, clsPublic.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol数量).ToString()));
                        tmpQty = tmpQty + clsPublic.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol选中数量).ToString());
                        gridView1.SetRowCellValue(i, gridCol选择, "√");
                    }
                    if (gridView1.GetRowCellValue(i, gridCol选择).ToString() == "√")
                    {
                        tmpQty = tmpQty + clsPublic.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol选中数量).ToString());
                    }
                }
                if (tmpQty > MaxQty)
                {
                    MessageBox.Show("引用数量超过最大数量，最大" + MaxQty);
                }
            }
            else if (Flag == 2)
            {
                decimal tmpQty = 0;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.IsRowSelected(i))
                    {
                        gridView1.SetRowCellValue(i, gridCol选中数量, clsPublic.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol数量).ToString()));
                        tmpQty = tmpQty + clsPublic.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol选中数量).ToString());
                        gridView1.SetRowCellValue(i, gridCol选择, "√");
                    }
                    if (gridView1.GetRowCellValue(i, gridCol选择).ToString() == "√")
                    {
                        tmpQty = tmpQty + clsPublic.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol选中数量).ToString());
                    }
                }
            }

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            lookUpEdit单据号1.EditValue = "";
            lookUpEdit单据号2.EditValue = "";
            buttonEdit物料编码1.EditValue = "";
            buttonEdit物料编码2.EditValue = "";
            lookUpEdit物料编码1.EditValue = "";
            lookUpEdit物料编码2.EditValue = "";
            gridControl1.DataSource = null;
        }

        private void buttonEdit物料编码1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(1);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit物料编码1.EditValue = frm.sID;
                frm.Enabled = true;
            }
        }

        private void buttonEdit物料编码2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(1);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit物料编码2.EditValue = frm.sID;
                frm.Enabled = true;
            }
        }

        private void buttonEdit物料编码1_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit物料编码1.Text.Trim() != "")
                lookUpEdit物料编码1.EditValue = buttonEdit物料编码1.Text.Trim();
            else
                lookUpEdit物料编码1.EditValue = null;
        }

        private void buttonEdit物料编码1_Leave(object sender, EventArgs e)
        {
            if (buttonEdit物料编码1.Text.Trim() == "")
                return;
            if (lookUpEdit物料编码1.Text.Trim() == "")
            {
                buttonEdit物料编码1.Text = "";
                buttonEdit物料编码1.Focus();
            }
        }

        private void buttonEdit物料编码2_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit物料编码2.Text.Trim() != "")
                lookUpEdit物料编码2.EditValue = buttonEdit物料编码2.Text.Trim();
            else
                lookUpEdit物料编码2.EditValue = null;
        }

        private void buttonEdit物料编码2_Leave(object sender, EventArgs e)
        {
            if (buttonEdit物料编码2.Text.Trim() == "")
                return;
            if (lookUpEdit物料编码2.Text.Trim() == "")
            {
                buttonEdit物料编码2.Text = "";
                buttonEdit物料编码2.Focus();
            }
        }


    }
}
