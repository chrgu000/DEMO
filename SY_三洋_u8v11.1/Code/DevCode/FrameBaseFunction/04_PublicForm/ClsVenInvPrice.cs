using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace FrameBaseFunction
{
    public class ClsVenInvPrice
    {
        FrameBaseFunction.ClsDataBase clsSQL = FrameBaseFunction.ClsDataBaseFactory.Instance();

        /// <summary>
        /// 供应商价格表
        /// </summary>
        /// <param name="isupplytype">供应类型：采购 1；委外 2</param>
        /// <returns></returns>
        public DataTable GetPrice(int isupplytype)
        {
            //string sSQL = "select a.*,b.iunitprice as iUnitPrice,b.itaxunitprice as iTaxPrice,b.itaxrate  from " +
            //                    "(select max(dstartdate) as dstartdate,cvencode,cvenname,cInvcode,cinvname,cinvstd,ccomunitcode,ccomunitname,cexch_name from @u8.pu_veninvpricelst " +
            //                    "where isupplytype = " + isupplytype + " and '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "' < isnull(ddisabledate,'2099-12-31')  " +
            //                    "group by cvencode,cvenname,cInvcode,cinvname,cinvstd,ccomunitcode,ccomunitname,cexch_name " +
            //                    ") a  " +
            //                        "inner join @u8.pu_veninvpricelst b on a.cInvCode=b.cInvCode and a.cvencode=b.cvencode  and a.dstartdate = b.dstartdate " +
            //                    "where b.isupplytype = " + isupplytype + "  " +
            //                    "order by  a.cvencode,a.cInvcode";

            string sSQL = " select *,v.iunitprice as iUnitPrice,v.itaxunitprice as iTaxPrice from " +
                            "( " +
                            "select max(Autoid) as Autoid from @u8.ven_inv_price group by cvencode,cInvCode " +
                            ") vT left join @u8.ven_inv_price v on v.Autoid = vT.autoid  " + 
                            " left join @u8.vendor vd on vd.cVenCode = v.cVenCode "+
                            "where v.iSupplyType = '" + isupplytype + "' " +
                            "order by v.iunitprice,v.Autoid";
            return clsSQL.ExecQuery(sSQL);
        
        }

        public DataTable GetVenHavPrice(int isupplytype,string cInvCode)
        {
            string sSQL = "select distinct vT.cInvCode,vT.cVenCode,vd.cVenName,vd.cVenAbbName from " +
                        "( " +
                        "select max(dEnableDate) as dEnableDate,cInvCode,cVenCode " +
                        "from @u8.ven_inv_price " +
                        "where cInvCode = '" + cInvCode + "' and iSupplyType = " + isupplytype + " " +
                        "group by cInvCode,cVenCode " +
                        ") vT left join @u8.vendor vd on vd.cVenCode = vT.cVenCode  " +
                        "order by vT.cVenCode";
            return clsSQL.ExecQuery(sSQL);
        }
    }
}
