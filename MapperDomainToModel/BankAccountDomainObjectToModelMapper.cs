using DomainObjects;
using System.Collections.Generic;
using System.Linq;
using BankAppModels;

namespace BankAppDomainObjectToModelMapper
{
    public static class BankAccountDomainObjectToModelMapper
    {
        public static BankAccountModel Map(BankAccountDO bankAccountDomainObject)
        {
            return new BankAccountModel
            {
                UserName = bankAccountDomainObject.UserName
            };
        }
        public static List<BankAccountModel> MapList(List<BankAccountDO> bankAccountDomainObjects)
        {
            return (from entity in bankAccountDomainObjects
                   select new BankAccountModel
                   {
                            UserName = entity.UserName
                        }).ToList<BankAccountModel>();
        }
    }
}
