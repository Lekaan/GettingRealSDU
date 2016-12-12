using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GettingRealSDU_BL;

namespace GettingRealApp
{
    class MainWindow
    {
        public static string Initials { get; set; }
        public static bool running = true;
    

        static void Main(string[] args)
        {
            Setup.Headder();
            Console.Write("Enter Initials:");
            Initials = Console.ReadLine();
            Rightsselection();

        }


        public static void Rightsselection() {

            DeviceRepository.StaticInstance.CreateDevice("1", "PC-1");
            DeviceRepository.StaticInstance.CreateDevice("2", "PC-2");
            DeviceRepository.StaticInstance.CreateDevice("3", "PC-3");
            DeviceRepository.StaticInstance.CreateDevice("4", "PC-4");
            DeviceRepository.StaticInstance.CreateDevice("5", "PC-5");
            DeviceRepository.StaticInstance.CreateDevice("6", "PC-6");
            DeviceRepository.StaticInstance.CreateDevice("7", "PC-7");
            DeviceRepository.StaticInstance.CreateDevice("8", "PC-8");
            DeviceRepository.StaticInstance.CreateDevice("9", "PC-9");
            DeviceRepository.StaticInstance.CreateDevice("10", "PC-10");
            DeviceRepository.StaticInstance.CreateDevice("11", "PC-11");
            DeviceRepository.StaticInstance.CreateDevice("12", "PC-12");

            
            while (running) 
            {  
                
                Console.Clear();
                Console.WriteLine("Hello " + Initials + " what would you like to login as ?");
                Console.WriteLine("");
                Console.WriteLine("Choice: \n 1:Support  \n 9:Admin \n x for exit program.");
                string Choice = Console.ReadLine();

                switch (Choice)
                {
                    case "1":
                        Console.Clear();
                        SupportWindow.SupportMain();
                        break;

                    case "9":
                        Console.Clear();
                        AdminWindow.MainWindowsAdmin();
                        break;

                    case "x":
                        running = false;
                        break;
                    default:
                        break;

                }
            } 
        

           
       }
    }
}
