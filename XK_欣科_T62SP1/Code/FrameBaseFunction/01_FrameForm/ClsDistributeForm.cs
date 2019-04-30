using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;

namespace FrameBaseFunction
{
    public class ClsDistributeForm
    {
        public System.Windows.Forms.Form DistributeForm(string sNameSpace, string sFormName,string sText)
        {
            Assembly asm = Assembly.Load(sNameSpace);
            string s = sNameSpace + "." + sFormName;
            object frmObj = asm.CreateInstance(s);
            System.Windows.Forms.Form frms = (System.Windows.Forms.Form)frmObj;
            frms.Text = sText;
            return frms;
        }
    }
}
