using System;
using System.Diagnostics;

namespace TorStartupCS
{
    public class ProcessStart
    {
        public Process torProcess = new Process();
        public string tor = Environment.ExpandEnvironmentVariables(@"C:\Users\%USERNAME%\Tor Browser\Browser\TorBrowser\Tor\tor.exe");
        
        //public string tor = ;
        //public string torPath = "C:\\Users\\%USERNAME%\\Tor Browser\\Browser\\TorBrowser\\Tor";

        public ProcessStart()
        {
        }

        public Process ProcessStartUp(Process process, string fileName/*, string filePath*/)
        {
            Process[] processByName;
            try
            {
                
                process.StartInfo.FileName = fileName;
                //process.StartInfo.Arguments = filePath;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.StartInfo.UseShellExecute = false;
                process.Start();
                process.WaitForExit();
                processByName = Process.GetProcessesByName("tor");
                return processByName[0];
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                throw (new System.Exception());

                //Console.WriteLine(ex.Message);
                //return null;
            }

            
        }

        public void ProcessQuit(Process process)
        {
            try
            {
                process.Kill();
                process.Close();
            }
            catch (System.InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

