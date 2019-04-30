using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using TH.BaseClass;

namespace DllForTK
{
    public class clsGetBOM
    {
        DataTable dtBom = new DataTable();

        public void GetBOMByToplevel(SqlTransaction tran, string sVerData, string sUid, string sPath, string sToplevel)
        {
            string sSQL = @"
select a.* ,isnull(b.[iCycle],0) as iCycle,a.toplevel as Relation
from [dbo].[TK_BOM] a left join ( select max(iCycle) as iCycle,sItemNo from [dbo].[TK_Base_ItemNo_Cycle] group by sItemNo)  b on a.child = b.[sItemNo]
where a.toplevel = N'{0}'
order by a.depth
";
            sSQL = string.Format(sSQL, sToplevel);
            dtBom = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
            long iCycle = BaseFunction.ReturnLong(dtBom.Rows[0]["iCycle"]);

            //标记产品周期
            sSQL = @"
update [TK_BOM] set childCycle = {0},childsCycle = {0}
where toplevel = N'{1}' and parent = N'{1}' and child = N'{1}'
";
            sSQL = string.Format(sSQL, iCycle, sToplevel);
            int iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

            InitBomN(tran, sToplevel, sToplevel, iCycle, sToplevel);


            //去除虚拟件
            for (int j = dtBom.Rows.Count - 1; j >= 0; j--)
            {
                if (dtBom.Rows[j]["childsm"].ToString().Trim().ToLower() != "PHANTOM".ToLower())
                    continue;

                ClsWriteLog.WriteLog(sPath, "同步数据", "BOM\t去除虚拟件 " + dtBom.Rows[j]["child"].ToString().Trim());

                string sChild = dtBom.Rows[j]["child"].ToString().Trim();
                string sparent = dtBom.Rows[j]["parent"].ToString().Trim();
                long iID = BaseFunction.ReturnLong(dtBom.Rows[j]["iID"]);
                string sRelation = dtBom.Rows[j]["Relation"].ToString().Trim();

                //string sTemp = sRelation.Replace("◆" + sparent, "");
                //string[] s = sTemp.Split('◆');
                decimal dQty = BaseFunction.ReturnDecimal(dtBom.Rows[j]["qty"]);

                DataRow[] drListBom = dtBom.Select(" [parent] = '" + sChild + "' and Relation like '" + sRelation + "%'");
                for (int k = 0; k < drListBom.Length; k++)
                {
                    decimal dQty2 = BaseFunction.ReturnDecimal(drListBom[k]["qty"]);
                    //decimal dCumqty2 = BaseFunction.ReturnDecimal(drListBom[k]["cumqty"]);

                    drListBom[k]["qty"] = decimal.Round(dQty * dQty2, 6);
                    //drListBom[k]["cumqty"] = decimal.Round(dQty * dCumqty2, 6);
                    drListBom[k]["parent"] = sparent;
                    drListBom[k]["depth"] = BaseFunction.ReturnInt(drListBom[k]["depth"]) - 1;
                }

                dtBom.Rows[j]["bDel"] = true;

                sSQL = @"
update [TK_BOM] set bDel = 1
where iID = {0}
                    ";
                sSQL = string.Format(sSQL, iID);
                iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
            }

            //将变更后的数据写入数据库
            for (int ii = 0; ii < dtBom.Rows.Count; ii++)
            {
                string sTop = dtBom.Rows[ii]["toplevel"].ToString().Trim();
                string sParent = dtBom.Rows[ii]["parent"].ToString().Trim();
                string sChild = dtBom.Rows[ii]["child"].ToString().Trim();
                if (sTop.ToLower() == sParent.ToLower() && sParent.ToLower() == sChild.ToLower())
                {
                    continue;
                }
                ClsWriteLog.WriteLog(sPath, "同步数据", "BOM\t将变更后的数据写入数据库 【" + sTop + "】 - 【" + sParent + "】 - 【" + sChild + "】");

                int childCycle = BaseFunction.ReturnInt(dtBom.Rows[ii]["childCycle"]);
                int childsCycle = BaseFunction.ReturnInt(dtBom.Rows[ii]["childsCycle"]);
                long iID = BaseFunction.ReturnLong(dtBom.Rows[ii]["iID"]);
                decimal dQty = BaseFunction.ReturnDecimal(dtBom.Rows[ii]["qty"]);

                sSQL = @"
update [TK_BOM] set childCycle = {0},childsCycle = {1},qty = {3},parent='{4}',depth={5}
where iID = {2}
";
                sSQL = string.Format(sSQL, childCycle, childsCycle, iID, dQty, sParent, dtBom.Rows[ii]["depth"]);
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
            }
        }


        public string GetBOM(SqlTransaction tran, string sVerData, string sUid,string sPath)
        {
            try
            {
                ClsWriteLog.WriteLog(sPath,  "同步数据", "BOM\t清除历史BOM，插入当前BOM");
                string sSQL = @"
truncate table [TK_BOM];

insert into [dbo].[TK_BOM]( depth, toplevel, parent, child, qty, cumqty, childsm, topprodgroup,b.[sDataVersion])
select distinct  ltrim(rtrim(REPLACE(depth,'.',''))), toplevel, parent, child, max(a.qty) as qty, max(a.cumqty) as cumqty, childsm, topprodgroup,[sVersion]
from _GetBomView a left join [dbo].[TK_NetRequirement_Sum] b on a.toplevel = b.sPartID
where b.sPartID is not null
group by  depth, toplevel, parent, child, childsm, topprodgroup,b.[sVersion]
";
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                sSQL = @"
select distinct toplevel from [dbo].[TK_BOM]
";
                DataTable dtToplevel = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                for (int i = 0; i < dtToplevel.Rows.Count; i++)
                {
                    string sToplevel = dtToplevel.Rows[i]["toplevel"].ToString().Trim();
                    GetBOMByToplevel(tran, sVerData, sUid, sPath, sToplevel);
                }

                ClsWriteLog.WriteLog(sPath, "同步数据", "BOM\t刷新其他数据");

                sSQL = @"
delete TK_BOM where bDel = 1

-- 设置低阶码
update a set a.depths = b.depths
from [TK_BOM] a
	inner join  (select max(depth) as depths,toplevel from [TK_BOM] group by toplevel) b on a.toplevel = b.toplevel
;
-- 设定Toplevel中共用件种类数
update  a set a.CommonParts = isnull(b.iCou,0)
from [TK_BOM] a
	left join 
	(
		select toplevel,count(iCou) as iCou
		from TK_BOM bom left join
			(
					select child,count(1) as iCou
					from
					(
						select distinct toplevel,child from [dbo].[TK_BOM] where childsm = 'PURCHASED' 
					) a 
					group by child
				) a on bom.child = a.child
		where a.iCou > 1
		group by toplevel
	)b on a.toplevel = b.toplevel 

;

-- 标记BOM不参与计算的采购件
update a set a.[Exclude] = 1
from  [TK_BOM] a inner join TK_Base_ItemNo_Exclude b on a.child = b.sItemNo
;

-- 标记BOM不参与计算的自制件
update a set a.[Exclude] = 1
from  [TK_BOM] a inner join TK_Base_ItemNo_Exclude b on a.parent = b.sItemNo
;
";
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
            }
            catch (Exception ee)
            {
                return ee.Message;
            }

            return "";

        }

        /// <summary>
        /// 递归，标记周期
        /// </summary>
        /// <param name="tran"></param>
        /// <param name="stoplevel">产品编码</param>
        /// <param name="sInvCode">当前层物料编码</param>
        /// <param name="iCycle">当前层物料周期</param>
        private void InitBomN(SqlTransaction tran, string stoplevel, string sInvCode, long iCycle, string Relation)
        {
            string sWhere = "[toplevel] = '{0}' and  [parent] = '{1}' and [child] <> '{1}'";
            sWhere = string.Format(sWhere, stoplevel, sInvCode);

            DataRow[] drList = dtBom.Select(sWhere);

            foreach (DataRow dr in drList)
            {
                int iCycle_child = BaseFunction.ReturnInt(dr["iCycle"]);
                string sChild = dr["child"].ToString().Trim();
                string childsm = dr["childsm"].ToString().Trim().ToLower();

                //if (childsm == "PHANTOM".ToLower())
                //{

                //}

                dr["childCycle"] = iCycle_child;
                long childsCycle = iCycle_child + iCycle;
                dr["childsCycle"] = childsCycle;

                dr["Relation"] = Relation + "◆" + sChild;
                if (childsm == "PURCHASED".ToLower())
                    continue;

                InitBomN(tran, stoplevel, sChild, childsCycle, dr["Relation"].ToString().Trim());
            }
        }


        public string Insert(SqlTransaction tran)
        {
            try
            {
                string sSQL = "";

                sSQL = "truncate table TK_BOM_Order ";
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                //////计算开始
                sSQL = "select * from TK_BOM WHERE depth = 1 order by toplevel";
                DataTable dtg = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                s = 1;

                for (int i = 0; i < dtg.Rows.Count; i++)
                {
                    string toplevel = dtg.Rows[i]["toplevel"].ToString();
                    Insert(tran, toplevel);

                    sSQL = "select parent as sparent,child as schild from TK_BOM WHERE toplevel='" + toplevel + "' and depth <> 1";
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    DataRow[] dw = dt.Select("sparent='" + toplevel + "'");
                    for (int j = 0; j < dw.Length; j++)
                    {
                        string child = dw[j]["schild"].ToString();
                        Insert(tran, child);

                        GetTree(tran, dtg, dt, toplevel, child);
                    }
                }

                return "OK";
            }
            catch (Exception ee)
            {
                return ee.Message;
            }
        }

        private void GetTree(SqlTransaction tran, DataTable dtg, DataTable dt, string toplevel, string child)
        {
            DataRow[] dw = dt.Select("sparent='" + child + "'");
            for (int j = 0; j < dw.Length; j++)
            {
                string schild = dw[j]["schild"].ToString();
                Insert(tran, schild);

                GetTree(tran, dtg, dt, toplevel, schild);
            }
        }

        private void Insert(SqlTransaction tran, string child)
        {
            Model.TK_BOM_OrderEntity model = new Model.TK_BOM_OrderEntity();
            model.child = child;
            model.orderid = s;


            DAL.TK_BOM_OrderData dal = new DAL.TK_BOM_OrderData();
            string sSQL = dal.Add(model);
            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
            s++;
        }


        int s = 1;
    }
}
