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

        [STAThread]
        static void Main(string[] args)
        {
            // Get the arguments : dateOfRobotStart hourOfRobotStart dateOfRobotEnd hourOfRobotEnd
            DateTime now = DateTime.Now;
            string inputTimeRecording = args[0] + " " + args[1];
            DateTime dateStartRecording = DateTime.ParseExact(inputTimeRecording, "yyyy/MM/dd HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            Console.WriteLine("Time of Recording == {0}", inputTimeRecording);

            string inputEndRecording = args[2] + " " + args[3];
            DateTime dateEndRecording = DateTime.ParseExact(inputEndRecording, "yyyy/MM/dd HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            Console.WriteLine("End of Recording == {0}", inputEndRecording);
            Console.WriteLine("Arguments loaded");

            TimeSpan timestampBeforeRecordingStarts = dateStartRecording - now;
            int millisecondsBeforeRecording = (int)timestampBeforeRecordingStarts.TotalMilliseconds;
            string timeBeforeRecording = string.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms",
                        timestampBeforeRecordingStarts.Hours,
                        timestampBeforeRecordingStarts.Minutes,
                        timestampBeforeRecordingStarts.Seconds,
                        timestampBeforeRecordingStarts.Milliseconds);
            Console.WriteLine("Recording will start in {0}", timeBeforeRecording);

            TimeSpan timestampBetweenStartAndEndOfRecording = dateEndRecording - dateStartRecording;
            int millisecondsBeforeStoppingRecordAfterItStarted = (int)timestampBetweenStartAndEndOfRecording.TotalMilliseconds;
            
            Thread.Sleep(millisecondsBeforeRecording);

            DateTime dateRobotStarting = DateTime.Now;
            Console.WriteLine("{0} - Robot starting", dateRobotStarting);
            Process.Start("firefox.exe", "https://www.canalplus.com/live/tab/favoris");
            Thread.Sleep(10000);
            //Go to the lequipe channel in the favorites tab
            for(int i = 0; i < 25; i++)
            {
                SendKeys.SendWait("{TAB}");
            }
            // Launch lequipe channel
            SendKeys.SendWait("{ENTER}");
            
            // Start OBS Studio
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WorkingDirectory = @"C:\Program Files\obs-studio\bin\64bit"; // like cd path command
            startInfo.FileName = "obs64.exe";
            Process.Start(startInfo);
            Thread.Sleep(15000);
            // Go to the Start Recording button
            SendKeys.SendWait("{TAB}");
            SendKeys.SendWait("{TAB}");
            SendKeys.SendWait("{TAB}");
            SendKeys.SendWait("{TAB}");
            SendKeys.SendWait("{TAB}");
            SendKeys.SendWait("{DOWN}");
            // Launch the record
            SendKeys.SendWait(" ");

            Thread.Sleep(3000);
            // Go to the Mozilla window
            SendKeys.SendWait("%({TAB}{TAB})");
            Thread.Sleep(2000);
            // Full screen
            SendKeys.SendWait("{F11}");

            Thread.Sleep(millisecondsBeforeStoppingRecordAfterItStarted);

            // Go to the OBS Studio window
            SendKeys.SendWait("%({TAB}{TAB})");
            Thread.Sleep(2000);
            SendKeys.SendWait(" ");

            DateTime dateRobotStopping = DateTime.Now;
            Console.WriteLine("{0} - Robot stopped", dateRobotStopping);
        }
    }
}
