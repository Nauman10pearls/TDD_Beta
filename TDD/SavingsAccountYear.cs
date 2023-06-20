using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD
{
    public class SavingsAccountYear
    {
        private int balanceamount = 0;
        private int interestRate = 0;

        public SavingsAccountYear(int startingBalance, int InterestRate)
        {
            this.balanceamount = startingBalance;
            this.interestRate = InterestRate;
        }

        public SavingsAccountYear() 
        {
        }

        public void deposit(int amount)
        {
            balanceamount += amount;
        }

        public int startingBalance()
        {
            return balanceamount;
        }

        public int balance()
        {
            return balanceamount;
        }

        public void Withdraw(int amount)
        {
            balanceamount -= amount;
        }

        public SavingsAccountYear nextYear()
        {
            return new  SavingsAccountYear(this.endingBalance(), interestRate);
        }

        public int endingBalance()
        {
            return balance() + (balance() * interestRate / 100);
        }

        public int InterestRate()
        {
            return interestRate;
        }
    }
}
