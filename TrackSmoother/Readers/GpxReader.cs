using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using TrackSmoother.Models.Gpx;

namespace TrackSmoother.Readers
{
    public static class GpxReader
    {
        private static XmlSerializerNamespaces namespaces;
        static GpxReader()
        {

//creator = "StravaGPX"
//xmlns: xsi = "http://www.w3.org/2001/XMLSchema-instance"
//xsi: schemaLocation = "http://www.topografix.com/GPX/1/1 http://www.topografix.com/GPX/1/1/gpx.xsd http://www.garmin.com/xmlschemas/GpxExtensions/v3 http://www.garmin.com/xmlschemas/GpxExtensionsv3.xsd http://www.garmin.com/xmlschemas/TrackPointExtension/v1 http://www.garmin.com/xmlschemas/TrackPointExtensionv1.xsd"
//version = "1.1"
//xmlns = "http://www.topografix.com/GPX/1/1"
//xmlns: gpxtpx = "http://www.garmin.com/xmlschemas/TrackPointExtension/v1"
//xmlns: gpxx = "http://www.garmin.com/xmlschemas/GpxExtensions/v3"

            namespaces = new XmlSerializerNamespaces();
            namespaces.Add("gpxtpx", "http://www.garmin.com/xmlschemas/TrackPointExtension/v1");
            namespaces.Add("gpxx", "http://www.garmin.com/xmlschemas/GpxExtensions/v3");
        }

        public static List<Tuple<double, double>> ReadFile(FileInfo file)
        {
            XDocument doc = XDocument.Load(file.FullName);

            List<Tuple<double, double>> coordinates = new List<Tuple<double, double>>();
            double latitude = 0;
            double longitude = 0;

            foreach (XElement el in doc.Root.Elements())
            {
                Console.WriteLine("{0}", el.Name);
                Console.WriteLine("  Attributes:");
                foreach (XAttribute attr in el.Attributes())
                {
                    Console.WriteLine("    {0}", attr);
                }
                Console.WriteLine("  Elements:");

                foreach (XElement element in el.Elements())
                {
                    if (element.Descendants().Any())
                    {
                        foreach (XElement element2 in element.Descendants())
                        {
                            Console.WriteLine("    {0}: {1}", element2.Name, element2.Value);
                            foreach (XAttribute attr in element2.Attributes())
                            {
                                Console.WriteLine("    {0}", attr);
                                if (attr.Name.LocalName == "lat")
                                {
                                    latitude = double.Parse(attr.Value, CultureInfo.InvariantCulture);
                                }
                                else if (attr.Name.LocalName == "lon")
                                {
                                    longitude = double.Parse(attr.Value, CultureInfo.InvariantCulture);
                                }

                                if (latitude != 0 && longitude != 0)
                                {
                                    coordinates.Add(new Tuple<double, double>(latitude, longitude));
                                    latitude = 0;
                                    longitude = 0;
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("    {0}: {1}", element.Name, element.Value);
                    }
                }
            }

            return coordinates;
        }

        public static void WriteFile(FileInfo file, List<Tuple<double, double>> coordinates)
        {
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings
            {
                Indent = true,
                OmitXmlDeclaration = false,
                Encoding = Encoding.UTF8
            };

            XmlSerializer serializer = new XmlSerializer(typeof(Gpx));
            StreamReader stream = new StreamReader(file.FullName, Encoding.UTF8);
            var gpx = (Gpx)serializer.Deserialize(stream);
            int i = 0;

            foreach (var e in gpx.Trk.Trkseg.Trkpt)
            {
                e.Lat = coordinates.ElementAt(i).Item1.ToString(CultureInfo.InvariantCulture);
                e.Lon = coordinates.ElementAt(i).Item2.ToString(CultureInfo.InvariantCulture);
                i++;
            }

            using (FileStream memoryStream = new FileStream(Path.Combine(file.DirectoryName, "res.gpx"), FileMode.Truncate))
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings))
                {
                    serializer.Serialize(xmlWriter, gpx, namespaces);
                }
            }
        }
    }
}
