using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using 系统服务;
using System.Data.SqlClient;

namespace 成衣生产
{
    public partial class Frm完工入库_New : Form
    {
        protected 系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
        protected 系统服务.ClsGetSQL clsGetSQL = 系统服务.ClsGetSQL.Instance();
        public DataTable dt;
        DataTable dthas;
        public Frm完工入库_New(DataTable sdthas)
        {
           
            InitializeComponent();
            dthas = sdthas;
        }

        public Frm完工入库_New()
        {
            InitializeComponent();

            #region 禁止用户调整表格

            layoutControl1.AllowCustomizationMenu = false;

            //gridView1.OptionsMenu.EnableColumnMenu = false;
            //gridView1.OptionsMenu.EnableFooterMenu = false;
            //gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            //gridView1.OptionsMenu.ShowAutoFilterRowItem = false;
            //gridView1.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            //gridView1.OptionsMenu.ShowGroupSortSummaryItems = false;
            //gridView1.OptionsMenu.ShowGroupSummaryEditorItem = false;
            //gridView1.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.False;
            //gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            //gridView1.OptionsCustomization.AllowColumnMoving = false;
            //gridView1.OptionsCustomization.

            #endregion
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm完工入库_New_Load(object sender, EventArgs e)
        {
            try
            {

                SetLookUpEdit();
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败：" + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void GetGrid()
        {
            string sSQL = "";
            sSQL = @"select a.*,cast(0 as bit) as iChk ,isnull(a.数量,0)-isnull(b.入库数量,0) as 未入库数量,a.iID as 生产计划iID from 生产计划 a 
left join (select 生产计划iID,sum(数量) as 入库数量 from 成品出入库 where 出入库类别='01' group by 生产计划iID) b on a.iID=b.生产计划iID  where isnull(a.数量,0)-isnull(b.入库数量,0) > 0 and a.审核人 is not null   ";

            if (txt客户.EditValue != null && txt客户.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL + " and a.客户 like '%" + txt客户.EditValue.ToString().Trim() + "%'";
            }
            if (dateEdit单据日期1.EditValue!=null && dateEdit单据日期1.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL + " and a.日期 >= '" + dateEdit单据日期1.EditValue.ToString().Trim() + "'";
            }
            if (dateEdit单据日期2.EditValue!=null && dateEdit单据日期2.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL + " and a.日期<='" + dateEdit单据日期2.EditValue.ToString().Trim() + "'";
            }
            
            
            sSQL = sSQL + " order by  a.iID";
            dt = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dt;
        }

        public void Get(string 单据日期1, string 单据日期2, string 客户)
        {
            if (单据日期1 != null && 单据日期1 != "")
            {
                单据日期1 = DateTime.Parse(单据日期1).ToString("yyyy-MM-dd");
                dateEdit单据日期1.EditValue = 单据日期1;
            }
            if (单据日期2 != null && 单据日期2 != "")
            {
                单据日期2 = DateTime.Parse(单据日期2).ToString("yyyy-MM-dd");
                dateEdit单据日期2.EditValue = 单据日期2;
            }
            txt客户.EditValue = 客户;
        }

        private void SetLookUpEdit()
        {
            DbHelperSQL.connectionString = 系统服务.ClsBaseDataInfo.sConnString;

            系统服务.LookUp._LoopUpData(ItemLookUpEdit类别, "30");

            string sSQL = @"SELECT distinct 款号 FROM [dbo].[尺码信息] ORDER BY 款号";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit款号.Properties.DataSource = dt;

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
            ItemLookUpEdit生产.Properties.DataSource = dt;

            sSQL = "select cCode,cName from 纱种 order by cCode";
            dt = DbHelperSQL.Query(sSQL);
            ItemLookUpEdit纱种.Properties.DataSource = dt;

        }

        private void btnEnsure_Click(object sender, EventArgs e)
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

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

                    DataTable dt = (DataTable)gridControl1.DataSource;
                    string sErrRow = "";
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (!ReturnBool(dt.Rows[i]["iChk"]))
                            continue;

                        DataRow dr = dt.Rows[i];
                        Model.成品出入库 model = new 成衣生产.Model.成品出入库();
                        DAL.成品出入库 dal = new 成衣生产.DAL.成品出入库();

                        model.制单人 = 系统服务.ClsBaseDataInfo.sUserName;
                        model.制单日期 = DateTime.Now;
                        model.单据日期 = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                        model.生产计划iID = ReturnInt(dt.Rows[i]["生产计划iID"]);
                        model.客户 = dt.Rows[i]["客户"].ToString();
                        model.款号 = dt.Rows[i]["款号"].ToString();
                        model.类别 = dt.Rows[i]["类别"].ToString();
                        model.纱种 = dt.Rows[i]["纱种"].ToString();
                        model.生产 = dt.Rows[i]["生产"].ToString();
                        model.数量 = ReturnDecimal(dt.Rows[i]["未入库数量"]);

                        if (model.客户.Trim() == "")
                        {
                            sErrRow = sErrRow + "行" + (i + 1).ToString() + "客户不能为空\n";
                        }
                        if (model.生产.Trim() == "")
                        {
                            sErrRow = sErrRow + "行" + (i + 1).ToString() + "生产不能为空\n";
                        }
                        if (model.类别.Trim() == "")
                        {
                            sErrRow = sErrRow + "行" + (i + 1).ToString() + "类别不能为空\n";
                        }
                        if (model.款号.Trim() == "")
                        {
                            sErrRow = sErrRow + "行" + (i + 1).ToString() + "款号不能为空\n";
                        }
                        if (model.纱种.Trim() == "")
                        {
                            sErrRow = sErrRow + "行" + (i + 1).ToString() + "纱种不能为空\n";
                        }
                        if (ReturnDateTimeString(model.单据日期) == "")
                        {
                            sErrRow = sErrRow + "行" + (i + 1).ToString() + "单据日期不能为空\n";
                        }
                        if (ReturnDecimal(model.数量) == 0)
                        {
                            sErrRow = sErrRow + "行" + (i + 1).ToString() + "请填写数量\n";
                        }

                        sSQL = "select sum(数量) from 生产计划 where 1=1 and iID='" + model.生产计划iID + "'";
                        decimal 生产计划数量 = ReturnDecimal(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);

                        sSQL = "select sum(数量) from 成品出入库 where 1=1 and 生产计划iID='" + model.生产计划iID + "' and iID<>" + model.iID + "";
                        decimal 已入库数量 = ReturnDecimal(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
                        if (生产计划数量 - 已入库数量 < ReturnDecimal(model.数量))
                        {
                            sErrRow = sErrRow + "行" + (i + 1).ToString() + "生产计划数量不足，当前可完工数量" + (生产计划数量 - 已入库数量) + "\n";
                        }

                        if (sErrRow != "")
                        {
                            sErr = sErr + sErrRow;
                            continue;
                        }

                        
                        sSQL = dal.Add(model);
                        iCount = iCount + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    }
                    if (sErr != "")
                    {
                        throw new Exception(sErr);
                    }
                    if (iCount > 0)
                    {
                        tran.Commit();

                        MessageBox.Show("OK\n");

                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                    else
                    {
                        throw new Exception(sErrRow);
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
            //try
            //{
            //    if (gridView1.RowCount < 1)
            //        return;

            //    for (int i = dt.Rows.Count - 1; i >= 0; i--)
            //    {
            //        if (dt.Rows[i]["iChk"] != "√")
            //        {
            //            dt.Rows.Remove(dt.Rows[i]);
            //        }
            //    }
            //    this.DialogResult = System.Windows.Forms.DialogResult.OK;
            //}
            //catch (Exception ee)
            //{
            //    MessageBox.Show(ee.Message);
            //}
        }

        private void button查询_Click(object sender, EventArgs e)
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

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.IsRowSelected(i))
                {
                    if (gridView1.GetRowCellValue(i, gridCol选择) == "")
                    {
                        gridView1.SetRowCellValue(i, gridCol选择, "√");
                    }
                    else
                    {
                        gridView1.SetRowCellValue(i, gridCol选择, "");
                    }
                }
            }
        }

        protected long ReturnLong(object o)
        {
            long d = 0;
            try
            {
                d = Convert.ToInt64(o);
            }
            catch { }
            return d;
        }

        protected bool ReturnBool(object o)
        {
            bool b = false;
            try
            {
                b = Convert.ToBoolean(o);
            }
            catch { }
            return b;
        }

        protected decimal ReturnDecimal(object o)
        {
            decimal d = 0;
            try
            {
                d = decimal.Round(Convert.ToDecimal(o), 6);
            }
            catch { }
            return d;
        }
        protected decimal ReturnDecimal(object o, int iLength)
        {
            decimal d = 0;
            try
            {
                d = decimal.Round(Convert.ToDecimal(o), iLength);
            }
            catch { }
            return d;
        }


        protected int ReturnInt(object o)
        {
            int d = 0;
            try
            {
                d = Convert.ToInt32(o);
            }
            catch { }
            return d;
        }

        protected string ReturnDateTimeString(object o)
        {
            string d = "";
            try
            {
                if (Convert.ToDateTime(o) >= Convert.ToDateTime("1900-01-01"))
                {
                    d = Convert.ToDateTime(o).ToString("yyyy-MM-dd");
                }
            }
            catch { }
            return d;
        }
    }
}
