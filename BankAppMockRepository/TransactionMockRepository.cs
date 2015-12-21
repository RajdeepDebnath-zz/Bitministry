using System.Collections.Generic;
using BankAppIRepository;
using DomainObjects;

namespace BankAppMockRepository
{
    public class TransactionMockRepository : ITransactionRepository
    {
        public List<TransactionDO> GetAllTransactionDOs()
        {
            return null;
        }

        public List<TransactionDO> GetTransactionDOsByUserName(string userName)
        {
            return null;
        }

        public int SaveNewTransaction(string userName, int amount)
        {
            return 0;
        }

        public int Transfer(string userNameFrom, string userNameTo, int amountDebit, int amountCredit)
        {
            return 0;
        }
    }
}
