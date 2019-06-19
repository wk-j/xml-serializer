using System;
using System.IO;
using System.Xml.Serialization;

namespace Inherit {
    public class A {
        [XmlElement("ProcessID")]
        public string ProcessId { set; get; }

    }

    public class B : A {
        public string ProcessTime { set; get; }
    }

    class Program {
        static void Main(string[] args) {
            var s = new XmlSerializer(typeof(B));
            var stream = new MemoryStream();
            var b = new B {
                ProcessId = "001",
                ProcessTime = "001"
            };

            s.Serialize(stream, b);

            stream.Seek(0, SeekOrigin.Begin);
            var str = new StreamReader(stream).ReadToEnd();

            Console.WriteLine(str);
        }
    }
}
