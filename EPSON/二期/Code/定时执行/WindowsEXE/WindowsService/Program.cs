using System;
using System.Collections.Generic;

using System.ServiceProcess;
using System.Text;
using System.Windows.Forms;

namespace AutoExe
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string sPath = Application.StartupPath;
            Application.Run(new FrmEXE(sPath));
        }
    }
}
