using System;
using System.Linq;

namespace Auspex.Excel.Mapper.Example.cs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("reading from example.xslx...");

            IExcelMapper mapper = new ExcelMapper();
            var file = mapper.ReadFile("example.xlsx");
            var rows = mapper.Map<ExampleClass>(file, "Blad1");

            Console.WriteLine($"rows (count={rows.Count()}):");

            foreach (var row in rows)
                Console.WriteLine($" - {row}");

            Console.WriteLine("press enter to quit");
            Console.ReadLine();
        }
    }
}