using BankApplication.Methods;

namespace BankApplicationTest
{
    [TestClass]
    public class BankAppMethodTest
    {
        [TestMethod]
        public void Withdrawal()
        {
            TransactionsMethod service = new();
        }
    }
}