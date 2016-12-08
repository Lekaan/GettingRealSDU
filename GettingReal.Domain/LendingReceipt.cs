using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingRealDomain
{
   public class LendingReceipt
    {
        public  string LoanerInfo { get; set; }
        public  DateTime CurrentTime { get; set; }
        public  Lending Loan { get; set; } 
        public  string Casenumber { get; set; }
        public  string Initials { get; set; }

    
        
        public LendingReceipt(string loanerinfo, string casenumber, Lending loan, string initials)
        {
            this.LoanerInfo = loanerinfo;           
            this.Casenumber = casenumber;
            this.Loan= loan;
            this.CurrentTime = DateTime.Now;
            this.Initials = initials;
            

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

        public void SetStatusLoan(string status)
        {
      
            switch (status)
            {
                case ("Afsluttet"):
                    this.Loan.Status = Lending.Udlaan.Afsluttet;
                    break;

                case ("IkkeTilbageLeveret"):
                    this.Loan.Status = Lending.Udlaan.IkkeTilbageLeveret;
                    break;

                case ("Reserveret"):
                    this.Loan.Status = Lending.Udlaan.Reserveret;
                    break;

                case ("Udlaant"):
                    this.Loan.Status = Lending.Udlaan.Udlaant;
                    break;

                default:
                    break;

            }
      

        }

        public override string ToString()
        {
            return "Casenumber: " + Casenumber + " "
                + "From: " + CurrentTime + " "
                + "To: " + Loan.EndDate + " "
                + "Created by: " + Initials + " "
                + "Borrowes by: " + LoanerInfo + " \n  ";    
                              
                              
        }




    }
}
