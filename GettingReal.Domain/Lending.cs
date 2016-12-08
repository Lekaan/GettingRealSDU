using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace GettingRealDomain
{
    public class Lending
    {
      public enum Udlaan
        {
            Udlaant,
            Afsluttet,
            IkkeTilbageLeveret,
            Reserveret
        };

        public DateTime StartDate { get; set; }
        public DateTime EndDate   { get; set; }
        public List<Device> Devices;
        public Udlaan Status { get; set; }
  


        public Lending(DateTime startdate, DateTime enddate, List<Device> devices)
        {
            this.StartDate = startdate; 
            this.EndDate = enddate;
            this.Devices = devices;          

        }

        public Lending() { }


    


    }
}
