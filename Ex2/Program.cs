using System;

namespace Ex2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\nEnter first integer:");  
            int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter second integer:");  
            int y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter third integer:");  
            int z = Convert.ToInt32(Console.ReadLine());
              
            Console.WriteLine("Maximum number is: "+Math.Max(x, Math.Max(y, z)));
        }
    }
}