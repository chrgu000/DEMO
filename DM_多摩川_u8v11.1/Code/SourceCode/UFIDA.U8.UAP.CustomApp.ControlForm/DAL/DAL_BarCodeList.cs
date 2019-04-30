using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TH.BaseClass;
using System.Data;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public class DAL_BarCodeList
    {
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string BarCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from _BarCodeList");
            strSql.Append(" where BarCode='" + BarCode + "' ");
            return DbHelperSQL.Exists(strSql.ToString());
        }


//        /// <summary>
//        /// 条形码可用量
//        /// </summary>
//        /// <param name="sBarCode"></param>
//        /// <returns></returns>
//        public string sBarCodeQty(string sBarCode)
//        {
//            string sSQL = @"
//IF not EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_BarCodeQTyTemp]') AND type in (N'U'))
//DROP TABLE [dbo].[_BarCodeQTyTemp]
//
//CREATE TABLE [dbo].[_BarCodeQTyTemp](
//	[Qty] [decimal](18, 6) NULL,
//	[sType] [varchar](50) NULL,
//	[RdType] [int] NULL
//) ON [PRIMARY]
//
//else
//    delete _BarCodeQTyTemp
//
//insert into _BarCodeQTyTemp
//select b.Qty,b.sType,b.RdType
//from dbo._BarCodeList a inner join dbo._BarCodeRD b on a.BarCode = b.BarCode
//	inner join (select a.cCode,b.iRowno,b.autoid,b.cinvcode from rdrecord01 a inner join rdrecords01 b 
//			on a.id = b.id) c on b.ExsID = c.autoid and c.cCode = b.ExCode and c.iRowno = b.ExRowNo and c.cInvCode = b.cInvCode
//where b.sType = '采购入库单'
//	and isnull(a.valid,0) = 1 and isnull(a.Used,0) = 1 
//	and a.BarCode = '111111'
//	
//insert into _BarCodeQTyTemp
//select b.Qty,b.sType,b.RdType
//from dbo._BarCodeList a inner join dbo._BarCodeRD b on a.BarCode = b.BarCode
//	inner join (select a.cCode,b.iRowno,b.autoid,b.cinvcode from rdrecord11 a inner join rdrecords11 b 
//			on a.id = b.id) c on b.ExsID = c.autoid and c.cCode = b.ExCode and c.iRowno = b.ExRowNo and c.cInvCode = b.cInvCode
//where b.sType = '材料出库单'
//	and isnull(a.valid,0) = 1 and isnull(a.Used,0) = 1 
//	and a.BarCode = '111111'
//
//	
//insert into _BarCodeQTyTemp
//select b.Qty,b.sType,b.RdType
//from dbo._BarCodeList a inner join dbo._BarCodeRD b on a.BarCode = b.BarCode
//	inner join (select a.cCode,b.iRowno,b.autoid,b.cinvcode from rdrecord08 a inner join rdrecords08 b 
//			on a.id = b.id) c on b.ExsID = c.autoid and c.cCode = b.ExCode and c.iRowno = b.ExRowNo and c.cInvCode = b.cInvCode
//where b.sType = '其他入库单'
//	and isnull(a.valid,0) = 1 and isnull(a.Used,0) = 1 
//	and a.BarCode = '111111'
//
//
//insert into _BarCodeQTyTemp
//select b.Qty,b.sType,b.RdType
//from dbo._BarCodeList a inner join dbo._BarCodeRD b on a.BarCode = b.BarCode
//	inner join (select a.cCode,b.iRowno,b.autoid,b.cinvcode from rdrecord09 a inner join rdrecords09 b 
//			on a.id = b.id) c on b.ExsID = c.autoid and c.cCode = b.ExCode and c.iRowno = b.ExRowNo and c.cInvCode = b.cInvCode
//where b.sType = '其他出库单'
//	and isnull(a.valid,0) = 1 and isnull(a.Used,0) = 1 
//	and a.BarCode = '111111'
//	
//	
//insert into _BarCodeQTyTemp
//select b.Qty,b.sType,b.RdType
//from dbo._BarCodeList a inner join dbo._BarCodeRD b on a.BarCode = b.BarCode
//	inner join (select a.cCode,b.iRowno,b.autoid,b.cinvcode from rdrecord10 a inner join rdrecords10 b 
//			on a.id = b.id) c on b.ExsID = c.autoid and c.cCode = b.ExCode and c.iRowno = b.ExRowNo and c.cInvCode = b.cInvCode
//where b.sType = '产成品入库单'
//	and isnull(a.valid,0) = 1
//	and a.BarCode = '111111'
//	
//insert into _BarCodeQTyTemp
//select b.Qty,b.sType,b.RdType
//from dbo._BarCodeList a inner join dbo._BarCodeRD b on a.BarCode = b.BarCode
//	inner join (select a.cDLCode,b.iRowno,b.autoid,b.cinvcode from DispatchList a inner join DispatchLists b on a.DLID  = b.DLID ) c 
//		on b.ExsID = c.autoid and c.cDLCode = b.ExCode and c.iRowno = b.ExRowNo and c.cInvCode = b.cInvCode
//where b.sType = '销售发货单'
//	and isnull(a.valid,0) = 1 and isnull(a.Used,0) = 1 
//	and a.BarCode = '111111'
//	
//select sum(case when isnull(RDType,0) = 1 then Qty when  isnull(RDType,0) = 2 then -1 * Qty else 0 end) as Qty
//from _BarCodeQTyTemp a
//";
//            sSQL = sSQL.Replace("111111", sBarCode);
//            return sSQL;
//        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model_BarCodeList model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.BarCode != null)
            {
                strSql1.Append("BarCode,");
                strSql2.Append("'" + model.BarCode + "',");
            }
            if (model.ExsID != null)
            {
                strSql1.Append("ExsID,");
                strSql2.Append("" + model.ExsID + ",");
            }
            if (model.ExCode != null)
            {
                strSql1.Append("ExCode,");
                strSql2.Append("'" + model.ExCode + "',");
            }
            if (model.ExRowNo != null)
            {
                strSql1.Append("ExRowNo,");
                strSql2.Append("" + model.ExRowNo + ",");
            }
            if (model.ExType != null)
            {
                strSql1.Append("ExType,");
                strSql2.Append("'" + model.ExType + "',");
            }
            if (model.ExVenCode != null)
            {
                strSql1.Append("ExVenCode,");
                strSql2.Append("'" + model.ExVenCode + "',");
            }
            if (model.ExVenName != null)
            {
                strSql1.Append("ExVenName,");
                strSql2.Append("'" + model.ExVenName + "',");
            }
            if (model.ExDepCode != null)
            {
                strSql1.Append("ExDepCode,");
                strSql2.Append("'" + model.ExDepCode + "',");
            }
            if (model.ExDepName != null)
            {
                strSql1.Append("ExDepName,");
                strSql2.Append("'" + model.ExDepName + "',");
            }
            if (model.ExQuantity != null)
            {
                strSql1.Append("ExQuantity,");
                strSql2.Append("" + model.ExQuantity + ",");
            }
            if (model.ExBatchQty != null)
            {
                strSql1.Append("ExBatchQty,");
                strSql2.Append("" + model.ExBatchQty + ",");
            }
            if (model.cWhCode != null)
            {
                strSql1.Append("cWhCode,");
                strSql2.Append("'" + model.cWhCode + "',");
            }
            if (model.cWhName != null)
            {
                strSql1.Append("cWhName,");
                strSql2.Append("'" + model.cWhName + "',");
            }
            if (model.iQty != null)
            {
                strSql1.Append("iQty,");
                strSql2.Append("" + model.iQty + ",");
            }
            if (model.Batch != null)
            {
                strSql1.Append("Batch,");
                strSql2.Append("'" + model.Batch + "',");
            }
            if (model.SerialNO != null)
            {
                strSql1.Append("SerialNO,");
                strSql2.Append("'" + model.SerialNO + "',");
            }
            if (model.PosCode != null)
            {
                strSql1.Append("PosCode,");
                strSql2.Append("'" + model.PosCode + "',");
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
            //if (model.PrintCout != null)
            //{
            //    strSql1.Append("PrintCout,");
            //    strSql2.Append("" + model.PrintCout + ",");
            //}
            if (model.SysDate != null)
            {
                strSql1.Append("SysDate,");
                strSql2.Append("'" + model.SysDate + "',");
            }
            if (model.GUID != null)
            {
                strSql1.Append("GUID,");
                strSql2.Append("'" + model.GUID.ToString() + "',");
            }
            if (model.AFsID != null)
            {
                strSql1.Append("AFsID,");
                strSql2.Append("" + model.AFsID + ",");
            }
            if (model.AFCode != null)
            {
                strSql1.Append("AFCode,");
                strSql2.Append("'" + model.AFCode + "',");
            }
            if (model.AFRowNo != null)
            {
                strSql1.Append("AFRowNo,");
                strSql2.Append("" + model.AFRowNo + ",");
            }
            if (model.AFType != null)
            {
                strSql1.Append("AFType,");
                strSql2.Append("'" + model.AFType + "',");
            }
            if (model.AFVenCode != null)
            {
                strSql1.Append("AFVenCode,");
                strSql2.Append("'" + model.AFVenCode + "',");
            }
            if (model.AFVenName != null)
            {
                strSql1.Append("AFVenName,");
                strSql2.Append("'" + model.AFVenName + "',");
            }
            if (model.AFCusName != null)
            {
                strSql1.Append("AFCusName,");
                strSql2.Append("'" + model.AFCusName + "',");
            }
            if (model.AFCusCode != null)
            {
                strSql1.Append("AFCusCode,");
                strSql2.Append("'" + model.AFCusCode + "',");
            }
            if (model.AFQuantity != null)
            {
                strSql1.Append("AFQuantity,");
                strSql2.Append("" + model.AFQuantity + ",");
            }
            if (model.XBarCode != null)
            {
                strSql1.Append("XBarCode,");
                strSql2.Append("'" + model.XBarCode + "',");
            }
            if (model.cInvCode != null)
            {
                strSql1.Append("cInvCode,");
                strSql2.Append("'" + model.cInvCode + "',");
            }
            if (model.cInvName != null)
            {
                strSql1.Append("cInvName,");
                strSql2.Append("'" + model.cInvName + "',");
            }
            if (model.cInvStd != null)
            {
                strSql1.Append("cInvStd,");
                strSql2.Append("'" + model.cInvStd + "',");
            }
            if (model.valid != null)
            {
                strSql1.Append("valid,");
                strSql2.Append("" + (model.valid ? 1 : 0) + ",");
            }
            if (model.Used != null)
            {
                strSql1.Append("Used,");
                strSql2.Append("" + model.Used + ",");
            }
            if (model.BarCodeHis != null)
            {
                strSql1.Append("BarCodeHis,");
                strSql2.Append("'" + model.BarCodeHis + "',");
            }
            if (model.ExcPTCode != null)
            {
                strSql1.Append("ExcPTCode,");
                strSql2.Append("'" + model.ExcPTCode + "',");
            }
            if (model.ExcPTName != null)
            {
                strSql1.Append("ExcPTName,");
                strSql2.Append("'" + model.ExcPTName + "',");
            }
            if (model.ExcInvDefine3 != null)
            {
                strSql1.Append("ExcInvDefine3,");
                strSql2.Append("'" + model.ExcInvDefine3 + "',");
            }
            if (model.ExcComUnitName != null)
            {
                strSql1.Append("ExcComUnitName,");
                strSql2.Append("'" + model.ExcComUnitName + "',");
            }
            if (model.ExcMemo != null)
            {
                strSql1.Append("ExcMemo,");
                strSql2.Append("'" + model.ExcMemo + "',");
            }
            if (model.ExcInvDefine4 != null)
            {
                strSql1.Append("ExcInvDefine4,");
                strSql2.Append("'" + model.ExcInvDefine4 + "',");
            }
            if (model.ExcInvDefine5 != null)
            {
                strSql1.Append("ExcInvDefine5,");
                strSql2.Append("'" + model.ExcInvDefine5 + "',");
            }
            strSql.Append("insert into _BarCodeList(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            return (strSql.ToString());

        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public UFIDA.U8.UAP.CustomApp.ControlForm.Model_BarCodeList DataRowToModel(DataRow row)
        {
            UFIDA.U8.UAP.CustomApp.ControlForm.Model_BarCodeList model = new Model_BarCodeList();
            if (row != null)
            {
                if (row["iID"] != null && row["iID"].ToString() != "")
                {
                    model.iID = int.Parse(row["iID"].ToString());
                }
                if (row["BarCode"] != null)
                {
                    model.BarCode = row["BarCode"].ToString();
                }
                if (row["ExsID"] != null && row["ExsID"].ToString() != "")
                {
                    model.ExsID = int.Parse(row["ExsID"].ToString());
                }
                if (row["ExCode"] != null)
                {
                    model.ExCode = row["ExCode"].ToString();
                }
                if (row["ExRowNo"] != null && row["ExRowNo"].ToString() != "")
                {
                    model.ExRowNo = int.Parse(row["ExRowNo"].ToString());
                }
                if (row["ExType"] != null)
                {
                    model.ExType = row["ExType"].ToString();
                }
                if (row["ExVenCode"] != null)
                {
                    model.ExVenCode = row["ExVenCode"].ToString();
                }
                if (row["ExVenName"] != null)
                {
                    model.ExVenName = row["ExVenName"].ToString();
                }
                if (row["ExDepCode"] != null)
                {
                    model.ExDepCode = row["ExDepCode"].ToString();
                }
                if (row["ExDepName"] != null)
                {
                    model.ExDepName = row["ExDepName"].ToString();
                }
                if (row["ExQuantity"] != null && row["ExQuantity"].ToString() != "")
                {
                    model.ExQuantity = decimal.Parse(row["ExQuantity"].ToString());
                }
                if (row["ExBatchQty"] != null && row["ExBatchQty"].ToString() != "")
                {
                    model.ExBatchQty = decimal.Parse(row["ExBatchQty"].ToString());
                }
                if (row["cWhCode"] != null)
                {
                    model.cWhCode = row["cWhCode"].ToString();
                }
                if (row["cWhName"] != null)
                {
                    model.cWhName = row["cWhName"].ToString();
                }
                if (row["iQty"] != null && row["iQty"].ToString() != "")
                {
                    model.iQty = decimal.Parse(row["iQty"].ToString());
                }
                if (row["Batch"] != null)
                {
                    model.Batch = row["Batch"].ToString();
                }
                if (row["SerialNO"] != null)
                {
                    model.SerialNO = row["SerialNO"].ToString();
                }
                if (row["PosCode"] != null)
                {
                    model.PosCode = row["PosCode"].ToString();
                }
                if (row["CreateUserName"] != null)
                {
                    model.CreateUserName = row["CreateUserName"].ToString();
                }
                if (row["CreateDate"] != null && row["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
                }
                //if (row["PrintCout"] != null && row["PrintCout"].ToString() != "")
                //{
                //    model.PrintCout = int.Parse(row["PrintCout"].ToString());
                //}
                if (row["SysDate"] != null && row["SysDate"].ToString() != "")
                {
                    model.SysDate = DateTime.Parse(row["SysDate"].ToString());
                }
                if (row["GUID"] != null && row["GUID"].ToString() != "")
                {
                    model.GUID = new Guid(row["GUID"].ToString());
                }
                if (row["AFsID"] != null && row["AFsID"].ToString() != "")
                {
                    model.AFsID = int.Parse(row["AFsID"].ToString());
                }
                if (row["AFCode"] != null)
                {
                    model.AFCode = row["AFCode"].ToString();
                }
                if (row["AFRowNo"] != null && row["AFRowNo"].ToString() != "")
                {
                    model.AFRowNo = int.Parse(row["AFRowNo"].ToString());
                }
                if (row["AFType"] != null)
                {
                    model.AFType = row["AFType"].ToString();
                }
                if (row["AFVenCode"] != null)
                {
                    model.AFVenCode = row["AFVenCode"].ToString();
                }
                if (row["AFVenName"] != null)
                {
                    model.AFVenName = row["AFVenName"].ToString();
                }
                if (row["AFCusName"] != null)
                {
                    model.AFCusName = row["AFCusName"].ToString();
                }
                if (row["AFCusCode"] != null)
                {
                    model.AFCusCode = row["AFCusCode"].ToString();
                }
                if (row["AFQuantity"] != null && row["AFQuantity"].ToString() != "")
                {
                    model.AFQuantity = decimal.Parse(row["AFQuantity"].ToString());
                }
                if (row["XBarCode"] != null)
                {
                    model.XBarCode = row["XBarCode"].ToString();
                }
                if (row["cInvCode"] != null)
                {
                    model.cInvCode = row["cInvCode"].ToString();
                }
                if (row["cInvName"] != null)
                {
                    model.cInvName = row["cInvName"].ToString();
                }
                if (row["cInvStd"] != null)
                {
                    model.cInvStd = row["cInvStd"].ToString();
                }
                if (row["Used"] != null && row["Used"].ToString() != "")
                {
                    model.Used = int.Parse(row["Used"].ToString());
                }
                if (row["valid"] != null && row["valid"].ToString() != "")
                {
                    if ((row["valid"].ToString() == "1") || (row["valid"].ToString().ToLower() == "true"))
                    {
                        model.valid = true;
                    }
                    else
                    {
                        model.valid = false;
                    }
                }
                if (row["BarCodeHis"] != null)
                {
                    model.BarCodeHis = row["BarCodeHis"].ToString();
                }

                if (row["ExcPTCode"] != null)
                {
                    model.ExcPTCode = row["ExcPTCode"].ToString();
                }
                if (row["ExcPTName"] != null)
                {
                    model.ExcPTName = row["ExcPTName"].ToString();
                }
                if (row["ExcInvDefine3"] != null)
                {
                    model.ExcInvDefine3 = row["ExcInvDefine3"].ToString();
                }
                if (row["ExcComUnitName"] != null)
                {
                    model.ExcComUnitName = row["ExcComUnitName"].ToString();
                }
                if (row["ExcMemo"] != null)
                {
                    model.ExcMemo = row["ExcMemo"].ToString();
                }
                if (row["ExcInvDefine4"] != null)
                {
                    model.ExcInvDefine4 = row["ExcInvDefine4"].ToString();
                }
                if (row["ExcInvDefine5"] != null)
                {
                    model.ExcInvDefine5 = row["ExcInvDefine5"].ToString();
                }
            }
            return model;
        }
    }
}
