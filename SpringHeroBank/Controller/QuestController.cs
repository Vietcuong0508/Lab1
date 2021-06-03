using System;
using System.Text;
using SpringHeroBank.Entity;
using SpringHeroBank.Model;
using SpringHeroBank.Service;

namespace SpringHeroBank.Controller
{
    public class QuestController
    {
        private AccountModel _accountModel = new AccountModel();
        private AccountService _accountService = new AccountService();

        public void CreateAccountController()
        {
            Console.OutputEncoding = Encoding.UTF8;

            var _account = new Account();
            Console.WriteLine("Please enter your full name:");
            _account.UserName = Console.ReadLine();
            Console.WriteLine("Please enter Email:");
            _account.Email = Console.ReadLine();
            Console.WriteLine("Please enter phone:");
            _account.PhoneNumber = Console.ReadLine();
            Console.WriteLine("Please enter password:");
            _account.Password = Console.ReadLine();
            Console.WriteLine("Please enter birthday (day-month-year):");
            _account.Birthday = Console.ReadLine();
            //truyền các giá trị người dùng đã nhập vào service để tiếp tục sử lý đăng kí
            _accountService.CreateAccountService(_account);
        }


        public Account LoginController()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("\nPlease enter email or card number:");
            var account = Console.ReadLine();
            Console.WriteLine("\nEnter password");
            var password = Console.ReadLine();
            var accountIsLogin = _accountModel.Login(account, password);
            return accountIsLogin;
        }
    }
}