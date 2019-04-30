using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UseWebService
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //采购入库单审核
        private void btnRdrecord01_Click(object sender, EventArgs e)
        {
            WebServiceQCDQ.DBWebService dbWeb = new UseWebService.WebServiceQCDQ.DBWebService();
            dbWeb.Url = "http://127.0.0.1/webQCDQ/DBService.asmx";

            string sReturn = dbWeb.sRdrecord01_Audit("201706011325", "th", "2017-09-20");
            MessageBox.Show(sReturn);
            //返回值 
            //OK ，执行成功
            //ERR,执行失败
        }

        /// <summary>
        /// 产成品入库单
        /// </summary>
        /// <param name="sWOCode">生产订单号</param>
        /// <param name="sZJCode">检验单号</param>
        /// <param name="sWhCode">仓库编号</param>
        /// <param name="sRdCode">收发类别</param>
        /// <param name="sDepCode">部门编码</param>
        /// <param name="sCreater">制单人</param>
        /// <param name="sDate">制单日期</param>
        /// <param name="sInvCode">产品编码</param>
        /// <param name="sBatch">批次</param>
        /// <param name="sQty">数量</param>
        /// <returns></returns>
        private void btnRdrecord10_Click(object sender, EventArgs e)
        {
            WebServiceQCDQ.DBWebService dbWeb = new UseWebService.WebServiceQCDQ.DBWebService();
            dbWeb.Url = "http://127.0.0.1/webQCDQ/DBService.asmx";

            
            //string sReturn = dbWeb.sRdrecord10_Save("生产订单号", "检验单号", "仓库编码", "收发类别", "部门编码（可以空字符串）", "制单人", "制单日期", "产品编码", "批次", "数量");
            string sReturn = dbWeb.sRdrecord10_Save("20180304478", "0000012133", "012", "12", "", "demo", "2018-03-15", "QW-VTD0931", "201803", "3");
            MessageBox.Show(sReturn);

            //返回值 
            //OK ，执行成功
            //ERR,执行失败
        }

        /// <summary>
        /// 其他出库单导入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRdrecord09_Click(object sender, EventArgs e)
        {
            WebServiceQCDQ.DBWebService dbWeb = new UseWebService.WebServiceQCDQ.DBWebService();
            dbWeb.Url = "http://127.0.0.1/webQCDQ/DBService.asmx";

            //string sReturn = dbWeb.sRdrecord09_Save("仓库编号", "入库类别", "入库部门编码", "制单人", "制单日期", "产品编码","批次", "产品数量");
            string sReturn = dbWeb.sRdrecord09_Save("012", "12", "", "th", "2018-03-16", "QW-AE054A◆QW-PWS045", "20160321◆20140909", "3◆2");
          
            MessageBox.Show(sReturn);

            //返回值 
            //OK ，执行成功
            //ERR,执行失败
        }


    }
}
