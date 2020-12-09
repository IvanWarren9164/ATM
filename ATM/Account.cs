using System;
using System.Collections.Generic;
using System.IO;

namespace ATM
{
    public class Account
    {
        public Account(string name, string password, int balance)
        {
            _Name = name;
            _Password = password;
            Balance = balance;
        }

        private string _Name = null;
        private string _Password = null;
        public int Balance { get; set; }
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

    }
}
