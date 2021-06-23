using System;
using System.Text;

namespace Lap7
{
    internal class Program
    {   
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            var employeeManager = new EmployeeManager();

            while (true)
            {
                Console.WriteLine("\n=============================");
                Console.WriteLine("Chon 1 để thêm mới.");
                Console.WriteLine("Chon 2 để hiển thị.");
                Console.WriteLine("Chon 3 để thay đổi.");
                Console.WriteLine("Chon 4 để xóa.");
                Console.WriteLine("Chon 5 để thoát.");
                Console.WriteLine("=============================\n");
                var choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        employeeManager.Add();
                        break;
                    case 2:
                        employeeManager.ShowList();
                        break;
                    case 3:
                        employeeManager.Modify();
                        break;
                    case 4:
                        employeeManager.delete();
                        break;
                    case 5:
                        Console.WriteLine("Tạm biệt!");
                        break;
                }
                if (choice == 5)
                {
                    break;
                }
            }
        }
    }
}