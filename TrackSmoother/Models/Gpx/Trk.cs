using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace TrackSmoother.Models.Gpx
{
	[XmlRoot(ElementName = "trk", Namespace = "http://www.topografix.com/GPX/1/1")]
	public class Trk
	{
		[XmlElement(ElementName = "name", Namespace = "http://www.topografix.com/GPX/1/1")]
		public string Name { get; set; }
		[XmlElement(ElementName = "type", Namespace = "http://www.topografix.com/GPX/1/1")]
		public string Type { get; set; }
		[XmlElement(ElementName = "trkseg", Namespace = "http://www.topografix.com/GPX/1/1")]
		public Trkseg Trkseg { get; set; }
	}
}
