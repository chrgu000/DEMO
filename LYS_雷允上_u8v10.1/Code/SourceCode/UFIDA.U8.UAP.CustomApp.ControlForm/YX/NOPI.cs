using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.Diagnostics;
using System.Windows.Forms;

/// <summary>
/// MyXls 的摘要说明
/// </summary>
public class NOPI
{
    public NOPI()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    /// <summary>
    /// NPOI简单Demo，快速入门代码
    /// </summary>
    /// <param name="dtSource"></param>
    /// <param name="strFileName"></param>
    /// <remarks>NPOI认为Excel的第一个单元格是：(0，0)</remarks>
    /// <Author></Author>
    public static DataTable FromExcel(string filePath, string sheetname, int StartRow, int StartColumns, int LenColumns)
    {
        DataTable dt = new DataTable();
        HSSFWorkbook hssfWorkbook = new HSSFWorkbook(new FileStream(filePath, FileMode.Open));
        for (int sheetIndex = 0; sheetIndex < hssfWorkbook.NumberOfSheets; ++sheetIndex) 
        {

            HSSFSheet hssfSheet = hssfWorkbook.GetSheetAt(sheetIndex) as HSSFSheet;
            if (hssfSheet.SheetName == sheetname)
            {
                HSSFRow currentRow = hssfSheet.GetRow(StartRow) as HSSFRow;
                for (int columnIndex = StartColumns; columnIndex < StartColumns + LenColumns; columnIndex++)
                {
                    HSSFCell currentCell = currentRow.GetCell(columnIndex) as HSSFCell;
                    string title = currentCell.ToString().Trim();
                    bool b = true;
                    for (int s = 0; s < dt.Columns.Count; s++)
                    {
                        if (dt.Columns[s].ColumnName == title)
                        {
                            dt.Columns.Add(title + "1");
                            b = false;
                            break;
                        }
                    }
                    if (b == true)
                    {
                        dt.Columns.Add(title);
                    }
                }

                for (int j = StartRow + 1; j <= hssfSheet.LastRowNum; j++)
                {
                    HSSFRow cRow = hssfSheet.GetRow(j) as HSSFRow;
                    if (cRow != null)
                    {
                        DataRow dw = dt.NewRow();
                        for (int columnIndex = StartColumns; columnIndex < StartColumns + LenColumns; columnIndex++)
                        {
                            HSSFCell cCell = cRow.GetCell(columnIndex) as HSSFCell;
                            if (cCell != null)
                            {
                                dw[columnIndex] = cCell.ToString().Trim();
                            }
                        }
                        dt.Rows.Add(dw);
                    }

                }
            }
        }

        return dt;

    }

}
