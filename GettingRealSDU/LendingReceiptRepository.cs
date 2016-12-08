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
        public List<LendingReceipt> lendingReceiptList = new List<LendingReceipt>();

        

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
            lendingReceiptList.Add(new LendingReceipt(loanerinfo,casenumber,loan, initials));
        }

        public LendingReceipt FindReceiptByCasenumber(string casenumber)
        {
            return lendingReceiptList.Find(LendingReceipt => LendingReceipt.Casenumber == casenumber);
        }

        
    }
}
