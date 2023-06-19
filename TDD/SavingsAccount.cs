using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD
{
    public class SavingsAccount
    {
        private int balanceamount = 0;
        public void deposit(int amount)
        {
            balanceamount += amount;
        }

        public int balance()
        {
            return balanceamount;
        }

        public void Withdraw(int amount)
        {
            balanceamount -= amount;
        }

        public SavingsAccount nextYear(int interestRate)
        {
            SavingsAccount result = new  SavingsAccount();
            result.deposit(balance() + (balance() * interestRate / 100));
            return result;
        }
    }
}
