using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingRealSDU
{
   public class DeviceRepository : IRepository
    {
      public List<Device> DeviceList;      
        
        public DeviceRepository()
        {
            DeviceList = new List<Device>();
        }
        
         

        public Device GetDevice(string id)
        {           
           return DeviceList.Find(Device => Device.Id == id); 
        }

        public List<Device> GetDeviceList()
        {
            return DeviceList;
        }

        public void CreateDevice(string id, string name)
        {     
                      
            DeviceList.Add(new Device(id, name));
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
