using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

    public static class SerialNumber
    {
        

        /// <summary>
        /// 得到新的序号
        /// </summary>
        /// <param name="表名"></param>
        /// <param name="字段名"></param>
        /// <param name="上层编码"></param>
        /// <returns></returns>
        //public static string GetNewSerialNumber(string TableName,string FieldName, string sID)
        //{
        //    string sSQL = "select * from _SerialNumber where TableID='" + TableName + "'";
        //    DataTable dt = clsSQLCommond.ExecQuery(sSQL);

        //    string[] type = dt.Rows[0]["Type"].ToString().Split('-');
        //    int len = 0;
        //    int cen = 0;
        //    for (int i = 0; i < type.Length; i++)
        //    {
        //        cen = i + 1;
        //        if (len >= sID.Length)
        //        {
        //            i = type.Length;
        //        }
        //        else
        //        {
        //            len = len + int.Parse(type[i]);
        //        }
                
        //    }

        //    sSQL = "select * from " + TableName + " where TableCode like '" + sID + "%' and TableCode <> '" + sID + "' and len(TableCode)=" + len + " order by TableCode";


        //    DataTable dts = clsSQLCommond.ExecQuery(sSQL);
        //    if (dts.Rows.Count > 0)
        //    {
        //        string number=dts.Rows[dts.Rows.Count-1][FieldName].ToString();
        //        number=number.Substring(sID.Length,number.Length);
        //        return sID + GetIsEnoughNumber(int.Parse(number), int.Parse(type[cen + 1]));
        //    }
        //    else
        //    {
        //        return sID + GetIsEnoughNumber(1, int.Parse(type[cen + 1]));
        //    }
        //}

        private static string GetIsEnoughNumber(int number, int len)
        {
            return number.ToString().PadLeft(len, '0');
        }

        //public static string GetSerialNumberRules(string TableName, string FieldName)
        //{
        //   string sSQL = "select * from _SerialNumber where TableID='" + TableName + "' and Code='" + FieldName + "'";
        //    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
        //    if (dt.Rows.Count > 0 && dt.Rows[0]["Type"].ToString()!="")
        //    {
        //        return dt.Rows[0]["Type"].ToString();
        //    }
        //    else
        //    {
        //        return "";
        //    }
        //}


        /// <summary>
        /// 得到树状结构
        /// </summary>
        /// <param name="treeList1"></param>
        /// <param name="TableID"></param>
        /// <param name="TopName"></param>
        //public static void GetTree(DevExpress.XtraTreeList.TreeList treeList1, string TableID, string FieldName, string TopName)
        //{
        //    try
        //    {
        //        treeList1.ClearNodes();
        //    }
        //    catch
        //    {
        //    }
        //    string sSQL = "select * from _SerialNumber where TableID='" + TableID + "' and Code='" + FieldName + "'";
        //    DataTable dts = clsSQLCommond.ExecQuery(sSQL);
        //    string Code = dts.Rows[0]["Code"].ToString();
        //    string Name = dts.Rows[0]["Name"].ToString();


        //    sSQL = "select * from " + TableID + "  order by " + Code;
        //    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
        //    string 序列号规则 = 系统服务.序号.GetSerialNumberRules(TableID,FieldName);
        //    string[] 序列号规则数组 = 序列号规则.Split('-');
        //    int top = 序列号规则数组[0].Length;

        //    object[] obj1 = new object[2];
        //    obj1[0] = TopName;
        //    obj1[1] = "";
        //    DevExpress.XtraTreeList.Nodes.TreeListNode tn1 = treeList1.AppendNode(obj1, null);
        //    tn1.Tag = "";

        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        if (dt.Rows[i][Code].ToString().Length == top)
        //        {
        //            object[] obj = new object[2];
        //            obj[0] = dt.Rows[i][Code].ToString().Trim();
        //            obj[1] = dt.Rows[i][Name].ToString().Trim();
        //            DevExpress.XtraTreeList.Nodes.TreeListNode tn = treeList1.AppendNode(obj, tn1);
        //            tn.Tag = dt.Rows[i][Code].ToString();
        //            GetTreeNode(treeList1, tn, dt, Code, Name, 序列号规则数组, 1, top + 序列号规则数组[1].Length);
        //        }
        //    }
        //    //if (treeList1.FocusedNode != null)
        //    //{
        //    //    try
        //    //    {
        //    //        treeList1.FocusedNode = null;
        //    //    }
        //    //    catch
        //    //    {
        //    //    }
        //    //}
        //}

        //private static void DeleteTreeListNode(DevExpress.XtraTreeList.Nodes.TreeListNode tn)
        //{
        //    for (int i = tn.Nodes.Count - 1; i >= 0; i--)
        //    {
        //        if (tn.Nodes[i].Nodes.Count > 0)
        //        {
        //            DeleteTreeListNode(tn.Nodes[i]);
        //        }
        //        tn.TreeList.DeleteNode(tn.Nodes[i]);
        //    }
        //}

        //private static void GetTreeNode(DevExpress.XtraTreeList.TreeList treeList1, DevExpress.XtraTreeList.Nodes.TreeListNode tn, DataTable dt, string Code, string Name, string[] seq, int lev, int len)
        //{
        //    if (tn.Tag.ToString().Trim() != "")
        //    {
        //        DataRow[] dw = dt.Select(Code + " like '" + tn.Tag.ToString().Trim() + "%' and len(" + Code + ")=" + len);
        //        for (int i = 0; i < dw.Length; i++)
        //        {
        //            object[] obj = new object[2];
        //            obj[0] = dw[i][Code].ToString().Trim();
        //            obj[1] = dw[i][Name].ToString().Trim();
        //            DevExpress.XtraTreeList.Nodes.TreeListNode tn1 = treeList1.AppendNode(obj, tn);
        //            tn1.Tag = dw[i][Code].ToString();
        //            if (seq.Length > lev + 1)
        //            {
        //                GetTreeNode(treeList1, tn1, dt, Code, Name, seq, lev + 1, len + seq[lev + 1].Length);
        //            }
        //        }
        //    }
        //}

        /// <summary>
        /// 判断编码原则    -- TH 2012-12-25 20:52
        /// </summary>
        /// <param name="TableID"></param>
        /// <param name="Code"></param>
        /// <param name="thisID"></param>
        /// <returns></returns>
        //public static string CheckSerialNumber(string TableID, string thisID)
        //{
        //    string sSQL = "SELECT TableID, TableName, Code, Name, Type FROM _SerialNumber where TableID = '" + TableID + "'";
        //    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
        //    string sType = dt.Rows[0]["Type"].ToString().Trim();

        //    int iLength = thisID.Trim().Length;
        //    string[] sList = sType.Split('-');

        //    int i编码规则长度 = 0;
        //    string oldID = "";
        //    for (int i = 0; i < sList.Length; i++)
        //    {
        //        i编码规则长度 = i编码规则长度 + sList[i].Length;
        //        if (i编码规则长度 < iLength)
        //        {
        //            oldID = thisID.Substring(0, i编码规则长度);
        //        }
        //        if (i编码规则长度 == iLength)
        //        {
        //            break;
        //        }
        //        if (i编码规则长度 > iLength)
        //        {
        //            return "编码长度不符合编码原则";
        //        }
        //    }
        //    if (iLength > i编码规则长度)
        //    {
        //        return "编码长度超出编码原则";
        //    }

        //    int iCou = 0;
        //    switch (TableID.ToLower())
        //    {
        //        case "inventoryclass":
        //            sSQL = "select count(1) from dbo.InventoryClass where cInvClassCode = '" + thisID + "'";
        //            iCou = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
        //            if (iCou == 1)
        //            {
        //                return thisID + "已经存在\n";
        //            }
        //            if (thisID.Length > sList[0].Length)
        //            {
        //                sSQL = "select count(1) from dbo.InventoryClass where cInvClassCode = '" + oldID + "'";
        //                iCou = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
        //                if (iCou == 0)
        //                {
        //                    return thisID + "没有上级编码\n";
        //                }
        //            }
        //            break;
        //        case "dealerclass":
        //            sSQL = "select count(1) from dbo.DealerClass where cDCode = '" + thisID + "'";
        //            iCou = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
        //            if (iCou == 1)
        //            {
        //                return thisID + "已经存在\n";
        //            }
        //            if (thisID.Length > sList[0].Length)
        //            {
        //                sSQL = "select count(1) from dbo.DealerClass where cDCode = '" + oldID + "'";
        //                iCou = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
        //                if (iCou == 0)
        //                {
        //                    return thisID + "没有上级编码\n";
        //                }
        //            }
        //            break;
        //        case "customerclass":
        //            sSQL = "select count(1) from dbo.CustomerClass where cCCode = '" + thisID + "'";
        //            iCou = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
        //            if (iCou == 1)
        //            {
        //                return thisID + "已经存在\n";
        //            }
        //            if (thisID.Length > sList[0].Length)
        //            {
        //                sSQL = "select count(1) from dbo.CustomerClass where cCCode = '" + oldID + "'";
        //                iCou = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
        //                if (iCou == 0)
        //                {
        //                    return thisID + "没有上级编码\n";
        //                }
        //            }
        //            break;
        //        case "department":
        //            sSQL = "select count(1) from dbo.Department where cDepCode = '" + thisID + "'";
        //            iCou = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
        //            if (iCou == 1)
        //            {
        //                return thisID + "已经存在\n";
        //            }

        //            if (thisID.Length > sList[0].Length)
        //            {
        //                sSQL = "select count(1) from dbo.Department where cDepCode = '" + oldID + "'";
        //                iCou = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
        //                if (iCou == 0)
        //                {
        //                    return thisID + "没有上级编码\n";
        //                }
        //            }
        //            break;
        //        case "districtclass":
        //            sSQL = "select count(1) from dbo.DistrictClass where cDCCode = '" + thisID + "'";
        //            iCou = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
        //            if (iCou == 1)
        //            {
        //                return thisID + "已经存在\n";
        //            }
        //            if (thisID.Length > sList[0].Length)
        //            {
        //                sSQL = "select count(1) from dbo.DistrictClass where cDCCode = '" + oldID + "'";
        //                iCou = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
        //                if (iCou == 0)
        //                {
        //                    return thisID + "没有上级编码\n";
        //                }
        //            }
        //            break;
        //        case "vendorclass":
        //            sSQL = "select count(1) from dbo.VendorClass where cVCCode = '" + thisID + "'";
        //            iCou = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
        //            if (iCou == 1)
        //            {
        //                return thisID + "已经存在\n";
        //            }
        //            if (thisID.Length > sList[0].Length)
        //            {
        //                sSQL = "select count(1) from dbo.VendorClass where cVCCode = '" + oldID + "'";
        //                iCou = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
        //                if (iCou == 0)
        //                {
        //                    return thisID + "没有上级编码\n";
        //                }
        //            }
        //            break;
        //    }

        //    return "";
        //}

        /// <summary>
        /// 判断编码原则
        /// </summary>
        /// <param name="TableID"></param>
        /// <param name="Code"></param>
        /// <param name="oldID"></param>
        /// <param name="thisID"></param>
        /// <returns></returns>
        //public static string CheckSerialNumber(string TableID, string oldID, string thisID)
        //{
        //    if (oldID == thisID.Substring(0, oldID.Length))
        //    {
        //        string sSQL = "select * from _SerialNumber where TableID='" + TableID + "'";
        //        DataTable dt = clsSQLCommond.ExecQuery(sSQL);

        //        int t=0;
        //        string[] type = dt.Rows[0]["Type"].ToString().Split('-');
        //        for (int i = 0; i < type.Length; i++)
        //        {
        //            if (t < oldID.Length)
        //            {
        //                t = t + type[i].Length;
        //            }
        //            else
        //            {
        //                if (t + type[i].Length != thisID.Length)
        //                {
        //                    return "不符合编码原则,编码原则" + dt.Rows[0]["Type"].ToString();
        //                }
        //                else
        //                {
        //                    return "";
        //                }
        //            }
                    
        //        }
        //    }
        //    else
        //    {
        //        return "不符合编码原则,子类别编码左侧必须等于类别编码";
        //    }
        //    return "";
        //}

        //public static void GetTreeFoucse(DevExpress.XtraTreeList.TreeList treeList1,string foucseID)
        //{
        //    for (int i = 0; i < treeList1.Nodes.Count; i++)
        //    {
        //        if (treeList1.Nodes[i].Tag.ToString().Trim() == foucseID)
        //        {
        //            treeList1.Nodes[i].Selected = true;
        //        }
        //        GetTreeFoucse(treeList1.Nodes[i], foucseID);
        //    }
        //}

        //public static void GetTreeFoucse(DevExpress.XtraTreeList.Nodes.TreeListNode tn, string foucseID)
        //{
        //    for (int i = 0; i < tn.Nodes.Count; i++)
        //    {
        //        if (tn.Nodes[i].Tag.ToString().Trim() == foucseID)
        //        {
        //            tn.Nodes[i].Selected = true;
        //        }
        //        GetTreeFoucse(tn, foucseID);
        //    }
        //}

        /// <summary>
        /// 得到连续的序列号
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="FieldName"></param>
        /// <param name="sID"></param>
        /// <returns></returns>
        public static string GetNewSerialNumberContinuous(string TableName, string FieldName)
        {
            ClsDataBase clsSQLCommond = new ClsDataBase();
            string sSQL = "select * from _SerialNumberContinuous where TableID='" + TableName + "' and Code='" + FieldName + "'";
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
            sSQL = "select isnull(max(" + FieldName + "),0)  from  " + TableName;
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            if (dt.Rows[0][0].ToString() != "0")
            {
                right = dt.Rows[0][0].ToString();
                right = right.Substring(left.Length + middle.Length, dts.Rows[0]["RightType"].ToString().Length);
                int iright = int.Parse(right) + 1;
                right = GetIsEnoughNumber(iright, dts.Rows[0]["RightType"].ToString().Length);
            }
            else
            {
                right = GetIsEnoughNumber(1, dts.Rows[0]["RightType"].ToString().Length);
            }
            return left + middle + right;
        }
    }
