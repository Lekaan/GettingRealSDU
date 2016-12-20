using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GettingRealSDU_BL;
using System.Collections.Generic;
using GettingRealDomain;
using System.Linq;

namespace GettingRealSDUTest
{
    [TestClass]
    public class LendingReceiptRepositoryTest
    {
        
        LendingReceipt lr = new LendingReceipt();
  

        [TestMethod]
        public void TestCreateLendingReceipt()
        {
            DateTime start = new DateTime(2017, 11, 30);
            DateTime slut = new DateTime(2017, 12, 3);

            Device device = new Device("22", "Pelle");
            List<Device> listdevice5 = new List<Device>();
            listdevice5.Add(device);

            lr.CreateLoan(start, slut, listdevice5);
            Lending loan = lr.GetLoan();
            string casenumber = "Søren-1234";

            string loanerinfo = "Søren";

            LendingReceiptRepository.Instance.CreateLendingReceipt(loanerinfo,casenumber,loan, "Pelle");
            Assert.AreEqual(casenumber,LendingReceiptRepository.Instance.lendingReceiptList[0].Casenumber);

        }

        [TestMethod]
        public void FindLendingReceiptByCaseNumber()
        {
            DateTime start = new DateTime(2017, 11, 30);
            DateTime slut = new DateTime(2017, 12, 3);

            Device device = new Device("22", "Pelle");
            List<Device> listdevice5 = new List<Device>();
            listdevice5.Add(device);

            lr.CreateLoan(start, slut, listdevice5);
            Lending loan = lr.GetLoan();
            string casenumber = "Søren-1234";
            string loanerinfo = "Søren";

            LendingReceiptRepository.Instance.CreateLendingReceipt(loanerinfo, casenumber, loan, "Pelle");

            string Casenumber = "Søren-1234";
            LendingReceipt lendingreceipt = LendingReceiptRepository.Instance.FindReceiptByCasenumber(Casenumber);


            DateTime startdate = new DateTime(2017, 11, 30);
            Assert.AreEqual(startdate, lendingreceipt.Loan.StartDate);

        }

        [TestMethod]
        public void ReturnAvailableDevicesfortimeperiod()
        {   
            Device devicePelle = new Device("1", "Pelles-PC");
            List<Device> PelleDevicelist = new List<Device>();

            DeviceRepository.StaticInstance.DeviceList.Add(devicePelle);
            PelleDevicelist.Add(devicePelle);

            DateTime start = new DateTime(2017, 11, 30);
            DateTime slut = new DateTime(2017, 12, 3);

            lr.CreateLoan(start, slut, PelleDevicelist);
            Lending loanSøren = lr.GetLoan();      
          
            LendingReceiptRepository.Instance.CreateLendingReceipt("Søren Hansen Søren@mail.com", "Søren-1234", loanSøren, "Pelle");
            Assert.IsFalse(LendingReceiptRepository.Instance.ReturnAvailableDevicesForGivenPeriod(start, slut).Contains(devicePelle));      
                    
        }
    }
}
