using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace 系统服务
{
    public static class 序号
    {
        static string sSQL;
        #region 序号增加
        public static long GetMaxID(string type)
        {
            sSQL = @"declare @id int
            if exists( select * from _Identity where cVouchType=1111) 
            update _Identity set @id=iId=(iId+1) where cVouchType=1111
            else
            begin
            insert _Identity(cVouchType,iId) values(1111,1)
            set @id=1
            end
            select @id";
            sSQL = sSQL.Replace("1111", "'" + type + "'");
            return Conn.Long(sSQL);
        }

        public static string GetMaxCodeRD(string type)
        {
            sSQL = @"declare @id int
            if exists( select * from _Identity where cVouchType=1111) 
            update _Identity set @id=iId=(iId+1) where cVouchType=1111
            else
            begin
            insert _Identity(cVouchType,iId) values(1111,1)
            set @id=1
            end
            select 'RD'+convert(nvarchar,right(datepart(YYYY,GETDATE()),2))+convert(nvarchar,datepart(mm,GETDATE()))+right(convert(nvarchar,datepart(mm,GETDATE()))+'00000'+@id,4)";
            sSQL = sSQL.Replace("1111", "'" + type + "'");
            return Conn.String(sSQL);
        }

        public static string GetMaxCode_SO(string type)
        {
            sSQL = @"declare @id int
            if exists( select * from _Identity where cVouchType=1111) 
            update _Identity set @id=iId=(iId+1) where cVouchType=1111
            else
            begin
            insert _Identity(cVouchType,iId) values(1111,1)
            set @id=1
            end
            select 'SOOUT'+convert(nvarchar,right(datepart(YYYY,GETDATE()),2))+convert(nvarchar,datepart(mm,GETDATE()))+right(convert(nvarchar,datepart(mm,GETDATE()))+'00000'+@id,4)";
            sSQL = sSQL.Replace("1111", "'" + type + "'");
            return Conn.String(sSQL);
        }

        public static void SetMaxID()
        {
            sSQL = @"--更新最大编码
declare @id int
declare @Autoid int

select MAX(ID) as ID,MAX(AutoId) AutoId into #AutoId from RdRecords11 
insert into #AutoId select MAX(ID),MAX(AutoId) from RdRecords12 
insert into #AutoId select MAX(ID),MAX(AutoId) from RdRecords13
insert into #AutoId select MAX(ID),MAX(AutoId) from RdRecords15 

insert into #AutoId select MAX(ID),MAX(AutoId) from RdRecords01 
insert into #AutoId select MAX(ID),MAX(AutoId) from RdRecords02 
insert into #AutoId select MAX(ID),MAX(AutoId) from RdRecords03 
insert into #AutoId select MAX(ID),MAX(AutoId) from RdRecords05 

select @id=MAX(ID),@Autoid=MAX(AutoId) from #AutoId

if exists( select * from _Identity where cVouchType='RD') 
update _Identity set iId=@id where cVouchType='RD'
else
begin
insert _Identity(cVouchType,iId) values('RD',@id)
end

if exists( select * from _Identity where cVouchType='RDS') 
update _Identity set iId=@Autoid where cVouchType='RDS'
else
begin
insert _Identity(cVouchType,iId) values('RDS',@Autoid)
end";
            Conn.Update(sSQL);
        }
        #endregion

        /// <summary>
        /// 得到连续的序列号
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="FieldName"></param>
        /// <param name="sID"></param>
        /// <returns></returns>
        public static string GetNewSerialNumberContinuous(string TableName, string FieldName)
        {
            sSQL = "select * from SerialNumberContinuous where TableID='" + TableName + "' and Code='" + FieldName + "'";
            DataTable dts = Conn.DataTable(sSQL);
            string left = "";
            string middle = "";
            string right = "";
            if (dts.Rows[0]["LeftType"].ToString() != "")
            {
                left = dts.Rows[0]["LeftType"].ToString();
            }
            if (dts.Rows[0]["MiddleType"].ToString() == "DateTime")
            {
                middle = DateTime.Now.ToString("yyMM");
            }
            sSQL = "select max(convert(int ,SUBSTRING(" + FieldName + ",len('" + left + middle + "')+1," + dts.Rows[0]["RightType"].ToString().Length + "+1))) from  " + TableName + " where left(" + FieldName + ",len('" + left + middle + "'))='" + left + middle + "'";
            DataTable dt = Conn.DataTable(sSQL);

            if (dt.Rows[0][0].ToString() != "0")
            {
                right = dt.Rows[0][0].ToString();
                int iright = 1;
                if (right != "")
                {
                    //right = right.Substring(left.Length + middle.Length, dts.Rows[0]["RightType"].ToString().Length);
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
