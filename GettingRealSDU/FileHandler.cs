using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GettingRealSDU
{
    public class FileHandler
    {


        private XmlDocument devices = new XmlDocument();

        public void CreateFiles()
        {
            if (!File.Exists("Devices.xml"))
            {
                XmlNode rootNode = devices.CreateElement("Devices");
                devices.AppendChild(rootNode);
                devices.Save("Devices.xml");
            }
            devices.Load("Devices.xml");            
        }

        public void CreateDevice(string id, string name)
        {
            XmlNode rootNode = devices.DocumentElement;
            XmlNode deviceNode = devices.CreateElement(name);
            XmlAttribute attId = devices.CreateAttribute("id");
            attId.Value = id;
            deviceNode.Attributes.Append(attId);
            rootNode.AppendChild(deviceNode);


            XmlNode bookingNode = devices.CreateElement("Booking");
            deviceNode.AppendChild(bookingNode);
            devices.Save("Devices.xml");
        }
    }
}
