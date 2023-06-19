using TDD;

namespace TDD_Unit
{
    [TestClass]
    public class _SavingsAccountYearTest
    {
        [TestMethod]
        public void depositAndWithdarwal()
        {
            SavingsAccountYear account = new SavingsAccountYear();
            account.deposit(100);
            Assert.AreEqual(100, account.balance());
            account.Withdraw(50);
            Assert.AreEqual(50, account.balance());
        }

        [TestMethod]
        public void NegativeBalanceIsjustFine()
        {
            SavingsAccountYear account = new SavingsAccountYear();
            account.Withdraw(75);
            Assert.AreEqual(-75, account.balance());
        }

        [TestMethod]
        public void NextYear()
        {
            SavingsAccountYear account = new SavingsAccountYear();
            account.deposit(10000);
            SavingsAccountYear  nextYear = account.nextYear(10);
            Assert.AreEqual(11000, nextYear.balance());
        }

        [TestMethod]
        public void endingBalance()
        {
            SavingsAccountYear account = new SavingsAccountYear(10000,10);
            Assert.AreEqual(11000, account.endingBalance());
        }
    }
}