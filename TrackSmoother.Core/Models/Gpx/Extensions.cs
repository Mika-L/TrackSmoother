using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace TrackSmoother.Core.Models.Gpx
{
	[XmlRoot(ElementName = "extensions", Namespace = "http://www.topografix.com/GPX/1/1")]
	public class Extensions
	{
		[XmlElement(ElementName = "TrackPointExtension", Namespace = "http://www.garmin.com/xmlschemas/TrackPointExtension/v1")]
		public TrackPointExtension TrackPointExtension { get; set; }
	}
}
