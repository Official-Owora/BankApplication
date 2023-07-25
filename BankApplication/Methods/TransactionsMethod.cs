using BankApplication.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BankApplication.Methods
{
    public class TransactionsMethod
    {
        private readonly Account _account;
        private readonly User _user;
        private readonly Transactions _transactions;
        public TransactionsMethod(User user, Account account, Transactions transactions)
        {
            _account = account;
            _user = user;
            _transactions = transactions;
        }

        public static void RegisterUser(List<User> Users, List<Account> Accounts)
        {

            bool checker = true;
            string FirstName = string.Empty;
            string LastName = string.Empty;
            string EmailAddress = string.Empty;
            string PhoneNumber = string.Empty;
            string AccountType = string.Empty;
            string Password = string.Empty;

            while (checker)
            {
                Console.WriteLine("Enter your First Name: ");
                FirstName = Console.ReadLine();
                if (AccountMethod.isValidName(FirstName))
                {
                    Console.WriteLine($"{FirstName} is valid");
                    checker = false;
                }
                else
                {
                    Console.WriteLine($"{FirstName} is invalid");

                }
                checker = true;

            }
            while (checker)
            {
                Console.WriteLine("Enter your Last Name: ");
                LastName = Console.ReadLine();
                if (AccountMethod.isValidName(LastName))
                {
                    Console.WriteLine($"{LastName} is valid");
                    checker = false;
                }
                else
                {
                    Console.WriteLine($"{LastName} is invalid");
                }
                checker = true;

            }
            while (checker)
            {
                Console.WriteLine("Enter your Email Address");
                EmailAddress = Console.ReadLine();
                if (AccountMethod.isValidEmail(EmailAddress))
                {
                    Console.WriteLine($"{EmailAddress} is valid");
                    checker = false;
                }
                else
                {
                    Console.WriteLine($"{EmailAddress} is invalid");
                }
                checker = true;

            }
            while (checker)
            {
                Console.WriteLine("Enter your PhoneNumber");
                PhoneNumber = Console.ReadLine();
                if (AccountMethod.isValidMobileNumber(PhoneNumber))
                {
                    Console.WriteLine($"{PhoneNumber} is valid");
                    checker = false;
                }
                else
                {
                    Console.WriteLine($"{PhoneNumber} is invalid");
                }
                checker = true;
            }
            Console.WriteLine("Enter account type. 'Savings' or 'Current': ");
            AccountType = (Console.ReadLine());

            Console.WriteLine("Enter your Password: ");
            Password = Console.ReadLine();

            User user = new User();
            user.FirstName = FirstName;
            user.LastName = LastName;
            user.PhoneNumber = PhoneNumber;
            user.EmailAddress = EmailAddress;
            Users.Add(user);

            Account account = new Account();
            account.FirstName = FirstName;
            account.LastName = LastName;
            account.PhoneNumber = PhoneNumber;
            account.EmailAddress = EmailAddress;
            Accounts.Add(account);

        }
        public static void Withdrawal(string accountNumber, string receiveraccount, decimal amountToWithdraw, string transactionDescription, List<Account> accounts, List<Transactions> transactions)
        {
            bool checker = false;
            foreach (Account accountDetail in accounts)
            {
                if (accountDetail.AccountNumber.Equals(accountNumber))
                {
                    if (accountDetail.AccountBalance - amountToWithdraw >= 1000)
                    {
                        Console.WriteLine("Enter your Paasword");
                        string Password = Console.ReadLine();
                        if (Password.Equals(accountDetail.Password))
                        {
                            accountDetail.AccountBalance -= amountToWithdraw;
                            Console.WriteLine($"Account Balance for {accountDetail.LastName} {accountDetail.FirstName}, with [{accountDetail.AccountNumber}]" + $"is: N{accountDetail.AccountBalance: 2F}");
                            Transactions transaction = new Transactions( accountNumber, transactionDescription, amountToWithdraw);
                            transactions.Add(transaction);
                            checker = true;
                            break;
                        }
                        if (checker == true)
                        {
                            return;
                        }
                    }
                    Console.WriteLine($"Account Details with Account Number: {accountNumber} does not exist");
                }
            }

        }
        public static void Deposit(string accountNumber, string transactionDescription, decimal accountBalance, List<Account> accounts, List<Transactions> transactions)
        {
            bool checker = false;
            foreach (Account accountDetail in accounts)
            {
                if (accountDetail.AccountNumber.Equals(accountNumber))
                {
                    accountDetail.AccountBalance += accountBalance;
                    Console.WriteLine($"Account balance for {accountDetail.LastName} {accountDetail.FirstName} with [{accountDetail.AccountNumber}]" + $" is: N{accountDetail.AccountBalance}");
                    Transactions transaction = new Transactions(accountNumber, transactionDescription, accountBalance);
                    transactions.Add(transaction);
                    checker = true;
                    break;
                }
                if (checker == true)
                {
                    return;
                }

            }
            Console.WriteLine($"Account Detail with Account Number: {accountNumber} does not exist");
        }
        public static void Tranfer(string senderAccount, string receiverAccount, decimal amount, string transactionDescription, List<Account> accounts, List<Transactions> transactions)
        {
            Withdrawal(senderAccount, receiverAccount, amount, transactionDescription,  accounts, transactions);
            Deposit(receiverAccount, transactionDescription, amount, accounts, transactions);
            Console.WriteLine(transactionDescription);
        }
        public static void Balance(string accountNumber, List<Account> accountList)
        {
            bool checker = false;
            foreach (Account accountDetail in accountList)
            {
                if (accountDetail.AccountNumber.Equals(accountNumber))
                {
                    Console.WriteLine("Enter your Passward");
                    string? Password = Console.ReadLine();
                    if (Password.Equals(accountDetail.Password))
                    {
                        Console.WriteLine($"Account Details: \n Account Name {accountDetail.LastName} {accountDetail.FirstName}" + $"\n Account Number {accountDetail.AccountNumber} \n Account Balance {accountDetail.AccountBalance}");
                        checker = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Password is invalid: {Password}");
                    }

                }
                if (checker == true)
                    return;
            }
            Console.WriteLine($"Account Number: {accountNumber} is invalid");
        }
    }
}
