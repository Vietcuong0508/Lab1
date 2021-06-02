using System;
using System.Collections.Generic;
using SpringHeroBank.Entity;
using SpringHeroBank.Model;
using SpringHeroBank.Service;

namespace SpringHeroBank.Controller
{
    public class AccountController
    {
        private TransactionModel _transactionModel = new TransactionModel();
        private TransactionService _transactionService = new TransactionService();

        public Account Recharge(Account account)
        {
            Console.WriteLine("Enter how much money you want to deposit:");
            var money = Double.Parse(Console.ReadLine());
            if (money <= 0)
            {
                Console.WriteLine($"\nCannot transfer ${money} into your account, minimum transfer requirement 1$\n");
                return account;
            }
            else
            {
                int choice = int.Parse(Console.ReadLine());
                Console.WriteLine("Transaction confirmation, enter 1");
                Console.WriteLine("Call off the deal, enter 2\n");
                if (choice == 1)
                {
                    return _transactionModel.Recharge(account.CardNumber, money, money + account.Balance);
                }
                else
                {
                    return account;
                }
            }
        }

        public Account Withdrawal(Account account)
        {
            Console.WriteLine("Enter how much you want to cash:");
            var money = Double.Parse(Console.ReadLine());
            if (money > account.Balance)
            {
                Console.WriteLine("Account is not enough to make the withdrawal!\n");
                return account;
            }
            else
            {
                int choice = int.Parse(Console.ReadLine());
                Console.WriteLine("Transaction confirmation, enter 1");
                Console.WriteLine("Call off the deal, enter 2\n");
                if (choice == 1)
                {
                    Console.WriteLine($"Withdrawal of {money} successfully from the account.");
                    return _transactionModel.Withdrawal(account.CardNumber, money, account.Balance - money);
                }
                else
                {
                    return account;
                }
            }
        }

        public Account Transfer(Account account)
        {
            Account user = null;
            Console.WriteLine("Enter the recipient's code:");
            var recipientCode = Console.ReadLine();
            if (recipientCode == account.CardNumber)
            {
                Console.WriteLine("\nYou can't transfer money to yourself!\n");
                return account;
            }
            else
            {
                var checkAccount = _transactionService.CheckUserExist(recipientCode);
                if (checkAccount == null)
                {
                    Console.WriteLine($"\nCouldn't find a user with the card code: {recipientCode} !\n");
                    return account;
                }
                else
                {
                    Console.WriteLine(
                        $"\n Finding users : {checkAccount.UserName} \t correspond to card number : {checkAccount.CardNumber}\n\n");
                    Console.WriteLine("Transaction confirmation, enter 1");
                    Console.WriteLine("Call off the deal, enter 2\n");
                    var choice = int.Parse(Console.ReadLine());
                    if (choice == 1)
                    {
                        Console.WriteLine(
                            $"Enter how much you want to cash: {checkAccount.UserName} with card code : {checkAccount.CardNumber}\n");
                        var money = double.Parse(Console.ReadLine());
                        if (money > account.Balance)
                        {
                            Console.WriteLine("\nAccount is not enough to make the withdrawal!\n");
                            return account;
                        }
                        else
                        {
                            Console.WriteLine("\nEnter message you want to send:");
                            var mes = Console.ReadLine();
                            return _transactionModel.Transfer(account.CardNumber, checkAccount.CardNumber, money, mes);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Creased trading!");
                        return account;
                    }
                }
            }
        }
        public void ShowTransactionHistory(Account account)
        {
            var transactions = _transactionModel.TransactionHistory(account.CardNumber);
            if (transactions.Count == 0)
            {
                Console.WriteLine("\nYou haven't made any trade\n");
            }
            else
            {
                foreach (var transaction in transactions)
                {
                    transaction.ToString();
                }
            }
        }

        public void ShowInformation(Account account)
        {
            Console.WriteLine("\n\n||======================| Information |====================||");
            Console.WriteLine($"- User : {account.UserName}");
            Console.WriteLine($"- Balance : ${account.Balance}");
            Console.WriteLine($"- Account Number : {account.CardNumber}");
            Console.WriteLine($"- Phone : {account.PhoneNumber}");
            Console.WriteLine($"- Email : {account.Email}");
            Console.WriteLine($"- PasswordHash : {account.PasswordHash}");
            Console.WriteLine($"- Birthday : {account.Birthday}");
            Console.WriteLine($"- CreateAt : {account.CreateAt}");
            Console.WriteLine("||======================| Information |====================||\n\n");
        }
    }
}