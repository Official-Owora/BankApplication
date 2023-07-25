using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace BankApplication.Models
{
    public class Account
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        public decimal AccountBalance { get; set; }
        public string AccountType { get; set; }
        public string AccountNumber { get; set; }
        public decimal MinimumBalance => AccountType == "Savings" ? 1000 : 0;
        List<Transaction> Transactions { get; set; }
    }
}
