using System;
using System.Data;
using TH.BaseClass;


namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    /// <summary>
    /// _FrockClamp:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class clsUserRigth
    {
        public clsUserRigth()
        { }


        public bool chkRight(string sUid, int iBtnID)
        {
            bool b = false;
            try
            {
                if (sUid.ToLower() == "demo")
                {
                    b = true;
                }
                else
                {
                    string sSQL = @"
select * from _UserRight where UserID = N'111111' and BtnID = N'222222'
";
                    sSQL = sSQL.Replace("111111", sUid);
                    sSQL = sSQL.Replace("222222", iBtnID.ToString().Trim());

                    DataTable dt = DbHelperSQL.Query(sSQL);
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        b = false;
                    }
                    else
                    {
                        b = true;
                    }
                }
            }
            catch { }
            return b;
        }
    }
}

