using BankAppBLLLib;
using BankAppModels;
using System.Collections.Generic;
using System.Web.Http;

namespace RajdeepBankApp.Controllers
{
    public class TransactionController : ApiController
    {
        private ITransactionBLL _transactionBLL;
        public TransactionController()
        {
            _transactionBLL = new TransactionBLL();
        }
        public TransactionController(ITransactionBLL bankAppBLL)
        {
            _transactionBLL = bankAppBLL;
        }
        [HttpPost]
        public int Withdraw(TransactionModel newTransaction)
        {
            return _transactionBLL.Withdraw(newTransaction.UserName, newTransaction.Amount);

        }
        [HttpPost]
        public int Transfer(TransferModel newTransferModel)
        {
            return _transactionBLL.Transfer(newTransferModel.UserNameFrom, newTransferModel.UserNameTo, newTransferModel.Amount);

        }
        [HttpPost]
        public int Diposit(TransactionModel newTransaction)
        {
            return _transactionBLL.Deposit(newTransaction.UserName, newTransaction.Amount);

        }
        [HttpGet]
        public List<TransactionModel> GetStatement([FromUri] string userName)
        {
            if (!string.IsNullOrWhiteSpace(userName))
            {
                return _transactionBLL.GetTransactionByUserName(userName);
            }
            return _transactionBLL.GetAllTransaction();

        }
        public int GetBalance([FromUri] string userName)
        {
            if (!string.IsNullOrWhiteSpace(userName))
            {
                return _transactionBLL.GetBalance(userName);
            }
            return 0;

        }

    }
}
