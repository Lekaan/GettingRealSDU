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
        public  DateTime CurrentTime { get; set; }
        public Lending Loan { get; set; } 
        public string Casenumber { get; set; }

    
        
        public LendingReceipt(string loanerinfo, string casenumber, Lending loan)
        {
            loanerinfo = LoanerInfo;           
            this.Casenumber = casenumber;
            this.Loan= loan;
            this.CurrentTime = DateTime.Now;

        }
         public LendingReceipt() { }

        public void CreateLoan(DateTime start, DateTime end, List<Device> devices)
        {
            this.Loan = new Lending(start, end, devices);
        }

        public Lending GetLoan()
        {
            return this.Loan;
        }

        public void EndLoan()
        {
            this.Loan.Status = Lending.Udlaan.Afsluttet;
        }




    }
}
