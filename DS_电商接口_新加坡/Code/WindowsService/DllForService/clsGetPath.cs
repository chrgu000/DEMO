using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace DllForService
{
    class clsGetPath
    {
        public static string GetWindowsServiceInstallPath(string ServiceName)
        {
            string registData;
            RegistryKey hkml = Registry.LocalMachine;
            RegistryKey software = hkml.OpenSubKey("SYSTEM", true);
            RegistryKey aimdir = software.OpenSubKey("CurrentControlSet\\services\\" + ServiceName, true);
            registData = aimdir.GetValue("ImagePath").ToString();
            return registData;

            ////return @"D:\WorkSpace\工作项目\DS_电商接口_新加坡_u8v12.5\Code\WindowsService\WindowsFormsApplication1\bin\Debug\Config.xml";
            //return @"C:\U8AutoService\Config.xml";
        }
    }
}
