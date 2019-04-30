using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using TH.BaseClass;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class 成本分配表 : UserControl
    {
        TH.BaseClass.GetBaseData getBaseData = new GetBaseData();
        
        string sProPath = Application.StartupPath;

        UFIDA.U8.UAP.CustomApp.ControlForm.RepBaseGrid Rep = new RepBaseGrid();

        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                GetLookUp();
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "加载窗体失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        public 成本分配表()
        {
            InitializeComponent();
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
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "导出Excel失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        private void GetLookUp()
        {
            string sSQL = "select distinct 会计期间 from  _ProMaterial order by 会计期间";
            DataTable dt = DbHelperSQL.Query(sSQL);
            
            lookUpEdit会计期间.Properties.DataSource = dt;
            if (dt != null && dt.Rows.Count > 0)
            {
                lookUpEdit会计期间.EditValue = dt.Rows[dt.Rows.Count - 1]["会计期间"];
            }

            sSQL = @"
select cInvCode,cInvName,cInvStd,cInvAddCode, a.cComUnitCode ,b.cComUnitName
from Inventory a inner join ComputationUnit b on a.cComUnitCode = b.cComunitCode
order by a.cInvCode
";
            dt = DbHelperSQL.Query(sSQL);
            ItemLookUpEditcInvCode.DataSource = dt;
            ItemLookUpEditcInvName.DataSource = dt;
            ItemLookUpEditcInvStd.DataSource = dt;
            ItemLookUpEditcComUnitName.DataSource = dt;

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


        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                //lookUpEditcDepCode.EditValue = DBNull.Value;
                //lookUpEditcDepName.EditValue = DBNull.Value;
            }
            catch (Exception ee)
            {
                MessageBox.Show("清空失败：" + ee.Message);
            }
        }

        private void GetGrid()
        {
            string sSQL = @"
select * from 
(
select a.id,b.autoid, a.cCode,a.dDate,a.cRdCode  ,b.cInvCode,c.cInvName,c.cInvStd,b.iQuantity,b.iUnitCost ,b.iPrice ,'产成品入库' as RdType,a.cDepCode,d.cDepName,null as 计算时间,null as 产品总数
from Rdrecord10 a inner join Rdrecords10 b on a.id = b.id
	inner join Inventory c on b.cInvCode = c.cInvCode
    inner join Department d on a.cDepCode = d.cDepCode
where a.cWhCode in (select sType from _CostType where iType = 4)
	and a.cRdCode in (select sType from _CostType where iType = 3)
    and a.dDAte >= '111111' and a.dDate < '222222'
    and isnull(b.iQuantity,0) > 0
union All
select a.id,b.autoid,a.cCode,a.dDate,a.cRdCode  ,b.cInvCode,c.cInvName,c.cInvStd,b.iQuantity,b.iUnitCost ,b.iPrice ,'其他入库' as RdType,a.cDepCode,d.cDepName,null as 计算时间,null as 产品总数
from Rdrecord08 a inner join Rdrecords08 b on a.id = b.id
	inner join Inventory c on b.cInvCode = c.cInvCode
    inner join Department d on a.cDepCode = d.cDepCode
where a.cWhCode in (select sType from _CostType where iType = 4)
	and a.cRdCode in (select sType from _CostType where iType = 3)
    and a.dDAte >= '111111' and a.dDate < '222222'
    and isnull(b.iQuantity,0) > 0
)a
order by a.cDepCode,a.dDate,a.autoid
";
            sSQL = sSQL.Replace("111111", lookUpEdit会计期间.EditValue.ToString() + "-01");
            sSQL = sSQL.Replace("222222", BaseFunction.ReturnDate(lookUpEdit会计期间.EditValue.ToString() + "-01").AddMonths(1).ToString("yyyy-MM-dd"));


            DataTable dt = DbHelperSQL.Query(sSQL);
            gridControl1.DataSource = dt;
        }
     

        private void btnSEL_Click(object sender, EventArgs e)
        {
            try
            {
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载数据失败：" + ee.Message);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
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
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "导出Excel失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        private void btn计算_Click(object sender, EventArgs e)
        {
            try
            {

                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                string sSQL = @"
select count(*) as iCou from 
(
select a.cHandler ,b.cbaccounter ,a.cCode
from Rdrecord10 a inner join Rdrecords10 b on a.id = b.id
	inner join Inventory c on b.cInvCode = c.cInvCode
    inner join Department d on a.cDepCode = d.cDepCode
where a.cWhCode in (select sType from _CostType where iType = 4)
	and a.cRdCode in (select sType from _CostType where iType = 3)
    and a.dDAte >= '111111' and a.dDate < '222222'
    and isnull(b.iQuantity,0) > 0
union All
select a.cHandler ,b.cbaccounter ,a.cCode
from Rdrecord08 a inner join Rdrecords08 b on a.id = b.id
	inner join Inventory c on b.cInvCode = c.cInvCode
    inner join Department d on a.cDepCode = d.cDepCode
where a.cWhCode in (select sType from _CostType where iType = 4)
	and a.cRdCode in (select sType from _CostType where iType = 3)
    and a.dDAte >= '111111' and a.dDate < '222222'
    and isnull(b.iQuantity,0) > 0
)a
where isnull(a.cHandler,'')  = '' or ISNULL(a.cbaccounter,'') <> ''
";
                sSQL = sSQL.Replace("111111", lookUpEdit会计期间.EditValue.ToString() + "-01");
                sSQL = sSQL.Replace("222222", BaseFunction.ReturnDate(lookUpEdit会计期间.EditValue.ToString() + "-01").AddMonths(1).ToString("yyyy-MM-dd"));


                long lCou = BaseFunction.ReturnLong(DbHelperSQL.GetSingle(sSQL));
                if (lCou > 0)
                {
                    throw new Exception("存在未审核或者已记账单据");
                }

                int iCou = 0;
                SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    string s会计期间 = lookUpEdit会计期间.EditValue.ToString().Trim();
                    string s计算时间 = DateTime.Now.ToString("yyMMddhhmmss");

                    sSQL = "select count(1) from _ProMaterial where 会计期间 = '" + s会计期间 + "' and isnull(审核人,'') = ''";
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt != null && BaseFunction.ReturnInt( dt.Rows[0][0]) > 0)
                    {
                        throw new Exception("存在尚未审核的车间材料领用汇总月报");
                    }

                    sSQL = @"

set nocount on

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_Temp部门产品金额]') AND type in (N'U'))
    DROP TABLE [dbo].[_Temp部门产品金额]

select sum(金额) as 金额,部门,产品编码,cast(null as decimal(16,6)) as 数量,cast(null as decimal(16,6)) as 单价
    ,cast(null as decimal(16,6)) as 本部门金额占比,cast(null as decimal(16,6)) as 本部门数量占比
into _Temp部门产品金额
from dbo._ProMaterial
where 会计期间 = '333333'
group by 部门,产品编码

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_Temp产品入库信息]') AND type in (N'U'))
    DROP TABLE [dbo].[_Temp产品入库信息]

select * 
into _Temp产品入库信息
from 
(
select a.id,b.autoid, a.cCode,a.dDate,a.cRdCode  ,b.cInvCode,c.cInvName,c.cInvStd,b.iQuantity,b.iUnitCost ,b.iPrice ,'产成品入库' as RdType,a.cDepCode,d.cDepName,null as 计算时间,null as 产品总数
     ,cast(null as decimal(16,6)) as 材料单价,cast(null as decimal(16,6)) as 料 ,cast(null as decimal(16,6)) as 工 ,cast(null as decimal(16,6)) as 费
     ,cast(null as decimal(16,6)) as 待分配金额,cast(null as decimal(16,6)) as 分配比例
     ,cast(null as decimal(16,6)) as 部门材料总金额
from Rdrecord10 a inner join Rdrecords10 b on a.id = b.id
	inner join Inventory c on b.cInvCode = c.cInvCode
    inner join Department d on a.cDepCode = d.cDepCode
where a.cWhCode in (select sType from _CostType where iType = 4)
	and a.cRdCode in (select sType from _CostType where iType = 3)
    and a.dDAte >= '111111' and a.dDate < '222222'
    and isnull(b.iQuantity,0) > 0
union All
select a.id,b.autoid,a.cCode,a.dDate,a.cRdCode  ,b.cInvCode,c.cInvName,c.cInvStd,b.iQuantity,b.iUnitCost ,b.iPrice ,'其他入库' as RdType,a.cDepCode,d.cDepName,null as 计算时间,null as 产品总数
     ,cast(null as decimal(16,6)) as 材料单价,cast(null as decimal(16,6)) as 料 ,cast(null as decimal(16,6)) as 工 ,cast(null as decimal(16,6)) as 费
     ,cast(null as decimal(16,6)) as 待分配金额,cast(null as decimal(16,6)) as 分配比例
     ,cast(null as decimal(16,6)) as 部门材料总金额
from Rdrecord08 a inner join Rdrecords08 b on a.id = b.id
	inner join Inventory c on b.cInvCode = c.cInvCode
    inner join Department d on a.cDepCode = d.cDepCode
where a.cWhCode in (select sType from _CostType where iType = 4)
	and a.cRdCode in (select sType from _CostType where iType = 3)
    and a.dDAte >= '111111' and a.dDate < '222222'
    and isnull(b.iQuantity,0) > 0
)a

update _Temp产品入库信息 set iPrice = null,iUnitCost = null 

update _Temp部门产品金额 set 数量 = b.iQty
from 
(
    select cInvCode,cDepCode,sum(iQuantity) as iQty from _Temp产品入库信息 group by cInvCode,cDepCode
)b 
where b.cDepCode = _Temp部门产品金额.部门 and b.cInvCode = _Temp部门产品金额.产品编码

update _Temp部门产品金额 set 单价 = case when 数量 = 0 then 0 else cast(金额 / 数量 as decimal(16,6)) end

-- 设置单据材料单价，材料金额
update _Temp产品入库信息 set 材料单价 = b.单价
from _Temp部门产品金额 b 
where b.部门 = _Temp产品入库信息.cDepCode  and b.产品编码 = _Temp产品入库信息.cInvCode

update _Temp产品入库信息 set 料 = 材料单价 * iQuantity
from _Temp部门产品金额 b 
where b.部门 = _Temp产品入库信息.cDepCode  and b.产品编码 = _Temp产品入库信息.cInvCode

--select * from _Temp产品入库信息 order by AutoID

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_Temp待分摊金额]') AND type in (N'U'))
DROP TABLE [dbo].[_Temp待分摊金额]

CREATE TABLE [dbo].[_Temp待分摊金额](
	[会计期间] [varchar](50) NOT NULL,
	[部门] [varchar](50) NOT NULL,
	[待分摊金额] [decimal](18, 6) NULL,
 CONSTRAINT [PK___Temp待分摊金额] PRIMARY KEY CLUSTERED 
(
	[会计期间] ASC,
	[部门] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

insert into [_Temp待分摊金额]([会计期间],[部门])
select '333333',cDepCode
from Department 
where cDepProp = '成本' and bDepEnd = 1 


-- 设置部门分摊
	update [_Temp待分摊金额] set 待分摊金额 = ISNULL(待分摊金额,0) +  isnull(b.金额,0)
	from 
	(
		select SUM(金额) as 金额,会计期间,部门 from dbo._部门费用登记 where 会计期间 = '333333' group by 会计期间,部门
	)b 
	where b.会计期间 = [_Temp待分摊金额].会计期间 and b.部门 = [_Temp待分摊金额].部门

 --设置公共分摊
	declare @s公共分摊类型 varchar(50)
	DECLARE curList CURSOR
	for
	select sType from dbo._CostType where iType = 1 order by sType
		
	OPEN curList
	fetch next from curList into @s公共分摊类型
	while @@FETCH_STATUS = 0
	BEGIN

		declare @d公共分摊金额 decimal(16,6)
		select @d公共分摊金额 = 金额 from dbo._共耗费用登记 where 费用类型 = @s公共分摊类型 and 会计期间 = '333333'
		
		update [_Temp待分摊金额] set 待分摊金额 = ISNULL(待分摊金额,0) +  isnull(b.金额,0)
		from
		(
			select sum(a.金额 * b.dPercentage / 100) as 金额,b.cDepCode,a.会计期间 
			from _共耗费用登记 a left join _AlocationProportion b on  a.费用类型 = b.CostType
			where a.费用类型 = @s公共分摊类型 
			group by b.cDepCode,a.会计期间
		)b 
		where [_Temp待分摊金额].会计期间 = b.会计期间 and [_Temp待分摊金额].部门 = b.cDepCode
			
		fetch next from curList into @s公共分摊类型
	END
	close curList
    deallocate  curList
    
update _Temp产品入库信息 set 待分配金额 = b.待分摊金额
from [_Temp待分摊金额] b 
where b.会计期间 = '333333' and b.部门 = _Temp产品入库信息.cDepCode

update _Temp产品入库信息 set 部门材料总金额 = b.材料费
from
(
	select SUM(料) as 材料费,cDepCode from _Temp产品入库信息 group by cDepCode
)b 
where b.cDepCode = _Temp产品入库信息.cDepCode

update _Temp产品入库信息 set 分配比例 = case when ISNULL(部门材料总金额,0) = 0 then 0 else CAST(料 / 部门材料总金额 as decimal(16,6)) end

update _Temp产品入库信息 set iPrice = ISNULL(料,0) + ISNULL(部门材料总金额,0) * ISNULL(分配比例,0)

update _Temp产品入库信息 set iUnitCost = case when isnull(iQuantity,0) = 0 then 0 else cast(iPrice / iQuantity as decimal(16,6)) end

select * from _Temp产品入库信息 order by cDepCode,dDate,autoid

";
                    sSQL = sSQL.Replace("333333", s会计期间);
                    sSQL = sSQL.Replace("111111", lookUpEdit会计期间.EditValue.ToString() + "-01");
                    sSQL = sSQL.Replace("222222", BaseFunction.ReturnDate(lookUpEdit会计期间.EditValue.ToString() + "-01").AddMonths(1).ToString("yyyy-MM-dd"));
                    DataTable dtGrid = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    gridControl1.DataSource = dtGrid;

                    //for (int i = 0; i < dtGrid.Rows.Count; i++)
                    //{
                    //    string sDepCode = dtGrid.Rows[i]["cDepCode"].ToString().Trim();
                    //    string sInvCode = dtGrid.Rows[i]["cInvCode"].ToString().Trim();
                    //    string s计算时间2 = dtGrid.Rows[i]["计算时间"].ToString().Trim();
                    //    if(s计算时间 == s计算时间2)
                    //    {
                    //        continue;
                    //    }

                    //    decimal d材料总金额 = 0;
                    //    sSQL = "select sum(金额) as 金额 from _ProMaterial where 产品编码 = '" + sInvCode + "' and 会计期间 = '" + s会计期间 + "' and 部门 = '" + sDepCode + "'";
                    //    dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    //    if (dt != null && dt.Rows.Count > 0)
                    //    {
                    //        d材料总金额 = BaseFunction.ReturnDecimal(dt.Rows[0][0], 6);
                    //    }



                    //}

                    tran.Commit();
                }
                catch (Exception ee)
                {
                    tran.Rollback();
                    throw new Exception(ee.Message);
                }
            }
            catch(Exception ee) 
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }
            try
            {

                string sSQL = @"
select count(*) as iCou from 
(
select a.cHandler ,b.cbaccounter ,a.cCode
from Rdrecord10 a inner join Rdrecords10 b on a.id = b.id
	inner join Inventory c on b.cInvCode = c.cInvCode
    inner join Department d on a.cDepCode = d.cDepCode
where a.cWhCode in (select sType from _CostType where iType = 4)
	and a.cRdCode in (select sType from _CostType where iType = 3)
    and a.dDAte >= '111111' and a.dDate < '222222'
    and isnull(b.iQuantity,0) > 0
union All
select a.cHandler ,b.cbaccounter ,a.cCode
from Rdrecord08 a inner join Rdrecords08 b on a.id = b.id
	inner join Inventory c on b.cInvCode = c.cInvCode
    inner join Department d on a.cDepCode = d.cDepCode
where a.cWhCode in (select sType from _CostType where iType = 4)
	and a.cRdCode in (select sType from _CostType where iType = 3)
    and a.dDAte >= '111111' and a.dDate < '222222'
    and isnull(b.iQuantity,0) > 0
)a
where isnull(a.cHandler,'')  = '' or ISNULL(a.cbaccounter,'') <> ''
";
                sSQL = sSQL.Replace("111111", lookUpEdit会计期间.EditValue.ToString() + "-01");
                sSQL = sSQL.Replace("222222", BaseFunction.ReturnDate(lookUpEdit会计期间.EditValue.ToString() + "-01").AddMonths(1).ToString("yyyy-MM-dd"));


                long lCou = BaseFunction.ReturnLong(DbHelperSQL.GetSingle(sSQL));
                if (lCou > 0)
                {
                    throw new Exception("存在未审核或者已记账单据");
                }

                int iCou = 0;
                SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    sSQL = @"
delete dbo._成本记录表 where 会计期间 = '111111'
";
                    sSQL = sSQL.Replace("111111", lookUpEdit会计期间.EditValue.ToString());
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        string s单据类型 = gridView1.GetRowCellValue(i, gridColRdType).ToString().Trim();
                        decimal d单价 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColiUnitCost), 6);
                        decimal d金额 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColiPrice), 6);
                        long lAutoid = BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridColautoid));

                        if (s单据类型 == "产成品入库")
                        {
                            sSQL = "update Rdrecords10 set iUnitCost = " + d单价.ToString() + ",iPrice = " + d金额 + " where autoid = " + lAutoid.ToString();
                            iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                        if (s单据类型 == "其他入库")
                        {
                            sSQL = "update Rdrecords08 set iUnitCost = " + d单价.ToString() + ",iPrice = " + d金额 + " where autoid = " + lAutoid.ToString();
                            iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }

                        Model._成本记录表 model = new UFIDA.U8.UAP.CustomApp.ControlForm.Model._成本记录表();
                        model.单据号 = gridView1.GetRowCellValue(i, gridColcCode).ToString().Trim();
                        model.单据日期 = BaseFunction.ReturnDate(gridView1.GetRowCellValue(i, gridColdDate));
                        model.部门编码 = gridView1.GetRowCellValue(i, gridColcDepCode).ToString().Trim();
                        model.存货编码 = gridView1.GetRowCellValue(i, gridColcInvCode).ToString().Trim();
                        model.数量 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColiQuantity), 6);
                        model.单价 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColiUnitCost), 6);
                        model.金额 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColiPrice), 6);
                        model.单据类型 = gridView1.GetRowCellValue(i, gridColRdType).ToString().Trim();
                        model.料 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol料), 6);
                        model.部门分摊 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol部门分摊), 6);
                        model.公用分摊 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol公用分摊), 6);
                        model.计算时间 = gridView1.GetRowCellValue(i, gridCol计算时间).ToString().Trim();
                        model.产品总数 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol产品总数), 6);
                        model.id = BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridColid));
                        model.autoid = BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridColautoid));
                        model.收发类别 = gridView1.GetRowCellValue(i, gridColcRdCode).ToString().Trim();
                        model.会计期间 = lookUpEdit会计期间.EditValue.ToString().Trim();
                        model.制单人 = sUserID;
                        model.制单日期 = DateTime.Now;

                        DAL._成本记录表 dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._成本记录表();
                        sSQL = dal.Add(model);
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    if (iCou > 0)
                    {
                        tran.Commit();
                        MessageBox.Show("保存成功");
                    }
                    else
                    {
                        MessageBox.Show("未更新成本数据");
                    }
                }
                catch (Exception ee)
                {
                    tran.Rollback();
                    throw new Exception(ee.Message);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}
