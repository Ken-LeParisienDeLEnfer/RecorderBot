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
            //Process[] p = Process.GetProcessesByName("microsoft-edge");
            Thread.Sleep(8000);
            //AuthenticateToMyCanal();
            //Process.Start("microsoft-edge:https://www.canalplus.com/live/?channel=451");
            //OpenRecorderExtensionAndLaunch();
            Process.Start(@"C:\\Program Files (x86)\Bandicam\bdcam.exe");
            Thread.Sleep(15000);
            SendKeys.SendWait("{F12}");
            SendKeys.SendWait("%{TAB}");
            Thread.Sleep(2000);
            SendKeys.SendWait("{RIGHT}");
            SendKeys.SendWait("{RIGHT}");
            SendKeys.SendWait("{ENTER}");
        }
    }
}
