﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GettingRealSDU_BL;
using GettingRealDomain;

namespace GettingRealApp
{

    public static class AdminWindow

    {
        public static void MainWindowsAdmin()
        {
            Setup.Headder();
            Setup.ShowWhoIsLoggedIn();
            bool running = true;

            do
            {
                Console.WriteLine("Choose between: \n 1: Adding Device \n 3: Delete Device \n 4: Return to login option");
                string choice = Console.ReadLine();        

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        AddDevice();
                        Console.ReadKey();
                        break;

                    case "3":
                        Console.Clear();
                        RemoveDevice();
                        Console.ReadKey();
                        break;

                    case "4":
                        running = false;
                        MainWindow.Rightsselection();
                        break;

                }
            } while (running);



        }

        public static void AddDevice()
        {
        
            Console.WriteLine("Insert Id for new pc:");
            string id = Console.ReadLine();
            Console.WriteLine("Insert Name for new pc:");
            string name = Console.ReadLine();

            DeviceRepository.StaticInstance.CreateDevice(id, name);          

            Console.WriteLine(DeviceRepository.StaticInstance.GetDevice(id).DeviceId + DeviceRepository.StaticInstance.GetDevice(id).DeviceName);
        }

        public static void RemoveDevice()
        {
            Console.Clear();
            DeviceRepository.StaticInstance.DeviceList.ForEach(Device => Console.WriteLine(Device));
            Console.WriteLine("Insert Id for the pc you want to remove:");
            string id = Console.ReadLine();         

            DeviceRepository.StaticInstance.DeleteDevice(id);


            Console.Clear();            
            Console.WriteLine("removed Id number {0}", id);
            DeviceRepository.StaticInstance.DeviceList.ForEach(Device => Console.WriteLine(Device));



        }
    }
}
