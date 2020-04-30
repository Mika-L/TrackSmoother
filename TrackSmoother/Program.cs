using System;
using System.IO;
using System.Linq;
using TrackSmoother.Filters;
using TrackSmoother.Readers;

namespace TrackSmoother
{
    class Program
    {
        static void Main(string[] args)
        {
            FileInfo file = new FileInfo(@"C:\Users\micly\Downloads\Course_pied_en_soir_e.gpx");
            var coord = GpxReader.ReadFile(file);

            //SavitzkyGolayFilter filter = new SavitzkyGolayFilter(50, 5);

            SavitzkyGolayFilter filter = new SavitzkyGolayFilter(30, 5);
            var lats = filter.Process(coord.Select(c => c.Item1).ToArray());
            var longs = filter.Process(coord.Select(c => c.Item2).ToArray());
            coord = lats.ToList().Zip(longs, (x, y) => new Tuple<double, double>(x, y)).ToList();
            GpxReader.WriteFile(file, coord);

            Console.WriteLine("Hello World!");
        }
    }
}
