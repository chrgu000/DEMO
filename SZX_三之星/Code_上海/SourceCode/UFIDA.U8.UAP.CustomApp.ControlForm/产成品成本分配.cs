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
    public partial class 产成品成本分配 : UserControl
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
                DbHelperSQL.connectionString = Conn;

                SetLookUp();
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "加载窗体失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        public 产成品成本分配()
        {
            InitializeComponent();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            
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

        private void btnSEL_Click(object sender, EventArgs e)
        {       
            try
            {
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }


        private void SetLookUp()
        {
            string sSQL = @"
select distinct cast(year(a.dDate) as varchar(4)) + '-' + cast(RIGHT('00'+CAST(a.dDate AS NVARCHAR(2)),2) as varchar(2)) as 会计期间
from rdrecord10 a
order by cast(year(a.dDate) as varchar(4)) + '-' + cast(RIGHT('00'+CAST(a.dDate AS NVARCHAR(2)),2) as varchar(2))
";
            DataTable dt = DbHelperSQL.Query(sSQL);
            if (dt != null && dt.Rows.Count > 0)
            {
                lookUpEdit会计期间.Properties.DataSource = dt;
                lookUpEdit会计期间.EditValue = dt.Rows[dt.Rows.Count - 1]["会计期间"].ToString().Trim();
            }

            sSQL = "select cInvCCode,cInvCName from InventoryClass order by cInvCCode";
            dt = DbHelperSQL.Query(sSQL);
            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            lookUpEditcInvCCode.Properties.DataSource = dt;
            lookUpEditcInvCName.Properties.DataSource = dt;
        }

        private void GetGrid()
        {
            if (lookUpEdit会计期间.EditValue == null || lookUpEdit会计期间.EditValue.ToString().Trim() == "")
            {
                lookUpEdit会计期间.Focus();
                throw new Exception("请选择会计期间");
            }

            string sSQL = "select * from GL_mend where iYPeriod = aaaaaa ";
            sSQL = sSQL.Replace("aaaaaa", lookUpEdit会计期间.EditValue.ToString().Substring(0, 4) + lookUpEdit会计期间.EditValue.ToString().Substring(5));
            DataTable dt = DbHelperSQL.Query(sSQL);
            if (dt == null || dt.Rows.Count == 0)
            {
                throw new Exception("获得仓库业务状态失败");
            }
            if (BaseFunction.ReturnBool(dt.Rows[0]["bflag_ST"]))
            {
                throw new Exception("当前会计期间已经结账,不能重新计算成本");
            }

            sSQL = @"
select b.cInvCode as 存货编码,c.cInvName as 存货名称,c.cInvStd as 规格型号,cast(sum(b.iQuantity) as decimal(18,3)) as 数量,d.cidefine12 as 原价
	,cast(cast(sum(b.iQuantity) as decimal(18,3)) * d.cidefine12 as decimal(18,6)) as 标准
	,cast(null as decimal(18,6)) as 差异
	,cast(null as decimal(18,6)) as 间接原价
	,cast(null as decimal(18,6)) as 实际成本
from rdrecord10 a inner join rdrecords10 b on a.id = b.ID
	inner join Inventory c on b.cInvCode = c.cInvCode
	left join Inventory_extradefine d on c.cInvCode = d.cInvCode 
where 1=1
group by b.cInvCode,c.cInvName,c.cInvStd,d.cidefine12
order by b.cInvCode
";
            DateTime d = BaseFunction.ReturnDate(lookUpEdit会计期间.EditValue.ToString() + "-01");
            sSQL = sSQL.Replace("1=1", "1=1 and a.dDate >= '" + d.ToString("yyyy-MM-dd") + "' and a.dDate < '" + d.AddMonths(1).ToString("yyyy-MM-dd") + "'");

            if (lookUpEditcInvCCode.EditValue != null)
            {
                sSQL = sSQL.Replace("1=1", "1=1 and c.cInvCCode like '" + lookUpEditcInvCCode.EditValue.ToString().Trim() + "%'");
            }
            dt = DbHelperSQL.Query(sSQL);
            gridControl1.DataSource = dt;
            gridView1.BestFitColumns();
        }

        private void lookUpEditcInvCCode_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lookUpEditcInvCName.EditValue = lookUpEditcInvCCode.EditValue;
            }
            catch { }
        }

        private void lookUpEditcInvCName_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lookUpEditcInvCCode.EditValue = lookUpEditcInvCName.EditValue;
            }
            catch { }
        }

        private void btn计算_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.RowCount <= 0)
                {
                    throw new Exception("请加载数据");
                }

                decimal d标准ColSum = BaseFunction.ReturnDecimal(gridCol标准.SummaryItem.SummaryValue);
                if (d标准ColSum <= 0)
                {
                    throw new Exception("获得标准金额失败");
                }

                decimal d差异Sum = BaseFunction.ReturnDecimal(txt差异.Text);
                decimal d间接原价Sum =  BaseFunction.ReturnDecimal(txt间接原价.Text);

                DataTable dt = (DataTable)gridControl1.DataSource;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    decimal d标准 = BaseFunction.ReturnDecimal(dt.Rows[i]["标准"]);
                    decimal 差异 = BaseFunction.ReturnDecimal(d差异Sum * d标准 / d标准ColSum, 2);
                    decimal d间接原价 = BaseFunction.ReturnDecimal(d间接原价Sum * d标准 / d标准ColSum, 2);
                    decimal d实际成本 = BaseFunction.ReturnDecimal(d标准 + 差异 + d间接原价, 2);
                    dt.Rows[i]["差异"] = 差异;
                    dt.Rows[i]["间接原价"] = d间接原价;
                    dt.Rows[i]["实际成本"] = d实际成本;
                }

                decimal d差异ColSum = BaseFunction.ReturnDecimal(gridCol差异.SummaryItem.SummaryValue);
                if (d差异ColSum != d差异Sum)
                {
                    int i差异行 = 0;
                    decimal d差异最大值 = BaseFunction.ReturnDecimal(dt.Rows[0]["差异"]);
                    for (int i = 1; i < dt.Rows.Count; i++)
                    {
                        if (d差异最大值 < BaseFunction.ReturnDecimal(dt.Rows[i]["差异"]))
                        {
                            i差异行 = i;
                            d差异最大值 = BaseFunction.ReturnDecimal(dt.Rows[i]["差异"]);
                        }
                    }

                    //if (d差异最大值 > Math.Abs(d差异ColSum - d差异Sum))
                    {
                        dt.Rows[i差异行]["差异"] = d差异最大值 - (d差异ColSum - d差异Sum);
                    }
                }

                decimal d间接原价ColSum = BaseFunction.ReturnDecimal(gridCol间接原价.SummaryItem.SummaryValue);
                if (d间接原价ColSum != d间接原价Sum)
                {
                    int i间接原价行 = 0;
                    decimal d间接原价最大值 = BaseFunction.ReturnDecimal(dt.Rows[0]["间接原价"]);
                    for (int i = 1; i < dt.Rows.Count; i++)
                    {
                        if (d间接原价最大值 < BaseFunction.ReturnDecimal(dt.Rows[i]["间接原价"]))
                        {
                            i间接原价行 = i;
                            d间接原价最大值 = BaseFunction.ReturnDecimal(dt.Rows[i]["间接原价"]);
                        }
                    }

                    //if (d间接原价最大值 > Math.Abs(d间接原价ColSum - d间接原价Sum))
                    {
                        dt.Rows[i间接原价行]["间接原价"] = d间接原价最大值 - (d间接原价ColSum - d间接原价Sum);
                    }
                }

                gridView1.BestFitColumns();
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btn保存_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                decimal d差异ColSum = BaseFunction.ReturnDecimal(gridCol差异.SummaryItem.SummaryValue);
                decimal d间接原价ColSum = BaseFunction.ReturnDecimal(gridCol间接原价.SummaryItem.SummaryValue);
                decimal d实际成本ColSum = BaseFunction.ReturnDecimal(gridCol实际成本.SummaryItem.SummaryValue);

                if (d差异ColSum == 0)
                {
                    DialogResult d = MessageBox.Show("请确定差异是否正确\n是否继续?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                    if (d != DialogResult.Yes)
                    {
                        return;
                    }
                }
                if (d间接原价ColSum == 0)
                {
                    DialogResult d = MessageBox.Show("请确定间接原价是否正确\n是否继续?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                    if (d != DialogResult.Yes)
                    {
                        return;
                    }
                }

                if (d实际成本ColSum == 0)
                {
                    throw new Exception("实际成本不正确");
                }

                string sErr = "";
                int iCou = 0;
                SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();


                string sSQL = "select getdate()";
                DateTime dNow = BaseFunction.ReturnDate(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);

                sSQL = @"
SELECT cValue FROM dbo.AccInformation
WHERE cSysID='AA' AND cid='20'
";
                DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                int i小数位 = 4;
                if (dt != null && dt.Rows.Count > 0)
                {
                    i小数位 = BaseFunction.ReturnInt(dt.Rows[0][0]);
                }

                try
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        string sInvCode = gridView1.GetRowCellValue(i, gridCol存货编码).ToString().Trim();
                        decimal d实际成本 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol实际成本));
                        decimal d数量 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol数量));
                        decimal d单价 = BaseFunction.ReturnDecimal(d实际成本 / d数量, i小数位);
                        decimal d未分配成本 = d实际成本;

                        sSQL = @"
select b.cInvCode 
from rdrecord10 a inner join rdrecords10 b on a.ID = b.ID
	inner join Inventory c on b.cInvCode = c.cInvCode
where 1=1
	and b.cInvCode = 'aaaaaa'
	and isnull(b.cbaccounter,'') <> ''
";
                        DateTime d = BaseFunction.ReturnDate(lookUpEdit会计期间.EditValue.ToString() + "-01");
                        sSQL = sSQL.Replace("1=1", "1=1 and a.dDate >= '" + d.ToString("yyyy-MM-dd") + "' and a.dDate < '" + d.AddMonths(1).ToString("yyyy-MM-dd") + "'");
                        sSQL = sSQL.Replace("aaaaaa", sInvCode);
                        dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            sErr = sErr + "存货 " + sInvCode + " 存在已记账单据\n";
                            continue;
                        }

                        sSQL = @"
select b.*
from rdrecord10 a inner join rdrecords10 b on a.ID = b.ID
	inner join Inventory c on b.cInvCode = c.cInvCode
where 1=1
	and b.cInvCode = 'aaaaaa'
";
                        sSQL = sSQL.Replace("1=1", "1=1 and a.dDate >= '" + d.ToString("yyyy-MM-dd") + "' and a.dDate < '" + d.AddMonths(1).ToString("yyyy-MM-dd") + "'");
                        sSQL = sSQL.Replace("aaaaaa", sInvCode);
                        DataTable dtRDs = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        for (int j = 0; j < dtRDs.Rows.Count; j++)
                        {
                            long lIDs = BaseFunction.ReturnLong(dtRDs.Rows[j]["AutoID"]);
                            decimal d当前行成本 = BaseFunction.ReturnDecimal(d单价 * BaseFunction.ReturnDecimal(dtRDs.Rows[j]["iQuantity"]), 2);

                            if (j == dtRDs.Rows.Count - 1)
                            {
                                d当前行成本 = d未分配成本;
                            }
                            else
                            {
                                d未分配成本 = d未分配成本 - d当前行成本;
                            }

                            sSQL = "update rdrecords10 set iUnitCost = bbbbbb,iPrice = cccccc where autoid = dddddd";
                            sSQL = sSQL.Replace("bbbbbb", d单价.ToString());
                            sSQL = sSQL.Replace("cccccc", d当前行成本.ToString());
                            sSQL = sSQL.Replace("dddddd", lIDs.ToString());
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }

                        Model._产品成本分配 model = new UFIDA.U8.UAP.CustomApp.ControlForm.Model._产品成本分配();
                        model.会计期间 = lookUpEdit会计期间.EditValue.ToString();
                        if (lookUpEditcInvCCode.EditValue != null && lookUpEditcInvCCode.EditValue.ToString().Trim() != "")
                        {
                            model.存货分类 = lookUpEditcInvCCode.EditValue.ToString().Trim();
                        }
                        model.差异Sum = BaseFunction.ReturnDecimal(txt差异.Text);
                        model.间接原价Sum = BaseFunction.ReturnDecimal(txt间接原价.Text);
                        model.存货编码 = sInvCode;
                        model.数量 = d数量;
                        model.原价 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol原价));
                        model.标准 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol标准));
                        model.差异 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol差异));
                        model.间接原价 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol间接原价));
                        model.实际成本 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol实际成本));
                        model.CreateUid = sUserID;
                        model.CreateDate = dNow;

                        DAL._产品成本分配 dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._产品成本分配();
                        sSQL = dal.Add(model);
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    if (sErr.Length > 0)
                    {
                        throw new Exception(sErr);
                    }

                    tran.Commit();

                    MessageBox.Show("保存成功");
                }
                catch (Exception ee)
                {
                    tran.Rollback();
                    throw new Exception(ee.Message);
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox msg = new FrmMsgBox();
                msg.Text = "提示";
                msg.richTextBox1.Text = ee.Message;
                msg.ShowDialog();
            }
        }
    }
}
