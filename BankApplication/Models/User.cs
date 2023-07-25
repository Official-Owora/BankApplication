using System.ComponentModel.DataAnnotations;

namespace BankApplication.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        public List<Account> Accounts { get; set; }

    }
}
