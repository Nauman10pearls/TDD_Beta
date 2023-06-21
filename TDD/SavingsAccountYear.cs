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
        private int startingPrincipal = 0;
        private int capitalGainsAmount = 0;
        private int interestRate = 0;
        private int totalWithdrawn = 0;

        public SavingsAccountYear(int startingBalance, int InterestRate)
        {
            this.startingbalance = startingBalance;
            this.interestRate = InterestRate;
        }

        public SavingsAccountYear(int startingBalance,int Startingprincipal, int InterestRate)
        {
            this.startingbalance = startingBalance;
            this.startingPrincipal = Startingprincipal;
            this.capitalGainsAmount = startingbalance - Startingprincipal;
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

        public int TotalWithDrawn()
        {
            return totalWithdrawn;
        }

        public int EndingPrincipal()
        {
            int result =  StartingPrinicipal() - TotalWithDrawn();
            return Math.Max(0, result);
        }
        public int endingBalance(int capitalGainsTaxRate)
        {
            int modifiedStart = startingbalance - TotalWithDrawn() - capitalGainstaxIncurred(capitalGainsTaxRate);
            return modifiedStart + (modifiedStart * interestRate / 100);
        }

        public SavingsAccountYear nextYear(int capitalGainsTaxRate)
        {
            return new  SavingsAccountYear(this.endingBalance(capitalGainsTaxRate), interestRate);
        }

        

        public void Withdraw(int amount)
        {
            this.totalWithdrawn += amount;
        }

        public int CapitalGainsWithdrawn()
        {
            int result =  -1 * (StartingPrinicipal() - TotalWithDrawn());
            return Math.Max(0,result);
        }

        public int capitalGainstaxIncurred(int taxRate)
        {
            return CapitalGainsWithdrawn() * taxRate / 100;
        }
    }
}
