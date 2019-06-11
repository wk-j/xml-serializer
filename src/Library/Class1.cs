using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Library {

    [XmlRoot(Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class Envelope {
        [XmlElement]
        public Header Header { set; get; }
        [XmlElement]
        public Body Body { set; get; }
    }

    [XmlRoot(Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class Body {
        [XmlArray("OrganizationList", Namespace = "")]
        [XmlArrayItem("OrganizationInfo")]
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

}
