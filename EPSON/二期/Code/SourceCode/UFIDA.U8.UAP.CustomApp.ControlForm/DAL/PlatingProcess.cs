using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:_PlatingProcess
    /// </summary>
    public partial class _PlatingProcess
    {
        public _PlatingProcess()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public string Exists(string ItemCode, string ProcessCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from _PlatingProcess");
            strSql.Append(" where ItemCode='" + ItemCode + "' and ProcessCode='" + ProcessCode + "' ");
            return (strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model._PlatingProcess model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.Remark != null)
            {
                strSql1.Append("Remark,");
                strSql2.Append("'" + model.Remark + "',");
            }
            if (model.iState != null)
            {
                strSql1.Append("iState,");
                strSql2.Append("'" + model.iState + "',");
            }
            if (model.CreaterUid != null)
            {
                strSql1.Append("CreaterUid,");
                strSql2.Append("'" + model.CreaterUid + "',");
            }
            if (model.CreaterDate != null)
            {
                strSql1.Append("CreaterDate,");
                strSql2.Append("'" + model.CreaterDate + "',");
            }
            if (model.ItemCode != null)
            {
                strSql1.Append("ItemCode,");
                strSql2.Append("'" + model.ItemCode + "',");
            }
            if (model.ProcessCode != null)
            {
                strSql1.Append("ProcessCode,");
                strSql2.Append("'" + model.ProcessCode + "',");
            }
            if (model.Material != null)
            {
                strSql1.Append("Material,");
                strSql2.Append("'" + model.Material + "',");
            }
            if (model.XRayFile != null)
            {
                strSql1.Append("XRayFile,");
                strSql2.Append("'" + model.XRayFile + "',");
            }
            if (model.FinishingSpec != null)
            {
                strSql1.Append("FinishingSpec,");
                strSql2.Append("'" + model.FinishingSpec + "',");
            }
            if (model.CommonPltSpec != null)
            {
                strSql1.Append("CommonPltSpec,");
                strSql2.Append("'" + model.CommonPltSpec + "',");
            }
            if (model.Color != null)
            {
                strSql1.Append("color,");
                strSql2.Append("'" + model.Color + "',");
            }
            if (model.Grade != null)
            {
                strSql1.Append("Grade,");
                strSql2.Append("'" + model.Grade + "',");
            }
            if (model.UnitSurfaceArea != null)
            {
                strSql1.Append("UnitSurfaceArea,");
                strSql2.Append("'" + model.UnitSurfaceArea + "',");
            }
            if (model.UnitWeight != null)
            {
                strSql1.Append("UnitWeight,");
                strSql2.Append("'" + model.UnitWeight + "',");
            }
            if (model.Note1 != null)
            {
                strSql1.Append("Note1,");
                strSql2.Append("'" + model.Note1 + "',");
            }
            if (model.Note2 != null)
            {
                strSql1.Append("Note2,");
                strSql2.Append("'" + model.Note2 + "',");
            }
            if (model.Note3 != null)
            {
                strSql1.Append("Note3,");
                strSql2.Append("'" + model.Note3 + "',");
            }
            if (model.UpdatedDate != null)
            {
                strSql1.Append("UpdatedDate,");
                strSql2.Append("'" + model.UpdatedDate + "',");
            }
            if (model.UpdatedBy != null)
            {
                strSql1.Append("UpdatedBy,");
                strSql2.Append("'" + model.UpdatedBy + "',");
            }
            strSql.Append("insert into _PlatingProcess(");
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
        public string Update(UFIDA.U8.UAP.CustomApp.ControlForm.Model._PlatingProcess model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update _PlatingProcess set ");
            if (model.Remark != null)
            {
                strSql.Append("Remark='" + model.Remark + "',");
            }
            else
            {
                strSql.Append("Remark= null ,");
            }
            if (model.CreaterUid != null)
            {
                strSql.Append("CreaterUid='" + model.CreaterUid + "',");
            }
            else
            {
                strSql.Append("CreaterUid= null ,");
            }
            if (model.CreaterDate != null)
            {
                strSql.Append("CreaterDate='" + model.CreaterDate + "',");
            }
            else
            {
                strSql.Append("CreaterDate= null ,");
            }
            if (model.ItemCode != null)
            {
                strSql.Append("ItemCode='" + model.ItemCode + "',");
            }
            else
            {
                strSql.Append("ItemCode= null ,");
            }
            if (model.ProcessCode != null)
            {
                strSql.Append("ProcessCode='" + model.ProcessCode + "',");
            }
            else
            {
                strSql.Append("ProcessCode= null ,");
            }
            if (model.Material != null)
            {
                strSql.Append("Material='" + model.Material + "',");
            }
            else
            {
                strSql.Append("Material= null ,");
            }
            if (model.Color != null)
            {
                strSql.Append("Color='" + model.Color + "',");
            }
            else
            {
                strSql.Append("Color= null ,");
            }
            if (model.XRayFile != null)
            {
                strSql.Append("XRayFile='" + model.XRayFile + "',");
            }
            else
            {
                strSql.Append("XRayFile= null ,");
            }
            if (model.FinishingSpec != null)
            {
                strSql.Append("FinishingSpec='" + model.FinishingSpec + "',");
            }
            else
            {
                strSql.Append("FinishingSpec= null ,");
            }
            if (model.CommonPltSpec != null)
            {
                strSql.Append("CommonPltSpec='" + model.CommonPltSpec + "',");
            }
            else
            {
                strSql.Append("CommonPltSpec= null ,");
            }
            if (model.Grade != null)
            {
                strSql.Append("Grade='" + model.Grade + "',");
            }
            else
            {
                strSql.Append("Grade= null ,");
            }
            if (model.UnitSurfaceArea != null)
            {
                strSql.Append("UnitSurfaceArea='" + model.UnitSurfaceArea + "',");
            }
            else
            {
                strSql.Append("UnitSurfaceArea= null ,");
            }
            if (model.UnitWeight != null)
            {
                strSql.Append("UnitWeight='" + model.UnitWeight + "',");
            }
            else
            {
                strSql.Append("UnitWeight= null ,");
            }
            if (model.Note1 != null)
            {
                strSql.Append("Note1='" + model.Note1 + "',");
            }
            else
            {
                strSql.Append("Note1= null ,");
            }
            if (model.Note2 != null)
            {
                strSql.Append("Note2='" + model.Note2 + "',");
            }
            else
            {
                strSql.Append("Note2= null ,");
            }
            if (model.Note3 != null)
            {
                strSql.Append("Note3='" + model.Note3 + "',");
            }
            else
            {
                strSql.Append("Note3= null ,");
            }
            if (model.UpdatedDate != null)
            {
                strSql.Append("UpdatedDate='" + model.UpdatedDate + "',");
            }
            else
            {
                strSql.Append("UpdatedDate= null ,");
            }
            if (model.UpdatedBy != null)
            {
                strSql.Append("UpdatedBy='" + model.UpdatedBy + "',");
            }
            else
            {
                strSql.Append("UpdatedBy= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where iID=" + model.iID + "");
            return (strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public string Delete(int iID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from _PlatingProcess ");
            strSql.Append(" where iID=" + iID + "");
            return (strSql.ToString());

        }	

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public UFIDA.U8.UAP.CustomApp.ControlForm.Model._PlatingProcess DataRowToModel(DataRow row)
        {
            UFIDA.U8.UAP.CustomApp.ControlForm.Model._PlatingProcess model = new UFIDA.U8.UAP.CustomApp.ControlForm.Model._PlatingProcess();
            if (row != null)
            {
                if (row["iID"] != null && row["iID"].ToString() != "")
                {
                    model.iID = int.Parse(row["iID"].ToString());
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["iState"] != null)
                {
                    model.iState = row["iState"].ToString();
                }
                if (row["CreaterUid"] != null)
                {
                    model.CreaterUid = row["CreaterUid"].ToString();
                }
                if (row["CreaterDate"] != null && row["CreaterDate"].ToString() != "")
                {
                    model.CreaterDate = DateTime.Parse(row["CreaterDate"].ToString());
                }
                if (row["ItemCode"] != null)
                {
                    model.ItemCode = row["ItemCode"].ToString();
                }
                if (row["ProcessCode"] != null)
                {
                    model.ProcessCode = row["ProcessCode"].ToString();
                }
                if (row["Material"] != null)
                {
                    model.Material = row["Material"].ToString();
                }
                if (row["XRayFile"] != null)
                {
                    model.XRayFile = row["XRayFile"].ToString();
                }
                if (row["FinishingSpec"] != null)
                {
                    model.FinishingSpec = row["FinishingSpec"].ToString();
                }
                if (row["CommonPltSpec"] != null)
                {
                    model.CommonPltSpec = row["CommonPltSpec"].ToString();
                }
                if (row["Grade"] != null)
                {
                    model.Grade = row["Grade"].ToString();
                }
                if (row["UnitSurfaceArea"] != null)
                {
                    model.UnitSurfaceArea = row["UnitSurfaceArea"].ToString();
                }
                if (row["UnitWeight"] != null)
                {
                    model.UnitWeight = row["UnitWeight"].ToString();
                }
                if (row["Note1"] != null)
                {
                    model.Note1 = row["Note1"].ToString();
                }
                if (row["Note2"] != null)
                {
                    model.Note2 = row["Note2"].ToString();
                }
                if (row["Note3"] != null)
                {
                    model.Note3 = row["Note3"].ToString();
                }
                if (row["UpdatedDate"] != null && row["UpdatedDate"].ToString() != "")
                {
                    model.UpdatedDate = DateTime.Parse(row["UpdatedDate"].ToString());
                }
                if (row["UpdatedBy"] != null)
                {
                    model.UpdatedBy = row["UpdatedBy"].ToString();
                }
            }
            return model;
        }

        

        /*
        */

        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

