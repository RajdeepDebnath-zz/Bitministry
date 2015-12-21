using DomainObjects;
using System.Collections.Generic;

namespace BankAppIRepository
{
    public interface IBankAccountRepository
    {
        List<BankAccountDO> GetBankAccountDOs();
    }
}
