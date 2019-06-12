using System;
using System.Xml.Serialization;

namespace Abstract {

    public class NS {
        public const string Envelope = "http://schemas.xmlsoap.org/soap/envelope/";
        public const string Addressing = "http://www.w3.org/2005/08/addressing";
        public const string Empty = "";
    }

    [XmlRoot(Namespace = NS.Envelope)]
    public class Header {
        [XmlElement("MessageID", Namespace = NS.Addressing)]
        public string MessageId { set; get; }

        [XmlElement("To", Namespace = NS.Addressing)]
        public string To { set; get; }
    }

    [XmlRoot(Namespace = NS.Envelope)]
    public class Envelope {
        [XmlElement]
        public Header Header { set; get; }
        public Body Body { set; get; }
    }

    [XmlRoot(Namespace = NS.Envelope)]
    public class Body {
        [XmlElement(Namespace = NS.Empty)]
        public Response CorrespondenceLetterInboundResponse { set; get; }
    }

    public class Response {
        [XmlElement("ProcessID")]
        public string ProcessId { set; get; }
        public DateTime ProcessTime { set; get; }
    }

    class Program {
        static void Main(string[] args) {

        }
    }
}
