using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Models
{
    public class Transactions
    {
        public string AccountNumber { get; set; }
        public string TransactionDescription { get; set; }
        public string TypeofTransaction { get; set; }
        public string ReceiverAccountNumber { get; set; }
        public string SourceAccountNumber { get; set; }
        public decimal Amount { get; set; }
    }
}
