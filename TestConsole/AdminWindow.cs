using System;
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
            Console.WriteLine("Choose between: 1: Adding Device \n 3: Delete Device");
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

            }



        }

        public static void AddDevice()
        {
            DeviceRepository dr = new DeviceRepository();
            Console.WriteLine("Insert Id for new pc:");
            string id = Console.ReadLine();
            Console.WriteLine("Insert Name for new pc:");
            string name = Console.ReadLine();
            
            dr.CreateDevice(id, name);
            

            Console.WriteLine(dr.GetDevice(id).DeviceId + dr.GetDevice(id).DeviceName);
        }

        public static void RemoveDevice()
        {
            DeviceRepository dr = new DeviceRepository();

            Console.WriteLine("Insert Id for the pc you want to remove:");
            string id = Console.ReadLine();

            dr.DeleteDevice(id);

            Console.WriteLine("removed Id number {0}", id);
       

        }
    }
}
