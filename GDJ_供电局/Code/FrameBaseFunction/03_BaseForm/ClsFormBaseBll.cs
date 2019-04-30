using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace FrameBaseFunction
{
    public abstract class ClsDistributeBll
    {
        public object DistributeBll(string sNameSpace, string sFormName)
        {
            Assembly asm = Assembly.Load(sNameSpace);
            string s = sNameSpace + ".cls" + sFormName.Substring(3) + "Bll";
            object frmObj = asm.CreateInstance(s);
            return frmObj;
        }
    }

    public abstract class ClsFormBaseBll
    {
        protected abstract void ExecFormBll();
    }
}
