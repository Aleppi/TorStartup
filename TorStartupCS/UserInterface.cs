using System;
using Microsoft.Win32;

namespace TorStartupCS
{
    public class UserInterface
    {
        public UserInterface()
        {
        }

        public void UserOptions()
        {
            Console.WriteLine("Type 'start' to start Tor.");
            Console.WriteLine("Type 'close' to close Tor.");
            Console.WriteLine("Type 'quit' to quit.");
        }

        public string UserInput()
        {
            string input = Console.ReadLine();
            return input;
        }

        public void UserMenu(string input)
        {
            ProxyToggle pt = new ProxyToggle();
            if (input.ToLower() == "start")
            {
                //Start Tor service here in the future
                //pt.ToggleProxy(pt.CheckProxy(Registry.GetValue(ProxyToggle.keyName, "ProxyEnable", 0)));
                pt.ToggleProxy(pt.CheckProxy(pt.proxyKey.GetValue("ProxyEnable", 0)));
                /*pt.proxyKey.SetValue("ProxyEnable", 1);
                pt.proxyKey.Flush();
                Console.WriteLine(pt.proxyKey.GetValue("ProxyEnable", 0));*/

            }
            else if (input.ToLower() == "close")
            {
                //Close Tor service here in the future
                //pt.ToggleProxy(pt.CheckProxy(Registry.GetValue(ProxyToggle.keyName, "ProxyEnable", 0)));
                pt.ToggleProxy(pt.CheckProxy(pt.proxyKey.GetValue("ProxyEnable", 0)));
                /*pt.proxyKey.SetValue("ProxyEnable", 0);
                pt.proxyKey.Flush();
                Console.WriteLine(pt.proxyKey.GetValue("ProxyEnable", 0));*/
            }
            else if (input.ToLower() == "quit")
            {
                TorStartupCS.running = false;
            }
            else
            {
                Console.WriteLine("Incorrect input.");
            }
        }
    }
}
