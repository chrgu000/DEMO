using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
//using UFIDA.U8.UAP.CustomApp.ControlForm.Business;
using DevExpress.XtraEditors;
using System.Xml;
using System.Data.SqlClient;
using TH.BaseClass;


namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class 销售汇总表 : UserControl
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

        string sState = "";

        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }

        public 销售汇总表()
        {
            InitializeComponent();
        }


        private void ProjectManager_Load(object sender, EventArgs e)
        {
            try
            {

                dateEdit1.DateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-01"));
                dateEdit2.DateTime = DateTime.Now;

            }
            catch (Exception ee)
            {
                //MessageBox.Show("加载数据失败");
                throw new Exception(ee.Message);
            }
        }

        
        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            try
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
            catch { }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "xls";
                sF.FileName = this.Text;
                sF.Filter = "Excel文件(*.xls)|*.xls|所有文件(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK == dRes)
                {
                    gridView1.ExportToXls(sF.FileName);
                    MessageBox.Show("导出Excel成功\n\t路径：" + sF.FileName);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnSEL_Click(object sender, EventArgs e)
        {
            try
            {
                //if(DateTime.Now > Convert.ToDateTime("2017-10-01"))
                //    return;

                string sDate1 = dateEdit1.DateTime.ToString("yyyy-MM-dd");
                string sDate2 = dateEdit2.DateTime.AddDays(1).ToString("yyyy-MM-dd");

                string sSQL = @"

IF OBJECT_ID('tempdb..#_TH_REP_SUM') IS NOT NULL
	drop table #_TH_REP_SUM
-- 北京
select  d.cInvCName,e.cInvCName as cInvCName2,b.cInvCode,c.cInvName,c.cInvStd
	,cast(sum(b.iQuantity) as decimal(16,2)) as iQtyBJ 
	,cast(sum(b.iNatSum) as decimal(16,2))  as iMomeyBJ 
	,cast(case when isnull(sum(b.iQuantity),0) <> 0 then sum(b.iNatSum) / sum(b.iQuantity) end as decimal(16,2)) AS iPriceBJ 
	,cast(null as decimal(16,2)) as iQtyKS
	,cast(null as decimal(16,2)) as iMomeyKS
	,cast(null as decimal(16,2)) as iPriceKS

	,cast(null as decimal(16,2)) as iQtySD
	,cast(null as decimal(16,2)) as iMomeySD
	,cast(null as decimal(16,2)) as iPriceSD

	,cast(null as decimal(16,2)) as iQtySC
	,cast(null as decimal(16,2)) as iMomeySC
	,cast(null as decimal(16,2)) as iPriceSC

	,cast(null as decimal(16,2)) as iQtyHW
	,cast(null as decimal(16,2)) as iMomeyHW
	,cast(null as decimal(16,2)) as iPriceHW

	,cast(null as decimal(16,2)) as iQtySXYH
	,cast(null as decimal(16,2)) as iMoneySXYH
	,cast(null as decimal(16,2)) as iPriceSXYH

	,cast(null as decimal(16,2)) as iQtySZ
	,cast(null as decimal(16,2)) as iMomeySZ
	,cast(null as decimal(16,2)) as iPriceSZ

	,cast(null as decimal(16,2)) as iQtyCZ
	,cast(null as decimal(16,2)) as iMomeyCZ
	,cast(null as decimal(16,2)) as iPriceCZ

	,cast(null as decimal(16,2)) as iQtyXM
	,cast(null as decimal(16,2)) as iMomeyXM
	,cast(null as decimal(16,2)) as iPriceXM

	,cast(null as decimal(16,2)) as iQtyDL
	,cast(null as decimal(16,2)) as iMomeyDL
	,cast(null as decimal(16,2)) as iPriceDL

into #_TH_REP_SUM
from   ufdata_101_2013..DispatchList a inner join ufdata_101_2013..DispatchLists  b on a.DLID = b.DLID
inner join ufdata_101_2013..inventory c on b.cInvCode  = c.cInvCode 
inner join ufdata_101_2013..InventoryClass d on substring(c.cInvCCode,1,3) = d.cInvCCode
inner join ufdata_101_2013..InventoryClass e on c.cInvCCode = e.cInvCCode
inner join ufdata_101_2013..Customer cus on cus.cCusCode = a.cCusCode
inner join ufdata_101_2013..Department  f on cus.cCusDepart  = f.cDepCode 
--inner join ufdata_101_2013..Department  f on a.cDepCode  = f.cDepCode 
where  f.cDepMemo is not null and f.cDepMemo = '北京'
	and a.dDate >= '2017-03-01' and a.dDate < '2017-03-08'
group by   d.cInvCName,f.cDepMemo,b.cInvCode,c.cInvName,c.cInvStd,e.cInvCName



-- 昆山销售部
INSERT INTO #_TH_REP_SUM(cInvCName,cInvCName2,cInvCode,cInvName,cInvStd,iQtyKS,iMomeyKS,iPriceKS)
select  d.cInvCName,e.cInvCName as cInvCName2,b.cInvCode,c.cInvName,c.cInvStd
	,cast(sum(b.iQuantity) as decimal(16,2)) as iquantity 
	,cast(sum(b.iNatSum) as decimal(16,2))  as momey
	,cast(case when isnull(sum(b.iQuantity),0) <> 0 then sum(b.iNatSum) / sum(b.iQuantity) end as decimal(16,2)) AS iPrice
from   ufdata_101_2013..DispatchList a inner join ufdata_101_2013..DispatchLists  b on a.DLID = b.DLID
inner join ufdata_101_2013..inventory c on b.cInvCode  = c.cInvCode 
inner join ufdata_101_2013..InventoryClass d on substring(c.cInvCCode,1,3) = d.cInvCCode
inner join ufdata_101_2013..InventoryClass e on c.cInvCCode = e.cInvCCode
inner join ufdata_101_2013..Customer cus on cus.cCusCode = a.cCusCode
inner join ufdata_101_2013..Department  f on cus.cCusDepart  = f.cDepCode 
--inner join ufdata_101_2013..Department  f on a.cDepCode  = f.cDepCode 
where  f.cDepMemo is not null and f.cDepMemo = '昆山销售部'
	and a.dDate >= '2017-03-01' and a.dDate < '2017-03-08'
group by   d.cInvCName,f.cDepMemo,b.cInvCode,c.cInvName,c.cInvStd,e.cInvCName


-- 山东
INSERT INTO #_TH_REP_SUM(cInvCName,cInvCName2,cInvCode,cInvName,cInvStd,iQtySD,iMomeySD,iPriceSD)
select  d.cInvCName,e.cInvCName as cInvCName2,b.cInvCode,c.cInvName,c.cInvStd
	,cast(sum(b.iQuantity) as decimal(16,2)) as iquantity 
	,cast(sum(b.iNatSum) as decimal(16,2))  as momey
	,cast(case when isnull(sum(b.iQuantity),0) <> 0 then sum(b.iNatSum) / sum(b.iQuantity) end as decimal(16,2)) AS iPrice
from   ufdata_101_2013..DispatchList a inner join ufdata_101_2013..DispatchLists  b on a.DLID = b.DLID
inner join ufdata_101_2013..inventory c on b.cInvCode  = c.cInvCode 
inner join ufdata_101_2013..InventoryClass d on substring(c.cInvCCode,1,3) = d.cInvCCode
inner join ufdata_101_2013..InventoryClass e on c.cInvCCode = e.cInvCCode
inner join ufdata_101_2013..Customer cus on cus.cCusCode = a.cCusCode
inner join ufdata_101_2013..Department  f on cus.cCusDepart  = f.cDepCode 
--inner join ufdata_101_2013..Department  f on a.cDepCode  = f.cDepCode 
where  f.cDepMemo is not null and f.cDepMemo = '山东'
	and a.dDate >= '2017-03-01' and a.dDate < '2017-03-08'
group by   d.cInvCName,f.cDepMemo,b.cInvCode,c.cInvName,c.cInvStd,e.cInvCName


-- 四川
INSERT INTO #_TH_REP_SUM(cInvCName,cInvCName2,cInvCode,cInvName,cInvStd,iQtySC,iMomeySC,iPriceSC)
select  d.cInvCName,e.cInvCName as cInvCName2,b.cInvCode,c.cInvName,c.cInvStd
	,cast(sum(b.iQuantity) as decimal(16,2)) as iquantity 
	,cast(sum(b.iNatSum) as decimal(16,2))  as momey
	,cast(case when isnull(sum(b.iQuantity),0) <> 0 then sum(b.iNatSum) / sum(b.iQuantity) end as decimal(16,2)) AS iPrice
from   ufdata_101_2013..DispatchList a inner join ufdata_101_2013..DispatchLists  b on a.DLID = b.DLID
inner join ufdata_101_2013..inventory c on b.cInvCode  = c.cInvCode 
inner join ufdata_101_2013..InventoryClass d on substring(c.cInvCCode,1,3) = d.cInvCCode
inner join ufdata_101_2013..InventoryClass e on c.cInvCCode = e.cInvCCode
inner join ufdata_101_2013..Customer cus on cus.cCusCode = a.cCusCode
inner join ufdata_101_2013..Department  f on cus.cCusDepart  = f.cDepCode 

--inner join ufdata_101_2013..Department  f on a.cDepCode  = f.cDepCode 
where  f.cDepMemo is not null and f.cDepMemo = '四川'
	and a.dDate >= '2017-03-01' and a.dDate < '2017-03-08'
group by   d.cInvCName,f.cDepMemo,b.cInvCode,c.cInvName,c.cInvStd,e.cInvCName


-- 海外
INSERT INTO #_TH_REP_SUM(cInvCName,cInvCName2,cInvCode,cInvName,cInvStd,iQtyHW,iMomeyHW,iPriceHW)
select  d.cInvCName,e.cInvCName as cInvCName2,b.cInvCode,c.cInvName,c.cInvStd
	,cast(sum(b.iQuantity) as decimal(16,2)) as iquantity 
	,cast(sum(b.iNatSum) as decimal(16,2))  as momey
	,cast(case when isnull(sum(b.iQuantity),0) <> 0 then sum(b.iNatSum) / sum(b.iQuantity) end as decimal(16,2)) AS iPrice
from   ufdata_101_2013..DispatchList a inner join ufdata_101_2013..DispatchLists  b on a.DLID = b.DLID
inner join ufdata_101_2013..inventory c on b.cInvCode  = c.cInvCode 
inner join ufdata_101_2013..InventoryClass d on substring(c.cInvCCode,1,3) = d.cInvCCode
inner join ufdata_101_2013..InventoryClass e on c.cInvCCode = e.cInvCCode
inner join ufdata_101_2013..Customer cus on cus.cCusCode = a.cCusCode
inner join ufdata_101_2013..Department  f on cus.cCusDepart  = f.cDepCode 
--inner join ufdata_101_2013..Department  f on a.cDepCode  = f.cDepCode 
where  f.cDepMemo is not null and f.cDepMemo = '海外'
	and a.dDate >= '2017-03-01' and a.dDate < '2017-03-08'
group by   d.cInvCName,f.cDepMemo,b.cInvCode,c.cInvName,c.cInvStd,e.cInvCName

-- 水性印花
INSERT INTO #_TH_REP_SUM(cInvCName,cInvCName2,cInvCode,cInvName,cInvStd,iQtySXYH,iMoneySXYH,iPriceSXYH)
select  d.cInvCName,e.cInvCName as cInvCName2,b.cInvCode,c.cInvName,c.cInvStd
	,cast(sum(b.iQuantity) as decimal(16,2)) as iquantity 
	,cast(sum(b.iNatSum) as decimal(16,2))  as momey
	,cast(case when isnull(sum(b.iQuantity),0) <> 0 then sum(b.iNatSum) / sum(b.iQuantity) end as decimal(16,2)) AS iPrice
from   ufdata_101_2013..DispatchList a inner join ufdata_101_2013..DispatchLists  b on a.DLID = b.DLID
inner join ufdata_101_2013..inventory c on b.cInvCode  = c.cInvCode 
inner join ufdata_101_2013..InventoryClass d on substring(c.cInvCCode,1,3) = d.cInvCCode
inner join ufdata_101_2013..InventoryClass e on c.cInvCCode = e.cInvCCode
inner join ufdata_101_2013..Customer cus on cus.cCusCode = a.cCusCode
inner join ufdata_101_2013..Department  f on cus.cCusDepart  = f.cDepCode 
--inner join ufdata_101_2013..Department  f on a.cDepCode  = f.cDepCode 
where  f.cDepMemo is not null and f.cDepMemo like '%水性印花%'
	and a.dDate >= '2017-03-01' and a.dDate < '2017-03-08'
group by   d.cInvCName,f.cDepMemo,b.cInvCode,c.cInvName,c.cInvStd,e.cInvCName


-- 深圳销售部
INSERT INTO #_TH_REP_SUM(cInvCName,cInvCName2,cInvCode,cInvName,cInvStd,iQtySZ,iMomeySZ,iPriceSZ)
select  d.cInvCName,e.cInvCName as cInvCName2,b.cInvCode,c.cInvName,c.cInvStd
	,cast(sum(b.iQuantity) as decimal(16,2)) as iquantity 
	,cast(sum(b.iNatSum) as decimal(16,2))  as momey
	,cast(case when isnull(sum(b.iQuantity),0) <> 0 then sum(b.iNatSum) / sum(b.iQuantity) end as decimal(16,2)) AS iPrice
from   ufdata_201_2014..DispatchList a inner join ufdata_201_2014..DispatchLists  b on a.DLID = b.DLID
inner join ufdata_201_2014..inventory c on b.cInvCode  = c.cInvCode 
inner join ufdata_201_2014..InventoryClass d on substring(c.cInvCCode,1,3) = d.cInvCCode
inner join ufdata_201_2014..InventoryClass e on c.cInvCCode = e.cInvCCode
--inner join ufdata_201_2014..Customer cus on cus.cCusCode = a.cCusCode
--inner join ufdata_201_2014..Department  f on cus.cCusDepart  = f.cDepCode 
inner join ufdata_201_2014..Department  f on a.cDepCode  = f.cDepCode 
where  f.cDepMemo is not null and f.cDepMemo = '深圳销售部'
	and a.dDate >= '2017-03-01' and a.dDate < '2017-03-08'
group by   d.cInvCName,f.cDepMemo,b.cInvCode,c.cInvName,c.cInvStd,e.cInvCName




-- 潮州
INSERT INTO #_TH_REP_SUM(cInvCName,cInvCName2,cInvCode,cInvName,cInvStd,iQtyCZ,iMomeyCZ,iPriceCZ)
select  d.cInvCName,e.cInvCName as cInvCName2,b.cInvCode,c.cInvName,c.cInvStd
	,cast(sum(b.iQuantity) as decimal(16,2)) as iquantity 
	,cast(sum(b.iNatSum) as decimal(16,2))  as momey
	,cast(case when isnull(sum(b.iQuantity),0) <> 0 then sum(b.iNatSum) / sum(b.iQuantity) end as decimal(16,2)) AS iPrice
from   ufdata_104_2014..DispatchList a inner join ufdata_104_2014..DispatchLists  b on a.DLID = b.DLID
inner join ufdata_104_2014..inventory c on b.cInvCode  = c.cInvCode 
inner join ufdata_104_2014..InventoryClass d on substring(c.cInvCCode,1,3) = d.cInvCCode
inner join ufdata_104_2014..InventoryClass e on c.cInvCCode = e.cInvCCode
--inner join ufdata_104_2014..Customer cus on cus.cCusCode = a.cCusCode
--inner join ufdata_104_2014..Department  f on cus.cCusDepart  = f.cDepCode
inner join ufdata_104_2014..Department  f on a.cDepCode  = f.cDepCode  
where  f.cDepMemo is not null and f.cDepMemo = '潮州销售部'
	and a.dDate >= '2017-03-01' and a.dDate < '2017-03-08'
group by   d.cInvCName,f.cDepMemo,b.cInvCode,c.cInvName,c.cInvStd,e.cInvCName



-- 厦门销售部
INSERT INTO #_TH_REP_SUM(cInvCName,cInvCName2,cInvCode,cInvName,cInvStd,iQtyXM,iMomeyXM,iPriceXM)
select  d.cInvCName,e.cInvCName as cInvCName2,b.cInvCode,c.cInvName,c.cInvStd
	,cast(sum(b.iQuantity) as decimal(16,2)) as iquantity 
	,cast(sum(b.iNatSum) as decimal(16,2))  as momey
	,cast(case when isnull(sum(b.iQuantity),0) <> 0 then sum(b.iNatSum) / sum(b.iQuantity) end as decimal(16,2)) AS iPrice
from   ufdata_102_2014..DispatchList a inner join ufdata_102_2014..DispatchLists  b on a.DLID = b.DLID
inner join ufdata_102_2014..inventory c on b.cInvCode  = c.cInvCode 
inner join ufdata_102_2014..InventoryClass d on substring(c.cInvCCode,1,3) = d.cInvCCode
inner join ufdata_102_2014..InventoryClass e on c.cInvCCode = e.cInvCCode
--inner join ufdata_102_2014..Customer cus on cus.cCusCode = a.cCusCode
--inner join ufdata_102_2014..Department  f on cus.cCusDepart  = f.cDepCode 
inner join ufdata_102_2014..Department  f on a.cDepCode  = f.cDepCode  
where  f.cDepMemo is not null and f.cDepMemo = '厦门销售部'
	and a.dDate >= '2017-03-01' and a.dDate < '2017-03-08'
group by   d.cInvCName,f.cDepMemo,b.cInvCode,c.cInvName,c.cInvStd,e.cInvCName


-- 大连销售部
INSERT INTO #_TH_REP_SUM(cInvCName,cInvCName2,cInvCode,cInvName,cInvStd,iQtyDL,iMomeyDL,iPriceDL)
select  d.cInvCName,e.cInvCName as cInvCName2,b.cInvCode,c.cInvName,c.cInvStd
	,cast(sum(b.iQuantity) as decimal(16,2)) as iquantity 
	,cast(sum(b.iNatSum) as decimal(16,2))  as momey
	,cast(case when isnull(sum(b.iQuantity),0) <> 0 then sum(b.iNatSum) / sum(b.iQuantity) end as decimal(16,2)) AS iPrice
from   ufdata_103_2014..DispatchList a inner join ufdata_103_2014..DispatchLists  b on a.DLID = b.DLID
inner join ufdata_103_2014..inventory c on b.cInvCode  = c.cInvCode 
inner join ufdata_103_2014..InventoryClass d on substring(c.cInvCCode,1,3) = d.cInvCCode
inner join ufdata_103_2014..InventoryClass e on c.cInvCCode = e.cInvCCode
--inner join ufdata_103_2014..Customer cus on cus.cCusCode = a.cCusCode
--inner join ufdata_103_2014..Department  f on cus.cCusDepart  = f.cDepCode 
inner join ufdata_103_2014..Department  f on a.cDepCode  = f.cDepCode 
where  f.cDepMemo is not null and f.cDepMemo = '大连销售部'
	and a.dDate >= '2017-03-01' and a.dDate < '2017-03-08'
group by   d.cInvCName,f.cDepMemo,b.cInvCode,c.cInvName,c.cInvStd,e.cInvCName

SELECT  
	cInvCName
	
	,sum(iQtyBJ) as iQtyBJ			--	数量
	,sum(iMomeyBJ) as iMomeyBJ 		--	金额
	,case when sum(iQtyBJ) <> 0 then cast(sum(iMomeyBJ) / sum(iQtyBJ) as decimal(16,2)) else null end as iPriceBJ 		--	单价

	,sum(iQtyKS) as iQtyKS
	,sum(iMomeyKS) as iMomeyKS
	,case when sum(iQtyKS) <> 0 then cast(sum(iMomeyKS) / sum(iQtyKS) as decimal(16,2)) else null end  as iPriceKS

	,sum(iQtySD) as iQtySD
	,sum(iMomeySD) as iMomeySD
	,case when sum(iQtySD) <> 0 then cast(sum(iMomeySD) / sum(iQtySD) as decimal(16,2)) else null end  as iPriceSD

	,sum(iQtySC) as iQtySC
	,sum(iMomeySC) as iMomeySC
	,case when sum(iQtySC) <> 0 then cast(sum(iMomeySC) / sum(iQtySC) as decimal(16,2)) else null end  as iPriceSC

	,sum(iQtyHW) as iQtyHW
	,sum(iMomeyHW) as iMomeyHW
	,case when sum(iQtyHW) <> 0 then cast(sum(iMomeyHW) / sum(iQtyHW) as decimal(16,2)) else null end  as iPriceHW

	,sum(iQtySXYH) as iQtySXYH
	,sum(iMoneySXYH) as iMoneySXYH
	,case when sum(iQtySXYH) <> 0 then cast(sum(iMoneySXYH) / sum(iQtySXYH) as decimal(16,2)) else null end as iPriceSXYH

	,sum(iQtySZ) as iQtySZ
	,sum(iMomeySZ) as iMomeySZ
	,case when sum(iQtySZ) <> 0 then cast(sum(iMomeySZ) / sum(iQtySZ) as decimal(16,2)) else null end  as iPriceSZ

	,sum(iQtyCZ) as iQtyCZ
	,sum(iMomeyCZ) as iMomeyCZ
	,case when sum(iQtyCZ) <> 0 then cast(sum(iMomeyCZ) / sum(iQtyCZ) as decimal(16,2)) else null end  as iPriceCZ

	,sum(iQtyXM) as iQtyXM
	,sum(iMomeyXM) as iMomeyXM
	,case when sum(iQtyXM) <> 0 then cast(sum(iMomeyXM) / sum(iQtyXM) as decimal(16,2)) else null end  as iPriceXM

	,sum(iQtyDL) as iQtyDL
	,sum(iMomeyDL) as iMomeyDL
	,case when sum(iQtyDL) <> 0 then cast(sum(iMomeyDL) / sum(iQtyDL) as decimal(16,2)) else null end  as iPriceDL


	,sum(isnull(iQtyBJ,0)) + sum(isnull(iQtyKS,0)) + sum(isnull(iQtySD,0)) + sum(isnull(iQtySC,0)) + sum(isnull(iQtyHW,0)) + sum(isnull(iQtySXYH,0))
	 + sum(isnull(iQtySZ,0)) + sum(isnull(iQtyCZ,0)) + sum(isnull(iQtyXM,0)) + sum(isnull(iQtyDL,0)) as iQtySum

	,sum(isnull(iMomeyBJ,0))+sum(isnull(iMomeyKS,0))+sum(isnull(iMomeySD,0))+sum(isnull(iMomeySC,0))+sum(isnull(iMomeyHW,0))+sum(isnull(iMoneySXYH,0))
	+sum(isnull(iMomeySZ,0))+sum(isnull(iMomeyCZ,0))+sum(isnull(iMomeyXM,0))+sum(isnull(iMomeyDL,0)) as iMoneySum

	,case WHEN (sum(isnull(iQtyBJ,0)) + sum(isnull(iQtyKS,0)) + sum(isnull(iQtySD,0)) + sum(isnull(iQtySC,0)) + sum(isnull(iQtyHW,0))+sum(isnull(iQtySXYH,0))
	 + sum(isnull(iQtySZ,0)) + sum(isnull(iQtyCZ,0)) + sum(isnull(iQtyXM,0)) + sum(isnull(iQtyDL,0))) <> 0
	 then
	cast( ((sum(isnull(iMomeyBJ,0))+sum(isnull(iMomeyKS,0))+sum(isnull(iMomeySD,0))+sum(isnull(iMomeySC,0))+sum(isnull(iMomeyHW,0))+sum(isnull(iMoneySXYH,0))
	+sum(isnull(iMomeySZ,0))+sum(isnull(iMomeyCZ,0))+sum(isnull(iMomeyXM,0))+sum(isnull(iMomeyDL,0)))) / 
	(sum(isnull(iQtyBJ,0)) + sum(isnull(iQtyKS,0)) + sum(isnull(iQtySD,0)) + sum(isnull(iQtySC,0)) + sum(isnull(iQtyHW,0))+sum(isnull(iQtySXYH,0))
	 + sum(isnull(iQtySZ,0)) + sum(isnull(iQtyCZ,0)) + sum(isnull(iQtyXM,0)) + sum(isnull(iQtyDL,0))) as decimal(16,2))
	else null end as iPriceSum
FROM #_TH_REP_SUM a
	left join Inventory i on a.cInvCode = i.cInvCode
where a.cInvCName <> '网纱'
group by a.cInvCName

union all

select cInvCName
	,SUM(iQtyBJ) as iQtyBJ,SUM(iMomeyBJ) as iMomeyBJ,cast (case when SUM(isnull(iQtyBJ,0)) <> 0 then SUM(iMomeyBJ) / SUM(iQtyBJ) end as decimal(16,2)) as iPriceBJ
	,SUM(iQtyKS) as iQtyKS,SUM(iMomeyKS) as iMomeyKS,cast (case when SUM(isnull(iQtyKS,0)) <> 0 then SUM(iMomeyKS) / SUM(iQtyKS) end as decimal(16,2)) as iPriceKS
	,SUM(iQtySD) as iQtySD,SUM(iMomeySD) as iMomeySD,cast (case when SUM(isnull(iQtySD,0)) <> 0 then SUM(iMomeySD) / SUM(iQtySD) end as decimal(16,2)) as iPriceSD
	,SUM(iQtySC) as iQtySC,SUM(iMomeySC) as iMomeySC,cast (case when SUM(isnull(iQtySC,0)) <> 0 then SUM(iMomeySC) / SUM(iQtySC) end as decimal(16,2)) as iPriceSC
	,SUM(iQtyHW) as iQtyHW,SUM(iMomeyHW) as iMomeyHW,cast (case when SUM(isnull(iQtyHW,0)) <> 0 then SUM(iMomeyHW) / SUM(iQtyHW) end as decimal(16,2)) as iPriceHW
	,SUM(iQtySXYH) as iQtySXYH,SUM(iMoneySXYH) as iMoneySXYH,cast (case when SUM(isnull(iQtySXYH,0)) <> 0 then SUM(iMoneySXYH) / SUM(iQtySXYH) end as decimal(16,2)) as iPriceSXYH
	,SUM(iQtySZ) as iQtySZ,SUM(iMomeySZ) as iMomeySZ,cast (case when SUM(isnull(iQtySZ,0)) <> 0 then SUM(iMomeySZ) / SUM(iQtySZ) end as decimal(16,2)) as iPriceSZ
	,SUM(iQtyCZ) as iQtyCZ,SUM(iMomeyCZ) as iMomeyCZ,cast (case when SUM(isnull(iQtyCZ,0)) <> 0 then SUM(iMomeyCZ) / SUM(iQtyCZ) end as decimal(16,2)) as iPriceCZ
	,SUM(iQtyXM) as iQtyXM,SUM(iMomeyXM) as iMomeyXM,cast (case when SUM(isnull(iQtyXM,0)) <> 0 then SUM(iMomeyXM) / SUM(iQtyXM) end as decimal(16,2)) as iPriceXM
	,SUM(iQtyDL) as iQtyDL,SUM(iMomeyDL) as iMomeyDL,cast (case when SUM(isnull(iQtyDL,0)) <> 0 then SUM(iMomeyDL) / SUM(iQtyDL) end as decimal(16,2)) as iPriceDL
	
	,sum(isnull(iQtyBJ,0)) + sum(isnull(iQtyKS,0)) + sum(isnull(iQtySD,0)) + sum(isnull(iQtySC,0)) + sum(isnull(iQtyHW,0)) + sum(isnull(iQtySXYH,0)) 
	 + sum(isnull(iQtySZ,0)) + sum(isnull(iQtyCZ,0)) + sum(isnull(iQtyXM,0)) + sum(isnull(iQtyDL,0)) as iQtySum
	
	,sum(isnull(iMomeyBJ,0))+sum(isnull(iMomeyKS,0))+sum(isnull(iMomeySD,0))+sum(isnull(iMomeySC,0))+sum(isnull(iMomeyHW,0)) +sum(isnull(iMoneySXYH,0)) 
	+sum(isnull(iMomeySZ,0))+sum(isnull(iMomeyCZ,0))+sum(isnull(iMomeyXM,0))+sum(isnull(iMomeyDL,0)) as iMoneySum
	
	,case WHEN (sum(isnull(iQtyBJ,0)) + sum(isnull(iQtyKS,0)) + sum(isnull(iQtySD,0)) + sum(isnull(iQtySC,0)) + sum(isnull(iQtyHW,0))+ sum(isnull(iQtySXYH,0)) 
	 + sum(isnull(iQtySZ,0)) + sum(isnull(iQtyCZ,0)) + sum(isnull(iQtyXM,0)) + sum(isnull(iQtyDL,0))) <> 0
	 then
	cast( ((sum(isnull(iMomeyBJ,0))+sum(isnull(iMomeyKS,0))+sum(isnull(iMomeySD,0))+sum(isnull(iMomeySC,0))+sum(isnull(iMomeyHW,0))+sum(isnull(iMoneySXYH,0)) 
	+sum(isnull(iMomeySZ,0))+sum(isnull(iMomeyCZ,0))+sum(isnull(iMomeyXM,0))+sum(isnull(iMomeyDL,0)))) / 
	(sum(isnull(iQtyBJ,0)) + sum(isnull(iQtyKS,0)) + sum(isnull(iQtySD,0)) + sum(isnull(iQtySC,0)) + sum(isnull(iQtyHW,0))+ sum(isnull(iQtySXYH,0)) 
	 + sum(isnull(iQtySZ,0)) + sum(isnull(iQtyCZ,0)) + sum(isnull(iQtyXM,0)) + sum(isnull(iQtyDL,0))) as decimal(16,2))
	else null end as iPriceSum
from
(
SELECT  
	case when substring(i.cInvCCode,1,3) = '908' then 
		case when substring(i.cInvCCode,1,5) = '90801' then 'FEC网纱' else '丝马特网纱' end
	else a.cInvCName end as cInvCName
	
	,sum(iQtyBJ) as iQtyBJ			--	数量
	,sum(iMomeyBJ) as iMomeyBJ 		--	金额

	,sum(iQtyKS) as iQtyKS
	,sum(iMomeyKS) as iMomeyKS

	,sum(iQtySD) as iQtySD
	,sum(iMomeySD) as iMomeySD

	,sum(iQtySC) as iQtySC
	,sum(iMomeySC) as iMomeySC

	,sum(iQtyHW) as iQtyHW
	,sum(iMomeyHW) as iMomeyHW

	,sum(iQtySXYH) as iQtySXYH
	,sum(iMoneySXYH) as iMoneySXYH

	,sum(iQtySZ) as iQtySZ
	,sum(iMomeySZ) as iMomeySZ

	,sum(iQtyCZ) as iQtyCZ
	,sum(iMomeyCZ) as iMomeyCZ

	,sum(iQtyXM) as iQtyXM
	,sum(iMomeyXM) as iMomeyXM

	,sum(iQtyDL) as iQtyDL
	,sum(iMomeyDL) as iMomeyDL
	
FROM #_TH_REP_SUM a
	left join Inventory i on a.cInvCode = i.cInvCode
where a.cInvCName = '网纱'
group by a.cInvCName,i.cInvCCode
)a
group by a.cInvCName


";
                sSQL = sSQL.Replace("2017-03-01",sDate1);
                sSQL = sSQL.Replace("2017-03-08", sDate2);

                SqlConnection conn = new SqlConnection(Conn);
                DataTable dt = SqlHelper.ExecuteDataset(conn, CommandType.Text, sSQL).Tables[0];
                gridControl1.DataSource = dt;
                gridView1.BestFitColumns();
            }
            catch (Exception ee)
            {
                MessageBox.Show("查询失败:" + ee.Message);
            }
        }
    }
}