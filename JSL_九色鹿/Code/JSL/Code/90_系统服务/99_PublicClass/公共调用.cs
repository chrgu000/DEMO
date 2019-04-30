using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace 系统服务
{
    public class 公共调用
    {
        string sSQL = "";
        系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
        public 公共调用()
        {
        }

        #region 换算率和税率
        public decimal iinvexchrate(string invocde)
        {

            sSQL = "select 换算率 from Inventory where cInvCode='" + invocde + "'";
            decimal d换算率 = ReturnDecimal(clsSQLCommond.ExecGetScalar(sSQL));
            return d换算率;
        }
        #endregion

        #region 每盒含税单价
        public decimal PriceAdjust(string cInvCode, string cCusCode)
        {
            sSQL = @"select b.D1 from PriceAdjust_Details b left join PriceAdjust_Main a on a.ID=b.ID left join Customer c on b.S2=c.S4 where b.B1=1 
and b.S1='" + cInvCode + "' and c.cCusCode='" + cCusCode + "' and a.dVerifysysTime is not null  order by a.dDate desc";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt.Rows.Count > 0)
            {
                return ReturnDecimal(dt.Rows[0]["D1"]);
            }
            else
            {
                sSQL = @"select b.D1 from PriceAdjust_Details b left join PriceAdjust_Main a on a.ID=b.ID left join Customer c on b.S2=c.S4 where (b.B1<>1 or b.B1 is null ) 
and b.S1='" + cInvCode + "' and c.cCusCode='" + cCusCode + "' and a.dVerifysysTime is not null  order by a.dDate desc";
                DataTable dts = clsSQLCommond.ExecQuery(sSQL);
                if (dts.Rows.Count > 0)
                {
                    return ReturnDecimal(dts.Rows[0]["D1"]);
                }
            }
            return 0;
        }
        #endregion

        #region 现存量
        public decimal Get现存量(string cInvCode, string M1)
        {
            sSQL = @"

select dDate,cRSCode,Flag,cInvCode,M1,M2,cWhCode,cPosCode,sum(iQuantity) as iQuantity,sum(iMoney) as iMoney,sum(sBoxQty) as sBoxQty,0 as cpsBoxQty into #rd from RdRecord01 a inner join RdRecords01 b on a.ID=b.ID 
where  dVerifysysPerson is not null group by dDate,cRSCode,Flag,cInvCode,M1,M2,cWhCode,cPosCode

insert into #rd select dDate,cRSCode,Flag,cInvCode,M1,M2,cWhCode,cPosCode,sum(iQuantity) as iQuantity,sum(iMoney) as iMoney,sum(sBoxQty) as sBoxQty,0 as cpsBoxQty from RdRecord02 a inner join RdRecords02 b on a.ID=b.ID 
where 1=1 and dVerifysysPerson is not null group by dDate,cRSCode,Flag,cInvCode,M1,M2,cWhCode,cPosCode

insert into #rd select dDate,cRSCode,Flag,cInvCode,M1,M2,cWhCode,cPosCode,sum(iQuantity) as iQuantity,sum(iMoney) as iMoney,sum(sBoxQty) as sBoxQty,sum(sBoxQty) as cpsBoxQty from RdRecord03 a inner join RdRecords03 b on a.ID=b.ID 
where  1=1 and dVerifysysPerson is not null group by dDate,cRSCode,Flag,cInvCode,M1,M2,cWhCode,cPosCode

insert into #rd select dDate,cRSCode,Flag,cInvCode,M1,M2,cWhCode,cPosCode,sum(iQuantity) as iQuantity,sum(iMoney) as iMoney,sum(sBoxQty) as sBoxQty,0 as cpsBoxQty from RdRecord05 a inner join RdRecords05 b on a.ID=b.ID 
where  1=1 and dVerifysysPerson is not null group by dDate,cRSCode,Flag,cInvCode,M1,M2,cWhCode,cPosCode

insert into #rd select dDate,cRSCode,Flag,cInvCode,M1,M2,cWhCode,cPosCode,sum(iQuantity) as iQuantity,sum(iMoney) as iMoney,sum(sBoxQty) as sBoxQty,0 as cpsBoxQty from RdRecord11 a inner join RdRecords11 b on a.ID=b.ID 
where 1=1 and dVerifysysPerson is not null group by dDate,cRSCode,Flag,cInvCode,M1,M2,cWhCode,cPosCode

insert into #rd select dDate,cRSCode,Flag,cInvCode,M1,M2,cWhCode,cPosCode,sum(iQuantity) as iQuantity,sum(iMoney) as iMoney,sum(sBoxQty) as sBoxQty,0 as cpsBoxQty from RdRecord12 a inner join RdRecords12 b on a.ID=b.ID 
where 1=1 and dVerifysysPerson is not null group by dDate,cRSCode,Flag,cInvCode,M1,M2,cWhCode,cPosCode

insert into #rd select dDate,cRSCode,Flag,cInvCode,M1,M2,cWhCode,cPosCode,sum(iQuantity) as iQuantity,sum(iMoney) as iMoney,sum(sBoxQty) as sBoxQty,sum(sBoxQty) as cpsBoxQty from RdRecord13 a inner join RdRecords13 b on a.ID=b.ID 
where 1=1 and dVerifysysPerson is not null group by dDate,cRSCode,Flag,cInvCode,M1,M2,cWhCode,cPosCode

insert into #rd select dDate,cRSCode,Flag,cInvCode,M1,M2,cWhCode,cPosCode,sum(iQuantity) as iQuantity,sum(iMoney) as iMoney,sum(sBoxQty) as sBoxQty,0 as cpsBoxQty from RdRecord15 a inner join RdRecords15 b on a.ID=b.ID 
where 1=1 and dVerifysysPerson is not null group by dDate,cRSCode,Flag,cInvCode,M1,M2,cWhCode,cPosCode

select 
cInvCode,M1,
sum(case when r.收发标志=0 then sBoxQty else -sBoxQty end) as sBoxQty
from #rd a left join RdStyle r on a.cRSCode=r.cRSCode 
where 1=1  group by cInvCode,M1
";

            if (cInvCode != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and cInvCode='" + cInvCode + "'");
            }
            if (M1 != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and M1='" + M1 + "'");
            }
            DataTable dtnow = clsSQLCommond.ExecQuery(sSQL);
            if (dtnow.Rows.Count > 0)
            {
                return ReturnDecimal(dtnow.Rows[0]["sBoxQty"]);
            }
            return 0;
        }

        public decimal Get现存量(string cInvCode, string M1, string M2)
        {
            sSQL = @"
select '入库单' as 类别,cInvCode,a.cRSCode,cMSCode,M1,M2,
case when c.收发标志=0 then iQuantity else -iQuantity end iQuantity,
case when c.收发标志=0 then sBoxQty else -sBoxQty end sBoxQty into #a from RdRecord a inner join RdRecords b on a.ID=b.ID 
left join RdStyle c on a.cRSCode=c.cRSCode 
where 1=1 and dVerifysysPerson is not null      

union all 

select  '销售出库' as 类别,cInvCode,null,null,M1,M2,-iQuantity,-sBoxQty from RdRecord13 a inner join RdRecords13 b on a.ID=b.ID 
where 1=1 and dVerifysysPerson is not null 

select cInvCode,M1,M2,sum(sBoxQty) as sBoxQty from #a  group by cInvCode,M1,M2 
";
            if (cInvCode != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and cInvCode='" + cInvCode + "'");
            }
            if (M1 != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and M1='" + M1 + "'");
            }
            if (M2 != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and M2='" + M2 + "'");
            }
            DataTable dtnow = clsSQLCommond.ExecQuery(sSQL);
            if (dtnow.Rows.Count > 0)
            {
                return ReturnDecimal(dtnow.Rows[0]["sBoxQty"]);
            }
            return 0;
        }
        #endregion

        #region 期初现存量
        public decimal Get期初现存量(string cInvCode, string M1, string M2)
        {
            sSQL = @"
select cInvCode,a.cRSCode,cMSCode,M1,M2,case when c.收发标志=0 then sBoxQty else -sBoxQty end sBoxQty into #a from RdRecord05 a inner join RdRecords05 b on a.ID=b.ID 
left join RdStyle c on a.cRSCode=c.cRSCode 
where 1=1  and a.cRSCode in('0502')

insert into #a select cInvCode,a.cRSCode,cMSCode,M1,M2,case when c.收发标志=0 then sBoxQty else -sBoxQty end sBoxQty  from RdRecord15 a inner join RdRecords15 b on a.ID=b.ID 
left join RdStyle c on a.cRSCode=c.cRSCode 
where 1=1 and a.cRSCode in('1502')

insert into #a select cInvCode,a.cRSCode,cMSCode,M1,M2,case when c.收发标志=0 then sBoxQty else -sBoxQty end sBoxQty  from RdRecord11 a inner join RdRecords11 b on a.ID=b.ID 
left join RdStyle c on a.cRSCode=c.cRSCode 
where 1=1 and a.cRSCode in('1101')

select cInvCode,M1,M2,sum(sBoxQty) as sBoxQty from #a where  1=1 group by cInvCode,M1 ,M2
";
            if (cInvCode != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and cInvCode='" + cInvCode + "'");
            }
            if (M1 != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and M1='" + M1 + "'");
            }
            if (M2 != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and M2='" + M2 + "'");
            }
            DataTable dtnow = clsSQLCommond.ExecQuery(sSQL);
            if (dtnow.Rows.Count > 0)
            {
                return ReturnDecimal(dtnow.Rows[0]["sBoxQty"]);
            }
            return 0;
        }
        #endregion

        #region 序号
        /// <summary>
        /// 得到新的序号
        /// </summary>
        /// <param name="表名"></param>
        /// <param name="字段名"></param>
        /// <param name="上层编码"></param>
        /// <returns></returns>
        public string GetNewSerialNumber(string TableName, string FieldName, string sID)
        {
            sSQL = "select * from SerialNumber where TableID='" + TableName + "'";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            string[] type = dt.Rows[0]["Type"].ToString().Split('-');
            int len = 0;
            int cen = 0;
            for (int i = 0; i < type.Length; i++)
            {
                cen = i + 1;
                if (len >= sID.Length)
                {
                    i = type.Length;
                }
                else
                {
                    len = len + int.Parse(type[i]);
                }

            }

            sSQL = "select * from " + TableName + " where TableCode like '" + sID + "%' and TableCode <> '" + sID + "' and len(TableCode)=" + len + " order by TableCode";


            DataTable dts = clsSQLCommond.ExecQuery(sSQL);
            if (dts.Rows.Count > 0)
            {
                string number = dts.Rows[dts.Rows.Count - 1][FieldName].ToString();
                number = number.Substring(sID.Length, number.Length);
                return sID + GetIsEnoughNumber(int.Parse(number), int.Parse(type[cen + 1]));
            }
            else
            {
                return sID + GetIsEnoughNumber(1, int.Parse(type[cen + 1]));
            }
        }

        private string GetIsEnoughNumber(int number, int len)
        {
            return number.ToString().PadLeft(len, '0');
        }

        public string GetSerialNumberRules(string TableName, string FieldName)
        {
            sSQL = "select * from SerialNumber where TableID='" + TableName + "' and Code='" + FieldName + "'";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt.Rows.Count > 0 && dt.Rows[0]["Type"].ToString() != "")
            {
                return dt.Rows[0]["Type"].ToString();
            }
            else
            {
                return "";
            }
        }


        /// <summary>
        /// 得到树状结构
        /// </summary>
        /// <param name="treeList1"></param>
        /// <param name="TableID"></param>
        /// <param name="TopName"></param>
        public void GetTree(DevExpress.XtraTreeList.TreeList treeList1, string TableID, string FieldName, string TopName)
        {
            try
            {
                treeList1.ClearNodes();
            }
            catch
            {
            }
            sSQL = "select * from SerialNumber where TableID='" + TableID + "' and Code='" + FieldName + "'";
            DataTable dts = clsSQLCommond.ExecQuery(sSQL);
            string Code = dts.Rows[0]["Code"].ToString();
            string Name = dts.Rows[0]["Name"].ToString();


            sSQL = "select * from " + TableID + "  order by " + Code;
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            string 序列号规则 = GetSerialNumberRules(TableID, FieldName);
            string[] 序列号规则数组 = 序列号规则.Split('-');
            int top = 序列号规则数组[0].Length;

            object[] obj1 = new object[2];
            obj1[0] = TopName;
            obj1[1] = "";
            DevExpress.XtraTreeList.Nodes.TreeListNode tn1 = treeList1.AppendNode(obj1, null);
            tn1.Tag = "";

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][Code].ToString().Length == top)
                {
                    object[] obj = new object[2];
                    obj[0] = dt.Rows[i][Code].ToString().Trim();
                    obj[1] = dt.Rows[i][Name].ToString().Trim();
                    DevExpress.XtraTreeList.Nodes.TreeListNode tn = treeList1.AppendNode(obj, tn1);
                    tn.Tag = dt.Rows[i][Code].ToString();
                    GetTreeNode(treeList1, tn, dt, Code, Name, 序列号规则数组, 1, top + 序列号规则数组[1].Length);
                }
            }
            //if (treeList1.FocusedNode != null)
            //{
            //    try
            //    {
            //        treeList1.FocusedNode = null;
            //    }
            //    catch
            //    {
            //    }
            //}
        }

        private void DeleteTreeListNode(DevExpress.XtraTreeList.Nodes.TreeListNode tn)
        {
            for (int i = tn.Nodes.Count - 1; i >= 0; i--)
            {
                if (tn.Nodes[i].Nodes.Count > 0)
                {
                    DeleteTreeListNode(tn.Nodes[i]);
                }
                tn.TreeList.DeleteNode(tn.Nodes[i]);
            }
        }

        private void GetTreeNode(DevExpress.XtraTreeList.TreeList treeList1, DevExpress.XtraTreeList.Nodes.TreeListNode tn, DataTable dt, string Code, string Name, string[] seq, int lev, int len)
        {
            if (tn.Tag.ToString().Trim() != "")
            {
                DataRow[] dw = dt.Select(Code + " like '" + tn.Tag.ToString().Trim() + "%' and len(" + Code + ")=" + len);
                for (int i = 0; i < dw.Length; i++)
                {
                    object[] obj = new object[2];
                    obj[0] = dw[i][Code].ToString().Trim();
                    obj[1] = dw[i][Name].ToString().Trim();
                    DevExpress.XtraTreeList.Nodes.TreeListNode tn1 = treeList1.AppendNode(obj, tn);
                    tn1.Tag = dw[i][Code].ToString();
                    if (seq.Length > lev + 1)
                    {
                        GetTreeNode(treeList1, tn1, dt, Code, Name, seq, lev + 1, len + seq[lev + 1].Length);
                    }
                }
            }
        }

        /// <summary>
        /// 判断编码原则    -- TH 2012-12-25 20:52
        /// </summary>
        /// <param name="TableID"></param>
        /// <param name="Code"></param>
        /// <param name="thisID"></param>
        /// <returns></returns>
        public string CheckSerialNumber(string TableID, string thisID)
        {
            sSQL = "SELECT TableID, TableName, Code, Name, Type FROM SerialNumber where TableID = '" + TableID + "'";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            string sType = dt.Rows[0]["Type"].ToString().Trim();

            int iLength = thisID.Trim().Length;
            string[] sList = sType.Split('-');

            int i编码规则长度 = 0;
            string oldID = "";
            for (int i = 0; i < sList.Length; i++)
            {
                i编码规则长度 = i编码规则长度 + sList[i].Length;
                if (i编码规则长度 < iLength)
                {
                    oldID = thisID.Substring(0, i编码规则长度);
                }
                if (i编码规则长度 == iLength)
                {
                    break;
                }
                if (i编码规则长度 > iLength)
                {
                    return "编码长度不符合编码原则";
                }
            }
            if (iLength > i编码规则长度)
            {
                return "编码长度超出编码原则";
            }

            int iCou = 0;
            switch (TableID.ToLower())
            {
                case "inventoryclass":
                    sSQL = "select count(1) from dbo.InventoryClass where cInvClassCode = '" + thisID + "'";
                    iCou = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
                    if (iCou == 1)
                    {
                        return thisID + "已经存在\n";
                    }
                    if (thisID.Length > sList[0].Length)
                    {
                        sSQL = "select count(1) from dbo.InventoryClass where cInvClassCode = '" + oldID + "'";
                        iCou = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
                        if (iCou == 0)
                        {
                            return thisID + "没有上级编码\n";
                        }
                    }
                    break;
                case "dealerclass":
                    sSQL = "select count(1) from dbo.DealerClass where cDCode = '" + thisID + "'";
                    iCou = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
                    if (iCou == 1)
                    {
                        return thisID + "已经存在\n";
                    }
                    if (thisID.Length > sList[0].Length)
                    {
                        sSQL = "select count(1) from dbo.DealerClass where cDCode = '" + oldID + "'";
                        iCou = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
                        if (iCou == 0)
                        {
                            return thisID + "没有上级编码\n";
                        }
                    }
                    break;
                case "customerclass":
                    sSQL = "select count(1) from dbo.CustomerClass where cCCode = '" + thisID + "'";
                    iCou = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
                    if (iCou == 1)
                    {
                        return thisID + "已经存在\n";
                    }
                    if (thisID.Length > sList[0].Length)
                    {
                        sSQL = "select count(1) from dbo.CustomerClass where cCCode = '" + oldID + "'";
                        iCou = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
                        if (iCou == 0)
                        {
                            return thisID + "没有上级编码\n";
                        }
                    }
                    break;
                case "department":
                    sSQL = "select count(1) from dbo.Department where cDepCode = '" + thisID + "'";
                    iCou = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
                    if (iCou == 1)
                    {
                        return thisID + "已经存在\n";
                    }

                    if (thisID.Length > sList[0].Length)
                    {
                        sSQL = "select count(1) from dbo.Department where cDepCode = '" + oldID + "'";
                        iCou = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
                        if (iCou == 0)
                        {
                            return thisID + "没有上级编码\n";
                        }
                    }
                    break;
                case "districtclass":
                    sSQL = "select count(1) from dbo.DistrictClass where cDCCode = '" + thisID + "'";
                    iCou = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
                    if (iCou == 1)
                    {
                        return thisID + "已经存在\n";
                    }
                    if (thisID.Length > sList[0].Length)
                    {
                        sSQL = "select count(1) from dbo.DistrictClass where cDCCode = '" + oldID + "'";
                        iCou = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
                        if (iCou == 0)
                        {
                            return thisID + "没有上级编码\n";
                        }
                    }
                    break;
                case "vendorclass":
                    sSQL = "select count(1) from dbo.VendorClass where cVCCode = '" + thisID + "'";
                    iCou = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
                    if (iCou == 1)
                    {
                        return thisID + "已经存在\n";
                    }
                    if (thisID.Length > sList[0].Length)
                    {
                        sSQL = "select count(1) from dbo.VendorClass where cVCCode = '" + oldID + "'";
                        iCou = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
                        if (iCou == 0)
                        {
                            return thisID + "没有上级编码\n";
                        }
                    }
                    break;
            }

            return "";
        }

        /// <summary>
        /// 判断编码原则
        /// </summary>
        /// <param name="TableID"></param>
        /// <param name="Code"></param>
        /// <param name="oldID"></param>
        /// <param name="thisID"></param>
        /// <returns></returns>
        public string CheckSerialNumber(string TableID, string oldID, string thisID)
        {
            if (oldID == thisID.Substring(0, oldID.Length))
            {

                系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();
                sSQL = "select * from SerialNumber where TableID='" + TableID + "'";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);

                int t = 0;
                string[] type = dt.Rows[0]["Type"].ToString().Split('-');
                for (int i = 0; i < type.Length; i++)
                {
                    if (t < oldID.Length)
                    {
                        t = t + type[i].Length;
                    }
                    else
                    {
                        if (t + type[i].Length != thisID.Length)
                        {
                            return "不符合编码原则,编码原则" + dt.Rows[0]["Type"].ToString();
                        }
                        else
                        {
                            return "";
                        }
                    }

                }
            }
            else
            {
                return "不符合编码原则,子类别编码左侧必须等于类别编码";
            }
            return "";
        }

        public void GetTreeFoucse(DevExpress.XtraTreeList.TreeList treeList1, string foucseID)
        {
            for (int i = 0; i < treeList1.Nodes.Count; i++)
            {
                if (treeList1.Nodes[i].Tag.ToString().Trim() == foucseID)
                {
                    treeList1.Nodes[i].Selected = true;
                }
                GetTreeFoucse(treeList1.Nodes[i], foucseID);
            }
        }

        public void GetTreeFoucse(DevExpress.XtraTreeList.Nodes.TreeListNode tn, string foucseID)
        {
            for (int i = 0; i < tn.Nodes.Count; i++)
            {
                if (tn.Nodes[i].Tag.ToString().Trim() == foucseID)
                {
                    tn.Nodes[i].Selected = true;
                }
                GetTreeFoucse(tn, foucseID);
            }
        }

        /// <summary>
        /// 得到连续的序列号
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="FieldName"></param>
        /// <param name="sID"></param>
        /// <returns></returns>
        public string GetNewSerialNumberContinuous(string TableName, string FieldName)
        {
            系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();

            sSQL = "select * from SerialNumberContinuous where TableID='" + TableName + "' and Code='" + FieldName + "'";
            DataTable dts = clsSQLCommond.ExecQuery(sSQL);
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
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

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
        #endregion

        #region 序号增加
        public long GetMaxID(string type)
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
            return long.Parse(clsSQLCommond.ExecGetScalar(sSQL).ToString());
        }

        public string GetMaxCode(string type)
        {
            sSQL = @"declare @id int
            if exists( select * from _Identity where cVouchType=1111) 
            update _Identity set @id=iId=(iId+1) where cVouchType=1111
            else
            begin
            insert _Identity(cVouchType,iId) values(1111,1)
            set @id=1
            end
            select 'RD'+convert(nvarchar,right(datepart(YYYY,GETDATE()),2))+right('0'+convert(nvarchar,datepart(mm,GETDATE())),2)+right(convert(nvarchar,datepart(mm,GETDATE()))+'00000'+@id,4)";
            sSQL = sSQL.Replace("1111", "'" + type + "'");
            return clsSQLCommond.ExecGetScalar(sSQL).ToString();
        }

        public string GetMaxCode_Sub(string type)
        {
            sSQL = @"declare @id int
            if exists( select * from _Identity where cVouchType=1111) 
            update _Identity set @id=iId=(iId+1) where cVouchType=1111
            else
            begin
            insert _Identity(cVouchType,iId) values(1111,1)
            set @id=1
            end
            select 'SUB'+convert(nvarchar,right(datepart(YYYY,GETDATE()),2))+right('0'+convert(nvarchar,datepart(mm,GETDATE())),2)+right(convert(nvarchar,datepart(mm,GETDATE()))+'00000'+@id,4)";
            sSQL = sSQL.Replace("1111", "'" + type + "'");
            return clsSQLCommond.ExecGetScalar(sSQL).ToString();
        }

        public string GetMaxCode_SO(string type)
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
            return clsSQLCommond.ExecGetScalar(sSQL).ToString();
        }

        public void SetMaxID()
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
end
";
            clsSQLCommond.ExecGetScalar(sSQL);
        }
        #endregion

        #region 更新现存量表
        public void ReturnNow(int bRdFlag,string RdAutoID, string cInvCode, string cWhCode, string cPosCode, string BoxNo, string sBoxNo
            , string M1, string M2, string M3, string M4, string M5, string M6, string M7, string M8, string M9, string M10
            , decimal HistoryQty, decimal HistoryNum, decimal HistorysBoxQty
            , decimal iQuantity, decimal iNum, int sBoxQty, System.Collections.ArrayList aList)
        {
            sSQL = "";
            decimal NowQty = iQuantity - HistoryQty;
            decimal NowNum = iNum - HistoryNum;
            decimal NowsBoxQty = sBoxQty - HistorysBoxQty;
            if (bRdFlag == 1)
            {
                NowQty = -NowQty;
                NowNum = -NowNum;
                NowsBoxQty = -NowsBoxQty;
            }

            sSQL = @"if exists( select * from CurrentStock where isnull(cInvCode,'') = 111111 and isnull(cWhCode,'') = 222222 and isnull(cPosCode,'') = 333333 
            and isnull(BoxNo,'') = 444444 and isnull(sBoxNo,'') = 555555
            and isnull(M1,'') = M1_000000 and ISNULL(M2,'') = M2_000000 and ISNULL(M3,'') = M3_000000 and ISNULL(M4,'') = M4_000000 and ISNULL(M5,'') = M5_000000 
            and ISNULL(M6,'') = M6_000000 and ISNULL(M7,'') = M7_000000 and ISNULL(M8,'') = M8_000000 and ISNULL(M9,'') = M9_000000 and ISNULL(M10,'') = M10_000000) 

            update CurrentStock set iQuantity = iQuantity + 666666,iNum = iNum + 777777,sBoxQty = sBoxQty + 888888
            where isnull(cInvCode,'') = 111111 and isnull(cWhCode,'') = 222222 and isnull(cPosCode,'') = 333333 
            and isnull(BoxNo,'') = 444444 and isnull(sBoxNo,'') = 555555
            and isnull(M1,'') = M1_000000 and ISNULL(M2,'') = M2_000000 and ISNULL(M3,'') = M3_000000 and ISNULL(M4,'') = M4_000000 and ISNULL(M5,'') = M5_000000 
            and ISNULL(M6,'') = M6_000000 and ISNULL(M7,'') = M7_000000 and ISNULL(M8,'') = M8_000000 and ISNULL(M9,'') = M9_000000 and ISNULL(M10,'') = M10_000000 

            else 

            insert CurrentStock(cInvCode, cWhCode, cPosCode, BoxNo, sBoxNo
            , M1, M2, M3, M4, M5, M6, M7, M8, M9, M10
            ,iQuantity ,iNum ,sBoxQty) 
            values( 111111, 222222, 333333, 444444, 555555
            , M1_000000, M2_000000,M3_000000,M4_000000,M5_000000,M6_000000,M7_000000,M8_000000,M9_000000,M10_000000
            , 666666,777777,888888)";

            sSQL = sSQL.Replace("111111", "'" + cInvCode + "'");
            sSQL = sSQL.Replace("222222", "'" + cWhCode + "'");
            sSQL = sSQL.Replace("333333", "'" + cPosCode + "'");
            sSQL = sSQL.Replace("444444", "'" + BoxNo + "'");
            sSQL = sSQL.Replace("555555", "'" + sBoxNo + "'");

            sSQL = sSQL.Replace("666666", "'" + NowQty + "'");
            sSQL = sSQL.Replace("777777", "'" + NowNum + "'");
            sSQL = sSQL.Replace("888888", "'" + NowsBoxQty + "'");

            sSQL = sSQL.Replace("M1_000000", "'" + M1 + "'");
            sSQL = sSQL.Replace("M2_000000", "'" + M2 + "'");
            sSQL = sSQL.Replace("M3_000000", "'" + M3 + "'");
            sSQL = sSQL.Replace("M4_000000", "'" + M4 + "'");
            sSQL = sSQL.Replace("M5_000000", "'" + M5 + "'");
            sSQL = sSQL.Replace("M6_000000", "'" + M6 + "'");
            sSQL = sSQL.Replace("M7_000000", "'" + M7 + "'");
            sSQL = sSQL.Replace("M8_000000", "'" + M8 + "'");
            sSQL = sSQL.Replace("M9_000000", "'" + M9 + "'");
            sSQL = sSQL.Replace("M10_000000", "'" + M10 + "'");

            aList.Add(sSQL);
        }

        public void ReturnNow(string delStrs, System.Collections.ArrayList aList)
        {
            string[] delSplit = delStrs.Split(',');

            for (int i = 0; i < delSplit.Length; i++)
            {
                sSQL = @"
            declare @cInvCode nvarchar(50)
            declare @cWhCode nvarchar(50)
            declare @cPosCode nvarchar(50)
            declare @BoxNo nvarchar(50)
            declare @sBoxNo nvarchar(50)
            declare @RdAutoID int
            declare @M1 nvarchar(50)
            declare @M2 nvarchar(50)
            declare @M3 nvarchar(50)
            declare @M4 nvarchar(50)
            declare @M5 nvarchar(50)
            declare @M6 nvarchar(50)
            declare @M7 nvarchar(50)
            declare @M8 nvarchar(50)
            declare @M9 nvarchar(50)
            declare @M10 nvarchar(50)
            declare @iQuantity decimal(16, 6)
            declare @iNum decimal(16, 6)
            declare @sBoxQty int
            declare @bRdFlag int

			select @cInvCode=isnull(cInvCode,''),@cWhCode=isnull(cWhCode,''),@cPosCode=isnull(cPosCode,''),@BoxNo=isnull(BoxNo,''),@sBoxNo=isnull(sBoxNo,'') ,@RdAuID=isnull(sBoxNo,'') 
			,@M1=isnull(M1,''),@M2=isnull(M2,''),@M3=isnull(M3,''),@M4=isnull(M4,''),@M5=isnull(M5,'')
            ,@M6=isnull(M6,''),@M7=isnull(M7,''),@M8=isnull(M8,''),@M9=isnull(M9,''),@M10=isnull(M10,'')
			,@iQuantity=iQuantity,@iNum=iNum,@sBoxQty=sBoxQty,@bRdFlag=bRdFlag
			from RdRecords a left join RdRecord b on a.ID=b.ID left join RdStyle r on b.cRSCode=r.cRSCode where AutoID= 111111 
			
			if @bRdFlag=1 
			begin
				set @iQuantity=-@iQuantity
				set @iNum=-@iNum
				set @sBoxQty=-@sBoxQty
			end
			
            if exists( select * from CurrentStock where isnull(cInvCode,'') = @cInvCode and isnull(cWhCode,'') = @cWhCode and isnull(cPosCode,'') = @cPosCode 
            and isnull(BoxNo,'') = @BoxNo and isnull(sBoxNo,'') = @sBoxNo
            and isnull(M1,'') = @M1 and ISNULL(M2,'') = @M2 and ISNULL(M3,'') = @M3 and ISNULL(M4,'') = @M4 and ISNULL(M5,'') = @M5 
            and ISNULL(M6,'') = @M6 and ISNULL(M7,'') = @M7 and ISNULL(M8,'') = @M8 and ISNULL(M9,'') = @M9 and ISNULL(M10,'') = @M10) 

            update CurrentStock set iQuantity = iQuantity - isnull(@iQuantity,0),iNum = iNum - isnull(@iNum,0),sBoxQty = sBoxQty - isnull(@sBoxQty,0)
            where isnull(cInvCode,'') = @cInvCode and isnull(cWhCode,'') = @cWhCode and isnull(cPosCode,'') = @cPosCode 
            and isnull(BoxNo,'') = @BoxNo and isnull(sBoxNo,'') = @sBoxNo
            and isnull(M1,'') = @M1 and ISNULL(M2,'') = @M2 and ISNULL(M3,'') = @M3 and ISNULL(M4,'') = @M4 and ISNULL(M5,'') = @M5 
            and ISNULL(M6,'') = @M6 and ISNULL(M7,'') = @M7 and ISNULL(M8,'') = @M8 and ISNULL(M9,'') = @M9 and ISNULL(M10,'') = @M10 

            else 

            insert CurrentStock(cInvCode, cWhCode, cPosCode, BoxNo, sBoxNo,RdAutoID
            , M1, M2, M3, M4, M5, M6, M7, M8, M9, M10
            ,iQuantity ,iNum ,sBoxQty) 
            values( @cInvCode, @cWhCode, @cPosCode, @BoxNo, @sBoxNo,@RdAutoID
            , @M1, @M2,@M3,@M4,@M5,@M6,@M7,@M8,@M9,@M10
            , -isnull(@iQuantity),-isnull(@iNum),-isnull(@sBoxQty))";

                sSQL = sSQL.Replace("111111", "'" + delSplit[i] + "'");

                //aList.Add(sSQL);
            }
        }
        #endregion

        public string UpdateiOutQuantity(string RdAutoID)
        {
            sSQL = @"
if object_id('Tempdb.dbo.#c') is not null drop table #c
select RdAutoID,iQuantity,sBoxQty into #c from RdRecords11 where RdAutoID=111111 
insert into #c select RdAutoID,iQuantity,sBoxQty from RdRecords12 where RdAutoID=111111 
insert into #c select RdAutoID,iQuantity,sBoxQty from RdRecords13 where RdAutoID=111111 
insert into #c select RdAutoID,iQuantity,sBoxQty from RdRecords15 where RdAutoID=111111 

insert into #c select RdAutoID,-iQuantity,-sBoxQty from RdRecords01 where RdAutoID=111111 
insert into #c select RdAutoID,-iQuantity,-sBoxQty from RdRecords02 where RdAutoID=111111 
insert into #c select RdAutoID,-iQuantity,-sBoxQty from RdRecords03 where RdAutoID=111111 
insert into #c select RdAutoID,-iQuantity,-sBoxQty from RdRecords05 where RdAutoID=111111 

update RdRecords01 set iOutQuantity=a.iQuantity,sOutBoxQty=a.sBoxQty from (select RdAutoID,sum(iQuantity) as iQuantity,sum(sBoxQty) as sBoxQty from #c group by RdAutoID) a where RdRecords01.AutoID=a.RdAutoID
update RdRecords02 set iOutQuantity=a.iQuantity,sOutBoxQty=a.sBoxQty from (select RdAutoID,sum(iQuantity) as iQuantity,sum(sBoxQty) as sBoxQty from #c group by RdAutoID) a where RdRecords02.AutoID=a.RdAutoID
update RdRecords03 set iOutQuantity=a.iQuantity,sOutBoxQty=a.sBoxQty from (select RdAutoID,sum(iQuantity) as iQuantity,sum(sBoxQty) as sBoxQty from #c group by RdAutoID) a where RdRecords03.AutoID=a.RdAutoID
update RdRecords05 set iOutQuantity=a.iQuantity,sOutBoxQty=a.sBoxQty from (select RdAutoID,sum(iQuantity) as iQuantity,sum(sBoxQty) as sBoxQty from #c group by RdAutoID) a where RdRecords05.AutoID=a.RdAutoID

update RdRecords11 set iOutQuantity=-a.iQuantity,sOutBoxQty=-a.sBoxQty from (select RdAutoID,sum(iQuantity) as iQuantity,sum(sBoxQty) as sBoxQty from #c group by RdAutoID) a where RdRecords11.AutoID=a.RdAutoID
update RdRecords12 set iOutQuantity=-a.iQuantity,sOutBoxQty=-a.sBoxQty from (select RdAutoID,sum(iQuantity) as iQuantity,sum(sBoxQty) as sBoxQty from #c group by RdAutoID) a where RdRecords12.AutoID=a.RdAutoID
update RdRecords13 set iOutQuantity=-a.iQuantity,sOutBoxQty=-a.sBoxQty from (select RdAutoID,sum(iQuantity) as iQuantity,sum(sBoxQty) as sBoxQty from #c group by RdAutoID) a where RdRecords13.AutoID=a.RdAutoID
update RdRecords15 set iOutQuantity=-a.iQuantity,sOutBoxQty=-a.sBoxQty from (select RdAutoID,sum(iQuantity) as iQuantity,sum(sBoxQty) as sBoxQty from #c group by RdAutoID) a where RdRecords15.AutoID=a.RdAutoID
";
            sSQL = sSQL.Replace("111111", RdAutoID);
            return sSQL;
        }

        public string UpdateiOutQuantity_Sub(string SubAutoID)
        {
            sSQL = @"
declare @iQty decimal(18, 6)
declare @iSubQty decimal(18, 6)
set @iQty=0
set @iSubQty=0
select @iQty=@iQty+sum(iQty),@iSubQty=@iSubQty+sum(iSubQty) from SubRecords11 where SubAutoID=111111 

update SubRecords01 set OutiQty=@iQty,OutiSubQty=@iSubQty where SubRecords01.AutoID=111111 
";
            sSQL = sSQL.Replace("111111", SubAutoID);
            return sSQL;
        }

        #region 规格化
        public decimal ReturnDecimal(object o)
        {
            decimal d = 0;
            try
            {
                d = decimal.Round(Convert.ToDecimal(o), 6);
            }
            catch { }
            return d;
        }
        public decimal ReturnDecimal(object o, int iLength)
        {
            decimal d = 0;
            try
            {
                d = decimal.Round(Convert.ToDecimal(o), iLength);
            }
            catch { }
            return d;
        }


        public int ReturnInt(object o)
        {
            int d = 0;
            try
            {
                d = Convert.ToInt32(o);
            }
            catch { }
            return d;
        }

        public long ReturnLong(object o)
        {
            long d = 0;
            try
            {
                d = Convert.ToInt64(o);
            }
            catch { }
            return d;
        }

        public string ReturnDateTimeString(object o)
        {
            string d = "";
            try
            {
                if (Convert.ToDateTime(o) >= Convert.ToDateTime("1900-01-01"))
                {
                    d = Convert.ToDateTime(o).ToString("yyyy-MM-dd");
                }
            }
            catch { }
            return d;
        }

        public DataTable DataRowToDataTable(DataRow[] dw)
        {
            DataTable dts = new DataTable();
            foreach (DataColumn dc in dw[0].Table.Columns)
            {
                dts.Columns.Add(dc.ColumnName);
            }
            foreach (DataRow dws in dw)
            {
                dts.ImportRow(dws);
            }
            return dts;
        }

        public DataTable SelectTable(DataTable dt, string[,] Requirement, string Order)
        {
            DataRow[] dw = dt.Select(GetFilter(Requirement), Order);
            DataTable dts = new DataTable();
            foreach (DataColumn dc in dt.Columns)
            {
                dts.Columns.Add(dc.ColumnName);
            }
            foreach (DataRow dws in dw)
            {
                dts.ImportRow(dws);
            }
            return dts;
        }

        public DataTable Group(DataTable dt, string[] ColumnName)
        {
            DataView dv = new DataView(dt);
            DataTable dtgroup = dv.ToTable(true, ColumnName);
            return dtgroup;
        }

        private string GetFilter(string[,] Requirement)
        {
            string s = "";
            for (int i = 0; i < Requirement.GetLength(0); i++)
            {
                if (i != 0)
                {
                    s = s + " and ";
                }
                if (Requirement.Length / Requirement.GetLength(0) == 2)
                {
                    if (Requirement[i, 1] != "")
                    {
                        s = s + Requirement[i, 0] + "='" + Requirement[i, 1] + "'";
                    }
                    else
                    {
                        s = s + "(" + Requirement[i, 0] + " is null or " + Requirement[i, 0] + " ='')";
                    }
                }
                else
                {
                    if (Requirement[i, 1] != "")
                    {
                        s = s + Requirement[i, 0] + Requirement[i, 2] + "'" + Requirement[i, 1] + "'";
                    }
                    else
                    {
                        s = s + "(" + Requirement[i, 0] + " is null or " + Requirement[i, 0] + " ='')";
                    }
                }
            }
            return s;
        }

        #endregion

        #region 表格变更
        public bool GetChange(string tablename, string tablenames, string id, ClsGetSQL clsGetSQL, System.Collections.ArrayList aList)
        {
            string sSQL = "";

            sSQL = "select isnull(max(HistoryNum)+1,1) as HistoryId from " + tablename + "History";
            long HistoryNum = long.Parse(clsSQLCommond.ExecQuery(sSQL).Rows[0][0].ToString());

            sSQL = "select isnull(max(HistoryId)+1,1) as HistoryId from " + tablename + "History";
            long HistoryId = long.Parse(clsSQLCommond.ExecQuery(sSQL).Rows[0][0].ToString());
            sSQL = "select isnull(max(HistoryId)+1,1) as HistoryId from " + tablenames + "History";
            long HistoryIds = long.Parse(clsSQLCommond.ExecQuery(sSQL).Rows[0][0].ToString());


            sSQL = "select * from " + tablename + " where ID=" + id;
            DataTable dtalter = clsSQLCommond.ExecQuery(sSQL);
            sSQL = "select * from " + tablenames + " where ID=" + id;
            DataTable dtsalter = clsSQLCommond.ExecQuery(sSQL);

            sSQL = "select * from " + tablename + "History where 1=-1";
            DataTable dtalterHistory = clsSQLCommond.ExecQuery(sSQL);
            sSQL = "select * from " + tablenames + "History where 1=-1";
            DataTable dtsHistory = clsSQLCommond.ExecQuery(sSQL);

            for (int i = 0; i < dtalter.Rows.Count; i++)
            {
                DataRow dwalter = dtalterHistory.NewRow();
                dwalter["HistoryId"] = HistoryId;
                dwalter["HistoryTime"] = DateTime.Now.ToString().Trim();
                dwalter["HistoryNum"] = HistoryNum;
                for (int j = 0; j < dtalter.Columns.Count; j++)
                {
                    if (dtalter.Rows[i][j].ToString() != "")
                    {
                        dwalter[dtalter.Columns[j].ColumnName] = dtalter.Rows[i][j].ToString();
                    }
                }
                dtalterHistory.Rows.Add(dwalter);
                sSQL = clsGetSQL.GetInsertSQL(系统服务.ClsBaseDataInfo.sDataBaseName, tablename + "History", dtalterHistory, dtalterHistory.Rows.Count - 1);
                aList.Add(sSQL);
                HistoryId = HistoryId + 1;
            }

            for (int i = 0; i < dtsalter.Rows.Count; i++)
            {
                DataRow dwalter = dtsHistory.NewRow();
                dwalter["HistoryId"] = HistoryIds;
                dwalter["HistoryTime"] = DateTime.Now.ToString().Trim();
                dwalter["HistoryNum"] = HistoryNum;
                for (int j = 0; j < dtsalter.Columns.Count; j++)
                {
                    if (dtsalter.Rows[i][j].ToString() != "")
                    {
                        dwalter[dtsalter.Columns[j].ColumnName] = dtsalter.Rows[i][j].ToString();
                    }
                }
                dtsHistory.Rows.Add(dwalter);
                sSQL = clsGetSQL.GetInsertSQL(系统服务.ClsBaseDataInfo.sDataBaseName, tablenames + "History", dtsHistory, dtsHistory.Rows.Count - 1);
                aList.Add(sSQL);
                HistoryIds = HistoryIds + 1;
            }

            return true;
        }

        public bool GetChange(string tablename, string tablenames, string tablenamel, string id, ClsGetSQL clsGetSQL, System.Collections.ArrayList aList)
        {
            string sSQL = "";

            sSQL = "select isnull(max(HistoryNum)+1,1) as HistoryId from " + tablename + "History";
            long HistoryNum = long.Parse(clsSQLCommond.ExecQuery(sSQL).Rows[0][0].ToString());

            sSQL = "select isnull(max(HistoryId)+1,1) as HistoryId from " + tablename + "History";
            long HistoryId = long.Parse(clsSQLCommond.ExecQuery(sSQL).Rows[0][0].ToString());
            sSQL = "select isnull(max(HistoryId)+1,1) as HistoryId from " + tablenames + "History";
            long HistoryIds = long.Parse(clsSQLCommond.ExecQuery(sSQL).Rows[0][0].ToString());
            sSQL = "select isnull(max(HistoryId)+1,1) as HistoryId from " + tablenamel + "History";
            long HistoryIdsl = long.Parse(clsSQLCommond.ExecQuery(sSQL).Rows[0][0].ToString());

            sSQL = "select * from " + tablename + " where ID=" + id;
            DataTable dtalter = clsSQLCommond.ExecQuery(sSQL);
            sSQL = "select * from " + tablenames + " where ID=" + id;
            DataTable dtsalter = clsSQLCommond.ExecQuery(sSQL);
            sSQL = "select * from " + tablenamel + " where ID=" + id;
            DataTable dtslalter = clsSQLCommond.ExecQuery(sSQL);

            sSQL = "select * from " + tablename + "History where 1=-1";
            DataTable dtalterHistory = clsSQLCommond.ExecQuery(sSQL);
            sSQL = "select * from " + tablenames + "History where 1=-1";
            DataTable dtsHistory = clsSQLCommond.ExecQuery(sSQL);
            sSQL = "select * from " + tablenamel + "History where 1=-1";
            DataTable dtslHistory = clsSQLCommond.ExecQuery(sSQL);

            for (int i = 0; i < dtalter.Rows.Count; i++)
            {
                DataRow dwalter = dtalterHistory.NewRow();
                dwalter["HistoryId"] = HistoryId;
                dwalter["HistoryTime"] = DateTime.Now.ToString().Trim();
                dwalter["HistoryNum"] = HistoryNum;
                for (int j = 0; j < dtalter.Columns.Count; j++)
                {
                    if (dtalter.Rows[i][j].ToString() != "")
                    {
                        dwalter[dtalter.Columns[j].ColumnName] = dtalter.Rows[i][j].ToString();
                    }
                }
                dtalterHistory.Rows.Add(dwalter);
                sSQL = clsGetSQL.GetInsertSQL(系统服务.ClsBaseDataInfo.sDataBaseName, tablename + "History", dtalterHistory, dtalterHistory.Rows.Count - 1);
                aList.Add(sSQL);
                HistoryId = HistoryId + 1;
            }

            for (int i = 0; i < dtsalter.Rows.Count; i++)
            {
                DataRow dwalter = dtsHistory.NewRow();
                dwalter["HistoryId"] = HistoryIds;
                dwalter["HistoryTime"] = DateTime.Now.ToString().Trim();
                dwalter["HistoryNum"] = HistoryNum;
                for (int j = 0; j < dtsalter.Columns.Count; j++)
                {
                    if (dtsalter.Rows[i][j].ToString() != "")
                    {
                        dwalter[dtsalter.Columns[j].ColumnName] = dtsalter.Rows[i][j].ToString();
                    }
                }
                dtsHistory.Rows.Add(dwalter);
                sSQL = clsGetSQL.GetInsertSQL(系统服务.ClsBaseDataInfo.sDataBaseName, tablenames + "History", dtsHistory, dtsHistory.Rows.Count - 1);
                aList.Add(sSQL);
                HistoryIds = HistoryIds + 1;
            }

            for (int i = 0; i < dtslalter.Rows.Count; i++)
            {
                DataRow dwalter = dtslHistory.NewRow();
                dwalter["HistoryId"] = HistoryIdsl;
                dwalter["HistoryTime"] = DateTime.Now.ToString().Trim();
                dwalter["HistoryNum"] = HistoryNum;
                for (int j = 0; j < dtslalter.Columns.Count; j++)
                {
                    if (dtslalter.Rows[i][j].ToString() != "")
                    {
                        dwalter[dtslalter.Columns[j].ColumnName] = dtslalter.Rows[i][j].ToString();
                    }
                }
                dtslHistory.Rows.Add(dwalter);
                sSQL = clsGetSQL.GetInsertSQL(系统服务.ClsBaseDataInfo.sDataBaseName, tablenamel + "History", dtslHistory, dtslHistory.Rows.Count - 1);
                aList.Add(sSQL);
                HistoryIdsl = HistoryIdsl + 1;
            }

            return true;
        }

        public bool GetChange(string tablename, string tablenames, string tablenamel, string tablenamec, string id, ClsGetSQL clsGetSQL, System.Collections.ArrayList aList)
        {
            string sSQL = "";

            sSQL = "select isnull(max(HistoryNum)+1,1) as HistoryId from " + tablename + "History";
            long HistoryNum = long.Parse(clsSQLCommond.ExecQuery(sSQL).Rows[0][0].ToString());

            sSQL = "select isnull(max(HistoryId)+1,1) as HistoryId from " + tablename + "History";
            long HistoryId = long.Parse(clsSQLCommond.ExecQuery(sSQL).Rows[0][0].ToString());
            sSQL = "select isnull(max(HistoryId)+1,1) as HistoryId from " + tablenames + "History";
            long HistoryIds = long.Parse(clsSQLCommond.ExecQuery(sSQL).Rows[0][0].ToString());
            sSQL = "select isnull(max(HistoryId)+1,1) as HistoryId from " + tablenamel + "History";
            long HistoryIdsl = long.Parse(clsSQLCommond.ExecQuery(sSQL).Rows[0][0].ToString());
            sSQL = "select isnull(max(HistoryId)+1,1) as HistoryId from " + tablenamec + "History";
            long HistoryIdsc = long.Parse(clsSQLCommond.ExecQuery(sSQL).Rows[0][0].ToString());

            sSQL = "select * from " + tablename + " where ID=" + id;
            DataTable dtalter = clsSQLCommond.ExecQuery(sSQL);
            sSQL = "select * from " + tablenames + " where ID=" + id;
            DataTable dtsalter = clsSQLCommond.ExecQuery(sSQL);
            sSQL = "select * from " + tablenamel + " where ID=" + id;
            DataTable dtslalter = clsSQLCommond.ExecQuery(sSQL);
            sSQL = "select * from " + tablenamec + " where ID=" + id;
            DataTable dtscalter = clsSQLCommond.ExecQuery(sSQL);


            sSQL = "select * from " + tablename + "History where 1=-1";
            DataTable dtalterHistory = clsSQLCommond.ExecQuery(sSQL);
            sSQL = "select * from " + tablenames + "History where 1=-1";
            DataTable dtsHistory = clsSQLCommond.ExecQuery(sSQL);
            sSQL = "select * from " + tablenamel + "History where 1=-1";
            DataTable dtslHistory = clsSQLCommond.ExecQuery(sSQL);
            sSQL = "select * from " + tablenamec + "History where 1=-1";
            DataTable dtscHistory = clsSQLCommond.ExecQuery(sSQL);

            for (int i = 0; i < dtalter.Rows.Count; i++)
            {
                DataRow dwalter = dtalterHistory.NewRow();
                dwalter["HistoryId"] = HistoryId;
                dwalter["HistoryTime"] = DateTime.Now.ToString().Trim();
                dwalter["HistoryNum"] = HistoryNum;
                for (int j = 0; j < dtalter.Columns.Count; j++)
                {
                    if (dtalter.Rows[i][j].ToString() != "")
                    {
                        dwalter[dtalter.Columns[j].ColumnName] = dtalter.Rows[i][j].ToString();
                    }
                }
                dtalterHistory.Rows.Add(dwalter);
                sSQL = clsGetSQL.GetInsertSQL(系统服务.ClsBaseDataInfo.sDataBaseName, tablename + "History", dtalterHistory, dtalterHistory.Rows.Count - 1);
                aList.Add(sSQL);
                HistoryId = HistoryId + 1;
            }

            for (int i = 0; i < dtsalter.Rows.Count; i++)
            {
                DataRow dwalter = dtsHistory.NewRow();
                dwalter["HistoryId"] = HistoryIds;
                dwalter["HistoryTime"] = DateTime.Now.ToString().Trim();
                dwalter["HistoryNum"] = HistoryNum;
                for (int j = 0; j < dtsalter.Columns.Count; j++)
                {
                    if (dtsalter.Rows[i][j].ToString() != "")
                    {
                        dwalter[dtsalter.Columns[j].ColumnName] = dtsalter.Rows[i][j].ToString();
                    }
                }
                dtsHistory.Rows.Add(dwalter);
                sSQL = clsGetSQL.GetInsertSQL(系统服务.ClsBaseDataInfo.sDataBaseName, tablenames + "History", dtsHistory, dtsHistory.Rows.Count - 1);
                aList.Add(sSQL);
                HistoryIds = HistoryIds + 1;
            }

            for (int i = 0; i < dtslalter.Rows.Count; i++)
            {
                DataRow dwalter = dtslHistory.NewRow();
                dwalter["HistoryId"] = HistoryIdsl;
                dwalter["HistoryTime"] = DateTime.Now.ToString().Trim();
                dwalter["HistoryNum"] = HistoryNum;
                for (int j = 0; j < dtslalter.Columns.Count; j++)
                {
                    if (dtslalter.Rows[i][j].ToString() != "")
                    {
                        dwalter[dtslalter.Columns[j].ColumnName] = dtslalter.Rows[i][j].ToString();
                    }
                }
                dtslHistory.Rows.Add(dwalter);
                sSQL = clsGetSQL.GetInsertSQL(系统服务.ClsBaseDataInfo.sDataBaseName, tablenamel + "History", dtslHistory, dtslHistory.Rows.Count - 1);
                aList.Add(sSQL);
                HistoryIdsl = HistoryIdsl + 1;
            }

            for (int i = 0; i < dtscalter.Rows.Count; i++)
            {
                DataRow dwalter = dtscHistory.NewRow();
                dwalter["HistoryId"] = HistoryIdsc;
                dwalter["HistoryTime"] = DateTime.Now.ToString().Trim();
                dwalter["HistoryNum"] = HistoryNum;
                for (int j = 0; j < dtscalter.Columns.Count; j++)
                {
                    if (dtscalter.Rows[i][j].ToString() != "")
                    {
                        dwalter[dtscalter.Columns[j].ColumnName] = dtscalter.Rows[i][j].ToString();
                    }
                }
                dtscHistory.Rows.Add(dwalter);
                sSQL = clsGetSQL.GetInsertSQL(系统服务.ClsBaseDataInfo.sDataBaseName, tablenamec + "History", dtscHistory, dtscHistory.Rows.Count - 1);
                aList.Add(sSQL);
                HistoryIdsc = HistoryIdsc + 1;
            }

            return true;
        }

        public bool GetChangeDelRow(string tablenames, string id, System.Collections.ArrayList aList)
        {
            string sSQL = "";
            if (id != "")
            {
                string[] strdel = id.Trim().Split(',');
                for (int i = 0; i < strdel.Length; i++)
                {
                    if (strdel[i].Trim() != "")
                    {
                        sSQL = "delete  from " + tablenames + " where AutoID ='" + strdel[i] + "'";
                        aList.Add(sSQL);
                    }
                }
            }
            return true;
        }

        public bool GetChangeDelRow(string tablenames, string tablenamel, string id, System.Collections.ArrayList aList)
        {
            string sSQL = "";
            if (id != "")
            {
                string[] strdel = id.Trim().Split(',');
                for (int i = 0; i < strdel.Length; i++)
                {
                    if (strdel[i].Trim() != "")
                    {
                        sSQL = "delete  from " + tablenames + " where AutoID ='" + strdel[i] + "'";
                        aList.Add(sSQL);

                        sSQL = "delete  from " + tablenamel + " where AutoID ='" + strdel[i] + "'";
                        aList.Add(sSQL);
                    }
                }
            }
            return true;
        }
        #endregion

        #region 创建文件夹
        public void CreateFile(string file)
        {
            if (!System.IO.Directory.Exists(file))
            {
                System.IO.Directory.CreateDirectory(file);
            }
        }
        #endregion

        #region
        /// <summary>
        /// 反写出入库单据
        /// </summary>
        /// <param name="RdAutoID"></param>
        /// <returns></returns>
        public string ReturnWriteRdAutoID(string RdAutoID)
        {
            sSQL = @"
if object_id('Tempdb.dbo.#a') is not null drop table #a
select RdAutoID,iQuantity,iNum,sBoxQty into #a from RdRecords11 where RdAutoID=111111 
insert into #a select RdAutoID,iQuantity,iNum,sBoxQty from RdRecords12 where RdAutoID=111111 
insert into #a select RdAutoID,iQuantity,iNum,sBoxQty from RdRecords13 where RdAutoID=111111 
insert into #a select RdAutoID,iQuantity,iNum,sBoxQty from RdRecords15 where RdAutoID=111111 

insert into #a select RdAutoID,-iQuantity,-iNum,-sBoxQty from RdRecords01 where RdAutoID=111111 
insert into #a select RdAutoID,-iQuantity,-iNum,-sBoxQty from RdRecords02 where RdAutoID=111111 
insert into #a select RdAutoID,-iQuantity,-iNum,-sBoxQty from RdRecords03 where RdAutoID=111111 
insert into #a select RdAutoID,-iQuantity,-iNum,-sBoxQty from RdRecords05 where RdAutoID=111111 

update RdRecords11 set iOutQuantity=a.iQuantity,iOutNum = a.iNum,sOutBoxQty = a.sBoxQty from (select RdAutoID,sum(iQuantity) as iQuantity,sum(iNum) as iNum,sum(sBoxQty) as sBoxQty from #a group by RdAutoID) a where RdRecords11.AutoID=a.RdAutoID
update RdRecords12 set iOutQuantity=a.iQuantity,iOutNum = a.iNum,sOutBoxQty = a.sBoxQty from (select RdAutoID,sum(iQuantity) as iQuantity,sum(iNum) as iNum,sum(sBoxQty) as sBoxQty from #a group by RdAutoID) a where RdRecords12.AutoID=a.RdAutoID
update RdRecords13 set iOutQuantity=a.iQuantity,iOutNum = a.iNum,sOutBoxQty = a.sBoxQty from (select RdAutoID,sum(iQuantity) as iQuantity,sum(iNum) as iNum,sum(sBoxQty) as sBoxQty from #a group by RdAutoID) a where RdRecords13.AutoID=a.RdAutoID
update RdRecords15 set iOutQuantity=a.iQuantity,iOutNum = a.iNum,sOutBoxQty = a.sBoxQty from (select RdAutoID,sum(iQuantity) as iQuantity,sum(iNum) as iNum,sum(sBoxQty) as sBoxQty from #a group by RdAutoID) a where RdRecords15.AutoID=a.RdAutoID

update RdRecords01 set iOutQuantity=a.iQuantity,iOutNum = a.iNum,sOutBoxQty = a.sBoxQty from (select RdAutoID,sum(iQuantity) as iQuantity,sum(iNum) as iNum,sum(sBoxQty) as sBoxQty from #a group by RdAutoID) a where RdRecords01.AutoID=a.RdAutoID
update RdRecords02 set iOutQuantity=a.iQuantity,iOutNum = a.iNum,sOutBoxQty = a.sBoxQty from (select RdAutoID,sum(iQuantity) as iQuantity,sum(iNum) as iNum,sum(sBoxQty) as sBoxQty from #a group by RdAutoID) a where RdRecords02.AutoID=a.RdAutoID
update RdRecords03 set iOutQuantity=a.iQuantity,iOutNum = a.iNum,sOutBoxQty = a.sBoxQty from (select RdAutoID,sum(iQuantity) as iQuantity,sum(iNum) as iNum,sum(sBoxQty) as sBoxQty from #a group by RdAutoID) a where RdRecords03.AutoID=a.RdAutoID
update RdRecords05 set iOutQuantity=a.iQuantity,iOutNum = a.iNum,sOutBoxQty = a.sBoxQty from (select RdAutoID,sum(iQuantity) as iQuantity,sum(iNum) as iNum,sum(sBoxQty) as sBoxQty from #a group by RdAutoID) a where RdRecords05.AutoID=a.RdAutoID
";
            sSQL = sSQL.Replace("111111", RdAutoID);
            return sSQL;
        }

        /// <summary>
        /// 反写委外订单材料表
        /// </summary>
        /// <param name="RdAutoID"></param>
        /// <returns></returns>
        public string ReturnWriteMosID(string MosID)
        {
            sSQL = @"
if object_id('Tempdb.dbo.#b') is not null drop table #b

select MOsID,iQuantity,iNum into #b from RdRecords12 where MOsID=111111 

update MO_MOSublist set iOutQuantity=a.iQuantity,iOutNum = a.iNum from (select MOsID,sum(iQuantity) as iQuantity,sum(iNum) as iNum from #b group by MOsID) a  where MO_MOSublist.sID = a.MOsID
";
            sSQL = sSQL.Replace("111111", MosID);
            return sSQL;
        }

        /// <summary>
        /// 反写销售订单
        /// </summary>
        /// <param name="RdAutoID"></param>
        /// <returns></returns>
        public string ReturnWriteSoAutoID(string SoAutoID)
        {
            sSQL = @"
if object_id('Tempdb.dbo.#c') is not null drop table #c

select SoAutoID,iQuantity,sBoxQty,iNum into #c from RdRecords11 where SoAutoID=111111 

insert into #c select SoAutoID,iQuantity,sBoxQty,iNum from RdRecords13 where SoAutoID=111111 

update SO_SODetails set iOutQuantity=a.iQuantity,iOutNum = a.iNum,sOutBoxQty = a.sBoxQty from (select SoAutoID,sum(iQuantity) as iQuantity,sum(iNum) as iNum,sum(sBoxQty) as sBoxQty from #c group by SoAutoID) a  where SO_SODetails.AutoID = a.SoAutoID
";
            sSQL = sSQL.Replace("111111", SoAutoID);
            return sSQL;
        }
        #endregion
    }

    
}
