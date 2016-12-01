using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GettingRealSDU
{
    public class DeviceRepository : IRepository
    {
        List<Device> deviceList = new List<Device>();

        string list;

        String deviceName;
        public string GetDevice(string id)
        {
            XmlDocument xd = new XmlDocument();
            FileStream devicefile = new FileStream("ITServiceDeviceFile.xml", FileMode.Open);
            xd.Load(devicefile);

            XmlNodeList XmlNode = xd.GetElementsByTagName("Computer");

            for (int i = 0; i < XmlNode.Count; i++)
            {
                XmlElement add = (XmlElement)xd.GetElementsByTagName("Name")[i];
                XmlElement cl = (XmlElement)xd.GetElementsByTagName("ID")[i];

                if (cl.GetAttribute("ID") == id)
                {
                    deviceName = add.InnerText;
                    break;
                }
            }
            return deviceName;
            //devicefile.Close();
        }



        public string GetDeviceList()
        {
            //string list;
            StringBuilder builder = new StringBuilder();

            XmlDocument xd = new XmlDocument();
            FileStream devicefile = new FileStream("ITServiceDeviceFile.xml", FileMode.Open);
            xd.Load(devicefile);

            XmlNodeList XmlNode = xd.GetElementsByTagName("Computer");

            foreach  (var node in XmlNode)
            {
                list = builder.Append(node).ToString();
            }
            return list;
            //devicefile.Close();
            
        }

        public void CreateDevice(string id, string name)
        {
            //DeviceList.Add(new Device(id, name));
            // laver en xml fil med Devices som root element
            if (!File.Exists("ITServiceDeviceFile.xml"))
            {
                XmlTextWriter devices;
                devices = new XmlTextWriter("ITServiceDeviceFile.xml", Encoding.UTF8);
                devices.WriteStartDocument();
                devices.WriteStartElement("Devices");
                devices.WriteEndElement();
                devices.Close();
            }

            XmlDocument xd = new XmlDocument();
            FileStream devicefile = new FileStream("ITServiceDeviceFile.xml", FileMode.Open);
            xd.Load(devicefile);
            XmlElement computerelement = xd.CreateElement("Computer");
            computerelement.SetAttribute("Name", name);
            computerelement.SetAttribute("ID", id);
            xd.DocumentElement.AppendChild(computerelement);
            devicefile.Close();
            xd.Save("ITServiceDeviceFile.xml");
        }

        public void RemoveDevice(string id)
        {
            FileStream deviceFile = new FileStream("ITServiceDeviceFile.xml", FileMode.Open);
            XmlDocument xd = new XmlDocument();
            xd.Load(deviceFile);
            XmlNodeList list = xd.GetElementsByTagName("Computer");
            for (int i = 0; i < list.Count; i++)
            {
                XmlElement cl = (XmlElement)xd.GetElementsByTagName("Computer")[i];
                if (cl.GetAttribute("ID") == id)
                {
                    xd.DocumentElement.RemoveAllAttributes();
                }
            }
            deviceFile.Close();
            xd.Save("ITServiceDeviceFile.xml");
        }


        public void LoadData()
        {
        }
        public void SaveData()
        {
        }
    }
}