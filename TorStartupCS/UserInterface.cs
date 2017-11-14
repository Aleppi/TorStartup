using System;
using Microsoft.Win32;
using System.Diagnostics;

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
                //Process[] processByName = Process.GetProcessesByName("tor");
                //Console.WriteLine(processByName);
                pt.ToggleProxy(pt.CheckProxy(pt.proxyKey.GetValue("ProxyEnable", 0)));
            }
            else if (input.ToLower() == "close")
            {
                pt.ToggleProxy(pt.CheckProxy(pt.proxyKey.GetValue("ProxyEnable", 0)));
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
