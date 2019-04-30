using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using FrameBaseFunction;
using System.Collections.Generic;

namespace TH.DAL
{
    /// <summary>
    /// 数据访问类:WorkCalendar
    /// </summary>
    public partial class WorkCalendar
    {
        public WorkCalendar()
        { }
        #region  Method

        public int Save(List<TH.Model.WorkCalendar> l)
        {
            List<string> list = new List<string>();
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
            }
            return DbHelperSQL.ExecuteSqlTran(list);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(TH.Model.WorkCalendar model)
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
            if (model.iYear != null)
            {
                strSql1.Append("iYear,");
                strSql2.Append("" + model.iYear + ",");
            }
            if (model.iMonth != null)
            {
                strSql1.Append("iMonth,");
                strSql2.Append("" + model.iMonth + ",");
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
            if (model.i21 != null)
            {
                strSql1.Append("i21,");
                strSql2.Append("" + model.i21 + ",");
            }
            if (model.i22 != null)
            {
                strSql1.Append("i22,");
                strSql2.Append("" + model.i22 + ",");
            }
            if (model.i23 != null)
            {
                strSql1.Append("i23,");
                strSql2.Append("" + model.i23 + ",");
            }
            if (model.i24 != null)
            {
                strSql1.Append("i24,");
                strSql2.Append("" + model.i24 + ",");
            }
            if (model.i25 != null)
            {
                strSql1.Append("i25,");
                strSql2.Append("" + model.i25 + ",");
            }
            if (model.i26 != null)
            {
                strSql1.Append("i26,");
                strSql2.Append("" + model.i26 + ",");
            }
            if (model.i27 != null)
            {
                strSql1.Append("i27,");
                strSql2.Append("" + model.i27 + ",");
            }
            if (model.i28 != null)
            {
                strSql1.Append("i28,");
                strSql2.Append("" + model.i28 + ",");
            }
            if (model.i29 != null)
            {
                strSql1.Append("i29,");
                strSql2.Append("" + model.i29 + ",");
            }
            if (model.i30 != null)
            {
                strSql1.Append("i30,");
                strSql2.Append("" + model.i30 + ",");
            }
            if (model.i31 != null)
            {
                strSql1.Append("i31,");
                strSql2.Append("" + model.i31 + ",");
            }
            strSql.Append("insert into WorkCalendar(");
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
        public string Update(TH.Model.WorkCalendar model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update WorkCalendar set ");
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
            if (model.iYear != null)
            {
                strSql.Append("iYear=" + model.iYear + ",");
            }
            if (model.iMonth != null)
            {
                strSql.Append("iMonth=" + model.iMonth + ",");
            }
            if (model.i1 != null && model.i1 != 0)
            {
                strSql.Append("i1=" + model.i1 + ",");
            }
            else
            {
                strSql.Append("i1= null ,");
            }
            if (model.i2 != null && model.i2 != 0)
            {
                strSql.Append("i2=" + model.i2 + ",");
            }
            else
            {
                strSql.Append("i2= null ,");
            }
            if (model.i3 != null && model.i3 != 0)
            {
                strSql.Append("i3=" + model.i3 + ",");
            }
            else
            {
                strSql.Append("i3= null ,");
            }
            if (model.i4 != null && model.i4 != 0)
            {
                strSql.Append("i4=" + model.i4 + ",");
            }
            else
            {
                strSql.Append("i4= null ,");
            }
            if (model.i5 != null && model.i5 != 0)
            {
                strSql.Append("i5=" + model.i5 + ",");
            }
            else
            {
                strSql.Append("i5= null ,");
            }
            if (model.i6 != null && model.i6 != 0)
            {
                strSql.Append("i6=" + model.i6 + ",");
            }
            else
            {
                strSql.Append("i6= null ,");
            }
            if (model.i7 != null && model.i7 != 0)
            {
                strSql.Append("i7=" + model.i7 + ",");
            }
            else
            {
                strSql.Append("i7= null ,");
            }
            if (model.i8 != null && model.i8 != 0)
            {
                strSql.Append("i8=" + model.i8 + ",");
            }
            else
            {
                strSql.Append("i8= null ,");
            }
            if (model.i9 != null && model.i9 != 0)
            {
                strSql.Append("i9=" + model.i9 + ",");
            }
            else
            {
                strSql.Append("i9= null ,");
            }
            if (model.i10 != null && model.i10 != 0)
            {
                strSql.Append("i10=" + model.i10 + ",");
            }
            else
            {
                strSql.Append("i10= null ,");
            }
            if (model.i11 != null && model.i11 != 0)
            {
                strSql.Append("i11=" + model.i11 + ",");
            }
            else
            {
                strSql.Append("i11= null ,");
            }
            if (model.i12 != null && model.i12 != 0)
            {
                strSql.Append("i12=" + model.i12 + ",");
            }
            else
            {
                strSql.Append("i12= null ,");
            }
            if (model.i13 != null && model.i13 != 0)
            {
                strSql.Append("i13=" + model.i13 + ",");
            }
            else
            {
                strSql.Append("i13= null ,");
            }
            if (model.i14 != null && model.i14 != 0)
            {
                strSql.Append("i14=" + model.i14 + ",");
            }
            else
            {
                strSql.Append("i14= null ,");
            }
            if (model.i15 != null && model.i15 != 0)
            {
                strSql.Append("i15=" + model.i15 + ",");
            }
            else
            {
                strSql.Append("i15= null ,");
            }
            if (model.i16 != null && model.i16 != 0)
            {
                strSql.Append("i16=" + model.i16 + ",");
            }
            else
            {
                strSql.Append("i16= null ,");
            }
            if (model.i17 != null && model.i17 != 0)
            {
                strSql.Append("i17=" + model.i17 + ",");
            }
            else
            {
                strSql.Append("i17= null ,");
            }
            if (model.i18 != null && model.i8 != 0)
            {
                strSql.Append("i18=" + model.i18 + ",");
            }
            else
            {
                strSql.Append("i18= null ,");
            }
            if (model.i19 != null && model.i19 != 0)
            {
                strSql.Append("i19=" + model.i19 + ",");
            }
            else
            {
                strSql.Append("i19= null ,");
            }
            if (model.i20 != null && model.i20 != 0)
            {
                strSql.Append("i20=" + model.i20 + ",");
            }
            else
            {
                strSql.Append("i20= null ,");
            }
            if (model.i21 != null && model.i21 != 0)
            {
                strSql.Append("i21=" + model.i21 + ",");
            }
            else
            {
                strSql.Append("i21= null ,");
            }
            if (model.i22 != null && model.i22 != 0)
            {
                strSql.Append("i22=" + model.i22 + ",");
            }
            else
            {
                strSql.Append("i22= null ,");
            }
            if (model.i23 != null && model.i23 != 0)
            {
                strSql.Append("i23=" + model.i23 + ",");
            }
            else
            {
                strSql.Append("i23= null ,");
            }
            if (model.i24 != null && model.i24 != 0)
            {
                strSql.Append("i24=" + model.i24 + ",");
            }
            else
            {
                strSql.Append("i24= null ,");
            }
            if (model.i25 != null && model.i25 != 0)
            {
                strSql.Append("i25=" + model.i25 + ",");
            }
            else
            {
                strSql.Append("i25= null ,");
            }
            if (model.i26 != null && model.i26 != 0)
            {
                strSql.Append("i26=" + model.i26 + ",");
            }
            else
            {
                strSql.Append("i26= null ,");
            }
            if (model.i27 != null && model.i7 != 0)
            {
                strSql.Append("i27=" + model.i27 + ",");
            }
            else
            {
                strSql.Append("i27= null ,");
            }
            if (model.i28 != null && model.i8 != 0)
            {
                strSql.Append("i28=" + model.i28 + ",");
            }
            else
            {
                strSql.Append("i28= null ,");
            }
            if (model.i29 != null && model.i9 != 0)
            {
                strSql.Append("i29=" + model.i29 + ",");
            }
            else
            {
                strSql.Append("i29= null ,");
            }
            if (model.i30 != null && model.i30 != 0)
            {
                strSql.Append("i30=" + model.i30 + ",");
            }
            else
            {
                strSql.Append("i30= null ,");
            }
            if (model.i31 != null && model.i31 != 0)
            {
                strSql.Append("i31=" + model.i31 + ",");
            }
            else
            {
                strSql.Append("i31= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where iID=" + model.iID + "");
            return strSql.ToString();
      
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int iID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from WorkCalendar ");
            strSql.Append(" where iID=" + iID + "");
            int rowsAffected = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }		/// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string iIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from WorkCalendar ");
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
        public TH.Model.WorkCalendar GetModel(int iID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" iID,GUID,CreateUid,CreateDate,UpdateUid,UpdateDate,iYear,iMonth,i1,i2,i3,i4,i5,i6,i7,i8,i9,i10,i11,i12,i13,i14,i15,i16,i17,i18,i19,i20,i21,i22,i23,i24,i25,i26,i27,i28,i29,i30,i31 ");
            strSql.Append(" from WorkCalendar ");
            strSql.Append(" where iID=" + iID + "");
            TH.Model.WorkCalendar model = new TH.Model.WorkCalendar();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TH.Model.WorkCalendar DataRowToModel(DataRow row)
        {
            TH.Model.WorkCalendar model = new TH.Model.WorkCalendar();
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
                if (row["iYear"] != null && row["iYear"].ToString() != "")
                {
                    model.iYear = int.Parse(row["iYear"].ToString());
                }
                if (row["iMonth"] != null && row["iMonth"].ToString() != "")
                {
                    model.iMonth = int.Parse(row["iMonth"].ToString());
                }
                if (row["i1"] != null && row["i1"].ToString() != "")
                {
                    model.i1 = decimal.Parse(row["i1"].ToString());
                }
                if (row["i2"] != null && row["i2"].ToString() != "")
                {
                    model.i2 = decimal.Parse(row["i2"].ToString());
                }
                if (row["i3"] != null && row["i3"].ToString() != "")
                {
                    model.i3 = decimal.Parse(row["i3"].ToString());
                }
                if (row["i4"] != null && row["i4"].ToString() != "")
                {
                    model.i4 = decimal.Parse(row["i4"].ToString());
                }
                if (row["i5"] != null && row["i5"].ToString() != "")
                {
                    model.i5 = decimal.Parse(row["i5"].ToString());
                }
                if (row["i6"] != null && row["i6"].ToString() != "")
                {
                    model.i6 = decimal.Parse(row["i6"].ToString());
                }
                if (row["i7"] != null && row["i7"].ToString() != "")
                {
                    model.i7 = decimal.Parse(row["i7"].ToString());
                }
                if (row["i8"] != null && row["i8"].ToString() != "")
                {
                    model.i8 = decimal.Parse(row["i8"].ToString());
                }
                if (row["i9"] != null && row["i9"].ToString() != "")
                {
                    model.i9 = decimal.Parse(row["i9"].ToString());
                }
                if (row["i10"] != null && row["i10"].ToString() != "")
                {
                    model.i10 = decimal.Parse(row["i10"].ToString());
                }
                if (row["i11"] != null && row["i11"].ToString() != "")
                {
                    model.i11 = decimal.Parse(row["i11"].ToString());
                }
                if (row["i12"] != null && row["i12"].ToString() != "")
                {
                    model.i12 = decimal.Parse(row["i12"].ToString());
                }
                if (row["i13"] != null && row["i13"].ToString() != "")
                {
                    model.i13 = decimal.Parse(row["i13"].ToString());
                }
                if (row["i14"] != null && row["i14"].ToString() != "")
                {
                    model.i14 = decimal.Parse(row["i14"].ToString());
                }
                if (row["i15"] != null && row["i15"].ToString() != "")
                {
                    model.i15 = decimal.Parse(row["i15"].ToString());
                }
                if (row["i16"] != null && row["i16"].ToString() != "")
                {
                    model.i16 = decimal.Parse(row["i16"].ToString());
                }
                if (row["i17"] != null && row["i17"].ToString() != "")
                {
                    model.i17 = decimal.Parse(row["i17"].ToString());
                }
                if (row["i18"] != null && row["i18"].ToString() != "")
                {
                    model.i18 = decimal.Parse(row["i18"].ToString());
                }
                if (row["i19"] != null && row["i19"].ToString() != "")
                {
                    model.i19 = decimal.Parse(row["i19"].ToString());
                }
                if (row["i20"] != null && row["i20"].ToString() != "")
                {
                    model.i20 = decimal.Parse(row["i20"].ToString());
                }
                if (row["i21"] != null && row["i21"].ToString() != "")
                {
                    model.i21 = decimal.Parse(row["i21"].ToString());
                }
                if (row["i22"] != null && row["i22"].ToString() != "")
                {
                    model.i22 = decimal.Parse(row["i22"].ToString());
                }
                if (row["i23"] != null && row["i23"].ToString() != "")
                {
                    model.i23 = decimal.Parse(row["i23"].ToString());
                }
                if (row["i24"] != null && row["i24"].ToString() != "")
                {
                    model.i24 = decimal.Parse(row["i24"].ToString());
                }
                if (row["i25"] != null && row["i25"].ToString() != "")
                {
                    model.i25 = decimal.Parse(row["i25"].ToString());
                }
                if (row["i26"] != null && row["i26"].ToString() != "")
                {
                    model.i26 = decimal.Parse(row["i26"].ToString());
                }
                if (row["i27"] != null && row["i27"].ToString() != "")
                {
                    model.i27 = decimal.Parse(row["i27"].ToString());
                }
                if (row["i28"] != null && row["i28"].ToString() != "")
                {
                    model.i28 = decimal.Parse(row["i28"].ToString());
                }
                if (row["i29"] != null && row["i29"].ToString() != "")
                {
                    model.i29 = decimal.Parse(row["i29"].ToString());
                }
                if (row["i30"] != null && row["i30"].ToString() != "")
                {
                    model.i30 = decimal.Parse(row["i30"].ToString());
                }
                if (row["i31"] != null && row["i31"].ToString() != "")
                {
                    model.i31 = decimal.Parse(row["i31"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select iID,GUID,CreateUid,CreateDate,UpdateUid,UpdateDate,iYear,iMonth,i1,i2,i3,i4,i5,i6,i7,i8,i9,i10,i11,i12,i13,i14,i15,i16,i17,i18,i19,i20,i21,i22,i23,i24,i25,i26,i27,i28,i29,i30,i31 ");
            strSql.Append(" FROM WorkCalendar ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

            DataSet ds = DbHelperSQL.Query(strSql.ToString());
     

            return ds;
        }


        public DataSet GetHolidays(string strWhere)
        {
            string sSQL = "select * from Holidays where year(dHolidays) = " + strWhere + " order by dHolidays";
            return DbHelperSQL.Query(sSQL);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" iID,GUID,CreateUid,CreateDate,UpdateUid,UpdateDate,iYear,iMonth,i1,i2,i3,i4,i5,i6,i7,i8,i9,i10,i11,i12,i13,i14,i15,i16,i17,i18,i19,i20,i21,i22,i23,i24,i25,i26,i27,i28,i29,i30,i31 ");
            strSql.Append(" FROM WorkCalendar ");
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
            strSql.Append("select count(1) FROM WorkCalendar ");
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
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
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
            strSql.Append(")AS Row, T.*  from WorkCalendar T ");
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

