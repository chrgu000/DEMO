using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Honeywell.DataCollection.WinCE.Decoding;
//using CoreSoft.SmartClass;
//using CoreSoft.Smart.SmartClass;

namespace Smartclient
{
    public class HoneyWellBarCode
    {
        // private static Honeywell.DataCollection.WinCE.Decoding.DecodeControl decodeControl1;

        private static DecodeControl decodeControl1;
        public static TextBox TargetTextBox { get; set; }

        public static void InitBarCode()
        {
            try
            {
                decodeControl1 = new Honeywell.DataCollection.WinCE.Decoding.DecodeControl();
                decodeControl1.AimerTimeout = 0;
                decodeControl1.AimIDDisplay = false;
                decodeControl1.AutoScan = true;
                decodeControl1.CodeIDDisplay = false;
                decodeControl1.Location = new System.Drawing.Point(51, 117);
                decodeControl1.ModifierDisplay = false;
                decodeControl1.Multiline = true;
                decodeControl1.Name = "decodeControl1";
                decodeControl1.Size = new System.Drawing.Size(166, 40);
                decodeControl1.TabIndex = 56;
                decodeControl1.TabStop = false;
                decodeControl1.Text = "decodeControl1";
                decodeControl1.VirtualKeyMode = false;
                decodeControl1.Visible = false;
                decodeControl1.DecodeEvent += new Honeywell.DataCollection.Decoding.DecodeBase.DecodeEventHandler(decodeControl1_DecodeEvent);
            }
            catch
            {
            }
        }

        static void decodeControl1_DecodeEvent(object sender, Honeywell.DataCollection.Decoding.DecodeBase.DecodeEventArgs e)
        {
            if (TargetTextBox != null)
            {
                string code = e.DecodeResults.pchMessage; ;
                code = code.Replace("*", "");
                TargetTextBox.Text = code;
            }
        }
    }
}
