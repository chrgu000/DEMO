using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrialKittingGating
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            BuyerGatingData cls = new TrialKittingGating.BuyerGatingData();
            cls.BuyGatingCalculate();
        }
    }
}
