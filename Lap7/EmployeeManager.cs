using System;
using System.Collections.Generic;

namespace Lap7
{
    public class EmployeeManager
    {
        private Dictionary<string, Employee> _employees = new Dictionary<string, Employee>();

        public void Add()
        {
            Console.WriteLine("Nhập vào id:");
            var id = Console.ReadLine();
            Console.WriteLine("nhập vào tên:");
            var name = Console.ReadLine();
            Console.WriteLine("nhập vào tuổi:");
            var age = int.Parse(Console.ReadLine());
            Console.WriteLine("nhập vào mức lương:");
            var salary = double.Parse(Console.ReadLine());
            _employees.Add(id, new Employee
            {
                Id = id,
                Name = name,
                Age = age,
                Salary = salary
            });
        }

        public void Modify()
        {
            Console.WriteLine("nhập vào id:");
            var id = Console.ReadLine();
            if (_employees.ContainsKey(id))
            {
                Console.WriteLine("nhập vào tên:");
                var name = Console.ReadLine();
                Console.WriteLine("nhập vào tuổi:");
                var age = int.Parse(Console.ReadLine());
                Console.WriteLine("nhập vào mức lương:");
                var salary = double.Parse(Console.ReadLine());
                _employees[id].Name = name;
                _employees[id].Age = age;
                _employees[id].Salary = salary;
                Console.WriteLine("thay đổi thành công!");
            }
        }

        public void ShowList()
        {
            if (_employees.Count > 0)
            {
                foreach (var key in _employees.Keys)
                {
                    Console.WriteLine(_employees[key].ToString());
                }

                return;
            }

            Console.WriteLine("Chưa có Employee nào!");
        }

        public void delete()
        {
            Console.WriteLine("nhập vào id Employee bạn muốn xóa:");
            var id = Console.ReadLine();
            if (_employees.ContainsKey(id))
            {
                _employees.Remove(id);
                Console.WriteLine("xóa thành công!");
            }
            else
            {
                Console.WriteLine($"không tìm thấy Employee nào với {id}!");
            }
        }
    }
}