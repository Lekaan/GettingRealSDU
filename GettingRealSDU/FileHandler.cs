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


        public XmlDocument devices = new XmlDocument();
        public XmlDocument support = new XmlDocument();

        public void CreateFiles()
        {
            if (!File.Exists("Devices.xml"))
            {
                XmlNode rootNode = devices.CreateElement("Devices");
                devices.AppendChild(rootNode);
                devices.Save("Devices.xml");
            }
            devices.Load("Devices.xml");

            if (!File.Exists("Supporter.xml"))
            {
                XmlNode rootNode = support.CreateElement("Supporter");
                support.AppendChild(rootNode);
                support.Save("Supporter.xml");
            }
            support.Load("Supporter.xml");
        }

        public void CreateDevice(string id, string name)
        {
            if (devices.SelectSingleNode("//" + name) != null)
            {
                Console.WriteLine("Device already exist");
                return;
            }

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

        public void CreateSupporter(string username, string forename, string lastname)
        {
            if (support.SelectSingleNode("//" + username) != null)
            {
                XmlNode supportNode = support.SelectSingleNode("//" + username);
                supportNode.Attributes[0].Value = forename;
                supportNode.Attributes[1].Value = lastname;
            }
            else
            {
                XmlNode rootNode = support.DocumentElement;
                XmlNode supportNode = support.CreateElement(username);

                XmlAttribute attForeName = support.CreateAttribute("ForeName");
                attForeName.Value = forename;
                supportNode.Attributes.Append(attForeName);
                
                XmlAttribute attLastName = support.CreateAttribute("LastName");
                attLastName.Value = lastname;
                supportNode.Attributes.Append(attLastName);

                rootNode.AppendChild(supportNode);
            }

            support.Save("Supporter.xml");
        }
    }
}
