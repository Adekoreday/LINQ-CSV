using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Models;

namespace csv_Reader
{
    class Program
    {
        static void Main(string[] args)
        {
            var allCar = ProcessCsv("fuel.csv");
            foreach (var item in allCar) {
                Console.WriteLine(item.Name);
            }
        }

         public static Models.Car  ProcessLines (string Line) {
            var contents = Line.Split(',');
            Console.WriteLine("cases", contents[0]);
            return new Models.Car () {
                Name = contents[1],
                Manufacturer = contents[2],
                Displacement = double.Parse(contents[3]),
                Cyllinders = int.Parse(contents[4])
            };
        }
        public static IEnumerable<Models.Car > ProcessCsv (string path) {
            return File.ReadAllLines(path)
            .Skip(1)
            .Where(lines => lines.Length > 1)
            .Select(item => ProcessLines(item))
            .ToList();
        }
    }
}
