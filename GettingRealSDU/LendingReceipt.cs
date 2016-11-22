using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingRealSDU
{
    class LendingReceipt
    {
        public  string LoanerInfo { get; set; }
        public  string CurrentTime { get; set; }

        public LendingReceipt(string loanerinfo, string currenttime)
        {
            loanerinfo = LoanerInfo;
            currenttime = CurrentTime;

        }
         public LendingReceipt() { }






    }
}
