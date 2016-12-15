using System.Xml.Serialization;
using System.IO;
using GettingRealDomain;
using System.Collections.Generic;

namespace GettingRealDAL
{
    public class XML
    {
        public static void SaveDeviceListToXmlFile(List<Device> DeviceList, string deviceListFile)
        {
            var serializer = new XmlSerializer(typeof(List<Device>));
            using (var stream = File.OpenWrite(deviceListFile))
            {
                serializer.Serialize(stream, DeviceList);
            }

        }
        public static List<Device> LoadDeviceListFromXmlFile(string deviceListFile)
        {
            List<Device> DeviceList = new List<Device>();
            var serializer = new XmlSerializer(typeof(List<Device>));
            using (var stream = File.OpenRead(deviceListFile))
            {
                var other = (List<Device>)(serializer.Deserialize(stream));
                DeviceList.Clear();
                DeviceList.AddRange(other);
            }
            return DeviceList;
        }


        public static void SaveLendingReceiptListToXmlFile(List<LendingReceipt> lendingReceiptList, string lendingReceiptListFile)
        {
            var serializer = new XmlSerializer(typeof(List<LendingReceipt>));
            using (var stream = File.OpenWrite(lendingReceiptListFile))
            {
                serializer.Serialize(stream, lendingReceiptList);
            }

        }
        public static void LoadLendingReceiptListFromXmlFile(List<LendingReceipt> lendingReceiptList, string lendingReceiptListFile)
        {
            var serializer = new XmlSerializer(typeof(List<LendingReceipt>));
            using (var stream = File.OpenRead(lendingReceiptListFile))
            {
                var other = (List<LendingReceipt>)(serializer.Deserialize(stream));
                lendingReceiptList.Clear();
                lendingReceiptList.AddRange(other);
            }
        }


        public static void SaveLendingListToXmlFile(List<Lending> lendingList, string lendingListFile)
        {
            var serializer = new XmlSerializer(typeof(List<Lending>));
            using (var stream = File.OpenWrite(lendingListFile))
            {
                serializer.Serialize(stream, lendingList);
            }

        }
        public static void LoadLendingListFromXmlFile(List<Lending> lendingList, string lendingListFile)
        {
            var serializer = new XmlSerializer(typeof(List<Lending>));
            using (var stream = File.OpenRead(lendingListFile))
            {
                var other = (List<Lending>)(serializer.Deserialize(stream));
                lendingList.Clear();
                lendingList.AddRange(other);
            }
        }
    }
}
