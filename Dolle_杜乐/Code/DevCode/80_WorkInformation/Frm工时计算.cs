using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WorkInformation
{
    public partial class Frm工时计算 : Form
    {

        DateTime d核查日期;
        DataTable dt生产计划;
        FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();
        public Frm工时计算(DateTime d,DataTable dt)
        {
            InitializeComponent();

            d核查日期 = d;
            dt生产计划 = dt;
        }

        private void Frm工时计算_Load(object sender, EventArgs e)
        {
            try
            {
                this.StartPosition = FormStartPosition.CenterScreen;

                string sSQL = "select * from _LookUpDate where iType = '12' order by iID";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows.Count == 3)
                {
                    txt正常.Text = dt.Rows[0]["iText"].ToString().Trim();
                    txt加班.Text = dt.Rows[1]["iText"].ToString().Trim();
                    txt两班.Text = dt.Rows[2]["iText"].ToString().Trim();
                }
                
                dateTimePicker1.Value = d核查日期;

                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void GetGrid()
        {
            int iCol = 0;
            if (d核查日期 != dateTimePicker1.Value)
            {
                TimeSpan ts = dateTimePicker1.Value - d核查日期;
                iCol = ts.Days;
            }
            if (iCol < 0)
            {
                throw new Exception("不能核查之前日期数据");
            }

            for (int i = 0; i < dt生产计划.Columns.Count; i++)
            {
                if (dt生产计划.Columns[i].ColumnName == "日期1")
                {
                    iCol = iCol + i;
                    break;
                }
            }

            try
            {
                string sSQL = "select a.Machine as 设备,isnull(a.数量 ,0) - isnull(b.停机数量,0) as 数量,CAST(0 as decimal(18,2)) 设备总工时,CAST(null as decimal(18,2)) 设备单台平均工时,CAST(null as varchar(5)) 设备状态 " +
                                "from dbo.Machine a " +
                                "left join dbo.设备日登记 b on rtrim(ltrim(a.Machine)) = rtrim(ltrim(b.设备)) and b.日期 = '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' " +
                                "where isnull(a.数量 ,0) > 0 " +
                                "order by  a.Machine ";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string s设备 = dt.Rows[i]["设备"].ToString().Trim();
                    decimal d设备总工时 = 0;
                    for (int j = 0; j < dt生产计划.Rows.Count; j++)
                    {
                        string s设备2 = dt生产计划.Rows[j]["设备"].ToString().Trim();
                        if (s设备 == s设备2)
                        {
                            decimal d单位工时 = ReturnObjectToDecimal(dt生产计划.Rows[j]["单位工时"], 10);
                            //decimal d制造令数量 = ReturnObjectToDecimal(dt生产计划.Rows[j]["制造令数量"], 10);
                            decimal d计划数量 = ReturnObjectToDecimal(dt生产计划.Rows[j][iCol], 10);
                            d设备总工时 = d设备总工时 + ReturnObjectToDecimal(d单位工时 * d计划数量, 3);
                        }
                    }

                    decimal d设备数量 = ReturnObjectToDecimal(dt.Rows[i]["数量"], 0);
                    dt.Rows[i]["设备总工时"] = d设备总工时;
                    if (d设备数量 > 0)
                    {
                        decimal d设备单位工时 = ReturnObjectToDecimal(d设备总工时 / d设备数量, 2);
                        dt.Rows[i]["设备单台平均工时"] = d设备单位工时;

                        if (d设备单位工时 <= ReturnObjectToDecimal(txt正常.Text.Trim(),2))
                        {
                            dt.Rows[i]["设备状态"] = "正常";
                        }
                        else if (d设备单位工时 <= ReturnObjectToDecimal(txt加班.Text.Trim(), 2))
                        {
                            dt.Rows[i]["设备状态"] = "加班";
                        }
                        else if (d设备单位工时 <= ReturnObjectToDecimal(txt两班.Text.Trim(), 2))
                        {
                            dt.Rows[i]["设备状态"] = "两班";
                        }
                        else
                        {
                            dt.Rows[i]["设备状态"] = "超时";
                        }

                    }
                }
                gridControl设备.DataSource = dt;
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得设备工时失败:" + ee.Message);
            }
            try
            {
                string sSQL = "select c.cDepName as 部门,isnull(a.人数,0) - isnull(b.休班人数,0) + isnull(b.增加人数,0) as 人员数量,CAST(0 as decimal(18,2)) 人员总工时,CAST(null as decimal(18,2)) 人员平均工时,CAST(null as varchar(5)) 人员状态 " +
                                "from dbo.生产部员工人数 a left join dbo.生产部人员日登记 b on rtrim(ltrim(a.部门))=rtrim(ltrim(b.部门))  and b.日期 = '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' " +
                                "   left join @u8.department c on rtrim(ltrim(c.cDepCode)) = rtrim(ltrim(a.部门)) " +
                                "order by a.部门";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);


                sSQL = "select * from _LookupDate where iType = '13'";
                DataTable dt班组对照 = clsSQLCommond.ExecQuery(sSQL);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string s部门 = dt.Rows[i]["部门"].ToString().Trim();
                    decimal d人员总工时 = 0;
                    for (int j = 0; j < dt生产计划.Rows.Count; j++)
                    {
                        string s部门2 = dt生产计划.Rows[j]["组别"].ToString().Trim();
                        if (s部门 == s部门2)
                        {
                            decimal d单位工时 = ReturnObjectToDecimal(dt生产计划.Rows[j]["单位工时"], 10);
                            decimal d计划数量 = ReturnObjectToDecimal(dt生产计划.Rows[j][iCol], 10);
                            d人员总工时 = d人员总工时 + ReturnObjectToDecimal(d单位工时 * d计划数量, 3);
                        }                       

                        DataRow[] dr班组 = dt班组对照.Select(" Remark = '" + s部门2 + "' ");
                        if (dr班组.Length > 0)
                        {
                            s部门2 = dr班组[0]["iText"].ToString().Trim();
                        }
                        else
                        {
                            throw new Exception(s部门2 + "不存在，或没有建立对应关系");
                        }
                    }

                    decimal d人员数量 = ReturnObjectToDecimal(dt.Rows[i]["人员数量"], 0);
                    dt.Rows[i]["人员总工时"] = d人员总工时;
                    if (d人员数量 > 0)
                    {
                        decimal d人员单位工时 = ReturnObjectToDecimal(d人员总工时 / d人员数量, 2);
                        dt.Rows[i]["人员平均工时"] = d人员单位工时;

                        if (d人员单位工时 <= ReturnObjectToDecimal(txt正常.Text.Trim(), 2))
                        {
                            dt.Rows[i]["人员状态"] = "正常";
                        }
                        else if (d人员单位工时 <= ReturnObjectToDecimal(txt加班.Text.Trim(), 2))
                        {
                            dt.Rows[i]["人员状态"] = "加班";
                        }
                        else if (d人员单位工时 <= ReturnObjectToDecimal(txt两班.Text.Trim(), 2))
                        {
                            dt.Rows[i]["人员状态"] = "两班";
                        }
                        else
                        {
                            dt.Rows[i]["人员状态"] = "超时";
                        }

                    }
                }
                gridControl班组.DataSource = dt;

            }
            catch (Exception ee)
            {
                MessageBox.Show("获得人工工时失败:" + ee.Message);
            }
        }

        private void btn核查_Click(object sender, EventArgs e)
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

        private void btn取消_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridView班组_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

        private void gridView设备_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

        private int ReturnObjectToInt(object o)
        {
            int i = 0;
            try
            {
                i = Convert.ToInt32(o);
            }
            catch
            { }
            return i;
        }

        private decimal ReturnObjectToDecimal(object o, int i)
        {
            decimal d = 0;
            try
            {
                d = Convert.ToDecimal(o);
                d = decimal.Round(d, i);
            }
            catch
            { }
            return d;
        }

        private void gridView班组_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (gridView班组.GetRowCellDisplayText(e.RowHandle, gridCol人员状态).ToString().Trim() == "正常")
            {
                e.Appearance.BackColor = Color.LightGreen;
            }
            if (gridView班组.GetRowCellDisplayText(e.RowHandle, gridCol人员状态).ToString().Trim() == "加班")
            {
                e.Appearance.BackColor = Color.Green;
            }
            if (gridView班组.GetRowCellDisplayText(e.RowHandle, gridCol人员状态).ToString().Trim() == "两班")
            {
                e.Appearance.BackColor = Color.Yellow;
            }
            if (gridView班组.GetRowCellDisplayText(e.RowHandle, gridCol人员状态).ToString().Trim() == "超时")
            {
                e.Appearance.BackColor = Color.Tomato;
            }
        }

        private void gridView设备_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (gridView设备.GetRowCellDisplayText(e.RowHandle, gridCol设备状态).ToString().Trim() == "正常")
            {
                e.Appearance.BackColor = Color.LightGreen;
            }
            if (gridView设备.GetRowCellDisplayText(e.RowHandle, gridCol设备状态).ToString().Trim() == "加班")
            {
                e.Appearance.BackColor = Color.Green;
            }
            if (gridView设备.GetRowCellDisplayText(e.RowHandle, gridCol设备状态).ToString().Trim() == "两班")
            {
                e.Appearance.BackColor = Color.Yellow;
            }
            if (gridView设备.GetRowCellDisplayText(e.RowHandle, gridCol设备状态).ToString().Trim() == "超时")
            {
                e.Appearance.BackColor = Color.Tomato;
            }
        }
    }
}
