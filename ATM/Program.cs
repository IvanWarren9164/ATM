using System;
using System.Collections.Generic;
using System.IO;

namespace ATM
{
    class Program
    {
        static void Main(string[] args)
        {
            List <Account> listOfAccounts= new List<Account>();
            Account currentAccount = new Account(null, null, 5);
            listOfAccounts = InitializeTestVariables(listOfAccounts);

            while (true)
            {
                Menu(listOfAccounts, currentAccount);
            }
        }

        public static List<Account> InitializeTestVariables(List<Account> listOfAccounts)
        {
            string accountName;
            string accountPassword;
            int accountBalance;

            accountName = "Ivan";
            accountPassword = "Password1234";
            accountBalance = 123;
            listOfAccounts.Add(new Account(accountName, accountPassword, accountBalance));

            accountName = "James";
            accountPassword = "CodingIsCool99";
            accountBalance = 123;
            listOfAccounts.Add(new Account(accountName, accountPassword, accountBalance));

            return listOfAccounts;
    
        }
        public static void Menu(List<Account> listOfAccounts, Account currentAccount)
        {
            int userChoice;
            string usernameEntry;
            string passwordEntry;
            int withdrawDepositEntry;
            Console.WriteLine("What would you like to do?: \n" +
                "[1] Register an Account \n" +
                "[2] Login \n");
            userChoice = int.Parse(Console.ReadLine());

            if(userChoice == 1)
            {
                Console.WriteLine("Enter your username \n");
                usernameEntry = Console.ReadLine();

                Console.WriteLine("\nEnter your password \n");
                passwordEntry = Console.ReadLine();
                ATM.Register(usernameEntry, passwordEntry, listOfAccounts);
            }
            else if(userChoice == 2)
            {
                Console.WriteLine("Enter your username \n");
                usernameEntry = Console.ReadLine();

                Console.WriteLine("\nEnter your password \n");
                passwordEntry = Console.ReadLine();
                currentAccount = ATM.Login(usernameEntry, passwordEntry, listOfAccounts, currentAccount);
            }
            else
            {
                Console.WriteLine("Error enter a valid selection");
                Console.Clear();
            }

            if (currentAccount.Name != null && currentAccount.Password != null)
                while (currentAccount.Name != null && currentAccount.Password != null)
                {
                    {
                        Console.WriteLine("What would you like to do?: \n" +
                            "[1] Logout \n" +
                            "[2] Show Current Balance \n" +
                            "[3] Deposit \n" +
                            "[4} Withdraw \n");
                        userChoice = int.Parse(Console.ReadLine());

                        if (userChoice == 1)
                        {
                            Console.Clear();
                            currentAccount = ATM.Logout(currentAccount);
                            
                        }
                        else if (userChoice == 2)
                        {
                            ATM.CheckBalance(currentAccount);
                        }
                        else if (userChoice == 3)
                        {
                            Console.WriteLine("How much would you like to deposit? \n");
                            withdrawDepositEntry = int.Parse(Console.ReadLine());
                            currentAccount = ATM.Deposit(withdrawDepositEntry, currentAccount);
                        }
                        else if (userChoice == 4)
                        {
                            Console.WriteLine("How much would you like to withdraw? \n");
                            withdrawDepositEntry = int.Parse(Console.ReadLine());
                            currentAccount = ATM.Withdraw(withdrawDepositEntry, currentAccount);
                        }
                    }
                }
        }
    }
}
