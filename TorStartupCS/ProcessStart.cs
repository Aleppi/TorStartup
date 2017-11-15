using System;
using System.Diagnostics;

namespace TorStartupCS
{
    public class ProcessStart
    {
        public Process torProcess = new Process();
        public string tor = Environment.ExpandEnvironmentVariables(@"C:\Users\%USERNAME%\Tor Browser\Browser\TorBrowser\Tor\tor.exe");
        
        public ProcessStart()
        {
        }

        public void ProcessStartUp(Process process, string fileName)
        {
            try
            {
                
                process.StartInfo.FileName = fileName;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.StartInfo.UseShellExecute = false;
                process.Start();
            }
            catch (System.ComponentModel.Win32Exception)
            {
                throw (new System.Exception());
            }

            
        }

        public void ProcessQuit()
        {
            Process[] process = Process.GetProcessesByName("tor");
            try
            {
                process[0].Kill();
                process[0].Close();
            }
            catch (System.InvalidOperationException)
            {
                throw (new System.Exception());
            }
        }
    }
}

