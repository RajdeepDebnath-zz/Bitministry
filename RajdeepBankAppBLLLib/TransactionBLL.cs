using BankAppEntityFrameworkRepository;
using System.Collections.Generic;
using BankAppModels;
using BankAppDomainObjectToModelMapper;
using System.Linq;
using BankAppIRepository;

namespace BankAppBLLLib
{
    public class TransactionBLL : ITransactionBLL
    {
        private ITransactionRepository _repository;
        public TransactionBLL()
        {
            this._repository = new TransactionRepository();
        }
        public TransactionBLL(ITransactionRepository _repository)
        {
            this._repository = _repository;
        }

        public List<TransactionModel> GetAllTransaction()
        {
            return TransactionDomainObjectToModelMapper.MapList(_repository.GetAllTransactionDOs());
        }

        public List<TransactionModel> GetTransactionByUserName(string userName)
        {
            return TransactionDomainObjectToModelMapper.MapList(_repository.GetTransactionDOsByUserName(userName));
        }

        public int Withdraw(string userName, int amount)
        {
            return _repository.SaveNewTransaction(userName, -1*amount);
        }

        public int Deposit(string userName, int amount)
        {
            return _repository.SaveNewTransaction(userName, amount);
        }

        public int Transfer(string userNameFrom, string userNameTo, int amount)
        {
            return _repository.Transfer(userNameFrom, userNameTo, -1*amount, amount);
        }

        public int GetBalance(string userName)
        {
            var transactionList = _repository.GetTransactionDOsByUserName(userName);
            return transactionList.Sum(tran => tran.Amount);
        }
    }
}
