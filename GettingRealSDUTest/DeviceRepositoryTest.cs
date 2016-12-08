using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GettingRealSDU;
using System.Collections.Generic;


namespace GettingRealSDUTest
{
    
    [TestClass]
    public class DeviceRepositoryTest
    {
        DeviceRepository dr;
        List<Device> TestList;

        [TestInitialize]
        public void Testinitialize()
        {
           dr = new DeviceRepository();
           TestList = new List<Device>();
           TestList.Add(new Device("1", "PC1"));

        }
       

        [TestMethod]
        public void GetDeviceList()
        {      
            dr.CreateDevice("1", "PC1");
            List<Device> DeviceList = dr.GetDeviceList();
            Assert.IsTrue(TestList[0].Name == DeviceList[0].Name);
        }

        [TestMethod]
        public void GetDeviceById()
        {
            dr.CreateDevice("6","PC6");

            Device testdevice = dr.GetDevice("6");
            Assert.IsTrue("PC6" == testdevice.Name);          
        }

        [TestMethod]
        public void CreateDevice()
        {
            dr.CreateDevice("5","PC5");
            Device testdevice = dr.GetDevice("5");

            Assert.IsTrue("5" == testdevice.Id);
            Assert.IsTrue("PC5" == testdevice.Name);
        }
    }
}
