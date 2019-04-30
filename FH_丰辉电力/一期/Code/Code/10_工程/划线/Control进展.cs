using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace 工程
{
    public partial class Control进展 : UserControl
    {
        protected 系统服务.ClsUseWebService clsWeb = new 系统服务.ClsUseWebService();
        private string iID;
        private string PID;
        private bool Back;

        private string sPer;
        public string Per
        {
            set { lblPer.Text = value; }
            get { return lblPer.Text; }
        }

        private string sEnable;
        public void Enable(bool b)
        {
            chkCheck.Enabled = b;
        }

        public void SetNull()
        {
            chkCheck.Enabled = false;
            chkCheck.Checked = false;
            lblPer.Text = "";
            lblTime.Text = "";
        }

        public Control进展()
        {
            InitializeComponent();
        }

        public void Set(string siID, string sPID, bool sBack,string Title,string per,string time)
        {
            iID = siID;
            PID = sPID;
            Back = sBack;
            memoEditTitle.Text = Title;
            lblPer.Text = per;
            if (time != "")
            {
                lblTime.Text = DateTime.Parse(time).ToString("yyyy-MM-dd");
                chkCheck.Checked = true;
            }
            else
            {
                lblTime.Text = "";
                chkCheck.Checked = false;
            }
        }
        private void Set(string PID)
        {
            if (PID != null && PID != "")
            {
                bool b = false;
                DataTable dt = clsWeb.dtProject(6, iID);
                DataRow[] dw = dt.Select("PID='" + PID + "'");
                if (dw.Length > 0)
                {
                    if (dw[0]["PersonCode"].ToString() != "")
                    {
                        b = true;
                    }
                    else
                    {
                        b = false;
                    }
                    if (dw[0]["dDate"].ToString() != "")
                    {
                        lblTime.Text = DateTime.Parse(dw[0]["dDate"].ToString()).ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        lblTime.Text = "";
                    }

                    lblPer.Text = dw[0]["PersonName"].ToString();
                    chkCheck.Checked = b;
                }
            }
        }

        private bool IsChecked(DataTable dtproj, string PID)
        {
            if (PID!=null && PID != "")
            {
                DataRow[] dw = dtproj.Select("PID=" + PID + "");
                if (dw.Length > 0 && dw[0]["PersonCode"].ToString() != "")
                {
                    return true;
                }
            }
            return false;
        }

        private void chkCheck_MouseClick(object sender, MouseEventArgs e)
        {
            //IsChange = true;
            DataTable dtproj = clsWeb.dtProject(6, iID);
            bool chk = chkCheck.Checked;
            bool b = IsChecked(dtproj, PID);
            bool isok = false;
            if (chk == false)//确认
            {
                if (b == true)//已经确认
                {
                    MessageBox.Show("已经确认");
                }
                else
                {
                    switch (PID)
                    {
                        case "1": if (IsChecked(dtproj, PID) == false) { isok = true; } break;
                        case "5": if (IsChecked(dtproj, "1") == true && IsChecked(dtproj, PID) == false) { isok = true; } break;
                        case "10": if (IsChecked(dtproj, "5") == true && IsChecked(dtproj, PID) == false) { isok = true; } break;
                        case "15": if (IsChecked(dtproj, "10") == true && IsChecked(dtproj, PID) == false) { isok = true; } break;
                        case "20": if (IsChecked(dtproj, "15") == true && IsChecked(dtproj, PID) == false) { isok = true; } break;
                        case "25": if (IsChecked(dtproj, "20") == true && IsChecked(dtproj, PID) == false) { isok = true; } break;
                        case "30": if (IsChecked(dtproj, "25") == true && IsChecked(dtproj, PID) == false) { isok = true; } break;
                        case "35": if (IsChecked(dtproj, "30") == true && IsChecked(dtproj, PID) == false) { isok = true; } break;
                        case "40": if (IsChecked(dtproj, "35") == true && IsChecked(dtproj, PID) == false) { isok = true; } break;
                        case "45": if (IsChecked(dtproj, "40") == true && IsChecked(dtproj, PID) == false) { isok = true; } break;
                        case "50": if (IsChecked(dtproj, "35") == true && IsChecked(dtproj, PID) == false) { isok = true; } break;
                        case "55": if (IsChecked(dtproj, "50") == true && IsChecked(dtproj, PID) == false) { isok = true; } break;
                        case "60": if (IsChecked(dtproj, "55") == true && IsChecked(dtproj, PID) == false) { isok = true; } break;
                        case "65": if (IsChecked(dtproj, "45") == true && IsChecked(dtproj, "60") == true && IsChecked(dtproj, PID) == false) { isok = true; } break;
                        case "70": if (IsChecked(dtproj, "65") == true && IsChecked(dtproj, PID) == false) { isok = true; } break;
                        case "75": if (IsChecked(dtproj, "65") == true && IsChecked(dtproj, PID) == false) { isok = true; } break;
                        case "80": if (IsChecked(dtproj, "70") == true && IsChecked(dtproj, "75") == true && IsChecked(dtproj, PID) == false) { isok = true; } break;
                        case "85": if (IsChecked(dtproj, "80") == true && IsChecked(dtproj, PID) == false) { isok = true; } break;
                        case "90": if (IsChecked(dtproj, "65") == true && IsChecked(dtproj, PID) == false) { isok = true; } break;

                        case "100": if (IsChecked(dtproj, PID) == false) { isok = true; } break;
                        case "105": if (IsChecked(dtproj, "100") == true && IsChecked(dtproj, PID) == false) { isok = true; } break;
                        case "110": if (IsChecked(dtproj, "105") == true && IsChecked(dtproj, PID) == false) { isok = true; } break;
                        case "115": if (IsChecked(dtproj, "100") == true && IsChecked(dtproj, PID) == false) { isok = true; } break;
                        case "120": if (IsChecked(dtproj, "115") == true && IsChecked(dtproj, PID) == false) { isok = true; } break;
                        case "125": if (IsChecked(dtproj, "110") == true && IsChecked(dtproj, "120") == true && IsChecked(dtproj, PID) == false) { isok = true; } break;
                        case "130": if (IsChecked(dtproj, "125") == true && IsChecked(dtproj, PID) == false) { isok = true; } break;
                        case "135": if (IsChecked(dtproj, "130") == true && IsChecked(dtproj, PID) == false) { isok = true; } break;
                        case "140": if (IsChecked(dtproj, "135") == true && IsChecked(dtproj, PID) == false) { isok = true; } break;

                        case "200": if (IsChecked(dtproj, PID) == false) { isok = true; } break;
                        case "205": if (IsChecked(dtproj, "200") == true && IsChecked(dtproj, PID) == false) { isok = true; } break;
                        case "210": if (IsChecked(dtproj, "200") == true && IsChecked(dtproj, PID) == false) { isok = true; } break;
                        case "215": if (IsChecked(dtproj, "205") == true && IsChecked(dtproj, "210") == true && IsChecked(dtproj, PID) == false) { isok = true; } break;
                        case "220": if (IsChecked(dtproj, "215") == true && IsChecked(dtproj, PID) == false) { isok = true; } break;
                        case "225": if (IsChecked(dtproj, "220") == true && IsChecked(dtproj, PID) == false) { isok = true; } break;
                        case "230": if (IsChecked(dtproj, "225") == true && IsChecked(dtproj, PID) == false) { isok = true; } break;
                        case "235": if (IsChecked(dtproj, "230") == true && IsChecked(dtproj, PID) == false) { isok = true; } break;
                    }
                    if (isok == true)
                    {
                        string sErr = clsWeb.saveProgress(PID, true, 系统服务.ClsBaseDataInfo.sUid, iID);
                        if (sErr == "ok")
                        {
                            MessageBox.Show("确认成功");
                        }
                        else
                        {
                            MessageBox.Show(sErr);
                        }
                    }
                    else
                    {
                        MessageBox.Show("不可确认");
                    }
                }
            }
            else if (chk == true)//取消确认
            {
                if (Back == true)
                {
                    if (b == false)//未确认
                    {
                        MessageBox.Show("未确认");
                    }
                    else
                    {
                        switch (PID)
                        {
                            case "1": if (IsChecked(dtproj, "5") == false) { isok = true; } break;
                            case "5": if (IsChecked(dtproj, "10") == false) { isok = true; } break;
                            case "10": if (IsChecked(dtproj, "15") == false) { isok = true; } break;
                            case "15": if (IsChecked(dtproj, "20") == false) { isok = true; } break;
                            case "20": if (IsChecked(dtproj, "25") == false) { isok = true; } break;
                            case "25": if (IsChecked(dtproj, "30") == false) { isok = true; } break;
                            case "30": if (IsChecked(dtproj, "35") == false) { isok = true; } break;
                            case "35": if (IsChecked(dtproj, "40") == false && IsChecked(dtproj, "45") == false) { isok = true; } break;
                            case "40": if (IsChecked(dtproj, "45") == false) { isok = true; } break;
                            case "45": if (IsChecked(dtproj, "65") == false) { isok = true; } break;
                            case "50": if (IsChecked(dtproj, "55") == false) { isok = true; } break;
                            case "55": if (IsChecked(dtproj, "60") == false) { isok = true; } break;
                            case "60": if (IsChecked(dtproj, "65") == false) { isok = true; } break;
                            case "65": if (IsChecked(dtproj, "70") == false && IsChecked(dtproj, "75") == false) { isok = true; } break;
                            case "70": if (IsChecked(dtproj, "80") == false) { isok = true; } break;
                            case "75": if (IsChecked(dtproj, "80") == false) { isok = true; } break;
                            case "80": if (IsChecked(dtproj, "85") == false) { isok = true; } break;
                            case "85": if (IsChecked(dtproj, "90") == false) { isok = true; } break;
                            case "90": if (IsChecked(dtproj, "90") == true) { isok = true; } break;

                            case "100": if (IsChecked(dtproj, "105") == false && IsChecked(dtproj, "115") == false) { isok = true; } break;
                            case "105": if (IsChecked(dtproj, "110") == false) { isok = true; } break;
                            case "110": if (IsChecked(dtproj, "125") == false) { isok = true; } break;
                            case "115": if (IsChecked(dtproj, "120") == false) { isok = true; } break;
                            case "120": if (IsChecked(dtproj, "125") == false) { isok = true; } break;
                            case "125": if (IsChecked(dtproj, "130") == false) { isok = true; } break;
                            case "130": if (IsChecked(dtproj, "135") == false) { isok = true; } break;
                            case "135": if (IsChecked(dtproj, "140") == false) { isok = true; } break;
                            case "140": if (IsChecked(dtproj, "140") == true) { isok = true; } break;

                            case "200": if (IsChecked(dtproj, "205") == false && IsChecked(dtproj, "210") == false) { isok = true; } break;
                            case "205": if (IsChecked(dtproj, "215") == false) { isok = true; } break;
                            case "210": if (IsChecked(dtproj, "215") == false) { isok = true; } break;
                            case "215": if (IsChecked(dtproj, "220") == false) { isok = true; } break;
                            case "220": if (IsChecked(dtproj, "225") == false) { isok = true; } break;
                            case "225": if (IsChecked(dtproj, "230") == false) { isok = true; } break;
                            case "230": if (IsChecked(dtproj, "235") == false) { isok = true; } break;
                            case "235": if (IsChecked(dtproj, "235") == true) { isok = true; } break;
                        }
                        if (isok == true)
                        {
                            string sErr = clsWeb.saveProgress(PID, false, 系统服务.ClsBaseDataInfo.sUid, iID);
                            if (sErr == "ok")
                            {
                                MessageBox.Show("取消成功");
                            }
                            else
                            {
                                MessageBox.Show(sErr);
                            }
                        }
                        else
                        {
                            MessageBox.Show("不可取消确认");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("没有权限取消确认");
                }
            }
            Set(PID);
        }
    }
}
