using BankAppModels;
using System.Collections.Generic;

namespace BankAppBLLLib
{
    public interface IBankAccountBLL
    {
        List<BankAccountModel> GetAllBankAccounts();
    }
}
