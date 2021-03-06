﻿using System;
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
    public static class ProxyToggle
    {

        public static RegistryKey proxyKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Internet Settings");

        public static void ProxyOn()
        {
            if (proxyKey.GetValue("ProxyServer") == null)
            {
                proxyKey.SetValue("ProxyServer", "socks=127.0.0.1:9050", RegistryValueKind.String);
            }
            else if (!proxyKey.GetValue("ProxyServer").ToString().Contains("socks=127.0.0.1:9050"))
            {
                proxyKey.SetValue("ProxyServer", proxyKey.GetValue("ProxyServer").ToString() + ";socks=127.0.0.1:9050", RegistryValueKind.String);
            }
            proxyKey.SetValue("ProxyEnable", 1, RegistryValueKind.DWord);
            proxyKey.Flush();
            InternetSetOptionApi.RefreshWinInetProxySettings();
        }

        public static void ProxyOff()
        {
            if (proxyKey.GetValue("ProxyServer") == null)
                return;

            string proxyServer = proxyKey.GetValue("ProxyServer").ToString();

            if (proxyKey.GetValue("ProxyServer").ToString().Contains(";socks=127.0.0.1:9050"))
            {
                proxyKey.SetValue("ProxyServer", proxyServer.Remove(proxyServer.Length - 21), RegistryValueKind.String);
            }
            else if (proxyKey.GetValue("ProxyServer").ToString().Contains("socks=127.0.0.1:9050"))
            {
                proxyKey.DeleteValue("ProxyServer");
                proxyKey.SetValue("ProxyEnable", 0, RegistryValueKind.DWord);
            }
            proxyKey.Flush();
            InternetSetOptionApi.RefreshWinInetProxySettings();
        }
    }
}
