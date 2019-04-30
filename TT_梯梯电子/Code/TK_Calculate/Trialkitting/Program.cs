using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TrialkittingLoadData
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DllForTK.clsDoExec cls = new DllForTK.clsDoExec();
            cls.doLoadBase();
        }
    }
}
