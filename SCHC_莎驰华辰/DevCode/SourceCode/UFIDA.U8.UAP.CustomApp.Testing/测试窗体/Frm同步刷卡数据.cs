using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UFIDA.U8.UAP.CustomApp.MetaData;
using System.IO;
using System.Xml;
using TH.BaseClass;

namespace WindowsFormsApplication1
{
    public partial class Frm同步刷卡数据 : Form
    {
        public Frm同步刷卡数据()
        {
            InitializeComponent();


            hr_tm_OriCardData1.Conn = Config.ConnStr;
            hr_tm_OriCardData1.sUserID = "demo";
            hr_tm_OriCardData1.sUserName = "demo";
            hr_tm_OriCardData1.sAccID = "998";
            hr_tm_OriCardData1.sLogDate = "2015-6-30";

            DbHelperSQL.connectionString = Config.ConnStr;
        }

      

    }
}
