namespace BankApplication.Models
{
    public class Transactions
    {
        public string AccountNumber { get; set; }
        public string TransactionDescription { get; set; }
        public string TypeofTransaction { get; set; }
        public string ReceiverAccount { get; set; }
        public string SenderAccount { get; set; }
        public decimal Amount { get; set; }
        public List<Account>Accounts { get; set; }

        public Transactions(string accountNumber, string transactionDescription, decimal amountToWithdraw)
        {
            AccountNumber = accountNumber;
            TransactionDescription = transactionDescription;
            Amount = amountToWithdraw;
        }
    }
}
