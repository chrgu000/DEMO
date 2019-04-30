using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using AutoUpdate;
using System.Collections;
using System.IO;
using 系统服务;

namespace AppStart
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool isUpdate = false;  //默认不需要更新
            isUpdate = CheckNeedUpdate();

            if (isUpdate)
            {
                MessageBox.Show("程序需要更新！", "提示");
                Application.Exit();

                System.Diagnostics.Process.Start(Application.StartupPath + @"\AutoUpdate.exe");

                return;
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new 系统服务.MdiMain());
            }
        }

        static bool CheckNeedUpdate()
        {
            string localXmlFile = Application.StartupPath + "\\UpdateList.xml";
            string serverXmlFile = string.Empty;
            string updateUrl = string.Empty;
            string tempUpdatePath = string.Empty;
            XmlFiles updaterXmlFiles = null;
            try
            {
                //从本地读取更新配置文件信息
                updaterXmlFiles = new XmlFiles(localXmlFile);
            }
            catch
            {
                return false;
            }
            //获取服务器地址
            updateUrl = updaterXmlFiles.GetNodeValue("//Url");

            AppUpdater appUpdater = new AppUpdater();
            appUpdater.UpdaterUrl = updateUrl + "UpdateList.xml";

            //与服务器连接,下载更新配置文件
            try
            {
                tempUpdatePath = Application.StartupPath + "\\update\\";
                //tempUpdatePath = Environment.GetEnvironmentVariable("Temp") + "\\" + "_" + updaterXmlFiles.FindNode("//Application").Attributes["applicationId"].Value + "_" + "y" + "_" + "x" + "_" + "m" + "_" + "\\";

                if (!appUpdater.DownAutoUpdateFile(tempUpdatePath))
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

            //获取更新文件列表
            Hashtable htUpdateFile = new Hashtable();

            serverXmlFile = tempUpdatePath + "UpdateList.xml";
            if (!File.Exists(serverXmlFile))
            {
                return false;
            }
            int availableUpdate = 0;
            availableUpdate = appUpdater.CheckForUpdate(serverXmlFile, localXmlFile, out htUpdateFile);
            if (availableUpdate > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}