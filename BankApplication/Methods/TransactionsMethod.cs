using BankApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BankApplication.Methods
{
    public class TransactionsMethod
    {
        public static void RegisterUser(List<User>userList, List<Account>accountList)
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
                    checker=false;
                }
                else
                {
                    Console.WriteLine($"{LastName} is invalid");
                }
                checker=true;

            }
            while(checker)
            {
                Console.WriteLine("Enter your Email Address");
                EmailAddress = Console.ReadLine();
                if (AccountMethod.isValidEmail(EmailAddress))
                {
                    Console.WriteLine($"{EmailAddress} is valid");
                    checker=false;
                }
                else
                {
                    Console.WriteLine($"{EmailAddress} is invalid");
                }
                checker=true;

            }
            while(checker)
            {
                Console.WriteLine("Enter your PhoneNumber");
                PhoneNumber = Console.ReadLine();
                if(AccountMethod.isValidMobileNumber(PhoneNumber))
                {
                    Console.WriteLine($"{PhoneNumber} is valid");
                    checker=false;
                }
                else
                {
                    Console.WriteLine($"{PhoneNumber} is invalid");
                }
                checker=true;
            }
            //Accepting Account type
            Console.WriteLine("Enter account type. 'Savings' or 'Current': ");
            AccountType = (Console.ReadLine());

            //Accepting Account type
            Console.WriteLine("Enter your Password: ");
            Password = Console.ReadLine();

            //Use details to create a new customer
            User user = new User(FirstName, LastName, EmailAddress, PhoneNumber);
            //Add new customer to Customer List
            userList.Add(user);

            Account account = new Account()
            {
                FirstName = FirstName,
                LastName = LastName,
                AccountType = AccountType,
                AccountBalance = 0, // Initialize the balance with 0
                AccountNumber = Guid.NewGuid().ToString()
            };

            //use details to create a new account object
            Account account = new Account(FirstName, LastName, EmailAddress, PhoneNumber);

            //To check if account already exists
            AccountMethod.CheckIfAccountExist(account, accountList);

        }
    }
}
