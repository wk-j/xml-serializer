using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Library;

namespace Namespace {
    class Program {
        static void Main(string[] args) {
            var envelope = new Envelope {
                Header = new Header {
                    To = "http://google.com",
                    MessageId = "test"
                },
                Body = new Body {
                    OrganizationList = new List<Organization> {
                        new Organization {
                            ThName = "Th",
                            EnName = "En",
                            EcmsUrl = "http://google.com",
                            OrganizationId = "001"
                        },
                        new Organization {
                            ThName = "Th",
                            EnName = "En",
                            EcmsUrl = "http://google.com",
                            OrganizationId = "001"
                        }
                    }
                }
            };

            var ns = new XmlSerializerNamespaces();
            ns.Add("SOAP-ENV", "http://schemas.xmlsoap.org/soap/envelope/");

            var serialize = new XmlSerializer(typeof(Envelope));
            var memory = new MemoryStream();
            serialize.Serialize(memory, envelope, ns);
            memory.Seek(0, SeekOrigin.Begin);

            var xml = new StreamReader(memory).ReadToEnd();
            File.WriteAllText("resource/Generate.xml", xml);
        }
    }
}
