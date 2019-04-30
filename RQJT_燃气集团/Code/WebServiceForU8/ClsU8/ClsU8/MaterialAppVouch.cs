using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using ClsBaseClass;
using System.Xml;

namespace ClsU8
{
    public class MaterialAppVouch
    {
        ClsDataBase clsSQLCommond = ClsDataBaseFactory.Instance();
        public string AddMaterialAppVouch(string sXML)
        {
            try
            {
                string sErr = "";
                string sCode = "";

                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml(sXML);
                //得到顶层节点列表 

                XmlNodeList xmlHead = xmldoc.SelectNodes("/storeout/header");
                XmlNodeList xmlBody = xmldoc.SelectNodes("/storeout/body/entry");

                if (xmlHead != null)
                {

                    SqlConnection conn = new SqlConnection(ClsBaseClass.ClsBaseDataInfo.sConnString);
                    conn.Open();
                    //启用事务
                    SqlTransaction tran = conn.BeginTransaction();
                    try
                    {
                        string sSQL = @"select getdate()";
                        DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        DateTime dtmToday = Convert.ToDateTime(Convert.ToDateTime(dtTemp.Rows[0][0]).ToString("yyyy-MM-dd"));
                        DateTime dtmNow = Convert.ToDateTime(dtTemp.Rows[0][0]);

                        foreach (XmlElement headNode in xmlHead)
                        {
                            DateTime dtmCode = Convert.ToDateTime(headNode.GetElementsByTagName("date")[0].InnerText.Trim());
                            #region 领料申请单
                            //1.   判断是否结账
                            sSQL = "select * from gl_mend where iperiod=month('" + dtmCode.ToString("yyyy-MM-dd") + "') and iyear = year('" + dtmCode.ToString("yyyy-MM-dd") + "')";
                            dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            if (dtTemp == null || dtTemp.Rows.Count < 1)
                            {
                                throw new Exception("加载模块结账信息失败");
                            }
                            int iR = ClsBaseDataInfo.ReturnObjectToInt(dtTemp.Rows[0]["bflag_ST"]);
                            if (iR == 1)
                            {
                                throw new Exception(dtmToday.ToString("yyyy-MM") + "已经结账");
                            }

                            sCode = headNode.GetElementsByTagName("code")[0].InnerText.Trim();

                            string cDepCode = headNode.GetElementsByTagName("departmentcode")[0].InnerText.Trim();
                            sSQL = "select cDepCode from Department where cDepCode='" + cDepCode + "' or cDepMemo like '%" + cDepCode + "%'";
                            DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            if (dt.Rows.Count > 0)
                            {
                                cDepCode = dt.Rows[0]["cDepCode"].ToString();
                            }
                            else
                            {
                                sErr = sErr + "部门：" + cDepCode + " 不存在\n";
                                continue;
                            }

                            string cPersonCode = headNode.GetElementsByTagName("personcode")[0].InnerText.Trim();
                            if (cPersonCode != "")
                            {
                                sSQL = "select JobNumber ,* from hr_hi_person where cPsn_Num = '" + cPersonCode + "' or JobNumber = '" + cPersonCode + "'";
                                dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                if (dt.Rows.Count > 0)
                                {
                                    cPersonCode = dt.Rows[0]["cPsn_Num"].ToString();
                                }
                                else
                                {
                                    sErr = sErr + "人员：" + cPersonCode + " 不存在\n";
                                    continue;
                                }
                            }
                            

                            long lID = -1;
                            long lIDDetails = -1;
                            sSQL = @"
                                            declare @p5 int
                                            set @p5=aaaaaa
                                            declare @p6 int
                                            set @p6=bbbbbb
                                            exec sp_GetId N'00',N'dddddd',N'mv',eeeeee,@p5 output,@p6 output,default
                                            select @p5, @p6
                                            ";
                            sSQL = sSQL.Replace("aaaaaa", lID.ToString());
                            sSQL = sSQL.Replace("bbbbbb", lIDDetails.ToString());
                            sSQL = sSQL.Replace("dddddd", ClsBaseClass.ClsBaseDataInfo.sAccID);
                            sSQL = sSQL.Replace("eeeeee", xmlBody.Count.ToString());
                            dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                            lID = ClsBaseDataInfo.ReturnObjectToLong(dt.Rows[0][0]);
                            lIDDetails = ClsBaseDataInfo.ReturnObjectToLong(dt.Rows[0][1]) - xmlBody.Count;

                            if (sCode == "")
                            {
                                sErr = sErr + "单据号不能为空\n";
                            }
                            sSQL = @"select * from MaterialAppVouch where cCode = '{0}'";
                            sSQL = string.Format(sSQL, sCode);
                            dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            if (dtTemp != null && dtTemp.Rows.Count > 0)
                            {
                                sErr = sErr + "单据号已经存在\n";
                            }

                            Model.MaterialAppVouch model = new Model.MaterialAppVouch();
                            model.VT_ID = 30718;
                            model.ID = lID;
                            model.cCode = sCode;
                            model.dDate = dtmCode;
                            model.cDepCode = cDepCode;
                            if (cPersonCode != "")
                            {
                                model.cPersonCode = cPersonCode;
                            }

                            model.cMemo = headNode.GetElementsByTagName("memory")[0].InnerText.Trim();
                            model.cDefine13 = headNode.GetElementsByTagName("define1")[0].InnerText.Trim();
                            model.cDefine14 = headNode.GetElementsByTagName("define2")[0].InnerText.Trim();
                            model.cDefine11 = headNode.GetElementsByTagName("define3")[0].InnerText.Trim();
                            model.cDefine12 = headNode.GetElementsByTagName("define4")[0].InnerText.Trim();
                            model.cDefine9 = headNode.GetElementsByTagName("define5")[0].InnerText.Trim();

                            model.cMaker = headNode.GetElementsByTagName("maker")[0].InnerText.Trim();
                            model.dnmaketime = dtmNow;
                            model.csysbarcode = "||st64|" + model.cCode;


                            model.cRdCode = "8";

                            DAL.MaterialAppVouch dal = new ClsU8.DAL.MaterialAppVouch();
                            sSQL = dal.Add(model);
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);



                            if (xmlHead != null)
                            {
                                int irowno = 0;
                                foreach (XmlElement bodyNode in xmlBody)
                                {
                                    string cInvCode = bodyNode.GetElementsByTagName("inventorycode")[0].InnerText.Trim();
                                    sSQL = @"
select * from Inventory where cInvCode = '{0}'
";
                                    sSQL = string.Format(sSQL, cInvCode);
                                    dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                    if (dtTemp == null || dtTemp.Rows.Count == 0)
                                    {
                                        sErr = sErr + "存货" + cInvCode + "不存在";
                                    }
                                    
                                    decimal fquantity = ClsBaseDataInfo.ReturnObjectToDecimal(bodyNode.GetElementsByTagName("quantity")[0].InnerText.Trim(), 2);
                                    decimal dnum = ClsBaseDataInfo.ReturnObjectToDecimal(bodyNode.GetElementsByTagName("number")[0].InnerText.Trim(), 2);

                                    if (fquantity <= 0)
                                    {
                                        sErr = sErr + "存货" + cInvCode + "请购数量必须大于0\n";
                                    }

                                    lIDDetails = lIDDetails + 1;
                                    

                                    irowno += 1;

                                    Model.MaterialAppVouchs models = new ClsU8.Model.MaterialAppVouchs();
                                    models.ID = lID;
                                    models.AutoID = lIDDetails;
                                    models.cInvCode = cInvCode;
                                    models.iQuantity = fquantity;
                                    if (dnum != 0)
                                    {
                                        models.iNum = dnum;
                                    }
                                    models.irowno = irowno;
                                    models.cbsysbarcode = "||st64|" + sCode + "|" + irowno.ToString();

                                    DAL.MaterialAppVouchs dals = new ClsU8.DAL.MaterialAppVouchs();
                                    sSQL = dals.Add(models);
                                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                                }
                            }

                        }

                        #endregion

                        if (sErr.Trim().Length > 0)
                        {
                            throw new Exception(sErr);
                        }

                        tran.Commit();
                    }
                    catch (Exception error)
                    {
                        tran.Rollback();
                        throw new Exception(error.Message);
                    }
                }
            }
            catch (Exception ee)
            {
                return "Err:" + ee.Message;
            }
            return "OK";
        }

    
    }
}
