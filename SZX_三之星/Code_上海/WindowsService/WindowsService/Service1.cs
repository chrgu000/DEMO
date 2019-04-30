using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;

using System.ServiceProcess;
using System.Text;
using System.Timers;
using System.Xml;
using System.Collections;
using System.Threading;
using System.Windows.Forms;

namespace U8Export
{
    public partial class Service : ServiceBase
    {
        private string sPathConfig = Application.StartupPath + @"\App.dll";
        private string sPathTxt = Application.StartupPath + @"\log.txt";

        System.Timers.Timer t;
        cls导出数据 cls;

        public Service()
        {
            cls = new cls导出数据();
            OnStart(null);
            TimeElapse(null, null);
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            StreamWriter("Start.");
            t = new System.Timers.Timer();
            t.Interval = 60000;                                                  //60000为一分钟
            t.Elapsed += new System.Timers.ElapsedEventHandler(TimeElapse);     //到达时间的时候执行事件；    
            t.Enabled = true;                                                   //是否执行System.Timers.Timer.Elapsed事件；    
        }

        private void StreamWriter(string p)
        {
            //using (System.IO.StreamWriter sw = new System.IO.StreamWriter("log.txt", true))
            //{
            //    sw.WriteLine(DateTime.Now.ToString("sErr" + "yyyy-MM-dd HH:mm:ss ") + p);
            //}
        }

        protected override void OnStop()
        {
            StreamWriter("Stop.");
        }

        public void TimeElapse(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                t.Enabled = false;
                cls.ExportData(sPathConfig);
                t.Enabled = true;
            }
            catch (Exception ee)
            {
                t.Enabled = true;
                StreamWriter(ee.Message);
            }
        }
    }
}
