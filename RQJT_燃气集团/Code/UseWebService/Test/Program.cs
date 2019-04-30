using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using Test;

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
            Application.Run(new Test.Form1());
        }

    }
}