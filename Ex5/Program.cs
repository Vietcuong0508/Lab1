using System;

namespace Ex5
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            {
                for (int num = 1; num < 21; num++)
                {
                    Console.WriteLine("Factorial of "
                                      + num + " is " + factorial(num));
                }
            }
        }

        static long factorial(long n)
        {
            if (n == 0)
                return 1;

            return n * factorial(n - 1);
        }
    }
}