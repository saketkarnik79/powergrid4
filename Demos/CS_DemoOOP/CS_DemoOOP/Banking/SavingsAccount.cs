using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using CS_DemoOOP.Insurance;

namespace CS_DemoOOP.Banking
{
    internal class SavingsAccount : AccountBase, IInsurance
    {
        public delegate void LowBalanceEventHandler(decimal balance);
        public event LowBalanceEventHandler? LowBalance;

        public override decimal Balance => _balance;

        private decimal _premium;

        public decimal Premium 
        { 
            get => _premium;
            set => _premium = value; 
        }

        public void CalculatePremium()
        {
            _premium=_balance * 0.05m; // Example: Calculate premium as 5% of the balance
            _balance -= _premium; // Example: Deduct 5% of the balance as premium
        }

        public override void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be greater than zero.");
            }
            _balance += amount;
        }

        public override void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be greater than zero.");
            }
            if (amount > _balance)
            {
                //throw new InvalidOperationException("Insufficient funds for withdrawal.");
                LowBalance?.Invoke(_balance);
            }
            else
            {
                _balance -= amount;
            }
        }
    }
}
