using System;
using System.Text;

namespace Ex1
{
    public class Information
    {
        public string name { get; set; }
        public string address { get; set; }
        public string phone { get; set; }

        public void ToString()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine($"Name: {name} \t Address: {address} \t Phone: {phone}");
        }
    }
}