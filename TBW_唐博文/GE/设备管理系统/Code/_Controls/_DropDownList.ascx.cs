using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class FormatDropDownList : System.Web.UI.UserControl
{
    protected string _DataSourceID="";
    protected string _DataTextField="";
    protected string _DataValueField="";
    protected string _iType = "";
    protected string _iFlag = "";
    protected DataTable dt;
    #region
    protected void Page_Load(object sender, EventArgs e)
    {
        if (ViewState["DataLoaded"] == null)
        {
            LoadData();
            ViewState["DataLoaded"] = true;
            //ddlhid.Attributes.Add("onchange", "javascript:StartDropDownList(" + ddl.ClientID + "," + ddlhid.ClientID + ")");
            //ddl.Attributes.Add("onchange", "javascript:ChangeDropDownList(" + ddl.ClientID + "," + ddlhid.ClientID + ")");
            //Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "myscript", "<script>StartDropDownList(" + ddl.ClientID + "," + ddlhid.ClientID + ");</script>");
        }
        //try
        //{
        //    for (int i = 0; i < ddl.Items.Count; i++)
        //    {
        //        ddl.Items[i].Selected = false;
        //    }
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        ddl.Items.Add(new ListItem(dt.Rows[i][1].ToString(), dt.Rows[i][0].ToString()));
        //    }
        //}
        //catch
        //{ }
    }
    

    public string Value
    {
        get
        {
            //return ddlhid.Text;
            string ivalue = "";
            for (int i = 0; i < ddl.Items.Count; i++)
            {
                if (ddl.Items[i].Selected == true)
                {
                    ivalue = ddl.Items[i].Value;
                }
            }
            return ivalue;
        }
        set
        {
            string ivalue = value;
            try
            {
                for (int i = 0; i < ddl.Items.Count; i++)
                {
                    ddl.Items[i].Selected = false;
                }
                for (int i = 0; i < ddl.Items.Count; i++)
                {
                    if (ddl.Items[i].Value == value)
                    {
                        ddl.Items[i].Selected = true;
                        i = ddl.Items.Count;
                        //ddlhid.Text = _catid;
                    }
                }
            }
            catch { }

        }
    }

    public bool Enabled
    {
        set
        {
            //ddl.e = value;
        }
    }

    public string DataSourceID
    {
        set
        {
            _DataSourceID = value;
        }
    }

    public string DataTextField
    {
        set
        {
            _DataTextField = value;
        }
    }

    public string DataValueField
    {
        set
        {
            _DataValueField = value;
        }
    }

    public string iType
    {
        set
        {
            _iType = value;
        }
    }

    public string iFlag
    {
        set
        {
            _iFlag = value;
        }
    }
    #endregion

    private void LoadData()
    {
        for (int i = ddl.Items.Count-1; i>=0; i--)
        {
            ddl.Items.Remove(ddl.Items[i]);
        }
        dt = new DataTable();
        PublicData p = new PublicData();
        string sSQL = "";
        if (_iFlag != "")
        {
            switch (_iFlag)
            {
                case "1":
                    dt = p.GetEquip();
                    break;
                case "2":
                    dt = p.GetInventory();
                    break;
                case "3":
                    dt = p.GetWorker(_iType);
                    break;
                case "4":
                    dt = p.GetEquipType();
                    break;
                case "5":
                    dt = p.GetLookUpType();
                    break; 

            }
            for (int i = 0; i < ddl.Items.Count; i++)
            {
                ddl.Items[i].Selected = false;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddl.Items.Add(new ListItem(dt.Rows[i][1].ToString(), dt.Rows[i][0].ToString()));
            }
        }
        else if (_iType != "")
        {
            dt = p.GetLookUpData(_iType);
            for (int i = 0; i < ddl.Items.Count; i++)
            {
                ddl.Items[i].Selected = false;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddl.Items.Add(new ListItem(dt.Rows[i][1].ToString(), dt.Rows[i][0].ToString()));
            }
        }
        
    }
}