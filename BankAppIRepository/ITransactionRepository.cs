using DomainObjects;
using System.Collections.Generic;

namespace BankAppIRepository
{
    public interface ITransactionRepository
    {
        List<TransactionDO> GetAllTransactionDOs();
        List<TransactionDO> GetTransactionDOsByUserName(string userName);
        int SaveNewTransaction(string userName, int amount);
        int Transfer(string userNameFrom, string userNameTo, int amountDebit, int amountCredit);
    }
}
