using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using AutoUpdate;
using System.Collections;
using System.IO;
using 系统服务;

namespace AppStart
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new 系统服务.MdiMain());
        }

    }
}