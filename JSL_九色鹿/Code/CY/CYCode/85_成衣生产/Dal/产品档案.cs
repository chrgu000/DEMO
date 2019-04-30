using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace 成衣生产.DAL
{
    /// <summary>
    /// 数据访问类:产品档案
    /// </summary>
    public partial class 产品档案
    {
        public 产品档案()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public string Exists(long iID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from 产品档案");
            strSql.Append(" where iID=" + iID + " ");
            return  (strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(成衣生产.Model.产品档案 model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.尺码信息iID != null)
            {
                strSql1.Append("尺码信息iID,");
                strSql2.Append("" + model.尺码信息iID + ",");
            }
            if (model.编码 != null)
            {
                strSql1.Append("编码,");
                strSql2.Append("'" + model.编码 + "',");
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
            if (model.款名 != null)
            {
                strSql1.Append("款名,");
                strSql2.Append("'" + model.款名 + "',");
            }
            if (model.规格 != null)
            {
                strSql1.Append("规格,");
                strSql2.Append("'" + model.规格 + "',");
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
            if (model.腰围L != null)
            {
                strSql1.Append("腰围L,");
                strSql2.Append("" + model.腰围L + ",");
            }
            if (model.腰围T != null)
            {
                strSql1.Append("腰围T,");
                strSql2.Append("" + model.腰围T + ",");
            }
            if (model.下摆宽L != null)
            {
                strSql1.Append("下摆宽L,");
                strSql2.Append("" + model.下摆宽L + ",");
            }
            if (model.下摆宽T != null)
            {
                strSql1.Append("下摆宽T,");
                strSql2.Append("" + model.下摆宽T + ",");
            }
            if (model.针型 != null)
            {
                strSql1.Append("针型,");
                strSql2.Append("'" + model.针型 + "',");
            }
            if (model.领形 != null)
            {
                strSql1.Append("领形,");
                strSql2.Append("'" + model.领形 + "',");
            }
            if (model.领深L != null)
            {
                strSql1.Append("领深L,");
                strSql2.Append("" + model.领深L + ",");
            }
            if (model.领深T != null)
            {
                strSql1.Append("领深T,");
                strSql2.Append("" + model.领深T + ",");
            }
            if (model.定制加工费 != null)
            {
                strSql1.Append("定制加工费,");
                strSql2.Append("" + model.定制加工费 + ",");
            }
            if (model.VIP加工费 != null)
            {
                strSql1.Append("VIP加工费,");
                strSql2.Append("" + model.VIP加工费 + ",");
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
            if (model.图纸责任人 != null)
            {
                strSql1.Append("图纸责任人,");
                strSql2.Append("'" + model.图纸责任人 + "',");
            }
            if (model.制版文件 != null)
            {
                strSql1.Append("制版文件,");
                strSql2.Append("'" + model.制版文件 + "',");
            }
            if (model.制版时间 != null)
            {
                strSql1.Append("制版时间,");
                strSql2.Append("'" + model.制版时间 + "',");
            }
            if (model.制版人 != null)
            {
                strSql1.Append("制版人,");
                strSql2.Append("'" + model.制版人 + "',");
            }
            if (model.上机文件 != null)
            {
                strSql1.Append("上机文件,");
                strSql2.Append("'" + model.上机文件 + "',");
            }
            if (model.上机时间 != null)
            {
                strSql1.Append("上机时间,");
                strSql2.Append("'" + model.上机时间 + "',");
            }
            if (model.上机人 != null)
            {
                strSql1.Append("上机人,");
                strSql2.Append("'" + model.上机人 + "',");
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
            if (model.身高L != null)
            {
                strSql1.Append("身高L,");
                strSql2.Append("" + model.身高L + ",");
            }
            if (model.身高T != null)
            {
                strSql1.Append("身高T,");
                strSql2.Append("" + model.身高T + ",");
            }
            if (model.体重L != null)
            {
                strSql1.Append("体重L,");
                strSql2.Append("" + model.体重L + ",");
            }
            if (model.体重T != null)
            {
                strSql1.Append("体重T,");
                strSql2.Append("" + model.体重T + ",");
            }
            if (model.胸围L != null)
            {
                strSql1.Append("胸围L,");
                strSql2.Append("" + model.胸围L + ",");
            }
            if (model.胸围T != null)
            {
                strSql1.Append("胸围T,");
                strSql2.Append("" + model.胸围T + ",");
            }
            if (model.胸围杯型L != null)
            {
                strSql1.Append("胸围杯型L,");
                strSql2.Append("" + model.胸围杯型L + ",");
            }
            if (model.胸围杯型T != null)
            {
                strSql1.Append("胸围杯型T,");
                strSql2.Append("" + model.胸围杯型T + ",");
            }
            if (model.身长L != null)
            {
                strSql1.Append("身长L,");
                strSql2.Append("" + model.身长L + ",");
            }
            if (model.身长T != null)
            {
                strSql1.Append("身长T,");
                strSql2.Append("" + model.身长T + ",");
            }
            if (model.肩宽L != null)
            {
                strSql1.Append("肩宽L,");
                strSql2.Append("" + model.肩宽L + ",");
            }
            if (model.肩宽T != null)
            {
                strSql1.Append("肩宽T,");
                strSql2.Append("" + model.肩宽T + ",");
            }
            if (model.袖长L != null)
            {
                strSql1.Append("袖长L,");
                strSql2.Append("" + model.袖长L + ",");
            }
            if (model.袖长T != null)
            {
                strSql1.Append("袖长T,");
                strSql2.Append("" + model.袖长T + ",");
            }
            strSql.Append("insert into 产品档案(");
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
        public string Update(成衣生产.Model.产品档案 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update 产品档案 set ");
            if (model.尺码信息iID != null)
            {
                strSql.Append("尺码信息iID=" + model.尺码信息iID + ",");
            }
            else
            {
                strSql.Append("尺码信息iID= null ,");
            }
            if (model.编码 != null)
            {
                strSql.Append("编码='" + model.编码 + "',");
            }
            if (model.类别 != null)
            {
                strSql.Append("类别='" + model.类别 + "',");
            }
            if (model.款号 != null)
            {
                strSql.Append("款号='" + model.款号 + "',");
            }
            if (model.款名 != null)
            {
                strSql.Append("款名='" + model.款名 + "',");
            }
            else
            {
                strSql.Append("款名= null ,");
            }
            if (model.规格 != null)
            {
                strSql.Append("规格='" + model.规格 + "',");
            }
            else
            {
                strSql.Append("规格= null ,");
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
            if (model.腰围L != null)
            {
                strSql.Append("腰围L=" + model.腰围L + ",");
            }
            else
            {
                strSql.Append("腰围L= null ,");
            }
            if (model.腰围T != null)
            {
                strSql.Append("腰围T=" + model.腰围T + ",");
            }
            else
            {
                strSql.Append("腰围T= null ,");
            }
            if (model.下摆宽L != null)
            {
                strSql.Append("下摆宽L=" + model.下摆宽L + ",");
            }
            else
            {
                strSql.Append("下摆宽L= null ,");
            }
            if (model.下摆宽T != null)
            {
                strSql.Append("下摆宽T=" + model.下摆宽T + ",");
            }
            else
            {
                strSql.Append("下摆宽T= null ,");
            }
            if (model.针型 != null)
            {
                strSql.Append("针型='" + model.针型 + "',");
            }
            else
            {
                strSql.Append("针型= null ,");
            }
            if (model.领形 != null)
            {
                strSql.Append("领形='" + model.领形 + "',");
            }
            else
            {
                strSql.Append("领形= null ,");
            }
            if (model.领深L != null)
            {
                strSql.Append("领深L=" + model.领深L + ",");
            }
            else
            {
                strSql.Append("领深L= null ,");
            }
            if (model.领深T != null)
            {
                strSql.Append("领深T=" + model.领深T + ",");
            }
            else
            {
                strSql.Append("领深T= null ,");
            }
            if (model.定制加工费 != null)
            {
                strSql.Append("定制加工费=" + model.定制加工费 + ",");
            }
            else
            {
                strSql.Append("定制加工费= null ,");
            }
            if (model.VIP加工费 != null)
            {
                strSql.Append("VIP加工费=" + model.VIP加工费 + ",");
            }
            else
            {
                strSql.Append("VIP加工费= null ,");
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
            if (model.图纸责任人 != null)
            {
                strSql.Append("图纸责任人='" + model.图纸责任人 + "',");
            }
            else
            {
                strSql.Append("图纸责任人= null ,");
            }
            if (model.制版文件 != null)
            {
                strSql.Append("制版文件='" + model.制版文件 + "',");
            }
            else
            {
                strSql.Append("制版文件= null ,");
            }
            if (model.制版时间 != null)
            {
                strSql.Append("制版时间='" + model.制版时间 + "',");
            }
            else
            {
                strSql.Append("制版时间= null ,");
            }
            if (model.制版人 != null)
            {
                strSql.Append("制版人='" + model.制版人 + "',");
            }
            else
            {
                strSql.Append("制版人= null ,");
            }
            if (model.上机文件 != null)
            {
                strSql.Append("上机文件='" + model.上机文件 + "',");
            }
            else
            {
                strSql.Append("上机文件= null ,");
            }
            if (model.上机时间 != null)
            {
                strSql.Append("上机时间='" + model.上机时间 + "',");
            }
            else
            {
                strSql.Append("上机时间= null ,");
            }
            if (model.上机人 != null)
            {
                strSql.Append("上机人='" + model.上机人 + "',");
            }
            else
            {
                strSql.Append("上机人= null ,");
            }
            if (model.制单人 != null)
            {
                strSql.Append("制单人='" + model.制单人 + "',");
            }
            else
            {
                strSql.Append("制单人= null ,");
            }
            if (model.制单日期 != null)
            {
                strSql.Append("制单日期='" + model.制单日期 + "',");
            }
            else
            {
                strSql.Append("制单日期= null ,");
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
            if (model.身高L != null)
            {
                strSql.Append("身高L=" + model.身高L + ",");
            }
            else
            {
                strSql.Append("身高L= null ,");
            }
            if (model.身高T != null)
            {
                strSql.Append("身高T=" + model.身高T + ",");
            }
            else
            {
                strSql.Append("身高T= null ,");
            }
            if (model.体重L != null)
            {
                strSql.Append("体重L=" + model.体重L + ",");
            }
            else
            {
                strSql.Append("体重L= null ,");
            }
            if (model.体重T != null)
            {
                strSql.Append("体重T=" + model.体重T + ",");
            }
            else
            {
                strSql.Append("体重T= null ,");
            }
            if (model.胸围L != null)
            {
                strSql.Append("胸围L=" + model.胸围L + ",");
            }
            if (model.胸围T != null)
            {
                strSql.Append("胸围T=" + model.胸围T + ",");
            }
            else
            {
                strSql.Append("胸围T= null ,");
            }
            if (model.胸围杯型L != null)
            {
                strSql.Append("胸围杯型L=" + model.胸围杯型L + ",");
            }
            else
            {
                strSql.Append("胸围杯型L= null ,");
            }
            if (model.胸围杯型T != null)
            {
                strSql.Append("胸围杯型T=" + model.胸围杯型T + ",");
            }
            else
            {
                strSql.Append("胸围杯型T= null ,");
            }
            if (model.身长L != null)
            {
                strSql.Append("身长L=" + model.身长L + ",");
            }
            else
            {
                strSql.Append("身长L= null ,");
            }
            if (model.身长T != null)
            {
                strSql.Append("身长T=" + model.身长T + ",");
            }
            else
            {
                strSql.Append("身长T= null ,");
            }
            if (model.肩宽L != null)
            {
                strSql.Append("肩宽L=" + model.肩宽L + ",");
            }
            else
            {
                strSql.Append("肩宽L= null ,");
            }
            if (model.肩宽T != null)
            {
                strSql.Append("肩宽T=" + model.肩宽T + ",");
            }
            else
            {
                strSql.Append("肩宽T= null ,");
            }
            if (model.袖长L != null)
            {
                strSql.Append("袖长L=" + model.袖长L + ",");
            }
            else
            {
                strSql.Append("袖长L= null ,");
            }
            if (model.袖长T != null)
            {
                strSql.Append("袖长T=" + model.袖长T + ",");
            }
            else
            {
                strSql.Append("袖长T= null ,");
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
            strSql.Append("delete from 产品档案 ");
            strSql.Append(" where iID=" + iID + "");
            return (strSql.ToString());
        }		
      

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public 成衣生产.Model.产品档案 DataRowToModel(DataRow row)
        {
            成衣生产.Model.产品档案 model = new 成衣生产.Model.产品档案();
            if (row != null)
            {
                if (row["iID"] != null && row["iID"].ToString() != "")
                {
                    model.iID = int.Parse(row["iID"].ToString());
                }
                if (row["编码"] != null)
                {
                    model.编码 = row["编码"].ToString();
                }
                if (row["类别"] != null)
                {
                    model.类别 = row["类别"].ToString();
                }
                if (row["款号"] != null)
                {
                    model.款号 = row["款号"].ToString();
                }
                if (row["款名"] != null)
                {
                    model.款名 = row["款名"].ToString();
                }
                if (row["规格"] != null)
                {
                    model.规格 = row["规格"].ToString();
                }
                if (row["生产"] != null)
                {
                    model.生产 = row["生产"].ToString();
                }
                if (row["纱种"] != null)
                {
                    model.纱种 = row["纱种"].ToString();
                }
                if (row["腰围L"] != null && row["腰围L"].ToString() != "")
                {
                    model.腰围L = decimal.Parse(row["腰围L"].ToString());
                }
                if (row["腰围T"] != null && row["腰围T"].ToString() != "")
                {
                    model.腰围T = decimal.Parse(row["腰围T"].ToString());
                }
                if (row["下摆宽L"] != null && row["下摆宽L"].ToString() != "")
                {
                    model.下摆宽L = decimal.Parse(row["下摆宽L"].ToString());
                }
                if (row["下摆宽T"] != null && row["下摆宽T"].ToString() != "")
                {
                    model.下摆宽T = decimal.Parse(row["下摆宽T"].ToString());
                }
                if (row["针型"] != null)
                {
                    model.针型 = row["针型"].ToString();
                }
                if (row["领形"] != null)
                {
                    model.领形 = row["领形"].ToString();
                }
                if (row["领深L"] != null && row["领深L"].ToString() != "")
                {
                    model.领深L = decimal.Parse(row["领深L"].ToString());
                }
                if (row["领深T"] != null && row["领深T"].ToString() != "")
                {
                    model.领深T = decimal.Parse(row["领深T"].ToString());
                }
                if (row["定制加工费"] != null && row["定制加工费"].ToString() != "")
                {
                    model.定制加工费 = decimal.Parse(row["定制加工费"].ToString());
                }
                if (row["VIP加工费"] != null && row["VIP加工费"].ToString() != "")
                {
                    model.VIP加工费 = decimal.Parse(row["VIP加工费"].ToString());
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
                if (row["图纸责任人"] != null)
                {
                    model.图纸责任人 = row["图纸责任人"].ToString();
                }
                if (row["制版文件"] != null)
                {
                    model.制版文件 = row["制版文件"].ToString();
                }
                if (row["制版时间"] != null && row["制版时间"].ToString() != "")
                {
                    model.制版时间 = DateTime.Parse(row["制版时间"].ToString());
                }
                if (row["制版人"] != null)
                {
                    model.制版人 = row["制版人"].ToString();
                }
                if (row["上机文件"] != null)
                {
                    model.上机文件 = row["上机文件"].ToString();
                }
                if (row["上机时间"] != null && row["上机时间"].ToString() != "")
                {
                    model.上机时间 = DateTime.Parse(row["上机时间"].ToString());
                }
                if (row["上机人"] != null)
                {
                    model.上机人 = row["上机人"].ToString();
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
                if (row["身高L"] != null && row["身高L"].ToString() != "")
                {
                    model.身高L = decimal.Parse(row["身高L"].ToString());
                }
                if (row["身高T"] != null && row["身高T"].ToString() != "")
                {
                    model.身高T = decimal.Parse(row["身高T"].ToString());
                }
                if (row["体重L"] != null && row["体重L"].ToString() != "")
                {
                    model.体重L = decimal.Parse(row["体重L"].ToString());
                }
                if (row["体重T"] != null && row["体重T"].ToString() != "")
                {
                    model.体重T = decimal.Parse(row["体重T"].ToString());
                }
                if (row["胸围L"] != null && row["胸围L"].ToString() != "")
                {
                    model.胸围L = decimal.Parse(row["胸围L"].ToString());
                }
                if (row["胸围T"] != null && row["胸围T"].ToString() != "")
                {
                    model.胸围T = decimal.Parse(row["胸围T"].ToString());
                }
                if (row["胸围杯型L"] != null && row["胸围杯型L"].ToString() != "")
                {
                    model.胸围杯型L = decimal.Parse(row["胸围杯型L"].ToString());
                }
                if (row["胸围杯型T"] != null && row["胸围杯型T"].ToString() != "")
                {
                    model.胸围杯型T = decimal.Parse(row["胸围杯型T"].ToString());
                }
                if (row["身长L"] != null && row["身长L"].ToString() != "")
                {
                    model.身长L = decimal.Parse(row["身长L"].ToString());
                }
                if (row["身长T"] != null && row["身长T"].ToString() != "")
                {
                    model.身长T = decimal.Parse(row["身长T"].ToString());
                }
                if (row["肩宽L"] != null && row["肩宽L"].ToString() != "")
                {
                    model.肩宽L = decimal.Parse(row["肩宽L"].ToString());
                }
                if (row["肩宽T"] != null && row["肩宽T"].ToString() != "")
                {
                    model.肩宽T = decimal.Parse(row["肩宽T"].ToString());
                }
                if (row["袖长L"] != null && row["袖长L"].ToString() != "")
                {
                    model.袖长L = decimal.Parse(row["袖长L"].ToString());
                }
                if (row["袖长T"] != null && row["袖长T"].ToString() != "")
                {
                    model.袖长T = decimal.Parse(row["袖长T"].ToString());
                }
            }
            return model;
        }

        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

