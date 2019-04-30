using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using ClsBaseClass;

namespace ClsU8
{
    public class ClsPerson
    {
        string tablename = "Person";
        string Code = "PersonCode";
        string Name = "PersonName";
        string CodeTitle = "人员编码";
        string NameTitle = "人员名称";
        string sSQL = "";
        protected ClsGetSQL clsGetSQL = ClsGetSQL.Instance();
        protected ClsDataBase clsSQLCommond = ClsDataBaseFactory.Instance();
        public string dt()
        {
            string s = "";

            try
            {
                sSQL = "select *, 'edit' as iSave from " + tablename;
                DataTable dt = clsSQLCommond.ExecQuery(sSQL); ;
                s = Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }

        public string save(DataTable dtGrid)
        {
            string sErr = "";
            ArrayList aList = new ArrayList();
            try
            {
                sSQL = "select * from " + tablename + " where 1=-1";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                sSQL = "select isnull(max(iID)+1,1) as iID from " + tablename;
                long iID = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));

                for (int i = 0; i < dtGrid.Rows.Count; i++)
                {
                    if (dtGrid.Rows[i]["iSave"].ToString().Trim() == "update" || dtGrid.Rows[i]["iSave"].ToString().Trim() == "add")
                    {
                        #region 判断
                        if (dtGrid.Rows[i][Code].ToString().Trim() == ""
                            && dtGrid.Rows[i][Name].ToString().Trim() == "")
                        {
                            continue;
                        }
                        if (dtGrid.Rows[i][Code].ToString().Trim() == "")
                        {
                            sErr = sErr + "行" + (i + 1) + CodeTitle + "不能为空\n";
                            continue;
                        }


                        if (dtGrid.Rows[i][Name].ToString().Trim() == "")
                        {
                            sErr = sErr + "行" + (i + 1) + NameTitle + "不能为空\n";
                            continue;
                        }

                        //if (dtGrid.Rows[i]["cDepCode"].ToString().Trim() == "")
                        //{
                        //    sErr = sErr + "行" + (i + 1) +"部门不能为空\n";
                        //    continue;
                        //}
                        #endregion

                        #region 判断是否重复
                        for (int j = 0; j < i; j++)
                        {
                            if (dtGrid.Rows[i][Code].ToString().Trim() == dtGrid.Rows[j][Code].ToString().Trim())
                            {
                                sErr = sErr + "行" + (i + 1) + CodeTitle + "重复\n";
                                continue;
                            }
                        }

                        for (int j = 0; j < i; j++)
                        {
                            if (dtGrid.Rows[i][Name].ToString().Trim() == dtGrid.Rows[j][Name].ToString().Trim())
                            {
                                sErr = sErr + "行" + (i + 1) + NameTitle + "重复\n";
                                continue;
                            }
                        }
                        #endregion
                        #region 生成table
                        DataRow dr = dt.NewRow();
                        if (dtGrid.Rows[i]["iID"].ToString().Trim() != "")
                        {
                            dr["iID"] = dtGrid.Rows[i]["iID"];
                        }
                        else
                        {
                            dr["iID"] = iID;
                            iID = iID + 1;
                        }
                        dr[Code] = dtGrid.Rows[i][Code].ToString().Trim();
                        dr[Name] = dtGrid.Rows[i][Name].ToString().Trim();

                        dr["cDepCode"] = dtGrid.Rows[i]["cDepCode"].ToString().Trim();
                        dr["SexID"] = dtGrid.Rows[i]["SexID"].ToString().Trim();
                        dr["cDCCode"] = dtGrid.Rows[i]["cDCCode"].ToString().Trim();
                        dr["BeginDate"] = dtGrid.Rows[i]["BeginDate"];
                        dr["EndDate"] = dtGrid.Rows[i]["EndDate"];
                        dt.Rows.Add(dr);

                        if (dtGrid.Rows[i]["isUserInfo"].ToString().Trim() == "")
                        {
                            dr["isUserInfo"] = 0;
                        }
                        else
                        {
                            dr["isUserInfo"] = dtGrid.Rows[i]["isUserInfo"].ToString().Trim();
                        }
                        
                        #endregion

                        if (dtGrid.Rows[i]["iSave"].ToString().Trim() == "update")
                        {
                            sSQL = clsGetSQL.GetUpdateSQL(ClsBaseDataInfo.sDataBaseName, tablename, dt, dt.Rows.Count - 1);
                            aList.Add(sSQL);
                        }
                        if (dtGrid.Rows[i]["iSave"].ToString().Trim() == "add")
                        {
                            sSQL = clsGetSQL.GetInsertSQL(ClsBaseDataInfo.sDataBaseName, tablename, dt, dt.Rows.Count - 1);
                            aList.Add(sSQL);
                            
                        }
                        if (dtGrid.Rows[i]["isUserInfo"].ToString().Trim() == "True")
                        {
                            sSQL = @"IF EXISTS(select vchrUid From _UserInfo  with (XLOCK) Where  vchrUid='" + dtGrid.Rows[i][Code].ToString().Trim() + "') " +
                            " update _UserInfo set vchrName='" + dtGrid.Rows[i][Name].ToString().Trim() + "' Where  vchrUid='" + dtGrid.Rows[i][Code].ToString().Trim() + "'" +
                            " else insert into _UserInfo(vchrUid,vchrName,vchrPwd) values('" + dtGrid.Rows[i][Code].ToString().Trim() + "','" + dtGrid.Rows[i][Name].ToString().Trim() + "','ADBF8135A642B58A')";
                            aList.Add(sSQL);
                        }
                        
                    }
                }
                if (sErr != "")
                {
                    throw new Exception(sErr);
                }
                if (aList.Count > 0)
                {
                    int iCou = clsSQLCommond.ExecSqlTran(aList);
                }
            }
            catch (Exception ee)
            {
                sErr = ee.Message;
            }
            if (sErr == "")
            {
                return "ok";
            }
            else
            {
                return sErr;
            }
        }

        public string del(string sPerCode)
        {
            string sErr = "";
            ArrayList aList = new ArrayList();
            try
            {
                sSQL = "select count(1) from dbo.ProjectProgress where "+Code+" = '" + sPerCode + "' ";
                long iCou = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));
                if (iCou > 0)
                {
                    throw  new Exception("人员 " + sPerCode + " 在工程中已经使用不能删除\n");
                }

                sSQL = "select count(1) from dbo.ProjectQuality where PersonCode = '" + sPerCode + "' or PersonCaptain='" + sPerCode + "' or PersonCheck='" + sPerCode + "' or PersonAssign='" + sPerCode + "'";
                iCou = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));
                if (iCou > 0)
                {
                    throw  new Exception("人员 " + sPerCode + " 在工程中已经使用不能删除\n");
                }

                sSQL = "select count(1) from dbo.ProjectSecurity where PersonCode = '" + sPerCode + "' or PersonCaptain='" + sPerCode + "' or PersonCheck='" + sPerCode + "' or PersonAssign='" + sPerCode + "' or PersonViolation='" + sPerCode + "'";
                iCou = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));
                if (iCou > 0)
                {
                    throw new Exception("人员 " + sPerCode + " 在工程中已经使用不能删除\n");
                }

                sSQL = "delete " + tablename + " where " + Code + " = '" + sPerCode + "' ";
                aList.Add(sSQL);

                if (sErr != "")
                {
                    throw new Exception(sErr);
                }
                if (aList.Count > 0)
                {
                    clsSQLCommond.ExecSqlTran(aList);
                }
            }
            catch (Exception ee)
            {
                sErr = ee.Message;
            }
            if (sErr == "")
            {
                return "ok";
            }
            else
            {
                return sErr;
            }
        }

        public bool bClosed(string PersonCode)
        {
            string sErr = "";
            ArrayList aList = new ArrayList();
            try
            {
                sSQL = @"select convert(bit,case when 开始日期<GETDATE() and 结束日期>GETDATE() then 0 else 1 end) bClosed from (
select cast(0 as bit) as 选择,PersonCode as iID,PersonCode as 人员编码,PersonName as 人员名称
,case when BeginDate is null then dateadd(d,-1,GETDATE()) else BeginDate end 开始日期
,case when EndDate is null then dateadd(d,1,GETDATE()) else EndDate end 结束日期  from Person 
where 1=1 and PersonCode='" + PersonCode + "') a   order by 人员编码";
                string b = clsSQLCommond.ExecGetScalar(sSQL).ToString();
                if (b != "")
                {
                    return bool.Parse(b);
                }
            }
            catch (Exception ee)
            {
                sErr = ee.Message;
            }
            return false;
        }
    }
}
