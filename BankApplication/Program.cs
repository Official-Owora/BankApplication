using BankApplication.Methods;
using BankApplication.Models;
using System.Collections.Generic;

List<User> users = new List<User> 
{
};
List<Account> accounts = new List<Account> 
{ 
};
List<Transactions> transactions = new List<Transactions> 
{ 
};
UserMethod userMethod = new(users);
AccountMethod accountMethod = new(accounts);

while(true)
{
    Console.WriteLine("Welcome to Cash BankAPP");
    Console.WriteLine($"1. OpenAccount\n2. Deposit\n3. Withdraw\n4. Transfer\n5. Check Balance\n6. Exit");

    int enterInput = int.Parse(Console.ReadLine());

    bool check = byte.TryParse(Console.ReadLine(), out byte option);
    if (check == true)
    {
        Console.WriteLine("Your input is valid");
    }
    else if (enterInput < 0 || enterInput > 6)
    {
        Console.WriteLine("Enter a number between 1 - 6");
    }
    else
    {
        switch (option)
        {
            case 1:
                Console.WriteLine("Enter your details to create your account");
                TransactionsMethod.RegisterUser(users, accounts);
                break;
            case 2:
                Console.WriteLine("This is a Deposit Transaction");
                Console.WriteLine("Kindly enter your account Number: ");
                string accountNumber = Console.ReadLine();

                Console.WriteLine("Enter amount to deposit: ");
                decimal inputAmount = decimal.Parse(Console.ReadLine());
                bool enterChecker = Decimal.TryParse(Console.ReadLine(), out decimal depositAmount);
                if (enterChecker == true)
                {
                    TransactionsMethod.Deposit(accountNumber, "transactionDescription", depositAmount, accounts, transactions);
                }
                else
                {
                    Console.WriteLine($"Amount entered is invalid.");
                }
                break;
            case 3:
                Console.WriteLine("This is Withdrawal Transaction");
                Console.WriteLine("Kindly enter your account Number: ");
                string accountsNumber = Console.ReadLine();

                Console.WriteLine("Enter amount to withdraw: ");
                decimal input = Decimal.Parse(Console.ReadLine());
                bool withdrawChecker = Decimal.TryParse(Console.ReadLine(), out decimal withdrawAmount);
                if (withdrawChecker == true)
                {
                    TransactionsMethod.Withdrawal(accountNumber, receiverAccount, withdrawAmount, accounts, transactions);
                }
                else
                {
                    Console.WriteLine($"Amount entered is invalid.");
                }
                break;
            case 4:
                Console.WriteLine("This is a Transfer Transaction");
                Console.WriteLine("Kindly enter sender account number: ");
                string senderAccount = Console.ReadLine();
                Console.WriteLine("Enter receiver account number: ");
                string receiverAccount = Console.ReadLine();

                Console.WriteLine("Enter amount to deposit: ");
                decimal transferAmount = Decimal.Parse(Console.ReadLine());
                bool transferChecker = Decimal.TryParse(Console.ReadLine(), out decimal amountToSend);

                if (transferChecker == false)
                {
                    Console.WriteLine($"Amount entered is invalid.");
                    break;
                }

                TransactionsMethod.Transfer(senderAccount, receiverAccount, amountToSend, "transactionDescription", accounts, transactions);
                break;
            case 5:
                Console.WriteLine("Check Balance");
                Console.WriteLine("Kindly enter your account number: ");
                string accountNumberr = Console.ReadLine();
                TransactionsMethod.Balance(accountNumber, accounts);
                break;

            case 6:
                Console.WriteLine("Enter 6 to exit");
                return;
            default:
                Console.WriteLine("Enter a valid number");
                break;
        }
    }

}
