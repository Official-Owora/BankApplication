using BankApplication.Models;
using System.ComponentModel.DataAnnotations;

namespace BankApplication.Methods
{
    public class UserMethod
    {
        public List<User> Users;
        public UserMethod(List<User> users)
        {
            Users = users;
        }
        public User CreateANewUser()
        {
            Console.WriteLine("Enter your FirstName and LastName: ");
            string[] nameOfNewUser = Console.ReadLine().Trim().Split(' ');
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
            Console.WriteLine("Enter your PhoneNumber: ");
            long.TryParse(Console.ReadLine(), out long PhoneNumber);
            User user = new User();
            user.FirstName = nameOfNewUser[0];
            user.LastName = nameOfNewUser[1];
            user.EmailAddress = emailAddress;
            Users.Add(user);
            return user;
        }
    }
}
