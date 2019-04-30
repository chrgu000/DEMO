using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Configuration;
using System.Collections;
namespace Ajax
{
    /// <summary>
    /// Summary description for AjaxClass.
    /// </summary>
    public class AjaxMethod : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        string sSQL = "";
        ClsDataBase clsSQLCommond = new ClsDataBase();
        ClsDES clsDES = ClsDES.Instance();
        #region alert提示
        /// <summary>
        /// 1.不可为空
        /// 2.确认删除吗
        /// 3.请扫描需要登出的标签
        /// 4.卡认证失败，无卡或卡片已读过
        /// 5.条已删除
        /// 6.身份证号错误
        /// 7.不可删除
        /// 8.删除失败
        /// 9.未设置该功能
        /// 10.手机或电话号码错误
        /// 11.是否为整数
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.Read)]
        public string GetAlert(int i)
        {
            PublicClass pc = new PublicClass();
            string salt = pc.GetLanguageAlert();
            sSQL = "select " + salt + " from  _AlertLabels where iID=" + i;
            return clsSQLCommond.ExecString(sSQL);
        }
        #endregion

        #region GetLogOut 退出登录
        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.Read)]
        public bool GetLogOut(string uid)
        {
            //sql = "update   _UserInfo set IsLog='N' where UserID='" + uid + "'";
            //clsSQLCommond.Update(sql);
            //PublicClass.SetCookie("", "", "", "");
            return true;
        }
        #endregion

        #region 得到条码
        /// <summary>
        /// 得到条码
        /// </summary>
        /// <returns></returns>
        [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.Read)]
        public string GetBarCode(string code)
        {
            return BarCodeToHTML.get39(code, 2, 20);
        }
        #endregion

        #region 登陆
        /// <summary>
        /// 登陆
        /// </summary>
        /// <returns></returns>
        [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.Read)]
        public bool GetVisitorsLog(string id)
        {
            ArrayList arrlist = new ArrayList();
            sSQL = "select isnull(max(right(SS6,4)),0) as CardID from Visitors where left(SS6,8)='" + DateTime.Now.ToString("yyMMdd") + "'";
            string CardID = (clsSQLCommond.Int(sSQL) + 1).ToString();

            sSQL = "select * from Visitors where iiID=" + id;
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            
            for(int i=0;i<dt.Rows.Count;i++)
            {
                if (dt.Rows[i]["SS6"].ToString() == "")
                {
                    string newid = CardID;
                    if (newid.Length == 1)
                    {
                        newid = "000" + newid;
                    }
                    else if (newid.Length == 2)
                    {
                        newid = "00" + newid;
                    }
                    else if (newid.Length == 3)
                    {
                        newid = "0" + newid;
                    }
                    newid = DateTime.Now.ToString("yyMMdd") + newid;
                    arrlist.Add("update Visitors set DDate1='" + DateTime.Now.ToString() + "',II2='2',SS6='" + newid + "' where AutoID=" + dt.Rows[i]["AutoID"].ToString());
                    CardID = CardID + 1;
                }
            }

            try
            {
                clsSQLCommond.ExecSqlTran(arrlist);
            }
            catch
            {
                return false;
            }

            return true;
        }
        #endregion

        #region 登出
        /// <summary>
        /// 登出
        /// </summary>
        /// <returns></returns>
        [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.Read)]
        public string GetVisitorsLogOut(string id)
        {
            string ddate = DateTime.Now.ToString();
            clsSQLCommond.Update("update Visitors set DDate2='" + ddate + "',II2='3' where iiID=" + id);
            return ddate;
        }
        #endregion

        #region 登出
        /// <summary>
        /// 登出
        /// </summary>
        /// <returns></returns>
        [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.Read)]
        public string GetVisitorsLogOut2(string autoid)
        {
            string ddate = DateTime.Now.ToString();
            clsSQLCommond.Update("update Visitors set DDate2='" + ddate + "',II2='3' where AutoID=" + autoid);
            return ddate;
        }
        #endregion

        #region 得到访客信息
        /// <summary>
        /// 得到访客信息
        /// </summary>
        /// <returns></returns>
        [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.Read)]
        public Array GetVis(string iID)
        {
            string[] str = new string[17];
            DataTable dt=new DataTable();
            if (iID != "")
            {

                sSQL = "select *,case when Date3 is null then '未访问' when Date4 is null then '访问中' end as Flag from Visitor left join Visitors  on Visitor.iID=Visitors.iiID where SS6='" + iID + "'";

                dt = clsSQLCommond.ExecQuery(sSQL);
            }
            if (iID!="" && dt.Rows.Count > 0)
            {
                str[0] = clsDES.Decrypt(dt.Rows[0]["SS1"].ToString());
                str[1] = dt.Rows[0]["SS2"].ToString();
                str[2] = dt.Rows[0]["SS3"].ToString();
                str[3] = clsDES.Decrypt(dt.Rows[0]["SS4"].ToString());
                str[4] = clsDES.Decrypt(dt.Rows[0]["SS5"].ToString());
                str[5] = dt.Rows[0]["S6"].ToString();
                str[6] = dt.Rows[0]["S7"].ToString();
                str[7] = dt.Rows[0]["S8"].ToString();
                str[8] = dt.Rows[0]["S9"].ToString();
                str[9] = dt.Rows[0]["D1"].ToString();
                str[10] = dt.Rows[0]["IImg1"].ToString();
                str[11] = DateTime.Parse(dt.Rows[0]["Date1"].ToString()).ToString("yyyy-MM-dd");
                str[12] = DateTime.Parse(dt.Rows[0]["Date2"].ToString()).ToString("yyyy-MM-dd");
                str[13] = dt.Rows[0]["DDate1"].ToString();
                str[14] = dt.Rows[0]["DDate2"].ToString();
                str[15] = dt.Rows[0]["iID"].ToString();
                str[16] = dt.Rows[0]["AutoID"].ToString();
            }
            else
            {
                str[0] = "";
                str[1] = "";
                str[2] = "";
                str[3] = "";
                str[4] = "";
                str[5] = "";
                str[6] = "";
                str[7] = "";
                str[8] = "";
                str[9] = "";
                str[10] = "";
                str[11] = "";
                str[12] = "";
                str[13] = "";
                str[14] = "";
                str[15] = "";
                str[16] = "";
            }
            return str;
        }
        #endregion

        #region SelectLanguange 得到语言
        /// <summary>
        /// 得到语言
        /// </summary>
        /// <returns></returns>
        [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.Read)]
        public string SelectLan(string uid)
        {
            if (uid != "")
            {
                sSQL = "select vlanguage from _UserInfo where vchrUid='" + uid + "'";
                return clsSQLCommond.ExecString(sSQL);
            }
            return "1";
        }
        #endregion

        #region SelectPrint 打印设置
        /// <summary>
        /// 打印设置
        /// </summary>
        /// <returns></returns>
        [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.Read)]
        public DataTable GetPrint(int i)
        {

            sSQL = "select * from PrintStyle where Flag='"+i+"'";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            return dt;

        }
        #endregion

        #region SelectPrint 打印设置
        /// <summary>
        /// 打印设置
        /// </summary>
        /// <returns></returns>
        [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.Read)]
        public string GetPrintSave(string hidid, string txt1, string txt2, string txt3, string txt4, string txt5, 
            string txt6, string txt7, string txt8, string txt9,
            string d1, string d2,   string txt10)
        {
            string printtime = DateTime.Now.ToString();
            SqlConnection con = new SqlConnection(clsSQLCommond.Online);
            SqlCommand cmd = new SqlCommand();
            SqlTransaction trans;
            con.Open();
            cmd.Connection = con;
            trans = con.BeginTransaction();
            cmd.Transaction = trans;
            try
            {
                Sql sc = new Sql();
                sc.Get("Visitors", "iID", hidid, false);

                sc.ToString("dChangeVerifyTime", DateTime.Now.ToString());
                sc.ToString("dChangeVerifyPerson", Session["uID"].ToString());

                sc.ToString("S1", txt1);
                sc.ToString("S2", txt2);
                sc.ToString("S3", txt3);
                sc.ToString("S4", txt4);
                sc.ToString("S5", txt5);

                sc.ToString("S6", txt6);
                sc.ToString("S7", txt7);
                sc.ToString("S8", txt8);
                sc.ToString("S9", txt9);
                sc.ToString("D1", txt10);

                sc.ToString("Date1", d1);
                sc.ToString("Date2", d2);
                sc.ToString("Date3", printtime);

                cmd.CommandText = sc.ReturnSql();
                cmd.ExecuteNonQuery();

                trans.Commit();
                return printtime;
            }
            catch
            {
                trans.Rollback();
                return "";
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }
            return "";
        }
        #endregion

        #region LookUpDate
        /// <summary>
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.Read)]
        public DataTable GetLookUpDate(int i)
        {
            return clsSQLCommond.ExecQuery("select iID,iText,iText2 from  _LookUpDate where iType='" + i + "'");
        }
        #endregion

        #region 访客信息保存
        /// <summary>
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.Read)]
        public string GetSave(string iID, string date1, string date2, string txt6, string txt7, string txt8, string txt9, string isnew, string[] arrautoid, string[] arr1, string[] arr2, string[] arr3, string[] arr4, string[] arr5, string[] arrimg1, string[] arrbar1, string hiddel, string[] arr7)
        {
            ArrayList arrlist = new ArrayList();
            string[] strdel=hiddel.Split(',');
            for(int i=0;i<strdel.Length;i++)
            {
                if (strdel[i].Trim() != "")
                {
                    sSQL = "delete from Visitors where AutoID=" + strdel[i];
                    arrlist.Add(sSQL);
                }
            }

            #region 主表
            Sql sc = new Sql();
            if (iID == "")
            {
                sSQL = "select isnull(max(iID),0)+1 from Visitor";
                long ID = long.Parse(clsSQLCommond.ExecString(sSQL));
                iID = ID.ToString();

                sc.Get("Visitor", "iID", ID.ToString(), true);

                sc.ToString("dCreatesysTime", DateTime.Now.ToString());
                sc.ToString("dCreatesysPerson", Session["uID"].ToString());
            }
            else
            {
                sc.Get("Visitor", "iID", iID, false);

                sc.ToString("dChangeVerifyTime", DateTime.Now.ToString());
                sc.ToString("dChangeVerifyPerson", Session["uID"].ToString());
            }
            //sc.ToString("S1", TextBox1.Text);
            //sc.ToString("S2", TextBox2.Text);
            //sc.ToString("S3", DropDownList3.SelectedValue);
            //sc.ToString("S4", TextBox4.Text);
            //sc.ToString("S5", TextBox5.Text);

            sc.ToString("S6", txt6);
            sc.ToString("S7", txt7);
            sc.ToString("S8", txt8);
            sc.ToString("S9", txt9);

            sc.ToString("Date1", date1);
            sc.ToString("Date2", date2);
            //sc.ToString("Date3", Label13_1.Text);
            //sc.ToString("Date4", Label14_1.Text);

            //sc.ToString("Img1", hidImg1.Value);

            if (isnew != "")
            {
                sc.ToString("I1", 1);
            }
            else
            {
                sc.ToString("I1", 2);
            }
            arrlist.Add(sc.ReturnSql());
            #endregion

            sSQL = "select isnull(max(AutoID),0)+1 from Visitors";
            long AutoID = long.Parse(clsSQLCommond.ExecString(sSQL));
 
            #region 从表
            for (int i = 0; i < arrautoid.Length; i++)
            {
                Sql scc = new Sql();
                if (arrautoid[i] == "")
                {
                    scc.Get("Visitors", "AutoID", AutoID.ToString(), true);
                    AutoID = AutoID + 1;
                }
                else
                {
                    scc.Get("Visitors", "AutoID", arrautoid[i], false);
                }
                scc.ToString("iiID", iID);
                scc.ToString("SS1", clsDES.Encrypt(arr1[i]));
                scc.ToString("SS2", arr2[i]);
                scc.ToString("SS3", arr3[i]);
                scc.ToString("SS4", clsDES.Encrypt(arr4[i]));
                scc.ToString("SS5", clsDES.Encrypt(arr5[i]));
                scc.ToString("SS6", arrbar1[i]);
                scc.ToString("SS7", arr7[i]);
                scc.ToString("IImg1", arrimg1[i]);
                if (isnew != "")
                {
                    sc.ToString("I2", 1);
                }
                else
                {
                    sc.ToString("I2", 0);
                }
                arrlist.Add(scc.ReturnSql());
            }
            #endregion
            try
            {
                clsSQLCommond.ExecSqlTran(arrlist);
            }
            catch
            {
                return "";
            }
            return iID;
        }
        #endregion

        #region 得到访客子表信息
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.Read)]
        public DataTable GetVisitors(string iID)
        {
            DataTable dts = clsSQLCommond.ExecQuery(@"SELECT   AutoID, iiID, SS1, SS2, SS3, SS4, SS5, SS6, SS7, SS8, SS9, SS10, DD1, DD2, DD3, DD4, DD5, DD6, DD7, DD8, DD9, DD10, CONVERT(varchar, DDate1) AS DDate1, CONVERT(varchar, DDate2) AS DDate2, DDate3, 
                      DDate4, DDate5, DDate6, DDate7, DDate8, DDate9, DDate10, sSysCreateDate, BB1, BB2, BB3, BB4, BB5, BB6, BB7, BB8, BB9, BB10, II1, II2, II3, II4, II5, II6, II7, II8, 
                      II9, II10, IImg1, IImg2, IImg3, IImg4, IImg5, IImg6, IImg7, IImg8, IImg9, IImg10
FROM         Visitors where iiID='" + iID + "'");
            for (int i = 0; i < dts.Rows.Count; i++)
            {
                dts.Rows[i]["SS1"] = clsDES.Decrypt(dts.Rows[i]["SS1"].ToString());
                dts.Rows[i]["SS4"] = clsDES.Decrypt(dts.Rows[i]["SS4"].ToString());
                dts.Rows[i]["SS5"] = clsDES.Decrypt(dts.Rows[i]["SS5"].ToString());
            }
                return dts;
        }
        #endregion

        #region 得到访客主表信息
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.Read)]
        public DataTable GetVisitor(string iID)
        {
            DataTable dt = clsSQLCommond.ExecQuery("select * from Visitor where iID='" + iID + "'");
            return dt;
        }
        #endregion

        [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.Read)]
        public bool Insert(string iID, string S1, string S2, string S3, string S4, string S5, string S6, string S7, string S8, string S9, string S10, string S11, string S12, string S13, string S14, string S15,
         DateTime Date1, DateTime Date2, DateTime Date3, DateTime Date4, DateTime Date5,
         decimal D1, decimal D2, decimal D3, decimal D4, decimal D5, decimal D6, decimal D7, decimal D8, decimal D9, decimal D10)
        {
            string tablename = "Equip";
            string uid = Session["uID"].ToString();
            ArrayList arr = new ArrayList();
            Sql sql = new Sql();
            if (iID == "" || iID == null)
            {
                sSQL = "select isnull(max(iID),0)+1 from  " + tablename + "";
                iID = clsSQLCommond.ExecString(sSQL);
                sql.Get(tablename, "iID", iID, true);
                sql.ToString("dCreatesysTime", DateTime.Now);
                sql.ToString("dCreatesysPerson", uid);
            }
            else
            {
                sql.Get(tablename, "iID", iID, false);
                sql.ToString("dChangeVerifyTime", DateTime.Now);
                sql.ToString("dChangeVerifyPerson", uid);
            }
            sql.ToString("S1", S1);
            sql.ToString("S2", S2);
            sql.ToString("S3", S3);
            sql.ToString("S4", S4);
            sql.ToString("S5", S5);
            sql.ToString("S6", S6);
            sql.ToString("S7", S7);
            sql.ToString("S8", S8);
            sql.ToString("S9", S9);
            sql.ToString("S10", S10);
            sql.ToString("S11", S11);
            sql.ToString("S12", S12);
            sql.ToString("S13", S13);
            sql.ToString("S14", S14);
            sql.ToString("S15", S15);
            sql.ToString("Date1", Date1);
            sql.ToString("Date2", Date2);
            sql.ToString("Date3", Date3);
            sql.ToString("Date4", Date4);
            sql.ToString("Date5", Date5);
            sql.ToString("D1", D1);
            sql.ToString("D2", D2);
            sql.ToString("D3", D3);
            sql.ToString("D4", D4);
            sql.ToString("D5", D5);
            sql.ToString("D6", D6);
            sql.ToString("D7", D7);
            sql.ToString("D8", D8);
            sql.ToString("D9", D9);
            sql.ToString("D10", D10);
            arr.Add(sql.ReturnSql());
            bool b = clsSQLCommond.ExecSqlTran(arr);
            return b;
        }

    }
}