using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace GettingRealSDU
{
    public class Lending
    {        
        public DateTime StartDate { get; set; }
        public DateTime EndDate   { get; set; }
        public List<Device> Devices = new List<Device>();


        public Lending(DateTime startdate, DateTime enddate, List<Device> devices)
        {
            this.StartDate = startdate; 
            this.EndDate = enddate;
            Devices = devices;
        }
        public Lending() { }





    }
}
