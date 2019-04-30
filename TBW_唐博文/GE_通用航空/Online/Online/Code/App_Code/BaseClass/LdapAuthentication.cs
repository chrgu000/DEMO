using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.DirectoryServices;
using System.Text;

/// <summary>
/// LdapAuthentication ��ժҪ˵��
/// </summary>
public class LdapAuthentication
{
    public LdapAuthentication()
    {
    }
    private string _path;
    private string _filterAttribute;

    public LdapAuthentication(string path)
    {
        _path = path;
    }

    /// <summary>
    /// �ж��Ƿ����û�
    /// </summary>
    /// <param name="domain">����</param>
    /// <param name="username">�û���</param>
    /// <param name="pwd">����</param>
    /// <returns></returns>
    public bool IsAuthenticated(string domain, string username, string pwd)
    {

        string domainAndUsername = username;// domain + @"\" + username;
        DirectoryEntry entry = new DirectoryEntry(domain, domainAndUsername, pwd, AuthenticationTypes.None);

        try
        {
            //Bind to the native AdsObject to force authentication.
            object obj = entry.NativeObject;

            DirectorySearcher search = new DirectorySearcher(entry);

            search.Filter = "(SAMAccountName=" + username + ")";
            search.PropertiesToLoad.Add("cn");
            SearchResult result = search.FindOne();
            if (null == result)
            {
                return false;
            }
            //Update the new path to the user in the directory.
            _path = result.Path;
            _filterAttribute = (string)result.Properties["cn"][0];
        }
        catch (Exception ex)
        {
            throw new Exception("Error authenticating user. " + ex.Message);
        }
        return true;
    }

    /// <summary>
    /// �����û�����ȡ��������
    /// </summary>
    /// <returns></returns>
    public string GetGroupByUser()
    {
        DirectorySearcher search = new DirectorySearcher(_path);
        search.Filter = "(cn=" + _filterAttribute + ")";
        search.PropertiesToLoad.Add("memberOf");
        StringBuilder groupNames = new StringBuilder();

        try
        {
            SearchResult result = search.FindOne();
            int propertyCount = result.Properties["memberOf"].Count;
            string dn;
            int equalsIndex, commaIndex;

            for (int propertyCounter = 0; propertyCounter < propertyCount; propertyCounter++)
            {
                dn = (string)result.Properties["memberOf"][propertyCounter];
                equalsIndex = dn.IndexOf("=", 1);
                commaIndex = dn.IndexOf(",", 1);
                if (-1 == equalsIndex)
                {
                    return null;
                }
                groupNames.Append(dn.Substring((equalsIndex + 1), (commaIndex - equalsIndex) - 1));
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Error obtaining group names. " + ex.Message);
        }
        return groupNames.ToString();
    }

    /// <summary>
    /// ��ȡ���û�
    /// </summary>
    /// <param name="Groupname">����</param>
    /// <returns></returns>
    public string[] GetUsersForGroup(string Groupname)
    {
        DirectorySearcher ds = new DirectorySearcher(_path);
        ds.Filter = "(&(objectClass=group)(cn=" + Groupname + "))";
        ds.PropertiesToLoad.Add("member");
        SearchResult r = ds.FindOne();

        if (r.Properties["member"] == null)
        {
            return (null);
        }

        string[] results = new string[r.Properties["member"].Count];
        for (int i = 0; i < r.Properties["member"].Count; i++)
        {
            string theGroupPath = r.Properties["member"][i].ToString();
            results[i] = theGroupPath.Substring(3, theGroupPath.IndexOf(",") - 3);
        }
        return (results);
    }

    /// <summary>
    /// ��ȡ�û�������
    /// </summary>
    /// <param name="username">�û���</param>
    /// <returns></returns>
    public string[] GetGroupsForUser(string username)
    {
        DirectorySearcher ds = new DirectorySearcher(_path);
        ds.Filter = "(&(sAMAccountName=" + username + "))";
        ds.PropertiesToLoad.Add("memberof");
        SearchResult r = ds.FindOne();

        if (r.Properties["memberof"].Count == 0)
        {
            return (null);
        }

        string[] results = new string[r.Properties["memberof"].Count];
        for (int i = 0; i < r.Properties["memberof"].Count; i++)
        {
            string theGroupPath = r.Properties["memberof"][i].ToString();
            results[i] = theGroupPath.Substring(3, theGroupPath.IndexOf(",") - 3);
        }
        return (results);
    }

    public string[] GetAllGroupsForUser(string username)
    {
        DirectorySearcher ds = new DirectorySearcher(_path);
        ds.Filter = "(&(sAMAccountName=" + username + "))";
        ds.PropertiesToLoad.Add("memberof");
        SearchResult r = ds.FindOne();
        if (r.Properties["memberof"] == null)
        {
            return (null);
        }
        string[] results = new string[r.Properties["memberof"].Count + 1];
        for (int i = 0; i < r.Properties["memberof"].Count; i++)
        {
            string theGroupPath = r.Properties["memberof"][i].ToString();
            results[i] = theGroupPath.Substring(3, theGroupPath.IndexOf(",") - 3);
        }
        results[r.Properties["memberof"].Count] = "All";//All�������κ���,��AD֮�ⶨ����һ���飬�Ա�����û�Ȩ��
        return (results);
    }

    /// <summary>
    /// ��ȡ���û�
    /// </summary>
    /// <param name="username">�û���</param>
    /// <returns></returns>

    public string GetUserDisplayName(string username)
    {
        string results;
        DirectorySearcher ds = new DirectorySearcher(_path);
        ds.Filter = "(&(objectClass=user)(sAMAccountName=" + username + "))";
        ds.PropertiesToLoad.Add("DisplayName");
        SearchResult r = ds.FindOne();
        results = r.GetDirectoryEntry().InvokeGet("DisplayName").ToString();
        return (results);

    }



    public string GetAdGroupDescription(string prefix)//����CN��ȡ��description
    {
        string results;
        DirectorySearcher groupsDS = new DirectorySearcher(_path);
        groupsDS.Filter = "(&(objectClass=group)(CN=" + prefix + "*))";
        groupsDS.PropertiesToLoad.Add("cn");
        SearchResult sr = groupsDS.FindOne();
        results = sr.GetDirectoryEntry().InvokeGet("description").ToString();
        return (results);
    }

    public DataTable GetAdGroupInfo()//����CN��ȡ����Ϣ
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("URL", typeof(System.String));
        dt.Columns.Add("cn", typeof(System.String));
        dt.Columns.Add("Description", typeof(System.String));

        DirectorySearcher searcher = new DirectorySearcher(_path);

        searcher.Filter = "(&(objectClass=group))";
        //searcher.SearchScope = SearchScope.Subtree;
        //searcher.Sort = new SortOption("description", System.DirectoryServices.SortDirection.Ascending);
        searcher.PropertiesToLoad.AddRange(new string[] { "cn", "description" });
        SearchResultCollection results = searcher.FindAll();
        if (results.Count == 0)
        {
            return (null);
        }
        else
        {
            foreach (SearchResult result in results)
            {
                DataRow dr = dt.NewRow();
                dr[0] = result.Path.ToString();
                dr[1] = result.GetDirectoryEntry().InvokeGet("cn").ToString();
                if (result.GetDirectoryEntry().InvokeGet("Description") != null)
                    dr[2] = result.GetDirectoryEntry().InvokeGet("Description").ToString();
                else
                    dr[2] = result.GetDirectoryEntry().InvokeGet("cn").ToString();
                dt.Rows.Add(dr);
            }
            dt.DefaultView.Sort = "description ASC";
            return dt;
        }

    }

    public string getAccountName(string cn) //����CN��ȡ��½��
    {
        foreach (string path in _path.Split(','))
        {
            DirectorySearcher ds = new DirectorySearcher(path);
            ds.Filter = "(&(objectClass=user)(cn=*" + cn + "*))";
            ds.PropertiesToLoad.Add("sAMAccountName");
            SearchResult r = ds.FindOne();
            if (r != null)
                return r.GetDirectoryEntry().InvokeGet("sAMAccountName").ToString();
        }
        return null;
    }

    public DataTable adUserlist(string groupname)   //�����û����ݱ�
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("cn", typeof(System.String));
        dt.Columns.Add("sAMAccountName", typeof(System.String));
        string[] groupmember = GetUsersForGroup(groupname);
        if (groupmember.Length == 0)
        {
            return null;
        }
        else
        {
            foreach (string member in groupmember)
            {
                if (IsAccountActive(getAccountControl(getAccountName(member))))
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = member.ToString();
                    dr[1] = getAccountName(member);
                    dt.Rows.Add(dr);
                }
            }
            return dt;

        }
    }



    public DataTable adUserlist()   //����ָ�����û���Ϣ���ݱ�
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("memberof", typeof(System.String));
        dt.Columns.Add("cn", typeof(System.String));
        dt.Columns.Add("Description", typeof(System.String));
        dt.Columns.Add("name", typeof(System.String));
        dt.Columns.Add("Mail", typeof(System.String));
        dt.Columns.Add("samaccountname", typeof(System.String));
        dt.Columns.Add("whencreated", typeof(System.String));
        dt.Columns.Add("title", typeof(System.String));
        dt.Columns.Add("department", typeof(System.String));
        DirectorySearcher searcher = new DirectorySearcher(_path);
        //searcher.Filter = "(description=ADPJ*)";
        searcher.Filter = "(description=ADPL*)";
        searcher.PropertiesToLoad.AddRange(new string[] { "memberof", "cn", "description", "name", "Mail", "samaccountname", "whencreated", "title", "department" });
        SearchResultCollection results = searcher.FindAll();

        if (results.Count == 0)
        {
            return (null);
        }
        else
        {
            foreach (SearchResult result in results)
            {

                DataRow dr = dt.NewRow();
                //dr[0] = result.Path.ToString();
                if (result.GetDirectoryEntry().InvokeGet("memberof") != null)
                    dr[0] = result.GetDirectoryEntry().InvokeGet("memberof").ToString();
                else
                    dr[0] = "";
                if (result.GetDirectoryEntry().InvokeGet("cn") != null)
                    dr[1] = result.GetDirectoryEntry().InvokeGet("cn").ToString();
                else
                    dr[1] = "";

                if (result.GetDirectoryEntry().InvokeGet("Description") != null)
                    dr[2] = result.GetDirectoryEntry().InvokeGet("Description").ToString();
                else
                    dr[2] = result.GetDirectoryEntry().InvokeGet("cn").ToString();
                if (result.GetDirectoryEntry().InvokeGet("name") != null)
                    dr[3] = result.GetDirectoryEntry().InvokeGet("name").ToString();
                else
                    dr[3] = "";
                if (result.GetDirectoryEntry().InvokeGet("Mail") != null)
                    dr[4] = result.GetDirectoryEntry().InvokeGet("Mail").ToString();
                else
                    dr[4] = "";
                if (result.GetDirectoryEntry().InvokeGet("samaccountname") != null)
                    dr[5] = result.GetDirectoryEntry().Properties["samaccountname"].Value.ToString();
                else
                    dr[5] = "";
                if (result.GetDirectoryEntry().InvokeGet("whencreated") != null)
                    dr[6] = result.GetDirectoryEntry().Properties["whencreated"].Value.ToString();
                else
                    dr[6] = "";

                if (result.GetDirectoryEntry().InvokeGet("title") != null)
                    dr[7] = result.GetDirectoryEntry().Properties["title"].Value.ToString();
                else
                    dr[7] = "";
                if (result.GetDirectoryEntry().InvokeGet("department") != null)
                    dr[8] = result.GetDirectoryEntry().Properties["department"].Value.ToString();
                else
                    dr[8] = "";

                dt.Rows.Add(dr);
            }
            dt.DefaultView.Sort = "description ASC";
            return dt;
        }
    }

    public void adUserlistbox(ListBox results, string groupName)  //����USER
    {
        results.Items.Clear();
        DataTable dt = adUserlist(groupName);
        if (dt != null)
        {
            results.DataSource = dt;
            results.DataTextField = dt.Columns[0].Caption;
            results.DataValueField = dt.Columns[1].Caption;
            results.DataBind();
        }
    }

    public void adGrouplistbox(ListBox results)
    {
        results.Items.Clear();
        DataTable dt = GetAdGroupInfo();
        DataRow dr = dt.NewRow();
        dr[1] = "All";
        dr[2] = "All";
        dt.Rows.Add(dr);
        results.DataSource = dt;
        results.DataTextField = dt.Columns[2].Caption;
        results.DataValueField = dt.Columns[1].Caption;
        results.DataBind();
    }

    public void aduserGrouplist(DropDownList results)
    {
        results.Items.Clear();
        DataTable dt = GetAdGroupInfo();
        results.DataSource = dt;
        results.DataTextField = dt.Columns[2].Caption;
        results.DataValueField = dt.Columns[1].Caption;
        results.DataBind();
    }

    public int getAccountControl(string accountName)//��ȡȨ����
    {
        int results;
        DirectorySearcher ds = new DirectorySearcher(_path);
        ds.Filter = "(&(objectClass=user)(sAMAccountName=" + accountName + "))";
        ds.PropertiesToLoad.Add("userAccountControl");
        try
        {
            SearchResult r = ds.FindOne();
            results = Convert.ToInt32(r.GetDirectoryEntry().InvokeGet("userAccountControl"));
            return results;
        }
        catch
        {
            return 0;
        }

    }

    public bool IsAccountActive(int userAccountControl)//�ж��Ƿ���Ч
    {
        int ADS_UF_ACCOUNTDISABLE = 0X0002;
        int userAccountControl_Disabled = Convert.ToInt32(ADS_UF_ACCOUNTDISABLE);
        int flagExists = userAccountControl & userAccountControl_Disabled;
        if (flagExists > 0)
            return false;
        else
            return true;
    }

    ///   <summary> 
    ///   ��ȡAD�û���Ϣ 
    ///   </summary> 
    ///   <param   name= "ADUsername "> �û� </param> 
    ///   <param   name= "ADPassword "> ���� </param> 
    ///   <param   name= "domain "> ���� </param> 
    ///   <returns> </returns> 
    public DirectoryEntry GetDirectoryEntryByAccount(string sAMAccountName)
    {
        DirectorySearcher deSearch = new DirectorySearcher(_path);
        deSearch.Filter = "(&(objectCategory=person)(objectClass=user)(sAMAccountName=" + sAMAccountName + "))";
        // deSearch.SearchScope = SearchScope.Subtree;

        try
        {
            SearchResult result = deSearch.FindOne();
            if (result == null)
            { return null; }
            DirectoryEntry de = new DirectoryEntry(_path);
            return de;
        }
        catch
        {
            //throw;
            return null;
        }
    }

    ///   <summary> 
    ///   ��ȡAD�û���Ϣ 
    ///   </summary> 
    ///   <param   name= "ADUsername "> �û� </param> 
    ///   <param   name= "ADPassword "> ���� </param> 
    ///   <param   name= "domain "> ���� </param> 
    ///   <returns> </returns> 
    public DataTable AdUserInfo(string ADUsername, string ADPassword, string domain)//System.Collections.SortedList
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Name");
        try
        {
            System.DirectoryServices.DirectorySearcher src;
            string ADPath = "LDAP:// " + domain;//   "ou=�ܹ�˾,DC=abc,DC=com,DC=cn ";   + ",ou=�ܹ�˾ " 
            System.Collections.SortedList sl = new System.Collections.SortedList();
            string domainAndUsername = domain + @"\" + ADUsername;
            System.DirectoryServices.DirectoryEntry de = new System.DirectoryServices.DirectoryEntry(ADPath, ADUsername, ADPassword, AuthenticationTypes.None);

            src = new System.DirectoryServices.DirectorySearcher(de);
            //src.Filter = "(SAMAccountName=" + ADUsername + ")";
            src.PageSize = 10000;//   �˲��������������ã������ܲ����ã��粻���ö�ȡAD����Ϊ0~999�����ݣ����ú���Զ�ȡ����1000�����ݡ� 
            //   src.SizeLimit   =   2000; 
            src.SearchScope = System.DirectoryServices.SearchScope.Subtree;
            src.Filter = "(&(&(objectCategory=person)))";
            
        
            foreach (System.DirectoryServices.SearchResult res in src.FindAll())
            {
                try
                {
                    //sl.Add(res.GetDirectoryEntry().Properties["Name"].Value, res.GetDirectoryEntry().InvokeGet("Description"));
                    if (res.GetDirectoryEntry().Properties["Name"].Value.ToString().Trim() != "")
                    {
                        DataRow dw = dt.NewRow();

                        dw["Name"] = res.GetDirectoryEntry().Properties["Name"].Value.ToString().Trim();
                        dt.Rows.Add(dw);
                    }
                }
                catch
                {
                }
            }
        }
        catch (Exception ex)
        {
            //throw new Exception("Get   Ad   Info ", ex);
        }
        return dt;
    } 





}