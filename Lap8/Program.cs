using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lap8
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            
            // ex1
            var temperatures = new List<int>();
            temperatures.Add(15);
            temperatures.Add(23);
            temperatures.Add(18);
            temperatures.Add(68);
            temperatures.Add(35);
            temperatures.Add(70);
            temperatures.Add(53);
            var count = 0;
            foreach (var temperature in temperatures)
            {
                if (temperature >= 25)
                {
                    count++;
                }
            }

            Console.WriteLine("Please enter GreaterCount:");
            var min = int.Parse(Console.ReadLine());
            var result = GreaterCount(temperatures, min);
            Console.WriteLine($"The number of times the temperature exceeds 25 degrees is: {count}");
            Console.WriteLine($"The number of times the temperature exceeds {min} degrees is {result}");
        }

        public static int GreaterCount(List<int> list, double min)
        {
            var count = 0;
            foreach (var item in list)
            {
                if (item >= min)
                {
                    count++;
                }
            }

            return count;
            // ex1

            // ex2
            //     var random = new Random();
            //     var temperature = new double[300];
            //     for (var i = 0; i < 300; i++)
            //     {
            //         temperature[i] = random.Next(0, 1000);
            //     }
            //
            //     while (true)
            //     {
            //         Console.Write("Please enter min number : ");
            //         var min = int.Parse(Console.ReadLine());
            //         Console.WriteLine(
            //             $"GreaterCount return : {GreaterCount(temperature, min)} times the temperature is greater than the number of min entered : {min}\n\n");
            //     }
            // }
            //
            // public static int GreaterCount(IEnumerable enumerable, double min)
            // {
            //     var count = 0;
            //     foreach (var item in enumerable)
            //     {
            //         if (double.Parse(item.ToString()) >= min)
            //         {
            //             count++;
            //         }
            //     }
            //
            //     return count;
            // ex2
        }
    }
}