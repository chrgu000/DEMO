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
    public class PU_AppVouch
    {
        ClsDataBase clsSQLCommond = ClsDataBaseFactory.Instance();
        public string AddPU_AppVouch(string sXML)
        {
            string sErr = "";
            try
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml(sXML);
                //得到顶层节点列表 

                XmlNodeList xmlHead = xmldoc.SelectNodes("/purchaseapp/header");
                XmlNodeList xmlBody = xmldoc.SelectNodes("/purchaseapp/body/entry");

                if (xmlHead != null)
                {
                    SqlConnection conn = new SqlConnection(ClsBaseClass.ClsBaseDataInfo.sConnString);
                    conn.Open();
                    //启用事务
                    SqlTransaction tran = conn.BeginTransaction();
                    try
                    {
                        long lID = -1;
                        long lIDDetails = -1;
                        string sCode = "";

                        foreach (XmlElement headNode in xmlHead)
                        {
                            sCode = headNode.GetElementsByTagName("code")[0].InnerText.Trim();
                            if (sCode == "")
                            {
                                sErr = sErr + "单据号不能为空\n";
                            }


                            DateTime dtmCode = Convert.ToDateTime(headNode.GetElementsByTagName("date")[0].InnerText.Trim());

                            //1.   判断是否结账
                            string sSQL = "select * from gl_mend where iperiod=month('" + dtmCode.ToString("yyyy-MM-dd") + "') and iyear = year('" + dtmCode.ToString("yyyy-MM-dd") + "')";
                            DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            if (dtTemp == null || dtTemp.Rows.Count < 1)
                            {
                                throw new Exception("加载模块结账信息失败");
                            }
                            int iR = ClsBaseDataInfo.ReturnObjectToInt(dtTemp.Rows[0]["bflag_PU"]);
                            if (iR == 1)
                            {
                                throw new Exception(dtmCode.ToString("yyyy-MM") + "已经结账");
                            }


                            string cDepCode = headNode.GetElementsByTagName("departmentcode")[0].InnerText.Trim();
                            if (cDepCode != "")
                            {
                                sSQL = "select cDepCode from Department where cDepCode='" + cDepCode + "' or cDepMemo like '%" + cDepCode + "%'";
                                dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                if (dtTemp.Rows.Count > 0)
                                {
                                    cDepCode = dtTemp.Rows[0]["cDepCode"].ToString();
                                }
                                else
                                {
                                    sErr = sErr + "请购部门：" + cDepCode + " 不存在\n";
                                    continue;
                                }
                            }

                            string cPersonCode = headNode.GetElementsByTagName("personcode")[0].InnerText.Trim();
                            if (cPersonCode != "")
                            {
                                sSQL = "select JobNumber ,* from hr_hi_person where cPsn_Num = '" + cPersonCode + "' or JobNumber = '" + cPersonCode + "'";
                                dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                if (dtTemp.Rows.Count > 0)
                                {
                                    cPersonCode = dtTemp.Rows[0]["cPsn_Num"].ToString();
                                }
                                else
                                {
                                    sErr = sErr + "请购人员：" + cPersonCode + " 不存在\n";
                                    continue;
                                }
                            }

                            sSQL = @"
                                            declare @p5 int
                                            set @p5=aaaaaa
                                            declare @p6 int
                                            set @p6=bbbbbb
                                            exec sp_GetId N'00',N'dddddd',N'PUAPP',eeeeee,@p5 output,@p6 output,default
                                            select @p5, @p6
                                            ";
                            sSQL = sSQL.Replace("aaaaaa", lID.ToString());
                            sSQL = sSQL.Replace("bbbbbb", lIDDetails.ToString());
                            sSQL = sSQL.Replace("dddddd", ClsBaseClass.ClsBaseDataInfo.sAccID);
                            sSQL = sSQL.Replace("eeeeee", xmlBody.Count.ToString());
                            DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                            lID = ClsBaseDataInfo.ReturnObjectToLong(dt.Rows[0][0]);
                            lIDDetails = ClsBaseDataInfo.ReturnObjectToLong(dt.Rows[0][1]) - xmlBody.Count;

                            Model.PU_AppVouch model = new Model.PU_AppVouch();

                            model.iVTid = 8171;
                            model.ID = lID;
                            model.cCode = sCode;
                            model.dDate = dtmCode;
                            model.cDepCode = cDepCode;
                            model.cPersonCode = cPersonCode;
                            //model.cPTCode = "01";
                            model.cBusType = "普通采购";
                            model.cMaker = headNode.GetElementsByTagName("maker")[0].InnerText.Trim();
                            model.cMemo = headNode.GetElementsByTagName("memory")[0].InnerText.Trim();

                            model.cDefine13 = headNode.GetElementsByTagName("define1")[0].InnerText.Trim();
                            model.cDefine14 = headNode.GetElementsByTagName("define2")[0].InnerText.Trim();
                            model.cDefine11 = headNode.GetElementsByTagName("define3")[0].InnerText.Trim();
                            model.cDefine12 = headNode.GetElementsByTagName("define4")[0].InnerText.Trim();

                            model.cMakeTime = DateTime.Now;
                            model.csysbarcode = "||pupr|" + model.cCode;

                            DAL.PU_AppVouch dal = new ClsU8.DAL.PU_AppVouch();
                            sSQL = dal.Add(model);
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }



                        if (xmlHead != null)
                        {
                            int irowno = 0;
                            foreach (XmlElement bodyNode in xmlBody)
                            {
                                irowno += 1;
                                string inventorycode = bodyNode.GetElementsByTagName("inventorycode")[0].InnerText.Trim();
                                decimal quantity = ClsBaseClass.ClsBaseDataInfo.ReturnObjectToDecimal(bodyNode.GetElementsByTagName("quantity")[0].InnerText.Trim());
                                decimal num = ClsBaseClass.ClsBaseDataInfo.ReturnObjectToDecimal(bodyNode.GetElementsByTagName("num")[0].InnerText.Trim());
                                DateTime requiredate = Convert.ToDateTime(bodyNode.GetElementsByTagName("requiredate")[0].InnerText.Trim());

                                string sSQL = @"
select * from Inventory where cInvCode = '{0}'
";
                                sSQL = string.Format(sSQL, inventorycode);
                                DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                if (dtTemp == null || dtTemp.Rows.Count == 0)
                                {
                                    sErr = sErr + "存货" + inventorycode + "不存在";
                                }


                                if (quantity <= 0)
                                {
                                    sErr = sErr + "存货" + inventorycode + "请购数量必须大于0\n";
                                }

                                lIDDetails = lIDDetails + 1;

                                Model.PU_AppVouchs models = new ClsU8.Model.PU_AppVouchs();
                                models.ID = lID;
                                models.AutoID = lIDDetails;
                                models.cInvCode = inventorycode;
                                models.fQuantity = quantity;
                                if (num != 0)
                                {
                                    models.fNum = num;
                                    models.iExchRate = ClsBaseDataInfo.ReturnObjectToDecimal(models.fQuantity / models.fNum, 6);
                                }
                                else
                                {
                                    models.iExchRate = 1;
                                }

                                models.irowno = irowno;

                                models.dRequirDate = requiredate;
                                models.dArriveDate = requiredate;

                                models.iPerTaxRate = ClsBaseClass.ClsBaseDataInfo.ReturnObjectToDecimal(dtTemp.Rows[0]["iImpTaxRate"]);
                                models.bTaxCost = true;
                                models.ivouchrowno = irowno;
                                models.cbsysbarcode = "||pupr|" + sCode + "|" + irowno.ToString();

                                DAL.PU_AppVouchs dals = new ClsU8.DAL.PU_AppVouchs();
                                sSQL = dals.Add(models);
                                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                            }
                        }

                        if (sErr != "")
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
            catch (Exception error)
            {
                return "Err:" + error.Message;
            }
            return "OK";
        }
    }
}
