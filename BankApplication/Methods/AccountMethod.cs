using BankApplication.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace BankApplication.Methods
{
    public class AccountMethod : Account
    {
        public List<Account> Accounts;
        public AccountMethod(List<Account> accounts)
        {
            Accounts = accounts;
        }
        public static Account EnterAccountName(string firstName, string lastName, string email, string phoneNumber)
        {
            Console.WriteLine("Enter your FirstName and LastName: ");
            string[] nameOfNewAccount = Console.ReadLine().Trim().Split(' ');
            Account account = new Account();
            account.FirstName = nameOfNewAccount[0];
            account.LastName = nameOfNewAccount[1];
            return account;
        }

        //6) Method-Name format checker using regex
        public static bool isValidName(string name)
        {
            //Will still check this regular expression
            string strRegex = @"^[A-Z]{1}[a-z]{1,}";

            return Regex.IsMatch(name, strRegex);
        }
        public void PasswordMethod(string password)
        {
            Console.WriteLine("Enter your Password: ");
            Password = Console.ReadLine();

        }

        public string EmailMethod(string email)
        {
            bool isValid = false;
            EmailAddressAttribute emailAddressAttribute = new();
            string emailAddress;
            do
            {
                Console.WriteLine("Enter a valid email address");
                emailAddress = Console.ReadLine();
                isValid = emailAddressAttribute.IsValid(emailAddress);
            }
            while (!isValid);
            return email;
        }
        public static bool isValidEmail(string emailAddress)
        {

            return Regex.IsMatch(emailAddress, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z");
        }

        public string PhoneNumber(string phoneNumber)
        {
            Console.WriteLine("Enter your PhoneNumber: ");
            long.TryParse(Console.ReadLine(), out long PhoneNumber);
            return phoneNumber;
        }

        public static bool isValidMobileNumber(string MobileNumber)
        {
            string strRegex = @"(^+[2-4]{3}-[1-9]{2}-[0-9]{4}-[0-9]{4}$)";

            Regex re = new Regex(strRegex);

            // The IsMatch method is used to validate
            // a string or to ensure that a string
            // conforms to a particular pattern.
            if (re.IsMatch(MobileNumber))
                return true;
            else
                return false;
        }
        public string AccountTypeMethod(string accountType)
        {
            Console.WriteLine("Enter your Account Type: ");
            string AccountType = Console.ReadLine();

            Console.WriteLine("Enter the Minimum Balance: ");
            decimal minimumBalance;

            if (decimal.TryParse(Console.ReadLine(), out minimumBalance))
            {
                string MinimumBalance = (minimumBalance >= 1000) ? "Savings" : "Current";
                Console.WriteLine($"Account Type: {MinimumBalance}");
            }
            else
            {
                Console.WriteLine("Invalid Minimum Balance input. Please enter a valid numeric value.");
            }
            return accountType;

        }
        public string AccountNumberMethod(string accountNumber)
        {
            long AccountNumber = new Random().Next(1124561918, 1993485186);
            string AccountType = "";
            do
            {
                Console.WriteLine("Enter account type. Format: S or C / Savings or Current");
                char value = Console.ReadLine().Trim().ToLower().ToCharArray()[0];
                if (value == 's' || value == 'c')
                    AccountType = value == 's' ? "savings" : "current";
            }
            while (string.IsNullOrWhiteSpace(AccountType));
            return AccountType;

        }
        
    }
}
