using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace 成衣生产.DAL
{
    /// <summary>
    /// 数据访问类:订单
    /// </summary>
    public partial class 订单
    {
        public 订单()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public string Exists(long iID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from 订单");
            strSql.Append(" where iID=" + iID + " ");
            return  (strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(成衣生产.Model.订单 model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.产品档案iID != null)
            {
                strSql1.Append("产品档案iID,");
                strSql2.Append("" + model.产品档案iID + ",");
            }
            if (model.单据日期 != null)
            {
                strSql1.Append("单据日期,");
                strSql2.Append("'" + model.单据日期 + "',");
            }
            if (model.联系电话 != null)
            {
                strSql1.Append("联系电话,");
                strSql2.Append("'" + model.联系电话 + "',");
            }
            if (model.客户 != null)
            {
                strSql1.Append("客户,");
                strSql2.Append("'" + model.客户 + "',");
            }
            if (model.备注 != null)
            {
                strSql1.Append("备注,");
                strSql2.Append("'" + model.备注 + "',");
            }
            if (model.制单人 != null)
            {
                strSql1.Append("制单人,");
                strSql2.Append("'" + model.制单人 + "',");
            }
            if (model.制单日期 != null)
            {
                strSql1.Append("制单日期,");
                strSql2.Append("'" + model.制单日期 + "',");
            }
            if (model.审核人 != null)
            {
                strSql1.Append("审核人,");
                strSql2.Append("'" + model.审核人 + "',");
            }
            if (model.审核日期 != null)
            {
                strSql1.Append("审核日期,");
                strSql2.Append("'" + model.审核日期 + "',");
            }
            if (model.关闭人 != null)
            {
                strSql1.Append("关闭人,");
                strSql2.Append("'" + model.关闭人 + "',");
            }
            if (model.关闭日期 != null)
            {
                strSql1.Append("关闭日期,");
                strSql2.Append("'" + model.关闭日期 + "',");
            }
            if (model.变更人 != null)
            {
                strSql1.Append("变更人,");
                strSql2.Append("'" + model.变更人 + "',");
            }
            if (model.变更日期 != null)
            {
                strSql1.Append("变更日期,");
                strSql2.Append("'" + model.变更日期 + "',");
            }
            if (model.打印次数 != null)
            {
                strSql1.Append("打印次数,");
                strSql2.Append("" + model.打印次数 + ",");
            }
            if (model.最后打印日期 != null)
            {
                strSql1.Append("最后打印日期,");
                strSql2.Append("'" + model.最后打印日期 + "',");
            }
            if (model.类别 != null)
            {
                strSql1.Append("类别,");
                strSql2.Append("'" + model.类别 + "',");
            }
            if (model.款号 != null)
            {
                strSql1.Append("款号,");
                strSql2.Append("'" + model.款号 + "',");
            }
            if (model.交货期 != null)
            {
                strSql1.Append("交货期,");
                strSql2.Append("'" + model.交货期 + "',");
            }
            if (model.数量 != null)
            {
                strSql1.Append("数量,");
                strSql2.Append("" + model.数量 + ",");
            }
            if (model.生产 != null)
            {
                strSql1.Append("生产,");
                strSql2.Append("'" + model.生产 + "',");
            }
            if (model.纱种 != null)
            {
                strSql1.Append("纱种,");
                strSql2.Append("'" + model.纱种 + "',");
            }
            if (model.领形 != null)
            {
                strSql1.Append("领形,");
                strSql2.Append("'" + model.领形 + "',");
            }
            if (model.针型 != null)
            {
                strSql1.Append("针型,");
                strSql2.Append("'" + model.针型 + "',");
            }
            if (model.身高 != null)
            {
                strSql1.Append("身高,");
                strSql2.Append("" + model.身高 + ",");
            }
            if (model.体重 != null)
            {
                strSql1.Append("体重,");
                strSql2.Append("" + model.体重 + ",");
            }
            if (model.胸围 != null)
            {
                strSql1.Append("胸围,");
                strSql2.Append("" + model.胸围 + ",");
            }
            if (model.胸围杯型 != null)
            {
                strSql1.Append("胸围杯型,");
                strSql2.Append("" + model.胸围杯型 + ",");
            }
            if (model.身长 != null)
            {
                strSql1.Append("身长,");
                strSql2.Append("" + model.身长 + ",");
            }
            if (model.肩宽 != null)
            {
                strSql1.Append("肩宽,");
                strSql2.Append("" + model.肩宽 + ",");
            }
            if (model.袖长 != null)
            {
                strSql1.Append("袖长,");
                strSql2.Append("" + model.袖长 + ",");
            }
            if (model.腰围 != null)
            {
                strSql1.Append("腰围,");
                strSql2.Append("" + model.腰围 + ",");
            }
            if (model.下摆宽 != null)
            {
                strSql1.Append("下摆宽,");
                strSql2.Append("" + model.下摆宽 + ",");
            }
            if (model.领深 != null)
            {
                strSql1.Append("领深,");
                strSql2.Append("" + model.领深 + ",");
            }
            if (model.主色 != null)
            {
                strSql1.Append("主色,");
                strSql2.Append("'" + model.主色 + "',");
            }
            if (model.配色1 != null)
            {
                strSql1.Append("配色1,");
                strSql2.Append("'" + model.配色1 + "',");
            }
            if (model.配色2 != null)
            {
                strSql1.Append("配色2,");
                strSql2.Append("'" + model.配色2 + "',");
            }
            if (model.配色3 != null)
            {
                strSql1.Append("配色3,");
                strSql2.Append("'" + model.配色3 + "',");
            }
            if (model.配色4 != null)
            {
                strSql1.Append("配色4,");
                strSql2.Append("'" + model.配色4 + "',");
            }
            if (model.配色5 != null)
            {
                strSql1.Append("配色5,");
                strSql2.Append("'" + model.配色5 + "',");
            }
            if (model.主色用纱量 != null)
            {
                strSql1.Append("主色用纱量,");
                strSql2.Append("" + model.主色用纱量 + ",");
            }
            if (model.配色1用纱量 != null)
            {
                strSql1.Append("配色1用纱量,");
                strSql2.Append("" + model.配色1用纱量 + ",");
            }
            if (model.配色2用纱量 != null)
            {
                strSql1.Append("配色2用纱量,");
                strSql2.Append("" + model.配色2用纱量 + ",");
            }
            if (model.配色3用纱量 != null)
            {
                strSql1.Append("配色3用纱量,");
                strSql2.Append("" + model.配色3用纱量 + ",");
            }
            if (model.配色4用纱量 != null)
            {
                strSql1.Append("配色4用纱量,");
                strSql2.Append("" + model.配色4用纱量 + ",");
            }
            if (model.配色5用纱量 != null)
            {
                strSql1.Append("配色5用纱量,");
                strSql2.Append("" + model.配色5用纱量 + ",");
            }
            strSql.Append("insert into 订单(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            return (strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string Update(成衣生产.Model.订单 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update 订单 set ");
            if (model.产品档案iID != null)
            {
                strSql.Append("产品档案iID=" + model.产品档案iID + ",");
            }
            if (model.单据日期 != null)
            {
                strSql.Append("单据日期='" + model.单据日期 + "',");
            }
            if (model.联系电话 != null)
            {
                strSql.Append("联系电话='" + model.联系电话 + "',");
            }
            else
            {
                strSql.Append("联系电话= null ,");
            }
            if (model.客户 != null)
            {
                strSql.Append("客户='" + model.客户 + "',");
            }
            if (model.备注 != null)
            {
                strSql.Append("备注='" + model.备注 + "',");
            }
            else
            {
                strSql.Append("备注= null ,");
            }
            if (model.制单人 != null)
            {
                strSql.Append("制单人='" + model.制单人 + "',");
            }
            if (model.制单日期 != null)
            {
                strSql.Append("制单日期='" + model.制单日期 + "',");
            }
            if (model.审核人 != null)
            {
                strSql.Append("审核人='" + model.审核人 + "',");
            }
            else
            {
                strSql.Append("审核人= null ,");
            }
            if (model.审核日期 != null)
            {
                strSql.Append("审核日期='" + model.审核日期 + "',");
            }
            else
            {
                strSql.Append("审核日期= null ,");
            }
            if (model.关闭人 != null)
            {
                strSql.Append("关闭人='" + model.关闭人 + "',");
            }
            else
            {
                strSql.Append("关闭人= null ,");
            }
            if (model.关闭日期 != null)
            {
                strSql.Append("关闭日期='" + model.关闭日期 + "',");
            }
            else
            {
                strSql.Append("关闭日期= null ,");
            }
            if (model.变更人 != null)
            {
                strSql.Append("变更人='" + model.变更人 + "',");
            }
            else
            {
                strSql.Append("变更人= null ,");
            }
            if (model.变更日期 != null)
            {
                strSql.Append("变更日期='" + model.变更日期 + "',");
            }
            else
            {
                strSql.Append("变更日期= null ,");
            }
            if (model.打印次数 != null)
            {
                strSql.Append("打印次数=" + model.打印次数 + ",");
            }
            else
            {
                strSql.Append("打印次数= null ,");
            }
            if (model.最后打印日期 != null)
            {
                strSql.Append("最后打印日期='" + model.最后打印日期 + "',");
            }
            else
            {
                strSql.Append("最后打印日期= null ,");
            }
            if (model.类别 != null)
            {
                strSql.Append("类别='" + model.类别 + "',");
            }
            else
            {
                strSql.Append("类别= null ,");
            }
            if (model.款号 != null)
            {
                strSql.Append("款号='" + model.款号 + "',");
            }
            if (model.交货期 != null)
            {
                strSql.Append("交货期='" + model.交货期 + "',");
            }
            else
            {
                strSql.Append("交货期= null ,");
            }
            if (model.数量 != null)
            {
                strSql.Append("数量=" + model.数量 + ",");
            }
            else
            {
                strSql.Append("数量= null ,");
            }
            if (model.生产 != null)
            {
                strSql.Append("生产='" + model.生产 + "',");
            }
            else
            {
                strSql.Append("生产= null ,");
            }
            if (model.纱种 != null)
            {
                strSql.Append("纱种='" + model.纱种 + "',");
            }
            else
            {
                strSql.Append("纱种= null ,");
            }
            if (model.领形 != null)
            {
                strSql.Append("领形='" + model.领形 + "',");
            }
            else
            {
                strSql.Append("领形= null ,");
            }
            if (model.针型 != null)
            {
                strSql.Append("针型='" + model.针型 + "',");
            }
            else
            {
                strSql.Append("针型= null ,");
            }
            if (model.身高 != null)
            {
                strSql.Append("身高=" + model.身高 + ",");
            }
            else
            {
                strSql.Append("身高= null ,");
            }
            if (model.体重 != null)
            {
                strSql.Append("体重=" + model.体重 + ",");
            }
            else
            {
                strSql.Append("体重= null ,");
            }
            if (model.胸围 != null)
            {
                strSql.Append("胸围=" + model.胸围 + ",");
            }
            else
            {
                strSql.Append("胸围= null ,");
            }
            if (model.胸围杯型 != null)
            {
                strSql.Append("胸围杯型=" + model.胸围杯型 + ",");
            }
            else
            {
                strSql.Append("胸围杯型= null ,");
            }
            if (model.身长 != null)
            {
                strSql.Append("身长=" + model.身长 + ",");
            }
            else
            {
                strSql.Append("身长= null ,");
            }
            if (model.肩宽 != null)
            {
                strSql.Append("肩宽=" + model.肩宽 + ",");
            }
            else
            {
                strSql.Append("肩宽= null ,");
            }
            if (model.袖长 != null)
            {
                strSql.Append("袖长=" + model.袖长 + ",");
            }
            else
            {
                strSql.Append("袖长= null ,");
            }
            if (model.腰围 != null)
            {
                strSql.Append("腰围=" + model.腰围 + ",");
            }
            else
            {
                strSql.Append("腰围= null ,");
            }
            if (model.下摆宽 != null)
            {
                strSql.Append("下摆宽=" + model.下摆宽 + ",");
            }
            else
            {
                strSql.Append("下摆宽= null ,");
            }
            if (model.领深 != null)
            {
                strSql.Append("领深=" + model.领深 + ",");
            }
            else
            {
                strSql.Append("领深= null ,");
            }
            if (model.主色 != null)
            {
                strSql.Append("主色='" + model.主色 + "',");
            }
            else
            {
                strSql.Append("主色= null ,");
            }
            if (model.配色1 != null)
            {
                strSql.Append("配色1='" + model.配色1 + "',");
            }
            else
            {
                strSql.Append("配色1= null ,");
            }
            if (model.配色2 != null)
            {
                strSql.Append("配色2='" + model.配色2 + "',");
            }
            else
            {
                strSql.Append("配色2= null ,");
            }
            if (model.配色3 != null)
            {
                strSql.Append("配色3='" + model.配色3 + "',");
            }
            else
            {
                strSql.Append("配色3= null ,");
            }
            if (model.配色4 != null)
            {
                strSql.Append("配色4='" + model.配色4 + "',");
            }
            else
            {
                strSql.Append("配色4= null ,");
            }
            if (model.配色5 != null)
            {
                strSql.Append("配色5='" + model.配色5 + "',");
            }
            else
            {
                strSql.Append("配色5= null ,");
            }
            if (model.主色用纱量 != null)
            {
                strSql.Append("主色用纱量=" + model.主色用纱量 + ",");
            }
            else
            {
                strSql.Append("主色用纱量= null ,");
            }
            if (model.配色1用纱量 != null)
            {
                strSql.Append("配色1用纱量=" + model.配色1用纱量 + ",");
            }
            else
            {
                strSql.Append("配色1用纱量= null ,");
            }
            if (model.配色2用纱量 != null)
            {
                strSql.Append("配色2用纱量=" + model.配色2用纱量 + ",");
            }
            else
            {
                strSql.Append("配色2用纱量= null ,");
            }
            if (model.配色3用纱量 != null)
            {
                strSql.Append("配色3用纱量=" + model.配色3用纱量 + ",");
            }
            else
            {
                strSql.Append("配色3用纱量= null ,");
            }
            if (model.配色4用纱量 != null)
            {
                strSql.Append("配色4用纱量=" + model.配色4用纱量 + ",");
            }
            else
            {
                strSql.Append("配色4用纱量= null ,");
            }
            if (model.配色5用纱量 != null)
            {
                strSql.Append("配色5用纱量=" + model.配色5用纱量 + ",");
            }
            else
            {
                strSql.Append("配色5用纱量= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where iID=" + model.iID + "");
            return (strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public string Delete(long iID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from 订单 ");
            strSql.Append(" where iID=" + iID + "");
            return (strSql.ToString());
        }		
      

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public 成衣生产.Model.订单 DataRowToModel(DataRow row)
        {
            成衣生产.Model.订单 model = new 成衣生产.Model.订单();
            if (row != null)
            {
                if (row["iID"] != null && row["iID"].ToString() != "")
                {
                    model.iID = int.Parse(row["iID"].ToString());
                }
                if (row["产品档案iID"] != null && row["产品档案iID"].ToString() != "")
                {
                    model.产品档案iID = int.Parse(row["产品档案iID"].ToString());
                }
                if (row["单据日期"] != null && row["单据日期"].ToString() != "")
                {
                    model.单据日期 = DateTime.Parse(row["单据日期"].ToString());
                }
                if (row["联系电话"] != null)
                {
                    model.联系电话 = row["联系电话"].ToString();
                }
                if (row["客户"] != null)
                {
                    model.客户 = row["客户"].ToString();
                }
                if (row["备注"] != null)
                {
                    model.备注 = row["备注"].ToString();
                }
                if (row["制单人"] != null)
                {
                    model.制单人 = row["制单人"].ToString();
                }
                if (row["制单日期"] != null && row["制单日期"].ToString() != "")
                {
                    model.制单日期 = DateTime.Parse(row["制单日期"].ToString());
                }
                if (row["审核人"] != null)
                {
                    model.审核人 = row["审核人"].ToString();
                }
                if (row["审核日期"] != null && row["审核日期"].ToString() != "")
                {
                    model.审核日期 = DateTime.Parse(row["审核日期"].ToString());
                }
                if (row["关闭人"] != null)
                {
                    model.关闭人 = row["关闭人"].ToString();
                }
                if (row["关闭日期"] != null && row["关闭日期"].ToString() != "")
                {
                    model.关闭日期 = DateTime.Parse(row["关闭日期"].ToString());
                }
                if (row["变更人"] != null)
                {
                    model.变更人 = row["变更人"].ToString();
                }
                if (row["变更日期"] != null && row["变更日期"].ToString() != "")
                {
                    model.变更日期 = DateTime.Parse(row["变更日期"].ToString());
                }
                if (row["打印次数"] != null && row["打印次数"].ToString() != "")
                {
                    model.打印次数 = int.Parse(row["打印次数"].ToString());
                }
                if (row["最后打印日期"] != null && row["最后打印日期"].ToString() != "")
                {
                    model.最后打印日期 = DateTime.Parse(row["最后打印日期"].ToString());
                }
                if (row["类别"] != null)
                {
                    model.类别 = row["类别"].ToString();
                }
                if (row["款号"] != null)
                {
                    model.款号 = row["款号"].ToString();
                }
                if (row["交货期"] != null && row["交货期"].ToString() != "")
                {
                    model.交货期 = DateTime.Parse(row["交货期"].ToString());
                }
                if (row["数量"] != null && row["数量"].ToString() != "")
                {
                    model.数量 = decimal.Parse(row["数量"].ToString());
                }
                if (row["生产"] != null)
                {
                    model.生产 = row["生产"].ToString();
                }
                if (row["纱种"] != null)
                {
                    model.纱种 = row["纱种"].ToString();
                }
                if (row["领形"] != null)
                {
                    model.领形 = row["领形"].ToString();
                }
                if (row["针型"] != null)
                {
                    model.针型 = row["针型"].ToString();
                }
                if (row["身高"] != null && row["身高"].ToString() != "")
                {
                    model.身高 = decimal.Parse(row["身高"].ToString());
                }
                if (row["体重"] != null && row["体重"].ToString() != "")
                {
                    model.体重 = decimal.Parse(row["体重"].ToString());
                }
                if (row["胸围"] != null && row["胸围"].ToString() != "")
                {
                    model.胸围 = decimal.Parse(row["胸围"].ToString());
                }
                if (row["胸围杯型"] != null && row["胸围杯型"].ToString() != "")
                {
                    model.胸围杯型 = decimal.Parse(row["胸围杯型"].ToString());
                }
                if (row["身长"] != null && row["身长"].ToString() != "")
                {
                    model.身长 = decimal.Parse(row["身长"].ToString());
                }
                if (row["肩宽"] != null && row["肩宽"].ToString() != "")
                {
                    model.肩宽 = decimal.Parse(row["肩宽"].ToString());
                }
                if (row["袖长"] != null && row["袖长"].ToString() != "")
                {
                    model.袖长 = decimal.Parse(row["袖长"].ToString());
                }
                if (row["腰围"] != null && row["腰围"].ToString() != "")
                {
                    model.腰围 = decimal.Parse(row["腰围"].ToString());
                }
                if (row["下摆宽"] != null && row["下摆宽"].ToString() != "")
                {
                    model.下摆宽 = decimal.Parse(row["下摆宽"].ToString());
                }
                if (row["领深"] != null && row["领深"].ToString() != "")
                {
                    model.领深 = decimal.Parse(row["领深"].ToString());
                }
                if (row["主色"] != null)
                {
                    model.主色 = row["主色"].ToString();
                }
                if (row["配色1"] != null)
                {
                    model.配色1 = row["配色1"].ToString();
                }
                if (row["配色2"] != null)
                {
                    model.配色2 = row["配色2"].ToString();
                }
                if (row["配色3"] != null)
                {
                    model.配色3 = row["配色3"].ToString();
                }
                if (row["配色4"] != null)
                {
                    model.配色4 = row["配色4"].ToString();
                }
                if (row["配色5"] != null)
                {
                    model.配色5 = row["配色5"].ToString();
                }
                if (row["主色用纱量"] != null && row["主色用纱量"].ToString() != "")
                {
                    model.主色用纱量 = decimal.Parse(row["主色用纱量"].ToString());
                }
                if (row["配色1用纱量"] != null && row["配色1用纱量"].ToString() != "")
                {
                    model.配色1用纱量 = decimal.Parse(row["配色1用纱量"].ToString());
                }
                if (row["配色2用纱量"] != null && row["配色2用纱量"].ToString() != "")
                {
                    model.配色2用纱量 = decimal.Parse(row["配色2用纱量"].ToString());
                }
                if (row["配色3用纱量"] != null && row["配色3用纱量"].ToString() != "")
                {
                    model.配色3用纱量 = decimal.Parse(row["配色3用纱量"].ToString());
                }
                if (row["配色4用纱量"] != null && row["配色4用纱量"].ToString() != "")
                {
                    model.配色4用纱量 = decimal.Parse(row["配色4用纱量"].ToString());
                }
                if (row["配色5用纱量"] != null && row["配色5用纱量"].ToString() != "")
                {
                    model.配色5用纱量 = decimal.Parse(row["配色5用纱量"].ToString());
                }
            }
            return model;
        }

        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

