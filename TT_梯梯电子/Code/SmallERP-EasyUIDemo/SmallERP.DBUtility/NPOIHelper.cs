using NPOI.HPSF;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SmallERP.DBUtility
{
    public class NPOIHelper
    {
        #region 从excel导入
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dtSource"></param>
        /// <param name="strFileName"></param>
        /// <remarks></remarks>
        /// <Author></Author>
        public DataTable Import(string filePath, string sheetname)
        {
            var ext = Path.GetExtension(filePath).ToLower();
            DataTable dt = new DataTable();
            using (FileStream fs = File.OpenRead(filePath))
            {
                IWorkbook wk;
                if (ext.Contains("xlsx"))
                    wk = new XSSFWorkbook(fs);
                else
                    wk = new HSSFWorkbook(fs);
                ISheet sheet = wk.GetSheetAt(0);
                int rowcount = 0;
                for (int j = 0; j <= sheet.LastRowNum; j++)  //LastRowNum 是当前表的总行数
                {
                    IRow row = sheet.GetRow(j);  //读取当前行数据
                    if (j == 0)
                    {
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            if (row.Cells[i].ToString() == "commitdate") {
                                dt.Columns.Add(row.Cells[i].ToString(),typeof(DateTime));
                            }
                            else
                            {
                                dt.Columns.Add(row.Cells[i].ToString());
                            }
                            rowcount++;
                        }
                    }
                    else
                    {
                        DataRow dw = dt.NewRow();
                        for (int i = 0; i < rowcount; i++)
                        {
                            dw[i] = (ICell)sheet.GetRow(j).GetCell(i);
                        }
                        dt.Rows.Add(dw);
                    }
                }
            }
            return dt;

        }
        #endregion

        #region 导出到excel 
        /// <summary>
        /// DataTable导出到Excel的MemoryStream
        /// </summary>
        /// <param name="dtSource">源DataTable</param>
        /// <param name="strHeaderText">表头文本</param>
        public MemoryStream Export(DataTable dtSource,DataTable dtp, string strHeaderText,out long fileSize)
        {
            //创建新的workbook
            //XSSFWorkbook workbook = new XSSFWorkbook();
            //XSSFSheet sheet = (XSSFSheet)workbook.CreateSheet();

            //使用模板的workbook
            IWorkbook workbook = null;
            ISheet sheet = null;
            FileStream fs = null;
            string fileName = AppDomain.CurrentDomain.BaseDirectory + @"Upload\model\计算导出模板.xlsx";
            using (fs = File.OpenRead(fileName))
            {
                //大批量数据导出的时候，需要注意这样的一个问题，Excel2003格式一个sheet只支持65536行，excel 2007 就比较多，是1048576
                //workbook = new HSSFWorkbook(fs);//2003版本.xls
                workbook = new XSSFWorkbook(fs); // 2007版本.xlsx
                if (workbook == null)
                {
                    throw new Exception("未找到相关的模板");
                }
                else
                {
                    sheet = workbook.GetSheetAt(0); //读取第一个sheet
                }
            }

            

            XSSFCellStyle dateStyle = (XSSFCellStyle)workbook.CreateCellStyle();
            XSSFDataFormat format = (XSSFDataFormat)workbook.CreateDataFormat();
            dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");

            //取得列宽
            //int[] arrColWidth = new int[dtSource.Columns.Count];
            //foreach (DataColumn item in dtSource.Columns)
            //{
            //    arrColWidth[item.Ordinal] = Encoding.GetEncoding(936).GetBytes(item.ColumnName.ToString()).Length;
            //}
            //for (int i = 0; i < dtSource.Rows.Count; i++)
            //{
            //    for (int j = 0; j < dtSource.Columns.Count; j++)
            //    {
            //        int intTemp = Encoding.GetEncoding(936).GetBytes(dtSource.Rows[i][j].ToString()).Length;
            //        if (intTemp > arrColWidth[j])
            //        {
            //            arrColWidth[j] = intTemp;
            //        }
            //    }
            //}

            XSSFRow dataRowHead = (XSSFRow)sheet.GetRow(0);
            XSSFRow dataRowHead2 = (XSSFRow)sheet.GetRow(1);
            foreach (XSSFCell newCell in dataRowHead)
            {
                string s1 = newCell.StringCellValue;
                string s1_1 = "";
                switch(s1)
                {
                    case "Week1":
                        s1_1 = "Period01";
                        break;
                    case "Week2":
                        s1_1 = "Period02";
                        break;
                    case "Week3":
                        s1_1 = "Period03";
                        break;
                    case "Week4":
                        s1_1 = "Period04";
                        break;
                    case "Week5":
                        s1_1 = "Period05";
                        break;
                    case "Week6":
                        s1_1 = "Period06";
                        break;
                    case "Week7":
                        s1_1 = "Period07";
                        break;
                    case "Week8":
                        s1_1 = "Period08";
                        break;
                    case "Week9":
                        s1_1 = "Period09";
                        break;
                    case "Week10":
                        s1_1 = "Period10";
                        break;
                    case "Week11":
                        s1_1 = "Period11";
                        break;
                    case "Week12":
                        s1_1 = "Period12";
                        break;
                    case "Week13":
                        s1_1 = "Period13";
                        break;
                    case "Month1":
                        s1_1 = "Period14";
                        break;
                    case "Month2":
                        s1_1 = "Period15";
                        break;
                    case "Month3":
                        s1_1 = "Period16";
                        break;
                    case "Month4":
                        s1_1 = "Period17";
                        break;
                }
                foreach (DataColumn dataCol in dtp.Columns)
                {
                    string s2 = dataCol.ColumnName;
                    if (s1_1 == s2)
                    {
                        int colIndex = newCell.ColumnIndex;
                        XSSFCell newCell2 = (XSSFCell)dataRowHead2.GetCell(colIndex);
                        newCell2.SetCellValue(DateTime.Parse(dtp.Rows[0][s2].ToString()).ToString("yyyy-MM-dd"));
                    }
                }
            }
            

            int rowIndex = 2;
            foreach (DataRow row in dtSource.Rows)
            {
                #region 新建表，填充表头，填充列头，样式
                //if (rowIndex == 65535 || rowIndex == 0)
                //{
                    //#region 表头及样式
                    //{
                    //    XSSFRow headerRow = (XSSFRow)sheet.CreateRow(0);
                    //    headerRow.HeightInPoints = 25;
                    //    headerRow.CreateCell(0).SetCellValue(strHeaderText);

                    //    XSSFCellStyle headStyle = (XSSFCellStyle)workbook.CreateCellStyle();
                    //    headStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
                    //    XSSFFont font = (XSSFFont)workbook.CreateFont();
                    //    font.FontHeightInPoints = 20;
                    //    font.Boldweight = 700;
                    //    headStyle.SetFont(font);
                    //    headerRow.GetCell(0).CellStyle = headStyle;
                    //    sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, dtSource.Columns.Count - 1));
                    //    //headerRow.Dispose();
                    //}
                    //#endregion


                    //#region 列头及样式
                    //{
                    //    XSSFRow headerRow = (XSSFRow)sheet.CreateRow(1);
                    //    XSSFCellStyle headStyle = (XSSFCellStyle)workbook.CreateCellStyle();
                    //    headStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
                    //    XSSFFont font = (XSSFFont)workbook.CreateFont();
                    //    font.FontHeightInPoints = 10;
                    //    font.Boldweight = 700;
                    //    headStyle.SetFont(font);
                    //    foreach (DataColumn column in dtSource.Columns)
                    //    {
                    //        headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                    //        headerRow.GetCell(column.Ordinal).CellStyle = headStyle;

                    //        //设置列宽
                    //        //sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 1) * 256);
                    //    }
                    //}
                    //#endregion

                    //rowIndex = 2;
                //}
                #endregion

                #region 填充内容
                XSSFRow dataRow = (XSSFRow)sheet.CreateRow(rowIndex);
                foreach (DataColumn column in dtSource.Columns)
                {
                    XSSFCell newCell = (XSSFCell)dataRow.CreateCell(column.Ordinal);

                    string drValue = row[column].ToString();

                    switch (column.DataType.ToString())
                    {
                        case "System.String"://字符串类型
                            newCell.SetCellValue(drValue);
                            break;
                        case "System.DateTime"://日期类型
                            DateTime dateV;
                            DateTime.TryParse(drValue, out dateV);
                            newCell.SetCellValue(dateV);

                            newCell.CellStyle = dateStyle;//格式化显示
                            break;
                        case "System.Boolean"://布尔型
                            bool boolV = false;
                            bool.TryParse(drValue, out boolV);
                            newCell.SetCellValue(boolV);
                            break;
                        case "System.Int16"://整型
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Byte":
                            int intV = 0;
                            int.TryParse(drValue, out intV);
                            newCell.SetCellValue(intV);
                            break;
                        case "System.Decimal"://浮点型
                        case "System.Double":
                            double doubV = 0;
                            double.TryParse(drValue, out doubV);
                            if (doubV != 0)
                            {
                                newCell.SetCellValue(doubV);
                            }
                            break;
                        case "System.DBNull"://空值处理
                            newCell.SetCellValue("");
                            break;
                        default:
                            newCell.SetCellValue("");
                            break;
                    }

                }
                #endregion

                rowIndex++;
            }
            using (MemoryStream ms = new MemoryStream())
            {
                fileSize = 0;
                workbook.Write(ms);
                
                ms.Flush();
                //ms.Position = 0;

                //workbook.Dispose();//一般只用写这一个就OK了，他会遍历并释放所有资源，但当前版本有问题所以只释放sheet
                return ms;
            }
        }

        /// <summary>
        /// 用于Web导出
        /// </summary>
        /// <param name="dtSource">源DataTable</param>
        /// <param name="dtp">源DataTable</param>
        /// <param name="strHeaderText">表头文本</param>
        /// <param name="strFileName">文件名</param>
        public void ExportByWeb(DataTable dtSource,DataTable dtp, string strHeaderText, string strFileName)
        {
            

            long fileSize = 0;
            MemoryStream ms = Export(dtSource, dtp, strHeaderText, out fileSize);

            //HttpContext curContext = HttpContext.Current;
            //// 设置编码和附件格式
            ////curContext.Response.ContentType = "application/vnd.ms-excel";
            ////curContext.Response.ContentEncoding = Encoding.UTF8;
            ////curContext.Response.Charset = "";
            //curContext.Response.AppendHeader("Content-Disposition",
            //    "attachment;filename=" + HttpUtility.UrlEncode(strFileName, Encoding.UTF8));
            //HttpContext.Current.Response.AddHeader("Content-Length", ms.Length.ToString());
            //curContext.Response.BinaryWrite(ms.GetBuffer());
            //curContext.Response.End();
            //ms.Dispose()

            HttpContext context = HttpContext.Current;
            context.Response.Clear();
            context.Response.ContentEncoding = Encoding.GetEncoding("GB2312");
            context.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";//application/octet-stream
            context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + strFileName);
            ////context.Response.AddHeader("Content-Length", fileSize.ToString());
            context.Response.BinaryWrite(ms.ToArray());
            //context.Response.Flush();
            //context.ApplicationInstance.CompleteRequest();
            //context.Response.End();
            context.Response.Flush();
            context.Response.End();
        }
        #endregion

        #region 导出到excel--BuyGating
        /// <summary>
        /// DataTable导出到Excel的MemoryStream
        /// </summary>
        /// <param name="dtSource">源DataTable</param>
        /// <param name="strHeaderText">表头文本</param>
        public MemoryStream ExportBuyGating(DataTable dtSource, string strHeaderText, out long fileSize)
        {
            //创建新的workbook
            //XSSFWorkbook workbook = new XSSFWorkbook();
            //XSSFSheet sheet = (XSSFSheet)workbook.CreateSheet();

            //使用模板的workbook
            IWorkbook workbook = null;
            ISheet sheet = null;
            FileStream fs = null;
            string fileName = AppDomain.CurrentDomain.BaseDirectory + @"Upload\model\BuyGating导出模板.xlsx";
            using (fs = File.OpenRead(fileName))
            {
                //大批量数据导出的时候，需要注意这样的一个问题，Excel2003格式一个sheet只支持65536行，excel 2007 就比较多，是1048576
                //workbook = new HSSFWorkbook(fs);//2003版本.xls
                workbook = new XSSFWorkbook(fs); // 2007版本.xlsx
                if (workbook == null)
                {
                    throw new Exception("未找到相关的模板");
                }
                else
                {
                    sheet = workbook.GetSheetAt(0); //读取第一个sheet
                }
            }

            XSSFCellStyle dateStyle = (XSSFCellStyle)workbook.CreateCellStyle();
            XSSFDataFormat format = (XSSFDataFormat)workbook.CreateDataFormat();
            dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");
            //throw new Exception("aa");
            int rowIndex = 1;
            foreach (DataRow row in dtSource.Rows)
            {
                #region 新建表，填充表头，填充列头，样式
                //if (rowIndex == 65535 || rowIndex == 0)
                //{
                //#region 表头及样式
                //{
                //    XSSFRow headerRow = (XSSFRow)sheet.CreateRow(0);
                //    headerRow.HeightInPoints = 25;
                //    headerRow.CreateCell(0).SetCellValue(strHeaderText);

                //    XSSFCellStyle headStyle = (XSSFCellStyle)workbook.CreateCellStyle();
                //    headStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
                //    XSSFFont font = (XSSFFont)workbook.CreateFont();
                //    font.FontHeightInPoints = 20;
                //    font.Boldweight = 700;
                //    headStyle.SetFont(font);
                //    headerRow.GetCell(0).CellStyle = headStyle;
                //    sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, dtSource.Columns.Count - 1));
                //    //headerRow.Dispose();
                //}
                //#endregion


                //#region 列头及样式
                //{
                //    XSSFRow headerRow = (XSSFRow)sheet.CreateRow(1);
                //    XSSFCellStyle headStyle = (XSSFCellStyle)workbook.CreateCellStyle();
                //    headStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
                //    XSSFFont font = (XSSFFont)workbook.CreateFont();
                //    font.FontHeightInPoints = 10;
                //    font.Boldweight = 700;
                //    headStyle.SetFont(font);
                //    foreach (DataColumn column in dtSource.Columns)
                //    {
                //        headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                //        headerRow.GetCell(column.Ordinal).CellStyle = headStyle;

                //        //设置列宽
                //        //sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 1) * 256);
                //    }
                //}
                //#endregion

                //rowIndex = 2;
                //}
                #endregion

                #region 填充内容
                XSSFRow dataRow = (XSSFRow)sheet.CreateRow(rowIndex);
                foreach (DataColumn column in dtSource.Columns)
                {
                    XSSFCell newCell = (XSSFCell)dataRow.CreateCell(column.Ordinal);

                    string drValue = row[column].ToString();

                    switch (column.DataType.ToString())
                    {
                        case "System.String"://字符串类型
                            newCell.SetCellValue(drValue);
                            break;
                        case "System.DateTime"://日期类型
                            DateTime dateV;
                            DateTime.TryParse(drValue, out dateV);
                            newCell.SetCellValue(dateV);

                            newCell.CellStyle = dateStyle;//格式化显示
                            break;
                        case "System.Boolean"://布尔型
                            bool boolV = false;
                            bool.TryParse(drValue, out boolV);
                            newCell.SetCellValue(boolV);
                            break;
                        case "System.Int16"://整型
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Byte":
                            int intV = 0;
                            int.TryParse(drValue, out intV);
                            newCell.SetCellValue(intV);
                            break;
                        case "System.Decimal"://浮点型
                        case "System.Double":
                            double doubV = 0;
                            double.TryParse(drValue, out doubV);
                            if (doubV != 0)
                            {
                                newCell.SetCellValue(doubV);
                            }
                            break;
                        case "System.DBNull"://空值处理
                            newCell.SetCellValue("");
                            break;
                        default:
                            newCell.SetCellValue("");
                            break;
                    }

                }
                #endregion

                rowIndex++;
            }
            using (MemoryStream ms = new MemoryStream())
            {
                fileSize = 0;
                workbook.Write(ms);

                ms.Flush();
                //ms.Position = 0;

                //workbook.Dispose();//一般只用写这一个就OK了，他会遍历并释放所有资源，但当前版本有问题所以只释放sheet
                return ms;
            }
        }

        /// <summary>
        /// 用于Web导出
        /// </summary>
        /// <param name="dtSource">源DataTable</param>
        /// <param name="dtp">源DataTable</param>
        /// <param name="strHeaderText">表头文本</param>
        /// <param name="strFileName">文件名</param>
        public void ExportByWebBuyGating(DataTable dtSource, string strHeaderText, string strFileName)
        {


            long fileSize = 0;
            MemoryStream ms = ExportBuyGating(dtSource, strHeaderText, out fileSize);

            //HttpContext curContext = HttpContext.Current;
            //// 设置编码和附件格式
            ////curContext.Response.ContentType = "application/vnd.ms-excel";
            ////curContext.Response.ContentEncoding = Encoding.UTF8;
            ////curContext.Response.Charset = "";
            //curContext.Response.AppendHeader("Content-Disposition",
            //    "attachment;filename=" + HttpUtility.UrlEncode(strFileName, Encoding.UTF8));
            //HttpContext.Current.Response.AddHeader("Content-Length", ms.Length.ToString());
            //curContext.Response.BinaryWrite(ms.GetBuffer());
            //curContext.Response.End();
            //ms.Dispose()

            HttpContext context = HttpContext.Current;
            context.Response.Clear();
            context.Response.ContentEncoding = Encoding.GetEncoding("GB2312");
            context.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";//application/octet-stream
            context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + strFileName);
            ////context.Response.AddHeader("Content-Length", fileSize.ToString());
            context.Response.BinaryWrite(ms.ToArray());
            //context.Response.Flush();
            //context.ApplicationInstance.CompleteRequest();
            //context.Response.End();
            context.Response.Flush();
            context.Response.End();
        }
        #endregion

        #region 导出到excelPAD
        /// <summary>
        /// DataTable导出到Excel的MemoryStream
        /// </summary>
        /// <param name="dtp"></param>
        /// <param name="dtt"></param>
        /// <param name="dtc"></param>
        /// <param name="dtsum"></param>
        /// <param name="strHeaderText"></param>
        /// <param name="fileSize"></param>
        /// <returns></returns>
        public MemoryStream ExportPAD(string sTKVersion, string qyPlanner, string qyGroup, string qycategory, string qyReorderpolicy, string strHeaderText, out long fileSize, bool isNetQty)
        {
            DataTable dtp = GetPeriod(sTKVersion);
            //DataTable dtt = GetResults(sTKVersion, qyPlanner, qyGroup);
            DataTable dtg = GetResultsGroup(sTKVersion, qyPlanner, qyGroup, qycategory, qyReorderpolicy);
            //DataTable dtc = GetCurrentStock(sTKVersion);
            DataTable dtcg = GetCurrentStockGroup();
            DataTable dtbomg = GetBOMGroup(sTKVersion, qyPlanner, qyGroup, qycategory, qyReorderpolicy);
            //DataTable dtbom = GetBOM(sTKVersion, qyPlanner, qyGroup);
            //创建新的workbook
            //XSSFWorkbook workbook = new XSSFWorkbook();
            //XSSFSheet sheet = (XSSFSheet)workbook.CreateSheet();

            //使用模板的workbook
            XSSFWorkbook workbook = null;
            ISheet sheet = null;
            FileStream fs = null;
            XSSFFormulaEvaluator formulaEvaluator = null;
            string fileName = AppDomain.CurrentDomain.BaseDirectory + @"Upload\model\PAD导出模板.xlsx";
            using (fs = File.OpenRead(fileName))
            {
                //大批量数据导出的时候，需要注意这样的一个问题，Excel2003格式一个sheet只支持65536行，excel 2007 就比较多，是1048576
                //workbook = new HSSFWorkbook(fs);//2003版本.xls
                workbook = new XSSFWorkbook(fs); // 2007版本.xlsx
                if (workbook == null)
                {
                    throw new Exception("未找到相关的模板");
                }
                else
                {
                    sheet = workbook.GetSheetAt(0); //读取第一个sheet
                    formulaEvaluator = new XSSFFormulaEvaluator(workbook);
                }
            }

            ICellStyle cellHead = (ICellStyle)workbook.CreateCellStyle();
            cellHead.Rotation = 180;
            cellHead.VerticalAlignment = VerticalAlignment.Center;
            cellHead.Alignment = HorizontalAlignment.Center;

            ICellStyle cellHead2 = (ICellStyle)workbook.CreateCellStyle();
            cellHead2.VerticalAlignment = VerticalAlignment.Center;
            cellHead2.Alignment = HorizontalAlignment.Center;

            ICellStyle cellStage = (ICellStyle)workbook.CreateCellStyle();
            cellStage.DataFormat = workbook.CreateDataFormat().GetFormat("0.00;[Red](-0.00)");

            XSSFRow dataRowHead = (XSSFRow)sheet.GetRow(0);
            XSSFRow dataRowHead2 = (XSSFRow)sheet.GetRow(9);

            XSSFRow dataRowHead2_Top = (XSSFRow)sheet.GetRow(8);

            int colIndex = 3;
            ArrayList cinvList = new ArrayList();
            ArrayList currList = new ArrayList();
            //生成物料表头
            for (int i = 0; i < dtg.Rows.Count; i++)
            {
                string cInvCode = dtg.Rows[i]["cInvCode"].ToString();
                XSSFCell newCell = (XSSFCell)dataRowHead.CreateCell(colIndex);
                newCell.SetCellValue(cInvCode);
                newCell.CellStyle = cellHead;
                XSSFCell newCell2 = (XSSFCell)dataRowHead2.CreateCell(colIndex);
                newCell2.SetCellValue(cInvCode);
                newCell2.CellStyle = cellHead;
                cinvList.Add(cInvCode);
                colIndex++;
            }
            
            //生成库存表头
            int colIndexCurr = colIndex;
            for (int i = 0; i < dtcg.Rows.Count; i++)
            {
                string warehouseclass = dtcg.Rows[i]["warehouseclass"].ToString();
                XSSFCell newCell2 = (XSSFCell)dataRowHead2.CreateCell(colIndex);
                newCell2.SetCellValue(warehouseclass);
                sheet.SetColumnWidth(colIndex, 10 * 256);//设置宽
                currList.Add(warehouseclass);
                colIndex++;
            }
            
            //生成工单占用量Allocated
            int colIndexAllocated = colIndex;
            XSSFCell newCellAllocated = (XSSFCell)dataRowHead2.CreateCell(colIndex);
            newCellAllocated.SetCellValue("Allocated");
            newCellAllocated.CellStyle = cellHead2;
            sheet.SetColumnWidth(colIndex, 15 * 256);//设置宽
            colIndex = colIndex + 1;

            int colIndexETA = colIndex;
            //ETA Status表头
            for (int i = 0; i < dtp.Rows.Count; i++)
            {
                string dtmStart = DateTime.Parse(dtp.Rows[i]["dtmStart"].ToString()).ToString("yyyy-MM-dd");
                string dtmEnd = DateTime.Parse(dtp.Rows[i]["dtmEnd"].ToString()).ToString("yyyy-MM-dd");
                string EgMonth = dtp.Rows[i]["EgMonth"].ToString();
                //设置汇总英文日期表头
                XSSFCell newCell = (XSSFCell)dataRowHead2_Top.CreateCell(colIndex);

                //合并表头
                sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(8, 8, colIndex, colIndex + 3));
                newCell.SetCellValue(EgMonth);
                newCell.CellStyle = cellHead2;

                //设置表头
                XSSFCell newCell1 = (XSSFCell)dataRowHead2.CreateCell(colIndex);
                newCell1.SetCellValue("Shortage");
                newCell1.CellStyle = cellHead2;
                sheet.SetColumnWidth(colIndex, 15 * 256);//设置宽

                XSSFCell newCell4 = (XSSFCell)dataRowHead2.CreateCell(colIndex + 1);
                newCell4.SetCellValue("PO ETA Qty");
                newCell4.CellStyle = cellHead2;
                sheet.SetColumnWidth(colIndex + 1, 15 * 256);//设置宽
                
                XSSFCell newCell2 = (XSSFCell)dataRowHead2.CreateCell(colIndex + 2);
                newCell2.SetCellValue("ETA");
                newCell2.CellStyle = cellHead2;
                sheet.SetColumnWidth(colIndex + 2, 15 * 256);//设置宽

                XSSFCell newCell3 = (XSSFCell)dataRowHead2.CreateCell(colIndex + 3);
                newCell3.SetCellValue("Status");
                newCell3.CellStyle = cellHead2;
                sheet.SetColumnWidth(colIndex + 3, 10 * 256);//设置宽

                colIndex = colIndex + 4;
            }

            //OpenPO及后续列表头
            int colIndexOpenPO = colIndex;
            XSSFCell newCellOpenPO = (XSSFCell)dataRowHead2.CreateCell(colIndex);
            newCellOpenPO.SetCellValue("OpenPO");
            newCellOpenPO.CellStyle = cellHead2;
            colIndex = colIndex + 1;

            int colIndexVendor = colIndex;
            XSSFCell newCellVendor = (XSSFCell)dataRowHead2.CreateCell(colIndex);
            newCellVendor.SetCellValue("Vendor");
            newCellVendor.CellStyle = cellHead2;
            colIndex = colIndex + 1;

            XSSFCell newCellVendor1 = (XSSFCell)dataRowHead2.CreateCell(colIndex);
            newCellVendor1.SetCellValue("ProductGroup");
            newCellVendor1.CellStyle = cellHead2;
            colIndex = colIndex + 1;

            XSSFCell newCellVendor2 = (XSSFCell)dataRowHead2.CreateCell(colIndex);
            newCellVendor2.SetCellValue("LT");
            newCellVendor2.CellStyle = cellHead2;
            colIndex = colIndex + 1;

            XSSFCell newCellVendor3 = (XSSFCell)dataRowHead2.CreateCell(colIndex);
            newCellVendor3.SetCellValue("MOQ");
            newCellVendor3.CellStyle = cellHead2;
            colIndex = colIndex + 1;

            XSSFCell newCellVendor4 = (XSSFCell)dataRowHead2.CreateCell(colIndex);
            newCellVendor4.SetCellValue("MPQ");
            newCellVendor4.CellStyle = cellHead2;
            colIndex = colIndex + 1;

            XSSFCell newCellVendor5 = (XSSFCell)dataRowHead2.CreateCell(colIndex);
            newCellVendor5.SetCellValue("ActualCost");
            newCellVendor5.CellStyle = cellHead2;
            colIndex = colIndex + 1;

            XSSFCell newCellVendor6 = (XSSFCell)dataRowHead2.CreateCell(colIndex);
            newCellVendor6.SetCellValue("TopList");
            newCellVendor6.CellStyle = cellHead2;
            

            int group = 500;

            string dStart = DateTime.Parse(dtp.Rows[0]["dtmStart"].ToString()).ToString("yyyy-MM-dd");
            //添加7个月的数量，循环查询
            //循环物料
            for (int i = 0; i < dtp.Rows.Count; i++)
            {
                XSSFRow dataRow = (XSSFRow)sheet.CreateRow(i + 1);

                string dtmStart = DateTime.Parse(dtp.Rows[i]["dtmStart"].ToString()).ToString("yyyy-MM-dd");
                string dtmEnd = DateTime.Parse(dtp.Rows[i]["dtmEnd"].ToString()).ToString("yyyy-MM-dd");
                string EgMonth = dtp.Rows[i]["EgMonth"].ToString();

                dataRow.CreateCell(2).SetCellValue(EgMonth);

                for (int s = 1; s < cinvList.Count; s ++)
                {
                    if ((s + 1) % group == 0)
                    {
                        int IDStart = s + 1 - group;
                        int IDEnd = s;
                        SetResults(sTKVersion, qyPlanner, qyGroup, qycategory, qyReorderpolicy, dataRow, cinvList, dtmStart, dtmEnd, IDStart, IDEnd, dStart, isNetQty);
                    }
                    else if (s == cinvList.Count - 1)
                    {
                        int IDStart = cinvList.Count - (s + 1) % group;
                        int IDEnd = s;
                        SetResults(sTKVersion, qyPlanner, qyGroup, qycategory, qyReorderpolicy, dataRow, cinvList, dtmStart, dtmEnd, IDStart, IDEnd, dStart, isNetQty);
                    }
                }
            }

            //添加子件BOM
            int rowIndex = 10;
            ArrayList rowList = new ArrayList();
            //循环物料，添加子件
            for (int i = 0; i < dtbomg.Rows.Count; i++)
            {
                string sChild = dtbomg.Rows[i]["child"].ToString();
                XSSFRow dataRow = (XSSFRow)sheet.CreateRow(rowIndex + i);

                dataRow.CreateCell(0).SetCellValue(sChild);
                dataRow.CreateCell(1).SetCellValue(dtbomg.Rows[i]["partdesc"].ToString());
                dataRow.CreateCell(2).SetCellValue(dtbomg.Rows[i]["childsm"].ToString());
                if (dtbomg.Rows[i]["alloqty"].ToString() != "")
                {
                    dataRow.CreateCell(colIndexAllocated).SetCellValue(double.Parse(dtbomg.Rows[i]["alloqty"].ToString()));
                }

                dataRow.CreateCell(colIndexOpenPO).SetCellValue(dtbomg.Rows[i]["OpenPO"].ToString());
                dataRow.CreateCell(colIndexOpenPO + 1).SetCellValue(dtbomg.Rows[i]["vc"].ToString());
                dataRow.CreateCell(colIndexOpenPO + 2).SetCellValue(dtbomg.Rows[i]["prodgroup"].ToString());
                dataRow.CreateCell(colIndexOpenPO + 3).SetCellValue(dtbomg.Rows[i]["lt"].ToString());
                dataRow.CreateCell(colIndexOpenPO + 4).SetCellValue(dtbomg.Rows[i]["moq"].ToString());
                dataRow.CreateCell(colIndexOpenPO + 5).SetCellValue(dtbomg.Rows[i]["mpq"].ToString());
                dataRow.CreateCell(colIndexOpenPO + 6).SetCellValue(dtbomg.Rows[i]["curmat"].ToString());
                dataRow.CreateCell(colIndexOpenPO + 7).SetCellValue(dtbomg.Rows[i]["toplevellist"].ToString());

                rowList.Add(sChild);
            }
            //循环子件添加BOM
            for (int s = 1; s < cinvList.Count; s++)
            {
                if ((s + 1) % group == 0)
                {
                    int IDStart = s + 1 - group;
                    int IDEnd = s;
                    SetBOM(sTKVersion, qyPlanner, qyGroup, qycategory, qyReorderpolicy, sheet, cinvList, rowIndex, IDStart, IDEnd);

                }
                else if (s == cinvList.Count - 1)
                {
                    int IDStart = cinvList.Count - (s + 1) % group;
                    int IDEnd = s;
                    SetBOM(sTKVersion, qyPlanner, qyGroup, qycategory, qyReorderpolicy, sheet, cinvList, rowIndex, IDStart, IDEnd);

                }
            }

            //循环子件添加库存
            SetCurr(sTKVersion, qyPlanner, qyGroup, qycategory, qyReorderpolicy, sheet, currList, rowIndex, colIndexCurr);

            //循环子件添加ETA Status
            for (int j = 0; j < rowList.Count; j++)
            {
                //if (rowList[j].ToString() != "1028219")//012215700002-160
                //{
                //    continue;
                //    //string ss = rowList[j].ToString();
                //}
                bool isVPO = false;//是否有vpo订单

                StringBuilder strSql = new StringBuilder();
                strSql.Append(@"select *,fOpenQTY as leftQty from 
                TK_Trialkit_Net_PO a with (nolock) where 1=1 and sTKVersion = '" + sTKVersion + "' and Child='" + rowList[j] + "'  ");
                strSql.Append(@"
                order by case when sPONo<>'VPO' then 1 else 2 end,dtmDuedate");//and dtmDuedate between '" + dtmStart + "' and '" + dtmEnd + "'
                DataTable dtETA = DbHelperSQL.Query(strSql.ToString()).Tables[0];

                DataTable dtQty = GetResultsQty(sTKVersion, qyPlanner, qyGroup, qycategory, qyReorderpolicy, rowList[j].ToString(), isNetQty, dStart);
                //decimal qty = 0;

                //循环月
                decimal qtyck = 0;
                for (int i = 0; i < dtp.Rows.Count; i++)
                {
                    bool isCG = false;//采购订单是否满足
                    bool isWeek = false;//是否满足周

                    string dtmStart = DateTime.Parse(dtp.Rows[i]["dtmStart"].ToString()).ToString("yyyy-MM-dd");
                    string dtmEnd = DateTime.Parse(dtp.Rows[i]["dtmEnd"].ToString()).ToString("yyyy-MM-dd");

                    string EgMonth = dtp.Rows[i]["EgMonth"].ToString();

                    int irow = rowIndex + j + 1;//子件行
                    int wrow = i + 2;//计划行
                    string cscol = ConvertColumnIndexToColumnName(colIndexCurr);//库存开始列
                    string cecol = ConvertColumnIndexToColumnName(colIndexAllocated - 1);//库存结束列
                    string Allocatedcol = ConvertColumnIndexToColumnName(colIndexAllocated);//工单余量列
                    string iscol = ConvertColumnIndexToColumnName(3);//计划开始列
                    string iecol = ConvertColumnIndexToColumnName(colIndexCurr - 1);//计划结束列
                    string lastcol = ConvertColumnIndexToColumnName(colIndexETA + i * 4 - 4);//上一计划列
                    string lastdiffcol = ConvertColumnIndexToColumnName(colIndexETA + i * 4 - 3);//上一计划已用列
                    string CellFormulaString = "";
                    if (i == 0)
                    {
                        CellFormulaString = "SUM(" + cscol + irow + ":" + cecol + irow + ")-" + Allocatedcol + irow + "-SUMPRODUCT($" + iscol + "$" + wrow + ":$" + iecol + "$" + wrow + "*" + iscol + irow + ":" + iecol + irow + ")";
                    }
                    else
                    {
                        CellFormulaString = lastcol + irow + "-SUMPRODUCT($" + iscol + "$" + wrow + ":$" + iecol + "$" + wrow + "*" + iscol + irow + ":" + iecol + irow + ")+" + lastdiffcol + irow;
                    }
                    ICell cell = (ICell)sheet.GetRow(rowIndex + j).CreateCell(colIndexETA + i * 4);
                    cell = formulaEvaluator.EvaluateInCell(cell);
                    cell.CellStyle = cellStage;
                    cell.SetCellFormula(CellFormulaString);

                    //double qty = formulaEvaluator.EvaluateInCell(cell).NumericCellValue;//SUMPRODUCT无法读取

                    //如果不是采购件跳过
                    if (sheet.GetRow(rowIndex + j).GetCell(2).ToString() != "PURCHASED")
                    {
                        continue;
                    }

                    if (i == 0)
                    {
                        //获取工单余量
                        if (sheet.GetRow(rowIndex + j).GetCell(colIndexAllocated) != null && sheet.GetRow(rowIndex + j).GetCell(colIndexAllocated).CellType == CellType.Numeric)
                        {
                            qtyck = qtyck - ReturnDecimal(sheet.GetRow(rowIndex + j).GetCell(colIndexAllocated).NumericCellValue, 2);
                        }

                        //获取仓库数量
                        for (int s = colIndexCurr; s < colIndexAllocated; s++)
                        {
                            if (sheet.GetRow(rowIndex + j).GetCell(s) != null)
                            {
                                qtyck = qtyck + ReturnDecimal(sheet.GetRow(rowIndex + j).GetCell(s).NumericCellValue, 2);
                            }
                        }
                        //sheet.GetRow(rowIndex + j).CreateCell(colIndexETA + i * 4 + 3).SetCellValue(qty);
                    }

                    //耗用量
                    //for (int s = 3; s < colIndexCurr; s++)
                    //{
                    //    if (sheet.GetRow(rowIndex + j).GetCell(s)!=null && sheet.GetRow(wrow - 1).GetCell(s) != null)
                    //    {
                    //        qty = qty - sheet.GetRow(rowIndex + j).GetCell(s).NumericCellValue * sheet.GetRow(wrow - 1).GetCell(s).NumericCellValue;
                    //    }
                    //}
                    //object objmonth = dtQty.Compute("sum(Qty)", "dtmQty>='" + dtmStart + "' and dtmQty<='" + dtmEnd + "'");
                    //decimal qtymonth = 0;
                    //if (objmonth.ToString() != "")
                    //{
                    //    qtymonth = ReturnDecimal(objmonth.ToString(), 2);
                    //}
                    //qty = qty - qtymonth;

                    //本次ETA计算量

                    //decimal qtynew = 0 - qty;//本月需求数量
                    //string ETA = "";
                    decimal etacount = 0;
                    //ArrayList ddtmdate = new ArrayList();//核对日期
                    //ArrayList dleftQty = new ArrayList();//已核对剩余数量
                    ArrayList arrETA = new ArrayList();
                    ArrayList arrETAQty = new ArrayList();
                    decimal qtyMonth = 0;
                    for (DateTime dtmStartWeek = DateTime.Parse(dtmStart); dtmStartWeek <= DateTime.Parse(dtmEnd); dtmStartWeek = dtmStartWeek.AddDays(7))
                    {
                        //本周计划
                        DateTime dtmEndWeek = dtmStartWeek.AddDays(6);
                        //本周计划数量
                        //double qtyweek = GetResultsQty(sTKVersion, qyPlanner, qyGroup, qyReorderpolicy, rowList[j].ToString(), dtmStartWeek.ToString("yyyy-MM-dd"), dtmEndWeek.ToString("yyyy-MM-dd"), isNetQty, dStart);
                        object objweek = dtQty.Compute("sum(Qty)", "dtmQty>='" + dtmStartWeek.ToString("yyyy-MM-dd") + "' and dtmQty<='" + dtmEndWeek.ToString("yyyy-MM-dd") + "'");

                        decimal qtyweek = 0;
                        if (objweek.ToString() != "")
                        {
                            qtyweek = ReturnDecimal(objweek.ToString(), 2);
                            qtyMonth = qtyMonth + qtyweek;
                        }
                        if (qtyweek - qtyck > 0)
                        {
                            qtyweek = qtyweek - qtyck;
                            qtyck = 0;
                        }
                        else
                        {
                            qtyck = qtyck - qtyweek;
                            qtyweek = 0;
                        }
                        if (qtyweek <= 0)
                        {
                            continue;
                        }
                        #region 找到采购订单
                        for (int s = 0; s < dtETA.Rows.Count; s++)
                        {
                            if (qtyweek <= 0)
                            {
                                break;
                            }
                            string dtmNow = dtETA.Rows[s]["dtmDuedate"].ToString();
                            int b1 = DateTime.Compare(DateTime.Parse(dtmNow), dtmEndWeek);
                            if (b1 > 0)
                            {
                                isCG = true;//判断是否延期
                            }
                            else if (isCG == false && dtETA.Rows[s]["sPONo"].ToString() == "VPO")
                            {
                                isVPO = true;//如果不延期判断是否是VPO
                            }
                            decimal leftqty = ReturnDecimal(dtETA.Rows[s]["leftQty"].ToString(), 2);
                            decimal etaqty = 0;
                            //如果本月计算量小于0跳过
                            if (leftqty == 0)
                            {
                                continue;
                            }
                            //if (ETA != "")
                            //{
                            //    ETA = ETA + ",";
                            //}

                            if (qtyweek > leftqty)
                            {
                                etaqty = leftqty;
                            }
                            else
                            {
                                etaqty = qtyweek;
                            }
                            qtyweek = qtyweek - etaqty;
                            dtETA.Rows[s]["leftQty"] = leftqty - etaqty;
                            etacount = etacount + etaqty;
                            //ddtmdate.Add(dtETA.Rows[s]["dtmDuedate"].ToString());
                            //dleftQty.Add(etaqty);

                            bool beta = false;

                            string ETADate = DateTime.Parse(dtETA.Rows[s]["dtmDuedate"].ToString()).Year.ToString().Substring(2, 2)
                                    + "/" + DateTime.Parse(dtETA.Rows[s]["dtmDuedate"].ToString()).Month.ToString()
                                    + "/" + DateTime.Parse(dtETA.Rows[s]["dtmDuedate"].ToString()).Day.ToString();
                            if (dtETA.Rows[s]["sPONo"].ToString() == "VPO")
                            {
                                ETADate = ETADate + "(LTC)";
                            }

                            for (int t = 0; t < arrETA.Count; t++)
                            {
                                if (arrETA[t].ToString() == ETADate)
                                {
                                    arrETAQty[t] = ReturnDecimal(arrETAQty[t].ToString(), 2) + ReturnDecimal(etaqty, 2);
                                    beta = true;
                                    break;
                                }
                            }
                            if (beta == false)
                            {
                                arrETA.Add(ETADate);
                                arrETAQty.Add(etaqty);
                            }
                            //ETA = ETA + DateTime.Parse(dtETA.Rows[s]["dtmDuedate"].ToString()).Year.ToString().Substring(2, 2)
                            //    + "/" + DateTime.Parse(dtETA.Rows[s]["dtmDuedate"].ToString()).Month.ToString()
                            //    + "/" + DateTime.Parse(dtETA.Rows[s]["dtmDuedate"].ToString()).Day.ToString() + "*" + etaqty.ToString();
                            //if (dtETA.Rows[s]["sPONo"].ToString() == "VPO")
                            //{
                            //    ETA = ETA + "(LTC)";
                            //}
                        }
                        if (qtyweek > 0)
                        {
                            isCG = true;//判断是否延期
                        }
                        #endregion
                    }

                    //decimal leftqtyweek = qty + etacount;
                    //qty = qty + etacount;

                    //本月采购订单数量不足
                    //if (leftqtyweek < 0)
                    //{
                    //    //sheet.GetRow(rowIndex + j).CreateCell(colIndexETA + i * 4 + 3).SetCellValue("Gating");
                    //    isCG = true;
                    //}
                    sheet.GetRow(rowIndex + j).CreateCell(colIndexETA + i * 4 + 1).SetCellValue(double.Parse(etacount.ToString()));

                    string sETA = "";
                    for (int t = 0; t < arrETA.Count; t++)
                    {
                        if (sETA != "")
                        {
                            sETA = sETA + ",";
                        }
                        sETA = sETA + arrETA[t].ToString() + "*" + arrETAQty[t].ToString();
                    }
                    //sETA = sETA + "[" + qtyMonth + "]";
                    sheet.GetRow(rowIndex + j).CreateCell(colIndexETA + i * 4 + 2).SetCellValue(sETA);
                    if (isVPO == true)//包含采购订单
                    {
                        sheet.GetRow(rowIndex + j).CreateCell(colIndexETA + i * 4 + 3).SetCellValue("LTC");
                    }
                    else if (isCG == true)//采购订单数量不足
                    {
                        sheet.GetRow(rowIndex + j).CreateCell(colIndexETA + i * 4 + 3).SetCellValue("Gating");
                    }
                    //sheet.GetRow(rowIndex + j).CreateCell(colIndexETA + i * 4 + 3).SetCellValue(qty);

                }
            }

            CellRangeAddress c = CellRangeAddress.ValueOf("A10:"+ConvertColumnIndexToColumnName(colIndex)+"10");
            sheet.SetAutoFilter(c);

            using (MemoryStream ms = new MemoryStream())
            {
                fileSize = 0;
                workbook.Write(ms);

                ms.Flush();
                //ms.Position = 0;

                //workbook.Dispose();//一般只用写这一个就OK了，他会遍历并释放所有资源，但当前版本有问题所以只释放sheet
                return ms;
            }
        }

        public string ConvertColumnIndexToColumnName(int index)
        {

            index = index + 1;

            int system = 26;

            char[] digArray = new char[100];

            int i = 0;

            while (index > 0)

            {

                int mod = index % system;

                if (mod == 0)

                    mod = system;

                digArray[i++] = (char)(mod - 1 + 'A');

                index = (index - 1) / 26;

            }

            StringBuilder sb = new StringBuilder(i);

            for (int j = i - 1; j >= 0; j--)

            {

                sb.Append(digArray[j]);

            }

            return sb.ToString();

        }

        public DataTable GetPeriod(string sTKVersion)
        {
            int iYear = int.Parse(sTKVersion.Split('-')[1].Substring(0, 4));
            int iMonth = int.Parse(sTKVersion.Split('-')[1].Substring(4, 2));
            int iDay = int.Parse(sTKVersion.Split('-')[1].Substring(6, 2));

            string dDate = iYear + "-";
            if (iMonth.ToString().Length == 1)
            {
                dDate = dDate + "0";
            }
            dDate = dDate + iMonth + "-";
            if (iDay.ToString().Length == 1)
            {
                dDate = dDate + "0";
            }
            dDate = dDate + iDay;

            StringBuilder strSql1 = new StringBuilder();
            strSql1.AppendFormat(" Select * From TK_Base_CalendarPeriod with (nolock) where convert(nvarchar(10),dtmStart,120)<='" + dDate + "' and convert(nvarchar(10),dtmEnd,120)>='" + dDate + "' ");
            DataTable dtc = DbHelperSQL.Query(strSql1.ToString()).Tables[0];
            if (dtc.Rows.Count != 1)
            {
                return null;
            }
            iYear = int.Parse(dtc.Rows[0]["iYear"].ToString());
            iMonth = int.Parse(dtc.Rows[0]["iMonth"].ToString());

            DateTime d = DateTime.Parse(iYear + "-" + iMonth + "-01");
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(@"SET LANGUAGE us_english
select *,substring(convert(varchar(11),iDay,106),4,3) as EgMonth from (
Select top 7 iYear, iMonth,DATEADD(d,1,dtmStart) as dtmStart,DATEADD(d,1,dtmEnd) as dtmEnd,convert(datetime,convert(nvarchar,iYear)+'-'+convert(nvarchar(2),right('0'+convert(nvarchar,iMonth),2))+'-01') as iDay From TK_Base_CalendarPeriod with (nolock)
where convert(nvarchar,iYear)+right('0'+convert(nvarchar,iMonth),2)>={0} order by iYear, iMonth
) a  order by iYear, iMonth", d.ToString("yyyyMM"));
            DataTable result = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            return result;
        }

        //<summary>
        //获得数据列表-导出PAD
        //</summary>
        //<returns></returns>
        public void SetResults(string sTKVersion, string qyPlanner, string qyGroup, string qycategory, string qyReorderpolicy, XSSFRow dataRow, ArrayList cinvList, string dtmStart, string dtmEnd, int IDStart, int IDEnd, string dStart, bool isNetQty)
        {
            DataTable dts = GetResults(sTKVersion, qyPlanner, qyGroup, qycategory, qyReorderpolicy, cinvList, dtmStart, dtmEnd, IDStart, IDEnd, dStart, isNetQty);
            if (dts.Rows.Count > 0)
            {
                for (int j = 0; j < dts.Columns.Count; j++)
                {
                    if (dts.Rows[0][j].ToString() != "")
                    {
                        dataRow.CreateCell(IDStart + j + 3).SetCellValue(double.Parse(dts.Rows[0][j].ToString()));
                    } 
                }
            }
        }

        public void SetBOM(string sTKVersion, string qyPlanner, string qyGroup, string qycategory, string qyReorderpolicy, ISheet sheet, ArrayList cinvList, int rowIndex, int IDStart, int IDEnd)
        {
            DataTable dts = GetBOM(sTKVersion, qyPlanner, qyGroup, qycategory, qyReorderpolicy, cinvList, IDStart, IDEnd);
            if (dts.Rows.Count > 0)
            {
                for (int p = 0; p < dts.Rows.Count; p++)
                {
                    for (int j = 0; j < dts.Columns.Count; j++)
                    {
                        if (dts.Rows[p][j].ToString() != "")
                        {
                            sheet.GetRow(rowIndex + p).CreateCell(IDStart + j + 3).SetCellValue(double.Parse(dts.Rows[p][j].ToString()));
                        }
                        else
                        {
                            //sheet.GetRow(rowIndex + p).CreateCell(IDStart + j + 3).SetCellValue(double.Parse("0"));
                        }
                    }
                }
            }
        }


        public void SetCurr(string sTKVersion, string qyPlanner, string qyGroup, string qycategory, string qyReorderpolicy, ISheet sheet, ArrayList currList, int rowIndex, int colIndexCurr)
        {
            DataTable dts = GetCurr(sTKVersion, qyPlanner, qyGroup, qycategory, qyReorderpolicy, currList, colIndexCurr);
            if (dts.Rows.Count > 0)
            {
                for (int p = 0; p < dts.Rows.Count; p++)
                {
                    for (int j = 0; j < dts.Columns.Count; j++)
                    {
                        if (dts.Rows[p][j].ToString() != "")
                        {
                            sheet.GetRow(rowIndex + p).CreateCell(colIndexCurr + j).SetCellValue(double.Parse(dts.Rows[p][j].ToString()));
                        }
                        else
                        {
                            sheet.GetRow(rowIndex + p).CreateCell(colIndexCurr + j).SetCellValue(double.Parse("0"));
                        }
                    }
                }
            }
        }

        //<summary>
        //获得数据列表-导出PAD
        //</summary>
        //<returns></returns>
        public DataTable GetResults(string sTKVersion, string qyPlanner, string qyGroup, string qycategory, string qyReorderpolicy, ArrayList cinvList, string dtmStart, string dtmEnd, int IDStart, int IDEnd, string dStart, bool isNetQty)
        {
            if (isNetQty == true)
            {
                //计划
                StringBuilder strSql = new StringBuilder();
                strSql.Append(@"
if exists(select * from tempdb..sysobjects where id=object_id('tempdb..#a')) drop table #a
select case when DATEDIFF(d,dtmPeriod,'" + dStart + "')>0 then '" + dStart + "' else dtmPeriod end dtmEnd,PartID as child,NetQty_PAD as qtyChild into #a from TK_Trialkit_Net_Details a with (nolock) ");
                strSql.Append(@"
where 1=1 and isnull(NetQty_PAD,0)<>0");
                strSql.Append(@"
select ");
                for (int i = IDStart; i <= IDEnd; i++)
                {
                    if (i > IDStart)
                    {
                        strSql.Append(@"
    ,");
                    }
                    strSql.Append("sum(case when child='" + cinvList[i] + "' then qtyChild end) [" + cinvList[i] + "]");
                }
                strSql.Append(@"
from #a
                ");

                strSql.Replace("1=1", "1=1 and sTKVersion='" + sTKVersion + "'");

                strSql.Replace("1=1", @"1=1 
                and convert(nvarchar(10),case when DATEDIFF(d,dtmPeriod,'" + dStart + "')>0 then '" + dStart + "' else dtmPeriod end,120)>=convert(nvarchar(10),'" + dtmStart + "',120) ");
                strSql.Replace("1=1", @"1=1 
                and convert(nvarchar(10),case when DATEDIFF(d,dtmPeriod,'" + dStart + "')>0 then '" + dStart + "' else dtmPeriod end,120)<=convert(nvarchar(10),'" + dtmEnd + "',120)");
                DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];

                return dt;
            }
            else
            {
                //齐套
                StringBuilder strSql = new StringBuilder();
                strSql.Append(@"
if exists(select * from tempdb..sysobjects where id=object_id('tempdb..#a')) drop table #a
select case when DATEDIFF(d,dtmPeriod,'" + dStart + "')>0 then '" + dStart + "' else dtmPeriod end dtmEnd,PartID as child,ResultsQty_PAD as qtyChild into #a from TK_Trialkit_Net_Results_ForPAD a with (nolock) ");
                strSql.Append(@"
where 1=1 and isnull(ResultsQty_PAD,0)<>0");
                strSql.Append(@"
select ");
                for (int i = IDStart; i <= IDEnd; i++)
                {
                    if (i > IDStart)
                    {
                        strSql.Append(@"
    ,");
                    }
                    strSql.Append("sum(case when child='" + cinvList[i] + "' then qtyChild end) [" + cinvList[i] + "]");
                }
                strSql.Append(@"
from #a
                ");

                strSql.Replace("1=1", "1=1 and sTKVersion='" + sTKVersion + "'");

                strSql.Replace("1=1", @"1=1 
                and convert(nvarchar(10),case when DATEDIFF(d,dtmPeriod,'" + dStart + "')>0 then '" + dStart + "' else dtmPeriod end,120)>=convert(nvarchar(10),'" + dtmStart + "',120) ");
                strSql.Replace("1=1", @"1=1 
                and convert(nvarchar(10),case when DATEDIFF(d,dtmPeriod,'" + dStart + "')>0 then '" + dStart + "' else dtmPeriod end,120)<=convert(nvarchar(10),'" + dtmEnd + "',120)");
                DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];

                return dt;
            }
        }

        //<summary>
        //获得数据列表-导出PAD Group
        //</summary>
        //<returns></returns>
        public DataTable GetResultsGroup(string sTKVersion, string qyPlanner, string qyGroup, string qycategory, string qyReorderpolicy)
        {
            //获得母件
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"
select cInvCode from (
SELECT PartID as cInvCode,max(orderid)  orderid FROM TK_Trialkit_Net a with (nolock) WHERE 1=1 
            GROUP BY PartID 
) a order by orderid
");
            if (!string.IsNullOrEmpty(sTKVersion))
            {
                strSql.Replace("1=1", "1=1 and sTKVersion='" + sTKVersion + "'");
            }
            if (!string.IsNullOrEmpty(qyPlanner))
            {
                strSql.Replace("1=1", "1=1 and default_plannerid='" + qyPlanner + "'");
            }
            if (!string.IsNullOrEmpty(qycategory))
            {
                strSql.Replace("1=1", "1=1 and category='" + qycategory + "'");
            }
            if (!string.IsNullOrEmpty(qyReorderpolicy))
            {
                strSql.Replace("1=1", "1=1 and reorderpolicy='" + qyReorderpolicy + "'");
            }
            if (!string.IsNullOrEmpty(qyGroup))
            {
                if (qyGroup.IndexOf(',') >= 0)
                {
                    strSql.Replace("1=1", "1=1 and ProGroup in ('" + qyGroup.Replace(",", "','") + "')");
                }
                else
                {
                    strSql.Replace("1=1", "1=1 and ProGroup = '" + qyGroup + "'");
                }
            }
            DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];

            return dt;
        }

        public DataTable GetBOMGroup(string sTKVersion, string qyPlanner, string qyGroup, string qycategory, string qyReorderpolicy)
        {
            //显示子件列表
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"
if exists(select * from tempdb..sysobjects where id=object_id('tempdb..#a')) drop table #a
if exists(select * from tempdb..sysobjects where id=object_id('tempdb..#b')) drop table #b
if exists(select * from tempdb..sysobjects where id=object_id('tempdb..#c')) drop table #c

SELECT PartID as cInvCode
into #a FROM TK_Trialkit_Net a with (nolock)  WHERE 1=1 
GROUP BY PartID

select * into #b from TK_Trialkit_Net_BOM where 2=2 

select * into #c from TK_Trialkit_Net_Child where 3=3 

");
            if (!string.IsNullOrEmpty(sTKVersion))
            {
                strSql.Replace("1=1", "1=1 and sTKVersion='" + sTKVersion + "'");
                strSql.Replace("2=2", "2=2 and sTKVersion='" + sTKVersion + "'");
                strSql.Replace("3=3", "3=3 and sTKVersion='" + sTKVersion + "'");
            }
            if (!string.IsNullOrEmpty(qyPlanner))
            {
                strSql.Replace("1=1", "1=1 and default_plannerid='" + qyPlanner + "'");
            }
            if (!string.IsNullOrEmpty(qycategory))
            {
                strSql.Replace("1=1", "1=1 and category='" + qycategory + "'");
            }
            if (!string.IsNullOrEmpty(qyReorderpolicy))
            {
                strSql.Replace("1=1", "1=1 and reorderpolicy='" + qyReorderpolicy + "'");
            }
            if (!string.IsNullOrEmpty(qyGroup))
            {
                if (qyGroup.IndexOf(',') >= 0)
                {
                    strSql.Replace("1=1", "1=1 and ProGroup in ('" + qyGroup.Replace(",", "','") + "')");
                }
                else
                {
                    strSql.Replace("1=1", "1=1 and ProGroup = '" + qyGroup + "'");
                }
            }
            strSql.Append(@"SELECT b.Child as child,childsm,OpenPO, partdesc, alloqty, vc, prodgroup, lt, moq, mpq, curmat, toplevellist  --into #c  
FROM #a a left join #b b with (nolock) on a.cInvCode=b.PartID left join #c c with (nolock) on b.Child=c.Child 
where b.Child is not null
            group by b.Child,childsm,OpenPO,partdesc, alloqty, vc, prodgroup, lt, moq, mpq, curmat, toplevellist ,orderid order by orderid
");
            DataTable result = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            return result;
        }

        public DataTable GetBOM(string sTKVersion, string qyPlanner, string qyGroup, string qycategory, string qyReorderpolicy, ArrayList cinvList, int IDStart, int IDEnd)
        {
            //显示母件和子件的BOM值
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"
if exists(select * from tempdb..sysobjects where id=object_id('tempdb..#a')) drop table #a
if exists(select * from tempdb..sysobjects where id=object_id('tempdb..#b')) drop table #b
if exists(select * from tempdb..sysobjects where id=object_id('tempdb..#c')) drop table #c

SELECT PartID as cInvCode 
into #a FROM TK_Trialkit_Net a with (nolock) WHERE 1=1 
GROUP BY PartID,orderid

select * into #b from TK_Trialkit_Net_BOM where 2=2 

select * into #c from TK_Trialkit_Net_Child where 3=3 

");
            if (!string.IsNullOrEmpty(sTKVersion))
            {
                strSql.Replace("1=1", "1=1 and sTKVersion='" + sTKVersion + "'");
                strSql.Replace("2=2", "2=2 and sTKVersion='" + sTKVersion + "'");
                strSql.Replace("3=3", "3=3 and sTKVersion='" + sTKVersion + "'");
            }
            if (!string.IsNullOrEmpty(qyPlanner))
            {
                strSql.Replace("1=1", "1=1 and default_plannerid='" + qyPlanner + "'");
            }
            if (!string.IsNullOrEmpty(qycategory))
            {
                strSql.Replace("1=1", "1=1 and category='" + qycategory + "'");
            }
            if (!string.IsNullOrEmpty(qyReorderpolicy))
            {
                strSql.Replace("1=1", "1=1 and reorderpolicy='" + qyReorderpolicy + "'");
            }
            if (!string.IsNullOrEmpty(qyGroup))
            {
                if (qyGroup.IndexOf(',') >= 0)
                {
                    strSql.Replace("1=1", "1=1 and ProGroup in ('" + qyGroup.Replace(",", "','") + "')");
                }
                else
                {
                    strSql.Replace("1=1", "1=1 and ProGroup = '" + qyGroup + "'");
                }
            }
            strSql.Append(@"
SELECT ");
            for (int i = IDStart; i <= IDEnd; i++)
            {
                if (i > IDStart)
                {
                    strSql.Append(@"
,");
                }
                strSql.Append("max(case when a.cInvCode='" + cinvList[i] + "' then b.Qty end) [" + cinvList[i] + "]");
            }
            strSql.Append(@" FROM #a a left join #b b with (nolock) on a.cInvCode=b.PartID
left join #c c with (nolock) on b.Child=c.Child
where b.Child is not null
            group by b.Child,orderid order by orderid");
            DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            return dt;
        }

        public DataTable GetCurrentStockGroup()
        {
            //仓库汇总
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select DISTINCT warehouseclass from t_trialkit_whclass with (nolock)");
            DataTable result = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            return result;
        }

        public DataTable GetCurr(string sTKVersion, string qyPlanner, string qyGroup, string qycategory, string qyReorderpolicy, ArrayList currList, int colIndexCurr)
        {
            //现存量
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"
if exists(select * from tempdb..sysobjects where id=object_id('tempdb..#a')) drop table #a
if exists(select * from tempdb..sysobjects where id=object_id('tempdb..#b')) drop table #b
if exists(select * from tempdb..sysobjects where id=object_id('tempdb..#c')) drop table #c
if exists(select * from tempdb..sysobjects where id=object_id('tempdb..#d')) drop table #d
if exists(select * from tempdb..sysobjects where id=object_id('tempdb..#e')) drop table #e

SELECT PartID as cInvCode
into #a FROM TK_Trialkit_Net a with (nolock)  WHERE 1=1 
GROUP BY PartID

select * into #b from TK_Trialkit_Net_BOM where 2=2 

select * into #c from TK_Trialkit_Net_Child where 3=3 

select * into #d from TK_Trialkit_Net_Warehouse where 4=4 

");
            if (!string.IsNullOrEmpty(sTKVersion))
            {
                strSql.Replace("1=1", "1=1 and sTKVersion='" + sTKVersion + "'");
                strSql.Replace("2=2", "2=2 and sTKVersion='" + sTKVersion + "'");
                strSql.Replace("3=3", "3=3 and sTKVersion='" + sTKVersion + "'");
                strSql.Replace("4=4", "4=4 and sTKVersion='" + sTKVersion + "'");
            }
            if (!string.IsNullOrEmpty(qyPlanner))
            {
                strSql.Replace("1=1", "1=1 and default_plannerid='" + qyPlanner + "'");
            }
            if (!string.IsNullOrEmpty(qycategory))
            {
                strSql.Replace("1=1", "1=1 and category='" + qycategory + "'");
            }
            if (!string.IsNullOrEmpty(qyReorderpolicy))
            {
                strSql.Replace("1=1", "1=1 and reorderpolicy='" + qyReorderpolicy + "'");
            }
            if (!string.IsNullOrEmpty(qyGroup))
            {
                if (qyGroup.IndexOf(',') >= 0)
                {
                    strSql.Replace("1=1", "1=1 and ProGroup in ('" + qyGroup.Replace(",", "','") + "')");
                }
                else
                {
                    strSql.Replace("1=1", "1=1 and ProGroup = '" + qyGroup + "'");
                }
            }

            strSql.Append(@"SELECT b.Child as child,c.orderid into #e");
            strSql.Append(@" FROM #a a left join #b b with (nolock) on a.cInvCode=b.PartID left join #c c with (nolock) on b.Child=c.Child 
where b.Child is not null
            group by b.Child,orderid 
");

            strSql.Append(@"SELECT ");
            for (int i = 0; i < currList.Count; i++)
            {
                if (i > 0)
                {
                    strSql.Append(@"
,");
                }
                strSql.Append("sum(case when warehouseclass='" + currList[i] + "' then dQty end) [" + currList[i] + "]");
            }
            strSql.Append(@" FROM #e a left join #d b with (nolock) on a.child=b.Child  
            group by a.orderid,a.child  order by orderid
");
            DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            return dt;
        }

        public DataTable GetResultsQty(string sTKVersion, string qyPlanner, string qyGroup, string qycategory, string qyReorderpolicy, string cInvCode, bool isNetQty, string dStart)
        {
            if (isNetQty == true)
            {
                //计划
                StringBuilder strSql = new StringBuilder();
                strSql.Append(@"
select cInvCode into #a from (
SELECT PartID as cInvCode,max(orderid)  orderid FROM TK_Trialkit_Net a with (nolock) WHERE 1=1 
            GROUP BY PartID 
) a order by orderid
");
                if (!string.IsNullOrEmpty(sTKVersion))
                {
                    strSql.Replace("1=1", "1=1 and sTKVersion='" + sTKVersion + "'");
                }
                if (!string.IsNullOrEmpty(qyPlanner))
                {
                    strSql.Replace("1=1", "1=1 and default_plannerid='" + qyPlanner + "'");
                }
                if (!string.IsNullOrEmpty(qycategory))
                {
                    strSql.Replace("1=1", "1=1 and category='" + qycategory + "'");
                }
                if (!string.IsNullOrEmpty(qyReorderpolicy))
                {
                    strSql.Replace("1=1", "1=1 and reorderpolicy='" + qyReorderpolicy + "'");
                }
                if (!string.IsNullOrEmpty(qyGroup))
                {
                    if (qyGroup.IndexOf(',') >= 0)
                    {
                        strSql.Replace("1=1", "1=1 and ProGroup in ('" + qyGroup.Replace(",", "','") + "')");
                    }
                    else
                    {
                        strSql.Replace("1=1", "1=1 and ProGroup = '" + qyGroup + "'");
                    }
                }

                strSql.Append(@"

SELECT NetQty_PAD*b.Qty as Qty, convert(nvarchar(10),case when DATEDIFF(d,dtmPeriod,'" + dStart + "')>0 then '" + dStart + "' else dtmPeriod end,120) dtmQty FROM TK_Trialkit_Net_Details a with (nolock) ");
                strSql.Append(@"
left join TK_Trialkit_Net_BOM b with (nolock) on a.PartID=b.PartID and a.sTKVersion=b.sTKVersion 
inner join #a c on a.PartID=c.cInvCode WHERE 2=2 and isnull(NetQty_PAD,0)<>0");
                if (!string.IsNullOrEmpty(sTKVersion))
                {
                    strSql.Replace("2=2", "2=2 and a.sTKVersion='" + sTKVersion + "'");
                }
                if (!string.IsNullOrEmpty(cInvCode))
                {
                    strSql.Replace("2=2", "2=2 and b.Child='" + cInvCode + "'");
                }

                return DbHelperSQL.Query(strSql.ToString()).Tables[0];
            }
            else
            {
                //齐套
                StringBuilder strSql = new StringBuilder();
                strSql.Append(@"
select cInvCode into #a from (
SELECT PartID as cInvCode,max(orderid)  orderid FROM TK_Trialkit_Net a with (nolock) WHERE 1=1 
            GROUP BY PartID 
) a order by orderid
");
                if (!string.IsNullOrEmpty(sTKVersion))
                {
                    strSql.Replace("1=1", "1=1 and sTKVersion='" + sTKVersion + "'");
                }
                if (!string.IsNullOrEmpty(qyPlanner))
                {
                    strSql.Replace("1=1", "1=1 and default_plannerid='" + qyPlanner + "'");
                }
                if (!string.IsNullOrEmpty(qycategory))
                {
                    strSql.Replace("1=1", "1=1 and category='" + qycategory + "'");
                }
                if (!string.IsNullOrEmpty(qyReorderpolicy))
                {
                    strSql.Replace("1=1", "1=1 and reorderpolicy='" + qyReorderpolicy + "'");
                }
                if (!string.IsNullOrEmpty(qyGroup))
                {
                    if (qyGroup.IndexOf(',') >= 0)
                    {
                        strSql.Replace("1=1", "1=1 and ProGroup in ('" + qyGroup.Replace(",", "','") + "')");
                    }
                    else
                    {
                        strSql.Replace("1=1", "1=1 and ProGroup = '" + qyGroup + "'");
                    }
                }

                strSql.Append(@"

SELECT ResultsQty_PAD*b.Qty as Qty, convert(nvarchar(10),case when DATEDIFF(d,dtmPeriod,'" + dStart + "')>0 then '" + dStart + "' else dtmPeriod end,120) dtmQty FROM TK_Trialkit_Net_Results_ForPAD a with (nolock) ");
                strSql.Append(@"
left join TK_Trialkit_Net_BOM b with (nolock) on a.PartID=b.PartID and a.sTKVersion=b.sTKVersion 
inner join #a c on a.PartID=c.cInvCode WHERE 2=2 and isnull(ResultsQty_PAD,0)<>0");
                if (!string.IsNullOrEmpty(sTKVersion))
                {
                    strSql.Replace("2=2", "2=2 and a.sTKVersion='" + sTKVersion + "'");
                }
                if (!string.IsNullOrEmpty(cInvCode))
                {
                    strSql.Replace("2=2", "2=2 and b.Child='" + cInvCode + "'");
                }

                return DbHelperSQL.Query(strSql.ToString()).Tables[0];
            }
        }

        /// <summary>
        /// 用于Web导出
        /// </summary>
        /// <param name="dtSource">源DataTable</param>
        /// <param name="dtp">源DataTable</param>
        /// <param name="strHeaderText">表头文本</param>
        /// <param name="strFileName">文件名</param>
        public void ExportByWebPAD(string sTKVersion, string qyPlanner, string qyGroup, string qycategory, string qyReorderpolicy, string strHeaderText, string strFileName, bool isNetQty)
        {
            //HttpContext curContext = HttpContext.Current;

            long fileSize = 0;
            MemoryStream ms = ExportPAD(sTKVersion, qyPlanner, qyGroup, qycategory, qyReorderpolicy, strHeaderText, out fileSize, isNetQty);

            //// 设置编码和附件格式
            ////curContext.Response.ContentType = "application/vnd.ms-excel";
            ////curContext.Response.ContentEncoding = Encoding.UTF8;
            ////curContext.Response.Charset = "";
            //curContext.Response.AppendHeader("Content-Disposition",
            //    "attachment;filename=" + HttpUtility.UrlEncode(strFileName, Encoding.UTF8));
            //HttpContext.Current.Response.AddHeader("Content-Length", ms.Length.ToString());
            //curContext.Response.BinaryWrite(ms.GetBuffer());
            //curContext.Response.End();
            //ms.Dispose()
            
            HttpContext context = HttpContext.Current;
            context.Response.Clear();
            context.Response.ContentEncoding = Encoding.GetEncoding("GB2312");
            context.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";//application/octet-stream
            context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + strFileName);
            ////context.Response.AddHeader("Content-Length", fileSize.ToString());
            context.Response.BinaryWrite(ms.ToArray());
            //context.Response.Flush();
            //context.ApplicationInstance.CompleteRequest();
            //context.Response.End();
            context.Response.Flush();
            context.Response.End();
        }
        #endregion

        protected decimal ReturnDecimal(object o, int iLength)
        {
            decimal d = 0;
            try
            {
                d = decimal.Round(Convert.ToDecimal(o), iLength);
            }
            catch { }
            return d;
        }
    }
}
