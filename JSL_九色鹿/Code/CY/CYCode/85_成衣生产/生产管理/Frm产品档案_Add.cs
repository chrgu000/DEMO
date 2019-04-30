using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;
using System.Data.SqlClient;
using 系统服务;

namespace 成衣生产
{
    public partial class Frm产品档案_Add : Form
    {

        public Frm产品档案_Add()
        {
            InitializeComponent();
        }

        private void Frm产品档案_Add_Load(object sender, EventArgs e)
        {
            try
            {
                SetLookup();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败");
            }
        }

        private void SetLookup()
        {
            //string sSQL = "SELECT * FROM [dbo].[成衣类别] ORDER BY cCode ";
            //DbHelperSQL.connectionString = 系统服务.ClsBaseDataInfo.sConnString;
            //DataTable dt = DbHelperSQL.Query(sSQL);
            //lookUpEdit类别.Properties.DataSource = dt;

            string sSQL = @"
SELECT distinct 款号 FROM [dbo].[尺码信息] ORDER BY 款号
";
            DbHelperSQL.connectionString = 系统服务.ClsBaseDataInfo.sConnString;
            DataTable dt = DbHelperSQL.Query(sSQL);
            lookUpEdit款号.Properties.DataSource = dt;

            sSQL = "select cCode,cName from 纱种 order by cCode";
            dt = DbHelperSQL.Query(sSQL);
            lookUpEdit纱种.Properties.DataSource = dt;

            dt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "cCode";
            dt.Columns.Add(dc);
            DataRow dr = dt.NewRow();
            dr["cCode"] = "工厂";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["cCode"] = "生产门店";
            dt.Rows.Add(dr);
            lookUpEdit生产.Properties.DataSource = dt;

            sSQL = "SELECT * FROM dbo.ColorNo ORDER BY cCNCode";
            dt = DbHelperSQL.Query(sSQL);
            dr = dt.NewRow();
            dt.Rows.IndexOf(dr);
            lookUpEdit配色1.Properties.DataSource = dt;
            lookUpEdit配色2.Properties.DataSource = dt;
            lookUpEdit配色3.Properties.DataSource = dt;
            lookUpEdit配色4.Properties.DataSource = dt;
            lookUpEdit配色5.Properties.DataSource = dt;
            lookUpEdit主色.Properties.DataSource = dt;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                string sErr = "";
                int iCount = 0;
                SqlConnection conn = new SqlConnection(系统服务.ClsBaseDataInfo.sConnString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                string sSQL = "";
                try
                {
                    if (txt编码.Text.Trim() == "")
                    {
                        txt编码.Focus();
                        throw new Exception("编码不能为空");
                    }
                 
                    if (lookUpEdit款号.Text.Trim() == "")
                    {
                        lookUpEdit款号.Focus();
                        throw new Exception("款号不能为空");
                    }
                   
                    if (lookUpEdit生产.Text.Trim() == "")
                    {
                        lookUpEdit生产.Focus();
                        throw new Exception("生产不能为空");
                    }
                    if (lookUpEdit纱种.Text.Trim() == "")
                    {
                        lookUpEdit纱种.Focus();
                        throw new Exception("纱种不能为空");
                    }
                    if (lookUpEdit主色.Text.Trim() == "")
                    {
                        lookUpEdit主色.Focus();
                        throw new Exception("主色不能为空");
                    }

                    sSQL = @"
SELECT iID,款号, 身高L, 身高T, 体重L, 体重T, 胸围L, 胸围T, 胸围杯型L, 胸围杯型T, 身长L, 身长T, 肩宽L, 肩宽T, 
                袖长L, 袖长T
FROM [dbo].[尺码信息] 
WHERE 1=1
ORDER BY 款号, 身高L, 身高T, 体重L, 体重T, 胸围L, 胸围T, 胸围杯型L, 胸围杯型T, 身长L, 身长T, 肩宽L, 肩宽T, 
                袖长L, 袖长T
";
                    sSQL = sSQL.Replace("1=1", "1=1 and 款号='" + lookUpEdit款号.EditValue.ToString().Trim() + "'");
                    DataTable dt尺码 = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt尺码 == null || dt尺码.Rows.Count == 0)
                    {
                        throw new Exception("请设置尺码信息");
                    }

                    sSQL = "SELECT * FROM [产品档案] WHERE 编码 = '" + txt编码.Text.Trim() + "' ";
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        throw new Exception("该编码已存在");
                    }
                    for (int i = 0; i < dt尺码.Rows.Count; i++)
                    {

                        Model.产品档案 model = new 成衣生产.Model.产品档案();
                        model.尺码信息iID =ReturnInt(dt尺码.Rows[i]["iID"]);
                        model.编码 = txt编码.Text.Trim();
                        model.款号 = lookUpEdit款号.EditValue.ToString().Trim();
                        model.纱种 = lookUpEdit纱种.EditValue.ToString().Trim();
                        model.针型 = txt针型.Text.Trim();
                        model.生产 = lookUpEdit生产.EditValue.ToString().Trim();

                        model.身高L = ReturnDecimal(dt尺码.Rows[i]["身高L"]);
                        model.身高T = ReturnDecimal(dt尺码.Rows[i]["身高T"]);
                        model.体重L = ReturnDecimal(dt尺码.Rows[i]["体重L"]);
                        model.体重T = ReturnDecimal(dt尺码.Rows[i]["体重T"]);
                        model.胸围L = ReturnDecimal(dt尺码.Rows[i]["胸围L"]);
                        model.胸围T = ReturnDecimal(dt尺码.Rows[i]["胸围T"]);
                        model.胸围杯型L = ReturnDecimal(dt尺码.Rows[i]["胸围杯型L"]);
                        model.胸围杯型T = ReturnDecimal(dt尺码.Rows[i]["胸围杯型T"]);
                        model.身长L = ReturnDecimal(dt尺码.Rows[i]["身长L"]);
                        model.身长T = ReturnDecimal(dt尺码.Rows[i]["身长T"]);
                        model.肩宽L = ReturnDecimal(dt尺码.Rows[i]["肩宽L"]);
                        model.肩宽T = ReturnDecimal(dt尺码.Rows[i]["肩宽T"]);
                        model.袖长L = ReturnDecimal(dt尺码.Rows[i]["袖长L"]);
                        model.袖长T = ReturnDecimal(dt尺码.Rows[i]["袖长T"]);

                        model.腰围L = ReturnDecimal(txt腰围.Text.Trim());
                        model.腰围T = ReturnDecimal(txt腰围T.Text.Trim());

                        model.下摆宽L = ReturnDecimal(txt下摆款.Text.Trim());
                        model.下摆宽T = ReturnDecimal(txt下摆款T.Text.Trim());

                        model.领形 = txt领型.Text.Trim();
                        model.领深L = ReturnDecimal(txt领深.Text.Trim());
                        model.领深T = ReturnDecimal(txt领深T.Text.Trim());

                        model.定制加工费 = ReturnDecimal(txt定制加工费.Text.Trim());
                        model.VIP加工费 = ReturnDecimal(txtVIP加工费.Text.Trim());

                        model.主色 = lookUpEdit主色.EditValue.ToString().Trim();
                        if (lookUpEdit配色1.EditValue != null)
                        {
                            model.配色1 = lookUpEdit配色1.EditValue.ToString().Trim();
                        }
                        if (lookUpEdit配色2.EditValue != null)
                            model.配色2 = lookUpEdit配色2.EditValue.ToString().Trim();
                        if (lookUpEdit配色3.EditValue != null)
                            model.配色3 = lookUpEdit配色3.EditValue.ToString().Trim();
                        if (lookUpEdit配色4.EditValue != null)
                            model.配色4 = lookUpEdit配色4.EditValue.ToString().Trim();
                        if (lookUpEdit配色5.EditValue != null)
                            model.配色5 = lookUpEdit配色5.EditValue.ToString().Trim();

                        if (txt主色纱用量.Text.Trim() != "")
                        {
                            model.主色用纱量 = ReturnDecimal(txt主色纱用量.Text.Trim());
                        }
                        if (txt配色1用量.Text.Trim() != "")
                        {
                            model.配色1用纱量 = ReturnDecimal(txt配色1用量.Text.Trim());
                        }
                        if (txt配色2用量.Text.Trim() != "")
                        {
                            model.配色2用纱量 = ReturnDecimal(txt配色2用量.Text.Trim());
                        }
                        if (txt配色3用量.Text.Trim() != "")
                        {
                            model.配色3用纱量 = ReturnDecimal(txt配色3用量.Text.Trim());
                        }
                        if (txt配色4用量.Text.Trim() != "")
                        {
                            model.配色4用纱量 = ReturnDecimal(txt配色4用量.Text.Trim());
                        }
                        if (txt配色5用量.Text.Trim() != "")
                        {
                            model.配色5用纱量 = ReturnDecimal(txt配色5用量.Text.Trim());
                        }
                        
                        model.制单人 = ClsBaseDataInfo.sUid;
                        model.制单日期 = DateTime.Now;

                        DAL.产品档案 dal = new 成衣生产.DAL.产品档案();
                        sSQL = dal.Add(model);
                        iCount += DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    if (iCount > 0)
                    {
                        tran.Commit();
                        MessageBox.Show("新增成功");
                        this.DialogResult = DialogResult.Yes;
                    }
                    else
                    {
                        throw new Exception("没有数据");
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
                FrmMsgBox msgbox = new FrmMsgBox();
                msgbox.richTextBox1.Text = ee.Message;
                msgbox.Text = "提示";
                msgbox.ShowDialog();
            }
        }


        private void SetTxtNull()
        {
            txt编码.Text = "";
            lookUpEdit款号.EditValue = null;
            lookUpEdit生产.EditValue = null;
            lookUpEdit纱种.EditValue = null;
            txt腰围.Text = "";
            txt针型.Text = "";
            txt领型.Text = "";
            txt领深.Text = "";
            txt定制加工费.Text = "";
            txtVIP加工费.Text = "";
            lookUpEdit主色.EditValue = null;
            lookUpEdit配色1.EditValue = null;
            lookUpEdit配色2.EditValue = null;
            lookUpEdit配色3.EditValue = null;
            lookUpEdit配色4.EditValue = null;
            lookUpEdit配色5.EditValue = null;

            txt主色纱用量.Text = "";
            txt配色1用量.Text = "";
            txt配色2用量.Text = "";
            txt配色3用量.Text = "";
            txt配色4用量.Text = "";
            txt配色5用量.Text = "";

            txt用纱合计.Text = "";
        }

        private decimal ReturnDecimal(object o)
        {
            decimal d = 0;
            try
            {
                d = Convert.ToDecimal(o);
            }
            catch { }
            return d;
        }

        private int ReturnInt(object o)
        {
            Int32 d = 0;
            try
            {
                d = Convert.ToInt32(o);
            }
            catch { }
            return d;
        }

        private void lookUpEdit色纱用量合计_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                decimal d = ReturnDecimal(txt主色纱用量.Text.Trim());
                decimal d1 = ReturnDecimal(txt配色1用量.Text.Trim());
                decimal d2 = ReturnDecimal(txt配色2用量.Text.Trim());
                decimal d3 = ReturnDecimal(txt配色3用量.Text.Trim());
                decimal d4 = ReturnDecimal(txt配色4用量.Text.Trim());
                decimal d5 = ReturnDecimal(txt配色5用量.Text.Trim());

                txt用纱合计.Text = (d + d1 + d2 + d3 + d4 + d5).ToString();
            }
            catch { }
        }
    }
}