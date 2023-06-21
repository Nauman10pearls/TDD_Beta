using TDD;

namespace TDD_Unit
{
    [TestClass]
    public class _SavingsAccountYearTest
    {
        [TestMethod]
        public void startingBalanceMatchesConstructor()
        {
            
            Assert.AreEqual(10000, newAccount().StartingBalance());
        }

        [TestMethod]
        public void interestRateMatchesConstructor()
        {
            Assert.AreEqual(10, newAccount().InterestRate());
        }
        
        [TestMethod]
        public void endingBalanceAppliesInterestRate()
        {
            Assert.AreEqual(11000, newAccount().endingBalance());
        }


        [TestMethod]
        public void NextYearsStartingBalanceEqualsThisYearEndingBalance()
        {
            SavingsAccountYear thisYear = newAccount();
            Assert.AreEqual(thisYear.endingBalance(), thisYear.nextYear().StartingBalance());
        }

        [TestMethod]
        public void NextYearsInterestRateEqualsThisYearsInterestRate()
        {
            SavingsAccountYear thisYear = newAccount();
            Assert.AreEqual(thisYear.InterestRate(), thisYear.nextYear().InterestRate());
        }

        [TestMethod]
        public void WithdrawingFundsOccuringAtTheBeginningOfTheYear()
        {
            SavingsAccountYear year = new SavingsAccountYear(10000, 10);
            year.Withdraw(1000);
            Assert.AreEqual(9900,year.endingBalance());
        }

        [TestMethod]
        public void MultipleWithdrawalsInAYear()
        {
            SavingsAccountYear year = new SavingsAccountYear(10000, 10);
            year.Withdraw(1000);
            year.Withdraw(2000);
            Assert.AreEqual(7700, year.endingBalance());
        }

        [TestMethod]
        public void Startingprincipal()
        {
            SavingsAccountYear year = new SavingsAccountYear(10000, 7000, 10);
            Assert.AreEqual(3000,year.StartingPrinicipal());
        }
        [TestMethod]
        public void EndingPrincipal()
        {
            SavingsAccountYear year = new SavingsAccountYear(10000, 7000, 10);
            Assert.AreEqual(3000, year.StartingPrinicipal());
            year.Withdraw(2000);
            Assert.AreEqual(1000, year.EndingPrincipal());
        }

        [TestMethod]
        public void EndingPrinicipalNeverGoesBelowZero()
        {
            SavingsAccountYear year = new SavingsAccountYear(10000, 7000, 10);
            Assert.AreEqual(3000, year.StartingPrinicipal());
            year.Withdraw(4000);
            Assert.AreEqual(0, year.EndingPrincipal());
        }

        

        //[TestMethod]
        //public void withDrawingMoreThanPrinicipalIncursCapitalgainsTax()
        //{
        //    SavingsAccountYear year = new SavingsAccountYear(10000,7000, 10);
        //    year.Withdraw(3000);
        //    Assert.AreEqual(7700, year.endingBalance());
        //    year.Withdraw(5000);
        //    Assert.AreEqual(2000 + 200 - (1250), year.endingBalance());
        //}

        private SavingsAccountYear newAccount()
        {
            SavingsAccountYear account = new SavingsAccountYear(10000, 10);
            return account;
        }

    }
}