using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GettingRealSDU_BL;
using System.Collections.Generic;
using GettingRealDomain;

namespace GettingRealSDUTest
{
    [TestClass]
    public class LendingReceiptRepositoryTest
    {
        DeviceRepository dr = new DeviceRepository();
        LendingReceipt lr = new LendingReceipt();
        LendingReceiptRepository lrr = new LendingReceiptRepository();

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

            lrr.CreateLendingReceipt(loanerinfo,casenumber,loan);

            Assert.AreEqual(casenumber,lrr.lendingReceiptList[0].Casenumber);


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

            lrr.CreateLendingReceipt(loanerinfo, casenumber, loan);

            string Casenumber = "Søren-1234";
            LendingReceipt lendingreceipt = lrr.FindReceiptByCasenumber(Casenumber);


            DateTime startdate = new DateTime(2017, 11, 30);
            Assert.AreEqual(startdate, lendingreceipt.Loan.StartDate);



        }

        [TestMethod]
        public void CannotCreateLoanOfDeviceThatIsAlreadyBorrowed()
        {
            throw new NotImplementedException();
        }
    }
}
