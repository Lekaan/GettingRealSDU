using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GettingRealDomain;

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
        public LendingReceiptRepository()
        {
            lendingReceiptList = new List<LendingReceipt>();
        }


        public void LoadData()
        {
            throw new NotImplementedException();
        }

        public void SaveData()
        {
            throw new NotImplementedException();
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

            foreach (var Lending in Instance.lendingReceiptList)
            {
                if (Lending.Loan.StartDate <= end && start <= Lending.Loan.EndDate)
                {
                    NotAvailable.AddRange(Lending.Loan.Devices);
                    Available = DeviceRepository.StaticInstance.DeviceList.Except<Device>(NotAvailable).ToList();                 
                    
                }
             

            }

            return Available;
        }



    }
}
