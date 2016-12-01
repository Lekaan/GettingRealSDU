﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GettingRealSDU;
using System.Collections.Generic;

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
            Assert.AreEqual("1", testloan.Devices[0].Id);


        }


        [TestMethod]
        public void EndLoan()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void CannotCreateLoanOfDeviceThatIsAlreadyBorrowed()
        {
            throw new NotImplementedException();
        }
    }
}
