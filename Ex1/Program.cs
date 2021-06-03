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
            information.Name = Console.ReadLine();
            Console.WriteLine("Please enter your address:");
            information.Address = Console.ReadLine();
            Console.WriteLine("Please enter your phone:");
            information.Phone = Console.ReadLine();
            information.ToString();
        }
    }
}