using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace TrialKittingByPerson
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                DllForTK.clsDoExec cls = new DllForTK.clsDoExec();
                cls.TrialkittingCalculateByPerson();
            }
            catch (Exception ee)
            { }
        }
    }
}
