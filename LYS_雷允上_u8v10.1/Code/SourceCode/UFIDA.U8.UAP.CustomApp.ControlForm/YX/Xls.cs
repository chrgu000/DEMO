using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using org.in2bits.MyXls;
using org.in2bits.MyXls.ByteUtil;
using System.Diagnostics;
using System.Windows.Forms;

/// <summary>
/// MyXls 的摘要说明
/// </summary>
public class Xls
{
    public Xls()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    #region 保存Table至Excel
    /// <summary>
    /// DataTable中数据保存进Excel
    /// </summary>
    /// <param name="filePath">保存路径</param>
    /// <param name="excelTable">DataTable</param>
    /// <param name="sheetName">Excel表名</param>
    /// <returns></returns>
    public static bool ToExcel(string filePath, System.Data.DataSet ds)
    {
        XlsDocument xls = new XlsDocument();//新建一个xls文档
        xls.FileName = filePath;//设定文件名
        for (int p = 0; p < ds.Tables.Count; p++)
        {
            Worksheet sheet = xls.Workbook.Worksheets.Add(ds.Tables[p].TableName);
            System.Data.DataTable excelTable = ds.Tables[p];
            Cells cells = sheet.Cells;
            

            int columns = excelTable.Columns.Count;
            int rows = excelTable.Rows.Count;

            for (int j = 0; j < columns; j++)
            {
                Cell cell = cells.Add(1, j + 1, excelTable.Columns[j].ColumnName);//设定第一行，第二例单元格的值
            }
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (excelTable.Columns[j].DataType.Name == "Decimal" || excelTable.Columns[j].DataType.Name == "Int32"|| excelTable.Columns[j].DataType.Name == "Double" ||excelTable.Columns[j].DataType.Name == "Int64")
                    {
                        if (excelTable.Rows[i][j].ToString().Trim() != "")
                        {
                            Cell cell = cells.Add(i + 2, j + 1, Convert.ToDecimal(excelTable.Rows[i][j].ToString()));
                        }
                    }
                    else
                    {
                        Cell cell = cells.Add(i + 2, j + 1, excelTable.Rows[i][j].ToString());//设定第一行，第二例单元格的值
                    }
                }
            }
        }
        xls.Save(true);

        return true;

    }
    #endregion


}
