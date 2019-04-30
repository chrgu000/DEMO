using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace Test
{
    public partial class cls 
    {
        private void button1_Click(DataTable dt)
        {
            //数据：iSOsID、cInvCode、iQuantity、iNum、cBatch
            WebReference.DBWebService DBWebService = new WebReference.DBWebService();
            DBWebService.Url = "http://127.0.0.1:8080/DBService.asmx";
            Test.ClsDES clsDES = Test.ClsDES.Instance();

            DataTable dtData = new DataTable();
            dtData.Columns.Add("iSOsID", typeof(long));
            dtData.Columns.Add("cInvCode", typeof(string));
            dtData.Columns.Add("iQuantity",typeof(decimal));
            dtData.Columns.Add("iNum", typeof(decimal));
            dtData.Columns.Add("cBatch", typeof(string));
            dtData.Columns.Add("sUserName", typeof(string));

            New(dtData, 1000038017, "A001", 100, 0, "","TH");
            New(dtData, 1000038018, "A002", 10, 0, "", "TH");
            New(dtData, 1000038019, "A003", 13, 0, "", "TH");

            string s = DBWebService.Add_DispatchList(clsDES.Encrypt(Cls序列化.SerializeDataTableXml(dtData)));
            s = clsDES.Decrypt(s);
            MessageBox.Show(s);
        }

        private void New(DataTable dt, long iSOsID, string cInvCode, decimal iQuantity, decimal iNum, string cBatch,string sUserName)
        {
            DataRow dw = dt.NewRow();
            dw["iSOsID"] = iSOsID;
            dw["cInvCode"] = cInvCode;
            dw["iQuantity"] = iQuantity;
            dw["iNum"] = iNum;
            dw["cBatch"] = cBatch;
            dw["sUserName"] = sUserName;
            dt.Rows.Add(dw);
        }
    }
}
