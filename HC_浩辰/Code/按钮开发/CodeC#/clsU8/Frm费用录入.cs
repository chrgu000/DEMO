using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;



namespace clsU8
{
    public partial class Frm费用录入 : Form
    {

        string s服务器;
        string sSA;
        string sPwd;
        string s数据库;
        string s单据号;
        string sConnString;
        string sUserID;


        public Frm费用录入()
        {
            InitializeComponent();
        }


        public Frm费用录入(string s1, string s2, string s3, string s4, string s5, string s6)
        {
            InitializeComponent();

            s服务器 = s1;
            sSA = s2;
            sPwd = s3;
            s数据库 = s4;
            s单据号 = s5;
            sUserID = s6;

            sConnString = "server = " + s服务器 + ";uid=" + sSA + ";pwd=" + sPwd + ";database=" + s数据库 + ";timeout = 200";
        }

        private void Frm_Load(object sender, EventArgs e)
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

      
        private void GetGrid()
        {
            string sSQL = @"
select b.id,c.*
from Ap_CloseBill a inner join Ap_CloseBills b on a.iID = b.iID	
	left join [dbo].[Ap_CloseBills_extradefine] c on b.ID = c.ID
where a.iID = '{0}'
";
            sSQL = string.Format(sSQL, s单据号);
            DataTable dt = DbHelperSQL.ExecuteDataset(sConnString, CommandType.Text, sSQL).Tables[0];

            if (dt != null && dt.Rows.Count > 0)
            {
                lID.Text = dt.Rows[0]["ID"].ToString().Trim();

                if (BaseFunction.ReturnDecimal(dt.Rows[0]["cbdefine1"], 2) != 0)
                    txt政府支持费.EditValue = BaseFunction.ReturnDecimal(dt.Rows[0]["cbdefine1"], 2);
                if (BaseFunction.ReturnDecimal(dt.Rows[0]["cbdefine2"], 2) != 0)
                    txt进货成本分摊.EditValue = BaseFunction.ReturnDecimal(dt.Rows[0]["cbdefine2"], 2);
                if (BaseFunction.ReturnDecimal(dt.Rows[0]["cbdefine3"], 2) != 0)
                    txt代理费.EditValue = BaseFunction.ReturnDecimal(dt.Rows[0]["cbdefine3"], 2);
                if (BaseFunction.ReturnDecimal(dt.Rows[0]["cbdefine4"], 2) != 0)
                    txt其他销售费用.EditValue = BaseFunction.ReturnDecimal(dt.Rows[0]["cbdefine4"], 2);
                if (BaseFunction.ReturnDecimal(dt.Rows[0]["cbdefine5"], 2) != 0)
                    txt特殊费用.EditValue = BaseFunction.ReturnDecimal(dt.Rows[0]["cbdefine5"], 2);
                if (BaseFunction.ReturnDecimal(dt.Rows[0]["cbdefine6"], 2) != 0)
                txt项目开发费.EditValue = BaseFunction.ReturnDecimal(dt.Rows[0]["cbdefine6"], 2);

                txt累计.EditValue = BaseFunction.ReturnDecimal(dt.Rows[0]["cbdefine1"], 2)
                    + BaseFunction.ReturnDecimal(dt.Rows[0]["cbdefine2"], 2)
                    + BaseFunction.ReturnDecimal(dt.Rows[0]["cbdefine3"], 2)
                    + BaseFunction.ReturnDecimal(dt.Rows[0]["cbdefine4"], 2)
                     + BaseFunction.ReturnDecimal(dt.Rows[0]["cbdefine5"], 2)
                     + BaseFunction.ReturnDecimal(dt.Rows[0]["cbdefine6"], 2);
            }

            if (sUserID.ToLower() == "demo")
            {
                txt政府支持费.Properties.ReadOnly = false;
                txt进货成本分摊.Properties.ReadOnly = false;
                txt代理费.Properties.ReadOnly = false;
                txt其他销售费用.Properties.ReadOnly = false;
                txt特殊费用.Properties.ReadOnly = false;
                txt项目开发费.Properties.ReadOnly = false;
            }
            else
            {
                sSQL = @"
select * from _TH_UserRight where sUserID = '{0}'
";
                sSQL = string.Format(sSQL, sUserID);
                dt = DbHelperSQL.ExecuteDataset(sConnString, CommandType.Text, sSQL).Tables[0];

                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow[] dr = dt.Select("sType = 'cbdefine1'");
                    if (dr.Length == 0)
                    {
                        txt政府支持费.Properties.ReadOnly = true;
                    }
                    else
                    {
                        txt政府支持费.Properties.ReadOnly = false;
                    }

                    dr = dt.Select("sType = 'cbdefine2'");
                    if (dr.Length == 0)
                    {
                        txt进货成本分摊.Properties.ReadOnly = true;
                    }
                    else
                    {
                        txt进货成本分摊.Properties.ReadOnly = false;
                    }

                    dr = dt.Select("sType = 'cbdefine3'");
                    if (dr.Length == 0)
                    {
                        txt代理费.Properties.ReadOnly = true;
                    }
                    else
                    {
                        txt代理费.Properties.ReadOnly = false;
                    }

                    dr = dt.Select("sType = 'cbdefine4'");
                    if (dr.Length == 0)
                    {
                        txt其他销售费用.Properties.ReadOnly = true;
                    }
                    else
                    {
                        txt其他销售费用.Properties.ReadOnly = false;
                    }

                    dr = dt.Select("sType = 'cbdefine5'");
                    if (dr.Length == 0)
                    {
                        txt特殊费用.Properties.ReadOnly = true;
                    }
                    else
                    {
                        txt特殊费用.Properties.ReadOnly = false;
                    }

                    dr = dt.Select("sType = 'cbdefine6'");
                    if (dr.Length == 0)
                    {
                        txt项目开发费.Properties.ReadOnly = true;
                    }
                    else
                    {
                        txt项目开发费.Properties.ReadOnly = false;
                    }
                }
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                long l_ID = BaseFunction.ReturnLong(lID.Text);
                if(l_ID <=0)
                {
                    throw new Exception("获得收款单ID失败");
                }

                decimal d1 = BaseFunction.ReturnDecimal(txt政府支持费.Text.Trim(),2);
                decimal d2 = BaseFunction.ReturnDecimal(txt进货成本分摊.Text.Trim(),2);
                decimal d3 = BaseFunction.ReturnDecimal(txt代理费.Text.Trim(),2);
                decimal d4 = BaseFunction.ReturnDecimal(txt其他销售费用.Text.Trim(),2);
                decimal d5 = BaseFunction.ReturnDecimal(txt特殊费用.Text.Trim(),2);
                decimal d6 = BaseFunction.ReturnDecimal(txt项目开发费.Text.Trim(),2);
                decimal dSum = d1 + d2 + d3 + d4 + d5 + d6;

                string sSQL = @"
if not exists(select * from Ap_CloseBills_extradefine where id = {0})
    insert into Ap_CloseBills_extradefine( ID, cbdefine1, cbdefine2, cbdefine3, cbdefine4, cbdefine5, cbdefine6)
    values({0},{1},{2},{3},{4},{5},{6})
else
    update Ap_CloseBills_extradefine set cbdefine1 = {1}
        ,cbdefine2 = {2}
        ,cbdefine3 = {3}
        ,cbdefine4 = {4}
        ,cbdefine5 = {5}
        ,cbdefine6 = {6}
    where id = {0}
;
update Ap_CloseBills set cdefine35 = {7} where id = {0}
";
                sSQL = string.Format(sSQL, l_ID, d1, d2, d3, d4, d5, d6, dSum);

                DbHelperSQL.ExecuteNonQuery(sConnString, CommandType.Text, sSQL);

                MessageBox.Show("保存成功");
                this.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show("保存失败：" + ee.Message);
            }
        }

        private void txt_EditValueChanged(object sender, EventArgs e)
        {
            decimal d1 = BaseFunction.ReturnDecimal(txt政府支持费.Text.Trim(), 2);
            decimal d2 = BaseFunction.ReturnDecimal(txt进货成本分摊.Text.Trim(), 2);
            decimal d3 = BaseFunction.ReturnDecimal(txt代理费.Text.Trim(), 2);
            decimal d4 = BaseFunction.ReturnDecimal(txt其他销售费用.Text.Trim(), 2);
            decimal d5 = BaseFunction.ReturnDecimal(txt特殊费用.Text.Trim(), 2);
            decimal d6 = BaseFunction.ReturnDecimal(txt项目开发费.Text.Trim(), 2);
            decimal dSum = d1 + d2 + d3 + d4 + d5 + d6;

            txt累计.Text = dSum.ToString();
        }
    }
}
