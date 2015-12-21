using System.Collections.Generic;
using System.Linq;

namespace EntityFrameworkDAL
{
    public class BankAccountDAL
    {
        public List<BankAccount> GetBankAccounts()
        {
            using (var context = new BankDBEntities())
            {
                return context.Set<BankAccount>().ToList<BankAccount>();
            }
        }
    }
}
