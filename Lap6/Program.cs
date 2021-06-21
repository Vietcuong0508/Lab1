using System;
using Lap6.Properties;

namespace Lap6
{
    internal class Program
    {
        // public delegate int CDelegate(int a, int b, int c);
        //
        // public static int TongBaSo(int a, int b, int c)
        // {
        //     return a + b + c;
        // }
        // public static void Main()
        // {
        //     CDelegate delegate1 = new CDelegate(TongBaSo);
        //     var result = delegate1(4, 8, 9);
        //     Console.WriteLine(result);
        // }
        
        public static void Main(string[] args)
        {
            Thermostat thermostat = new Thermostat();
            Heater heater = new Heater(60);
            thermostat.OnTemperatureChange += heater.OnTemperatureChanged;
            Heater heater2 = new Heater(100);
            thermostat.OnTemperatureChange += heater2.OnTemperatureChanged;
            Cooler cooler = new Cooler(80);
            thermostat.OnTemperatureChange += cooler.OnTemperatureChanged;
            Console.Write("Enter temperature:");
            thermostat.CurrentTemperature = int.Parse(Console.ReadLine());
        }
    }
}