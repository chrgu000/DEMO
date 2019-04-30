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
            context.Response.ContentType = "application/octet-stream";
            context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + strFileName);
            //context.Response.AddHeader("Content-Length", fileSize.ToString());
            context.Response.BinaryWrite(ms.ToArray());
            context.Response.Flush();
            context.ApplicationInstance.CompleteRequest();
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
        public MemoryStream ExportPAD(string sTKVersion, string qyPlanner, string qyGroup, string qyReorderpolicy, string strHeaderText, out long fileSize, bool isNetQty)
        {
            DataTable dtp = GetPeriod(sTKVersion);
            //DataTable dtt = GetResults(sTKVersion, qyPlanner, qyGroup);
            DataTable dtg = GetResultsGroup(sTKVersion, qyPlanner, qyGroup, qyReorderpolicy);
            //DataTable dtc = GetCurrentStock(sTKVersion);
            DataTable dtcg = GetCurrentStockGroup();
            DataTable dtbomg = GetBOMGroup(sTKVersion, qyPlanner, qyGroup, qyReorderpolicy);
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
                        SetResults(sTKVersion, qyPlanner, qyGroup, qyReorderpolicy, dataRow, cinvList, dtmStart, dtmEnd, IDStart, IDEnd, DateTime.Parse(dtp.Rows[0]["dtmStart"].ToString()).ToString("yyyy-MM-dd"), isNetQty);
                    }
                    else if (s == cinvList.Count - 1)
                    {
                        int IDStart = cinvList.Count - (s + 1) % group;
                        int IDEnd = s;
                        SetResults(sTKVersion, qyPlanner, qyGroup, qyReorderpolicy, dataRow, cinvList, dtmStart, dtmEnd, IDStart, IDEnd, DateTime.Parse(dtp.Rows[0]["dtmStart"].ToString()).ToString("yyyy-MM-dd"), isNetQty);
                    }
                }
            }

            //添加子件BOM
            int rowIndex = 10;
            ArrayList rowList = new ArrayList();
            ArrayList rowOpenPOList = new ArrayList();
            //循环物料，添加子件
            for (int i = 0; i < dtbomg.Rows.Count; i++)
            {
                string sChild = dtbomg.Rows[i]["child"].ToString();
                string fOpenQTY = dtbomg.Rows[i]["fOpenQTY"].ToString();
                XSSFRow dataRow = (XSSFRow)sheet.CreateRow(rowIndex + i);

                dataRow.CreateCell(0).SetCellValue(sChild);
                dataRow.CreateCell(1).SetCellValue(dtbomg.Rows[i]["partdesc"].ToString());
                dataRow.CreateCell(2).SetCellValue(dtbomg.Rows[i]["childsm"].ToString());
                if (dtbomg.Rows[i]["alloqty"].ToString() != "")
                {
                    dataRow.CreateCell(colIndexAllocated).SetCellValue(double.Parse(dtbomg.Rows[i]["alloqty"].ToString()));
                }

                dataRow.CreateCell(colIndexOpenPO + 1).SetCellValue(dtbomg.Rows[i]["vc"].ToString());
                dataRow.CreateCell(colIndexOpenPO + 2).SetCellValue(dtbomg.Rows[i]["prodgroup"].ToString());
                dataRow.CreateCell(colIndexOpenPO + 3).SetCellValue(dtbomg.Rows[i]["lt"].ToString());
                dataRow.CreateCell(colIndexOpenPO + 4).SetCellValue(dtbomg.Rows[i]["moq"].ToString());
                dataRow.CreateCell(colIndexOpenPO + 5).SetCellValue(dtbomg.Rows[i]["mpq"].ToString());
                dataRow.CreateCell(colIndexOpenPO + 6).SetCellValue(dtbomg.Rows[i]["curmat"].ToString());
                dataRow.CreateCell(colIndexOpenPO + 7).SetCellValue(dtbomg.Rows[i]["toplevellist"].ToString());

                rowList.Add(sChild);
                rowOpenPOList.Add(fOpenQTY);
            }
            //循环子件添加BOM
            for (int s = 1; s < cinvList.Count; s++)
            {
                if ((s + 1) % group == 0)
                {
                    int IDStart = s + 1 - group;
                    int IDEnd = s;
                    SetBOM(sTKVersion, qyPlanner, qyGroup, qyReorderpolicy, sheet, cinvList, rowIndex, IDStart, IDEnd);
                    
                }
                else if (s == cinvList.Count - 1)
                {
                    int IDStart = cinvList.Count - (s + 1) % group;
                    int IDEnd = s;
                    SetBOM(sTKVersion, qyPlanner, qyGroup, qyReorderpolicy, sheet, cinvList, rowIndex, IDStart, IDEnd);
                    
                }
            }

            //循环子件添加库存
            SetCurr(sTKVersion, qyPlanner, qyGroup, qyReorderpolicy, sheet, currList, rowIndex, colIndexCurr);

            //循环子件添加ETA Status
            for (int j = 0; j < rowList.Count; j++)
            {
                if (rowList[j].ToString() == "071317800207")
                {
                    string ss = "";
                }
                bool isVPO = false;//是否有vpo订单
                bool isCG = false;//采购订单是否满足
                bool isWeek = false;//是否满足周
                StringBuilder strSql = new StringBuilder();
                strSql.Append(@"select sPONo,iItemNO,dtmDuedate,sum(fOpenQTY) as fOpenQTY,sum(fOpenQTY) as leftQty from 
             TK_PO a with (nolock) where 1=1 and iItemNO='" + rowList[j] + "'  group by sPONo,iItemNO,dtmDuedate  order by dtmDuedate");//and dtmDuedate between '" + dtmStart + "' and '" + dtmEnd + "'
                DataTable dtETA = DbHelperSQL.Query(strSql.ToString()).Tables[0];

                double qty = 0;

                for (int i = 0; i < dtp.Rows.Count; i++)
                {
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
                    if(i == 0){
                        //获取工单余量
                        if (sheet.GetRow(rowIndex + j).GetCell(colIndexAllocated)!=null && sheet.GetRow(rowIndex + j).GetCell(colIndexAllocated).CellType == CellType.Numeric)
                        {
                            qty = qty - sheet.GetRow(rowIndex + j).GetCell(colIndexAllocated).NumericCellValue;
                        }
                        
                        //获取仓库数量
                        for (int s = colIndexCurr; s < colIndexAllocated; s++)
                        {
                            if (sheet.GetRow(rowIndex + j).GetCell(s) != null)
                            {
                                qty = qty + sheet.GetRow(rowIndex + j).GetCell(s).NumericCellValue;
                            }
                        }
                        //sheet.GetRow(rowIndex + j).CreateCell(colIndexETA + i * 4 + 3).SetCellValue(qty);
                    }
                    //耗用量
                    for (int s = 3; s < colIndexCurr; s++)
                    {
                        if (sheet.GetRow(rowIndex + j).GetCell(s)!=null && sheet.GetRow(wrow - 1).GetCell(s) != null)
                        {
                            qty = qty - sheet.GetRow(rowIndex + j).GetCell(s).NumericCellValue * sheet.GetRow(wrow - 1).GetCell(s).NumericCellValue;
                        }
                    }
                    
                    //本次ETA计算量
                    if (qty < 0)
                    {
                        //if (sheet.GetRow(rowIndex + j).GetCell(0).ToString() != "DEC362496")
                        //{
                        //    string aa = "";
                        //}
                        double qtynew = 0 - qty;
                        string ETA = "";
                        double etacount = 0;
                        ArrayList ddtmdate = new ArrayList();//核对日期
                        ArrayList dleftQty = new ArrayList();//已核对剩余数量

                        #region 找到采购订单
                        for (int s = 0; s < dtETA.Rows.Count; s++)
                        {
                            string dtmNow = dtETA.Rows[s]["dtmDuedate"].ToString();
                            int b1 = DateTime.Compare(DateTime.Parse(dtmNow), DateTime.Parse(dtmEnd));
                            if (b1 > 0)
                            {
                                continue;
                            }
                            if (dtETA.Rows[s]["sPONo"].ToString() == "VPO")
                            {
                                //sheet.GetRow(rowIndex + j).CreateCell(colIndexETA + i * 4 + 3).SetCellValue("Gating");
                                isVPO = true;
                            }
                            double leftqty = double.Parse(dtETA.Rows[s]["leftQty"].ToString());
                            double etaqty = 0;
                            //如果本月计算量小于0跳过
                            if (leftqty == 0)
                            {
                                continue;
                            }
                            if (ETA != "")
                            {
                                ETA = ETA + ",";
                            }

                            if (qtynew > leftqty)
                            {
                                etaqty = leftqty;
                            }
                            else
                            {
                                etaqty = qtynew;
                            }
                            dtETA.Rows[s]["leftQty"] = leftqty - etaqty;
                            etacount = etacount + etaqty;
                            ddtmdate.Add(dtETA.Rows[s]["dtmDuedate"].ToString());
                            dleftQty.Add(etaqty);
                            ETA = ETA + DateTime.Parse(dtETA.Rows[s]["dtmDuedate"].ToString()).Year.ToString().Substring(2,2) 
                                + "/" + DateTime.Parse(dtETA.Rows[s]["dtmDuedate"].ToString()).Month.ToString() 
                                + "/" + DateTime.Parse(dtETA.Rows[s]["dtmDuedate"].ToString()).Day.ToString() + "*" + etaqty.ToString();
                        }
                        #endregion

                        qty = qty + etacount;
                        sheet.GetRow(rowIndex + j).CreateCell(colIndexETA + i * 4 + 1).SetCellValue(etacount);
                        sheet.GetRow(rowIndex + j).CreateCell(colIndexETA + i * 4 + 2).SetCellValue(ETA);
                        //sheet.GetRow(rowIndex + j).CreateCell(colIndexETA + i * 4 + 3).SetCellValue(qty);//Status
                        //本月采购订单数量不足
                        if (qty < 0)
                        {
                            //sheet.GetRow(rowIndex + j).CreateCell(colIndexETA + i * 4 + 3).SetCellValue("Gating");
                            isCG = true;
                        }
                        else
                        {
                            DataTable dttmp = GetResults(sTKVersion, qyPlanner, qyGroup, qyReorderpolicy, rowList[j].ToString(), dtmStart, dtmEnd);
                            for (int p = 0; p < dttmp.Rows.Count; p++)
                            {
                                double LeftQty = double.Parse(dttmp.Rows[p]["LeftQty"].ToString());
                                if (isWeek = false && LeftQty > 0)
                                {
                                    DateTime dtmQty = DateTime.Parse(dttmp.Rows[p]["dtmQty"].ToString());
                                    for (int q = 0; q < ddtmdate.Count; q++)
                                    {
                                        double chkQty = double.Parse(dleftQty[q].ToString());
                                        if (isWeek = false && chkQty > 0)
                                        {
                                            DateTime chkdtmQty = DateTime.Parse(ddtmdate[q].ToString());
                                            double qtytmp = 0;
                                            if (LeftQty > chkQty)
                                            {
                                                qtytmp = chkQty;
                                            }
                                            else
                                            {
                                                qtytmp = LeftQty;
                                            }
                                            if (DateTime.Compare(dtmQty, chkdtmQty) < 0)
                                            {
                                                isCG = true;
                                                continue;
                                            }
                                            else
                                            {
                                                dleftQty[q] = qtytmp;
                                                dttmp.Rows[p]["LeftQty"] = LeftQty - qtytmp;
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        if (isVPO == true)//包含采购订单
                        {
                        }
                        else if (isCG == true)//采购订单数量不足
                        {
                            sheet.GetRow(rowIndex + j).CreateCell(colIndexETA + i * 4 + 3).SetCellValue("Gating");
                        }
                    }
                }
            }

            //循环子件添加PO
            for (int i = 0; i < rowOpenPOList.Count; i++)
            {
                sheet.GetRow(i + rowIndex).CreateCell(colIndexOpenPO).SetCellValue(double.Parse(rowOpenPOList[i].ToString()));
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
Select top 7 iYear, iMonth,dtmStart,dtmEnd,convert(datetime,convert(nvarchar,iYear)+'-'+convert(nvarchar(2),right('0'+convert(nvarchar,iMonth),2))+'-01') as iDay From TK_Base_CalendarPeriod with (nolock)
where convert(nvarchar,iYear)+right('0'+convert(nvarchar,iMonth),2)>={0} order by iYear, iMonth
) a  order by iYear, iMonth", d.ToString("yyyyMM"));
            DataTable result = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            return result;
        }

        //<summary>
        //获得数据列表-导出PAD
        //</summary>
        //<returns></returns>
        public DataTable GetResults(string sTKVersion, string qyPlanner, string qyGroup, string qyReorderpolicy)
        {
            StringBuilder strSql = new StringBuilder();
//            strSql.Append(@"SELECT cInvCode,dtmQty,sum(Qty) as Qty FROM TK_Trialkitting_Results with (nolock) WHERE 1=1 --and isnull(R.Qty,0)<>0 
//            GROUP BY cInvCode,dtmQty ");
            strSql.Append(@"SELECT cInvCode,dtmQty,sum(NetQty) as Qty FROM TK_Trialkitting_Results with (nolock) WHERE 1=1 --and isnull(R.Qty,0)<>0 
            GROUP BY cInvCode,dtmQty ");
            if (!string.IsNullOrEmpty(sTKVersion))
            {
                strSql.Replace("1=1", "1=1 and sTKVersion='" + sTKVersion + "'");
            }
            if (!string.IsNullOrEmpty(qyPlanner))
            {
                strSql.Replace("1=1", "1=1 and Planner='" + qyPlanner + "'");
            }
            if (!string.IsNullOrEmpty(qyGroup))
            {
                string[] splitqueryGroup = qyGroup.Split(',');
                string listqueryGroup = "";
                for (int i = 0; i < splitqueryGroup.Length; i++)
                {
                    if (splitqueryGroup[i] != "")
                    {
                        if (listqueryGroup != "")
                        {
                            listqueryGroup = listqueryGroup + ",";
                        }
                        listqueryGroup = listqueryGroup + "'" + splitqueryGroup[i] + "'";
                    }
                }
                strSql.Replace("1=1", "1=1 and ProdGroup in (" + listqueryGroup + ")");
            }
            if (!string.IsNullOrEmpty(qyReorderpolicy))
            {
                strSql.Replace("1=1", "1=1 and Reorderpolicy='" + qyReorderpolicy + "'");
            }
            DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];

            return dt;
        }

        //<summary>
        //获得数据列表-导出PAD
        //</summary>
        //<returns></returns>
        public void SetResults(string sTKVersion, string qyPlanner, string qyGroup, string qyReorderpolicy, XSSFRow dataRow, ArrayList cinvList, string dtmStart, string dtmEnd, int IDStart, int IDEnd, string dStart, bool isNetQty)
        {
            DataTable dts = GetResults(sTKVersion, qyPlanner, qyGroup, qyReorderpolicy, cinvList, dtmStart, dtmEnd, IDStart, IDEnd, dStart, isNetQty);
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

        //<summary>
        //获得数据列表-导出PAD
        //</summary>
        //<returns></returns>
        public DataTable GetResults(string sTKVersion, string qyPlanner, string qyGroup, string qyReorderpolicy, ArrayList cinvList, string dtmStart, string dtmEnd, int IDStart, int IDEnd, string dStart, bool isNetQty)
        {
            StringBuilder strSql = new StringBuilder();
//            strSql.Append(@"
//select max(sDataVersion) sDataVersion,sTKVersion into #b from TK_Trialkitting_Result with (nolock) where 2=2 group by sTKVersion
//
//                select dStart as dtmQty,sPartID as cInvCode,fOpenQTY as NetQty into #a from TK_WO_History a with (nolock) left join #b b on a.sVersion=b.sDataVersion where 2=2 
//                union all
//                select dStart as dtmQty,sItemNo,dQty from TK_CurrentStock_History a with (nolock) left join #b b on a.sVersion=b.sDataVersion where 2=2
//                union all
//                select case when dtmEnd<dStart then dStart else dtmEnd end as dtmQty,child as cInvCode,qtyChild as NetQty into #a from TK_Trialkit_Calculate with (nolock)  where 2=2
//                ");
//            strSql.Replace("2=2", "2=2 and sTKVersion='" + sTKVersion + "'");
//            strSql.Replace("dStart", "'" + dStart + "'");
            if (isNetQty == true)
            {
                strSql.Append(@"
                SELECT  ");
                for (int i = IDStart; i <= IDEnd; i++)
                {
                    if (i > IDStart)
                    {
                        strSql.Append(",");
                    }
                    strSql.Append("sum(case when cInvCode='" + cinvList[i] + "' then Qty end) [" + cinvList[i] + "]");
                }
                strSql.Append(@" FROM TK_Trialkitting_Results  a with (nolock) WHERE 1=1 --and isnull(Qty,0)<>0 
            and convert(nvarchar(10),dtmQty,120)>=convert(nvarchar(10),'" + dtmStart + "',120) and convert(nvarchar(10),dtmQty,120)<=convert(nvarchar(10),'" + dtmEnd + "',120)");
                strSql.Replace("1=1", "1=1 and sTKVersion='" + sTKVersion + "'");
            }
            else
            {
                strSql.Append(@"
                select max(sDataVersion) sDataVersion,sTKVersion into #a from TK_Trialkitting_Result with (nolock) where 2=2  group by sTKVersion
                SELECT  ");
                for (int i = IDStart; i <= IDEnd; i++)
                {
                    if (i > IDStart)
                    {
                        strSql.Append(",");
                    }
                    strSql.Append("sum(case when sPartID='" + cinvList[i] + "' then fOpenQTY end) [" + cinvList[i] + "]");
                }
                strSql.Append(@" FROM TK_NetRequirement_History a with (nolock) left join #a b on a.sVersion=b.sDataVersion  WHERE 1=1
            and convert(nvarchar(10),dtmRequirement,120)>=convert(nvarchar(10),'" + dtmStart + "',120) and convert(nvarchar(10),dtmRequirement,120)<=convert(nvarchar(10),'" + dtmEnd + "',120)");
                strSql.Replace("1=1", "1=1 and sTKVersion='" + sTKVersion + "'");
            }


            //if (!string.IsNullOrEmpty(sTKVersion))
            //{
            //    strSql.Replace("1=1", "1=1 and sTKVersion='" + sTKVersion + "'");
            //}
            //if (!string.IsNullOrEmpty(qyPlanner))
            //{
            //    strSql.Replace("1=1", "1=1 and Planner='" + qyPlanner + "'");
            //}
            //if (!string.IsNullOrEmpty(qyGroup))
            //{
            //    string[] splitqueryGroup = qyGroup.Split(',');
            //    string listqueryGroup = "";
            //    for (int i = 0; i < splitqueryGroup.Length; i++)
            //    {
            //        if (splitqueryGroup[i] != "")
            //        {
            //            if (listqueryGroup != "")
            //            {
            //                listqueryGroup = listqueryGroup + ",";
            //            }
            //            listqueryGroup = listqueryGroup + "'" + splitqueryGroup[i] + "'";
            //        }
            //    }
            //    strSql.Replace("1=1", "1=1 and ProdGroup in (" + listqueryGroup + ")");
            //}
//            if (sTKVersion.Substring(0, 3) == "00-")
//            {
//                strSql.Append(@"select sPartID as cInvCode,dtmRequirement as dtmQty,sum(fQTY) as NetQty into #a from TK_NetRequirement_History T with (nolock) 
//left join (select max(sDataVersion) sDataVersion,sTKVersion from TK_Trialkitting_Result with (nolock) group by sTKVersion) R on T.sVersion=R.sDataVersion 
//                Where 1=1 group by sPartID,dtmRequirement ");
//                strSql.Replace("1=1", "1=1  and convert(nvarchar(10),dtmRequirement,120)>=convert(nvarchar(10),'" + dtmStart + "',120) and convert(nvarchar(10),dtmRequirement,120)<=convert(nvarchar(10),'" + dtmEnd + "',120)");
//                if (!string.IsNullOrEmpty(sTKVersion))
//                {
//                    strSql.Replace("1=1", "1=1 and sTKVersion='" + sTKVersion + "'");
//                }
//                if (!string.IsNullOrEmpty(qyPlanner))
//                {
//                    strSql.Replace("1=1", "1=1 and sPlannerCode='" + qyPlanner + "'");
//                }
//                if (!string.IsNullOrEmpty(qyGroup))
//                {
//                    string[] splitqueryGroup = qyGroup.Split(',');
//                    string listqueryGroup = "";
//                    for (int i = 0; i < splitqueryGroup.Length; i++)
//                    {
//                        if (splitqueryGroup[i] != "")
//                        {
//                            if (listqueryGroup != "")
//                            {
//                                listqueryGroup = listqueryGroup + ",";
//                            }
//                            listqueryGroup = listqueryGroup + "'" + splitqueryGroup[i] + "'";
//                        }
//                    }
//                    strSql.Replace("1=1", "1=1 and sProductGroup in (" + listqueryGroup + ")");
//                }
//                if (!string.IsNullOrEmpty(qyReorderpolicy))
//                {
//                    strSql.Replace("1=1", "1=1 and Reorderpolicy='" + qyReorderpolicy + "'");
//                }
//            }
//            else
//            {
//                strSql.Append(@"select Partid as cInvCode,dtmPeriod as dtmQty,sum(Qty) as NetQty into #a from TK_Trialkit_Trial_Upload T with (nolock) 
//                Where 1=1 group by Partid,dtmPeriod");
//                strSql.Replace("1=1", "1=1  and convert(nvarchar(10),dtmPeriod,120)>=convert(nvarchar(10),'" + dtmStart + "',120) and convert(nvarchar(10),dtmPeriod,120)<=convert(nvarchar(10),'" + dtmEnd + "',120)");
//                if (!string.IsNullOrEmpty(sTKVersion))
//                {
//                    strSql.Replace("1=1", "1=1 and sTKVersion='" + sTKVersion + "'");
//                }
//                //if (!string.IsNullOrEmpty(qyPlanner))
//                //{
//                //    strSql.Replace("1=1", "1=1 and Planner='" + qyPlanner + "'");
//                //}
//                //if (!string.IsNullOrEmpty(qyGroup))
//                //{
//                //    string[] splitqueryGroup = qyGroup.Split(',');
//                //    string listqueryGroup = "";
//                //    for (int i = 0; i < splitqueryGroup.Length; i++)
//                //    {
//                //        if (splitqueryGroup[i] != "")
//                //        {
//                //            if (listqueryGroup != "")
//                //            {
//                //                listqueryGroup = listqueryGroup + ",";
//                //            }
//                //            listqueryGroup = listqueryGroup + "'" + splitqueryGroup[i] + "'";
//                //        }
//                //    }
//                //    strSql.Replace("1=1", "1=1 and ProdGroup in (" + listqueryGroup + ")");
//                //}
//                //if (!string.IsNullOrEmpty(qyReorderpolicy))
//                //{
//                //    strSql.Replace("1=1", "1=1 and Reorderpolicy='" + qyReorderpolicy + "'");
//                //}
//            }
//            strSql.Append(@"
//            SELECT  ");
//            for (int i = IDStart; i <= IDEnd; i++)
//            {
//                if (i > IDStart)
//                {
//                    strSql.Append(",");
//                }
//                strSql.Append("sum(case when cInvCode='" + cinvList[i] + "' then NetQty end) [" + cinvList[i] + "]");
//            }
//            strSql.Append(@" FROM #a with (nolock) --and isnull(Qty,0)<>0 
//            ");
            
            
            DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];

            return dt;
        }

        //<summary>
        //获得数据列表-导出PAD Group
        //</summary>
        //<returns></returns>
        public DataTable GetResultsGroup(string sTKVersion, string qyPlanner, string qyGroup,string qyReorderpolicy)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT DISTINCT cInvCode,orderid FROM TK_Trialkitting_Results with (nolock) 
                left join (select child as schild,max(orderid) AS orderid from TK_BOM_Order with (nolock) group by child) f on TK_Trialkitting_Results.cInvCode=f.schild 
            WHERE 1=1 --and isnull(Qty,0)<>0 
            GROUP BY cInvCode,orderid order by orderid");
            if (!string.IsNullOrEmpty(sTKVersion))
            {
                strSql.Replace("1=1", "1=1 and sTKVersion='" + sTKVersion + "'");
            }
            //if (!string.IsNullOrEmpty(qyPlanner))
            //{
            //    strSql.Replace("1=1", "1=1 and Planner='" + qyPlanner + "'");
            //}
            if (!string.IsNullOrEmpty(qyReorderpolicy))
            {
                strSql.Replace("1=1", "1=1 and Reorderpolicy='" + qyReorderpolicy + "'");
            }
            if (!string.IsNullOrEmpty(qyGroup))
            {
                string[] splitqueryGroup = qyGroup.Split(',');
                string listqueryGroup = "";
                for (int i = 0; i < splitqueryGroup.Length; i++)
                {
                    if (splitqueryGroup[i] != "")
                    {
                        if (listqueryGroup != "")
                        {
                            listqueryGroup = listqueryGroup + ",";
                        }
                        listqueryGroup = listqueryGroup + "'" + splitqueryGroup[i] + "'";
                    }
                }
                strSql.Replace("1=1", "1=1 and ProdGroup in (" + listqueryGroup + ")");
            }
            DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];

            return dt;
        }

        //<summary>
        //获得数据列表-导出PAD
        //</summary>
        //<returns></returns>
        public DataTable GetResults(string sTKVersion, string qyPlanner, string qyGroup, string qyReorderpolicy, string cInvCode, string dtmStart, string dtmEnd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT dtmQty,Qty,Qty as LeftQty ");
            strSql.Append(@" FROM TK_Trialkitting_Results with (nolock) WHERE 1=1 --and isnull(Qty,0)<>0 
            and convert(nvarchar(10),dtmQty,120)>=convert(nvarchar(10),'" + dtmStart + "',120) and convert(nvarchar(10),dtmQty,120)<=convert(nvarchar(10),'" + dtmEnd + "',120)");
            if (!string.IsNullOrEmpty(sTKVersion))
            {
                strSql.Replace("1=1", "1=1 and sTKVersion='" + sTKVersion + "'");
            }
            //if (!string.IsNullOrEmpty(qyPlanner))
            //{
            //    strSql.Replace("1=1", "1=1 and Planner='" + qyPlanner + "'");
            //}
            if (!string.IsNullOrEmpty(qyGroup))
            {
                string[] splitqueryGroup = qyGroup.Split(',');
                string listqueryGroup = "";
                for (int i = 0; i < splitqueryGroup.Length; i++)
                {
                    if (splitqueryGroup[i] != "")
                    {
                        if (listqueryGroup != "")
                        {
                            listqueryGroup = listqueryGroup + ",";
                        }
                        listqueryGroup = listqueryGroup + "'" + splitqueryGroup[i] + "'";
                    }
                }
                strSql.Replace("1=1", "1=1 and ProdGroup in (" + listqueryGroup + ")");
            }
            if (!string.IsNullOrEmpty(qyReorderpolicy))
            {
                strSql.Replace("1=1", "1=1 and Reorderpolicy='" + qyReorderpolicy + "'");
            }
            if (!string.IsNullOrEmpty(cInvCode))
            {
                strSql.Replace("1=1", "1=1 and cInvCode='" + cInvCode + "'");
            }
            DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];

            return dt;
        }

        public DataTable GetBOMGroup(string sTKVersion, string qyPlanner, string qyGroup, string qyReorderpolicy)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"
            select iItemNO,sum(fOpenQTY) as fOpenQTY into #a from (
            select iItemNO,fOpenQTY from TK_PO with (nolock) where sPONo <> 'VPO'
                    union all
                    select sPartID,fOpenQTY from TK_WO with (nolock) 
            ) a group by iItemNO 

           select * into #b from TK_BOM with (nolock) 
			select * into #c from TK_Trialkitting_Results with (nolock) 
			select * into #d from _Get_TK_Material_Combine_String with (nolock) 

			select * into #f from _Get_TK_PartMaster with (nolock) 

            SELECT DISTINCT child,childsm,isnull(PO.fOpenQTY,0) as fOpenQTY
                ,case when isnull(ie.partdesc,'')<>'' then ie.partdesc else p.partdesc end partdesc, alloqty, vc, ie.prodgroup, lt, moq, mpq, curmat, toplevellist
                 FROM #b T with (nolock) left join #c R with (nolock) on T.parent=R.cInvCode 
                left join #a PO on T.child=PO.iItemNO 
                left join #d ie with (nolock) on T.child=ie.partnum
                left join #f p with (nolock) on T.child=p.partnum

             WHERE 1=1 and R.cInvCode is not null --and isnull(R.Qty,0)<>0 ");
            if (!string.IsNullOrEmpty(sTKVersion))
            {
                strSql.Replace("1=1", "1=1 and sTKVersion='" + sTKVersion + "'");
            }
            //if (!string.IsNullOrEmpty(qyPlanner))
            //{
            //    strSql.Replace("1=1", "1=1 and Planner='" + qyPlanner + "'");
            //}
            if (!string.IsNullOrEmpty(qyGroup))
            {
                string[] splitqueryGroup = qyGroup.Split(',');
                string listqueryGroup = "";
                for (int i = 0; i < splitqueryGroup.Length; i++)
                {
                    if (splitqueryGroup[i] != "")
                    {
                        if (listqueryGroup != "")
                        {
                            listqueryGroup = listqueryGroup + ",";
                        }
                        listqueryGroup = listqueryGroup + "'" + splitqueryGroup[i] + "'";
                    }
                }
                strSql.Replace("1=1", "1=1 and R.ProdGroup in (" + listqueryGroup + ")");
            }
            //if (!string.IsNullOrEmpty(qyReorderpolicy))
            //{
            //    strSql.Replace("1=1", "1=1 and Reorderpolicy='" + qyReorderpolicy + "'");
            //}

            DataTable result = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            return result;
        }

        public void SetBOM(string sTKVersion, string qyPlanner, string qyGroup, string qyReorderpolicy, ISheet sheet, ArrayList cinvList, int rowIndex, int IDStart, int IDEnd)
        {
            DataTable dts = GetBOM(sTKVersion, qyPlanner, qyGroup, qyReorderpolicy, cinvList, IDStart, IDEnd);
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

        public DataTable GetBOM(string sTKVersion, string qyPlanner, string qyGroup, string qyReorderpolicy, ArrayList cinvList, int IDStart, int IDEnd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT ");
            for (int i = IDStart; i <= IDEnd; i++)
            {
                if (i > IDStart)
                {
                    strSql.Append(",");
                }
                strSql.Append("max(case when parent='" + cinvList[i] + "' then T.qty end) [" + cinvList[i] + "]");
            }
            strSql.Append(@" FROM TK_BOM T with (nolock) left join TK_Trialkitting_Results R with (nolock) on T.parent=R.cInvCode 
             WHERE 1=1 and R.cInvCode is not null --and isnull(R.Qty,0)<>0 
            group by child order by child");
            if (!string.IsNullOrEmpty(sTKVersion))
            {
                strSql.Replace("1=1", "1=1 and sTKVersion='" + sTKVersion + "'");
            }
            //if (!string.IsNullOrEmpty(qyPlanner))
            //{
            //    strSql.Replace("1=1", "1=1 and Planner='" + qyPlanner + "'");
            //}
            if (!string.IsNullOrEmpty(qyGroup))
            {
                string[] splitqueryGroup = qyGroup.Split(',');
                string listqueryGroup = "";
                for (int i = 0; i < splitqueryGroup.Length; i++)
                {
                    if (splitqueryGroup[i] != "")
                    {
                        if (listqueryGroup != "")
                        {
                            listqueryGroup = listqueryGroup + ",";
                        }
                        listqueryGroup = listqueryGroup + "'" + splitqueryGroup[i] + "'";
                    }
                }
                strSql.Replace("1=1", "1=1 and ProdGroup in (" + listqueryGroup + ")");
            }
            if (!string.IsNullOrEmpty(qyReorderpolicy))
            {
                strSql.Replace("1=1", "1=1 and Reorderpolicy='" + qyReorderpolicy + "'");
            }
            DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            return dt;
        }

        public void SetCurr(string sTKVersion, string qyPlanner, string qyGroup, string qyReorderpolicy, ISheet sheet, ArrayList currList, int rowIndex, int colIndexCurr)
        {
            DataTable dts = GetCurr(sTKVersion, qyPlanner, qyGroup, qyReorderpolicy, currList, colIndexCurr);
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

        public DataTable GetCurr(string sTKVersion, string qyPlanner, string qyGroup, string qyReorderpolicy, ArrayList currList, int colIndexCurr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT ");
            for (int i = 0; i < currList.Count; i++)
            {
                if (i > 0)
                {
                    strSql.Append(",");
                }
                strSql.Append("max(case when warehouseclass='" + currList[i] + "' then dQty end) [" + currList[i] + "]");
            }
            strSql.Append(@" FROM TK_BOM T with (nolock) left join TK_Trialkitting_Results R with (nolock) on T.parent=R.cInvCode 
                left join (select sItemNo,dQty,b.warehouseclass
from TK_CurrentStock t with (nolock) 
	left join [dbo].[t_trialkit_whclass] b on t.Warehouse = b.warehouseid 
 		and (t.LocationID = b.locationid or b.locationid is null)
  ) b on T.child=b.sItemNo
             WHERE 1=1 and R.cInvCode is not null --and isnull(R.Qty,0)<>0 
            group by child order by child");
            if (!string.IsNullOrEmpty(sTKVersion))
            {
                strSql.Replace("1=1", "1=1 and sTKVersion='" + sTKVersion + "'");
            }
            //if (!string.IsNullOrEmpty(qyPlanner))
            //{
            //    strSql.Replace("1=1", "1=1 and Planner='" + qyPlanner + "'");
            //}
            if (!string.IsNullOrEmpty(qyGroup))
            {
                string[] splitqueryGroup = qyGroup.Split(',');
                string listqueryGroup = "";
                for (int i = 0; i < splitqueryGroup.Length; i++)
                {
                    if (splitqueryGroup[i] != "")
                    {
                        if (listqueryGroup != "")
                        {
                            listqueryGroup = listqueryGroup + ",";
                        }
                        listqueryGroup = listqueryGroup + "'" + splitqueryGroup[i] + "'";
                    }
                }
                strSql.Replace("1=1", "1=1 and ProdGroup in (" + listqueryGroup + ")");
            }
            if (!string.IsNullOrEmpty(qyReorderpolicy))
            {
                strSql.Replace("1=1", "1=1 and Reorderpolicy = '" + qyReorderpolicy + "'");
            }
            DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            return dt;
        }

        public void SetETA(ISheet sheet, DataTable dtp, ArrayList rowList, int rowIndex, int colIndexETA, int rowIDStart, int rowIDEnd)
        {
            DataTable dts = GetETA(dtp, rowList, rowIDStart, rowIDEnd);
            if (dts.Rows.Count > 0)
            {
                for (int p = 0; p < dts.Rows.Count; p++)
                {
                    for (int j = 0; j < dts.Columns.Count; j++)
                    {
                        if (dts.Rows[p][j].ToString() != "")
                        {
                            sheet.GetRow(rowIndex + rowIDStart + p).CreateCell(colIndexETA + j).SetCellValue(double.Parse(dts.Rows[p][j].ToString()));
                        }
                        else
                        {
                            sheet.GetRow(rowIndex + rowIDStart + p).CreateCell(colIndexETA + j).SetCellValue(double.Parse("0"));
                        }
                    }
                }
            }
        }

        public DataTable GetETA(DataTable dtp, ArrayList rowList, int rowIDStart, int rowIDEnd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("create table #a(cInvCode nvarchar(500),iOrder int)  ");
            for (int i = rowIDStart; i <= rowIDEnd; i++)
            {
                strSql.Append(@" 
                insert into #a values('" + rowList[i] + "'," + i + ")");
            }

            strSql.Append(@"
                SELECT  * ");
            strSql.Append(@" from #a a left join 
            (select iItemNO,fOpenQTY,dtmDuedate from TK_PO with (nolock)
                union all
                select sPartID,fOpenQTY,dtmDuedate from TK_WO with (nolock) ) b on a.cInvCode=b.iItemNO ");
            strSql.Append("  group by sItemNo,iOrder");
            strSql.Append(@" order by iOrder ");
            DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];

            return dt;
        }

//        public DataTable GetCurrentStock(string sTKVersion)
//        {
//            StringBuilder strSql = new StringBuilder();
//            strSql.Append(@"select sItemNo,sum(dQty) as dQty,case when w1.warehouseclass is not null then w1.warehouseclass else w2.warehouseclass end warehouseclass 
//from TK_CurrentStock t left join t_trialkit_whclass w1 on t.Warehouse=w1.warehouseid and t.LocationID=isnull(w1.locationid,'')
//left join t_trialkit_whclass w2 on t.Warehouse=w2.warehouseid  ");
//            strSql.Append(" WHERE 1=1 group by sItemNo,case when w1.warehouseclass is not null then w1.warehouseclass else w2.warehouseclass end");
//            if (!string.IsNullOrEmpty(sTKVersion))
//            {
//                strSql.Replace("1=1", "1=1 and sVersion='" + sTKVersion + "'");
//            }
//            //if (!string.IsNullOrEmpty(qyPlanner))
//            //{
//            //    strSql.Replace("1=1", "1=1 and Planner='" + qyPlanner + "'");
//            //}
//            //if (!string.IsNullOrEmpty(qyGroup))
//            //{
//            //    string[] splitqueryGroup = qyGroup.Split(',');
                //string listqueryGroup = "";
                //for (int i = 0; i < splitqueryGroup.Length; i++)
                //{
                //    if (splitqueryGroup[i] != "")
                //    {
                //        if (listqueryGroup != "")
                //        {
                //            listqueryGroup = listqueryGroup + ",";
                //        }
                //        listqueryGroup = listqueryGroup + "'" + splitqueryGroup[i] + "'";
                //    }
                //}
                //strSql.Replace("1=1", "1=1 and ProdGroup in (" + listqueryGroup + ")");
//            //}
//            DataTable result = DbHelperSQL.Query(strSql.ToString()).Tables[0];
//            return result;
//        }

        public DataTable GetCurrentStockGroup()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select DISTINCT warehouseclass from t_trialkit_whclass with (nolock)");
            DataTable result = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            return result;
        }

        ///// <summary>
        ///// 查询列表
        ///// </summary>
        ///// <param name="sWhere"></param>
        ///// <returns></returns>
        //public DataTable GetList(string sTKVersion, string qyPlanner, string qyGroup)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("SELECT sPartID, sChild, Qty_Child FROM TK_WO_Materials_Sum_History T left join TK_Trialkitting_Results R on T.sPartID=R.cInvCode");
        //    strSql.Append(" WHERE 1=1 and R.cInvCode is not null");
        //    //if (!string.IsNullOrEmpty(sTKVersion))
        //    //{
        //    //    strSql.Replace("1=1", "1=1 and sVersion='" + sTKVersion + "'");
        //    //}
        //    //if (!string.IsNullOrEmpty(qyPlanner))
        //    //{
        //    //    strSql.Replace("1=1", "1=1 and Planner='" + qyPlanner + "'");
        //    //}
        //    //if (!string.IsNullOrEmpty(qyGroup))
        //    //{
        //    //    strSql.Replace("1=1", "1=1 and ProdGroup='" + qyGroup + "'");
        //    //}
        //    DataTable result = DbHelperSQL.Query(strSql.ToString()).Tables[0];
        //    return result;
        //}
        /// <summary>
        /// 用于Web导出
        /// </summary>
        /// <param name="dtSource">源DataTable</param>
        /// <param name="dtp">源DataTable</param>
        /// <param name="strHeaderText">表头文本</param>
        /// <param name="strFileName">文件名</param>
        public void ExportByWebPAD(string sTKVersion, string qyPlanner, string qyGroup, string qyReorderpolicy, string strHeaderText, string strFileName,bool isNetQty)
        {
            //HttpContext curContext = HttpContext.Current;

            long fileSize = 0;
            MemoryStream ms = ExportPAD(sTKVersion, qyPlanner, qyGroup, qyReorderpolicy, strHeaderText, out fileSize, isNetQty);

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
    }
}
