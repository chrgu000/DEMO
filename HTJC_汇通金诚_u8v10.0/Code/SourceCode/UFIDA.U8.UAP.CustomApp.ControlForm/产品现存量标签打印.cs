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
using System.IO;
using System.IO.Ports;
using System.Threading;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class 产品现存量标签打印 : UserControl
    {

        string sState = "";

        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }

        public 产品现存量标签打印()
        {
            InitializeComponent();

            sPrintLayOutMod = sProPath + "\\UAP\\Runtime\\print\\Model\\产品标签打印Mod.dll";
            sPrintLayOutUser = sProPath + "\\UAP\\Runtime\\print\\User\\产品标签打印User.dll";
        }


        private void ProjectManager_Load(object sender, EventArgs e)
        {
            try
            {
                if (sUserID == "admin" || sUserID == "system" || sUserID == "demo")
                {
                    btnPrintSET.Visible = true;
                }
                else
                {
                    btnPrintSET.Visible = false;
                }

                SetLookup();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载数据失败");
            }
        }

        private void SetLookup()
        {
            try
            {
                string sSQL = @"
select distinct a.MoCode
from mom_order a inner join mom_orderdetail b on a.moid = b.moid
where b.Status = 3
order by a.MoCode
";
                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                DataRow dr = dt.NewRow();
                dt.Rows.InsertAt(dr, 0);

                lookUpEdit生产订单号1.Properties.DataSource = dt;
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得生产订单号失败");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSel_Click(object sender, EventArgs e)
        {
            try
            {
               
                string sSQL = @"
select cast(1 as bit) as 选择 
    ,rd.mocode 生产订单号,rd.SortSeq as 行号
	,Curr.cInvCode as 存货编码,Inv.cInvName as 存货名称,Inv.cInvStd as 规格型号
	,Curr.cBatch as 批号,rd.cBatchProperty6 as 炉号,Curr.cFree1 as 长度
	,rd.数量 as 毛重,Curr.iQuantity as 净重,Curr.iNum as 件数
	,case when isnull(a.条形码,0) <> 0 then a.条形码 else null end as 条形码
from CurrentStock Curr
	left join (
		select rds.cInvCode,rds.cBatch ,mo.MOCode,mos.SortSeq ,mos.define25 as 数量,cBatchProperty6
		from rdrecord10 rd inner join Rdrecords10 rds on rd.id = rds.id
			inner join mom_orderdetail mos on mos.modid = rds.iMPoIds 
			inner join mom_order mo on mo.moid = mos.moid
		) Rd on rd.cInvCode = curr.cInvCode and rd.cBatch = Curr.cBatch
	left join [条形码信息] a on a.生产订单号 = rd.MOCode and a.行号 = rd.sortseq and Curr.cBatch = a.批号
	inner join Inventory Inv on Inv.cInvCode = Curr.cInvCode
where curr.cWhCode = '04' and curr.iquantity > 0
    and 1=1
order by Curr.cInvCode
";
                if (lookUpEdit生产订单号1.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and rd.mocode = '" + lookUpEdit生产订单号1.Text.Trim() + "' ");
                }
                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                grdDetail.DataSource = dt;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }


        #region 设置打印模板

        private void btnPrintSET_Click(object sender, EventArgs e)
        {
            bool bMod = false;
            if (sUserID == "admin" || sUserID == "system" || sUserID == "demo")
            {
                bMod = true;
            }

            if (!Directory.Exists(sProPath + "\\UAP\\Runtime\\print"))
                Directory.CreateDirectory(sProPath + "\\UAP\\Runtime\\print");
            if (!Directory.Exists(sProPath + "\\UAP\\Runtime\\print\\Model"))
                Directory.CreateDirectory(sProPath + "\\UAP\\Runtime\\print\\Model");
            if (!Directory.Exists(sProPath + "\\UAP\\Runtime\\print\\User"))
                Directory.CreateDirectory(sProPath + "\\UAP\\Runtime\\print\\User");

            if (bMod)
            {
                if (File.Exists(sPrintLayOutMod))
                {
                    Rep.LoadLayout(sPrintLayOutMod);
                }
            }
            else
            {
                if (File.Exists(sPrintLayOutUser))
                {
                    Rep.LoadLayout(sPrintLayOutUser);
                }
                else if (File.Exists(sPrintLayOutMod))
                {
                    Rep.LoadLayout(sPrintLayOutMod);
                }
            }

            Rep.ShowDesignerDialog();

            DialogResult d = MessageBox.Show("是否保存?模板调整将在下次打开窗体时体现\n是：保存打印模板\n否：恢复默认打印模板\n", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
            if (DialogResult.Yes == d)
            {
                if (bMod)
                {
                    Rep.SaveLayoutToXml(sPrintLayOutMod);
                }
                else
                {
                    Rep.SaveLayoutToXml(sPrintLayOutUser);
                }
            }
            else if (DialogResult.No == d)
            {
                if (File.Exists(sPrintLayOutUser))
                {
                    File.Delete(sPrintLayOutUser);
                }
            }
        }

        
        protected string sProPath = Application.StartupPath;    //程序执行位置
        string sPrintLayOutMod;
        string sPrintLayOutUser;
        RepBaseGrid Rep = new RepBaseGrid();
        DataSet dsPrint = new DataSet();          //打印模板数据源



        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {

                string sSQL = "select getdate()";
                DateTime d当前日期 = Convert.ToDateTime(SqlHelper.ExecuteScalar(Conn, CommandType.Text, sSQL));
                string s条码单据号 = d当前日期.ToString("yyyyMMddHHmmss");

                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    Rep = new RepBaseGrid();
                    if (File.Exists(sPrintLayOutUser))
                    {
                        Rep.LoadLayout(sPrintLayOutUser);
                    }
                    else if (File.Exists(sPrintLayOutMod))
                    {
                        Rep.LoadLayout(sPrintLayOutMod);
                    }
                    else
                    {
                        MessageBox.Show("加载报表模板失败，请与管理员联系");
                        return;
                    }
                    Rep.dsPrint.Tables.Clear();

                    string sGuid = Guid.NewGuid().ToString();

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (!Convert.ToBoolean(gridView1.GetRowCellValue(i, gridCol选择)))
                            continue;

                        sSQL = "select * from 条形码信息 where 存货编码 = '"+ gridView1.GetRowCellValue(i,gridCol存货编码).ToString().Trim() + "' and 批号 = '" + gridView1.GetRowCellValue(i, gridCol批号).ToString().Trim() + "' and 长度 = '" + gridView1.GetRowCellValue(i, gridCol长度).ToString().Trim() + "' and 炉号 = '" + gridView1.GetRowCellValue(i, gridCol炉号).ToString().Trim() + "'";
                        DataTable dt = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt == null || dt.Rows.Count == 0)
                        {
                            string s毛重 = gridView1.GetRowCellValue(i, gridCol毛重).ToString().Trim();
                            int iKG = s毛重.IndexOf("KG");
                            s毛重 = s毛重.Substring(0, iKG);

                            sSQL = "INSERT INTO [条形码信息]([存货编码] ,[长度],[批号] ,[炉号] ,[数量] ,[毛重]" +
                                              ",[保存人]  ,[保存日期],[打印次数],[生产订单号],[行号] " +
                                              " ,[最后一次打印人]  ,[最后一次打印日期],条码单据号,guid) " +
                                          " VALUES ('" + gridView1.GetRowCellValue(i, gridCol存货编码).ToString().Trim() + "','" + gridView1.GetRowCellValue(i, gridCol长度).ToString().Trim() + "','" + gridView1.GetRowCellValue(i, gridCol批号).ToString().Trim() + "','" + gridView1.GetRowCellValue(i, gridCol炉号).ToString().Trim() + "'," + gridView1.GetRowCellValue(i, gridCol净重).ToString().Trim() + "," + s毛重 + "  " +
                                                ",'" + sUserID + "',getdate(),1,'" + gridView1.GetRowCellValue(i, gridCol生产订单号).ToString().Trim().Trim() + "','" + gridView1.GetRowCellValue(i, gridCol行号).ToString().Trim().Trim() + "' " +
                                                ",'" + sUserID + "',getdate(),'" + s条码单据号 + "','" + sGuid + "')";
                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                        else
                        {
                            sSQL = "update 条形码信息 set 打印次数 = isnull(打印次数,0) + 1,最后一次打印日期 = getdate(),GUID = '" + sGuid + "' where 存货编码 = '"+ gridView1.GetRowCellValue(i,gridCol存货编码).ToString().Trim() + "' and 批号 = '" + gridView1.GetRowCellValue(i, gridCol批号).ToString().Trim() + "' and 长度 = '" + gridView1.GetRowCellValue(i, gridCol长度).ToString().Trim() + "' and 炉号 = '" + gridView1.GetRowCellValue(i, gridCol炉号).ToString().Trim() + "'";
                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                    }


                    sSQL = @"
select right(cast('000000000'+rtrim(条形码) as varchar(20)),10) as 条形码, 存货编码, 长度, 批号, 炉号, 数量, 毛重, 保存人, 保存日期, 打印次数, 最后一次打印人
    ,最后一次打印日期, 条码单据号, 修改人, 修改日期, 关闭人, 关闭日期, 采购订单号, 生产订单号, 销售订单号, 行号, GUID
    ,采购入库单号, 采购入库单行号, 产成品入库单号, 产成品入库单行号
    ,b.cInvName,b.cInvStd
from 条形码信息 a inner join Inventory b on a.存货编码 = b.cInvCode 
where guid = '" + sGuid + "'";
                    DataTable dtHead = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    dtHead.TableName = "dtHead";
                    Rep.dsPrint.Tables.Add(dtHead.Copy());
                    Rep.ShowPreview();
                    //Rep.Print();

                    tran.Commit();
                }
                catch (Exception error)
                {
                    tran.Rollback();
                    throw new Exception(error.Message);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }



        #endregion

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    gridView1.SetRowCellValue(i, gridCol选择, chkAll.Checked);
                }
            }
            catch (Exception ee)
            { }
        }
    }
}