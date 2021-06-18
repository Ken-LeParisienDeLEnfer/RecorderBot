using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace CopaAmericaRecorder
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Console.WriteLine("Hello");
            Process.Start("firefox.exe", "https://www.canalplus.com/live/?channel=451");
            Thread.Sleep(8000);
            //AuthenticateToMyCanal();
            //Process.Start("microsoft-edge:https://www.canalplus.com/live/?channel=451");
            //Process.Start(@"C:\\Program Files\obs-studio\bin\64bit\obs64.exe");
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WorkingDirectory = @"C:\Program Files\obs-studio\bin\64bit"; // like cd path command
            startInfo.FileName = "obs64.exe";
            Process.Start(startInfo);
            Thread.Sleep(10000);
            SendKeys.SendWait("$");
            Thread.Sleep(3000);
            SendKeys.SendWait("%{TAB}");
            Thread.Sleep(2000);
            SendKeys.SendWait("{RIGHT}");
            SendKeys.SendWait("{RIGHT}");
            SendKeys.SendWait("{ENTER}");
        }
    }
}
