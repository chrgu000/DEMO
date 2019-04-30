using System;
using System.Collections.Generic;
using System.Text;
using UFIDA.U8.Portal.Proxy.editors;
using UFIDA.U8.Portal.Proxy.Actions;
using UFIDA.U8.Portal.Framework.Actions;
using UFIDA.U8.Portal.Common.Core;
using System.Windows.Forms;
using UFIDA.U8.UAP.CustomApp.ControlForm;
using TH.BaseClass;
using System.Data;



namespace UFIDA.U8.UAP.CustomApp.Entrance
{
    public class PrintBarCode_SELCreater : INetUserControl
    {
        #region INetUserControl Members
        UFIDA.U8.Portal.Framework.MainFrames.IEditorInput _IEditorInput;
        UFIDA.U8.Portal.Framework.MainFrames.IEditorPart _IEditorPart;
        string _Title;

        bool INetUserControl.CloseEvent()
        {
            return true;
        }

        //需要调用窗体名称
        System.Windows.Forms.Control INetUserControl.CreateControl(UFSoft.U8.Framework.Login.UI.clsLogin login, string MenuID, string Paramters)
        {

            UFSoft.U8.Framework.LoginContext.UserData LoginInfo = new UFSoft.U8.Framework.LoginContext.UserData();
            LoginInfo = login.GetLoginInfo();
            string conn = LoginInfo.ConnString;
            conn = Utils.ConvertConn(conn);
            DbHelperSQL.connectionString = conn;
            
            string sLogUserid = LoginInfo.UserId;
            string sLogUserName = LoginInfo.UserName;
            string sLogDate = LoginInfo.operDate;
            string sAccID = LoginInfo.AccID;

            bool bRight = false;
            if (sLogUserid.ToLower() == "demo")
                bRight = true;
            else
            {
                string sSQL = "select * from _UserRight where UserID = '" + sLogUserid + "' and FormID = '1090'";
                System.Data.DataTable dt = DbHelperSQL.Query(sSQL);
                if (dt != null && dt.Rows.Count > 0 && dt.Rows[0][0].ToString().Trim() != "")
                    bRight = true;
            }

            if (!bRight)
            {
                throw new Exception("没有权限");
                //return null;
            }
            else
            {
                PrintBarCode_SEL fm = new PrintBarCode_SEL();
                fm.Conn = conn;
                fm.sUserID = sLogUserid;
                fm.sUserName = sLogUserName;
                fm.sLogDate = sLogDate;



                this._Title = "条形码出入库查看";

                return fm;
            }
        }


        UFIDA.U8.Portal.Proxy.Actions.NetAction[] INetUserControl.CreateToolbar(UFSoft.U8.Framework.Login.UI.clsLogin login)
        {

            //UFIDA.U8.Portal.Proxy.Actions.NetAction[] actions = new NetAction[1];
            ////定义toolbar的处理事件

            //UserActionDelegate actionDelegate = new UserActionDelegate();

            //actions[0] = new NetAction("退出", new UserActionDelegate());
            //actions[0].ActionType = NetAction.NetActionType.Normal ;
            //actions[0].Text = "退出";

            return null;


        }

        UFIDA.U8.Portal.Framework.MainFrames.IEditorInput INetUserControl.EditorInput
        {
            get
            {
                return _IEditorInput;
            }
            set
            {
                _IEditorInput = value;
            }
        }

        UFIDA.U8.Portal.Framework.MainFrames.IEditorPart INetUserControl.EditorPart
        {
            get
            {
                return _IEditorPart;
            }
            set
            {
                _IEditorPart = value;
            }
        }

        string INetUserControl.Title
        {
            get
            {
                return _Title;
            }
            set
            {
                _Title = value;
            }
        }

        /// <summary>
        /// 处理toolbar button事件
        /// </summary>
        internal class UserActionDelegate : IActionDelegate
        {
            public UserActionDelegate()
            {

            }
            public void Run(IAction action)
            {

            }
            public void SelectionChanged(IAction action, ISelection selection)
            {
            }
        }

        #endregion
    }
}
