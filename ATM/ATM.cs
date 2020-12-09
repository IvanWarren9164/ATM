using System;
using System.Collections.Generic;
using System.IO;
namespace ATM
{
    public abstract class ATM
    {
        public static void Register(string accountName, string accountPassword,List<Account> listOfAccounts)
        {
            listOfAccounts.Add(new Account(accountName, accountPassword, 0));
        }
        public static Account Login(string accountName, string accountPassword,List<Account> listOfAccounts,Account currentAccount)
        {

            if (LoginCheck(currentAccount) == true)
            {
                foreach (Account account in listOfAccounts)
                {
                    if (account.Name == accountName && account.Password == accountPassword)
                    {
                        Console.Clear();
                        Console.WriteLine($"Success! Welcome {accountName}! \n");
                        currentAccount.Name = accountName;
                        currentAccount.Password = accountPassword;
                    }
                }
                return currentAccount;
            }
            else if (LoginCheck(currentAccount) == false)
            {
                foreach (Account account in listOfAccounts)
                {
                    if (account.Name == accountName && account.Password == accountPassword)
                    {
                        Console.Clear();
                        Console.WriteLine("Someone else is already logged in, switching to your account... ");
                        currentAccount.Name = accountName;
                        currentAccount.Password = accountPassword;
                    }
                }
                return currentAccount;
   
            }
            else
            {
                Console.WriteLine("Error unable to login please try again");
                return currentAccount;
            }
            
        }
        public static Account Logout(Account currentAccount)
        {
            currentAccount.Name = null;
            currentAccount.Password = null;
            currentAccount.Balance = 0;
            return currentAccount;
        }
        public static void CheckBalance(Account currentAccount)
        {
            Console.WriteLine($"Your current balance is: ${ currentAccount.Balance}");
        }
        public static Account Deposit(int userEntry, Account currentAccount)
        {
            currentAccount.Balance = currentAccount.Balance + userEntry;
            return currentAccount;
        }
        public static Account Withdraw(int userEntry, Account currentAccount)
        {
            if(userEntry > currentAccount.Balance)
            {
                Console.WriteLine($"Error you only have ${currentAccount.Balance}");
                return currentAccount;
            }
            else
            {
                currentAccount.Balance = currentAccount.Balance - userEntry;
                Console.WriteLine($"Your new balance is: ${currentAccount.Balance}");
                return currentAccount;
            }
        }
        public static bool LoginCheck(Account currentAccount)
        {
            if (currentAccount.Name == null && currentAccount.Password == null)
            {
                return true;
            }
            else
            { 
                return false; 
            }
        }

    }
}
