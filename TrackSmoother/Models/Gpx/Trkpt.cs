using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace TrackSmoother.Models.Gpx
{
	[XmlRoot(ElementName = "trkpt", Namespace = "http://www.topografix.com/GPX/1/1")]
	public class Trkpt
	{
		[XmlElement(ElementName = "ele", Namespace = "http://www.topografix.com/GPX/1/1")]
		public string Ele { get; set; }
		[XmlElement(ElementName = "time", Namespace = "http://www.topografix.com/GPX/1/1")]
		public string Time { get; set; }
		[XmlAttribute(AttributeName = "lat")]
		public string Lat { get; set; }
		[XmlAttribute(AttributeName = "lon")]
		public string Lon { get; set; }
		[XmlElement(ElementName = "extensions", Namespace = "http://www.topografix.com/GPX/1/1")]
		public Extensions Extensions { get; set; }
	}
}
