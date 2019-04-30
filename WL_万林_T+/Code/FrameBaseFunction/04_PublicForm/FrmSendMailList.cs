using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FrameBaseFunction
{
    public partial class FrmMailListSend : Form
    {
        public DataTable dt;
        public string sDO;
        DataTable dtMail;
        FrameBaseFunction.ClseMail clsMail = new FrameBaseFunction.ClseMail();
        FrameBaseFunction.ClsDataBase clsSQL = FrameBaseFunction.ClsDataBaseFactory.Instance();

        public FrmMailListSend()
        {
            InitializeComponent();

            dt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "mailAddress";      //邮件地址
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "mailPerID";        //收件人ID
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "mailPer";          //收件人
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "Subject";          //主题
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "sText";            //内容
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "cCode";            //单据号
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "bUsed";            //是否已用
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "sMailCC";          //抄送地址
            dt.Columns.Add(dc);

            dtMail = dt.Copy();
        }

        public void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, gridColmailAddress).ToString().Trim() != "")
                    {
                        if (gridView1.GetRowCellValue(i, gridColsMailCC).ToString().Trim() != "")
                        {
                            clsMail.sMailCC = gridView1.GetRowCellValue(i, gridColsMailCC).ToString().Trim();
                        }
                        else
                        {
                            clsMail.sMailCC = ""; 
                        }
                        clsMail.MailSend(gridView1.GetRowCellValue(i, gridColmailAddress).ToString().Trim(), gridView1.GetRowCellValue(i, gridColSubject).ToString().Trim(), gridView1.GetRowCellValue(i, gridColsText).ToString().Trim());
                    }
                }
                DialogResult = DialogResult.OK;
            }
            catch (Exception ee)
            {
                
            }
        }

        public void FrmMailListSend_Load(object sender, EventArgs e)
        {
            try
            {
                //string sNoMail = "";
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["bUsed"].ToString().Trim() == "1")
                            continue;
                        dt.Rows[i]["bUsed"] = "1";
                        DataRow dr = dtMail.NewRow();
                        dr["mailAddress"] = dt.Rows[i]["mailAddress"];
                        dr["mailPerID"] = dt.Rows[i]["mailPerID"];
                        dr["cCode"] = dt.Rows[i]["cCode"].ToString().Trim();
                        dr["mailPer"] = dt.Rows[i]["mailPer"];
                        dr["Subject"] = dt.Rows[i]["Subject"];
                        dr["sText"] = dt.Rows[i]["sText"];
                        dr["sMailCC"] = dt.Rows[i]["sMailCC"];
                        dr["bUsed"] = "1";

                        for (int j = i + 1; j < dt.Rows.Count; j++)
                        {
                            if (dt.Rows[i]["mailPerID"].ToString().Trim() == dt.Rows[j]["mailPerID"].ToString().Trim())
                            {
                                dt.Rows[j]["bUsed"] = "1";
                                if (dr["cCode"].ToString().Trim().IndexOf(dt.Rows[j]["cCode"].ToString().Trim()) > -1)
                                    continue;

                                if (dt.Rows[i]["cCode"].ToString().Trim() != dt.Rows[j]["cCode"].ToString().Trim())
                                {
                                    dr["cCode"] = dr["cCode"].ToString().Trim() + "," + dt.Rows[j]["cCode"].ToString().Trim();
                                }
                            }
                        }
                        dtMail.Rows.Add(dr);
                    }
                }
                for (int i = 0; i < dtMail.Rows.Count; i++)
                {
                    if (dtMail.Rows[i]["sText"].ToString().Trim() == "")
                    {
                        dtMail.Rows[i]["sText"] = "尊敬的" + dtMail.Rows[i]["mailPer"].ToString().Trim() + "：  " + sDO + "：" + dtMail.Rows[i]["cCode"]  ;
                    }
                    else
                    {
                        dtMail.Rows[i]["sText"] = "尊敬的" + dtMail.Rows[i]["mailPer"].ToString().Trim() + "：  " + sDO + "：" + dtMail.Rows[i]["cCode"] + ", 原因：" + dtMail.Rows[i]["sText"].ToString().Trim();
                    }
                }

                    gridControl1.DataSource = dtMail;
            }
            catch (Exception ee)
            { }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}