
/*
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
            ProcessStart ps = new ProcessStart();
            if (input.ToLower() == "start")
            {
                ps.ProcessStartUp(ps.torProcess, ps.tor);
                pt.ProxyOn();
            }
            else if (input.ToLower() == "close")
            {
                pt.ProxyOff();
                ps.ProcessQuit();
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
*/
