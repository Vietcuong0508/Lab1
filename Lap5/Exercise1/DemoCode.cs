// using System;
// using System.Text;
// using Customer;
// using Order;
//
// namespace Lap5.Exercise1
// {
//     public class DemoCode
//     {
//         {
//             Console.OutputEncoding = Encoding.UTF8;
//             ShowMenu();
//         }
//         
//         public static void ShowMenu()
//         {
//             while (true)
//             {
//                 Console.WriteLine(".1 Grocery");
//                 Console.WriteLine(".2 Bakery");
//                 Console.WriteLine(".0 exist");
//                 var choice = int.Parse(Console.ReadLine());
//                 if (choice == 1)
//                 {
//                     Console.WriteLine("vui lòng nhập vào tên người dùng :");
//                     var name = Console.ReadLine();
//                     Customer.Customer customer = new Customer.Customer(); //sử dụng namespace gọi class
//                     var nameResult = customer.AcceptsCustomerName(name);
//                     Order.Grocery grocery = new Grocery();
//                     Console.WriteLine(nameResult + " " + grocery.ChoiceGrocery());
//                 }
//                 else if (choice == 2)
//                 {
//                     Console.WriteLine("vui lòng nhập vào tên người dùng :");
//                     var name = Console.ReadLine();
//                     Customer.Customer customer = new Customer.Customer(); //sử dụng namespace gọi class
//                     var nameResult = customer.AcceptsCustomerName(name);
//                     Order.Bakery bakery = new Bakery();
//                     Console.WriteLine(nameResult + " " + bakery.ChoiceBakery());
//                 }
//                 else if (choice == 0)
//                 {
//                     break;
//                 }
//                 else
//                 {
//                     Console.WriteLine("Vui lòng nhập từ 0 - 2");
//                 }
//             }
//         }
//
//
//         public string getName()
//         {
//             var name = Console.ReadLine();
//             return name;
//         }
//     }
// }
//
// namespace Customer
// {
//     public class Customer
//     {
//         public string AcceptsCustomerName(string customerName)
//         {
//             return $"người dùng : {customerName}";
//         }
//     }
// }
//
//
// namespace Order
// {
//     public class Grocery
//     {
//         public string ChoiceGrocery()
//         {
//             return "đã chọn Grocery";
//         }
//     }
//
//     public class Bakery
//     {
//         public string ChoiceBakery()
//         {
//             return "đã chọn Bakery";
//         }
//     }
// }