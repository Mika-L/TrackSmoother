using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace TrackSmoother.Core.Models.Gpx
{
	[XmlRoot(ElementName = "gpx", Namespace = "http://www.topografix.com/GPX/1/1")]
	public class Gpx
	{
		[XmlElement(ElementName = "metadata", Namespace = "http://www.topografix.com/GPX/1/1")]
		public Metadata Metadata { get; set; }
		[XmlElement(ElementName = "trk", Namespace = "http://www.topografix.com/GPX/1/1")]
		public Trk Trk { get; set; }
		[XmlAttribute(AttributeName = "creator")]
		public string Creator { get; set; }
		//[XmlAttribute(AttributeName = "xmlns:xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
		//public string Xsi { get; set; }
		//[XmlAttribute(AttributeName = "xsi:schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
		//public string SchemaLocation { get; set; }
		[XmlAttribute(AttributeName = "version")]
		public string Version { get; set; }
		//[XmlAttribute(AttributeName = "xmlns")]
		//public string Xmlns { get; set; }
	}
}
