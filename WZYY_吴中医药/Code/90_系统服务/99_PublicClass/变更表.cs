using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace 系统服务
{
    public static class 变更表
    {
        static 系统服务.ClsDataBase clsSQLCommond = 系统服务.ClsDataBaseFactory.Instance();

        public static bool GetChange(string tablename, string tablenames, string id, ClsGetSQL clsGetSQL, System.Collections.ArrayList aList)
        {
            string sSQL = "";

            sSQL = "select isnull(max(HistoryNum)+1,1) as HistoryId from " + tablename + "History where ID='" + id + "'";
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

            DateTime HistoryTime = DateTime.Now;

            for (int i = 0; i < dtalter.Rows.Count; i++)
            {
                DataRow dwalter = dtalterHistory.NewRow();
                dwalter["HistoryId"] = HistoryId;
                dwalter["HistoryTime"] = HistoryTime.ToString().Trim();
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
                dwalter["HistoryTime"] = HistoryTime.ToString().Trim();
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

        public static bool GetChange(string tablename, string tablenames, string tablenamel, string id, ClsGetSQL clsGetSQL, System.Collections.ArrayList aList)
        {
            string sSQL = "";

            sSQL = "select isnull(max(HistoryNum)+1,1) as HistoryId from " + tablename + "History where ID='" + id + "'";
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

            DateTime HistoryTime = DateTime.Now;

            for (int i = 0; i < dtalter.Rows.Count; i++)
            {
                DataRow dwalter = dtalterHistory.NewRow();
                dwalter["HistoryId"] = HistoryId;
                dwalter["HistoryTime"] = HistoryTime.ToString().Trim();
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
                dwalter["HistoryTime"] = HistoryTime.ToString().Trim();
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
                dwalter["HistoryTime"] = HistoryTime.ToString().Trim();
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

        public static bool GetChange(string tablename, string tablenames, string tablenamel,string tablenamec, string id, ClsGetSQL clsGetSQL, System.Collections.ArrayList aList)
        {
            string sSQL = "";

            sSQL = "select isnull(max(HistoryNum)+1,1) as HistoryId from " + tablename + "History where ID='" + id + "'";
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

            DateTime HistoryTime = DateTime.Now;

            for (int i = 0; i < dtalter.Rows.Count; i++)
            {
                DataRow dwalter = dtalterHistory.NewRow();
                dwalter["HistoryId"] = HistoryId;
                dwalter["HistoryTime"] = HistoryTime.ToString().Trim();
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
                dwalter["HistoryTime"] = HistoryTime.ToString().Trim();
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
                dwalter["HistoryTime"] = HistoryTime.ToString().Trim();
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
                dwalter["HistoryTime"] = HistoryTime.ToString().Trim();
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

        public static bool GetDelRow(string tablenames, string id, System.Collections.ArrayList aList)
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

        public static bool GetDelRow(string tablenames, string tablenamel, string id, System.Collections.ArrayList aList)
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

    }
}
