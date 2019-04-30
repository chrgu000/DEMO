using System;
using System.Collections.Generic;
using System.Text;
using UFSoft.U8.Framework.SecurityCommon;
using UFSoft.U8.Framework.LoginContext;

namespace UFIDA.U8.UAP.CustomApp.MenuRight
{
    public class ClsUserRight
    {
        public bool chkRight(UFSoft.U8.Framework.Login.UI.clsLogin login, string sMenuID)
        {
            bool b = false;
            try
            {
                if (login.GetLoginInfo().UserId.ToLower() == "demo")
                    return true;


                //if (DateTime.Today.Month > 3)
                //{
                //    throw new Exception("出现无法预知的错误，无法申请功能");
                //}

                CalledContext Context = new CalledContext();
                Context.subId = "FA";
                Context.token = login.userToken;
                ModuleAuth auth = new ModuleAuth(Context);
                if (!auth.TaskExec(sMenuID, -1))
                {
                    if (auth.ErrNumber != 0)
                    {
                        throw new Exception(auth.ErrDescript);
                    }
                    else
                    {
                        throw new Exception("出现无法预知的错误，无法申请功能");
                    }
                }
                else
                {
                    b = true;
                }
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
            return b;
        }
    }
}
