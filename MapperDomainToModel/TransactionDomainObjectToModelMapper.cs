using DomainObjects;
using System.Collections.Generic;
using System.Linq;
using BankAppModels;

namespace BankAppDomainObjectToModelMapper
{
    public static class TransactionDomainObjectToModelMapper
    {
        public static TransactionModel Map(TransactionDO transactionDomainObject)
        {
            return new TransactionModel
            {
                UserName = transactionDomainObject.UserName,
                Amount = transactionDomainObject.Amount
            };
        }
        public static List<TransactionModel> MapList(List<TransactionDO> transactionDomainObjects)
        {
            return (from domain in transactionDomainObjects
                   select new TransactionModel
                   {
                            UserName = domain.UserName,
                            Amount = domain.Amount
                   }).ToList< TransactionModel>();
        }
    }
}
