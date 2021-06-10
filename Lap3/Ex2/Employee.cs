namespace Lap3
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public long Sin { get; set; }
        public double Salary { get; set; }

        public override string ToString()
        {
            return $"FirstName :{FirstName}, LastName :{LastName}, Address :{Address}, Sin :{Sin}, Salary :{Salary}";
        }

        public double CalculBonus(int percentage)
        {
            var result = Salary * percentage;
            return result ;
        }
    }
}