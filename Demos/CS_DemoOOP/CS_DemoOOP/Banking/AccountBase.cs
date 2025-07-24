using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_DemoOOP.Banking
{
    internal abstract class AccountBase
    {
		private string _accountNumber;

		public string AccountNumber
		{
			get { return _accountNumber; }
			set 
			{ 
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException("Account number cannot be null or empty.");
                }
				if (value.Length < 5 || value.Length > 20)
				{
					throw new ArgumentException("Account number must be between 5 and 20 characters long.");
                }
                _accountNumber = value; 
			}
		}

		protected decimal _balance;
		public abstract decimal Balance
		{ get; }

		public abstract void Deposit(decimal amount);
		public abstract void Withdraw(decimal amount);
    }
}
