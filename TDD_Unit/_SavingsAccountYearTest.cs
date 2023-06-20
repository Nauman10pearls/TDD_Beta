using TDD;

namespace TDD_Unit
{
    [TestClass]
    public class _SavingsAccountYearTest
    {
        [TestMethod]
        public void startingBalance()
        {
            SavingsAccountYear account = new SavingsAccountYear(10000,10);
            Assert.AreEqual(10000, account.startingBalance());
        }
        
        [TestMethod]
        public void endingBalance()
        {
            SavingsAccountYear account = new SavingsAccountYear(10000,10);
            Assert.AreEqual(11000, account.endingBalance());
        }


        [TestMethod]
        public void NextYearsStartingBalanceShouldEqualThisYearEndingBalance()
        {
            SavingsAccountYear thisYear = new SavingsAccountYear(10000, 10);
            Assert.AreEqual(thisYear.endingBalance(), thisYear.nextYear().startingBalance());
        }

        [TestMethod]
        public void NextYearsInterestRateEqualsThisYearsInterestRate()
        {
            SavingsAccountYear thisYear = new SavingsAccountYear(10000, 10);
            Assert.AreEqual(thisYear.InterestRate(), thisYear.nextYear().InterestRate());
        }

    }
}