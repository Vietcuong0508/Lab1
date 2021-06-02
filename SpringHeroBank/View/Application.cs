using System;
using System.Text;
using MySql.Data.MySqlClient;
using SpringHeroBank.Controller;
using SpringHeroBank.Entity;
using SpringHeroBank.Model;

namespace SpringHeroBank.View
{
    public class Application
    {
        public Account userLogin = null;

        public void menu()
        {
            QuestController questController = new QuestController();
            AccountController acountController = new AccountController();
            Console.OutputEncoding = Encoding.UTF8;
            int choice;
            while (true)
            {
                if (userLogin == null)
                {
                    Console.WriteLine("\n\n||============|| Spring Hero Bank ||============||");
                    Console.WriteLine("||  Enter 1 for login.                          ||");
                    Console.WriteLine("||  Enter 2 for register.                       ||");
                    Console.WriteLine("||  Enter 3 to get out of program.              ||");
                    Console.WriteLine("||==============================================||");
                    Console.WriteLine("\nEnter your choice:");
                    choice = int.Parse(Console.ReadLine());

                    if (choice == 1 || choice == 2 || choice == 3)
                    {
                        switch (choice)
                        {
                            case 1:
                                userLogin = questController.LoginController();
                                break;
                            case 2:
                                questController.CreateAccountController();
                                break;
                            case 3:
                                Console.WriteLine("Bye bye!");
                                break;
                        }

                        if (choice == 3)
                        {
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nPlease enter the right choices:\n");
                    }
                }
                else
                {
                    Console.WriteLine(
                        $"=====|| Spring Hero Bank ||===|| User : {userLogin.UserName} ||===|| Balance : ${userLogin.Balance} ||===|| phone : {userLogin.PhoneNumber} ||===|| Card number : {userLogin.CardNumber} ||=====\n");
                    Console.WriteLine("||==================|| MENU ||==================||");
                    Console.WriteLine("|| Enter 1 to add money to the account.         ||");
                    Console.WriteLine("|| Enter 2 to withdraw money from the account.  ||");
                    Console.WriteLine("|| Enter 3 for transfer of money.               ||");
                    Console.WriteLine("|| Enter 4 to see trading history.              ||");
                    Console.WriteLine("|| Enter 5 for documentation.                   ||");
                    Console.WriteLine("|| Enter 6 for export.                          ||");
                    Console.WriteLine("||==============================================||\n");
                    Console.WriteLine("\nEnter your choice:");
                    choice = int.Parse(Console.ReadLine());


                    if (choice == 1 || choice == 2 || choice == 3 || choice == 4 || choice == 5 || choice == 6)
                    {
                        switch (choice)
                        {
                            case 1:
                                userLogin = acountController.Recharge(userLogin);
                                break;
                            case 2:
                                userLogin = acountController.Withdrawal(userLogin);
                                break;
                            case 3:
                                userLogin = acountController.Transfer(userLogin);
                                break;
                            case 4:
                                acountController.ShowTransactionHistory(userLogin);
                                break;
                            case 5:
                                acountController.ShowInformation(userLogin);
                                break;
                            case 6:
                                userLogin = null;
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nPlease enter the right choices:\n");
                    }
                }
            }
        }
    }
}