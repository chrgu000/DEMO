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
    public class NPOIHelper2
    {
        #region 导出到excelPAD

        private string sTKVersion = "";
        private string qyGroup = "";
        private string qyPlanner = "";
        private string strHeaderText = "";

        private DataTable dtp;
        private DataTable dtg;
        private DataTable dtcg;
        private DataTable dtbomg;

        private int colIndex = 0;
        //生成库存表头
        private int colIndexCurr = 0;
        //生成工单占用量Allocated
        private int colIndexAllocated = 0;
        //ETA Status表头
        private int colIndexETA = 0;
        //OpenPO及后续列表头
        private int colIndexOpenPO = 0;

        private int colIndexVendor = 0;

        private ArrayList cinvList;
        private ArrayList currList;
        private ArrayList rowList;
        private ArrayList rowOpenPOList;

        private string Fullfilename = "";
        private int aaa = 0;

        int group = 0;
        int rowIndex = 0;
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
        private string ExportPAD()
        {
            group = 3;
            rowIndex = 10;
            rowList = new ArrayList();
            rowOpenPOList = new ArrayList();
            NewModel();

            dtp = GetPeriod();
            dtg = GetResultsGroup();
            dtcg = GetCurrentStockGroup();
            dtbomg = GetBOMGroup();

            cinvList = new ArrayList();
            currList = new ArrayList();

            NewTitle();
            NewResult();
            NewBOM();
            NewResultBOM();
            return Fullfilename;
        }

        #region Title
        private void NewTitle()
        {
            XSSFWorkbook workbook = null;
            ISheet sheet = null;
            FileStream fs = null;
            XSSFFormulaEvaluator formulaEvaluator = null;

            using (fs = File.OpenRead(Fullfilename))
            {
                workbook = new XSSFWorkbook(fs); // 2007版本.xlsx
                if (workbook == null)
                {
                    throw new Exception("未找到相关的模板");
                }
                else
                {
                    sheet = workbook.GetSheetAt(0); //读取第一个sheet 最多16384列
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

            colIndex = 3;
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
            colIndexCurr = colIndex;
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
            colIndexAllocated = colIndex;
            XSSFCell newCellAllocated = (XSSFCell)dataRowHead2.CreateCell(colIndex);
            newCellAllocated.SetCellValue("Allocated");
            newCellAllocated.CellStyle = cellHead2;
            sheet.SetColumnWidth(colIndex, 15 * 256);//设置宽
            colIndex = colIndex + 1;

            colIndexETA = colIndex;
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
            colIndexOpenPO = colIndex;
            XSSFCell newCellOpenPO = (XSSFCell)dataRowHead2.CreateCell(colIndex);
            newCellOpenPO.SetCellValue("OpenPO");
            newCellOpenPO.CellStyle = cellHead2;
            colIndex = colIndex + 1;

            colIndexVendor = colIndex;
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

            FileStream fileHSSF = new FileStream(Fullfilename, FileMode.Create);
            workbook.Write(fileHSSF);
            fileHSSF.Close();
            fileHSSF.Dispose();
        }
        #endregion

        #region Result
        private void NewResult()
        {
            XSSFWorkbook workbook = null;
            ISheet sheet = null;
            FileStream fs = null;
            XSSFFormulaEvaluator formulaEvaluator = null;

            using (fs = File.OpenRead(Fullfilename))
            {
                workbook = new XSSFWorkbook(fs); // 2007版本.xlsx
                if (workbook == null)
                {
                    throw new Exception("未找到相关的模板");
                }
                else
                {
                    sheet = workbook.GetSheetAt(0); //读取第一个sheet 最多16384列
                    formulaEvaluator = new XSSFFormulaEvaluator(workbook);
                }
            }

            //添加7个月的数量，循环查询
            //循环物料
            for (int i = 0; i < dtp.Rows.Count; i++)
            {
                XSSFRow dataRow = (XSSFRow)sheet.CreateRow(i + 1);

                string dtmStart = DateTime.Parse(dtp.Rows[i]["dtmStart"].ToString()).ToString("yyyy-MM-dd");
                string dtmEnd = DateTime.Parse(dtp.Rows[i]["dtmEnd"].ToString()).ToString("yyyy-MM-dd");
                string EgMonth = dtp.Rows[i]["EgMonth"].ToString();

                dataRow.CreateCell(2).SetCellValue(EgMonth);

                for (int s = 1; s < cinvList.Count; s++)
                {
                    if ((s + 1) % group == 0)
                    {
                        int IDStart = s + 1 - group;
                        int IDEnd = s;
                        SetResults(dataRow, dtmStart, dtmEnd, IDStart, IDEnd);
                    }
                    else if (s == cinvList.Count - 1)
                    {
                        int IDStart = cinvList.Count - (s + 1) % group;
                        int IDEnd = s;
                        SetResults(dataRow, dtmStart, dtmEnd, IDStart, IDEnd);
                    }
                }
            }

            FileStream fileHSSF = new FileStream(Fullfilename, FileMode.Create);
            workbook.Write(fileHSSF);
            fileHSSF.Close();
            fileHSSF.Dispose();
        }

        //<summary>
        //获得数据列表-导出PAD
        //</summary>
        //<returns></returns>
        public void SetResults(XSSFRow dataRow, string dtmStart, string dtmEnd, int IDStart, int IDEnd)
        {
            DataTable dts = GetResults(dtmStart, dtmEnd, IDStart, IDEnd);
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
        public DataTable GetResults(string dtmStart, string dtmEnd, int IDStart, int IDEnd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  ");
            for (int i = IDStart; i <= IDEnd; i++)
            {
                if (i > IDStart)
                {
                    strSql.Append(",");
                }
                strSql.Append("sum(case when cInvCode='" + cinvList[i] + "' then Qty end) [" + cinvList[i] + "]");
            }
            strSql.Append(" FROM TK_Trialkitting_Results WHERE 1=1 and convert(nvarchar(10),dtmQty,120)>=convert(nvarchar(10),'" + dtmStart + "',120) and convert(nvarchar(10),dtmQty,120)<=convert(nvarchar(10),'" + dtmEnd + "',120)");
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
                strSql.Replace("1=1", "1=1 and ProdGroup='" + qyGroup + "'");
            }
            DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];

            return dt;
        }
        #endregion

        #region BOM
        private void NewBOM()
        {
            XSSFWorkbook workbook = null;
            ISheet sheet = null;
            FileStream fs = null;
            XSSFFormulaEvaluator formulaEvaluator = null;

            using (fs = File.OpenRead(Fullfilename))
            {
                workbook = new XSSFWorkbook(fs); // 2007版本.xlsx
                if (workbook == null)
                {
                    throw new Exception("未找到相关的模板");
                }
                else
                {
                    sheet = workbook.GetSheetAt(0); //读取第一个sheet 最多16384列
                    formulaEvaluator = new XSSFFormulaEvaluator(workbook);
                }
            }

            //添加子件BOM
            //循环物料，添加子件
            for (int i = 0; i < dtbomg.Rows.Count; i++)
            {
                string sChild = dtbomg.Rows[i]["child"].ToString();
                string fOpenQTY = dtbomg.Rows[i]["fOpenQTY"].ToString();
                XSSFRow dataRow = (XSSFRow)sheet.CreateRow(rowIndex + i);

                dataRow.CreateCell(0).SetCellValue(sChild);
                dataRow.CreateCell(1).SetCellValue(dtbomg.Rows[i]["partdesc"].ToString());
                dataRow.CreateCell(2).SetCellValue(dtbomg.Rows[i]["childsm"].ToString());
                dataRow.CreateCell(colIndexAllocated).SetCellValue(dtbomg.Rows[i]["alloqty"].ToString());

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

            FileStream fileHSSF = new FileStream(Fullfilename, FileMode.Create);
            workbook.Write(fileHSSF);
            fileHSSF.Close();
            fileHSSF.Dispose();
        }
        #endregion

        #region ResultBOM
        private void NewResultBOM()
        {
            

            //循环子件添加BOM
            for (int s = 1; s < cinvList.Count; s++)
            {
                if ((s + 1) % group == 0)
                {
                    int IDStart = s + 1 - group;
                    int IDEnd = s;

                    SetBOM(rowIndex, IDStart, IDEnd);

                    
                }
                else if (s == cinvList.Count - 1)
                {
                    int IDStart = cinvList.Count - (s + 1) % group;
                    int IDEnd = s;

                    SetBOM(rowIndex, IDStart, IDEnd);
                }
            }

            
        }

        public void SetBOM(int rowIndex, int IDStart, int IDEnd)
        {
            XSSFWorkbook workbook = null;
            ISheet sheet = null;
            FileStream fs = null;
            XSSFFormulaEvaluator formulaEvaluator = null;

            using (fs = File.OpenRead(Fullfilename))
            {
                workbook = new XSSFWorkbook(fs); // 2007版本.xlsx
                if (workbook == null)
                {
                    throw new Exception("未找到相关的模板");
                }
                else
                {
                    sheet = workbook.GetSheetAt(0); //读取第一个sheet 最多16384列
                    formulaEvaluator = new XSSFFormulaEvaluator(workbook);
                }
            }

            DataTable dts = GetBOM(IDStart, IDEnd);
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
            //Fullfilename = Fullfilename.Replace(".xlsx", "") + aaa + ".xlsx";
            //aaa++;
            FileStream fileHSSF = new FileStream(Fullfilename, FileMode.Create);
            workbook.Write(fileHSSF);
            fileHSSF.Close();
            fileHSSF.Dispose();
        }

        public DataTable GetBOM(int IDStart, int IDEnd)
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
            strSql.Append(@" FROM TK_BOM T left join TK_Trialkitting_Results R on T.parent=R.cInvCode 
             WHERE 1=1 and R.cInvCode is not null group by child order by child");
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
                strSql.Replace("1=1", "1=1 and ProdGroup='" + qyGroup + "'");
            }
            DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            return dt;
        }
        #endregion

        private void NewModel()
        {
            XSSFWorkbook workbook = null;
            ISheet sheet = null;
            FileStream fs = null;
            string fileName = AppDomain.CurrentDomain.BaseDirectory + @"Upload\model\PAD导出模板.xlsx";
            using (fs = File.OpenRead(fileName))
            {
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
            string path = AppDomain.CurrentDomain.BaseDirectory + @"Upload\temp\";
            var keyValue = Guid.NewGuid().ToString();
            string filename = "PAD-" + DateTime.Now.ToString("yyyyMMdd") + "-" + keyValue + ".xlsx";
            Fullfilename = Path.Combine(path, filename);//获得保存路径

            FileStream fileHSSF = new FileStream(Fullfilename, FileMode.Create);
            workbook.Write(fileHSSF);
            fileHSSF.Close();
            fileHSSF.Dispose();
        }

        private string ConvertColumnIndexToColumnName(int index)
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

        private DataTable GetPeriod()
        {
            int iYear = int.Parse(sTKVersion.Split('-')[1].Substring(0, 4));
            int iMonth = int.Parse(sTKVersion.Split('-')[1].Substring(4, 2));
            int iDay = int.Parse(sTKVersion.Split('-')[1].Substring(6, 2));

            string dDate = iYear + "-";
            if (iMonth.ToString().Length == 1)
            {
                dDate = dDate + "0";
            }
            dDate = dDate + iMonth + "-" + iDay;

            StringBuilder strSql1 = new StringBuilder();
            strSql1.AppendFormat(" Select * From TK_Base_CalendarPeriod where convert(nvarchar(10),dtmStart,120)<='" + dDate + "' and convert(nvarchar(10),dtmEnd,120)>='" + dDate + "' ");
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
Select top 7 iYear, iMonth,dtmStart,dtmEnd,convert(datetime,convert(nvarchar,iYear)+'-'+convert(nvarchar(2),right('0'+convert(nvarchar,iMonth),2))+'-01') as iDay From TK_Base_CalendarPeriod 
where convert(nvarchar,iYear)+right('0'+convert(nvarchar,iMonth),2)>={0} order by iYear, iMonth
) a  order by iYear, iMonth", d.ToString("yyyyMM"));
            DataTable result = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            return result;
        }

        //<summary>
        //获得数据列表-导出PAD Group
        //</summary>
        //<returns></returns>
        private DataTable GetResultsGroup()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT DISTINCT cInvCode FROM TK_Trialkitting_Results WHERE 1=1 GROUP BY cInvCode ");
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
                strSql.Replace("1=1", "1=1 and ProdGroup='" + qyGroup + "'");
            }
            DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];

            return dt;
        }

        private DataTable GetCurrentStockGroup()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select DISTINCT warehouseclass from t_trialkit_whclass");
            DataTable result = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            return result;
        }

        private DataTable GetBOMGroup()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT DISTINCT child,childsm,isnull(PO.fOpenQTY,0) as fOpenQTY,partdesc, alloqty, vc, prodgroup, lt, moq, mpq, curmat, toplevellist
                 FROM TK_BOM T left join TK_Trialkitting_Results R on T.parent=R.cInvCode 
                left join (select iItemNO,sum(fOpenQTY) as fOpenQTY from TK_PO group by iItemNO 
                    union all
                    select sPartID,sum(fOpenQTY) as fOpenQTY from TK_WO group by sPartID
                ) PO on T.child=PO.iItemNO 
                left join Inventory_extend ie on T.child=ie.partnum
             WHERE 1=1 and R.cInvCode is not null order by child");
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
                strSql.Replace("1=1", "1=1 and ProdGroup='" + qyGroup + "'");
            }
            DataTable result = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            return result;
        }

        /// <summary>
        /// 用于Web导出
        /// </summary>
        /// <param name="dtSource">源DataTable</param>
        /// <param name="dtp">源DataTable</param>
        /// <param name="strHeaderText">表头文本</param>
        /// <param name="strFileName">文件名</param>
        public void ExportByWebPAD(string ssTKVersion, string sqyPlanner, string sqyGroup, string sstrHeaderText, string strFileName)
        {
            sTKVersion = ssTKVersion;
            qyPlanner = sqyPlanner;
            qyGroup = sqyGroup;
            strHeaderText = sstrHeaderText;
            string fileName = ExportPAD();

            FileInfo fileInfo = new FileInfo(fileName);
            HttpContext context = HttpContext.Current;
            context.Response.Clear();
            context.Response.ClearContent();
            context.Response.ClearHeaders();
            context.Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
            context.Response.AddHeader("Content-Length", fileInfo.Length.ToString());
            context.Response.AddHeader("Content-Transfer-Encoding", "binary");
            context.Response.ContentType = "application/octet-stream";
            context.Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
            context.Response.WriteFile(fileInfo.FullName);
            context.Response.Flush();
            context.Response.End();
        }
        #endregion
    }
}
