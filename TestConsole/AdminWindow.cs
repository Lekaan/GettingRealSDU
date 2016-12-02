using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GettingRealSDU;

namespace TestConsole
{
   public static class AdminWindow
    {
        public static void MainWindowsAdmin()
        {
            Setup.Headder();
            Setup.ShowWhoIsLoggedIn();
            Console.WriteLine("Choose between: 1: Adding Device \n 3: Delete Device");
            Console.WriteLine("Nice");
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
