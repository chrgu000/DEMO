using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.DirectoryServices;
using System.Runtime.InteropServices;

public class AD
{

    //调用Win32API Import advapi32.dll
    [DllImport("advapi32.dll")]
    private static extern bool LogonUser(string lpszUsername, string lpszDomain, string lpszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);

    private bool ValidateUserAccount(string username, string domainName, string Password)
    {
        const int LOGON32_LOGON_INTERACTIVE = 2; //通过网络验证账户合法性
        const int LOGON32_PROVIDER_DEFAULT = 0; //使用默认的Windows 2000/NT NTLM验证方
        IntPtr tokenHandle = new IntPtr(0);
        tokenHandle = IntPtr.Zero;
        bool checkok = LogonUser(username, domainName, Password, LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT, ref tokenHandle);
        return checkok;
    }

    public bool TryAuthenticate(string domain, string userName, string password)
    {
        bool isLogin = false;
        try
        {
            DirectoryEntry entry = new DirectoryEntry(string.Format("LDAP://{0}", domain), userName, password);
            entry.RefreshCache();
            isLogin = true;
        }
        catch
        {
            isLogin = false;
        }
        return isLogin;
    }
    ///   <summary> 
    ///   读取AD用户信息 
    ///   </summary> 
    ///   <param   name= "ADUsername "> 用户 </param> 
    ///   <param   name= "ADPassword "> 密码 </param> 
    ///   <param   name= "domain "> 域名 </param> 
    ///   <returns> </returns> 
    public DataTable AdUserInfo(string ADUsername, string ADPassword, string domain)//System.Collections.SortedList
    {
        ClsDataBase clsSQLCommond = new ClsDataBase();
        DataTable dt = new DataTable();
        dt.Columns.Add("Name");
        System.DirectoryServices.DirectorySearcher src;
        string ADPath = "LDAP:// " + domain;
        System.Collections.SortedList sl = new System.Collections.SortedList();
        System.DirectoryServices.DirectoryEntry de = new System.DirectoryServices.DirectoryEntry(ADPath, ADUsername, ADPassword);

        src = new System.DirectoryServices.DirectorySearcher(de);
        src.PageSize = 10000;//   此参数可以任意设置，但不能不设置，如不设置读取AD数据为0~999条数据，设置后可以读取大于1000条数据。 
        src.SearchScope = System.DirectoryServices.SearchScope.Subtree;
        src.Filter = "(&(&(objectCategory=person)))";

        DataTable dtadlist = clsSQLCommond.ExecQuery("select * from   _LookUpDate where iType=6");

        foreach (System.DirectoryServices.SearchResult res in src.FindAll())
        {
            DirectoryEntry users = res.GetDirectoryEntry(); 
            string str = "";
            string str3 = "";
            string str4 = "";
            str = res.GetDirectoryEntry().Properties["distinguishedName"].Value.ToString().Trim();
            string[] str2 = System.Text.RegularExpressions.Regex.Split(str, ",OU=", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            if (str2.Length > 1)
            {
                str3 = str2[1];
            }
            if (str3 != "")
            {
                str4 = str3.Split(',')[0].Trim();
            }
            if (res.GetDirectoryEntry().Properties["CN"].Value.ToString().Trim() == "yx")
            {
                string s = "s";
            }
            DataRow[] dwadlist = dtadlist.Select("iText='" + str4 + "'");
            if (dwadlist.Length > 0)
            {
                DataRow dw = dt.NewRow();
                dw["Name"] = res.GetDirectoryEntry().Properties["Name"].Value.ToString().Trim();
                dt.Rows.Add(dw);
            }
        }
        return dt;
    }

}
