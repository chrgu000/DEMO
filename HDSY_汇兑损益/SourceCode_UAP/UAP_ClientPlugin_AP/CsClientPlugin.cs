using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UFIDA.U8.UAP.UI.Runtime.Model;
using UFIDA.U8.UAP.UI.Runtime.Common;
using System.Data;
using System.Windows.Forms;
using UFIDA.U8.UAP.Common;
using UFIDA.U8.Framework.Lib.Context;

namespace UAP_ClientPlugin_AP
{
    public class CsClientPlugin : ReceiptPluginBase
    {

        [IsImplement(true)]
        public override IButtonEventHandler GetButtonEventHandler(VoucherButtonArgs ButtonArgs, VoucherProxy voucherObject)
        {
            switch (ButtonArgs.ButtonKey)
            {
                //应收读取汇兑损益业务数据
                case "BtnAP_ReadData":
                    {
                        return new BtnAP_ReadData(voucherObject.LoginInfo);
                    }
                //创建应收汇兑损益凭证
                case "BtnAP_CreateAccountingDocument":
                    {
                        return new BtnAP_CreateAccountingDocument(voucherObject.LoginInfo);
                    }
                //弃审
                case "btnAbandonAudit":
                    {
                        return new BtnAP_UnAudit(voucherObject.LoginInfo);
                    }


                default:
                    return null;

            }
        }

        [IsImplement(true)]
        public virtual void CellChanged(CellChangeEventArgs para, BusinessProxy businessObject, VoucherProxy voucherObject)
        {

            //foreach (var item in rows)
            //{
            //var rows = businessObject.Rows.Values.OrderBy(o => o.Cells["uapruntime_rowno"].Value);

            //}
            //if (businessObject.Name == "主表" && para.ColumnName == "cNo")
            //{
            //    businessObject.Rows[0].Cells["cMemo"].Value = businessObject.Rows[0].Cells["cNo"].Value;
            //}


        }

        [IsImplement(true)]
        public override void CellDoubleClick(CellDoubleClickEventArgs para, BusinessProxy businessObject, VoucherProxy voucherObject)
        {
            businessObject.Rows[para.RowKey].Cells[para.ColumnName].Value = "1111";

            //businessObject.SetCellsStyle()

            //businessObject.Cells[para.ColumnName].Value = "CellDoubleClick";

            //voucherObject.RefreshView();

        }



        /// <summary>
        /// 单据加载前
        /// </summary>
        /// <param name="login"></param>
        /// <param name="Cardnumber"></param>
        /// <param name="ds"></param>
        /// <param name="state"></param>
        /// <param name="loadingParas"></param>
        [IsImplement(true)]
        public override void ReceiptLoading(U8Login.clsLogin login, string Cardnumber, DataSet ds, VoucherStateEnum state, ReceiptLoadingParas loadingParas)
        {
            loadingParas.DefaultCondition = "<filteritems><table name='test_0011_E001'><Item key='cNo' operator1='=' val1='1' /></table></filteritems>";
        }

        /// <summary>
        /// 单据中打开参照
        /// </summary>
        /// <param name="para"></param>
        /// <param name="businessObject"></param>
        /// <param name="voucherObject"></param>
        /// <returns></returns>
        [IsImplement(true)]
        public override bool ReferOpening(ReferOpenEventArgs para, BusinessProxy businessObject, VoucherProxy voucherObject)
        {
            if (para.Column.ColumnName == "cDepCode")       //部门参照
            {
                //设置部门参照过滤条件
                para.RefService.FilterSQL = "cDepCode='01'"; //cDepCode是部门物理表中的物理字段名
            }
            //else if (para.Column.ColumnName == "cCusCode")  //客户参照
            //{
            //    //设置客户参照过滤条件
            //    para.RefService.FilterSQL = "cCusCode='000'"; //cCusCode是客户物理表中的物理字段名
            //}

            return true;

        }

        [IsImplement(true)]
        public override void ReceiptLoaded(VoucherProxy ReceiptObject)
        {




        }

        [IsImplementAttribute(true)]
        public override Control CreateControl(BusinessProxy businessObject, VoucherProxy voucherObject, string ID)
        {



            Control resultControl = null;
   
            return resultControl;


        }

        /// <summary>
        /// 执行SQL  
        /// </summary>
        private void SqlExecute()
        {
            string token = UFPlatformContext.Current.Token;
            U8Login.clsLogin login = new U8Login.clsLogin();
            login.ConstructLogin(token);

            string conn = login.UFDataConnstringForNet;
        }
    }
}
