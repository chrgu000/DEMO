using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace 系统服务
{
    public static class Table
    {
        #region 将DataRow[] 更改为DataTable
        public static DataTable DataRowToDataTable(DataRow[] dw)
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
        #endregion
    }
}
