using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Warehouse
{
    public partial class FrmClosedPoSel : Form
    {

        DataTable _dtSource = new DataTable();
        public FrmClosedPoSel(DataTable dtSource)
        {
            InitializeComponent();
            _dtSource = dtSource;
        }

        private void FrmClosedPoSel_Load(object sender, EventArgs e)
        {
            BindDataSource();
        }

        private void BindDataSource()
        {
            string filderPo = "";
            string filderOm = "";
            foreach (DataRow row in _dtSource.Rows)
            {
                if (row["FormType"].ToString() == "采购订单")
                    filderPo += row["DId"].ToString() + ",";
                if (row["FormType"].ToString() == "委外订单")
                    filderOm += row["DId"].ToString() + ",";
            }
            if (filderPo == "" && filderOm=="")
            {
                return;
            }
            filderPo += "-1";
            filderOm += "-1";
            string sql = @"
                          select  cast(0 as bit) as IsSel ,
                                i.cInvCode ,
                                i.cInvName ,
                                i.cInvStd ,
                                CM.cComUnitName as MUnitName ,
                                CA.cComUnitName as AUnitName ,
                                m.cPOID ,
                                d.POID ,
                                d.ID as PODId ,
                                d.iQuantity ,
                                d.iNum ,
                                ( case when isnull(d.cbCloser, '') = '' then '未关闭'
                                       else '已关闭'
                                  end ) as CloseState ,
                                ( case when i.bPurchase = 1 then '采购'
                                       when i.bProxyForeign = 1 then '委外'
                                       else '未知'
                                  end ) as InvProp
                        from    dbo.PO_Podetails D
                                left join dbo.PO_Pomain M on D.POID = M.POID
                                left join dbo.Inventory I on D.cInvCode = I.cInvCode
                                left join dbo.ComputationUnit CM on i.cComUnitCode = CM.cComunitCode
                                left join dbo.ComputationUnit CA on i.cAssComUnitCode = ca.cComunitCode
                        where   D.ID in ( {0} )
                        union all
                        select  cast(0 as bit) as IsSel ,
                                i.cInvCode ,
                                i.cInvName ,
                                i.cInvStd ,
                                CM.cComUnitName as MUnitName ,
                                CA.cComUnitName as AUnitName ,
                                m.cCode ,
                                d.MOID ,
                                d.MODetailsID as PODId ,
                                d.iQuantity ,
                                d.iNum ,
                                ( case when isnull(d.cbCloser, '') = '' then '未关闭'
                                       else '已关闭'
                                  end ) as CloseState ,
                                ( case when i.bPurchase = 1 then '采购'
                                       when i.bProxyForeign = 1 then '委外'
                                       else '未知'
                                  end ) as InvProp
                        from    dbo.OM_MODetails D
                                left join dbo.OM_MOMain M on D.MOID = M.MOID
                                left join dbo.Inventory I on D.cInvCode = I.cInvCode
                                left join dbo.ComputationUnit CM on i.cComUnitCode = CM.cComunitCode
                                left join dbo.ComputationUnit CA on i.cAssComUnitCode = ca.cComunitCode
                        where   D.MODetailsID in ( {1} )";

            sql=string.Format(sql, filderPo, filderOm);
            

            DataTable dt = SqlHelper.ExecuteDataset(Assistanter.U8ConnectString, CommandType.Text, sql).Tables [0];
            grdDetail.DataSource = dt;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            grvDetail.PostEditor();
            for (int i = 0; i < grvDetail.RowCount; i++)
            {
                bool isSel = (bool)grvDetail.GetRowCellValue(i, colSel);
                if (!isSel)
                    continue;
                string poDId = grvDetail.GetRowCellValue(i, colPODId).ToString();
                string type = grvDetail.GetRowCellValue(i, colInvProp).ToString();
                string sql ="" ;
                if(type=="采购")
                    sql="update PO_Podetails set cbCloser ='" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',cbCloseDate=getdate(),cbCloseTime=getdate() " +
                        " where id=" + poDId;
                if(type =="委外")
                    sql = "update OM_MODetails set cbCloser ='" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',cbCloseDate=getdate(),cbCloseTime=getdate() " +
                        " where MODetailsID=" + poDId;

                SqlHelper.ExecuteNonQuery(Assistanter.U8ConnectString, CommandType.Text, sql);
            }
            MessageBox.Show("已关闭", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            BindDataSource();
        }
    }
}
