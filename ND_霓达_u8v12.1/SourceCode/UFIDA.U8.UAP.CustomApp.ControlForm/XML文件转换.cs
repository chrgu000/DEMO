using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using TH.BaseClass;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class XML文件转换 : UserControl
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

        public XML文件转换()
        {
            InitializeComponent();
        }


        private void FrmXML文件转换_Load(object sender, EventArgs e)
        {
            try
            {
                DbHelperSQL.connectionString = Conn;
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
            SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
            conn.Open();
            //启用事务
            SqlTransaction tran = conn.BeginTransaction();
            string sSQL = "";
            try
            {
                XmlDocument docold = new XmlDocument();
                XmlDocument docnew = new XmlDocument();

                DataTable dtadd = new DataTable();
                dtadd.Columns.Add("cId");
                dtadd.Columns.Add("cValue");

                if (buttonEditchk.EditValue != null && buttonEditchk.EditValue.ToString() != "")
                {
                    if (System.IO.File.Exists(buttonEditchk.EditValue.ToString()))
                    {
                        #region
                        docold.Load(buttonEditchk.EditValue.ToString());

                        //设定title
                        XmlDeclaration dec = docnew.CreateXmlDeclaration("1.0", "utf-8", null);
                        docnew.AppendChild(dec);

                        //添加根节点
                        XmlNode xmlnodNew = docnew.CreateNode("element", "ufinterface", "");
                        docnew.AppendChild(xmlnodNew);

                        //添加根节点属性

                        XmlNode xmltop = docold.DocumentElement;//获得原文件根节点
                        Add(docnew, xmlnodNew, "lastquerydate", xmltop.Attributes["lastquerydate"].Value);
                        Add(docnew, xmlnodNew, "timestamp", xmltop.Attributes["timestamp"].Value);
                        Add(docnew, xmlnodNew, "bignoreextenduserdefines", "y");
                        Add(docnew, xmlnodNew, "maxdataitems", "20000");
                        Add(docnew, xmlnodNew, "dynamicdate", xmltop.Attributes["dynamicdate"].Value);
                        Add(docnew, xmlnodNew, "family", "销售管理");
                        Add(docnew, xmlnodNew, "display", "销售订单");
                        Add(docnew, xmlnodNew, "paginate", "0");
                        Add(docnew, xmlnodNew, "exportneedexch", "N");
                        Add(docnew, xmlnodNew, "codeexchanged", "N");
                        Add(docnew, xmlnodNew, "proc", "query");
                        Add(docnew, xmlnodNew, "docid", "349995911");
                        Add(docnew, xmlnodNew, "roottag", "saleorder");
                        Add(docnew, xmlnodNew, "receiver", "u8");
                        Add(docnew, xmlnodNew, "sender", "001");
                        #endregion

                        //订单
                        #region
                        XmlNodeList topold = docold.DocumentElement.ChildNodes;
                        for (int i = 0; i < topold.Count; i++)
                        {
                            XmlNode xmlso = docnew.CreateNode("element", "saleorder", "");
                            xmlnodNew.AppendChild(xmlso);


                            XmlNodeList xml = topold[i].ChildNodes;
                            for (int j = 0; j < xml.Count; j++)
                            {
                                XmlNode xmln = xml[j];

                                if (xmln.Name == "header")
                                {
                                    XmlNode xmlheader = docnew.CreateNode("element", "header", "");
                                    xmlso.AppendChild(xmlheader);

                                    string date = "";
                                    string code = "";
                                    string deptcode = "";
                                    string address = "";
                                    string currency_name = "";
                                    string currency_rate = "";
                                    string taxratehead = "";
                                    string remark = "";
                                    string define1 = "";
                                    string define2 = "";
                                    string define3 = "";
                                    string define4 = "";
                                    string define5 = "";
                                    string define6 = "";
                                    string define7 = "";
                                    string define8 = "";
                                    string define9 = "";
                                    string define10 = "";
                                    string define11 = "";
                                    string define12 = "";
                                    string define13 = "";
                                    string define14 = "";
                                    string define15 = "";
                                    string define16 = "";
                                    string arrivedate = "";

                                    XmlNodeList xmlhead = xmln.ChildNodes;
                                    for (int s = 0; s < xmlhead.Count; s++)
                                    {
                                        switch (xmlhead[s].Name)
                                        {
                                            case "date":
                                                date = xmlhead[s].InnerText;
                                                break;
                                            case "code":
                                                code = xmlhead[s].InnerText;
                                                break;
                                            case "deptcode":
                                                deptcode = xmlhead[s].InnerText;
                                                break;
                                            case "address":
                                                address = xmlhead[s].InnerText;
                                                break;
                                            case "currency_name":
                                                currency_name = xmlhead[s].InnerText;
                                                break;
                                            case "currency_rate":
                                                currency_rate = xmlhead[s].InnerText;
                                                break;
                                            case "taxrate":
                                                taxratehead = xmlhead[s].InnerText;
                                                break;
                                            case "remark":
                                                remark = xmlhead[s].InnerText;
                                                break;
                                            case "define1":
                                                define1 = xmlhead[s].InnerText;
                                                break;
                                            case "define2":
                                                define2 = xmlhead[s].InnerText;
                                                break;
                                            case "define3":
                                                define3 = xmlhead[s].InnerText;
                                                break;
                                            case "define4":
                                                define4 = xmlhead[s].InnerText;
                                                break;
                                            case "define5":
                                                define5 = xmlhead[s].InnerText;
                                                break;
                                            case "define6":
                                                define6 = xmlhead[s].InnerText;
                                                break;
                                            case "define7":
                                                define7 = xmlhead[s].InnerText;
                                                break;
                                            case "define8":
                                                define8 = xmlhead[s].InnerText;
                                                break;
                                            case "define9":
                                                define9 = xmlhead[s].InnerText;
                                                break;
                                            case "define10":
                                                define10 = xmlhead[s].InnerText;
                                                break;
                                            case "define11":
                                                define11 = xmlhead[s].InnerText;
                                                break;
                                            case "define12":
                                                define12 = xmlhead[s].InnerText;
                                                break;
                                            case "define13":
                                                define13 = xmlhead[s].InnerText;
                                                break;
                                            case "define14":
                                                define14 = xmlhead[s].InnerText;
                                                break;
                                            case "define15":
                                                define15 = xmlhead[s].InnerText;
                                                break;
                                            case "define16":
                                                define16 = xmlhead[s].InnerText;
                                                break;
                                        }
                                    }

                                    Add2(docnew, xmlheader, "id", "");
                                    Add2(docnew, xmlheader, "outid", "");
                                    Add2(docnew, xmlheader, "typecode", "01");
                                    Add2(docnew, xmlheader, "date", date);
                                    Add2(docnew, xmlheader, "code", code);
                                    Add2(docnew, xmlheader, "custcode", "24001");
                                    Add2(docnew, xmlheader, "deptcode", deptcode);
                                    Add2(docnew, xmlheader, "personcode", "");
                                    Add2(docnew, xmlheader, "sendcode", "1");
                                    Add2(docnew, xmlheader, "sendaddress", address);

                                    Add2(docnew, xmlheader, "ccusperson", "李健");
                                    Add2(docnew, xmlheader, "ccuspersoncode", "");
                                    Add2(docnew, xmlheader, "paycondition_code", "");
                                    Add2(docnew, xmlheader, "currency", currency_name);
                                    Add2(docnew, xmlheader, "currencyrate", currency_rate);
                                    Add2(docnew, xmlheader, "taxrate", taxratehead);
                                    Add2(docnew, xmlheader, "earnest", "0");
                                    Add2(docnew, xmlheader, "memo", remark);
                                    Add2(docnew, xmlheader, "maker", "demo");
                                    Add2(docnew, xmlheader, "businesstype", "普通销售");

                                    Add2(docnew, xmlheader, "disflag", "0");
                                    Add2(docnew, xmlheader, "define1", define12);
                                    Add2(docnew, xmlheader, "define2", "");
                                    Add2(docnew, xmlheader, "define3", "");
                                    Add2(docnew, xmlheader, "define4", "");
                                    Add2(docnew, xmlheader, "define5", "");
                                    Add2(docnew, xmlheader, "define6", "");
                                    Add2(docnew, xmlheader, "define7", "0");
                                    Add2(docnew, xmlheader, "define8", define8);
                                    Add2(docnew, xmlheader, "define9", "");
                                    Add2(docnew, xmlheader, "define10", "");
                                    Add2(docnew, xmlheader, "define11", define14);
                                    Add2(docnew, xmlheader, "define12", define2);
                                    Add2(docnew, xmlheader, "define13", define1);
                                    Add2(docnew, xmlheader, "define14", code);
                                    Add2(docnew, xmlheader, "define15", "");
                                    Add2(docnew, xmlheader, "define16", "");

                                    Add2(docnew, xmlheader, "cusname", "霓达(上海)企业管理有限公司");
                                    Add2(docnew, xmlheader, "caddcode", "");
                                    Add2(docnew, xmlheader, "cgatheringplan", "");
                                    Add2(docnew, xmlheader, "bmustbook", "");
                                    Add2(docnew, xmlheader, "fbookratio", "");
                                    Add2(docnew, xmlheader, "fbooksum", "");
                                    Add2(docnew, xmlheader, "fbooknatsum", "");
                                    Add2(docnew, xmlheader, "retaildates", "");
                                    Add2(docnew, xmlheader, "define2", "");
                                }
                                else
                                {
                                    XmlNode xmlbody = docnew.CreateNode("element", "body", "");
                                    xmlso.AppendChild(xmlbody);

                                    XmlNodeList xmlb = xml[j].ChildNodes;
                                    for (int s = 0; s < xmlb.Count; s++)
                                    {
                                        XmlNode xmle = docnew.CreateNode("element", "entry", "");
                                        xmlbody.AppendChild(xmle);

                                        string inventorycode = "";
                                        string arrivedate = "";
                                        decimal quantity = 0;
                                        decimal num = 0;
                                        decimal free1 = 0;
                                        decimal free2 = 0;
                                        string free3 = "";
                                        string free4 = "";
                                        string define27 = "";
                                        string define29 = "";
                                        string define32 = "";
                                        string define33 = "";
                                        string define31 = "";
                                        decimal taxrate = 0;
                                        string assistantunit = "";
                                        decimal sum = 0;

                                        XmlNodeList xmlhead = xmlb[s].ChildNodes;
                                        for (int p = 0; p < xmlhead.Count; p++)
                                        {
                                            switch (xmlhead[p].Name)
                                            {
                                                case "inventorycode":
                                                    inventorycode = xmlhead[p].InnerText;
                                                    break;
                                                case "arrivedate":
                                                    arrivedate = xmlhead[p].InnerText;
                                                    break;
                                                case "quantity":
                                                    quantity = TH.BaseClass.BaseFunction.ReturnDecimal(xmlhead[p].InnerText, 6);
                                                    break;
                                                case "num":
                                                    num = TH.BaseClass.BaseFunction.ReturnDecimal(xmlhead[p].InnerText, 6);
                                                    break;
                                                case "free1":
                                                    free1 = TH.BaseClass.BaseFunction.ReturnDecimal(xmlhead[p].InnerText);
                                                    break;
                                                case "free2":
                                                    free2 = TH.BaseClass.BaseFunction.ReturnDecimal(xmlhead[p].InnerText);
                                                    break;
                                                case "free3":
                                                    free3 = xmlhead[p].InnerText;
                                                    break;
                                                case "free4":
                                                    free4 = xmlhead[p].InnerText;
                                                    break;
                                                case "define27":
                                                    define27 = xmlhead[p].InnerText;
                                                    break;
                                                case "define29":
                                                    define29 = xmlhead[p].InnerText;
                                                    break;
                                                case "define31":
                                                    define31 = xmlhead[p].InnerText;
                                                    break;
                                                case "define32":
                                                    define32 = xmlhead[p].InnerText;
                                                    break;
                                                case "define33":
                                                    define33 = xmlhead[p].InnerText;
                                                    break;
                                                case "taxrate":
                                                    taxrate = TH.BaseClass.BaseFunction.ReturnDecimal(xmlhead[p].InnerText, 6);
                                                    break;
                                                case "assistantunit":
                                                    assistantunit = xmlhead[p].InnerText;
                                                    break;
                                                case "sum":
                                                    sum = TH.BaseClass.BaseFunction.ReturnDecimal(xmlhead[p].InnerText, 6);
                                                    break;
                                            }
                                        }

                                        GetInsert("20", free1.ToString(), dtadd);
                                        GetInsert("21", free2.ToString(), dtadd);
                                        GetInsert("28", free3, dtadd);
                                        GetInsert("29", free4, dtadd);

                                        decimal unitrate = 0;
                                        if (free1 != 0 && free2 != 0)
                                        {
                                            unitrate = TH.BaseClass.BaseFunction.ReturnDecimal(free1 * free2 / 10000, 2);
                                        }
                                        if (num != 0)
                                        {
                                            num = quantity;
                                            quantity = TH.BaseClass.BaseFunction.ReturnDecimal(num * unitrate, 6);
                                        }
                                        decimal taxunitprice = TH.BaseClass.BaseFunction.ReturnDecimal(sum / quantity);
                                        decimal natmoney = TH.BaseClass.BaseFunction.ReturnDecimal(sum / (1.0M + taxrate / 100M), 4);
                                        decimal tax = sum - natmoney;
                                        decimal unitprice = TH.BaseClass.BaseFunction.ReturnDecimal(natmoney / quantity);

                                        Add2(docnew, xmle, "id", "");
                                        Add2(docnew, xmle, "body_outid", "");
                                        Add2(docnew, xmle, "inventorycode", inventorycode);
                                        Add2(docnew, xmle, "preparedate", arrivedate);
                                        Add2(docnew, xmle, "quantity", quantity);
                                        if (unitrate != 0)
                                        {
                                            Add2(docnew, xmle, "num", num);
                                        }
                                        else
                                        {
                                            Add2(docnew, xmle, "num", "");
                                        }
                                        Add2(docnew, xmle, "quotedprice", "0");

                                        Add2(docnew, xmle, "unitprice", unitprice);
                                        Add2(docnew, xmle, "taxunitprice", taxunitprice);
                                        Add2(docnew, xmle, "money", "0");
                                        Add2(docnew, xmle, "money", natmoney);
                                        Add2(docnew, xmle, "tax", tax);
                                        Add2(docnew, xmle, "sum", sum);

                                        Add2(docnew, xmle, "assistantunit", assistantunit);
                                        Add2(docnew, xmle, "discount", "0");
                                        if (unitprice == 0)
                                        {
                                            Add2(docnew, xmle, "natunitprice", "");
                                            Add2(docnew, xmle, "natmoney", "");
                                            Add2(docnew, xmle, "nattax", "");
                                            Add2(docnew, xmle, "natsum", "");
                                        }
                                        else
                                        {
                                            Add2(docnew, xmle, "natunitprice", unitprice);
                                            Add2(docnew, xmle, "natmoney", natmoney);
                                            Add2(docnew, xmle, "nattax", tax);
                                            Add2(docnew, xmle, "natsum", num);
                                        }
                                        Add2(docnew, xmle, "natdiscount", "0");
                                        Add2(docnew, xmle, "memo", "");

                                        Add2(docnew, xmle, "mid", "");
                                        Add2(docnew, xmle, "discountrate", "0");
                                        Add2(docnew, xmle, "discountrate2", "0");
                                        Add2(docnew, xmle, "taxrate", taxrate);

                                        Add2(docnew, xmle, "define22", "");
                                        Add2(docnew, xmle, "define23", "");
                                        Add2(docnew, xmle, "define24", "");
                                        Add2(docnew, xmle, "define25", "");
                                        Add2(docnew, xmle, "define26", "0");
                                        Add2(docnew, xmle, "define27", define27);
                                        Add2(docnew, xmle, "define28", "");
                                        Add2(docnew, xmle, "define29", define29);
                                        Add2(docnew, xmle, "define30", "");
                                        Add2(docnew, xmle, "define31", define31);
                                        Add2(docnew, xmle, "define32", define32);
                                        Add2(docnew, xmle, "define33", define33);
                                        Add2(docnew, xmle, "define34", "0");
                                        Add2(docnew, xmle, "define35", "0");
                                        Add2(docnew, xmle, "define36", "1900-01-01 00:00:00");
                                        Add2(docnew, xmle, "define37", "1900-01-01 00:00:00");

                                        Add2(docnew, xmle, "itemcode", "");
                                        Add2(docnew, xmle, "item_class", "");
                                        Add2(docnew, xmle, "itemname", "");
                                        Add2(docnew, xmle, "itemclass_name", "");

                                        if (unitrate != 0)
                                        {
                                            Add2(docnew, xmle, "free1", free1);
                                            Add2(docnew, xmle, "free2", free2);
                                        }
                                        else
                                        {
                                            Add2(docnew, xmle, "free1", "");
                                            Add2(docnew, xmle, "free2", "");
                                        }
                                        Add2(docnew, xmle, "free3", free3);
                                        Add2(docnew, xmle, "free4", free4);
                                        Add2(docnew, xmle, "free5", "");
                                        Add2(docnew, xmle, "free6", "");
                                        Add2(docnew, xmle, "free7", "");
                                        Add2(docnew, xmle, "free8", "");
                                        Add2(docnew, xmle, "free9", "");
                                        Add2(docnew, xmle, "free10", "");

                                        Add2(docnew, xmle, "irowno", (s + 1).ToString());
                                        Add2(docnew, xmle, "unitrate", unitrate);
                                        Add2(docnew, xmle, "unitcode", assistantunit);
                                        Add2(docnew, xmle, "dreleasedate", "");
                                        Add2(docnew, xmle, "dpredate", arrivedate);//预发货日期
                                        Add2(docnew, xmle, "dpremodate", arrivedate);
                                        Add2(docnew, xmle, "demandtype", "");
                                        Add2(docnew, xmle, "demandcode", "");
                                        Add2(docnew, xmle, "demandmemo", "");
                                        Add2(docnew, xmle, "cdetailsdemandcode", "");

                                        Add2(docnew, xmle, "retailxsquantity", "");
                                        Add2(docnew, xmle, "retailxsmoney", "");
                                        Add2(docnew, xmle, "retailkcquantity", "");
                                        Add2(docnew, xmle, "retailyhmoney", "");
                                        Add2(docnew, xmle, "ccusinvcode", "");
                                        Add2(docnew, xmle, "ccusinvname", "");
                                        Add2(docnew, xmle, "bsaleprice", "1");
                                        Add2(docnew, xmle, "bgift", "0");
                                        Add2(docnew, xmle, "fcusminprice", "");
                                        Add2(docnew, xmle, "cparentcode", "");

                                        Add2(docnew, xmle, "cchildcode", "");
                                        Add2(docnew, xmle, "icalctype", "");
                                        Add2(docnew, xmle, "fchildqty", "");
                                        Add2(docnew, xmle, "fchildrate", "");
                                    }
                                }
                            }
                        }
                        #endregion


                        for (int i = 0; i < dtadd.Rows.Count; i++)
                        {
                            sSQL = "insert into UserDefine(cId,cValue,cAlias,bFreeStop) values('" + dtadd.Rows[i]["cId"].ToString() + "','" + dtadd.Rows[i]["cValue"].ToString() + "','" + dtadd.Rows[i]["cValue"].ToString() + "',0)";
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }

                        SaveFileDialog sF = new SaveFileDialog();
                        sF.DefaultExt = "xls";
                        sF.FileName = this.Text;
                        sF.Filter = "XML(*.xml)|*.xml";
                        DialogResult dRes = sF.ShowDialog();
                        if (DialogResult.OK == dRes)
                        {
                            docnew.Save(sF.FileName);
                            MessageBox.Show("xml转换成功\n\t路径：" + sF.FileName);
                        }
                    }
                    else
                    {
                        MessageBox.Show("xml不存在！");
                    }
                }

                tran.Commit();
            }
            catch (Exception ee)
            {
                tran.Rollback();
                MessageBox.Show("xml转换失败：" + ee.Message);
            }
        }

        private void GetInsert(string cID, string cValue,DataTable dtadd)
        {
            if (cValue.Trim() != "")
            {
                string sSQL = "select * from UserDefine where cID='" + cID + "' and cValue='" + cValue + "' ";
                DataTable dt = DbHelperSQL.Query(sSQL);
                DataRow[] dw = dtadd.Select("cID='" + cID + "' and cValue='" + cValue+ "'");
                if (dt.Rows.Count == 0 && dw.Length == 0)
                {
                    DataRow dwnew = dtadd.NewRow();
                    dwnew["cID"] = cID;
                    dwnew["cValue"] = cValue;
                    dtadd.Rows.Add(dwnew);
                }
            }
        }

        private void Add(XmlDocument doc, XmlNode node, string Name, string Value)
        {
            XmlAttribute attr = doc.CreateAttribute(Name);
            if (Value != "")
            {
                attr.Value = Value;
            }
            node.Attributes.SetNamedItem(attr);
        }
        private void Add(XmlDocument doc, XmlNode node, string Name, decimal Value)
        {
            XmlAttribute attr = doc.CreateAttribute(Name);
            attr.Value = Value.ToString();
            node.Attributes.SetNamedItem(attr);
        }
        private void Add2(XmlDocument doc, XmlNode node, string Name, string Value)
        {
            XmlNode nodetmp = doc.CreateNode("element", Name, null);
            if (Value != "")
            {
                nodetmp.InnerText = Value;
            }
            node.AppendChild(nodetmp);
        }
        private void Add2(XmlDocument doc, XmlNode node, string Name, decimal Value)
        {
            XmlNode nodetmp = doc.CreateNode("element", Name, null);
            nodetmp.InnerText = Value.ToString();
            node.AppendChild(nodetmp);
        }

        private void buttonEditchk_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                OpenFileDialog file = new OpenFileDialog();
                file.ShowDialog();
                buttonEditchk.EditValue= file.FileName;
            }
            catch (Exception ee)
            {
                MessageBox.Show("选择文件失败！");
            }
        }
    }
}