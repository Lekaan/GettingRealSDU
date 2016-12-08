using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingRealDomain
{
  public class Device
    {
        public string Id { get; set; }
        public string Name { get; set; }


        public Device() { }
        public Device(string id, string name)
        {
            Id = id;
            Name = name;
        }


    }
}
