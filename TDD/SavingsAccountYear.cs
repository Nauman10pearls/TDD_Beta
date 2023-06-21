using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD
{
    public class SavingsAccountYear
    {
        private int startingbalance = 0;
        private int capitalGainsAmount = 0;
        private int interestRate = 0;
        private int totalWithdrawn = 0;

        public SavingsAccountYear(int startingBalance, int InterestRate)
        {
            this.startingbalance = startingBalance;
            this.interestRate = InterestRate;
        }

        public SavingsAccountYear(int startingBalance,int CapitalGainsAmount, int InterestRate)
        {
            this.startingbalance = startingBalance;
            this.capitalGainsAmount = CapitalGainsAmount;
            this.interestRate = InterestRate;
        }

        public SavingsAccountYear() 
        {
        }

        public int StartingBalance()
        {
            return startingbalance;
        }
        public int StartingPrinicipal()
        {
            return startingbalance - capitalGainsAmount;
        }
        public int InterestRate()
        {
            return interestRate;
        }

        public int EndingPrincipal()
        {
            int result =  StartingPrinicipal() - totalWithdrawn ;
            return (result < 0) ? 0 : result;
        }
        public int endingBalance()
        {
            int modifiedStart = startingbalance - totalWithdrawn;
            return modifiedStart + (modifiedStart * interestRate / 100);
        }

        public SavingsAccountYear nextYear()
        {
            return new  SavingsAccountYear(this.endingBalance(), interestRate);
        }

        public void Withdraw(int amount)
        {
            this.totalWithdrawn += amount;
        }

        
    }
}
