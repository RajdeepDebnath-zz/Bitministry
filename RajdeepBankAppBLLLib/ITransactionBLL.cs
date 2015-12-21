using BankAppModels;
using System.Collections.Generic;

namespace BankAppBLLLib
{
    public interface ITransactionBLL
    {
        List<TransactionModel> GetAllTransaction();
        List<TransactionModel> GetTransactionByUserName(string userName);
        int GetBalance(string userName);
        int Withdraw(string userName, int amount);
        int Deposit(string userName, int amount);
        int Transfer(string userNameFrom, string userNameTo, int amount);
    }
}
