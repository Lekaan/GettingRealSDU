using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GettingRealSDU_BL;
using System.Collections.Generic;
using GettingRealDomain;
 


namespace GettingRealSDUTest
{
    [TestClass]
    public class LendingReceiptTest
    {
    
        

    
         LendingReceipt lr = new LendingReceipt();
         DeviceRepository dr = new DeviceRepository();    

      



        [TestMethod]
        public void CreateLoan()
        {
            

            DateTime start = new DateTime(2016,11,30);
            DateTime slut = new DateTime(2016,12,3);

            Device device = new Device("1", "Pelle");
            List<Device> listdevice = new List<Device>();
            listdevice.Add(device);


            lr.CreateLoan(start, slut, listdevice);
            Lending testloan = lr.GetLoan();

            

            Assert.AreEqual(start, testloan.StartDate);
            Assert.AreEqual(slut, testloan.EndDate);
            Assert.AreEqual("1", testloan.Devices[0].DeviceId);
      



        }


        [TestMethod]
        public void CanSetStatus()
        {
            DateTime start = new DateTime(2016, 11, 30);
            DateTime slut = new DateTime(2016, 12, 3);

            Device device = new Device("1", "Pelle");
            List<Device> listdevice2 = new List<Device>();
            listdevice2.Add(device);

            lr.CreateLoan(start, slut, listdevice2);
            Lending testloan2 = lr.GetLoan();


            lr.SetStatusLoan("Afsluttet");

            Assert.AreEqual(Lending.Udlaan.Afsluttet, testloan2.Status);          


        }

       
    }
}
