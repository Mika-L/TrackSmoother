using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace TrackSmoother.Models.Gpx
{
	[XmlRoot(ElementName = "gpxtpx:TrackPointExtension", Namespace = "http://www.garmin.com/xmlschemas/TrackPointExtension/v1")]
	public class TrackPointExtension
	{
		[XmlElement(ElementName = "hr", Namespace = "http://www.garmin.com/xmlschemas/TrackPointExtension/v1")]
		public string Hr { get; set; }
		[XmlElement(ElementName = "cad", Namespace = "http://www.garmin.com/xmlschemas/TrackPointExtension/v1")]
		public string Cad { get; set; }
	}
}
