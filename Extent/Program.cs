using System;
using System.IO;
using System.Linq;
using Extent.ExtentCalculation;

namespace Extent
{
    class Program
    {
        //Replace file location strings to match your local files
        private const string ExtentsFile = @"C:\Users\ethan\source\repos\Extents\Extents\FilesToProcess\extents.txt";
        private const string PointsFile = @"C:\Users\ethan\source\repos\Extents\Extents\FilesToProcess\points.txt";

        static void Main(string[] args)
        {
            var extentCalculator = new ExtentCalculator();
           
           // Read the extents file and calculate the changePoints
           using (var fileStream = File.OpenRead(ExtentsFile))
           {
               using (var reader = new StreamReader(fileStream))
               {
                   string extentLine;
                   while ((extentLine = reader.ReadLine()) != null)
                   {
                      var list = extentLine.Trim().Split(' ').Select(Int32.Parse).ToList();
                       extentCalculator.AddExtent(new ExtentCalculation.Extent(list[0], list[1]));
                   }
               }
           }

            // Create the mapping from integer to the number of extents overlapping that integer
            extentCalculator.Initialize();

           // Read the points file and output the number of extents for each point
            using (var fileStream = File.OpenRead(PointsFile))
           {
               using (var reader = new StreamReader(fileStream))
               {
                   string pointsLine;
                   while ((pointsLine = reader.ReadLine()) != null)
                   {
                       if (Int32.TryParse(pointsLine.Trim(), out var point)) // If the line doesn't parse as an integer, skip it
                       {
                           Console.WriteLine(extentCalculator.GetNumberOfExtentsForPoint(point));
                       }
                   }
               }
           }

           // This is just to keep the console open after output
           Console.Read();
        }
    }
}
