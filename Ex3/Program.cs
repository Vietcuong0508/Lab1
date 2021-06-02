using System;

namespace Ex3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int dayname;
            Console.Write("Input number between 1 and 7:");
            dayname = Convert.ToInt32(Console.ReadLine());

            switch (dayname)
            {
                case 1:
                    Console.Write("Monday \n");
                    break;
                case 2:
                    Console.Write("Tuesday \n");
                    break;
                case 3:
                    Console.Write("Wednesday \n");
                    break;
                case 4:
                    Console.Write("Thursday \n");
                    break;
                case 5:
                    Console.Write("Friday \n");
                    break;
                case 6:
                    Console.Write("Saturday \n");
                    break;
                case 7:
                    Console.Write("Sunday  \n");
                    break;
                default:
                    Console.Write("Invalid number. \nPlease try again.\n");
                    break;
            }
        }
    }
}