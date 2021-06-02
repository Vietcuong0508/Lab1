using System;
using System.Text;

namespace Ex1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Information information = new Information();
            Console.WriteLine("Please enter your name:");
            information.name = Console.ReadLine();
            Console.WriteLine("Please enter your address:");
            information.address = Console.ReadLine();
            Console.WriteLine("Please enter your phone:");
            information.phone = Console.ReadLine();
            information.ToString();
        }
    }
}