using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using UFIDA.U8.UAP.CustomApp.ControlForm.Business;
using DevExpress.XtraEditors;
using System.Xml;
using System.Collections;
using UFIDA.U8.UAP.CustomApp.ControlForm;
using TH.BaseClass;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class Sa_CloseBill : UserControl
    {
        //public class CmbDataSource
        //    public string WareHouseCode;
        //    public string WareHouseName;
        //}

        //public class UserMsg
        //{
        //    public string UserCode;
        //    public string UserName;
        //}
        string sFilePath = "";

        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }

        public Sa_CloseBill()
        {
            InitializeComponent();
        }


        private void Sa_CloseBill_Load(object sender, EventArgs e)
        {
            try
            {
                string sSQL = "select cSSCode ,cSSName from SettleStyle ";
                DataTable dtSettleStyle = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                ItemLookUpEdit结算方式.Properties.Columns.Clear();
                ItemLookUpEdit结算方式.Properties.DataSource = dtSettleStyle;
                ItemLookUpEdit结算方式.Properties.ValueMember = "cSSCode";
                ItemLookUpEdit结算方式.Properties.DisplayMember = "cSSName";
                ItemLookUpEdit结算方式.Properties.NullText = "";
                ItemLookUpEdit结算方式.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cSSCode", "结算方式编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cSSName", "结算方式名称")});

                sSQL = "select cCusCode  ,cCusName from Customer  ";
                DataTable dtCustomer = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                ItemLookUpEdit客户.Properties.Columns.Clear();
                ItemLookUpEdit客户.Properties.DataSource = dtCustomer;
                ItemLookUpEdit客户.Properties.ValueMember = "cCusCode";
                ItemLookUpEdit客户.Properties.DisplayMember = "cCusName";
                ItemLookUpEdit客户.Properties.NullText = "";
                ItemLookUpEdit客户.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusCode", "客户编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusName", "客户名称")});


                DateTime nowday = DateTime.Now;
                dateCreate.DateTime =nowday.AddDays(1 - nowday.Day);
                dateCreate2.DateTime = dateCreate.DateTime.AddMonths(1).AddDays(-1);
                //grdDetail.DataSource = Sa_CloseBillBLL.GetFormsData(GetFilterStr(), Conn);

                gridColChk.OptionsColumn.AllowEdit = true;
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载数据失败");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //gridView1.OptionsBehavior.Editable = false;

            if (dateCreate.Text.Trim() == "")
            {
                MessageBox.Show("票据日期不能为空");
                dateCreate.Focus();
                return;
            }
            if (dateCreate2.Text.Trim() == "")
            {
                MessageBox.Show("票据日期不能为空");
                dateCreate2.Focus();
                return;
            }
            if (dateCreate2.DateTime < dateCreate.DateTime)
            {
                MessageBox.Show("票据日期必须从小到大");
                dateCreate.Focus();
                return;
            }

            DataTable dt = Sa_CloseBillBLL.GetFormsData(GetFilterStr(), Conn);
            grdDetail.DataSource = dt;
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("没有任何数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            gridColChk.OptionsColumn.AllowEdit = true;
        }

        private string GetFilterStr()
        {
            List<string> filter = new List<string>();
            if (txt票据号.Text.Trim() != "")
                filter.Add(" and isnull(cVouchID,'') " + cmb票据号.Text + " '" + (cmb票据号.Text == "like" ? "%" : "") + txt票据号.Text + (cmb票据号.Text == "like" ? "%" : "") + "'");
            
            filter.Add(" and dVouchDate>='" + dateCreate.DateTime.ToString("yyyy-MM-dd") + "' and dVouchDate<='" + dateCreate2.DateTime.ToString("yyyy-MM-dd") + "' ");

            return string.Join("\r\n", filter.ToArray());
        }

        private void grvDetail_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {

            if (e.RowHandle < 0)
                return;
            e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                gridView1.PostEditor();
                this.Validate();

                string sErr = "";
                string outstr = "";
                bool b = false;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (Convert.ToBoolean(gridView1.GetRowCellValue(i, gridColChk)) == true && outstr.IndexOf("," + gridView1.GetRowCellValue(i, gridColiID).ToString().Trim() + ",") == -1)
                    {
                        if (outstr != "")
                        {
                            outstr = outstr + ",";
                        }
                        outstr = outstr + gridView1.GetRowCellValue(i, gridColiID).ToString().Trim();
                        b = true;

                    }
                }
                if (b == true)
                {
                    if (outstr != "")
                    {

                        DataTable dt = Sa_CloseBillBLL.GetFormsData(" and iID in(" + outstr + ")", Conn);
                        DataTable dts = Sa_CloseBillBLL.GetFormsData1(" and iID in (" + outstr + ")", Conn);
                        //sFilePath = SqlHelper.ExecuteDataset(Conn, CommandType.Text, "select Path from 基础信息映射表路径 ").Tables[0].Rows[0][0].ToString();
                        //if (System.IO.File.Exists(sFilePath) == false)//如果存在
                        //{
                        //MessageBox.Show("请选择基础信息映射表路径");
                        OpenFileDialog saveFileDialog1 = new OpenFileDialog();
                        saveFileDialog1.Title = "请选择基础信息映射表路径";
                        saveFileDialog1.InitialDirectory = Environment.SpecialFolder.DesktopDirectory.ToString();
                        saveFileDialog1.Filter = "excel Files(*.xls)|*.xls|All Files(*.*)|*.*";
                        saveFileDialog1.FileName = "";
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            sFilePath = saveFileDialog1.FileName;
                        }
                        else
                        {
                            MessageBox.Show("未选择基础信息映射表，将退出导出");
                            return;
                        }
                        //}
                        //if (System.IO.File.Exists(sFilePath) == false)
                        //{
                        //    throw new Exception("基础信息映射表路径选择失败");
                        //}
                        DataTable dt制单人映射表;
                        DataTable dt结算方式映射表;
                        DataTable dt客户映射表;
                        DataTable dt币种;
                        DataTable dt部门档案映射表;
                        DataTable dt开发默认值表;
                        DataTable dt人员档案映射表;

                        
                        try
                        {
                            dt制单人映射表 = NOPI.FromExcel(sFilePath, "制单人映射表", 1, 0, 3);
                        }
                        catch (Exception ee)
                        {
                            throw new Exception("制单人映射表取值失败:" + ee.Message);
                        }
                        try
                        {
                            dt结算方式映射表 = NOPI.FromExcel(sFilePath, "结算方式映射表", 1, 0, 3);
                        }
                        catch (Exception ee)
                        {
                            throw new Exception("结算方式映射表取值失败:" + ee.Message);
                        }
                        try
                        {
                            dt客户映射表 = NOPI.FromExcel(sFilePath, "客户映射表", 1, 0, 3);
                        }
                        catch (Exception ee)
                        {
                            throw new Exception("客户映射表取值失败:" + ee.Message);
                        }
                        try
                        {
                            dt币种 = NOPI.FromExcel(sFilePath, "币种", 1, 0, 3);
                        }
                        catch (Exception ee)
                        {
                            throw new Exception("币种映射表取值失败:" + ee.Message);
                        }
                        try
                        {
                            dt部门档案映射表 = NOPI.FromExcel(sFilePath, "部门档案映射表", 1, 0, 3);
                        }
                        catch (Exception ee)
                        {
                            throw new Exception("部门档案映射表取值失败:" + ee.Message);
                        }
                        try
                        {
                            dt人员档案映射表 = NOPI.FromExcel(sFilePath, "人员档案映射表", 1, 0, 3);
                        }
                        catch (Exception ee)
                        {
                            throw new Exception("人员档案映射表取值失败:" + ee.Message);
                        }

                        try
                        {
                            dt开发默认值表 = SqlHelper.ExecuteDataset(Conn, CommandType.Text, "select * from 开发默认值表").Tables[0];
                        }
                        catch (Exception ee)
                        {
                            throw new Exception("开发默认值表取值失败:" + ee.Message);
                        }
                        XmlDocument doc = new XmlDocument();
                        XmlDeclaration xmldecl = doc.CreateXmlDeclaration("1.0", "GB2312", null);
                        doc.AppendChild(xmldecl);

                        XmlElement Node = doc.CreateElement("ufinterface");
                        Node.SetAttribute("roottag", "voucher");
                        Node.SetAttribute("billtype", "D4");
                        Node.SetAttribute("subtype", "run");
                        Node.SetAttribute("replace", "Y");
                        Node.SetAttribute("receiver", "220300000000");
                        Node.SetAttribute("sender", "szlys01");
                        Node.SetAttribute("proc", "add");
                        Node.SetAttribute("isexchange", "Y");
                        Node.SetAttribute("filename", "收款结算单模板demo.xml");
                        doc.AppendChild(Node);


                        for (int j = 0; j < dt.Rows.Count; j++)
                        {
                            XmlElement Node1 = doc.CreateElement("voucher");
                            string s = "";
                            if (j < 10)
                            {
                                s = "000" + j;
                            }
                            else if (j < 100)
                            {
                                s = "00" + j;
                            }
                            else if (j < 1000)
                            {
                                s = "0" + j;
                            }
                            Node1.SetAttribute("id", dt.Rows[j]["iID"].ToString().Trim() + DateTime.Now.ToString("yyyyMMdd") + s);
                            Node.AppendChild(Node1);

                            #region Head
                            XmlElement NodeHead = doc.CreateElement("voucher_head");
                            Node1.AppendChild(NodeHead);

                            //是否预收预付标志 非空字段
                            XmlElement N1 = doc.CreateElement("prepay");
                            N1.InnerText = "n";
                            NodeHead.AppendChild(N1);

                            //单位编码  非空字段
                            XmlElement N2 = doc.CreateElement("corp");
                            N2.InnerText = "220300000000";
                            NodeHead.AppendChild(N2);

                            //业务类型 非空字段，D4是收款结算单,D5是付款结算单,D6是划账结算单,sysid都应该为2该数据项需要需要基础数据对照(单据类型)
                            XmlElement N3 = doc.CreateElement("billTypeCode");
                            N3.InnerText = "D4";
                            NodeHead.AppendChild(N3);

                            XmlElement N4 = doc.CreateElement("businessType");
                            N4.InnerText = "D4";
                            NodeHead.AppendChild(N4);

                            //单据日期 非空字段
                            XmlElement N5 = doc.CreateElement("billDate");
                            if (dt.Rows[j]["dVouchDate"].ToString().Trim() != "")
                            {
                                N5.InnerText = Convert.ToDateTime(dt.Rows[j]["dVouchDate"]).ToString("yyyy-MM-dd").Trim();
                            }
                            NodeHead.AppendChild(N5);

                            //系统编号 0应收 1应付 2现金平台  非空字段
                            XmlElement N6 = doc.CreateElement("sysid");
                            N6.InnerText = "2";
                            NodeHead.AppendChild(N6);

                            //是否期初单据 非空字段
                            XmlElement N7 = doc.CreateElement("initFlag");
                            N7.InnerText = "n";
                            NodeHead.AppendChild(N7);

                            //录入人 非空字段
                            XmlElement N8 = doc.CreateElement("inputOp");
                            DataRow[] dw8 = dt制单人映射表.Select("trim(编码)='" + sUserID.Trim() + "'");
                            if (dw8.Length > 0)
                            {
                                N8.InnerText = dw8[0]["编码1"].ToString().Trim();
                                if (N8.InnerText == "")
                                {
                                    sErr = sErr + "第" + (j + 1) + "行" + "录入人" + sUserID.Trim() + "已找到映射表，但映射表对应值为空" + "\n";
                                }
                            }
                            else
                            {
                                N8.InnerText = "";
                                sErr = sErr + "第" + (j + 1) + "行" + "登录人" + sUserID + "未找到映射表" + "\n";
                            }
                            NodeHead.AppendChild(N8);

                            //采购类型编码
                            XmlElement N9 = doc.CreateElement("saleType");
                            N9.InnerText = "";
                            NodeHead.AppendChild(N9);

                            #region freeitem
                            XmlElement NF1 = doc.CreateElement("freeitem1");
                            NF1.InnerText = "";
                            NodeHead.AppendChild(NF1);

                            XmlElement NF2 = doc.CreateElement("freeitem2");
                            NF2.InnerText = "";
                            NodeHead.AppendChild(NF2);

                            XmlElement NF3 = doc.CreateElement("freeitem3");
                            NF3.InnerText = "";
                            NodeHead.AppendChild(NF3);

                            XmlElement NF4 = doc.CreateElement("freeitem4");
                            NF4.InnerText = "";
                            NodeHead.AppendChild(NF4);

                            XmlElement NF5 = doc.CreateElement("freeitem5");
                            NF5.InnerText = "";
                            NodeHead.AppendChild(NF5);

                            XmlElement NF6 = doc.CreateElement("freeitem6");
                            NF6.InnerText = "";
                            NodeHead.AppendChild(NF6);

                            XmlElement NF7 = doc.CreateElement("freeitem7");
                            NF7.InnerText = "";
                            NodeHead.AppendChild(NF7);

                            XmlElement NF8 = doc.CreateElement("freeitem8");
                            NF8.InnerText = "";
                            NodeHead.AppendChild(NF8);

                            XmlElement NF9 = doc.CreateElement("freeitem9");
                            NF9.InnerText = "";
                            NodeHead.AppendChild(NF9);

                            XmlElement NF10 = doc.CreateElement("freeitem10");
                            NF10.InnerText = "";
                            NodeHead.AppendChild(NF10);

                            XmlElement NF11 = doc.CreateElement("freeitem11");
                            NF11.InnerText = "";
                            NodeHead.AppendChild(NF11);

                            XmlElement NF12 = doc.CreateElement("freeitem12");
                            NF12.InnerText = "";
                            NodeHead.AppendChild(NF12);

                            XmlElement NF13 = doc.CreateElement("freeitem13");
                            NF13.InnerText = "";
                            NodeHead.AppendChild(NF13);

                            XmlElement NF14 = doc.CreateElement("freeitem14");
                            NF14.InnerText = "";
                            NodeHead.AppendChild(NF14);

                            XmlElement NF15 = doc.CreateElement("freeitem15");
                            NF15.InnerText = "";
                            NodeHead.AppendChild(NF15);

                            XmlElement NF16 = doc.CreateElement("freeitem16");
                            NF16.InnerText = "";
                            NodeHead.AppendChild(NF16);

                            XmlElement NF17 = doc.CreateElement("freeitem17");
                            NF17.InnerText = "";
                            NodeHead.AppendChild(NF17);

                            XmlElement NF18 = doc.CreateElement("freeitem18");
                            NF18.InnerText = "";
                            NodeHead.AppendChild(NF18);

                            XmlElement NF19 = doc.CreateElement("freeitem19");
                            NF19.InnerText = "";
                            NodeHead.AppendChild(NF19);

                            XmlElement NF20 = doc.CreateElement("freeitem20");
                            NF20.InnerText = "";
                            NodeHead.AppendChild(NF20);
                            #endregion

                            //收付款人
                            XmlElement N10 = doc.CreateElement("teller");
                            N10.InnerText = "";
                            NodeHead.AppendChild(N10);

                            //科目编码
                            XmlElement N11 = doc.CreateElement("subject");
                            DataRow[] dw11 = dt开发默认值表.Select("iType=2");
                            if (dw11.Length > 0)
                            {
                                N11.InnerText = dw11[0]["s1"].ToString().Trim();
                            }
                            else
                            {
                                sErr = sErr + "第" + (j + 1) + "行" + "表头科目编码默认值未设置" + "\n";
                            }
                            NodeHead.AppendChild(N11);

                            //票据号
                            XmlElement N12 = doc.CreateElement("note_num");
                            N12.InnerText = "";
                            NodeHead.AppendChild(N12);

                            //票据结算方式
                            XmlElement N13 = doc.CreateElement("settleType");
                            DataRow[] dw13 = dt结算方式映射表.Select("trim(编码)='" + dt.Rows[j]["cSSCode"].ToString().Trim() + "'");
                            if (dw13.Length > 0)
                            {
                                N13.InnerText = dw13[0]["编码1"].ToString().Trim();
                                if (N13.InnerText == "")
                                {
                                    sErr = sErr + "第" + (j + 1) + "行" + "结算方式" + dt.Rows[j]["cSSCode"].ToString().Trim() + "已找到映射表，但映射表对应值为空" + "\n";
                                }
                            }
                            else
                            {
                                sErr = sErr + "第" + (j + 1) + "行" + "结算方式" + dt.Rows[j]["cSSCode"].ToString().Trim() + "未找到映射表" + "\n";
                                N13.InnerText = "";
                            }
                            NodeHead.AppendChild(N13);

                            //确认人
                            XmlElement N14 = doc.CreateElement("affirmant");
                            N14.InnerText = "";
                            NodeHead.AppendChild(N14);

                            //银行确认人  如果导入的单据状态是签字态 ，则必须录入银行确认人（业务意义为签字人）
                            XmlElement N15 = doc.CreateElement("bank_affirmant");
                            N15.InnerText = "";
                            NodeHead.AppendChild(N15);

                            //备注
                            XmlElement N16 = doc.CreateElement("scomment");
                            N16.InnerText = "应收账款";
                            NodeHead.AppendChild(N16);

                            //附件，不能为空，默认为0
                            XmlElement N17 = doc.CreateElement("appendix");
                            N17.InnerText = "0";
                            NodeHead.AppendChild(N17);

                            //原币金额 非空字段,不能为0
                            XmlElement N18 = doc.CreateElement("original_sum");
                            N18.InnerText = dt.Rows[j]["iAmount_f"].ToString().Trim();
                            NodeHead.AppendChild(N18);

                            //辅币金额 非空字段，默认为0
                            XmlElement N19 = doc.CreateElement("fractional_sum");
                            N19.InnerText = "0";
                            NodeHead.AppendChild(N19);

                            //本币金额 非空字段，应该与原币金额original_sum相同
                            XmlElement N20 = doc.CreateElement("local_sum");
                            N20.InnerText = dt.Rows[j]["iAmount_f"].ToString().Trim();
                            NodeHead.AppendChild(N20);

                            //V5 新增

                            //单据状态 1保存 2审核 3签字确认
                            XmlElement N21 = doc.CreateElement("billstatus");
                            N21.InnerText = "1";
                            NodeHead.AppendChild(N21);

                            //内控账期日期
                            XmlElement N22 = doc.CreateElement("inner_effect_date");
                            N22.InnerText = "";
                            NodeHead.AppendChild(N22);

                            //客商开户银行
                            XmlElement N23 = doc.CreateElement("kskhyh");
                            N23.InnerText = "";
                            NodeHead.AppendChild(N23);

                            //事项审批单事由
                            XmlElement N24 = doc.CreateElement("sscause");
                            N24.InnerText = "";
                            NodeHead.AppendChild(N24);

                            //最终审批人
                            XmlElement N25 = doc.CreateElement("lastshr");
                            N25.InnerText = "";
                            NodeHead.AppendChild(N25);

                            //审批状态
                            XmlElement N26 = doc.CreateElement("spzt");
                            N26.InnerText = "";
                            NodeHead.AppendChild(N26);

                            //支付人
                            XmlElement N27 = doc.CreateElement("payman");
                            N27.InnerText = "";
                            NodeHead.AppendChild(N27);

                            //支付日期
                            XmlElement N28 = doc.CreateElement("paydate");
                            N28.InnerText = "";
                            NodeHead.AppendChild(N28);

                            //暂估应付标志
                            XmlElement N29 = doc.CreateElement("zgyf");
                            N29.InnerText = "";
                            NodeHead.AppendChild(N29);

                            #region freeitem
                            XmlElement NF21 = doc.CreateElement("freeitem21");
                            NF21.InnerText = "";
                            NodeHead.AppendChild(NF21);

                            XmlElement NF22 = doc.CreateElement("freeitem22");
                            NF22.InnerText = "";
                            NodeHead.AppendChild(NF22);

                            XmlElement NF23 = doc.CreateElement("freeitem23");
                            NF23.InnerText = "";
                            NodeHead.AppendChild(NF23);

                            XmlElement NF24 = doc.CreateElement("freeitem24");
                            NF24.InnerText = "";
                            NodeHead.AppendChild(NF24);

                            XmlElement NF25 = doc.CreateElement("freeitem25");
                            NF25.InnerText = "";
                            NodeHead.AppendChild(NF25);

                            XmlElement NF26 = doc.CreateElement("freeitem26");
                            NF26.InnerText = "";
                            NodeHead.AppendChild(NF26);

                            XmlElement NF27 = doc.CreateElement("freeitem27");
                            NF27.InnerText = "";
                            NodeHead.AppendChild(NF27);

                            XmlElement NF28 = doc.CreateElement("freeitem28");
                            NF28.InnerText = "";
                            NodeHead.AppendChild(NF28);

                            XmlElement NF29 = doc.CreateElement("freeitem29");
                            NF29.InnerText = "";
                            NodeHead.AppendChild(NF29);

                            XmlElement NF30 = doc.CreateElement("freeitem30");
                            NF30.InnerText = "";
                            NodeHead.AppendChild(NF30);
                            #endregion

                            #endregion

                            #region Body
                            XmlElement NodeBody = doc.CreateElement("voucher_body");
                            DataRow[] dwbody = dts.Select("iID='" + dt.Rows[j]["iID"].ToString() + "'");

                            for (int i = 0; i < dwbody.Length; i++)
                            {
                                XmlElement Nodes = doc.CreateElement("entry");
                                NodeBody.AppendChild(Nodes);

                                //金额方向 非空字段
                                XmlElement NS1 = doc.CreateElement("sum_direction");
                                NS1.InnerText = "1";
                                Nodes.AppendChild(NS1);

                                //摘要
                                XmlElement NS2 = doc.CreateElement("digest");
                                NS2.InnerText = N16.InnerText;
                                Nodes.AppendChild(NS2);

                                //科目编码，需要对照
                                XmlElement NS3 = doc.CreateElement("subject");
                                DataRow[] dws3 = dt开发默认值表.Select("iType=3");
                                if (dws3.Length > 0)
                                {
                                    NS3.InnerText = dws3[0]["s1"].ToString();
                                }
                                else
                                {
                                    sErr = sErr + "第" + (j + 1) + "行" + "表体科目编码默认值未设置" + "\n";
                                }
                                Nodes.AppendChild(NS3);

                                //客商主键，付款结算单不能为空
                                XmlElement NS4 = doc.CreateElement("customer");
                                DataRow[] dws4 = dt客户映射表.Select("trim(编码)='" + dwbody[i]["cCusVen"].ToString().Trim() + "'");
                                if (dws4.Length > 0)
                                {
                                    NS4.InnerText = dws4[0]["编码1"].ToString().Trim();
                                    if(NS4.InnerText=="")
                                    {
                                        sErr = sErr + "第" + (j + 1) + "行" + "客户" + dwbody[i]["cCusVen"].ToString().Trim() + "已找到映射表，但映射表对应值为空" + "\n";
                                    }
                                }
                                else
                                {
                                    sErr = sErr + "第" + (j + 1) + "行" + "客户" + dwbody[i]["cCusVen"].ToString().Trim() + "未找到映射表" + "\n";
                                    NS4.InnerText = "";
                                }
                                Nodes.AppendChild(NS4);

                                //币种编码 非空字段，需要对照
                                XmlElement NS5 = doc.CreateElement("currencyId");
                                DataRow[] dws5 = dt币种.Select("trim(名称)='" + dt.Rows[j]["cexch_name"].ToString().Trim() + "'");
                                if (dws5.Length > 0)
                                {
                                    NS5.InnerText = dws5[0]["编码1"].ToString().Trim();
                                    if (NS5.InnerText == "")
                                    {
                                        sErr = sErr + "第" + (j + 1) + "行" + "币种编码" + dt.Rows[j]["cexch_name"].ToString().Trim() + "已找到映射表，但映射表对应值为空" + "\n";
                                    }
                                }
                                else
                                {
                                    sErr = sErr + "第" + (j + 1) + "行" + "币种" + dt.Rows[j]["cexch_name"].ToString().Trim() + "未找到映射表" + "\n";
                                    NS5.InnerText = "";
                                }
                                Nodes.AppendChild(NS5);

                                //本币汇率 非空字段
                                XmlElement NS6 = doc.CreateElement("original_exchange_rate");
                                NS6.InnerText = "1";
                                Nodes.AppendChild(NS6);

                                //辅币汇率 非空字段
                                XmlElement NS7 = doc.CreateElement("fractional_exchange_rate");
                                NS7.InnerText = "0.0";
                                Nodes.AppendChild(NS7);

                                //项目编码
                                XmlElement NS8 = doc.CreateElement("job");
                                NS8.InnerText = "";
                                Nodes.AppendChild(NS8);

                                //借方原币金额 非空字段
                                XmlElement NS9 = doc.CreateElement("debit_original_sum");
                                NS9.InnerText = "0";
                                Nodes.AppendChild(NS9);

                                //借方辅币金额 非空字段，默认为0
                                XmlElement NS10 = doc.CreateElement("debit_fractional_sum");
                                NS10.InnerText = "0";
                                Nodes.AppendChild(NS10);

                                //借方本币金额 非空字段
                                XmlElement NS11 = doc.CreateElement("debit_local_sum");
                                NS11.InnerText = "0";
                                Nodes.AppendChild(NS11);

                                //原币余额 非空字段
                                XmlElement NS12 = doc.CreateElement("original_balance");
                                NS12.InnerText = dt.Rows[j]["iAmount_f"].ToString().Trim();
                                Nodes.AppendChild(NS12);

                                //辅币余额 非空字段，默认为0
                                XmlElement NS13 = doc.CreateElement("fractional_balance");
                                NS13.InnerText = "0";
                                Nodes.AppendChild(NS13);

                                //本币余额 非空字段
                                XmlElement NS14 = doc.CreateElement("local_balance");
                                NS14.InnerText = dt.Rows[j]["iAmount"].ToString().Trim();
                                Nodes.AppendChild(NS14);

                                //数量余额 非空字段
                                XmlElement NS15 = doc.CreateElement("quantity_balance");
                                NS15.InnerText = dwbody[i]["iRAmt_s"].ToString().Trim();
                                Nodes.AppendChild(NS15);

                                //存货编码
                                XmlElement NS16 = doc.CreateElement("inventoryId");
                                NS16.InnerText = "";
                                Nodes.AppendChild(NS16);

                                //筹投资标志
                                XmlElement NS17 = doc.CreateElement("investFlag");
                                NS17.InnerText = "";
                                Nodes.AppendChild(NS17);

                                //借方数量 非空字段
                                XmlElement NS18 = doc.CreateElement("debit_quantity");
                                NS18.InnerText = "0";
                                Nodes.AppendChild(NS18);

                                //单价
                                XmlElement NS19 = doc.CreateElement("unit_price");
                                NS19.InnerText = "";
                                Nodes.AppendChild(NS19);

                                //税率
                                XmlElement NS20 = doc.CreateElement("tax_rate");
                                NS20.InnerText = "0";
                                Nodes.AppendChild(NS20);

                                //借方原币税金 非空字段
                                XmlElement NS21 = doc.CreateElement("debit_original_tax");
                                NS21.InnerText = "0";
                                Nodes.AppendChild(NS21);

                                //借方辅币税金 非空字段
                                XmlElement NS22 = doc.CreateElement("debit_fractional_tax");
                                NS22.InnerText = "0";
                                Nodes.AppendChild(NS22);

                                //借方本币税金 非空字段
                                XmlElement NS23 = doc.CreateElement("debit_local_tax");
                                NS23.InnerText = "0";
                                Nodes.AppendChild(NS23);

                                //付款银行名称
                                XmlElement NS24 = doc.CreateElement("pay_bankName");
                                NS24.InnerText = "";
                                Nodes.AppendChild(NS24);

                                //付款银行账户 需特殊处理的字段,要求必须录入帐号编码
                                XmlElement NS25 = doc.CreateElement("pay_accounts");
                                NS25.InnerText = "";
                                Nodes.AppendChild(NS25);

                                //付款银行地址
                                XmlElement NS26 = doc.CreateElement("pay_bank_addr");
                                NS26.InnerText = "";
                                Nodes.AppendChild(NS26);

                                //收款银行名称
                                XmlElement NS27 = doc.CreateElement("gather_bankName");
                                NS27.InnerText = "";
                                Nodes.AppendChild(NS27);

                                //收款银行账户
                                XmlElement NS28 = doc.CreateElement("gather_accounts");
                                NS28.InnerText = "1102020409000161471";
                                Nodes.AppendChild(NS28);

                                //收款银行地址
                                XmlElement NS29 = doc.CreateElement("gather_bank_addr");
                                NS29.InnerText = "";
                                Nodes.AppendChild(NS29);

                                #region freeitem
                                XmlElement NSF1 = doc.CreateElement("freeitem1");
                                NSF1.InnerText = "";
                                Nodes.AppendChild(NSF1);

                                XmlElement NSF2 = doc.CreateElement("freeitem2");
                                NSF2.InnerText = "";
                                Nodes.AppendChild(NSF2);

                                XmlElement NSF3 = doc.CreateElement("freeitem3");
                                NSF3.InnerText = "";
                                Nodes.AppendChild(NSF3);

                                XmlElement NSF4 = doc.CreateElement("freeitem4");
                                NSF4.InnerText = "";
                                Nodes.AppendChild(NSF4);

                                XmlElement NSF5 = doc.CreateElement("freeitem5");
                                NSF5.InnerText = "";
                                Nodes.AppendChild(NSF5);

                                XmlElement NSF6 = doc.CreateElement("freeitem6");
                                NSF6.InnerText = "";
                                Nodes.AppendChild(NSF6);

                                XmlElement NSF7 = doc.CreateElement("freeitem7");
                                NSF7.InnerText = "";
                                Nodes.AppendChild(NSF7);

                                XmlElement NSF8 = doc.CreateElement("freeitem8");
                                NSF8.InnerText = "";
                                Nodes.AppendChild(NSF8);

                                XmlElement NSF9 = doc.CreateElement("freeitem9");
                                NSF9.InnerText = "";
                                Nodes.AppendChild(NSF9);

                                XmlElement NSF10 = doc.CreateElement("freeitem10");
                                NSF10.InnerText = "";
                                Nodes.AppendChild(NSF10);

                                XmlElement NSF11 = doc.CreateElement("freeitem11");
                                NSF11.InnerText = "";
                                Nodes.AppendChild(NSF11);

                                XmlElement NSF12 = doc.CreateElement("freeitem12");
                                NSF12.InnerText = "";
                                Nodes.AppendChild(NSF12);

                                XmlElement NSF13 = doc.CreateElement("freeitem13");
                                NSF13.InnerText = "";
                                Nodes.AppendChild(NSF13);

                                XmlElement NSF14 = doc.CreateElement("freeitem14");
                                NSF14.InnerText = "";
                                Nodes.AppendChild(NSF14);

                                XmlElement NSF15 = doc.CreateElement("freeitem15");
                                NSF15.InnerText = "";
                                Nodes.AppendChild(NSF15);

                                XmlElement NSF16 = doc.CreateElement("freeitem16");
                                NSF16.InnerText = "";
                                Nodes.AppendChild(NSF16);

                                XmlElement NSF17 = doc.CreateElement("freeitem17");
                                NSF17.InnerText = "";
                                Nodes.AppendChild(NSF17);

                                XmlElement NSF18 = doc.CreateElement("freeitem18");
                                NSF18.InnerText = "";
                                Nodes.AppendChild(NSF18);

                                XmlElement NSF19 = doc.CreateElement("freeitem19");
                                NSF19.InnerText = "";
                                Nodes.AppendChild(NSF19);

                                XmlElement NSF20 = doc.CreateElement("freeitem20");
                                NSF20.InnerText = "";
                                Nodes.AppendChild(NSF20);
                                #endregion

                                //订单号
                                XmlElement NS30 = doc.CreateElement("orderId");
                                NS30.InnerText = "";
                                Nodes.AppendChild(NS30);

                                //开票日期
                                XmlElement NS31 = doc.CreateElement("check_date");
                                NS31.InnerText = "";
                                Nodes.AppendChild(NS31);

                                //借方辅币无税金额 非空字段
                                XmlElement NS32 = doc.CreateElement("debit_frac_noTax");
                                NS32.InnerText = "0";
                                Nodes.AppendChild(NS32);

                                //贷方辅币无税金额 非空字段
                                XmlElement NS33 = doc.CreateElement("credit_frac_noTax");
                                NS33.InnerText = "0";
                                Nodes.AppendChild(NS33);

                                //借方本币无税金额 非空字段
                                XmlElement NS34 = doc.CreateElement("debit_local_noTax");
                                NS34.InnerText = "0";
                                Nodes.AppendChild(NS34);

                                //收入标志
                                XmlElement NS35 = doc.CreateElement("incomeFlag");
                                NS35.InnerText = "y";
                                Nodes.AppendChild(NS35);

                                //收支项目
                                XmlElement NS36 = doc.CreateElement("accsubjId");
                                NS36.InnerText = "0101";
                                Nodes.AppendChild(NS36);

                                //账户档案，或者为空，如果有值一定要建立对照
                                XmlElement NS37 = doc.CreateElement("accountid");
                                NS37.InnerText = "";
                                Nodes.AppendChild(NS37);

                                //收款协议号
                                XmlElement NS38 = doc.CreateElement("pay_agreementId");
                                NS38.InnerText = "";
                                Nodes.AppendChild(NS38);

                                //贷方原币金额 非空字段
                                XmlElement NS39 = doc.CreateElement("credit_original_sum");
                                NS39.InnerText = dwbody[i]["iAmt_f"].ToString().Trim();
                                Nodes.AppendChild(NS39);

                                //贷方辅币金额 非空字段
                                XmlElement NS40 = doc.CreateElement("credit_frac_sum");
                                NS40.InnerText = "0";
                                Nodes.AppendChild(NS40);

                                //贷方本币金额 非空字段
                                XmlElement NS41 = doc.CreateElement("credit_local_sum");
                                NS41.InnerText = dwbody[i]["iAmt"].ToString().Trim();
                                Nodes.AppendChild(NS41);

                                //贷方数量 非空字段
                                XmlElement NS42 = doc.CreateElement("credit_quantity");
                                NS42.InnerText = "0";
                                Nodes.AppendChild(NS42);

                                //贷方原币税金 非空字段
                                XmlElement NS43 = doc.CreateElement("credit_original_Tax");
                                NS43.InnerText = "0";
                                Nodes.AppendChild(NS43);

                                //贷方辅币税金 非空字段
                                XmlElement NS44 = doc.CreateElement("credit_frac_Tax");
                                NS44.InnerText = "0";
                                Nodes.AppendChild(NS44);

                                //贷方本币税金 非空字段
                                XmlElement NS45 = doc.CreateElement("credit_local_Tax");
                                NS45.InnerText = "0";
                                Nodes.AppendChild(NS45);

                                //往来对象 非空字段，0客户，1供应商，2部门，3业务员
                                XmlElement NS46 = doc.CreateElement("object");
                                NS46.InnerText = "0";
                                Nodes.AppendChild(NS46);

                                //借方原币无税金额 非空字段
                                XmlElement NS47 = doc.CreateElement("debit_original_noTax");
                                NS47.InnerText = "0";
                                Nodes.AppendChild(NS47);

                                //贷方原币无税金额 非空字段
                                XmlElement NS48 = doc.CreateElement("credit_original_noTax");
                                NS48.InnerText = dwbody[i]["iAmt_f"].ToString().Trim();
                                Nodes.AppendChild(NS48);

                                //贷方本币无税金额 非空字段
                                XmlElement NS49 = doc.CreateElement("credit_local_noTax");
                                NS49.InnerText = dwbody[i]["iAmt"].ToString().Trim();
                                Nodes.AppendChild(NS49);

                                //税号
                                XmlElement NS50 = doc.CreateElement("tax_num");
                                NS50.InnerText = "";
                                Nodes.AppendChild(NS50);

                                //项目阶段
                                XmlElement NS51 = doc.CreateElement("pk_jobobjpha");
                                NS51.InnerText = "";
                                Nodes.AppendChild(NS51);

                                //款项用途
                                XmlElement NS52 = doc.CreateElement("purpose_sum");
                                NS52.InnerText = "";
                                Nodes.AppendChild(NS52);

                                //部门编码
                                XmlElement NS53 = doc.CreateElement("deptid");
                                DataRow[] dws53 = dt部门档案映射表.Select("trim(编码)='" + dwbody[i]["cDepCode"].ToString().Trim() + "'");
                                if (dws53.Length > 0)
                                {
                                    NS53.InnerText = dws53[0]["编码1"].ToString().Trim();
                                    if (NS53.InnerText.Trim() == "")
                                    {
                                        sErr = sErr + "第" + (j + 1) + "行" + "部门" + dwbody[i]["cDepCode"].ToString().Trim() + "已找到映射表，但映射表对应值为空" + "\n";
                                    }
                                }
                                else
                                {
                                    sErr = sErr + "第" + (j + 1) + "行" + "部门" + dwbody[i]["cDepCode"].ToString().Trim() + "未找到映射表" + "\n";
                                    //NS53.InnerText = "";
                                }
                                Nodes.AppendChild(NS53);

                                //业务员编码
                                XmlElement NS54 = doc.CreateElement("employeeId");
                                DataRow[] dws54 = dt人员档案映射表.Select("trim(编码)='" + dt.Rows[j]["cPerson"].ToString().Trim() + "'");
                                if (dws54.Length > 0)
                                {
                                    NS54.InnerText = dws54[0]["编码1"].ToString().Trim();
                                    if (NS54.InnerText.Trim() == "")
                                    {
                                        sErr = sErr + "第" + (j + 1) + "行" + "业务员" + dt.Rows[j]["cPerson"].ToString().Trim() + "已找到映射表，但映射表对应值为空" + "\n";
                                    }
                                }
                                else
                                {
                                    NS54.InnerText = "";
                                    sErr = sErr + "第" + (j + 1) + "行" + "业务员" + dt.Rows[j]["cPerson"].ToString().Trim() + "未找到映射表" + "\n";
                                }
                                Nodes.AppendChild(NS54);

                                //含税单价
                                XmlElement NS55 = doc.CreateElement("unit_price_WithTax");
                                //NS55.InnerText = "";
                                Nodes.AppendChild(NS55);

                                //扣税类别，不能为空，默认为0
                                XmlElement NS56 = doc.CreateElement("Tax_Type");
                                NS56.InnerText = "0";
                                Nodes.AppendChild(NS56);

                                //注意：客商、部门、业务员不能同时为空
                                //V5新增

                                //交易类型
                                XmlElement NS57 = doc.CreateElement("tradertype");
                                NS57.InnerText = "0";
                                Nodes.AppendChild(NS57);

                                //批次号1
                                XmlElement NS58 = doc.CreateElement("seqnum");
                                //NS58.InnerText = "";
                                Nodes.AppendChild(NS58);

                                //散户
                                XmlElement NS59 = doc.CreateElement("sanhu");
                                //NS59.InnerText = "";
                                Nodes.AppendChild(NS59);

                                //使用部门
                                XmlElement NS60 = doc.CreateElement("usedept");
                                //NS60.InnerText = "";
                                Nodes.AppendChild(NS60);

                                //固定资产卡片号
                                XmlElement NS61 = doc.CreateElement("facardbh");
                                //NS61.InnerText = "";
                                Nodes.AppendChild(NS61);

                                //现金流量项目
                                XmlElement NS62 = doc.CreateElement("cashitem");
                                NS62.InnerText = "100011";
                                Nodes.AppendChild(NS62);

                                //支付状态
                                XmlElement NS63 = doc.CreateElement("payflag");
                                //NS63.InnerText = "";
                                Nodes.AppendChild(NS63);

                                //报价单位无税单价
                                XmlElement NS64 = doc.CreateElement("bjdwwsdj");
                                //NS64.InnerText = "";
                                Nodes.AppendChild(NS64);

                                //出库单号
                                XmlElement NS65 = doc.CreateElement("ckdh");
                                //NS65.InnerText = "";
                                Nodes.AppendChild(NS65);

                                //支付人
                                XmlElement NS66 = doc.CreateElement("payman");
                                //NS66.InnerText = "";
                                Nodes.AppendChild(NS66);

                                //支付日期
                                XmlElement NS67 = doc.CreateElement("paydate");
                                //NS67.InnerText = "";
                                Nodes.AppendChild(NS67);

                                //项目阶段管理档案id
                                XmlElement NS68 = doc.CreateElement("pk_jobobjpha");
                                //NS68.InnerText = "";
                                Nodes.AppendChild(NS68);

                                #region freeitem
                                XmlElement NSF21 = doc.CreateElement("freeitem21");
                                NSF21.InnerText = "";
                                Nodes.AppendChild(NSF21);

                                XmlElement NSF22 = doc.CreateElement("freeitem22");
                                NSF22.InnerText = "";
                                Nodes.AppendChild(NSF22);

                                XmlElement NSF23 = doc.CreateElement("freeitem23");
                                NSF23.InnerText = "";
                                Nodes.AppendChild(NSF23);

                                XmlElement NSF24 = doc.CreateElement("freeitem24");
                                NSF24.InnerText = "";
                                Nodes.AppendChild(NSF24);

                                XmlElement NSF25 = doc.CreateElement("freeitem25");
                                NSF25.InnerText = "";
                                Nodes.AppendChild(NSF25);

                                XmlElement NSF26 = doc.CreateElement("freeitem26");
                                NSF26.InnerText = "";
                                Nodes.AppendChild(NSF26);

                                XmlElement NSF27 = doc.CreateElement("freeitem27");
                                NSF27.InnerText = "";
                                Nodes.AppendChild(NSF27);

                                XmlElement NSF28 = doc.CreateElement("freeitem28");
                                NSF28.InnerText = "";
                                Nodes.AppendChild(NSF28);

                                XmlElement NSF29 = doc.CreateElement("freeitem29");
                                NSF29.InnerText = "";
                                Nodes.AppendChild(NSF29);

                                XmlElement NSF30 = doc.CreateElement("freeitem30");
                                NSF30.InnerText = "";
                                Nodes.AppendChild(NSF30);
                                #endregion

                                //
                                XmlElement NS69 = doc.CreateElement("settlementinfo");
                                NS69.InnerText = "";
                                Nodes.AppendChild(NS69);

                                XmlElement NSS1 = doc.CreateElement("settlement");
                                NSS1.InnerText = "";
                                NS69.AppendChild(NSS1);

                                XmlElement NSSS1 = doc.CreateElement("currency");
                                DataRow[] dwss1 = dt币种.Select("trim(名称)='" + dt.Rows[j]["cexch_name"].ToString().Trim() + "'");
                                if (dwss1.Length > 0)
                                {
                                    NSSS1.InnerText = dwss1[0]["编码1"].ToString().Trim();
                                    if (NSSS1.InnerText.Trim() == "")
                                    {
                                        sErr = sErr + "第" + (j + 1) + "行" + "币种" + dt.Rows[j]["cexch_name"].ToString().Trim() + "已找到映射表，但映射表对应值为空" + "\n";
                                    }
                                }
                                else
                                {
                                    sErr = sErr + "第" + (j + 1) + "行" + "币种" + dt.Rows[j]["cexch_name"].ToString().Trim() + "未找到映射表" + "\n";
                                    NSSS1.InnerText = "";
                                }
                                NSS1.AppendChild(NSSS1);

                                XmlElement NSSS2 = doc.CreateElement("corp");
                                NSSS2.InnerText = "220300000000";
                                NSS1.AppendChild(NSSS2);

                                XmlElement NSSS3 = doc.CreateElement("pay");
                                //NSSS3.InnerText = "";
                                NSS1.AppendChild(NSSS3);

                                XmlElement NSSS4 = doc.CreateElement("paylocal");
                                //NSSS4.InnerText = "";
                                NSS1.AppendChild(NSSS4);

                                XmlElement NSSS5 = doc.CreateElement("receive");
                                //NSSS5.InnerText = "";
                                NSS1.AppendChild(NSSS5);

                                XmlElement NSSS6 = doc.CreateElement("receivelocal");
                                //NSSS6.InnerText = "";
                                NSS1.AppendChild(NSSS6);

                                //本方银行账户
                                XmlElement NSSS7 = doc.CreateElement("ownaccount");
                                //NSSS7.InnerText = "";
                                NSS1.AppendChild(NSSS7);

                                //对方银行账户 需特殊处理的字段,要求必须录入帐号编码
                                XmlElement NSSS8 = doc.CreateElement("oppaccount");
                                //NSSS8.InnerText = "";
                                NSS1.AppendChild(NSSS8);

                                XmlElement NSSS9 = doc.CreateElement("localrate");
                                NSSS9.InnerText = "1";
                                NSS1.AppendChild(NSSS9);

                                XmlElement NSSS10 = doc.CreateElement("tradertype");
                                NSSS10.InnerText = "0";
                                NSS1.AppendChild(NSSS10);

                                XmlElement NSSS11 = doc.CreateElement("balatype");
                                //NSSS11.InnerText = "";
                                NSS1.AppendChild(NSSS11);

                                XmlElement NSSS12 = doc.CreateElement("tradername");
                                NSSS12.InnerText = "雷允上药业有限公司";
                                NSS1.AppendChild(NSSS12);

                                XmlElement NSSS13 = doc.CreateElement("memo");
                                NSSS13.InnerText = N16.InnerText;
                                NSS1.AppendChild(NSSS13);

                                XmlElement NSSS14 = doc.CreateElement("notetype");
                                //NSSS14.InnerText = "";
                                NSS1.AppendChild(NSSS14);

                                XmlElement NSSS15 = doc.CreateElement("notenumber");
                                //NSSS15.InnerText = "";
                                NSS1.AppendChild(NSSS15);

                                XmlElement NSSS16 = doc.CreateElement("billtype");
                                //NSSS16.InnerText = "";
                                NSS1.AppendChild(NSSS16);

                                XmlElement NSSS17 = doc.CreateElement("billcode");
                                //NSSS17.InnerText = "";
                                NSS1.AppendChild(NSSS17);

                                XmlElement NSSS18 = doc.CreateElement("billdate");
                                //NSSS18.InnerText = "";
                                NSS1.AppendChild(NSSS18);
                            }
                            Node1.AppendChild(NodeBody);
                            #endregion
                        }
                        bool issave = false;
                        if (sErr != "")
                        {
                            //DialogResult result = MessageBox.Show("有部分数据为找到映射表，是否保存?", "保存提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            //if (result == DialogResult.OK)
                            //{
                            //    issave = true;
                            //}
                        }
                        else
                        {
                            issave = true;
                        }
                        if (issave == true)
                        {
                            SaveFileDialog sa = new SaveFileDialog();
                            sa.Filter = "xml files(*.xml)|*.xml|所有文件(*.*)|*.*";
                            sa.FileName = "收款单导出";
                            DialogResult d = sa.ShowDialog();
                            string sPath = sa.FileName;
                            if (d == DialogResult.OK)
                            {
                                if (sPath != "")
                                {
                                    doc.Save(sPath);
                                    MessageBox.Show("导出列表成功！\n路径：" + sPath);
                                }
                                else
                                {
                                    MessageBox.Show("请选择导出路径");
                                }
                            }
                        }
                        if (sErr != "")
                        {
                            Sa_CloseBillMsg frm = new Sa_CloseBillMsg(sErr,doc);
                            if (DialogResult.OK == frm.ShowDialog())
                            {
                                frm.Enabled = true;
                            }
                        }


                    }
                    //gridView1.OptionsBehavior.Editable = false;
                    
                }
                else
                {
                    MessageBox.Show("收款单号不可以为空");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("导出列表失败：" + ee.Message);
            }
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            GetChk(checkEdit1.Checked);
        }

        private void GetChk(bool b)
        {
            if (b == false)
            {
                checkEdit1.Text = "全选";
            }
            else
            {
                checkEdit1.Text = "全部取消";
            }
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                gridView1.SetRowCellValue(i, gridColChk, b);
            }

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int iRow = gridView1.FocusedRowHandle;
                bool b = Convert.ToBoolean(gridView1.GetRowCellValue(iRow, gridColChk));
                string s = gridView1.GetRowCellValue(iRow, gridCol收款单号).ToString().Trim();
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    string s2 = gridView1.GetRowCellValue(i, gridCol收款单号).ToString().Trim();
                    if (s == s2)
                    {
                        gridView1.SetRowCellValue(i, gridColChk, !b);
                    }
                }
            }
            catch
            { }
        }
    }
}