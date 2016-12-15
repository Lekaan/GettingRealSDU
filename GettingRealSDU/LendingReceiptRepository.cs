using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GettingRealDomain;
using GettingRealDAL;

namespace GettingRealSDU_BL
{
    public class LendingReceiptRepository : IRepository
    {
        //Singleton 
        private static readonly LendingReceiptRepository _instance = new LendingReceiptRepository();
        public static LendingReceiptRepository Instance
        {
            get
            {
                return _instance;
            }
        }

        public List<LendingReceipt> lendingReceiptList;
        string LendingReceipts = "lendingreceipt.xml";
        
        public LendingReceiptRepository()
        {
            lendingReceiptList = new List<LendingReceipt>();
           
        }


        public void LoadData()
        {
           Instance.lendingReceiptList= XML.LoadLendingReceiptFromXmlFile(LendingReceipts);
        }

        public void SaveData()
        {
           XML.SaveLendingReceiptToXmlFile(Instance.lendingReceiptList, LendingReceipts);
        }

        public void CreateLendingReceipt(string loanerinfo, string casenumber, Lending loan, string initials)
        {
            Instance.lendingReceiptList.Add(new LendingReceipt(loanerinfo,casenumber,loan, initials));
        }

        public LendingReceipt FindReceiptByCasenumber(string casenumber)
        {
            return  Instance.lendingReceiptList.Find(LendingReceipt => LendingReceipt.Casenumber == casenumber);
        }

        public List<Device> ReturnAvailableDevicesForGivenPeriod(DateTime start, DateTime end)
        {
            List<Device> NotAvailable = new List<Device>();
            List<Device> Available = new List<Device>();
            Available = DeviceRepository.StaticInstance.DeviceList;



            foreach (var LendingReceipt in Instance.lendingReceiptList)
            {
                if (LendingReceipt.Loan.StartDate <= end && start <= LendingReceipt.Loan.EndDate)
                {
                    NotAvailable.AddRange(LendingReceipt.Loan.Devices);                                 
                    
                }             

            }
            Available.RemoveAll(Device1 => NotAvailable.Any(Device => Device.DeviceId == Device1.DeviceId));
            return Available;

        }



    }
}
