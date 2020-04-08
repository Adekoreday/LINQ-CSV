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
            var allCar = ProcessCsv<Car>("fuel.csv", ProcessCar);
            var allManufacturers = ProcessCsv<Manufacturers>("manufacturers.csv", ProcessManufacturers);

            foreach (var item in allCar) {
                Console.WriteLine(item.Name);
            }
                Console.WriteLine("Reading Manufacturers <--------->");
            foreach(var item in allManufacturers) {
                Console.WriteLine(item.Name);
            }
        }

        public static Manufacturers ProcessManufacturers (string Line) {
            var contents = Line.Split(',');
            Console.WriteLine("cases", contents[0]);
            return new Manufacturers () {
                Name = contents[0],
                HeadQuaters = contents[1],
                Year = int.Parse(contents[2])
            };
        }
         public static Car  ProcessCar (string Line) {
            var contents = Line.Split(',');
            Console.WriteLine("cases", contents[0]);
            return new Car () {
                Name = contents[1],
                Manufacturer = contents[2],
                Displacement = double.Parse(contents[3]),
                Cyllinders = int.Parse(contents[4])
            };
        }
        public static IEnumerable<T> ProcessCsv<T> (string path, Func<string, T> ProcessItem) {
            return File.ReadAllLines(path)
            .Skip(1)
            .Where(lines => lines.Length > 1)
            .Select(item => ProcessItem(item))
            .ToList();
        }


    }
}
