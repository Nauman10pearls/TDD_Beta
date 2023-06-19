using TDD;

SavingsAccount account = new SavingsAccount();
account.deposit(10000);
for(int i = 0; i < 60; i++)
{
    Console.WriteLine(i + ": $" + account.balance());
    account = account.nextYear(10);
}