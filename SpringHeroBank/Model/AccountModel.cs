using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using SpringHeroBank.Entity;
using SpringHeroBank.Service;

namespace SpringHeroBank.Model
{
    public class AccountModel
    {
        private ConnectionHelper _connectionHelper = new ConnectionHelper();
        private MD5Helper _md5Helper = new MD5Helper();
        private Account _account = null;

        public Boolean CreateNewAccount(Account account)
        {
            MySqlConnection connection = _connectionHelper.Connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            try
            {
                cmd.CommandText =
                    "INSERT INTO account(UserName,Email,PasswordHash,Salt,PhoneNumber,CardNumber,BirthDay,CreateAt,UpdateAt) VALUES (@UserName,@Email,@PasswordHash,@Salt,@PhoneNumber,@CardNumber,@BirthDay,@CreateAt,@UpdateAt)";
                cmd.Parameters.AddWithValue("@UserName", account.UserName);
                cmd.Parameters.AddWithValue("@Email", account.Email);
                cmd.Parameters.AddWithValue("@PasswordHash", account.PasswordHash);
                cmd.Parameters.AddWithValue("@Salt", account.Salt);
                cmd.Parameters.AddWithValue("@PhoneNumber", account.PhoneNumber);
                cmd.Parameters.AddWithValue("@CardNumber", account.CardNumber);
                cmd.Parameters.AddWithValue("@BirthDay", account.Birthday);
                cmd.Parameters.AddWithValue("@CreateAt", account.CreateAt);
                cmd.Parameters.AddWithValue("@UpdateAt", account.UpdateAt);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException err)
            {
                return false;
            }
        }

        public Account Login(string account, string password)
        {
            MySqlConnection connection = _connectionHelper.Connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            try
            {
                cmd.CommandText = $"SELECT * from account WHERE Email = '{account}'";
                MySqlDataReader result = cmd.ExecuteReader();

                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        var salt = result["salt"];
                        var passwordHash = _md5Helper.PasswordHash(password, salt.ToString());
                        if (passwordHash.Equals(result["PasswordHash"].ToString()))
                        {
                            result.Close();
                            cmd.CommandText = $"SELECT * from account WHERE Password = '{passwordHash}'";
                            MySqlDataReader accountData = cmd.ExecuteReader();
                            while (accountData.Read())
                            {
                                Account _account = new Account()
                                {
                                    UserName = accountData["UserName"].ToString(),
                                    Email = accountData["Email"].ToString(),
                                    PhoneNumber = accountData["PhoneNumber"].ToString(),
                                    PasswordHash = accountData["PasswordHash"].ToString(),
                                    Salt = accountData["Salt"].ToString(),
                                    Balance = double.Parse(accountData["Balance"].ToString()),
                                    CardNumber = accountData["CardNumber"].ToString(),
                                    Birthday = accountData["Birthday"].ToString(),
                                    Status = int.Parse(accountData["Status"].ToString()),
                                    CreateAt = DateTime.Parse(accountData["CreateAt"].ToString()),
                                    UpdateAt = DateTime.Parse(accountData["UpdateAt"].ToString())
                                };
                                accountData.Close();
                                return _account;
                            }
                        }
                        else
                        {
                            result.Close();
                            Console.WriteLine("\n Wrong password! \n");
                            _account = null;
                            return null;
                        }
                    }
                }
                else
                {
                    result.Close();
                    cmd.CommandText = $"SELECT * from account WHERE CardNumber = '{account}'";
                    MySqlDataReader result2 = cmd.ExecuteReader();

                    if (result2.HasRows)
                    {
                        while (result2.Read())
                        {
                            var salt = result2["salt"];
                            var hashPass = _md5Helper.PasswordHash(password, salt.ToString());
                            if (hashPass.Equals(result2["PasswordHash"].ToString()))
                            {
                                result2.Close();
                                cmd.CommandText = $"SELECT * from account WHERE Password = '{hashPass}'";
                                MySqlDataReader accountData = cmd.ExecuteReader();
                                while (accountData.Read())
                                {
                                    Account _account = new Account()
                                    {
                                        UserName = accountData["UserName"].ToString(),
                                        Email = accountData["Email"].ToString(),
                                        PhoneNumber = accountData["PhoneNumber"].ToString(),
                                        PasswordHash = accountData["PasswordHash"].ToString(),
                                        Salt = accountData["Salt"].ToString(),
                                        Balance = double.Parse(accountData["Balance"].ToString()),
                                        CardNumber = accountData["CardNumber"].ToString(),
                                        Birthday = accountData["Birthday"].ToString(),
                                        Status = int.Parse(accountData["Status"].ToString()),
                                        CreateAt = DateTime.Parse(accountData["CreateAt"].ToString()),
                                        UpdateAt = DateTime.Parse(accountData["UpdateAt"].ToString())
                                    };
                                    accountData.Close();
                                    return _account;
                                }
                            }
                            else
                            {
                                Console.WriteLine("\n Wrong password! \n");
                                _account = null;
                                return null;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"\nNo registered with account : {account}\n");
                        result2.Close();
                        _account = null;
                        return null;
                    }
                }

                return _account;
            }
            catch (MySqlException e)
            {
                _account = null;
                return null;
            }
        }
    }
}