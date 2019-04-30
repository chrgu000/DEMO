using System;
using System.Data;
using System.Web;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Xml;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Drawing;


namespace TH.WebService.DAL
{
    public class BarCodePrint
    {
        DataTable dtBarCode;
        public BarCodePrint(DataTable dt )
        {
            dtBarCode = dt.Copy();
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TextPrint_PrintPage(object sender, PrintPageEventArgs e)
        {
            //e.Graphics.DrawLine(Pens.Black, new Point(20, 20), new Point(180, 180));
            //e.Graphics.DrawLine(Pens.Black, new Point(0, 0), new Point(200, 0));
            //e.Graphics.DrawLine(Pens.Black, new Point(200, 0), new Point(200, 200));
            //e.Graphics.DrawLine(Pens.Black, new Point(0, 200), new Point(300, 200));
            int left1 = 5;//第一列左边距离
            int left2 = 75;//第二列左边距离
            int top = 0;//顶端距离
            int topstep = 15;//每行高度
            System.Drawing.Font Black8 = new System.Drawing.Font("黑体", 8, System.Drawing.FontStyle.Regular);

            e.Graphics.DrawString("存货编码", Black8, System.Drawing.Brushes.Black, left1, top);
            e.Graphics.DrawString(dtBarCode.Rows[0]["存货编码"].ToString().Trim(), Black8, System.Drawing.Brushes.Black, left2, top);
            top = top + topstep;
            e.Graphics.DrawString("存货名称", Black8, System.Drawing.Brushes.Black, left1, top);
            e.Graphics.DrawString(dtBarCode.Rows[0]["存货名称"].ToString().Trim(), Black8, System.Drawing.Brushes.Black, left2, top);
            top = top + topstep;
            e.Graphics.DrawString("规格型号", Black8, System.Drawing.Brushes.Black, left1, top);
            e.Graphics.DrawString(dtBarCode.Rows[0]["规格型号"].ToString().Trim(), Black8, System.Drawing.Brushes.Black, left2, top);
            //top = top + topstep;
            //e.Graphics.DrawString("数量", Black8, System.Drawing.Brushes.Black, left1, top);
            //e.Graphics.DrawString(dtBarCode.Rows[0]["数量"].ToString().Trim(), Black8, System.Drawing.Brushes.Black, left2, top);
            top = top + topstep;
            e.Graphics.DrawString("可用量", Black8, System.Drawing.Brushes.Black, left1, top);
            e.Graphics.DrawString(dtBarCode.Rows[0]["可用量"].ToString().Trim(), Black8, System.Drawing.Brushes.Black, left2, top);
            top = top + topstep;
            e.Graphics.DrawString("供应商", Black8, System.Drawing.Brushes.Black, left1, top);
            e.Graphics.DrawString(dtBarCode.Rows[0]["供应商"].ToString().Trim(), Black8, System.Drawing.Brushes.Black, left2, top);
            top = top + topstep;
            e.Graphics.DrawString("货位", Black8, System.Drawing.Brushes.Black, left1, top);
            e.Graphics.DrawString(dtBarCode.Rows[0]["货位"].ToString().Trim(), Black8, System.Drawing.Brushes.Black, left2, top);
            top = top + topstep;
            e.Graphics.DrawString("批号", Black8, System.Drawing.Brushes.Black, left1, top);
            e.Graphics.DrawString(dtBarCode.Rows[0]["批号"].ToString().Trim(), Black8, System.Drawing.Brushes.Black, left2, top);
            top = top + topstep;
            e.Graphics.DrawString("序列号", Black8, System.Drawing.Brushes.Black, left1, top);
            e.Graphics.DrawString(dtBarCode.Rows[0]["序列号"].ToString().Trim(), Black8, System.Drawing.Brushes.Black, left2, top);
            top = top + topstep;
            e.Graphics.DrawString("重要度", Black8, System.Drawing.Brushes.Black, left1, top);
            e.Graphics.DrawString(dtBarCode.Rows[0]["重要度"].ToString().Trim(), Black8, System.Drawing.Brushes.Black, left2, top);
            top = top + topstep;
            e.Graphics.DrawString("REV", Black8, System.Drawing.Brushes.Black, left1, top);
            e.Graphics.DrawString(dtBarCode.Rows[0]["REV"].ToString().Trim(), Black8, System.Drawing.Brushes.Black, left2, top);
            top = top + topstep;

            BarCode.BarCode128 _Code = new BarCode.BarCode128();
            _Code.ValueFont = new Font("宋体", 10);
            e.Graphics.DrawImage(_Code.GetCodeImage(dtBarCode.Rows[0]["条形码"].ToString().Trim(), BarCode.BarCode128.Encode.Code128A), left1, top);


            e.Graphics.RotateTransform(-180);
            e.HasMorePages = false;
        }

    }
}
