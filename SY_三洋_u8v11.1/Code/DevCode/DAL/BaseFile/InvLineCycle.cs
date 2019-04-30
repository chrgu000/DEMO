using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using FrameBaseFunction;
using System.Collections.Generic;//Please add references

namespace TH.DAL
{
    /// <summary>
    /// 数据访问类:InvLineCycle
    /// </summary>
    public partial class InvLineCycle
    {
        public InvLineCycle()
        { }
        #region  Method

        public DataTable GetInventory(string cInvCode)
        {
            string sSQL = "select * from @u8.Inventory where cInvCode = '" + cInvCode + "'";

            return DbHelperSQL.Query(sSQL);
        }

        public DataTable GetLookUp()
        {
            string sSQL = "select * from @u8.Inventory order by cInvCode; select * from ProductionLine order by [LineNo]";

            return DbHelperSQL.Query(sSQL);
        }
        
        public int Del(List<TH.Model.InvLineCycle> l)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < l.Count; i++)
            {
                if (l[i].iID == 0)
                {
                    continue;
                }

                list.Add(Delete(l[i].iID));
            }
            return DbHelperSQL.ExecuteSqlTran(list);
        }

        public int Save(List<TH.Model.InvLineCycle> l)
        {
            List<string> list = new List<string>();

            string sSQL = "";
            for (int i = 0; i < l.Count; i++)
            {
                if (l[i].iID == 0)
                {
                    l[i].CreateUid = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                    l[i].CreateDate = DbHelperSQL.ExecuteGetServerTime();
                    list.Add(Add(l[i]));
                }
                else
                {
                    l[i].UpdateUid = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                    l[i].UpdateDate = DbHelperSQL.ExecuteGetServerTime();
                    list.Add(Update(l[i]));
                }

                if (l[i].Priority)
                {
                    sSQL = @"
if exists (select * from @u8.Inventory_extradefine where cInvCode = '000000' )
	update @u8.Inventory_extradefine set cidefine3 = 333333, cidefine4 = '444444',cidefine6 = 666666,cidefine7 = 777777,cidefine9 = 999999
	where cInvCode = '000000'
else
	insert into @u8.Inventory_extradefine(cInvCode,cidefine3,cidefine4,cidefine6,cidefine7,cidefine9)
	values('000000',333333,'444444',666666,777777,999999)
";
                    sSQL = sSQL.Replace("000000", l[i].cInvCode.ToString());
                    sSQL = sSQL.Replace("333333", l[i].SelfCycle.ToString());
                    sSQL = sSQL.Replace("444444", l[i].LineNo.ToString());
                    sSQL = sSQL.Replace("666666", l[i].SelfCycleB.ToString());
                    sSQL = sSQL.Replace("777777", l[i].SelfSetupCycle.ToString());
                    sSQL = sSQL.Replace("888888", l[i].SelfCapacity.ToString());
                    sSQL = sSQL.Replace("999999","1");
                    list.Add(sSQL);
                }
            }



            return DbHelperSQL.ExecuteSqlTran(list);
        }

        /// <summary>
        /// 批量更新存货生产档案进用友
        /// </summary>
        /// <returns></returns>
        public int PLTB()
        {
            int iCou = 0;
            SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString);
            conn.Open();
            //启用事务
            SqlTransaction tran = conn.BeginTransaction();

            try
            {
                string sSQL = @"
insert into @u8.Inventory_extradefine(cInvCode,cidefine3,cidefine4,cidefine6,cidefine7,cidefine9)
select cInvCode,SelfCycle,[LineNo],SelfCycleB,SelfSetupCycle,SelfCapacity
from InvLineCycle
where isnull(Priority,0) = 1 and cInvCode not in(select cInvCode from @u8.Inventory_extradefine)
";
                iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                sSQL = @"
update @u8.Inventory_extradefine set cidefine3 = b.SelfCycle,cidefine4 = b.[LineNo],cidefine6 = b.SelfCycleB,cidefine7 = b.SelfSetupCycle,cidefine9 = b.SelfCapacity
from dbo.InvLineCycle b 
where b.cInvCode = @u8.Inventory_extradefine.cInvCode and isnull(b.Priority,0) = 1 and isnull(b.[LineNo],'') <> ''
";
                iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                tran.Commit();
            }
            catch (Exception error)
            {
                tran.Rollback();
                throw new Exception(error.Message);
            }

            return iCou;
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int iID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from InvLineCycle");
            strSql.Append(" where iID=" + iID + " ");
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(TH.Model.InvLineCycle model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.GUID != null)
            {
                strSql1.Append("GUID,");
                strSql2.Append("'" + Guid.NewGuid().ToString() + "',");
            }
            if (model.CreateUid != null)
            {
                strSql1.Append("CreateUid,");
                strSql2.Append("'" + model.CreateUid + "',");
            }
            if (model.CreateDate != null)
            {
                strSql1.Append("CreateDate,");
                strSql2.Append("'" + model.CreateDate + "',");
            }
            if (model.UpdateUid != null)
            {
                strSql1.Append("UpdateUid,");
                strSql2.Append("'" + model.UpdateUid + "',");
            }
            if (model.UpdateDate != null)
            {
                strSql1.Append("UpdateDate,");
                strSql2.Append("'" + model.UpdateDate + "',");
            }
            if (model.CloseUid != null)
            {
                strSql1.Append("CloseUid,");
                strSql2.Append("'" + model.CloseUid + "',");
            }
            if (model.CloseDate != null)
            {
                strSql1.Append("CloseDate,");
                strSql2.Append("'" + model.CloseDate + "',");
            }
            if (model.cInvCode != null)
            {
                strSql1.Append("cInvCode,");
                strSql2.Append("'" + model.cInvCode + "',");
            }
            if (model.LineNo != null)
            {
                strSql1.Append("[LineNo],");
                strSql2.Append("'" + model.LineNo + "',");
            }
            if (model.PurchaseCycle != null)
            {
                strSql1.Append("PurchaseCycle,");
                strSql2.Append("" + model.PurchaseCycle + ",");
            }
            if (model.ProxyForeignCycle != null)
            {
                strSql1.Append("ProxyForeignCycle,");
                strSql2.Append("" + model.ProxyForeignCycle + ",");
            }
            if (model.SelfCycle != null)
            {
                strSql1.Append("SelfCycle,");
                strSql2.Append("" + model.SelfCycle + ",");
            }
            if (model.SelfCycleB != null)
            {
                strSql1.Append("SelfCycleB,");
                strSql2.Append("" + model.SelfCycleB + ",");
            }
            if (model.SelfSetupCycle != null)
            {
                strSql1.Append("SelfSetupCycle,");
                strSql2.Append("" + model.SelfSetupCycle + ",");
            }
            if (model.Priority != null)
            {
                strSql1.Append("Priority,");
                strSql2.Append("" + (model.Priority ? 1 : 0) + ",");
            }
            if (model.QualityCycle != null)
            {
                strSql1.Append("QualityCycle,");
                strSql2.Append("" + model.QualityCycle + ",");
            }
            if (model.SelfCapacity != null)
            {
                strSql1.Append("SelfCapacity,");
                strSql2.Append("" + model.SelfCapacity + ",");
            }
            strSql.Append("insert into InvLineCycle(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            return strSql.ToString();
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string Update(TH.Model.InvLineCycle model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update InvLineCycle set ");
            if (model.GUID != null)
            {
                strSql.Append("GUID='" + model.GUID + "',");
            }
            else
            {
                strSql.Append("GUID= null ,");
            }
            if (model.CreateUid != null)
            {
                strSql.Append("CreateUid='" + model.CreateUid + "',");
            }
            else
            {
                strSql.Append("CreateUid= null ,");
            }
            if (model.CreateDate != null)
            {
                strSql.Append("CreateDate='" + model.CreateDate + "',");
            }
            else
            {
                strSql.Append("CreateDate= null ,");
            }
            if (model.UpdateUid != null)
            {
                strSql.Append("UpdateUid='" + model.UpdateUid + "',");
            }
            else
            {
                strSql.Append("UpdateUid= null ,");
            }
            if (model.UpdateDate != null)
            {
                strSql.Append("UpdateDate='" + model.UpdateDate + "',");
            }
            else
            {
                strSql.Append("UpdateDate= null ,");
            }
            if (model.CloseUid != null)
            {
                strSql.Append("CloseUid='" + model.CloseUid + "',");
            }
            else
            {
                strSql.Append("CloseUid= null ,");
            }
            if (model.CloseDate != null)
            {
                strSql.Append("CloseDate='" + model.CloseDate + "',");
            }
            else
            {
                strSql.Append("CloseDate= null ,");
            }
            if (model.cInvCode != null)
            {
                strSql.Append("cInvCode='" + model.cInvCode + "',");
            }
            else
            {
                strSql.Append("cInvCode= null ,");
            }
            if (model.LineNo != null)
            {
                strSql.Append("[LineNo]='" + model.LineNo + "',");
            }
            else
            {
                strSql.Append("[LineNo]= null ,");
            }
            if (model.PurchaseCycle != null)
            {
                strSql.Append("PurchaseCycle=" + model.PurchaseCycle + ",");
            }
            else
            {
                strSql.Append("PurchaseCycle= null ,");
            }
            if (model.ProxyForeignCycle != null)
            {
                strSql.Append("ProxyForeignCycle=" + model.ProxyForeignCycle + ",");
            }
            else
            {
                strSql.Append("ProxyForeignCycle= null ,");
            }
            if (model.SelfCycle != null)
            {
                strSql.Append("SelfCycle=" + model.SelfCycle + ",");
            }
            else
            {
                strSql.Append("SelfCycle= null ,");
            }
            if (model.SelfCycleB != null)
            {
                strSql.Append("SelfCycleB=" + model.SelfCycleB + ",");
            }
            else
            {
                strSql.Append("SelfCycleB= null ,");
            }
            if (model.SelfSetupCycle != null)
            {
                strSql.Append("SelfSetupCycle=" + model.SelfSetupCycle + ",");
            }
            else
            {
                strSql.Append("SelfSetupCycle= null ,");
            }
            if (model.Priority != null)
            {
                strSql.Append("Priority=" + (model.Priority ? 1 : 0) + ",");
            }
            else
            {
                strSql.Append("Priority= null ,");
            }
            if (model.QualityCycle != null)
            {
                strSql.Append("QualityCycle=" + model.QualityCycle + ",");
            }
            else
            {
                strSql.Append("QualityCycle= null ,");
            }
            if (model.SelfCapacity != null)
            {
                strSql.Append("SelfCapacity=" + model.SelfCapacity + ",");
            }
            else
            {
                strSql.Append("SelfCapacity= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where iID=" + model.iID + "");
            return strSql.ToString();
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public string Delete(int iID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from InvLineCycle ");
            strSql.Append(" where iID=" + iID + "");
            return strSql.ToString();
        }		
        
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string iIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from InvLineCycle ");
            strSql.Append(" where iID in (" + iIDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TH.Model.InvLineCycle GetModel(int iID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" iID,GUID,CreateUid,CreateDate,UpdateUid,UpdateDate,CloseUid,CloseDate,cInvCode,[LineNo],PurchaseCycle,ProxyForeignCycle,SelfCycle,SelfCycleB,SelfSetupCycle,Priority,QualityCycle,SelfCapacity ");
            strSql.Append(" from InvLineCycle ");
            strSql.Append(" where iID=" + iID + "");
            TH.Model.InvLineCycle model = new TH.Model.InvLineCycle();
            DataTable ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Rows.Count > 0)
            {
                return DataRowToModel(ds.Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TH.Model.InvLineCycle DataRowToModel(DataRow row)
        {
            TH.Model.InvLineCycle model = new TH.Model.InvLineCycle();
            if (row != null)
            {
                if (row["iID"] != null && row["iID"].ToString() != "")
                {
                    model.iID = int.Parse(row["iID"].ToString());
                }
                if (row["GUID"] != null && row["GUID"].ToString() != "")
                {
                    model.GUID = new Guid(row["GUID"].ToString());
                }
                if (row["CreateUid"] != null)
                {
                    model.CreateUid = row["CreateUid"].ToString();
                }
                if (row["CreateDate"] != null && row["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
                }
                if (row["UpdateUid"] != null)
                {
                    model.UpdateUid = row["UpdateUid"].ToString();
                }
                if (row["UpdateDate"] != null && row["UpdateDate"].ToString() != "")
                {
                    model.UpdateDate = DateTime.Parse(row["UpdateDate"].ToString());
                }
                if (row["CloseUid"] != null)
                {
                    model.CloseUid = row["CloseUid"].ToString();
                }
                if (row["CloseDate"] != null && row["CloseDate"].ToString() != "")
                {
                    model.CloseDate = DateTime.Parse(row["CloseDate"].ToString());
                }
                if (row["cInvCode"] != null)
                {
                    model.cInvCode = row["cInvCode"].ToString();
                }
                if (row["LineNo"] != null)
                {
                    model.LineNo = row["LineNo"].ToString();
                }
                if (row["PurchaseCycle"] != null && row["PurchaseCycle"].ToString() != "")
                {
                    model.PurchaseCycle = int.Parse(row["PurchaseCycle"].ToString());
                }
                if (row["ProxyForeignCycle"] != null && row["ProxyForeignCycle"].ToString() != "")
                {
                    model.ProxyForeignCycle = int.Parse(row["ProxyForeignCycle"].ToString());
                }
                if (row["SelfCycle"] != null && row["SelfCycle"].ToString() != "")
                {
                    model.SelfCycle = decimal.Parse(row["SelfCycle"].ToString());
                }
                if (row["SelfCycleB"] != null && row["SelfCycleB"].ToString() != "")
                {
                    model.SelfCycleB = int.Parse(row["SelfCycleB"].ToString());
                }
                if (row["SelfSetupCycle"] != null && row["SelfSetupCycle"].ToString() != "")
                {
                    model.SelfSetupCycle = decimal.Parse(row["SelfSetupCycle"].ToString());
                }
                if (row["Priority"] != null && row["Priority"].ToString() != "")
                {
                    if ((row["Priority"].ToString() == "1") || (row["Priority"].ToString().ToLower() == "true"))
                    {
                        model.Priority = true;
                    }
                    else
                    {
                        model.Priority = false;
                    }
                }
                if (row["QualityCycle"] != null && row["QualityCycle"].ToString() != "")
                {
                    model.QualityCycle = int.Parse(row["QualityCycle"].ToString());
                }
                if (row["SelfCapacity"] != null && row["SelfCapacity"].ToString() != "")
                {
                    model.SelfCapacity = int.Parse(row["SelfCapacity"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select iID,GUID,CreateUid,CreateDate,UpdateUid,UpdateDate,CloseUid,CloseDate,cInvCode,[LineNo],PurchaseCycle,ProxyForeignCycle,SelfCycle,SelfCycleB,SelfSetupCycle,Priority,QualityCycle,SelfCapacity,cast(0 as decimal(16,1)) as 产量");
            strSql.Append(" FROM InvLineCycle ");
            strSql.Append(" where isnull(SelfCycle,0) <> 0 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and cInvCode = '" + strWhere + "'");
            }
            strSql.Append(" order by cInvCode,[LineNo] ");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataTable GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" iID,GUID,CreateUid,CreateDate,UpdateUid,UpdateDate,CloseUid,CloseDate,cInvCode,[LineNo],PurchaseCycle,ProxyForeignCycle,SelfCycle,SelfCycleB,SelfSetupCycle,Priority,QualityCycle,SelfCapacity ");
            strSql.Append(" FROM InvLineCycle ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM InvLineCycle ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataTable GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.iID desc");
            }
            strSql.Append(")AS Row, T.*  from InvLineCycle T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        */

        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

