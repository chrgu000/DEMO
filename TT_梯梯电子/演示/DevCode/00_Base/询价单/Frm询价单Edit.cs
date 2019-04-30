using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using FrameBaseFunction;
using System.IO;
using System.Data.SqlClient;
using System.Data.OleDb;


namespace Base
{
    public partial class Frm询价单Edit : Form
    {
        FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();
        FrameBaseFunction.ClsGetSQL clsGetSQL = FrameBaseFunction.ClsGetSQL.Instance();

        string sDepCode = "";

        string sGuid = "";
        public Frm询价单Edit(string s2)
        {
            InitializeComponent();

            labelGUID.Text = "";
            sDepCode = s2;
        }
        string sType = "";
        public Frm询价单Edit(string s,string s2)
        {
            InitializeComponent();

            sGuid = s;

            labelGUID.Text = s;

            sDepCode = s2;
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
                    gridView2.ExportToXls(sF.FileName);
                    MessageBox.Show("导出Excel成功\n\t路径：" + sF.FileName);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

      
        #endregion

        private void SetValue()
        {

            string sSQL = @"
select a.* ,b.*,c.cVenName
from UFDLImport..询价单 a inner join UFDLImport..询价单供应商 b on a.GUID = b.GUID 
    left join @u8.Vendor c on b.供应商编码 = c.cVenCode
where a.GUID = '111111'
";
            sSQL = sSQL.Replace("111111", sGuid);
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt == null || dt.Rows.Count == 0)
            {
                SetNull();
                return;
            }

            labeliID.Text = dt.Rows[0]["iID"].ToString().Trim();

            string sVenCode = "";
            string sVenName = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (sVenCode == "")
                {
                    sVenCode = dt.Rows[i]["供应商编码"].ToString().Trim();
                    sVenName = dt.Rows[i]["cVenName"].ToString().Trim();
                }
                else
                {
                    sVenCode = sVenCode + "," + dt.Rows[i]["供应商编码"].ToString().Trim();
                    sVenName = sVenName + "," + dt.Rows[i]["cVenName"].ToString().Trim();
                }
            }

            label供应商.Text = sVenCode;
            txtVenCode.Text = sVenCode;
            txtVenName.Text = sVenName;

            sSQL = @"
select a.*,b.附件名 as 下载附件 ,cast(null as varchar(200)) as 上传附件
from UFDLImport..询价单物料列表 a left join UFDLImport..询价单附件 b on a.GUID物料 = b.GUID物料
where 1=1 
order by a.iID
";
            sSQL = sSQL.Replace("1=1","1=1 and a.GUID = '" + sGuid + "'");
            DataTable dt物料列表 = clsSQLCommond.ExecQuery(sSQL);
            gridControl2.DataSource = dt物料列表;


            txt主题.Text = dt.Rows[0]["标题"].ToString().Trim();
            richTextBox备注.Text = dt.Rows[0]["备注"].ToString().Trim();
            dtm截止.Text = Convert.ToDateTime(dt.Rows[0]["截止日期"]).ToString("yyyy-MM-dd");
            lookUpEditTime.EditValue =  Convert.ToDateTime(dt.Rows[0]["截止日期"]).ToString("HH:mm");
            txt终止日期.Text = dt.Rows[0]["终止询价日期"].ToString().Trim();
            dtm单据日期.DateTime = Convert.ToDateTime(dt.Rows[0]["单据日期"]);
            txt制单人.EditValue = dt.Rows[0]["制单人"].ToString().Trim();
            date制单日期.Text = dt.Rows[0]["制单日期"].ToString().Trim();
            txt发布人.EditValue = dt.Rows[0]["发布人"].ToString().Trim();
            date_发布日期.Text = dt.Rows[0]["发布日期"].ToString().Trim();
            if (txt发布人.Text.Trim() != "")
            {
                SetEnbale(true);
            }
            else
            {
                SetEnbale(false);
            }
        }

        private void SetEnbale(bool p)
        {
            txt主题.ReadOnly = p;
            richTextBox备注.ReadOnly = p;
            dtm截止.Properties.ReadOnly = p;
            lookUpEditTime.Properties.ReadOnly = p;
            txt终止日期.Enabled = false;
            dtm单据日期.Properties.ReadOnly = p;
            btnExcel.Enabled = !p;
            btnAddRow.Enabled = !p;
            btnDelRow.Enabled = !p;
            txtVenCode.Enabled = !p;
            btnExExcel.Enabled = true;

            btn保存.Enabled = !p;
            btn删除.Enabled = !p;
         
            txt制单人.Enabled = false;
            txt发布人.Enabled = false;
            date_发布日期.Enabled = false;
            date制单日期.Enabled = false;

            for (int i = 0; i < gridView2.Columns.Count; i++)
            {
                gridView2.Columns[i].OptionsColumn.AllowEdit = !p;
            }
            gridCol_上传附件.OptionsColumn.AllowEdit = true;
            gridCol_下载附件.OptionsColumn.AllowEdit = true;
            gridCol_GUID物料.OptionsColumn.AllowEdit = false;
        }

        private void SetNull()
        {
            label供应商.Text = "";
            txt主题.Text = "";
            richTextBox备注.Text = "";
            dtm截止.DateTime = DateTime.Today;
            dtm单据日期.DateTime = DateTime.Today;
            txt终止日期.Text = "";
            txt制单人.Text = "";
            date制单日期.Text = "";
            txt发布人.Text = "";
            date_发布日期.Text = "";
            labelGUID.Text = "";
            sGuid = "";

            string sSQL = @"
select a.*,b.附件名 as 下载附件 ,cast(null as varchar(200)) as 上传附件
from UFDLImport..询价单物料列表 a left join UFDLImport..询价单附件 b on a.GUID物料 = b.GUID物料
where 1=-1 
order by a.iID
";

            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            gridControl2.DataSource = dt;

            txt主题.Focus();
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                dtm单据日期.DateTime = DateTime.Today;
                dtm截止.DateTime = DateTime.Today;

                SetLookUp();
                if (sGuid == "")
                {
                    SetNull();
                }
                else
                {
                    SetValue();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            }
        }

        private void gridView_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

        private void sSave()
        {
            try
            {
                try
                {
                    gridView2.FocusedRowHandle -= 1;
                    gridView2.FocusedRowHandle += 1;
                }
                catch { }

                string sErr = "";

                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    string s自定义物料 = gridView2.GetRowCellValue(i, gridCol_自定义物料).ToString().Trim();
                    string scInvCode = gridView2.GetRowCellValue(i, gridCol_cInvCode).ToString().Trim();
                    decimal d数量 = ReturnObjectToDecimal(gridView2.GetRowCellValue(i, gridCol_数量), 6);

                    for (int j = i + 1; j < gridView2.RowCount; j++)
                    {
                        string s自定义物料2 = gridView2.GetRowCellValue(j, gridCol_自定义物料).ToString().Trim();
                        string scInvCode2 = gridView2.GetRowCellValue(j, gridCol_cInvCode).ToString().Trim();
                        decimal d数量2 = ReturnObjectToDecimal(gridView2.GetRowCellValue(j, gridCol_数量), 6);

                        if (i == j)
                            continue;

                        if (s自定义物料 == s自定义物料2 && s自定义物料 != "" && d数量 == d数量2)
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "与 行 " + (j + 1) + "自定义物料一样\n";
                            continue;
                        }

                        if (scInvCode == scInvCode2 && scInvCode != "" && d数量 == d数量2)
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "与 行 " + (j + 1) + "物料编码一样\n";
                            continue;
                        }
                    }

                    if (scInvCode.Trim() != "")
                    {
                        string sInvName = gridView2.GetRowCellDisplayText(i, gridCol_cInvName).ToString().Trim();
                        if (sInvName.Trim() == "")
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "物料编码不正确\n";
                            continue;
                        }
                    }
                }

                if (sErr.Length > 0)
                {
                    throw new Exception(sErr);
                }

                if (txt主题.Text.Trim() == "")
                {
                    txt主题.Focus();
                    throw new Exception("主题不能为空");
                }
                if (richTextBox备注.Text.Trim() == "")
                {
                    richTextBox备注.Focus();
                    throw new Exception("备注不能为空");
                }
                if (sGuid == "")
                {
                    sGuid = Guid.NewGuid().ToString();
                }

                DateTime d截止时间 = Convert.ToDateTime(dtm截止.DateTime.ToString("yyyy-MM-dd") + " " + lookUpEditTime.Text + ":00");
                if (dtm截止.DateTime < dtm单据日期.DateTime || d截止时间 < DateTime.Now.AddHours(1))
                {
                    throw new Exception("单据截止时间必须大于当前时间至少一小时");
                }

                string sSQL = "select count(1) from UFDLImport..询价单 where guid = '" + sGuid + "' and isnull(发布人,'') <> ''";
                int iCou = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
                if (iCou > 0)
                    throw new Exception("已经发布不能修改");

                ArrayList aList = new ArrayList();



                sSQL = "delete UFDLImport..询价单物料列表 where guid = '" + sGuid + "'";
                aList.Add(sSQL);


                bool b = false;
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    string sInvCode = gridView2.GetRowCellValue(i, gridCol_cInvCode).ToString().Trim();
                    string sInvCode自定义 = gridView2.GetRowCellValue(i, gridCol_自定义物料).ToString().Trim();
                    if (sInvCode == "" && sInvCode自定义 == "")
                    {
                        sErr = sErr + "行 " + (i + 1).ToString() + " 物料编码不能为空\n";
                        continue;
                    }
                    if (sInvCode != "" && sInvCode自定义 != "")
                    {
                        sErr = sErr + "行 " + (i + 1).ToString() + " 物料编码,自定义物料不能同时存在\n";
                        continue;
                    }

                    b = true;
                    sSQL = @"
insert into UFDLImport..询价单物料列表(GUID, 自定义物料,物料编码, 数量, 送样周期, 备注1, 备注2, 备注3, GUID物料)
values('1111',2222,3333,4444,5555,'6666','7777','8888','9999')
";
                    sSQL = sSQL.Replace("1111", sGuid);

                    if (sInvCode自定义 == "")
                    {
                        sInvCode自定义 = "null";
                    }
                    else
                    {
                        sInvCode自定义 = "'" + sInvCode自定义 + "'";
                    }
                    sSQL = sSQL.Replace("2222", sInvCode自定义);

                    if (sInvCode == "")
                    {
                        sInvCode = "null";
                    }
                    else
                    {
                        sInvCode = "'" + sInvCode + "'";
                    }
                    sSQL = sSQL.Replace("3333", sInvCode);

                    decimal dQty = ReturnObjectToDecimal(gridView2.GetRowCellValue(i, gridCol_数量), 2);
                    if (dQty < 0)
                    {
                        sErr = sErr + "行 " + (i + 1).ToString() + " 数量不能为负数\n";
                        continue;
                    }
                    if (dQty > 0)
                    {
                        sSQL = sSQL.Replace("4444", dQty.ToString());
                    }
                    else
                    {
                        sSQL = sSQL.Replace("4444", "null");
                    }

                    decimal d送样周期 = ReturnObjectToDecimal(gridView2.GetRowCellValue(i, gridCol_送样周期), 2);
                    if (d送样周期 < 0)
                    {
                        sErr = sErr + "行 " + (i + 1).ToString() + " 送样周期不能为负数\n";
                        continue;
                    }
                    if (dQty > 0)
                    {
                        sSQL = sSQL.Replace("5555", d送样周期.ToString());
                    }
                    else
                    {
                        sSQL = sSQL.Replace("5555", "null");
                    }


                    sSQL = sSQL.Replace("6666", gridView2.GetRowCellValue(i, gridCol_备注1).ToString().Trim());
                    sSQL = sSQL.Replace("7777", gridView2.GetRowCellValue(i, gridCol_备注2).ToString().Trim());
                    sSQL = sSQL.Replace("8888", gridView2.GetRowCellValue(i, gridCol_备注3).ToString().Trim());

                    string sGuid物料 = gridView2.GetRowCellValue(i, gridCol_GUID物料).ToString().Trim();
                    if (sGuid物料.Length == 0)
                    {
                        sGuid物料 = Guid.NewGuid().ToString();
                    }
                    sSQL = sSQL.Replace("9999", sGuid物料);
                    aList.Add(sSQL);
                }

                if (!b)
                {
                    throw new Exception("请设置物料");
                }

                sSQL = "delete UFDLImport..询价单供应商 where guid = '" + sGuid + "'";
                aList.Add(sSQL);

                b = false;

                if (label供应商.Text.Trim() == "")
                {
                    throw new Exception("请选择供应商");
                }
                string[] s供应商 = label供应商.Text.Trim().Split(',');
                for (int i = 0; i < s供应商.Length; i++)
                {
                    sSQL = "insert into UFDLImport..询价单供应商(供应商编码,guid)values('" + s供应商[i].Trim() + "','" + sGuid + "')";
                    aList.Add(sSQL);
                    b = true;
                }

                if (!b)
                {
                    throw new Exception("请选择供应商");
                }

                sSQL = "select count(1) from UFDLImport..询价单 where guid = '" + sGuid + "'";
                iCou = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
                if (iCou == 0)
                {
                    sSQL = "insert into UFDLImport..询价单(标题,备注,制单人,制单日期,单据日期,截止日期,guid,部门)values('" + txt主题.Text.Trim() + "','" + richTextBox备注.Text.Trim() + "','" + FrameBaseFunction.ClsBaseDataInfo.sUid + "','" + DateTime.Today.ToString("yyyy-MM-dd") + "','" + dtm单据日期.DateTime.ToString("yyyy-MM-dd") + "','" + dtm截止.DateTime.ToString("yyyy-MM-dd") + " " + lookUpEditTime.Text.Trim() + "','" + sGuid + "','" + sDepCode + "')";
                    aList.Add(sSQL);
                }
                else
                {
                    sSQL = "update UFDLImport..询价单 set 截止日期 = '" + dtm截止.DateTime.ToString("yyyy-MM-dd") + " " + lookUpEditTime.Text.Trim() + "',标题 = '" + txt主题.Text.Trim() + "',备注 = '" + richTextBox备注.Text.Trim() + "',制单人 = '" + FrameBaseFunction.ClsBaseDataInfo.sUid + "',制单日期 = '" + DateTime.Today.ToString("yyyy-MM-dd") + "' where guid = '" + sGuid + "'";
                    aList.Add(sSQL);
                }


                if (sErr.Length > 0)
                {
                    throw new Exception(sErr);
                }

                if (aList.Count > 1)
                {
                    clsSQLCommond.ExecSqlTran(aList);

                    sErr = "";
                    for (int i = 0; i < gridView2.RowCount; i++)
                    {
                        try
                        {
                            string sFile = "";
                            try
                            {
                                sFile = gridView2.GetRowCellValue(i, gridCol_上传附件).ToString().Trim();
                            }
                            catch { }
                            if (sFile != "")
                            {
                                string sGUID物料 = gridView2.GetRowCellValue(i, gridCol_GUID物料).ToString().Trim();
                                bool b上传 = 上传附件(sFile, sGUID物料);
                                if (!b上传)
                                {
                                    throw new Exception("");
                                }
                            }
                        }

                        catch (Exception ee)
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "上传附件失败\n";
                        }
                    }

                    MessageBox.Show("保存成功");
                    if (sErr.Length > 0)
                    {
                        MessageBox.Show(sErr, "上传附件失败");
                    }

                    SetValue();
                }
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }

        private void btn保存_Click(object sender, EventArgs e)
        {
            try
            {
                sSave();
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "提示";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        private void btn删除_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView2.FocusedRowHandle -= 1;
                    gridView2.FocusedRowHandle += 1;
                }
                catch { }

                sGuid = labelGUID.Text.Trim();
                if (sGuid.Length == 0)
                {
                    throw new Exception("没有选择需要删除的数据");
                }

                ArrayList aList = new ArrayList();
                string sSQL = "select count(1) from UFDLImport..询价单 where guid = '" + sGuid + "' and isnull(发布人,'') <> ''";
                int iCou = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
                if (iCou > 0)
                {
                    throw new Exception("单据已经发布，不能删除");
                }

                sSQL = "delete UFDLImport..询价单物料列表 where guid = '" + sGuid + "'";
                aList.Add(sSQL);

                sSQL = "delete UFDLImport..询价单供应商 where guid = '" + sGuid + "'";
                aList.Add(sSQL);

                sSQL = "delete UFDLImport..询价单附件 where guid = '" + sGuid + "'";
                aList.Add(sSQL);

                sSQL = "delete UFDLImport..询价单 where guid = '" + sGuid + "'";
                aList.Add(sSQL);

                
                if (aList.Count > 0)
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("删除成功");

                    SetNull();
                }
                else
                {
                    MessageBox.Show("没有选择需要删除的数据");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btn发布_Click(object sender, EventArgs e)
        {
            try
            {

                try
                {
                    gridView2.FocusedRowHandle -= 1;
                    gridView2.FocusedRowHandle += 1;
                }
                catch { }

                sSave();

                string sSQL = "select * from UFDLImport..询价单 where [GUID] = '" + sGuid + "'";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt == null || dt.Rows.Count == 0)
                {
                    throw new Exception("获得询价单失败");
                }
                if (dt.Rows[0]["发布人"].ToString().Trim() != "")
                {
                    throw new Exception("已经发布");
                }

                sSQL = "update UFDLImport..询价单 set 发布人 = '" + FrameBaseFunction.ClsBaseDataInfo.sUid + "',发布日期 = '" + DateTime.Today.ToString("yyyy-MM-dd") + "' where guid = '" + sGuid + "'";

                clsSQLCommond.ExecSql(sSQL);
                MessageBox.Show("发布成功");

                try
                {
                    string[] s供应商 = label供应商.Text.Trim().Split(',');
                    for (int i = 0; i < s供应商.Length; i++)
                    {
                        sSQL = "select sEMail from UFDLImport.._vendUid where vendcode = '" + s供应商[i] + "' and isnull(sEMail,'') <> '' order by AccYear desc";
                        dt = clsSQLCommond.ExecQuery(sSQL);
                        if (dt != null && dt.Rows.Count > 0 && dt.Rows[0][0].ToString().Trim() != "")
                        {
                            SendMail(dt.Rows[0][0].ToString().Trim(), "报价单", "询价单" + labeliID .Text + "已经发布请尽快报价");
                        }
                    }
                }
                catch { }

                this.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }



        /// <summary>
        /// 发送邮件
        /// </summary>
        private void SendMail(string sAdd, string sSub, string sText)
        {
            try
            {
                ClseMail clseMail = new ClseMail();
                clseMail.MailSend(sAdd, sSub, sText);
            }
            catch (Exception ee)
            {
                throw new Exception("邮件发送失败！ " + ee.Message);
            }
        }

        private void btn取消_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView2.FocusedRowHandle -= 1;
                    gridView2.FocusedRowHandle += 1;
                }
                catch { }

                string sSQL = "select * from UFDLImport..询价单 where [GUID] = '" + sGuid + "'";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt == null || dt.Rows.Count == 0)
                {
                    throw new Exception("获得询价单失败");
                }
                if (dt.Rows[0]["发布人"].ToString().Trim() == "")
                {
                    throw new Exception("尚未发布");
                }

                sSQL = "select * from UFDLImport..询价单供应商报价 where [GUID] = '@guid'";
                sSQL = sSQL.Replace("@guid", sGuid);
                dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt != null && dt.Rows.Count > 0)
                {
                    throw new Exception("已有供应商提交报价，不能取消");
                }


                sSQL = "update UFDLImport..询价单 set 发布人 = null,发布日期 = null where guid = '" + sGuid + "'";

                clsSQLCommond.ExecSql(sSQL);
                MessageBox.Show("取消发布成功");

                SetEnbale(false);

                txt发布人.Text = "";
                date_发布日期.Text = "";
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btn退出_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void ItemButtonEdit上传附件_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                OpenFileDialog oFile = new OpenFileDialog();
                oFile.Filter = "附件|*.*";
                if (oFile.ShowDialog() == DialogResult.OK)
                {
                    string sFilePath = oFile.FileName;

                    if (!File.Exists(sFilePath))
                    {
                        throw new Exception("文件不存在");
                    }

                    gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridCol_上传附件, sFilePath);
                    //上传附件(sFilePath);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private bool 上传附件(string sFilePath,string sGuid物料)
        {
            bool b = false;
            using (SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandTimeout = 3600;
                cmd.Connection = conn;
                SqlTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;

                try
                {
                    string[] sName = sFilePath.Split('\\');
                    string sFileName = sName[sName.Length - 1];

                    FileInfo fi = new FileInfo(sFilePath);
                    FileStream fs = fi.OpenRead();
                    byte[] bytes = new byte[fs.Length];
                    fs.Read(bytes, 0, Convert.ToInt32(fs.Length));

                    string sSQL = @"
if exists(select * from UFDLImport..询价单附件 where GUID物料 = '@GUID物料' and [GUID] = '@GUID')
	update UFDLImport..询价单附件  set 附件 = @file,上传人 = '@上传人',上传日期 = GETDATE() ,附件名 = N'@附件名'
    where GUID物料 = '@GUID物料' and [GUID] = '@GUID'
else
	insert into UFDLImport..询价单附件(GUID, 附件, 上传人, 上传日期, GUID物料,附件名)
	values('@GUID',@file,'@上传人',GETDATE(),'@GUID物料',N'@附件名')
";
                    sSQL = sSQL.Replace("@GUID物料", sGuid物料);
                    sSQL = sSQL.Replace("@GUID", sGuid);
                    sSQL = sSQL.Replace("@上传人", FrameBaseFunction.ClsBaseDataInfo.sUid);
                    sSQL = sSQL.Replace("@附件名", sFileName);

                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sSQL;
                    SqlParameter spFile = new SqlParameter("@file", SqlDbType.Image);
                    spFile.Value = bytes;
                    cmd.Parameters.Add(spFile);
                    int iCou = cmd.ExecuteNonQuery();

                    tx.Commit();

                    gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridCol_下载附件, sFileName);

                    if (iCou > 0)
                    {
                        b = true;
                    }
                    fs = null;
                    fi = null;
                    bytes = null;
                }
                catch (System.Data.SqlClient.SqlException E)
                {
                    tx.Rollback();
                    throw new Exception(E.Message);
                }
                return b;
            }
        }

        private void ItemButtonEdit下载附件_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                string sSQL = @"
select * from UFDLImport..询价单附件 where GUID物料 = '@GUID物料' and [GUID] = '@GUID'
";
                sSQL = sSQL.Replace("@GUID物料", gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridCol_GUID物料).ToString().Trim());
                sSQL = sSQL.Replace("@GUID", sGuid);
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt == null || dt.Rows.Count == 0)
                {
                    throw new Exception("附件不存在");
                }


                SaveFileDialog oFile = new SaveFileDialog();
                oFile.Filter = "附件|*.*";
                oFile.FileName = dt.Rows[0]["附件名"].ToString().Trim();
               
                if (oFile.ShowDialog() == DialogResult.OK)
                {
                    string sFilePath = oFile.FileName;

                    FileInfo fi = new FileInfo(sFilePath);
                    string[] sName = sFilePath.Split('\\');
                    string sFileName = sName[sName.Length - 1];
                    Byte[] b = (byte[])dt.Rows[0]["附件"];
                    writePic(b, sFilePath);
                    MessageBox.Show("下载成功");

                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        public void writePic(byte[] pics, string sPath)
        {
            FileStream fs = new FileStream(sPath, FileMode.Append, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(pics, 0, pics.Length);
            bw.Close();
            fs.Close();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog oFile = new OpenFileDialog();
                oFile.Filter = "Excel文件2003|*.xls|Excel文件2007|*.xlsx";
                if (oFile.ShowDialog() == DialogResult.OK)
                {
                    string sFilePath = oFile.FileName;
                    string sSQL = "select * from [报价单$]";

                    DataTable dtExcel = ExcelToDT(sFilePath, sSQL, true);
                    DataColumn dc = new DataColumn();
                    dc.ColumnName = "GUID物料";
                    dtExcel.Columns.Add(dc);

                    for (int i = 0; i < dtExcel.Rows.Count; i++)
                    {
                        Guid g = Guid.NewGuid();
                        dtExcel.Rows[i]["GUID物料"] = g.ToString();

                        string sInvCode = dtExcel.Rows[i]["物料编码"].ToString().Trim();
                        if (sInvCode == "")
                        {
                            continue;
                        }

                        DataTable dtInv = (DataTable)ItemLookUpEdit_cInvName.DataSource;
                        DataRow[] dr = dtInv.Select("cInvCode = '" + sInvCode + "'");
                        if (dr.Length > 0)
                        {
                            sInvCode = dr[0]["cInvCode"].ToString().Trim();
                            dtExcel.Rows[i]["物料编码"] = sInvCode;
                        }
                    }

                    gridControl2.DataSource = dtExcel;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void SetLookUp()
        {
            string sSQL = "select cInvCode,cInvName,cInvStd from @u8.Inventory order by cInvCode";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            DataRow dr2 = dt.NewRow();
            dt.Rows.InsertAt(dr2, 0);

            ItemLookUpEdit_cInvName.DataSource = dt;
            ItemLookUpEdit_cInvStd.DataSource = dt;

            dt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "Time";
            dt.Columns.Add(dc);

            for (int i = 0; i < 24; i++)
            {
                DataRow dr = dt.NewRow();

                string sHour = i.ToString();
                while (sHour.Length < 2)
                {
                    sHour = "0" + sHour;
                }

                dr["Time"] = sHour + ":00";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Time"] = sHour + ":30";
                dt.Rows.Add(dr);
            }
            lookUpEditTime.Properties.DataSource = dt;
            lookUpEditTime.EditValue = "16:30";

            sSQL = "select  vchrUid, vchrName from _UserInfo order by vchrUid";
            dt = clsSQLCommond.ExecQuery(sSQL);
            txt制单人.Properties.DataSource = dt;
            txt发布人.Properties.DataSource = dt;
        }


        private decimal ReturnObjectToDecimal(object o, int iL)
        {
            decimal i = 0;
            try
            {
                i = Convert.ToDecimal(o);
                i = decimal.Round(i, iL);
            }
            catch { }
            return i;
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            try
            {
                gridView2.AddNewRow();
            }
            catch { }
        }

        private void btnDelRow_Click(object sender, EventArgs e)
        {
            try
            {
                gridView2.DeleteRow(gridView2.FocusedRowHandle);
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "提示";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        private void gridView2_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
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

        private void gridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                string s1 = gridView2.GetRowCellValue(e.RowHandle, gridCol_cInvCode).ToString().Trim();
                string s2 = gridView2.GetRowCellValue(e.RowHandle, gridCol_自定义物料).ToString().Trim();
                if (s1 != "" || s2 != "")
                {
                    string sGuid = gridView2.GetRowCellValue(e.RowHandle, gridCol_GUID物料).ToString().Trim();
                    if (sGuid == "")
                    {
                        Guid g = Guid.NewGuid();
                        gridView2.SetRowCellValue(e.RowHandle, gridCol_GUID物料, g.ToString());
                    }
                }
            }
            catch { }
        }

        private void ItemButtonEditcInvCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                try
                {
                    gridView2.FocusedColumn = gridCol_GUID物料;
                    gridView2.FocusedColumn = gridCol_cInvCode;
                }
                catch { }

                string sInvCode = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridCol_cInvCode).ToString().Trim();
                FrmInvInfo fInv = new FrmInvInfo(sInvCode);
                if (DialogResult.OK == fInv.ShowDialog())
                {
                    gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridCol_cInvCode, fInv.sInvCode);
                    //gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridCol_cInvName, fInv.sInvName);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        /// <summary>
        /// 读取Excel转换为DataTable
        /// </summary>
        /// <param name="Path">路径</param>
        /// <param name="sSQL">读取Excel的查询语句 如：select * from [Sheet1$]</param>
        /// <param name="bIsTitle">Excel第一行是否标题</param>
        /// <returns>DataTable</returns>
        public DataTable ExcelToDT(string Path, string sSQL, bool bIsTitle)
        {
            try
            {
                ArrayList arrList = new ArrayList();
                arrList.Add(sSQL);
                DataSet ds = ExcelToDS(Path, arrList, bIsTitle);

                if (ds == null || ds.Tables.Count < 1)
                    return null;
                else
                    return ds.Tables[0];
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }

        /// <summary>
        /// 读取Excel转换为DataSet
        /// </summary>
        /// <param name="Path">路径</param>
        /// <param name="arrList">读取Excel的查询语句ArrayList; 如：select * from [Sheet1$]</param>
        /// <param name="bIsTitle">Excel第一行是否标题</param>
        /// <returns>DataSet</returns>
        public DataSet ExcelToDS(string Path, ArrayList arrList, bool bIsTitle)
        {
            try
            {
                string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Extended Properties=\"excel 8.0;hdr=1;imex=1;Persist Security Info=false;Mode=Share Deny Read\";" + "data source=" + Path;
                if (Path.ToLower().IndexOf("xlsx") > 0)
                {
                    strConn = "Provider=Microsoft.ACE.OLEDB.12.0; Persist Security Info=False;Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1'; data source=" + Path + "";
                }

                //if (bIsTitle)
                //    strConn += "HDR=YES;'";
                //else
                //    strConn += "HDR=NO;'";

                OleDbConnection conn = new OleDbConnection(strConn);
                conn.Open();

                string strExcel = "";
                OleDbDataAdapter myCommand = new OleDbDataAdapter(strExcel, strConn);
                DataSet ds = new DataSet();

                for (int i = 0; i < arrList.Count; i++)
                {
                    strExcel = arrList[i].ToString();
                    myCommand.SelectCommand.CommandText = strExcel;
                    myCommand.Fill(ds, "dt" + i.ToString());
                }

                if (ds == null || ds.Tables.Count < 1)
                    return null;
                else
                    return ds;
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }

        private void txtVenCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                FrmVendorInfo fVen = new FrmVendorInfo(txtVenCode.Text.Trim(), true);
                if (DialogResult.OK == fVen.ShowDialog())
                {
                    txtVenCode.Text = fVen.sVenCode;
                    txtVenName.Text = fVen.sVenName;

                    label供应商.Text = fVen.sVenCode;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载供应商失败");
            }
        }

        private void btnExExcel_Click(object sender, EventArgs e)
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
                    gridView2.ExportToXls(sF.FileName);
                    MessageBox.Show("导出Excel成功\n\t路径：" + sF.FileName);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}