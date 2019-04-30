using System;
using System.Collections.Generic;
using System.Text;
using Test.localhost;
using System.Xml;

namespace Test
{
    class ClsUseWebService
    {
        DBWebService DBWebService = new DBWebService();

        public ClsUseWebService()
        {
            //DBWebService.Url = "http://172.23.173.163:8080/DBService.asmx";
            DBWebService.Url = "http://localhost:18080/GDJ/DBService.asmx";
        }


        public string InsertCustomer(string sXML)
        {
            string s = DBWebService.InsertCustomer(sXML);
            return s;
        }


        public string InsertVendor(string sXML)
        {
            string s = DBWebService.InsertVendor(sXML);
            return s;
        }


        public string InsertItem(string sXML)
        {
            string s = DBWebService.InsertItem(sXML);
            return s;
        }

        public string GetApCloseBill_IN(string sXML)
        {
            string s = DBWebService.GetApCloseBill_IN(sXML);
            return s;
        }

        public string GetApCloseBill_OUT(string sXML)
        {
            string s = DBWebService.GetApCloseBill_OUT(sXML);
            return s;
        }

        public string GetProCost(string sXML)
        {
            string s = DBWebService.GetProCost(sXML);
            return s;
        }
    }
}
