using System;
using System.Diagnostics;

namespace TorStartupCS
{
    public class ProcessStart
    {
        public Process torProcess = new Process();
        public string tor = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32;C:\Users\%USERNAME%\Tor Browser\Browser\TorBrowser\Tor\tor.exe");
        
        //public string tor = ;
        //public string torPath = "C:\\Users\\%USERNAME%\\Tor Browser\\Browser\\TorBrowser\\Tor";

        public ProcessStart()
        {
        }

        public void ProcessStartUp(Process process, string fileName/*, string filePath*/)
        {
            /*ProcessStartInfo info
    = new ProcessStartInfo(tor);
            info.UseShellExecute = false;*/
            try
            {
                process.StartInfo.FileName = fileName;
                //process.StartInfo.Arguments = filePath;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.StartInfo.UseShellExecute = false;
                process.Start();
                process.WaitForExit();
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ProcessQuit(Process process)
        {
            process.Kill();
            process.Close();
        }
    }
}

