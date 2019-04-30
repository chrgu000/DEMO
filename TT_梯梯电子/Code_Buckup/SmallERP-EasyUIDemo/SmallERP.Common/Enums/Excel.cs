using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;

namespace SmallERP.Common.Enums
{
    public enum DataTypeEnum
    {
        Int = 0,
        Float = 1,
        Double = 2,
        String = 3,
        DateTime = 4,
        Date = 5,
        Decimal=6
    }
    public class ExportFieldInfo
    {
        /// <summary>
        /// 字段名，用于反射获取值
        /// </summary>
        public string FieldName { get; set; }
        /// <summary>
        /// 中文名，用于导出标题
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// 数据类型，用于强制转换，并进行格式化,其实利用反射也可以获取到数据类型，此处因为要处理Date和Date的显示格式
        /// </summary>
        public DataTypeEnum DataType { get; set; }
    }
    public class ExcelHelper<T>
    {
        /// <summary>
        /// 导出到内存流
        /// </summary>
        /// <param name="datas">需要导出的模型列表</param>
        /// <param name="fieldInfies">导出的字段列表信息</param>
        /// <param name="sheetRows">每个工作表的行数</param>
        /// <returns></returns>
        public static MemoryStream ToExcel(List<T> datas, List<ExportFieldInfo> fieldInfies, int sheetRows = 1048576)
        {
            
            //创建Excel文件的对象
           // NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
            IWorkbook book = new XSSFWorkbook();
            //需要生成工作溥总簿
            int sheetCount = datas.Count / sheetRows + 1;
            int rowCount = datas.Count;
            for (int i = 0; i < sheetCount; i++)
            {
                //添加一个sheet
                NPOI.SS.UserModel.ISheet sheet = book.CreateSheet("Sheet" + Convert.ToString(i));
                //给sheet添加第一行的头部标题
                NPOI.SS.UserModel.IRow rowTitle = sheet.CreateRow(0);
                for (int k = 0; k < fieldInfies.Count; k++)
                {
                    rowTitle.CreateCell(k).SetCellValue(fieldInfies.ElementAt(k).DisplayName);
                }
                //处理Excel一张工作簿只能放1048576行记录的问题
                //因为头部占一行，所以要减1
                for (int j = 0; j < sheetRows - 1; j++)
                {
                    //将数据逐步写入sheet各个行
                    NPOI.SS.UserModel.IRow rowtemp = sheet.CreateRow(j + 1);
                    int dataIndex = i * (sheetRows - 1) + j;
                    for (int k = 0; k < fieldInfies.Count; k++)
                    {
                        //获取类型
                        Type type = datas[dataIndex].GetType();
                        //获取指定名称的属性
                        System.Reflection.PropertyInfo propertyInfo = type.GetProperty(fieldInfies.ElementAt(k).FieldName);
                        //获取属性值
                        var value = propertyInfo.GetValue(datas[dataIndex], null);
                        switch (fieldInfies.ElementAt(k).DataType)
                        {
                            case DataTypeEnum.Int:
                                rowtemp.CreateCell(k).SetCellValue(Convert.ToInt32(value));
                                break;
                            case DataTypeEnum.Float:
                                rowtemp.CreateCell(k).SetCellValue(Convert.ToDouble(value));
                                break;
                            case DataTypeEnum.Double:
                                rowtemp.CreateCell(k).SetCellValue(Convert.ToDouble(value));
                                break;
                            case DataTypeEnum.String:
                                rowtemp.CreateCell(k).SetCellValue(Convert.ToString(value));
                                break;
                            case DataTypeEnum.DateTime:
                                rowtemp.CreateCell(k).SetCellValue(Convert.ToDateTime(value).ToString("yyyy-MM-dd HH:mm:ss"));
                                break;
                            case DataTypeEnum.Date:
                                rowtemp.CreateCell(k).SetCellValue(Convert.ToDateTime(value).ToString("yyyy-MM-dd"));
                                break;
                            case DataTypeEnum.Decimal:
                                rowtemp.CreateCell(k).SetCellValue(Convert.ToInt32(value));
                                break;
                            default:
                                break;
                        }
                    }
                    //所有记录循环完成
                    if (i * (sheetRows - 1) + (j + 1) == rowCount)
                    {
                        // 写入到客户端 
                        var ms = new NPOIMemoryStream();
                        book.Write(ms);
                        ms.Seek(0, SeekOrigin.Begin);
                        return ms;
                    }
                }

            }
            return null;
        }
        public class NPOIMemoryStream : MemoryStream
        {
            /// <summary>
            /// 获取流是否关闭
            /// </summary>
            public bool IsColse
            {
                get;
                private set;
            }

            public NPOIMemoryStream(bool colse = false)
            {
                IsColse = colse;
            }

            public override void Close()
            {
                if (IsColse)
                {
                    base.Close();
                }

            }
        } 
    }


}

