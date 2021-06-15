using System;

namespace lap5.Exercise2
{
    public class AmountException :Exception
    {
        public AmountException()
        { }
        public AmountException(string message):base(message)
        { }
    }
    public class SeniorLecture
    {
        public double Salary { get; set; }
        public double Bonus { get; set; }
        public string Name { get; set; }
    }
}