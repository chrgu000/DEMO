using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace clsU8
{
    public partial class Frm采购入库单检验 : Form
    {
        
        string s服务器;
        string sSA;
        string sPwd;
        string s数据库;
        string s单据号;
        string sConnString;


        public Frm采购入库单检验()
        {
            InitializeComponent();
        }

        string s存货编码 = "";
        private void Frm采购入库单检验_Load(object sender, EventArgs e)
        {
            Cls时间锁 cls = new Cls时间锁();
            if (cls.bchk时间锁(sConnString) == false)
            {
                throw new Exception("加载数据失败");
            }
            try
            {
                //for (int i = gridView1.Columns.Count - 1; i >= 6; i--)
                //{
                //    if (gridView1.Columns[i].Name.IndexOf("gridCol_QCCode") >= 0)
                //    {
                //        gridView1.Columns.Remove(gridView1.Columns[i]);
                //    }
                //}

                string sSQL = @"
select a.ID,b.AutoID,irowno,b.cInvCode,i.cInvName,i.cInvStd ,convert(nvarchar,case when qcc.Conclusion is not null then qcc.Conclusion else '1' end) Conclusion,qcc.Remark,convert(decimal(18, 2),iQuantity) as iQuantity
from rdrecord01 a left join rdrecords01 b on a.id = b.id
left join Inventory i on b.cInvCode=i.cInvCode left join _QCConclusion qcc on b.AutoID=qcc.AutoID
where a.cCode = '111111111' 
order by b.AUTOID";
                sSQL = sSQL.Replace("111111111", s单据号);

                DataTable dt = SqlHelper.ExecuteDataset(sConnString, CommandType.Text, sSQL).Tables[0];
                string cInvCode = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (cInvCode != "")
                    {
                        cInvCode = cInvCode + ",";
                    }
                    cInvCode = cInvCode + "'" + dt.Rows[i]["cInvCode"].ToString() + "'";
                }

                DataTable dtqc = SqlHelper.ExecuteDataset(sConnString, CommandType.Text, "select a.QCCode,a.QCName from _QC a left join _QCcInvCode b on a.QCCode=b.QCCode where cInvCode in (" + cInvCode + ") group by a.QCCode,a.QCName order by a.QCCode,a.QCName").Tables[0];
                DataTable dtqcresult = SqlHelper.ExecuteDataset(sConnString, CommandType.Text, "select * from _QCResult where ID='" + dt.Rows[0]["ID"].ToString() + "'").Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dtqc.Rows.Count; i++)
                    {
                        string QCCode = dtqc.Rows[i]["QCCode"].ToString();
                        string QCName = dtqc.Rows[i]["QCName"].ToString();
                        dt.Columns.Add(QCCode);
                        GetCol(QCName, QCCode);
                        for (int j = 0; j < dt.Rows.Count; j++)
                        {
                            DataRow[] dw = dtqcresult.Select("AutoID='" + dt.Rows[j]["AutoID"] + "' and QCCode='" + QCCode + "'");
                            if (dw.Length > 0)
                            {
                                dt.Rows[j][QCCode] = dw[0]["Result"];
                            }
                        }
                    }
                    
                    gridControl1.DataSource = dt;
                    gridCol结论.VisibleIndex = gridView1.Columns.Count;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载数据失败：" + ee.Message);
            }
        }

        private void GetCol(string ColText, string FieldName)
        {
            DevExpress.XtraGrid.Columns.GridColumn Col = new DevExpress.XtraGrid.Columns.GridColumn();
            Col.FieldName = FieldName;
            Col.Name = "gridCol_QCCode" + FieldName;
            Col.Caption = ColText;
            Col.OptionsColumn.AllowEdit = true;
            Col.Width = 80;
            Col.Visible = true;
            Col.VisibleIndex = gridView1.Columns.Count;
            //Col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            //Col.SummaryItem.FieldName = FieldName;
            //Col.ColumnEdit = this.ItemRadioGroup1;
            gridView1.Columns.Add(Col);

            //gridView1.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, FieldName, Col);
        }

        public Frm采购入库单检验(string s1, string s2, string s3, string s4, string s5)
        {
            InitializeComponent();

            s服务器 = s1;
            sSA = s2;
            sPwd = s3;
            s数据库 = s4;
            s单据号 = s5;

            sConnString = "server=" + s服务器 + ";uid=" + sSA + ";pwd= " + sPwd + ";database=" + s数据库 + ";timeout=200";
        }


        private void btn取消_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string sErr = "";
                SqlConnection conn = new SqlConnection(sConnString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                string sSQL = "";
                try
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        for (int j = 0; j < gridView1.Columns.Count; j++)
                        {
                            if (gridView1.Columns[j].Name.IndexOf("gridCol_QCCode") >= 0)
                            {
                                DataTable dt = SqlHelper.ExecuteDataset(tran, CommandType.Text, @"select * from _QCResult with(nolock) where 
AutoID='" + gridView1.GetRowCellValue(i, gridCol表体序号).ToString().Trim() + "' and QCCode='" + gridView1.Columns[j].FieldName + "'").Tables[0];
                                if (dt.Rows.Count > 0)
                                {
                                    sSQL = "update _QCResult set Result='" + gridView1.GetRowCellValue(i, gridView1.Columns[j].FieldName).ToString().Trim() + "' where AutoID='" + gridView1.GetRowCellValue(i, gridCol表体序号).ToString().Trim() + "' and QCCode='" + gridView1.Columns[j].FieldName + "'";
                                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                                }
                                else
                                {
                                    sSQL = "insert into _QCResult(ID,AutoID,QCCode,Result)" +
                                                  "values('" + gridView1.GetRowCellValue(i, gridCol序号).ToString().Trim() + "','" + gridView1.GetRowCellValue(i, gridCol表体序号).ToString().Trim() + "','" + gridView1.Columns[j].FieldName + "','" + gridView1.GetRowCellValue(i, gridView1.Columns[j].FieldName).ToString().Trim() + "')";
                                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                                }
                            }
                        }

                        DataTable dt2 = SqlHelper.ExecuteDataset(tran, CommandType.Text, @"select * from _QCConclusion with(nolock) where 
AutoID='" + gridView1.GetRowCellValue(i, gridCol表体序号).ToString().Trim() + "' ").Tables[0];
                        if (dt2.Rows.Count > 0)
                        {
                            sSQL = "update _QCConclusion set Conclusion='" + gridView1.GetRowCellValue(i, gridCol结论).ToString().Trim() + "',Remark='" + gridView1.GetRowCellValue(i, gridCol检验描述).ToString().Trim() + "' where AutoID='" + gridView1.GetRowCellValue(i, gridCol表体序号).ToString().Trim() + "'";
                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                        else
                        {
                            sSQL = "insert into _QCConclusion(ID,AutoID,Conclusion,Remark)" +
                                          "values('" + gridView1.GetRowCellValue(i, gridCol序号).ToString().Trim() + "','" + gridView1.GetRowCellValue(i, gridCol表体序号).ToString().Trim() + "','" + gridView1.GetRowCellValue(i, gridCol结论).ToString().Trim() + "','" + gridView1.GetRowCellValue(i, gridCol检验描述).ToString().Trim() + "')";
                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                    }
                    
                    if (sErr != "")
                    {
                        throw new Exception(sErr);
                    }
                    MessageBox.Show("保存成功");
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
    }
}
