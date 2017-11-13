using System;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace TorStartupCS
{
    internal class InternetSetOptionApi
    {
        [DllImport("wininet.dll")]
        public static extern bool InternetSetOption(IntPtr hInternet, int dwOption, IntPtr lpBuffer, int dwBufferLength);
        public const int INTERNET_OPTION_SETTINGS_CHANGED = 39;
        public const int INTERNET_OPTION_REFRESH = 37;
        static bool settingsReturn, refreshReturn;

        public static void RefreshWinInetProxySettings()
        {
            settingsReturn = InternetSetOption(IntPtr.Zero, INTERNET_OPTION_SETTINGS_CHANGED, IntPtr.Zero, 0);
            refreshReturn = InternetSetOption(IntPtr.Zero, INTERNET_OPTION_REFRESH, IntPtr.Zero, 0);
        }
    }
    public class ProxyToggle
    {

        public RegistryKey proxyKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Internet Settings");
        /*public const string userRoot = "HKEY_CURRENT_USER";
        public const string subKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Internet Settings";
        public const string keyName = userRoot + "\\" + subKey;
        */
        ProcessStart ps = new ProcessStart();
        
        public ProxyToggle()
	    {
	    }

        

        public bool CheckProxy(System.Object regValue)
        {
            bool proxyOn;
            if ((int)regValue == 1)
            {
                proxyOn = true;
            }
            else
            {
                proxyOn = false;
            }
            return proxyOn;
        }

        public bool ToggleProxy(bool proxyOn)
        {
            if (proxyOn == false)
            {
                ps.ProcessStartUp(ps.torProcess, ps.tor/*, ps.torPath*/);
                proxyKey.SetValue("ProxyEnable", 1);
                proxyKey.Flush();
                InternetSetOptionApi.RefreshWinInetProxySettings();
            }
            else
            {
                proxyKey.SetValue("ProxyEnable", 0);
                proxyKey.Flush();
                InternetSetOptionApi.RefreshWinInetProxySettings();
                ps.ProcessQuit(ps.torProcess);
                //Console.WriteLine("Proxy is already enabled.")
            }
            return proxyOn;
        }

        /*public bool ProxyOff(bool proxyOn)
        {
            if (proxyOn == true)
            {
                Registry.SetValue(keyName, "ProxyEnable", 0, RegistryValueKind.DWord);
            }
            else
            {
                Console.WriteLine("Proxy is already disabled.");
            }
            return proxyOn;
        }
        */
    }
}
