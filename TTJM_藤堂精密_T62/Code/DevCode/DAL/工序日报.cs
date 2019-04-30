using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using FrameBaseFunction;

namespace TH.DAL
{
    /// <summary>
    /// 数据访问类:工序日报
    /// </summary>
    public partial class 工序日报
    {
        _GetBaseData _GetBase = new _GetBaseData();
        public 工序日报()
        { }

        public int Del(DataTable dt)
        {
            string sErr = "";
            int iCou = 0;
            try
            {
                SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (BaseFunction.BaseFunction.ReturnBool(dt.Rows[i]["bChoose"]))
                        {
                            long l = BaseFunction.BaseFunction.ReturnLong(dt.Rows[i]["iID"]);
                            string sSQL = Delete(l);
                            iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                    }

                    if (sErr.Length > 0)
                        throw new Exception(sErr);

                    tran.Commit();
                }
                catch (Exception error)
                {
                    tran.Rollback();
                    iCou = 0;

                    throw new Exception(error.Message);
                }
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }

            return iCou;
        }

        public int Save(DataTable dt)
        {
            string sErr = "";
            int iCou = 0;
            try
            {
                SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (BaseFunction.BaseFunction.ReturnBool(dt.Rows[i]["bChoose"]))
                        {
                            TH.Model.工序日报 model = DataRowToModel(dt.Rows[i]);

                            long l = BaseFunction.BaseFunction.ReturnLong(model.iID);
                            if (l == 0)
                            {
                                model.CreateUserName = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                                model.CreateDate = _GetBase.GetDatetimeSer();
                                string sSQL = Add(model);
                                iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                            }
                            else
                            {

                                model.UpdateUserName = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                                model.UpdateDate = _GetBase.GetDatetimeSer();
                                string sSQL = Update(model);
                                iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL); 
                            }
                        }
                    }

                    if (sErr.Length > 0)
                        throw new Exception(sErr);

                    tran.Commit();
                }
                catch (Exception error)
                {
                    tran.Rollback();
                    iCou = 0;

                    throw new Exception(error.Message);
                }
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }

            return iCou;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        private string Delete(long iID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from 工序报表 ");
            strSql.Append(" where iID=" + iID + " ");
            return strSql.ToString();
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(TH.Model.工序日报 model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.sType != null)
            {
                strSql1.Append("sType,");
                strSql2.Append("'" + model.sType + "',");
            }
            if (model.CreateUserName != null)
            {
                strSql1.Append("CreateUserName,");
                strSql2.Append("'" + model.CreateUserName + "',");
            }
            if (model.CreateDate != null)
            {
                strSql1.Append("CreateDate,");
                strSql2.Append("'" + model.CreateDate + "',");
            }
            if (model.UpdateUserName != null)
            {
                strSql1.Append("UpdateUserName,");
                strSql2.Append("'" + model.UpdateUserName + "',");
            }
            if (model.UpdateDate != null)
            {
                strSql1.Append("UpdateDate,");
                strSql2.Append("'" + model.UpdateDate + "',");
            }
            if (model.AuditUserName != null)
            {
                strSql1.Append("AuditUserName,");
                strSql2.Append("'" + model.AuditUserName + "',");
            }
            if (model.AuditDate != null)
            {
                strSql1.Append("AuditDate,");
                strSql2.Append("'" + model.AuditDate + "',");
            }
            if (model.CloseUserName != null)
            {
                strSql1.Append("CloseUserName,");
                strSql2.Append("'" + model.CloseUserName + "',");
            }
            if (model.CloseDate != null)
            {
                strSql1.Append("CloseDate,");
                strSql2.Append("'" + model.CloseDate + "',");
            }
            if (model.i1 != null)
            {
                strSql1.Append("i1,");
                strSql2.Append("" + model.i1 + ",");
            }
            if (model.i2 != null)
            {
                strSql1.Append("i2,");
                strSql2.Append("" + model.i2 + ",");
            }
            if (model.i3 != null)
            {
                strSql1.Append("i3,");
                strSql2.Append("" + model.i3 + ",");
            }
            if (model.i4 != null)
            {
                strSql1.Append("i4,");
                strSql2.Append("" + model.i4 + ",");
            }
            if (model.i5 != null)
            {
                strSql1.Append("i5,");
                strSql2.Append("" + model.i5 + ",");
            }
            if (model.i6 != null)
            {
                strSql1.Append("i6,");
                strSql2.Append("" + model.i6 + ",");
            }
            if (model.i7 != null)
            {
                strSql1.Append("i7,");
                strSql2.Append("" + model.i7 + ",");
            }
            if (model.i8 != null)
            {
                strSql1.Append("i8,");
                strSql2.Append("" + model.i8 + ",");
            }
            if (model.i9 != null)
            {
                strSql1.Append("i9,");
                strSql2.Append("" + model.i9 + ",");
            }
            if (model.i10 != null)
            {
                strSql1.Append("i10,");
                strSql2.Append("" + model.i10 + ",");
            }
            if (model.i11 != null)
            {
                strSql1.Append("i11,");
                strSql2.Append("" + model.i11 + ",");
            }
            if (model.i12 != null)
            {
                strSql1.Append("i12,");
                strSql2.Append("" + model.i12 + ",");
            }
            if (model.i13 != null)
            {
                strSql1.Append("i13,");
                strSql2.Append("" + model.i13 + ",");
            }
            if (model.i14 != null)
            {
                strSql1.Append("i14,");
                strSql2.Append("" + model.i14 + ",");
            }
            if (model.i15 != null)
            {
                strSql1.Append("i15,");
                strSql2.Append("" + model.i15 + ",");
            }
            if (model.i16 != null)
            {
                strSql1.Append("i16,");
                strSql2.Append("" + model.i16 + ",");
            }
            if (model.i17 != null)
            {
                strSql1.Append("i17,");
                strSql2.Append("" + model.i17 + ",");
            }
            if (model.i18 != null)
            {
                strSql1.Append("i18,");
                strSql2.Append("" + model.i18 + ",");
            }
            if (model.i19 != null)
            {
                strSql1.Append("i19,");
                strSql2.Append("" + model.i19 + ",");
            }
            if (model.i20 != null)
            {
                strSql1.Append("i20,");
                strSql2.Append("" + model.i20 + ",");
            }
            if (model.Date1 != null)
            {
                strSql1.Append("Date1,");
                strSql2.Append("'" + model.Date1 + "',");
            }
            if (model.Date2 != null)
            {
                strSql1.Append("Date2,");
                strSql2.Append("'" + model.Date2 + "',");
            }
            if (model.Date3 != null)
            {
                strSql1.Append("Date3,");
                strSql2.Append("'" + model.Date3 + "',");
            }
            if (model.Date4 != null)
            {
                strSql1.Append("Date4,");
                strSql2.Append("'" + model.Date4 + "',");
            }
            if (model.Date5 != null)
            {
                strSql1.Append("Date5,");
                strSql2.Append("'" + model.Date5 + "',");
            }
            if (model.Date6 != null)
            {
                strSql1.Append("Date6,");
                strSql2.Append("'" + model.Date6 + "',");
            }
            if (model.Date7 != null)
            {
                strSql1.Append("Date7,");
                strSql2.Append("'" + model.Date7 + "',");
            }
            if (model.Date8 != null)
            {
                strSql1.Append("Date8,");
                strSql2.Append("'" + model.Date8 + "',");
            }
            if (model.Date9 != null)
            {
                strSql1.Append("Date9,");
                strSql2.Append("'" + model.Date9 + "',");
            }
            if (model.Date10 != null)
            {
                strSql1.Append("Date10,");
                strSql2.Append("'" + model.Date10 + "',");
            }
            if (model.Date11 != null)
            {
                strSql1.Append("Date11,");
                strSql2.Append("'" + model.Date11 + "',");
            }
            if (model.Date12 != null)
            {
                strSql1.Append("Date12,");
                strSql2.Append("'" + model.Date12 + "',");
            }
            if (model.d1 != null)
            {
                strSql1.Append("d1,");
                strSql2.Append("" + model.d1 + ",");
            }
            if (model.d2 != null)
            {
                strSql1.Append("d2,");
                strSql2.Append("" + model.d2 + ",");
            }
            if (model.d3 != null)
            {
                strSql1.Append("d3,");
                strSql2.Append("" + model.d3 + ",");
            }
            if (model.d4 != null)
            {
                strSql1.Append("d4,");
                strSql2.Append("" + model.d4 + ",");
            }
            if (model.d5 != null)
            {
                strSql1.Append("d5,");
                strSql2.Append("" + model.d5 + ",");
            }
            if (model.d6 != null)
            {
                strSql1.Append("d6,");
                strSql2.Append("" + model.d6 + ",");
            }
            if (model.d7 != null)
            {
                strSql1.Append("d7,");
                strSql2.Append("" + model.d7 + ",");
            }
            if (model.d8 != null)
            {
                strSql1.Append("d8,");
                strSql2.Append("" + model.d8 + ",");
            }
            if (model.d9 != null)
            {
                strSql1.Append("d9,");
                strSql2.Append("" + model.d9 + ",");
            }
            if (model.d10 != null)
            {
                strSql1.Append("d10,");
                strSql2.Append("" + model.d10 + ",");
            }
            if (model.d11 != null)
            {
                strSql1.Append("d11,");
                strSql2.Append("" + model.d11 + ",");
            }
            if (model.d12 != null)
            {
                strSql1.Append("d12,");
                strSql2.Append("" + model.d12 + ",");
            }
            if (model.d13 != null)
            {
                strSql1.Append("d13,");
                strSql2.Append("" + model.d13 + ",");
            }
            if (model.d14 != null)
            {
                strSql1.Append("d14,");
                strSql2.Append("" + model.d14 + ",");
            }
            if (model.d15 != null)
            {
                strSql1.Append("d15,");
                strSql2.Append("" + model.d15 + ",");
            }
            if (model.d16 != null)
            {
                strSql1.Append("d16,");
                strSql2.Append("" + model.d16 + ",");
            }
            if (model.d17 != null)
            {
                strSql1.Append("d17,");
                strSql2.Append("" + model.d17 + ",");
            }
            if (model.d18 != null)
            {
                strSql1.Append("d18,");
                strSql2.Append("" + model.d18 + ",");
            }
            if (model.d19 != null)
            {
                strSql1.Append("d19,");
                strSql2.Append("" + model.d19 + ",");
            }
            if (model.d20 != null)
            {
                strSql1.Append("d20,");
                strSql2.Append("" + model.d20 + ",");
            }
            if (model.s1 != null)
            {
                strSql1.Append("s1,");
                strSql2.Append("'" + model.s1 + "',");
            }
            if (model.s2 != null)
            {
                strSql1.Append("s2,");
                strSql2.Append("'" + model.s2 + "',");
            }
            if (model.s3 != null)
            {
                strSql1.Append("s3,");
                strSql2.Append("'" + model.s3 + "',");
            }
            if (model.s4 != null)
            {
                strSql1.Append("s4,");
                strSql2.Append("'" + model.s4 + "',");
            }
            if (model.s5 != null)
            {
                strSql1.Append("s5,");
                strSql2.Append("'" + model.s5 + "',");
            }
            if (model.s6 != null)
            {
                strSql1.Append("s6,");
                strSql2.Append("'" + model.s6 + "',");
            }
            if (model.s7 != null)
            {
                strSql1.Append("s7,");
                strSql2.Append("'" + model.s7 + "',");
            }
            if (model.s8 != null)
            {
                strSql1.Append("s8,");
                strSql2.Append("'" + model.s8 + "',");
            }
            if (model.s9 != null)
            {
                strSql1.Append("s9,");
                strSql2.Append("'" + model.s9 + "',");
            }
            if (model.s10 != null)
            {
                strSql1.Append("s10,");
                strSql2.Append("'" + model.s10 + "',");
            }
            if (model.s11 != null)
            {
                strSql1.Append("s11,");
                strSql2.Append("'" + model.s11 + "',");
            }
            if (model.s12 != null)
            {
                strSql1.Append("s12,");
                strSql2.Append("'" + model.s12 + "',");
            }
            strSql.Append("insert into 工序报表(");
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
        public string Update(TH.Model.工序日报 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update 工序报表 set ");
            if (model.sType != null)
            {
                strSql.Append("sType='" + model.sType + "',");
            }
            if (model.CreateUserName != null)
            {
                strSql.Append("CreateUserName='" + model.CreateUserName + "',");
            }
            else
            {
                strSql.Append("CreateUserName= null ,");
            }
            if (model.CreateDate != null)
            {
                strSql.Append("CreateDate='" + model.CreateDate + "',");
            }
            else
            {
                strSql.Append("CreateDate= null ,");
            }
            if (model.UpdateUserName != null)
            {
                strSql.Append("UpdateUserName='" + model.UpdateUserName + "',");
            }
            else
            {
                strSql.Append("UpdateUserName= null ,");
            }
            if (model.UpdateDate != null)
            {
                strSql.Append("UpdateDate='" + model.UpdateDate + "',");
            }
            else
            {
                strSql.Append("UpdateDate= null ,");
            }
            if (model.AuditUserName != null)
            {
                strSql.Append("AuditUserName='" + model.AuditUserName + "',");
            }
            else
            {
                strSql.Append("AuditUserName= null ,");
            }
            if (model.AuditDate != null)
            {
                strSql.Append("AuditDate='" + model.AuditDate + "',");
            }
            else
            {
                strSql.Append("AuditDate= null ,");
            }
            if (model.CloseUserName != null)
            {
                strSql.Append("CloseUserName='" + model.CloseUserName + "',");
            }
            else
            {
                strSql.Append("CloseUserName= null ,");
            }
            if (model.CloseDate != null)
            {
                strSql.Append("CloseDate='" + model.CloseDate + "',");
            }
            else
            {
                strSql.Append("CloseDate= null ,");
            }
            if (model.i1 != null)
            {
                strSql.Append("i1=" + model.i1 + ",");
            }
            else
            {
                strSql.Append("i1= null ,");
            }
            if (model.i2 != null)
            {
                strSql.Append("i2=" + model.i2 + ",");
            }
            else
            {
                strSql.Append("i2= null ,");
            }
            if (model.i3 != null)
            {
                strSql.Append("i3=" + model.i3 + ",");
            }
            else
            {
                strSql.Append("i3= null ,");
            }
            if (model.i4 != null)
            {
                strSql.Append("i4=" + model.i4 + ",");
            }
            else
            {
                strSql.Append("i4= null ,");
            }
            if (model.i5 != null)
            {
                strSql.Append("i5=" + model.i5 + ",");
            }
            else
            {
                strSql.Append("i5= null ,");
            }
            if (model.i6 != null)
            {
                strSql.Append("i6=" + model.i6 + ",");
            }
            else
            {
                strSql.Append("i6= null ,");
            }
            if (model.i7 != null)
            {
                strSql.Append("i7=" + model.i7 + ",");
            }
            else
            {
                strSql.Append("i7= null ,");
            }
            if (model.i8 != null)
            {
                strSql.Append("i8=" + model.i8 + ",");
            }
            else
            {
                strSql.Append("i8= null ,");
            }
            if (model.i9 != null)
            {
                strSql.Append("i9=" + model.i9 + ",");
            }
            else
            {
                strSql.Append("i9= null ,");
            }
            if (model.i10 != null)
            {
                strSql.Append("i10=" + model.i10 + ",");
            }
            else
            {
                strSql.Append("i10= null ,");
            }
            if (model.i11 != null)
            {
                strSql.Append("i11=" + model.i11 + ",");
            }
            else
            {
                strSql.Append("i11= null ,");
            }
            if (model.i12 != null)
            {
                strSql.Append("i12=" + model.i12 + ",");
            }
            else
            {
                strSql.Append("i12= null ,");
            }
            if (model.i13 != null)
            {
                strSql.Append("i13=" + model.i13 + ",");
            }
            else
            {
                strSql.Append("i13= null ,");
            }
            if (model.i14 != null)
            {
                strSql.Append("i14=" + model.i14 + ",");
            }
            else
            {
                strSql.Append("i14= null ,");
            }
            if (model.i15 != null)
            {
                strSql.Append("i15=" + model.i15 + ",");
            }
            else
            {
                strSql.Append("i15= null ,");
            }
            if (model.i16 != null)
            {
                strSql.Append("i16=" + model.i16 + ",");
            }
            else
            {
                strSql.Append("i16= null ,");
            }
            if (model.i17 != null)
            {
                strSql.Append("i17=" + model.i17 + ",");
            }
            else
            {
                strSql.Append("i17= null ,");
            }
            if (model.i18 != null)
            {
                strSql.Append("i18=" + model.i18 + ",");
            }
            else
            {
                strSql.Append("i18= null ,");
            }
            if (model.i19 != null)
            {
                strSql.Append("i19=" + model.i19 + ",");
            }
            else
            {
                strSql.Append("i19= null ,");
            }
            if (model.i20 != null)
            {
                strSql.Append("i20=" + model.i20 + ",");
            }
            else
            {
                strSql.Append("i20= null ,");
            }
            if (model.Date1 != null)
            {
                strSql.Append("Date1='" + model.Date1 + "',");
            }
            else
            {
                strSql.Append("Date1= null ,");
            }
            if (model.Date2 != null)
            {
                strSql.Append("Date2='" + model.Date2 + "',");
            }
            else
            {
                strSql.Append("Date2= null ,");
            }
            if (model.Date3 != null)
            {
                strSql.Append("Date3='" + model.Date3 + "',");
            }
            else
            {
                strSql.Append("Date3= null ,");
            }
            if (model.Date4 != null)
            {
                strSql.Append("Date4='" + model.Date4 + "',");
            }
            else
            {
                strSql.Append("Date4= null ,");
            }
            if (model.Date5 != null)
            {
                strSql.Append("Date5='" + model.Date5 + "',");
            }
            else
            {
                strSql.Append("Date5= null ,");
            }
            if (model.Date6 != null)
            {
                strSql.Append("Date6='" + model.Date6 + "',");
            }
            else
            {
                strSql.Append("Date6= null ,");
            }
            if (model.Date7 != null)
            {
                strSql.Append("Date7='" + model.Date7 + "',");
            }
            else
            {
                strSql.Append("Date7= null ,");
            }
            if (model.Date8 != null)
            {
                strSql.Append("Date8='" + model.Date8 + "',");
            }
            else
            {
                strSql.Append("Date8= null ,");
            }
            if (model.Date9 != null)
            {
                strSql.Append("Date9='" + model.Date9 + "',");
            }
            else
            {
                strSql.Append("Date9= null ,");
            }
            if (model.Date10 != null)
            {
                strSql.Append("Date10='" + model.Date10 + "',");
            }
            else
            {
                strSql.Append("Date10= null ,");
            }
            if (model.Date11 != null)
            {
                strSql.Append("Date11='" + model.Date11 + "',");
            }
            else
            {
                strSql.Append("Date11= null ,");
            }
            if (model.Date12 != null)
            {
                strSql.Append("Date12='" + model.Date12 + "',");
            }
            else
            {
                strSql.Append("Date12= null ,");
            }
            if (model.d1 != null)
            {
                strSql.Append("d1=" + model.d1 + ",");
            }
            else
            {
                strSql.Append("d1= null ,");
            }
            if (model.d2 != null)
            {
                strSql.Append("d2=" + model.d2 + ",");
            }
            else
            {
                strSql.Append("d2= null ,");
            }
            if (model.d3 != null)
            {
                strSql.Append("d3=" + model.d3 + ",");
            }
            else
            {
                strSql.Append("d3= null ,");
            }
            if (model.d4 != null)
            {
                strSql.Append("d4=" + model.d4 + ",");
            }
            else
            {
                strSql.Append("d4= null ,");
            }
            if (model.d5 != null)
            {
                strSql.Append("d5=" + model.d5 + ",");
            }
            else
            {
                strSql.Append("d5= null ,");
            }
            if (model.d6 != null)
            {
                strSql.Append("d6=" + model.d6 + ",");
            }
            else
            {
                strSql.Append("d6= null ,");
            }
            if (model.d7 != null)
            {
                strSql.Append("d7=" + model.d7 + ",");
            }
            else
            {
                strSql.Append("d7= null ,");
            }
            if (model.d8 != null)
            {
                strSql.Append("d8=" + model.d8 + ",");
            }
            else
            {
                strSql.Append("d8= null ,");
            }
            if (model.d9 != null)
            {
                strSql.Append("d9=" + model.d9 + ",");
            }
            else
            {
                strSql.Append("d9= null ,");
            }
            if (model.d10 != null)
            {
                strSql.Append("d10=" + model.d10 + ",");
            }
            else
            {
                strSql.Append("d10= null ,");
            }
            if (model.d11 != null)
            {
                strSql.Append("d11=" + model.d11 + ",");
            }
            else
            {
                strSql.Append("d11= null ,");
            }
            if (model.d12 != null)
            {
                strSql.Append("d12=" + model.d12 + ",");
            }
            else
            {
                strSql.Append("d12= null ,");
            }
            if (model.d13 != null)
            {
                strSql.Append("d13=" + model.d13 + ",");
            }
            else
            {
                strSql.Append("d13= null ,");
            }
            if (model.d14 != null)
            {
                strSql.Append("d14=" + model.d14 + ",");
            }
            else
            {
                strSql.Append("d14= null ,");
            }
            if (model.d15 != null)
            {
                strSql.Append("d15=" + model.d15 + ",");
            }
            else
            {
                strSql.Append("d15= null ,");
            }
            if (model.d16 != null)
            {
                strSql.Append("d16=" + model.d16 + ",");
            }
            else
            {
                strSql.Append("d16= null ,");
            }
            if (model.d17 != null)
            {
                strSql.Append("d17=" + model.d17 + ",");
            }
            else
            {
                strSql.Append("d17= null ,");
            }
            if (model.d18 != null)
            {
                strSql.Append("d18=" + model.d18 + ",");
            }
            else
            {
                strSql.Append("d18= null ,");
            }
            if (model.d19 != null)
            {
                strSql.Append("d19=" + model.d19 + ",");
            }
            else
            {
                strSql.Append("d19= null ,");
            }
            if (model.d20 != null)
            {
                strSql.Append("d20=" + model.d20 + ",");
            }
            else
            {
                strSql.Append("d20= null ,");
            }
            if (model.s1 != null)
            {
                strSql.Append("s1='" + model.s1 + "',");
            }
            else
            {
                strSql.Append("s1= null ,");
            }
            if (model.s2 != null)
            {
                strSql.Append("s2='" + model.s2 + "',");
            }
            else
            {
                strSql.Append("s2= null ,");
            }
            if (model.s3 != null)
            {
                strSql.Append("s3='" + model.s3 + "',");
            }
            else
            {
                strSql.Append("s3= null ,");
            }
            if (model.s4 != null)
            {
                strSql.Append("s4='" + model.s4 + "',");
            }
            else
            {
                strSql.Append("s4= null ,");
            }
            if (model.s5 != null)
            {
                strSql.Append("s5='" + model.s5 + "',");
            }
            else
            {
                strSql.Append("s5= null ,");
            }
            if (model.s6 != null)
            {
                strSql.Append("s6='" + model.s6 + "',");
            }
            else
            {
                strSql.Append("s6= null ,");
            }
            if (model.s7 != null)
            {
                strSql.Append("s7='" + model.s7 + "',");
            }
            else
            {
                strSql.Append("s7= null ,");
            }
            if (model.s8 != null)
            {
                strSql.Append("s8='" + model.s8 + "',");
            }
            else
            {
                strSql.Append("s8= null ,");
            }
            if (model.s9 != null)
            {
                strSql.Append("s9='" + model.s9 + "',");
            }
            else
            {
                strSql.Append("s9= null ,");
            }
            if (model.s10 != null)
            {
                strSql.Append("s10='" + model.s10 + "',");
            }
            else
            {
                strSql.Append("s10= null ,");
            }
            if (model.s11 != null)
            {
                strSql.Append("s11='" + model.s11 + "',");
            }
            else
            {
                strSql.Append("s11= null ,");
            }
            if (model.s12 != null)
            {
                strSql.Append("s12='" + model.s12 + "',");
            }
            else
            {
                strSql.Append("s12= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where iID=" + model.iID + " ");
            return strSql.ToString();
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TH.Model.工序日报 DataRowToModel(DataRow row)
        {
            TH.Model.工序日报 model = new TH.Model.工序日报();
           	if (row != null)
			{
				if(row["iID"]!=null && row["iID"].ToString()!="")
				{
					model.iID=int.Parse(row["iID"].ToString());
				}
				if(row["sType"]!=null)
				{
					model.sType=row["sType"].ToString();
				}
				if(row["CreateUserName"]!=null)
				{
					model.CreateUserName=row["CreateUserName"].ToString();
				}
				if(row["CreateDate"]!=null && row["CreateDate"].ToString()!="")
				{
					model.CreateDate=DateTime.Parse(row["CreateDate"].ToString());
				}
				if(row["UpdateUserName"]!=null)
				{
					model.UpdateUserName=row["UpdateUserName"].ToString();
				}
				if(row["UpdateDate"]!=null && row["UpdateDate"].ToString()!="")
				{
					model.UpdateDate=DateTime.Parse(row["UpdateDate"].ToString());
				}
				if(row["AuditUserName"]!=null)
				{
					model.AuditUserName=row["AuditUserName"].ToString();
				}
				if(row["AuditDate"]!=null && row["AuditDate"].ToString()!="")
				{
					model.AuditDate=DateTime.Parse(row["AuditDate"].ToString());
				}
				if(row["CloseUserName"]!=null)
				{
					model.CloseUserName=row["CloseUserName"].ToString();
				}
				if(row["CloseDate"]!=null && row["CloseDate"].ToString()!="")
				{
					model.CloseDate=DateTime.Parse(row["CloseDate"].ToString());
				}
				if(row["i1"]!=null && row["i1"].ToString()!="")
				{
					model.i1=int.Parse(row["i1"].ToString());
				}
				if(row["i2"]!=null && row["i2"].ToString()!="")
				{
					model.i2=int.Parse(row["i2"].ToString());
				}
				if(row["i3"]!=null && row["i3"].ToString()!="")
				{
					model.i3=int.Parse(row["i3"].ToString());
				}
				if(row["i4"]!=null && row["i4"].ToString()!="")
				{
					model.i4=int.Parse(row["i4"].ToString());
				}
				if(row["i5"]!=null && row["i5"].ToString()!="")
				{
					model.i5=int.Parse(row["i5"].ToString());
				}
				if(row["i6"]!=null && row["i6"].ToString()!="")
				{
					model.i6=int.Parse(row["i6"].ToString());
				}
				if(row["i7"]!=null && row["i7"].ToString()!="")
				{
					model.i7=int.Parse(row["i7"].ToString());
				}
				if(row["i8"]!=null && row["i8"].ToString()!="")
				{
					model.i8=int.Parse(row["i8"].ToString());
				}
				if(row["i9"]!=null && row["i9"].ToString()!="")
				{
					model.i9=int.Parse(row["i9"].ToString());
				}
				if(row["i10"]!=null && row["i10"].ToString()!="")
				{
					model.i10=int.Parse(row["i10"].ToString());
				}
				if(row["i11"]!=null && row["i11"].ToString()!="")
				{
					model.i11=int.Parse(row["i11"].ToString());
				}
				if(row["i12"]!=null && row["i12"].ToString()!="")
				{
					model.i12=int.Parse(row["i12"].ToString());
				}
				if(row["i13"]!=null && row["i13"].ToString()!="")
				{
					model.i13=int.Parse(row["i13"].ToString());
				}
				if(row["i14"]!=null && row["i14"].ToString()!="")
				{
					model.i14=int.Parse(row["i14"].ToString());
				}
				if(row["i15"]!=null && row["i15"].ToString()!="")
				{
					model.i15=int.Parse(row["i15"].ToString());
				}
				if(row["i16"]!=null && row["i16"].ToString()!="")
				{
					model.i16=int.Parse(row["i16"].ToString());
				}
				if(row["i17"]!=null && row["i17"].ToString()!="")
				{
					model.i17=int.Parse(row["i17"].ToString());
				}
				if(row["i18"]!=null && row["i18"].ToString()!="")
				{
					model.i18=int.Parse(row["i18"].ToString());
				}
				if(row["i19"]!=null && row["i19"].ToString()!="")
				{
					model.i19=int.Parse(row["i19"].ToString());
				}
				if(row["i20"]!=null && row["i20"].ToString()!="")
				{
					model.i20=int.Parse(row["i20"].ToString());
				}
				if(row["Date1"]!=null && row["Date1"].ToString()!="")
				{
					model.Date1=DateTime.Parse(row["Date1"].ToString());
				}
				if(row["Date2"]!=null && row["Date2"].ToString()!="")
				{
					model.Date2=DateTime.Parse(row["Date2"].ToString());
				}
				if(row["Date3"]!=null && row["Date3"].ToString()!="")
				{
					model.Date3=DateTime.Parse(row["Date3"].ToString());
				}
				if(row["Date4"]!=null && row["Date4"].ToString()!="")
				{
					model.Date4=DateTime.Parse(row["Date4"].ToString());
				}
				if(row["Date5"]!=null && row["Date5"].ToString()!="")
				{
					model.Date5=DateTime.Parse(row["Date5"].ToString());
				}
				if(row["Date6"]!=null && row["Date6"].ToString()!="")
				{
					model.Date6=DateTime.Parse(row["Date6"].ToString());
				}
				if(row["Date7"]!=null && row["Date7"].ToString()!="")
				{
					model.Date7=DateTime.Parse(row["Date7"].ToString());
				}
				if(row["Date8"]!=null && row["Date8"].ToString()!="")
				{
					model.Date8=DateTime.Parse(row["Date8"].ToString());
				}
				if(row["Date9"]!=null && row["Date9"].ToString()!="")
				{
					model.Date9=DateTime.Parse(row["Date9"].ToString());
				}
				if(row["Date10"]!=null && row["Date10"].ToString()!="")
				{
					model.Date10=DateTime.Parse(row["Date10"].ToString());
				}
				if(row["Date11"]!=null && row["Date11"].ToString()!="")
				{
					model.Date11=DateTime.Parse(row["Date11"].ToString());
				}
				if(row["Date12"]!=null && row["Date12"].ToString()!="")
				{
					model.Date12=DateTime.Parse(row["Date12"].ToString());
				}
				if(row["d1"]!=null && row["d1"].ToString()!="")
				{
					model.d1=decimal.Parse(row["d1"].ToString());
				}
				if(row["d2"]!=null && row["d2"].ToString()!="")
				{
					model.d2=decimal.Parse(row["d2"].ToString());
				}
				if(row["d3"]!=null && row["d3"].ToString()!="")
				{
					model.d3=decimal.Parse(row["d3"].ToString());
				}
				if(row["d4"]!=null && row["d4"].ToString()!="")
				{
					model.d4=decimal.Parse(row["d4"].ToString());
				}
				if(row["d5"]!=null && row["d5"].ToString()!="")
				{
					model.d5=decimal.Parse(row["d5"].ToString());
				}
				if(row["d6"]!=null && row["d6"].ToString()!="")
				{
					model.d6=decimal.Parse(row["d6"].ToString());
				}
				if(row["d7"]!=null && row["d7"].ToString()!="")
				{
					model.d7=decimal.Parse(row["d7"].ToString());
				}
				if(row["d8"]!=null && row["d8"].ToString()!="")
				{
					model.d8=decimal.Parse(row["d8"].ToString());
				}
				if(row["d9"]!=null && row["d9"].ToString()!="")
				{
					model.d9=decimal.Parse(row["d9"].ToString());
				}
				if(row["d10"]!=null && row["d10"].ToString()!="")
				{
					model.d10=decimal.Parse(row["d10"].ToString());
				}
				if(row["d11"]!=null && row["d11"].ToString()!="")
				{
					model.d11=decimal.Parse(row["d11"].ToString());
				}
				if(row["d12"]!=null && row["d12"].ToString()!="")
				{
					model.d12=decimal.Parse(row["d12"].ToString());
				}
				if(row["d13"]!=null && row["d13"].ToString()!="")
				{
					model.d13=decimal.Parse(row["d13"].ToString());
				}
				if(row["d14"]!=null && row["d14"].ToString()!="")
				{
					model.d14=decimal.Parse(row["d14"].ToString());
				}
				if(row["d15"]!=null && row["d15"].ToString()!="")
				{
					model.d15=decimal.Parse(row["d15"].ToString());
				}
				if(row["d16"]!=null && row["d16"].ToString()!="")
				{
					model.d16=decimal.Parse(row["d16"].ToString());
				}
				if(row["d17"]!=null && row["d17"].ToString()!="")
				{
					model.d17=decimal.Parse(row["d17"].ToString());
				}
				if(row["d18"]!=null && row["d18"].ToString()!="")
				{
					model.d18=decimal.Parse(row["d18"].ToString());
				}
				if(row["d19"]!=null && row["d19"].ToString()!="")
				{
					model.d19=decimal.Parse(row["d19"].ToString());
				}
				if(row["d20"]!=null && row["d20"].ToString()!="")
				{
					model.d20=decimal.Parse(row["d20"].ToString());
				}
				if(row["s1"]!=null)
				{
					model.s1=row["s1"].ToString();
				}
				if(row["s2"]!=null)
				{
					model.s2=row["s2"].ToString();
				}
				if(row["s3"]!=null)
				{
					model.s3=row["s3"].ToString();
				}
				if(row["s4"]!=null)
				{
					model.s4=row["s4"].ToString();
				}
				if(row["s5"]!=null)
				{
					model.s5=row["s5"].ToString();
				}
				if(row["s6"]!=null)
				{
					model.s6=row["s6"].ToString();
				}
				if(row["s7"]!=null)
				{
					model.s7=row["s7"].ToString();
				}
				if(row["s8"]!=null)
				{
					model.s8=row["s8"].ToString();
				}
				if(row["s9"]!=null)
				{
					model.s9=row["s9"].ToString();
				}
				if(row["s10"]!=null)
				{
					model.s10=row["s10"].ToString();
				}
				if(row["s11"]!=null)
				{
					model.s11=row["s11"].ToString();
				}
				if(row["s12"]!=null)
				{
					model.s12=row["s12"].ToString();
				}
			}
			return model;
        }

    }
}

