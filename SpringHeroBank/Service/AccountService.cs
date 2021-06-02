using System;
using MySql.Data.MySqlClient;
using SpringHeroBank.Entity;
using SpringHeroBank.Model;

namespace SpringHeroBank.Service
{
    public class AccountService
    {
        private Random _random = new Random();
        private MD5Helper _md5Helper = new MD5Helper();
        private AccountModel _accountModel = new AccountModel();


        public void CreateAccountService(Account account)
        {
            var salt = _random.Next(100000000, 999999999).ToString();
            //tạo ra mã thẻ ngân hàng
            var accountNumber = _random.Next(1000, 9999).ToString() + _random.Next(1000, 9999).ToString() +
                                _random.Next(1000, 9999).ToString() + _random.Next(1000, 9999).ToString();
            //mã hóa mật khẩu
            var passwordHash = _md5Helper.PasswordHash(account.Password, salt);
            //tạo mới đối tượng người dùng với thông tin đầy đủ
            var accountCreate = new Account()
            {
                UserName = account.UserName,
                Email = account.Email,
                PhoneNumber = account.PhoneNumber,
                Birthday = account.Birthday,
                PasswordHash = passwordHash,
                Salt = salt,
                CardNumber = accountNumber,
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now,
            };
            var created = _accountModel.CreateNewAccount(accountCreate);
            if (created)
            {
                Console.WriteLine($"\nCreating new successful account, your account number is : {accountNumber}\n");
            }
            else
            {
                Console.WriteLine("\nCreate error !\n");
            }
        }
    }
}