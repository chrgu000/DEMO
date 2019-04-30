using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using FrameBaseFunction;

namespace Base
{
    public partial class Frm询价单 : FrameBaseFunction.Frm列表窗体模板
    {  
        DataTable dtSel = new DataTable();
        int iPage = 0;
        ArrayList aList;
        string sSQL;

        public Frm询价单()
        {
            InitializeComponent();
        }

        protected override void BtnClick(string sBtnName, string sBtnText)
        {
            try
            {
                switch (sBtnName.ToLower())
                {
                    case "sel":
                        btnSel();
                        break;
                    case "add":
                        btnAdd();
                        break;
                    case "del":
                        btnDel();
                        break;
                    case "save":
                        btnAudit();
                        break;
                    case "undo":
                        btnUnAudit();
                        break;
                    case "lock":
                        btnstopX();
                        break;
                    case "unlock":
                        btnselX();
                        break;
                    case "audit":
                        btnselAll();
                        break;
                    default:
                        break;
                }

                sState = sBtnName.ToLower();
            }
            catch (Exception ee)
            {
                throw new Exception(sBtnText + " 失败! \n\n原因:\n  " + ee.Message);
            }
        }

        private void btnselAll()
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            int iFocRow = -1;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (Convert.ToBoolean(gridView1.GetRowCellValue(i, gridCol选择)))
                {
                    iFocRow = i;
                    break;
                }
            }

            if (iFocRow == -1)
            {
                throw new Exception("请选择单据");
            }

            string sGuid = gridView1.GetRowCellValue(iFocRow, gridColGUID).ToString().Trim();
            Frm询价单结论公布内部 f = new Frm询价单结论公布内部(sGuid, lookUpEditcDepCode.EditValue.ToString());
            f.WindowState = FormWindowState.Normal;
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ShowDialog();
        }

        private void btnselX()
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            int iFocRow = -1;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (Convert.ToBoolean(gridView1.GetRowCellValue(i, gridCol选择)))
                {
                    iFocRow = i;
                    break;
                }
            }
            if (iFocRow == -1)
            {
                throw new Exception("请选择单据");
            }

            string sGuid = gridView1.GetRowCellValue(iFocRow, gridColGUID).ToString().Trim();
            string sSQL = "select *,getdate() as 当前时间 from UFDLImport..询价单 where GUID = '" + sGuid + "'";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            if (dt == null || dt.Rows.Count == 0)
            {
                throw new Exception("行 " + (iFocRow + 1).ToString() + "获得询价单失败");
            }
            if (dt.Rows[0]["发布人"].ToString().Trim() == "")
            {
                throw new Exception("行 " + (iFocRow + 1).ToString() + "尚未发布");
            }
            DateTime d当前时间 = Convert.ToDateTime(dt.Rows[0]["当前时间"]);
            DateTime d截止时间 = Convert.ToDateTime(dt.Rows[0]["截止日期"]);
            DateTime d终止时间 = Convert.ToDateTime("2099-12-31");
            if (dt.Rows[0]["终止询价日期"].ToString().Trim() != "")
            {
                d终止时间 = Convert.ToDateTime(dt.Rows[0]["终止询价日期"]);
            }
            if (d当前时间 < d截止时间 && d当前时间 < d终止时间)
            {
                throw new Exception("行 " + (iFocRow + 1).ToString() + "截止时间未到");
            }

            //有供应商未报价，提示，并取消查看
            sSQL = @"
select b.[供应商编码],d.cVenName
from UFDLImport..询价单 a inner join UFDLImport..询价单物料列表 aa on a.GUID = aa.GUID
	inner join UFDLImport..询价单供应商 b on a.GUID = b.GUID 
	left join UFDLImport..询价单供应商报价 c on c.GUID = a.guid and aa.GUID物料 = c.GUID物料 and b.供应商编码 = c.供应商编码
	inner join @u8.vendor d on b.供应商编码 = d.cVenCode
	left join UFDLImport..询价单附件 e on e.GUID物料 = aa.GUID物料
where a.[GUID] = 'aaaaaa'
	AND c.单价 is null
GROUP BY b.[供应商编码],d.cVenName

";
            sSQL = sSQL.Replace("aaaaaa", sGuid);
            DataTable dtTemp = clsSQLCommond.ExecQuery(sSQL);
            if (d当前时间 < d截止时间.AddHours(2))
            {
                if (dtTemp != null && dtTemp.Rows.Count > 0)
                {
                    string sVenTemp = "";
                    for (int i = 0; i < dtTemp.Rows.Count; i++)
                    {
                        if (sVenTemp == "")
                        {
                            sVenTemp = dtTemp.Rows[i]["供应商编码"].ToString().Trim() + "-" + dtTemp.Rows[i]["cVenName"].ToString().Trim();
                        }
                        else
                        {
                            sVenTemp = sVenTemp + "\n" + dtTemp.Rows[i]["供应商编码"].ToString().Trim() + "-" + dtTemp.Rows[i]["cVenName"].ToString().Trim();
                        }
                    }

                    throw new Exception("报价未完成，当前无法查看，尚有如下公司未报价，请及时通知:\n" + sVenTemp);
                }
            }

            Frm询价单查看 f = new Frm询价单查看(sGuid);
            f.ShowDialog();

        }

        private void btnstopX()
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            string sInfo = "";

            aList = new ArrayList();
            string sErr = "";
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (!Convert.ToBoolean(gridView1.GetRowCellValue(i, gridCol选择)))
                    continue;

                string sSQL = "select *,getdate() as 当前时间 from UFDLImport..询价单 where guid = '" + gridView1.GetRowCellValue(i, gridColGUID).ToString().Trim() + "'";
                DataTable dt= clsSQLCommond.ExecQuery(sSQL);
                if (dt == null || dt.Rows.Count ==0)
                {
                    sErr = sErr + "行" + (i + 1).ToString() + "获得询价单失败\n";
                    continue;
                }
                if (dt.Rows[0]["发布人"].ToString().Trim() == "")
                {
                    sErr = sErr + "行" + (i + 1).ToString() + "尚未发布\n";
                    continue;
                }
                if (dt.Rows[0]["终止人"].ToString().Trim() != "")
                {
                    sErr = sErr + "行" + (i + 1).ToString() + "已经终止\n";
                    continue;
                }
                DateTime dNow = Convert.ToDateTime(dt.Rows[0]["当前时间"]);
                DateTime d截止日期 = Convert.ToDateTime(dt.Rows[0]["截止日期"]);
                if (dNow > d截止日期)
                {
                    sErr = sErr + "行" + (i + 1).ToString() + "已过截止日期，不需要终止\n";
                    continue;
                }

                sSQL = @"
select 供应商编码 from UFDLImport..询价单 a left join UFDLImport.[dbo].[询价单供应商] b on a.guid = b.GUID
where a.guid = 'aaaaaa'
	and 供应商编码 not in (select 供应商编码 from UFDLImport.[dbo].[询价单供应商报价] where guid = 'aaaaaa')
";
                sSQL = sSQL.Replace("aaaaaa", gridView1.GetRowCellValue(i, gridColGUID).ToString().Trim());
                DataTable dtVend = clsSQLCommond.ExecQuery(sSQL);
                if (dtVend != null && dtVend.Rows.Count > 0)
                {
                    string sVend = "";
                    for (int j = 0; j < dtVend.Rows.Count; j++)
                    {
                        if (sVend == "")
                        {
                            sVend = dtVend.Rows[j]["供应商编码"].ToString().Trim();
                        }
                        else
                        {
                            sVend = sVend + "," + dtVend.Rows[j]["供应商编码"].ToString().Trim();
                        }
                    }
                    sInfo = sInfo + "行" + (i + 1).ToString() + ":  " +sVend + "\n";
                }

                sSQL = "update UFDLImport..询价单 set 终止人 = '" + FrameBaseFunction.ClsBaseDataInfo.sUid + "',终止询价日期 = getdate() where guid = '" + gridView1.GetRowCellValue(i, gridColGUID).ToString().Trim() + "'";
                aList.Add(sSQL);
            }
            if (sErr != "")
            {
                throw new Exception(sErr);
            }

            if (sInfo != "")
            {
                DialogResult d = MessageBox.Show("以下供应商未报价，是否继续:\n" + sInfo, "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (d != DialogResult.Yes)
                {
                    throw new Exception("请通知以下供应商继续报价:\n" + sInfo);
                }
            }

            if (aList.Count > 0)
            {
                clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("终止成功");
                btnSel();
            }
            else
            {
                MessageBox.Show("没有选择需要发布的数据");
            }
        }

        private void btnAdd()
        {
            string sDepCode = lookUpEditcDepCode.EditValue.ToString().Trim();
            if (sDepCode == "")
            {
                throw new Exception("获得用户部门信息失败");
            }

            Frm询价单Edit f = new Frm询价单Edit(sDepCode);
            f.ShowDialog();

            btnSel();
        }

        private void btnSel()
        {
            int iFoc = 0;
            if (gridView1.FocusedRowHandle > 0)
                iFoc = gridView1.FocusedRowHandle;

            string sSQL = @"
select cast(0 as bit) as 选择
    , iID, 单据日期, 制单人, 制单日期, 发布人, 发布日期, 标题, 备注,  GUID
    ,cast(null as varchar(8000)) as 供应商编码,cast(null as varchar(8000)) as 供应商名称 
    , CONVERT(varchar, 截止日期, 120) AS 截止日期
    , CONVERT(varchar, 终止询价日期, 120) as 终止询价日期, 终止人
from UFDLImport..询价单 a
where 1=1 and a.部门 = '111111'
order by a.iID
";
            sSQL = sSQL.Replace("111111", lookUpEditcDepCode.EditValue.ToString().Trim());
            if (date1.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and 单据日期 >= '" + date1.DateTime.ToString("yyyy-MM-dd") + "' ");
            }
            if (date2.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and 单据日期 <= '" + date2.DateTime.ToString("yyyy-MM-dd") + "' ");
            }
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sSQL = "select *,b.cVenName as 供应商名称 from UFDLImport..询价单供应商 a inner join @u8.vendor b on a.供应商编码 = b.cVenCode where guid = '" + dt.Rows[i]["guid"].ToString().Trim() + "' order by a.iID";
                DataTable dtGrid = clsSQLCommond.ExecQuery(sSQL);
                string s供应商编码 = "";
                string s供应商名称 = "";
                for (int j = 0; j < dtGrid.Rows.Count; j++)
                {
                    if (s供应商编码 == "")
                    {
                        s供应商编码 = dtGrid.Rows[j]["供应商编码"].ToString().Trim();
                        s供应商名称 = dtGrid.Rows[j]["供应商名称"].ToString().Trim();
                    }
                    else
                    {
                        s供应商编码 = s供应商编码 + "," + dtGrid.Rows[j]["供应商编码"].ToString().Trim();
                        s供应商名称 = s供应商名称 + "," + dtGrid.Rows[j]["供应商名称"].ToString().Trim();
                    }
                }
                dt.Rows[i]["供应商编码"] = s供应商编码;
                dt.Rows[i]["供应商名称"] = s供应商名称;
            }
            gridControl1.DataSource = dt;
            gridView1.FocusedRowHandle = iFoc;

        }

        private void btnUnAudit()
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            aList = new ArrayList();
            string sErr = "";
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (!Convert.ToBoolean(gridView1.GetRowCellValue(i, gridCol选择)))
                    continue;

                string sSQL = "select count(1) from UFDLImport..询价单 where guid = '" + gridView1.GetRowCellValue(i, gridColGUID).ToString().Trim() + "' and isnull(发布人,'') = ''";
                int iCou = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
                if (iCou > 0)
                {
                    sErr = sErr + "行" + (i + 1).ToString() + "尚未发布\n";
                    continue;
                }

                sSQL = "update UFDLImport..询价单 set 发布人 = null,发布日期 = null where guid = '" + gridView1.GetRowCellValue(i, gridColGUID).ToString().Trim() + "'";
                aList.Add(sSQL);
            }
            if (sErr != "")
            {
                throw new Exception(sErr);
            }

            if (aList.Count > 0)
            {
                clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("取消发布成功");
                btnSel();
            }
            else
            {
                MessageBox.Show("没有选择需要发布的数据");
            }
        }

        private void btnAudit()
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            aList = new ArrayList();
            string sErr = "";
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (!Convert.ToBoolean(gridView1.GetRowCellValue(i, gridCol选择)))
                    continue;

                string sSQL = "select count(1) from UFDLImport..询价单 where guid = '" + gridView1.GetRowCellValue(i, gridColGUID).ToString().Trim() + "' and isnull(发布人,'') <> ''";
                int iCou = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
                if (iCou > 0)
                {
                    sErr = sErr + "行" + (i + 1).ToString() + "已经发布\n";
                    continue;
                }

                sSQL = "update UFDLImport..询价单 set 发布人 = '" + FrameBaseFunction.ClsBaseDataInfo.sUid + "',发布日期 = getdate() where guid = '" + gridView1.GetRowCellValue(i, gridColGUID).ToString().Trim() + "'";
                aList.Add(sSQL);
            }
            if (sErr != "")
            {
                throw new Exception(sErr);
            }

            if (aList.Count > 0)
            {
                clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("发布成功");
                btnSel();
            }
            else
            {
                MessageBox.Show("没有选择需要发布的数据");
            }
        }

        private void btnDel()
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            aList = new ArrayList();
            string sErr = "";
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (Convert.ToBoolean(gridView1.GetRowCellValue(i, gridCol选择)))
                {
                    string sSQL = "select count(1) from UFDLImport..询价单 where guid = '" + gridView1.GetRowCellValue(i, gridColGUID).ToString().Trim() + "' and isnull(发布人,'') <> ''";
                    int iCou = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
                    if (iCou > 0)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "已经发布\n";
                        continue;
                    }

                    sSQL = "delete UFDLImport..询价单物料列表 where guid = '" + gridView1.GetRowCellValue(i, gridColGUID).ToString().Trim() + "'";
                    aList.Add(sSQL);

                    sSQL = "delete UFDLImport..询价单供应商 where guid = '" + gridView1.GetRowCellValue(i, gridColGUID).ToString().Trim() + "'";
                    aList.Add(sSQL);

                    sSQL = "delete UFDLImport..询价单附件 where guid = '" + gridView1.GetRowCellValue(i, gridColGUID).ToString().Trim() + "'";
                    aList.Add(sSQL);

                    sSQL = "delete UFDLImport..询价单 where guid = '" + gridView1.GetRowCellValue(i, gridColGUID).ToString().Trim() + "'";
                    aList.Add(sSQL);
                }
            }
            if (sErr != "")
            {
                throw new Exception(sErr);
            }

            if (aList.Count > 0)
            {
                clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("删除成功");
                btnSel();
            }
            else
            {
                MessageBox.Show("没有选择需要发布的数据");
            }
        }

        private void btnSave()
        {
            throw new NotImplementedException();
        }

        #region 按钮模板

      
        /// <summary>
        /// 输出
        /// </summary>
        private void btnExport()
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

      
        #endregion






        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                SetLookUp();

                string sSQL = @"
select a.cDepCode ,b.cDepName
from dbo._UserInfo a
	left join @u8.Department b on a.cDepCode = b.cDepCode
where vchrUid = '1111'
";
                sSQL = sSQL.Replace("1111", FrameBaseFunction.ClsBaseDataInfo.sUid);
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt == null || dt.Rows.Count == 0)
                {
                    throw new Exception("获得用户信息失败");
                }
                if (dt.Rows[0]["cDepCode"].ToString().Trim() == "")
                {
                    throw new Exception("请设置用户所属部门");
                }
                lookUpEditcDepCode.EditValue = dt.Rows[0]["cDepCode"].ToString().Trim();

                date1.DateTime = DateTime.Today.AddMonths(-1);
                date2.DateTime = DateTime.Today;

                date1.Enabled = true;
                date1.Properties.ReadOnly = false;

                date2.Enabled = true;
                date2.Properties.ReadOnly = false;

                btnSel();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            }
        }

        private void gridView评审_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int iRow = 0;
                if (gridView1.FocusedRowHandle > 0)
                    iRow = gridView1.FocusedRowHandle;

                string sDepCode = lookUpEditcDepCode.EditValue.ToString().Trim();
                if (sDepCode == "")
                {
                    throw new Exception("获得用户部门信息失败");
                }


                string sGuid = gridView1.GetRowCellValue(iRow, gridColGUID).ToString().Trim();
                if (sGuid != "")
                {
                    Frm询价单Edit f = new Frm询价单Edit(sGuid, sDepCode);
                    f.ShowDialog();

                    btnSel();
                }
            }
            catch { }
        }

        private void SetLookUp()
        {
            string sSQL = "select cDepCode,cDepName from @u8.Department order by cDepCode";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            lookUpEditcDepCode.Properties.DataSource = dt;


            sSQL = "select  vchrUid, vchrName from _UserInfo order by vchrUid";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEditUser.DataSource = dt;
        }
    }
}