using DomainObjects;
using System.Collections.Generic;
using EntityFrameworkDAL;
using BankAppEntityToDomainMapper;
using System;
using BankAppIRepository;

namespace BankAppEntityFrameworkRepository
{
    public class BankAccountRepository : IBankAccountRepository
    {
        private BankAccountDAL _BankAccountDAL;
        public BankAccountRepository()
        {
            _BankAccountDAL = new BankAccountDAL();
        }

        public BankAccountRepository(BankAccountDAL dal)
        {
            _BankAccountDAL = dal;
        }

        public List<BankAccountDO> GetBankAccountDOs()
        {
            return BankAccountEntityToDomainMapper.MapList(_BankAccountDAL.GetBankAccounts());
        }
    }
}
