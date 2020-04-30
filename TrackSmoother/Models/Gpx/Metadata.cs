using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace TrackSmoother.Models.Gpx
{
	[XmlRoot(ElementName = "metadata", Namespace = "http://www.topografix.com/GPX/1/1")]
	public class Metadata
	{
		[XmlElement(ElementName = "time", Namespace = "http://www.topografix.com/GPX/1/1")]
		public string Time { get; set; }
	}
}
