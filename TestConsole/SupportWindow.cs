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
            bool running2 = true;
            while (running2)
            {
                Console.Clear();
                Setup.Headder();
                Setup.ShowWhoIsLoggedIn();
                Console.WriteLine("Please choose between: \n 1: Create Loan \n 2: Create Reservation \n 3: Show all current Loans \n 4: Return to role selection");
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
                        ShowLoanerReceipt();
                        break; 

                    case "4":
                        Console.Clear();
                        running2 = false;
                        MainWindow.Rightsselection();
                        break;
                }
            } 
                           
                           
            
        }


        public static void Loan()
        {
            

            Device device = new Device();
            List<Device> Listofchoosendevices = new List<Device>();
            Lending loan = new Lending();
              
           

            Setup.Headder();
            Setup.ShowWhoIsLoggedIn();

            Console.WriteLine("Define Lending Period:  Now to dd.mm.yyyy");
            Console.Write("Enter returndate: ");
            DateTime enddate = DateTime.Parse(Console.ReadLine());


            Console.WriteLine("Available PC: \n");
            List<Device> available = LendingReceiptRepository.Instance.ReturnAvailableDevicesForGivenPeriod(DateTime.Now,enddate);
            available.ForEach(Device => Console.WriteLine(Device.ToString()));
          

            string choice = "";


            do
            {
                Console.WriteLine("\n Choose PC to add to Loan, end selection with x");
                choice = Console.ReadLine();
                if (choice != "x")
                {
                    Listofchoosendevices.Add(DeviceRepository.StaticInstance.GetDevice(choice));
                    Listofchoosendevices.ForEach(Device => Console.WriteLine(Device.ToString()));

                }

            }while (choice != "x");
            

            Console.WriteLine("You have chosen ");

            Listofchoosendevices.ForEach(Device => Console.WriteLine(Device.ToString()));


            Console.WriteLine("Enter Name and Email on Person borrowing the/theese device/s.");
            string loanerinfo = Console.ReadLine();
            Console.Write("Enter Casenumber: ");
            string casenumber = Console.ReadLine();

       

            loan.EndDate = enddate;
            loan.StartDate = DateTime.Now;
            loan.Devices = Listofchoosendevices;

            LendingReceiptRepository.Instance.CreateLendingReceipt(loanerinfo,casenumber,loan, MainWindow.Initials);

            Console.WriteLine("Following Receipt has been created: ");

            Console.WriteLine(LendingReceiptRepository.Instance.FindReceiptByCasenumber(casenumber).ToString());        
            LendingReceiptRepository.Instance.FindReceiptByCasenumber(casenumber).Loan.Devices.ForEach(Device => Console.WriteLine(Device.ToString()));
            LendingReceiptRepository.Instance.FindReceiptByCasenumber(casenumber).Loan.Status = Lending.Udlaan.Udlaant;
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

            Console.WriteLine("Available PC: \n");
            List<Device> available = LendingReceiptRepository.Instance.ReturnAvailableDevicesForGivenPeriod(startdate, enddate);
            available.ForEach(Device => Console.WriteLine(Device.ToString()));
            Console.ReadLine();

            Device device = new Device();
            List<Device> Listofchoosendevices = new List<Device>();
            Lending loan = new Lending();

            string choice2 = "";
            do
            {
                Console.WriteLine("\n Choose PC to add to Loan, end selection with x");
                choice2 = Console.ReadLine();
                if (choice2 != "x")
                {
                    Listofchoosendevices.Add(DeviceRepository.StaticInstance.GetDevice(choice2));
                    Listofchoosendevices.ForEach(Device => Console.WriteLine(Device.ToString()));

                }

            } while (choice2 != "x");
            

            Console.WriteLine("You have chosen ");

            Listofchoosendevices.ForEach(Device => Console.WriteLine(Device.ToString()));


            Console.WriteLine("Enter Name and Email on Person borrowing the/theese device/s.");
            string loanerinfo = Console.ReadLine();
            Console.Write("Enter Casenumber: ");
            string casenumber = Console.ReadLine();



            loan.EndDate = enddate;
            loan.StartDate = DateTime.Now;
            loan.Devices = Listofchoosendevices;

            LendingReceiptRepository.Instance.CreateLendingReceipt(loanerinfo, casenumber, loan, MainWindow.Initials);

            Console.WriteLine("Following Receipt has been created: ");

            Console.WriteLine(LendingReceiptRepository.Instance.FindReceiptByCasenumber(casenumber).ToString());
            LendingReceiptRepository.Instance.FindReceiptByCasenumber(casenumber).Loan.Devices.ForEach(Device => Console.WriteLine(Device.ToString()));
            LendingReceiptRepository.Instance.FindReceiptByCasenumber(casenumber).Loan.Status = Lending.Udlaan.Reserveret;
            Console.ReadLine();


        }

        public static void ShowLoanerReceipt()
        {
           foreach( var LendingReceipt in LendingReceiptRepository.Instance.lendingReceiptList)
            {
                Console.WriteLine(LendingReceipt.ToString());
                Console.WriteLine("Devices borrowed");
                LendingReceipt.Loan.Devices.ForEach(Device => Console.WriteLine(Device.ToString()));
                Console.WriteLine();
            }
            Console.ReadLine();                          

        }    
                
    }
}
