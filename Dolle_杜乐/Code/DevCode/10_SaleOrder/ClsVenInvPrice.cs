using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SaleOrder
{
    public class ClsVenInvPrice
    {
        //TH.BaseClsInfo.ClsDataBase clsSQL = TH.BaseClsInfo.ClsDataBaseFactory.Instance();
        FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();

        /// <summary>
        /// 供应商价格表
        /// </summary>
        /// <param name="isupplytype">供应类型：采购 1；委外 2</param>
        /// <returns></returns>
        public DataTable GetPrice(int isupplytype)
        {
            //string sSQL = " select *,v.iunitprice as iUnitPrice,v.itaxunitprice as iTaxPrice from " +
            //                "( " +
            //                "select max(Autoid) as Autoid from @u8.ven_inv_price group by cvencode,cInvCode " +
            //                ") vT left join @u8.ven_inv_price v on v.Autoid = vT.autoid  " +
            //                " left join @u8.vendor vd on vd.cVenCode = v.cVenCode " +
            //                "where v.iSupplyType = '" + isupplytype + "' " +
            //                "order by v.iunitprice,v.Autoid";

            string sSQL = @"
 select *,v.iunitprice as iUnitPrice,v.itaxunitprice as iTaxPrice 
 from ( 
 
			select max(dEnableDate) as dEnableDate,cvencode,cInvCode  
			from @u8.ven_inv_price where iSupplyType =  '{0}' 
			group by cvencode,cInvCode 
			
		) vT left join @u8.ven_inv_price v on v.dEnableDate = vT.dEnableDate and v.cInvCode = vt.cInvCode and v.cVenCode = vt.cVenCode
		left join @u8.vendor vd on vd.cVenCode = v.cVenCode 
 where v.iSupplyType = '{0}' 
 order by v.iunitprice,v.Autoid
";
            sSQL = string.Format(sSQL, isupplytype);
            return clsSQLCommond.ExecQuery(sSQL);

        }

        public DataTable GetVenHavPrice(int isupplytype, string cInvCode)
        {
            string sSQL = "select distinct vT.cInvCode,vT.cVenCode,vd.cVenName,vd.cVenAbbName from " +
                        "( " +
                        "select max(dEnableDate) as dEnableDate,cInvCode,cVenCode " +
                        "from @u8.ven_inv_price " +
                        "where cInvCode = '" + cInvCode + "' and iSupplyType = " + isupplytype + " " +
                        "group by cInvCode,cVenCode " +
                        ") vT left join @u8.vendor vd on vd.cVenCode = vT.cVenCode  " +
                        "order by vT.cVenCode";

            return clsSQLCommond.ExecQuery(sSQL);
        }
    }
}
