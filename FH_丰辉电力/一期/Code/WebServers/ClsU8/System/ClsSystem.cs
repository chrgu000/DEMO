using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using ClsBaseClass;

namespace ClsU8
{
    public class ClsSystem
    {
        protected ClsGetSQL clsGetSQL = ClsGetSQL.Instance();
        ClsDataBase clsSQLCommond = ClsDataBaseFactory.Instance();

        public DateTime dtm当前服务器时间()
        {
            DateTime dToday = Convert.ToDateTime("1900-01-01");
            try
            {
                string sSQL = "select getdate()";
                dToday = Convert.ToDateTime(clsSQLCommond.ExecGetScalar(sSQL).ToString());
            }
            catch (Exception ee)
            {

            }
            return dToday;
        }

        public string dtUserInfo(string vchrUid, string vchrPwd)
        {
            string s = "";

            try
            {
                bool b注册 = false;
                string sSQL = @"
SELECT     TOP (200) iID, sType, cCode, cText
FROM         _Code
WHERE     (sType = 'aaa')
";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt == null || dt.Rows.Count != 1)
                {
                    b注册 = false;
                }
                else
                {
                    b注册 = true;
                }

                ClsDES clsDes = ClsDES.Instance();
                DateTime d注册 = Convert.ToDateTime(clsDes.Decrypt(clsDes.Decrypt(dt.Rows[0]["cText"].ToString().Trim())));
                sSQL = "select getdate()";
                DateTime dNow = Convert.ToDateTime(clsSQLCommond.ExecGetScalar(sSQL));
                if (d注册 > dNow)
                {
                    if (b注册)
                    {
                        sSQL = "select  vchrUid, vchrPwd, vchrRemark, tstamp, dtmCreate, dtmClose from  _UserInfo " +
                                   "where vchrUid = '" + vchrUid.Trim() + "' and vchrPwd = '" + vchrPwd.Trim() + "'";
                        dt = clsSQLCommond.ExecQuery(sSQL);
                        s = Cls序列化.SerializeDataTableXml(dt);
                    }
                }
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }

        public string dtGetAccInfo()
        {
            string s = "";

            try
            {
                string sSQL = "SELECT DISTINCT A.cAcc_Id,'[' + A.cAcc_Id + ']' + A.cAcc_Name as vchrText  " +
                         "FROM UFSystem.dbo.UA_Account A,UFSystem.dbo.UA_period P   " +
                         "WHERE A.cAcc_Id=P.cAcc_Id AND (P.bIsDelete=0 OR P.bIsDelete IS NULL)  " +
                         "ORDER BY A.cAcc_Id,vchrText";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);;
                s = Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }

        public string svchrName(string vchrUid)
        {
            string s = "";

            try
            {
                string sSQL = "select  vchrName from  _UserInfo " +
                           "where vchrUid = '" + vchrUid.Trim() + "' ";
                s = clsSQLCommond.ExecGetScalar(sSQL).ToString();
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }

        public string sbU8Improt(string sUFDataBaseName)
        {
            string s = "";

            try
            {
                string sSQL = "select count(*) from Master.dbo.sysdatabases where name='" + sUFDataBaseName.Trim() + "'";
                s = clsSQLCommond.ExecGetScalar(sSQL).ToString();
            }
            catch (Exception ee)
            {

            }
            return s;
        }

        public string saveDefine1(string vchrUid)
        {
            string s = "";
            try
            {
                string sSQL = @"insert into Define1(S1,s6,SysCreateDate)values('" + vchrUid.Trim() + "','系统登录',getdate())";
                clsSQLCommond.ExecSql(sSQL);
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }

        public string saveDefine1all(string vchrUid, string sUserName, string Name, string Text, string ClickedItemName, string ClickedItemText)
        {
            string s = "";
            try
            {
                string sSQL = "insert into Define1(S1,s2,S3,S4,S5,S6,SysCreateDate)values('" + vchrUid + "','" + sUserName + "','" + Name + "','" + Text + "','" + ClickedItemName + "','" + ClickedItemText + "',getdate())";
                clsSQLCommond.ExecSql(sSQL);
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }

        public string saveUserInfoPwd(string vchrUid, string vchrPwd)
        {
            string s = "";
            try
            {
                string sSQL = @"update _UserInfo set vchrPwd = '" + vchrPwd + "' where vchrUid = '" + vchrUid + "'";
                clsSQLCommond.ExecSql(sSQL);
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }

        public int sUserRoleInfo(string vchrRoleID, string sUid)
        {
            int s = 0;
            try
            {
                string sSQL = @"select count(*) from dbo._UserRoleInfo where vchrRoleID = '" + vchrRoleID + "' and vchrUserID = '" + sUid + "'";
                s = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL).ToString());
            }
            catch (Exception ee)
            {

            }
            return s;
        }

        public int sRoleRight(string sUid, string sInfo)
        {
            int s = 0;
            try
            {
                string sSQL = "SELECT     COUNT(*) AS iCount " +
                              "FROM         dbo._RoleRight INNER JOIN dbo._UserRoleInfo ON _RoleRight.vchrRoleID = dbo._UserRoleInfo.vchrRoleID " +
                              "WHERE   dbo._UserRoleInfo.vchrUserID = '" + sUid + "' and dbo._RoleRight.vchrRoleRight = '" + sInfo + "' ";
                s = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL).ToString());
            }
            catch (Exception ee)
            {

            }
            return s;
        }

        public string svchrRoleID(string sUid)
        {
            string s = "";

            try
            {
                string sSQL = "select vchrRoleID from dbo._UserRoleInfo where vchrUserID = '" + sUid + "'";
                s = clsSQLCommond.ExecGetScalar(sSQL).ToString().Trim();
            }
            catch (Exception ee)
            {
            }
            return s;
        }

        public string sDeptID(string sUid)
        {
            string s = "";

            try
            {
                string sSQL = "select a.DeptID from dbo.Person a inner join dbo.Department b on b.cDepCode = a.DeptID where a.PersonCode = '" + sUid + "'";
                s = clsSQLCommond.ExecGetScalar(sSQL).ToString().Trim();
            }
            catch (Exception ee)
            {
            }
            return s;
        }

        public string dtForm(string fchrFrmNameID, string fchrFrmText,string Flag)
        {
            string s = "";
            string sSQL = "";
            try
            {
                if (Flag == "1")
                {
                    sSQL = @"select * from _Form where fchrFrmNameID = '" + fchrFrmNameID + "' and fchrFrmText = '" + fchrFrmText + "' ORDER BY fIntOrderID";
                }
                else if (Flag == "2")
                {
                    sSQL = @"select * from _Form ORDER BY fIntOrderID";
                }
                else if (Flag == "3")
                {
                    sSQL = @"select * from _Form  WHERE (fbitHide = 0) AND (fbitNoUse = 0)ORDER BY fIntOrderID";
                }
                DataTable dt = clsSQLCommond.ExecQuery(sSQL); 
                s = Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }

        public string dtFormBtnInfo(string fchrFrmNameID, string fchrFrmText)
        {
            string s = "";

            try
            {
                string sSQL = @"select *,vchrBtnText as FormText,intOrder as FormOrder from dbo._FormBtnInfo where fchrFrmNameID = '" + fchrFrmNameID + "/" + fchrFrmText + "'";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                s = Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }

        public string dtBtnBaseInfo()
        {
            string s = "";

            try
            {
                string sSQL = @"select '' as bChoose,*,'' as FormText,'' as FormOrder,'' as FormEnable from _BtnBaseInfo order by iOrder";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                s = Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }

        public string dtCreateBtn(string sUid, string sFormInfo)
        {
            string s = "";

            try
            {
                string sSQL2 = @"select count(*) from dbo._UserRoleInfo where vchrRoleID = 'administrator' and vchrUserID = '" + sUid + "'";
                string sSQL = "";
                if (sUid == "admin" || sUid == "system" || Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL2)) != 0)
                {
                    sSQL = "SELECT TOP 100 PERCENT fchrFrmNameID, vchrBtnID, vchrBtnText, iIcon, vchrRemark, intOrder,isnull(bEnable,0) as bEnable " +
                                    "FROM dbo._FormBtnInfo " +
                                    "WHERE (fchrFrmNameID = '" + sFormInfo + "') " +
                                    "ORDER BY intOrder DESC";
                }
                else
                {
                    sSQL = "SELECT distinct _FormBtnInfo.fchrFrmNameID, vchrBtnID, vchrBtnText, _FormBtnInfo.vchrRemark, intOrder,isnull(bEnable,0) as bEnable , " +
                                "  RTRIM(LTRIM(LEFT(dbo._RoleRight.vchrRoleRight, CHARINDEX('|', dbo._RoleRight.vchrRoleRight) - 1))) AS vchrL,  " +
                                "  RTRIM(LTRIM(RIGHT(dbo._RoleRight.vchrRoleRight, LEN(dbo._RoleRight.vchrRoleRight) - CHARINDEX('|', dbo._RoleRight.vchrRoleRight))))  " +
                                "  AS vchrR " +
                                "FROM         dbo._RoleInfo INNER JOIN " +
                                "	dbo._RoleRight ON dbo._RoleInfo.vchrRoleID = dbo._RoleRight.vchrRoleID INNER JOIN " +
                                "	dbo._UserRoleInfo ON dbo._RoleInfo.vchrRoleID = dbo._UserRoleInfo.vchrRoleID AND dbo._UserRoleInfo.vchrUserID = '" + sUid + "'  " +
                                "	INNER JOIN " +
                                "	dbo._FormBtnInfo ON vchrBtnID = RTRIM(LTRIM(RIGHT(dbo._RoleRight.vchrRoleRight, LEN(dbo._RoleRight.vchrRoleRight) - CHARINDEX('|', dbo._RoleRight.vchrRoleRight)))) AND fchrFrmNameID = RTRIM(LTRIM(LEFT(dbo._RoleRight.vchrRoleRight, CHARINDEX('|', dbo._RoleRight.vchrRoleRight) - 1))) " +
                                "WHERE     (fchrFrmNameID = '" + sFormInfo + "')  " +
                                "ORDER BY intOrder DESC";
                }
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                s = Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }

        public string dtMainSetTree(string sUid, string sProForm)
        {
            string s = "";

            try
            {
                string sSQL2 = @"select count(*) from dbo._UserRoleInfo where vchrRoleID = 'administrator' and vchrUserID = '" + sUid + "'";
                string sSQL;
                if (sUid == "admin" || sUid == "system")
                {
                    sSQL = "SELECT TOP 100 PERCENT * FROM dbo._Form WHERE (1 = 1) AND (fbitNoUse = 0) AND (fbitHide = 0) and (vchrFormBel='" + sProForm + "' or vchrFormBel is null)  ORDER BY fIntOrderID";
                }
                else if (Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL2)) != 0)
                {
                    sSQL = "SELECT TOP 100 PERCENT * FROM dbo._Form WHERE (isnull(bUse,0) = 1) AND (fbitNoUse = 0) AND (fbitHide = 0) and (vchrFormBel='" + sProForm + "' or vchrFormBel is null)  ORDER BY fIntOrderID";
                }
                else
                {
                    sSQL = "SELECT DISTINCT " +
                                "      dbo._Form.fchrFrmNameID, dbo._Form.fchrFrmText, dbo._Form.fchrNameSpace,  " +
                                "	  dbo._Form.fchrFrmUpName,  " +
                                "      dbo._Form.fbitHide, dbo._Form.fbitNoUse, dbo._Form.fIntOrderID " +
                                "FROM         dbo._RoleInfo INNER JOIN " +
                                "      dbo._RoleRight ON dbo._RoleInfo.vchrRoleID = dbo._RoleRight.vchrRoleID INNER JOIN " +
                                "      dbo._UserRoleInfo ON dbo._RoleInfo.vchrRoleID = dbo._UserRoleInfo.vchrRoleID and dbo._UserRoleInfo.vchrUserID='" + sUid + "' INNER JOIN " +
                                "      dbo._Form ON 1=1 " +
                                "		 AND dbo._Form.fchrFrmNameID +'/'+dbo._Form.fchrFrmText= RTRIM(LTRIM(RIGHT(dbo._RoleRight.vchrRoleRight, LEN(dbo._RoleRight.vchrRoleRight) - CHARINDEX('|', dbo._RoleRight.vchrRoleRight)))) " +
                                "WHERE (isnull(bUse,0) = 1) AND (fbitNoUse = 0) AND (fbitHide = 0) and (vchrFormBel='" + sProForm + "' or vchrFormBel is null)  " +
                                "ORDER BY fIntOrderID ";
                }
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                s = Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }

        public string sfchrFrmNameID()
        {
            string s = "";

            try
            {
                string sSQL = "select fchrFrmNameID from dbo._Form where fchrfrmnameid not like 'frm%' order by fIntOrderID";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                s = Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }

        public string delForm(string FormCode)
        {
            string sErr = "";
            ArrayList aList = new ArrayList();
            string sSQL="";
            try
            {
                if (FormCode.StartsWith("frm"))
                {
                    sSQL = "delete dbo._FormBtnInfo where fchrFrmNameID = '" + FormCode + "'";
                    aList.Add(sSQL);
                }
                sSQL = "delete _Form where fchrFrmNameID = '" +FormCode + "' ";
                aList.Add(sSQL);
                
                if (sErr != "")
                {
                    throw new Exception(sErr);
                }
                if (aList.Count > 0)
                {
                    int iCou = clsSQLCommond.ExecSqlTran(aList);
                }
                return sErr;
            }
            catch (Exception ee)
            {
                sErr = ee.Message;
            }
            return sErr;
        }

        public string delRoleInfo(string sRoleID)
        {
            string sErr = "";
            ArrayList aList = new ArrayList();
            string sSQL = "";
            try
            {
                
                sSQL = "select * from _UserRoleInfo where vchrRoleID = '" + sRoleID + "'";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows.Count > 0)
                {
                    throw new Exception("角色已有账号使用");
                }

                sSQL = "delete _RoleRight where vchrRoleID = '" + sRoleID + "'";
                aList.Add(sSQL);

                sSQL = "delete _RoleInfo where vchrRoleID = '" + sRoleID + "'";
                aList.Add(sSQL);

                if (sErr != "")
                {
                    throw new Exception(sErr);
                }
                if (aList.Count > 0)
                {
                    int iCou = clsSQLCommond.ExecSqlTran(aList);
                }
                return sErr;
            }
            catch (Exception ee)
            {
                sErr = ee.Message;
            }
            return sErr;
        }

        public string saveForm(DataTable dtGrid, string FormCode, string FormName, string NameSpace, string FrmUpName, string OrderID, int iHide, int iNoUse, int iSystem, int iUse)
        {
            string sErr = "";
            ArrayList aList = new ArrayList();
            string sSQL = "";
            try
            {
                sSQL = "if exists(select * from dbo._Form where fchrFrmNameID = '" + FormCode + "' and fchrFrmText = '" + FormName + "') " +
                        " update _Form set  fchrFrmText = '" + FormName + "', fchrNameSpace = '" + NameSpace + "', fchrFrmUpName = '" + FrmUpName + "', " +
                                "fbitHide = " + iHide + ", fbitNoUse = " + iNoUse + ", fIntOrderID = " + OrderID + ", " +
                                "bSystem = " + iSystem + ", bUse = " + iUse + " " +
                        " where fchrFrmNameID = '" + FormCode + "' and fchrFrmText = '" + FormName + "'; " +
                   "else " +
                   " insert into _Form( fchrFrmNameID, fchrFrmText, fchrNameSpace, fchrFrmUpName, fbitHide, fbitNoUse, fIntOrderID,  bSystem, bUse) values " +
                                      "('" + FormCode + "','" + FormName + "','" + NameSpace + "','" + FrmUpName + "', " +
                                      "" + iHide + "," + iNoUse + "," + OrderID + ", " + iSystem + "," + iUse + ")";
                aList.Add(sSQL);

                if (FormCode.ToLower().StartsWith("frm"))
                {
                    sSQL = "select * from _FormBtnInfo where 1=-1";
                    DataTable dtBtn = clsSQLCommond.ExecQuery(sSQL);

                    sSQL = "delete _FormBtnInfo where fchrFrmNameID = '" + FormCode + "/" + FormName + "' ";
                    aList.Add(sSQL);

                    for (int i = 0; i < dtGrid.Rows.Count; i++)
                    {
                        if (dtGrid.Rows[i]["bChoose"].ToString().Trim() == "√")
                        {
                            DataRow dr = dtBtn.NewRow();
                            dr["fchrFrmNameID"] = FormCode + "/" + FormName;
                            dr["vchrBtnID"] = dtGrid.Rows[i]["btnCode"].ToString().Trim();
                            dr["vchrBtnText"] = dtGrid.Rows[i]["FormText"].ToString().Trim();
                            dr["intOrder"] = dtGrid.Rows[i]["FormOrder"].ToString().Trim();
                            dr["bEnable"] = dtGrid.Rows[i]["FormEnable"].ToString().Trim();
                            dtBtn.Rows.Add(dr);
                        }
                    }
                    for (int i = 0; i < dtBtn.Rows.Count; i++)
                    {
                        sSQL = clsGetSQL.GetInsertSQL(ClsBaseDataInfo.sDataBaseName, "_FormBtnInfo", dtBtn, i);
                        aList.Add(sSQL);
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
                return sErr;
            }
            catch (Exception ee)
            {
                sErr = ee.Message;
            }
            return sErr;
        }

        public string dtTableColInfo(string DataBase, string Table)
        {
            string s = "";
            string sSQL = "";
            try
            {
                sSQL = "select  t.COLUMN_Text,t.iID,a.*,a.DATA_Type as DATA_Type2,0 as bUsed ,2 as DataType,isnull(t.collation_add,0) as collation_add,case a.COLUMN_NAME when isnull(t.COLUMN_NAME,0) then 0 else 1 end  as newAdd,isnull(t.bKey ,0) as bKey " +
                                "from " + DataBase + ".INFORMATION_SCHEMA.COLUMNS a left join dbo._TableColInfo t on a.TABLE_CATALOG = t.TABLE_CATALOG and a.TABLE_NAME=t.TABLE_NAME and a.COLUMN_NAME = t.COLUMN_NAME " +
                                "where a.table_name = '" + Table + "' " +
                                "order by a.table_name,a.ordinal_position";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                s = Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }

        public string dtSysObjects(string DataBase,string Flag)
        {
            string s = "";
            string sSQL = "";
            try
            {
                if (Flag == "1")
                {
                    sSQL = "Select Name FROM " + DataBase + "..SysObjects Where XType='U' orDER BY Name  ";
                }
                else if(Flag=="2")
                {
                    sSQL = "Select Name FROM Master..SysDatabases order by Name ";
                }
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                s = Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }

        public string saveTableColInfo(DataTable dtGrid, string DataBase, string Table, int iSystem)
        {
            string sErr = "";
            ArrayList aList = new ArrayList();
            string sSQL = "";
            try
            {
                sSQL = "delete _TableColInfo where TABLE_CATALOG = '" + DataBase + "' and TABLE_NAME = '" + Table + "'";
                aList.Add(sSQL);

                for (int i = 0; i < dtGrid.Rows.Count; i++)
                {
                    int iKey = 0;
                    if (Convert.ToBoolean(dtGrid.Rows[i]["bKey"]))
                        iKey = 1;

                    sSQL = "insert into dbo._TableColInfo(bSystem,TABLE_CATALOG,TABLE_SCHEMA,TABLE_NAME,COLUMN_NAME,COLUMN_Text,DATA_TYPE,COLLATION_ADD,bKey) " +
                            "values(" + iSystem + ",'" + dtGrid.Rows[i]["TABLE_CATALOG"] + "','dbo','" + dtGrid.Rows[i]["TABLE_NAME"] + "','" + dtGrid.Rows[i]["COLUMN_NAME"] + "','" + dtGrid.Rows[i]["COLUMN_Text"] + "'," + dtGrid.Rows[i]["DataType"] + "," + dtGrid.Rows[i]["collation_add"] + "," + iKey + ")";

                    aList.Add(sSQL);
                }


                if (sErr != "")
                {
                    throw new Exception(sErr);
                }
                if (aList.Count > 0)
                {
                    int iCou = clsSQLCommond.ExecSqlTran(aList);
                }
                return sErr;
            }
            catch (Exception ee)
            {
                sErr = ee.Message;
            }
            return sErr;
        }

    }
}
