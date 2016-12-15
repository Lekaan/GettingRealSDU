using System.Xml.Serialization;
using System.IO;
using GettingRealDomain;
using System.Collections.Generic;
using System.Xml;
using System;

namespace GettingRealDAL
{
    public class XML
    {
        public static void CreateXMLFiles()
        {
            if (!File.Exists("devices.xml"))
            {
                List<Device> DeviceList = new List<Device>();
                XmlDocument xmlDocument = new XmlDocument();
                XmlSerializer serializer = new XmlSerializer(DeviceList.GetType());
                using (MemoryStream stream = new MemoryStream())
                {
                    serializer.Serialize(stream, DeviceList);
                    stream.Position = 0;
                    xmlDocument.Load(stream);
                    xmlDocument.Save("devices.xml");
                    stream.Close();
                }
            }

            if (!File.Exists("lendingreceipt.xml"))
            {
                List<LendingReceipt> lendingReceiptList = new List<LendingReceipt>();
                XmlDocument xmlDocument = new XmlDocument();
                XmlSerializer serializer = new XmlSerializer(lendingReceiptList.GetType());
                using (MemoryStream stream = new MemoryStream())
                {
                    serializer.Serialize(stream, lendingReceiptList);
                    stream.Position = 0;
                    xmlDocument.Load(stream);
                    xmlDocument.Save("lendingreceipt.xml");
                    stream.Close();
                }
            }
        }

        public static void SaveDeviceListToXmlFile(List<Device> DeviceList, string devicesfile)
        {

            if (DeviceList == null) { return; }

            XmlDocument xmlDocument = new XmlDocument();
            XmlSerializer serializer = new XmlSerializer(DeviceList.GetType());
            using (MemoryStream stream = new MemoryStream())
            {
                serializer.Serialize(stream, DeviceList);
                stream.Position = 0;
                xmlDocument.Load(stream);
                xmlDocument.Save(devicesfile);
                stream.Close();
            }
        }

        public static List<Device> LoadDeviceListFromXmlFile(string devicesfile)
        {
            CreateXMLFiles();
            if (string.IsNullOrEmpty(devicesfile)) { return default(List<Device>); }

            List<Device> objectOut = default(List<Device>);

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(devicesfile);
            string xmlString = xmlDocument.OuterXml;

            using (StringReader read = new StringReader(xmlString))
            {
                Type outType = typeof(List<Device>);

                XmlSerializer serializer = new XmlSerializer(outType);
                using (XmlReader reader = new XmlTextReader(read))
                {
                    objectOut = (List<Device>)serializer.Deserialize(reader);
                    reader.Close();
                }

                read.Close();
            }
            return objectOut;
        }

        public static void SaveLendingReceiptToXmlFile(List<LendingReceipt> LendingReceipt, string lendingreceiptfile)
        {
            if (LendingReceipt == null) { return; }

            XmlDocument xmlDocument = new XmlDocument();
            XmlSerializer serializer = new XmlSerializer(LendingReceipt.GetType());
            using (MemoryStream stream = new MemoryStream())
            {
                serializer.Serialize(stream, LendingReceipt);
                stream.Position = 0;
                xmlDocument.Load(stream);
                xmlDocument.Save(lendingreceiptfile);
                stream.Close();
            }
        }

        public static List<LendingReceipt> LoadLendingReceiptFromXmlFile(string lendingreceiptfile)
        {
            CreateXMLFiles();
            if (string.IsNullOrEmpty(lendingreceiptfile)) { return default(List<LendingReceipt>); }

            List<LendingReceipt> objectOut = default(List<LendingReceipt>);

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(lendingreceiptfile);
            string xmlString = xmlDocument.OuterXml;

            using (StringReader read = new StringReader(xmlString))
            {
                Type outType = typeof(List<LendingReceipt>);

                XmlSerializer serializer = new XmlSerializer(outType);
                using (XmlReader reader = new XmlTextReader(read))
                {
                    objectOut = (List<LendingReceipt>)serializer.Deserialize(reader);
                    reader.Close();
                }
                read.Close();
            }
            return objectOut;
        }
    }
}
