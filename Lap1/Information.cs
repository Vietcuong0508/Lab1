using System;
using System.Text;

namespace Ex1
{
    public class Information
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public void ToString()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine($"Name: {Name} \t Address: {Address} \t Phone: {Phone}");
        }
    }
}