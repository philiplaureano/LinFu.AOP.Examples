using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SampleLibrary
{
    public class BankAccount
    {
        private int _balance;

        public BankAccount(int balance)
        {
            _balance = balance;
        }

        public int Balance
        {
            get { return _balance; }
        }

        public void Deposit(int amount)
        {
            _balance += amount;

            // The app should crash at this point 
            // if LinFu doesn't intercept the exception
            throw new ApplicationException("Boom!");
        }

        public void Withdraw(int amount)
        {
            _balance -= amount;
        }
    }
}
