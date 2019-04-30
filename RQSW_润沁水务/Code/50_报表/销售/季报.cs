using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace 报表
{
    public static class 季报
    {
        static 系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
        static 系统服务.ClsGetSQL clsGetSQL = new 系统服务.ClsGetSQL();
        static 系统服务.FrmBaseInfo frmBaseInfo = new 系统服务.FrmBaseInfo();
        static string Date1;
        static string Date2;
        static string 部门;
        static string 业务员;
        static string 季度;
        static string 统计方式;
        static string tablename = "StatByQuarter";
        static string 月;
        static string 年;
        static DataTable dt出货;
        static DataTable dt出差费;
        public static DataTable Get(string s部门, string s业务员,string s年, string s季度,string s统计方式,bool issave)
        {
            DataTable dt = new DataTable();
            DataTable dts;
            try
            {

                部门 = s部门;
                业务员 = s业务员;
                年 = s年;
                季度 = s季度;
                统计方式 = s统计方式;
                if (季度 == "1")
                {
                    月 = "1,2,3";
                }
                else if (季度 == "2")
                {
                    月 = "4,5,6";
                }
                else if (季度 == "3")
                {
                    月 = "7,8,9";
                }
                else if (季度 == "4")
                {
                    月 = "10,11,12";
                }
                string sSQL = "";
                if (统计方式 == "1")//按部门统计
                {
                    sSQL = "select S1 as cDepCode from SAPlan where S1 like '03%' and S1<>'03' and I1=2 and I2 in(" + 月 + ") and s5 = '" + s年 + "' ";
                    if (部门 != "")
                    {
                        sSQL = sSQL + " and S1='" + 部门 + "'";
                    }
                }
                else//按人员统计
                {
                    sSQL = "select S1 as cDepCode,S3 as PersonCode from SAPlan where 1=1 and I1=2 and I2  in(" + 月 + ")  s5 = '" + s年 + "' ";

                    if (部门 != "")
                    {
                        sSQL = sSQL + " and S1='" + 部门 + "'";
                    }
                }

                if (业务员 != "")
                {
                    sSQL = sSQL + " and S3='" + 业务员 + "'";
                }
                if (统计方式 == "1")
                {
                    sSQL = sSQL + " group by S1";
                }
                else
                {
                    sSQL = sSQL + " group by S1,S3";
                }
                dts = clsSQLCommond.ExecQuery(sSQL);
                dt.Columns.Add("统计项");
                for (int i = 0; i < dts.Rows.Count; i++)
                {
                    if (统计方式 == "1")
                    {
                        dt.Columns.Add(dts.Rows[i]["cDepCode"].ToString());
                    }
                    else
                    {
                        dt.Columns.Add(dts.Rows[i]["PersonCode"].ToString());
                    }
                }
                if (统计方式 == "1")
                {
                    if (部门 == "")
                    {
                        dt.Columns.Add("公司个人");
                    }
                }
                dt.Columns.Add("合计");

            }
            catch
            {
                throw new Exception("本月计划统计项生成失败");
            }
            
            try
            {
                GetRow本月计划(dt);
            }
            catch
            {
                throw new Exception("本月计划统计项生成失败");
            }
            try
            {
                GetRow出货量(dt);
            }
            catch
            {
                throw new Exception("出货量统计项生成失败");
            }
            try
            {
                GetRow出货家数(dt);
            }
            catch
            {
                throw new Exception("出货家统计项生成失败");
            }
            try
            {
                GetRow收款(dt);
            }
            catch
            {
                throw new Exception("收款统计项生成失败");
            }
            try
            {
                GetRow达成否(dt);
            }
            catch
            {
                throw new Exception("是否达成统计项生成失败");
            }
            try
            {
                GetRow未达成扣款(dt);
            }
            catch
            {
                throw new Exception("未达成扣款统计项生成失败");
            }
            try
            {
                GetRow新客户家数(dt);
            }
            catch
            {
                throw new Exception("新客户家数统计项生成失败");
            }
            try
            {
                GetRow销售额合计(dt);
            }
            catch
            {
                throw new Exception("销售额合计统计项生成失败");
            }
            try
            {
                GetRow应收款(dt);
            }
            catch
            {
                throw new Exception("应收款统计项生成失败");
            }
            try
            {
                GetRow销售费用合计(dt);
            }
            catch
            {
                throw new Exception("销售费用合计统计项生成失败");
            }
            try
            {
                GetRow业务招待费用(dt);
            }
            catch
            {
                throw new Exception("业务招待费用统计项生成失败");
            }
            try
            {
                GetRow出货利润(dt);
            }
            catch
            {
                throw new Exception("出货利润统计项生成失败");
            }
            try
            {
                GetRow累计出货数量(dt);
            }
            catch
            {
                throw new Exception("累计出货数量统计项生成失败");
            }
            try
            {
                GetRow退货量(dt);
            }
            catch
            {
                throw new Exception("退货量统计项生成失败");
            }
            try
            {
                GetRow样品(dt);
            }
            catch
            {
                throw new Exception("样品统计项生成失败");
            }
            if (issave == true)
            {
                GetSave(dt, dts);
            }
      
            return dt;
        }

        private static void GetRow本月计划(DataTable dt)
        {
            DataTable dts = 计划.季计划出货(年, 月);

            if (dts.Rows.Count > 0)
            {
                Date1 = DateTime.Parse(dts.Compute("min(Date1)", "").ToString()).ToString("yyyy-MM-dd");
                Date2 = DateTime.Parse(dts.Compute("max(Date2)", "").ToString()).ToString("yyyy-MM-dd");
            }

            dt出货 = 出货.Table(Date1, Date2);

            #region 本月计划出货量
            if (1 == 1)
            {
                DataRow dw = dt.NewRow();
                dw["统计项"] = "1";
                decimal sum = 0;

                for (int i = 1; i < dt.Columns.Count - 1; i++)
                {
                    if (统计方式 == "1")
                    {
                        if (dt.Columns[i].ColumnName != "公司个人")
                        {
                            dw[i] = dts.Compute("sum(D2)", "S1='" + dt.Columns[i].ColumnName + "'");
                            sum = sum + 系统服务.规格化.ReturnDecimal(dw[i], 2);
                        }
                        else
                        {
                            dw[i] = dts.Compute("sum(D2)", "S1 not like '03%'");
                            sum = sum +系统服务.规格化.ReturnDecimal(dw[i], 2);
                        }
                    }
                    else
                    {
                        dw[i] = dts.Compute("sum(D2)", "S3='" + dt.Columns[i].ColumnName + "'");
                        sum = sum + 系统服务.规格化.ReturnDecimal(dw[i], 2);
                    }
                }

                dw["合计"] = sum;
                dt.Rows.Add(dw);
            }
            #endregion

            #region 本月计划收款
            if (1 == 1)
            {
                DataRow dw = dt.NewRow();
                dw["统计项"] = "2";
                decimal sum = 0;

                for (int i = 1; i < dt.Columns.Count - 1; i++)
                {
                    if (统计方式 == "1")
                    {
                        dw[i] = dts.Compute("sum(D1)", "S1='" + dt.Columns[i].ColumnName + "'");
                        sum = sum + 系统服务.规格化.ReturnDecimal(dw[i], 2);
                    }
                    else
                    {
                        dw[i] = dts.Compute("sum(D1)", "S3='" + dt.Columns[i].ColumnName + "'");
                        sum = sum + 系统服务.规格化.ReturnDecimal(dw[i], 2);
                    }
                }

                dw["合计"] = sum;
                dt.Rows.Add(dw);
            }
            #endregion

            #region 本月保底量
            if (1 == 1)
            {
                DataRow dw = dt.NewRow();
                dw["统计项"] = "11";
                decimal sum = 0;

                for (int i = 1; i < dt.Columns.Count - 1; i++)
                {
                    if (统计方式 == "1")
                    {
                        dw[i] = dts.Compute("sum(保底量)", "S1='" + dt.Columns[i].ColumnName + "'");
                        sum = sum + 系统服务.规格化.ReturnDecimal(dw[i], 2);
                    }
                    else
                    {
                        dw[i] = dts.Compute("sum(保底量)", "S3='" + dt.Columns[i].ColumnName + "'");
                        sum = sum + 系统服务.规格化.ReturnDecimal(dw[i], 2);
                    }
                }

                dw["合计"] = sum;
                dt.Rows.Add(dw);
            }
            #endregion

            #region 本月保底家数
            if (1 == 1)
            {
                DataRow dw = dt.NewRow();
                dw["统计项"] = "14";
                decimal sum = 0;

                for (int i = 1; i < dt.Columns.Count - 1; i++)
                {
                    if (统计方式 == "1")
                    {
                        dw[i] = 系统服务.规格化.ReturnInt(系统服务.规格化.ReturnDecimal(dts.Compute("sum(保底量)", "S1='" + dt.Columns[i].ColumnName + "'")) / 1000);
                        sum = sum + 系统服务.规格化.ReturnInt(dw[i]);
                    }
                    else
                    {
                        dw[i] = 系统服务.规格化.ReturnInt(系统服务.规格化.ReturnDecimal(dts.Compute("sum(保底量)", "S3='" + dt.Columns[i].ColumnName + "'")) / 1000);
                        sum = sum + 系统服务.规格化.ReturnInt(dw[i]);
                    }
                }

                dw["合计"] = sum;
                dt.Rows.Add(dw);
            }
            #endregion

            #region 本月保底收款
            if (1 == 1)
            {
                DataRow dw = dt.NewRow();
                dw["统计项"] = "17";
                decimal sum = 0;

                for (int i = 1; i < dt.Columns.Count - 1; i++)
                {
                    if (统计方式 == "1")
                    {
                        dw[i] = dts.Compute("sum(D1)", "S1='" + dt.Columns[i].ColumnName + "'");
                        sum = sum + 系统服务.规格化.ReturnDecimal(dw[i], 2);
                    }
                    else
                    {
                        dw[i] = dts.Compute("sum(D1)", "S3='" + dt.Columns[i].ColumnName + "'");
                        sum = sum + 系统服务.规格化.ReturnDecimal(dw[i], 2);
                    }
                }

                dw["合计"] = sum;
                dt.Rows.Add(dw);
            }
            #endregion
        }

        private static void GetRow出货量(DataTable dt)
        {
            if (1 == 1)
            {
                DataRow dw = dt.NewRow();
                dw["统计项"] = "21";

                decimal sum = 0;

                for (int i = 1; i < dt.Columns.Count - 1; i++)
                {
                    if (统计方式 == "1")
                    {
                        dw[i] = 系统服务.规格化.ReturnDecimal(dt出货.Compute("sum(iQuantity)", "cDepCode='" + dt.Columns[i].ColumnName + "' and Flag='1'"), 2);
                        sum = sum + 系统服务.规格化.ReturnDecimal(dw[i], 2);
                    }
                    else
                    {
                        dw[i] = 系统服务.规格化.ReturnDecimal(dt出货.Compute("sum(iQuantity)", "cPersonCode='" + dt.Columns[i].ColumnName + "' and Flag='1'"), 2);
                        sum = sum + 系统服务.规格化.ReturnDecimal(dw[i], 2);
                    }
                }

                dw["合计"] = sum;
                dt.Rows.Add(dw);
            }
            if (1 == 1)
            {
                DataRow dw = dt.NewRow();
                dw["统计项"] = "22";

                decimal sum = 0;

                DataTable dts = 出货.Table出货变更(Date1, Date2);
                for (int i = 1; i < dt.Columns.Count - 1; i++)
                {
                    if (统计方式 == "1")
                    {
                        dw[i] = 系统服务.规格化.ReturnDecimal(dt出货.Compute("sum(iQuantity)", "cDepCode='" + dt.Columns[i].ColumnName + "' and Flag='2'"), 2);
                        sum = sum + 系统服务.规格化.ReturnDecimal(dw[i], 2);
                    }
                    else
                    {
                        dw[i] = 系统服务.规格化.ReturnDecimal(dt出货.Compute("sum(iQuantity)", "cPersonCode='" + dt.Columns[i].ColumnName + "' and Flag='2'"), 2);
                        sum = sum + 系统服务.规格化.ReturnDecimal(dw[i], 2);
                    }
                }

                dw["合计"] = sum;
                dt.Rows.Add(dw);
            }
        }

        private static void GetRow出货家数(DataTable dt)
        {
            DataRow dw = dt.NewRow();
            dw["统计项"] = "24";

            decimal sum = 0;
            string sSQL = "";
            sSQL = "select DISTINCT cDepCode,cCusCode from SO_SOMain where dDate>='" + Date1 + "' and dDate<='" + Date2 + "' ";
            DataTable dts = clsSQLCommond.ExecQuery(sSQL);

            sSQL = "select DISTINCT cPersonCode,cCusCode from SO_SOMain where dDate>='" + Date1 + "' and dDate<='" + Date2 + "'";
            DataTable dts2 = clsSQLCommond.ExecQuery(sSQL);

            for (int i = 1; i < dt.Columns.Count - 1; i++)
            {
                if (统计方式 == "1")
                {
                    dw[i] = dts.Compute("count(cCusCode)", "cDepCode='" + dt.Columns[i].ColumnName + "'");
                    sum = sum + 系统服务.规格化.ReturnDecimal(dw[i], 2);
                }
                else
                {
                    dw[i] = dts2.Compute("count(cCusCode)", "cPersonCode='" + dt.Columns[i].ColumnName + "'");
                    sum = sum + 系统服务.规格化.ReturnDecimal(dw[i]);
                }
            }

            dw["合计"] = 系统服务.规格化.ReturnInt(sum);
            dt.Rows.Add(dw);
        }

        private static void GetRow收款(DataTable dt)
        {
            DataRow dw = dt.NewRow();
            dw["统计项"] = "27";

//            sSQL = @"select b.*,c.cDepCode,a.cPersonCode from SO_CloseBill a left join SO_CloseBillDetails b on a.ID=b.ID 
//            left join (select a.cSOCode as cTypeCode,iMoney,b.cPersonCode,b.cDepCode from SO_SODetails a left join SO_SOMain b on a.ID=b.ID where a.S1='1'
//            union all select cast (iID as varchar(50)),D1,S3,S1 from AR_First 
//            ) c on b.cTypeCode=c.cTypeCode 
//            where dDate>='" + Date1 + "' and dDate<='" + Date2 + "' ";
            decimal sum = 0;
            DataTable dt收款 = 收款.Table(Date1, Date2);
            for (int i = 1; i < dt.Columns.Count - 1; i++)
            {
                if (统计方式 == "1")
                {
                    dw[i] = dt收款.Compute("sum(iAmount)", "cDepCode='" + dt.Columns[i].ColumnName + "'");
                    sum = sum + 系统服务.规格化.ReturnDecimal(dw[i], 2);
                }
                else
                {
                    dw[i] = dt收款.Compute("sum(iAmount)", "cPersonCode='" + dt.Columns[i].ColumnName + "'");
                    sum = sum + 系统服务.规格化.ReturnDecimal(dw[i], 2);
                }
            }

            dw["合计"] = sum;
            dt.Rows.Add(dw);
        }

        private static void GetRow达成否(DataTable dt)
        {
            DataRow dw = dt.NewRow();
            dw["统计项"] = "31";

            for (int i = 1; i < dt.Columns.Count - 1; i++)
            {
                decimal 保底量 = 系统服务.规格化.ReturnDecimal(dt.Select("统计项='11'")[0][i]);
                decimal 保底家数 = 系统服务.规格化.ReturnDecimal(dt.Select("统计项='14'")[0][i]);
                decimal 保底收款 = 系统服务.规格化.ReturnDecimal(dt.Select("统计项='17'")[0][i]);

                decimal 出货量 = 系统服务.规格化.ReturnDecimal(dt.Select("统计项='21'")[0][i]);
                decimal 本期变更出货量 = 系统服务.规格化.ReturnDecimal(dt.Select("统计项='22'")[0][i]);
                decimal 出货家数 = 系统服务.规格化.ReturnDecimal(dt.Select("统计项='24'")[0][i]);
                decimal 收款 = 系统服务.规格化.ReturnDecimal(dt.Select("统计项='27'")[0][i]);
                string str = "达成";
                if (保底量 > 出货量 + 本期变更出货量)
                {
                    str = "未达成";
                }
                if (保底家数 > 出货家数)
                {
                    str = "未达成";
                }
                if (保底收款 > 收款)
                {
                    str = "未达成";
                }
                dw[i] = str;
            }

            dt.Rows.Add(dw);
        }

        private static void GetRow未达成扣款(DataTable dt)
        {
            DataRow dw = dt.NewRow();
            dw["统计项"] = "32";
            dt.Rows.Add(dw);
        }

        private static void GetRow新客户家数(DataTable dt)
        {
            DataRow dw = dt.NewRow();
            dw["统计项"] = "41";

            decimal sum = 0;
            string sSQL = "";
            sSQL = "select DISTINCT cDepCode,cCusCode from SO_SOMain where dDate>='" + Date1 + "' and dDate<='" + Date2 + "' and CusType='1'";
            DataTable dts = clsSQLCommond.ExecQuery(sSQL);

            sSQL = "select DISTINCT cPersonCode,cCusCode from SO_SOMain where dDate>='" + Date1 + "' and dDate<='" + Date2 + "' and CusType='1'";
            DataTable dts2 = clsSQLCommond.ExecQuery(sSQL);

            for (int i = 1; i < dt.Columns.Count - 1; i++)
            {
                if (统计方式 == "1")
                {
                    dw[i] = dts.Compute("count(cCusCode)", "cDepCode='" + dt.Columns[i].ColumnName + "'");
                    sum = sum + 系统服务.规格化.ReturnDecimal(dw[i], 2);
                }
                else
                {
                    dw[i] = dts2.Compute("count(cCusCode)", "cPersonCode='" + dt.Columns[i].ColumnName + "'");
                    sum = sum + 系统服务.规格化.ReturnDecimal(dw[i]);
                }
            }

            dw["合计"] = sum;
            dt.Rows.Add(dw);
        }

        private static void GetRow销售额合计(DataTable dt)
        {
            DataRow dw = dt.NewRow();
            dw["统计项"] = "51";

            decimal sum = 0;

            DataTable dts = 销售.Table(Date1, Date2);
            for (int i = 1; i < dt.Columns.Count - 1; i++)
            {
                if (统计方式 == "1")
                {
                    dw[i] = 系统服务.规格化.ReturnDecimal(dt出货.Compute("sum(iMoney)", "cDepCode='" + dt.Columns[i].ColumnName + "'"), 2);
                    sum = sum + 系统服务.规格化.ReturnDecimal(dw[i], 2);
                }
                else
                {
                    dw[i] = 系统服务.规格化.ReturnDecimal(dt出货.Compute("sum(iMoney)", "cPersonCode='" + dt.Columns[i].ColumnName + "'"), 2);
                    sum = sum + 系统服务.规格化.ReturnDecimal(dw[i]);
                }
            }

            dw["合计"] = sum;
            dt.Rows.Add(dw);
        }

        private static void GetRow应收款(DataTable dt)
        {
            #region 应收款
            if (1 == 1)
            {
                DataTable dts = 应收款.Table(Date2, "", "");
                DataRow dw = dt.NewRow();
                dw["统计项"] = "61";

                decimal sum = 0;


                for (int i = 1; i < dt.Columns.Count - 1; i++)
                {
                    if (统计方式 == "1")
                    {
                        dw[i] = dts.Compute("sum(iMoney)", "cDepCode='" + dt.Columns[i].ColumnName + "'");
                        sum = sum + 系统服务.规格化.ReturnDecimal(dw[i], 2);
                    }
                    else
                    {
                        dw[i] = dts.Compute("sum(iMoney)", "cPersonCode='" + dt.Columns[i].ColumnName + "'");
                        sum = sum + 系统服务.规格化.ReturnDecimal(dw[i]);
                    }
                }

                dw["合计"] = sum;
                dt.Rows.Add(dw);
            }
            #endregion

            #region 90-180天应收款
            if (1 == 1)
            {
                DataTable dts = 应收款.账龄("", Date2,DateTime.Parse(Date2).AddDays(-180).ToString("yyyy-MM-dd"), DateTime.Parse(Date2).AddDays(-90).ToString("yyyy-MM-dd"));
                DataRow dw = dt.NewRow();
                dw["统计项"] = "71";

                decimal sum = 0;

                for (int i = 1; i < dt.Columns.Count - 1; i++)
                {
                    if (统计方式 == "1")
                    {
                        dw[i] = dts.Compute("sum(iMoney)", "cDepCode='" + dt.Columns[i].ColumnName + "'");
                        sum = sum + 系统服务.规格化.ReturnDecimal(dw[i], 2);
                    }
                    else
                    {
                        dw[i] = dts.Compute("sum(iMoney)", "cPersonCode='" + dt.Columns[i].ColumnName + "'");
                        sum = sum + 系统服务.规格化.ReturnDecimal(dw[i]);
                    }
                }

                dw["合计"] = sum;
                dt.Rows.Add(dw);
            }
            #endregion

            #region 扣款额(1)
            if (1 == 1)
            {
                DataRow dw = dt.NewRow();
                dw["统计项"] = "72";
                dt.Rows.Add(dw);
            }
            #endregion

            #region 180天以上应收款
            if (1 == 1)
            {
                DataTable dts = 应收款.账龄("", Date2, "",DateTime.Parse(Date2).AddDays(-180).ToString("yyyy-MM-dd"));
                DataRow dw = dt.NewRow();
                dw["统计项"] = "81";

                decimal sum = 0;


                for (int i = 1; i < dt.Columns.Count - 1; i++)
                {
                    if (统计方式 == "1")
                    {
                        dw[i] = dts.Compute("sum(iMoney)", "cDepCode='" + dt.Columns[i].ColumnName + "'");
                        sum = sum + 系统服务.规格化.ReturnDecimal(dw[i], 2);
                    }
                    else
                    {
                        dw[i] = dts.Compute("sum(iMoney)", "cPersonCode='" + dt.Columns[i].ColumnName + "'");
                        sum = sum + 系统服务.规格化.ReturnDecimal(dw[i]);
                    }
                }

                dw["合计"] = sum;
                dt.Rows.Add(dw);
            }
            #endregion

            #region 扣款额(2)
            if (1 == 1)
            {
                DataRow dw = dt.NewRow();
                dw["统计项"] = "82";
                dt.Rows.Add(dw);
            }
            #endregion

            #region 180天以上应收款返款
            if (1 == 1)
            {
                DataRow dw = dt.NewRow();
                dw["统计项"] = "83";
                dt.Rows.Add(dw);
            }
            #endregion
        }

        private static void GetRow销售费用合计(DataTable dt)
        {
            string sSQL = "";
            sSQL = @"select SS2,SS1,a.DD,D1,出差费用 ,a.D2,a.D4 from (
select SS2,SS1,sum(cast(isnull(D6,0)+isnull(D7,0) as decimal(18, 2))) as DD,
sum(cast(D1 as decimal(18, 2))) as D1,sum(cast(D2 as decimal(18, 2))) as D2,
sum(cast(D4 as decimal(18, 2))) as D4 from OperationalCosts a left join OperationalCostsDetails b on a.ID=b.ID
 where dDate>='" + Date1 + "' and dDate<='" + Date2 + "'  group by SS2,SS1) a left join (select S3,sum(D4) as 出差费用 from Mileage where I2 in (" + 月 + ") group by S3) b on a.SS1=b.S3";
            dt出差费 = clsSQLCommond.ExecQuery(sSQL);
            if (1 == 1)//公关费
            {
                DataRow dw = dt.NewRow();
                dw["统计项"] = "91";

                decimal sum = 0;

                for (int i = 1; i < dt.Columns.Count - 1; i++)
                {
                    if (统计方式 == "1")
                    {
                        dw[i] = dt出差费.Compute("sum(DD)", "SS2='" + dt.Columns[i].ColumnName + "'");
                        sum = sum + 系统服务.规格化.ReturnDecimal(dw[i], 2);
                    }
                    else
                    {
                        dw[i] = dt出差费.Compute("sum(DD)", "SS1='" + dt.Columns[i].ColumnName + "'");
                        sum = sum + 系统服务.规格化.ReturnDecimal(dw[i]);
                    }
                }

                dw["合计"] = sum;
                dt.Rows.Add(dw);
            }

            if (1 == 1)//出差费
            {
                DataRow dw = dt.NewRow();
                dw["统计项"] = "92";

                decimal sum = 0;


                for (int i = 1; i < dt.Columns.Count - 1; i++)
                {
                    if (统计方式 == "1")
                    {
                        dw[i] = dt出差费.Compute("sum(D1)", "SS2='" + dt.Columns[i].ColumnName + "'");
                        sum = sum + 系统服务.规格化.ReturnDecimal(dw[i], 2);
                    }
                    else
                    {
                        dw[i] = dt出差费.Compute("sum(D1)", "SS1='" + dt.Columns[i].ColumnName + "'");
                        sum = sum + 系统服务.规格化.ReturnDecimal(dw[i]);
                    }
                }

                dw["合计"] = sum;
                dt.Rows.Add(dw);
            }

            if (1 == 1)//油费
            {
                DataRow dw = dt.NewRow();
                dw["统计项"] = "93";

                decimal sum = 0;


                for (int i = 1; i < dt.Columns.Count - 1; i++)
                {
                    if (统计方式 == "1")
                    {
                        dw[i] = dt出差费.Compute("sum(D2)", "SS2='" + dt.Columns[i].ColumnName + "'");
                        sum = sum + 系统服务.规格化.ReturnDecimal(dw[i], 2);
                    }
                    else
                    {
                        dw[i] = dt出差费.Compute("sum(D2)", "SS1='" + dt.Columns[i].ColumnName + "'");
                        sum = sum + 系统服务.规格化.ReturnDecimal(dw[i]);
                    }
                }

                dw["合计"] = sum;
                dt.Rows.Add(dw);
            }

            if (1 == 1)//其他
            {
                DataRow dw = dt.NewRow();
                dw["统计项"] = "94";

                decimal sum = 0;


                for (int i = 1; i < dt.Columns.Count - 1; i++)
                {
                    if (统计方式 == "1")
                    {
                        dw[i] = dt出差费.Compute("sum(D4)", "SS2='" + dt.Columns[i].ColumnName + "'");
                        sum = sum + 系统服务.规格化.ReturnDecimal(dw[i], 2);
                    }
                    else
                    {
                        dw[i] = dt出差费.Compute("sum(D4)", "SS1='" + dt.Columns[i].ColumnName + "'");
                        sum = sum + 系统服务.规格化.ReturnDecimal(dw[i]);
                    }
                }

                dw["合计"] = sum;
                dt.Rows.Add(dw);
            }
            if (1 == 1)//销售费用合计
            {
                DataRow dw = dt.NewRow();
                dw["统计项"] = "95";

                int iRow = dt.Rows.Count;
                decimal sum = 0;
                for (int i = 1; i < dt.Columns.Count - 1; i++)
                {
                    dw[i] = 系统服务.规格化.ReturnDecimal(dt.Select("统计项='91'")[0][i])
                        + 系统服务.规格化.ReturnDecimal(dt.Select("统计项='92'")[0][i])
                        + 系统服务.规格化.ReturnDecimal(dt.Select("统计项='93'")[0][i])
                        + 系统服务.规格化.ReturnDecimal(dt.Select("统计项='94'")[0][i]);
                    sum = sum + 系统服务.规格化.ReturnDecimal(dt.Select("统计项='91'")[0][i])
                        + 系统服务.规格化.ReturnDecimal(dt.Select("统计项='92'")[0][i])
                        + 系统服务.规格化.ReturnDecimal(dt.Select("统计项='93'")[0][i])
                        + 系统服务.规格化.ReturnDecimal(dt.Select("统计项='94'")[0][i]);
                }
                dw["合计"] = sum;
                dt.Rows.Add(dw);
            }

            if (1 == 1)//车辆里程金额
            {
                DataRow dw = dt.NewRow();
                dw["统计项"] = "96";

                decimal sum = 0;


                for (int i = 1; i < dt.Columns.Count - 1; i++)
                {
                    if (统计方式 == "1")
                    {
                        dw[i] = dt出差费.Compute("sum(出差费用)", "SS2='" + dt.Columns[i].ColumnName + "'");
                        sum = sum + 系统服务.规格化.ReturnDecimal(dw[i], 2);
                    }
                    else
                    {
                        dw[i] = dt出差费.Compute("sum(出差费用)", "SS1='" + dt.Columns[i].ColumnName + "'");
                        sum = sum + 系统服务.规格化.ReturnDecimal(dw[i]);
                    }
                }

                dw["合计"] = sum;
                dt.Rows.Add(dw);
            }

            if (1 == 1)//规定出差费用
            {
                DataRow dw = dt.NewRow();
                dw["统计项"] = "101";
                decimal sum = 0;
                for (int i = 1; i < dt.Columns.Count - 1; i++)
                {
                    decimal 出货 = 系统服务.规格化.ReturnDecimal(dt.Select("统计项='21'")[0][i]) + 系统服务.规格化.ReturnDecimal(dt.Select("统计项='22'")[0][i]);
                    decimal 计划 = 系统服务.规格化.ReturnDecimal(dt.Select("统计项='1'")[0][i]);
                    decimal 费用 = 系统服务.规格化.ReturnDecimal(dt.Select("统计项='92'")[0][i]) + 系统服务.规格化.ReturnDecimal(dt.Select("统计项='93'")[0][i]);


                    if (计划 != 0)
                    {
                        decimal imoney = (出货 / 计划) * 费用;
                        dw[i] = imoney;

                        sum = sum + imoney;
                    }
                }
                dw["合计"] = sum;
                dt.Rows.Add(dw);
            }

            #region 扣款额(3)
            if (1 == 1)
            {
                DataRow dw = dt.NewRow();
                dw["统计项"] = "102";
                int iRow = dt.Rows.Count;
                decimal sum = 0;
                sSQL = "select PersonCode from Person where Date8<'" + Date2 + "' and Date8 is not null";
                DataTable dts = clsSQLCommond.ExecQuery(sSQL);
                for (int i = 1; i < dt.Columns.Count - 1; i++)
                {
                    decimal d1 = 系统服务.规格化.ReturnDecimal(dt.Select("统计项='92'")[0][i]) + 系统服务.规格化.ReturnDecimal(dt.Select("统计项='93'")[0][i]);
                    decimal 规定 = 系统服务.规格化.ReturnDecimal(dt.Select("统计项='101'")[0][i]);
                    decimal 车辆 = 系统服务.规格化.ReturnDecimal(dt.Select("统计项='96'")[0][i]);
                    if (规定 > 车辆 && 车辆 != 0)
                    {
                        规定 = 车辆;
                    }
                    DataRow[] dwper = dts.Select("PersonCode='" + dt.Columns[i].ColumnName + "'");

                    if (规定 - d1 < 0 && dwper.Length > 0)
                    {

                        dw[i] = 规定 - d1;
                        sum = sum + 规定 - d1;
                    }
                }
                dw["合计"] = sum;
                dt.Rows.Add(dw);
            }
            #endregion
        }

        private static void GetRow业务招待费用(DataTable dt)
        {
            string sSQL = "";
            if (1 == 1)
            {
                DataRow dw = dt.NewRow();
                dw["统计项"] = "111";

                decimal sum = 0;
                for (int i = 1; i < dt.Columns.Count - 1; i++)
                {
                    if (统计方式 == "1")
                    {
                        dw[i] = 系统服务.规格化.ReturnDecimal(dt出货.Compute("sum(业务招待费)", "cDepCode='" + dt.Columns[i].ColumnName + "'"), 2);
                        sum = sum + 系统服务.规格化.ReturnDecimal(dw[i], 2);
                    }
                    else
                    {
                        dw[i] = 系统服务.规格化.ReturnDecimal(dt出货.Compute("sum(业务招待费)", "cPersonCode='" + dt.Columns[i].ColumnName + "'"), 2);
                        sum = sum + 系统服务.规格化.ReturnDecimal(dw[i]);
                    }
                }

                dw["合计"] = sum;
                dt.Rows.Add(dw);
            }

            #region 规定业务招待费
            if (1 == 1)
            {
                DataRow dw = dt.NewRow();
                dw["统计项"] = "112";
                decimal sum = 0;

                
                for (int i = 1; i < dt.Columns.Count - 1; i++)
                {
                    DataRow[] dwyw = dt.Select("统计项='21'");
                    if (dwyw.Length > 0)
                    {
                        decimal yw = 系统服务.规格化.ReturnDecimal(dwyw[0][i]) * 500 / 1000;
                        dw[i] = yw.ToString();
                        sum = sum + 系统服务.规格化.ReturnDecimal(yw, 2);
                    }
                    
                    
                }

                dw["合计"] = sum;
                dt.Rows.Add(dw);
            }
            #endregion

            #region 差额
            if (1 == 1)
            {
                DataRow dw = dt.NewRow();
                dw["统计项"] = "113";
                int iRow = dt.Rows.Count;
                decimal sum = 0;
                for (int i = 1; i < dt.Columns.Count - 1; i++)
                {
                    dw[i] = 系统服务.规格化.ReturnDecimal(dt.Rows[iRow - 1][i]) - 系统服务.规格化.ReturnDecimal(dt.Rows[iRow - 2][i]);
                    sum = sum + 系统服务.规格化.ReturnDecimal(dt.Rows[iRow - 1][i]) - 系统服务.规格化.ReturnDecimal(dt.Rows[iRow - 2][i]);
                }
                dw["合计"] = sum;
                dt.Rows.Add(dw);
            }
            #endregion
        }

        private static void GetRow出货利润(DataTable dt)
        {
            if (1 == 1)
            {
                DataRow dw = dt.NewRow();
                dw["统计项"] = "121";

                decimal sum = 0;

                for (int i = 1; i < dt.Columns.Count - 1; i++)
                {
                    if (统计方式 == "1")
                    {
                        dw[i] = 系统服务.规格化.ReturnDecimal(dt出货.Compute("sum(利润)", "cDepCode='" + dt.Columns[i].ColumnName + "'"));
                        sum = sum + 系统服务.规格化.ReturnDecimal(dt出货.Compute("sum(利润)", "cDepCode='" + dt.Columns[i].ColumnName + "'"));
                    }
                    else
                    {
                        dw[i] = 系统服务.规格化.ReturnDecimal(dt出货.Compute("sum(利润)", "cPersonCode='" + dt.Columns[i].ColumnName + "'"));
                        sum = sum + 系统服务.规格化.ReturnDecimal(dt出货.Compute("sum(利润)", "cPersonCode='" + dt.Columns[i].ColumnName + "'"));
                    }
                }

                dw["合计"] = sum;
                dt.Rows.Add(dw);
            }
            if (1 == 1)
            {
                DataRow dw = dt.NewRow();
                dw["统计项"] = "131";

                decimal sum = 0;
                for (int i = 1; i < dt.Columns.Count - 1; i++)
                {
                    if (统计方式 == "1")
                    {
                        dw[i] = 系统服务.规格化.ReturnDecimal(dt出货.Compute("sum(收款利润)", "cDepCode='" + dt.Columns[i].ColumnName + "' and Flag='1'"));
                        sum = sum + 系统服务.规格化.ReturnDecimal(dt出货.Compute("sum(收款利润)", "cDepCode='" + dt.Columns[i].ColumnName + "' and Flag='1'"));
                    }
                    else
                    {
                        dw[i] = 系统服务.规格化.ReturnDecimal(dt出货.Compute("sum(收款利润)", "cPersonCode='" + dt.Columns[i].ColumnName + "' and Flag='1'"));
                        sum = sum + 系统服务.规格化.ReturnDecimal(dt出货.Compute("sum(收款利润)", "cPersonCode='" + dt.Columns[i].ColumnName + "' and Flag='1'"));
                    }
                }

                dw["合计"] = sum;
                dt.Rows.Add(dw);
            }
            if (1 == 1)
            {
                DataRow dw = dt.NewRow();
                dw["统计项"] = "132";

                decimal sum = 0;
                for (int i = 1; i < dt.Columns.Count - 1; i++)
                {
                    if (统计方式 == "1")
                    {
                        dw[i] = 系统服务.规格化.ReturnDecimal(dt出货.Compute("sum(收款利润)", "cDepCode='" + dt.Columns[i].ColumnName + "' and Flag='2'"));
                        sum = sum + 系统服务.规格化.ReturnDecimal(dt出货.Compute("sum(收款利润)", "cDepCode='" + dt.Columns[i].ColumnName + "' and Flag='2'"));
                    }
                    else
                    {
                        dw[i] = 系统服务.规格化.ReturnDecimal(dt出货.Compute("sum(收款利润)", "cPersonCode='" + dt.Columns[i].ColumnName + "' and Flag='2'"));
                        sum = sum + 系统服务.规格化.ReturnDecimal(dt出货.Compute("sum(收款利润)", "cPersonCode='" + dt.Columns[i].ColumnName + "' and Flag='2'"));
                    }
                }

                dw["合计"] = sum;
                dt.Rows.Add(dw);
            }


            if (1 == 1)
            {
                DataRow dw = dt.NewRow();
                dw["统计项"] = "141";

                decimal sum = 0;


                for (int i = 1; i < dt.Columns.Count - 1; i++)
                {
                    if (统计方式 == "1")
                    {
                        dw[i] = 系统服务.规格化.ReturnDecimal(dt出货.Compute("sum(个人利润)", "cDepCode='" + dt.Columns[i].ColumnName + "' and Flag='1'"));
                        sum = sum + 系统服务.规格化.ReturnDecimal(dt出货.Compute("sum(个人利润)", "cDepCode='" + dt.Columns[i].ColumnName + "' and Flag='1'"));
                    }
                    else
                    {
                        dw[i] = 系统服务.规格化.ReturnDecimal(dt出货.Compute("sum(个人利润)", "cPersonCode='" + dt.Columns[i].ColumnName + "' and Flag='1'"));
                        sum = sum + 系统服务.规格化.ReturnDecimal(dt出货.Compute("sum(个人利润)", "cPersonCode='" + dt.Columns[i].ColumnName + "' and Flag='1'"));
                    }
                }

                dw["合计"] = sum;
                dt.Rows.Add(dw);
            }

            if (1 == 1)
            {
                DataRow dw = dt.NewRow();
                dw["统计项"] = "142";

                decimal sum = 0;


                for (int i = 1; i < dt.Columns.Count - 1; i++)
                {
                    if (统计方式 == "1")
                    {
                        dw[i] = 系统服务.规格化.ReturnDecimal(dt出货.Compute("sum(个人利润)", "cDepCode='" + dt.Columns[i].ColumnName + "' and Flag='2'"));
                        sum = sum + 系统服务.规格化.ReturnDecimal(dt出货.Compute("sum(个人利润)", "cDepCode='" + dt.Columns[i].ColumnName + "' and Flag='2'"));
                    }
                    else
                    {
                        dw[i] = 系统服务.规格化.ReturnDecimal(dt出货.Compute("sum(个人利润)", "cPersonCode='" + dt.Columns[i].ColumnName + "' and Flag='2'"));
                        sum = sum + 系统服务.规格化.ReturnDecimal(dt出货.Compute("sum(个人利润)", "cPersonCode='" + dt.Columns[i].ColumnName + "' and Flag='2'"));
                    }
                }

                dw["合计"] = sum;
                dt.Rows.Add(dw);
            }
        }

        private static void GetRow累计出货数量(DataTable dt)
        {
            DataRow dw = dt.NewRow();
            dw["统计项"] = "28";

            decimal sum = 0;


            DataTable dts = 出货.Table(DateTime.Parse(Date2).Year.ToString() + "-01-01", Date2);
            for (int i = 1; i < dt.Columns.Count - 1; i++)
            {
                if (统计方式 == "1")
                {
                    dw[i] = dts.Compute("sum(iQuantity)", "cDepCode='" + dt.Columns[i].ColumnName + "'");
                    sum = sum + 系统服务.规格化.ReturnDecimal(dw[i], 2);
                }
                else
                {
                    dw[i] = dts.Compute("sum(iQuantity)", "cPersonCode='" + dt.Columns[i].ColumnName + "'");
                    sum = sum + 系统服务.规格化.ReturnDecimal(dw[i], 2);
                }
            }

            dw["合计"] = sum;
            dt.Rows.Add(dw);
        }

        private static void GetRow退货量(DataTable dt)
        {
            //退货量
            if (1 == 1)
            {
                DataRow dw = dt.NewRow();
                dw["统计项"] = "151";

                decimal sum = 0;

                string sSQL = @"select cDepCode,cPersonCode,cCusCode,-iQuantity as iQuantity from SO_SOReturn a left join SO_SOReturns b on a.ID=b.ID 
            where dDate>='" + Date1 + "' and dDate<='" + Date2 + "'";
                DataTable dts = clsSQLCommond.ExecQuery(sSQL);
                for (int i = 1; i < dt.Columns.Count - 1; i++)
                {
                    if (统计方式 == "1")
                    {
                        dw[i] = dts.Compute("sum(iQuantity)", "cDepCode='" + dt.Columns[i].ColumnName + "'");
                        sum = sum + 系统服务.规格化.ReturnDecimal(dw[i], 2);
                    }
                    else
                    {
                        dw[i] = dts.Compute("sum(iQuantity)", "cPersonCode='" + dt.Columns[i].ColumnName + "'");
                        sum = sum + 系统服务.规格化.ReturnDecimal(dw[i], 2);
                    }
                }

                dw["合计"] = sum;
                dt.Rows.Add(dw);
            }

            //允许退货量
            if (1 == 1)
            {
                DataRow dw = dt.NewRow();
                dw["统计项"] = "152";

                decimal sum = 0;

                for (int i = 1; i < dt.Columns.Count - 1; i++)
                {
                    dw[i] = (系统服务.规格化.ReturnDecimal(dt.Select("统计项='21'")[0][i]) + 系统服务.规格化.ReturnDecimal(dt.Select("统计项='22'")[0][i]))*0.05M;
                    sum = sum + 系统服务.规格化.ReturnDecimal(dw[i], 2);
                }

                dw["合计"] = sum;
                dt.Rows.Add(dw);
            }

            //退货超过部分
            if (1 == 1)
            {
                DataRow dw = dt.NewRow();
                dw["统计项"] = "153";

                decimal sum = 0;

                for (int i = 1; i < dt.Columns.Count - 1; i++)
                {
                    dw[i] = (系统服务.规格化.ReturnDecimal(dt.Select("统计项='152'")[0][i])-系统服务.规格化.ReturnDecimal(dt.Select("统计项='151'")[0][i]))/1000M;
                    sum = sum + 系统服务.规格化.ReturnDecimal(dw[i], 2);
                }

                dw["合计"] = sum;
                dt.Rows.Add(dw);
            }
        }

        private static void GetRow样品(DataTable dt)
        {
            //样品用量
            if (1 == 1)
            {
                DataRow dw = dt.NewRow();
                dw["统计项"] = "161";

                decimal sum = 0;

                for (int i = 1; i < dt.Columns.Count - 1; i++)
                {
                    if (统计方式 == "1")
                    {
                        dw[i] = dt出货.Compute("sum(iSampleQuantity)", "cDepCode='" + dt.Columns[i].ColumnName + "'");
                        sum = sum + 系统服务.规格化.ReturnDecimal(dw[i], 2);
                    }
                    else
                    {
                        dw[i] = dt出货.Compute("sum(iSampleQuantity)", "cPersonCode='" + dt.Columns[i].ColumnName + "'");
                        sum = sum + 系统服务.规格化.ReturnDecimal(dw[i], 2);
                    }
                }

                dw["合计"] = sum;
                dt.Rows.Add(dw);
            }

            //允许样品量
            if (1 == 1)
            {
                DataRow dw = dt.NewRow();
                dw["统计项"] = "162";

                decimal sum = 0;

                for (int i = 1; i < dt.Columns.Count - 1; i++)
                {
                    dw[i] = (系统服务.规格化.ReturnDecimal(dt.Select("统计项='21'")[0][i]) + 系统服务.规格化.ReturnDecimal(dt.Select("统计项='22'")[0][i])) / 1000M;
                    sum = sum + 系统服务.规格化.ReturnDecimal(dw[i], 2);
                }

                dw["合计"] = sum;
                dt.Rows.Add(dw);
            }

            //退货超过部分
            if (1 == 1)
            {
                DataRow dw = dt.NewRow();
                dw["统计项"] = "163";

                decimal sum = 0;

                for (int i = 1; i < dt.Columns.Count - 1; i++)
                {
                    dw[i] = (系统服务.规格化.ReturnDecimal(dt.Select("统计项='162'")[0][i])) * 20M;
                    sum = sum + 系统服务.规格化.ReturnDecimal(dw[i], 2);
                }

                dw["合计"] = sum;
                dt.Rows.Add(dw);
            }
        }


        private static void GetSave(DataTable dt, DataTable dts)
        {

            string sSQL = "select * from " + tablename + " where 1=-1";
            DataTable dtupdate = clsSQLCommond.ExecQuery(sSQL);

            System.Collections.ArrayList aList = new System.Collections.ArrayList();

            sSQL = "delete from " + tablename + " where Quarter='" + 季度 + "'";
            aList.Add(sSQL);

            #region 子表

            string datetimeadd=DateTime.Now.ToString();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (dt.Columns[j].ColumnName != "统计项" && dt.Columns[j].ColumnName != "合计")
                    {
                        DataRow drh = dtupdate.NewRow();

                        drh["Quarter"] = 季度;
                        drh["PersonCode"] = dt.Columns[j].ColumnName;
                        drh["cDepCode"] = dts.Select("PersonCode='" + dt.Columns[j].ColumnName + "'")[0]["cDepCode"].ToString().Trim();
                        drh["iType"] = dt.Rows[i]["统计项"].ToString();

                        drh["iValue1"] = dt.Rows[i][j].ToString();
                        drh["iValue2"] = dt.Rows[i][j].ToString();
                        drh["dCreatesysTime"] = datetimeadd;
                        drh["dCreatesysPerson"] = 系统服务.ClsBaseDataInfo.sUid;
                        dtupdate.Rows.Add(drh);

                        sSQL = clsGetSQL.GetInsertSQL(系统服务.ClsBaseDataInfo.sDataBaseName, tablename, dtupdate, dtupdate.Rows.Count - 1);
                        aList.Add(sSQL);
                    }
                }
            }
            #endregion



            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("保存成功！\n合计执行语句:" + iCou + "条");
            }
        }

        private static void GetRow表头(DataTable dt)
        {
            string sSQL = "";
            if (统计方式 == "1")
            {
                sSQL = "select * from Department  ";
                DataTable dts = clsSQLCommond.ExecQuery(sSQL);

                for (int i = 1; i < dt.Columns.Count - 1; i++)
                {
                    if (dt.Columns[i].ColumnName != "公司个人")
                    {
                        dt.Columns[i].ColumnName = dts.Compute("max(cDepName)", "cDepCode='" + dt.Columns[i].ColumnName + "'").ToString();
                    }
                }
            }
            else
            {
                sSQL = "select * from Person  ";
                DataTable dts = clsSQLCommond.ExecQuery(sSQL);

                for (int i = 1; i < dt.Columns.Count - 1; i++)
                {
                    dt.Columns[i].ColumnName = dts.Compute("max(PersonName)", "PersonCode='" + dt.Columns[i].ColumnName + "'").ToString();
                }
            }

            sSQL = "select * from  _LookUpDate where iType=33";
            DataTable dtss = clsSQLCommond.ExecQuery(sSQL);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow[] dw=dtss.Select("iID='"+dt.Rows[i]["统计项"].ToString()+"'");
                if(dw.Length>0)
                {
                    dt.Rows[i]["统计项"] = dw[0]["iText"].ToString();
                }
            }
        }

    }
}
