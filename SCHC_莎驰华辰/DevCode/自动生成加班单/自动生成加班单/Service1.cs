using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;
using System.Xml;
using System.Collections;
using System.Threading;
using System.Windows.Forms;
using System.Data.SqlClient;
using TH.BaseClass;

namespace TH.WindowsService
{
    public partial class Service1 : ServiceBase
    {
        private string sPathConfig = Application.StartupPath + @"\App.dll";
        private string sPathTxt = Application.StartupPath + @"\log.txt";

        System.Timers.Timer t;
        public Service1()
        {
            TimeElapse(null, null);//发布时注销
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            StreamWriter("Start.");
            t = new System.Timers.Timer();
            t.Interval = 6000*30;
            t.Elapsed += new System.Timers.ElapsedEventHandler(TimeElapse);     //到达时间的时候执行事件；    
            t.Enabled = true;                                                   //是否执行System.Timers.Timer.Elapsed事件；    
        }

        private void StreamWriter(string p)
        {
            //throw new NotImplementedException();
        }

        protected override void OnStop()
        {
            StreamWriter("Stop.");
        }

        public void TimeElapse(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                //t.Enabled = false;//发布时取消注销    
                ClsRunOverTime cls = new ClsRunOverTime(sPathConfig, sPathTxt, Application.StartupPath);


                cls.GetTimer();
                StreamWriter("New");
                t.Enabled = true;//发布时取消注销   
            }
            catch (Exception ee)
            {
                StreamWriter(ee.Message);
            }
        }

    }
}
