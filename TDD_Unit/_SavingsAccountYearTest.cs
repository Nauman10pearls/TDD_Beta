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
        public void StartingprincipalMatchesConstructor()
        {
            SavingsAccountYear year = new SavingsAccountYear(10000, 3000, 10);
            Assert.AreEqual(3000, year.StartingPrinicipal());
        }

        [TestMethod]
        public void interestRateMatchesConstructor()
        {
            Assert.AreEqual(10, newAccount().InterestRate());
        }

        [TestMethod]
        public void StartingCapitalGainsIsStartingBalanceMinusStartingPrincipal()
        {
            SavingsAccountYear year = new SavingsAccountYear(10000, 3000, 10);
            Assert.AreEqual(7000,year.StartingCapitalGains());
        }
        
        [TestMethod]
        public void endingBalanceAppliesInterestRate()
        {
            Assert.AreEqual(11000, newAccount().endingBalance(25));
        }

        [TestMethod]
        public void EndingPrincipalConisdersWithdrawals()
        {
            SavingsAccountYear year = new SavingsAccountYear(10000, 3000, 10);
            year.Withdraw(2000);
            Assert.AreEqual(1000, year.EndingPrincipal());
        }

        [TestMethod]
        public void EndingPrinicipalNeverGoesBelowZero()
        {
            SavingsAccountYear year = new SavingsAccountYear(10000, 3000, 10);
            year.Withdraw(4000);
            Assert.AreEqual(0, year.EndingPrincipal());
        }

        [TestMethod]
        public void CapitalGainsTaxesDoNotEarnedInterest()
        {
            SavingsAccountYear year = new SavingsAccountYear(10000, 0, 10);
            year.Withdraw(1000);
            Assert.AreEqual(1000, year.CapitalGainsWithdrawn());
            Assert.AreEqual(333, year.capitalGainstaxIncurred(25));
            //Assert.AreEqual(1333,year.TotalWithDrawnIncludingCapitalGains());
            Assert.AreEqual(866, year.InterestEarned(25));
        }

        [TestMethod]
        public void EndingCapitalGainsIncludesInterestEarned()
        {
            SavingsAccountYear year = new SavingsAccountYear(10000, 3000, 10);
            Assert.AreEqual(7000, year.StartingCapitalGains());
            Assert.AreEqual(4000, year.EndingCapitalGains());
        }

        [TestMethod]
        public void InterestEarnedIsStartingBalanceCominedWithInterestRate()
        {
            SavingsAccountYear year = new SavingsAccountYear(10000, 3000, 10);
            Assert.AreEqual(1000, year.InterestEarned(25));
        }

        [TestMethod]
        public void WithDrawnFundsDoNotEarnInterest()
        {
            SavingsAccountYear year = newAccount();
            year.Withdraw(1000);
            Assert.AreEqual(9900,year.InterestEarned(25));
        }

        [TestMethod]
        public void TotalWithDrawnIncludingCapitalGains()
        {
            SavingsAccountYear year = new SavingsAccountYear(10000, 0, 10);
            year.Withdraw(1000);
            Assert.AreEqual(333, year.capitalGainstaxIncurred(25));
            Assert.AreEqual(1333,year.TotalWithDrawnIncludingCapitalGainsWithDrawn(25));
        }

        

        [TestMethod]
        [Ignore]
        public void MultipleWithdrawalsInAYearAreTotaled()
        {
            SavingsAccountYear year = newAccount();
            year.Withdraw(1000);
            year.Withdraw(2000);
            Assert.AreEqual(3000, year.TotalWithDrawn());
        }

        [TestMethod]
        public void WithDrawingMoreThanPrincipalTakesFromCapitalGains()
        {
            SavingsAccountYear year = new SavingsAccountYear(10000, 3000, 10);
            year.Withdraw(1000);
            Assert.AreEqual(0, year.CapitalGainsWithdrawn());
            year.Withdraw(3000);
            Assert.AreEqual(1000,year.CapitalGainsWithdrawn());
        }

        [TestMethod]
        public void CapitalGainsTaxIncurred_NeedsToCoverCapitalGainsWithdrawn_AND_theAdditionalCapitalGainsWithdrawnToPayCapitalGainsTax()
        {
            SavingsAccountYear year = new SavingsAccountYear(10000, 3000, 10);
            year.Withdraw(5000);
            Assert.AreEqual(2000,year.CapitalGainsWithdrawn());
            Assert.AreEqual(666, year.capitalGainstaxIncurred(25));
        }

        [TestMethod]
        public void CapitalGainsTaxIsIncludedInEndingBalance()
        {
            SavingsAccountYear year = new SavingsAccountYear(10000, 3000, 10);
            int amountWithdrawn = 5000;
            year.Withdraw(amountWithdrawn);
            int expectedCapitalGainsTax = 666;
            Assert.AreEqual(expectedCapitalGainsTax, year.capitalGainstaxIncurred(25));
            int expectedStartingBalanceAfterWithDrawals = 10000 - amountWithdrawn - expectedCapitalGainsTax;
            Assert.AreEqual((int)(expectedStartingBalanceAfterWithDrawals * 1.10), year.endingBalance(25));
        }

        //[TestMethod]
        //public void withDrawingMoreThanPrinicipalIncursCapitalgainsTax()
        //{
        //    SavingsAccountYear year = new SavingsAccountYear(10000,3000, 10);
        //    year.Withdraw(3000);
        //    Assert.AreEqual(7700, year.endingBalance());
        //    year.Withdraw(5000);
        //    Assert.AreEqual(2000 + 200 - (1250), year.endingBalance());
        //}

        [TestMethod]
        public void NextYearsStartingBalanceEqualsThisYearEndingBalance()
        {
            SavingsAccountYear thisYear = newAccount();
            Assert.AreEqual(thisYear.endingBalance(25), thisYear.nextYear(25).StartingBalance());
        }

        [TestMethod]
        public void NextYearsInterestRateEqualsThisYearsInterestRate()
        {
            SavingsAccountYear thisYear = newAccount();
            Assert.AreEqual(thisYear.InterestRate(), thisYear.nextYear(25).InterestRate());
        }

        private SavingsAccountYear newAccount()
        {
            SavingsAccountYear account = new SavingsAccountYear(10000,10000, 10);
            return account;
        }

    }
}