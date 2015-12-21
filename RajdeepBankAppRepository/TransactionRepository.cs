using DomainObjects;
using System.Collections.Generic;
using EntityFrameworkDAL;
using BankAppEntityToDomainMapper;
using System;
using BankAppIRepository;

namespace BankAppEntityFrameworkRepository
{
    public class TransactionRepository : ITransactionRepository
    {
        private TransactionDAL _TransactionDAL;
        public TransactionRepository()
        {
            _TransactionDAL = new TransactionDAL();
        }

        public TransactionRepository(TransactionDAL dal)
        {
            _TransactionDAL = dal;
        }

        public List<TransactionDO> GetAllTransactionDOs()
        {
            return TransactionEntityToDomainMapper.MapList(_TransactionDAL.GetAllTransaction());
        }

        public List<TransactionDO> GetTransactionDOsByUserName(string userName)
        {
            return TransactionEntityToDomainMapper.MapList(_TransactionDAL.GetTransactionByUserName(userName));
        }

        public int SaveNewTransaction(string userName, int amount)
        {
            return _TransactionDAL.SaveNewTransaction(userName, amount);
        }

        public int Transfer(string userNameFrom, string userNameTo, int amountDebit, int amountCredit)
        {
            return _TransactionDAL.Transfer(userNameFrom, userNameTo, amountDebit, amountCredit);
        }
    }
}
