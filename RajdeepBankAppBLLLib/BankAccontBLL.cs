using BankAppEntityFrameworkRepository;
using System.Collections.Generic;
using BankAppModels;
using BankAppDomainObjectToModelMapper;
using BankAppIRepository;

namespace BankAppBLLLib
{
    public class BankAccontBLL : IBankAccountBLL
    {
        private IBankAccountRepository _repository;
        public BankAccontBLL()
        {
            this._repository = new BankAccountRepository();
        }
        public BankAccontBLL(IBankAccountRepository _repository)
        {
            this._repository = _repository;
        }
        public List<BankAccountModel> GetAllBankAccounts()
        {
            return BankAccountDomainObjectToModelMapper.MapList(_repository.GetBankAccountDOs());
        }
    }
}
