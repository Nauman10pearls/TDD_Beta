using TDD;

namespace TDD_Unit
{
    [TestClass]
    public class _SavingsAccountTest
    {
        [TestMethod]
        public void depositAndWithdarwal()
        {
            SavingsAccount account = new SavingsAccount();
            account.deposit(100);
            Assert.AreEqual(100, account.balance());
            account.Withdraw(50);
            Assert.AreEqual(50, account.balance());
        }

        [TestMethod]
        public void NegativeBalanceIsjustFine()
        {
            SavingsAccount account = new SavingsAccount();
            account.Withdraw(75);
            Assert.AreEqual(-75, account.balance());
        }

        [TestMethod]
        public void NextYear()
        {
            SavingsAccount account = new SavingsAccount();
            account.deposit(10000);
            SavingsAccount  nextYear = account.nextYear(10);
            Assert.AreEqual(11000, nextYear.balance());
        }
    }
}