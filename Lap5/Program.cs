using System;
using System.Text;
using lap5.Exercise2;
using Order;

namespace Lap5
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            //Exercise2
            Console.WriteLine("vui lòng nhập tên");
            var name = Console.ReadLine();
            Console.WriteLine("vui lòng nhập salary");
            var salary = double.Parse(Console.ReadLine());
            Console.WriteLine("vui lòng nhập bonus");
            var bonus = double.Parse(Console.ReadLine());
            var seniorLecture = new SeniorLecture
            {
                Name = name,
                Salary = salary,
                Bonus = bonus
            };
            try
            {
                CheckAmount(seniorLecture);
            }
            catch (AmountException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static void CheckAmount(SeniorLecture seniorLecture)
        {
            if (seniorLecture.Salary < 60000)
            {
                throw new AmountException($"mức lương của giảng viên {seniorLecture.Name} tối thiểu phải từ 60000");
            }
            else if (seniorLecture.Bonus > 10000)
            {
                throw new AmountException($"mức thưởng của giảng viên {seniorLecture.Name} tối đa không quá 10000");
            }
            else
            {
                Console.WriteLine("Okie");
            }
        }
        //Exercise2

        //Exercise1
        public static void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine(".1 Grocery");
                Console.WriteLine(".2 Bakery");
                Console.WriteLine(".0 exist");
                var choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    Console.WriteLine("vui lòng nhập vào tên người dùng :");
                    var name = Console.ReadLine();
                    Customer.Customer customer = new Customer.Customer(); // sử dụng namespace gọi class
                    var nameResult = customer.AcceptsCustomerName(name);
                    Order.Grocery grocery = new Grocery();
                    Console.WriteLine(nameResult + " " + grocery.ChoiceGrocery());
                }
                else if (choice == 2)
                {
                    Console.WriteLine("vui lòng nhập vào tên người dùng :");
                    var name = Console.ReadLine();
                    Customer.Customer customer = new Customer.Customer(); // sử dụng namespace gọi class
                    var nameResult = customer.AcceptsCustomerName(name);
                    Order.Bakery bakery = new Bakery();
                    Console.WriteLine(nameResult + " " + bakery.ChoiceBakery());
                }
                else if (choice == 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Vui lòng nhập từ 0 - 2");
                }
            }
        }

        public string getName()
        {
            var name = Console.ReadLine();
            return name;
        }
//Exercise1
    }
}

namespace Customer
{
    public class Customer
    {
        public string AcceptsCustomerName(string customerName)
        {
            return $"người dùng : {customerName}";
        }
    }
}

namespace Order
{
    public class Grocery
    {
        public string ChoiceGrocery()
        {
            return "đã chọn Grocery";
        }
    }

    public class Bakery
    {
        public string ChoiceBakery()
        {
            return "đã chọn Bakery";
        }
    }
}