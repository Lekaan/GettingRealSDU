using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GettingRealSDU_BL;
using GettingRealDomain;

namespace GettingRealApp
{
    public static class SupportWindow
    {

        public static void SupportMain()
        {
            bool running = true;
            do
            {
                Console.Clear();
                Setup.Headder();
                Setup.ShowWhoIsLoggedIn();
                Console.WriteLine("Please choose between: \n 1: Create Loan \n 2: Create Reservation   \n 3: Return to role selection");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        Loan();
                        break;
                    case "2":
                        Console.Clear();
                        Reservation();
                        break;

                    case "3":
                        Console.Clear();
                        running = false;
                        MainWindow.Rightsselection();
                        break;

                }
            } while (running);
                           
                           
            
        }


        public static void Loan()
        {
            

            Device device = new Device();
            List<Device> Listofchoosendevices = new List<Device>();
            Lending loan = new Lending();
            LendingReceiptRepository lendingrepo = new LendingReceiptRepository();       
            DeviceRepository dr = new DeviceRepository();

            dr.CreateDevice("1", "PC-1");
            dr.CreateDevice("2", "PC-2");
            dr.CreateDevice("3", "PC-3");
            dr.CreateDevice("4", "PC-4");
            dr.CreateDevice("5", "PC-5");
            dr.CreateDevice("6", "PC-6");
            dr.CreateDevice("7", "PC-7");
            dr.CreateDevice("8", "PC-8");
            dr.CreateDevice("9", "PC-9");
            dr.CreateDevice("10", "PC-10");
            dr.CreateDevice("11", "PC-11");
            dr.CreateDevice("12", "PC-12");

            Setup.Headder();
            Setup.ShowWhoIsLoggedIn();

            Console.WriteLine("Define Lending Period:  Now to dd.mm.yyyy");
            Console.Write("Enter returndate: ");
            DateTime enddate = DateTime.Parse(Console.ReadLine());
              


<<<<<<< HEAD
            dr.DeviceList.ForEach(Device => Console.WriteLine("   "+Device.DeviceId + "  " + Device.Name));
=======
            dr.DeviceList.ForEach(Device => Console.WriteLine(Device.ToString()));
>>>>>>> refs/remotes/origin/master
            string choice = "";


            do
            {
                Console.WriteLine("\n Choose PC to add to Loan, end selection with x");
                choice = Console.ReadLine();
                if (choice != "x")
                {
                    Listofchoosendevices.Add(dr.GetDevice(choice));
<<<<<<< HEAD
                    Listofchoosendevices.ForEach(Device => Console.WriteLine("   " + Device.DeviceId + "  " + Device.Name));
=======
                    Listofchoosendevices.ForEach(Device => Console.WriteLine(Device.ToString()));
>>>>>>> refs/remotes/origin/master
                }

            }while (choice != "x");
            

            Console.WriteLine("You have chosen ");
<<<<<<< HEAD
            Listofchoosendevices.ForEach(Device => Console.WriteLine("   " + Device.DeviceId + "  " + Device.Name));
=======
            Listofchoosendevices.ForEach(Device => Console.WriteLine(Device.ToString()));
>>>>>>> refs/remotes/origin/master

            Console.WriteLine("Enter Name and Email on Person borrowing the/theese device/s.");
            string loanerinfo = Console.ReadLine();
            Console.Write("Enter Casenumber: ");
            string casenumber = Console.ReadLine();

       

            loan.EndDate = enddate;
            loan.StartDate = DateTime.Now;
            loan.Devices = Listofchoosendevices;

            lendingrepo.CreateLendingReceipt(loanerinfo,casenumber,loan, MainWindow.Initials);

            Console.WriteLine("Following Receipt has been created: ");




            Console.WriteLine(lendingrepo.FindReceiptByCasenumber(casenumber).ToString());
                

<<<<<<< HEAD
            lendingrepo.FindReceiptByCasenumber(casenumber).Loan.Devices.ForEach(Device => Console.WriteLine("   " + Device.DeviceId + "  " + Device.Name));
=======
            lendingrepo.FindReceiptByCasenumber(casenumber).Loan.Devices.ForEach(Device => Console.WriteLine(Device.ToString()));
>>>>>>> refs/remotes/origin/master
            lendingrepo.FindReceiptByCasenumber(casenumber).Loan.Status = Lending.Udlaan.Udlaant;
            Console.ReadLine();










        }

        public static void Reservation()
        {
            Setup.Headder();
            Setup.ShowWhoIsLoggedIn();

            Console.WriteLine("Define Lending Period:  Now to dd.mm.yyyy");

            Console.Write("Enter start date: ");
            DateTime startdate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter return date: ");
            DateTime enddate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine(" ");




        }
        






    }
}
