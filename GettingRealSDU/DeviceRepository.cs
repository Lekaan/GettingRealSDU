using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingRealSDU
{
    class DeviceRepository : IRepository
    {
        List<Device> DeviceList; 

        public Device GetDevice(int id)
        {
            return 0;
        }

        public List<Device> GetDeviceList()
        {
            return DeviceList;
        }

        public void LoadData()
        {
            throw new NotImplementedException();
        }

        public void SaveData()
        {
            throw new NotImplementedException();
        }
    }
}
