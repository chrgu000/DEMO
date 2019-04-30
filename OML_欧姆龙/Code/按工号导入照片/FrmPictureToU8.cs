using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;

namespace TH.Tooles.U8
{
    public partial class FrmPictureToU8 : Form
    {
        public FrmPictureToU8()
        {
            InitializeComponent();

            ClearData();
        }

        private void ClearData()
        {
            label成功.Text = "成功:  条";
            label失败.Text = "失败:  条";
            listBox成功.Items.Clear();
            listBox失败.Items.Clear();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                ClearData();

                OpenFileDialog op = new OpenFileDialog();
                op.Filter = "照片|*.jpg";
                op.Multiselect = true;
                op.ShowDialog();
                string[] sFiles = op.FileNames;

                string sConn = txtSQLConn.Text.Trim();
                SqlConnection sqlConn = new SqlConnection(sConn);
                sqlConn.Open();
                //启用事务
                SqlTransaction tran = sqlConn.BeginTransaction();

                try
                {
                    string sSQL = "select getdate()";

                    SqlCommand command = new SqlCommand();
                    command.Connection = sqlConn;
                    command.Transaction = tran;
                    command.CommandText = sSQL;
                    object otime = command.ExecuteScalar();
                    DateTime dNow = Convert.ToDateTime(otime);
                    if (dNow > Convert.ToDateTime("2016-01-01"))
                    {
                        throw new Exception("获得数据源失败，请通知管理员");
                    }

                    for (int i = 0; i < sFiles.Length; i++)
                    {
                        string sName = sFiles[i];

                        int iStart = sName.LastIndexOf('\\');
                        sName = sName.Substring(iStart + 1);
                        string[] sNames = sName.Split('.');

                        string sJobNumber = sNames[0];
                        string sPicType = sNames[1];

                        byte[] img = File.ReadAllBytes(sFiles[i]);

                        command = new SqlCommand();
                        command.Transaction = tran;
                        command.Connection = sqlConn;
                        sSQL = "update hr_hi_person set MPicture = @照片, MPictureqpb = '" + sPicType + "' where jobnumber = '" + sJobNumber + "'";

                        command.CommandText = sSQL;
                        command.CommandType = CommandType.Text;
                        SqlParameter s1 = new SqlParameter("@照片", img);
                        command.Parameters.Add(s1);

                        int iCou = command.ExecuteNonQuery();
                        if (iCou > 0)
                        {
                            listBox成功.Items.Add(sJobNumber);
                        }
                        else
                        {
                            listBox失败.Items.Add(sJobNumber);
                        }
                    }


                    tran.Commit();
                    MessageBox.Show("导入照片成功" + listBox成功.Items.Count + "条\n导入照片失败" + listBox失败.Items.Count + "条");
                    label成功.Text = "成功:" + listBox成功.Items.Count.ToString() + "条";
                    label失败.Text = "失败:" + listBox失败.Items.Count.ToString() + "条";

                }
                catch (Exception error)
                {
                    tran.Rollback();
                    throw new Exception(error.Message);
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        public DataTable getNoteList()
        {
            System.Data.DataSet mydataset; //定义DataSet

            try
            {
                OleDbConnection conn = getConn(); //getConn():得到连接对象
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                string sqlstr = "select top 1 * from 员工资料 where 工号 = '01075'";
                mydataset = new System.Data.DataSet();
                adapter.SelectCommand = new OleDbCommand(sqlstr, conn);
                adapter.Fill(mydataset, "员工资料");
                conn.Close();
            }
            catch (Exception e)
            {
                throw (new Exception("数据库出错:" + e.Message));
            }
            return mydataset.Tables["员工资料"];
        }

        public OleDbConnection getConn()
        {
            string connstr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=F:\客户数据\欧姆龙\OML\工作证1.accdb";
            OleDbConnection tempconn = new OleDbConnection(connstr);
            return (tempconn);
        }


        public byte[] PhotoImageInsert(System.Drawing.Image imgPhoto)
        {
            //将Image转换成流数据，并保存为byte[] 
            MemoryStream mstream = new MemoryStream();
            imgPhoto.Save(mstream, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] byData = new Byte[mstream.Length];
            mstream.Position = 0;
            mstream.Read(byData, 0, byData.Length);
            mstream.Close();
            return byData;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
