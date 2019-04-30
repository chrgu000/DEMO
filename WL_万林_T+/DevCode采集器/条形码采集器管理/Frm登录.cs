﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BarCode
{
    public partial class Frm登录 : FrmBase
    {
        public Frm登录()
        {
            InitializeComponent();
        }

        private void btn登录_Click(object sender, EventArgs e)
        {
            try
            {
                MobileBaseDLL.ClsBaseDataInfo.sConnString = "server=114.55.54.113;uid=sa;pwd=UFsystem@123;database=UFTData805153_000100;timeout=200";
                //MobileBaseDLL.ClsBaseDataInfo.sConnString = "server=192.168.150.21;uid=sa;pwd=189.cn;database=UFTData139883_000002;timeout=200";
                if (txt账号.Text.Trim() != "" && txt密码.Text.Trim() != "")
                {
                    MobileBaseDLL.ClsDES clsDES = MobileBaseDLL.ClsDES.Instance();

                    string sUid = txt账号.Text.Trim();
                    string sPwd = txt密码.Text.Trim();

                    string sSQL = "select * from dbo._UserInfo where vchrUid = '" + sUid + "' and vchrPwd = '" + clsDES.Encrypt(sPwd) + "' ";
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    if(dt!=null && dt.Rows.Count >0)
                    {
                        sSQL = "SELECT isnull(cCode,-1) FROM _Code WHERE sType = '版本' ";

                        MobileBaseDLL.ClsBaseDataInfo.sUid = dt.Rows[0]["vchrUid"].ToString().Trim();
                        MobileBaseDLL.ClsBaseDataInfo.sUserName = dt.Rows[0]["vchrName"].ToString().Trim();
                        MobileBaseDLL.ClsBaseDataInfo.sUFDataBaseName = "UFDATA_200_2015";

                        this.DialogResult = DialogResult.Yes;
                    }
                    else
                    {
                        msgBox.textBox1.Text = "登陆失败:账号或者密码不正确";
                        msgBox.ShowDialog();
                    }
                }
                else
                {
                    msgBox.textBox1.Text = "登陆失败:账号或者密码为空";
                    msgBox.ShowDialog();
                }
            }
            catch (Exception ee)
            {
                msgBox.textBox1.Text = "登陆失败:" + ee.Message;
                msgBox.ShowDialog();
            }
        }

        private void Frm登录_Load(object sender, EventArgs e)
        {
            try
            {
                MobileBaseDLL.ClsBaseDataInfo.sUFDataBaseName = "UFTData135775_000002";
                dtmLogin.Text = DateTime.Today.ToString("yyyy-MM-dd");
            }
            catch (Exception ee)
            {

            }
        }
    }
}