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
        private int v1;
        private int v2;

        public SavingsAccountYear(int startingBalance, int interestRate)
        {
            
        }

        public SavingsAccountYear() 
        {
        }

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

        public SavingsAccountYear nextYear(int interestRate)
        {
            SavingsAccountYear result = new  SavingsAccountYear();
            result.deposit(balance() + (balance() * interestRate / 100));
            return result;
        }
    }
}
