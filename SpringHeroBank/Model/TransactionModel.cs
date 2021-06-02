using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using SpringHeroBank.Entity;
using SpringHeroBank.Service;

namespace SpringHeroBank.Model
{
    public class TransactionModel
    {
        private ConnectionHelper _connectionHelper = new ConnectionHelper();

        public Account Recharge(string accountNumber, double money, double newMoney)
        {
            Account account = null;

            var connection = _connectionHelper.Connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            try
            {
                cmd.CommandText = $"UPDATE account SET balance = {newMoney} WHERE CardNumber = '{accountNumber}'";
                cmd.ExecuteNonQuery();
                cmd.CommandText =
                    $"INSERT into tradehistory(ID,Amount,Code,SenderCode,ReceiverCode,Type,Message,CreateAt,UpdateAt) VALUES (@ID,@Amount,@Code,@SenderCode,@ReceiverCode,@Type,@Message,@CreateAt,@UpdateAt)";
                cmd.Parameters.AddWithValue("@Id", new TransactionService().GenerateRandomNumbers());
                cmd.Parameters.AddWithValue("@Amount", money);
                cmd.Parameters.AddWithValue("@Code", accountNumber);
                cmd.Parameters.AddWithValue("@SenderCode", accountNumber);
                cmd.Parameters.AddWithValue("@ReceiverCode", accountNumber);
                cmd.Parameters.AddWithValue("@Type", 2);
                cmd.Parameters.AddWithValue("@Message", $"Successfully deposit ${money} into the account");
                cmd.Parameters.AddWithValue("@CreateAt", DateTime.Now);
                cmd.Parameters.AddWithValue("@UpdateAt", DateTime.Now);
                cmd.CommandText = $"SELECT * from account WHERE CardNumber = '{accountNumber}'";
                var result = cmd.ExecuteReader();
                while (result.Read())
                {
                    account = new Account()
                    {
                        UserName = result["UserName"].ToString(),
                        Email = result["Email"].ToString(),
                        PhoneNumber = result["PhoneNumber"].ToString(),
                        PasswordHash = result["PasswordHash"].ToString(),
                        Salt = result["Salt"].ToString(),
                        Balance = double.Parse(result["Balance"].ToString()),
                        CardNumber = result["CardNumber"].ToString(),
                        Birthday = result["Birthday"].ToString(),
                        Status = int.Parse(result["Status"].ToString()),
                        CreateAt = DateTime.Parse(result["CreateAt"].ToString()),
                        UpdateAt = DateTime.Parse(result["UpdateAt"].ToString())
                    };
                }
                result.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e);
            }

            return account;
        }
        
         public Account Withdrawal(string accountNumber, double money, double newMoney)
        {
            Account account = null;

            var connection = _connectionHelper.Connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            try
            {
                cmd.CommandText = $"UPDATE account SET balance = {newMoney} WHERE CardNumber = '{accountNumber}'";
                cmd.ExecuteNonQuery();
                cmd.CommandText =
                    $"INSERT into tradehistory(ID,Amount,Code,SenderCode,ReceiverCode,Type,Message,CreateAt,UpdateAt) VALUES (@ID,@Amount,@Code,@SenderCode,@ReceiverCode,@Type,@Message,@CreateAt,@UpdateAt)";
                cmd.Parameters.AddWithValue("@ID", new TransactionService().GenerateRandomNumbers());
                cmd.Parameters.AddWithValue("@Amount", money);
                cmd.Parameters.AddWithValue("@Code", accountNumber);
                cmd.Parameters.AddWithValue("@SenderCode", accountNumber);
                cmd.Parameters.AddWithValue("@ReceiverCode", accountNumber);
                cmd.Parameters.AddWithValue("@Type", 1);
                cmd.Parameters.AddWithValue("@Message", $"Withdrawal of ${money} successfully form the account");
                cmd.Parameters.AddWithValue("@CreateAt", DateTime.Now);
                cmd.Parameters.AddWithValue("@UpdateAt", DateTime.Now);
                cmd.ExecuteNonQuery();
                cmd.CommandText = $"SELECT * from account WHERE CardNumber = '{accountNumber}'";
                var result = cmd.ExecuteReader();
                while (result.Read())
                {
                    account = new Account()
                    {
                        UserName = result["UserName"].ToString(),
                        Email = result["Email"].ToString(),
                        PhoneNumber = result["PhoneNumber"].ToString(),
                        PasswordHash = result["PasswordHash"].ToString(),
                        Salt = result["Salt"].ToString(),
                        Balance = double.Parse(result["Balance"].ToString()),
                        CardNumber = result["CardNumber"].ToString(),
                        Birthday = result["Birthday"].ToString(),
                        Status = int.Parse(result["Status"].ToString()),
                        CreateAt = DateTime.Parse(result["CreateAt"].ToString()),
                        UpdateAt = DateTime.Parse(result["UpdateAt"].ToString())
                    };
                }

                result.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e);
            }

            return account;
        }
        
        public Account Transfer(string senderCode, string recipientCode, double money, string message)
        {
            double newBalaneSender = 0;
            double newBalaneRecipient = 0;
            var connection = _connectionHelper.Connection();
            var cmd = new MySqlCommand {Connection = connection};
            var transaction = connection.BeginTransaction();
            cmd.Transaction = transaction;
            Account account = null;


            try
            {
                // tính số tiền còn lại của người chuyển 
                cmd.CommandText = $"SELECT * from account WHERE CardNumber = '{senderCode}'";
                var result1 = cmd.ExecuteReader();
                while (result1.Read())
                {
                    newBalaneSender = double.Parse(result1["Balance"].ToString()) - money;
                }

                result1.Close();
                // tính tổng số tiền của người nhận sau chuyển
                cmd.CommandText = $"SELECT * from account WHERE CardNumber = '{recipientCode}'";
                var result2 = cmd.ExecuteReader();
                while (result2.Read())
                {
                    newBalaneRecipient = double.Parse(result2["Balance"].ToString()) + money;
                }

                result2.Close();


                cmd.CommandText =
                    $"UPDATE account SET Balance = {newBalaneSender} WHERE CardNumber = '{senderCode}'";
                cmd.ExecuteNonQuery();
                cmd.CommandText =
                    $"UPDATE account SET Balance = {newBalaneRecipient} WHERE CardNumber = '{recipientCode}'";
                cmd.ExecuteNonQuery();
                cmd.CommandText = $"SELECT * from account WHERE CardNumber = '{senderCode}'";
                var result3 = cmd.ExecuteReader();
                while (result3.Read())
                {
                    account = new Account()
                    {
                        UserName = result3["UserName"].ToString(),
                        Email = result3["Email"].ToString(),
                        PhoneNumber = result3["PhoneNumber"].ToString(),
                        PasswordHash = result3["PasswordHash"].ToString(),
                        Salt = result3["Salt"].ToString(),
                        Balance = double.Parse(result3["Balance"].ToString()),
                        CardNumber = result3["CardNumber"].ToString(),
                        Birthday = result3["Birthday"].ToString(),
                        Status = int.Parse(result3["Status"].ToString()),
                        CreateAt = DateTime.Parse(result3["CreateAt"].ToString()),
                        UpdateAt = DateTime.Parse(result3["UpdateAt"].ToString())
                    };
                }

                result3.Close();
                //lưu thông tin cho bên người gửi
                cmd.CommandText =
                    $"INSERT into tradehistory(ID,Amount,Code,SenderCode,ReceiverCode,Type,Message,CreateAt,UpdateAt) VALUES (@ID,@Amount,@Code,@SenderCode,@ReceiverCode,@Type,@Message,@CreateAt,@UpdateAt)";
                cmd.Parameters.AddWithValue("@ID", new TransactionService().GenerateRandomNumbers());
                cmd.Parameters.AddWithValue("@Amount", money);
                cmd.Parameters.AddWithValue("@Code", senderCode);
                cmd.Parameters.AddWithValue("@SenderCode", senderCode);
                cmd.Parameters.AddWithValue("@ReceiverCode", recipientCode);
                cmd.Parameters.AddWithValue("@Type", 3);
                cmd.Parameters.AddWithValue("@Message", $"{message}");
                cmd.Parameters.AddWithValue("@CreateAt", DateTime.Now);
                cmd.Parameters.AddWithValue("@UpdateAt", DateTime.Now);
                cmd.ExecuteNonQuery();
                
                //lưu thông tin cho bên người nhận
                cmd.CommandText =
                    $"INSERT into tradehistory(ID,Amount,Code,SenderCode,ReceiverCode,Type,Message,CreateAt,UpdateAt) VALUES (@ID1,@Amount1,@Code1,@SenderCode1,@ReceiverCode1,@Type1,@Message1,@CreateAt1,@UpdateAt1)";
                cmd.Parameters.AddWithValue("@ID1", new TransactionService().GenerateRandomNumbers());
                cmd.Parameters.AddWithValue("@Amount1", money);
                cmd.Parameters.AddWithValue("@Code1", recipientCode);
                cmd.Parameters.AddWithValue("@SenderCode1", senderCode);
                cmd.Parameters.AddWithValue("@ReceiverCode1", recipientCode);
                cmd.Parameters.AddWithValue("@Type1", 3);
                cmd.Parameters.AddWithValue("@Message1", $"{message}");
                cmd.Parameters.AddWithValue("@CreateAt1", DateTime.Now);
                cmd.Parameters.AddWithValue("@UpdateAt1", DateTime.Now);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Transfer successfully!\n");
                transaction.Commit();
                return account;
            }
            catch (MySqlException e)
            {
                transaction.Rollback();
                Console.WriteLine("Transfer error");
                throw;
            }
        }
        public List<Transaction> TransactionHistory(string senderCode)
        {
            var transactionHistories = new List<Transaction>();
            var connection = _connectionHelper.Connection();
            var cmd = new MySqlCommand() {Connection = connection};
            try
            {
                cmd.CommandText = $"SELECT * from tradehistoty WHERE Code = '{senderCode}'";
                var result = cmd.ExecuteReader();
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        var transaction = new Transaction()
                        {
                            Id = int.Parse(result["Id"].ToString()),
                            Amount = double.Parse(result["Amount"].ToString()),
                            SenderCode = result["SenderCode"].ToString(),
                            ReceiverCode = result["ReceiverCode"].ToString(),
                            Type = int.Parse(result["Type"].ToString()),
                            Message = result["Message"].ToString(),
                            CreateAt = DateTime.Parse(result["CreateAt"].ToString()),
                            UpdateAt = DateTime.Parse(result["UpdateAt"].ToString())
                        };
                        transactionHistories.Add(transaction);
                    }
                }

                result.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e);
                throw;
            }

            return transactionHistories;
        }
    }
}