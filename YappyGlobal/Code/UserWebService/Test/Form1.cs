using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDispatchList_Click(object sender, EventArgs e)
        {
            try
            {
                //数据：cWhCode 仓库编码，iSOsID 销售订单表体ID,cInvCode 产品编码,iQuantity 发货数量,iNum 发货件数,cBatch 批次,sUserName 制单人
                WebReference.DBWebService DBWebService = new WebReference.DBWebService();
                Test.ClsDES clsDES = Test.ClsDES.Instance();

                DataTable dt = new DataTable();
                dt.Columns.Add("cWhCode", typeof(string));
                dt.Columns.Add("iSOsID", typeof(long));
                dt.Columns.Add("cInvCode", typeof(string));
                dt.Columns.Add("iQuantity", typeof(decimal));
                dt.Columns.Add("iNum", typeof(decimal));
                dt.Columns.Add("cBatch", typeof(string));
                dt.Columns.Add("sUserName", typeof(string));
                //NewDispatchList(dt, "w1", 1000018072, "CIS071", 6, (decimal)0.125, "", "System");
                //NewDispatchList(dt, "w1", 1000018073, "CIS072", 18, (decimal)0.375, "", "System");
                //NewDispatchList(dt, "w1", 1000018074, "CIS101", 6, (decimal)0.125, "", "System");
                NewDispatchList(dt, "w1", 1000069889, "O326", 1, (decimal)12, "", "System");

                string stemp = clsDES.Encrypt(Cls序列化.SerializeDataTableXml(dt));
                string s = DBWebService.Add_DispatchList(stemp);
                s = clsDES.Decrypt(s);
                MessageBox.Show(s);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void NewDispatchList(DataTable dt, string cWhCode,long iSOsID, string cInvCode, decimal iQuantity, decimal iNum, string cBatch, string sUserName)
        {
            DataRow dw = dt.NewRow();
            dw["cWhCode"] = cWhCode;
            dw["iSOsID"] = iSOsID;
            dw["cInvCode"] = cInvCode;
            dw["iQuantity"] = iQuantity;
            dw["iNum"] = iNum;
            dw["cBatch"] = cBatch;
            dw["sUserName"] = sUserName;
            dt.Rows.Add(dw);
        }

        private void btnRdRecord_Click(object sender, EventArgs e)
        {
            try
            {
                //数据：cWhCode 仓库编码，ID 采购订单表体ID,cInvCode 产品编码,iQuantity 入库数量,iNum 入库件数,cBatch 批次,sUserName 制单人
                WebReference.DBWebService DBWebService = new WebReference.DBWebService();
                Test.ClsDES clsDES = Test.ClsDES.Instance();

                DataTable dt = new DataTable();
                dt.Columns.Add("cWhCode", typeof(string));
                dt.Columns.Add("ID", typeof(long));
                dt.Columns.Add("cInvCode", typeof(string));
                dt.Columns.Add("iQuantity", typeof(decimal));
                dt.Columns.Add("iNum", typeof(decimal));
                dt.Columns.Add("cBatch", typeof(string));
                dt.Columns.Add("sUserName", typeof(string));
                dt.Columns.Add("cRdCode", typeof(string));
                NewRdRecord01(dt, "w1", "1", 1000001222, "H112", 1, (decimal)1, "", "System");
                NewRdRecord01(dt, "w1", "1", 1000001223, "H122", 2, (decimal)2, "", "System");
                NewRdRecord01(dt, "w1", "1", 1000001224, "H132", 3, (decimal)3, "", "System");

                string stemp = clsDES.Encrypt(Cls序列化.SerializeDataTableXml(dt));
                string s = DBWebService.Add_Rdrecord01(stemp);
                s = clsDES.Decrypt(s);
                MessageBox.Show(s);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }


        private void NewRdRecord01(DataTable dt, string cWhCode,string cRdCode, long iID, string cInvCode, decimal iQuantity, decimal iNum, string cBatch, string sUserName)
        {
            DataRow dw = dt.NewRow();
            dw["cWhCode"] = cWhCode;
            dw["ID"] = iID;
            dw["cInvCode"] = cInvCode;
            dw["iQuantity"] = iQuantity;
            dw["iNum"] = iNum;
            dw["cBatch"] = cBatch;
            dw["sUserName"] = sUserName;
            dw["cRdCode"] = "R01";
            dt.Rows.Add(dw);
        }

        private void btnSOStatus_Click(object sender, EventArgs e)
        {
            try
            {
                WebReference.DBWebService DBWebService = new WebReference.DBWebService();
                Test.ClsDES clsDES = Test.ClsDES.Instance();
                string s = DBWebService.UpdateSO_ScanStatus("SO-20034607◆20");
          
            }
            catch (Exception ee)
            {

            }
        }

        private void btnPOStatus_Click(object sender, EventArgs e)
        {
            try
            {
                WebReference.DBWebService DBWebService = new WebReference.DBWebService();
                Test.ClsDES clsDES = Test.ClsDES.Instance();
                string s = DBWebService.UpdatePO_ScanStatus("PO2018-1024◆10");

            }
            catch (Exception ee)
            {

            }
        }
    }
}
