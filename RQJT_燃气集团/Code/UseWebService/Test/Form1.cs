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

        private void btnPU_AppVouch_Click(object sender, EventArgs e)
        {
            try
            {
                DBWebService.DBWebService webservice = new DBWebService.DBWebService();
                //webservice.Url = "http://127.0.0.1/WebService1/DBService.asmx";
                webservice.Url = "http://7.104.1.197:18080/DBService.asmx";

                string sXML = @"<?xml version='1.0' encoding='UTF-8'?>
  <purchaseapp><header><departmentcode> KJ </departmentcode><personcode> 0654 </personcode><define1> 2026 </define1><maker> 402 </maker><define2> 科灵路161号 - 江苏省拍卖业委托拍卖合同 </define2><define3> HTQT2019032101002 </define3><define4> 科灵路161号 - 江苏省拍卖业委托拍卖合同 </define4><code> QGD20190411003 </code><date> 2019 - 04 - 11 </date><memory></memory></header><body><entry><requiredate> 2019-04-11 </requiredate><num></num><quantity> 1 </quantity><inventorycode> B12503013 </inventorycode></entry></body></purchaseapp>
    ";

  //              string sXML = @"<?xml version='1.0' encoding='utf - 8'?>
  //  <purchaseapp>
  
  //    <header>
  
  //      <code> Test001 </code>
  
  //      <date> 2019-03-01 </date>
  
  //      <departmentcode> 00 </departmentcode>
  
  //      <personcode> 0007 </personcode>
  
  //      <maker> th </maker>
  
  //      <memory> memory </memory>
  
  //      <define1> 合同编号 </define1>
  
  //      <define2> 合同名称 </define2>
  
  //      <define3> 项目编号 </define3>
  
  //      <define4> 项目名称 </define4>
  
  //    </header>
  
  //    <body>
  
  //      <entry>
  
  //        <inventorycode> B10101001 </inventorycode>
  
  //        <quantity> 10 </quantity>
  
  //        <requiredate> 2019-05-01 </requiredate>
  
  //        <num/>
  
  //      </entry>
  
  //      <entry>
  
  //        <inventorycode> B10101003 </inventorycode>
  
  //        <quantity> 20 </quantity>
  
  //        <requiredate> 2019-05-05 </requiredate>
  
  //        <num/>
  
  //      </entry>
  
  //    </body>
  
  //  </purchaseapp>
  //";
                string s = webservice.AddPU_AppVouch(sXML);
                MessageBox.Show(s);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnMaterialAppVouc_Click(object sender, EventArgs e)
        {
            try
            {
                DBWebService.DBWebService webservice = new DBWebService.DBWebService();
                webservice.Url = "http://127.0.0.1/WebService1/DBService.asmx";

                string sXML = @"<?xml version='1.0' encoding='utf - 8'?>
    <storeout>
  
      <header>
  
        <date>2019-03-05</date>
  
        <code>Test001</code>
  
        <departmentcode>00</departmentcode>
  
        <personcode>0007</personcode>
  
        <maker> demo </maker>
  
        <memory>memory</memory>
  
         <define1> 合同编号 </define1>
  
        <define2> 合同名称 </define2>
  
        <define3> 项目编号 </define3>
  
        <define4> 项目名称 </define4>
  
        <define5> define5 </define5>
  
      </header>
  
      <body>
  
        <entry>
  
          <inventorycode>B10101001</inventorycode>
  
          <quantity> 1 </quantity>
  
          <number></number>
  

        </entry>
        <entry>
  
          <inventorycode>B10101003</inventorycode>
  
          <quantity> 11 </quantity>
  
          <number></number>
  

        </entry>
  
      </body>
  
    </storeout>
    ";
                string s = webservice.AddMaterialAppVouch(sXML);
                MessageBox.Show(s);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

        }
    }
}
