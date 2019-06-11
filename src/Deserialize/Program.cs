using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Library;
using Newtonsoft.Json;

namespace Deserialize {
    class Program {
        static void Main(string[] args) {
            // var xml = File.ReadAllText("resource/Generate.xml");
            var xml = File.ReadAllText("resource/Out.xml");
            var element = XElement.Parse(xml);
            var reader = element.CreateReader();
            var serializer = new XmlSerializer(typeof(Envelope));

            var obj = (Envelope)serializer.Deserialize(reader);
            // var json = JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented);
            Console.WriteLine(obj.Body.OrganizationList.Count);
        }
    }
}
