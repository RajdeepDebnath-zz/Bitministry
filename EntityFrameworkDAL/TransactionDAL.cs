using System.Collections.Generic;
using System.Linq;

namespace EntityFrameworkDAL
{
    public class TransactionDAL
    {
        public List<Transaction> GetAllTransaction()
        {
            using (var context = new BankDBEntities())
            {
                return context.Set<Transaction>().ToList<Transaction>();
            }
        }
        public List<Transaction> GetTransactionByUserName(string userName)
        {
            using (var context = new BankDBEntities())
            {
                return context.Set<Transaction>().Where( t => t.UserName == userName).ToList<Transaction>();
            }
        }
        public int SaveNewTransaction(string userName, int amount)
        {
            using (var context = new BankDBEntities())
            {
                var bankAccount = context.Set<BankAccount>().Where(user => user.UserName == userName).FirstOrDefault();
                var newTransaction = new Transaction();
                newTransaction.UserName = userName;
                newTransaction.Amount = amount;
                newTransaction.BankAccount = bankAccount;
                context.Transactions.Add(newTransaction);
                return context.SaveChanges();
            }
        }
        public int Transfer(string userNameFrom, string userNameTo, int amountDebit, int amountCredit)
        {
            using (var context = new BankDBEntities())
            {
                var bankAccountDebit = context.Set<BankAccount>().Where(user => user.UserName == userNameFrom).FirstOrDefault();
                var debitTransaction = new Transaction();
                debitTransaction.UserName = userNameFrom;
                debitTransaction.Amount = amountDebit;
                debitTransaction.BankAccount = bankAccountDebit;
                context.Transactions.Add(debitTransaction);

                var bankAccountCredit = context.Set<BankAccount>().Where(user => user.UserName == userNameTo).FirstOrDefault();
                var creditTransaction = new Transaction();
                creditTransaction.UserName = userNameTo;
                creditTransaction.Amount = amountCredit;
                creditTransaction.BankAccount = bankAccountCredit;
                context.Transactions.Add(creditTransaction);

                return context.SaveChanges();
            }
        }
    }
}
