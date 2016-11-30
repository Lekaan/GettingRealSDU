using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingRealSDU
{
   public class LendingReceipt
    {
        public  string LoanerInfo { get; set; }
        public  string CurrentTime { get; set; }
        public Lending loan { get; set; } 

    
        
        public LendingReceipt(string loanerinfo, string currenttime)
        {
            loanerinfo = LoanerInfo;
            currenttime = CurrentTime;

        }
         public LendingReceipt() { }

        public void CreateLoan(DateTime start, DateTime end, List<Device> devices)
        {
            this.loan = new Lending(start, end, devices);
        }

        public Lending GetLoan()
        {
            return this.loan;
        }




    }
}
