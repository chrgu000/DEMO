using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using FrameBaseFunction;

namespace TH.DAL
{
    /// <summary>
    /// 数据访问类:存货产线档案导入
    /// </summary>
    public partial class 存货产线档案导入
    {
        public 存货产线档案导入()
        { }


        public int Save(DataTable dt)
        {
            int iCou = 0;
            SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString);
            conn.Open();
            //启用事务
            SqlTransaction tran = conn.BeginTransaction();

            try
            {

                string sSQL = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if(!BaseFunction.BaseFunction.ReturnBool(dt.Rows[i]["choose"]))
                    {
                        continue;
                    }

                    TH.Model.InvLineCycle ModelInvLineCycle = new TH.Model.InvLineCycle();
                    ModelInvLineCycle.cInvCode = dt.Rows[i]["cInvCode"].ToString().Trim();
                    ModelInvLineCycle.LineNo = dt.Rows[i]["产线编码"].ToString().Trim();
                    ModelInvLineCycle.Priority = BaseFunction.BaseFunction.ReturnBool(dt.Rows[i]["是否默认产线"]);
                    ModelInvLineCycle.SelfCycle = BaseFunction.BaseFunction.ReturnDecimal(dt.Rows[i]["单件默认生产工时"]);
                    ModelInvLineCycle.SelfCycleB = BaseFunction.BaseFunction.ReturnInt(dt.Rows[i]["单件生产工时基数"]);
                    ModelInvLineCycle.SelfSetupCycle = BaseFunction.BaseFunction.ReturnDecimal(dt.Rows[i]["生产准备时间"]);
                    ModelInvLineCycle.CreateUid = FrameBaseFunction.ClsBaseDataInfo.sUid;
                    GetBaseData Getbasedata = new GetBaseData();
                    ModelInvLineCycle.CreateDate = Getbasedata.GetDatetimeSer();

                    sSQL = ExistsInvLineCycle(ModelInvLineCycle.cInvCode,ModelInvLineCycle.LineNo);
                    DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran,CommandType.Text,sSQL).Tables[0];

                    if (dtTemp != null && dtTemp.Rows.Count > 0)
                    {
                       sSQL =  DeleteInvLineCycle(ModelInvLineCycle.cInvCode);
                       DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }
                    sSQL = AddInvLineCycle(ModelInvLineCycle);
                    iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    if (ModelInvLineCycle.Priority)
                    {
                        TH.Model.Inventory_extradefine model = new TH.Model.Inventory_extradefine();
                        model.cInvCode = dt.Rows[i]["cInvCode"].ToString().Trim();
                        model.cidefine3 = ModelInvLineCycle.SelfCycle;
                        model.cidefine4 = ModelInvLineCycle.LineNo;
                        model.cidefine6 = ModelInvLineCycle.SelfCycleB;
                        model.cidefine7 = ModelInvLineCycle.SelfSetupCycle;

                        bool b = ExistsInventory_extradefine(model.cInvCode);
                        if (b)
                        {
                            sSQL = UpdateInventory_extradefine(model);
                        }
                        else
                        {
                            sSQL = AddInventory_extradefine(model);
                        }
                        iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }
                }
                tran.Commit();
            }
            catch (Exception error)
            {
                tran.Rollback();
                iCou = 0;
                throw new Exception(error.Message);
            }

            return iCou;
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public string ExistsInvLineCycle(string sInvCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from InvLineCycle");
            strSql.Append(" where cInvCode='" + sInvCode + "' ");
            return (strSql.ToString());
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public string ExistsInvLineCycle(string sInvCode,string sLineNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from InvLineCycle");
            strSql.Append(" where cInvCode='" + sInvCode + "' and [LineNo] = '" + sLineNo + "'");
            return (strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string AddInvLineCycle(TH.Model.InvLineCycle model)
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
            return (strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string UpdateInvLineCycle(TH.Model.InvLineCycle model)
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
                strSql.Append("LineNo='" + model.LineNo + "',");
            }
            else
            {
                strSql.Append("LineNo= null ,");
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
            return (strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public string DeleteInvLineCycle(string sInvCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from InvLineCycle ");
            strSql.Append(" where cInvCode='" + sInvCode + "'");
           return (strSql.ToString());

        }	

        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsInventory_extradefine(string cInvCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from @u8.Inventory_extradefine");
            strSql.Append(" where cInvCode='" + cInvCode + "' ");
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string AddInventory_extradefine(TH.Model.Inventory_extradefine model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.cInvCode != null)
            {
                strSql1.Append("cInvCode,");
                strSql2.Append("'" + model.cInvCode + "',");
            }
            if (model.cidefine1 != null)
            {
                strSql1.Append("cidefine1,");
                strSql2.Append("" + model.cidefine1 + ",");
            }
            if (model.cidefine2 != null)
            {
                strSql1.Append("cidefine2,");
                strSql2.Append("" + model.cidefine2 + ",");
            }
            if (model.cidefine3 != null)
            {
                strSql1.Append("cidefine3,");
                strSql2.Append("" + model.cidefine3 + ",");
            }
            if (model.cidefine4 != null)
            {
                strSql1.Append("cidefine4,");
                strSql2.Append("'" + model.cidefine4 + "',");
            }
            if (model.cidefine5 != null)
            {
                strSql1.Append("cidefine5,");
                strSql2.Append("" + model.cidefine5 + ",");
            }
            if (model.cidefine6 != null)
            {
                strSql1.Append("cidefine6,");
                strSql2.Append("" + model.cidefine6 + ",");
            }
            if (model.cidefine7 != null)
            {
                strSql1.Append("cidefine7,");
                strSql2.Append("" + model.cidefine7 + ",");
            }
            if (model.cidefine8 != null)
            {
                strSql1.Append("cidefine8,");
                strSql2.Append("" + model.cidefine8 + ",");
            }
            if (model.cidefine9 != null)
            {
                strSql1.Append("cidefine9,");
                strSql2.Append("" + model.cidefine9 + ",");
            }
            strSql.Append("insert into @u8.Inventory_extradefine(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            return strSql.ToString();
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string UpdateInventory_extradefine(TH.Model.Inventory_extradefine model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update @u8.Inventory_extradefine set ");
            
          
            if (model.cidefine3 != null)
            {
                strSql.Append("cidefine3=" + model.cidefine3 + ",");
            }
            else
            {
                strSql.Append("cidefine3= null ,");
            }
            if (model.cidefine4 != null)
            {
                strSql.Append("cidefine4='" + model.cidefine4 + "',");
            }
            else
            {
                strSql.Append("cidefine4= null ,");
            }
           
            if (model.cidefine6 != null)
            {
                strSql.Append("cidefine6=" + model.cidefine6 + ",");
            }
            else
            {
                strSql.Append("cidefine6= null ,");
            }
            if (model.cidefine7 != null)
            {
                strSql.Append("cidefine7=" + model.cidefine7 + ",");
            }
            else
            {
                strSql.Append("cidefine7= null ,");
            }
           
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where cInvCode='" + model.cInvCode + "' ");
            return strSql.ToString();
        }


        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

