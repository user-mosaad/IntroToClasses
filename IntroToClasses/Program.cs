using Classes;

var account = new BankAccount("Thomas Shelby", 1_000);
Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance:N0} initial balance.");
account.MakeWithdrawal(500, DateTime.Now, "Rent payment");
Console.WriteLine(account.Balance);
account.MakeDeposit(100, DateTime.Now, "Friend paid me back");
Console.WriteLine(account.Balance);
Console.WriteLine(account.GetAccountHistory());

var account2 = new BankAccount("Arthur Shelby", 1_000);
Console.WriteLine($"Account {account2.Number} was created for {account2.Owner} with {account2.Balance:N0} initial balance.");

// Test for a negative balance.
try
{
    account.MakeWithdrawal(750, DateTime.Now, "Attempt to overdraw");
}
catch (InvalidOperationException e)
{
    Console.WriteLine("Exception caught trying to overdraw");
    Console.WriteLine(e.ToString());
}

// Test that the initial balance must be positive.
BankAccount invalidAccount;
try
{
    invalidAccount = new BankAccount("invalid", -55);
}
catch (ArgumentOutOfRangeException e)
{
    Console.WriteLine("Exception caught creating account with negative balance");
    Console.WriteLine(e.ToString());
    return;
}
