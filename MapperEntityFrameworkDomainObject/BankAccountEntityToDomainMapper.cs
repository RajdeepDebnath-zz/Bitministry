using DomainObjects;
using EntityFrameworkDAL;
using System.Collections.Generic;
using System.Linq;

namespace BankAppEntityToDomainMapper
{
    public static class BankAccountEntityToDomainMapper
    {
        public static BankAccountDO Map(BankAccount bankAccountEntity)
        {
            return new BankAccountDO
            {
                UserName = bankAccountEntity.UserName
            };
        }
        public static List<BankAccountDO> MapList(List<BankAccount> bankAccountEntities)
        {
            return (from entity in bankAccountEntities
                   select new  BankAccountDO
                        {
                            UserName = entity.UserName
                        }).ToList<BankAccountDO>();
        }
    }
}
