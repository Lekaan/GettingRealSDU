using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingRealDomain
{
  public class Device
    {
        public string DeviceId { get; set; }
        public string DeviceName { get; set; }


        public Device() { }
        public Device(string deviceid, string name)
        {
            DeviceId = deviceid;
            DeviceName = name;
        }

        public override string ToString()
        {
            return "Id: " + DeviceId+ "  Name: " + DeviceName;
        }


    }
}
