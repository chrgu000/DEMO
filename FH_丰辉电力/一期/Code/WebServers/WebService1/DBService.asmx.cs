using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.IO;
using System.Xml;
using ClsU8;
using ClsBaseClass;

namespace TH.DBWebService
{
    
    /// <summary>
    /// 
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class DBWebService : System.Web.Services.WebService
    {
        ClsDES ClsDES = ClsDES.Instance();
        #region 自动更新文件
        [WebMethod]
        public string dtFileV()
        {
            string sSQL = @"
SELECT 
      [文件名称]
      ,[路径]
      ,[版本]
      ,[更新日期]
      ,[创建时间]
  FROM [XWSystemDB_FH].[dbo].[文件版本信息]
  order by iID
";
            ClsBaseClass.ClsDataBase clsSQL = ClsBaseClass.ClsDataBaseFactory.Instance();
            DataTable dt = clsSQL.ExecQuery(sSQL);
            return Cls序列化.SerializeDataTableXml(dt);
        }

        [WebMethod]
        public string dtDownFileVer(string sFileName)
        {
            string sSQL = @"
SELECT 
      [文件名称]
      ,[文件]
      ,[路径]
      ,[版本]
      ,[更新日期]
      ,[创建时间]
  FROM [XWSystemDB_FH].[dbo].[文件版本信息]
   where  [文件名称] = '111111'
  order by iID
";
            sSQL = sSQL.Replace("111111", sFileName);
            ClsBaseClass.ClsDataBase clsSQL = ClsBaseClass.ClsDataBaseFactory.Instance();
            DataTable dt = clsSQL.ExecQuery(sSQL);
            return Cls序列化.SerializeDataTableXml(dt);
        }
        #endregion

        [WebMethod]
        public DateTime dtm当前服务器时间()
        {
            ClsSystem cls = new ClsSystem();
            return cls.dtm当前服务器时间();
        }


        [WebMethod]
        public string UploadFile(string iID, string fileName, byte[] fileContent)
        {
            UploadDownLoad cls = new UploadDownLoad();
            return ClsDES.Encrypt(cls.UploadFile(ClsDES.Decrypt(iID), ClsDES.Decrypt(fileName), fileContent));
        }

        [WebMethod]
        public byte[] DownloadFile(string iID, string fileName)
        {
            UploadDownLoad cls = new UploadDownLoad();
            return cls.DownloadFile(ClsDES.Decrypt(iID), ClsDES.Decrypt(fileName));
        }

        #region _LookUpType
        [WebMethod]
        public string dtLookUpType()
        {
            ClsLookUpType cls = new ClsLookUpType();
            return ClsDES.Encrypt(cls.dt());
        }

        [WebMethod]
        public string saveLookUpType(string sdt)
        {
            ClsLookUpType cls = new ClsLookUpType();
            return ClsDES.Encrypt(cls.save(Cls序列化.DeserializeDataTable(ClsDES.Decrypt(sdt))));
        }

        [WebMethod]
        public string delLookUpType(string iID)
        {
            ClsLookUpType cls = new ClsLookUpType();
            return ClsDES.Encrypt(cls.del(ClsDES.Decrypt(iID)));
        }

        [WebMethod]
        public bool bClosedLookUpType(string cECode)
        {
            ClsLookUpType cls = new ClsLookUpType();
            return cls.bClosed(ClsDES.Decrypt(cECode));
        }
        #endregion

        #region _LookUpDate
        [WebMethod]
        public string dtLookUpDate(string iType)
        {
            ClsLookUpDate cls = new ClsLookUpDate();
            return ClsDES.Encrypt(cls.dt(ClsDES.Decrypt(iType)));
        }

        [WebMethod]
        public string saveLookUpDate(string sdt, string iType)
        {
            ClsLookUpDate cls = new ClsLookUpDate();
            return ClsDES.Encrypt(cls.save(Cls序列化.DeserializeDataTable(ClsDES.Decrypt(sdt)), ClsDES.Decrypt(iType)));
        }

        [WebMethod]
        public string delLookUpDate(string iID, string iType)
        {
            ClsLookUpDate cls = new ClsLookUpDate();
            return ClsDES.Encrypt(cls.del(ClsDES.Decrypt(iID), ClsDES.Decrypt(iType)));
        }

        [WebMethod]
        public bool bClosedLookUpDate(string cECode, string iType)
        {
            ClsLookUpDate cls = new ClsLookUpDate();
            return cls.bClosed(ClsDES.Decrypt(cECode));
        }
        #endregion

        #region System
        [WebMethod]
        public string dtUserInfo(string vchrUid, string vchrPwd)
        {
            ClsSystem cls = new ClsSystem();
            return ClsDES.Encrypt(cls.dtUserInfo(ClsDES.Decrypt(vchrUid), ClsDES.Decrypt(vchrPwd)));
        }

        [WebMethod]
        public string dtGetAccInfo()
        {
            ClsSystem cls = new ClsSystem();
            return ClsDES.Encrypt(cls.dtGetAccInfo());
        }

        [WebMethod]
        public string svchrName(string vchrUid)
        {
            ClsSystem cls = new ClsSystem();
            return ClsDES.Encrypt(cls.svchrName(ClsDES.Decrypt(vchrUid)));
        }

        [WebMethod]
        public string sbU8Improt(string sUFDataBaseName)
        {
            ClsSystem cls = new ClsSystem();
            return ClsDES.Encrypt(cls.sbU8Improt(ClsDES.Decrypt(sUFDataBaseName)));
        }

        [WebMethod]
        public string saveDefine1(string vchrUid)
        {
            ClsSystem cls = new ClsSystem();
            return ClsDES.Encrypt(cls.saveDefine1(ClsDES.Decrypt(vchrUid)));
        }


        [WebMethod]
        public string saveDefine1all(string vchrUid, string sUserName, string Name, string Text, string ClickedItemName, string ClickedItemText)
        {
            ClsSystem cls = new ClsSystem();
            return ClsDES.Encrypt(cls.saveDefine1all(ClsDES.Decrypt(vchrUid), ClsDES.Decrypt(sUserName), ClsDES.Decrypt(Name), ClsDES.Decrypt(Text), ClsDES.Decrypt(ClickedItemName), ClsDES.Decrypt(ClickedItemText)));
        }

        [WebMethod]
        public string saveUserInfoPwd(string vchrUid, string vchrPwd)
        {
            ClsSystem cls = new ClsSystem();
            return ClsDES.Encrypt(cls.saveUserInfoPwd(ClsDES.Decrypt(vchrUid), ClsDES.Decrypt(vchrPwd)));
        }

        [WebMethod]
        public int sUserRoleInfo(string vchrRoleID, string sUid)
        {
            ClsSystem cls = new ClsSystem();
            return cls.sUserRoleInfo(ClsDES.Decrypt(vchrRoleID), ClsDES.Decrypt(sUid));
        }

        [WebMethod]
        public int sRoleRight(string sUid, string sInfo)
        {
            ClsSystem cls = new ClsSystem();
            return cls.sRoleRight(ClsDES.Decrypt(sUid), ClsDES.Decrypt(sInfo));
        }

        [WebMethod]
        public string svchrRoleID(string sUid)
        {
            ClsSystem cls = new ClsSystem();
            return ClsDES.Encrypt(cls.svchrRoleID(ClsDES.Decrypt(sUid)));
        }

        [WebMethod]
        public string sDeptID(string sUid)
        {
            ClsSystem cls = new ClsSystem();
            return ClsDES.Encrypt(cls.sDeptID(ClsDES.Decrypt(sUid)));
        }

        [WebMethod]
        public string dtForm(string fchrFrmNameID, string fchrFrmText,string Flag)
        {
            ClsSystem cls = new ClsSystem();
            return ClsDES.Encrypt(cls.dtForm(ClsDES.Decrypt(fchrFrmNameID), ClsDES.Decrypt(fchrFrmText), ClsDES.Decrypt(Flag)));
        }

        [WebMethod]
        public string dtFormBtnInfo(string fchrFrmNameID, string fchrFrmText)
        {
            ClsSystem cls = new ClsSystem();
            return ClsDES.Encrypt(cls.dtFormBtnInfo(ClsDES.Decrypt(fchrFrmNameID), ClsDES.Decrypt(fchrFrmText)));
        }

        [WebMethod]
        public string dtBtnBaseInfo()
        {
            ClsSystem cls = new ClsSystem();
            return ClsDES.Encrypt(cls.dtBtnBaseInfo());
        }

        [WebMethod]
        public string dtCreateBtn(string sUid, string sFormInfo)
        {
            ClsSystem cls = new ClsSystem();
            return ClsDES.Encrypt(cls.dtCreateBtn(ClsDES.Decrypt(sUid), ClsDES.Decrypt(sFormInfo)));
        }

        [WebMethod]
        public string dtMainSetTree(string sUid, string sProForm)
        {
            ClsSystem cls = new ClsSystem();
            return ClsDES.Encrypt(cls.dtMainSetTree(ClsDES.Decrypt(sUid), ClsDES.Decrypt(sProForm)));
        }

        [WebMethod]
        public string sfchrFrmNameID()
        {
            ClsSystem cls = new ClsSystem();
            return ClsDES.Encrypt(cls.sfchrFrmNameID());
        }

        [WebMethod]
        public string delForm(string FormCode)
        {
            ClsSystem cls = new ClsSystem();
            return ClsDES.Encrypt(cls.delForm(ClsDES.Decrypt(FormCode)));
        }

        [WebMethod]
        public string delRoleInfo(string sRoleID)
        {
            ClsSystem cls = new ClsSystem();
            return ClsDES.Encrypt(cls.delRoleInfo(ClsDES.Decrypt(sRoleID)));
        }

        [WebMethod]
        public string saveForm(string sdt, string FormCode, string FormName, string NameSpace, string FrmUpName, string OrderID, int iHide, int iNoUse, int iSystem, int iUse)
        {
            ClsSystem cls = new ClsSystem();
            return ClsDES.Encrypt(cls.saveForm(Cls序列化.DeserializeDataTable(ClsDES.Decrypt(sdt)), ClsDES.Decrypt(FormCode), ClsDES.Decrypt(FormName), ClsDES.Decrypt(NameSpace), ClsDES.Decrypt(FrmUpName), ClsDES.Decrypt(OrderID), 
                iHide, iNoUse, iSystem, iUse));
        }

        [WebMethod]
        public string dtTableColInfo(string DataBase, string Table)
        {
            ClsSystem cls = new ClsSystem();
            return ClsDES.Encrypt(cls.dtTableColInfo(ClsDES.Decrypt(DataBase), ClsDES.Decrypt(Table)));
        }

        [WebMethod]
        public string dtSysObjects(string DataBase, string Flag)
        {
            ClsSystem cls = new ClsSystem();
            return ClsDES.Encrypt(cls.dtSysObjects(ClsDES.Decrypt(DataBase), ClsDES.Decrypt(Flag)));
        }

        [WebMethod]
        public string saveTableColInfo(string sdt, string DataBase, string Table, int iSystem)
        {
            ClsSystem cls = new ClsSystem();
            return ClsDES.Encrypt(cls.saveTableColInfo(Cls序列化.DeserializeDataTable(ClsDES.Decrypt(sdt)), ClsDES.Decrypt(DataBase), ClsDES.Decrypt(Table), iSystem));
        }
        #endregion

        #region ClsBuckUpDataBase
        [WebMethod]
        public bool ClsBuckUpDataBaseBuckUpDataBase(string sPathInfo)
        {
            ClsU8.Query.ClsBuckUpDataBase clsQuery = new ClsU8.Query.ClsBuckUpDataBase();
            return clsQuery.BuckUpDataBase(ClsDES.Decrypt(sPathInfo));
        }

        [WebMethod]
        public DateTime ClsBuckUpDataBaseGetSerTime()
        {
            ClsU8.Query.ClsBuckUpDataBase clsQuery = new ClsU8.Query.ClsBuckUpDataBase();
            return clsQuery.GetSerTime();
        }

        [WebMethod]
        public string ClsBuckUpDataBaseGetSerHostName()
        {
            ClsU8.Query.ClsBuckUpDataBase clsQuery = new ClsU8.Query.ClsBuckUpDataBase();
            return ClsDES.Encrypt(Cls序列化.SerializeDataTableXml(clsQuery.GetSerHostName()));
        }
        #endregion

        #region ClsRoleInfoQuery
        [WebMethod]
        public string ClsRoleInfoQueryGetAllDt()
        {
            ClsU8.Query.ClsRoleInfoQuery clsQuery = new ClsU8.Query.ClsRoleInfoQuery();
            return ClsDES.Encrypt(Cls序列化.SerializeDataTableXml(clsQuery.GetAllDt()));
        }

        [WebMethod]
        public bool ClsRoleInfoQueryChkClosed(string sUid)
        {
            ClsU8.Query.ClsRoleInfoQuery clsQuery = new ClsU8.Query.ClsRoleInfoQuery();
            return clsQuery.ChkClosed(ClsDES.Decrypt(sUid));
        }
        #endregion

        #region ClsRoleEditQuery
        [WebMethod]
        public string ClsRoleEditQueryGetAllDt()
        {
            ClsU8.Query.ClsRoleEditQuery clsQuery = new ClsU8.Query.ClsRoleEditQuery();
            return ClsDES.Encrypt(Cls序列化.SerializeDataTableXml(clsQuery.GetAllDt()));
        }

        [WebMethod]
        public string ClsRoleEditQueryGetUserRole(string sUid)
        {
            ClsU8.Query.ClsRoleEditQuery clsQuery = new ClsU8.Query.ClsRoleEditQuery();
            return ClsDES.Encrypt(Cls序列化.SerializeDataTableXml(clsQuery.GetUserRole(ClsDES.Decrypt(sUid))));
        }

        [WebMethod]
        public bool ClsRoleEditQueryChkRoleID(string sUid)
        {
            ClsU8.Query.ClsRoleEditQuery clsQuery = new ClsU8.Query.ClsRoleEditQuery();
            return clsQuery.ChkRoleID(ClsDES.Decrypt(sUid));
        }
        #endregion

        #region ClsRoleRight
        [WebMethod]
        public string ClsRoleRightGetTreeInfo(string sPK)
        {
            ClsU8.Query.ClsRoleRight clsQuery = new ClsU8.Query.ClsRoleRight();
            return ClsDES.Encrypt(Cls序列化.SerializeDataTableXml(clsQuery.GetTreeInfo(ClsDES.Decrypt(sPK))));
        }
        #endregion

        #region ClsUserEditQuery
        [WebMethod]
        public string ClsUserEditQueryGetAllDt()
        {
            ClsU8.Query.ClsUserEditQuery clsQuery = new ClsU8.Query.ClsUserEditQuery();
            return ClsDES.Encrypt(Cls序列化.SerializeDataTableXml(clsQuery.GetAllDt()));
        }

        [WebMethod]
        public string ClsUserEditQueryGetUserRole(string sUid)
        {
            ClsU8.Query.ClsUserEditQuery clsQuery = new ClsU8.Query.ClsUserEditQuery();
            return ClsDES.Encrypt(Cls序列化.SerializeDataTableXml(clsQuery.GetUserRole(ClsDES.Decrypt(sUid))));
        }

        [WebMethod]
        public bool ClsUserEditQueryChkUID(string sUid)
        {
            ClsU8.Query.ClsUserEditQuery clsQuery = new ClsU8.Query.ClsUserEditQuery();
            return clsQuery.ChkUID(ClsDES.Decrypt(sUid));
        }
        #endregion

        #region ClsUserInfoQuery
        [WebMethod]
        public string ClsUserInfoQueryGetAllDt()
        {
            ClsU8.Query.ClsUserInfoQuery clsQuery = new ClsU8.Query.ClsUserInfoQuery();
            return ClsDES.Encrypt(Cls序列化.SerializeDataTableXml(clsQuery.GetAllDt()));
        }
        #endregion

        #region ClsRoleEditBll
        [WebMethod]
        public string ClsRoleEditBllAdd(string vchrRoleID, string vchrRoleText, string vchrRemark, bool bClosed, DateTime dtmCreate, string sdt)
        {
            ClsU8.Bll.ClsRoleEditBll clsBll = new ClsU8.Bll.ClsRoleEditBll();
            return ClsDES.Encrypt(clsBll.Add(ClsDES.Decrypt(vchrRoleID), ClsDES.Decrypt(vchrRoleText), ClsDES.Decrypt(vchrRemark), bClosed, dtmCreate, Cls序列化.DeserializeDataTable(ClsDES.Decrypt(sdt))));
        }

        [WebMethod]
        public string ClsRoleEditBllUpdate(string vchrRoleID, string vchrRoleText, string vchrRemark, bool bClosed, DateTime dtmCreate, string sdt)
        {
            ClsU8.Bll.ClsRoleEditBll clsBll = new ClsU8.Bll.ClsRoleEditBll();
            return ClsDES.Encrypt(clsBll.Update(ClsDES.Decrypt(vchrRoleID), ClsDES.Decrypt(vchrRoleText), ClsDES.Decrypt(vchrRemark), bClosed, dtmCreate, Cls序列化.DeserializeDataTable(ClsDES.Decrypt(sdt))));
        }
        #endregion

        #region ClsRoleInfoBll
        [WebMethod]
        public string ClsRoleInfoBllDelete(string sRoleid)
        {
            ClsU8.Bll.ClsRoleInfoBll clsBll = new ClsU8.Bll.ClsRoleInfoBll();
            return ClsDES.Encrypt(clsBll.Close(ClsDES.Decrypt(sRoleid)));
        }

        [WebMethod]
        public string ClsRoleInfoBllUnDelete(string sRoleid)
        {
            ClsU8.Bll.ClsRoleInfoBll clsBll = new ClsU8.Bll.ClsRoleInfoBll();
            return ClsDES.Encrypt(clsBll.UnClose(ClsDES.Decrypt(sRoleid)));
        }
        #endregion

        #region ClsRoleRightBll
        [WebMethod]
        public string ClsRoleRightBllAdd(string sPK, string dt)
        {
            ClsU8.Bll.ClsRoleRightBll clsBll = new ClsU8.Bll.ClsRoleRightBll();
            return ClsDES.Encrypt(clsBll.Add(ClsDES.Decrypt(sPK), Cls序列化.DeserializeDataTable(ClsDES.Decrypt(dt))));
        }
        #endregion

        #region ClsUserEditBll
        [WebMethod]
        public string ClsUserEditBllAdd(string vchrUid, string vchrPwd, DateTime dtmCreate, DateTime dtmClose, string vchrRemark, string vchrName, string dt)
        {
            ClsU8.Bll.ClsUserEditBll clsBll = new ClsU8.Bll.ClsUserEditBll();
            return ClsDES.Encrypt(clsBll.Add(ClsDES.Decrypt(vchrUid), ClsDES.Decrypt(vchrPwd), dtmCreate, dtmClose, ClsDES.Decrypt(vchrRemark), ClsDES.Decrypt(vchrName), Cls序列化.DeserializeDataTable(ClsDES.Decrypt(dt))));
        }

        [WebMethod]
        public string ClsUserEditBllUpdate(string vchrUid, string vchrPwd, DateTime dtmCreate, DateTime dtmClose, string vchrRemark, string vchrName, string dt)
        {
            ClsU8.Bll.ClsUserEditBll clsBll = new ClsU8.Bll.ClsUserEditBll();
            return ClsDES.Encrypt(clsBll.Update(ClsDES.Decrypt(vchrUid), ClsDES.Decrypt(vchrPwd), dtmCreate, dtmClose, ClsDES.Decrypt(vchrRemark), ClsDES.Decrypt(vchrName),Cls序列化.DeserializeDataTable(ClsDES.Decrypt(dt))));
        }
        #endregion

        #region ClsUserInfoBll
        [WebMethod]
        public string ClsUserInfoBllDelete(string sUserid)
        {
            ClsU8.Bll.ClsUserInfoBll clsBll = new ClsU8.Bll.ClsUserInfoBll();
            return ClsDES.Encrypt(clsBll.Delete(ClsDES.Decrypt(sUserid)));
        }
        #endregion


        #region LookUp
        [WebMethod]
        public string LookUpLookUpType()
        {
            ClsLookUp cls = new ClsLookUp();
            return ClsDES.Encrypt(cls.LookUpLookUpType());
        }

        [WebMethod]
        public string LookUpLoopUpData(string iID)
        {
            ClsLookUp cls = new ClsLookUp();
            return ClsDES.Encrypt(cls.LookUpLoopUpData(ClsDES.Decrypt(iID)));
        }

        [WebMethod]
        public string LookUpDepartment()
        {
            ClsLookUp cls = new ClsLookUp();
            return ClsDES.Encrypt(cls.LookUpDepartment());
        }

        [WebMethod]
        public string LookUpComputationUnit()
        {
            ClsLookUp cls = new ClsLookUp();
            return ClsDES.Encrypt(cls.LookUpComputationUnit());
        }

        [WebMethod]
        public string LookUpInventory()
        {
            ClsLookUp cls = new ClsLookUp();
            return ClsDES.Encrypt(cls.LookUpInventory());
        }

        [WebMethod]
        public string LookUpPerson()
        {
            ClsLookUp cls = new ClsLookUp();
            return ClsDES.Encrypt(cls.LookUpPerson());
        }

        [WebMethod]
        public string LookUpDistrictClass()
        {
            ClsLookUp cls = new ClsLookUp();
            return ClsDES.Encrypt(cls.LookUpDistrictClass());
        }

        [WebMethod]
        public string LookUpEngineering()
        {
            ClsLookUp cls = new ClsLookUp();
            return ClsDES.Encrypt(cls.LookUpEngineering());
        }

        [WebMethod]
        public string LookUpQuality()
        {
            ClsLookUp cls = new ClsLookUp();
            return ClsDES.Encrypt(cls.LookUpQuality());
        }

        [WebMethod]
        public string LookUpSecurity()
        {
            ClsLookUp cls = new ClsLookUp();
            return ClsDES.Encrypt(cls.LookUpSecurity());
        }

        [WebMethod]
        public string LookUpRdRecord()
        {
            ClsLookUp cls = new ClsLookUp();
            return ClsDES.Encrypt(cls.LookUpRdRecord());
        }

        [WebMethod]
        public string LookUpUserInfo()
        {
            ClsLookUp cls = new ClsLookUp();
            return ClsDES.Encrypt(cls.LookUpUserInfo());
        }

        [WebMethod]
        public string LookUpProject()
        {
            ClsLookUp cls = new ClsLookUp();
            return ClsDES.Encrypt(cls.LookUpProject());
        }
        #endregion

        #region Show
        [WebMethod]
        public string ShowlookUpDate(string code, string iType)
        {
            ClsShow cls = new ClsShow();
            return ClsDES.Encrypt(cls.ShowlookUpDate(ClsDES.Decrypt(code), ClsDES.Decrypt(iType)));
        }

        [WebMethod]
        public string ShowInventory(string cInvCode)
        {
            ClsShow cls = new ClsShow();
            return ClsDES.Encrypt(cls.ShowInventory(ClsDES.Decrypt(cInvCode)));
        }

        [WebMethod]
        public string ShowPerson(string PersonCode)
        {
            ClsShow cls = new ClsShow();
            return ClsDES.Encrypt(cls.ShowPerson(ClsDES.Decrypt(PersonCode)));
        }

        [WebMethod]
        public string ShowDepartment(string cDepCode)
        {
            ClsShow cls = new ClsShow();
            return ClsDES.Encrypt(cls.ShowDepartment(ClsDES.Decrypt(cDepCode)));
        }


        [WebMethod]
        public string ShowEngineering(string cECode)
        {
            ClsShow cls = new ClsShow();
            return ClsDES.Encrypt(cls.ShowEngineering(ClsDES.Decrypt(cECode)));
        }

        [WebMethod]
        public string ShowQuality(string cQCode)
        {
            ClsShow cls = new ClsShow();
            return ClsDES.Encrypt(cls.ShowQuality(ClsDES.Decrypt(cQCode)));
        }

        [WebMethod]
        public string ShowSecurity(string cSCode)
        {
            ClsShow cls = new ClsShow();
            return ClsDES.Encrypt(cls.ShowSecurity(ClsDES.Decrypt(cSCode)));
        }

        [WebMethod]
        public string ShowDistrictClass(string cDCCode)
        {
            ClsShow cls = new ClsShow();
            return ClsDES.Encrypt(cls.ShowDistrictClass(ClsDES.Decrypt(cDCCode)));
        }

        [WebMethod]
        public string ShowProject(string cCode)
        {
            ClsShow cls = new ClsShow();
            return ClsDES.Encrypt(cls.ShowProject(ClsDES.Decrypt(cCode)));
        }
        #endregion

       

        #region Security
        [WebMethod]
        public string dtSecurity()
        {
            ClsSecurity cls = new ClsSecurity();
            return ClsDES.Encrypt(cls.dt());
        }

        [WebMethod]
        public string saveSecurity(string sdt)
        {
            ClsSecurity cls = new ClsSecurity();
            return ClsDES.Encrypt(cls.save(Cls序列化.DeserializeDataTable(ClsDES.Decrypt(sdt))));
        }

        [WebMethod]
        public string delSecurity(string cSCode)
        {
            ClsSecurity cls = new ClsSecurity();
            return ClsDES.Encrypt(cls.del(ClsDES.Decrypt(cSCode)));
        }

        [WebMethod]
        public bool bClosedSecurity(string cSCode)
        {
            ClsSecurity cls = new ClsSecurity();
            return cls.bClosed(ClsDES.Decrypt(cSCode));
        }
        #endregion

        #region Quality
        [WebMethod]
        public string dtQuality()
        {
            ClsQuality cls = new ClsQuality();
            return ClsDES.Encrypt(cls.dt());
        }

        [WebMethod]
        public string saveQuality(string sdt)
        {
            ClsQuality cls = new ClsQuality();
            return ClsDES.Encrypt(cls.save(Cls序列化.DeserializeDataTable(ClsDES.Decrypt(sdt))));
        }

        [WebMethod]
        public string delQuality(string cQCode)
        {
            ClsQuality cls = new ClsQuality();
            return ClsDES.Encrypt(cls.del(ClsDES.Decrypt(cQCode)));
        }

        [WebMethod]
        public bool bClosedQuality(string cQCode)
        {
            ClsQuality cls = new ClsQuality();
            return cls.bClosed(ClsDES.Decrypt(cQCode));
        }
        #endregion

        #region Engineering
        [WebMethod]
        public string dtEngineering()
        {
            ClsEngineering cls = new ClsEngineering();
            return ClsDES.Encrypt(cls.dt());
        }

        [WebMethod]
        public string saveEngineering(string sdt)
        {
            ClsEngineering cls = new ClsEngineering();
            return ClsDES.Encrypt(cls.save(Cls序列化.DeserializeDataTable(ClsDES.Decrypt(sdt))));
        }

        [WebMethod]
        public string delEngineering(string scECode)
        {
            ClsEngineering cls = new ClsEngineering();
            return ClsDES.Encrypt(cls.del(ClsDES.Decrypt(scECode)));
        }

        [WebMethod]
        public bool bClosedEngineering(string cECode)
        {
            ClsEngineering cls = new ClsEngineering();
            return cls.bClosed(ClsDES.Decrypt(cECode));
        }
        #endregion



        #region ComputationUnit
        [WebMethod]
        public string dtComputationUnit()
        {
            ClsComputationUnit cls = new ClsComputationUnit();
            return ClsDES.Encrypt(cls.dt());
        }

        [WebMethod]
        public string saveComputationUnit(string sdt)
        {
            ClsComputationUnit cls = new ClsComputationUnit();
            return ClsDES.Encrypt(cls.save(Cls序列化.DeserializeDataTable(ClsDES.Decrypt(sdt))));
        }

        [WebMethod]
        public string delComputationUnit(string cComunitCode)
        {
            ClsComputationUnit cls = new ClsComputationUnit();
            return ClsDES.Encrypt(cls.del(ClsDES.Decrypt(cComunitCode)));
        }
        #endregion

        #region Department
        [WebMethod]
        public string dtDepartment()
        {
            ClsDepartment cls = new ClsDepartment();
            return ClsDES.Encrypt(cls.dt());
        }

        [WebMethod]
        public string saveDepartment(string sdt)
        {
            ClsDepartment cls = new ClsDepartment();
            return ClsDES.Encrypt(cls.save(Cls序列化.DeserializeDataTable(ClsDES.Decrypt(sdt))));
        }

        [WebMethod]
        public string delDepartment(string sDel)
        {
            ClsDepartment cls = new ClsDepartment();
            return ClsDES.Encrypt(cls.del(ClsDES.Decrypt(sDel)));
        }
        #endregion

        #region DistrictClass
        [WebMethod]
        public string dtDistrictClass()
        {
            ClsDistrictClass cls = new ClsDistrictClass();
            return ClsDES.Encrypt(cls.dt());
        }

        [WebMethod]
        public string saveDistrictClass(string sdt)
        {
            ClsDistrictClass cls = new ClsDistrictClass();
            return ClsDES.Encrypt(cls.save(Cls序列化.DeserializeDataTable(ClsDES.Decrypt(sdt))));
        }

        [WebMethod]
        public string delDistrictClass(string sPersonCode)
        {
            ClsDistrictClass cls = new ClsDistrictClass();
            return ClsDES.Encrypt(cls.del(ClsDES.Decrypt(sPersonCode)));
        }
        #endregion

        #region Inventory
        [WebMethod]
        public string dtInventory()
        {
            ClsInventory cls = new ClsInventory();
            return ClsDES.Encrypt(cls.dt());
        }

        [WebMethod]
        public string saveInventory(string sdt)
        {
            ClsInventory cls = new ClsInventory();
            return ClsDES.Encrypt(cls.save(Cls序列化.DeserializeDataTable(ClsDES.Decrypt(sdt))));
        }

        [WebMethod]
        public string delInventory(string cInvCode)
        {
            ClsInventory cls = new ClsInventory();
            return ClsDES.Encrypt(cls.del(ClsDES.Decrypt(cInvCode)));
        }

        [WebMethod]
        public bool bClosedInventory(string cInvCode)
        {
            ClsInventory cls = new ClsInventory();
            return cls.bClosed(ClsDES.Decrypt(cInvCode));
        }
        #endregion

        #region Person
        [WebMethod]
        public string dtPerson()
        {
            ClsPerson cls = new ClsPerson();
            return ClsDES.Encrypt(cls.dt());
        }

        [WebMethod]
        public string savePerson(string sdt)
        {
            ClsPerson cls = new ClsPerson();
            return ClsDES.Encrypt(cls.save(Cls序列化.DeserializeDataTable(ClsDES.Decrypt(sdt))));
        }

        [WebMethod]
        public string delPerson(string sPerCode)
        {
            ClsPerson cls = new ClsPerson();
            return ClsDES.Encrypt(cls.del(ClsDES.Decrypt(sPerCode)));
        }

        [WebMethod]
        public bool bClosedPerson(string PersonCode)
        {
            ClsPerson cls = new ClsPerson();
            return cls.bClosed(ClsDES.Decrypt(PersonCode));
        }
        #endregion

        #region Project
        [WebMethod]
        public string dtListProject(string sWhere, string cPCCode)
        {
            ClsProject cls = new ClsProject();
            return ClsDES.Encrypt(cls.dtList(ClsDES.Decrypt(sWhere), ClsDES.Decrypt(cPCCode)));
        }

        [WebMethod]
        public string dtProject(int type, string iID)
        {
            ClsProject cls = new ClsProject();
            return ClsDES.Encrypt(cls.dt(type, ClsDES.Decrypt(iID)));
        }

        [WebMethod]
        public string dtnewProject(int type)
        {
            ClsProject cls = new ClsProject();
            return ClsDES.Encrypt(cls.dtnew(type));
        }

        [WebMethod]
        public string siIDProject(int type, string iID)
        {
            ClsProject cls = new ClsProject();
            return ClsDES.Encrypt(cls.siID(type, ClsDES.Decrypt(iID)));
        }

        [WebMethod]
        public string saveProject(string uid, string dtHead, string dtGridRecord, string dtGridQuality, string dtGridSecurity, string dtGridAtt
            , string delRecord, string delQuality, string delSecurity, string delAtt)
        {
            ClsProject cls = new ClsProject();
            return ClsDES.Encrypt(cls.save(ClsDES.Decrypt(uid), Cls序列化.DeserializeDataTable(ClsDES.Decrypt(dtHead))
                , Cls序列化.DeserializeDataTable(ClsDES.Decrypt(dtGridRecord))
                , Cls序列化.DeserializeDataTable(ClsDES.Decrypt(dtGridQuality))
                , Cls序列化.DeserializeDataTable(ClsDES.Decrypt(dtGridSecurity))
                , Cls序列化.DeserializeDataTable(ClsDES.Decrypt(dtGridAtt))
                , ClsDES.Decrypt(delRecord), ClsDES.Decrypt(delQuality), ClsDES.Decrypt(delSecurity), ClsDES.Decrypt(delAtt)));
        }

        [WebMethod]
        public string saveProgress(string PID, bool b, string uid, string iID)
        {
            ClsProject cls = new ClsProject();
            return ClsDES.Encrypt(cls.saveProgress(ClsDES.Decrypt(PID), b, ClsDES.Decrypt(uid), ClsDES.Decrypt(iID)));
        }

        [WebMethod]
        public string delProject(string iID)
        {
            ClsProject cls = new ClsProject();
            return ClsDES.Encrypt(cls.del(ClsDES.Decrypt(iID)));
        }

        [WebMethod]
        public string editProject(string iID)
        {
            ClsProject cls = new ClsProject();
            return ClsDES.Encrypt(cls.edit(ClsDES.Decrypt(iID)));
        }

        [WebMethod]
        public string auditProject(string iID,string uid)
        {
            ClsProject cls = new ClsProject();
            return ClsDES.Encrypt(cls.audit(ClsDES.Decrypt(iID), ClsDES.Decrypt(uid)));
        }

        [WebMethod]
        public string unAuditProject(string iID)
        {
            ClsProject cls = new ClsProject();
            return ClsDES.Encrypt(cls.unAudit(ClsDES.Decrypt(iID)));
        }

        [WebMethod]
        public string openProject(string uid, string sdt)
        {
            ClsProject cls = new ClsProject();
            return ClsDES.Encrypt(cls.open(ClsDES.Decrypt(uid), Cls序列化.DeserializeDataTable(ClsDES.Decrypt(sdt))));
        }

        [WebMethod]
        public string closeProject(string uid, string sdt)
        {
            ClsProject cls = new ClsProject();
            return ClsDES.Encrypt(cls.close(ClsDES.Decrypt(uid), Cls序列化.DeserializeDataTable(ClsDES.Decrypt(sdt))));
        }
        #endregion

        #region ProjectRole
        [WebMethod]
        public string dtProjectRole()
        {
            ClsProjectRole cls = new ClsProjectRole();
            return ClsDES.Encrypt(cls.dt());
        }

        [WebMethod]
        public string saveProjectRole(string sdt)
        {
            ClsProjectRole cls = new ClsProjectRole();
            return ClsDES.Encrypt(cls.save(Cls序列化.DeserializeDataTable(ClsDES.Decrypt(sdt))));
        }

        [WebMethod]
        public string dtRole(string vchrUid)
        {
            ClsProjectRole cls = new ClsProjectRole();
            return ClsDES.Encrypt(cls.dtrole(ClsDES.Decrypt(vchrUid)));
        }
        #endregion

        #region RdRecord
        [WebMethod]
        public string dtListRdRecord(string iCode1, string iCode2, string dDate1, string dDate2, string cInvCode1, string cInvCode2, string cRsCode)
        {
            ClsRdRecord cls = new ClsRdRecord();
            return ClsDES.Encrypt(cls.dtList(ClsDES.Decrypt(iCode1), ClsDES.Decrypt(iCode2), ClsDES.Decrypt(dDate1), ClsDES.Decrypt(dDate2), ClsDES.Decrypt(cInvCode1), ClsDES.Decrypt(cInvCode2), ClsDES.Decrypt(cRsCode)));
        }

        [WebMethod]
        public string dtRdRecord(int type, string iID, string cRsCode)
        {
            ClsRdRecord cls = new ClsRdRecord();
            return ClsDES.Encrypt(cls.dt(type, ClsDES.Decrypt(iID), ClsDES.Decrypt(cRsCode)));
        }

        [WebMethod]
        public string dtnewRdRecord(int type)
        {
            ClsRdRecord cls = new ClsRdRecord();
            return ClsDES.Encrypt(cls.dtnew(type));
        }

        [WebMethod]
        public string siIDRdRecord(int type, string iID, string cRsCode)
        {
            ClsRdRecord cls = new ClsRdRecord();
            return ClsDES.Encrypt(cls.siID(type, ClsDES.Decrypt(iID), ClsDES.Decrypt(cRsCode)));
        }

        [WebMethod]
        public string saveRdRecord(string uid, string sdthead, string sdt, string del)
        {
            ClsRdRecord cls = new ClsRdRecord();
            return ClsDES.Encrypt(cls.save(ClsDES.Decrypt(uid), Cls序列化.DeserializeDataTable(ClsDES.Decrypt(sdthead)), Cls序列化.DeserializeDataTable(ClsDES.Decrypt(sdt)), ClsDES.Decrypt(del)));
        }

        [WebMethod]
        public string delRdRecord(string iID)
        {
            ClsRdRecord cls = new ClsRdRecord();
            return ClsDES.Encrypt(cls.del(ClsDES.Decrypt(iID)));
        }

        [WebMethod]
        public decimal NowQty(string cInvCode)
        {
            ClsRdRecord cls = new ClsRdRecord();
            return cls.NowQty(ClsDES.Decrypt(cInvCode));
        }

        [WebMethod]
        public string editRdRecord(string iID)
        {
            ClsRdRecord cls = new ClsRdRecord();
            return ClsDES.Encrypt(cls.edit(ClsDES.Decrypt(iID)));
        }

        [WebMethod]
        public string auditRdRecord(string iID, string uid)
        {
            ClsRdRecord cls = new ClsRdRecord();
            return ClsDES.Encrypt(cls.audit(ClsDES.Decrypt(iID), ClsDES.Decrypt(uid)));
        }

        [WebMethod]
        public string unAuditRdRecord(string iID)
        {
            ClsRdRecord cls = new ClsRdRecord();
            return ClsDES.Encrypt(cls.unAudit(ClsDES.Decrypt(iID)));
        }
        #endregion

        #region Report
        [WebMethod]
        public string dtReportSecurity(DateTime dDate1, DateTime dDate2, DateTime dDate3, DateTime dDate4, string cPCCode, string cDCCode, string PersonCode, string cSCode, string cECode)
        {
            ClsReport cls = new ClsReport();
            return ClsDES.Encrypt(cls.dtReportSecurity(dDate1, dDate2, dDate3, dDate4, ClsDES.Decrypt(cPCCode), ClsDES.Decrypt(cDCCode), ClsDES.Decrypt(PersonCode), ClsDES.Decrypt(cSCode), ClsDES.Decrypt(cECode)));
        }

        [WebMethod]
        public string dtReportQuality(DateTime dDate1, DateTime dDate2, DateTime dDate3, DateTime dDate4, string cPCCode, string cDCCode, string PersonCode, string cQCode, string cECode)
        {
            ClsReport cls = new ClsReport();
            return ClsDES.Encrypt(cls.dtReportQuality(dDate1, dDate2, dDate3, dDate4, ClsDES.Decrypt(cPCCode), ClsDES.Decrypt(cDCCode), ClsDES.Decrypt(PersonCode), ClsDES.Decrypt(cQCode), ClsDES.Decrypt(cECode)));
        }

        [WebMethod]
        public string dtReportCheck(DateTime dDate1, DateTime dDate2, DateTime dDate3, DateTime dDate4, string cPCCode, string cDCCode, string PersonCode, string cECode)
        {
            ClsReport cls = new ClsReport();
            return ClsDES.Encrypt(cls.dtReportCheck(dDate1, dDate2, dDate3, dDate4, ClsDES.Decrypt(cPCCode), ClsDES.Decrypt(cDCCode), ClsDES.Decrypt(PersonCode), ClsDES.Decrypt(cECode)));
        }

        [WebMethod]
        public string dtReportNow()
        {
            ClsReport cls = new ClsReport();
            return ClsDES.Encrypt(cls.dtReportNow());
        }
        #endregion

        #region MonthRdRecord
        [WebMethod]
        public string dtListMonthRdRecord(string iCode1, string iCode2, string dDate1, string dDate2, string cInvCode1, string cInvCode2)
        {
            ClsMonthRdRecord cls = new ClsMonthRdRecord();
            return ClsDES.Encrypt(cls.dtList(ClsDES.Decrypt(iCode1), ClsDES.Decrypt(iCode2), ClsDES.Decrypt(dDate1), ClsDES.Decrypt(dDate2), ClsDES.Decrypt(cInvCode1), ClsDES.Decrypt(cInvCode2)));
        }

        [WebMethod]
        public string dtMonthRdRecord(int type, string iID)
        {
            ClsMonthRdRecord cls = new ClsMonthRdRecord();
            return ClsDES.Encrypt(cls.dt(type, ClsDES.Decrypt(iID)));
        }

        [WebMethod]
        public string dtnewMonthRdRecord(int type)
        {
            ClsMonthRdRecord cls = new ClsMonthRdRecord();
            return ClsDES.Encrypt(cls.dtnew(type));
        }

        [WebMethod]
        public string siIDMonthRdRecord(int type, string iID)
        {
            ClsMonthRdRecord cls = new ClsMonthRdRecord();
            return ClsDES.Encrypt(cls.siID(type, ClsDES.Decrypt(iID)));
        }

        [WebMethod]
        public string saveMonthRdRecord(string uid, string sdthead, string sdt, string del)
        {
            ClsMonthRdRecord cls = new ClsMonthRdRecord();
            return ClsDES.Encrypt(cls.save(ClsDES.Decrypt(uid), Cls序列化.DeserializeDataTable(ClsDES.Decrypt(sdthead)), Cls序列化.DeserializeDataTable(ClsDES.Decrypt(sdt)), ClsDES.Decrypt(del)));
        }

        [WebMethod]
        public string delMonthRdRecord(string iID)
        {
            ClsMonthRdRecord cls = new ClsMonthRdRecord();
            return ClsDES.Encrypt(cls.del(ClsDES.Decrypt(iID)));
        }

        [WebMethod]
        public string auditMonthRdRecord(string iID, string uid)
        {
            ClsMonthRdRecord cls = new ClsMonthRdRecord();
            return ClsDES.Encrypt(cls.audit(ClsDES.Decrypt(iID), ClsDES.Decrypt(uid)));
        }

        [WebMethod]
        public string unAuditMonthRdRecord(string iID)
        {
            ClsMonthRdRecord cls = new ClsMonthRdRecord();
            return ClsDES.Encrypt(cls.unAudit(ClsDES.Decrypt(iID)));
        }

        #endregion
    }
}
