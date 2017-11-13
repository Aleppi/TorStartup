using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace TorStartupCS
{
    class TorStartupCS
    {
        public static bool running = true;
        public static void Main()
        {
            UserInterface ui = new UserInterface();
            //ProxyToggle pt = new ProxyToggle();
            
            while (running)
            {
                ui.UserOptions();
                string input = ui.UserInput();
                ui.UserMenu(input);
            }
        }
    }
}