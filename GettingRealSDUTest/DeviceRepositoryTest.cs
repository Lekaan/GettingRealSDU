using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GettingRealSDU_BL;
using System.Collections.Generic;
using GettingRealDomain;


namespace GettingRealSDUTest
{
    
    [TestClass]
    public class DeviceRepositoryTest
    {
       
        List<Device> TestList;

        [TestInitialize]
        public void Testinitialize()
        {
            
           TestList = new List<Device>();
           TestList.Add(new Device("1", "PC1"));

        }
       

        [TestMethod]
        public void GetDeviceList()
        {      
            DeviceRepository.StaticInstance.CreateDevice("1", "PC1");
            List<Device> DeviceList = DeviceRepository.StaticInstance.GetDeviceList();
            Assert.IsTrue(TestList[0].DeviceName == DeviceList[0].DeviceName);
        }

        [TestMethod]
        public void GetDeviceById()
        {
            DeviceRepository.StaticInstance.CreateDevice("6","PC6");

            Device testdevice = DeviceRepository.StaticInstance.GetDevice("6");
            Assert.IsTrue("PC6" == testdevice.DeviceName);          
        }

        [TestMethod]
        public void CreateDevice()
        {
            DeviceRepository.StaticInstance.CreateDevice("5","PC5");
            Device testdevice = DeviceRepository.StaticInstance.GetDevice("5");

            Assert.IsTrue("5" == testdevice.DeviceId);
            Assert.IsTrue("PC5" == testdevice.DeviceName);
        }
    }
}
