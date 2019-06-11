using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

[XmlRoot(Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
public class Envelope {
    [XmlElement]
    public Header Header { set; get; }
    [XmlElement]
    public Body Body { set; get; }
}

[XmlRoot(Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
public class Body {
    [XmlElement("OrganizationInfo", Namespace = "")]
    public List<Organization> OrganizationList { set; get; }
}

[XmlRoot(Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
public class Header {
    [XmlElement("MessageID")]
    public string MessageId { set; get; }
    public string To { set; get; }
}

public class Organization {
    [XmlElement("Th-Name")]
    public string ThName { set; get; }

    [XmlElement("En-Name")]
    public string EnName { set; get; }

    [XmlElement("Ecms-Url")]
    public string EcmsUrl { set; get; }

    [XmlElement("OrganizationID")]
    public string OrganizationId { set; get; }
}


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
