using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingRealSDU
{
    class Device
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public Device() { }
        public Device(int id, string name)
        {
            id = Id;
            name = Name;
        }


    }
}
