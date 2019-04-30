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

namespace U8DS
{
    public partial class Service : ServiceBase
    {
        System.Timers.Timer t;

        public Service()
        {
            OnStart(null);
            TimeElapse(null, null);
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            t = new System.Timers.Timer();
            //t.Interval = 300000;                                                  //60000为一分钟
            t.Interval = 30000;
            t.Elapsed += new System.Timers.ElapsedEventHandler(TimeElapse);     //到达时间的时候执行事件；       
            t.AutoReset = true;
            t.Enabled = true;                                                   //是否执行System.Timers.Timer.Elapsed事件； 
        }


        protected override void OnStop()
        {
            this.t.Enabled = false;
        }

        public void TimeElapse(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                t.Enabled = false;

                DllForService.clsCreateFHD cls = new DllForService.clsCreateFHD();
                cls.CreateFHD();

                t.Enabled = true;
            }
            catch (Exception ee)
            {
                t.Enabled = true;
            }
            finally
            { 
                
            }
        }
    }
}
