using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using DevExpress.XtraEditors;
using Warehouse.OMBack;
using System.Data.SqlClient;
using FrameBaseFunction;


namespace Warehouse
{
    public partial class FrmWHBack :FrameBaseFunction.Frm列表窗体模板
    {

        bool isCanFind = false;
        bool inSearch = false;
        string SQL = "";
        DataTable DTSource = new DataTable();
        DataTable DTVen = new DataTable();
        DataTable DtWaitCloseForm = new DataTable();

        int currentRow = 0;

        public FrmWHBack()
        {
            InitializeComponent();

            SQL = @"
                 set nocount  on 
                 select cast(0 as bit) as IsSel ,
                        i.cInvCode ,
                        i.cInvName ,
                        i.cInvStd ,
                        CM.cComUnitName as MUnitName ,
                        CA.cComUnitName as AUnitName ,
                        c.iQuantity ,
                        c.iNum ,
                        ( case when c.iNum = 0 then null
                               else c.iQuantity / c.iNum
                          end ) as Rate ,
                        ( case when ( i.bPurchase = 1
                                      and i.bProxyForeign = 1
                                    ) then '采购,委外'
                               when i.bPurchase = 1 then '采购'
                               when i.bProxyForeign = 1 then '委外'
                               else '未知'
                          end ) as InvProp ,
                        cast(null as decimal(18, 6)) as BackQty ,
                        cast(null as decimal(18, 6)) as BackNum ,
                        cast('' as nvarchar(20)) as DoType ,
                        cast('' as nvarchar(20)) as ChangedInv ,
                        cast('' as nvarchar(20)) as ChangedWH
                 into   #Inv
                 from   dbo.CurrentStock C
                        left join dbo.Inventory I on C.cInvCode = I.cInvCode
                        left join dbo.ComputationUnit CM on i.cComUnitCode = CM.cComunitCode
                        left join dbo.ComputationUnit CA on i.cAssComUnitCode = ca.cComunitCode
                 where  1=1
                        and c.iQuantity > 0 

               

                 select i.cInvCode
                 into   #HavingPO
                 from   #Inv I
                        left join dbo.PO_Podetails PD on I.cInvCode = PD.cInvCode
                 where  i.InvProp = '未知'
                        and pd.cInvCode is not null
                 group by i.cInvCode 
                				
                				
                 select i.cInvCode
                 into   #HavingOM
                 from   #Inv I
                        left join dbo.OM_MODetails PD on I.cInvCode = PD.cInvCode
                 where  i.InvProp = '未知'
                        and pd.cInvCode is not null
                 group by i.cInvCode 
                				
                				
                 update #Inv
                 set    InvProp = '采购'
                 from   #Inv ,
                        #HavingPO
                 where  #Inv.cInvCode = #HavingPO.cInvCode 
                				
                				
                 update #Inv
                 set    InvProp = '委外'
                 from   #Inv ,
                        #HavingOM
                 where  #Inv.cInvCode = #HavingOM.cInvCode 
                				
                 update #Inv
                 set    InvProp = '采购,委外'
                 from   #Inv ,
                        ( select    #HavingPO.cInvCode
                          from      #HavingPO ,
                                    #HavingOM
                          where     #HavingPO.cInvCode = #HavingOM.cInvCode
                        ) S1
                 where  #Inv.cInvCode = s1.cInvCode
                				
                				
                 select cInvCode ,
                        max(cVenCode) as VenCode ,
                        count(cInvCode) as VenCount
                 into   #InvVen
                 from   ( select    d.cInvCode ,
                                    p.cVenCode
                          from      PO_Pomain p
                                    left join dbo.PO_Podetails d on p.POID = d.POID
                          where     d.cInvCode in ( select  cInvCode
                                                    from    #Inv )
                          group by  d.cInvCode ,
                                    p.cVenCode

                        union 
                        select  d.cInvCode,
                                v.cVenCode 
                        from    dbo.OM_MOMain P
                                left join dbo.OM_MODetails D on P.MOID = D.MOID
                                left join dbo.Vendor V on p.cVenCode = v.cVenCode
                        where   d.cInvCode in ( select  cInvCode
                                                    from    #Inv )
                        group by d.cInvCode,v.cVenCode 

                        ) s1
                 group by cInvCode
                 having count(cInvCode) = 1


                 update  #Inv set DoType='直接退货' 

                 select * ,
                        vd.cVenName
                 from   #Inv I
                        left join #InvVen V on I.cInvCode = V.cInvCode
                        left join dbo.Vendor VD on v.VenCode = vd.cVenCode 
                                        
                 drop table #Inv
                 drop table #InvVen
                 drop table #HavingPO
                 drop table #HavingOM
                            
            ";

        }


        protected override void BtnClick(string sBtnName, string sBtnText)
        {
            //try
            //{
            switch (sBtnName.ToLower())
            {
                case "save":
                    GenBackForm();
                    break;
                case "sel":
                    GetInvQty();
                    break;
                case "export":
                    Export();
                    break;
                case "vensel":
                    vensel();
                    break;
                case "dotype":
                    dotype();
                    break;
                default:
                    break;
            }
            //}
            //catch (Exception ee)
            //{
            //    MessageBox.Show(sBtnText + " 失败! \n\n原因:\n  " + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void dotype()
        {
            string invType = grvDetail.GetRowCellValue(grvDetail.FocusedRowHandle, colInvProp) == null ? "" : grvDetail.GetRowCellValue(grvDetail.FocusedRowHandle, colInvProp).ToString();
            if (!invType.Contains("委外"))
            {
                MessageBox.Show("只有委外件才需要指定处理方式", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string invCode = grvDetail.GetRowCellValue(grvDetail.FocusedRowHandle, colInvCode).ToString();
            string doType = grvDetail.GetRowCellValue(grvDetail.FocusedRowHandle, colDoType) == null ? "" : grvDetail.GetRowCellValue(grvDetail.FocusedRowHandle, colDoType).ToString();

            
            FrmProxyDoType fm = new FrmProxyDoType(invCode);
            fm.DoType = doType;
            if (fm.ShowDialog() != DialogResult.OK)
                return;
            grvDetail.SetRowCellValue(grvDetail.FocusedRowHandle, colDoType, fm.DoType);

            if (fm.DoType == "形态转换退货")
            {

                grvDetail.SetRowCellValue(grvDetail.FocusedRowHandle, colChangeInv, fm.ChangeInvCode);
                grvDetail.SetRowCellValue(grvDetail.FocusedRowHandle, colVenCode, fm.ChangeVenCode);
                grvDetail.SetRowCellValue(grvDetail.FocusedRowHandle, colVenName, fm.ChangeVenName);

                if (lueWH.EditValue != null)
                {
                    grvDetail.SetRowCellValue(grvDetail.FocusedRowHandle, colChangeWH, lueWH.EditValue.ToString());
                }
                else
                {
                    grvDetail.SetRowCellValue(grvDetail.FocusedRowHandle, colChangeWH, null);
                }
            }

            if (fm.DoType == "直接退货")
            {
                string sql =@"  
                        select  d.cInvCode,
                                v.cVenCode,
                                v.cVenName 
                        from    dbo.OM_MOMain P
                                left join dbo.OM_MODetails D on P.MOID = D.MOID
                                left join dbo.Vendor V on p.cVenCode = v.cVenCode
                        where   d.cInvCode='"+invCode +"'"+
                        "group by d.cInvCode,v.cVenCode,v.cVenName  ";
                DataTable dt = SqlHelper.ExecuteDataset(Assistanter.U8ConnectString, CommandType.Text, sql).Tables [0];
                if (dt.Rows.Count == 1)
                {
                    string oldVenCode = "";
                    string oldVenName = "";
                    oldVenCode = dt.Rows[0]["cVenCode"].ToString();
                    oldVenName = dt.Rows[0]["cVenName"].ToString();
                    grvDetail.SetRowCellValue(grvDetail.FocusedRowHandle, colChangeInv, "");
                    grvDetail.SetRowCellValue(grvDetail.FocusedRowHandle, colVenCode, oldVenCode);
                    grvDetail.SetRowCellValue(grvDetail.FocusedRowHandle, colVenName, oldVenName);
                }
                else
                {
                    grvDetail.SetRowCellValue(grvDetail.FocusedRowHandle, colChangeInv, "");
                    grvDetail.SetRowCellValue(grvDetail.FocusedRowHandle, colVenCode, "");
                    grvDetail.SetRowCellValue(grvDetail.FocusedRowHandle, colVenName, "");
                }
                grvDetail.SetRowCellValue(grvDetail.FocusedRowHandle, colChangeWH, null);
            }


        }

        private void vensel()
        {

            string proxyDoType = grvDetail.GetRowCellValue(grvDetail.FocusedRowHandle, colDoType).ToString();

            string invCode = grvDetail.GetRowCellValue(grvDetail.FocusedRowHandle, colInvCode).ToString();

            if (proxyDoType == "形态转换退货")
            {
                invCode = grvDetail.GetRowCellValue(grvDetail.FocusedRowHandle, colChangeInv) == null ? "" : grvDetail.GetRowCellValue(grvDetail.FocusedRowHandle, colChangeInv).ToString();
            }

            frmVenSel fm = new frmVenSel(invCode);
            if (fm.ShowDialog() != DialogResult.OK)
                return;

            grvDetail.SetRowCellValue(grvDetail.FocusedRowHandle, colVenCode, fm.VenCode);
            grvDetail.SetRowCellValue(grvDetail.FocusedRowHandle, colVenName, fm.VenName);

        }

        private void GenBackForm()
        {
            FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();
            string sSQL = "select * from @u8.GL_mend where iperiod = month('" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "')";
            DataTable dtTemp1 = clsSQLCommond.ExecQuery(sSQL);
            if (Convert.ToBoolean(dtTemp1.Rows[0]["bflag_ST"]) == true)
            {
                MessageBox.Show("当月库存管理已结帐，不能处理！");
                return;
            }


            U8ImportUtis.aList.Clear();
            DtWaitCloseForm.Clear();

            string errMsg = "";
            string invChangeMsg = "";
            grvDetail.PostEditor();
            this.Validate();

            bool haveData = false;
            for (int i = 0; i < grvDetail.RowCount; i++)
            {
                bool isSel = (bool)grvDetail.GetRowCellValue(i, colSel);
                if (isSel)
                {
                    haveData = true;
                    break; ;
                }
            }

            if (!haveData)
            {
                MessageBox.Show("未选择任何数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!CheckData())
                return;
            U8ImportUtis.WHCode = lueWH.EditValue.ToString();


            //采购件退货
            DataTable dtPuBack = new DataTable();
            DataColumn cID = new DataColumn("PODId");
            DataColumn cPoID = new DataColumn("POID");
            DataColumn cQty = new DataColumn("BackQty");
            DataColumn cArriveQty = new DataColumn("ArriveQty");
            DataColumn cReiveQty = new DataColumn("ReceiveQty");
            DataColumn cVenCode = new DataColumn("VenCode");

            cQty.DataType = typeof(decimal);
            cArriveQty.DataType = typeof(decimal);
            cReiveQty.DataType = typeof(decimal);

            dtPuBack.Columns.Add(cID);
            dtPuBack.Columns.Add(cQty);
            dtPuBack.Columns.Add(cPoID);
            dtPuBack.Columns.Add(cArriveQty);
            dtPuBack.Columns.Add(cReiveQty);
            dtPuBack.Columns.Add(cVenCode);


            //委外件直接退货
            DataTable dtOMDoBack = new DataTable();
            DataColumn cOMID = new DataColumn("PODId");
            DataColumn cOMPoID = new DataColumn("POID");
            DataColumn cOMQty = new DataColumn("BackQty");
            DataColumn cOMArriveQty = new DataColumn("ArriveQty");
            DataColumn cOMReiveQty = new DataColumn("ReceiveQty");
            DataColumn cOMVenCode = new DataColumn("VenCode");
            cOMQty.DataType = typeof(decimal);
            cOMArriveQty.DataType = typeof(decimal);
            cOMReiveQty.DataType = typeof(decimal);
            dtOMDoBack.Columns.Add(cOMID);
            dtOMDoBack.Columns.Add(cOMQty);
            dtOMDoBack.Columns.Add(cOMPoID);
            dtOMDoBack.Columns.Add(cOMArriveQty);
            dtOMDoBack.Columns.Add(cOMReiveQty);
            dtOMDoBack.Columns.Add(cOMVenCode);

            SqlConnection conn = new SqlConnection(Assistanter.U8ConnectString);

            conn.Open();
            //启用事务
            SqlTransaction trans = conn.BeginTransaction();
            try
            {
                int lastPeriod = 0;
                string sql = " select isnull(min(iperiod ),0) as iperiod  from GL_mend where bflag_ST =0";
                DataTable dtPeriod = SqlHelper.ExecuteDataset(Assistanter.U8ConnectString, CommandType.Text, sql).Tables[0];
                if (dtPeriod.Rows.Count > 0)
                {
                    lastPeriod = int.Parse(dtPeriod.Rows[0]["iperiod"].ToString());
                }

                for (int i = 0; i < grvDetail.RowCount; i++)
                {

                    bool isSel = (bool)grvDetail.GetRowCellValue(i, colSel);
                    if (!isSel)
                        continue;
                    decimal backQty = decimal.Parse(grvDetail.GetRowCellValue(i, colBackQty) == null || grvDetail.GetRowCellValue(i, colBackQty).ToString() == "" ? "0" : grvDetail.GetRowCellValue(i, colBackQty).ToString());
                    string invProp = grvDetail.GetRowCellValue(i, colInvProp) == null || grvDetail.GetRowCellValue(i, colInvProp).ToString() == "" ? "0" : grvDetail.GetRowCellValue(i, colInvProp).ToString();
                    string venCode = grvDetail.GetRowCellValue(i, colVenCode) == null || grvDetail.GetRowCellValue(i, colVenCode).ToString() == "" ? "0" : grvDetail.GetRowCellValue(i, colVenCode).ToString();
                    string invCode = grvDetail.GetRowCellValue(i, colInvCode) == null || grvDetail.GetRowCellValue(i, colInvCode).ToString() == "" ? "0" : grvDetail.GetRowCellValue(i, colInvCode).ToString();
                    string proxyDoType = grvDetail.GetRowCellValue(i, colDoType).ToString();

                    string afterWhCode = grvDetail.GetRowCellValue(i, colChangeWH) == null ? "" : grvDetail.GetRowCellValue(i, colChangeWH).ToString();

                    #region 采购件处理
                    if (invProp.Contains("采购"))
                    {
                        sql = @"select d.POID ,
                                        d.ID as PODID ,
                                        d.iQuantity,
                                        isnull(d.iReceivedQTY ,0) as iReceivedQTY ,
                                        isnull(d.iArrQTY ,0) as iArrQTY 
                                from    dbo.PO_Podetails D
                                        left join dbo.PO_Pomain M on D.POID = M.POID
                                where   m.cVenCode = '{0}'
                                        and d.cInvCode = '{1}'
                                        --and month(M.dPODate)>={2}
                                        --and isnull(d.cbCloser, '') = ''
                                order by m.dPODate desc ";
                        sql = string.Format(sql, venCode, invCode,lastPeriod );
                        DataTable dt = SqlHelper.ExecuteDataset(Assistanter.U8ConnectString, CommandType.Text, sql).Tables[0];
                        decimal totalBackQty = 0;
                        for (int j = 0; j < dt.Rows.Count; j++)
                        {
                            totalBackQty += decimal.Parse(dt.Rows[j]["iReceivedQTY"].ToString()) + decimal.Parse(dt.Rows[j]["iArrQTY"].ToString());
                        }
                        if (totalBackQty < backQty)
                        {
                            string msg = "第" + (i + 1) + "行,订单可退货数量:" + totalBackQty + "小于本次需退货数量:" + backQty + "无法退货";
                            MessageBox.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error );
                           
                            return ;

                        }
                        totalBackQty = 0;

                        sql = @"select  *
                                from    ( select    cast(1 as int) as FType ,
                                                    case when  isnull(D.iArrQTY,0)>0 then 1 else 2  end as QtyType,
                                                    dPODate ,
                                                    d.POID ,
                                                    d.ID as PODID ,
                                                    d.iQuantity,
                                                    isnull(D.iArrQTY,0) as iArrQTY,
                                                    isnull(d.iReceivedQTY ,0) as iReceivedQTY 
                                          from      dbo.PO_Podetails D
                                                    left join dbo.PO_Pomain M on D.POID = M.POID
                                          where     m.cVenCode = '{0}'
                                                    and d.cInvCode = '{1}'
                                                    --and month(M.dPODate)>={2}
                                                    and isnull(d.cbCloser, '') = ''
                                          union all
                                          select    cast(2 as int) as FType ,
                                                    case when  isnull(D.iArrQTY,0)>0 then 1 else 2  end as QtyType,
                                                    dPODate ,
                                                    d.POID ,
                                                    d.ID as PODID ,
                                                    d.iQuantity,
                                                    isnull(D.iArrQTY,0) as iArrQTY,
                                                    isnull(d.iReceivedQTY,0 ) as iReceivedQTY 
                                          from      dbo.PO_Podetails D
                                                    left join dbo.PO_Pomain M on D.POID = M.POID
                                          where     m.cVenCode = '{0}'
                                                    and d.cInvCode = '{1}'
                                                    and isnull(d.cbCloser, '') <> ''
                                                    --and month(M.dPODate)>={2}
                                        ) S1
                                order by FType ,QtyType,
                                        dPODate desc ";
                        sql = string.Format(sql, venCode, invCode,lastPeriod );
                        dt = SqlHelper.ExecuteDataset(Assistanter.U8ConnectString, CommandType.Text, sql).Tables[0];

                        for (int j = 0; j < dt.Rows.Count; j++)
                        {
                            if (totalBackQty > backQty)
                                break;
                            decimal remainQty = backQty - totalBackQty;

                            decimal currentQty = 0;
                            decimal currentArrQty = decimal.Parse(dt.Rows[j]["iArrQTY"].ToString() == "" ? "0" : dt.Rows[j]["iArrQTY"].ToString());
                            decimal currentReveQty = decimal.Parse(dt.Rows[j]["iReceivedQty"].ToString() == "" ? "0" : dt.Rows[j]["iReceivedQty"].ToString());

                            currentQty = currentArrQty + currentReveQty;

                            string poId = dt.Rows[j]["POID"].ToString();
                            string poDId = dt.Rows[j]["PODID"].ToString();
                            DataRow row = dtPuBack.NewRow();
                            row["POID"] = poId;
                            row["PODId"] = poDId;

                            if (remainQty >= currentQty)
                            {
                                row["BackQty"] = currentQty.ToString();
                            }
                            else
                            {
                                if (remainQty > 0)
                                {
                                    row["BackQty"] = remainQty.ToString();
                                }
                                else
                                {
                                    row["BackQty"] = backQty;
                                }
                            }

                            if (currentArrQty > 0)
                                row["ArriveQty"] = row["BackQty"];

                            if (currentReveQty > 0)
                                row["ReceiveQty"] = row["BackQty"];

                            row["VenCode"] = venCode;
                            totalBackQty += currentQty;

                            dtPuBack.Rows.Add(row);
                        }
                    }
                    #endregion

                    #region 委外件处理
                    if (invProp.Contains("委外"))
                    {

                        if (proxyDoType == "直接退货")
                        {
                            sql = @"select
                                            m.MOID as POID ,
                                            d.MODetailsID as PODid ,
                                            isnull(d.iArrQTY,0) as iArrQTY,
                                            isnull(d.iReceivedQTY ,0) as iReceiveQty
                                    from    dbo.OM_MOMain M
                                            left join dbo.OM_MODetails D on M.MOID = D.MOID
                                    where   1=1
                                            --and isnull(d.cbCloser, '') = ''
                                            and m.cVenCode = '{0}'
                                            and d.cInvCode = '{1}'
                                            --and month( m.dDate ) >={2}
                                    order by m.dDate desc  ";
                            sql = string.Format(sql, venCode, invCode,lastPeriod );
                            DataTable dt = SqlHelper.ExecuteDataset(Assistanter.U8ConnectString, CommandType.Text, sql).Tables[0];
                            decimal totalBackQty = 0;
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                totalBackQty += (decimal.Parse(dt.Rows[j]["iArrQTY"].ToString()) + decimal.Parse(dt.Rows[j]["iReceiveQty"].ToString()));
                            }
                            if (totalBackQty < backQty)
                            {
                                string msg = "第" + (i + 1) + "行,订单可退货数量:" + totalBackQty + "小于本次需退货数量:" + backQty + "无法退货";
                                MessageBox.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error  );
                                errMsg += "第" + (i + 1) + "行,订单可退货数量:" + totalBackQty + "小于本次需退货数量:" + backQty + "无法退货";
                                return ;

                                //string msg = "第" + (i + 1) + "行,订单可退货数量:" + totalBackQty + "小于本次需退货数量:" + backQty + "无法退货";


                                //if (MessageBox.Show(msg, "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                //{
                                //    errMsg += "第" + (i + 1) + "行,未关闭订单可退货数量:" + totalBackQty + "小于本次需退货数量:" + backQty + "无法自动退货\r\n";
                                //    continue;
                                //}
                            }

                            totalBackQty = 0;

                            sql = @"
                                select  *
                                from    ( select    cast(1 as int) FType ,
                                                    case when isnull(d.iArrQTY,0)>0 then 1 else 2 end as QtyType,
                                                    m.MOID as POID ,
                                                    m.dDate ,
                                                    d.MODetailsID as PODid ,
                                                    isnull(d.iArrQTY,0) as iArrQTY,
                                                    isnull(d.iReceivedQTY ,0) as iReceiveQty
                                          from      dbo.OM_MOMain M
                                                    left join dbo.OM_MODetails D on M.MOID = D.MOID
                                          where     m.cVenCode = '{0}'
                                                    and d.cInvCode = '{1}'
                                                    and isnull(d.cbCloser, '') = ''
                                                    --and month( m.dDate ) >={2}
                                          union all
                                          select    cast(2 as int) FType ,
                                                    case when isnull(d.iArrQTY,0)>0 then 1 else 2 end as QtyType,
                                                    m.MOID as POID ,
                                                    m.dDate ,
                                                    d.MODetailsID as PODid ,
                                                    isnull(d.iArrQTY,0) as iArrQTY,
                                                    isnull(d.iReceivedQTY ,0) as iReceiveQty
                                          from      dbo.OM_MOMain M
                                                    left join dbo.OM_MODetails D on M.MOID = D.MOID
                                          where     m.cVenCode = '{0}'
                                                    and d.cInvCode = '{1}'
                                                    and isnull(d.cbCloser, '') <> ''
                                                    --and month( m.dDate ) >={2}
                                        ) S1
                                order by S1.FType ,QtyType,
                                        dDate desc 
                                ";
                            sql = string.Format(sql, venCode, invCode,lastPeriod );
                            dt = SqlHelper.ExecuteDataset(Assistanter.U8ConnectString, CommandType.Text, sql).Tables[0];

                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                if (totalBackQty > backQty)
                                    break;
                                decimal remainQty = backQty - totalBackQty;
                                decimal currentQty = 0;
                                decimal currentArrQty = decimal.Parse(dt.Rows[j]["iArrQTY"].ToString() == "" ? "0" : dt.Rows[j]["iArrQTY"].ToString());
                                decimal currentReveQty = decimal.Parse(dt.Rows[j]["iReceiveQty"].ToString() == "" ? "0" : dt.Rows[j]["iReceiveQty"].ToString());

                                currentQty = currentArrQty + currentReveQty;

                                string poId = dt.Rows[j]["POID"].ToString();
                                string poDId = dt.Rows[j]["PODID"].ToString();

                                DataRow row = dtOMDoBack.NewRow();
                                row["POID"] = poId;
                                row["PODId"] = poDId;
                                if (remainQty >= currentQty)
                                {
                                    row["BackQty"] = currentQty.ToString();
                                }
                                else
                                {
                                    if (remainQty > 0)
                                    {
                                        row["BackQty"] = remainQty.ToString();
                                    }
                                    else
                                    {
                                        row["BackQty"] = backQty;
                                    }
                                }

                                if (currentArrQty > 0)
                                    row["ArriveQty"] = row["BackQty"];

                                if (currentReveQty > 0)
                                    row["ReceiveQty"] = row["BackQty"];

                                row["VenCode"] = venCode;
                                totalBackQty += currentQty;

                                dtOMDoBack.Rows.Add(row);
                            }
                        }

                        if (proxyDoType == "形态转换退货")
                        {
                            string beforInvCode = grvDetail.GetRowCellValue(i, colInvCode).ToString();
                            string afterInvCode = grvDetail.GetRowCellValue(i, colChangeInv).ToString();
                            string changeBackQty = grvDetail.GetRowCellValue(i, colBackQty).ToString();

                            afterWhCode = afterWhCode == "" ? lueWH.EditValue.ToString() : afterWhCode;
                            try
                            {
                                invChangeMsg+= U8ImportUtis.GenInvChange(trans, beforInvCode, afterInvCode, changeBackQty, changeBackQty, afterWhCode);
                            }
                            catch(Exception error)
                            {
                                errMsg += "第" + (i + 1) + "行,产生形态转换发生错误\n" + error.Message+"\r\n";
                                continue;
                            }

                            sql = @"
                                    select  *
                                    from    ( select    cast(1 as int) as FType ,
                                                        dPODate ,
                                                        d.POID ,
                                                        d.ID as PODID ,
                                                        d.iQuantity,
                                                        isnull(D.iArrQTY,0) as iArrQTY,
                                                        isnull(d.iReceivedQTY,0 ) as iReceivedQTY 
                                              from      dbo.PO_Podetails D
                                                        left join dbo.PO_Pomain M on D.POID = M.POID
                                              where     m.cVenCode = '{0}'
                                                        and d.cInvCode = '{1}'
                                                        --and isnull(d.cbCloser, '') = ''
                                                        --and month(M.dPODate)>={2}
                                            ) S1
                                    order by FType ,
                                            dPODate desc";
                            sql = string.Format(sql, venCode, afterInvCode,lastPeriod,lastPeriod );
                            DataTable dt = SqlHelper.ExecuteDataset(Assistanter.U8ConnectString, CommandType.Text, sql).Tables[0];
                            decimal totalBackQty = 0;
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                totalBackQty += decimal.Parse(dt.Rows[j]["iReceivedQTY"].ToString()) + decimal.Parse(dt.Rows[j]["iReceivedQTY"].ToString());
                            }
                            if (totalBackQty < backQty)
                            {
                                string msg = "第" + (i + 1) + "行,订单可退货数量:" + totalBackQty + "小于本次需退货数量:" + backQty + "无法退货";
                                MessageBox.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error );
                                errMsg += "第" + (i + 1) + "行,订单可退货数量:" + totalBackQty + "小于本次需退货数量:" + backQty + "无法退货";
                                return ;
                            }

                            totalBackQty = 0;

                            sql = @"
                                    select  *
                                    from    ( select    cast(1 as int) as FType ,
                                                        case when  isnull(D.iArrQTY,0)>0 then 1 else 2  end as QtyType,
                                                        dPODate ,
                                                        d.POID ,
                                                        d.ID as PODID ,
                                                        d.iQuantity,
                                                        isnull(D.iArrQTY,0) as iArrQTY,
                                                        isnull(d.iReceivedQTY,0 ) as iReceivedQTY 
                                              from      dbo.PO_Podetails D
                                                        left join dbo.PO_Pomain M on D.POID = M.POID
                                              where     m.cVenCode = '{0}'
                                                        and d.cInvCode = '{1}'
                                                        and isnull(d.cbCloser, '') = ''
                                                        --and month(M.dPODate)>={2}
                                              union all
                                              select    cast(2 as int) as FType ,
                                                        case when  isnull(D.iArrQTY,0)>0 then 1 else 2  end as QtyType,
                                                        dPODate ,
                                                        d.POID ,
                                                        d.ID as PODID ,
                                                        d.iQuantity,
                                                        isnull(D.iArrQTY,0) as iArrQTY,
                                                        isnull(d.iReceivedQTY,0 ) as iReceivedQTY 
                                              from      dbo.PO_Podetails D
                                                        left join dbo.PO_Pomain M on D.POID = M.POID
                                              where     m.cVenCode = '{0}'
                                                        and d.cInvCode = '{1}'
                                                        and isnull(d.cbCloser, '') <> ''
                                                        --and month(M.dPODate)>={2}
                                            ) S1
                                    order by FType ,QtyType,
                                            dPODate desc";
                            sql = string.Format(sql, venCode, afterInvCode,lastPeriod );
                            dt = SqlHelper.ExecuteDataset(Assistanter.U8ConnectString, CommandType.Text, sql).Tables[0];

                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                if (totalBackQty > backQty)
                                    break;
                                decimal remainQty = backQty - totalBackQty;
                                decimal currentQty = decimal.Parse(dt.Rows[j]["iQuantity"].ToString());
                                decimal arriveQty = decimal.Parse(dt.Rows[j]["iArrQTY"].ToString());
                                string poId = dt.Rows[j]["POID"].ToString();
                                string poDId = dt.Rows[j]["PODID"].ToString();
                                DataRow row = dtPuBack.NewRow();
                                row["POID"] = poId;
                                row["PODId"] = poDId;
                                if (remainQty >= currentQty)
                                {
                                    row["BackQty"] = currentQty.ToString();
                                }
                                else
                                {
                                    if (remainQty > 0)
                                        row["BackQty"] = remainQty.ToString();
                                    else
                                    {
                                        row["BackQty"] = backQty;

                                    }
                                }

                                if (arriveQty > 0)
                                {
                                    row["ArriveQty"] = row["BackQty"];
                                    row["ReceiveQty"] = 0;
                                }

                                else
                                {
                                    row["ReceiveQty"] = row["BackQty"];
                                    row["ArriveQty"] = 0;
                                }

                                row["VenCode"] = venCode;
                                totalBackQty += currentQty;

                                dtPuBack.Rows.Add(row);
                            }
                        }

                    #endregion
                    }
                }

                string returnMsg = "";
                bool isSucess = U8ImportUtis.DoBack(trans, dtPuBack, dtOMDoBack, out returnMsg);

                trans.Commit();
                trans = null;
                conn.Close();
                conn = null;

                if (isSucess)
                {
                    returnMsg = "处理完毕:\r\n" +invChangeMsg+ returnMsg;
                }
                else
                {
                    returnMsg = "发生错误:\r\n" + returnMsg;
                }

                FrmMsgBox fMsgBos = new FrmMsgBox();
                fMsgBos.richTextBox1.Text  = returnMsg;

                DialogResult resl = fMsgBos.ShowDialog();

                if (errMsg == "" && resl == DialogResult.OK)
                    GetInvQty();
            }
            catch (Exception error)
            {
                trans.Rollback();
                conn = null;
                MessageBox.Show(error+"\r\n"+errMsg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetInvQty()
        {
            if (lueWH.Text.Trim() == "")
            {
                MessageBox.Show("请设置仓库！");
                lueWH.Focus();
                return;
            }

            string filter = "";

            filter = " 1=1 ";
            if (lueWH.Text != "")
                filter += " and c.cWHCode ='" + lueWH.EditValue.ToString() + "'";

            if (lueInvStart.Text != "")
                filter += " and c.cInvCode >='" + lueInvStart.EditValue.ToString() + "'";


            if (lueInvTo.Text != "")
                filter += " and c.cInvCode <='" + lueInvTo.EditValue.ToString() + "'";

            if (btnInvClass.EditValue != null && btnInvClass.Text != "")
            {
                filter += " and c.cInvCode like '" + btnInvClass.Text + "%'";
            }

            string sql = filter == "" ? SQL : SQL.Replace("1=1", filter);
            DTSource = SqlHelper.ExecuteDataset(Assistanter.U8ConnectString, CommandType.Text, sql).Tables[0];
            grdDetail.DataSource = DTSource;
        }


        private bool CheckData()
        {
            string msg = "";
            if (lueWH.EditValue == null)
            {
                msg += "请选择仓库";
            }
            for (int i = 0; i < grvDetail.RowCount; i++)
            {
                bool isSel = (bool)grvDetail.GetRowCellValue(i, colSel);
                if (!isSel)
                    continue;
                decimal backQty = decimal.Parse(grvDetail.GetRowCellValue(i, colBackQty) == null || grvDetail.GetRowCellValue(i, colBackQty).ToString() == "" ? "0" : grvDetail.GetRowCellValue(i, colBackQty).ToString());
                string invProp = grvDetail.GetRowCellValue(i, colInvProp) == null || grvDetail.GetRowCellValue(i, colInvProp).ToString() == "" ? "0" : grvDetail.GetRowCellValue(i, colInvProp).ToString();
                string venCode = grvDetail.GetRowCellValue(i, colVenCode) == null || grvDetail.GetRowCellValue(i, colVenCode).ToString() == "" ? "" : grvDetail.GetRowCellValue(i, colVenCode).ToString();

                if (backQty == 0)
                    msg += "第" + (i + 1) + "行" + "退货数量为0 \r\n";

                if (invProp == "未知")
                    msg += "第" + (i + 1) + "行" + "未知的物料属性 \r\n";

                if (venCode == "")
                    msg += "第" + (i + 1) + "行" + "供应商未确定 \r\n";

                if (invProp == "委外")
                {
                    string doType = grvDetail.GetRowCellValue(i, colDoType) == null ? "" : grvDetail.GetRowCellValue(i, colDoType).ToString();
                    if (doType == "")
                    {
                        msg += "第" + (i + 1) + "行" + "委外件请确定处理方案 \r\n";
                    }
                }

            }
            if (msg != "")
            {
                MessageBox.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }



        private void Export()
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "*.xls|*.xls";
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            grvDetail.ExportToXls(dlg.FileName);
            MessageBox.Show("完成");
        }

        private void FormVenBack_Load(object sender, EventArgs e)
        {

            LoadVenCode();

            InitWaitCloseForm();
            IniWHRpi();
        }

        private void IniWHRpi()
        {
            string sql = "select cWhCode  ,cWhName  from dbo.Warehouse  order by cWhCode  ";
            DataTable dt = SqlHelper.ExecuteDataset(Assistanter.U8ConnectString, CommandType.Text, sql).Tables[0];
            rpiWH.DataSource = dt;
        }

        private void InitWaitCloseForm()
        {
            DataColumn colDataType = new DataColumn("FormType");
            DataColumn colDId = new DataColumn("DId");
            DtWaitCloseForm.Columns.Add(colDataType);
            DtWaitCloseForm.Columns.Add(colDId);
        }



        private void LoadVenCode()
        {
            string sql = "select cWhCode ,cWhName  from dbo.Warehouse  order by cWhCode  ";
            DataTable dt = SqlHelper.ExecuteDataset(Assistanter.U8ConnectString, CommandType.Text, sql).Tables[0];
            lueWH.Properties.DataSource = dt;
        }


        private void grvDetail_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            if (e.Info.IsRowIndicator)
            {
                if (e.RowHandle >= 0)
                {
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
                }
                else if (e.RowHandle < 0 && e.RowHandle > -1000)
                {
                    e.Info.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
                    e.Info.DisplayText = "G" + e.RowHandle.ToString();
                }
            }
        }

        private void rpiProxyDoType_Click(object sender, EventArgs e)
        {
            //dotype();
        }

        private void rpiVen_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            vensel();
        }

        private void lueInvStart_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FrmInvInfo fVen = new FrmInvInfo(lueInvStart.Text.Trim());

            if (DialogResult.OK == fVen.ShowDialog())
            {

                lueInvStart.Text = fVen.sInvCode;
                lblInvStart.Text = fVen.sInvName;

            }
        }

        private void lueInvTo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FrmInvInfo fVen = new FrmInvInfo(lueInvTo.Text.Trim());
            if (DialogResult.OK == fVen.ShowDialog())
            {

                lueInvTo.Text = fVen.sInvCode;
                lblInvTo.Text = fVen.sInvName;
            }
        }

        private void lueInvStart_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = GetcInvCode(lueInvStart.Text.Trim());
                if (dt != null && dt.Rows.Count > 0)
                {
                    lblInvStart.Text = dt.Rows[0]["iText"].ToString().Trim();
                    lueInvTo.Text = lueInvStart.Text;
                }
                else
                {
                    lueInvStart.Text = "";
                    lblInvStart.Text = "";
                    lblInvTo.Text = "";
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得存货信息失败！ " + ee.Message);
            }
        }


        private DataTable GetcInvCode(string scInvCode)
        {
            try
            {
                FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();
                string sSQL = "select cInvCode as iID,cInvName as iText from @u8.Inventory  where cInvCode = '" + scInvCode + "' order by cInvCode";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                return dt;
            }
            catch
            {
                throw new Exception("获得存货信息失败！");
            }
        }


        private DataTable GetcInvClass(string invClass)
        {
            try
            {
                FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();
                string sSQL = "select cInvCCode , cInvCName    from @u8.InventoryClass  where  cInvCCode= '" + invClass + "' ";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                return dt;
            }
            catch
            {
                throw new Exception("获得存货信息失败！");
            }
        }

        private void lueInvTo_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = GetcInvCode(lueInvTo.Text.Trim());
                if (dt != null && dt.Rows.Count > 0)
                {
                    lblInvTo.Text = dt.Rows[0]["iText"].ToString().Trim();
                }
                else
                {
                    lueInvTo.Text = "";
                    lblInvTo.Text = "";
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得存货信息失败！ " + ee.Message);
            }
        }

        private void btnInvClass_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FrmInvClass fm = new FrmInvClass();
            if (fm.ShowDialog() != DialogResult.OK)
                return;
            btnInvClass.Text = fm.SelClassCode;
            txtInvClassName.Text = fm.SelClassName;

        }

        private void btnInvClass_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = GetcInvClass(btnInvClass.Text.Trim());
                if (dt != null && dt.Rows.Count > 0)
                {
                    btnInvClass.Text = dt.Rows[0]["cInvCCode"].ToString().Trim();
                    txtInvClassName.Text = dt.Rows[0]["cInvCName"].ToString().Trim();

                }
                else
                {
                    btnInvClass.Text = "";
                    txtInvClassName.Text = "";
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得存货分类信息失败！ " + ee.Message);
            }
        }

        private void rpiBackNum_EditValueChanged(object sender, EventArgs e)
        {
            TextEdit edit = sender as TextEdit;
            string num = edit.Text;

            string rate = grvDetail.GetRowCellValue(grvDetail.FocusedRowHandle, colRate) == null || grvDetail.GetRowCellValue(grvDetail.FocusedRowHandle, colRate).ToString() == "" ? "0" :
                grvDetail.GetRowCellValue(grvDetail.FocusedRowHandle, colRate).ToString();
            decimal dRate = decimal.Parse(rate);
            if (dRate == 0)
            {
                grvDetail.SetRowCellValue(grvDetail.FocusedRowHandle, colBackNum, null);
                MessageBox.Show("换算率为0或者不存在,不能自动换算");
                return;

            }
            decimal backQty = Math.Round(dRate * decimal.Parse(num), 4);
            decimal stockQty = decimal.Parse(grvDetail.GetRowCellValue(grvDetail.FocusedRowHandle, colQty).ToString());
            if (backQty > stockQty)
            {
                MessageBox.Show("退货数量大于库存数量");
                grvDetail.SetRowCellValue(grvDetail.FocusedRowHandle, colBackNum, null);
                grvDetail.SetRowCellValue(grvDetail.FocusedRowHandle, colBackQty, null);
                return;

            }
            grvDetail.SetRowCellValue(grvDetail.FocusedRowHandle, colBackQty, backQty);
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            inSearch = true;

            for (int i = (isCanFind == true ? currentRow + 1 : currentRow); i < grvDetail.RowCount; i++)
            {
                string invName = grvDetail.GetRowCellValue(i, colInvName) == null ? "" : grvDetail.GetRowCellValue(i, colInvName).ToString();
                if (invName.Contains(txtSeaInvName.Text))
                {
                    isCanFind = true;
                    currentRow = i;
                    grvDetail.FocusedRowHandle = i;

                    return;
                }
            }

            if (!isCanFind)
            {
                MessageBox.Show("未找到");
                currentRow = 0;
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (DTSource.Rows.Count == 0)
            {

                MessageBox.Show("没有数据");
                return;
            }
            DTSource.DefaultView.RowFilter = ("IsSel=1");

            grdDetail.DataSource = DTSource.DefaultView;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (DTSource.Rows.Count == 0)
            {

                MessageBox.Show("没有数据");
                return;
            }
            DTSource.DefaultView.RowFilter = ("");

            grdDetail.DataSource = DTSource.DefaultView;

        }

        private void txtSeaInvCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FrmInvInfo fVen = new FrmInvInfo(txtSeaInvCode.Text.Trim());

            if (DialogResult.OK == fVen.ShowDialog())
            {
                txtSeaInvCode.Text = fVen.sInvCode;
                txtSeaInvName.Text = fVen.sInvName;
            }
        }

        private void txtSeaInvCode_EditValueChanged(object sender, EventArgs e)
        {
            inSearch = false;
            currentRow = 0;


            try
            {
                DataTable dt = GetcInvCode(txtSeaInvCode.Text.Trim());
                if (dt != null && dt.Rows.Count > 0)
                {
                    txtSeaInvName.Text = dt.Rows[0]["iText"].ToString().Trim();


                }
                else
                {
                    txtSeaInvName.Text = "";
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得存货信息失败！ " + ee.Message);
            }

        }

        private void grvDetail_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (!inSearch)
            {
                return;
            }

            string invName = grvDetail.GetRowCellValue(e.RowHandle, colInvName) == null ? "" : grvDetail.GetRowCellValue(e.RowHandle, colInvName).ToString();
            if (invName.Contains(txtSeaInvName.Text))
            {
                e.Appearance.BackColor = Color.YellowGreen;
            }
        }

        private void txtSeaInvName_EditValueChanged(object sender, EventArgs e)
        {
            inSearch = false;
            currentRow = 0;
        }

        private void rpiProxyDoType_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            dotype();
        }

        private void rpiBackQty_EditValueChanged(object sender, EventArgs e)
        {
            decimal qty = decimal.Parse((sender as TextEdit).Text);
            decimal remainQty = decimal.Parse(grvDetail.GetRowCellValue(grvDetail.FocusedRowHandle, colQty).ToString());
            if (qty > remainQty)
            {
                MessageBox.Show("输入的退货数量大于库存数量", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                grvDetail.SetRowCellValue(grvDetail.FocusedRowHandle, colBackQty, null);
                return;
            }
           
        }

    }
}
