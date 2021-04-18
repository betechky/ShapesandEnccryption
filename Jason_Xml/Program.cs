using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Jason_Xml
{
    public class Item
    {
        public string id { set; get; }
        public string label { set; get; }
    }

    public class Menu
    {
        public string header { set; get; }
        public List<Item> items { set; get; }
    }

    public class Top
    {
        public Menu menu { set; get; }

        public void Print()
        {
            Console.WriteLine(menu.header);

            foreach (var item in menu.items)
            {
                Console.WriteLine("\t");

                if (item != null)
                {
                    if (item.id != null)
                        Console.Write(" id = " + item.id);
                    if (item.label != null)
                        Console.Write(" label = " + item.label);
                }
                else
                {
                    Console.WriteLine("\t null");
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
     
            // string json = Console.ReadLine();
            string json = File.ReadAllText("data.json");
            // Console.WriteLine($"json : {json}");

            //Top obj = JsonConvert.DeserializeObject<Top>(json);
            //obj.Print();

            Top obj = JsonConvert.DeserializeObject<Top>(json);
            obj.Print();

            Console.WriteLine("\n==========================================\n");

            XmlDocument xmlDoc = JsonConvert.DeserializeXmlNode(json);
            // xmlDoc.Save("data.xml");
            xmlDoc.Save(Console.Out);
            // IDisposable
            using (StringWriter sw = new StringWriter(new StringBuilder()))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Top));
                xmlSerializer.Serialize(sw, obj);
                File.WriteAllText("data2.xml", sw.ToString());
            }

            string xmlString = File.ReadAllText("data2.xml");
            Top objFromXml = new Top();
            using (StringReader sr = new StringReader(xmlString))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Top));
                objFromXml = (Top)xmlSerializer.Deserialize(sr); // as Top
            }
            Console.WriteLine("\n================= Obj 2 from XML =========================\n");
            //objFromXml.Print();


            ToXml(obj, "dddd.xml");

            Top objFromXml2 = FromXml<Top>("dddd.xml");
            objFromXml2.Print();

            Console.WriteLine("\n================= Shapes =========================\n");



        }
        public static void ToXml<T>(T obj, string path)
        {
            using (StringWriter sw = new StringWriter(new StringBuilder()))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                xmlSerializer.Serialize(sw, obj);
                File.WriteAllText(path, sw.ToString());
            }
        }

        public static T FromXml<T>(string path)
        {
            string xmlString = File.ReadAllText(path);
            using (StringReader sr = new StringReader(xmlString))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Top));
                return (T)xmlSerializer.Deserialize(sr);
            }
        }


    }
}

