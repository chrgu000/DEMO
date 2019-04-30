<%@ WebHandler Language="C#" Class="SavePhoto" %>

using System;
using System.Web;
using System.IO;
using System.Drawing;

public class SavePhoto : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        
        if (context.Request.Form["PHeight"] != null && context.Request.Form["PWidth"] != null && context.Request.Form["strBMP"] != null)
        {
            try
            {
                int height = int.Parse(context.Request.Form["PHeight"].ToString());
                int width = int.Parse(context.Request.Form["PWidth"].ToString());
                string strBmp = context.Request.Form["strBMP"].ToString();
                string base64= SaveBmp(BuildBitmap(width, height, strBmp), context.Server.MapPath("image"));

                //context.Response.Write("RetMsg=true");
                context.Response.Write("base64=" + base64);
            }
            catch (Exception)
            {
                context.Response.Write("RetMsg=false");
            }
        }
        
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
    public System.Drawing.Bitmap BuildBitmap(int width, int height, string strBmp)
    {
        System.Drawing.Bitmap tmpBmp = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
        string[] StmpBmp = strBmp.Split(',');
        int pos = 0;
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                tmpBmp.SetPixel(x, y, Color.FromArgb(int.Parse(StmpBmp[pos], System.Globalization.NumberStyles.HexNumber)));
                pos++;
            }
        }
        return tmpBmp;
    }
    public string SaveBmp(System.Drawing.Bitmap bp, string filePath)
    {
        //string FileName = filePath + "\\" + System.Guid.NewGuid().ToString() + ".bmp";
        //bmp.Save(FileName, System.Drawing.Imaging.ImageFormat.Bmp);

        System.IO.MemoryStream m = new System.IO.MemoryStream();
        bp.Save(m, System.Drawing.Imaging.ImageFormat.Gif);
        byte[] b = m.GetBuffer();
        string str= Convert.ToBase64String(b);
        return str;
        //string str= Convert.ToBase64String(b);
        //string[] strsplit = new string[str.Length];
        //for (int i = 0; i < str.Length; i++)
        //{
        //    strsplit[i] = str.Substring(i, 1);
        //}
        //return strsplit;
    }

}