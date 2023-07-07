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
        private int interestRate = 0;
        private int totalWithdrawn = 0;


        public SavingsAccountYear(int startingBalance,int Startingprincipal, int InterestRate)
        {
            this.startingbalance = startingBalance;
            this.startingPrincipal = Startingprincipal;
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
            return startingPrincipal;
        }
        public int StartingCapitalGains()
        {
            return startingbalance - startingPrincipal;
        }
        public int InterestRate()
        {
            return interestRate;
        }

        public int InterestEarned(int capitalGainsTaxRate)
        {
            return (startingbalance - TotalWithDrawn() - capitalGainstaxIncurred(capitalGainsTaxRate)) * interestRate /100;
        }

        public int TotalWithdrawnExceptCapitalGainsTax()
        {
            return totalWithdrawn;
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
        public int EndingCapitalGains()
        {
            return 0;
        }
        public int endingBalance(int capitalGainsTaxRate)
        {
            int modifiedStart = startingbalance - TotalWithDrawn() - capitalGainstaxIncurred(capitalGainsTaxRate);
            return modifiedStart + InterestEarned(capitalGainsTaxRate);
        }

        public SavingsAccountYear nextYear(int capitalGainsTaxRate)
        {
            return new  SavingsAccountYear(this.endingBalance(capitalGainsTaxRate),0, interestRate);
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
            double dblTaxRate = taxRate / 100.0;
            double dblCapGains = CapitalGainsWithdrawn();
            return (int)((dblCapGains / (1 - dblTaxRate)) - dblCapGains);
        }

        public int TotalWithDrawn(int capitalGainsTax)
        {
            return TotalWithDrawn() + capitalGainstaxIncurred(capitalGainsTax);
        }
    }
}
