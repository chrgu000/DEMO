using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ClsBaseClass;

namespace ClsU8
{
    public class SerialNumber
    {
        ClsDataBase clsSQLCommond = ClsDataBaseFactory.Instance();
        public string GetNewSerialNumberContinuous(string TableName, string FieldName)
        {
            string sSQL = string.Concat(new string[]
			{
				"select * from SerialNumberContinuous where TableID='",
				TableName,
				"' and Code='",
				FieldName,
				"'"
			});
            DataTable dts = clsSQLCommond.ExecQuery(sSQL);
            string left = "";
            string middle = "";
            if (dts.Rows[0]["LeftType"].ToString() != "")
            {
                left = dts.Rows[0]["LeftType"].ToString();
            }
            if (dts.Rows[0]["MiddleType"].ToString() == "DateTime")
            {
                middle = DateTime.Now.ToString("yyMM");
            }
            sSQL = string.Concat(new object[]
			{
				"select max(convert(int ,SUBSTRING(",
				FieldName,
				",len('",
				left,
				middle,
				"')+1,",
				dts.Rows[0]["RightType"].ToString().Length,
				"+1))) from  ",
				TableName,
				" where left(",
				FieldName,
				",len('",
				left,
				middle,
				"'))='",
				left,
				middle,
				"'"
			});
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            string right;
            if (dt.Rows[0][0].ToString() != "0")
            {
                right = dt.Rows[0][0].ToString();
                int iright = 1;
                if (right != "")
                {
                    iright = int.Parse(right) + 1;
                }
                right = GetIsEnoughNumber(iright, dts.Rows[0]["RightType"].ToString().Length);
            }
            else
            {
                right = GetIsEnoughNumber(1, dts.Rows[0]["RightType"].ToString().Length);
            }
            return left + middle + right;
        }
        private static string GetIsEnoughNumber(int number, int len)
        {
            return number.ToString().PadLeft(len, '0');
        }
    }
}
