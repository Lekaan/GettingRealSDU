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
        public string Name { get; set; }


        public Device() { }
        public Device(string deviceId, string name)
        {
            DeviceId = deviceId;
            Name = name;
        }


    }
}
