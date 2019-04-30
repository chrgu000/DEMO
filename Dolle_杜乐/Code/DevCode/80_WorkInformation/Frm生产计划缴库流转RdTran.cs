using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace WorkInformation
{
    public partial class Frm�����ƻ��ɿ���תRdTran : Form
    {
        FrameBaseFunction.ClsDataBase clsSQL = FrameBaseFunction.ClsDataBaseFactory.Instance();
        DataRow dr;
        public DataTable dt;

        public Frm�����ƻ��ɿ���תRdTran(DataRow dRow)
        {
            InitializeComponent();

            this.dr = dRow;
        }

        private void Frm�����ƻ��ɿ���תRdTran_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = null;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (dt == null || dt.Rows.Count == 0)
            {

            }
            else
            {
                DataRow[] drID = dt.Select("[ID]=" + dr["ID"]);
                if (drID.Length == 0)
                {

                }
                else
                {
                    gridControl1.DataSource = drID;
                }
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            gridControl1.DataSource = null;
        }
    }
}