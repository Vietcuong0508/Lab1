using System;
using System.Security.Cryptography;
using System.Text;
using MySql.Data.MySqlClient;
using SpringHeroBank.Entity;
using SpringHeroBank.Model;

namespace SpringHeroBank.Service
{
    public class TransactionService
    {
        private ConnectionHelper _connectionHelper = new ConnectionHelper();

        private Random _random = new Random();

        public int GenerateRandomNumbers()
        {
            return int.Parse(_random.Next(10, 99).ToString() + _random.Next(10, 99).ToString() +
                             _random.Next(100, 999).ToString());
        }

        public Account CheckUserExist(string accountNumber)
        {
            var connection = _connectionHelper.Connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            Account account = null;
            try
            {
                cmd.CommandText = $"SELECT * from account WHERE CardNumber = '{accountNumber}'";
                var result = cmd.ExecuteReader();
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        account = new Account()
                        {
                            UserName = result["UserName"].ToString(),
                            Email = result["Email"].ToString(),
                            PhoneNumber = result["PhoneNumber"].ToString(),
                            CardNumber = result["CardNumber"].ToString(),
                            Birthday = result["Birthday"].ToString()
                        };
                    }
                }
                result.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Connection error!");
            }
            return account;
        }
    }
}