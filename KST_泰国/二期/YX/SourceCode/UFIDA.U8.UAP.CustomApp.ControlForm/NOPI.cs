using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
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

    #region 从excel导入
    /// <summary>
    /// 
    /// </summary>
    /// <param name="dtSource"></param>
    /// <param name="strFileName"></param>
    /// <remarks></remarks>
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
    #endregion

    public static bool ToExcel(string filePath, string type)
    {
        Stream MyExcelStream = OpenClasspathResource(filePath);
        HSSFWorkbook workbook = new HSSFWorkbook(MyExcelStream);
        HSSFSheet hs = (HSSFSheet)workbook.GetSheet(workbook.GetSheetName(0));
        IRow row = hs.CreateRow(0);
        return true;
    }

    private static Stream OpenClasspathResource(string fileName)
    {
        FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
        return file;
    }
         

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dtSource"></param>
    /// <param name="strFileName"></param>
    /// <remarks></remarks>
    /// <Author></Author>
    public static bool ToExcel(string filePath, DevExpress.XtraGrid.Views.Grid.GridView gridview, DevExpress.XtraGrid.Views.BandedGrid.BandedGridView gridview2, string SheetName, string SheetName2)
    {
        HSSFWorkbook wk = new HSSFWorkbook();
        //try
        //{

        NewSheet(wk, gridview, SheetName);
        NewSheet(wk, gridview2, SheetName2);


        using (FileStream fs = File.OpenWrite(@filePath)) //打开一个xls文件，如果没有则自行创建，如果存在myxls.xls文件则在创建是不要打开该文件！
        {
            wk.Write(fs);   //向打开的这个xls文件中写入mySheet表并保存。
            //MessageBox.Show("提示：创建成功！");
        }

        return true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dtSource"></param>
    /// <param name="strFileName"></param>
    /// <remarks></remarks>
    /// <Author></Author>
    public static bool ToExcel2(string filePath, DevExpress.XtraGrid.Views.Grid.GridView gridview, DevExpress.XtraGrid.Views.BandedGrid.BandedGridView gridview2, string SheetName)
    {
        HSSFWorkbook wk = new HSSFWorkbook();
        //try
        //{

        NewSheet2(wk, gridview, gridview2, SheetName);
        

        using (FileStream fs = File.OpenWrite(@filePath)) //打开一个xls文件，如果没有则自行创建，如果存在myxls.xls文件则在创建是不要打开该文件！
        {
            wk.Write(fs);   //向打开的这个xls文件中写入mySheet表并保存。
            //MessageBox.Show("提示：创建成功！");
        }

        return true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dtSource"></param>
    /// <param name="strFileName"></param>
    /// <remarks></remarks>
    /// <Author></Author>
    public static bool ToExcel(string filePath, DevExpress.XtraGrid.Views.Grid.GridView gridview, string SheetName)
    {
        HSSFWorkbook wk = new HSSFWorkbook();
        //try
        //{

        NewSheet(wk, gridview, SheetName);


        using (FileStream fs = File.OpenWrite(@filePath)) //打开一个xls文件，如果没有则自行创建，如果存在myxls.xls文件则在创建是不要打开该文件！
        {
            wk.Write(fs);   //向打开的这个xls文件中写入mySheet表并保存。
            //MessageBox.Show("提示：创建成功！");
        }

        return true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dtSource"></param>
    /// <param name="strFileName"></param>
    /// <remarks></remarks>
    /// <Author></Author>
    public static bool ToExcel(string filePath, DevExpress.XtraGrid.Views.BandedGrid.BandedGridView gridview, string SheetName)
    {
        HSSFWorkbook wk = new HSSFWorkbook();
        
        //try
        //{
        NewSheet(wk, gridview, SheetName);

        //}
        //catch
        //{

        //}
        using (FileStream fs = File.OpenWrite(@filePath)) //打开一个xls文件，如果没有则自行创建，如果存在myxls.xls文件则在创建是不要打开该文件！
        {
            wk.Write(fs);   //向打开的这个xls文件中写入mySheet表并保存。
            //MessageBox.Show("提示：创建成功！");
        }

        return true;
    }

    public static void NewSheet(HSSFWorkbook wk, DevExpress.XtraGrid.Views.Grid.GridView gridview, string SheetName)
    {
        ISheet tb = wk.CreateSheet(SheetName);

        IRow irowband = tb.CreateRow(0);

        tb.CreateFreezePane(0, 1, 0, 1);

        int icount = 0;
        int icount2 = 0;
        for (int j = 0; j < gridview.Columns.Count; j++)
        {
            if (gridview.Columns[j].Visible == true)
            {
                ICell ic2 = irowband.CreateCell(icount2);
                ic2.SetCellValue(gridview.Columns[j].Caption);
                ic2.CellStyle = Getcellstyle(wk, stylexls.头);

                tb.SetDefaultColumnStyle(j, GetColStyle(wk));

                icount2 = icount2 + 1;
            }
        }

        CellRangeAddress c = new CellRangeAddress(0, 1, 0, icount2 - 1);
        tb.SetAutoFilter(c);

        icount = icount2;

        


        for (int i = 0; i < gridview.RowCount; i++)
        {
            int scount = 0;
            IRow irow = tb.CreateRow(i + 1);
            for (int j = 0; j < gridview.Columns.Count; j++)
            {
                if (gridview.Columns[j].Visible == true)
                {
                    string value = "";
                    ICell icell1top = irow.CreateCell(scount);
                    try
                    {
                        value = gridview.GetRowCellDisplayText(i, gridview.Columns[j]).ToString();
                    }
                    catch
                    {
                    }
                    string lvalue = "";
                    if (value.Length > 0)
                    {
                        lvalue = value.Substring(0, 1);

                    }


                    if (value != "")
                    {
                        if (lvalue == "￥" || lvalue == "$" || lvalue == "€")
                        {
                            value = value.Substring(1, value.Length - 1);
                        }
                    }

                    if (lvalue == "￥" || lvalue == "$" || lvalue == "€")
                    {
                        if (value != "")
                        {
                            double svalue = double.Parse(value);
                            icell1top.SetCellValue(svalue);
                        }
                        icell1top.CellStyle = Getcellstyle(wk, stylexls.货币, lvalue);
                    }
                    else if (gridview.Columns[j].DisplayFormat.FormatType == DevExpress.Utils.FormatType.Numeric)
                    {
                        if (value != "")
                        {
                            double svalue = double.Parse(value);
                            icell1top.SetCellValue(svalue);
                        }
                        icell1top.CellStyle = Getcellstyle(wk, stylexls.数字);
                    }
                    else if (gridview.Columns[j].DisplayFormat.FormatType == DevExpress.Utils.FormatType.DateTime)
                    {
                        if (value != "")
                        {
                            icell1top.SetCellValue(DateTime.Parse(value));
                        }
                        icell1top.CellStyle = Getcellstyle(wk, stylexls.时间);
                    }
                    else
                    {
                        icell1top.SetCellValue(value);
                        //icell1top.CellStyle = Getcellstyle(wk, stylexls.默认);
                    }

                    if ((value.Length + lvalue.Length) * 256 + 350 > tb.GetColumnWidth(scount))
                    {
                        tb.SetColumnWidth(scount, (value.Length + lvalue.Length) * 256 + 350);
                    }

                    scount = scount + 1;
                }
            }

        }
    }

    public static void NewSheet(HSSFWorkbook wk, DevExpress.XtraGrid.Views.BandedGrid.BandedGridView gridview, string SheetName)
    {
        ISheet tb = wk.CreateSheet(SheetName);

        IRow irowband = tb.CreateRow(0);
        IRow irowcol = tb.CreateRow(1);

        tb.CreateFreezePane(0, 2, 0, 2);

        ICellStyle ictitle = Getcellstyle(wk, stylexls.头);
        ICellStyle icrow = Getcellstyle(wk, stylexls.默认);
        ICellStyle ictime = Getcellstyle(wk, stylexls.时间);
        ICellStyle icdigital = Getcellstyle(wk, stylexls.数字);

        
        int icount = 0;
        int icount2 = 0;


        for (int i = 0; i < gridview.Bands.Count; i++)
        {

            for (int j = 0; j < gridview.Bands[i].Columns.Count; j++)
            {
                if (gridview.Bands[i].Columns[j].Visible == true)
                {
                    ICell ic2 = irowcol.CreateCell(icount2);
                    ic2.SetCellValue(gridview.Bands[i].Columns[j].Caption);
                    ic2.CellStyle = ictitle;
                    tb.SetColumnWidth(icount2, gridview.Bands[i].Columns[j].Caption.Length * 256);

                    ICell ic1 = irowband.CreateCell(icount2);
                    ic1.CellStyle = ictitle;

                    icount2 = icount2 + 1;
                }
            }

            if (gridview.Bands[i].Columns.Count != 1)
            {
                tb.AddMergedRegion(new CellRangeAddress(0, 0, icount, icount2 - 1));
            }

            ICell ic = irowband.CreateCell(icount);
            ic.SetCellValue(gridview.Bands[i].Caption);
            ic.CellStyle= ictitle;
            icount = icount2;
        }
        CellRangeAddress c = new CellRangeAddress(1, 1, 0, icount2 - 1);

        tb.SetAutoFilter(c);

        

        for (int i = 0; i < gridview.RowCount; i++)
        {
            int scount = 0;
            IRow irow = tb.CreateRow(i + 2);
            for (int j = 0; j < gridview.Columns.Count; j++)
            {
                if (gridview.Columns[j].Visible == true)
                {
                    string value = "";
                    ICell icell1top = irow.CreateCell(scount);
                    icell1top.CellStyle = icrow;
                    try
                    {
                        value = gridview.GetRowCellDisplayText(i, gridview.Columns[j]).ToString();
                    }
                    catch
                    {
                    }
                    string lvalue = "";
                    if (value.Length > 0)
                    {
                        lvalue = value.Substring(0, 1);

                    }


                    if (value != "")
                    {
                        if (lvalue == "￥" || lvalue == "$" || lvalue == "€")
                        {
                            value = value.Substring(1, value.Length - 1);
                        }
                    }

                    if (lvalue == "￥" || lvalue == "$" || lvalue == "€")
                    {
                        if (value != "")
                        {
                            double svalue = double.Parse(value);
                            icell1top.SetCellValue(svalue);
                        }
                        icell1top.CellStyle = Getcellstyle(wk, stylexls.货币, lvalue);
                    }
                    else if (gridview.Columns[j].DisplayFormat.FormatType == DevExpress.Utils.FormatType.Numeric)
                    {
                        if (value != "")
                        {
                            double svalue = double.Parse(value);
                            icell1top.SetCellValue(svalue);
                        }
                        icell1top.CellStyle = icdigital;
                    }
                    else if (gridview.Columns[j].DisplayFormat.FormatType == DevExpress.Utils.FormatType.DateTime)
                    {
                        if (value != "")
                        {
                            icell1top.SetCellValue(DateTime.Parse(value));
                        }
                        icell1top.CellStyle = ictime;
                    }
                    else
                    {
                        icell1top.SetCellValue(value);
                        //icell1top.CellStyle = Getcellstyle(wk, stylexls.默认);
                    }
                    //else if (type == System.Type.GetType("System.Decimal") || type == System.Type.GetType("System.Int32") || type == System.Type.GetType("System.Int64") || type == System.Type.GetType("System.Double") || type == System.Type.GetType("System.Decimal"))
                    //{
                    //    icell1top.CellStyle = Getcellstyle(wk, stylexls.数字);
                    //}


                    if ((value.Length +lvalue.Length)* 256+350 > tb.GetColumnWidth(scount))
                    {
                        int mcount = (value.Length + lvalue.Length) * 256 + 350;
                        if (mcount > 30 * 256)
                        {
                            mcount = 30 * 256;
                        }
                        tb.SetColumnWidth(scount, mcount);
                    }

                    scount = scount + 1;
                }
            }

        }
    
    }

    public static void NewSheet2(HSSFWorkbook wk, DevExpress.XtraGrid.Views.Grid.GridView gridview, DevExpress.XtraGrid.Views.BandedGrid.BandedGridView gridview2, string SheetName)
    {
        ISheet tb = wk.CreateSheet(SheetName);

        IRow irowband = tb.CreateRow(0);

        tb.CreateFreezePane(0, 1, 0, 1);

        ICellStyle ictitle = Getcellstyle(wk, stylexls.头);
        ICellStyle icrow = Getcellstyle(wk, stylexls.默认);
        ICellStyle ictime = Getcellstyle(wk, stylexls.时间);
        ICellStyle icdigital = Getcellstyle(wk, stylexls.数字);
        
        int icount = 0;
        int icount2 = 0;

        #region 表1
        for (int j = 0; j < gridview.Columns.Count; j++)
        {
            if (gridview.Columns[j].Visible == true)
            {
                ICell ic2 = irowband.CreateCell(icount2);
                ic2.SetCellValue(gridview.Columns[j].Caption);
                ic2.CellStyle = ictitle;

                icount2 = icount2 + 1;
            }
        }

        CellRangeAddress c = new CellRangeAddress(0, 0, 0, icount2 - 1);
        tb.SetAutoFilter(c);

        for (int i = 0; i < gridview.RowCount; i++)
        {

            int scount = 0;
            icount = icount + 1;
            IRow irow = tb.CreateRow(icount);
            for (int j = 0; j < gridview.Columns.Count; j++)
            {
                if (gridview.Columns[j].Visible == true)
                {
                    string value = "";
                    ICell icell1top = irow.CreateCell(scount);
                    icell1top.CellStyle = icrow;
                    try
                    {
                        value = gridview.GetRowCellDisplayText(i, gridview.Columns[j]).ToString();
                    }
                    catch
                    {
                    }
                    string lvalue = "";
                    if (value.Length > 0)
                    {
                        lvalue = value.Substring(0, 1);

                    }


                    if (value != "")
                    {
                        if (lvalue == "￥" || lvalue == "$" || lvalue == "€")
                        {
                            value = value.Substring(1, value.Length - 1);
                        }
                    }

                    if (lvalue == "￥" || lvalue == "$" || lvalue == "€")
                    {
                        if (value != "")
                        {
                            double svalue = double.Parse(value);
                            icell1top.SetCellValue(svalue);
                        }
                        icell1top.CellStyle = Getcellstyle(wk, stylexls.货币, lvalue);
                    }
                    else if (gridview.Columns[j].DisplayFormat.FormatType == DevExpress.Utils.FormatType.Numeric)
                    {
                        if (value != "")
                        {
                            double svalue = double.Parse(value);
                            icell1top.SetCellValue(svalue);
                        }
                        icell1top.CellStyle = icdigital;
                    }
                    else if (gridview.Columns[j].DisplayFormat.FormatType == DevExpress.Utils.FormatType.DateTime)
                    {
                        if (value != "")
                        {
                            icell1top.SetCellValue(DateTime.Parse(value));
                        }
                        icell1top.CellStyle = ictime;
                    }
                    else
                    {
                        icell1top.SetCellValue(value);
                    }

                    if ((value.Length + lvalue.Length) * 256 + 350 > tb.GetColumnWidth(scount))
                    {
                        int mcount=(value.Length + lvalue.Length) * 256 + 350;
                        if (mcount > 30*256)
                        {
                            mcount = 30*256;
                        }
                        tb.SetColumnWidth(scount, mcount);
                    }
                    scount = scount + 1;
                }
            }

        }
        #endregion

        #region 表2
        icount2 = 0;
        icount = icount + 5;
        IRow irowband2 = tb.CreateRow(icount);
        icount = icount + 1;
        IRow irowcol = tb.CreateRow(icount);

        int newcount = 0;
        for (int i = 0; i < gridview2.Bands.Count; i++)
        {
            for (int j = 0; j < gridview2.Bands[i].Columns.Count; j++)
            {
                newcount = newcount + 1;
            }
        }
        for (int i = 0; i < newcount; i++)
        {
            ICell ic = irowband2.CreateCell(i);
            ic.CellStyle = ictitle;
            ICell ic1 = irowcol.CreateCell(i);
            ic1.CellStyle = ictitle;
        }
        for (int i = 0; i < gridview2.Bands.Count; i++)
        {
            if (gridview2.Bands[i].Columns.Count != 1)
            {
                tb.AddMergedRegion(new CellRangeAddress(icount - 1, icount - 1, icount2, icount2 + gridview2.Bands[i].Columns.Count - 1));

                ICell ic = irowband2.CreateCell(icount2);
                ic.SetCellValue(gridview2.Bands[i].Caption);
                ic.CellStyle = ictitle;

                for (int j = 0; j < gridview2.Bands[i].Columns.Count; j++)
                {
                    if (gridview2.Bands[i].Columns[j].Visible == true)
                    {
                        ICell ic2 = irowcol.CreateCell(icount2);
                        ic2.SetCellValue(gridview2.Bands[i].Columns[j].Caption);
                        ic2.CellStyle = ictitle;
                        icount2 = icount2 + 1;
                    }
                }
            }
            else
            {
                tb.AddMergedRegion(new CellRangeAddress(icount - 1, icount, icount2, icount2));
                ICell ic = irowband2.CreateCell(icount2);
                ic.SetCellValue(gridview2.Bands[i].Columns[0].Caption);
                ic.CellStyle =ictitle;
                icount2 = icount2 + 1;
            }

        }

        for (int i = 0; i < gridview2.RowCount; i++)
        {
            int scount = 0;
            icount = icount + 1;
            IRow irow = tb.CreateRow(icount);
            for (int j = 0; j < gridview2.Columns.Count; j++)
            {
                if (gridview2.Columns[j].Visible == true)
                {
                    string value = "";
                    ICell icell1top = irow.CreateCell(scount);
                    icell1top.CellStyle = icrow;
                    try
                    {
                        value = gridview2.GetRowCellDisplayText(i, gridview2.Columns[j]).ToString();
                    }
                    catch
                    {
                    }
                    string lvalue = "";
                    if (value.Length > 0)
                    {
                        lvalue = value.Substring(0, 1);

                    }


                    if (value != "")
                    {
                        if (lvalue == "￥" || lvalue == "$" || lvalue == "€")
                        {
                            value = value.Substring(1, value.Length - 1);
                        }
                    }

                    if (lvalue == "￥" || lvalue == "$" || lvalue == "€")
                    {
                        if (value != "")
                        {
                            double svalue = double.Parse(value);
                            icell1top.SetCellValue(svalue);
                        }
                        icell1top.CellStyle = Getcellstyle(wk, stylexls.货币, lvalue);
                    }
                    else if (gridview2.Columns[j].DisplayFormat.FormatType == DevExpress.Utils.FormatType.Numeric)
                    {
                        if (value != "")
                        {
                            double svalue = double.Parse(value);
                            icell1top.SetCellValue(svalue);
                        }
                        icell1top.CellStyle = icdigital;
                    }
                    else if (gridview2.Columns[j].DisplayFormat.FormatType == DevExpress.Utils.FormatType.DateTime)
                    {
                        if (value != "")
                        {
                            icell1top.SetCellValue(DateTime.Parse(value));
                        }
                        icell1top.CellStyle = ictime;
                    }
                    else
                    {
                        icell1top.SetCellValue(value);
                    }

                    if ((value.Length + lvalue.Length) * 256 + 350 > tb.GetColumnWidth(scount))
                    {
                        tb.SetColumnWidth(scount, (value.Length + lvalue.Length) * 256 + 350);
                    }

                    scount = scount + 1;
                }
            }

        }
        #endregion


    }

    #region 定义单元格常用到样式的枚举
    public enum stylexls
    {
        头,
        url,
        时间,
        数字,
        货币,
        百分比,
        中文大写,
        科学计数法,
        默认
    }
    #endregion

    #region
    public enum stylemoney
    {
        人民币='￥',
        美元='$',
        欧元='€'
    }
    #endregion

    static ICellStyle GetColStyle(IWorkbook wb)
    {
        ICellStyle cellStyle = wb.CreateCellStyle();

        cellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.THIN;
        cellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.THIN;
        cellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.THIN;
        cellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.THIN;

        return cellStyle;

    }

    #region 定义单元格常用到样式
    static ICellStyle Getcellstyle(IWorkbook wb, stylexls str)
    {
        ICellStyle cellStyle = wb.CreateCellStyle();

        //定义几种字体  
        //也可以一种字体，写一些公共属性，然后在下面需要时加特殊的  
        IFont font12 = wb.CreateFont();
        //font12.FontHeightInPoints = 10;
        //font12.FontName = "微软雅黑";
        

        IFont font = wb.CreateFont();
        //font.FontName = "微软雅黑";
        //font.Underline = 1;下划线  

        IFont fontcolorblue = wb.CreateFont();
        //fontcolorblue.Color = HSSFColor.OLIVE_GREEN.BLUE.index;
        //fontcolorblue.IsItalic = true;//下划线  
        //fontcolorblue.FontName = "微软雅黑";


        //边框  
        cellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.THIN;
        cellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.THIN;
        cellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.THIN;
        cellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.THIN;

        //边框颜色  
        //cellStyle.LeftBorderColor = NPOI.HSSF.Util.HSSFColor.OLIVE_GREEN.BLUE.index;
        //cellStyle.BottomBorderColor = NPOI.HSSF.Util.HSSFColor.OLIVE_GREEN.BLUE.index;
        //cellStyle.TopBorderColor = NPOI.HSSF.Util.HSSFColor.OLIVE_GREEN.BLUE.index;

        //背景图形，我没有用到过。感觉很丑  
        //cellStyle.FillBackgroundColor = HSSFColor.OLIVE_GREEN.BLUE.index;  
        //cellStyle.FillForegroundColor = HSSFColor.OLIVE_GREEN.BLUE.index;  
        //cellStyle.FillForegroundColor = HSSFColor.WHITE.index;
        //// cellStyle.FillPattern = FillPatternType.NO_FILL;  
        //cellStyle.FillBackgroundColor = HSSFColor.BLUE.index;

        //水平对齐  
        //cellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.LEFT;

        ////垂直对齐  
        //cellStyle.VerticalAlignment = VerticalAlignment.CENTER;

        ////自动换行  
        //cellStyle.WrapText = true;

        //缩进;当设置为1时，前面留的空白太大了。希旺官网改进。或者是我设置的不对  
        //cellStyle.Indention = 0;

        //上面基本都是设共公的设置  
        //下面列出了常用的字段类型  
        switch (str)
        {
            case stylexls.头:
                //cellStyle.FillPattern = FillPatternType.LEAST_DOTS;  
                cellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
                cellStyle.FillBackgroundColor = NPOI.HSSF.Util.HSSFColor.OLIVE_GREEN.LIME.index;
                cellStyle.SetFont(font12);
                break;
            case stylexls.时间:
                IDataFormat datastyle = wb.CreateDataFormat();

                cellStyle.DataFormat = datastyle.GetFormat("dd-mmm-yy;@");
                cellStyle.SetFont(font);
                break;
            case stylexls.数字:
                cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
                cellStyle.SetFont(font);
                break;
            case stylexls.url:
                fontcolorblue.Underline = 1;
                cellStyle.SetFont(fontcolorblue);
                break;
            case stylexls.百分比:
                cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00%");
                cellStyle.SetFont(font);
                break;
            case stylexls.中文大写:
                IDataFormat format1 = wb.CreateDataFormat();
                cellStyle.DataFormat = format1.GetFormat("[DbNum2][$-804]0");
                cellStyle.SetFont(font);
                break;
            case stylexls.科学计数法:
                cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00E+00");
                cellStyle.SetFont(font);
                break;
            case stylexls.默认:
                cellStyle.SetFont(font);
                break;
        }
        return cellStyle;


    }
    static ICellStyle Getcellstyle(IWorkbook wb, stylexls str,string smoney)
    {
        ICellStyle cellStyle = wb.CreateCellStyle();

        //定义几种字体  
        //也可以一种字体，写一些公共属性，然后在下面需要时加特殊的  
        //IFont font12 = wb.CreateFont();
        //font12.FontHeightInPoints = 10;
        //font12.FontName = "微软雅黑";


        //IFont font = wb.CreateFont();
        //font.FontName = "微软雅黑";
        //font.Underline = 1;下划线  


        //IFont fontcolorblue = wb.CreateFont();
        //fontcolorblue.Color = HSSFColor.OLIVE_GREEN.BLUE.index;
        //fontcolorblue.IsItalic = true;//下划线  
        //fontcolorblue.FontName = "微软雅黑";


        cellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.THIN;
        cellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.THIN;
        cellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.THIN;
        cellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.THIN;

        //边框颜色  
        //cellStyle.BottomBorderColor = HSSFColor.OLIVE_GREEN.BLUE.index;
        //cellStyle.TopBorderColor = HSSFColor.OLIVE_GREEN.BLUE.index;

        //背景图形，我没有用到过。感觉很丑  
        //cellStyle.FillBackgroundColor = HSSFColor.OLIVE_GREEN.BLUE.index;  
        //cellStyle.FillForegroundColor = HSSFColor.OLIVE_GREEN.BLUE.index;  
        //cellStyle.FillForegroundColor = HSSFColor.WHITE.index;
        //// cellStyle.FillPattern = FillPatternType.NO_FILL;  
        //cellStyle.FillBackgroundColor = HSSFColor.BLUE.index;

        //水平对齐  
        //cellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.LEFT;

        ////垂直对齐  
        //cellStyle.VerticalAlignment = VerticalAlignment.CENTER;

        ////自动换行  
        //cellStyle.WrapText = true;

        ////缩进;当设置为1时，前面留的空白太大了。希旺官网改进。或者是我设置的不对  
        //cellStyle.Indention = 0;

        //上面基本都是设共公的设置  
        //下面列出了常用的字段类型  
        switch (str)
        {
            case stylexls.货币:
                IDataFormat format = wb.CreateDataFormat();
                switch (smoney)
                {
                    case "￥":
                        cellStyle.DataFormat = format.GetFormat("￥#,##0.00;￥-#,##0.00");
                        break;
                    case "$":
                        cellStyle.DataFormat = format.GetFormat("$#,##0.00;-$#,##0.00");
                        break;
                    case "€":
                        cellStyle.DataFormat = format.GetFormat("[$€-C07] #,##0.00;-[$€-C07] #,##0.00");
                        break;
                }
                //cellStyle.SetFont(font);
                break;
        }
        return cellStyle;


    }
    #endregion  


}
