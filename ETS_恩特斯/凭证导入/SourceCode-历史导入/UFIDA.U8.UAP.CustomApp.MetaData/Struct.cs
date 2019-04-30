using System;
using System.Collections.Generic;
using System.Text;

namespace UFIDA.U8.UAP.CustomApp.MetaData
{
    public class CheckData
    {
        public string BarCode {get;set;}
        public decimal CheckQty {get;set;}
        public decimal BadQty {get;set;}
        public string Status { get; set; }

    }
    public class ImportData
    {
        public string CheckerName { get; set; }
        public DateTime CheckDate { get; set; }
        public string WareHouse { get; set; }

        public List <CheckData > CheckDatas {get;set;}
    }
}
