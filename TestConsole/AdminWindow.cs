using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GettingRealSDU;

namespace TestConsole
{
    class AdminWindow
    {
        public void MainWindowsAdmin()
        {
            Setup.Headder();
            Setup.ShowWhoIsLoggedIn();
            Console.WriteLine("Choose between: 1: Adding Device \n 3: Delete Device");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":



                    break;

                case "3":


                    break;

            }



        }

    }
}
