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
        
        
        public ProxyToggle()
	    {
	    }


        public void ProxyOn()
        {
            proxyKey.SetValue("ProxyEnable", 1);
            proxyKey.Flush();
            InternetSetOptionApi.RefreshWinInetProxySettings();
        }

        public void ProxyOff()
        {
            proxyKey.SetValue("ProxyEnable", 0);
            proxyKey.Flush();
            InternetSetOptionApi.RefreshWinInetProxySettings();
        }
    }
}
