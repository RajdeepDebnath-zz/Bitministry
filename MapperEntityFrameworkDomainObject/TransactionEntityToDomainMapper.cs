using DomainObjects;
using EntityFrameworkDAL;
using System.Collections.Generic;
using System.Linq;

namespace BankAppEntityToDomainMapper
{
    public static class TransactionEntityToDomainMapper
    {
        public static TransactionDO MapTransaction(Transaction transactionEntity)
        {
            return new TransactionDO
            {
                UserName = transactionEntity.UserName
            };
        }
        public static List<TransactionDO> MapList(List<Transaction> transactionEntities)
        {
            return (from entity in transactionEntities
                    select new TransactionDO
                    {
                        UserName = entity.UserName,
                        Amount = entity.Amount
                    }).ToList<TransactionDO>();
        }
    }
}
