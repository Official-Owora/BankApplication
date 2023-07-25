using BankApplication.Methods;
using BankApplication.Models;

List<User> users = new();
List<Account> accounts = new();
UserMethod userMethod = new(users);

Console.WriteLine("Welcome to Cash BankAPP");
Console.WriteLine($"1. CreateAccount\n2. Login\n3. Deposit\n4. Withdraw\n5. Transfer\n6. Exit");

byte.TryParse(Console.ReadLine(), out byte option);
switch(option)
{
    case 1:
        EnterAccountName();
        break;
    case 2:

}
Account EnterAccountName(string firstName, string lastName, string email, string phoneNumber)
{
    Console.WriteLine("Enter your FirstName and LastName: ");
    string[] nameOfNewAccount = Console.ReadLine().Trim().Split(' ');
    Account account = new Account();
    account.FirstName = nameOfNewAccount[0];
    account.LastName = nameOfNewAccount[1];
    return account;
}

