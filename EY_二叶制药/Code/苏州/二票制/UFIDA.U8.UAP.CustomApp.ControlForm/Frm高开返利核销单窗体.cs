using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TH.BaseClass;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class Frm高开返利核销单窗体 : Form
    {
        TH.BaseClass.GetBaseData getBaseData = new GetBaseData();

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }

        public string s_Code;

        public Frm高开返利核销单窗体(string sCode, string Conn, string sUserID, string sUserName, string sLogDate, string sAccID)
        {
            InitializeComponent();

            this.s_Code = sCode;
            this.Conn = Conn;
            this.sUserID = sUserID;
            this.sUserName = sUserName;
            this.sLogDate = sLogDate;
            this.sAccID = sAccID;
        }

        private void Frm高开返利核销单窗体_Load(object sender, EventArgs e)
        {
            try
            {
                GetGrid(s_Code, Conn, sUserID, sUserName, sLogDate, sAccID);
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载数据失败:" + ee.Message);
            }
        }

        private void GetGrid(string sCode, string Conn, string sUserID, string sUserName, string sLogDate, string sAccID)
        {
            string sSQL = @"

select a.[FLD_Money] as HXMoney,a.cCode,a.Remark
    ,b.*
from [dbo].[_高开返利核销单] a
		inner join _TH_GET_FLD b on a.FLD_iID = b.iID
where a.cCode = '{0}' and isnull(a.FLD_iID,0) <> 0
order by a.iID
";
            sSQL = string.Format(sSQL, sCode);
            DataTable dtFLD = DbHelperSQL.Query(sSQL);
            if (dtFLD != null && dtFLD.Rows.Count > 0)
            {
                gridControl返利单.DataSource = dtFLD;

                txt单据号.Text = dtFLD.Rows[0]["cCode"].ToString().Trim();
                dtm.DateTime = BaseFunction.ReturnDate(dtFLD.Rows[0]["dtmDate"]);
                txt备注.Text = dtFLD.Rows[0]["Remark"].ToString().Trim();
            }

            sSQL = @"
select a.[FP_Money] as HXMoney
    ,b.*
from [_高开返利核销单] a
	inner join _TH_GET_PurBillVouch b on a.[FP_IDs]= b.FP_IDs
where a.cCode = '{0}' and isnull(a.[FP_IDs],0) <> 0
order by a.iID
";
            sSQL = string.Format(sSQL, sCode);
            DataTable dtFP = DbHelperSQL.Query(sSQL);
            if (dtFP != null && dtFP.Rows.Count > 0)
            {
                gridControl_发票.DataSource = dtFP;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView返利单.FocusedRowHandle -= 1;
                    gridView返利单.FocusedRowHandle += 1;
                }
                catch { }

                string sErr = "";
                int iCou = 0;
                SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    if (txt单据号.Text.Trim() == "")
                    {
                        throw new Exception("请选择单据");
                    }

                    string sSQL = @"
select * from [dbo].[_高开返利核销单] where cCode = '{0}' 
";
                    sSQL = string.Format(sSQL, txt单据号.Text.Trim());
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        throw new Exception("单据不存在");
                    }

                    DAL._高开返利核销单 dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._高开返利核销单();
                    sSQL = dal.Delete(txt单据号.Text.Trim());
                    iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    tran.Commit();

                    if (iCou > 0)
                    {
                        MessageBox.Show("删除成功");

                        this.Close();
                    }
                }
                catch (Exception error)
                {
                    tran.Rollback();
                    throw new Exception(error.Message);
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "删除失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }
    }
}
