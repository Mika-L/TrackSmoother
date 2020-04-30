using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace TrackSmoother.Models.Gpx
{
	[XmlRoot(ElementName = "trkseg", Namespace = "http://www.topografix.com/GPX/1/1")]
	public class Trkseg
	{
		[XmlElement(ElementName = "trkpt", Namespace = "http://www.topografix.com/GPX/1/1")]
		public List<Trkpt> Trkpt { get; set; }
	}
}
