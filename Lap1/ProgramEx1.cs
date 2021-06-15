using System;
using System.Text;
using Ex1;

namespace Lap1
{
    internal class ProgramEx1
    {
        public static void Main(string[] args)
        {
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
}