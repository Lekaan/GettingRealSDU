using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GettingRealSDU;

namespace TestConsole
{
    class MainWindow
    {
        public static string Initials { get; set; }


        static void Main(string[] args)
        {
            Setup.Headder();           
            Console.Write("Enter Initials:");
            Initials = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Hello "+ Initials + " what would you like to login as ?");
            Console.WriteLine("");
            Console.WriteLine("Choice: \n 1:Support  \n 9:Admin");
            string Choice = Console.ReadLine();
            switch (Choice)
            {
                case "1":
                    Console.Clear();
                    SupportWindow.SupportMain();
                    break;

                case "9":
                    Console.Clear();

                    break;
                default:
                    
                    break;

            }            

       }
    }
}
