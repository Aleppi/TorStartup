using System;
using System.Diagnostics;

namespace TorStartupCS
{
    public static class ProcessStart
    {
        private static Process torProcess = new Process();
        private static string tor = Environment.ExpandEnvironmentVariables(@"C:\Users\%USERNAME%\Tor Browser\Browser\TorBrowser\Tor\tor.exe");

        public static void ProcessStartUp()
        {
            try
            {
                torProcess.StartInfo.FileName = tor;
                torProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                torProcess.StartInfo.UseShellExecute = false;
                torProcess.Start();
            }
            catch (Exception)
            {
            }
        }

        public static void ProcessQuit()
        {
            Process[] process = Process.GetProcessesByName("tor");
            if (process.Length > 0)
            {
                try
                {
                    for (int i = 0; i < process.Length; i++)
                    {
                        process[i].Kill();
                        process[i].Close();
                    }
                }
                catch (Exception)
                {
                }
            }
        }
    }
}

