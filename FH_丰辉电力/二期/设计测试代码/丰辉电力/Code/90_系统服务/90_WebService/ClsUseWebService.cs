using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace 系统服务
{
    public class ClsUseWebService
    {
        WebReference.DBWebService DBWebService = new WebReference.DBWebService();
        系统服务.ClsDES clsDES = 系统服务.ClsDES.Instance();
        public ClsUseWebService()
        {
            if (系统服务.ClsBaseDataInfo.sWebURL.Trim() != "")
                DBWebService.Url = 系统服务.ClsBaseDataInfo.sWebURL;
        }
        #region System
        public DateTime dtm当前服务器时间()
        {
            return DBWebService.dtm当前服务器时间();
        }

        public string UploadFile(string iID, string fileName, byte[] fileContent)
        {
            return clsDES.Decrypt(DBWebService.UploadFile(clsDES.Encrypt(iID), clsDES.Encrypt(fileName), fileContent));
        }

        public byte[] DownloadFile(string iID, string fileName)
        {
            return DBWebService.DownloadFile(clsDES.Encrypt(iID), clsDES.Encrypt(fileName));
        }

        public DataTable dtUserInfo(string vchrUid, string vchrPwd)
        {
            string s = DBWebService.dtUserInfo(clsDES.Encrypt(vchrUid), clsDES.Encrypt(vchrPwd));
            DataTable dt = Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
            return dt;
        }

        public DataTable dtGetAccInfo()
        {
            string s = DBWebService.dtGetAccInfo();
            DataTable dt = Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
            return dt;
        }


        public string svchrName(string vchrUid)
        {
            string s = clsDES.Decrypt(DBWebService.svchrName(clsDES.Encrypt(vchrUid)));
            return s;
        }

        public string sbU8Improt(string sUFDataBaseName)
        {
            string s = clsDES.Decrypt(DBWebService.sbU8Improt(clsDES.Encrypt(sUFDataBaseName)));
            return s;
        }

        public string saveDefine1(string vchrUid)
        {
            string s = clsDES.Decrypt(DBWebService.saveDefine1(clsDES.Encrypt(vchrUid)));
            return s;
        }

        public string saveDefine1all(string vchrUid, string sUserName, string Name, string Text, string ClickedItemName, string ClickedItemText)
        {
            string s = clsDES.Decrypt(DBWebService.saveDefine1all(clsDES.Encrypt(vchrUid), clsDES.Encrypt(sUserName), clsDES.Encrypt(Name), clsDES.Encrypt(Text), clsDES.Encrypt(ClickedItemName), clsDES.Encrypt(ClickedItemText)));
            return s;
        }

        public string saveUserInfoPwd(string vchrUid, string vchrPwd)
        {
            string s = clsDES.Decrypt(DBWebService.saveUserInfoPwd(clsDES.Encrypt(vchrUid), clsDES.Encrypt(vchrPwd)));
            return s;
        }

        public int sUserRoleInfo(string vchrRoleID, string sUid)
        {
            return DBWebService.sUserRoleInfo(clsDES.Encrypt(vchrRoleID), clsDES.Encrypt(sUid));
        }

        public int sRoleRight(string sUid, string sInfo)
        {
            return DBWebService.sRoleRight(clsDES.Encrypt(sUid), clsDES.Encrypt(sInfo));
        }

        public string svchrRoleID(string sUid)
        {
            string s = clsDES.Decrypt(DBWebService.svchrRoleID(clsDES.Encrypt(sUid)));
            return s;
        }

        public string sDeptID(string sUid)
        {
            string s = clsDES.Decrypt(DBWebService.sDeptID(clsDES.Encrypt(sUid)));
            return s;
        }

        public DataTable dtForm(string fchrFrmNameID, string fchrFrmText, string Flag)
        {
            string s = DBWebService.dtForm(clsDES.Encrypt(fchrFrmNameID), clsDES.Encrypt(fchrFrmText), clsDES.Encrypt(Flag));
            return Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
        }

        public DataTable dtFormBtnInfo(string fchrFrmNameID, string fchrFrmText)
        {
            string s = DBWebService.dtFormBtnInfo(clsDES.Encrypt(fchrFrmNameID), clsDES.Encrypt(fchrFrmText));
            return Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
        }

        public DataTable dtBtnBaseInfo()
        {
            string s = DBWebService.dtBtnBaseInfo();
            return Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
        }

        public DataTable dtCreateBtn(string sUid, string sFormInfo)
        {
            string s = DBWebService.dtCreateBtn(clsDES.Encrypt(sUid), clsDES.Encrypt(sFormInfo));
            return Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
        }

        public DataTable dtMainSetTree(string sUid, string sProForm)
        {
            string s = DBWebService.dtMainSetTree(clsDES.Encrypt(sUid), clsDES.Encrypt(sProForm));
            return Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
        }

        public DataTable sfchrFrmNameID()
        {
            string s = DBWebService.sfchrFrmNameID();
            return Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
        }

        public string delForm(string FormCode)
        {
            string s = clsDES.Decrypt(DBWebService.delForm(clsDES.Encrypt(FormCode)));
            return s;
        }

        public string delRoleInfo(string sRoleID)
        {
            string s = clsDES.Decrypt(DBWebService.delRoleInfo(clsDES.Encrypt(sRoleID)));
            return s;
        }

        public string saveForm(DataTable sdt, string FormCode, string FormName, string NameSpace, string FrmUpName, string OrderID, int iHide, int iNoUse, int iSystem, int iUse)
        {
            string s = clsDES.Decrypt(DBWebService.saveForm(clsDES.Encrypt(Cls序列化.SerializeDataTableXml(sdt)), clsDES.Encrypt(FormCode), clsDES.Encrypt(FormName), clsDES.Encrypt(NameSpace), 
                clsDES.Encrypt(FrmUpName),clsDES.Encrypt(OrderID), iHide, iNoUse, iSystem, iUse));
            return s;
        }

        public DataTable dtTableColInfo(string DataBase, string Table)
        {
            string s = DBWebService.dtTableColInfo(clsDES.Encrypt(DataBase), clsDES.Encrypt(Table));
            return Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
        }

        public DataTable dtSysObjects(string DataBase, string Flag)
        {
            string s = DBWebService.dtSysObjects(clsDES.Encrypt(DataBase), clsDES.Encrypt(Flag));
            return Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
        }

        public string saveTableColInfo(DataTable sdt, string DataBase, string Table, int iSystem)
        {
            string s = clsDES.Decrypt(DBWebService.saveTableColInfo(clsDES.Encrypt(Cls序列化.SerializeDataTableXml(sdt)), clsDES.Encrypt(DataBase), clsDES.Encrypt(Table), iSystem));
            return s;
        }
        #endregion

        #region _LookUpType
        public DataTable dtLookUpType()
        {
            string s = DBWebService.dtLookUpType();
            DataTable dt = Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
            return dt;
        }

        public string saveLookUpType(DataTable dts)
        {
            string s = clsDES.Decrypt(DBWebService.saveLookUpType(clsDES.Encrypt(Cls序列化.SerializeDataTableXml(dts))));
            return s;
        }

        public string delLookUpType(string iID)
        {
            string s = clsDES.Decrypt(DBWebService.delLookUpType(clsDES.Encrypt(iID)));
            return s;
        }

        public bool bClosedLookUpType(string cECode)
        {
            bool s = DBWebService.bClosedLookUpType(clsDES.Encrypt(cECode));
            return s;
        }
        #endregion

        #region _LookUpDate
        public DataTable dtLookUpDate(string iType)
        {
            string s = DBWebService.dtLookUpDate(clsDES.Encrypt(iType));
            DataTable dt = Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
            return dt;
        }

        public string saveLookUpDate(DataTable dts,string iType)
        {
            string s = clsDES.Decrypt(DBWebService.saveLookUpDate(clsDES.Encrypt(Cls序列化.SerializeDataTableXml(dts)), clsDES.Encrypt(iType)));
            return s;
        }

        public string delLookUpDate(string iID, string iType)
        {
            string s = clsDES.Decrypt(DBWebService.delLookUpDate(clsDES.Encrypt(iID), clsDES.Encrypt(iType)));
            return s;
        }

        public bool bClosedLookUpDate(string cECode,string iType)
        {
            bool s = DBWebService.bClosedLookUpDate(clsDES.Encrypt(cECode), clsDES.Encrypt(iType));
            return s;
        }
        #endregion

        #region ClsBuckUpDataBase
        public bool ClsBuckUpDataBaseBuckUpDataBase(string sPathInfo)
        {
            return DBWebService.ClsBuckUpDataBaseBuckUpDataBase(clsDES.Encrypt(sPathInfo));
        }

        public DateTime ClsBuckUpDataBaseGetSerTime()
        {
            return DBWebService.ClsBuckUpDataBaseGetSerTime();
        }

        public DataTable ClsBuckUpDataBaseGetSerHostName()
        {
            string s = DBWebService.ClsBuckUpDataBaseGetSerHostName();
            DataTable dt = Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
            return dt;
        }
        #endregion

        #region ClsRoleEditQuery
        public DataTable ClsRoleEditQueryGetAllDt()
        {
            string s = DBWebService.ClsRoleEditQueryGetAllDt();
            DataTable dt = Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
            return dt;
        }

        public DataTable ClsRoleEditQueryGetUserRole(string sUid)
        {
            string s = DBWebService.ClsRoleEditQueryGetUserRole(clsDES.Encrypt(sUid));
            DataTable dt = Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
            return dt;
        }

        public bool ClsRoleEditQueryChkRoleID(string sUid)
        {
            return DBWebService.ClsRoleEditQueryChkRoleID(clsDES.Encrypt(sUid));
        }
        #endregion

        #region ClsRoleInfoQuery
        public DataTable ClsRoleInfoQueryGetAllDt()
        {
            string s = DBWebService.ClsRoleInfoQueryGetAllDt();
            DataTable dt = Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
            return dt;
        }

        public bool ClsRoleInfoQueryChkClosed(string sUid)
        {
            return DBWebService.ClsRoleInfoQueryChkClosed(clsDES.Encrypt(sUid));
        }
        #endregion

        #region ClsRoleRight
        public DataTable ClsRoleRightGetTreeInfo(string sPK)
        {
            string s = DBWebService.ClsRoleRightGetTreeInfo(clsDES.Encrypt(sPK));
            DataTable dt = Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
            return dt;
        }
        #endregion

        #region ClsUserEditQuery
        public DataTable ClsUserEditQueryGetAllDt()
        {
            string s = DBWebService.ClsUserEditQueryGetAllDt();
            DataTable dt = Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
            return dt;
        }

        public DataTable ClsUserEditQueryGetUserRole(string sUid)
        {
            string s = DBWebService.ClsUserEditQueryGetUserRole(clsDES.Encrypt(sUid));
            DataTable dt = Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
            return dt;
        }

        public bool ClsUserEditQueryChkUID(string sUid)
        {
            return DBWebService.ClsUserEditQueryChkUID(clsDES.Encrypt(sUid));
        }
        #endregion

        #region ClsUserInfoQuery
        public DataTable ClsUserInfoQueryGetAllDt()
        {
            string s = DBWebService.ClsUserInfoQueryGetAllDt();
            DataTable dt = Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
            return dt;
        }
        #endregion


        #region ClsRoleEditBll
        public string ClsRoleEditBllAdd(string vchrRoleID, string vchrRoleText, string vchrRemark, bool bClosed, DateTime dtmCreate, DataTable dt)
        {
            return clsDES.Decrypt(DBWebService.ClsRoleEditBllAdd(clsDES.Encrypt(vchrRoleID), clsDES.Encrypt(vchrRoleText), clsDES.Encrypt(vchrRemark), bClosed, dtmCreate, clsDES.Encrypt(Cls序列化.SerializeDataTableXml(dt))));
        }

        public string ClsRoleEditBllUpdate(string vchrRoleID, string vchrRoleText, string vchrRemark, bool bClosed, DateTime dtmCreate, DataTable dt)
        {
            return clsDES.Decrypt(DBWebService.ClsRoleEditBllUpdate(clsDES.Encrypt(vchrRoleID), clsDES.Encrypt(vchrRoleText), clsDES.Encrypt(vchrRemark), bClosed, dtmCreate, clsDES.Encrypt(Cls序列化.SerializeDataTableXml(dt))));
        }
        #endregion

        #region ClsRoleInfoBll
        public string ClsRoleInfoBllDelete(string sRoleid)
        {
            return clsDES.Decrypt(DBWebService.ClsRoleInfoBllDelete(clsDES.Encrypt(sRoleid)));
        }

        public string ClsRoleInfoBllUnDelete(string sRoleid)
        {
            return clsDES.Decrypt(DBWebService.ClsRoleInfoBllUnDelete(clsDES.Encrypt(sRoleid)));
        }
        #endregion

        #region ClsRoleRightBll
        public string ClsRoleRightBllAdd(string sPK, DataTable dt)
        {
            return clsDES.Decrypt(DBWebService.ClsRoleRightBllAdd(clsDES.Encrypt(sPK), clsDES.Encrypt(Cls序列化.SerializeDataTableXml(dt))));
        }
        #endregion

        #region ClsUserEditBll
        public string ClsUserEditBllAdd(string vchrUid, string vchrPwd, DateTime dtmCreate, DateTime dtmClose, string vchrRemark, string vchrName, DataTable dt)
        {
            return clsDES.Decrypt(DBWebService.ClsUserEditBllAdd(clsDES.Encrypt(vchrUid), clsDES.Encrypt(vchrPwd), dtmCreate, dtmClose, clsDES.Encrypt(vchrRemark), clsDES.Encrypt(vchrName), clsDES.Encrypt(Cls序列化.SerializeDataTableXml(dt))));
        }

        public string ClsUserEditBllUpdate(string vchrUid, string vchrPwd, DateTime dtmCreate, DateTime dtmClose, string vchrRemark, string vchrName, DataTable dt)
        {
            return clsDES.Decrypt(DBWebService.ClsUserEditBllUpdate(clsDES.Encrypt(vchrUid), clsDES.Encrypt(vchrPwd), dtmCreate, dtmClose, clsDES.Encrypt(vchrRemark), clsDES.Encrypt(vchrName), clsDES.Encrypt(Cls序列化.SerializeDataTableXml(dt))));
        }
        #endregion

        #region ClsUserInfoBll
        public string ClsUserInfoBllDelete(string sUserid)
        {
            return clsDES.Decrypt(DBWebService.ClsUserInfoBllDelete(clsDES.Encrypt(sUserid)));
        }
        #endregion


        #region LookUp
        public DataTable LookUpLookUpType()
        {
            string s = DBWebService.LookUpLookUpType();
            DataTable dt = Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
            return dt;
        }

        public DataTable LookUpLoopUpData(string id)
        {
            string s = DBWebService.LookUpLoopUpData(clsDES.Encrypt(id));
            DataTable dt = Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
            return dt;
        }

        public DataTable LookUpDepartment()
        {
            string s = DBWebService.LookUpDepartment();
            DataTable dt = Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
            return dt;
        }

        public DataTable LookUpComputationUnit()
        {
            string s = DBWebService.LookUpComputationUnit();
            DataTable dt = Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
            return dt;
        }

        public DataTable LookUpInventory()
        {
            string s = DBWebService.LookUpInventory();
            DataTable dt = Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
            return dt;
        }

        public DataTable LookUpPerson()
        {
            string s = DBWebService.LookUpPerson();
            DataTable dt = Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
            return dt;
        }

        public DataTable LookUpDistrictClass()
        {
            string s = DBWebService.LookUpDistrictClass();
            DataTable dt = Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
            return dt;
        }

        public DataTable LookUpEngineering()
        {
            string s = DBWebService.LookUpEngineering();
            DataTable dt = Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
            return dt;
        }

        public DataTable LookUpQuality()
        {
            string s = DBWebService.LookUpQuality();
            DataTable dt = Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
            return dt;
        }

        public DataTable LookUpSecurity()
        {
            string s = DBWebService.LookUpSecurity();
            DataTable dt = Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
            return dt;
        }

        public DataTable LookUpRdRecord()
        {
            string s = DBWebService.LookUpRdRecord();
            DataTable dt = Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
            return dt;
        }

        public DataTable LookUpUserInfo()
        {
            string s = DBWebService.LookUpUserInfo();
            DataTable dt = Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
            return dt;
        }

        public DataTable LookUpProject()
        {
            string s = DBWebService.LookUpProject();
            DataTable dt = Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
            return dt;
        }
        #endregion

        #region Show
        public DataTable ShowInventory(string cInvCode)
        {
            string s = DBWebService.ShowInventory(clsDES.Encrypt(cInvCode));
            DataTable dt = Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
            return dt;
        }

        public DataTable ShowPerson(string PersonCode)
        {
            string s = DBWebService.ShowPerson(clsDES.Encrypt(PersonCode));
            DataTable dt = Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
            return dt;
        }

        public DataTable ShowDepartment(string cDepCode)
        {
            string s = DBWebService.ShowDepartment(clsDES.Encrypt(cDepCode));
            DataTable dt = Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
            return dt;
        }

        public DataTable ShowEngineering(string cECode)
        {
            string s = DBWebService.ShowEngineering(clsDES.Encrypt(cECode));
            DataTable dt = Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
            return dt;
        }

        public DataTable ShowQuality(string cQCode)
        {
            string s = DBWebService.ShowQuality(clsDES.Encrypt(cQCode));
            DataTable dt = Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
            return dt;
        }

        public DataTable ShowSecurity(string cSCode)
        {
            string s = DBWebService.ShowSecurity(clsDES.Encrypt(cSCode));
            DataTable dt = Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
            return dt;
        }

        public DataTable ShowDistrictClass(string cDCCode)
        {
            string s = DBWebService.ShowDistrictClass(clsDES.Encrypt(cDCCode));
            DataTable dt = Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
            return dt;
        }

        public DataTable ShowlookUpDate(string code,string iType)
        {
            string s = DBWebService.ShowlookUpDate(clsDES.Encrypt(code), clsDES.Encrypt(iType));
            DataTable dt = Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
            return dt;
        }

        public DataTable ShowProject(string code)
        {
            string s = DBWebService.ShowProject(clsDES.Encrypt(code));
            DataTable dt = Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
            return dt;
        }

        #endregion


        #region Security
        public DataTable dtSecurity()
        {
            string s = DBWebService.dtSecurity();
            DataTable dt = Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
            return dt;
        }

        public string saveSecurity(DataTable dts)
        {
            string s = clsDES.Decrypt(DBWebService.saveSecurity(clsDES.Encrypt(Cls序列化.SerializeDataTableXml(dts))));
            return s;
        }

        public string delSecurity(string cSCode)
        {
            string s = clsDES.Decrypt(DBWebService.delSecurity(clsDES.Encrypt(cSCode)));
            return s;
        }

        public bool bClosedSecurity(string cSCode)
        {
            bool s = DBWebService.bClosedSecurity(clsDES.Encrypt(cSCode));
            return s;
        }
        #endregion

        #region Quality
        public DataTable dtQuality()
        {
            string s = DBWebService.dtQuality();
            DataTable dt = Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
            return dt;
        }

        public string saveQuality(DataTable dts)
        {
            string s = clsDES.Decrypt(DBWebService.saveQuality(clsDES.Encrypt(Cls序列化.SerializeDataTableXml(dts))));
            return s;
        }

        public string delQuality(string cQCode)
        {
            string s = clsDES.Decrypt(DBWebService.delQuality(clsDES.Encrypt(cQCode)));
            return s;
        }

        public bool bClosedQuality(string cQCode)
        {
            bool s = DBWebService.bClosedQuality(clsDES.Encrypt(cQCode));
            return s;
        }
        #endregion

        #region Engineering
        public DataTable dtEngineering()
        {
            string s = DBWebService.dtEngineering();
            DataTable dt = Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
            return dt;
        }

        public string saveEngineering(DataTable dts)
        {
            string s = clsDES.Decrypt(DBWebService.saveEngineering(clsDES.Encrypt(Cls序列化.SerializeDataTableXml(dts))));
            return s;
        }

        public string delEngineering(string cECode)
        {
            string s = clsDES.Decrypt(DBWebService.delEngineering(clsDES.Encrypt(cECode)));
            return s;
        }

        public bool bClosedEngineering(string cECode)
        {
            bool s = DBWebService.bClosedEngineering(clsDES.Encrypt(cECode));
            return s;
        }
        #endregion

        #region ComputationUnit
        public DataTable dtComputationUnit()
        {
            string s = DBWebService.dtComputationUnit();
            DataTable dt = Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
            return dt;
        }

        public string saveComputationUnit(DataTable dts)
        {
            string s = clsDES.Decrypt(DBWebService.saveComputationUnit(clsDES.Encrypt(Cls序列化.SerializeDataTableXml(dts))));
            return s;
        }

        public string delComputationUnit(string cComunitCode)
        {
            string s = clsDES.Decrypt(DBWebService.delComputationUnit(clsDES.Encrypt(cComunitCode)));
            return s;
        }
        #endregion

        #region Department
        public DataTable dtDepartment()
        {
            string s = DBWebService.dtDepartment();
            DataTable dt = Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
            return dt;
        }

        public string saveDepartment(DataTable dts)
        {
            string s = clsDES.Decrypt(DBWebService.saveDepartment(clsDES.Encrypt(Cls序列化.SerializeDataTableXml(dts))));
            return s;
        }

        public string delDepartment(string sDepCode)
        {
            string s = clsDES.Decrypt(DBWebService.delDepartment(clsDES.Encrypt(sDepCode)));
            return s;
        }
        #endregion

        #region DistrictClass
        public DataTable dtDistrictClass()
        {
            string s = DBWebService.dtDistrictClass();
            DataTable dt = Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
            return dt;
        }

        public string saveDistrictClass(DataTable dts)
        {
            string s = clsDES.Decrypt(DBWebService.saveDistrictClass(clsDES.Encrypt(Cls序列化.SerializeDataTableXml(dts))));
            return s;
        }

        public string delDistrictClass(string cDCCode)
        {
            string s = clsDES.Decrypt(DBWebService.delDistrictClass(clsDES.Encrypt(cDCCode)));
            return s;
        }
        #endregion

        #region Inventory
        public DataTable dtInventory()
        {
            string s = DBWebService.dtInventory();
            DataTable dt = Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
            return dt;
        }

        public string saveInventory(DataTable dts)
        {
            string s = clsDES.Decrypt(DBWebService.saveInventory(clsDES.Encrypt(Cls序列化.SerializeDataTableXml(dts))));
            return s;
        }

        public string delInventory(string cInvCode)
        {
            string s = clsDES.Decrypt(DBWebService.delInventory(clsDES.Encrypt(cInvCode)));
            return s;
        }

        public bool bClosedInventory(string cInvCode)
        {
            bool s = DBWebService.bClosedInventory(clsDES.Encrypt(cInvCode));
            return s;
        }
        #endregion

        #region Person
        public DataTable dtPerson()
        {
            string s = DBWebService.dtPerson();
            DataTable dt = Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
            return dt;
        }

        public string savePerson(DataTable dts)
        {
            string s = clsDES.Decrypt(DBWebService.savePerson(clsDES.Encrypt(Cls序列化.SerializeDataTableXml(dts))));
            return s;
        }

        public string delPerson(string sPerCode)
        {
            string s = clsDES.Decrypt(DBWebService.delPerson(clsDES.Encrypt(sPerCode)));
            return s;
        }

        public bool bClosedPerson(string PersonCode)
        {
            bool s = DBWebService.bClosedPerson(clsDES.Encrypt(PersonCode));
            return s;
        }
        #endregion

        #region Project
        public DataTable dtListProject(string sWhere, string cPCCode)
        {
            string s = DBWebService.dtListProject(clsDES.Encrypt(sWhere), clsDES.Encrypt(cPCCode));
            DataTable dt = Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
            return dt;
        }

        public DataTable dtProject(int type, string iID)
        {
            string s = DBWebService.dtProject(type,clsDES.Encrypt(iID));
            DataTable dt = Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
            return dt;
        }

        public DataTable dtnewProject(int type)
        {
            string s = DBWebService.dtnewProject(type);
            DataTable dt = Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
            return dt;
        }

        public string siIDProject(int type, string iID)
        {
            string s = clsDES.Decrypt(DBWebService.siIDProject(type, clsDES.Encrypt(iID)));
            return s;
        }

        public string saveProject(string uid, DataTable dtHead, DataTable dtGridRecord, DataTable dtGridQuality, DataTable dtGridSecurity, DataTable dtGridAtt
            , string delRecord, string delQuality, string delSecurity, string delAtt)
        {
            string s = clsDES.Decrypt(DBWebService.saveProject(clsDES.Encrypt(uid), clsDES.Encrypt(Cls序列化.SerializeDataTableXml(dtHead))
            , clsDES.Encrypt(Cls序列化.SerializeDataTableXml(dtGridRecord))
            , clsDES.Encrypt(Cls序列化.SerializeDataTableXml(dtGridQuality))
            , clsDES.Encrypt(Cls序列化.SerializeDataTableXml(dtGridSecurity))
            , clsDES.Encrypt(Cls序列化.SerializeDataTableXml(dtGridAtt))
            , clsDES.Encrypt(delRecord), clsDES.Encrypt(delQuality), clsDES.Encrypt(delSecurity), clsDES.Encrypt(delAtt)));
            return s;
        }

        public string saveProgress(string PID, bool b, string uid, string iID)
        {
            string s = clsDES.Decrypt(DBWebService.saveProgress(clsDES.Encrypt(PID), b, clsDES.Encrypt(uid), clsDES.Encrypt(iID)));
            return s;
        }

        public string delProject(string iID)
        {
            string s = clsDES.Decrypt(DBWebService.delProject(clsDES.Encrypt(iID)));
            return s;
        }

        public string editProject(string iID)
        {
            string s = clsDES.Decrypt(DBWebService.editProject(clsDES.Encrypt(iID)));
            return s;
        }

        public string auditProject(string iID,string uid)
        {
            string s = clsDES.Decrypt(DBWebService.auditProject(clsDES.Encrypt(iID), clsDES.Encrypt(uid)));
            return s;
        }

        public string unAuditProject(string iID)
        {
            string s = clsDES.Decrypt(DBWebService.unAuditProject(clsDES.Encrypt(iID)));
            return s;
        }

        public string openProject(string uid, DataTable dtGrid)
        {
            string s = clsDES.Decrypt(DBWebService.openProject(clsDES.Encrypt(uid), clsDES.Encrypt(Cls序列化.SerializeDataTableXml(dtGrid))));
            return s;
        }

        public string closeProject(string uid,DataTable dtGrid)
        {
            string s = clsDES.Decrypt(DBWebService.closeProject(clsDES.Encrypt(uid), clsDES.Encrypt(Cls序列化.SerializeDataTableXml(dtGrid))));
            return s;
        }
        #endregion

        #region ProjectRole
        public DataTable dtProjectRole()
        {
            string s = DBWebService.dtProjectRole();
            DataTable dt = Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
            return dt;
        }

        public string saveProjectRole(DataTable dts)
        {
            string s = clsDES.Decrypt(DBWebService.saveProjectRole(clsDES.Encrypt(Cls序列化.SerializeDataTableXml(dts))));
            return s;
        }

        public DataTable dtRole(string vchrUid)
        {
            string s = DBWebService.dtRole(clsDES.Encrypt(vchrUid));
            DataTable dt = Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
            return dt;
        }

        #endregion

        #region RdRecord
        public DataTable dtListRdRecord(string iCode, string iName, string dDate1, string dDate2, string cInvCode1, string cInvCode2, string cRsCode)
        {
            string s = DBWebService.dtListRdRecord(clsDES.Encrypt(iCode), clsDES.Encrypt(iName), clsDES.Encrypt(dDate1), clsDES.Encrypt(dDate2), clsDES.Encrypt(cInvCode1), clsDES.Encrypt(cInvCode2), clsDES.Encrypt(cRsCode));
            DataTable dt = Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
            return dt;
        }

        public DataTable dtRdRecord(int type, string iID, string cRsCode)
        {
            string s = DBWebService.dtRdRecord(type, clsDES.Encrypt(iID), clsDES.Encrypt(cRsCode));
            DataTable dt = Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
            return dt;
        }

        public DataTable dtnewRdRecord(int type)
        {
            string s = DBWebService.dtnewRdRecord(type);
            DataTable dt = Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
            return dt;
        }

        public string siIDRdRecord(int type, string iID, string cRsCode)
        {
            string s = clsDES.Decrypt(DBWebService.siIDRdRecord(type, clsDES.Encrypt(iID), clsDES.Encrypt(cRsCode)));
            return s;
        }

        public string saveRdRecord(string uid, DataTable dthead, DataTable dts, string del)
        {
            string s = clsDES.Decrypt(DBWebService.saveRdRecord(clsDES.Encrypt(uid), clsDES.Encrypt(Cls序列化.SerializeDataTableXml(dthead)), clsDES.Encrypt(Cls序列化.SerializeDataTableXml(dts)), clsDES.Encrypt(del)));
            return s;
        }

        public string delRdRecord(string iID)
        {
            string s = clsDES.Decrypt(DBWebService.delRdRecord(clsDES.Encrypt(iID)));
            return s;
        }

        public decimal NowQty(string cInvCode)
        {
            return DBWebService.NowQty(clsDES.Encrypt(cInvCode));
        }

        public string editRdRecord(string iID)
        {
            string s = clsDES.Decrypt(DBWebService.editRdRecord(clsDES.Encrypt(iID)));
            return s;
        }

        public string auditRdRecord(string iID, string uid)
        {
            string s = clsDES.Decrypt(DBWebService.auditRdRecord(clsDES.Encrypt(iID), clsDES.Encrypt(uid))); 
            return s;
        }

        public string unAuditRdRecord(string iID)
        {
            string s = clsDES.Decrypt(DBWebService.unAuditRdRecord(clsDES.Encrypt(iID)));
            return s;
        }
        #endregion

        #region Report
        public DataTable dtReportSecurity(DateTime dDate1, DateTime dDate2, DateTime dDate3, DateTime dDate4, string cPCCode, string cDCCode, string PersonCode, string cSCode, string cECode)
        {
            string s = DBWebService.dtReportSecurity(dDate1, dDate2, dDate3, dDate4, clsDES.Encrypt(cPCCode), clsDES.Encrypt(cDCCode), clsDES.Encrypt(PersonCode), clsDES.Encrypt(cSCode), clsDES.Encrypt(cECode));
            DataTable dt = Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
            return dt;
        }

        public DataTable dtReportQuality(DateTime dDate1, DateTime dDate2, DateTime dDate3, DateTime dDate4, string cPCCode, string cDCCode, string PersonCode, string cQCode, string cECode)
        {
            string s = DBWebService.dtReportQuality(dDate1, dDate2, dDate3, dDate4, clsDES.Encrypt(cPCCode), clsDES.Encrypt(cDCCode), clsDES.Encrypt(PersonCode), clsDES.Encrypt(cQCode), clsDES.Encrypt(cECode));
            DataTable dt = Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
            return dt;
        }

        public DataTable dtReportCheck(DateTime dDate1, DateTime dDate2, DateTime dDate3, DateTime dDate4, string cPCCode, string cDCCode, string PersonCode, string cECode)
        {
            string s = DBWebService.dtReportCheck(dDate1, dDate2, dDate3, dDate4, clsDES.Encrypt(cPCCode), clsDES.Encrypt(cDCCode), clsDES.Encrypt(PersonCode), clsDES.Encrypt(cECode));
            DataTable dt = Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
            return dt;
        }

        public DataTable dtReportNow()
        {
            string s = DBWebService.dtReportNow();
            DataTable dt = Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
            return dt;
        }
        #endregion

        #region MonthRdRecord
        public DataTable dtListMonthRdRecord(string iCode, string iName, string dDate1, string dDate2, string cInvCode1, string cInvCode2)
        {
            string s = DBWebService.dtListMonthRdRecord(clsDES.Encrypt(iCode), clsDES.Encrypt(iName), clsDES.Encrypt(dDate1), clsDES.Encrypt(dDate2), clsDES.Encrypt(cInvCode1), clsDES.Encrypt(cInvCode2));
            DataTable dt = Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
            return dt;
        }

        public DataTable dtMonthRdRecord(int type, string iID)
        {
            string s = DBWebService.dtMonthRdRecord(type, clsDES.Encrypt(iID));
            DataTable dt = Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
            return dt;
        }

        public DataTable dtnewMonthRdRecord(int type)
        {
            string s = DBWebService.dtnewMonthRdRecord(type);
            DataTable dt = Cls序列化.DeserializeDataTable(clsDES.Decrypt(s));
            return dt;
        }

        public string siIDMonthRdRecord(int type, string iID)
        {
            string s = clsDES.Decrypt(DBWebService.siIDMonthRdRecord(type, clsDES.Encrypt(iID)));
            return s;
        }

        public string saveMonthRdRecord(string uid, DataTable dthead, DataTable dts, string del)
        {
            string s = clsDES.Decrypt(DBWebService.saveMonthRdRecord(clsDES.Encrypt(uid), clsDES.Encrypt(Cls序列化.SerializeDataTableXml(dthead)), clsDES.Encrypt(Cls序列化.SerializeDataTableXml(dts)), clsDES.Encrypt(del)));
            return s;
        }

        public string delMonthRdRecord(string iID)
        {
            string s = clsDES.Decrypt(DBWebService.delMonthRdRecord(clsDES.Encrypt(iID)));
            return s;
        }

        public string auditMonthRdRecord(string iID, string uid)
        {
            string s = clsDES.Decrypt(DBWebService.auditMonthRdRecord(clsDES.Encrypt(iID), clsDES.Encrypt(uid)));
            return s;
        }

        public string unAuditMonthRdRecord(string iID)
        {
            string s = clsDES.Decrypt(DBWebService.unAuditMonthRdRecord(clsDES.Encrypt(iID)));
            return s;
        }
        #endregion
    }
}
